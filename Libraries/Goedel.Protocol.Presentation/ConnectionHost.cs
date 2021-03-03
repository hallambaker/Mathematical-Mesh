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

namespace Goedel.Protocol.Presentation {
    /// <summary>
    /// Presentation host connection. Tracks the state of a host connection.
    /// </summary>
    public abstract partial class SessionResponder : Session {
        ///<inheritdoc/> 
        public override byte[] ClientKeyIn => ClientKeyClientToHost;
        ///<inheritdoc/>
        public override byte[] ClientKeyOut => ClientKeyHostToClient;
        ///<inheritdoc/> 
        public override byte[] MutualKeyIn => MutualKeyClientToHost;
        ///<inheritdoc/>
        public override byte[] MutualKeyOut => MutualKeyHostToClient;
        ///<inheritdoc/> 
        public override Credential HostCredential => CredentialSelf;
        ///<inheritdoc/> 
        public override Credential ClientCredential => CredentialOther;


        ///<summary>The listener this connection host services</summary> 
        public Listener Listener { get; }

        ///<summary>The source port identifier.</summary> 
        public PortId SourcePortId { get; }


        /// <summary>
        /// Constructor for a connection host instance connected to <paramref name="listener"/>
        /// </summary>
        /// <param name="listener">The listener this connection is to service.</param>
        /// <param name="portId">The source port on which this connection was received.</param>
        public SessionResponder(Listener listener, PortId portId) {
            Listener = listener;
            CredentialSelf = Listener?.CredentialSelf;
            SourcePortId = portId;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract Task<byte[]> Receive();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        public abstract void Reply(byte[] payload);





        }

    }
