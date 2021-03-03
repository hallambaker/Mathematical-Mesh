using System;
using System.Net;
using System.Collections.Generic;
using System.Threading;

using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Protocol.Service;
using Goedel.Mesh.Management;

namespace Goedel.Mesh.Test {
    public class TestClient {

        HttpEndpoint httpEndpoint;
        bool Created { get; set; } = false;


        public TestClient(string accountAddress, List<Endpoint> endpoints) {

            httpEndpoint = endpoints[0] as HttpEndpoint;


            var session = new WebRemoteSession(null, null, accountAddress);

            //var webClient = session.GetWebClient<ServiceManagementServiceClient>();

            throw new NYI();
            }


        public void NextAction() {
            var requestData = "Hello World".ToUTF8();

            if (!Created) {
                HTTPRequest(requestData);
                Created = true;
                return;
                }



            HTTPRequest(requestData);
            }


        public void HTTPRequest(byte[] requestData) {
            using var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.UserAgent, "MeshTestClient");
            client.Headers.Add(HttpRequestHeader.CacheControl, "no-store,no-transform");
            
            var uri = httpEndpoint.GetServiceUri();


            Screen.WriteLine($"Connect to {uri}");
            try {
                var responseData = client.UploadData(uri, requestData);
                }
            catch (Exception e) {
                e.Future();
                // deal with whatever issue here.


                }
            }
        public void UDPRequest() {
            }
        }
    }
