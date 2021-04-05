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
using Goedel.Protocol.Presentation;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Threading;

namespace Goedel.Mesh.Session {
    public class MeshListener : Listener {

        public const string ChallengeTag = "Challenge";

        public MeshListener(Credential credential) : base(credential) {
            }


        public override SessionInitiator GetConnectionClient(
                    PortId destinationId,
                    byte[] payload = null,
                    Credential hostCredential = null) => throw new NotImplementedException();





        public override void Reject(Packet packetRequest, byte[] payload = null) => throw new NotImplementedException();


        SessionResponder sessionResponderChallenge = null;

        ///<inheritdoc/>
        public override SessionResponder GetTemporaryResponder(
            Packet packetRequest) => sessionResponderChallenge ??
                    new MeshSessionResponder(this).CacheValue(out sessionResponderChallenge);


        public override List<PacketExtension> MakeChallenge(
                Packet packetRequest,
                byte[] payload = null) {
            var bytes = Platform.GetRandomBytes(16);
            var challenge = new PacketExtension() {
                Tag = ChallengeTag,
                Value = bytes
                };
            return new List<PacketExtension> { challenge };
            }


        public override bool VerifyChallenge(
                Packet packetRequest) => true;


        public override SessionResponder Accept(
                Packet packetRequest) {

            // this is failing because there is no means of knowing which ephemeral was given away.



            var responder = new MeshSessionResponder(this, packetRequest);

            switch (packetRequest) {
                case PacketClientCompleteDeferred packetClientCompleteDeferred: {
                    responder.CompleteClientCompleteDeferred(packetClientCompleteDeferred);
                    break;
                    }

                default: {
                    throw new NYI();
                    }
                //case PacketClientExchange packetClientExchange: {
                //    responder.CompleteClientComplete(packetClientExchange);
                //    break;
                //    }
                }

            // register the responder.    
            if (DictionarySessionsInbound.TryGetValue(responder.LocalStreamId, out var session)) {
                DictionarySessionsInbound.Remove(responder.LocalStreamId);
                DictionarySessionsInbound.Add(responder.LocalStreamId, responder);
                }

            return responder;
            }

        }

    }
