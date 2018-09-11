using System;
using System.IO;
using System.Numerics;
using Goedel.Utilities;
using Goedel.Cryptography.Algorithms;

namespace Goedel.Cryptography {

    /// <summary>
    /// The Diffie Hellman Recryption provider
    /// </summary>
    public class CryptoProviderExchangeDH : CryptoProviderRecryption {

        static CryptoAlgorithmID _CryptoAlgorithmID =
                    Goedel.Cryptography.CryptoAlgorithmID.DH;

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmID CryptoAlgorithmID => _CryptoAlgorithmID; 
 

        /// <summary>
        /// Return a CryptoAlgorithm structure with properties describing this provider.
        /// </summary>
        public override CryptoAlgorithm CryptoAlgorithm  => CryptoAlgorithmThis;

        static CryptoAlgorithm CryptoAlgorithmThis = new CryptoAlgorithm(
                    Goedel.Cryptography.CryptoAlgorithmID.DH, _AlgorithmClass,
                    Factory, 2048);

        //static KeyPair KeyPairFactory(
        //        KeySecurity KeySecurity = KeySecurity.Exportable, int KeySize = 0,
        //        bool Signature = true, bool Exchange = true,
        //        CryptoAlgorithmID CryptoAlgorithmID = CryptoAlgorithmID.NULL) =>
        //            new KeyPairDH(KeySecurity, KeySize);


        /// <summary>
        /// Register this provider in the specified crypto catalog. A provider may 
        /// register itself multiple times to describe different configurations that 
        /// are supported.
        /// </summary>
        /// <param name="Catalog">The catalog to register the provider to, if
        /// null, the default catalog is used.</param>
        /// <returns>Description of the principal algorithm registration.</returns>
        public static CryptoAlgorithm Register(CryptoCatalog Catalog = null) {
            Catalog = Catalog ?? CryptoCatalog.Default;
            return Catalog.Add(CryptoAlgorithmThis);
            }




        /// <summary>
        /// Default algorithm key or output size.
        /// </summary>
        public override int Size => 2048;

        /// <summary>
        /// Delegate to create a cryptographic provider with optional key size and/or
        /// bulk algorithm variants where needed.
        /// </summary>
        /// <param name="KeySize">Key size parameter (if needed).</param>
        /// <param name="BulkAlgorithmID">Algorithm identifier of bulk algorithm (if needed).</param>
        /// <returns>The cryptographic provider created.</returns>
        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmID BulkAlgorithmID) => new CryptoProviderExchangeDH(KeySize: KeySize);


        /// <summary>
        /// The UDF fingerprint of the key.
        /// </summary>
        /// <remarks>
        /// Keys are stored in  %APPDATA%\AppData\Roaming\CryptoMesh\Keys\DH on windows AND
        /// ~\.Mesh\Keys\DH on U*ix based systems.
        /// </remarks>
        public override string UDF  => DHKeyPair.UDF; 
 

        KeyPairDH DHKeyPair;

        /// <summary>
        /// Return the provider key.
        /// </summary>
        public override KeyPair KeyPair {
            get => DHKeyPair; 
            set {
                var DHKeyPair = value as KeyPairDH;
                Assert.NotNull(DHKeyPair, InvalidKeyPairType.Throw, "DH keypair expected");
                this.DHKeyPair = DHKeyPair;
                }
            }

        /// <summary>
        /// Construct a provider for a Keypair
        /// </summary>
        /// <param name="KeyPair">Keypair to construct from</param>
        /// <param name="Bulk">Default encryption algorithm.</param>
        public CryptoProviderExchangeDH(KeyPair KeyPair, 
                    CryptoAlgorithmID Bulk=CryptoAlgorithmID.Default) {
            this.KeyPair = KeyPair;
            this.BulkAlgorithmDefault = Bulk;
            }

        /// <summary>
        /// Construct a provider for a Keypair
        /// </summary>
        /// <param name="KeySecurity">Specifies the protection level for the key.</param>
        /// <param name="KeySize">The Key size</param>
        public CryptoProviderExchangeDH(KeySecurity KeySecurity = KeySecurity.Ephemeral,
                    int KeySize = 2048) => Generate(KeySecurity, KeySize);

        // From CryptoProviderAsymmetric

        /// <summary>
        /// Generates a new signing key pair with the default key size.
        /// </summary>
        /// <param name="KeySecurity">Specifies the protection level for the key.</param>
        /// <param name="KeySize">The Key size</param>
        public override void Generate(KeySecurity KeySecurity, int KeySize = 2048) {
            KeySize = KeySize > 0 ? KeySize : 2048;
            DHKeyPair = new KeyPairDH(KeySecurity, KeySize);
            }


        /// <summary>
        /// Label used to specify a master key derrivation.
        /// </summary>
        public static readonly byte[] MasterKeyInfo = "master".ToUTF8();

        /// <summary>
        /// Encrypt the bulk key.
        /// </summary>
        /// <returns>The encoder</returns>
        public override void Encrypt(byte[] Key,
            out byte[] Exchange, out KeyPair Ephemeral, byte[] Salt = null) =>
                    DHKeyPair.Encrypt(Key, out Exchange, out Ephemeral, Salt ?? MasterKeyInfo);


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
                    byte[] Salt = null) => 
                        DHKeyPair.Decrypt(EncryptedKey, Ephemeral, AlgorithmID, Partial, Salt ?? MasterKeyInfo);
         }
    }
