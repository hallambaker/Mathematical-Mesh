using Goedel.Cryptography;

namespace Goedel.XUnit {
    public partial class KeyPairPartialTest : KeyPairPartial {

        public string IdGroup;
        public string IdMember;
        public KeyPair PrivateKey;
        KeyPairAdvanced keyPairService;

        public KeyPairPartialTest(KeyPairAdvanced keyPairGroup,
                KeyPairAdvanced keyPairPart, KeyPairAdvanced keyPairService) : 
            base(keyPairGroup, keyPairPart) => this.keyPairService = keyPairService;

        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="encryptedKey">The encrypted session</param>
        /// <param name="ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="algorithmID">The algorithm to use.</param>
        /// <param name="partial">Partial key agreement carry in (for recryption)</param>
        /// <param name="salt">Optional salt value for use in key derivation. If specified
        /// must match the salt used to encrypt.</param>        
        /// <returns>The decoded data instance</returns>
        public override byte[] Decrypt(
                    byte[] encryptedKey,
                    KeyPair ephemeral = null,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                    KeyAgreementResult partial = null,
                    byte[] salt = null) {

            partial = keyPairService.Agreement(ephemeral);

            return KeyPartial.Decrypt(encryptedKey, ephemeral, algorithmID, partial, salt);

            }

        }
    }

