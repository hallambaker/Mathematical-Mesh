//Sample license text.
using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Debug;
using Goedel.LibCrypto;

namespace Goedel.Cryptography.Jose {


    public partial class JoseWebSignature {

        Header _ParsedHeader;

        CryptoAlgorithmID _BulkAlgorithm = CryptoAlgorithmID.NULL;
        /// <summary>
        /// Get or set the bulk encryption algorithm
        /// </summary>
        public CryptoAlgorithmID BulkAlgorithm {
            get {
                if (_BulkAlgorithm == CryptoAlgorithmID.NULL) {
                    _BulkAlgorithm = CryptoCatalog.Default.AlgorithmEncryption;
                    }
                return _BulkAlgorithm;
                }
            set { _BulkAlgorithm = value; }
            }

        /// <summary>
        /// Parse the binary signature header
        /// </summary>
        public Header ParsedHeader {
            get {
                _ParsedHeader = Goedel.Cryptography.Jose.Header.From(Header);
                return _ParsedHeader;
                }

            }

        /// <summary>
        /// Sign the specified data with the specified key and construct
        /// the corresponding JWS object.
        /// </summary>
        /// <param name="Data">Data to be signed</param>
        /// <param name="SignatureKey">The signature key</param>
        public JoseWebSignature(byte [] Data, KeyPair SignatureKey) {
            Payload = Data;

            var Signer = SignatureKey.SignatureProvider;

            // if we wanted to change the digest provider
            // Signer.DigestAlgorithm = CryptoAlgorithmID.SHA_2_256;

            var PreHeader = new SignatureHeader(Signer);

            // This isn't working right now because the code does not
            // fetch the private key from the store.
            
            Payload = Data;
            Header = PreHeader.GetBytes(false);
            var SignatureValue = Signer.Sign(Payload);
            Signature = SignatureValue.Integrity;

            }


        /// <summary>
        /// Verify the specified signature.
        /// </summary>
        /// <param name="UDF">The UDF of the purported signature verification key.</param>
        /// <param name="Public">The public signature verification key.</param>
        /// <returns>True if verification succeeds, otherwise false.</returns>
        public bool Verify(string UDF, KeyPair Public) {
            Throw.IfNot(UDF == Public.UDF, "Key does not match fingerprint");

            return Verify(Public);
            }


        /// <summary>
        /// Verify the specified signature.
        /// </summary>
        /// <param name="Public">The public signature verification key.</param>
        /// <returns>True if verification succeeds, otherwise false.</returns>
        public bool Verify(KeyPair Public) {
            var Verifier = Public.VerificationProvider;

            // unpack the header here.

            // set digest here using alg parameter.


            return Verifier.Verify(Payload, Signature);
            }


        }


    }
