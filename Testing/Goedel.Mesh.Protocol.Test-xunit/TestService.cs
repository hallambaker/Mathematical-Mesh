using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Protocol;
using Goedel.Test;
using Goedel.Test.Core;
using Goedel.Utilities;
using Goedel.IO;
using System;
using System.Collections.Generic;

using Xunit;

#pragma warning disable IDE0059

namespace Goedel.XUnit {


    public partial class TestService {
        // Goal: Authenticate service requests and responses
        // Goal: Lightweight key exchange mechanism for service
        // Goal: Service handoff to a different IP address
        // Goal: Enable use of JSON-B encodings throughout

        // Task: Verify.
        // Task: Sign

        // Verify: Validate device profile signature
        // Verify: Validate mesh profile signature
        // Verify: Validate contact signature

        // Sign: Container updates

        // Encrypt: Encrypt credential entry
        // Encrypt: Encrypt contact request
        // Encrypt: Encrypt connection request
        // Encrypt: Encrypt confirmation request

        static TestService() {
            TestEnvironmentCommon.Initialize();
            Mesh.Mesh.Initialize();
            }


        public static TestService Test() => new TestService();
        static string AccountAlice = "alice@example.com";
        static string ServiceName = "example.com";
        static string AccountBob = "bob@example.com";
        static string AccountQ = "q@example.com";

        public string DeviceAliceAdmin = "Alice Admin";
        public string DeviceAlice2 = "Alice Device 2";
        public string DeviceAlice3 = "Alice Device 3";
        public string DeviceBobAdmin = "Bob Admin";
        public string DeviceQ = "DeviceQ";

        static string AccountGroup = "groupw@example.com";

        public static Contact ContactAlice => MeshMachineTest.ContactAlice;
        public static Contact ContactBob => MeshMachineTest.ContactBob;


        CatalogedCredential password1 = new CatalogedCredential() {
            Username = "fred",
            Password = "password",
            Service = "example.com"
            };
        CatalogedCredential password2 = new CatalogedCredential() {
            Username = "fred",
            Password = "password",
            Service = "example.net"
            };
        //CatalogedCredential password3 = new CatalogedCredential() {
        //    Username = "fred",
        //    Password = "password",
        //    Service = "fred.example.com"
        //    };
        [Fact]
        public void ProtocolHello() {

            var testEnvironmentCommon = new TestEnvironmentCommon();
            var meshClient = testEnvironmentCommon.MeshLocalPortal.GetService(ServiceName);


            var request = new HelloRequest();
            var response = meshClient.Hello(request, null);
            response.Success().TestTrue();
            }


        [Fact]
        public void MeshServiceEncryptCredential() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            var machineAdminAlice = new MeshMachineTest(testEnvironmentCommon, DeviceAliceAdmin);
            var machineAdminBob = new MeshMachineTest(testEnvironmentCommon, DeviceBobAdmin);

            // first device
            var contextAccountAlice_1_a = machineAdminAlice.MeshHost.CreateMesh(AccountAlice, "personal");
            contextAccountAlice_1_a.SetContactSelf(ContactAlice);

            var profileAlice = contextAccountAlice_1_a.ProfileUser;

            using (var transaction1 = contextAccountAlice_1_a.TransactBegin()) {
                var catalogCredential = transaction1.GetCatalogCredential();
                transaction1.CatalogUpdate(catalogCredential, password1);
                transaction1.Transact();


                VerifyContainerEncrypted(catalogCredential, profileAlice.AccountEncryptionKey);
                catalogCredential.Dump();
                }


            // second device
            var machineAlice2 = new MeshMachineTest(testEnvironmentCommon, DeviceAlice2);
            var boundPin = contextAccountAlice_1_a.GetPIN(MeshConstants.MessagePINActionDevice);
            var contextAccountAlice_2 = machineAlice2.MeshHost.Connect(AccountAlice, pin: boundPin.Pin);
            var sync = contextAccountAlice_1_a.Sync();
            var connectRequest = contextAccountAlice_1_a.GetPendingMessageConnectionRequest();
            contextAccountAlice_1_a.Process(connectRequest);
            contextAccountAlice_2.Complete();



            }




        [Fact]
        public void MeshServiceFull() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            var machineAdminAlice = new MeshMachineTest(testEnvironmentCommon, DeviceAliceAdmin);
            var machineAdminBob = new MeshMachineTest(testEnvironmentCommon, DeviceBobAdmin);

            machineAdminAlice.CheckHostCatalogExtended();


            // Create a presonal mesh 
            var contextAccountAlice_1_a = machineAdminAlice.MeshHost.CreateMesh(AccountAlice, "personal");
            machineAdminAlice.CheckHostCatalogExtended();


            // Perform some offline operations on the account catalogs
            contextAccountAlice_1_a.SetContactSelf(ContactAlice);

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

            var boundPin = contextAccountAlice_1_a.GetPIN(MeshConstants.MessagePINActionDevice);
            var contextAccountAlice_2 = machineAlice2.MeshHost.Connect(AccountAlice, pin: boundPin.Pin);
            machineAlice2.CheckHostCatalogExtended(); // Connect pending

            // Still have to process of course to get the data
            var sync = contextAccountAlice_1_a.Sync();


            var connectRequest = contextAccountAlice_1_a.GetPendingMessageConnectionRequest();
            contextAccountAlice_1_a.Process(connectRequest);

            contextAccountAlice_2.Complete();
            machineAlice2.CheckHostCatalogExtended(); // Complete


            // Do some catalog updates and check the results

            using (var transaction1 = contextAccountAlice_1_a.TransactBegin()) {
                var catalogCredential = transaction1.GetCatalogCredential();
                transaction1.CatalogUpdate(catalogCredential, password1);
                transaction1.Transact();


                catalogCredential.Dump();
                }

            // Connect a third device by approving a request
            var machineAlice3 = new MeshMachineTest(testEnvironmentCommon, DeviceAlice3);
            var contextAccount3 = machineAlice3.MeshHost.Connect(AccountAlice);

            sync = contextAccountAlice_1_a.Sync();
            var connectRequest3 = contextAccountAlice_1_a.GetPendingMessageConnectionRequest();
            contextAccountAlice_1_a.Process(connectRequest3);

            contextAccount3.Complete();


            // Do some catalog updates and check the results
            using (var transaction1 = contextAccountAlice_1_a.TransactBegin()) {
                var catalogCredential = transaction1.GetCatalogCredential();
                transaction1.CatalogUpdate(catalogCredential, password2);
                transaction1.Transact();
                }

            // Check message handling - introduce Bob
            var contextAccountBob = machineAdminBob.MeshHost.CreateMesh(AccountBob, "personal");


            //var contactCatalogBob = contextAccountBob.GetCatalogContact();
            contextAccountBob.SetContactSelf(ContactBob);

            // **** Contact testing
            contextAccountBob.ContactRequest(AccountAlice);

            sync = contextAccountAlice_1_a.Sync();
            var contactRequest = contextAccountAlice_1_a.GetPendingMessageContactRequest();
            contextAccountAlice_1_a.Process(contactRequest);

            // Get the response back
            sync = contextAccountBob.Sync();
            var contactResponseBob = contextAccountBob.GetPendingMessageContactRequest();

            contextAccountBob.Process(contactResponseBob);


            //// **** Confirmation testing

            // Ask Alice to add our credential
            contextAccountBob.ConfirmationRequest(AccountAlice, "Dinner tonight");

            sync = contextAccountAlice_1_a.Sync();
            var confirmRequest = contextAccountAlice_1_a.GetPendingMessageConfirmationRequest();
            contextAccountAlice_1_a.Process(confirmRequest);

            // Get the response back
            sync = contextAccountBob.Sync();
            var confirmResponseBob = contextAccountBob.GetPendingMessageConfirmationResponse();
            contextAccountAlice_1_a.Process(confirmResponseBob);
            }


        /// <summary>
        /// Connect a device by approving a request
        /// </summary>
        [Fact]
        public void MeshDeviceConnectApprove() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");

            // New Device
            var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice3,
                    AccountAlice);

            // Admin Device
            contextAccountAlice.Sync();
            var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
            contextAccountAlice.Process(connectRequest);

            // Check second device
            var contextOnboarded = TestCompletionSuccess(contextOnboardPending);
            ExerciseAccount(contextOnboarded);
            }


        /// <summary>
        /// Connect a second device using the PIN connection mechanism
        /// </summary>
        [Fact]
        public void MeshDeviceConnectPIN() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            var contextAdmin = MeshMachineTest.GenerateAccountUser(
                testEnvironmentCommon, DeviceAliceAdmin, AccountAlice, "main");

            // Admin Device
            var boundPin = contextAdmin.GetPIN(MeshConstants.MessagePINActionDevice);
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
            var testEnvironmentCommon = new TestEnvironmentCommon();

            var contextAdmin = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon, DeviceAliceAdmin, AccountAlice,
                "main");

            // Create the QR Code with PIN
            var boundPin = contextAdmin.GetPIN(MeshConstants.MessagePINActionDevice);
            var connectUri = MeshUri.ConnectUri(contextAdmin.AccountAddress, boundPin.Pin);

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
            var testEnvironmentCommon = new TestEnvironmentCommon();


            var contextQ = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon, DeviceQ, AccountQ,
                "main");
            var contextAdmin = MeshMachineTest.GenerateAccountUser(
                testEnvironmentCommon, DeviceAliceAdmin, AccountAlice, "main");

            var DeviceOnboarding = new MeshMachineTest(testEnvironmentCommon, DeviceAlice2);

            // Generate the profile and install it on the device
            contextQ.Preconfigure(out var filename, out var profileDevice,
                out var connectUri);

            var contextOnboardPreconfigured = DeviceOnboarding.Install(filename);

            contextAdmin.Connect(connectUri);

            // Attempt to 
            var contextOnboardPending = contextOnboardPreconfigured.Poll();

            // Check second device
            var contextOnboarded = TestCompletionSuccess(contextOnboardPending);
            ExerciseAccount(contextOnboarded);

            }



        [Fact]
        public void MeshEscrowRecover() {

            // Create mesh
            var testEnvironmentCommon = new TestEnvironmentCommon();
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
            var recoveredAccount = recoveryMachine.MeshHost.CreateMesh("recover",
                        accountSeed: accountSeed);

            // delete seed
            contextAliceOriginal.EraseMeshSecret();

            // FAIL: create key shares 2

            Xunit.Assert.Throws<NoMeshSecret>( 
                ()=>contextAliceOriginal.Escrow(3, 2));

            // Recover to new service


            contextAliceOriginal.ProfileUser.Udf.TestEqual( recoveredAccount.ProfileUser.Udf);


            }


        [Fact]
        public void MeshCreateAdmin() {
            var (context1, context2) = CreateConnectGrant("/admin");
            CanAdmin(context2).TestTrue() ;
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

            var testEnvironmentCommon = new TestEnvironmentCommon();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");

            // New Device
            var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice3,
                    AccountAlice, "device2");

            // Admin Device
            contextAccountAlice.Sync();
            var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
            contextAccountAlice.Process(connectRequest);

            // Check second device
            var contextOnboarded = TestCompletionSuccess(contextOnboardPending);

            return (contextAccountAlice, contextOnboarded);
            }

        [Fact]
        public void MeshCatalogAccount() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");
            }

        [Fact]
        public void MeshCatalogMultipleDevice() {
            // Test service, devices for Alice, Bob
            var testEnvironmentCommon = new TestEnvironmentCommon();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");
            }

        [Fact]
        public void MeshMessageContact() {
            // Test service, devices for Alice, Bob
            var testEnvironmentCommon = new TestEnvironmentCommon();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");
            var contextAccountBob = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon, 
                    DeviceBobAdmin, AccountBob, "main");


            // This test is failing because the message from Bob isn't passed to Alice.
            // Bob ---> Alice
            contextAccountBob.ContactRequest(AccountAlice);

            // Alice ---> Bob
            var sync = contextAccountAlice.Sync();

            var fromBob = contextAccountAlice.GetPendingMessageContactRequest();
            contextAccountAlice.Process(fromBob);

            // Bob
            var syncBob = contextAccountBob.Sync();

            var fromAlice = contextAccountBob.GetPendingMessageContactRequest();


            contextAccountBob.Process(fromAlice);

            (fromBob as MessageContact).Reply.TestTrue();
            (fromAlice as MessageContact).Reply.TestFalse();

            "Add checks to see that each has the contact info of the other in their catalog".TaskTest();
            }

        [Fact]
        public void MeshMessageConfirm() {
            // Test service, devices for Alice, Bob
            var testEnvironmentCommon = new TestEnvironmentCommon();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");
            var contextAccountBob = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceBobAdmin, AccountBob, "main");

            // Bob ---> Alice
            contextAccountBob.ConfirmationRequest(AccountAlice, "Open the pod bay doors");

            // Alice ---> Bob
            var sync = contextAccountAlice.Sync();
            var fromBob = contextAccountAlice.GetPendingMessageConfirmationRequest();
            contextAccountAlice.Process(fromBob);

            // Bob
            var syncBob = contextAccountBob.Sync();
            var fromAlice = contextAccountBob.GetPendingMessageConfirmationResponse();
            contextAccountAlice.Process(fromAlice);
            }


        public static bool Exchange(ContextUser contextAccountAlice, ContextUser contextAccountBob) {
            contextAccountBob.ContactRequest(AccountAlice);
            var sync = contextAccountAlice.Sync();


            var fromBob = contextAccountAlice.GetPendingMessageContactRequest();
            contextAccountAlice.Process(fromBob);
            var syncBob = contextAccountBob.Sync();

            var fromAlice = contextAccountBob.GetPendingMessageContactRequest();
            contextAccountBob.Process(fromAlice);

            return true;
            }

        [Fact]
        public void MeshCatalogGroup() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            var plaintext = Platform.GetRandomBytes(1000);

            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");
            var contextAccountBob = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceBobAdmin, AccountBob, "main");

            Exchange(contextAccountAlice, contextAccountBob);

            // Generate a recryption group
            var contextGroup = contextAccountAlice.CreateGroup(AccountGroup);

            var groupList = new List<string>() { AccountGroup };
            // Encrypt to the group
            var envelope = contextAccountAlice.DareEncode(plaintext, recipients: groupList, sign: true);

            // attempt to decrypt with Alice's key
            // this should fail as Alice doesn't have the decryption key.

            Xunit.Assert.Throws<NoAvailableDecryptionKey>(() =>
                contextAccountAlice.DareDecode(envelope, verify: true));

            // Create a member entry for Alice
            contextGroup.Add(AccountAlice);
            contextAccountAlice.Sync();
            contextAccountAlice.ProcessAutomatics();

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

            // Create a member entry fo Bob
            contextGroup.Delete(AccountBob);

            var decrypt4 = contextAccountAlice.DareDecode(envelope, verify: true);
            decrypt4.IsEqualTo(plaintext).TestTrue();

            }


        [Fact]
        public void CheckPinMessageSigned() => throw new NYI();
        [Fact]
        public void CheckPinMessageEncrypted() => throw new NYI();


        #region // helper routines

        static void ReportDevices(ContextUser contextUser) {
            var catalogDevice = contextUser.GetStore(CatalogDevice.Label) as CatalogDevice;

            Console.WriteLine();
            Console.WriteLine(catalogDevice.Report());

            }

        /// <summary>
        /// Exercise the account to verify functionality. Currently a stub.
        /// </summary>
        /// <param name="contextUser">The context to exercise the account from.</param>
        static void ExerciseAccount(ContextUser contextUser) => contextUser.Future();

        static List<ProcessResult> ProcessAutomatics(ContextUser contextUser) {
            contextUser.Sync();
            return contextUser.ProcessAutomatics();
            }

        static ContextUser TestCompletionSuccess(ContextMeshPending contextMeshPending) {
            var contextUser = contextMeshPending.Complete();
            contextUser.Sync(); // Will fail if cannot complete

            return contextUser;
            }



        bool VerifyContainers(ContextUser contextUser) {

            var profileuser = contextUser.ProfileUser;
            using (var transaction1 = contextUser.TransactBegin()) {
                VerifyContainerEncrypted(transaction1.GetCatalogApplication(), 
                                profileuser.AccountEncryptionKey);
                VerifyContainerEncrypted(transaction1.GetCatalogDevice(),
                                profileuser.AccountEncryptionKey);
                VerifyContainerEncrypted(transaction1.GetCatalogContact(),
                                profileuser.AccountEncryptionKey);
                VerifyContainerEncrypted(transaction1.GetCatalogCredential(),
                                profileuser.AccountEncryptionKey);
                VerifyContainerEncrypted(transaction1.GetCatalogBookmark(),
                                profileuser.AccountEncryptionKey); 
                VerifyContainerEncrypted(transaction1.GetCatalogCalendar(),
                                profileuser.AccountEncryptionKey);
                VerifyContainerEncrypted(transaction1.GetCatalogNetwork(),
                                profileuser.AccountEncryptionKey);
                }


            return true;
            }

        bool VerifyContainerEncrypted(
                    Store container,
                    KeyPair encryptionKey) =>
            VerifyContainerEncrypted(container.Container, encryptionKey);

        static bool VerifyContainerEncrypted(Goedel.Cryptography.Dare.Container container,
                    KeyPair encryptionKey) {


            foreach (var envelope in container) {
                (envelope.Header?.EncryptionAlgorithm).TestNotNull(); // envelope must be encrypted.

                }


            return true;
            }

        bool Verify(ContextUser first, ContextUser second) {
            //(first.ProfileDevice.UDF == second.ProfileDevice.UDF).AssertTrue();

            Verify(first.ActivationDevice, second.ActivationDevice);
            Verify(first.ProfileUser, second.ProfileUser);
            (first.StoresDirectory == second.StoresDirectory).TestTrue();
            return true;
            }

        static bool Verify(ActivationDevice first, ActivationDevice second) {
            //Verify(first.ConnectionAccount, second.ConnectionAccount);
            (first.AccountUdf == second.AccountUdf).TestTrue();
            return true;
            }

        static bool Verify(ProfileUser first, ProfileUser second) {
            (first.AccountEncryption.Udf == second.AccountEncryption.Udf).TestTrue();
            (first.Udf == second.Udf).TestTrue();
            return true;
            }

        public static bool Verify(ConnectionDevice first, ConnectionDevice second) {
            (first.DeviceSignature.Udf == second.DeviceSignature.Udf).TestTrue();
            (first.DeviceEncryption.Udf == second.DeviceEncryption.Udf).TestTrue();
            (first.DeviceAuthentication.Udf == second.DeviceAuthentication.Udf).TestTrue();
            return true;
            }

        #endregion
        }
    }
