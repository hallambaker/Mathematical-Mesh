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
using System.Collections.Generic;

namespace Goedel.Protocol {

    /// <summary>
    /// Base class for a Host
    /// </summary>
    public abstract class JPCProvider {

        /// <summary>
        /// If set, all domain names are mapped onto 127.0.0.1
        /// </summary>
        public static bool LocalLoopback = false;

        protected JPCProvider () {
            Interfaces = new List<JPCInterface> ();
            }

        /// <summary>
        /// The dispatch service.
        /// </summary>
        public List<JPCInterface> Interfaces;

        /// <summary>
        /// Dispatch Class. Reads input from the provided reader and attempts to
        /// dispatch a method in response. Note that the calling routine may throw 
        /// an error. This must be caught and processed by the host dispatch class.
        /// </summary>
        /// <param name="JPCService">The service that is to handle the request.</param>
        /// <param name="JSONReader"></param>
        /// <returns>The response to the request.</returns>
        public abstract Goedel.Protocol.JSONObject Dispatch(JPCSession Session,
            JSONReader JSONReader);


        /// <summary>
        /// Construct a URI for a well known service.
        /// </summary>
        /// <param name="Domain">DNS domain name of the service.</param>
        /// <param name="WellKnown">The well-known service identifier tag (see RFC 5785).</param>
        /// <param name="TLS">If true, the https scheme is used, otherwise http is used.</param>
        /// <returns></returns>
        public static string WellKnownToURI (string Domain, string WellKnown, 
                            string Prefix, bool TLS, bool HostMode) {

            var Address = DNS.Resolve(Domain, Prefix);

            return (TLS ? "https://" : "http://") + 
                (HostMode ? Domain : Address) + 
                "/.well-known/" + WellKnown + "/";
            }



        }


    /// <summary>
    /// Base class for all JPC server and client classes.
    /// </summary>
    public abstract class JPCInterface {

        /// <summary>
        /// The WellKnown service name for HTTP and DNS prefix use.
        /// </summary>
        public abstract string GetWellKnown {
            get;
            }

        /// <summary>
        /// The WellKnown service name for HTTP and DNS prefix use.
        /// </summary>
        public abstract string GetDiscovery {
            get;
            }

        }





    /// <summary>
    /// The session class describes the caller of a method.
    /// </summary>
    public abstract class JPCSession {

        /// <summary>
        /// Account name.
        /// </summary>
        public string Account;

        /// <summary>
        /// Fingerprint of authentication key
        /// </summary>
        public string UDF;

        /// <summary>
        /// DNS Address.
        /// </summary>
        public string Domain;

        /// <summary>
        /// If true we have an authentication structure.
        /// </summary>
        public bool Authenticated;

        /// <summary>
        /// Authenticate session data.
        /// </summary>
        /// <param name="UDF">Fingerprint of authentication key to use for authentication.</param>
        public abstract bool Authenticate(string UDF);
      

        }

    /// <summary>
    /// Direct connection between client and service host. Useful for debugging
    /// and for direct access to a service on the same machine.
    /// </summary>
    public partial class DirectSession : JPCSession{

        public DirectSession (string Account) {
            this.Account = Account;
            }

        public override bool Authenticate(string UDF) {
            this.UDF = UDF;
            Authenticated = true;
            return Authenticated;
            }
        }



    /// <summary>
    /// Direct connection between client and service host. Useful for debugging
    /// and for direct access to a service on the same machine.
    /// </summary>
    public abstract partial class JPCRemoteSession : JPCSession {



        /// <summary>
        /// Set the authentication key for use with the session
        /// </summary>
        /// <param name="UDF">Fingerprint of the authentication key.</param>
        /// <returns>True is successful. Otherwise, false.</returns>
        public override bool Authenticate(string UDF) {
            this.UDF = UDF;
            return false;
            }

        public abstract StreamBuffer Post(StreamBuffer Data);

        public virtual string Post (string Tag, JSONObject Request) {

            var Buffer = new StreamBuffer();
            var JSONWriter = new JSONWriter(Buffer);

            // Wrap the request object with the transaction name.
            JSONWriter.WriteObjectStart();
            JSONWriter.WriteToken(Tag,0);
            Request.Serialize(JSONWriter, true);
            JSONWriter.WriteObjectEnd();

            // Send the request
            var ResponseBuffer = Post(Buffer);
            return ResponseBuffer.GetUTF8;
            }

        }

    /// <summary>
    /// Direct connection between client and service host with messages 
    /// encoded and decoded from JSON. For use in debugging issues that
    /// might be the result of JSON encoding issues and to collect samples
    /// for documentation.
    /// </summary>
    public partial class LocalRemoteSession : JPCRemoteSession {
        protected JPCProvider Host;


        /// <summary>
        /// Create a remote session without authentication. This call
        /// is typically used when beginning an interaction that will
        /// lead to the authentication credential being established.
        /// </summary>
        /// <param name="Host">The host implementation</param>
        /// <param name="Domain">Portal address</param>
        /// <param name="Account">User account</param>
        public LocalRemoteSession(JPCProvider Host, string Domain, string Account)
                : this (Host, Domain, Account, null)  {
            }

        /// <summary>
        /// Create a remote session with authentication under the
        /// specified credential.
        /// </summary>
        /// <param name="Host">The host implementation</param>
        /// <param name="Domain">Portal address</param>
        /// <param name="Account">User account</param>
        /// <param name="UDF">Authentication key identifier.</param>
        public LocalRemoteSession(JPCProvider Host, string Domain, string Account, string UDF) {
            this.Account = Account;
            this.Domain = Domain;
            this.UDF = UDF;
            this.Host = Host;
            }

        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="Data">StreamBuffer object containing JSON encoded request.</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override StreamBuffer Post(StreamBuffer Data) {

            var DataText = Data.GetUTF8;
            var JSONReader = new JSONReader(DataText);

            var ResultObject = Host.Dispatch(this, JSONReader);

            return null;
            }

        }



    /// <summary>
    /// Generic exception. Thrown when the specified host is not
    /// valid.
    /// </summary>
    public class InvalidHostService : SystemException {
        public InvalidHostService() : base() { }
        public InvalidHostService(string message) : base(message) { }
        public InvalidHostService(string message, System.Exception inner) : base(message, inner) { }
        }

    /// <summary>
    /// Generic exception. Thrown when the requested operation is not
    /// known to the host.
    /// </summary>
    public class UnknownOperation : SystemException {
        public UnknownOperation() : base() { }
        public UnknownOperation(string message) : base(message) { }
        public UnknownOperation(string message, System.Exception inner) : base(message, inner) { }
        }

    }

