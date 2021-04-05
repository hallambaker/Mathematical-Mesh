using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Test;
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
        public string Protocol => TestProvider.GetWellKnown;
        public const string Instance = "69";
        Listener TestListener;

        ServiceManagementService TestProvider;

        [Fact]
        public void TestMeshService() {

            var clientCredential = GetInitiatorCredential();
            var hostCredential = GetResponderCredential();


            TestProvider = new TestServiceStatus();
            var provider = new Provider(TestProvider, PresentationType.All,
                        Domain, Instance);

            var providers = new List<Provider> { provider };
            using var server = new MeshHost(hostCredential, providers);


            var meshServiceBinding = new MeshSession(clientCredential, Domain, Protocol, Instance, PresentationType.Http);
            meshServiceBinding.Initialize(null, null);


            var clientAlice = new ServiceManagementServiceClient() {
                            JpcSession = meshServiceBinding };


            var request = new ServiceStatusRequest();
            var response = clientAlice.ServiceStatus(request);



            var response2 = clientAlice.ServiceStatus(request);

            var response3 = clientAlice.ServiceStatus(request);


            // Start the service


            // send hello 



            // send large request



            }


        }

    public class TestServiceStatus : ServiceManagementService {
        public override JpcSession GetSession() => throw new NotImplementedException();
        public override ServiceStatusResponse ServiceStatus(ServiceStatusRequest request, IJpcSession session) {

            return new ServiceStatusResponse() {
                Start = DateTime.Now
                };

            }

        }


    public partial class MeshServiceSession : JpcRemoteSession {

        public  string Protocol { get; }
        public  string Instance { get; }

        Session Session { get; }


        public MeshServiceSession(PresentationType presentationTypes,
                    string domain, string protocol, string instance = null) : base (null) {

            Domain = domain;
            Protocol = protocol;
            Instance = instance;

            Session = new TestConnectionClient(null);
            }




        public static JpcSession JpcSession(
                    string domain, string protocol, string instance=null) =>
             new MeshServiceSession(PresentationType.Http, domain, protocol, instance);

        public void BindCredential(Credential credential) {
            }


        ///<inheritdoc/>
        public override JsonObject Post(string tag, JsonObject request) {

            // Get the Web service client


            // serialize the request



            // Make a presentation of the request


            // send the request and await the response



            // extract the response data


            // parse the response data.


            throw new NYI();
            }

        }
    }