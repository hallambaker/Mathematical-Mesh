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


namespace Goedel.Mesh.Test;

public class TestClient {
    readonly HttpEndpoint httpEndpoint;
    bool Created { get; set; } = false;


    public TestClient(string accountAddress, List<Endpoint> endpoints) {

        httpEndpoint = endpoints[0] as HttpEndpoint;


        //var session = new WebRemoteSession(null, null, accountAddress);

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

        var handler = new HttpClientHandler();
        using var client = new HttpClient(handler);
        client.DefaultRequestHeaders.Add("UserAgent", "MeshTestClient");
        client.DefaultRequestHeaders.Add("CacheControl", "no-store,no-transform");

        var uri = httpEndpoint.GetServiceUri();


        //Screen.WriteLine($"Connect to {uri}");
        try {

            var content = new ByteArrayContent(requestData);

            var response = client.PostAsync(uri, content);
            response.Wait();
            var responseData = response.Result.Content;

            }
        catch (Exception e) {
            e.Future();
            // deal with whatever issue here.


            }
        }
    public void UDPRequest() {
        }
    }
