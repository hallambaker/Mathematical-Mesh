using Goedel.Cryptography.PKIX;

using System;

namespace Goedel.Cryptography {
    /// <summary>
    /// Wrapper around a partial key pair.
    /// </summary>
    public abstract class KeyPairPartial : KeyPairAdvanced {

        ///<summary>The partial private key</summary>
        public KeyPairAdvanced KeyPartial { get; set; }

        ///<summary>The group key of which the partial is a contribution.</summary>
        public KeyPairAdvanced KeyGroup { get; set; }

        #region //Properties
        ///<summary>The implementation public key value</summary>
        public override IKeyAdvancedPublic IKeyAdvancedPublic => KeyGroup.IKeyAdvancedPublic;

        ///<summary>The implementation private key value (if exportable)</summary>
        public override IKeyAdvancedPrivate IKeyAdvancedPrivate => KeyPartial.IKeyAdvancedPrivate;

        /// <summary>The supported key uses (e.g. signing, encryption)</summary>
        public override KeyUses KeyUses => KeyPartial.KeyUses;

        /// <summary>
        /// The public key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public override SubjectPublicKeyInfo KeyInfoData => KeyGroup.KeyInfoData;

        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public override SubjectPublicKeyInfo PrivateKeyInfoData => KeyPartial.PrivateKeyInfoData;

        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public override IPKIXPrivateKey PKIXPrivateKey => KeyPartial.PKIXPrivateKey;

        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public override IPKIXPublicKey PKIXPublicKey => KeyGroup.PKIXPublicKey;

        ///<summary>If true, the key only has access to public key values. This is always true for 
        ///a partial key.</summary>
        public override bool PublicOnly => false;

        #endregion

        #region // Constructors

        /// <summary>
        /// Constructor, create a partial key for the (at least public) key <paramref name="keyGroup"/>
        /// using the private key data <paramref name="keyPartial"/>.
        /// </summary>
        /// <param name="keyGroup">The composite key.</param>
        /// <param name="keyPartial">The partial private key.</param>
        public KeyPairPartial(KeyPairAdvanced keyGroup, KeyPairAdvanced keyPartial) {
            KeyPartial = keyPartial;
            KeyGroup = keyGroup;
            }
        #endregion

        #region // Changed methods

        //public override KeyPairAdvanced Cogenerate(out KeyPairAdvanced privateKey) => KeyPairPart.;




        /// <summary>
        /// Encrypt a bulk key.
        /// </summary>
        /// <returns>The encoder</returns>
        /// <param name="key">The key to encrypt.</param>
        /// <param name="ephemeral">The ephemeral key to use for the exchange (if used)</param>
        /// <param name="exchange">The private key to use for the exchange.</param>
        /// <param name="salt">Optional salt value for use in key derivation.</param>
        public override void Encrypt(
                    byte[] key,
                    out byte[] exchange,
                    out KeyPair ephemeral,
                    byte[] salt = null) => KeyGroup.Encrypt(key, out exchange, out ephemeral, salt);

        #endregion

        #region // Boilerplate methods




        /// <summary>
        /// Factory method to produce a key pair from key parameters.
        /// </summary>
        /// <param name="privateKey">The private key</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPrivate privateKey) => throw new NotImplementedException();

        /// <summary>
        /// Factory method to produce a key pair from implementation public key parameters
        /// </summary>
        /// <param name="publicKey">The public key</param>
        /// <returns>The key pair created.</returns>
        public override KeyPairAdvanced KeyPair(IKeyAdvancedPublic publicKey) => throw new NotImplementedException();

        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns>The new keypair that contains only the public values.</returns>
        public override KeyPair KeyPairPublic() => KeyGroup.KeyPairPublic();

        /// <summary>
        /// Persist the key to a key collection.
        /// </summary>
        /// <param name="keyCollection"></param>
        public override void Persist(KeyCollection keyCollection) => throw new NotImplementedException();


        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="digest">The digest to sign.</param>
        /// <param name="algorithmID">The algorithm to use.</param>
        /// <param name="context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <returns>The signature data</returns>
        public override byte[] SignHash(
                    byte[] digest,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                    byte[] context = null) => throw new NotImplementedException();

        /// <summary>
        /// Verify a signature over the purported data digest. Only valid if the underlying
        /// key supports threshold signatures.
        /// </summary>
        /// <param name="signature">The signature blob value.</param>
        /// <param name="algorithmID">The signature and hash algorithm to use.</param>
        /// <param name="context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <param name="digest">The digest value to be verified.</param>
        /// <returns>True if the signature is valid, otherwise false.</returns>

        public override bool VerifyHash(
                    byte[] digest,
                    byte[] signature,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                    byte[] context = null) => throw new NotImplementedException();

        #endregion

        }
    }
