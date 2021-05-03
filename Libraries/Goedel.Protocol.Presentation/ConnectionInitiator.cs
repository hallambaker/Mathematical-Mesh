//  Copyright © 2021 by Threshold Secrets Llc.
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

using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;

namespace Goedel.Protocol.Presentation {
    /// <summary>
    /// Presentation client connection. Tracks the state of a client connection.
    /// </summary>
    public partial class ConnectionInitiator : RudConnection {

        #region // Properties
        ///<inheritdoc/>
        public override byte[] ClientKeyIn => ClientKeyHostToClient;
        ///<inheritdoc/>
        public override byte[] ClientKeyOut => ClientKeyClientToHost;
        ///<inheritdoc/>
        public override byte[] MutualKeyIn => MutualKeyHostToClient;
        ///<inheritdoc/> 
        public override byte[] MutualKeyOut => MutualKeyClientToHost;
        ///<inheritdoc/>
        public override Credential HostCredential => CredentialOther;
        ///<inheritdoc/>
        public override Credential ClientCredential => CredentialSelf;


        ///<summary>The verified account.</summary> 
        public VerifiedAccount VerifiedAccount { get; set; }

        ///<summary>The connection domain.</summary> 
        public string Domain { get; set; }

        ///<summary>The connection instance specifier (to allow multiple services
        ///to be run for testing, etc.</summary> 
        public string Instance { get; set; }





        ///<summary>Reusable packet challenge</summary> 
        public Packet PacketChallenge;

        ///<summary>The primary RUD stream.</summary> 
        public RudStream RudStreamInitial { get; set; }


        ///<inheritdoc/>
        public override void AddResponse(
                List<PacketExtension> extensions) => extensions.Add(new PacketExtension() {
                    Tag = Constants.ExtensionTagsChallengeTag,
                    Value = RudStreamInitial.ChallengeNonce
                    });


        ///<summary>The Web Client</summary> 
        public WebClient WebClient { get; set; }


        #endregion
        #region // Constructors

        /// <summary>
        /// Return an instance of a client connecting to host <paramref name="domain"/> using
        /// device credential <paramref name="initiatorCredential"/> with client protocol binding
        /// <paramref name="protocol"/>.
        /// </summary>
        /// <param name="initiatorCredential">The device credential of the initiator</param>
        /// <param name="domain">The domain of the responder being connected to.</param>
        /// <param name="instance"></param>
        /// <param name="transportTypes">The transport types.</param>
        /// <param name="protocol">The service protocol to return a client stream for.</param>
        public ConnectionInitiator (
                    Credential initiatorCredential, 
                    string domain,
                    string instance = null, 
                    TransportType transportTypes = TransportType.All,
                    string protocol=null) {

            Domain = domain;
            Instance = instance;
            CredentialSelf = initiatorCredential;
            WebClient = new WebClient();


            //// Create the initial stream NB Do NOT re-present the credential used to
            //// initialize the connection.
            //RudStreamInitial = new RudStreamClient(null, protocol, null, this) {
            //    StreamState = StreamState.Initial
            //    };
            }


        #endregion
        #region // Destructor

        ///<inheritdoc/>
        protected override void Disposing() => WebClient?.Dispose();

        #endregion
        #region // Methods


        /// <summary>
        /// Return a client bound to the connection via the relevant protocol
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetClient<T>(Credential credential=null) where T : JpcClientInterface, new() {

            var client = new T();

            client.JpcSession = new RudStreamClient(null, client.GetWellKnown, credential, rudConnection:this);


            //RudStreamInitial.MakeStreamClient(client.GetWellKnown, credential);

            return client;
            }

        #endregion

        }

    }
