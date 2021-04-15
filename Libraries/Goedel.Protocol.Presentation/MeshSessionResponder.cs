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
using Goedel.Cryptography.Jose;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Goedel.Protocol.Presentation {
    public class MeshSessionResponder : SessionResponder {


        ///<summary>The source Id to be used by this responder when returning packets.</summary> 

        public StreamId SourceId;


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



        static List<PacketExtension> EphemeralExtensionsCurrent;

        static List<KeyPairAdvanced> EphemeralsPrevious;

        static List<KeyPairAdvanced> EphemeralsCurrent;

        //static DateTime EphemeralsCreated;

        static DateTime EphemeralsExpire;

        static TimeSpan EphemeralValidity = new(1, 0, 0);




        //public static string GetChallenge(List<PacketExtension> packetExtensions) {
        //    foreach (var extension in packetExtensions) {
        //        if (extension.Tag == Constants.ExtensionChallengeNonce) {
        //            return extension.Value.ToUTF8();
        //            }
        //        }
        //    throw new NYI();
        //    }


        //public string MakeChallenge(Packet packetRequest) {

        //    ephemeral = packetRequest switch {
        //        PacketClientInitial => packetRequest.PlaintextExtensions[0].Value,
        //        PacketClientExchange clientExchange => clientExchange.ClientEphemeral,
        //        _ => throw new NYI()
        //        };


        //    return UDF.Nonce(128);
        //    }

        //public bool VerifyChallenge(Packet packetRequest) {
        //    //ephemeral.TestEqual(packetRequest.PlaintextExtensions[0].Value);

        //    ephemeral = null;

        //    return true;
        //    }
        
        /// <summary>
        /// Constructor, create a responder connection for <paramref name="listener"/>
        /// </summary>
        /// <param name="listener">The listener managing the connection.</param>
        /// <param name="packetIn">The received packet.</param>
        public MeshSessionResponder(
                Listener listener,
                Packet packetIn=null
                ) : base(listener) {

            if (packetIn != null) {
                LocalStreamId = StreamId.GetStreamId();
                ReturnStreamId = LocalStreamId.GetValue();

                PacketIn = packetIn;
                }
            }

        // should create just one set of ephemerals, hand them out to everyone for an hour and then rotate them.


        public void RollEphemerals() {
            EphemeralsPrevious = EphemeralsCurrent;
            var ephemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
            EphemeralsCurrent = new List<KeyPairAdvanced> { ephemeral };
            var extension = new PacketExtension() {
                Tag = ephemeral.CryptoAlgorithmId.ToJoseID(),
                Value = ephemeral.IKeyAdvancedPublic.Encoding
                };

            EphemeralExtensionsCurrent = new List<PacketExtension> { extension };
            //EphemeralsCreated = DateTime.Now;
            EphemeralsExpire = DateTime.Now + EphemeralValidity;
            }


        List<KeyPairAdvanced> ephemeralsOffered;
        ///<inheritdoc/>
        public override void AddEphemerals(byte[] destinationId, List<PacketExtension> extensions) {
            if (EphemeralsCurrent == null | DateTime.Now > EphemeralsExpire) {
                RollEphemerals();
                }
            foreach (var ephemeral in EphemeralExtensionsCurrent) {
                extensions.Add(ephemeral);
                }
            }


        //KeyPairAdvanced GetEphemeral(List<KeyPairAdvanced> keyPairAdvanceds, string keyId) {
        //    if (keyPairAdvanceds == null) {
        //        return null;
        //        }
        //    foreach (var ephemeral in keyPairAdvanceds) {
        //        if (ephemeral.MatchKeyIdentifier(keyId)) {
        //            return ephemeral;
        //            }
        //        }
        //    return null;
        //    }

        //KeyPairAdvanced GetEphemeral(string keyId) =>
        //    GetEphemeral(EphemeralsCurrent, keyId) ?? GetEphemeral(EphemeralsPrevious, keyId);




        ///<inheritdoc/>
        public override void MutualKeyExchange(string keyId) {

            // look up keyId in the credential other.

            // get the ephemeral value with the matching algorithm.






            // reconstitute the ephemeral from the stream id.

            //var (privateEphemeral, publickey) = ClientCredential.SelectKey(ephemeralsOffered, keyId);

            var privateEphemeral = EphemeralsCurrent[0];
            MutualKeyExchange(privateEphemeral, CredentialOther.AuthenticationPublic);
            }




        }

    }
