using System.Numerics;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Cryptography.PKIX;
using System;
using Goedel.Cryptography;

namespace Goedel.Cryptography.Algorithms {

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
        /// The public key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public override SubjectPublicKeyInfo PrivateKeyInfoData  => PKIXPrivateKeyDH.SubjectPublicKeyInfo();



        /// <summary>
        /// Stub method to return a signature provider. This provider does not implement
        /// signature and so always returns null. 
        /// </summary>
        /// <param name="Bulk">The digest algorithm to use</param>
        /// <returns>The cryptographic provider.</returns>
        public override CryptoProviderSignature SignatureProvider(
                    CryptoAlgorithmID Bulk = CryptoAlgorithmID.Default) {
            throw new InvalidOperation("DHKeyPair does not support signature operations. ");
            }


        /// <summary>
        /// Returns an encryption provider for the key (if the public portion is available)
        /// </summary>
        /// <param name="Bulk">The encryption algorithm to use</param>
        /// <returns>The cryptographic provider.</returns>
        public override CryptoProviderExchange ExchangeProvider(
                    CryptoAlgorithmID Bulk = CryptoAlgorithmID.Default) {
            return new CryptoProviderExchangeDH(this, Bulk);
            }


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
        /// Split the private key into a number of recryption keys.
        /// <para>
        /// Since the
        /// typical use case for recryption requires both parts of the generated machine
        /// to be used on a machine that is not the machine on which they are created, the
        /// key security level is always to permit export.</para>
        /// </summary>
        /// <param name="Shares">The number of keys to create.</param>
        /// <returns>The created keys</returns>
        public KeyPair[] GenerateRecryptionSet(int Shares) {
            var Private = PrivateKey.MakeRecryption(Shares);

            var Result = new KeyPair[Shares];
            for (var i = 0; i < Shares; i++) {
                Result[i] = new KeyPairDH(Private[i], KeySecurity: KeySecurity.Exportable);
                }

            return Result;
            }

        /// <summary>
        /// Perform key agreement
        /// </summary>
        /// <param name="KeyPair">The public key to agree to.</param>
        /// <returns>The key agreement result.</returns>
        public override KeyAgreementResult Agreement (KeyPair KeyPair) {
            var DHKeyPair = KeyPair as KeyPairDH;
            Assert.NotNull(DHKeyPair, KeyTypeMismatch.Throw);
            return Agreement(DHKeyPair);
            }



        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="Private">Private key parameters</param>
        /// <returns>The key agreement value ZZ</returns>
        public BigInteger Agreement(DiffeHellmanPrivate Private) {
            return Private.Agreement(PublicKey);
            }


        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="Public">Public key parameters</param>
        /// <param name="Carry">Carried result to add in to the agreement (for recryption)</param>
        /// <returns>The key agreement value ZZ</returns>
        public DiffieHellmanResult Agreement(KeyPairDH Public, DiffieHellmanResult Carry = null) {
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
        /// Create a new ephemeral private key and use it to perform a key
        /// agreement.
        /// </summary>
        /// <returns>The key agreement parameters, the public key value and the
        /// key agreement.</returns>
        public DiffieHellmanResult Agreement() {
            return PublicKey.Agreement();
            }


        /// <summary>
        /// Perform a Diffie Hellman Key Agreement to a private key
        /// </summary>
        /// <param name="Public">Public key parameters</param>
        /// <param name="Carry">Recryption carry over value, to be combined with the
        /// result of this key agreement.</param>
        /// <returns>The key agreement value ZZ</returns>
        public BigInteger Agreement(KeyPairDH Public, BigInteger Carry) {
            return PrivateKey.Agreement(Public.PublicKey, Carry);
            }

        /// <summary>
        /// Erase the key from the local machine
        /// </summary>
        public override void EraseFromDevice() {
            Platform.EraseFromKeyStore(UDF); 
            }


        /// <summary>
        /// Search all the local machine stores to find a key pair with the specified
        /// fingerprint
        /// </summary>
        /// <param name="UDF">Fingerprint of key</param>
        /// <returns>The key pair found</returns>
        public static KeyPair FindLocalDH(string UDF) {

            return Platform.FindInKeyStore(UDF, CryptoAlgorithmID.DH);
            }


        /// <summary>
        /// Construct an Ephemeral Keypair for this private key and return a new keypair that
        /// has the public parameters of the new ephemeral keypair but acts as a combined keypair.
        /// </summary>
        /// <returns>The hybrid keypair.</returns>
        public KeyPairDH MakeEphemeral () {
            var DiffeHellmanPrivate = new DiffeHellmanPrivate(PrivateKey);
            return new KeyPairDH(DiffeHellmanPrivate);
            }

        /// <summary>
        /// Combine two public keys to obtain a new public key.
        /// </summary>
        /// <param name="Contibution">The public key contribution.</param>
        /// <returns>The new public key.</returns>
        public KeyPairDH Combine (KeyPairDH Contibution) {

            var NewPublic = PublicKey.Combine(Contibution.PublicKey);
            return new KeyPairDH(NewPublic);
            }
        }

    /// <summary>Represents a key agreement result.</summary>
    public abstract partial class KeyAgreementResult : IPKIXAgreement {
        /// <summary>
        /// Return the DER encoding of this structure
        /// </summary>
        /// <returns>The DER encoded value.</returns>
        public abstract byte[] DER ();


        /// <summary>Salt to use in HKDF key derivation. If set will set the 
        /// Key derivation function to HKDF with the specified salt.</summary>
        public abstract int[] OID { get; }

        /// <summary>Key derivation function.</summary>
        public abstract KeyDerive KeyDerive { get; set; }

        /// <summary>
        /// Salt value for use in KDF calculation.
        /// </summary>
        public abstract byte[] Salt { get; set; }
        }


    }
