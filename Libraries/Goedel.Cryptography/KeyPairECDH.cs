using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.Utilities;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography.Algorithms;
using System;
using Goedel.ASN;

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
        /// Perform an ECDH Key Agreement to a private key
        /// </summary>
        /// <param name="Public">Public key parameters</param>
        /// <param name="Carry">Carried result to add in to the agreement (for recryption)</param>
        /// <returns>The key agreement value ZZ</returns>
        public ResultECDH Agreement(KeyPairECDH Public, ResultDiffieHellman Carry = null) =>
            throw new NotImplementedException();

        /// <summary>
        /// Generate a key pair for the specified algorithm and key size.
        /// </summary>
        /// <param name="keySize">The Key size, must be 255 or 448</param>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="signature">If true the key MAY be used for signing</param>
        /// <param name="exchange">If true the key MAY be used for exchange</param>
        /// <param name="cryptoAlgorithmID">The cryptographic algorithm identifier</param>
        /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="keySecurity"/></param>
        /// <returns>The generated key pair</returns>
        public static KeyPair KeyPairFactory(
                    int keySize = 0,
                    KeyStorage keyType = KeyStorage.Bound,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.NULL) {

            

            KeyPair keyPair = null;

            switch (cryptoAlgorithmID) {
                case CryptoAlgorithmID.Ed448:
                    keyPair = KeyPairEd448.Generate(keyType, keyUses, cryptoAlgorithmID); break;
                case CryptoAlgorithmID.Ed25519:
                    keyPair = KeyPairEd25519.Generate(keyType, keyUses, cryptoAlgorithmID); break;
                case CryptoAlgorithmID.X448:
                    keyPair = KeyPairX448.Generate(keyType, keyUses, cryptoAlgorithmID); break;
                case CryptoAlgorithmID.X25519:
                    keyPair = KeyPairX25519.Generate(keyType, keyUses, cryptoAlgorithmID); break;
                }

            if (keyPair == null) {
                keySize = keySize == 0 ? 448 : keySize;
                switch (keySize) {
                    case 448:
                        keyPair = KeyPairEd448.Generate(keyType, keyUses, cryptoAlgorithmID); break;
                    case 25519:
                        keyPair = KeyPairEd25519.Generate(keyType, keyUses, cryptoAlgorithmID); break;
                    }
                }
            Assert.NotNull(keyPair, NoProviderSpecified.Throw);

            return keyPair;
            }

        /// <summary>
        /// Create a KeyPairECDH instance for the algorithm <paramref name="CryptoAlgorithmID"/> 
        /// from the key data <paramref name="key"/>. If <paramref name="isPrivate"/> is true, 
        /// a private key is created, otherwise the data is interpreted as a public key.
        /// </summary>
        /// <param name="key">The key data in RFC8032 format.</param>
        /// <param name="isPrivate">If true, the data represents a secret key value,
        /// otherwise a public key is represented.</param>
        /// <param name="CryptoAlgorithmID">The cryptographic algorithm represented by the key.</param>
        /// <returns>The created key pair.</returns>
        public static KeyPairECDH KeyPairFactory(byte[] key, KeyStorage keyType = KeyStorage.Public,
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
                }

            throw new NYI();
            }


        }

    }
