using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

using System;

namespace Goedel.Cryptography {
    /// <summary>
    /// Wrapper around a partial key pair.
    /// </summary>
    public class CryptoKeySymmetric : CryptoKey {

        /// <summary>
        /// UDF fingerprint of the key
        /// </summary>
        public override string KeyIdentifier { get; }

        /// <summary>
        /// UDF fingerprint of the key
        /// </summary>
        public override byte[] UDFBytes { get; }

        ///<summary>The secret key.</summary>
        private byte[] SecretValue { get; }


        /// <summary>
        /// Constructor taking the secret value from the binary value 
        /// <paramref name="secretValue"/>
        /// </summary>
        /// <param name="secretValue">The secret value.</param>
        /// <param name="udfTypeIdentifier">The UDF type identifier to create. This
        /// is either <see cref="UdfTypeIdentifier.Encryption"/> or
        /// <see cref="UdfTypeIdentifier.EncryptionAuthentication"/></param>
        public CryptoKeySymmetric(byte[] secretValue, 
                    UdfTypeIdentifier udfTypeIdentifier = UdfTypeIdentifier.Encryption) {
            SecretValue = secretValue;
            UDFBytes = UDF.SymetricKeyIdBytes(SecretValue); ;
            KeyIdentifier = UDF.SymetricKeyId(SecretValue, udfTypeIdentifier: udfTypeIdentifier);
            }

        /// <summary>
        /// Constructor taking the secret value from the UDF presentation of the secret key
        /// <paramref name="encryptionKey"/>
        /// </summary>
        /// <param name="encryptionKey">The UDF presentation of the secret value.</param>
        public CryptoKeySymmetric(string encryptionKey) :
                this(UDF.SymmetricKeyData(encryptionKey)) {
            }

        /// <summary>
        /// Encrypt the bulk key.
        /// </summary>
        /// <returns>The encoder</returns>
        public override void Encrypt(
            byte[] key,
            out byte[] exchange,
            out KeyPair ephemeral,
            byte[] info = null) {

            var keyDerive = new KeyDeriveHKDF(SecretValue, (byte[])null);
            var encryptionKey = keyDerive.Derive(info, Length: 256);
            exchange = Platform.KeyWrapRFC3394.Wrap(encryptionKey, key);

            ephemeral = null;
            }


        /// <summary>
        /// Perform a key exchange to decrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="encryptedKey">The encrypted session key</param>
        /// <param name="ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="partial">Partial key agreement value (for recryption)</param>
        /// <param name="info">Optional info value for use in key derivation. If specified
        /// must match the info value used to encrypt.</param>
        /// <param name="algorithmID">The algorithm to use (redundant?)</param>
        /// <returns>The decoded data instance</returns>
        public override byte[] Decrypt(
                    byte[] encryptedKey,
                    KeyPair ephemeral = null,
                    CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                    KeyAgreementResult partial = null,
                    byte[] info = null) {

            var keyDerive = new KeyDeriveHKDF(SecretValue, (byte[])null);
            var encryptionKey = keyDerive.Derive(info, Length: 256);

            return Platform.KeyWrapRFC3394.Unwrap(encryptionKey, encryptedKey);
            }


        /// <summary>
        /// Sign a precomputed digest (Not implemented)
        /// </summary>
        /// <param name="data">The data to sign.</param>
        /// <param name="algorithmID">The algorithm to use.</param>
        /// <param name="context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <returns>The signature data</returns>
        public override byte[] SignHash(byte[] data, CryptoAlgorithmId algorithmID =
            CryptoAlgorithmId.Default, byte[] context = null) => throw new NotImplementedException();

        }


    }
