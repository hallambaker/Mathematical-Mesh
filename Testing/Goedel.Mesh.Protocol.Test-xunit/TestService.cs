using System.Collections.Generic;
using Xunit;
using Goedel.Cryptography.Dare;
using Goedel.Mesh.Protocol.Server;
using Goedel.Mesh.Protocol.Client;
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

        [Fact]
        public void ProtocolHello() {
            var machineEnvironment = new TestEnvironmentMachine( "ProtocolHello");

            var meshClient = machineEnvironment.MeshPortalDirect.GetService(ServiceName);


            var request = new HelloRequest();
            var response = meshClient.Hello(request, null);

            }

        [Fact]
        public void ProtocolHelloContext() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            MeshMachineTest.GetContext(testEnvironmentCommon, AccountAlice, "Alice Admin", 
                    out var machineAliceAdmin, out var deviceAdmin, out var masterAdmin);
            var response = masterAdmin.Hello(ServiceName);


            }


        [Fact]
        public void ProtocolAccountLifecycle() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            MeshMachineTest.GetContext(testEnvironmentCommon, AccountAlice, "Alice Admin", 
                out var machineAliceAdmin, out var deviceAdmin, out var masterAdmin);


            // create account
            var statusCreate = masterAdmin.CreateAccount(AccountAlice); // Test: success result.
            statusCreate.AssertSuccess();

            // get account status
            var statusEmpty = masterAdmin.Status();
            statusEmpty.AssertSuccess();

            // delete account
            var statusDelete = masterAdmin.DeleteAccount();
            statusEmpty.AssertSuccess();

            // get account status
            var statusFail = masterAdmin.Status(); // Test: Test that we get a fail response.
            statusFail.AssertError();
            }


        [Fact]
        public void ProtocolCatalog() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            MeshMachineTest.GetContext(testEnvironmentCommon, AccountAlice, "Alice Admin", 
                out var machineAliceAdmin, out var deviceAdmin, out var masterAdmin);


            // create account
            var statusCreate = masterAdmin.CreateAccount(AccountAlice);



            masterAdmin.SetContactSelf(MeshMachineTest.ContactAlice);

            // Check updated elements are correct.

            // get account status
            var statusAdded = masterAdmin.Status();
            statusAdded.AssertSuccess(); // Check: make sure one item has been added etc.

            }



        [Fact]
        public void MeshConnect() {
            var testEnvironmentCommon = new TestEnvironmentCommon();
            MeshMachineTest.GetContext(testEnvironmentCommon, AccountAlice, "Alice Admin", 
                out var machineAliceAdmin, out var deviceAdmin, out var masterAdmin);


            // create account
            var meshClientAdmin = masterAdmin.CreateAccount(AccountAlice);

            // Create device profile
            MeshMachineTest.GetContext(testEnvironmentCommon, AccountAlice, "Alice 2", out var MachineAliceSecond, out var deviceSecond);
            var ww = masterAdmin.Sync();
            // Post connection request
            var connectResponse = deviceSecond.RequestConnect(AccountAlice);


            // Pull device profile update - fails because device is not yet connected.

            // Error: this is not working yet because the requests are not properly authorized.

            var deviceStatusFail = deviceSecond.Sync();
            deviceStatusFail.AssertError();

            // Check the completion message
            var count = ProcessPending(masterAdmin);
            (count == 0).AssertTrue();

            // Pull device profile update - success, we get the personal and device profile.
            var deviceStatusSuccess = deviceSecond.Sync();
            deviceStatusSuccess.AssertSuccess();
            }

        [Fact]
        public void MeshContact() {
            var testEnvironmentCommon = new TestEnvironmentCommon();

            var AccountAlice = "alice@example.com";
            var AccountBob = "bob@example.com";

            MeshMachineTest.GetContext(testEnvironmentCommon, AccountAlice, "Alice Admin", 
                out var machineAliceAdmin, out var deviceAdmin, out var masterAdmin);
            MeshMachineTest.GetContext(testEnvironmentCommon, AccountBob, "Bob Admin", 
                out var machineAdminBob, out var deviceAdminBob, out var masterAdminBob);

            var statusCreateAlice = masterAdmin.CreateAccount(AccountAlice);
            var statusCreateBob = masterAdminBob.CreateAccount(AccountBob);

            // Create Bob contact.
            var SignedContact = masterAdminBob.SetContactSelf(MeshMachineTest.ContactBob);


            // Bob make contact request Alice.
            masterAdminBob.ContactRequest(AccountAlice, SignedContact);


            // Bob make confirmation request Alice - fail.
            var confirmFail = masterAdminBob.ConfirmationRequest(AccountAlice, "Reject This");


            // Alice accept connection request - grant confirmation privilege.
            ProcessPending(masterAdmin);


            // Bob make confirmation request Alice - accepted.
            var confirmSuccess = masterAdminBob.ConfirmationRequest(AccountAlice, "Approve This");

            // Alice accept confirmation request.
            ProcessPending(masterAdmin);

            // Bob gets confirmation response.

            //confirmSuccess.CheckResponse();
            }


        int ProcessPending(ContextDevice device) {
            var completed = new Dictionary<string, MeshMessage>();

            var processed = 0;
            var sync = device.Sync();
            sync.AssertSuccess();

            foreach (var message in device.SpoolInbound.Select(1, true)) {
                var meshMessage = MeshMessage.FromJSON(message.GetBodyReader());

                if (!completed.ContainsKey(meshMessage.MessageID)) {
                    if (meshMessage as MeshMessageComplete != null) {
                        processed++;
                        }

                    switch (meshMessage) {
                        case MeshMessageComplete meshMessageComplete:  {
                            foreach (var reference in meshMessageComplete.References) {
                                completed.Add(reference.MessageID, meshMessageComplete);
                                // Hack: This should make actual use of the relationship
                                //   (Accept, Reject, Read)

                                }

                            break;
                            }


                        case MessageConnectionRequest messageConnectionRequest: {
                            var accept = true;

                            device.ProcessConnectionRequest(messageConnectionRequest, accept);

                            break;
                            }
                        case MessageContactRequest messageContactRequest: {
                            var accept = true;

                            device.ProcessContactRequest(messageContactRequest, accept);

                            break;
                            }
                        case MessageConfirmationRequest messageConfirmationRequest: {
                            var accept = messageConfirmationRequest.Text[0] == 'A';

                            device.ProcessConfirmationRequest(messageConfirmationRequest, accept);

                            break;
                            }
                        case MessageConfirmationResponse messageConfirmationResponse: {
                            break;
                            }
                        case MessageTaskRequest messageTaskRequest: {
                            break;
                            }
                        }
                    }
                }

            return processed;
            }

        //public MeshPortalDirect CreateService(string service) =>
        //    new MeshPortalDirect(service);

        }
    }
