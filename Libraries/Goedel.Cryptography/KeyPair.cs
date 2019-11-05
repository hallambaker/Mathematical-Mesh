using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

namespace Goedel.Cryptography {
    /// <summary>
    /// Base class for all cryptographic key pairs.
    /// </summary>
    public abstract partial class KeyPair : CryptoKey {

        /// <summary>
        /// The key locator, an Internet name in username@domain format. This is used as the basis 
        /// for constructing the Strong Internet Name.
        /// </summary>
        public string Locator { get; set; }

        /// <summary>
        /// The strong internet name for the key.
        /// </summary>
        public string StrongInternetName => Locator + ".mm--" + UDF;

        /// <summary>The supported key uses (e.g. signing, encryption)</summary>
        public abstract KeyUses KeyUses { get; }


        ///<summary>The key security model</summary>
        public virtual KeySecurity KeySecurity { get; protected set; } = KeySecurity.Public;

        /// <summary>
        /// If true, keys will be created in containers prefixed with the name
        /// "test:" to allow them to be easily identified and cleaned up.
        /// </summary>
        public static bool TestMode { get; set; } = false;

        /// <summary>
        /// If true, the key has been written to persistent storage and will be 
        /// locatable by UDF after the application instance has terminated.
        /// </summary>
        public bool IsPersisted { get; set; } = false;

        /// <summary>
        /// If true, the KeySecurity model marks the key to be persisted but the key has not
        /// (yet) been stored.
        /// </summary>
        public bool PersistPending => (KeySecurity.IsPersisted() & !IsPersisted);


        /////<summary>The Key Security level.</summary>
        //public KeyStorage KeySecurity { get; private set; } = KeyStorage.Public;

        /// <summary>
        /// Return the CryptoAlgorithmID that would be used with the specified base parameters.
        /// </summary>
        /// <param name="baseID">The base identifier.</param>
        /// <returns>The computed CryptoAlgorithmID</returns>
        public virtual CryptoAlgorithmID SignatureAlgorithmID(CryptoAlgorithmID baseID) => baseID;

        /// <summary>
        /// Encrypt a bulk key.
        /// </summary>
        /// <returns>The encoder</returns>
        /// <param name="key">The key to encrypt.</param>
        /// <param name="ephemeral">The ephemeral key to use for the exchange (if used)</param>
        /// <param name="exchange">The private key to use for the exchange.</param>
        /// <param name="salt">Optional salt value for use in key derivation.</param>
        public abstract void Encrypt(byte[] key,
            out byte[] exchange, out KeyPair ephemeral, byte[] salt = null);

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
        public abstract byte[] Decrypt(
                    byte[] encryptedKey,
                    KeyPair ephemeral = null,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                    KeyAgreementResult partial = null,
                    byte[] salt = null);

        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="data">The data to sign.</param>
        /// <param name="algorithmID">The algorithm to use.</param>
        /// <param name="context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <returns>The signature data</returns>
        public virtual byte[] Sign(byte[] data,
                CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                byte[] context = null) {

            var hash = algorithmID.Bulk().GetDigest(data);
            return SignHash(hash, algorithmID, context);
            }

        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="data">The data to sign.</param>
        /// <param name="algorithmID">The algorithm to use.</param>
        /// <param name="context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <returns>The signature data</returns>
        public abstract byte[] SignHash(byte[] data,
                CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default,
                byte[] context = null);

        /// <summary>
        /// Verify a signature over the purported data.
        /// </summary>
        /// <param name="signature">The signature blob value.</param>
        /// <param name="algorithmID">The signature and hash algorithm to use.</param>
        /// <param name="context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <param name="data">The data to be digested and verified.</param>
        /// <returns>True if the signature is valid, otherwise false.</returns>
        public virtual bool Verify(byte[] data, byte[] signature,
                CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default, byte[] context = null) {
            var hash = algorithmID.Bulk().GetDigest(data);
            return VerifyHash(hash, signature, algorithmID, context);
            }

        /// <summary>
        /// Verify a signature over the purported data digest.
        /// </summary>
        /// <param name="signature">The signature blob value.</param>
        /// <param name="algorithmID">The signature and hash algorithm to use.</param>
        /// <param name="context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <param name="digest">The digest value to be verified.</param>
        /// <returns>True if the signature is valid, otherwise false.</returns>
        public abstract bool VerifyHash(byte[] digest, byte[] signature,
                CryptoAlgorithmID algorithmID = CryptoAlgorithmID.Default, byte[] context = null);


        /// <summary>
        /// Factory method to generate a keypair of a type specified by <paramref name="algorithmID"/>
        /// and the specified parameters using the default implementation registered with the
        /// KeyPair type.
        /// </summary>
        /// <param name="algorithmID">The type of keypair to create.</param>
        /// <param name="keySize">The key size (ignored if the algorithm supports only one key size)</param>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="keySecurity"/></param>
        /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
        /// <returns>The created key pair</returns>
        public static KeyPair Factory(
                    CryptoAlgorithmID algorithmID,
                    KeySecurity keySecurity,
                    KeyCollection keyCollection = null,
                    int keySize = 0,
                    KeyUses keyUses = KeyUses.Any) {

            KeyPair keyPair = null;

            switch (algorithmID) {
                case CryptoAlgorithmID.RSAExch: {
                    keyPair = KeyPairFactoryRSA(keySize, keySecurity, KeyUses.Encrypt, algorithmID);
                    break;
                    }

                case CryptoAlgorithmID.RSASign: {
                    keyPair = KeyPairFactoryRSA(keySize, keySecurity, KeyUses.Sign, algorithmID);
                    break;
                    }
                case CryptoAlgorithmID.DH: {
                    keyPair = KeyPairFactoryDH(keySize, keySecurity, keyUses, algorithmID);
                    break;
                    }
                case CryptoAlgorithmID.X25519:
                case CryptoAlgorithmID.Ed25519:
                case CryptoAlgorithmID.X448:
                case CryptoAlgorithmID.Ed448: {
                    keyPair = KeyPairFactoryECDH(keySize, keySecurity, keyUses, algorithmID);
                    break;
                    }

                }

            Assert.NotNull(keyPair, NoProviderSpecified.Throw);
            keyPair.KeySecurity = keySecurity;

            if (keySecurity != KeySecurity.Ephemeral) {
                keyCollection = keyCollection ?? KeyCollection.Default;

                keyCollection.Persist(keyPair);
                keyCollection.Add(keyPair);
                }
            return keyPair;

            }



        /// <summary>
        /// Generate a new keypair. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryKeyPairDelegate KeyPairFactoryRSA = KeyPairRSA.Generate;

        /// <summary>
        /// Generate a new keypair. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryKeyPairDelegate KeyPairFactoryDH = KeyPairDH.Generate;

        /// <summary>
        /// Generate a new keypair. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryKeyPairDelegate KeyPairFactoryECDH = KeyPairECDH.KeyPairFactory;






        #region // Abstract Methods

        /// <summary>
        /// The public key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public abstract SubjectPublicKeyInfo KeyInfoData { get; }


        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public abstract SubjectPublicKeyInfo PrivateKeyInfoData { get; }


        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public abstract IPKIXPrivateKey PKIXPrivateKey { get; }


        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public abstract IPKIXPublicKey PKIXPublicKey { get; }


        ///<summary>The raw UDF fingerprint.</summary>
        public override byte[] UDFBytes => udfBytes ?? PKIXPublicKey.UDFBytes(512).CacheValue(out udfBytes);
        byte[] udfBytes = null;



        /// <summary>
        /// Returns the UDF fingerprint of the current key as a string.
        /// </summary>
        public override string UDF => udf ?? Cryptography.UDF.PresentationBase32(UDFBytes).CacheValue(out udf);
        string udf = null;

        ///<summary>The UDF fingerprint of this key pair.</summary>
        public string UDFValue => Cryptography.UDF.OID(this);



        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns></returns>
        public abstract KeyPair KeyPairPublic();

        /// <summary>
        /// If true, the provider only provides the public key values.
        /// </summary>
        public abstract bool PublicOnly { get; }

        /// <summary>
        /// Persist key to the key collection <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="keyCollection"></param>
        public abstract void Persist(KeyCollection keyCollection);



        #endregion

        }




    }
