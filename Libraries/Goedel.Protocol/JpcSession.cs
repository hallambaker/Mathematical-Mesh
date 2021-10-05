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


using System.IO;

using Goedel.Utilities;
namespace Goedel.Protocol {

    /// <summary>
    /// Describe the validation of the credential
    /// </summary>
    public enum CredentialValidation {
        ///<summary>Validation not attempted.</summary> 
        None,
        ///<summary>Validation failed.</summary> 
        Failed,
        ///<summary>The authentication key is valid under the device credential pressented.</summary> 
        Device,
        ///<summary>The authentication key is valid under the account credential pressented.</summary> 
        Account
        }

    /// <summary>
    /// Credential interface
    /// </summary>
    public interface ICredential {
        ///<summary>The account name claimed under the credential</summary> 
        public string Account { get; }

        ///<summary>The provider servicing the account claimed under the credential</summary> 
        public string Provider { get; }

        ///<summary>The authentication key used to authenticate the device.</summary> 
        public string AuthenticationKeyId { get; }

        ///<summary>Validation status of <see cref="AuthenticationKeyId"/> with respect to the credential data.</summary> 
        public CredentialValidation CredentialValidation { get; }
        }

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
    public abstract class JpcSession : Disposable, IJpcSession {

        ///<summary>The credential to which the session is bound.</summary> 
        public ICredential Credential { get; set; }

        ///<summary>The client interface.</summary> 
        public JpcClientInterface JpcClientInterface;

        ///<inheritdoc/> 
        public virtual string TargetAccount { get; init; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public JpcSession() {
            }

        /// <summary>
        /// Constructor for a session with credential <paramref name="credential"/>.
        /// </summary>
        /// <param name="credential">The credential to be used.</param>
        public JpcSession(ICredential credential) => Credential = credential;


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
                JpcSession = this as IJpcSession
                };
            JpcClientInterface = client;
            return client;
            }

        /// <summary>
        /// Post a transaction request and return the resulting object.
        /// </summary>
        /// <param name="tag">The transaction identifier.</param>
        /// <param name="request">The request data.</param>
        /// <returns>The transaction result.</returns>
        public virtual JsonObject Post(string tag, JsonObject request) =>
                    throw new System.NotImplementedException();

        ///<inheritdoc cref="IJpcSession"/>
        public abstract IJpcSession Rebind(ICredential credential);
        }




    /// <summary>
    /// Direct connection between client and service host. Useful for debugging
    /// and for direct access to a service on the same machine.
    /// </summary>
    public abstract partial class JpcRemoteSession : JpcSession, IJpcSession {


        /// <summary>
        /// Create a direct session  with credential <paramref name="credential"/>.
        /// </summary>
        /// <param name="credential">The credential to be used.</param>
        public JpcRemoteSession(ICredential credential) : base(credential) {
            }


        ///<inheritdoc/>
        public override IJpcSession Rebind(ICredential credential) {
            Credential = credential;
            return this;
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
        /// <param name="credential">The credential to be used.</param>
        public JpcSessionSerialized(JpcInterface host, ICredential credential) : base(credential) {
            Host = host;
            Host.AssertNotNull(NYI.Throw);

            }
        /// <summary>
        /// Post a request and retrieve the response.
        /// </summary>
        /// <param name="data">StreamBuffer object containing JSON encoded request.</param>
        /// <param name="requestObject">The request object.</param>
        /// <returns>StreamBuffer object containing JSON encoded response.</returns>
        public virtual Stream Post(MemoryStream data, JsonObject requestObject) {

            var DataText = data.GetUTF8();
            var JSONReader = new JsonReader(DataText);

            var result = Host.Dispatch(this, JSONReader);
            return new MemoryStream(result.GetBytes());
            }


        /// <summary>
        /// Post a transaction of type <paramref name="tag"/> with request data 
        /// <paramref name="request"/> to the service expecting a response of type
        /// </summary>
        /// <param name="tag">The transaction tag.</param>
        /// <param name="request">The request data.</param>
        /// <returns>The response data.</returns>
        public override JsonObject Post(string tag, JsonObject request) {

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


    }

