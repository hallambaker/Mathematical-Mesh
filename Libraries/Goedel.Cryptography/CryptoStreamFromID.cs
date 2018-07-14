using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.Cryptography.Algorithms;

namespace Goedel.Cryptography {

    /// <summary>
    /// Extension methods to return .NET Standard cryptographic providers from
    /// CryptoAlgorithmID identifiers.
    /// </summary>
    public static class CryptoStreamFromID {

        private static Aes Aes = Aes.Create();

        /// <summary>
        /// Return the key size and block size for the algorithm specified by <paramref name="CryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="CryptoAlgorithmID">The algorithm to report the sizes of.</param>
        /// <returns>Tuple consisting (int KeySize, int BlockSize).</returns>
        public static (int KeySize, int BlockSize) GetKeySize(
                    this CryptoAlgorithmID CryptoAlgorithmID
                    ) {

            switch (CryptoAlgorithmID) {
                case CryptoAlgorithmID.AES128:
                case CryptoAlgorithmID.AES128GCM: 
                case CryptoAlgorithmID.AES128CTS: 
                case CryptoAlgorithmID.AES128HMAC: 
                case CryptoAlgorithmID.AES128CBCNone: 
                case CryptoAlgorithmID.AES128ECB: return (128, 128);

                case CryptoAlgorithmID.AES256CBC:
                case CryptoAlgorithmID.AES256GCM:
                case CryptoAlgorithmID.AES256CTS:
                case CryptoAlgorithmID.AES256HMAC:
                case CryptoAlgorithmID.AES256CBCNone:
                case CryptoAlgorithmID.AES256ECB: return (256, 128);

                case CryptoAlgorithmID.HMAC_SHA_2_256: return (128, 0);

                case CryptoAlgorithmID.HMAC_SHA_2_512:
                case CryptoAlgorithmID.HMAC_SHA_2_512T128: return (256, 0);
                }


            return (-1, -1);
            }

        /// <summary>
        /// Return an encryption transform the algorithm specified by <paramref name="CryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="CryptoAlgorithmID">The algorithm.</param>
        /// <param name="Key">The key to use.</param>
        /// <param name="IV">The initialization vector (if required).</param>
        /// <returns>The encryption transform.</returns>
        public static ICryptoTransform CreateEncryptor(
                        this CryptoAlgorithmID CryptoAlgorithmID,
                        byte[] Key,
                        byte[] IV=null) {

            switch (CryptoAlgorithmID) {
                case CryptoAlgorithmID.AES128:
                case CryptoAlgorithmID.AES128GCM:
                case CryptoAlgorithmID.AES128CTS:
                case CryptoAlgorithmID.AES128CBCNone:
                case CryptoAlgorithmID.AES128ECB:
       
                case CryptoAlgorithmID.AES256CBC:
                case CryptoAlgorithmID.AES256GCM:
                case CryptoAlgorithmID.AES256CTS:
                case CryptoAlgorithmID.AES256CBCNone:
                case CryptoAlgorithmID.AES256ECB: 

                case CryptoAlgorithmID.AES128HMAC:
                case CryptoAlgorithmID.AES256HMAC: {
                    return Aes.CreateEncryptor(Key, IV);
                    }
                }
            return null;
            }

        /// <summary>
        /// Return a decryption transform the algorithm specified by <paramref name="CryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="CryptoAlgorithmID">The algorithm.</param>
        /// <param name="Key">The key to use.</param>
        /// <param name="IV">The initialization vector (if required).</param>
        /// <returns>The decryption transform.</returns>
        public static ICryptoTransform CreateDecryptor(
                        this CryptoAlgorithmID CryptoAlgorithmID,
                        byte[] Key,
                        byte[] IV) {

            switch (CryptoAlgorithmID) {
                case CryptoAlgorithmID.AES128:
                case CryptoAlgorithmID.AES128GCM:
                case CryptoAlgorithmID.AES128CTS:
                case CryptoAlgorithmID.AES128CBCNone:
                case CryptoAlgorithmID.AES128ECB:

                case CryptoAlgorithmID.AES256CBC:
                case CryptoAlgorithmID.AES256GCM:
                case CryptoAlgorithmID.AES256CTS:
                case CryptoAlgorithmID.AES256CBCNone:
                case CryptoAlgorithmID.AES256ECB:

                case CryptoAlgorithmID.AES128HMAC:
                case CryptoAlgorithmID.AES256HMAC: {
                    return Aes.CreateDecryptor(Key, IV);
                    }
                }
            return null;
            }

        /// <summary>
        /// Return a Message Authentication Code provider for the algorithm 
        /// specified by <paramref name="CryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="CryptoAlgorithmID">The algorithm.</param>
        /// <param name="Key">The key to use.</param>
        /// <returns>The Message Authentication Code provider.</returns>
        public static HashAlgorithm CreateMac(
                        this CryptoAlgorithmID CryptoAlgorithmID,
                        byte[] Key) {

            switch (CryptoAlgorithmID) {
                case CryptoAlgorithmID.HMAC_SHA_2_256: return new HMACSHA256(Key);
                case CryptoAlgorithmID.HMAC_SHA_2_512: return new HMACSHA512(Key);
                case CryptoAlgorithmID.HMAC_SHA_2_512T128: return new HMACSHA512(Key);

                case CryptoAlgorithmID.AES128HMAC:  return new HMACSHA256(Key);
                case CryptoAlgorithmID.AES256HMAC:  return new HMACSHA512(Key);
                   
                }
            return null;
            }

        /// <summary>
        /// Return a digest provider for the algorithm 
        /// specified by <paramref name="CryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="CryptoAlgorithmID">The algorithm.</param>
        /// <returns>The digest provider.</returns>
        public static HashAlgorithm CreateDigest(
                        this CryptoAlgorithmID CryptoAlgorithmID
                        ) {

            switch (CryptoAlgorithmID) {
                case CryptoAlgorithmID.SHA_2_256: return SHA256.Create();
                case CryptoAlgorithmID.SHA_2_512: return SHA512.Create();
                case CryptoAlgorithmID.SHA_2_512T128: return SHA512.Create();

                case CryptoAlgorithmID.SHA_3_256: return new SHA3Managed(256);
                case CryptoAlgorithmID.SHA_3_512: return new SHA3Managed(512);
                case CryptoAlgorithmID.SHAKE_128: return new SHAKE128();
                case CryptoAlgorithmID.SHAKE_256: return new SHAKE256();
                }
            return null;
            }

        /// <summary>
        /// Return a shake provider for the algorithm 
        /// specified by <paramref name="CryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="CryptoAlgorithmID">The algorithm.</param>
        /// <param name="hashBitLength">The number of output bits to generate.</param>
        /// <returns>The digest provider.</returns>
        public static HashAlgorithm CreateShake(
                        CryptoAlgorithmID CryptoAlgorithmID,
                        int hashBitLength
                        ) {

            switch (CryptoAlgorithmID) {
                case CryptoAlgorithmID.SHAKE_128: return new SHAKE128(hashBitLength);
                case CryptoAlgorithmID.SHAKE_256: return new SHAKE256(hashBitLength);
                }
            return null;
            }

        }
    }
