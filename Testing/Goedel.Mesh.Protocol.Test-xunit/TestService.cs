using Goedel.Cryptography;
using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Utilities;

using System;
using System.Collections.Generic;

using Xunit;

namespace Goedel.XUnit {
    public class TestService {
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


        public static TestService Test() => new TestService();
        static string AccountAlice = "alice@example.com";
        static string ServiceName = "example.com";
        static string AccountBob = "bob@example.com";

        public string DeviceAliceAdmin = "Alice Admin";
        public string DeviceAlice2 = "Alice Device 2";
        public string DeviceAlice3 = "Alice Device 3";
        public string DeviceBobAdmin = "Bob Admin";


        static string AccountGroup = "groupw@example.com";

        public Contact ContactAlice => MeshMachineTest.ContactAlice;
        public Contact ContactBob => MeshMachineTest.ContactBob;


        CatalogedCredential Password1 = new CatalogedCredential() {
            Username = "fred",
            Password = "password",
            Service = "example.com"
            };
        CatalogedCredential Password2 = new CatalogedCredential() {
            Username = "fred",
            Password = "password",
            Service = "example.net"
            };
        CatalogedCredential Password3 = new CatalogedCredential() {
            Username = "fred",
            Password = "password",
            Service = "fred.example.com"
            };
        [Fact]
        public void ProtocolHello() {

            var testEnvironmentCommon = new TestEnvironmentCommon();
            var meshClient = testEnvironmentCommon.MeshLocalPortal.GetService(ServiceName);


            var request = new HelloRequest();
            var response = meshClient.Hello(request, null);
            response.Success().AssertTrue();
            }

        [Fact]
        public void MeshServiceFull() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            var machineAdmin = new MeshMachineTest(testEnvironmentCommon, DeviceAliceAdmin);

            var contextMeshAdmin = machineAdmin.MeshHost.CreateMesh("main");
            var contextAccountAlice_1_a = contextMeshAdmin.CreateAccount("main");

            // Perform some offline operations on the account catalogs
            var contactCatalog = contextAccountAlice_1_a.GetCatalogContact();
            contextAccountAlice_1_a.SetContactSelf(ContactAlice);

            // Check we can read the data from a second context
            var contextAccountAlice_1_b = machineAdmin.GetContextAccount();
            Verify(contextAccountAlice_1_a, contextAccountAlice_1_b);

            // Check that we can read back from the data stored on disk.
            var machineAdmin_3 = new MeshMachineTest(testEnvironmentCommon, DeviceAliceAdmin);
            var contextAccountAlice_1_c = machineAdmin_3.GetContextAccount();


            // ****  Multiple device tests

            // Add a service
            contextAccountAlice_1_a.AddService(AccountAlice);

            // Connect a second device using the PIN connection mechanism
            var machineAlice2 = new MeshMachineTest(testEnvironmentCommon, DeviceAlice2);
            var PIN = contextAccountAlice_1_a.GetPIN();
            var contextAccountAlice_2 = machineAlice2.MeshHost.Connect(AccountAlice, PIN: PIN.PIN);

            // Still have to process of course to get the data
            var sync = contextAccountAlice_1_a.Sync();
            var connectRequest = contextAccountAlice_1_a.GetPendingMessageConnectionRequest();
            contextAccountAlice_1_a.Process(connectRequest);

            contextAccountAlice_2.Complete();

            // Do some catalog updates and check the results
            var catalogCredential = contextAccountAlice_1_a.GetCatalogCredential();
            catalogCredential.New(Password1);


            // Bug: This is failing because the get pending routine is not traversing containers correctly

            //// Connect a third device by approving a request
            //var machineAlice3 = new MeshMachineTest(testEnvironmentCommon, DeviceAlice3);
            //var contextAccount3 = machineAlice3.Connect(AccountAlice);

            //sync = contextAccountAlice_1_a.Sync();
            //var connectRequest3 = contextAccountAlice_1_a.GetPendingMessageConnectionRequest();
            //contextAccountAlice_1_a.Process(connectRequest3);

            //contextAccount3.Complete();


            // Do some catalog updates and check the results
            catalogCredential.New(Password2);

            // Check message handling - introduce Bob
            var machineAdminBob = MeshMachineTest.GenerateMasterAccount(
                testEnvironmentCommon, DeviceBobAdmin, "main",
                out var contextAccountBob,
                AccountBob);

            //var contactCatalogBob = contextAccountBob.GetCatalogContact();
            contextAccountBob.SetContactSelf(ContactBob);

            // **** Contact testing
            contextAccountBob.ContactRequest(AccountAlice);

            // This is not syncing inbound spool as it should. Still only have two frames, not three!
            sync = contextAccountAlice_1_a.Sync();
            var contactRequest = contextAccountAlice_1_a.GetPendingMessageContactRequest();
            contextAccountAlice_1_a.Process(contactRequest);

            // Get the response back
            sync = contextAccountBob.Sync();
            var contactResponseBob = contextAccountBob.GetPendingMessageContactReply();

            contextAccountBob.Process(contactResponseBob);


            // **** Confirmation testing

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
        /// Connect a second device using the PIN connection mechanism
        /// </summary>
        [Fact]
        public void MeshDeviceConnectPIN() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            MeshMachineTest.GenerateMasterAccount(testEnvironmentCommon, DeviceAliceAdmin, "main",
                out var contextAccountAlice, AccountAlice);

            var catalogDevice = contextAccountAlice.GetCatalogDevice();

            // Admin Device
            var PIN = contextAccountAlice.GetPIN();

            Console.WriteLine();
            Console.WriteLine("**** Added the service, 1 device");
            Console.WriteLine(catalogDevice.Report());

            // New Device
            var contextAccount2Pending = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice2,
                AccountAlice, PIN: PIN.PIN);

            // Admin Device
            contextAccountAlice.Sync();

            var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
            contextAccountAlice.Process(connectRequest);

            Console.WriteLine();
            Console.WriteLine("**** Accepted 2nd device");
            Console.WriteLine(catalogDevice.Report());
            // Device has been added but the device connection lacks the account information!

            var catalogDevice2 = contextAccountAlice.GetCatalogDevice();

            var contextAccount2 = contextAccount2Pending.Complete();
            Console.WriteLine();
            Console.WriteLine("**** Synchronized 2nd device");
            Console.WriteLine(catalogDevice2.Report());

            contextAccount2.Sync();
            Console.WriteLine();
            Console.WriteLine("**** Synchronized 2nd device");
            Console.WriteLine(catalogDevice2.Report());
            }

        /// <summary>
        /// Connect a device by approving a request
        /// </summary>
        [Fact]
        public void MeshDeviceConnectApprove() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            MeshMachineTest.GenerateMasterAccount(testEnvironmentCommon, DeviceAliceAdmin, "main",
                out var contextAccountAlice, AccountAlice);

            // New Device
            var contextAccount3Pending = MeshMachineTest.Connect(testEnvironmentCommon, DeviceAlice3,
                    AccountAlice);

            // Admin Device
            contextAccountAlice.Sync();
            var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
            contextAccountAlice.Process(connectRequest);

            // New Device
            var contextAccount3 = contextAccount3Pending.Complete();
            contextAccount3.Sync();
            }

        [Fact]
        public void MeshCatalogStandalone() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            MeshMachineTest.GenerateMasterAccount(testEnvironmentCommon, DeviceAliceAdmin, "main",
                out var contextAccountAlice);

            //var contactCatalog = contextAccountAlice.GetCatalogContact();
            contextAccountAlice.SetContactSelf(ContactAlice);
            }

        [Fact]
        public void MeshCatalogAccount() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            MeshMachineTest.GenerateMasterAccount(testEnvironmentCommon, DeviceAliceAdmin, "main",
                out var contextAccountAlice, AccountAlice);

            //var contactCatalog = contextAccountAlice.GetCatalogContact();
            contextAccountAlice.SetContactSelf(ContactAlice);
            }



        [Fact]
        public void MeshCatalogMultipleDevice() {
            // Test service, devices for Alice, Bob
            var testEnvironmentCommon = new TestEnvironmentCommon();
            MeshMachineTest.GenerateMasterAccount(testEnvironmentCommon, DeviceAliceAdmin, "main",
                out var contextAccountAlice, AccountAlice);


            }

        [Fact]
        public void MeshMessageContact() {
            // Test service, devices for Alice, Bob
            var testEnvironmentCommon = new TestEnvironmentCommon();
            MeshMachineTest.GenerateMasterAccount(testEnvironmentCommon, DeviceAliceAdmin, "main",
                out var contextAccountAlice, AccountAlice);
            MeshMachineTest.GenerateMasterAccount(testEnvironmentCommon, DeviceBobAdmin, "main",
                out var contextAccountBob, AccountBob);

            // Bob ---> Alice
            contextAccountBob.ContactRequest(AccountAlice);

            // Alice ---> Bob
            var sync = contextAccountAlice.Sync();

            var fromBob = contextAccountAlice.GetPendingMessageContactRequest();
            contextAccountAlice.Process(fromBob);

            // Bob
            var syncBob = contextAccountBob.Sync();

            var fromAlice = contextAccountBob.GetPendingMessageContactReply();
            contextAccountAlice.Process(fromAlice);
            }

        [Fact]
        public void MeshMessageConfirm() {
            // Test service, devices for Alice, Bob
            var testEnvironmentCommon = new TestEnvironmentCommon();
            MeshMachineTest.GenerateMasterAccount(testEnvironmentCommon, DeviceAliceAdmin, "main",
                out var contextAccountAlice, AccountAlice);
            MeshMachineTest.GenerateMasterAccount(testEnvironmentCommon, DeviceBobAdmin, "main",
                out var contextAccountBob, AccountBob);

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


        [Fact]
        public void MeshCatalogGroup() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            var plaintext = Platform.GetRandomBytes(1000);

            MeshMachineTest.GenerateMasterAccount(testEnvironmentCommon, DeviceAliceAdmin, "main",
                out var contextAccountAlice, AccountAlice);
            MeshMachineTest.GenerateMasterAccount(testEnvironmentCommon, DeviceBobAdmin, "main",
                out var contextAccountBob, AccountBob);

            // Generate a recryption group
            var contextGroup = contextAccountAlice.CreateGroup(AccountGroup);
            var groupList = new List<string>() { AccountGroup };

            // Encrypt to the group
            var envelope = contextAccountAlice.DareEncode(plaintext, recipients: groupList, sign: true);


            // Decrypt using admin key
            // this should succeed because the group context has the decryption key.
            var decrypt = contextGroup.DareDecode(envelope, verify: true);
            decrypt.IsEqualTo(plaintext).AssertTrue();


            // attempt to decrypt with Alice's key
            // this should fail as Alice doesn't have the decryption key.

            Xunit.Assert.Throws<NYI>(() =>
              contextAccountAlice.DareDecode(envelope, verify: true));

            // Create a member entry for Alice
            contextGroup.Add(AccountAlice);

            // this should now succeed
            var decrypt2 = contextAccountAlice.DareDecode(envelope, verify: true);
            decrypt2.IsEqualTo(plaintext).AssertTrue();

            Xunit.Assert.Throws<NYI>(() =>
              contextAccountBob.DareDecode(envelope, verify: true));

            // Create a member entry fo Bob
            contextGroup.Add(AccountBob);

            var decrypt3 = contextAccountAlice.DareDecode(envelope, verify: true);
            decrypt3.IsEqualTo(plaintext).AssertTrue();

            throw new NYI();
            }


        bool Verify(ContextAccount first, ContextAccount second) {
            //(first.ProfileDevice.UDF == second.ProfileDevice.UDF).AssertTrue();

            Verify(first.ActivationAccount, second.ActivationAccount);
            Verify(first.ProfileAccount, second.ProfileAccount);
            (first.DirectoryAccount == second.DirectoryAccount).AssertTrue();
            (first.KeySignatureUDF == second.KeySignatureUDF).AssertTrue();
            (first.KeyEncryptionUDF == second.KeyEncryptionUDF).AssertTrue();
            (first.KeyAuthenticationUDF == second.KeyAuthenticationUDF).AssertTrue();
            return true;
            }

        bool Verify(ActivationAccount first, ActivationAccount second) {
            //Verify(first.ConnectionAccount, second.ConnectionAccount);
            (first.AccountUDF == second.AccountUDF).AssertTrue();
            return true;
            }

        bool Verify(ProfileAccount first, ProfileAccount second) {
            (first.KeyEncryption.UDF == second.KeyEncryption.UDF).AssertTrue();
            (first.MeshProfileUDF == second.MeshProfileUDF).AssertTrue();
            return true;
            }

        bool Verify(ConnectionAccount first, ConnectionAccount second) {
            (first.KeySignature.UDF == second.KeySignature.UDF).AssertTrue();
            (first.KeyEncryption.UDF == second.KeyEncryption.UDF).AssertTrue();
            (first.KeyAuthentication.UDF == second.KeyAuthentication.UDF).AssertTrue();
            return true;
            }


        bool Verify(ConnectionDevice first, ConnectionDevice second) {
            (first.KeySignature.UDF == second.KeySignature.UDF).AssertTrue();
            (first.KeyEncryption.UDF == second.KeyEncryption.UDF).AssertTrue();
            (first.KeyAuthentication.UDF == second.KeyAuthentication.UDF).AssertTrue();
            return true;
            }

        }
    }
