//   Copyright © 2015 by Comodo Group Inc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Goedel.Cryptography;
using Goedel.Utilities;

namespace Goedel.Cryptography.Windows {


    /// <summary>
    /// Provider for RSA encryption.
    /// </summary>
    public class CryptoProviderExchangeRSA : CryptoProviderExchange {

        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmID CryptoAlgorithmID => CryptoAlgorithmID.RSAExch;


        /// <summary>
        /// Return a CryptoAlgorithm structure with properties describing this provider.
        /// </summary>
        public override CryptoAlgorithm CryptoAlgorithm => CryptoAlgorithmAny; 

        static CryptoAlgorithm CryptoAlgorithmAny = new CryptoAlgorithm(
                    CryptoAlgorithmID.RSAExch, _AlgorithmClass, Factory, 2048);

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


        KeyPairRSA _RSAKeyPair;

        /// <summary>
        /// Return the key as a RSAKeyPair;
        /// </summary>
        public override Goedel.Cryptography.KeyPair KeyPair {
            get => _RSAKeyPair;
            set => _RSAKeyPair = value as KeyPairRSA;
            }

        /// <summary>
        /// The wrapped provider class.
        /// </summary>
        RSA Provider =>_RSAKeyPair.Provider;

        /// <summary>
        /// The default key size
        /// </summary>

        public int KeySize { get; set; }

        /// <summary>
        /// The key fingerprint.
        /// </summary>
        public override string UDF => KeyPair?.UDF;


        /// <summary>
        /// If true (default), OAEP padding will be used. If false, deprecated PKCS#1.5 
        /// padding is used.
        /// </summary>
        protected RSAEncryptionPadding OAEP = RSAEncryptionPadding.OaepSHA1;

        /// <summary>
        /// Return a provider with the specified key size.
        /// </summary>
        /// <param name="KeySize">Key length in bits.</param>
        public CryptoProviderExchangeRSA(int KeySize) => this.KeySize = KeySize;

        /// <summary>
        /// Create an instance of the RSA crypto provider.
        /// </summary>
        /// <param name="RSAKeyPair">RSAKeyPair to use.</param>
        public CryptoProviderExchangeRSA(KeyPairRSA RSAKeyPair) => KeyPair = RSAKeyPair;


        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmID DigestAlgorithm) => new CryptoProviderExchangeRSA(KeySize);

        /// <summary>
        /// Default algorithm key size.
        /// </summary>
        public override int Size => KeySize;


        /// <summary>
        /// Generate a new RSA Key Pair with the Key size specified when the 
        /// instance was created.
        /// </summary>
        /// <param name="KeySecurity">The key security mode</param>
        /// <param name="Size">The key size (2048 or 4096), if zero the default is used.</param>
        public override void Generate(KeySecurity KeySecurity, int Size=0) {
            KeySize = (Size == 0) ? KeySize : Size;
            _RSAKeyPair = new KeyPairRSA(KeySecurity, KeySize);
            }

        /// <summary>
        /// Locate private key in local key store.
        /// </summary>
        /// <param name="UDF">Fingerprint of key</param>
        /// <returns>true if found, otherwise false.</returns>
        public override bool FindLocal(string UDF) {
            _RSAKeyPair = new KeyPairRSA(UDF);
            return _RSAKeyPair.Provider != null;
            }


        /// <summary>
        /// Perform a standalone encryption of a master key.
        /// </summary>
        /// <param name="Key">The key data to encrypt</param>
        /// <param name="Exchange">The result of the encryption operation.</param>
        /// <param name="Ephemeral">Always null, not required for RSA.</param>
        /// <param name="Salt">Optional salt value, ignored as RSA provides plaintext recovery.</param>
        public override void Encrypt (byte[] Key, out byte[] Exchange, out KeyPair Ephemeral,
                byte[] Salt) {
            Exchange = Provider.Encrypt(Key, OAEP);
            Ephemeral = null;
            }


        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="EncryptedKey">The encrypted session</param>
        /// <param name="Ephemeral">Ephemeral key input (unused in RSA)</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <param name="Partial">Partial result for use in recryption (ignored)</param>
        /// <param name="Salt">Unused.</param>
        /// <returns>The decoded data instance</returns>
        public override byte[] Decrypt(
                    byte[] EncryptedKey,
                    KeyPair Ephemeral = null,
                    CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
                    KeyAgreementResult Partial = null,
                    byte[] Salt = null) => Provider.Decrypt(EncryptedKey, OAEP);


        }


    /// <summary>
    /// Deprecated implementation of RSA. For compatibility only.
    /// </summary>
    public class CryptoProviderExchangeRSAPKCS : CryptoProviderExchangeRSA {
        /// <summary>
        /// The CryptoAlgorithmID Identifier.
        /// </summary>
        public override CryptoAlgorithmID CryptoAlgorithmID => CryptoAlgorithmID.RSAExch_P15;


        /// <summary>
        /// RSA provider that defaults to the PKCS#1.5 padding. For compatibility use only.
        /// </summary>
        /// <param name="KeySize">The key size in bits. Note that implementations are only
        /// required to support 2048 and 4096 bits.</param>
        public CryptoProviderExchangeRSAPKCS(int KeySize) : base(KeySize) => OAEP = RSAEncryptionPadding.Pkcs1;

        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmID Ignore) => new CryptoProviderExchangeRSAPKCS(KeySize);
        }


    }