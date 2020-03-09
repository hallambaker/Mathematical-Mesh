using Goedel.Cryptography.Algorithms;
using Goedel.IO;
using Goedel.Utilities;

using System.IO;
using System.Security.Cryptography;

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
                    this CryptoAlgorithmID cryptoAlgorithmID
                    ) {

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmID.AES128:
                case CryptoAlgorithmID.AES128GCM:
                case CryptoAlgorithmID.AES128CTS:
                case CryptoAlgorithmID.AES128HMAC:
                case CryptoAlgorithmID.AES128CBCNone:
                case CryptoAlgorithmID.AES128ECB: return (128, 128);

                case CryptoAlgorithmID.Default:
                case CryptoAlgorithmID.AES256:
                case CryptoAlgorithmID.AES256CBC:
                case CryptoAlgorithmID.AES256GCM:
                case CryptoAlgorithmID.AES256CTS:
                case CryptoAlgorithmID.AES256HMAC:
                case CryptoAlgorithmID.AES256CBCNone:
                case CryptoAlgorithmID.AES256ECB: return (256, 128);

                case CryptoAlgorithmID.HMAC_SHA_2_256: return (128, 0);

                case CryptoAlgorithmID.HMAC_SHA_2_512:
                case CryptoAlgorithmID.HMAC_SHA_2_512T128: return (256, 0);
                case CryptoAlgorithmID.Unknown:
                    break;
                case CryptoAlgorithmID.NULL:
                    break;
                case CryptoAlgorithmID.Bulk:
                    break;
                case CryptoAlgorithmID.BulkMask:
                    break;
                case CryptoAlgorithmID.BulkTagMask:
                    break;
                case CryptoAlgorithmID.Digest:
                    break;
                case CryptoAlgorithmID.MAC:
                    break;
                case CryptoAlgorithmID.MaxDigest:
                    break;
                case CryptoAlgorithmID.MaxMAC:
                    break;
                case CryptoAlgorithmID.MaxEncryption:
                    break;
                case CryptoAlgorithmID.BaseMask:
                    break;
                case CryptoAlgorithmID.Meta:
                    break;
                case CryptoAlgorithmID.MetaMask:
                    break;
                case CryptoAlgorithmID.MetaTagMask:
                    break;
                case CryptoAlgorithmID.Signature:
                    break;
                case CryptoAlgorithmID.Exchange:
                    break;
                case CryptoAlgorithmID.Wrap:
                    break;
                case CryptoAlgorithmID.MaxSignature:
                    break;
                case CryptoAlgorithmID.MaxExchange:
                    break;
                case CryptoAlgorithmID.MaxWrap:
                    break;
                case CryptoAlgorithmID.SHA_2_256:
                    break;
                case CryptoAlgorithmID.SHA_2_512:
                    break;
                case CryptoAlgorithmID.SHA_2_512T128:
                    break;
                case CryptoAlgorithmID.SHA_3_256:
                    break;
                case CryptoAlgorithmID.SHA_3_512:
                    break;
                case CryptoAlgorithmID.SHAKE_128:
                    break;
                case CryptoAlgorithmID.SHAKE_256:
                    break;
                case CryptoAlgorithmID.ModeCTS:
                    break;
                case CryptoAlgorithmID.ModeGCM:
                    break;
                case CryptoAlgorithmID.ModeHMAC:
                    break;
                case CryptoAlgorithmID.ModeCBCNone:
                    break;
                case CryptoAlgorithmID.ModeECB:
                    break;
                case CryptoAlgorithmID.AES128CBC:
                    break;
                case CryptoAlgorithmID.Level_High:
                    break;
                case CryptoAlgorithmID.RSASign_PSS:
                    break;
                case CryptoAlgorithmID.EdDSA:
                    break;
                case CryptoAlgorithmID.Ed25519ctx:
                    break;
                case CryptoAlgorithmID.Ed25519ph:
                    break;
                case CryptoAlgorithmID.Ed448:
                    break;
                case CryptoAlgorithmID.Ed448ph:
                    break;
                case CryptoAlgorithmID.RSASign_SHA_2_256:
                    break;
                case CryptoAlgorithmID.RSASign_SHA_2_512:
                    break;
                case CryptoAlgorithmID.RSASign_PSS_SHA_2_256:
                    break;
                case CryptoAlgorithmID.RSASign_PSS_SHA_2_512:
                    break;
                case CryptoAlgorithmID.RSAExch_P15:
                    break;
                case CryptoAlgorithmID.DH:
                    break;
                case CryptoAlgorithmID.ECDH:
                    break;
                case CryptoAlgorithmID.X25519:
                    break;
                case CryptoAlgorithmID.X448:
                    break;
                case CryptoAlgorithmID.XEd25519:
                    break;
                case CryptoAlgorithmID.XEd448:
                    break;
                case CryptoAlgorithmID.Direct:
                    break;
                case CryptoAlgorithmID.KW3394_AES128:
                    break;
                case CryptoAlgorithmID.KW3394_AES256:
                    break;
                case CryptoAlgorithmID.AES128_GCM_KW:
                    break;
                case CryptoAlgorithmID.AES256_GCM_KW:
                    break;
                default:
                    break;
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
                        this CryptoAlgorithmID cryptoAlgorithmID,
                        byte[] key,
                        byte[] iv = null) {

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmID.Default:
                case CryptoAlgorithmID.AES128:
                case CryptoAlgorithmID.AES128GCM:
                case CryptoAlgorithmID.AES128CTS:
                case CryptoAlgorithmID.AES128CBCNone:
                case CryptoAlgorithmID.AES128ECB:
                case CryptoAlgorithmID.AES256:
                case CryptoAlgorithmID.AES256CBC:
                case CryptoAlgorithmID.AES256GCM:
                case CryptoAlgorithmID.AES256CTS:
                case CryptoAlgorithmID.AES256CBCNone:
                case CryptoAlgorithmID.AES256ECB:

                case CryptoAlgorithmID.AES128HMAC:
                case CryptoAlgorithmID.AES256HMAC: {
                    return Aes.CreateEncryptor(key, iv);
                    }

                case CryptoAlgorithmID.Unknown:
                    break;
                case CryptoAlgorithmID.NULL:
                    break;
                case CryptoAlgorithmID.Bulk:
                    break;
                case CryptoAlgorithmID.BulkMask:
                    break;
                case CryptoAlgorithmID.BulkTagMask:
                    break;
                case CryptoAlgorithmID.Digest:
                    break;
                case CryptoAlgorithmID.MAC:
                    break;
                case CryptoAlgorithmID.MaxDigest:
                    break;
                case CryptoAlgorithmID.MaxMAC:
                    break;
                case CryptoAlgorithmID.MaxEncryption:
                    break;
                case CryptoAlgorithmID.BaseMask:
                    break;
                case CryptoAlgorithmID.Meta:
                    break;
                case CryptoAlgorithmID.MetaMask:
                    break;
                case CryptoAlgorithmID.MetaTagMask:
                    break;
                case CryptoAlgorithmID.Signature:
                    break;
                case CryptoAlgorithmID.Exchange:
                    break;
                case CryptoAlgorithmID.Wrap:
                    break;
                case CryptoAlgorithmID.MaxSignature:
                    break;
                case CryptoAlgorithmID.MaxExchange:
                    break;
                case CryptoAlgorithmID.MaxWrap:
                    break;
                case CryptoAlgorithmID.SHA_2_256:
                    break;
                case CryptoAlgorithmID.SHA_2_512:
                    break;
                case CryptoAlgorithmID.SHA_2_512T128:
                    break;
                case CryptoAlgorithmID.SHA_3_256:
                    break;
                case CryptoAlgorithmID.SHA_3_512:
                    break;
                case CryptoAlgorithmID.SHAKE_128:
                    break;
                case CryptoAlgorithmID.SHAKE_256:
                    break;
                case CryptoAlgorithmID.ModeCTS:
                    break;
                case CryptoAlgorithmID.ModeGCM:
                    break;
                case CryptoAlgorithmID.ModeHMAC:
                    break;
                case CryptoAlgorithmID.ModeCBCNone:
                    break;
                case CryptoAlgorithmID.ModeECB:
                    break;
                case CryptoAlgorithmID.AES128CBC:
                    break;
                case CryptoAlgorithmID.HMAC_SHA_2_256:
                    break;
                case CryptoAlgorithmID.HMAC_SHA_2_512:
                    break;
                case CryptoAlgorithmID.HMAC_SHA_2_512T128:
                    break;
                case CryptoAlgorithmID.Level_High:
                    break;
                case CryptoAlgorithmID.RSASign_PSS:
                    break;
                case CryptoAlgorithmID.EdDSA:
                    break;
                case CryptoAlgorithmID.Ed25519ctx:
                    break;
                case CryptoAlgorithmID.Ed25519ph:
                    break;
                case CryptoAlgorithmID.Ed448:
                    break;
                case CryptoAlgorithmID.Ed448ph:
                    break;
                case CryptoAlgorithmID.RSASign_SHA_2_256:
                    break;
                case CryptoAlgorithmID.RSASign_SHA_2_512:
                    break;
                case CryptoAlgorithmID.RSASign_PSS_SHA_2_256:
                    break;
                case CryptoAlgorithmID.RSASign_PSS_SHA_2_512:
                    break;
                case CryptoAlgorithmID.RSAExch_P15:
                    break;
                case CryptoAlgorithmID.DH:
                    break;
                case CryptoAlgorithmID.ECDH:
                    break;
                case CryptoAlgorithmID.X25519:
                    break;
                case CryptoAlgorithmID.X448:
                    break;
                case CryptoAlgorithmID.XEd25519:
                    break;
                case CryptoAlgorithmID.XEd448:
                    break;
                case CryptoAlgorithmID.Direct:
                    break;
                case CryptoAlgorithmID.KW3394_AES128:
                    break;
                case CryptoAlgorithmID.KW3394_AES256:
                    break;
                case CryptoAlgorithmID.AES128_GCM_KW:
                    break;
                case CryptoAlgorithmID.AES256_GCM_KW:
                    break;
                default:
                    break;
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
                        this CryptoAlgorithmID cryptoAlgorithmID,
                        byte[] key,
                        byte[] iV) {

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmID.Default:
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
                    return Aes.CreateDecryptor(key, iV);
                    }

                case CryptoAlgorithmID.Unknown:
                    break;
                case CryptoAlgorithmID.NULL:
                    break;
                case CryptoAlgorithmID.Bulk:
                    break;
                case CryptoAlgorithmID.BulkMask:
                    break;
                case CryptoAlgorithmID.BulkTagMask:
                    break;
                case CryptoAlgorithmID.Digest:
                    break;
                case CryptoAlgorithmID.MAC:
                    break;
                case CryptoAlgorithmID.MaxDigest:
                    break;
                case CryptoAlgorithmID.MaxMAC:
                    break;
                case CryptoAlgorithmID.MaxEncryption:
                    break;
                case CryptoAlgorithmID.BaseMask:
                    break;
                case CryptoAlgorithmID.Meta:
                    break;
                case CryptoAlgorithmID.MetaMask:
                    break;
                case CryptoAlgorithmID.MetaTagMask:
                    break;
                case CryptoAlgorithmID.Signature:
                    break;
                case CryptoAlgorithmID.Exchange:
                    break;
                case CryptoAlgorithmID.Wrap:
                    break;
                case CryptoAlgorithmID.MaxSignature:
                    break;
                case CryptoAlgorithmID.MaxExchange:
                    break;
                case CryptoAlgorithmID.MaxWrap:
                    break;
                case CryptoAlgorithmID.SHA_2_256:
                    break;
                case CryptoAlgorithmID.SHA_2_512:
                    break;
                case CryptoAlgorithmID.SHA_2_512T128:
                    break;
                case CryptoAlgorithmID.SHA_3_256:
                    break;
                case CryptoAlgorithmID.SHA_3_512:
                    break;
                case CryptoAlgorithmID.SHAKE_128:
                    break;
                case CryptoAlgorithmID.SHAKE_256:
                    break;
                case CryptoAlgorithmID.ModeCTS:
                    break;
                case CryptoAlgorithmID.ModeGCM:
                    break;
                case CryptoAlgorithmID.ModeHMAC:
                    break;
                case CryptoAlgorithmID.ModeCBCNone:
                    break;
                case CryptoAlgorithmID.ModeECB:
                    break;
                case CryptoAlgorithmID.AES256:
                    break;
                case CryptoAlgorithmID.AES128CBC:
                    break;
                case CryptoAlgorithmID.HMAC_SHA_2_256:
                    break;
                case CryptoAlgorithmID.HMAC_SHA_2_512:
                    break;
                case CryptoAlgorithmID.HMAC_SHA_2_512T128:
                    break;
                case CryptoAlgorithmID.Level_High:
                    break;
                case CryptoAlgorithmID.RSASign_PSS:
                    break;
                case CryptoAlgorithmID.EdDSA:
                    break;
                case CryptoAlgorithmID.Ed25519ctx:
                    break;
                case CryptoAlgorithmID.Ed25519ph:
                    break;
                case CryptoAlgorithmID.Ed448:
                    break;
                case CryptoAlgorithmID.Ed448ph:
                    break;
                case CryptoAlgorithmID.RSASign_SHA_2_256:
                    break;
                case CryptoAlgorithmID.RSASign_SHA_2_512:
                    break;
                case CryptoAlgorithmID.RSASign_PSS_SHA_2_256:
                    break;
                case CryptoAlgorithmID.RSASign_PSS_SHA_2_512:
                    break;
                case CryptoAlgorithmID.RSAExch_P15:
                    break;
                case CryptoAlgorithmID.DH:
                    break;
                case CryptoAlgorithmID.ECDH:
                    break;
                case CryptoAlgorithmID.X25519:
                    break;
                case CryptoAlgorithmID.X448:
                    break;
                case CryptoAlgorithmID.XEd25519:
                    break;
                case CryptoAlgorithmID.XEd448:
                    break;
                case CryptoAlgorithmID.Direct:
                    break;
                case CryptoAlgorithmID.KW3394_AES128:
                    break;
                case CryptoAlgorithmID.KW3394_AES256:
                    break;
                case CryptoAlgorithmID.AES128_GCM_KW:
                    break;
                case CryptoAlgorithmID.AES256_GCM_KW:
                    break;
                default:
                    break;
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
                        this CryptoAlgorithmID cryptoAlgorithmID) {

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmID.HMAC_SHA_2_256: return new HMACSHA256();
                case CryptoAlgorithmID.Default:
                case CryptoAlgorithmID.HMAC_SHA_2_512: return new HMACSHA512();
                case CryptoAlgorithmID.HMAC_SHA_2_512T128: return new HMACSHA512();

                case CryptoAlgorithmID.AES128HMAC: return new HMACSHA256();
                case CryptoAlgorithmID.AES256HMAC: return new HMACSHA512();
                case CryptoAlgorithmID.Unknown:
                    break;
                case CryptoAlgorithmID.NULL:
                    break;
                case CryptoAlgorithmID.Bulk:
                    break;
                case CryptoAlgorithmID.BulkMask:
                    break;
                case CryptoAlgorithmID.BulkTagMask:
                    break;
                case CryptoAlgorithmID.Digest:
                    break;
                case CryptoAlgorithmID.MAC:
                    break;
                case CryptoAlgorithmID.Encryption:
                    break;
                case CryptoAlgorithmID.MaxDigest:
                    break;
                case CryptoAlgorithmID.MaxMAC:
                    break;
                case CryptoAlgorithmID.MaxEncryption:
                    break;
                case CryptoAlgorithmID.BaseMask:
                    break;
                case CryptoAlgorithmID.Meta:
                    break;
                case CryptoAlgorithmID.MetaMask:
                    break;
                case CryptoAlgorithmID.MetaTagMask:
                    break;
                case CryptoAlgorithmID.Signature:
                    break;
                case CryptoAlgorithmID.Exchange:
                    break;
                case CryptoAlgorithmID.Wrap:
                    break;
                case CryptoAlgorithmID.MaxSignature:
                    break;
                case CryptoAlgorithmID.MaxExchange:
                    break;
                case CryptoAlgorithmID.MaxWrap:
                    break;
                case CryptoAlgorithmID.SHA_2_256:
                    break;
                case CryptoAlgorithmID.SHA_2_512:
                    break;
                case CryptoAlgorithmID.SHA_2_512T128:
                    break;
                case CryptoAlgorithmID.SHA_3_256:
                    break;
                case CryptoAlgorithmID.SHA_3_512:
                    break;
                case CryptoAlgorithmID.SHAKE_128:
                    break;
                case CryptoAlgorithmID.SHAKE_256:
                    break;
                case CryptoAlgorithmID.ModeCTS:
                    break;
                case CryptoAlgorithmID.ModeGCM:
                    break;
                case CryptoAlgorithmID.ModeHMAC:
                    break;
                case CryptoAlgorithmID.ModeCBCNone:
                    break;
                case CryptoAlgorithmID.ModeECB:
                    break;
                case CryptoAlgorithmID.AES256:
                    break;
                case CryptoAlgorithmID.AES128CBC:
                    break;
                case CryptoAlgorithmID.AES128GCM:
                    break;
                case CryptoAlgorithmID.AES128CTS:
                    break;
                case CryptoAlgorithmID.AES128CBCNone:
                    break;
                case CryptoAlgorithmID.AES128ECB:
                    break;
                case CryptoAlgorithmID.AES256CBC:
                    break;
                case CryptoAlgorithmID.AES256GCM:
                    break;
                case CryptoAlgorithmID.AES256CTS:
                    break;
                case CryptoAlgorithmID.AES256CBCNone:
                    break;
                case CryptoAlgorithmID.AES256ECB:
                    break;
                case CryptoAlgorithmID.Level_High:
                    break;
                case CryptoAlgorithmID.RSASign_PSS:
                    break;
                case CryptoAlgorithmID.EdDSA:
                    break;
                case CryptoAlgorithmID.Ed25519ctx:
                    break;
                case CryptoAlgorithmID.Ed25519ph:
                    break;
                case CryptoAlgorithmID.Ed448:
                    break;
                case CryptoAlgorithmID.Ed448ph:
                    break;
                case CryptoAlgorithmID.RSASign_SHA_2_256:
                    break;
                case CryptoAlgorithmID.RSASign_SHA_2_512:
                    break;
                case CryptoAlgorithmID.RSASign_PSS_SHA_2_256:
                    break;
                case CryptoAlgorithmID.RSASign_PSS_SHA_2_512:
                    break;
                case CryptoAlgorithmID.RSAExch_P15:
                    break;
                case CryptoAlgorithmID.DH:
                    break;
                case CryptoAlgorithmID.ECDH:
                    break;
                case CryptoAlgorithmID.X25519:
                    break;
                case CryptoAlgorithmID.X448:
                    break;
                case CryptoAlgorithmID.XEd25519:
                    break;
                case CryptoAlgorithmID.XEd448:
                    break;
                case CryptoAlgorithmID.Direct:
                    break;
                case CryptoAlgorithmID.KW3394_AES128:
                    break;
                case CryptoAlgorithmID.KW3394_AES256:
                    break;
                case CryptoAlgorithmID.AES128_GCM_KW:
                    break;
                case CryptoAlgorithmID.AES256_GCM_KW:
                    break;
                default:
                    break;
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
                        this CryptoAlgorithmID cryptoAlgorithmID,
                        byte[] key) {

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmID.HMAC_SHA_2_256: return new HMACSHA256(key);
                case CryptoAlgorithmID.Default:
                case CryptoAlgorithmID.HMAC_SHA_2_512: return new HMACSHA512(key);
                case CryptoAlgorithmID.HMAC_SHA_2_512T128: return new HMACSHA512(key);

                case CryptoAlgorithmID.AES128HMAC: return new HMACSHA256(key);
                case CryptoAlgorithmID.AES256HMAC: return new HMACSHA512(key);
                case CryptoAlgorithmID.Unknown:
                    break;
                case CryptoAlgorithmID.NULL:
                    break;
                case CryptoAlgorithmID.Bulk:
                    break;
                case CryptoAlgorithmID.BulkMask:
                    break;
                case CryptoAlgorithmID.BulkTagMask:
                    break;
                case CryptoAlgorithmID.Digest:
                    break;
                case CryptoAlgorithmID.MAC:
                    break;
                case CryptoAlgorithmID.Encryption:
                    break;
                case CryptoAlgorithmID.MaxDigest:
                    break;
                case CryptoAlgorithmID.MaxMAC:
                    break;
                case CryptoAlgorithmID.MaxEncryption:
                    break;
                case CryptoAlgorithmID.BaseMask:
                    break;
                case CryptoAlgorithmID.Meta:
                    break;
                case CryptoAlgorithmID.MetaMask:
                    break;
                case CryptoAlgorithmID.MetaTagMask:
                    break;
                case CryptoAlgorithmID.Signature:
                    break;
                case CryptoAlgorithmID.Exchange:
                    break;
                case CryptoAlgorithmID.Wrap:
                    break;
                case CryptoAlgorithmID.MaxSignature:
                    break;
                case CryptoAlgorithmID.MaxExchange:
                    break;
                case CryptoAlgorithmID.MaxWrap:
                    break;
                case CryptoAlgorithmID.SHA_2_256:
                    break;
                case CryptoAlgorithmID.SHA_2_512:
                    break;
                case CryptoAlgorithmID.SHA_2_512T128:
                    break;
                case CryptoAlgorithmID.SHA_3_256:
                    break;
                case CryptoAlgorithmID.SHA_3_512:
                    break;
                case CryptoAlgorithmID.SHAKE_128:
                    break;
                case CryptoAlgorithmID.SHAKE_256:
                    break;
                case CryptoAlgorithmID.ModeCTS:
                    break;
                case CryptoAlgorithmID.ModeGCM:
                    break;
                case CryptoAlgorithmID.ModeHMAC:
                    break;
                case CryptoAlgorithmID.ModeCBCNone:
                    break;
                case CryptoAlgorithmID.ModeECB:
                    break;
                case CryptoAlgorithmID.AES256:
                    break;
                case CryptoAlgorithmID.AES128CBC:
                    break;
                case CryptoAlgorithmID.AES128GCM:
                    break;
                case CryptoAlgorithmID.AES128CTS:
                    break;
                case CryptoAlgorithmID.AES128CBCNone:
                    break;
                case CryptoAlgorithmID.AES128ECB:
                    break;
                case CryptoAlgorithmID.AES256CBC:
                    break;
                case CryptoAlgorithmID.AES256GCM:
                    break;
                case CryptoAlgorithmID.AES256CTS:
                    break;
                case CryptoAlgorithmID.AES256CBCNone:
                    break;
                case CryptoAlgorithmID.AES256ECB:
                    break;
                case CryptoAlgorithmID.Level_High:
                    break;
                case CryptoAlgorithmID.RSASign_PSS:
                    break;
                case CryptoAlgorithmID.EdDSA:
                    break;
                case CryptoAlgorithmID.Ed25519ctx:
                    break;
                case CryptoAlgorithmID.Ed25519ph:
                    break;
                case CryptoAlgorithmID.Ed448:
                    break;
                case CryptoAlgorithmID.Ed448ph:
                    break;
                case CryptoAlgorithmID.RSASign_SHA_2_256:
                    break;
                case CryptoAlgorithmID.RSASign_SHA_2_512:
                    break;
                case CryptoAlgorithmID.RSASign_PSS_SHA_2_256:
                    break;
                case CryptoAlgorithmID.RSASign_PSS_SHA_2_512:
                    break;
                case CryptoAlgorithmID.RSAExch_P15:
                    break;
                case CryptoAlgorithmID.DH:
                    break;
                case CryptoAlgorithmID.ECDH:
                    break;
                case CryptoAlgorithmID.X25519:
                    break;
                case CryptoAlgorithmID.X448:
                    break;
                case CryptoAlgorithmID.XEd25519:
                    break;
                case CryptoAlgorithmID.XEd448:
                    break;
                case CryptoAlgorithmID.Direct:
                    break;
                case CryptoAlgorithmID.KW3394_AES128:
                    break;
                case CryptoAlgorithmID.KW3394_AES256:
                    break;
                case CryptoAlgorithmID.AES128_GCM_KW:
                    break;
                case CryptoAlgorithmID.AES256_GCM_KW:
                    break;
                default:
                    break;
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
                        this CryptoAlgorithmID cryptoAlgorithmID
                        ) {

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmID.SHA_2_256: return SHA256.Create();
                case CryptoAlgorithmID.Default:
                case CryptoAlgorithmID.SHA_2_512: return SHA512.Create();
                case CryptoAlgorithmID.SHA_2_512T128: return SHA512.Create();

                case CryptoAlgorithmID.SHA_3_256: return new SHA3Managed(256);
                case CryptoAlgorithmID.SHA_3_512: return new SHA3Managed(512);
                case CryptoAlgorithmID.SHAKE_128: return new SHAKE128();
                case CryptoAlgorithmID.SHAKE_256: return new SHAKE256();
                case CryptoAlgorithmID.Unknown:
                    break;
                case CryptoAlgorithmID.NULL:
                    break;
                case CryptoAlgorithmID.Bulk:
                    break;
                case CryptoAlgorithmID.BulkMask:
                    break;
                case CryptoAlgorithmID.BulkTagMask:
                    break;
                case CryptoAlgorithmID.Digest:
                    break;
                case CryptoAlgorithmID.MAC:
                    break;
                case CryptoAlgorithmID.Encryption:
                    break;
                case CryptoAlgorithmID.MaxDigest:
                    break;
                case CryptoAlgorithmID.MaxMAC:
                    break;
                case CryptoAlgorithmID.MaxEncryption:
                    break;
                case CryptoAlgorithmID.BaseMask:
                    break;
                case CryptoAlgorithmID.Meta:
                    break;
                case CryptoAlgorithmID.MetaMask:
                    break;
                case CryptoAlgorithmID.MetaTagMask:
                    break;
                case CryptoAlgorithmID.Signature:
                    break;
                case CryptoAlgorithmID.Exchange:
                    break;
                case CryptoAlgorithmID.Wrap:
                    break;
                case CryptoAlgorithmID.MaxSignature:
                    break;
                case CryptoAlgorithmID.MaxExchange:
                    break;
                case CryptoAlgorithmID.MaxWrap:
                    break;
                case CryptoAlgorithmID.ModeCTS:
                    break;
                case CryptoAlgorithmID.ModeGCM:
                    break;
                case CryptoAlgorithmID.ModeHMAC:
                    break;
                case CryptoAlgorithmID.ModeCBCNone:
                    break;
                case CryptoAlgorithmID.ModeECB:
                    break;
                case CryptoAlgorithmID.AES256:
                    break;
                case CryptoAlgorithmID.AES128CBC:
                    break;
                case CryptoAlgorithmID.AES128GCM:
                    break;
                case CryptoAlgorithmID.AES128CTS:
                    break;
                case CryptoAlgorithmID.AES128HMAC:
                    break;
                case CryptoAlgorithmID.AES128CBCNone:
                    break;
                case CryptoAlgorithmID.AES128ECB:
                    break;
                case CryptoAlgorithmID.AES256CBC:
                    break;
                case CryptoAlgorithmID.AES256GCM:
                    break;
                case CryptoAlgorithmID.AES256CTS:
                    break;
                case CryptoAlgorithmID.AES256HMAC:
                    break;
                case CryptoAlgorithmID.AES256CBCNone:
                    break;
                case CryptoAlgorithmID.AES256ECB:
                    break;
                case CryptoAlgorithmID.HMAC_SHA_2_256:
                    break;
                case CryptoAlgorithmID.HMAC_SHA_2_512:
                    break;
                case CryptoAlgorithmID.HMAC_SHA_2_512T128:
                    break;
                case CryptoAlgorithmID.Level_High:
                    break;
                case CryptoAlgorithmID.RSASign_PSS:
                    break;
                case CryptoAlgorithmID.EdDSA:
                    break;
                case CryptoAlgorithmID.Ed25519ctx:
                    break;
                case CryptoAlgorithmID.Ed25519ph:
                    break;
                case CryptoAlgorithmID.Ed448:
                    break;
                case CryptoAlgorithmID.Ed448ph:
                    break;
                case CryptoAlgorithmID.RSASign_SHA_2_256:
                    break;
                case CryptoAlgorithmID.RSASign_SHA_2_512:
                    break;
                case CryptoAlgorithmID.RSASign_PSS_SHA_2_256:
                    break;
                case CryptoAlgorithmID.RSASign_PSS_SHA_2_512:
                    break;
                case CryptoAlgorithmID.RSAExch_P15:
                    break;
                case CryptoAlgorithmID.DH:
                    break;
                case CryptoAlgorithmID.ECDH:
                    break;
                case CryptoAlgorithmID.X25519:
                    break;
                case CryptoAlgorithmID.X448:
                    break;
                case CryptoAlgorithmID.XEd25519:
                    break;
                case CryptoAlgorithmID.XEd448:
                    break;
                case CryptoAlgorithmID.Direct:
                    break;
                case CryptoAlgorithmID.KW3394_AES128:
                    break;
                case CryptoAlgorithmID.KW3394_AES256:
                    break;
                case CryptoAlgorithmID.AES128_GCM_KW:
                    break;
                case CryptoAlgorithmID.AES256_GCM_KW:
                    break;
                default:
                    break;
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
                        CryptoAlgorithmID cryptoAlgorithmID,
                        int hashBitLength
                        ) => cryptoAlgorithmID switch
                            {
                                CryptoAlgorithmID.SHAKE_128 => new SHAKE128(hashBitLength),
                                CryptoAlgorithmID.SHAKE_256 => new SHAKE256(hashBitLength),
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
                CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512) {
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
                CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512) =>
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
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.SHA_2_512, int offset = 0,
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
            CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.HMAC_SHA_2_512, int offset = 0,
            int count = -1) {
            count = count < 0 ? data.Length - offset : count;
            cryptoAlgorithmID = cryptoAlgorithmID.Default(CryptoAlgorithmID.HMAC_SHA_2_512);

            using var hashAlgorithm = cryptoAlgorithmID.CreateMac(key);
            return hashAlgorithm.ComputeHash(data, offset, count);
            }
        }
    }
