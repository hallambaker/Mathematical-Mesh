//  Copyright © 2020 Threshold Secrets llc
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
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Protocol.Presentation;
using System.Text;
using System.Collections.Generic;

namespace Goedel.Mesh {
    public partial class ConnectionAccount {
        ///<summary>Typed enveloped data</summary> 
        public Enveloped<ConnectionAccount> EnvelopedConnectionAccount =>
            envelopedConnectionDevice ?? new Enveloped<ConnectionAccount>(DareEnvelope).
                    CacheValue(out envelopedConnectionDevice);
        Enveloped<ConnectionAccount> envelopedConnectionDevice;

        /// <summary>
        /// Minimize the connection data to remove unnecessary data.
        /// </summary>
        public void Strip() {
            if (Authentication != null) {
                Authentication.Udf = null;
                }
            }

        }
    public partial class ConnectionDevice : ICredential {

        ///<summary>Typed enveloped data</summary> 
        public Enveloped<ConnectionDevice> EnvelopedConnectionDevice =>
            envelopedConnectionDevice ?? new Enveloped<ConnectionDevice>(DareEnvelope).
                    CacheValue(out envelopedConnectionDevice);

        /////<inheritdoc cref="ICredential"/>
        //public string Tag => throw new System.NotImplementedException();

        /////<inheritdoc cref="ICredential"/>
        //public byte[] Value => throw new System.NotImplementedException();

        ///<inheritdoc cref="ICredential"/>
        public KeyPairAdvanced AuthenticationPublic => Authentication.GetKeyPairAdvanced();



        Enveloped<ConnectionDevice> envelopedConnectionDevice;


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public ConnectionDevice() {
            }


        /// <summary>
        /// Constructor for use by deserializers.
        /// </summary>
        public static ConnectionDevice FromValue (byte[] data) {
            throw new NYI();
            }


        /// <summary>
        /// Append a description of the instance to the StringBuilder <paramref name="builder"/> with
        /// a leading indent of <paramref name="indent"/> units. The cryptographic context from
        /// the key collection <paramref name="keyCollection"/> is used to decrypt any encrypted data.
        /// </summary>
        /// <param name="builder">The string builder to write to.</param>
        /// <param name="indent">The number of units to indent the presentation.</param>
        /// <param name="keyCollection">The key collection to use to obtain decryption keys.</param>
        public override void ToBuilder(StringBuilder builder, int indent = 0, IKeyCollection keyCollection = null) {

            builder.AppendIndent(indent, $"Connection Device");
            indent++;
            DareEnvelope.Report(builder, indent);
            indent++;
            //builder.AppendIndent(indent, $"KeyOfflineSignature: {KeyOfflineSignature.UDF} ");

            //if (KeysOnlineSignature != null) {
            //    foreach (var online in KeysOnlineSignature) {
            //        builder.AppendIndent(indent, $"   KeysOnlineSignature: {online.UDF} ");
            //        }
            //    }
            builder.AppendIndent(indent, $"KeyEncryption:       {Encryption.Udf} ");
            builder.AppendIndent(indent, $"KeyAuthentication:   {Authentication.Udf} ");

            }

        //public ICredential GetCredentials(List<PacketExtension> extensions) => throw new System.NotImplementedException();
        //public void AddEphemerals(List<PacketExtension> extensions, ref List<KeyPairAdvanced> ephmeralsOffered) => throw new System.NotImplementedException();
        //public void AddCredentials(List<PacketExtension> extensions) => throw new System.NotImplementedException();
        //public (KeyPairAdvanced, KeyPairAdvanced) SelectKey(List<PacketExtension> extensions) => throw new System.NotImplementedException();
        //public (KeyPairAdvanced, KeyPairAdvanced) SelectKey(string keyId, byte[] ephemeral) => throw new System.NotImplementedException();

        ///<inheritdoc cref="ICredential"/>
        public (KeyPairAdvanced, KeyPairAdvanced) SelectKey() =>
            (KeyPair.Factory(CryptoAlgorithmId.X448, KeySecurity.Device) as KeyPairAdvanced,
                        AuthenticationPublic);

        ///<inheritdoc cref="ICredential"/>
        public (KeyPairAdvanced, KeyPairAdvanced) SelectKey(List<KeyPairAdvanced> ephemerals, string keyId) =>
            (ephemerals[0], AuthenticationPublic);
        }

    }
