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

        /// <summary>
        /// Return the CryptoAlgorithmID that would be used with the specified base parameters.
        /// </summary>
        /// <param name="Base">The base identifier.</param>
        /// <returns>The computed CryptoAlgorithmID</returns>
        public virtual CryptoAlgorithmID SignatureAlgorithmID(CryptoAlgorithmID Base) => Base;

        /// <summary>
        /// Encrypt a bulk key.
        /// </summary>
        /// <returns>The encoder</returns>
        /// <param name="Key">The key to encrypt.</param>
        /// <param name="Ephemeral">The ephemeral key to use for the exchange (if used)</param>
        /// <param name="Exchange">The private key to use for the exchange.</param>
        /// <param name="Salt">Optional salt value for use in key derivation.</param>
        public abstract void Encrypt(byte[] Key,
            out byte[] Exchange, out KeyPair Ephemeral, byte[] Salt = null);

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
        public abstract byte[] Decrypt(
                    byte[] EncryptedKey,
                    KeyPair Ephemeral = null,
                    CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
                    KeyAgreementResult Partial = null,
                    byte[] Salt = null);

        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="Data">The data to sign.</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <param name="Context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <returns>The signature data</returns>
        public virtual byte[] Sign(byte[] Data,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
                byte[] Context = null) {

            var hash= AlgorithmID.Bulk().GetDigest(Data);
            return SignHash(hash, AlgorithmID, Context);

            }

        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="Data">The data to sign.</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <param name="Context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <returns>The signature data</returns>
        public abstract byte[] SignHash(byte[] Data,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
                byte[] Context = null);





        /// <summary>
        /// Verify a signature over the purported data.
        /// </summary>
        /// <param name="Signature">The signature blob value.</param>
        /// <param name="AlgorithmID">The signature and hash algorithm to use.</param>
        /// <param name="Context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <param name="Data">The data to be digested and verified.</param>
        /// <returns>True if the signature is valid, otherwise false.</returns>
        public virtual bool Verify(byte[] Data, byte[] Signature,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default, byte[] Context = null) {
            var hash = AlgorithmID.Bulk().GetDigest(Data);
            return VerifyHash(hash, Signature, AlgorithmID, Context);
            }

        /// <summary>
        /// Verify a signature over the purported data digest.
        /// </summary>
        /// <param name="Signature">The signature blob value.</param>
        /// <param name="AlgorithmID">The signature and hash algorithm to use.</param>
        /// <param name="Context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <param name="Digest">The digest value to be verified.</param>
        /// <returns>True if the signature is valid, otherwise false.</returns>
        public abstract bool VerifyHash(byte[] Digest, byte[] Signature,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default, byte[] Context = null);

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
        /// <param name="KeyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="KeySecurity"/></param>
        /// <returns>The created key pair</returns>
        public static KeyPair Factory(
                    CryptoAlgorithmID algorithmID,
                    KeySecurity KeySecurity,
                    KeyCollection KeyCollection=null,
                    int KeySize = 0,
                    bool Sign = true,
                    bool Exchange = true) {

            switch (algorithmID) {
                case CryptoAlgorithmID.RSAExch: {
                    return KeyPairFactoryRSA(KeySecurity, KeyCollection, KeySize, false, true, algorithmID);

                    }

                case CryptoAlgorithmID.RSASign: {
                    return KeyPairFactoryRSA(KeySecurity, KeyCollection, KeySize, true, false, algorithmID);

                    }
                case CryptoAlgorithmID.DH: {
                    return KeyPairFactoryDH(KeySecurity, KeyCollection, KeySize, Sign, Exchange, algorithmID);

                    }
                case CryptoAlgorithmID.Ed25519: {
                    return KeyPairFactoryECDH(KeySecurity, KeyCollection, 255, Sign, Exchange, algorithmID);

                    }
                case CryptoAlgorithmID.Ed448: {
                    return KeyPairFactoryECDH(KeySecurity, KeyCollection, 448, Sign, Exchange, algorithmID);

                    }

                }
            throw new NoProviderSpecified();

            }



        /// <summary>
        /// Generate a new keypair. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryKeyPairDelegate KeyPairFactoryRSA = null;

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
