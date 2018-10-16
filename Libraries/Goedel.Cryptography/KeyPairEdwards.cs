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
    public class KeyPairEd25519 : KeyPairECDH {

        CurveEdwards25519Public PublicKey;
        CurveEdwards25519Private PrivateKey;

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


        KeyStorage KeyType = KeyStorage.Public;
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
        public KeyPairEd25519(
                    byte[] key,
                    KeyStorage keyType = KeyStorage.Public,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) {

            CryptoAlgorithmID = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmID.Ed25519);
            KeyType = keyType;
            KeyUses = keyUses;
            if (keyType == KeyStorage.Public) {
                PublicKey = new CurveEdwards25519Public(key);
                }
            else {
                EncodedPrivateKey = key;
                PrivateKey = new CurveEdwards25519Private(key);
                PublicKey = PrivateKey.Public;
                if (keyType == KeyStorage.Exportable) {
                    var PKIXPrivateKeyECDH = new PKIXPrivateKeyEd25519() {
                        Data = key
                        };
                    this.PKIXPrivateKeyECDH = PKIXPrivateKeyECDH; // Enable export.
                    }
                }
            PKIXPublicKeyECDH = new PKIXPublicKeyEd25519(PublicKey.Encoding);
            }


        /// <summary>
        /// Construct a KeyPairEd25519 instance for a secret scalar. This is used to create
        /// private keys using cogeneration.
        /// </summary>
        /// <param name="privateKey">The secret scalar value.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
        /// in signature operations.</param>
        public KeyPairEd25519(
                    CurveEdwards25519Private privateKey = null,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) {
            CryptoAlgorithmID = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmID.Ed25519);
            PrivateKey = privateKey;
            KeyType = KeyStorage.Bound;
            KeyUses = keyUses;
            }

        /// <summary>
        /// Generate a new private key.
        /// </summary>
        /// <param name="keyType">The key storage class.</param>
        /// <param name="keyUses">The permitted key uses</param>
        /// <param name="cryptoAlgorithmID">Cryptoraphic algorithm</param>
        /// <returns>The created key pair.</returns>
        public static KeyPairEd25519 Generate(
                    KeyStorage keyType = KeyStorage.Public,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) =>
            new KeyPairEd25519(Platform.GetRandomBits(256), keyType, keyUses, cryptoAlgorithmID);


        /// <summary>
        /// Construct class from a public key value
        /// </summary>
        /// <param name="Public">The public key value</param>
        /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
        /// in signature operations.</param>
        public KeyPairEd25519(IKeyAdvancedPublic Public,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) {

            CryptoAlgorithmID = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmID.Ed25519);
            PublicKey = Public as CurveEdwards25519Public;
            PKIXPublicKeyECDH = new PKIXPublicKeyEd25519(PublicKey.Encoding);
            
            }

        /// <summary>
        /// Factory method to produce a key pair from key parameters.
        /// </summary>
        /// <param name="PrivateKey">The private key</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate PrivateKey) =>
            new KeyPairEd25519((CurveEdwards25519Private)PrivateKey);

        /// <summary>
        /// Factory method to produce a key pair from implementation public key parameters
        /// </summary>
        /// <param name="PublicKey">The public key</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPublic PublicKey) =>
            new KeyPairEd25519((CurveEdwards25519Public)PublicKey);


        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns>The new keypair that contains only the public values.</returns>
        public override KeyPair KeyPairPublic() => new KeyPairEd25519(PublicKey);


        /// <summary>
        /// Persist the key to a key collection. Note that it is only possible to store a 
        /// </summary>
        /// <param name="keyCollection"></param>
        public override void Persist(KeyCollection keyCollection) {
            Assert.True(KeyType == KeyStorage.Exportable | KeyType == KeyStorage.Persistable);
            var pkix = PKIXPrivateKeyECDH ?? new PKIXPrivateKeyEd25519(EncodedPrivateKey, PKIXPublicKeyECDH) { };
            keyCollection.Persist(pkix);
            }


        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="Public">Public key parameters</param>
        /// <param name="Carry">Carried result to add in to the agreement (for recryption)</param>
        /// <returns>The key agreement value ZZ</returns>
        CurveEdwards25519Result Agreement(KeyPairEd25519 Public, CurveEdwards25519Result Carry = null) {
            CurveEdwards25519 Agreement;
            if (Carry == null) {
                Agreement = PrivateKey.Agreement(Public.PublicKey);
                }
            else {
                Agreement = PrivateKey.Agreement(Public.PublicKey, Carry.Agreement);
                }
            return new CurveEdwards25519Result() { Agreement = Agreement };
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

            var KeyPairEd25519 = Ephemeral as KeyPairEd25519;
            Assert.NotNull(KeyPairEd25519, KeyTypeMismatch.Throw);

            var Agreementx = Agreement(KeyPairEd25519, Partial as CurveEdwards25519Result);
            return Agreementx.Decrypt(EncryptedKey, Ephemeral, Partial, Salt);
            }


        static byte[] Dom2(CryptoAlgorithmID cryptoAlgorithm, byte[] y) {
            byte x=0;
            switch (cryptoAlgorithm) {
                case CryptoAlgorithmID.Ed25519 : return null;
                case CryptoAlgorithmID.Ed25519ph: {
                    x = 1;
                    break;
                    }
                case CryptoAlgorithmID.Ed25519ctx: {
                    x = 0;
                    break;
                    }
                }

            var Buffer = new MemoryStream();
            Buffer.Write("SigEd25519 no Ed25519 collisions".ToBytes());
            Buffer.WriteByte(x);
            if (y == null) {
                Buffer.WriteByte(0);
                }
            else {
                Buffer.WriteByte((byte)y.Length);
                Buffer.Write(y);
                }
            return Buffer.ToArray();
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
            byte[] Context = null) {

            AlgorithmID = AlgorithmID == CryptoAlgorithmID.Default ? CryptoAlgorithmID : AlgorithmID;
            if (AlgorithmID == CryptoAlgorithmID.Ed25519ph) {
                var sha512 = SHA512.Create();
                Data = sha512.ComputeHash(Data);
                }

            return PrivateKey.Sign(Data, Dom2 (AlgorithmID, Context));
            }

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
                byte[] Context = null) {
            AlgorithmID = AlgorithmID == CryptoAlgorithmID.Default ? CryptoAlgorithmID : AlgorithmID;
            if (AlgorithmID == CryptoAlgorithmID.Ed25519ph) {
                var sha512 = SHA512.Create();
                Data = sha512.ComputeHash(Data);
                }

            return PublicKey.Verify(Data, Signature, Dom2(AlgorithmID, Context));
            }
        }


    /// <summary>
    /// KeyPair binding for Ed448 signature and exchange.
    /// </summary>
    public class KeyPairEd448 : KeyPairECDH {

        CurveEdwards448Public PublicKey;
        CurveEdwards448Private PrivateKey;

        #region //Properties
        ///<summary>The implementation public key value</summary>
        public override IKeyAdvancedPublic IKeyAdvancedPublic => PublicKey;

        ///<summary>The implementation private key value (if exportable)</summary>
        public override IKeyAdvancedPrivate IKeyAdvancedPrivate => PrivateKey;

        ///<summary>The private key parameters represented in PKIX form</summary>
        public override PKIXPrivateKeyECDH PKIXPrivateKeyECDH { get; }

        ///<summary>The public key parameters represented in PKIX form</summary>
        public override PKIXPublicKeyECDH PKIXPublicKeyECDH { get; }

        ///<summary>If true, the key only has access to public key values.</summary>
        public override bool PublicOnly => PrivateKey == null;

        /// <summary>The supported key uses (e.g. signing, encryption)</summary>
        public override KeyUses KeyUses { get; } = KeyUses.Any;

        public virtual KeyStorage KeyType { get; } = KeyStorage.Public;

        /// <summary>
        /// The byte encoding of the public key
        /// </summary>
        public override byte[] PublicData => PublicKey.Encoding;
        #endregion


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
        public KeyPairEd448(
                    byte[] key,
                    KeyStorage keyType = KeyStorage.Public,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) {

            CryptoAlgorithmID = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmID.Ed448);
            KeyType = keyType;
            KeyUses = keyUses;
            if (keyType == KeyStorage.Public) {
                PublicKey = new CurveEdwards448Public(key);
                }
            else {
                EncodedPrivateKey = key;
                PrivateKey = new CurveEdwards448Private(key);
                PublicKey = PrivateKey.Public;
                if (keyType == KeyStorage.Exportable) {
                    PKIXPrivateKeyECDH = new PKIXPrivateKeyEd448() {
                        Data = key
                        };
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
        public KeyPairEd448(
                    CurveEdwards448Private privateKey = null,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) {
            CryptoAlgorithmID = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmID.Ed448);
            PrivateKey = privateKey;
            KeyType = KeyStorage.Bound;
            KeyUses = keyUses;
            }

        /// <summary>
        /// Generate a new private key.
        /// </summary>
        /// <param name="keyType">The key storage class.</param>
        /// <param name="keyUses">The permitted key uses</param>
        /// <param name="cryptoAlgorithmID">Cryptoraphic algorithm</param>
        /// <returns>The created key pair.</returns>
        public static KeyPairEd448 Generate(
                    KeyStorage keyType = KeyStorage.Public,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) =>
            new KeyPairEd448(Platform.GetRandomBits(448), keyType, keyUses, cryptoAlgorithmID);


        /// <summary>
        /// Construct class from a public key value
        /// </summary>
        /// <param name="Public">The public key value</param>
        /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
        /// in signature operations.</param>
        public KeyPairEd448(IKeyAdvancedPublic Public,
                    CryptoAlgorithmID cryptoAlgorithmID = CryptoAlgorithmID.Default) {
            CryptoAlgorithmID = cryptoAlgorithmID == CryptoAlgorithmID.Default ?
                CryptoAlgorithmID.Ed448 : cryptoAlgorithmID;
            PublicKey = Public as CurveEdwards448Public;
            PKIXPublicKeyECDH = new PKIXPublicKeyEd448(PublicKey.Encoding);
            }


        /// <summary>
        /// Factory method to produce a key pair from key parameters.
        /// </summary>
        /// <param name="PrivateKey">The private key</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate PrivateKey) =>
            new KeyPairEd448((CurveEdwards448Private)PrivateKey);

        /// <summary>
        /// Factory method to produce a key pair from implementation public key parameters
        /// </summary>
        /// <param name="PublicKey">The public key</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPublic PublicKey) =>
            new KeyPairEd448((CurveEdwards448Public)PublicKey);

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
            Assert.True(KeyType == KeyStorage.Exportable | KeyType == KeyStorage.Persistable);
            var pkix = PKIXPrivateKeyECDH ?? new PKIXPrivateKeyEd448(EncodedPrivateKey, PKIXPublicKeyECDH) { };
            keyCollection.Persist(pkix);
            }

        #region // Operations
        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="Public">Public key parameters</param>
        /// <param name="Carry">Carried result to add in to the agreement (for recryption)</param>
        /// <returns>The key agreement value ZZ</returns>
        ResultECDH Agreement(KeyPairEd448 Public, CurveEdwards448Result Carry = null) {
            Assert.True(KeyUses.HasFlag (KeyUses.Encrypt), CryptographicOperationNotSupported.Throw);

            CurveEdwards448 Agreement;
            if (Carry == null) {
                Agreement = PrivateKey.Agreement(Public.PublicKey);
                }
            else {
                Agreement = PrivateKey.Agreement(Public.PublicKey, Carry.Agreement);
                }
            return new CurveEdwards448Result() { Agreement = Agreement };
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

            var KeyPairEd448 = Ephemeral as KeyPairEd448;
            Assert.NotNull(KeyPairEd448, KeyTypeMismatch.Throw);

            var Agreementx = Agreement(KeyPairEd448, Partial as CurveEdwards448Result);
            return Agreementx.Decrypt(EncryptedKey, Ephemeral, Partial, Salt);
            }

        static byte[] Dom4(CryptoAlgorithmID cryptoAlgorithm, byte[] y) {
            byte x = 0;
            switch (cryptoAlgorithm) {
                case CryptoAlgorithmID.Ed448: {
                    x = 0;
                    break;
                    }
                case CryptoAlgorithmID.Ed448ph: {
                    x = 1;
                    break;
                    }
                }

            var Buffer = new MemoryStream();
            Buffer.Write("SigEd448".ToBytes());
            Buffer.WriteByte(x);
            if (y == null) {
                Buffer.WriteByte(0);
                }
            else {
                Buffer.WriteByte((byte)y.Length);
                Buffer.Write(y);
                }
            return Buffer.ToArray();
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
                byte[] Context = null) {
            Assert.True((KeyUses & KeyUses.Sign) != 0, CryptographicOperationNotSupported.Throw);

            AlgorithmID = AlgorithmID == CryptoAlgorithmID.Default ? CryptoAlgorithmID : AlgorithmID;
            if (AlgorithmID == CryptoAlgorithmID.Ed448ph) {
                var shake256 = new SHAKE256(64 * 8);
                Data = shake256.ComputeHash(Data);
                }

            return PrivateKey.Sign(Data, Dom4 (AlgorithmID, Context)); ;
            }


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
                byte[] Context = null) {
            Assert.True((KeyUses & KeyUses.Sign) != 0, CryptographicOperationNotSupported.Throw);

            AlgorithmID = AlgorithmID == CryptoAlgorithmID.Default ? CryptoAlgorithmID : AlgorithmID;
            if (AlgorithmID == CryptoAlgorithmID.Ed448ph) {
                var shake256 = new SHAKE256(64 * 8);
                Data = shake256.ComputeHash(Data);
                }
            return PublicKey.Verify(Signature, Data, Dom4(AlgorithmID, Context));
            }


        #endregion
        }

    }
