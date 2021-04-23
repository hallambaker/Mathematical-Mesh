//  Copyright © 2021 Threshold Secrets Llc
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
//  
//  
using Goedel.Protocol;

using Goedel.Utilities;
using Goedel.Protocol.Presentation;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Goedel.Mesh.Credential {

    /// <summary>
    /// JPC Credential bound to a Mesh credential (i.e. Mesh Profile and connection
    /// assertion).
    /// </summary>
    public class MeshCredential : Goedel.Protocol.Presentation.Credential {


        public override string Tag => Constants.ExtensionTagsMeshConnectionTag;


        public override byte[] Value => Connection.DareEnvelope.GetJsonB(false);

        ///<summary>The profile to which this credential is bound</summary> 
        public Profile Profile { get; init;  }

        ///<summary>The connection binding the device presenting the credential to 
        ///<see cref="Profile"/></summary> 
        public Connection Connection { get; init; }

        /////<summary>The user context to which the credential is bound.</summary> 
        //public ContextUser ContextUser { get; init; }


        KeyPairAdvanced AuthenticationPrivate { get; init; }

        ///<summary>The public authentication key.</summary> 
        public override KeyPairAdvanced AuthenticationPublic => 
                    Connection.Authentication.GetKeyPair() as KeyPairAdvanced;

        /// <summary>
        /// Default constructor
        /// </summary>
        public MeshCredential() {
            }

        /// <summary>
        /// Create a Mesh credential from public key data described in <paramref name="data"/>
        /// </summary>
        /// <param name="data">JSON-B encoded connection credential.</param>
        public MeshCredential(byte[] data) {
            var reader = new JsonBcdReader(data);

            //var temp = data.ToUTF8();
            //Screen.WriteLine(temp);

            var envelope = new DareEnvelope();
            envelope.Deserialize(reader);


            var enveloped = new Enveloped<Connection>(envelope);

            //var temp2 = enveloped.Body.ToUTF8();
            //Screen.WriteLine(temp2);

            Connection = enveloped.Decode();


            }

        /// <summary>
        /// Create a credential for the connection <paramref name="connection"/>.
        /// </summary>
        /// <param name="connection">The user context used to construct this credential</param>
        /// <param name="authenticationPrivate">The authentication private key.</param>
        public MeshCredential(
            Connection connection,
                    KeyPair authenticationPrivate) {
            Connection = connection;
            AuthenticationPrivate = authenticationPrivate as KeyPairAdvanced;

            }

        ///<inheritdoc/>
        public override ConnectionResponder GetTemporaryResponder(
                    Listener listener,
                    Packet packetRequest) =>
                    new MeshSessionResponder(listener, packetRequest);


        ///<inheritdoc/>
        public override void AddEphemerals(
                    List<PacketExtension> extensions,
                    ref List<KeyPairAdvanced> ephmeralsOffered) {
            KeyPairAdvanced ephemeral;

            if (ephmeralsOffered != null) {
                ephemeral = ephmeralsOffered[0];
                Screen.WriteLine($"Re-Offer of = {ephemeral}");

                }
            else {
                ephemeral = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
                ephmeralsOffered = new List<KeyPairAdvanced> { ephemeral };
                Screen.WriteLine($"Make Offer of = {ephemeral}");
                }

            var extension = new PacketExtension() {
                Tag = ephemeral.CryptoAlgorithmId.ToJoseID(),
                Value = ephemeral.IKeyAdvancedPublic.Encoding
                };


            extensions.Add(extension);
            }

        ///<inheritdoc/>
        public override void AddCredentials(
                    List<PacketExtension> extensions) {
            //Screen.WriteLine($"Add credentials {Connection.DareEnvelope.GetJson().ToUTF8()}");
            //Screen.WriteLine($"Add credentials {Connection.GetJson().ToUTF8()}");

            //Screen.WriteLine($"Add credentials Length {Connection.GetJsonB().Length}");


            extensions.Add(new PacketExtension() {
                Tag = Tag,
                Value = Value
                }) ;
            //Screen.WriteLine($"  Packed {value.Length}");

            }

        ///<inheritdoc/>
        public override Goedel.Protocol.Presentation.Credential GetCredentials(
                    List<PacketExtension> extensions) {
            foreach (var extension in extensions) {
                if (extension.Tag == Tag) {
                    return new MeshCredential(extension.Value);
                    }
                }

            throw new NYI();
            }

        ///<inheritdoc/>
        public override (KeyPairAdvanced, KeyPairAdvanced) SelectKey(
                    List<PacketExtension> extensions) {
            foreach (var extension in extensions) {
                if (extension.Tag == "X448") {
                    var ephemeral = new KeyPairX448(extension.Value, KeySecurity.Public);
                    //Screen.WriteLine($"Select = {ephemeral}");
                    return (AuthenticationPrivate, ephemeral);
                    }
                }
            throw new NYI();
            }

        ///<inheritdoc/>
            public override (KeyPairAdvanced, KeyPairAdvanced) SelectKey(
                    string keyId, 
                    byte[] ephemeral) =>
                    (AuthenticationPrivate, new KeyPairX448(ephemeral, KeySecurity.Public));

        ///<inheritdoc/>
        public override (KeyPairAdvanced, KeyPairAdvanced) SelectKey() {
            var ephemeralKey = KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced;
            

            return (ephemeralKey, AuthenticationPublic);
            }

        ///<inheritdoc/>
        public override (KeyPairAdvanced, KeyPairAdvanced) SelectKey(
                    List<KeyPairAdvanced> ephemerals, 
                    string keyId) => (ephemerals[0], AuthenticationPublic);
        }
    }
