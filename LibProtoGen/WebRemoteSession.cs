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
            WebRequest WebRequest = WebRequest.Create(URI);
            WebRequest.Method = "POST";
            WebRequest.ContentType = "application/json;charset=UTF-8";
            WebRequest.Headers.Add("Cache-Control: no-store");
            WebRequest.ContentLength = Content.Length;

            //Trace.WriteLine("Send Request");
            //Trace.WriteLine(Content.GetUTF8);

            RequestStream = WebRequest.GetRequestStream();



            // If using an integrity preamble, put it here.

            byte[] buffer = Content.GetBytes;
            RequestStream.Write(Content.GetBytes, 0, Content.Length);

            // If using an integrity postamble, put it here.

            RequestStream.Close();


            // Request Complete, fetch the response.
            HttpWebResponse WebResponse = (HttpWebResponse)WebRequest.GetResponse();
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
