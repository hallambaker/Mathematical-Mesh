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
    /// Client side connection state.
    /// </summary>
    public enum ClientState {
        ///<summary>Initial state, sending either Initial or Cloaked.</summary> 
        Initial,
        ///<summary>Host challenge received, sending answer.</summary> 
        Challenge,
        ///<summary>Connection established, sending packets.</summary> 
        Write,
        ///<summary>Connection terminated, cannot be used further.</summary> 
        Abort
        }


    /// <summary>
    /// Presentation client connection. Tracks the state of a client connection.
    /// </summary>
    public abstract partial class SessionInitiator : Session {
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

        ///<summary>The current state of this client.</summary> 
        ClientState clientState;


        ///// <summary>
        ///// Perform a request/response transation with request payload <paramref name="payload"/>
        ///// and return the result.
        ///// </summary>
        ///// <param name="payload">The binary payload</param>
        ///// <returns>The binar</returns>
        //public abstract Task<byte[]> Transact(byte[] payload);


        }

    }
