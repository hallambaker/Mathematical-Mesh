//  Copyright © 2021 Threshold Secrets Llc
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

using System.Collections.Generic;
using System.IO;
using System.Net;
using Goedel.Utilities;
using Goedel.Discovery;
namespace Goedel.Protocol {


    /// <summary>
    /// Enumeration describing the different connection modes
    /// </summary>
    public enum JpcConnection {
        ///<summary>The client makes a direct call to the service API.</summary> 
        Direct,
        ///<summary>The client makes a direct call to the service through the JSON
        ///serialization/deserialization interfaces.</summary> 
        Serialized,
        ///<summary>The client makes a remote call to the service by means of a 
        ///HTTP POST method containing a JSON serialization.</summary> 
        Http,
        ///<summary>The client makes a remote call to the service using a ticket 
        ///previously issued by the service by means of either the HTTP or the UDP 
        ///transport.</summary> 
        Ticketed
        }


    /// <summary>
    /// The session class describes the caller of a method.
    /// </summary>
    public abstract class JpcSession : Disposable {

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

        ///<summary>The client interface.</summary> 
        public JpcClientInterface JpcClientInterface;





        /// <summary>
        /// VerifiedAccount instance describing the verified account details. 
        /// </summary>
        public virtual VerifiedAccount VerifiedAccount => !Authenticated ? null :
            new VerifiedAccount() { AccountAddress = AccountAddress };



        /// <summary>
        /// Constructor for a session with service <paramref name="accountAddress"/>.
        /// </summary>
        /// <param name="accountAddress">The name of the service (e.g. example.com) or an account 
        /// at the service (e.g. alice@example.com).</param>
        public JpcSession(string accountAddress) {
            AccountAddress = accountAddress;
            accountAddress?.SplitAccountIDService(out Domain, out Account);
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
        public virtual T GetWebClient<T>() where T : JpcClientInterface, new() {
            var client = new T {
                JpcSession = this
                };
            JpcClientInterface = client;
            return client;
            }


        }




    /// <summary>
    /// Direct connection between client and service host. Useful for debugging
    /// and for direct access to a service on the same machine.
    /// </summary>
    public partial class JpcSessionDirect : JpcSession {
        JpcInterface JpcInterface;

        /// <summary>
        /// Create a direct session for the specified account.
        /// </summary>
        /// <param name="accountAddress">The account name</param>
        /// <param name="jpcInterface">The interfact to which the direct session is bound</param>
        public JpcSessionDirect(JpcInterface jpcInterface, string accountAddress) : base(accountAddress) {
            Authenticated = true;
            JpcInterface = jpcInterface;
            }

        /// <summary>
        /// Return a client bound to the interface using the session.
        /// </summary>
        /// <typeparam name="T">The client type</typeparam>
        /// <returns>The client</returns>
        public override T GetWebClient<T>()  {

            return JpcInterface.GetDirect(this) as T;
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
        /// Post the specified data to the remote service.
        /// </summary>
        /// <param name="data">Input data</param>
        /// <param name="request">The request</param>
        /// <returns>The response data</returns>
        public abstract Stream Post(MemoryStream data, JsonObject request);

        /// <summary>
        /// Construct a Post string.
        /// </summary>
        /// <param name="tag">Operation to perform.</param>
        /// <param name="request">Request data.</param>
        /// <returns>string returned in response.</returns>
        public virtual string Post(string tag, JsonObject request) {

            var buffer = new MemoryStream();
            var JSONWriter = new JsonWriter(buffer);

            // Wrap the request object with the transaction name.
            JSONWriter.WriteObjectStart();
            JSONWriter.WriteToken(tag, 0);
            request.Serialize(JSONWriter, false);
            JSONWriter.WriteObjectEnd();

            // Send the request
            var responseBuffer = Post(buffer, request);

            return responseBuffer.GetUTF8();
            }

        /// <summary>
        /// Post a transaction of type <paramref name="tag"/> with request data 
        /// <paramref name="request"/> to the service expecting a response of type
        /// <paramref name="tagResponse"/>
        /// </summary>
        /// <param name="tag">The transaction tag.</param>
        /// <param name="tagResponse">The response type tag.</param>
        /// <param name="request">The request data.</param>
        /// <returns>The response data.</returns>
        public virtual JsonObject Post(string tag, string tagResponse, JsonObject request) {

            var buffer = new MemoryStream();
            var jsonWriter = new JsonWriter(buffer);
            jsonWriter.WriteObjectStart();
            jsonWriter.WriteToken(tag, 0);
            request.Serialize(jsonWriter, false);
            jsonWriter.WriteObjectEnd();

            var responseBuffer = Post(buffer, request);

            var reader = new JsonReader(responseBuffer);
            var result = JsonObject.FromJson(reader, true);

            return result;
            }

        }

    /// <summary>
    /// Direct connection between client and service host with messages 
    /// encoded and decoded from JSON. For use in debugging issues that
    /// might be the result of JSON encoding issues and to collect samples
    /// for documentation.
    /// </summary>
    public partial class JpcSessionSerialized : JpcRemoteSession {
        /// <summary>
        /// The provider.
        /// </summary>
        public JpcInterface Host { get; }


        /// <summary>
        /// Create a remote session with authentication under the
        /// specified credential.
        /// </summary>
        /// <param name="host">The host implementation</param>
        /// <param name="accountAddress">The service account.</param>
        public JpcSessionSerialized(JpcInterface host, string accountAddress) : base(accountAddress) {
            Host = host;
            Host.AssertNotNull(NYI.Throw);

            }
        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="data">StreamBuffer object containing JSON encoded request.</param>
        /// <param name="requestObject">The request object.</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public override Stream Post(MemoryStream data, JsonObject requestObject) {

            var DataText = data.GetUTF8();
            var JSONReader = new JsonReader(DataText);

            var result = Host.Dispatch(this, JSONReader);
            return new MemoryStream(result.GetBytes());
            }

        }

    /// <summary>
    /// Session of type HTTP.
    /// </summary>
    public partial class JpcSessionHTTP : JpcRemoteSession {

        string Instance { get; }

        WebClient webClient;

        protected override void Disposing() {
            webClient?.Dispose();
            }


        /// <summary>
        /// Return a session  bound to the account <paramref name="account"/>.
        /// </summary>
        /// <param name="account">The account address</param>
        /// <param name="instance">The remote instance identifier.</param>
        public JpcSessionHTTP(string account, string instance = null) :
                base(account) => Instance = instance;

        /// <summary>
        /// Post the specified data to the remote service.
        /// </summary>
        /// <param name="data">Input data</param>
        /// <param name="request">The request</param>
        /// <returns>The response data</returns>
        public override Stream Post(MemoryStream data, JsonObject request) {
            // Get the Web client
            var uri = WebServiceEndpoint.GetEndpoint(Domain, JpcClientInterface.GetWellKnown,
                    JpcClientInterface.GetDiscovery, Instance);

            webClient ??=  new WebClient();


            // Prepare the request
            var requestData = data.GetBuffer();
            var responseData = webClient.UploadData(uri, requestData);
            return new MemoryStream(responseData);
            }
        }

    /// <summary>
    /// Ticketed session.
    /// </summary>
    public partial class JpcSessionTicketed : JpcRemoteSession {

        /// <summary>
        /// Return a session  bound to the account <paramref name="account"/>.
        /// </summary>
        /// <param name="account">The account address</param>
        /// <param name="ticket">The ticket data</param>
        public JpcSessionTicketed(JpcTicket ticket, string account) :
                base(account) {
            }

        /// <summary>
        /// Post the specified data to the remote service.
        /// </summary>
        /// <param name="Data">Input data</param>
        /// <param name="request">The request</param>
        /// <returns>The response data</returns>
        public override Stream Post(MemoryStream Data, JsonObject request) => throw new System.NotImplementedException();

        }

    }

