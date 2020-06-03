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

using Goedel.Utilities;

using System.Collections.Generic;
using System.IO;

namespace Goedel.Protocol {

    /// <summary>
    /// Base class for a Host
    /// </summary>
    public abstract class JPCProvider {

        /// <summary>
        /// If set, all domain names are mapped onto 127.0.0.1
        /// </summary>
        public static bool LocalLoopback = false;



        /// <summary>
        /// The dispatch service.
        /// </summary>
        public List<JPCInterface> Interfaces = new List<JPCInterface>();

        /// <summary>
        /// Dispatch Class. Reads input from the provided reader and attempts to
        /// dispatch a method in response. Note that the calling routine may throw 
        /// an error. This must be caught and processed by the host dispatch class.
        /// </summary>
        /// <param name="Session">The service session that is to handle the request.</param>
        /// <param name="JSONReader">The input stream to be read</param>
        /// <returns>The response to the request.</returns>
        public abstract Goedel.Protocol.JSONObject Dispatch(JpcSession Session,
            JSONReader JSONReader);


        /// <summary>
        /// Construct a URI for a well known service.
        /// </summary>
        /// <param name="Domain">DNS domain name of the service.</param>
        /// <param name="WellKnown">The well-known service identifier tag (see RFC 5785).</param>
        /// <param name="TLS">If true, the https scheme is used, otherwise http is used.</param>
        /// <param name="HostMode">If true, service is self hosted.</param>
        /// <param name="Prefix">The service prefix type</param>
        /// <returns>The formed URI</returns>
        public static string WellKnownToURI(string Domain, string WellKnown,
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
    public abstract class JpcSession {

        ///<summary>The service identifier (Account@Domain)</summary>
        public string ServiceID;


        ///<summary>The account portion of ServiceID</summary>
        public string Account;

        ///<summary>The domain portion of ServiceID</summary>
        public string Domain;

        /// <summary>
        /// Fingerprint of authentication key
        /// </summary>
        public string UDF;

        /// <summary>
        /// If true we have an authentication structure.
        /// </summary>
        public bool Authenticated;

        /// <summary>
        /// VerifiedAccount instance describing the verified account details. 
        /// </summary>
        public virtual VerifiedAccount VerifiedAccount => !Authenticated ? null :
            new VerifiedAccount() { AccountAddress = ServiceID };


        /// <summary>
        /// Authenticate session data.
        /// </summary>
        /// <param name="UDF">Fingerprint of authentication key to use for authentication.</param>
        /// <returns>True if authentication succeeded, otherwise false.</returns>
        public abstract bool Authenticate(string UDF);



        /// <summary>
        /// Constructor for a session with service <paramref name="accountAddress"/>.
        /// </summary>
        /// <param name="accountAddress">The name of the service (e.g. example.com) or an account 
        /// at the service (e.g. alice@example.com).</param>
        public JpcSession(string accountAddress) {
            ServiceID = accountAddress;
            accountAddress.SplitAccountIDService(out Domain, out Account);
            }

        }

    /// <summary>
    /// Direct connection between client and service host. Useful for debugging
    /// and for direct access to a service on the same machine.
    /// </summary>
    public partial class DirectSession : JpcSession {




        /// <summary>
        /// Create a direct session for the specified account.
        /// </summary>
        /// <param name="serviceID">The account name</param>
        public DirectSession(string serviceID) : base(serviceID) => Authenticated = true;


        /// <summary>
        /// Authenticate session using the specified credentials
        /// </summary>
        /// <param name="UDF">UDF of credential to use.</param>
        /// <returns>If true, request was authenticated.</returns>
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
    public abstract partial class JPCRemoteSession : JpcSession {


        /// <summary>
        /// Create a direct session for the specified account.
        /// </summary>
        /// <param name="serviceID">The account name</param>
        public JPCRemoteSession(string serviceID) : base(serviceID) {
            }

        /// <summary>
        /// Set the authentication key for use with the session
        /// </summary>
        /// <param name="UDF">Fingerprint of the authentication key.</param>
        /// <returns>True is successful. Otherwise, false.</returns>
        public override bool Authenticate(string UDF) {
            this.UDF = UDF;
            return false;
            }

        /// <summary>
        /// Post the specified data to the remote service.
        /// </summary>
        /// <param name="Data">Input data</param>
        /// <returns>The response data</returns>
        public abstract Stream Post(MemoryStream Data);

        /// <summary>
        /// Construct a Post string.
        /// </summary>
        /// <param name="Tag">Operation to perform.</param>
        /// <param name="Request">Request data.</param>
        /// <returns>string returned in response.</returns>
        public virtual string Post(string Tag, JSONObject Request) {

            var Buffer = new MemoryStream();
            var JSONWriter = new JSONWriter(Buffer);

            // Wrap the request object with the transaction name.
            JSONWriter.WriteObjectStart();
            JSONWriter.WriteToken(Tag, 0);
            Request.Serialize(JSONWriter, false);
            JSONWriter.WriteObjectEnd();

            // Send the request
            var ResponseBuffer = Post(Buffer);

            return ResponseBuffer.GetUTF8();
            }

        }

    /// <summary>
    /// Direct connection between client and service host with messages 
    /// encoded and decoded from JSON. For use in debugging issues that
    /// might be the result of JSON encoding issues and to collect samples
    /// for documentation.
    /// </summary>
    public partial class LocalRemoteSession : JPCRemoteSession {
        /// <summary>
        /// The provider.
        /// </summary>
        protected JPCProvider Host;


        /// <summary>
        /// Create a remote session with authentication under the
        /// specified credential.
        /// </summary>
        /// <param name="Host">The host implementation</param>
        /// <param name="serviceID">The service account.</param>
        public LocalRemoteSession(JPCProvider Host, string serviceID) : base(serviceID) =>
                this.Host = Host;

        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="Data">StreamBuffer object containing JSON encoded request.</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override Stream Post(MemoryStream Data) {

            var DataText = Data.GetUTF8();
            var JSONReader = new JSONReader(DataText);

            var result = Host.Dispatch(this, JSONReader);
            return new MemoryStream(result.GetBytes());
            }

        }


    }

