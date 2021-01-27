﻿//   Copyright © 2015 by Comodo Group Inc.
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
    /// Enumeration describing the different connection modes
    /// </summary>
    public enum JpcConnection {
        ///<summary>The client makes a direct call to the service API.</summary> 
        Direct,
        ///<summary>The client calls the service API through the 
        ///serialization/deserialization interfaces.</summary> 
        Serialized,
        ///<summary>The client calls the service by means of a HTTP request.</summary> 
        Http,
        ///<summary>The client calls the service by means of a UDP request if
        ///possible and otherwise uses HTTP</summary> 
        Udp

        }



    /// <summary>
    /// Base class for a Host dispatcher.
    /// </summary>
    public abstract class JpcProvider {


        /// <summary>
        /// Dispatch Class. Reads input from the provided reader and attempts to
        /// dispatch a method in response. Note that the calling routine may throw 
        /// an error. This must be caught and processed by the host dispatch class.
        /// </summary>
        /// <param name="Session">The service session that is to handle the request.</param>
        /// <param name="JSONReader">The input stream to be read</param>
        /// <returns>The response to the request.</returns>
        public abstract Goedel.Protocol.JsonObject Dispatch(JpcSession Session,
            JsonReader JSONReader);

        }



    /// <summary>
    /// Base class for all JPC server and client classes.
    /// </summary>
    public abstract class JpcInterface {

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

        /// <summary>
        /// The active JpcSession.
        /// </summary>		
		public virtual JpcSession JpcSession { get; set; }


        }





    /// <summary>
    /// The session class describes the caller of a method.
    /// </summary>
    public abstract class JpcSession {

        ///<summary>The service identifier (Account@Domain)</summary>
        public string AccountAddress;


        ///<summary>The account portion of <see cref="AccountAddress"/></summary>
        public string Account;

        ///<summary>The domain portion of <see cref="AccountAddress"/></summary>
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
            new VerifiedAccount() { AccountAddress = AccountAddress };


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
            AccountAddress = accountAddress;
            accountAddress.SplitAccountIDService(out Domain, out Account);
            }


        /// <summary>
        /// Factory method returning a new JPC interface calling a service of
        /// type <typeparamref name="T"/> with an initial <see cref="JpcSession"/> binding of
        /// the calling instance. This binding MAY be updated through interaction with the 
        /// service, e.g. to replace a HTTP/JSON binding authenticated by means of a direct
        /// key exchange with a key exchange established in a referenced token.
        /// </summary>
        /// <typeparam name="T">Type of the instance to return.</typeparam>
        /// <returns></returns>
        public T GetWebClient<T>() where T : JpcInterface, new() => new T {
            JpcSession = this
            };



        }

    /// <summary>
    /// Direct connection between client and service host. Useful for debugging
    /// and for direct access to a service on the same machine.
    /// </summary>
    public partial class DirectSession : JpcSession {




        /// <summary>
        /// Create a direct session for the specified account.
        /// </summary>
        /// <param name="accountAddress">The account name</param>
        public DirectSession(string accountAddress) : base(accountAddress) => Authenticated = true;


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
    public abstract partial class JpcRemoteSession : JpcSession {


        /// <summary>
        /// Create a direct session for the specified account.
        /// </summary>
        /// <param name="accountAddress">The account name</param>
        public JpcRemoteSession(string accountAddress) : base(accountAddress) {
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
        /// <param name="request">The request</param>
        /// <returns>The response data</returns>
        public abstract Stream Post(MemoryStream Data, JsonObject request);

        /// <summary>
        /// Construct a Post string.
        /// </summary>
        /// <param name="Tag">Operation to perform.</param>
        /// <param name="request">Request data.</param>
        /// <returns>string returned in response.</returns>
        public virtual string Post(string Tag, JsonObject request) {

            var Buffer = new MemoryStream();
            var JSONWriter = new JSONWriter(Buffer);

            // Wrap the request object with the transaction name.
            JSONWriter.WriteObjectStart();
            JSONWriter.WriteToken(Tag, 0);
            request.Serialize(JSONWriter, false);
            JSONWriter.WriteObjectEnd();

            // Send the request
            var ResponseBuffer = Post(Buffer, request);

            return ResponseBuffer.GetUTF8();
            }

        }

    /// <summary>
    /// Direct connection between client and service host with messages 
    /// encoded and decoded from JSON. For use in debugging issues that
    /// might be the result of JSON encoding issues and to collect samples
    /// for documentation.
    /// </summary>
    public partial class LocalRemoteSession : JpcRemoteSession {
        /// <summary>
        /// The provider.
        /// </summary>
        protected JpcProvider Host;


        /// <summary>
        /// Create a remote session with authentication under the
        /// specified credential.
        /// </summary>
        /// <param name="Host">The host implementation</param>
        /// <param name="accountAddress">The service account.</param>
        public LocalRemoteSession(JpcProvider Host, string accountAddress) : base(accountAddress) =>
                this.Host = Host;

        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="Data">StreamBuffer object containing JSON encoded request.</param>
        /// <param name="requestObject">The request object.</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override Stream Post(MemoryStream Data, JsonObject requestObject) {

            var DataText = Data.GetUTF8();
            var JSONReader = new JsonReader(DataText);

            var result = Host.Dispatch(this, JSONReader);
            return new MemoryStream(result.GetBytes());
            }

        }


    }

