using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Debug;
using Goedel.CryptoLibNG;

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

        public bool CorruptVerify(string UDF, KeyPair Public) {
            Throw.IfNot(UDF == Public.UDF, "Key does not match fingerprint");

            Signature[1] = (byte) (Signature[1] ^ 0xff);

            return Verify(Public);
            }


        public bool Verify(string UDF, KeyPair Public) {
            Throw.IfNot(UDF == Public.UDF, "Key does not match fingerprint");

            return Verify(Public);
            }

        public bool Verify(KeyPair Public) {
            var Verifier = Public.VerificationProvider;

            // unpack the header here.

            // set digest here using alg parameter.


            return Verifier.Verify(Payload, Signature);
            }


        }


    }
