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


namespace Goedel.Cryptography {



    /// <summary>
    /// Base provider for public key encryption and symmetric key wrap.
    /// 
    /// NB these classes do not support bulk encryption.
    /// </summary>
    public abstract class CryptoProviderExchange : CryptoProviderAsymmetric {

        /// <summary>The crypto algorithm class.</summary>
        protected static CryptoAlgorithmClass _AlgorithmClass =
            CryptoAlgorithmClass.Exchange;

        /// <summary>Return the crypto algorithm class.</summary>
        public override CryptoAlgorithmClass AlgorithmClass => _AlgorithmClass; 

        /// <summary>
        /// Extract the actual algorithm ID from the requested Algorithm ID. This allows
        /// the provider to select the default for the key exchange mode etc.
        /// </summary>
        /// <param name="BaseAlgorithm">Base ID</param>
        /// <returns>Selected ID.</returns>
        protected virtual CryptoAlgorithmID SetOptions (CryptoAlgorithmID BaseAlgorithm) {
            return BaseAlgorithm.Meta();
            }


        /// <summary>
        /// The default digest algorithm. This may be overridden in subclasses.
        /// for example, to make a different digest algorithm the default for
        /// a particular provider.
        /// </summary>
        public override CryptoAlgorithmID BulkAlgorithmDefault { get; set; } =
                CryptoCatalog.Default.AlgorithmEncryption;

        /// <summary>
        /// Perform a key wrap operation and return a CryptoDataWrapped instance
        /// containing the wrapped key parameters and a bulk provider. 
        /// </summary>
        /// <param name="Algorithm">The key wrap algorithm</param>
        /// <param name="Bulk">The bulk provider to use. If specified, the parameters from
        /// the specified provider will be used. Otherwise a new bulk provider will 
        /// be created and returned as part of the result.</param>
        /// <param name="OutputStream">Output stream (ignored)</param> 
        /// <returns>Instance describing the key agreement parameters.</returns>
        public override CryptoDataEncoder MakeEncoder(
                            CryptoProviderBulk Bulk = null,
                            CryptoAlgorithmID Algorithm = CryptoAlgorithmID.Default,
                            Stream OutputStream = null
                            ) {

            var BulkAlgorithm = Algorithm.Bulk();
            BulkAlgorithm = (BulkAlgorithm == CryptoAlgorithmID.Default) ? BulkAlgorithmDefault : BulkAlgorithm;

            var ExchangeAlgorithm = SetOptions (Algorithm.Meta());

            var Encryption = (Bulk as CryptoProviderEncryption) ?? 
                CryptoCatalog.Default.GetEncryption(BulkAlgorithm);

            var Key = Platform.GetRandomBits(Encryption.KeySize);
            var IV = Platform.GetRandomBits(Encryption.IVSize);

            var Result = Encryption.MakeEncryptor(Key, IV, Algorithm, OutputStream);
            Result.AlgorithmIdentifier = ExchangeAlgorithm | Encryption.CryptoAlgorithmID;

            var Exchange = Encrypt(Result);
            Result.Exchanges = new List<CryptoDataExchange>() { Exchange};

            return Result;
            }


        /// <summary>
        /// Encrypt the specified data.
        /// </summary>
        /// <param name="Data">Data to be encrypted.</param>
        /// <param name="Algorithm">Composite encryption algorithm.</param>
        /// <returns>The encoder</returns>
        public CryptoDataEncoder Encrypt(byte[] Data, CryptoAlgorithmID Algorithm = CryptoAlgorithmID.Default) {
            var Encoder = MakeEncoder(Algorithm: Algorithm);
            Encoder.InputStream.Write(Data, 0, Data.Length);
            Encoder.Complete();
            return Encoder;
            }

        /// <summary>
        /// Encrypt the specified data.
        /// </summary>
        /// <param name="Text">Text to be converted to UTF8 and encrypted.</param>
        /// <param name="Algorithm">The enncryption algorithm to use.</param>
        /// <returns>The encoder</returns>
        public CryptoDataEncoder Encrypt(string Text, CryptoAlgorithmID Algorithm = CryptoAlgorithmID.Default) {
            return Encrypt(Encoding.UTF8.GetBytes(Text), Algorithm);
            }

        /// <summary>
        /// Encrypt the bulk key.
        /// </summary>
        /// <param name="Data">The data to encrypt.</param>
        /// <param name="Algorithm">Composite encryption algorithm.</param>
        /// <param name="Wrap">If true create a new CryptoData instance that
        /// wraps the parameters supplied in Data.</param>
        /// <returns>The encoder</returns>
        public abstract CryptoDataExchange Encrypt(CryptoData Data, 
            CryptoAlgorithmID Algorithm = CryptoAlgorithmID.Default, bool Wrap =false);

        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="EncryptedKey">The encrypted session</param>
        /// <param name="Ephemeral">Ephemeral key input (if required)</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <param name="Partial">Partial key agreementr value (for recryption)</param>
        /// <returns>The decoded data instance</returns>
        public abstract byte[] Decrypt(
                    byte[] EncryptedKey, KeyPair Ephemeral = null,
                    CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
                    KeyAgreementResult Partial = null);

        }
    }