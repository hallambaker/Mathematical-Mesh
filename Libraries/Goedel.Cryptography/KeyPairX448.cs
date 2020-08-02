using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

namespace Goedel.Cryptography {

    /// <summary>
    /// KeyPair binding for X448 signature and exchange.
    /// </summary>
    public class KeyPairX448 : KeyPairECDH {

        #region //Properties
        ///<summary>The public key value.</summary>
        public CurveX448Public PublicKey { get; set; }

        ///<summary>The implementation private key value (if exportable)</summary>
        public CurveX448Private PrivateKey { get; set; }

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

        KeySecurity keyType = KeySecurity.Public;
        byte[] encodedPrivateKey = null;

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
                    CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) {

            CryptoAlgorithmId = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmId.X448);
            this.keyType = keyType;
            KeyUses = keyUses;
            if (keyType == KeySecurity.Public) {
                PublicKey = new CurveX448Public(key);
                PKIXPublicKeyECDH = new PKIXPublicKeyX448(PublicKey.Encoding);
                }
            else {
                encodedPrivateKey = key;
                var exportable = keyType.IsExportable();
                PrivateKey = new CurveX448Private(key, exportable);
                PublicKey = PrivateKey.Public;
                PKIXPublicKeyECDH = new PKIXPublicKeyX448(PublicKey.Encoding);
                if (exportable) {
                    PKIXPrivateKeyECDH = new PKIXPrivateKeyX448(key, PKIXPublicKeyECDH);
                    }
                }
            PKIXPublicKeyECDH = new PKIXPublicKeyX448(PublicKey.Encoding);
            }


        /// <summary>
        /// Construct a key via parameters presented to KDF-HMAC-SHA-2-512. 
        /// <para>The values <paramref name="ikm"/> and <paramref name="salt"/> are used to
        /// generate the key data value as specified by RFC8032.</para>
        /// </summary>
        /// <param name="ikm">The initial keying material.</param>
        /// <param name="salt">Salt value.</param>
        /// <param name="keyType">The key type.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
        /// in signature operations.</param>
        public KeyPairX448(byte[] ikm, byte[] salt,
                    KeySecurity keyType = KeySecurity.Public,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) :
                    this(KeyDeriveHKDF.Derive(ikm, salt, null, 448, CryptoAlgorithmId.HMAC_SHA_2_512), keyType, keyUses, cryptoAlgorithmID) {
            }

        /// <summary>
        /// Construct a KeyPairEd25519 instance for a secret scalar. This is used to create
        /// private keys using cogeneration.
        /// </summary>
        /// <param name="privateKey">The secret scalar value.</param>
        /// <param name="keySecurity">The key security model.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
        /// in signature operations.</param>
        public KeyPairX448(
                    CurveX448Private privateKey = null,
                    KeySecurity keySecurity = KeySecurity.Bound,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) {
            CryptoAlgorithmId = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmId.X448);
            PrivateKey = privateKey;
            PublicKey = privateKey.Public;
            PKIXPublicKeyECDH = new PKIXPublicKeyX448(PublicKey.Encoding);
            keyType = keySecurity;
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
                    CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) =>
            new KeyPairX448(Platform.GetRandomBits(448), keyType, keyUses, cryptoAlgorithmID);

        ///// <summary>
        ///// Generate a key co-generation contribution and return the new composite public
        ///// key and the private key contribution.
        ///// </summary>
        ///// <param name="privateKey">The private key contribution.</param>
        ///// <returns>The composite public key.</returns>
        //public override KeyPairAdvanced Cogenerate(out KeyPairAdvanced privateKey) {
        //    privateKey = Generate(KeySecurity.Exportable, KeyUses, CryptoAlgorithmID);
        //    var combinedKey = PublicKey.Combine(privateKey.IKeyAdvancedPublic as CurveX448Public);
        //    return new KeyPairX448(combinedKey, CryptoAlgorithmID);
        //    }

        /// <summary>
        /// Construct class from a public key value
        /// </summary>
        /// <param name="Public">The public key value</param>
        /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
        /// in signature operations.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        public KeyPairX448(IKeyAdvancedPublic Public,
                    CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default,
                    KeyUses keyUses = KeyUses.Any) {
            CryptoAlgorithmId = cryptoAlgorithmID == CryptoAlgorithmId.Default ?
                CryptoAlgorithmId.X448 : cryptoAlgorithmID;
            PublicKey = Public as CurveX448Public;
            PKIXPublicKeyECDH = new PKIXPublicKeyX448(PublicKey.Encoding);
            KeyUses = keyUses;
            }


        /// <summary>
        /// Factory method to produce a key pair from key parameters.
        /// </summary>
        /// <param name="PrivateKey">The private key</param>
        /// <param name="keySecurity">The key security model.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate PrivateKey,
                    KeySecurity keySecurity = KeySecurity.Bound,
                    KeyUses keyUses = KeyUses.Any) =>
            new KeyPairX448((CurveX448Private)PrivateKey, keySecurity, keyUses);

        /// <summary>
        /// Factory method to produce a key pair from implementation public key parameters
        /// </summary>
        /// <param name="PublicKey">The public key</param>
        /// <param name="keyUses">The permitted key uses.</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPublic PublicKey,
                    KeyUses keyUses = KeyUses.Any) =>
            new KeyPairX448((CurveX448Public)PublicKey, keyUses: keyUses);

        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns>The new keypair that contains only the public values.</returns>
        public override KeyPair KeyPairPublic() => new KeyPairX448(PublicKey);

        /// <summary>
        /// Persist the key to a key collection. Note that it is only possible to store a 
        /// </summary>
        /// <param name="keyCollection"></param>
        public override void Persist(KeyCollection keyCollection) {
            Assert.AssertTrue(PersistPending, CryptographicException.Throw);
            var pkix = PKIXPrivateKeyECDH ?? new PKIXPrivateKeyX448() { Data = encodedPrivateKey };
            keyCollection.Persist(KeyIdentifier, pkix, keyType.IsExportable());
            }

        #region // Operations
        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="Public">Public key parameters</param>
        /// <param name="Carry">Carried result to add in to the agreement (for recryption)</param>
        /// <returns>The key agreement value ZZ</returns>
        ResultECDH Agreement(KeyPairX448 Public, CurveX448Result Carry = null) {
            Assert.AssertTrue(KeyUses.HasFlag(KeyUses.Encrypt), CryptographicOperationNotSupported.Throw);

            CurveX448 Agreement;
            if (Carry == null) {
                Agreement = PrivateKey.Agreement(Public.PublicKey);
                }
            else {
                Agreement = PrivateKey.Agreement(Public.PublicKey, Carry.AgreementX448);
                }
            return new CurveX448Result() { AgreementX448 = Agreement };
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
            CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default,
            KeyAgreementResult Partial = null, byte[] Salt = null) {

            var keyPairX448 = Ephemeral as KeyPairX448;
            Assert.AssertNotNull(keyPairX448, KeyTypeMismatch.Throw);

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
                CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default,
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
            CryptoAlgorithmId AlgorithmID = CryptoAlgorithmId.Default,
                byte[] Context = null) => throw new InvalidOperation();
        #endregion
        }

    }
