using System.IO;
using System.Security.Cryptography;

using Goedel.Cryptography.Algorithms;
using Goedel.IO;
using Goedel.Utilities;

namespace Goedel.Cryptography {

    /// <summary>
    /// Extension methods to return .NET Standard cryptographic providers from
    /// CryptoAlgorithmID identifiers.
    /// </summary>
    public static class CryptoStreamFromID {

        private static Aes Aes = Aes.Create();

        /// <summary>
        /// Return the key size and block size for the algorithm specified by <paramref name="cryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The algorithm to report the sizes of.</param>
        /// <returns>Tuple consisting (int KeySize, int BlockSize).</returns>
        public static (int KeySize, int BlockSize) GetKeySize(
                    this CryptoAlgorithmId cryptoAlgorithmID
                    ) {

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmId.AES128:
                case CryptoAlgorithmId.AES128GCM:
                case CryptoAlgorithmId.AES128CTS:
                case CryptoAlgorithmId.AES128HMAC:
                case CryptoAlgorithmId.AES128CBCNone:
                case CryptoAlgorithmId.AES128ECB: return (128, 128);

                case CryptoAlgorithmId.Default:
                case CryptoAlgorithmId.AES256:
                case CryptoAlgorithmId.AES256CBC:
                case CryptoAlgorithmId.AES256GCM:
                case CryptoAlgorithmId.AES256CTS:
                case CryptoAlgorithmId.AES256HMAC:
                case CryptoAlgorithmId.AES256CBCNone:
                case CryptoAlgorithmId.AES256ECB: return (256, 128);

                case CryptoAlgorithmId.HMAC_SHA_2_256: return (128, 0);

                case CryptoAlgorithmId.HMAC_SHA_2_512:
                case CryptoAlgorithmId.HMAC_SHA_2_512T128: return (256, 0);

                }


            return (-1, -1);
            }

        /// <summary>
        /// Return an encryption transform the algorithm specified by <paramref name="cryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The algorithm.</param>
        /// <param name="key">The key to use.</param>
        /// <param name="iv">The initialization vector (if required).</param>
        /// <returns>The encryption transform.</returns>
        public static ICryptoTransform CreateEncryptor(
                        this CryptoAlgorithmId cryptoAlgorithmID,
                        byte[] key,
                        byte[] iv = null) {

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmId.Default:
                case CryptoAlgorithmId.AES128:
                case CryptoAlgorithmId.AES128GCM:
                case CryptoAlgorithmId.AES128CTS:
                case CryptoAlgorithmId.AES128CBCNone:
                case CryptoAlgorithmId.AES128ECB:
                case CryptoAlgorithmId.AES256:
                case CryptoAlgorithmId.AES256CBC:
                case CryptoAlgorithmId.AES256GCM:
                case CryptoAlgorithmId.AES256CTS:
                case CryptoAlgorithmId.AES256CBCNone:
                case CryptoAlgorithmId.AES256ECB:

                case CryptoAlgorithmId.AES128HMAC:
                case CryptoAlgorithmId.AES256HMAC: {
                    return Aes.CreateEncryptor(key, iv);
                    }

                }
            return null;
            }

        /// <summary>
        /// Return a decryption transform the algorithm specified by <paramref name="cryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The algorithm.</param>
        /// <param name="key">The key to use.</param>
        /// <param name="iV">The initialization vector (if required).</param>
        /// <returns>The decryption transform.</returns>
        public static ICryptoTransform CreateDecryptor(
                        this CryptoAlgorithmId cryptoAlgorithmID,
                        byte[] key,
                        byte[] iV) {

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmId.Default:
                case CryptoAlgorithmId.AES128:
                case CryptoAlgorithmId.AES128GCM:
                case CryptoAlgorithmId.AES128CTS:
                case CryptoAlgorithmId.AES128CBCNone:
                case CryptoAlgorithmId.AES128ECB:

                case CryptoAlgorithmId.AES256CBC:
                case CryptoAlgorithmId.AES256GCM:
                case CryptoAlgorithmId.AES256CTS:
                case CryptoAlgorithmId.AES256CBCNone:
                case CryptoAlgorithmId.AES256ECB:

                case CryptoAlgorithmId.AES128HMAC:
                case CryptoAlgorithmId.AES256HMAC: {
                    return Aes.CreateDecryptor(key, iV);
                    }


                }
            return null;
            }

        /// <summary>
        /// Return a Message Authentication Code provider for the algorithm 
        /// specified by <paramref name="cryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The algorithm.</param>
        /// <returns>The Message Authentication Code provider.</returns>
        public static HashAlgorithm CreateMac(
                        this CryptoAlgorithmId cryptoAlgorithmID) {

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmId.HMAC_SHA_2_256: return new HMACSHA256();
                case CryptoAlgorithmId.Default:
                case CryptoAlgorithmId.HMAC_SHA_2_512: return new HMACSHA512();
                case CryptoAlgorithmId.HMAC_SHA_2_512T128: return new HMACSHA512();

                case CryptoAlgorithmId.AES128HMAC: return new HMACSHA256();
                case CryptoAlgorithmId.AES256HMAC: return new HMACSHA512();

                }
            return null;
            }

        /// <summary>
        /// Return a Message Authentication Code provider for the algorithm 
        /// specified by <paramref name="cryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The algorithm.</param>
        /// <param name="key">The key to use.</param>
        /// <returns>The Message Authentication Code provider.</returns>
        public static HashAlgorithm CreateMac(
                        this CryptoAlgorithmId cryptoAlgorithmID,
                        byte[] key) {

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmId.HMAC_SHA_2_256: return new HMACSHA256(key);
                case CryptoAlgorithmId.Default:
                case CryptoAlgorithmId.HMAC_SHA_2_512: return new HMACSHA512(key);
                case CryptoAlgorithmId.HMAC_SHA_2_512T128: return new HMACSHA512(key);

                case CryptoAlgorithmId.AES128HMAC: return new HMACSHA256(key);
                case CryptoAlgorithmId.AES256HMAC: return new HMACSHA512(key);

                }
            return null;
            }

        /// <summary>
        /// Return a digest provider for the algorithm 
        /// specified by <paramref name="cryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The algorithm.</param>
        /// <returns>The digest provider.</returns>
        public static HashAlgorithm CreateDigest(
                        this CryptoAlgorithmId cryptoAlgorithmID
                        ) {

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmId.SHA_2_256: return SHA256.Create();
                case CryptoAlgorithmId.Default:
                case CryptoAlgorithmId.SHA_2_512: return SHA512.Create();
                case CryptoAlgorithmId.SHA_2_512T128: return SHA512.Create();

                case CryptoAlgorithmId.SHA_3_256: return new SHA3Managed(256);
                case CryptoAlgorithmId.SHA_3_512: return new SHA3Managed(512);
                case CryptoAlgorithmId.SHAKE_128: return new SHAKE128();
                case CryptoAlgorithmId.SHAKE_256: return new SHAKE256();

                }
            return null;
            }

        /// <summary>
        /// Return a shake provider for the algorithm 
        /// specified by <paramref name="cryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The algorithm.</param>
        /// <param name="hashBitLength">The number of output bits to generate.</param>
        /// <returns>The digest provider.</returns>
        public static HashAlgorithm CreateShake(
                        CryptoAlgorithmId cryptoAlgorithmID,
                        int hashBitLength
                        ) => cryptoAlgorithmID switch {
                            CryptoAlgorithmId.SHAKE_128 => new SHAKE128(hashBitLength),
                            CryptoAlgorithmId.SHAKE_256 => new SHAKE256(hashBitLength),
                            _ => null,
                            };

        /// <summary>
        /// Calculate the digest value of the contents of <paramref name="fileName"/> using the algorithm
        /// specified by <paramref name="cryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="fileName">The file containing the data to digest.</param>
        /// <param name="cryptoAlgorithmID">The digest algorithm.</param>
        /// <returns>The digest value.</returns>
        public static byte[] GetDigestOfFile(this string fileName,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.SHA_2_512) {
            var hashProvider = cryptoAlgorithmID.CreateDigest();
            using (var inputStream = fileName.OpenFileRead()) {
                using var cryptoStream = new CryptoStream(Stream.Null, hashProvider, CryptoStreamMode.Write);
                inputStream.CopyTo(cryptoStream);
                }
            return hashProvider.Hash;

            }

        /// <summary>
        /// Calculate the digest value of <paramref name="utf8"/> using the algorithm
        /// specified by <paramref name="cryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="utf8">String to be converted to UTF8 to provide the digest input.</param>
        /// <param name="cryptoAlgorithmID">The digest algorithm.</param>
        /// <returns>The digest value.</returns>
        public static byte[] GetDigest(this string utf8,
                CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.SHA_2_512) =>
            GetDigest(utf8.ToUTF8(), cryptoAlgorithmID: cryptoAlgorithmID);

        /// <summary>
        /// Calculate the digest of the portion of <paramref name="data"/> specified by
        /// <paramref name="offset"/> and <paramref name="count"/> with the digest algorithm specified
        /// by <paramref name="cryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="data">The input to compute the hash code for.</param>
        /// <param name="cryptoAlgorithmID"></param>
        /// <param name="offset">The offset into the byte array from which to begin using data.</param>
        /// <param name="count">The number of bytes in the array to use as data. If less than 0,
        /// defaults to the remaining bytes <paramref name="data"/> after <paramref name="offset"/>.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] GetDigest(this byte[] data,
                    CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.SHA_2_512, int offset = 0,
            int count = -1) {
            count = count < 0 ? data.Length - offset : count;
            using var hashAlgorithm = cryptoAlgorithmID.CreateDigest();
            return hashAlgorithm.ComputeHash(data, offset, count);
            }

        /// <summary>
        /// Calculate the digest of the portion of <paramref name="data"/> specified by
        /// <paramref name="offset"/> and <paramref name="count"/> with the digest algorithm specified
        /// by <paramref name="cryptoAlgorithmID"/>.
        /// </summary>
        /// <param name="data">The input to compute the hash code for.</param>
        /// <param name="offset">The offset into the byte array from which to begin using data.</param>
        /// <param name="count">The number of bytes in the array to use as data. If less than 0,
        /// defaults to the remaining bytes <paramref name="data"/> after <paramref name="offset"/>.</param>
        /// <param name="cryptoAlgorithmID"></param>
        /// <param name="key">The secret key for the MAC operation.</param>
        /// <returns>The computed hash code.</returns>
        public static byte[] GetMAC(this byte[] data, byte[] key,
            CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.HMAC_SHA_2_512, int offset = 0,
            int count = -1) {
            count = count < 0 ? data.Length - offset : count;
            cryptoAlgorithmID = cryptoAlgorithmID.Default(CryptoAlgorithmId.HMAC_SHA_2_512);

            using var hashAlgorithm = cryptoAlgorithmID.CreateMac(key);
            return hashAlgorithm.ComputeHash(data, offset, count);
            }
        }
    }
