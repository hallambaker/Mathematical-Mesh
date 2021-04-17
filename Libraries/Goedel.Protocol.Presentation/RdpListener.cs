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

using Goedel.Cryptography;
//using Goedel.Protocol.Presentation;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Threading;

namespace Goedel.Protocol.Presentation {

    /// <summary>
    /// RDP Listener class, accepts connections from multiple sources and passes them to
    /// the specified service.
    /// </summary>
    public class RdpListener : Listener {

        /// <summary>
        /// Base constructor, populate the common properties.
        /// </summary>
        /// <param name="credential">The credential used by the listener.</param>
        public RdpListener(Credential credential) : base(credential) {
            }


        ConnectionResponder sessionResponderChallenge = null;

        ///<inheritdoc/>
        public override ConnectionResponder GetTemporaryResponder(
            Packet packetRequest) => sessionResponderChallenge ??
                    new MeshSessionResponder(this).CacheValue(out sessionResponderChallenge);

        ///<inheritdoc/>
        public override List<PacketExtension> MakeChallenge(
                Packet packetRequest,
                byte[] payload = null) {
            var bytes = Platform.GetRandomBytes(16);
            var challenge = new PacketExtension() {
                Tag = Constants.ExtensionChallengeNonce,
                Value = bytes
                };
            return new List<PacketExtension> { challenge };
            }

        ///<inheritdoc/>
        public override bool VerifyChallenge(
                Packet packetRequest) => true;

        ///<inheritdoc/>
        public override ConnectionResponder Accept(
                Packet packetRequest) {


            var responder = new MeshSessionResponder(this, packetRequest);

            switch (packetRequest) {
                case PacketClientCompleteDeferred packetClientCompleteDeferred: {
                    responder.CompleteClientCompleteDeferred(packetClientCompleteDeferred);
                    responder.RemoteStreamId = packetClientCompleteDeferred.SourceId;
                    break;
                    }

                default: {
                    throw new NYI();
                    }
                }

            // register the responder.    
            if (DictionarySessionsInbound.TryGetValue(responder.LocalStreamId, out var session)) {
                DictionarySessionsInbound.Remove(responder.LocalStreamId);
                
                }

            DictionarySessionsInbound.Add(responder.LocalStreamId, responder);
            // need to set a flag here so that we can send out the stream id on the connection!


            return responder;
            }

        }

    }
