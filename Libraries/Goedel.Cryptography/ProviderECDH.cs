//using System;
//using System.IO;
//using System.Numerics;
//using Goedel.Utilities;
//using Goedel.Cryptography.Algorithms;

//namespace Goedel.Cryptography {

//    /// <summary>
//    /// The Diffie Hellman Recryption provider
//    /// </summary>
//    public class CryptoProviderExchangeECDH : CryptoProviderRecryption {

//        /// <summary>
//        /// The CryptoAlgorithmID Identifier.
//        /// </summary>
//        public override CryptoAlgorithmID CryptoAlgorithmID => KeyPairECDH.CryptoAlgorithmID; 


//        /// <summary>
//        /// Return a CryptoAlgorithm structure with properties describing this provider.
//        /// </summary>
//        public override CryptoAlgorithm CryptoAlgorithm {
//            get {
//                switch (KeyPairECDH) {
//                    case KeyPairEd25519 x: return CryptoAlgorithmEd25519;
//                    case KeyPairEd448 x: return CryptoAlgorithmEd448;
//                    }
//                throw new NYI();
//                }
//            }

//        static CryptoAlgorithm CryptoAlgorithmEd448 = new CryptoAlgorithm(
//                    Goedel.Cryptography.CryptoAlgorithmID.DH, _AlgorithmClass,
//                    Factory, 2048);

//        static CryptoAlgorithm CryptoAlgorithmEd25519 = new CryptoAlgorithm(
//            Goedel.Cryptography.CryptoAlgorithmID.DH, _AlgorithmClass,
//            Factory, 2048);


//        /// <summary>
//        /// Key size in bits
//        /// </summary>
//        public override int Size => 0;

//        /// <summary>
//        /// Register this provider in the specified crypto catalog. A provider may 
//        /// register itself multiple times to describe different configurations that 
//        /// are supported.
//        /// </summary>
//        /// <param name="Catalog">The catalog to register the provider to, if
//        /// null, the default catalog is used.</param>
//        /// <returns>Description of the principal algorithm registration.</returns>
//        public static CryptoAlgorithm Register(CryptoCatalog Catalog = null) {
//            Catalog = Catalog ?? CryptoCatalog.Default;
//            Catalog.Add(CryptoAlgorithmEd25519);
//            return Catalog.Add(CryptoAlgorithmEd448);
//            }

//        KeyPairECDH KeyPairECDH;

//        /// <summary>
//        /// Delegate to create a cryptographic provider with optional key size and/or
//        /// bulk algorithm variants where needed.
//        /// </summary>
//        /// <param name="KeySize">Key size parameter (if needed).</param>
//        /// <param name="BulkAlgorithmID">Algorithm identifier of bulk algorithm (if needed).</param>
//        /// <returns>The cryptographic provider created.</returns>
//        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmID BulkAlgorithmID) => new CryptoProviderExchangeDH(KeySize: KeySize);


//        /// <summary>
//        /// The UDF fingerprint of the key.
//        /// </summary>
//        /// <remarks>
//        /// Keys are stored in  %APPDATA%\AppData\Roaming\CryptoMesh\Keys\DH on windows AND
//        /// ~\.Mesh\Keys\DH on U*ix based systems.
//        /// </remarks>
//        public override string UDF  => KeyPairECDH.UDF; 


//        /// <summary>
//        /// Return the provider key.
//        /// </summary>
//        public override KeyPair KeyPair {
//            get => KeyPairECDH; 
//            set {
//                var KeyPairECDH = value as KeyPairECDH;
//                Assert.NotNull(KeyPairECDH, InvalidKeyPairType.Throw, "DH keypair expected");
//                this.KeyPairECDH = KeyPairECDH;
//                }
//            }

//        /// <summary>
//        /// Construct a provider for a Keypair
//        /// </summary>
//        /// <param name="KeyPair">Keypair to construct from</param>
//        /// <param name="Bulk">Default encryption algorithm.</param>
//        public CryptoProviderExchangeECDH(KeyPair KeyPair, 
//                    CryptoAlgorithmID Bulk=CryptoAlgorithmID.Default) {
//            this.KeyPair = KeyPair;
//            this.BulkAlgorithmDefault = Bulk;
//            }

//        /// <summary>
//        /// Construct a provider for a Keypair
//        /// </summary>
//        /// <param name="KeySecurity">Specifies the protection level for the key.</param>
//        /// <param name="KeySize">The Key size</param>
//        public CryptoProviderExchangeECDH(KeySecurity KeySecurity = KeySecurity.Ephemeral,
//                    int KeySize = 2048) => Generate(KeySecurity, KeySize);

//        // From CryptoProviderAsymmetric

//        /// <summary>
//        /// Generates a new key pair with the default key size.
//        /// </summary>
//        /// <param name="KeySecurity">Specifies the protection level for the key.</param>
//        /// <param name="KeySize">The Key size</param>
//        public override void Generate(KeySecurity KeySecurity, int KeySize = 2048) =>
//            KeyPairECDH.KeyPairFactory(KeySecurity, null, KeySize, Signature: false, Exchange: true);

//        /// <summary>
//        /// Label used to specify a master key derrivation.
//        /// </summary>
//        public static readonly byte[] MasterKeyInfo = "master".ToUTF8();


//        /// <summary>
//        /// Encrypt the bulk key.
//        /// </summary>
//        /// <returns>The encoder</returns>
//        public override void Encrypt(byte[] Key,
//            out byte[] Exchange, out KeyPair Ephemeral, byte[] Salt = null) =>
//                    KeyPairECDH.Encrypt(Key, out Exchange, out Ephemeral, Salt ?? MasterKeyInfo);


//        /// <summary>
//        /// Perform a key exchange to decrypt a bulk or wrapped key under this one.
//        /// </summary>
//        /// <param name="EncryptedKey">The encrypted session key</param>
//        /// <param name="Ephemeral">Ephemeral key input (required for DH)</param>
//        /// <param name="AlgorithmID">The algorithm to use.</param>
//        /// <param name="Partial">Partial key agreement value (for recryption)</param>
//        /// <param name="Salt">Optional salt value for use in key derivation. If specified
//        /// must match the salt used to encrypt.</param>
//        /// <returns>The decoded data instance</returns>
//        public override byte[] Decrypt(
//                    byte[] EncryptedKey,
//                    KeyPair Ephemeral,
//                    CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
//                    KeyAgreementResult Partial = null, 
//                    byte[] Salt = null) {

//            var DHPublic = Ephemeral as KeyPairECDH;
//            Assert.NotNull(DHPublic, KeyTypeMismatch.Throw);

//            var Agreement = KeyPairECDH.Agreement(DHPublic, Partial as DiffieHellmanResult);
//            return Agreement.Decrypt(EncryptedKey, Ephemeral, Partial, Salt ?? MasterKeyInfo);

//            }

//        }
//    }
