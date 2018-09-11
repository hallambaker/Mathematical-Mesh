using System.Collections.Generic;
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

        /// <summary>The key pair supports signing and/or verification operations</summary>
        public abstract bool Signature { get; }

        /// <summary>The key pair supports key exchange operations</summary>
        public abstract bool Exchange { get; }

        /// <summary>
        /// If true, keys will be created in containers prefixed with the name
        /// "test:" to allow them to be easily identified and cleaned up.
        /// </summary>
        public static bool TestMode { get; set; } = false;

        #region // Provider methods - TO BE DELETED

        /// <summary>
        /// Returns a signature provider for the key (if the private portion is available).
        /// </summary>
        /// <param name="BulkAlgorithm">The digest algorithm to use</param>
        /// <returns>The signature provider.</returns>
        public abstract CryptoProviderSignature SignatureProvider(
                    CryptoAlgorithmID BulkAlgorithm = CryptoAlgorithmID.Default);

        /// <summary>
        /// Returns an encryption provider for the key (if the public portion is available)
        /// </summary>
        /// <param name="BulkAlgorithm">The encryption algorithm to use</param>
        /// <returns>The encryption provider.</returns>
        public abstract CryptoProviderExchange ExchangeProvider(
                    CryptoAlgorithmID BulkAlgorithm = CryptoAlgorithmID.Default);

        CryptoProviderExchange CachedExchangeProvider = null;
        CryptoProviderSignature CachedSignatureProvider = null;

        #endregion


        /// <summary>
        /// Return the CryptoAlgorithmID that would be used with the specified base parameters.
        /// </summary>
        /// <param name="Base">The base identifier.</param>
        /// <returns>The computed CryptoAlgorithmID</returns>
        public virtual CryptoAlgorithmID SignatureAlgorithmID(CryptoAlgorithmID Base) => Base;



        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="Bulk">The provider to wrap.</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <returns>The encryption provider</returns>
        public virtual CryptoDataExchange EncryptKey(CryptoData Bulk,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default) {

            CachedExchangeProvider = CachedExchangeProvider ?? ExchangeProvider(AlgorithmID);
            var Exchange = CachedExchangeProvider.Encrypt(Bulk, Wrap: true);
            Bulk.Exchanges = Bulk.Exchanges ?? new List<CryptoDataExchange>();
            Bulk.Exchanges.Add(Exchange);

            return Exchange;
            }

        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="Data">The data to sign.</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <returns>The signature data</returns>
        public virtual CryptoDataSignature Sign(byte[] Data,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default) {

            CachedSignatureProvider = CachedSignatureProvider ??
                        SignatureProvider(AlgorithmID);

            return CachedSignatureProvider.Sign(Data);
            }

        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="Data">The data to sign.</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <returns>The signature data</returns>
        public virtual byte[] SignHash(byte[] Data,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default) {

            CachedSignatureProvider = CachedSignatureProvider ??
                        SignatureProvider(AlgorithmID);

            return CachedSignatureProvider.SignHash(Data, AlgorithmID);
            }


        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="EncryptedKey">The encrypted session</param>
        /// <param name="Ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <param name="Partial">Partial key agreement carry in (for recryption)</param>
        /// <returns>The decoded data instance</returns>
        public virtual byte[] Decrypt(
                    byte[] EncryptedKey,
                    KeyPair Ephemeral = null,
                    CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
                    KeyAgreementResult Partial = null) {

            CachedExchangeProvider = CachedExchangeProvider ??
                ExchangeProvider(AlgorithmID);

            return CachedExchangeProvider.Decrypt(EncryptedKey, Ephemeral,
                CryptoAlgorithmID, Partial: Partial);
            }

        /// <summary>
        /// Verify a precomputed digest
        /// </summary>
        /// <param name="Bulk">The provider to wrap.</param>
        /// <param name="Signature">The signature blob value.</param>
        /// <param name="AlgorithmID">The algorithm used.</param>
        /// <returns>True if the digest is cvalid, otherwise false.</returns>
        public virtual bool Verify(CryptoData Bulk, byte[] Signature,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default) {
            CachedSignatureProvider = CachedSignatureProvider ??
                        SignatureProvider(AlgorithmID);

            return CachedSignatureProvider.Verify(Bulk, Signature);
            }

        /// <summary>
        /// Search for the local key with the specified UDF fingerprint.
        /// </summary>
        public abstract void GetPrivate();


        /// <summary>
        /// Search all the local machine stores to find a key pair with the specified
        /// fingerprint
        /// </summary>
        /// <param name="UDF">Fingerprint of key</param>
        /// <returns>The key pair found</returns>
        public static KeyPair FindLocal(string UDF) {
            foreach (var Delegate in Platform.FindLocalDelegates) {
                var KeyPair = Delegate(UDF);
                if (KeyPair != null) {
                    return KeyPair;
                    }
                }
            return null;
            }

        /// <summary>
        /// Factory method to generate a keypair of a type specified by <paramref name="algorithmID"/>
        /// and the specified parameters using the default implementation registered with the
        /// KeyPair type.
        /// </summary>
        /// <param name="algorithmID">The type of keypair to create.</param>
        /// <param name="KeySecurity">The key security model</param>
        /// <param name="KeySize">The key size (ignored if the algorithm supports only one key size)</param>
        /// <param name="Sign">If true, the key may be used for singature operations</param>
        /// <param name="Exchange">If true, the key may be used for exchange operations</param>
        /// <returns>The created key pair</returns>
        public static KeyPair Factory(
                    CryptoAlgorithmID algorithmID,
                    KeySecurity KeySecurity,
                    int KeySize = 0,
                    bool Sign = true,
                    bool Exchange = true) {

            switch (algorithmID) {
                case CryptoAlgorithmID.RSAExch: {
                    return KeyPairFactoryRSA(KeySecurity, KeySize, false, true, algorithmID);

                    }

                case CryptoAlgorithmID.RSASign: {
                    return KeyPairFactoryRSA(KeySecurity, KeySize, true, false, algorithmID);

                    }
                case CryptoAlgorithmID.DH: {
                    return KeyPairFactoryDH(KeySecurity, KeySize, Sign, Exchange, algorithmID);

                    }
                case CryptoAlgorithmID.Ed25519: {
                    return KeyPairFactoryECDH(KeySecurity, 255, Sign, Exchange, algorithmID);

                    }
                case CryptoAlgorithmID.Ed448: {
                    return KeyPairFactoryECDH(KeySecurity, 448, Sign, Exchange, algorithmID);

                    }

                }
            throw new NoProviderSpecified();

            }



        /// <summary>
        /// Generate a new keypair. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryKeyPairDelegate KeyPairFactoryRSA = KeyPairBaseRSA.GenerateKeyPair;

        /// <summary>
        /// Generate a new keypair. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryKeyPairDelegate KeyPairFactoryDH = KeyPairDH.GenerateKeyPair;

        /// <summary>
        /// Generate a new keypair. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryKeyPairDelegate KeyPairFactoryECDH = KeyPairECDH.KeyPairFactory;






        #region // Abstract Methods


        /// <summary>
        /// Erase the key from the local machine.
        /// </summary>
        public abstract void EraseFromDevice();

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


        string _UDF = null;
        /// <summary>
        /// Returns the UDF fingerprint of the current key as a string.
        /// </summary>
        public override string UDF => _UDF ?? PKIXPublicKey.UDF().CacheValue(out _UDF);

        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns></returns>
        public abstract KeyPair KeyPairPublic();

        /// <summary>
        /// If true, the provider only provides the public key values.
        /// </summary>
        public abstract bool PublicOnly { get; }

        #endregion

        }




    }
