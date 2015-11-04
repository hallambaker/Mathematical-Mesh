using System;
using System.Net;
using Goedel.Debug;

namespace Goedel.Protocol {

    /// <summary>
    /// Manage JPC session to a remote Web Service.
    /// </summary>
    public partial class WebRemoteSession : JPCRemoteSession {

        // Misc state variables.
        int Port = 80;
        string Stem;
        string Uri { get { return "http://" + Portal + ":" + Port.ToString() + "/" + Stem; } }


        /// <summary>
        /// Create a remote session without authentication. This call
        /// is typically used when beginning an interaction that will
        /// lead to the authentication credential being established.
        /// </summary>
        /// <param name="ServiceName">The canonical service name.</param>/// 
        /// <param name="Portal">Address of portal</param>
        /// <param name="Account">Account name</param>
        public WebRemoteSession(string ServiceName, string Portal, string Account) : 
                    this (ServiceName, Portal, Account, null) {
            }

        /// <summary>
        /// Create a remote session with authentication under the
        /// specified credential.
        /// </summary>
        /// <param name="ServiceName">The canonical service name.</param>
        /// <param name="Portal">Address of portal</param>
        /// <param name="Account">Account name</param>
        /// <param name="UDF">Fingerprint of authentication key.</param>
        public WebRemoteSession(string ServiceName, string Portal, 
                    string Account, string UDF) {
            this.Stem = ".well-known/" + ServiceName + "/";
            this.Portal = Portal;
            this.Account = Account;
            }

        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="Content">StreamBuffer object containing JSON encoded request.</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override StreamBuffer Post(StreamBuffer Content) {

            // Get request object for the URI
            WebRequest WebRequest = WebRequest.Create(Uri);
            WebRequest.Method = "POST";
            WebRequest.ContentType = "application/json;charset=UTF-8";
            WebRequest.Headers.Add("Cache-Control: no-store");

            var RequestStream = WebRequest.GetRequestStream();


            byte[] buffer = Content.GetBytes;
            WebRequest.ContentLength = Content.Length;

            // If using an integrity preamble, put it here.

            Content.Write(RequestStream);

            // If using an integrity postamble, put it here.

            // Request Complete, fetch the response.
            HttpWebResponse WebResponse = (HttpWebResponse)WebRequest.GetResponse();
            int Code = (int)WebResponse.StatusCode;

            Trace.WriteLine("Got a response {0} {1}", Code, WebResponse.StatusDescription);

            if (Code > 399) {
                throw new Exception(WebResponse.StatusDescription);
                }

            var ReadBuffer = new StreamBuffer(WebResponse.GetResponseStream());

            return ReadBuffer;
            }

        }
    }
