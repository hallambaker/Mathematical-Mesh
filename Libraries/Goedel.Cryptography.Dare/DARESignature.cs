using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.Dare {
    public partial class DareSignature {

        /// <summary>
        /// Default constructor for use in deserialization.
        /// </summary>
        public DareSignature() {
            }

        /// <summary>
        /// Sign the digest value <paramref name="DigestValue"/> with 
        /// <paramref name="SignerKey"/> and create a DARESignature
        /// instance with the resulting values.
        /// </summary>
        /// <param name="SignerKey">The signature key.</param>
        /// <param name="DigestValue">The digest value.</param>
        /// <param name="DigestId">The digest algorithm used to calculate 
        /// <paramref name="DigestValue"/>.</param>
        /// <param name="KeyDerive">Key derivation function used to calculate a signature witness 
        /// value (if required).</param>
        public DareSignature(KeyPair SignerKey, byte[] DigestValue,
                    CryptoAlgorithmId DigestId, KeyDerive KeyDerive = null) {
            SignatureValue = SignerKey.SignHash(DigestValue, DigestId);
            KeyIdentifier = SignerKey.UDF;
            Alg = SignerKey.SignatureAlgorithmID(DigestId).ToJoseID();

            if (KeyDerive != null) {
                WitnessValue = KeyDerive.Derive(SignatureValue);
                }


            }
        }

    }
