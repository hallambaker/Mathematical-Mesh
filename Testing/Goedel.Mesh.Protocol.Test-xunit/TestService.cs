using System;
using Xunit;
using Goedel.Cryptography.Dare;
using Goedel.Mesh.Server;
using Goedel.Mesh.Client;
using Goedel.Utilities;
using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Mesh;

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

            var contextMeshAdmin = machineAdmin.CreateMesh("main");
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
            var contextAccountAlice_2 = machineAlice2.Connect(AccountAlice, PIN: PIN.PIN);
            contextAccountAlice_2.Complete();

            // Do some catalog updates and check the results
            var catalogCredential = contextAccountAlice_1_a.GetCatalogCredential();
            catalogCredential.New(Password1);

            // Connect a third device by approving a request
            var machineAlice3 = new MeshMachineTest(testEnvironmentCommon, DeviceAlice3);
            var contextAccount3 = machineAlice3.Connect(AccountAlice);

            var connectRequest = contextAccountAlice_1_a.GetPendingMessageConnectionRequest();
            contextAccountAlice_1_a.Process(connectRequest);

            contextAccount3.Complete();


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
            var sync = contextAccountAlice_1_a.Sync();
            var contactRequest = contextAccountAlice_1_a.GetPendingMessageConnectionRequest();
            contextAccountAlice_1_a.Process(contactRequest);

            // Get the response back
            sync = contextAccountBob.Sync();
            var contactResponseBob = contextAccountBob.GetPendingMessageConnectionRequest();
            
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


        #region // Old tests


        //[Fact]
        //public void ProtocolHelloContext() {

        //    MeshMachineTest.GetContextMaster(AccountAlice, "Alice Admin",
        //            out var machineAliceAdmin, out var deviceAdmin);
        //    var response = deviceAdmin.Hello(ServiceName);
        //    response.Success.AssertTrue();

        //    }


        //[Fact]
        //public void ProtocolAccountLifecycle() {
        //    MeshMachineTest.GetContextMaster(AccountAlice, "Alice Admin",
        //        out var machineAliceAdmin, out var deviceAdmin);


        //    // create account
        //    var statusCreate = deviceAdmin.CreateAccount(AccountAlice); // Test: success result.
        //    statusCreate.AssertSuccess();

        //    // get account status
        //    var statusEmpty = deviceAdmin.Status();
        //    statusEmpty.AssertSuccess();

        //    // delete account
        //    var statusDelete = deviceAdmin.DeleteAccount();
        //    statusEmpty.AssertSuccess();

        //    // get account status
        //    var statusFail = deviceAdmin.Status(); // Test: Test that we get a fail response.
        //    statusFail.AssertError();
        //    }


        //[Fact]
        //public void ProtocolCatalog() {
        //    MeshMachineTest.GetContextMaster(AccountAlice, "Alice Admin",
        //        out var machineAliceAdmin, out var deviceAdmin);


        //    // create account
        //    var statusCreate = deviceAdmin.CreateAccount(AccountAlice);



        //    deviceAdmin.SetContactSelf(MeshMachineTest.ContactAlice);

        //    // Check updated elements are correct.

        //    // get account status
        //    var statusAdded = deviceAdmin.Status();
        //    statusAdded.AssertSuccess(); // Check: make sure one item has been added etc.

        //    }

        //[Fact]
        //public void MeshConnectBase() {
        //    var testEnvironmentCommon = new TestEnvironmentCommon();

        //    var machineAdmin = new MeshMachineTest(testEnvironmentCommon, DeviceAliceAdmin);
        //    var contextAdmin = new ContextDevice(machineAdmin, accountName: null, deviceUDF: null);
        //    // Multiple accounts/devices not supported at the moment. 




        //    //MeshMachineTest.GetContext(testEnvironmentCommon, AccountAlice, DeviceAliceAdmin, 
        //    //    out var machineAdmin, out var contextAdmin);

        //    contextAdmin.GenerateMaster();

        //    // Check that we can retrieve the contect from the machine

        //    var machineAdmin2 = new MeshMachineTest(testEnvironmentCommon, DeviceAliceAdmin);
        //    var contextAdmin2 = new ContextDevice(machineAdmin);


        //    (machineAdmin2.DirectoryMaster == machineAdmin.DirectoryMaster).AssertTrue(
        //        String: "Directories should match");
        //    (contextAdmin.ProfileDevice.UDF == contextAdmin2.ProfileDevice.UDF).AssertTrue(
        //        String: "Profile UDFs should match");

        //    // Create account at the service


        //    // Add password entry to the credential store


        //    // Check that we can recover the account registration info in new context



        //    // Connect a second device

        //    /*
        //        MeshMachineTest.GetContext(testEnvironmentCommon, AccountAlice, "Alice 2", 
        //            out var MachineAliceSecond, out var deviceSecond);

        //        var connectResponse = deviceSecond.RequestConnect(AccountAlice);
        //        connectResponse.AssertSuccess();
        //    */

        //    // Try to Sync device - fail


        //    // Accept the connection 


        //    // Check that we can recover the connection request info in new context on device


        //    // Try to Sync device - success 


        //    // Check that we can now read the credentials.


        //    // Check that we can recover the connection info in new context on device


        //    // Begin connect a third device
        //    // Reject request
        //    // Check that we cannot read the credentials.

        //    }



        //[Fact]
        //public void MeshConnect() {
        //    var testEnvironmentCommon = new TestEnvironmentCommon();

        //    MeshMachineTest.GetContextMaster(testEnvironmentCommon, AccountAlice, "Alice Admin",
        //        out var machineAliceAdmin, out var deviceAdmin);


        //    // create account
        //    var meshClientAdmin = deviceAdmin.CreateAccount(AccountAlice);

        //    // Create device profile
        //    MeshMachineTest.GetContext(testEnvironmentCommon, AccountAlice, "Alice 2", out var MachineAliceSecond, out var deviceSecond);
        //    var ww = deviceAdmin.Sync();
        //    // Post connection request
        //    var connectResponse = deviceSecond.RequestConnect(AccountAlice);


        //    // Pull device profile update - fails because device is not yet connected.

        //    // Error: this is not working yet because the requests are not properly authorized.

        //    var deviceStatusFail = deviceSecond.Sync();
        //    deviceStatusFail.AssertError();

        //    // Check the completion message
        //    var count = ProcessPending(deviceAdmin);
        //    (count == 0).AssertTrue();

        //    // Pull device profile update - success, we get the personal and device profile.
        //    var deviceStatusSuccess = deviceSecond.Sync();
        //    deviceStatusSuccess.AssertSuccess();
        //    }

        //[Fact]
        //public void MeshContact() {
        //    var testEnvironmentService = new TestEnvironmentCommon();

        //    var AccountAlice = "alice@example.com";
        //    var AccountBob = "bob@example.com";

        //    MeshMachineTest.GetContextMaster(testEnvironmentService, AccountAlice, "Alice Admin",
        //        out var machineAliceAdmin, out var masterAdmin);
        //    MeshMachineTest.GetContextMaster(testEnvironmentService, AccountBob, "Bob Admin",
        //        out var machineAdminBob, out var masterAdminBob);

        //    var statusCreateAlice = masterAdmin.CreateAccount(AccountAlice);
        //    var statusCreateBob = masterAdminBob.CreateAccount(AccountBob);

        //    // Create Bob contact.
        //    var contactEntry = masterAdminBob.SetContactSelf(ContactBob);


        //    // Bob make contact request Alice.
        //    masterAdminBob.ContactRequest(AccountAlice, contactEntry.Contact);


        //    // Bob make confirmation request Alice - fail.
        //    var confirmFail = masterAdminBob.ConfirmationRequest(AccountAlice, "Reject This");


        //    // Alice accept connection request - grant confirmation privilege.
        //    ProcessPending(masterAdmin);


        //    // Bob make confirmation request Alice - accepted.
        //    var confirmSuccess = masterAdminBob.ConfirmationRequest(AccountAlice, "Approve This");

        //    // Alice accept confirmation request.
        //    ProcessPending(masterAdmin);

        //    // Bob gets confirmation response.

        //    //confirmSuccess.CheckResponse();
        //    }








        //int ProcessPending(ContextDevice device) {

        //    var sync = device.Sync();
        //    sync.AssertSuccess();

        //    return ProcessPending(device, device.SpoolInbound);
        //    }

        //int ProcessPending(ContextDevice device, Spool SpoolInbound) {
        //    var completed = new Dictionary<string, MeshMessage>();
        //    var processed = 0;
        //    foreach (var message in SpoolInbound.Select(1, true)) {
        //        var meshMessage = MeshMessage.FromJSON(message.GetBodyReader());

        //        if (!completed.ContainsKey(meshMessage.MessageID)) {
        //            if (meshMessage as MeshMessageComplete != null) {
        //                processed++;
        //                }

        //            switch (meshMessage) {
        //                case MeshMessageComplete meshMessageComplete:  {
        //                    foreach (var reference in meshMessageComplete.References) {
        //                        completed.Add(reference.MessageID, meshMessageComplete);
        //                        // Hack: This should make actual use of the relationship
        //                        //   (Accept, Reject, Read)

        //                        }

        //                    break;
        //                    }


        //                case MessageConnectionRequest messageConnectionRequest: {
        //                    var accept = true;

        //                    device.ProcessConnectionRequest(messageConnectionRequest, accept);

        //                    break;
        //                    }
        //                case MessageContactRequest messageContactRequest: {
        //                    var accept = true;

        //                    device.ProcessContactRequest(messageContactRequest, accept);

        //                    break;
        //                    }
        //                case MessageConfirmationRequest messageConfirmationRequest: {
        //                    var accept = messageConfirmationRequest.Text[0] == 'A';

        //                    device.ProcessConfirmationRequest(messageConfirmationRequest, accept);

        //                    break;
        //                    }
        //                case MessageConfirmationResponse messageConfirmationResponse: {
        //                    break;
        //                    }
        //                case MessageTaskRequest messageTaskRequest: {
        //                    break;
        //                    }
        //                }
        //            }
        //        }

        //    return processed;
        //    }

        ////public MeshPortalDirect CreateService(string service) =>
        ////    new MeshPortalDirect(service);

        #endregion

        }
    }
