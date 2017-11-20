using System;
using System.IO;
using System.Numerics;
using Goedel.Utilities;

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
        public override CryptoAlgorithm CryptoAlgorithm  => CryptoAlgorithmAny;
 

        static CryptoAlgorithm CryptoAlgorithmAny = new CryptoAlgorithm(
                    Goedel.Cryptography.CryptoAlgorithmID.DH, 2048, _AlgorithmClass, Factory);

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
            return Catalog.Add(CryptoAlgorithmAny);
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
        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmID BulkAlgorithmID) {
            return new CryptoProviderExchangeDH(KeySize:KeySize);
            }


        /// <summary>
        /// The UDF fingerprint of the key.
        /// </summary>
        /// <remarks>
        /// Keys are stored in  %APPDATA%\AppData\Roaming\CryptoMesh\Keys\DH on windows AND
        /// ~\.Mesh\Keys\DH on U*ix based systems.
        /// </remarks>
        public override string UDF  => DHKeyPair.UDF; 
 

        DHKeyPair DHKeyPair;

        /// <summary>
        /// Return the provider key.
        /// </summary>
        public override KeyPair KeyPair {
            get => DHKeyPair; 
            set {
                var DHKeyPair = value as DHKeyPair;
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
        public CryptoProviderExchangeDH(KeySecurity KeySecurity= KeySecurity.Ephemeral,
                    int  KeySize=2048) {
            Generate(KeySecurity, KeySize);
            }

        // From CryptoProviderAsymmetric

        /// <summary>
        /// Generates a new signing key pair with the default key size.
        /// </summary>
        /// <param name="KeySecurity">Specifies the protection level for the key.</param>
        /// <param name="KeySize">The Key size</param>
        public override void Generate(KeySecurity KeySecurity, int KeySize = 2048) {
            KeySize = KeySize > 0 ? KeySize : 2048;
            DHKeyPair = new DHKeyPair(KeySecurity, KeySize);
            }

        /// <summary>
        /// Locate the private key in the local key store.
        /// </summary>
        /// <param name="UDF">Fingerprint of key to locate.</param>
        /// <returns>True if private key exists.</returns>
        public override bool FindLocal(string UDF) {
            KeyPair = Platform.FindInKeyStore(UDF, CryptoAlgorithmID.DH);
            return KeyPair != null;
            }

        /// <summary>The maximum number of shares into which a key may be split</summary>
        public override int SharesMaximum  => 16;


        /// <summary>
        /// Encrypt the bulk key.
        /// </summary>
        /// <param name="Data">The data to encrypt.</param>
        /// <param name="Algorithm">Composite encryption algorithm.</param>
        /// <param name="Wrap">If true create a new CryptoData instance that
        /// wraps the parameters supplied in Data.</param> 
        /// <returns>The encoder</returns>
        public override CryptoDataExchange Encrypt(CryptoData Data,
            CryptoAlgorithmID Algorithm = CryptoAlgorithmID.Default, bool Wrap = false) {

            var Agreement = DHKeyPair.Agreement();
            var KeyDerive = Agreement.KeyDerive;

            var Exchange = Platform.KeyWrapRFC3394.Wrap(
                        KeyDerive.ClientToServerEncrypt(Data.Key.Length*8), Data.Key);
            
            var Result = new CryptoDataExchange(Algorithm, Data, this) {
                Exchange = Exchange,
                Ephemeral = new DHKeyPair(Agreement.DiffeHellmanPublic)
                };
            return Result;
            }

        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="EncryptedKey">The encrypted session</param>
        /// <param name="Ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <param name="Partial">Partial key agreement value (for recryption)</param>
        /// <returns>The decoded data instance</returns>
        public override byte[] Decrypt(
                    byte[] EncryptedKey,
                    KeyPair Ephemeral,
                    CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
                    KeyAgreementResult Partial = null) {

            var DHPublic = Ephemeral as DHKeyPair;
            var Agreement = DHKeyPair.Agreement(DHPublic, Partial as DiffieHellmanResult);
            var KeyDerive = Agreement.KeyDerive;
            var KeySize = (EncryptedKey.Length * 8) - 64;

            return Platform.KeyWrapRFC3394.Unwrap(
                        KeyDerive.ClientToServerEncrypt(KeySize), EncryptedKey);

            }


        // From CryptoProviderRecryption

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
        public override KeyPair[] GenerateRecryptionSet(int Shares) {
            Assert.True(Shares <= SharesMaximum, RecryptionShareLimitExceeded.Throw);
            return DHKeyPair.GenerateRecryptionSet(Shares);
            }

        // --------------------------------------



        /// <summary>
        /// Perform a recryption operation on the input data. A recryption operation
        /// is any operation that is not a final decryption operation. Multiple 
        /// recryption operations may be performed in series.
        /// </summary>
        /// <param name="CryptoData">The data to recrypt.</param>
        /// <returns>The partially decrypted data</returns>
        public override CryptoDataExchange Recrypt(CryptoDataExchange CryptoData) {
            // NYI: DH Recrypt
            throw new NYI("To do");

            }




        /// <summary>
        /// Perform a recryption operation on the input data. A recryption operation
        /// is any operation that is not a final decryption operation. When more 
        /// than two recryption keys are used, the 
        /// </summary>
        /// <param name="CryptoDatas">The data to recrypt.</param>
        /// <returns>The partially decrypted data</returns>
        public override CryptoDataExchange Recrypt(CryptoDataExchange[] CryptoDatas) {
            // NYI: DH Recrypt
            throw new NYI("To do");
            }



        /// <summary>
        /// If the private key pair is available, generate a new ephemeral keypair of the 
        /// same size and return a crypto provider whose public key is the public key
        /// of the ephemeral and whose private key is the combination of the private
        /// key of the ephemeral and the base instance.
        /// </summary>
        /// <returns>The new provider.</returns>
        public override CryptoProviderRecryption MakeEphemeral () {

            var NewKeypair = DHKeyPair.MakeEphemeral();
            return new CryptoProviderExchangeDH(NewKeypair);

            }

        /// <summary>
        /// Perform a recryption operation on the input data. A recryption operation
        /// is any operation that is not a final decryption operation. When more 
        /// than two recryption keys are used, the 
        /// </summary>
        /// <param name="Public">The data to recrypt.</param>
        /// <returns>The partially decrypted data</returns>
        public override KeyAgreementResult Exchange (KeyPair Public) {

            return DHKeyPair.Agreement(Public);
            }

        }
    }
