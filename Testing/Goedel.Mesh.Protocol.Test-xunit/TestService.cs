using System;
using Xunit;
using Goedel.Mesh.Protocol;
using Goedel.Mesh.Protocol.Server;
using Goedel.Mesh.Protocol.Client;
using Goedel.Utilities;
using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Mesh;

namespace Goedel.XUnit {
    public class TestService {



        public static TestService Test() => new TestService();
        static string AccountAlice = "alice@example.com";
        static string ServiceName = "example.com";

        [Fact]
        public void ProtocolHello() {
            var meshPortalDirect = CreateService(ServiceName);
            var meshClient = meshPortalDirect.GetService(ServiceName);


            var request = new HelloRequest();
            var response = meshClient.Hello(request);

            }

        [Fact]
        public void ProtocolHelloContext() {
            MeshMachineTest.GetContext(AccountAlice, "Alice Admin", out var machineAliceAdmin, out var deviceAdmin, out var masterAdmin);
            var response = masterAdmin.Connect(ServiceName);


            }


        [Fact]
        public void ProtocolAccountLifecycle() {
            MeshMachineTest.GetContext(AccountAlice, "Alice Admin", 
                out var machineAliceAdmin, out var deviceAdmin, out var masterAdmin);


            // create account
            var statusCreate = masterAdmin.CreateAccount(AccountAlice);


            // get account status
            var statusEmpty = masterAdmin.Status();


            // delete account
            var statusDelete = masterAdmin.DeleteAccount();

            // get account status
            var statusFail = masterAdmin.Status();

            throw new NYI(); // fail the test till we have the right hooks in place to check status returns.
            }


        [Fact]
        public void ProtocolCatalog() {
            MeshMachineTest.GetContext(AccountAlice, "Alice Admin", 
                out var machineAliceAdmin, out var deviceAdmin, out var masterAdmin);


            // create account
            var statusCreate = masterAdmin.CreateAccount(AccountAlice);


            // post to catalog
            var SignedContact = masterAdmin.SignContact(MeshMachineTest.ContactAlice);

            var catalogEntryContact = new CatalogEntryContact(MeshMachineTest.ContactAlice);
            masterAdmin.Add(catalogEntryContact);

            // Check updated elements are correct.

            }



        [Fact]
        public void MeshConnect() {
            

            MeshMachineTest.GetContext(AccountAlice, "Alice Admin", 
                out var machineAliceAdmin, out var deviceAdmin, out var masterAdmin);


            // create account
            var meshClientAdmin = masterAdmin.CreateAccount(AccountAlice);

            // Create device profile
            MeshMachineTest.GetContext(AccountAlice, "Alice 2", out var MachineAliceSecond, out var Device2);

            // Post connection request
            var helloResponse = deviceAdmin.Connect(AccountAlice);


            // Pull device profile update - fail
            var deviceStatusFail = masterAdmin.Sync();

            // Accept connection request
            ProcessPending(masterAdmin);


            // Pull device profile update - success
            var deviceStatusSuccess = masterAdmin.Sync();
            }

        [Fact]
        public void MeshContact() {
            var AccountAlice = "alice@example.com";
            var AccountBob = "bob@example.com";

            MeshMachineTest.GetContext(AccountAlice, "Alice Admin", 
                out var machineAliceAdmin, out var deviceAdmin, out var masterAdmin);
            MeshMachineTest.GetContext(AccountBob, "Bob Admin", 
                out var machineAdminBob, out var deviceAdminBob, out var masterAdminBob);

            var statusCreateAlice = masterAdmin.CreateAccount(AccountAlice);
            var statusCreateBob = masterAdminBob.CreateAccount(AccountBob);

            // Create Bob contact.
            var SignedContact = masterAdminBob.SignContact(MeshMachineTest.ContactBob);


            // Bob make contact request Alice.
            masterAdminBob.ContactRequest(AccountAlice, SignedContact);


            // Bob make confirmation request Alice - fail.
            var confirmFail = masterAdminBob.ConfirmationRequest(AccountAlice, "Approve this");


            // Alice accept connection request - grant confirmation privilege.
            ProcessPending(masterAdmin);


            // Bob make confirmation request Alice - accepted.
            var confirmSuccess = masterAdminBob.ConfirmationRequest(AccountAlice, "Do you approve?");

            // Alice accept confirmation request.
            ProcessPending(masterAdmin);

            // Bob gets confirmation response.

            confirmSuccess.CheckResponse();
            }


        bool ProcessPending(ContextDevice device) {
            //foreach (var inbound in device.SpoolInbound) {
            //    // if inbound = connection request


            //    // if inbound = contact request


            //    // if inbound = confirmation request
            //    }

            return true;
            }

        public MeshPortalDirect CreateService(string service) =>
            new MeshPortalDirect(service);

        }
    }
