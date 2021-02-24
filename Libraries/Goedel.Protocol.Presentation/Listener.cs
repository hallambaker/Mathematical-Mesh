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

using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Protocol;
using System.Threading.Tasks;


namespace Goedel.Protocol.Presentation {

    /// <summary>
    /// Port identifier. Specifies an IP address and port number.
    /// </summary>
    public record PortId {
        ///<summary>The IP address.</summary> 
        public IPAddress IPAddress;

        ///<summary>The port number.</summary> 
        public int Port;
        }

    /// <summary>
    /// Port history. Used to track possible abuse.
    /// </summary>
    public record PortHistory {
        ///<summary>Time at which the last challenge was issued.</summary> 
        public DateTime LastChallenge;

        ///<summary>Number of challenges issued.</summary> 
        public int Challenges;

        ///<summary>Number of refusals made.</summary> 
        public int Refusals;

        /// <summary>
        /// Constructor, initialize the last challenge time to now.
        /// </summary>
        public PortHistory() {
            LastChallenge = DateTime.Now;
            }
        }



    /// <summary>
    /// Base class for presentation listeners.
    /// </summary>
    public abstract partial class Listener : Disposable {

        ///<summary>Private credential of self.</summary> 
        public virtual Credential CredentialSelf { get; }

        /// <summary>
        /// Base constructor, populate the common properties.
        /// </summary>
        /// <param name="credentialSelf">The credential used by the listener.</param>
        public Listener(Credential credentialSelf) {
            CredentialSelf = credentialSelf;
            }

        /// <summary>
        /// Request establishment of a client connection to the endpoint 
        /// <paramref name="destinationId"/> 
        /// </summary>
        /// <param name="destinationId">The endpoint to connect to.</param>
        /// <param name="payload">Optional payload. Note that this is sent enclair if
        /// <paramref name="hostCredential"/> is null.</param>
        /// <param name="hostCredential">The host credential. If not null, the payload 
        /// is sent encrypted under this credential.</param>
        /// <returns></returns>
        public abstract ConnectionClient GetConnectionClient(
                    PortId destinationId,
                    byte[] payload = null,
                    Credential hostCredential = null);

        /// <summary>
        /// Accept the inbound connection request described in <paramref name="packetRequest"/>.
        /// </summary>
        /// <param name="packetRequest">Parsed inbound request packet.</param>
        /// <param name="payload">Optional payload response. This is always encryted under the host credential
        /// at minimum.</param>
        /// <returns>The host connection. This may be used to wait for inbound requests from the 
        /// connection.</returns>
        public abstract ConnectionHost Accept(
                    Packet packetRequest,
                    byte[] payload = null);

        /// <summary>
        /// Defer creation of a host connection by sending a challenge to the source.
        /// </summary>
        /// <param name="packetRequest">Parsed inbound request packet.</param>
        /// <param name="payload">Optional payload response. This is always returned enclair.</param>
        public abstract void Challenge(
                    Packet packetRequest,
                    byte[] payload = null);

        /// <summary>
        /// Refuse an inbound connection.
        /// </summary>
        /// <param name="packetRequest">Parsed inbound request packet.</param>
        /// <param name="payload">Optional payload response. This is always returned enclair.</param>
        public abstract void Reject(
                    Packet packetRequest,
                    byte[] payload = null);

        }
    }
