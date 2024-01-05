#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using System.Collections.Generic;

using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Mesh.Test;
using Goedel.Protocol;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;

//#pragma warning disable IDE0059
//#pragma warning disable CA1822

namespace Goedel.XUnit;



public partial class TestService {

    // Task: Verify.
    // Task: Sign

    // Verify: Validate device profile signature
    // Verify: Validate mesh profile signature
    // Verify: Validate contact signature

    // Sign: Sequence updates

    // Encrypt: Encrypt credential entry
    // Encrypt: Encrypt contact request
    // Encrypt: Encrypt connection request
    // Encrypt: Encrypt confirmation request

    static TestService() => Goedel.Cryptography.Core.Initialization.Initialized.TestTrue();




    public string DeviceServiceRegistry = "Service Registry";
    public string DeviceServiceResolver = "Service Resolver";
    public string DeviceServiceCarnet = "Service Carnet";
    public string DeviceServicePresence = "Service Presence";
    public string DeviceServiceRepository = "Service Repository";




    static readonly string AccountGroup = "groupw@example.com";

    public static Contact ContactAlice => MeshMachineTest.ContactAlice;
    public static Contact ContactBob => MeshMachineTest.ContactBob;

    readonly CatalogedCredential password1 = new() {
        Username = "fred",
        Password = "password",
        Service = "example.com"
        };
    readonly CatalogedCredential password2 = new() {
        Username = "fred",
        Password = "password",
        Service = "example.net"
        };



    [Fact]
    public void ProtocolHello() {
        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var machineAdminAlice = new MeshMachineTest(testEnvironmentCommon, DeviceAliceAdmin);


        var profileDevice = ProfileDevice.Generate();

        var credentialTemp =
                new MeshCredentialPrivate(profileDevice, null, null,
                    profileDevice.KeyAuthentication as KeyPairAdvanced);

        var meshClient = machineAdminAlice.GetMeshClient(credentialTemp, ServiceName);

        var request = new HelloRequest();
        var response = meshClient.Hello(request);
        response.Success().TestTrue();
        }


    [Fact]
    public void MeshServiceEncryptCredential() {
        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var machineAdminAlice = new MeshMachineTest(testEnvironmentCommon, DeviceAliceAdmin);
        var machineAdminBob = new MeshMachineTest(testEnvironmentCommon, DeviceBobAdmin);

        // first device
        var contextAccountAlice_1_a = machineAdminAlice.MeshHost.ConfigureMeshAsync(AccountAlice, "personal").Sync();
        contextAccountAlice_1_a.SetContactSelfAsync(ContactAlice).Sync();

        var profileAlice = contextAccountAlice_1_a.ProfileUser;

        using (var transaction1 = contextAccountAlice_1_a.TransactBegin()) {
            var catalogCredential = transaction1.GetCatalogCredential();
            transaction1.CatalogUpdate(catalogCredential, password1);
            transaction1.TransactAsync().Sync();


            VerifyStoreEncrypted(catalogCredential, profileAlice.AccountEncryptionKey);
            catalogCredential.Dump();
            }


        // second device
        var machineAlice2 = new MeshMachineTest(testEnvironmentCommon, DeviceAlice2);
        var boundPin = contextAccountAlice_1_a.GetPinAsync(MeshConstants.MessagePINActionDevice).Sync();
        var contextAccountAlice_2 = machineAlice2.MeshHost.ConnectAsync(AccountAlice, pin: boundPin.Pin).Sync();
        var sync = contextAccountAlice_1_a.SynchronizeAsync().Sync();
        var connectRequest = contextAccountAlice_1_a.GetPendingMessageConnectionRequest();
        contextAccountAlice_1_a.ProcessAsync(connectRequest, roles: RightsDirect).Sync();
        contextAccountAlice_2.CompleteAsync().Sync();


        CheckPinMessageSignedEncrypted(contextAccountAlice_1_a);
        }




    [Fact]
    public void MeshServiceFull() {
        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var machineAdminAlice = new MeshMachineTest(testEnvironmentCommon, DeviceAliceAdmin);
        var machineAdminBob = new MeshMachineTest(testEnvironmentCommon, DeviceBobAdmin);


        machineAdminAlice.CheckHostCatalogExtended();


        // Create a presonal mesh 
        var contextAccountAlice_1_a = machineAdminAlice.MeshHost.ConfigureMeshAsync(AccountAlice, "personal").Sync();
        machineAdminAlice.CheckHostCatalogExtended();


        // Perform some offline operations on the account catalogs
        contextAccountAlice_1_a.SetContactSelfAsync(ContactAlice).Sync();

        // Check we can read the data from a second context
        var contextAccountAlice_1_b = machineAdminAlice.GetContextAccount();
        Verify(contextAccountAlice_1_a, contextAccountAlice_1_b);

        // Check that we can read back from the data stored on disk.
        var machineAdmin_3 = new MeshMachineTest(testEnvironmentCommon, DeviceAliceAdmin);
        var contextAccountAlice_1_c = machineAdmin_3.GetContextAccount();


        // ****  Multiple device tests

        // Connect a second device using the PIN connection mechanism
        var machineAlice2 = new MeshMachineTest(testEnvironmentCommon, DeviceAlice2);
        machineAlice2.CheckHostCatalogExtended(); // initial

        var boundPin = contextAccountAlice_1_a.GetPinAsync(MeshConstants.MessagePINActionDevice).Sync();
        var contextAccountAlice_2 = machineAlice2.MeshHost.ConnectAsync(AccountAlice, pin: boundPin.Pin).Sync();
        machineAlice2.CheckHostCatalogExtended(); // Connect pending

        // Still have to process of course to get the data
        var sync = contextAccountAlice_1_a.SynchronizeAsync().Sync();


        var connectRequest = contextAccountAlice_1_a.GetPendingMessageConnectionRequest();
        contextAccountAlice_1_a.ProcessAsync(connectRequest, roles: RightsDirect).Sync();

        contextAccountAlice_2.CompleteAsync().Sync();
        machineAlice2.CheckHostCatalogExtended(); // Complete


        // Do some catalog updates and check the results

        using (var transaction1 = contextAccountAlice_1_a.TransactBegin()) {
            var catalogCredential = transaction1.GetCatalogCredential();
            transaction1.CatalogUpdate(catalogCredential, password1);
            transaction1.TransactAsync().Sync();


            catalogCredential.Dump();
            }

        // Connect a third device by approving a request
        var machineAlice3 = new MeshMachineTest(testEnvironmentCommon, DeviceAlice3);
        var contextAccount3 = machineAlice3.MeshHost.ConnectAsync(AccountAlice).Sync();

        sync = contextAccountAlice_1_a.SynchronizeAsync().Sync();
        var connectRequest3 = contextAccountAlice_1_a.GetPendingMessageConnectionRequest();
        contextAccountAlice_1_a.ProcessAsync(connectRequest3, roles: RightsThreshold).Sync();

        contextAccount3.CompleteAsync().Sync();


        // Do some catalog updates and check the results
        using (var transaction1 = contextAccountAlice_1_a.TransactBegin()) {
            var catalogCredential = transaction1.GetCatalogCredential();
            transaction1.CatalogUpdate(catalogCredential, password2);
            transaction1.TransactAsync().Sync();
            }

        // Check message handling - introduce Bob
        var contextAccountBob = machineAdminBob.MeshHost.ConfigureMeshAsync(AccountBob, "personal").Sync();


        //var contactCatalogBob = contextAccountBob.GetCatalogContact();
        contextAccountBob.SetContactSelfAsync(ContactBob).Sync();

        // **** Contact testing
        contextAccountBob.ContactRequestAsync(AccountAlice).Sync();

        sync = contextAccountAlice_1_a.SynchronizeAsync().Sync();
        var contactRequest = contextAccountAlice_1_a.GetPendingMessageContactRequest();
        contextAccountAlice_1_a.ProcessAsync(contactRequest).Sync();

        // GetUnique the response back
        sync = contextAccountBob.SynchronizeAsync().Sync();
        var contactResponseBob = contextAccountBob.GetPendingMessageContactRequest();

        contextAccountBob.ProcessAsync(contactResponseBob).Sync();


        //// **** Confirmation testing

        // Ask Alice to add our credential
        contextAccountBob.ConfirmationRequestAsync(AccountAlice, "Dinner tonight").Sync();

        sync = contextAccountAlice_1_a.SynchronizeAsync().Sync();
        var confirmRequest = contextAccountAlice_1_a.GetPendingMessageConfirmationRequest();
        contextAccountAlice_1_a.ProcessAsync(confirmRequest).Sync();

        // GetUnique the response back
        sync = contextAccountBob.SynchronizeAsync().Sync();
        var confirmResponseBob = contextAccountBob.GetPendingMessageConfirmationResponse();
        contextAccountAlice_1_a.ProcessAsync(confirmResponseBob).Sync();
        }







    /// <summary>
    /// Connect a device by approving a request
    /// </summary>
    [Fact]
    public void MeshDeviceConnectApprove() {
        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");

        // New Device
        var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice3,
                AccountAlice);

        // Admin Device
        contextAccountAlice.SynchronizeAsync().Sync();
        var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
        contextAccountAlice.ProcessAsync(connectRequest, roles: RightsDirect).Sync();

        // Check second device
        var contextOnboarded = TestCompletionSuccess(contextOnboardPending);
        ExerciseAccount(contextOnboarded);
        }


    /// <summary>
    /// Connect a second device using the PIN connection mechanism
    /// </summary>
    [Fact]
    public void MeshDeviceConnectPIN() {
        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAdmin = MeshMachineTest.GenerateAccountUser(
            testEnvironmentCommon, DeviceAliceAdmin, AccountAlice, "main");

        // Admin Device
        var boundPin = contextAdmin.GetPinAsync(MeshConstants.MessagePINActionDevice, roles: RightsDirect).Sync();
        ReportDevices(contextAdmin);

        // New Device
        var contextOnboarding = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice2,
            AccountAlice, PIN: boundPin.Pin);

        // Admin Device
        ProcessAutomatics(contextAdmin);

        // Check second device
        var contextOnboarded = TestCompletionSuccess(contextOnboarding);
        ExerciseAccount(contextOnboarded);
        }


    /// <summary>
    /// Connect a second device using the Dynamic QR connection mechanism
    /// </summary>
    [Fact]
    public void MeshDeviceConnectDynamicQR() {
        var testEnvironmentCommon = GetTestEnvironmentCommon();

        var contextAdmin = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon, DeviceAliceAdmin, AccountAlice,
            "main");

        // Create the QR Code with PIN
        var boundPin = contextAdmin.GetPinAsync(MeshConstants.MessagePINActionDevice, roles: RightsDirect).Sync();
        var connectUri = MeshUri.ConnectUriDevice(contextAdmin.ServiceAddress, boundPin.Pin);

        ReportDevices(contextAdmin);

        // Present the QR code URI
        var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice2, connectUri);

        // Admin Device
        ProcessAutomatics(contextAdmin);

        // Check second device
        var contextOnboarded = TestCompletionSuccess(contextOnboardPending);
        ExerciseAccount(contextOnboarded);
        }


    /// <summary>
    /// Connect a second device using the Dynamic QR connection mechanism
    /// </summary>
    [Fact]
    public void MeshDeviceConnectStaticQR() {
        var testEnvironmentCommon = GetTestEnvironmentCommon();


        var contextQ = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon, DeviceQ, AccountQ,
            "main");
        var contextAdmin = MeshMachineTest.GenerateAccountUser(
            testEnvironmentCommon, DeviceAliceAdmin, AccountAlice, "main");

        var DeviceOnboarding = new MeshMachineTest(testEnvironmentCommon, DeviceAlice2);

        // Generate the profile and install it on the device
        var preconfig = contextQ.Preconfigure();

        var filename = preconfig.Filename;
        var profileDevice = preconfig.ProfileDevice;
        var connectUri = preconfig.ConnectUri;

        var contextOnboardPreconfigured = DeviceOnboarding.Install(filename);

        contextAdmin.ConnectStaticUriAsync(connectUri, RightsDirect).Sync();

        // Attempt to 
        var contextOnboardPending = contextOnboardPreconfigured.PollAsync().Sync();

        // Check second device
        var contextOnboarded = TestCompletionSuccess(contextOnboardPending);
        ExerciseAccount(contextOnboarded);

        }



    [Fact]
    public void MeshEscrowRecover() {

        // Create mesh
        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAliceOriginal = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");

        // create key shares
        var shares = contextAliceOriginal.Escrow(3, 2);

        // Recover on different device from key shares
        var recoveryMachine = new MeshMachineTest(testEnvironmentCommon, DeviceAlice2);

        // create key shares
        var recoveryShares = new List<string> { shares[0].UDFKey, shares[1].UDFKey };
        var secret = new SharedSecret(recoveryShares);

        var accountSeed = new PrivateKeyUDF(secret.UDFKey);
        var recoveredAccount = recoveryMachine.MeshHost.ConfigureMeshAsync(AccountAlice,
                    accountSeed: accountSeed, create: false).Sync();

        // delete seed
        contextAliceOriginal.EraseMeshSecret();

        // FAIL: create key shares 2

        Xunit.Assert.Throws<NoMeshSecret>(
            () => contextAliceOriginal.Escrow(3, 2));

        // Recover to new service


        contextAliceOriginal.ProfileUser.UdfString.TestEqual(recoveredAccount.ProfileUser.UdfString);


        }


    [Fact]
    public void MeshCreateAdmin() {
        var (context1, context2) = CreateConnectGrant("/admin");
        CanAdmin(context2).TestTrue();
        }

    [Fact]
    public void MeshGrantAdmin() {
        var (context1, context2) = CreateConnectGrant("");
        //CanAdmin(context2).TestFalse();

        // grant role
        CanAdmin(context2).TestTrue();
        }

    static bool CanAdmin(ContextUser contextUser) => true;


    (ContextUser, ContextUser) CreateConnectGrant(string roles) {

        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");

        // New Device
        var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice3,
                AccountAlice, "device2");

        // Admin Device
        contextAccountAlice.SynchronizeAsync().Sync();
        var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
        contextAccountAlice.ProcessAsync(connectRequest, roles: RightsDirect).Sync();

        // Check second device
        var contextOnboarded = TestCompletionSuccess(contextOnboardPending);

        return (contextAccountAlice, contextOnboarded);
        }

    /// <summary>
    /// Test that attempts by Mallet to read Alice's private catalogs fail.
    /// </summary>
    /// <exception cref="NYI"></exception>
    [Fact(Skip = "Not yet implemented")]
    public void MalletCatalogReadFail() {
        throw new NYI();
        }

    [Fact]
    public void MeshCatalogAccount() {
        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");
        }

    [Fact]
    public void MeshCatalogMultipleDevice() {
        // Test service, devices for Alice, Bob
        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");
        }

    [Fact]
    public void MeshMessageContact() {
        // Test service, devices for Alice, Bob
        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");
        var contextAccountBob = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceBobAdmin, AccountBob, "main");


        contextAccountBob.ContactRequestAsync(AccountAlice).Sync();

        // Alice ---> Bob
        var sync = contextAccountAlice.SynchronizeAsync().Sync();

        var fromBob = contextAccountAlice.GetPendingMessageContactRequest();
        contextAccountAlice.ProcessAsync(fromBob).Sync();

        // Bob
        var syncBob = contextAccountBob.SynchronizeAsync().Sync();

        var fromAlice = contextAccountBob.GetPendingMessageContactRequest();


        contextAccountBob.ProcessAsync(fromAlice).Sync();

        (fromBob as MessageContact).Reply.TestTrue();
        (fromAlice as MessageContact).Reply.TestFalse();

        "Add checks to see that each has the contact info of the other in their catalog".TaskTest();
        }

    [Fact]
    public void MeshMessageConfirm() {
        // Test service, devices for Alice, Bob
        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");
        var contextAccountBob = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceBobAdmin, AccountBob, "main");

        // Bob ---> Alice
        contextAccountBob.ConfirmationRequestAsync(AccountAlice, "Open the pod bay doors").Sync();

        // Alice ---> Bob
        var sync = contextAccountAlice.SynchronizeAsync().Sync();
        var fromBob = contextAccountAlice.GetPendingMessageConfirmationRequest();
        contextAccountAlice.ProcessAsync(fromBob).Sync();

        // Bob
        var syncBob = contextAccountBob.SynchronizeAsync().Sync();
        var fromAlice = contextAccountBob.GetPendingMessageConfirmationResponse();
        contextAccountAlice.ProcessAsync(fromAlice).Sync();
        }


    public static bool Exchange(ContextUser contextAccountAlice, ContextUser contextAccountBob) {
        contextAccountBob.ContactRequestAsync(AccountAlice).Sync();
        var sync = contextAccountAlice.SynchronizeAsync().Sync();


        var fromBob = contextAccountAlice.GetPendingMessageContactRequest();
        contextAccountAlice.ProcessAsync(fromBob).Sync();
        var syncBob = contextAccountBob.SynchronizeAsync().Sync();

        var fromAlice = contextAccountBob.GetPendingMessageContactRequest();
        contextAccountBob.ProcessAsync(fromAlice).Sync();

        return true;
        }






    [Fact]
    public void MeshCatalogGroup() {
        var testEnvironmentCommon = GetTestEnvironmentCommon();
        var plaintext = Platform.GetRandomBytes(1000);

        var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceAliceAdmin, AccountAlice, "main");
        var contextAccountBob = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                DeviceBobAdmin, AccountBob, "main");

        Exchange(contextAccountAlice, contextAccountBob);

        // Generate a recryption group
        var contextGroup = contextAccountAlice.CreateGroupAsync(AccountGroup, roles: RightsDirect).Sync();

        var groupList = new List<string>() { AccountGroup };
        // Encrypt to the group
        var envelope = contextAccountAlice.DareEncode(plaintext, recipients: groupList, sign: true);

        Xunit.Assert.Throws<NoAvailableDecryptionKey>(() =>
            contextAccountAlice.DareDecode(envelope, verify: true));

        // Create a member entry for Alice
        contextGroup.Add(AccountAlice);
        contextAccountAlice.SynchronizeAsync().Sync();
        contextAccountAlice.ProcessAutomaticsAsync().Sync();

        // need to sync messages here to accept the group addition.

        // this should now succeed
        var decrypt2 = contextAccountAlice.DareDecode(envelope, verify: true);
        decrypt2.IsEqualTo(plaintext).TestTrue();

        Xunit.Assert.Throws<NoAvailableDecryptionKey>(() =>
          contextAccountBob.DareDecode(envelope, verify: true));

        // Create a member entry fo Bob
        contextGroup.Add(AccountBob);

        var decrypt3 = contextAccountAlice.DareDecode(envelope, verify: true);
        decrypt3.IsEqualTo(plaintext).TestTrue();

        // this is going to be failing because Bob has to get and process the contact request.
        contextAccountBob.SynchronizeAsync().Sync();
        contextAccountBob.ProcessAutomaticsAsync().Sync();


        var decrypt4 = contextAccountBob.DareDecode(envelope, verify: true);
        decrypt4.IsEqualTo(plaintext).TestTrue();

        // Create a member entry fo Bob
        contextGroup.DeleteAsync(AccountBob).Sync();

        var decrypt5 = contextAccountAlice.DareDecode(envelope, verify: true);
        decrypt5.IsEqualTo(plaintext).TestTrue();


        Xunit.Assert.Throws<CryptographicOperationRefused>(() =>
          contextAccountBob.DareDecode(envelope, verify: true));



        System.Threading.Thread.Sleep(2000);

        // Create a member entry fo Bob
        contextGroup.Add(AccountBob);
        // this is going to be failing because Bob has to get and process the contact request.
        contextAccountBob.SynchronizeAsync().Sync();
        contextAccountBob.ProcessAutomaticsAsync().Sync();

        var decrypt6 = contextAccountBob.DareDecode(envelope, verify: true);
        decrypt6.IsEqualTo(plaintext).TestTrue();
        }
 

    static void CheckPinMessageSignedEncrypted(ContextUser contextUser) {

        var spoolLocal = contextUser.GetStore(SpoolLocal.Label) as SpoolLocal;
        VerifyStoreEncrypted(spoolLocal);
        }



    #region // helper routines

    static void ReportDevices(ContextUser contextUser) {
        var catalogDevice = contextUser.GetStore(CatalogDevice.Label) as CatalogDevice;

        Screen.WriteInfo("");
        Screen.WriteInfo(catalogDevice.Report());

        }

    /// <summary>
    /// Exercise the account to verify functionality. Currently a stub.
    /// </summary>
    /// <param name="contextUser">The context to exercise the account from.</param>
    static void ExerciseAccount(ContextUser contextUser) => contextUser.Future();

    static List<ProcessResult> ProcessAutomatics(ContextUser contextUser) {
        contextUser.SynchronizeAsync().Sync();
        return contextUser.ProcessAutomaticsAsync().Sync();
        }

    static ContextUser TestCompletionSuccess(ContextMeshPending contextMeshPending) {
        var contextUser = contextMeshPending.CompleteAsync().Sync();
        contextUser.SynchronizeAsync().Sync(); // Will fail if cannot complete

        return contextUser;
        }



    public static bool VerifyContainers(ContextUser contextUser) {

        var profileuser = contextUser.ProfileUser;
        using (var transaction1 = contextUser.TransactBegin()) {
            VerifyStoreEncrypted(transaction1.GetCatalogApplication(),
                            profileuser.AccountEncryptionKey);
            VerifyStoreEncrypted(transaction1.GetCatalogDevice(),
                            profileuser.AccountEncryptionKey);
            VerifyStoreEncrypted(transaction1.GetCatalogContact(),
                            profileuser.AccountEncryptionKey);
            VerifyStoreEncrypted(transaction1.GetCatalogCredential(),
                            profileuser.AccountEncryptionKey);
            VerifyStoreEncrypted(transaction1.GetCatalogBookmark(),
                            profileuser.AccountEncryptionKey);
            VerifyStoreEncrypted(transaction1.GetCatalogCalendar(),
                            profileuser.AccountEncryptionKey);
            VerifyStoreEncrypted(transaction1.GetCatalogNetwork(),
                            profileuser.AccountEncryptionKey);
            }


        return true;
        }

    static bool VerifyStoreEncrypted(
                Store container,
                KeyPair encryptionKey = null) =>
        VerifyContainerEncrypted(container.Sequence, encryptionKey);

    static bool VerifyContainerEncrypted(Goedel.Cryptography.Dare.Sequence container,
                KeyPair encryptionKey = null) {


        foreach (var envelope in container) {
            (envelope.Header?.EncryptionAlgorithm).TestNotNull(); // envelope must be encrypted.

            }


        return true;
        }

    static bool Verify(ContextUser first, ContextUser second) {
        //(first.ProfileDevice.UDF == second.ProfileDevice.UDF).AssertTrue();

        Verify(first.ActivationAccount, second.ActivationAccount);
        Verify(first.ProfileUser, second.ProfileUser);
        (first.StoresDirectory == second.StoresDirectory).TestTrue();
        return true;
        }

    static bool Verify(ActivationAccount first, ActivationAccount second) {
        //Verify(first.ConnectionAccount, second.ConnectionAccount);
        (first.AccountUdf == second.AccountUdf).TestTrue();
        return true;
        }

    static bool Verify(ProfileUser first, ProfileUser second) {
        (first.CommonEncryption.Udf == second.CommonEncryption.Udf).TestTrue();
        (first.UdfString == second.UdfString).TestTrue();
        return true;
        }

    public static bool Verify(ConnectionDevice first, ConnectionDevice second) {
        (first.Signature.Udf == second.Signature.Udf).TestTrue();
        (first.Encryption.Udf == second.Encryption.Udf).TestTrue();
        (first.Authentication.Udf == second.Authentication.Udf).TestTrue();
        return true;
        }

    public static bool Verify(ConnectionService first, ConnectionService second) {
        (first.Authentication.Udf == second.Authentication.Udf).TestTrue();
        return true;
        }

    #endregion
    }
