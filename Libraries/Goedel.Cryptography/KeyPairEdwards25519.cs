using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

using System;
using System.Security.Cryptography;

namespace Goedel.Cryptography {

    /// <summary>
    /// Ed25519 public / private keypair.
    /// </summary>
    public class KeyPairEd25519 : KeyPairEdwards {

        #region //Properties
        ///<summary>The implementation public key value</summary>
        public CurveEdwards25519Public PublicKey { get; set; }

        ///<summary>The implementation private key value (if exportable)</summary>
        public CurveEdwards25519Private PrivateKey { get; set; }

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
        public KeyPairEd25519(
                    byte[] key,
                    KeySecurity keyType = KeySecurity.Public,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) {

            CryptoAlgorithmId = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmId.Ed25519);
            KeyType = keyType;
            KeyUses = keyUses;
            if (keyType == KeySecurity.Public) {
                PublicKey = new CurveEdwards25519Public(key);
                PKIXPublicKeyECDH = new PKIXPublicKeyEd25519(PublicKey.Encoding);
                KeyType = KeySecurity.Public;
                }
            else {
                EncodedPrivateKey = key;
                var exportable = keyType.IsExportable();
                PrivateKey = new CurveEdwards25519Private(key, exportable);
                PublicKey = PrivateKey.Public;
                PKIXPublicKeyECDH = new PKIXPublicKeyEd25519(PublicKey.Encoding);
                if (exportable) {
                    PKIXPrivateKeyECDH = new PKIXPrivateKeyEd25519(key, PKIXPublicKeyECDH);
                    }
                }

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
        public KeyPairEd25519(byte[] ikm, byte[] salt,
                    KeySecurity keyType = KeySecurity.Public,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) :
                    this(KeyDeriveHKDF.Derive(ikm, salt, null, 256, CryptoAlgorithmId.HMAC_SHA_2_512), keyType, keyUses, cryptoAlgorithmID) {
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
        public KeyPairEd25519(
                    CurveEdwards25519Private privateKey = null,
                    KeySecurity keySecurity = KeySecurity.Bound,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) {
            CryptoAlgorithmId = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmId.Ed25519);
            PrivateKey = privateKey ?? new CurveEdwards25519Private();
            PublicKey = PrivateKey.Public;
            PKIXPublicKeyECDH = new PKIXPublicKeyEd25519(PublicKey.Encoding);
            KeyType = keySecurity;
            KeyUses = keyUses;
            }

        /// <summary>
        /// Construct class from a public key value
        /// </summary>
        /// <param name="publicKey">The public key value</param>
        /// <param name="cryptoAlgorithmID">Specifies the default algorithm variation for use
        /// in signature operations.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        public KeyPairEd25519(IKeyAdvancedPublic publicKey,
                    CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default,
                    KeyUses keyUses = KeyUses.Any) {

            CryptoAlgorithmId = cryptoAlgorithmID.DefaultMeta(CryptoAlgorithmId.Ed25519);
            this.PublicKey = publicKey as CurveEdwards25519Public;
            PKIXPublicKeyECDH = new PKIXPublicKeyEd25519(this.PublicKey.Encoding);
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
                    KeySecurity keyType = KeySecurity.Public,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmId cryptoAlgorithmID = CryptoAlgorithmId.Default) =>
            new KeyPairEd25519(Platform.GetRandomBits(256), keyType, keyUses, cryptoAlgorithmID);

        /// <summary>
        /// Factory method to produce a key pair from key parameters.
        /// </summary>
        /// <param name="privateKey">The private key</param>
        /// <param name="keySecurity">The key security model.</param>
        /// <param name="keyUses">The permitted key uses.</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate privateKey,
                    KeySecurity keySecurity = KeySecurity.Bound,
                    KeyUses keyUses = KeyUses.Any) =>
            new KeyPairEd25519((CurveEdwards25519Private)privateKey, keySecurity, keyUses);

        /// <summary>
        /// Factory method to produce a key pair from implementation public key parameters
        /// </summary>
        /// <param name="publicKey">The public key</param>
        /// <param name="keyUses">The permitted key uses.</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPublic publicKey,
                    KeyUses keyUses = KeyUses.Any) =>
            new KeyPairEd25519((CurveEdwards25519Public)publicKey, keyUses: keyUses);


        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns>The new keypair that contains only the public values.</returns>
        public override KeyPair KeyPairPublic() => new KeyPairEd25519(PublicKey, keyUses: KeyUses) {
            Locator = Locator
            };


        /// <summary>
        /// Persist the key to a key collection. Note that it is only possible to store a 
        /// </summary>
        /// <param name="keyCollection"></param>
        public override void Persist(
                KeyCollection keyCollection) {
            Assert.AssertTrue(PersistPending, CryptographicException.Throw);
            var pkix = PKIXPrivateKeyECDH ?? new PKIXPrivateKeyEd25519(EncodedPrivateKey, PKIXPublicKeyECDH) { };
            keyCollection.Persist(KeyIdentifier, pkix, KeyType.IsExportable());
            }


        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="publicKey">Public key parameters</param>
        /// <param name="Carry">Carried result to add in to the agreement (for recryption)</param>
        /// <returns>The key agreement value ZZ</returns>
        public CurveEdwards25519Result Agreement(KeyPairEd25519 publicKey, CurveEdwards25519Result Carry = null) {
            CurveEdwards25519 Agreement;
            if (Carry == null) {
                Agreement = PrivateKey.Agreement(publicKey.PublicKey);
                }
            else {
                Agreement = PrivateKey.Agreement(publicKey.PublicKey, Carry.AgreementEd25519);
                }
            return new CurveEdwards25519Result() { AgreementEd25519 = Agreement };
            }

        /// <summary>
        /// Encrypt a bulk key.
        /// </summary>
        /// <returns>The encoder</returns>
        /// <param name="key">The key to encrypt.</param>
        /// <param name="ephemeral">The ephemeral key to use for the exchange (if used)</param>
        /// <param name="exchange">The private key to use for the exchange.</param>
        /// <param name="salt">Optional salt value for use in key derivation.</param> 
        public override void Encrypt(byte[] key,
                out byte[] exchange,
                out KeyPair ephemeral,
                byte[] salt = null) => PublicKey.Agreement().Encrypt(key, out exchange, out ephemeral, salt);


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
        public override byte[] Decrypt(byte[] encryptedKey,
                KeyPair ephemeral = null,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                KeyAgreementResult partial = null,
                byte[] salt = null) {

            var KeyPairEd25519 = ephemeral as KeyPairEd25519;
            Assert.AssertNotNull(KeyPairEd25519, KeyTypeMismatch.Throw);

            var Agreementx = Agreement(KeyPairEd25519, partial as CurveEdwards25519Result);

            //Console.WriteLine($"Key {Agreementx.IKM.ToStringBase16FormatHex()}");

            return Agreementx.Decrypt(encryptedKey, ephemeral, partial, salt);
            }


        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="data">The data to sign.</param>
        /// <param name="algorithmID">The algorithm to use.</param>
        /// <param name="context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <returns>The signature data</returns>
        public override byte[] SignHash(
                byte[] data,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null) {

            algorithmID = algorithmID == CryptoAlgorithmId.Default ? CryptoAlgorithmId : algorithmID;
            if (algorithmID == CryptoAlgorithmId.Ed25519ph) {
                using var sha512 = SHA512.Create();
                data = sha512.ComputeHash(data);
                }

            


            var dom2 = CurveEdwards25519.Dom2(algorithmID, context);

            //Console.WriteLine($"Data = {data.ToStringBase16FormatHex()}");
            //Console.WriteLine($"Dom2 = {dom2?.ToStringBase16FormatHex()}");

            return PrivateKey.Sign(data, dom2);
            }

        /// <summary>
        /// Begin the process of signing the data <paramref name="data"/> according to the
        /// algorithm specifier <paramref name="algorithmID"/> and optional context value
        /// <paramref name="context"/>.
        /// </summary>
        /// <param name="data">The data to sign</param>
        /// <param name="algorithmID">The specific signature algorithm variant.</param>
        /// <param name="context">Optional context value.</param>
        /// <returns>The signature context.</returns>
        public override ThresholdSignatureEdwards SignHashThreshold(byte[] data,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null) => new ThresholdSignatureEdwards25519(PrivateKey);






        /// <summary>
        /// Verify a signature over the purported data digest.
        /// </summary>
        /// <param name="signature">The signature blob value.</param>
        /// <param name="algorithmID">The signature and hash algorithm to use.</param>
        /// <param name="context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <param name="data">The digest value to be verified.</param>
        /// <returns>True if the signature is valid, otherwise false.</returns>
        public override bool VerifyHash(
                byte[] data,
                byte[] signature,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null) {
            algorithmID = algorithmID == CryptoAlgorithmId.Default ? CryptoAlgorithmId : algorithmID;
            if (algorithmID == CryptoAlgorithmId.Ed25519ph) {
                using var sha512 = SHA512.Create();

                data = sha512.ComputeHash(data);
                }

            var dom2 = CurveEdwards25519.Dom2(algorithmID, context);
            return PublicKey.Verify(data, signature, dom2);
            }
        }



    }
