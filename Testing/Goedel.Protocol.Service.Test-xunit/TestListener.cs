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
        #endregion
        #region // Constructors

        ///<inheritdoc/>
        public TestListener(Credential credentialSelf) : base(credentialSelf) {

            }
        #endregion

        #region // Override Methods

        ///<inheritdoc/>
        public override ConnectionHost Accept(
                    Packet packetRequest,
                    byte[] payload = null) => new TestConnectionHost(this, packetRequest);

        ///<inheritdoc/>
        public override void Challenge(Packet packetRequest, byte[] payload = null) => throw new NotImplementedException();

        ///<inheritdoc/>
        public override ConnectionClient GetConnectionClient(PortId destinationId, byte[] payload = null, Credential hostCredential = null) => throw new NotImplementedException();

        ///<inheritdoc/>
        public override void Reject(Packet packetRequest, byte[] payload = null) => throw new NotImplementedException();
        #endregion

        #region // Methods
        #endregion
        }


    public class TestCredential : Credential {

        const string credentialTag = "TestCredential";

        KeyPairAdvanced KeySign;
        KeyPairAdvanced KeyExchange;

        public TestCredential() {
            KeySign = KeyPair.Factory(CryptoAlgorithmId.Ed448, KeySecurity.Device) as KeyPairAdvanced;
            KeyExchange = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
            }

        public TestCredential(byte[] encodedCredential) {

            KeyExchange = new KeyPairX448(encodedCredential, KeySecurity.Public);
            }

        ///<inheritdoc/>
        public override void AddCredentials(List<PacketExtension> extensions) =>
                extensions.Add(new PacketExtension() {
                    Tag = credentialTag,
                    Value = KeyExchange.IKeyAdvancedPublic.Encoding
                    });



        /// <summary>
        /// Add an extension containing this credential to <paramref name="extensions"/>.
        /// </summary>
        /// <param name="extensions">List of extensions to add the credential to.</param>
        public override  Credential GetCredentials(
                    List<PacketExtension> extensions
                    ) {
            foreach (var extension in extensions) {
                if (extension.Tag == credentialTag) {
                    return new TestCredential(extension.Value);
                    }
                }
            throw new NYI();

            }


        ///<inheritdoc/>
        public override void AddEphemerals(List<PacketExtension> extensions, 
                        ref List<KeyPairAdvanced> ephmeralsOffered) {

            KeyPairAdvanced ephemeral;

            if (ephmeralsOffered != null) {
                ephemeral = ephmeralsOffered[0];
                }
            else {
                ephemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
                ephmeralsOffered = new List<KeyPairAdvanced> { ephemeral };
                }

            var extension = new PacketExtension() {
                Tag = ephemeral.CryptoAlgorithmId.ToJoseID(),
                Value = ephemeral.IKeyAdvancedPublic.Encoding
                };


            extensions.Add(extension);

            }

        ///<inheritdoc/>
        public override (KeyPairAdvanced, KeyPairAdvanced) SelectKey(List<PacketExtension> extensions) {
            foreach (var extension in extensions) {
                if (extension.Tag == "X448") {
                    return (KeyExchange, new KeyPairX448(extension.Value, KeySecurity.Public));
                    }
                }
            throw new NYI();
            }

        ///<inheritdoc/>
        public override (KeyPairAdvanced, KeyPairAdvanced) SelectKey(string keyId, byte[] ephemeral) =>
                    (KeyExchange, new KeyPairX448(ephemeral, KeySecurity.Public));

        ///<inheritdoc/>
        public override (KeyPairAdvanced, KeyPairAdvanced) SelectKey() {


            var ephemeralKey = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
            return (ephemeralKey, KeyExchange);

            }

        public override (KeyPairAdvanced, KeyPairAdvanced) SelectKey(
                    List<KeyPairAdvanced> ephemerals,
                    string keyId) {
            return (ephemerals[0], KeyExchange);
            }

        }


    public class TestConnectionClient : ConnectionClient {

        public TestConnectionClient(
                        Credential credential
                        ) {
            CredentialSelf = credential;
            }

        public override Task<byte[]> Transact(byte[] payload) => throw new NotImplementedException();
        }


    public class TestConnectionHost : ConnectionHost {
        public override Task<byte[]> Receive() => throw new NotImplementedException();
        public override void Reply(byte[] payload) => throw new NotImplementedException();


        public TestConnectionHost(
                Listener listener,
                Packet packetIn
                ) : base(listener) {
            PacketIn = packetIn;
            if (packetIn is PacketClientExchange packetClientExchange) {
                // We have accepted the connection, cause the client exchange to be performed.
                CompleteClientExchange(packetClientExchange);
                }

            //CredentialSelf = credential;
            }


        }


    }
