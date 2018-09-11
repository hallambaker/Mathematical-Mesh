using System.Numerics;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography.Algorithms;
using System;

namespace Goedel.Cryptography {

    /// <summary>
    /// Base class for DH key exchange. Algorithm identifier, factory and conversion methods are
    /// defined in this class. To make use of a different cryptographic implementation, implement
    /// a new subclass and override the default key factories.
    /// </summary>
    public abstract class KeyPairBaseDH : KeyPairAdvanced {

        /// <summary>
        /// ASN.1 Object Identifier for the domain parameters (1.3.6.1.4.1.35405.1.22.0).
        /// </summary>
        /// <remarks>
        /// Since this is not standard DH, the OID is in 
        /// PHB's OID space.
        /// </remarks>
        public const string KeyOIDDomain = Constants.OIDS__id_dh_domain;

        /// <summary>
        /// ASN.1 Object Identifier for the public key parameters (1.3.6.1.4.1.35405.1.22.1).
        /// </summary>
        /// <remarks>
        /// Since this is not standard DH, the OID is in 
        /// PHB's OID space.
        /// </remarks>
        public const string KeyOIDPublic = Constants.OIDS__id_dh_public;// "";

        /// <summary>
        /// ASN.1 Object Identifier for the private key parameters (1.3.6.1.4.1.35405.1.22.2).
        /// </summary>
        /// <remarks>
        /// Since this is not standard DH, the OID is in 
        /// PHB's OID space.
        /// </remarks>
        public const string KeyOIDPrivate = Constants.OIDS__id_dh_private;


        /// <summary>
        /// Return private key parameters in PKIX structure
        /// </summary>
        public abstract DHDomain DHDomain { get; }

        /// <summary>
        /// Return private key parameters in PKIX structure
        /// </summary>
        public abstract PKIXPrivateKeyDH PKIXPrivateKeyDH { get; }

        /// <summary>
        /// Return public key parameters in PKIX structure
        /// </summary>
        public abstract PKIXPublicKeyDH PKIXPublicKeyDH { get; }

        /// <summary>
        /// Construct a KeyPair entry from PKIX parameters. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryDHPublicKeyDelegate KeyPairPublicFactory = KeyPairDH.KeyPairPublicFactory;

        /// <summary>
        /// Construct a KeyPair entry from PKIX parameters. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryDHPrivateKeyDelegate KeyPairPrivateFactory = KeyPairDH.KeyPairPrivateFactory;

        /// <summary>The key pair supports signing and/or verification operations</summary>
        public override bool Signature => false;

        /// <summary>The key pair supports key exchange operations</summary>
        public override bool Exchange => true;


        }



    /// <summary>
    /// Description of a Diffie Hellman Key Pair. This class exposes methods and properties
    /// that allow conversion of the public key (and private key if known) values to various
    /// formats.
    /// </summary>
    public class KeyPairDH : KeyPairBaseDH {

        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public override IPKIXPrivateKey PKIXPrivateKey {
            get {
                Assert.NotNull(PKIXPrivateKeyDH, NotExportable.Throw);
                return PKIXPrivateKeyDH;
                }
            }



        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public override IPKIXPublicKey PKIXPublicKey => PKIXPublicKeyDH;

        ///<summary>The implementation public key value</summary>
        public override IKeyAdvancedPublic IKeyAdvancedPublic => PublicKey;

        ///<summary>The implementation private key value (if exportable)</summary>
        public override IKeyAdvancedPrivate IKeyAdvancedPrivate => PrivateKey;

        /// <summary>
        /// Factory method to produce a key pair from key parameters.
        /// </summary>
        /// <param name="PrivateKey">The private key</param>
        /// <param name="KeySecurity">The Key security model</param>
        /// <returns>The key pair created.</returns>

        public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate PrivateKey, KeySecurity KeySecurity) 
            => new KeyPairDH((DiffeHellmanPrivate)PrivateKey, KeySecurity: KeySecurity);

        /// <summary>
        /// Factory method to produce a key pair from implementation public key parameters
        /// </summary>
        /// <param name="PublicKey">The public key</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPublic PublicKey)
            => new KeyPairDH((DiffeHellmanPublic)PublicKey);

        /// <summary>
        /// Generate a key pair for the specified algorithm and key size.
        /// </summary>
        /// <param name="KeySize">The Key size, must be 255 or 448</param>
        /// <param name="KeySecurity">The key security model</param>
        /// <param name="Signature">If true the key MAY be used for signing</param>
        /// <param name="Exchange">If true the key MAY be used for exchange</param>
        /// <param name="CryptoAlgorithmID">The cryptographic algorithm identifier</param>
        /// <returns>The generated key pair</returns>
        public static KeyPair GenerateKeyPair(
                KeySecurity KeySecurity = KeySecurity.Ephemeral,
            int KeySize = 0,
            bool Signature = true,
            bool Exchange = true,
            CryptoAlgorithmID CryptoAlgorithmID = CryptoAlgorithmID.NULL) =>
            new KeyPairDH(KeySecurity, KeySize == 0 ? 2048 : KeySize);


        /// <summary>
        /// The internal Public DH parameters
        /// </summary>
        public DiffeHellmanPublic PublicKey { get; private set; }

        /// <summary>
        /// The internal Private DH parameters
        /// </summary>
        DiffeHellmanPrivate PrivateKey { get; set; }


        /// <summary>
        /// Return private key parameters in PKIX structure
        /// </summary>
        public override DHDomain DHDomain  => PublicKey.DHDomain;

        #region // PKIX data formats
        /// <summary>
        /// Return private key parameters in PKIX structure
        /// </summary>
        public override PKIXPrivateKeyDH PKIXPrivateKeyDH { get; }

        /// <summary>
        /// Return public key parameters in PKIX structure
        /// </summary>
        public override PKIXPublicKeyDH PKIXPublicKeyDH {
            get {
                _DHPublicKey = _DHPublicKey ?? new PKIXPublicKeyDH() {
                    Domain = DHDomain,
                    Public = PublicKey.Public.ToByteArray()
                    };
                return _DHPublicKey;
                }
            }
        PKIXPublicKeyDH _DHPublicKey = null;

        /// <summary>
        /// The public key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public override SubjectPublicKeyInfo KeyInfoData => PKIXPublicKeyDH.SubjectPublicKeyInfo();


        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public override SubjectPublicKeyInfo PrivateKeyInfoData  => PKIXPrivateKeyDH.SubjectPublicKeyInfo();


        /// <summary>
        /// Delegate to create a key pair base
        /// </summary>
        /// <param name="PKIXParameters">The key parameters</param>
        /// <returns>The created key pair</returns>
        public static new KeyPair KeyPairPublicFactory(PKIXPublicKeyDH PKIXParameters) {
            var DiffeHellmanPublic = new DiffeHellmanPublic(PKIXParameters);

            return new KeyPairDH(DiffeHellmanPublic);
            }

        /// <summary>
        /// Delegate to create a key pair base
        /// </summary>
        /// <param name="PKIXParameters">The key parameters</param>
        /// <param name="Exportable">If true, private key parameters may be exported</param>
        /// <returns>The created key pair</returns>
        public static new KeyPair KeyPairPrivateFactory(PKIXPrivateKeyDH PKIXParameters,
                    bool Exportable = false) {
            var DiffeHellmanPrivate = new DiffeHellmanPrivate(PKIXParameters);
            var KS = Exportable ? KeySecurity.Exportable : KeySecurity.Ephemeral;

            return new KeyPairDH(DiffeHellmanPrivate, KS);
            }


        #endregion


        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns>The new keypair that contains only the public values.</returns>
        public override KeyPair KeyPairPublic() {
            var Result = new KeyPairDH(new DiffeHellmanPublic(PublicKey));
            Assert.True(Result.PublicOnly);
            return Result;
            }

        /// <summary>
        /// If true, the provider only provides the public key values.
        /// </summary>
        public override bool PublicOnly => PrivateKey==null;

        #region // CryptoProviders (to be deleted)
        /// <summary>
        /// Stub method to return a signature provider. This provider does not implement
        /// signature and so always returns null. 
        /// </summary>
        /// <param name="Bulk">The digest algorithm to use</param>
        /// <returns>The cryptographic provider.</returns>
        public override CryptoProviderSignature SignatureProvider(
                    CryptoAlgorithmID Bulk = CryptoAlgorithmID.Default) => throw new InvalidOperation("DHKeyPair does not support signature operations. ");


        /// <summary>
        /// Returns an encryption provider for the key (if the public portion is available)
        /// </summary>
        /// <param name="Bulk">The encryption algorithm to use</param>
        /// <returns>The cryptographic provider.</returns>
        public override CryptoProviderExchange ExchangeProvider(
                    CryptoAlgorithmID Bulk = CryptoAlgorithmID.Default) => 
                        new CryptoProviderExchangeDH(this, Bulk);

        #endregion

        #region // Constructors
        /// <summary>
        /// Create a new DH keypair.
        /// </summary>
        /// <param name="KeySecurity">The key security model</param>
        /// <param name="KeySize">The key size</param>
        public KeyPairDH(KeySecurity KeySecurity = KeySecurity.Ephemeral, int KeySize = 2048) :
                    this (new DiffeHellmanPrivate(KeySize), KeySecurity) {
            }

        /// <summary>
        /// Create a new DH keypair.
        /// </summary>
        /// <param name="PublicKey">The public key to create a provider for</param>
        /// <param name="KeySecurity">The key security model</param>

        public KeyPairDH(DiffeHellmanPublic PublicKey, KeySecurity KeySecurity = KeySecurity.Ephemeral) {
            this.PublicKey = PublicKey;
            PrivateKey = PublicKey as DiffeHellmanPrivate;
            if (KeySecurity == KeySecurity.Ephemeral) {
                return; // Work is complete, do not persist or enable export
                }

            var PKIXPrivateKeyDH = new PKIXPrivateKeyDH() {
                Domain = DHDomain,
                Private = PrivateKey.Private.ToByteArray(),
                Public = PrivateKey.Public.ToByteArray(),
                };

            if (KeySecurity.IsExportable()) {
                this.PKIXPrivateKeyDH = PKIXPrivateKeyDH; // Enable export.
                }

            if (KeySecurity.IsPersisted()) {
                Platform.WriteToKeyStore(PKIXPrivateKeyDH, KeySecurity);
                }
            }
        #endregion



        /// <summary>
        /// Retrieve the private key from local storage (if not already available)
        /// </summary>
        public override void GetPrivate() {
            if (PrivateKey != null) {
                return; // Already got the private value
                }

            var Private = Platform.FindInKeyStore(UDF, CryptoAlgorithmID.DH) as KeyPairDH;
            PublicKey = Private.PublicKey;
            }


        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="Public">Public key parameters</param>
        /// <param name="Carry">Carried result to add in to the agreement (for recryption)</param>
        /// <returns>The key agreement value ZZ</returns>
        DiffieHellmanResult Agreement(KeyPairDH Public, DiffieHellmanResult Carry = null) {
            BigInteger Agreement;
            if (Carry == null) {
                Agreement = PrivateKey.Agreement(Public.PublicKey);
                }
            else {
                Agreement = PrivateKey.Agreement(Public.PublicKey, Carry.Agreement);
                }
            return new DiffieHellmanResult() { Agreement = Agreement };
            }

        /// <summary>
        /// Encrypt the specified exchange key.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="Exchange"></param>
        /// <param name="Ephemeral"></param>
        /// <param name="Salt"></param>
        public override void Encrypt(byte[] Key,
            out byte[] Exchange,
            out KeyPair Ephemeral,
            byte[] Salt = null) => PublicKey.Agreement().Encrypt(Key, out Exchange, out Ephemeral, Salt);


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
                    byte[] Salt = null) {

            var DHPublic = Ephemeral as KeyPairDH;
            Assert.NotNull(DHPublic, KeyTypeMismatch.Throw);

            var Agreementx = Agreement(DHPublic, Partial as DiffieHellmanResult);
            return Agreementx.Decrypt(EncryptedKey, Ephemeral, Partial, Salt);
            }


         }


    }
