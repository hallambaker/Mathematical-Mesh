using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

using System;
using System.Numerics;
using Goedel.Cryptography.Algorithms;

namespace Goedel.Cryptography {


    /// <summary>
    /// DH Key Pair
    /// </summary>
    public abstract class KeyPairBaseECDH : KeyPairAdvanced {

        /// <summary>
        /// Return private key parameters in PKIX structure
        /// </summary>
        public abstract PKIXPrivateKeyECDH PKIXPrivateKeyECDH { get; }

        /// <summary>
        /// Return public key parameters in PKIX structure
        /// </summary>
        public abstract PKIXPublicKeyECDH PKIXPublicKeyECDH { get; }


        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public override IPKIXPrivateKey PKIXPrivateKey {
            get {
                Assert.NotNull(PKIXPrivateKeyECDH, NotExportable.Throw);
                return PKIXPrivateKeyECDH;
                }
            }

        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public override IPKIXPublicKey PKIXPublicKey => PKIXPublicKeyECDH;



        }


    /// <summary>
    /// Description of a Diffie Hellman Key Pair. This class exposes methods and properties
    /// that allow conversion of the public key (and private key if known) values to various
    /// formats.
    /// </summary>
    public abstract class KeyPairECDH : KeyPairBaseECDH {


        /// <summary>The supported key uses (e.g. signing, encryption)</summary>
        public override KeyUses KeyUses { get; }

        /// <summary>
        /// Create a new ephemeral private key and use it to perform a key
        /// agreement.
        /// </summary>
        /// <returns>The key agreement parameters, the public key value and the
        /// key agreement.</returns>
        public ResultECDH Agreement() => throw new NotImplementedException();

        /// <summary>
        /// The byte encoding of the public key
        /// </summary>
        public virtual byte[] PublicData => throw new NYI();


        // Abstract method implementations to be shared across the curves


        /// <summary>
        /// The public key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public override SubjectPublicKeyInfo KeyInfoData => PKIXPublicKeyECDH.SubjectPublicKeyInfo();

        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public override SubjectPublicKeyInfo PrivateKeyInfoData => PKIXPrivateKeyECDH.SubjectPublicKeyInfo();


        /// <summary>
        /// Create an ECDH private key of type <paramref name="cryptoAlgorithmID"/> 
        /// from a specified scalar value <paramref name="privateScalar"/>. 
        /// </summary>
        /// <param name="cryptoAlgorithmID">The cryptographic algorithm identifier of the 
        /// type of key to create.</param>
        /// <param name="privateScalar">The private scalar value.</param>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
        /// <returns>The generated key pair</returns>
        public static KeyPair KeyPairFactory(
            CryptoAlgorithmID cryptoAlgorithmID,
            BigInteger privateScalar,
            KeySecurity keySecurity = KeySecurity.Bound,
            KeyUses keyUses = KeyUses.Any) {

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmID.Ed448: {
                    return new KeyPairEd448(new CurveEdwards448Private(privateScalar),
                        keySecurity, keyUses, cryptoAlgorithmID);
                    }

                case CryptoAlgorithmID.Ed25519: {
                    return new KeyPairEd25519(new CurveEdwards25519Private(privateScalar),
                        keySecurity, keyUses, cryptoAlgorithmID);
                    }
                case CryptoAlgorithmID.X448: {
                    return new KeyPairX448(new CurveX448Private(privateScalar),
                        keySecurity, keyUses, cryptoAlgorithmID);
                    }
                case CryptoAlgorithmID.X25519: {
                    return new KeyPairX25519(new CurveX25519Private(privateScalar),
                        keySecurity, keyUses, cryptoAlgorithmID);
                    }

                case CryptoAlgorithmID.Unknown:
                    break;
                case CryptoAlgorithmID.NULL:
                    break;
                case CryptoAlgorithmID.Default:
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
                case CryptoAlgorithmID.Ed25519ctx:
                    break;
                case CryptoAlgorithmID.Ed25519ph:
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

        ///// <summary>
        ///// Perform an ECDH Key Agreement to a private key
        ///// </summary>
        ///// <param name="Public">Public key parameters</param>
        ///// <param name="Carry">Carried result to add in to the agreement (for recryption)</param>
        ///// <returns>The key agreement value ZZ</returns>
        //public ResultECDH Agreement(KeyPairECDH Public, ResultECDH Carry = null) =>
        //    throw new NotImplementedException();

        /// <summary>
        /// Generate a key pair for the specified algorithm and key size.
        /// </summary>
        /// <param name="keySize">The Key size, must be 255 or 448</param>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="cryptoAlgorithmID">The cryptographic algorithm identifier</param>
        /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
        /// <returns>The generated key pair</returns>
        public static KeyPair KeyPairFactory(
                    int keySize = 0,
                    KeySecurity keySecurity = KeySecurity.Bound,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.NULL) {



            KeyPair keyPair = null;

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmID.Ed448: {
                    keyPair = KeyPairEd448.Generate(keySecurity, keyUses, cryptoAlgorithmID);
                    break;
                    }
                case CryptoAlgorithmID.Ed25519: {
                    keyPair = KeyPairEd25519.Generate(keySecurity, keyUses, cryptoAlgorithmID);
                    break;
                    }
                case CryptoAlgorithmID.X448: {
                    keyPair = KeyPairX448.Generate(keySecurity, keyUses, cryptoAlgorithmID);
                    break;
                    }
                case CryptoAlgorithmID.X25519: {
                    keyPair = KeyPairX25519.Generate(keySecurity, keyUses, cryptoAlgorithmID);
                    break;
                    }

                case CryptoAlgorithmID.Unknown:
                    break;
                case CryptoAlgorithmID.NULL:
                    break;
                case CryptoAlgorithmID.Default:
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
                case CryptoAlgorithmID.Ed25519ctx:
                    break;
                case CryptoAlgorithmID.Ed25519ph:
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

            if (keyPair == null) {
                keySize = keySize == 0 ? 448 : keySize;
                switch (keySize) {
                    case 448:
                        keyPair = KeyPairEd448.Generate(keySecurity, keyUses, cryptoAlgorithmID); break;
                    case 25519:
                        keyPair = KeyPairEd25519.Generate(keySecurity, keyUses, cryptoAlgorithmID); break;
                    default:
                        break;
                    }
                }
            Assert.NotNull(keyPair, NoProviderSpecified.Throw);

            return keyPair;
            }

        /// <summary>
        /// Create a KeyPairECDH instance for the algorithm <paramref name="CryptoAlgorithmID"/> 
        /// from the key data <paramref name="key"/>. 
        /// </summary>
        /// <param name="key">The key data in RFC8032 format.</param>
        /// <param name="keyType">The key security model</param>
        /// <param name="CryptoAlgorithmID">The cryptographic algorithm represented by the key.</param>
        /// <returns>The created key pair.</returns>
        public static KeyPairECDH KeyPairFactory(byte[] key, KeySecurity keyType = KeySecurity.Public,
            CryptoAlgorithmID CryptoAlgorithmID = CryptoAlgorithmID.NULL) {
            switch (CryptoAlgorithmID) {
                case CryptoAlgorithmID.Ed448:
                case CryptoAlgorithmID.Ed448ph:
                    return new KeyPairEd448(key, keyType);
                case CryptoAlgorithmID.Ed25519:
                case CryptoAlgorithmID.Ed25519ph:
                case CryptoAlgorithmID.Ed25519ctx: return new KeyPairEd25519(key, keyType);
                case CryptoAlgorithmID.X448:
                    return new KeyPairX448(key, keyType);
                case CryptoAlgorithmID.X25519:
                    return new KeyPairX25519(key, keyType);
                case CryptoAlgorithmID.Unknown:
                    break;
                case CryptoAlgorithmID.NULL:
                    break;
                case CryptoAlgorithmID.Default:
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

            throw new NYI();
            }


        }

    }
