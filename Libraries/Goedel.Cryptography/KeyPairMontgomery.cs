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
    /// Ed25519 public / private keypair.
    /// </summary>
    public class KeyPairX25519 : KeyPairECDH {

        ///<summary>The public key value.</summary>
        public CurveX25519Public PublicKey;
        CurveX25519Private PrivateKey;


        #region //Properties
        ///<summary>The implementation public key value</summary>
        public override IKeyAdvancedPublic IKeyAdvancedPublic => PublicKey;

        ///<summary>The implementation private key value (if exportable)</summary>
        public override IKeyAdvancedPrivate IKeyAdvancedPrivate => PrivateKey;

        ///<summary>The private key parameters represented in PKIX form</summary>
        public override PKIXPrivateKeyECDH PKIXPrivateKeyECDH { get; }

        ///<summary>The public key parameters represented in PKIX form</summary>
        public override PKIXPublicKeyECDH PKIXPublicKeyECDH { get; }

        /// <summary>The supported key uses (e.g. signing, encryption)</summary>
        public override KeyUses KeyUses { get; } = KeyUses.Any;


        ///<summary>If true, the key only has access to public key values.</summary>
        public override bool PublicOnly => PrivateKey == null;

        /// <summary>
        /// The byte encoding of the public key
        /// </summary>
        public override byte[] PublicData => PublicKey.Encoding;
        #endregion


        KeySecurity KeyType = KeySecurity.Public;
        byte[] EncodedPrivateKey = null;


        /// <summary>
        /// Construct a KeyPairEd25519 instance for the specified key data in interchange 
        /// format. 
        /// </summary>
        /// <param name="key">The key data as specified in RFC8032.</param>
        /// <param name="keyType">The key type.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
        /// in signature operations.</param>
        public KeyPairX25519(
                    byte[] key,
                    KeySecurity keyType = KeySecurity.Public,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) {

            CryptoAlgorithmID = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmID.Ed25519);
            KeyType = keyType;
            KeyUses = keyUses;
            if (keyType == KeySecurity.Public) {
                PublicKey = new CurveX25519Public(key);
                }
            else {
                EncodedPrivateKey = key;
                var privateKey = new CurveX25519Private(key);
                PublicKey = privateKey.PublicKey;
                if (keyType.IsExportable()) {
                    PKIXPrivateKeyECDH = new PKIXPrivateKeyX25519(key, PKIXPublicKeyECDH);
                    }
                }
            PKIXPublicKeyECDH = new PKIXPublicKeyX25519(PublicKey.Encoding);
            }


        /// <summary>
        /// Construct a KeyPairEd25519 instance for a secret scalar. This is used to create
        /// private keys using cogeneration.
        /// </summary>
        /// <param name="privateKey">The secret scalar value.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
        /// in signature operations.</param>
        public KeyPairX25519(
                    CurveX25519Private privateKey = null,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) {
            CryptoAlgorithmID = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmID.X25519);
            PrivateKey = privateKey;
            KeyType = KeySecurity.Bound;
            KeyUses = keyUses;
            }

        /// <summary>
        /// Generate a new private key.
        /// </summary>
        /// <param name="keyType">The key storage class.</param>
        /// <param name="keyUses">The permitted key uses</param>
        /// <param name="cryptoAlgorithmID">Cryptoraphic algorithm</param>
        /// <returns>The created key pair.</returns>
        public static KeyPairX25519 Generate(
                    KeySecurity keyType = KeySecurity.Public,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) =>
            new KeyPairX25519(Platform.GetRandomBits(256), keyType, keyUses, cryptoAlgorithmID);


        /// <summary>
        /// Construct class from a public key value
        /// </summary>
        /// <param name="Public">The public key value</param>
        /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
        /// in signature operations.</param>
        public KeyPairX25519(IKeyAdvancedPublic Public,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) {

            CryptoAlgorithmID = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmID.X25519);
            PublicKey = Public as CurveX25519Public;
            PKIXPublicKeyECDH = new PKIXPublicKeyX25519(PublicKey.Encoding);

            }

        /// <summary>
        /// Factory method to produce a key pair from key parameters.
        /// </summary>
        /// <param name="PrivateKey">The private key</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate PrivateKey) =>
            new KeyPairX25519((CurveX25519Private)PrivateKey);

        /// <summary>
        /// Factory method to produce a key pair from implementation public key parameters
        /// </summary>
        /// <param name="PublicKey">The public key</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPublic PublicKey) =>
            new KeyPairX25519((CurveX25519Public)PublicKey);


        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns>The new keypair that contains only the public values.</returns>
        public override KeyPair KeyPairPublic() => new KeyPairX25519(PublicKey);


        /// <summary>
        /// Persist the key to a key collection. Note that it is only possible to store a 
        /// </summary>
        /// <param name="keyCollection"></param>
        public override void Persist(KeyCollection keyCollection) {
            Assert.True(PersistPending);
            var pkix = PKIXPrivateKeyECDH ?? new PKIXPrivateKeyEd25519() { Data = EncodedPrivateKey };
            keyCollection.Persist(pkix, KeyType.IsExportable());
            }


        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="Public">Public key parameters</param>
        /// <param name="Carry">Carried result to add in to the agreement (for recryption)</param>
        /// <returns>The key agreement value ZZ</returns>
        CurveX25519Result Agreement(KeyPairX25519 Public, CurveX25519Result Carry = null) {
            CurveMontgomery25519 Agreement;
            if (Carry == null) {
                Agreement = PrivateKey.Agreement(Public.PublicKey);
                }
            else {
                Agreement = PrivateKey.Agreement(Public.PublicKey, Carry.Agreement);
                }
            return new CurveX25519Result() { Agreement = Agreement };
            }

        /// <summary>
        /// Encrypt a bulk key.
        /// </summary>
        /// <returns>The encoder</returns>
        /// <param name="Key">The key to encrypt.</param>
        /// <param name="Ephemeral">The ephemeral key to use for the exchange (if used)</param>
        /// <param name="Exchange">The private key to use for the exchange.</param>
        /// <param name="Salt">Optional salt value for use in key derivation.</param> 
        public override void Encrypt(byte[] Key,
            out byte[] Exchange,
            out KeyPair Ephemeral,
            byte[] Salt = null) => PublicKey.Agreement().Encrypt(Key, out Exchange, out Ephemeral, Salt);


        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="EncryptedKey">The encrypted session</param>
        /// <param name="Ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <param name="Partial">Partial key agreement carry in (for recryption)</param>
        /// <param name="Salt">Optional salt value for use in key derivation. If specified
        /// must match the salt used to encrypt.</param>        
        /// <returns>The decoded data instance</returns>
        public override byte[] Decrypt(byte[] EncryptedKey,
            KeyPair Ephemeral = null,
            CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
            KeyAgreementResult Partial = null, byte[] Salt = null) {

            var keyPairX25519 = Ephemeral as KeyPairX25519;
            Assert.NotNull(keyPairX25519, KeyTypeMismatch.Throw);

            var Agreementx = Agreement(keyPairX25519, Partial as CurveX25519Result);
            return Agreementx.Decrypt(EncryptedKey, Ephemeral, Partial, Salt);
            }


        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="Data">The data to sign.</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <param name="Context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <returns>The signature data</returns>
        public override byte[] SignHash(
            byte[] Data,
            CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
            byte[] Context = null) => throw new InvalidOperation();

        /// <summary>
        /// Verify a signature over the purported data digest.
        /// </summary>
        /// <param name="Signature">The signature blob value.</param>
        /// <param name="AlgorithmID">The signature and hash algorithm to use.</param>
        /// <param name="Context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <param name="Data">The digest value to be verified.</param>
        /// <returns>True if the signature is valid, otherwise false.</returns>
        public override bool VerifyHash(
            byte[] Data,
            byte[] Signature,
            CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
                byte[] Context = null) => throw new InvalidOperation();
        }


    /// <summary>
    /// KeyPair binding for Ed448 signature and exchange.
    /// </summary>
    public class KeyPairX448 : KeyPairECDH {

        CurveX448Public PublicKey;
        CurveX448Private PrivateKey;

        #region //Properties
        ///<summary>The implementation public key value</summary>
        public override IKeyAdvancedPublic IKeyAdvancedPublic => PublicKey;

        ///<summary>The implementation private key value (if exportable)</summary>
        public override IKeyAdvancedPrivate IKeyAdvancedPrivate => PrivateKey;

        ///<summary>The private key parameters represented in PKIX form</summary>
        public override PKIXPrivateKeyECDH PKIXPrivateKeyECDH { get; }

        ///<summary>The public key parameters represented in PKIX form</summary>
        public override PKIXPublicKeyECDH PKIXPublicKeyECDH { get; }

        /// <summary>The supported key uses (e.g. signing, encryption)</summary>
        public override KeyUses KeyUses { get; } = KeyUses.Any;


        ///<summary>If true, the key only has access to public key values.</summary>
        public override bool PublicOnly => PrivateKey == null;

        /// <summary>
        /// The byte encoding of the public key
        /// </summary>
        public override byte[] PublicData => PublicKey.Encoding;
        #endregion

        KeySecurity KeyType = KeySecurity.Public;
        byte[] EncodedPrivateKey = null;

        /// <summary>
        /// Construct a KeyPairEd25519 instance for the specified key data in interchange 
        /// format. 
        /// </summary>
        /// <param name="key">The key data as specified in RFC8032.</param>
        /// <param name="keyType">The key type.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
        /// in signature operations.</param>
        public KeyPairX448(
                    byte[] key,
                    KeySecurity keyType = KeySecurity.Public,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) {

            CryptoAlgorithmID = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmID.Ed448);
            KeyType = keyType;
            KeyUses = keyUses;
            if (keyType == KeySecurity.Public) {
                PublicKey = new CurveX448Public(key);
                }
            else {
                EncodedPrivateKey = key;
                var privateKey = new CurveX448Private(key);
                PublicKey = privateKey.Public;
                if (keyType == KeySecurity.Exportable) {
                    var PKIXPrivateKeyECDH = new PKIXPrivateKeyX448() {
                        Data = key
                        };
                    this.PKIXPrivateKeyECDH = PKIXPrivateKeyECDH; // Enable export.
                    }
                }
            PKIXPublicKeyECDH = new PKIXPublicKeyEd448(PublicKey.Encoding);
            }


        /// <summary>
        /// Construct a KeyPairEd25519 instance for a secret scalar. This is used to create
        /// private keys using cogeneration.
        /// </summary>
        /// <param name="privateKey">The secret scalar value.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
        /// in signature operations.</param>
        public KeyPairX448(
                    CurveX448Private privateKey = null,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) {
            CryptoAlgorithmID = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmID.Ed448);
            PrivateKey = privateKey;
            KeyType = KeySecurity.Bound;
            KeyUses = keyUses;
            }

        /// <summary>
        /// Generate a new private key.
        /// </summary>
        /// <param name="keyType">The key storage class.</param>
        /// <param name="keyUses">The permitted key uses</param>
        /// <param name="cryptoAlgorithmID">Cryptoraphic algorithm</param>
        /// <returns>The created key pair.</returns>
        public static KeyPairX448 Generate(
                    KeySecurity keyType = KeySecurity.Public,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) =>
            new KeyPairX448(Platform.GetRandomBits(448), keyType, keyUses, cryptoAlgorithmID);


        /// <summary>
        /// Construct class from a public key value
        /// </summary>
        /// <param name="Public">The public key value</param>
        /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
        /// in signature operations.</param>
        public KeyPairX448(IKeyAdvancedPublic Public,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) {
            CryptoAlgorithmID = cryptoAlgorithmID == CryptoAlgorithmID.Default ?
                CryptoAlgorithmID.Ed448 : cryptoAlgorithmID;
            PublicKey = Public as CurveX448Public;
            PKIXPublicKeyECDH = new PKIXPublicKeyX448(PublicKey.Encoding);
            }


        /// <summary>
        /// Factory method to produce a key pair from key parameters.
        /// </summary>
        /// <param name="PrivateKey">The private key</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate PrivateKey) =>
            new KeyPairX448((CurveX448Private)PrivateKey);

        /// <summary>
        /// Factory method to produce a key pair from implementation public key parameters
        /// </summary>
        /// <param name="PublicKey">The public key</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPublic PublicKey) =>
            new KeyPairX448((CurveEdwards448Public)PublicKey);

        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns>The new keypair that contains only the public values.</returns>
        public override KeyPair KeyPairPublic() => new KeyPairEd448(PublicKey);

        /// <summary>
        /// Persist the key to a key collection. Note that it is only possible to store a 
        /// </summary>
        /// <param name="keyCollection"></param>
        public override void Persist(KeyCollection keyCollection) {
            Assert.True(PersistPending);
            var pkix = PKIXPrivateKeyECDH ?? new PKIXPrivateKeyX448() { Data = EncodedPrivateKey };
            keyCollection.Persist(pkix, KeyType.IsExportable());
            }

        #region // Operations
        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="Public">Public key parameters</param>
        /// <param name="Carry">Carried result to add in to the agreement (for recryption)</param>
        /// <returns>The key agreement value ZZ</returns>
        ResultECDH Agreement(KeyPairX448 Public, CurveX448Result Carry = null) {
            Assert.True(KeyUses.HasFlag(KeyUses.Encrypt), CryptographicOperationNotSupported.Throw);

            CurveMontgomery448 Agreement;
            if (Carry == null) {
                Agreement = PrivateKey.Agreement(Public.PublicKey);
                }
            else {
                Agreement = PrivateKey.Agreement(Public.PublicKey, Carry.Agreement);
                }
            return new CurveX448Result() { Agreement = Agreement };
            }

        /// <summary>
        /// Encrypt a bulk key.
        /// </summary>
        /// <returns>The encoder</returns>
        /// <param name="Key">The key to encrypt.</param>
        /// <param name="Ephemeral">The ephemeral key to use for the exchange (if used)</param>
        /// <param name="Exchange">The private key to use for the exchange.</param>
        /// <param name="Salt">Optional salt value for use in key derivation.</param>
        public override void Encrypt(byte[] Key,
            out byte[] Exchange,
            out KeyPair Ephemeral,
            byte[] Salt = null) => PublicKey.Agreement().Encrypt(Key, out Exchange, out Ephemeral, Salt);

        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="EncryptedKey">The encrypted session</param>
        /// <param name="Ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <param name="Partial">Partial key agreement carry in (for recryption)</param>
        /// <param name="Salt">Optional salt value for use in key derivation. If specified
        /// must match the salt used to encrypt.</param>        
        /// <returns>The decoded data instance</returns>
        public override byte[] Decrypt(byte[] EncryptedKey,
            KeyPair Ephemeral = null,
            CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
            KeyAgreementResult Partial = null, byte[] Salt = null) {

            var keyPairX448 = Ephemeral as KeyPairX448;
            Assert.NotNull(keyPairX448, KeyTypeMismatch.Throw);

            var Agreementx = Agreement(keyPairX448, Partial as CurveX448Result);
            return Agreementx.Decrypt(EncryptedKey, Ephemeral, Partial, Salt);
            }

        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="Data">The data to sign.</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <param name="Context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <returns>The signature data</returns>
        public override byte[] SignHash(byte[] Data,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
                byte[] Context = null) => throw new InvalidOperation();

        /// <summary>
        /// Verify a signature over the purported data digest.
        /// </summary>
        /// <param name="Signature">The signature blob value.</param>
        /// <param name="AlgorithmID">The signature and hash algorithm to use.</param>
        /// <param name="Context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <param name="Data">The digest value to be verified.</param>
        /// <returns>True if the signature is valid, otherwise false.</returns>
        public override bool VerifyHash(
            byte[] Data,
            byte[] Signature,
            CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
                byte[] Context = null) => throw new InvalidOperation();
        #endregion
        }

    }
