//Sample license text.
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Goedel.LibCrypto {

    /// <summary>
    /// Base provider for public key encryption and symmetric key wrap.
    /// 
    /// NB these classes do not support bulk encryption.
    /// </summary>
    public abstract class CryptoProviderExchange : CryptoProviderAsymmetric {
        /// <summary>
        /// The type of algorithm
        /// </summary>
        public override CryptoAlgorithmClass AlgorithmClass { get { return CryptoAlgorithmClass.Exchange; } }


        /// <summary>
        /// Encrypt key data.
        /// </summary>
        /// <param name="Input">The key data to encrypt.</param>
        /// <returns>Encrypted data</returns>
        public abstract byte[] Encrypt(byte[] Input);

        /// <summary>
        /// Encrypt key data.
        /// </summary>
        /// <param name="Input">The key data to encrypt.</param>
        /// <returns>Encrypted data</returns>
        public CryptoData Encrypt(CryptoData Input) {
            var Result = Encrypt(Input.Key);
            return new CryptoData(CryptoAlgorithmID, OID, null, Result, null, null);
            }


        /// <summary>
        /// JSON Key use.
        /// </summary>
        public override string JSONKeyUse { get { return "enc"; } }


        /// <summary>
        /// Decrypt data. Note that this is only possibly when the corresponding private
        /// key is available on the local machine.
        /// </summary>
        /// <param name="Input">The data to decrypt.</param>
        /// <returns>Decrypted data.</returns>
        public abstract byte[] Decrypt(byte[] Input);


        /// <summary>
        /// Decrypt data. Note that this is only possibly when the corresponding private
        /// key is available on the local machine.
        /// </summary>
        /// <param name="Input">The data to decrypt.</param>
        /// <returns>Decrypted data.</returns>
        public CryptoData Decrypt(CryptoData Input) {
            var Result = Decrypt(Input.Data);
            return new CryptoData(CryptoAlgorithmID, OID, null, null, Result, null);
            }



        }

    /// <summary>
    /// Provider for RSA encryption.
    /// </summary>
    public class CryptoProviderExchangeRSA : CryptoProviderExchange {


        RSAKeyPair _RSAKeyPair;

        /// <summary>
        /// Return the key as a RSAKeyPair;
        /// </summary>
        public override KeyPair KeyPair {
            get { return _RSAKeyPair; }
            set { _RSAKeyPair = value as RSAKeyPair; }
            }

        /// <summary>
        /// The wrapped provider class.
        /// </summary>
        RSACryptoServiceProvider Provider {
            get { return _RSAKeyPair.Provider; }
            }

        /// <summary>
        /// The default key size
        /// </summary>
        
        public int KeySize {
            get { return _KeySize; }
            set { _KeySize = value; }
            }
        private int _KeySize;

        /// <summary>
        /// The key fingerprint.
        /// </summary>
        public override string UDF {
            get {
                if (KeyPair == null) return null;
                return KeyPair.UDF;
                }
            }

        /// <summary>
        /// If true (default), OAEP padding will be used. If false, deprecated PKCS#1.5 
        /// padding is used.
        /// </summary>
        protected bool OAEP;

        /// <summary>
        /// Return a provider with the specified key size.
        /// </summary>
        /// <param name="KeySize">Key length in bits.</param>
        public CryptoProviderExchangeRSA(int KeySize) {
            this.KeySize = KeySize;
            this.OAEP = true;
            }

        /// <summary>
        /// Create an instance of the RSA crypto provider.
        /// </summary>
        /// <param name="RSAKeyPair">RSAKeyPair to use.</param>
        public CryptoProviderExchangeRSA(RSAKeyPair RSAKeyPair) {
            this.KeyPair = RSAKeyPair;
            this.OAEP = true;
            }

        /// <summary>
        /// Returns the default crypto provider.
        /// </summary>
        public override GetCryptoProvider GetCryptoProvider {
            get {
                return Factory;
                }
            }

        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmID DigestAlgorithm) {
            return new CryptoProviderExchangeRSA(KeySize);
            }

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmID CryptoAlgorithmID {
            get {
                if (KeySize == 2048) {
                    return CryptoAlgorithmID.RSAExch2048;
                    }
                return CryptoAlgorithmID.RSAExch4096;
                }
            }
        /// <summary>
        /// .NET Framework name
        /// </summary>
        public override string Name {
            get {
                return "RSA";
                }
            }
        /// <summary>
        /// JSON Algorithm Name
        /// </summary>
        public override string JSONName {
            get {
                return "RSAES"; // NYI placeholder for now
                }
            }
        /// <summary>
        /// Default algorithm key size.
        /// </summary>
        public override int Size {
            get {
                return KeySize;
                }
            }

        /// <summary>
        /// Generate a new RSA Key Pair with the Key size specified when the 
        /// instance was created.
        /// </summary>
        public override void Generate(KeySecurity KeySecurity) {
        _RSAKeyPair = new RSAKeyPair(KeySize);
        _RSAKeyPair.Persist(KeySecurity);
            }

        /// <summary>
        /// Locate private key in local key store.
        /// </summary>
        /// <param name="UDF">Fingerprint of key</param>
        /// <returns>true if found, otherwise false.</returns>
        public override bool FindLocal(string UDF) {
            _RSAKeyPair = new RSAKeyPair(UDF);
            return _RSAKeyPair.Provider != null;
            }

        /// <summary>
        /// Encrypt data block. Block MUST be smaller than the key length or
        /// an exception will be thrown.
        /// </summary>
        /// <param name="Input">Data to encrypt.</param>
        /// <returns>Encrypted data.</returns>
        public override byte[] Encrypt(byte[] Input) {
            return Provider.Encrypt(Input, OAEP);
            }

        /// <summary>
        /// Decrypt data block.
        /// </summary>
        /// <param name="Input">Data to decrypt.</param>
        /// <returns>Decrypted data.</returns>
        public override byte[] Decrypt(byte[] Input) {
            return Provider.Decrypt(Input, OAEP);
            }



        /// <summary>
        /// JSON Key type.
        /// </summary>
        public override string JSONKeyType { get { return "rsa"; } }


        }


    /// <summary>
    /// Deprecated implementation of RSA. For compatibility only.
    /// </summary>
    public class CryptoProviderExchangeRSAPKCS : CryptoProviderExchangeRSA {
        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmID CryptoAlgorithmID {
            get {
                if (KeySize == 2048) {
                    return CryptoAlgorithmID.RSAExch2048_P15;
                    }
                return CryptoAlgorithmID.RSAExch4096_P15;
                }
            }


        /// <summary>
        /// RSA provider that defaults to the PKCS#1.5 padding. For compatibility use only.
        /// </summary>
        /// <param name="KeySize"></param>
        public CryptoProviderExchangeRSAPKCS(int KeySize) : base(KeySize) {
            this.OAEP = false;
            }

        /// <summary>
        /// Returns a delegate that creates an instance of this class.
        /// </summary>
        public override GetCryptoProvider GetCryptoProvider {
            get {
                return Factory;
                }
            }

        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmID Ignore) {
            return new CryptoProviderExchangeRSAPKCS(KeySize);
            }
        }


    }