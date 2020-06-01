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
        /// <paramref name="signerKey"/> and create a DARESignature
        /// instance with the resulting values.
        /// </summary>
        /// <param name="signerKey">The signature key.</param>
        /// <param name="DigestValue">The digest value.</param>
        /// <param name="digestId">The digest algorithm used to calculate 
        /// <paramref name="DigestValue"/>.</param>
        /// <param name="keyDerive">Key derivation function used to calculate a signature witness 
        /// value (if required).</param>
        public DareSignature(CryptoKey signerKey, byte[] DigestValue,
                    CryptoAlgorithmId digestId, KeyDerive keyDerive = null) {

            SignatureValue = signerKey.SignHash(DigestValue, digestId);
            KeyIdentifier = signerKey.KeyIdentifier;
            Alg = signerKey.SignatureAlgorithmID(digestId).ToJoseID();

            if (keyDerive != null) {
                WitnessValue = keyDerive.Derive(SignatureValue);
                }


            }
        }

    }
