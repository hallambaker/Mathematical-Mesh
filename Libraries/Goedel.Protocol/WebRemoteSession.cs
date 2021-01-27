//   Copyright © 2015 by Comodo Group Inc.
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
//  
//  

using Goedel.Discovery;
using Goedel.Utilities;

using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Goedel.Protocol {

    /// <summary>
    /// Manage JPC session to a remote Web Service.
    /// </summary>
    public partial class WebRemoteSession : JpcRemoteSession {
        ServiceDescription serviceDescription = null;
        string uri;

        /// <summary>
        /// Create a remote session with authentication under the
        /// specified credential.
        /// </summary>
        /// <param name="domain">Domain</param>
        /// <param name="service">The IANA Well Known service identifier</param>
        /// <param name="accountAddress">Account name</param>
        /// <param name="udf">Fingerprint of authentication key.</param>
        public WebRemoteSession(string domain, string service, string accountAddress = null, string udf = null) : base(accountAddress) {

            udf.Future();
            AccountAddress = accountAddress;

            if (domain == null) {
                uri = "http://127.0.0.1:80/.well-known/"; // + Service + "/";
                Domain = null;
                }
            else {
                serviceDescription = DnsClient.ResolveService(domain, Service: service);
                var Host = serviceDescription.Next();
                uri = Host.HTTPEndpoint;
                Domain = Host.Address;
                }
            }

        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="Content">StreamBuffer object containing JSON encoded request.</param>
        /// <param name="requestObject">Request object (for debugging)</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override Stream Post(MemoryStream Content, JsonObject requestObject) {

            try {
                var BaseAddress = new Uri(uri);

                using var HTTPClient = new HttpClient();
                HTTPClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() {
                    NoStore = true
                    };

                byte[] buffer = Content.ToArray();
                var HTTPContent = new ByteArrayContent(buffer);
                HTTPContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


                var ResponseTask = HTTPClient.PostAsync(new Uri(uri), HTTPContent);
                ResponseTask.Wait();
                var HTTPResponse = ResponseTask.Result;

                var Code = (int)HTTPResponse.StatusCode;

                //Trace.WriteLine("Got a response {0} {1}", Code, WebResponse.StatusDescription);

                if (Code > 399) {
                    throw new Exception(HTTPResponse.ReasonPhrase);
                    }

                var ContentTask = HTTPResponse.Content.ReadAsStreamAsync();
                ContentTask.Wait();

                return ContentTask.Result;
                }
            catch {
                throw new ConnectionFail(args: uri) ;
                }
            }

        }
    }
