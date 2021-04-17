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
using System.Net;


namespace Goedel.Protocol.Presentation {


    /// <summary>
    /// Presentation client connection. Tracks the state of a client connection.
    /// </summary>
    public abstract partial class ConnectionInitiator : Connection {

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
        public string Protocol { get; set; }
        public string Instance { get; set; }

        ///<summary>If true, the connection is connected to the remote endpoint.</summary> 
        public bool Connected { get; protected set; } = false;

        ///<summary>The object encoding for use in the connection</summary> 
        public ObjectEncoding ObjectEncoding { get; set; } = ObjectEncoding.JSON;

        ///<summary>Reusable packet challenge</summary> 
        public Packet PacketChallenge;


        public RdpStream RdpStreamInitial { get; set; }


        public string Uri { get; set; }



        protected WebClient WebClient { get; set; }


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

            var sessionStream = RdpStreamInitial.MakeStreamClient(credential);
            return new() {
                JpcSession = sessionStream
                };
            }

        #endregion

        }

    }
