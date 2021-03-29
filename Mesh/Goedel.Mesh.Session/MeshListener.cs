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
using System.Threading.Tasks;
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
        public override SessionResponder Challenge(
            Packet packetRequest,
            byte[] payload = null) => sessionResponderChallenge ??
                    new MeshSessionResponder(this, packetRequest);


        }



    public class MeshSessionResponder : SessionResponder {


        static ulong sessionIdCount = 0;

        public ulong SessionId;

        public override Task<byte[]> Receive() => throw new NotImplementedException();
        public override void Reply(byte[] payload) => throw new NotImplementedException();

        byte[] ephemeral;


        /// <summary>
        /// Add a challenge value over the current state to <paramref name="extensions"/>
        /// </summary>
        /// <param name="extensions">List of extensions to add the ephemerals to.</param>
        public override void AddChallenge(
                List<PacketExtension> extensions) {

            }

        public static string GetChallenge(List<PacketExtension> packetExtensions) {
            foreach (var extension in packetExtensions) {
                if (extension.Tag == MeshListener.ChallengeTag) {
                    return extension.Value.ToUTF8();
                    }
                }
            throw new NYI();
            }


        public string MakeChallenge(Packet packetRequest) {

            ephemeral = packetRequest switch {
                PacketClientInitial => packetRequest.PlaintextExtensions[0].Value,
                PacketClientExchange clientExchange => clientExchange.ClientEphemeral,
                _ => throw new NYI()
                };


            return UDF.Nonce(128);
            }

        public bool VerifyChallenge(Packet packetRequest) {
            //ephemeral.TestEqual(packetRequest.PlaintextExtensions[0].Value);

            ephemeral = null;

            return true;
            }


        public MeshSessionResponder(
                Listener listener,
                Packet packetIn
                ) : base(listener, packetIn.SourcePortId) {

            // need to assign a unique SessionId here.

            SessionId = Interlocked.Increment(ref sessionIdCount);

            //PacketIn = packetIn;
            //if (packetIn is PacketClientExchange packetClientExchange) {
            //    // We have accepted the connection, cause the client exchange to be performed.
            //    CompleteClientExchange(packetClientExchange);
            //    }
            //if (packetIn is PacketClientCompleteDeferred packetClientCompleteDeferred) {
            //    // We have accepted the connection, cause the client exchange to be performed.
            //    CompleteClientCompleteDeferred(packetClientCompleteDeferred);
            //    }
            //CredentialSelf = credential;
            }


        }

    }
