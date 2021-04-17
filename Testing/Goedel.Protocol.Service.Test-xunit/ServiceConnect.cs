using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Mesh.Client;
using Goedel.Utilities;
using Goedel.Protocol.Presentation;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using System;
using System.Collections;
using System.Collections.Generic;
using Goedel.Mesh.Test;
using System.Threading;
using Goedel.Mesh;
using Goedel.Mesh.Session;
using Goedel.Mesh.Management;
using Goedel.Protocol.Service;

using Xunit;
using System.IO;

namespace Goedel.XUnit {
    public partial class TestPresentationMesh {


        public const string Domain = "localhost";
        //public string Protocol => ServiceManagementService.WellKnown;
        public const string Instance = "69";

        ServiceManagementService testProvider;

        [Fact]
        public void TestMeshService() {

            var clientCredential = GetInitiatorCredential();
            var hostCredential = GetResponderCredential();


            testProvider = new TestServiceStatus();
            var provider = new Provider(testProvider, PresentationType.All, Domain, Instance);

            var providers = new List<Provider> { provider };
            using var server = new Goedel.Protocol.Service.RdpService(hostCredential, providers);


            var meshServiceBinding = new RdpConnection(clientCredential, Domain, Instance,
                        PresentationType.Http, ServiceManagementService.WellKnown);
            meshServiceBinding.Initialize(null, null);

            //var x = ServiceManagementServiceClient.WellKnown;

            var clientAlice = meshServiceBinding.GetClient<ServiceManagementServiceClient>();


            var request = new ServiceStatusRequest();
            var response = clientAlice.ServiceStatus(request);



            var response2 = clientAlice.ServiceStatus(request);

            var response3 = clientAlice.ServiceStatus(request);


            }

        [Fact]
        public void TestMeshMultiService() {


            var testEnvironmentCommon = new TestEnvironmentCommon();

            var clientCredential = GetInitiatorCredential();
            var hostCredential = GetResponderCredential();

            var meshService = testEnvironmentCommon.MeshService;
            var meshProvider = new Provider(testProvider, PresentationType.All, Domain, Instance);

            testProvider = new TestServiceStatus();
            var provider = new Provider(testProvider, PresentationType.All, Domain, Instance);

            var providers = new List<Provider> { meshProvider, provider };




            var Connection = new RdpConnection(clientCredential, Domain, Instance, PresentationType.Http);
            var statusClient = Connection.GetClient<ServiceManagementServiceClient>();
            var meshClient = Connection.GetClient<MeshServiceClient>();
            }
        [Fact]

        public void TestCreateAccount() {
            var testEnvironmentCommon = new TestEnvironmentRdp();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");

            var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, "device3",
                    AccountAlice, "device2");

            contextAccountAlice.Sync();
            var connectRequest = contextAccountAlice.GetPendingMessageConnectionRequest();
            contextAccountAlice.Process(connectRequest);

            var contextOnboarded = TestCompletionSuccess(contextOnboardPending);
            }

        static ContextUser TestCompletionSuccess(ContextMeshPending contextMeshPending) {
            var contextUser = contextMeshPending.Complete();
            contextUser.Sync(); // Will fail if cannot complete

            return contextUser;
            }
        [Fact]

        public void TestMultipleServices() {

            // create a Mesh client
            // create a status client to same endpoint.

            throw new NYI();
            }

        [Fact]

        public void TestImpersonation() {


            var testEnvironmentCommon = new TestEnvironmentRdp();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");

            var contextAccountMallet = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountMallet, "mallet");
            contextAccountMallet.ProfileUser = contextAccountAlice.ProfileUser;


            Xunit.Assert.Throws<NYI>(() => contextAccountMallet.Sync());


            }


        [Fact]

        public void TestPreconnect() {
            var testEnvironmentCommon = new TestEnvironmentRdp();
            var contextAccountAlice = MeshMachineTest.GenerateAccountUser(testEnvironmentCommon,
                    DeviceAliceAdmin, AccountAlice, "main");

            var contextOnboardPending = MeshMachineTest.Connect(testEnvironmentCommon, "device3",
                    AccountAlice, "device2");

            Xunit.Assert.Throws<ConnectionStillPending>(() => contextOnboardPending.Sync());

            }



        }


    public class TestServiceStatus : ServiceManagementService {
        public override JpcSession GetSession() => throw new NotImplementedException();
        public override ServiceStatusResponse ServiceStatus(ServiceStatusRequest request, IJpcSession session) => new() {
            Start = DateTime.Now
            };

        }


    //public partial class MeshServiceSession : JpcRemoteSession {

    //    public  string Protocol { get; }
    //    public  string Instance { get; }

    //    Session Session { get; }


    //    //public MeshServiceSession(PresentationType presentationTypes,
    //    //            string domain, string protocol, string instance = null) : base (null) {

    //    //    Domain = domain;
    //    //    Protocol = protocol;
    //    //    Instance = instance;

    //    //    Session = new TestConnectionClient(null);
    //    //    }




    //    //public static JpcSession JpcSession(
    //    //            string domain, string protocol, string instance=null) =>
    //    //     new MeshServiceSession(PresentationType.Http, domain, protocol, instance);

    //    //public void BindCredential(Credential credential) {
    //    //    }


    //    ///<inheritdoc/>
    //    public override JsonObject Post(string tag, JsonObject request) {

    //        // Get the Web service client


    //        // serialize the request



    //        // Make a presentation of the request


    //        // send the request and await the response



    //        // extract the response data


    //        // parse the response data.


    //        throw new NYI();
    //        }

        //}
    }