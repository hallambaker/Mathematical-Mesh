using System;
using System.Net;
using System.Collections.Generic;
using System.Threading;

using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Protocol.Service {
    public class TestClient {

        HttpEndpoint HttpEndpoint;

        public TestClient(string accountAddress, List<Endpoint> endpoints) {

            HttpEndpoint = endpoints[0] as HttpEndpoint;





            }


        public void NextAction() {


            }


        public void HTTPRequest() {
            using var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.UserAgent, "MeshTestClient");
            client.Headers.Add(HttpRequestHeader.CacheControl, "no-store,no-transform");
            var requestData = "Hello World".ToUTF8();
            var uri = HttpEndpoint.ServiceUri();


            Screen.WriteLine($"Connect to {uri}");
            try {
                var responseData = client.UploadData(uri, requestData);
                }
            catch (Exception e) {
                // deal with whatever issue here.


                }
            }


        }
    }
