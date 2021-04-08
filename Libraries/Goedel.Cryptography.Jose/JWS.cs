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
        public virtual JsonReader JSONReader => new(Data);


        /// <summary>Caches the CryptoData instance</summary>
        CryptoData cryptoDataDigest;

        /// <summary>
        /// Call GetCryptoData and return the result, unless GetCryptoData has been
        /// called previously on this instance in which case return the last result. 
        /// </summary>
        public CryptoData CryptoDataDigest {
            get => cryptoDataDigest ?? GetCryptoData().CacheValue(out cryptoDataDigest);
            protected set => cryptoDataDigest = value;
            }


        /// <summary>
        /// Default Constructor
        /// </summary>
        public JoseWebSignature() { }

        /// <summary>
        /// Sign JSON object.
        /// </summary>
        /// <param name="JSONObject">The object to sign</param>
        /// <param name="encoding">The data encoding to use</param>
        /// <param name="signingKey">The signature key</param>
        /// <param name="contentType">Optional IANA content type identifier. 
        /// Omitted if null</param>
        /// <param name="algorithm">The signature and encryption algorithm</param>
        public JoseWebSignature(JsonObject JSONObject,
                    DataEncoding encoding = DataEncoding.JSON,
                    KeyPair signingKey = null,
                    string contentType = null,
                    CryptoAlgorithmId algorithm = CryptoAlgorithmId.Default) :
                this(JSONObject.GetBytes(encoding), signingKey, contentType, algorithm) {
            }

        /// <summary>
        /// Sign binary data.
        /// </summary>
        /// <param name="data">The data to sign</param>
        /// <param name="signingKey">The signature key</param>
        /// <param name="contentType">Optional IANA content type identifier. 
        /// Omitted if null</param>
        /// <param name="algorithm">The signature and encryption algorithm</param>
        public JoseWebSignature(byte[] data,
                    KeyPair signingKey = null,
                    string contentType = null,
                    CryptoAlgorithmId algorithm = CryptoAlgorithmId.Default) {

            var encoder = CryptoCatalog.Default.GetDigest(algorithm);
            cryptoDataDigest = encoder.Process(data);
            Payload = data;

            if (signingKey != null) {
                AddSignature(signingKey, encoder.CryptoAlgorithmID);
                }

            Bind(cryptoDataDigest);
            }

        /// <summary>
        /// Sign text as UTF8 encoding.
        /// </summary>
        /// <param name="text">The text to sign</param>
        /// <param name="signingKey">The signature key</param>
        /// <param name="contentType">Optional IANA content type identifier. 
        /// Omitted if null</param>
        /// <param name="algorithm">The signature and encryption algorithm</param>
        public JoseWebSignature(
                    string text,
                    KeyPair signingKey = null,
                    string contentType = null,
                    CryptoAlgorithmId algorithm = CryptoAlgorithmId.Default) :
                this(System.Text.Encoding.UTF8.GetBytes(text),
                        signingKey, contentType, algorithm) { }


        /// <summary>
        /// Add a signature to an existing data item.
        /// </summary>
        /// <param name="signerKey">The signing key</param>
        /// <param name="contentType">The content type</param>
        /// <param name="providerAlgorithm">The provider algorithm</param>
        /// <returns>The signature instance.</returns>
        public Signature AddSignature(KeyPair signerKey,
                CryptoAlgorithmId providerAlgorithm = CryptoAlgorithmId.Default,
                string contentType = null) {

            Signatures ??= new List<Signature>();

            var alg = signerKey.SignatureAlgorithmID(providerAlgorithm);


            var protectedTBE = new Header() {
                Cty = contentType,
                Val = CryptoDataDigest.Integrity,
                Alg = alg.ToJoseID()
                };
            var protectedJson = protectedTBE.ToJson();

            var signatureValue = signerKey.Sign(protectedJson, providerAlgorithm);

            var header = new Header() {
                Kid = signerKey.KeyIdentifier
                };

            var signature = new Signature() {
                Header = header,
                Protected = protectedJson,
                SignatureValue = signatureValue
                };
            Signatures.Add(signature);
            return signature;

            }

        /// <summary>
        /// Recalculate the CryptoData object parameters. This causes 
        /// </summary>
        /// <returns>The result of the cryptographic operation.</returns>
        public CryptoData GetCryptoData() => cryptoDataDigest;



        private void Bind(CryptoData data,
                string contentType = null
                ) {
            var digestID = data.AlgorithmIdentifier.Digest();

            Unprotected = new Header() {
                Dig = digestID.ToJoseID()
                };
            }

        /// <summary>
        /// Verify the specified signature.
        /// </summary>
        /// <param name="udf">The UDF of the purported signature verification key.</param>
        /// <param name="publicKey">The public signature verification key.</param>
        /// <returns>True if verification succeeds, otherwise false.</returns>
        public bool Verify(string udf, KeyPair publicKey) {
            Assert.AssertTrue(udf == publicKey.KeyIdentifier, FingerprintMatchFailed.Throw);
            return Verify(publicKey);
            }

        /// <summary>
        /// Verify the specified signature.
        /// </summary>
        /// <param name="publicKey">The public signature verification key.</param>
        /// <returns>True if verification succeeds, otherwise false.</returns>
        public bool Verify(KeyPair publicKey) {
            var signature = MatchSigner(publicKey);

            var protectedText = signature.Protected.ToUTF8();
            var header = new Header();
            header.Deserialize(protectedText);

            var algorithm = header.Alg.FromJoseID();
            //var bulkID = algorithm.Bulk();

            var encoder = CryptoCatalog.Default.GetDigest(algorithm);
            var digestOfData = encoder.Process(Data);


            //var match = header.Val.IsEqualTo(digestOfData.Integrity);

            if (!header.Val.IsEqualTo(digestOfData.Integrity)) {
                return false; // Digest does not match
                }

            return publicKey.Verify(signature.Protected, signature.SignatureValue, algorithm);
            }


        /// <summary>
        /// Match a recipient header by key.
        /// </summary>
        /// <param name="signingKey">Key</param>
        /// <returns>The Recipient data for the specified key, if found.</returns>
        public Signature MatchSigner(KeyPair signingKey) => MatchSigner(signingKey.KeyIdentifier);

        /// <summary>
        /// Match a recipient header by key identifier.
        /// </summary>
        /// <param name="udf">Key fingerprint</param>
        /// <returns>The Recipient data for the specified key, if found.</returns>
        public Signature MatchSigner(string udf) {
            foreach (var signature in Signatures) {
                if (signature?.Header?.Kid == udf) {
                    return signature;
                    }
                }
            return null;
            }

        }


    }
