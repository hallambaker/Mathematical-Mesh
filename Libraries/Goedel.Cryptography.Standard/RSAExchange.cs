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

namespace Goedel.Cryptography.Framework {


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
                    CryptoAlgorithmID.RSAExch, 2048, _AlgorithmClass, Factory);

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


        RSAKeyPair _RSAKeyPair;

        /// <summary>
        /// Return the key as a RSAKeyPair;
        /// </summary>
        public override Goedel.Cryptography.KeyPair KeyPair {
            get { return _RSAKeyPair; }
            set { _RSAKeyPair = value as RSAKeyPair; }
            }

        /// <summary>
        /// The wrapped provider class.
        /// </summary>
        RSACryptoServiceProvider Provider =>_RSAKeyPair.Provider; 

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
        public override string UDF => KeyPair?.UDF;


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


        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmID DigestAlgorithm) {
            return new CryptoProviderExchangeRSA(KeySize);
            }

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
            _RSAKeyPair = new RSAKeyPair(KeySecurity, KeySize);
            //_RSAKeyPair.Persist(KeySecurity);
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


        //byte[] KeptKey;

        /// <summary>
        /// Encrypt the bulk key.
        /// </summary>
        /// <param name="Data">The bulk key to encrypt</param>
        /// <param name="Algorithm">Composite encryption algorithm.</param>
        /// <param name="Wrap">If true create a new CryptoData instance that
        /// wraps the parameters supplied in Data.</param> 
        /// <returns>Cryptographic provider.</returns>
        public override CryptoDataExchange Encrypt(CryptoData Data,
            CryptoAlgorithmID Algorithm = CryptoAlgorithmID.Default, bool Wrap = false) {

            var Exchange = Provider.Encrypt(Data.Key, OAEP);
            //KeptKey = Exchange;

            return new CryptoDataExchange(Algorithm, Data, this) {
                Exchange = Exchange,
                };

            }

        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="EncryptedKey">The encrypted session</param>
        /// <param name="Ephemeral">Ephemeral key input (unused in RSA)</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <param name="Partial">Partial result for use in recryption (ignored)</param>
        /// <returns>The decoded data instance</returns>
        public override byte[] Decrypt(
                    byte[] EncryptedKey,
                    KeyPair Ephemeral = null,
                    CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
                    KeyAgreementResult Partial = null) {
            return Provider.Decrypt(EncryptedKey, OAEP);
            }

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
        public CryptoProviderExchangeRSAPKCS(int KeySize) : base(KeySize) {
            this.OAEP = false;
            }
        
        private static CryptoProvider Factory(int KeySize, CryptoAlgorithmID Ignore) {
            return new CryptoProviderExchangeRSAPKCS(KeySize);
            }
        }


    }