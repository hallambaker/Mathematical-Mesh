//   Copyright © 2015 by Comodo Group Inc.
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

using System.Collections.Generic;

namespace Goedel.Cryptography.Jose {


    public partial class JoseWebSignature {

        /// <summary>
        /// The signed data.
        /// </summary>
        public virtual byte[] Data {
            get => Payload;
            set => Payload = value;
            }

        /// <summary>The JSONReader.</summary>
        public virtual JSONReader JSONReader => new JSONReader(Data);


        /// <summary>Caches the CryptoData instance</summary>
        protected CryptoData _CryptoDataDigest = null;

        /// <summary>
        /// Call GetCryptoData and return the result, unless GetCryptoData has been
        /// called previously on this instance in which case return the last result. 
        /// </summary>
        public CryptoData CryptoDataDigest {
            get {
                _CryptoDataDigest ??= GetCryptoData();
                return _CryptoDataDigest;
                }
            }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public JoseWebSignature() { }

        /// <summary>
        /// Sign JSON object.
        /// </summary>
        /// <param name="JSONObject">The object to sign</param>
        /// <param name="Encoding">The data encoding to use</param>
        /// <param name="SigningKey">The signature key</param>
        /// <param name="ContentType">Optional IANA content type identifier. 
        /// Omitted if null</param>
        /// <param name="Algorithm">The signature and encryption algorithm</param>
        public JoseWebSignature(JSONObject JSONObject,
                    DataEncoding Encoding = DataEncoding.JSON,
                    KeyPair SigningKey = null,
                    string ContentType = null,
                    CryptoAlgorithmId Algorithm = CryptoAlgorithmId.Default) :
                this(JSONObject.GetBytes(Encoding), SigningKey, ContentType, Algorithm) {
            }

        /// <summary>
        /// Sign binary data.
        /// </summary>
        /// <param name="Data">The data to sign</param>
        /// <param name="SigningKey">The signature key</param>
        /// <param name="ContentType">Optional IANA content type identifier. 
        /// Omitted if null</param>
        /// <param name="Algorithm">The signature and encryption algorithm</param>
        public JoseWebSignature(byte[] Data,
                    KeyPair SigningKey = null,
                    string ContentType = null,
                    CryptoAlgorithmId Algorithm = CryptoAlgorithmId.Default) {

            var Encoder = CryptoCatalog.Default.GetDigest(Algorithm);
            _CryptoDataDigest = Encoder.Process(Data);
            Payload = Data;

            if (SigningKey != null) {
                AddSignature(SigningKey, Encoder.CryptoAlgorithmID);
                }

            Bind(_CryptoDataDigest);
            }

        /// <summary>
        /// Sign text as UTF8 encoding.
        /// </summary>
        /// <param name="Text">The text to sign</param>
        /// <param name="SigningKey">The signature key</param>
        /// <param name="ContentType">Optional IANA content type identifier. 
        /// Omitted if null</param>
        /// <param name="Algorithm">The signature and encryption algorithm</param>
        public JoseWebSignature(
                    string Text,
                    KeyPair SigningKey = null,
                    string ContentType = null,
                    CryptoAlgorithmId Algorithm = CryptoAlgorithmId.Default) :
                this(System.Text.Encoding.UTF8.GetBytes(Text),
                        SigningKey, ContentType, Algorithm) { }


        /// <summary>
        /// Add a signature to an existing data item.
        /// </summary>
        /// <param name="SignerKey">The signing key</param>
        /// <param name="ContentType">The content type</param>
        /// <param name="ProviderAlgorithm">The provider algorithm</param>
        /// <returns>The signature instance.</returns>
        public Signature AddSignature(KeyPair SignerKey,
                CryptoAlgorithmId ProviderAlgorithm = CryptoAlgorithmId.Default,
                string ContentType = null) {

            Signatures ??= new List<Signature>();

            var Alg = SignerKey.SignatureAlgorithmID(ProviderAlgorithm);


            var ProtectedTBE = new Header() {
                Cty = ContentType,
                Val = CryptoDataDigest.Integrity,
                Alg = Alg.ToJoseID()
                };
            var Protected = ProtectedTBE.ToJson();

            var SignatureValue = SignerKey.Sign(Protected, ProviderAlgorithm);

            var Header = new Header() {
                Kid = SignerKey.KeyIdentifier
                };

            var Signature = new Signature() {
                Header = Header,
                Protected = Protected,
                SignatureValue = SignatureValue
                };
            Signatures.Add(Signature);
            return Signature;

            }

        /// <summary>
        /// Recalculate the CryptoData object parameters. This causes 
        /// </summary>
        /// <returns>The result of the cryptographic operation.</returns>
        public CryptoData GetCryptoData() => _CryptoDataDigest;



        private void Bind(CryptoData Data,
                string ContentType = null
                ) {
            var DigestID = Data.AlgorithmIdentifier.Digest();

            Unprotected = new Header() {
                Dig = DigestID.ToJoseID()
                };
            }

        /// <summary>
        /// Verify the specified signature.
        /// </summary>
        /// <param name="UDF">The UDF of the purported signature verification key.</param>
        /// <param name="Public">The public signature verification key.</param>
        /// <returns>True if verification succeeds, otherwise false.</returns>
        public bool Verify(string UDF, KeyPair Public) {
            Assert.True(UDF == Public.KeyIdentifier, FingerprintMatchFailed.Throw);
            return Verify(Public);
            }

        /// <summary>
        /// Verify the specified signature.
        /// </summary>
        /// <param name="Public">The public signature verification key.</param>
        /// <returns>True if verification succeeds, otherwise false.</returns>
        public bool Verify(KeyPair Public) {
            var Signature = MatchSigner(Public);

            var ProtectedText = Signature.Protected.ToUTF8();
            var Header = new Header();
            Header.Deserialize(ProtectedText);

            var Algorithm = Header.Alg.FromJoseID();
            var BulkID = Algorithm.Bulk();

            var Encoder = CryptoCatalog.Default.GetDigest(Algorithm);
            var DigestOfData = Encoder.Process(Data);


            var Match = Header.Val.IsEqualTo(DigestOfData.Integrity);

            if (!Header.Val.IsEqualTo(DigestOfData.Integrity)) {
                return false; // Digest does not match
                }

            return Public.Verify(Signature.Protected, Signature.SignatureValue, Algorithm);
            }


        /// <summary>
        /// Match a recipient header by key.
        /// </summary>
        /// <param name="SigningKey">Key</param>
        /// <returns>The Recipient data for the specified key, if found.</returns>
        public Signature MatchSigner(KeyPair SigningKey) => MatchSigner(SigningKey.KeyIdentifier);

        /// <summary>
        /// Match a recipient header by key identifier.
        /// </summary>
        /// <param name="UDF">Key fingerprint</param>
        /// <returns>The Recipient data for the specified key, if found.</returns>
        public Signature MatchSigner(string UDF) {
            foreach (var Signature in Signatures) {
                if (Signature?.Header?.Kid == UDF) {
                    return Signature;
                    }
                }
            return null;
            }

        }


    }
