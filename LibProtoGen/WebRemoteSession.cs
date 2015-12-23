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

using System;
using System.Net;
using System.IO;
using Goedel.Debug;

namespace Goedel.Protocol {

    /// <summary>
    /// Manage JPC session to a remote Web Service.
    /// </summary>
    public partial class WebRemoteSession : JPCRemoteSession {

        // Misc state variables.
        string URI;

        /// <summary>
        /// Create a remote session without authentication. This call
        /// is typically used when beginning an interaction that will
        /// lead to the authentication credential being established.
        /// </summary>
        /// <param name="URI">The Web Service Endpoint.</param>/// 
        /// <param name="Domain">Domain</param>
        /// <param name="Account">Account name</param>
        public WebRemoteSession(string URI, string Domain, string Account) : 
                    this (URI, Domain, Account, null) {
            }

        /// <summary>
        /// Create a remote session with authentication under the
        /// specified credential.
        /// </summary>
        /// <param name="ServiceName">The Web Service Endpoint.</param>
        /// <param name="Domain">Domain</param>
        /// <param name="Account">Account name</param>
        /// <param name="UDF">Fingerprint of authentication key.</param>
        public WebRemoteSession(string URI, string Domain, 
                    string Account, string UDF) {
            this.Domain = Domain;
            this.URI = URI;
            this.Account = Account;
            }

        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="Content">StreamBuffer object containing JSON encoded request.</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override StreamBuffer Post(StreamBuffer Content) {
            Stream RequestStream = null;


            // Get request object for the URI
            var Request = WebRequest.CreateHttp(URI);
            Request.Method = "POST";
            Request.Host = Domain;
            Request.ContentType = "application/json;charset=UTF-8";
            Request.Headers.Add("Cache-Control: no-store");
            Request.ContentLength = Content.Length;

            //Trace.WriteLine("Send Request");
            //Trace.WriteLine(Content.GetUTF8);

            RequestStream = Request.GetRequestStream();



            // If using an integrity preamble, put it here.

            byte[] buffer = Content.GetBytes;
            RequestStream.Write(Content.GetBytes, 0, Content.Length);

            // If using an integrity postamble, put it here.

            RequestStream.Close();


            // Request Complete, fetch the response.
            HttpWebResponse WebResponse = (HttpWebResponse)Request.GetResponse();
            int Code = (int)WebResponse.StatusCode;

            //Trace.WriteLine("Got a response {0} {1}", Code, WebResponse.StatusDescription);

            if (Code > 399) {
                throw new Exception(WebResponse.StatusDescription);
                }

            var ReadBuffer = new StreamBuffer(WebResponse.GetResponseStream());

            return ReadBuffer;
            }

        }
    }
