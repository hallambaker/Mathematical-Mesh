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

using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;
using Goedel.Protocol.Presentation;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using System;
using System.Collections;
using System.Collections.Generic;
using Goedel.Mesh.Test;
using System.Threading;
using System.Threading.Tasks;


namespace Goedel.XUnit {
    public class TestListener : Listener {
        #region // Properties

        public const string ChallengeTag = "Challenge";

        #endregion
        #region // Constructors

        ///<inheritdoc/>
        public TestListener(Credential credentialSelf) : base(credentialSelf) {
            //AnonymousConnection = new TestConnectionHost (
            }
        #endregion

        #region // Override Methods

        /////<inheritdoc/>
        //public override SessionResponder Accept(
        //            Packet packetRequest,
        //            byte[] payload = null) => new TestConnectionHost(this, packetRequest);

        /////<inheritdoc/>
        //public override void Challenge(Packet packetRequest, byte[] payload = null) => throw new NotImplementedException();

        ///<inheritdoc/>
        public override SessionInitiator GetConnectionClient(PortId destinationId, byte[] payload = null, Credential hostCredential = null) => throw new NotImplementedException();

        ///<inheritdoc/>
        public override void Reject(Packet packetRequest, byte[] payload = null) => throw new NotImplementedException();
        #endregion

        #region // Methods

        Dictionary<string, SessionResponder> PendingChallenges { get; }  = new();

        public SessionResponder GetConnectionHost(Packet packetRequest) {

            if (packetRequest is PacketClientCompleteDeferred packetClientCompleteDeferred) {
                var challengeId = TestConnectionHost.GetChallenge(packetClientCompleteDeferred.PlaintextExtensions);
                PendingChallenges.TryGetValue(challengeId, out var connection).AssertTrue(NYI.Throw);
                connection.CompleteClientCompleteDeferred(packetClientCompleteDeferred);
                return connection;
                }

            return new TestConnectionHost(this, packetRequest);

            }

        public byte[] SerializeChallenge(Packet packetRequest, byte[] payload = null) {

            var connection = new TestConnectionHost(this, packetRequest);

            var challenge = connection.MakeChallenge(packetRequest);
            var challengeExtensions = new List<PacketExtension> {
                new PacketExtension () {
                    Tag = TestListener.ChallengeTag,
                    Value = challenge.ToBytes()
                    }
                };

            // stash the challenge connection here.
            PendingChallenges.Add(challenge, connection);

            var packet = (packetRequest) switch {

                PacketClientInitial => connection.SerializeHostChallenge1 (payload, challengeExtensions),
                PacketClientExchange => connection.SerializeHostChallenge2 (payload, challengeExtensions),
                _ => throw new NYI()
                };


            return packet;
            }


        #endregion
        }



    public class TestConnectionClient : SessionInitiator {

        public TestConnectionClient(
                        Credential credential
                        ) => CredentialSelf = credential;

        /// <summary>
        /// Add a response value over the current state to <paramref name="extensions"/>
        /// </summary>
        /// <param name="extensions">List of extensions to add the ephemerals to.</param>
        public override void AddResponse(
                List<PacketExtension> extensions) {
            foreach (var extension in PacketIn.PlaintextExtensions) {

                if (extension.Tag == TestListener.ChallengeTag) {
                    extensions.Add(extension);
                    }
                }

            }


         }


    public class TestConnectionHost : SessionResponder {
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
                if (extension.Tag == TestListener.ChallengeTag) {
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
            ephemeral.TestEqual(packetRequest.PlaintextExtensions[0].Value);

            ephemeral = null;

            return true;
            }


        public TestConnectionHost(
                Listener listener,
                Packet packetIn
                ) : base(listener, packetIn.SourcePortId) {
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
