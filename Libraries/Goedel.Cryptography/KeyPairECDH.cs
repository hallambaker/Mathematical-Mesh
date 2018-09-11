using System.Numerics;
using System.Collections.Generic;
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


        ///// <summary>
        ///// Construct a KeyPair entry from PKIX parameters. Initialized by the cryptographic
        ///// platform provider.
        ///// </summary>
        //public static FactoryECDHPublicKeyDelegate KeyPairPublicFactory = KeyPairECDH.KeyPairPublicFactory;

        ///// <summary>
        ///// Construct a KeyPair entry from PKIX parameters. Initialized by the cryptographic
        ///// platform provider.
        ///// </summary>
        //public static FactoryECDHPrivateKeyDelegate KeyPairPrivateFactory = KeyPairECDH.KeyPairPrivateFactory;




        }


    /// <summary>
    /// Description of a Diffie Hellman Key Pair. This class exposes methods and properties
    /// that allow conversion of the public key (and private key if known) values to various
    /// formats.
    /// </summary>
    public abstract class KeyPairECDH : KeyPairBaseECDH {

        /// <summary>
        /// Create a new ephemeral private key and use it to perform a key
        /// agreement.
        /// </summary>
        /// <returns>The key agreement parameters, the public key value and the
        /// key agreement.</returns>
        public ResultECDH Agreement() => throw new NotImplementedException();

        #region // Providers (To be deleted)
        /// <summary>
        /// Returns an encryption provider for the key (if the public portion is available)
        /// </summary>
        /// <param name="Bulk">The encryption algorithm to use</param>
        /// <returns>The cryptographic provider.</returns>
        public override CryptoProviderExchange ExchangeProvider(
                    CryptoAlgorithmID Bulk = CryptoAlgorithmID.Default) =>
            throw new NotImplementedException();
        //new CryptoProviderExchangeECDH(this, Bulk);

        /// <summary>
        /// Obsolete
        /// </summary>
        /// <param name="BulkAlgorithm"></param>
        /// <returns></returns>
        public override CryptoProviderSignature SignatureProvider(
            CryptoAlgorithmID BulkAlgorithm = CryptoAlgorithmID.Default) =>
                    throw new NotImplementedException();

        #endregion


        // Abstract method implementations to be shared across the curves

        /// <summary>
        /// Encrypt a bulk key.
        /// </summary>
        /// <returns>The encoder</returns>
        /// <param name="Key">The key to encrypt.</param>
        /// <param name="Ephemeral">The ephemeral key to use for the exchange (if used)</param>
        /// <param name="Exchange">The private key to use for the exchange.</param>
        /// <param name="Salt">Optional salt value for use in key derivation.</param>
        public override void Encrypt(
                    byte[] Key, 
                    out byte[] Exchange, 
                    out KeyPair Ephemeral, 
                    byte[] Salt = null) => throw new NotImplementedException();

        /// <summary>
        /// Perform a key exchange to decrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="EncryptedKey">The encrypted session key</param>
        /// <param name="Ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <param name="Partial">Partial key agreement value (for recryption)</param>
        /// <param name="Salt">Optional salt value for use in key derivation. If specified
        /// must match the salt used to encrypt.</param>
        /// <returns>The decoded data instance</returns>
        public override byte[] Decrypt(
                    byte[] EncryptedKey,
                    KeyPair Ephemeral,
                    CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
                    KeyAgreementResult Partial = null,
                    byte[] Salt = null) => throw new NotImplementedException();


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
        public ResultECDH Agreement(KeyPairECDH Public, DiffieHellmanResult Carry = null) =>
            throw new NotImplementedException();

        /// <summary>
        /// Generate a key pair for the specified algorithm and key size.
        /// </summary>
        /// <param name="KeySize">The Key size, must be 255 or 448</param>
        /// <param name="KeySecurity">The key security model</param>
        /// <param name="Signature">If true the key MAY be used for signing</param>
        /// <param name="Exchange">If true the key MAY be used for exchange</param>
        /// <param name="CryptoAlgorithmID">The cryptographic algorithm identifier</param>
        /// <returns>The generated key pair</returns>
        public static KeyPair KeyPairFactory(
                KeySecurity KeySecurity = KeySecurity.Exportable, int KeySize = 0,
                bool Signature = true, bool Exchange = true,
                CryptoAlgorithmID CryptoAlgorithmID = CryptoAlgorithmID.NULL) {

            KeySize = KeySize == 0 ? 448 : KeySize;

            switch (CryptoAlgorithmID) {
                case CryptoAlgorithmID.Ed448: return new KeyPairEd448(KeySecurity, Signature, Exchange);
                case CryptoAlgorithmID.Ed25519: return new KeyPairEd25519(KeySecurity, Signature, Exchange);
                }

            switch (KeySize) {
                case 448: return new KeyPairEd448(KeySecurity, Signature, Exchange);
                case 25519: return new KeyPairEd25519(KeySecurity, Signature, Exchange);
                }
            throw new NYI();
            }

        }


    /// <summary>
    /// Ed25519 public / private keypair.
    /// </summary>
    public class KeyPairEd25519 : KeyPairECDH {

        CurveEdwards25519Public CurveEdwards25519Public;
        CurveEdwards25519Private CurveEdwards25519Private;

        /// <summary>
        /// Construct class from a public key value
        /// </summary>
        /// <param name="Public">The public key value</param>
        public KeyPairEd25519(IKeyAdvancedPublic Public) => 
                    CurveEdwards25519Public = Public as CurveEdwards25519Public;

        /// <summary>
        /// Generate a new DH keypair.
        /// </summary>
        /// <param name="KeySecurity">The key security model</param>
        /// <param name="Signature">If true the key MAY be used for signing</param>
        /// <param name="Exchange">If true the key MAY be used for exchange</param>
        public KeyPairEd25519(
            KeySecurity KeySecurity = KeySecurity.Exportable,
            bool Signature = true, bool Exchange = true) :
                    this(new CurveEdwards25519Private(KeySecurity.IsExportable())) {
            }

        /// <summary>
        /// Create a new Ed25519 keypair for private key parameters <paramref name="PrivateKey"/>
        /// and protect with the model <paramref name="KeySecurity"/>.
        /// </summary>
        /// <param name="PrivateKey">The public key to create a provider for</param>
        /// <param name="KeySecurity">The key security model</param>
        /// <param name="Signature">If true the key MAY be used for signing</param>
        /// <param name="Exchange">If true the key MAY be used for exchange</param>
        public KeyPairEd25519(
                    CurveEdwards25519Private PrivateKey,
                    KeySecurity KeySecurity = KeySecurity.Ephemeral,
                    bool Signature = true, bool Exchange = true) {

            this.CurveEdwards25519Public = PrivateKey.Public;
            this.CurveEdwards25519Private = PrivateKey;
            if (KeySecurity == KeySecurity.Ephemeral) {
                return; // Work is complete, do not persist or enable export
                }

            var PKIXPrivateKeyECDH = new PKIXPrivateKey25519() {
                Data = CurveEdwards25519Private.Encoding,
                };

            if (KeySecurity.IsExportable()) {
                this.PKIXPrivateKeyECDH = PKIXPrivateKeyECDH; // Enable export.
                }

            if (KeySecurity.IsPersisted()) {
                Platform.WriteToKeyStore(PKIXPrivateKeyECDH, KeySecurity);
                }
            }

        ///<summary>The implementation public key value</summary>
        public override IKeyAdvancedPublic IKeyAdvancedPublic => CurveEdwards25519Public;

        ///<summary>The implementation private key value (if exportable)</summary>
        public override IKeyAdvancedPrivate IKeyAdvancedPrivate => CurveEdwards25519Private;

        ///<summary>The private key parameters represented in PKIX form</summary>
        public override PKIXPrivateKeyECDH PKIXPrivateKeyECDH { get; }

        ///<summary>The public key parameters represented in PKIX form</summary>
        public override PKIXPublicKeyECDH PKIXPublicKeyECDH { get; }

        ///<summary>If true, the key may be used for signing</summary>
        public override bool Signature { get; } = true;

        ///<summary>If true, the key may be used for exchange</summary>
        public override bool Exchange { get; } = true;

        ///<summary>If true, the key only has access to public key values.</summary>
        public override bool PublicOnly => CurveEdwards25519Private == null;

        /// <summary>
        /// Factory method to produce a key pair from key parameters.
        /// </summary>
        /// <param name="PrivateKey">The private key</param>
        /// <param name="KeySecurity">The Key security model</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate PrivateKey, KeySecurity KeySecurity) =>
            new KeyPairEd25519((CurveEdwards25519Private)PrivateKey, KeySecurity: KeySecurity);

        /// <summary>
        /// Factory method to produce a key pair from implementation public key parameters
        /// </summary>
        /// <param name="PublicKey">The public key</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPublic PublicKey) =>
            new KeyPairEd25519((CurveEdwards25519Private)PublicKey);

        /// <summary>
        /// Attempt to locate anbd bind the private key parameters via the platform key store.
        /// </summary>
        public override void GetPrivate() {
            if (CurveEdwards25519Private != null) {
                return; // Already got the private value
                }

            var Private = Platform.FindInKeyStore(UDF, CryptoAlgorithmID.ECDH) as KeyPairEd25519;
            CurveEdwards25519Private = Private.CurveEdwards25519Private;
            }


        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns>The new keypair that contains only the public values.</returns>
        public override KeyPair KeyPairPublic() => new KeyPairEd25519(CurveEdwards25519Public);

        }


    /// <summary>
    /// KeyPair binding for Ed448 signature and exchange.
    /// </summary>
    public class KeyPairEd448 : KeyPairECDH {

        CurveEdwards448Public CurveEdwards448Public;
        CurveEdwards448Private CurveEdwards448Private;

        /// <summary>
        /// Construct class from a public key value
        /// </summary>
        /// <param name="Public">The public key value</param>
        public KeyPairEd448(IKeyAdvancedPublic Public) =>
                    CurveEdwards448Public = Public as CurveEdwards448Public;

        /// <summary>
        /// Generate a new DH keypair.
        /// </summary>
        /// <param name="KeySecurity">The key security model</param>
        /// <param name="Signature">If true the key MAY be used for signing</param>
        /// <param name="Exchange">If true the key MAY be used for exchange</param>
        public KeyPairEd448(
            KeySecurity KeySecurity = KeySecurity.Exportable,
            bool Signature = true, bool Exchange = true) :
                    this(new CurveEdwards448Private(KeySecurity.IsExportable())) {
            }

        /// <summary>
        /// Create a new Ed25519 keypair for private key parameters <paramref name="PrivateKey"/>
        /// and protect with the model <paramref name="KeySecurity"/>.
        /// </summary>
        /// <param name="PrivateKey">The public key to create a provider for</param>
        /// <param name="KeySecurity">The key security model</param>
        /// <param name="Signature">If true the key MAY be used for signing</param>
        /// <param name="Exchange">If true the key MAY be used for exchange</param>
        public KeyPairEd448(
                    CurveEdwards448Private PrivateKey,
                    KeySecurity KeySecurity = KeySecurity.Ephemeral,
                    bool Signature = true, bool Exchange = true) {

            this.CurveEdwards448Public = PrivateKey.Public;
            this.CurveEdwards448Private = PrivateKey;
            if (KeySecurity == KeySecurity.Ephemeral) {
                return; // Work is complete, do not persist or enable export
                }

            var PKIXPrivateKeyECDH = new PKIXPrivateKey25519() {
                Data = CurveEdwards448Private.Encoding,
                };

            if (KeySecurity.IsExportable()) {
                this.PKIXPrivateKeyECDH = PKIXPrivateKeyECDH; // Enable export.
                }

            if (KeySecurity.IsPersisted()) {
                Platform.WriteToKeyStore(PKIXPrivateKeyECDH, KeySecurity);
                }
            }

        ///<summary>The implementation public key value</summary>
        public override IKeyAdvancedPublic IKeyAdvancedPublic => CurveEdwards448Public;

        ///<summary>The implementation private key value (if exportable)</summary>
        public override IKeyAdvancedPrivate IKeyAdvancedPrivate => CurveEdwards448Private;

        ///<summary>The private key parameters represented in PKIX form</summary>
        public override PKIXPrivateKeyECDH PKIXPrivateKeyECDH { get; }

        ///<summary>The public key parameters represented in PKIX form</summary>
        public override PKIXPublicKeyECDH PKIXPublicKeyECDH { get; }

        ///<summary>If true, the key may be used for signing</summary>
        public override bool Signature { get; } = true;

        ///<summary>If true, the key may be used for exchange</summary>
        public override bool Exchange { get; } = true;

        ///<summary>If true, the key only has access to public key values.</summary>
        public override bool PublicOnly => CurveEdwards448Private == null;

        /// <summary>
        /// Factory method to produce a key pair from key parameters.
        /// </summary>
        /// <param name="PrivateKey">The private key</param>
        /// <param name="KeySecurity">The Key security model</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate PrivateKey, KeySecurity KeySecurity) =>
            new KeyPairEd448((CurveEdwards448Private)PrivateKey, KeySecurity: KeySecurity);

        /// <summary>
        /// Factory method to produce a key pair from implementation public key parameters
        /// </summary>
        /// <param name="PublicKey">The public key</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPublic PublicKey) =>
            new KeyPairEd448((CurveEdwards448Private)PublicKey);

        /// <summary>
        /// Attempt to locate anbd bind the private key parameters via the platform key store.
        /// </summary>
        public override void GetPrivate() {
            if (CurveEdwards448Private != null) {
                return; // Already got the private value
                }

            var Private = Platform.FindInKeyStore(UDF, CryptoAlgorithmID.ECDH) as KeyPairEd448;
            CurveEdwards448Private = Private.CurveEdwards448Private;
            }


        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns>The new keypair that contains only the public values.</returns>
        public override KeyPair KeyPairPublic() => new KeyPairEd25519(CurveEdwards448Public);


        }

    }
