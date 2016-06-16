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

using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Debug;


namespace Goedel.Cryptography.Jose {

    /// <summary>
    /// Represents a JWE data structure.
    /// </summary>
    public partial class JoseWebEncryption {
        CryptoAlgorithmID _BulkAlgorithm = CryptoAlgorithmID.NULL;
        CryptoData CryptoData;

        /// <summary>
        /// Get or set the bulk encryption algorithm
        /// </summary>
        public CryptoAlgorithmID BulkAlgorithm {
            get {
                if (_BulkAlgorithm == CryptoAlgorithmID.NULL) {
                    _BulkAlgorithm = CryptoCatalog.Default.AlgorithmEncryption;
                    }
                return _BulkAlgorithm;
                }
            set { _BulkAlgorithm = value; }
            }

        /// <summary>
        /// Construct a JWE encryption object and encrypt the specified data.
        /// </summary>
        /// <param name="Data">The data to be encrypted.</param>
        public JoseWebEncryption(byte[] Data) {
            Encrypt(Data);
            }

        /// <summary>
        /// Construct a JWE encryption object and encrypt the specified data
        /// using the specified encryption provider.
        /// </summary>
        /// <param name="Encryptor">Encryption provider to use.</param>
        /// <param name="Data">The data to be encrypted.</param>
        public JoseWebEncryption(byte[] Data, CryptoProviderEncryption Encryptor) {
            Encrypt(Data, Encryptor);
            }


        /// <summary>
        /// Construct a JWE encryption object and encrypt the specified data
        /// and create decryption entries for the specified recipients.
        /// </summary>
        /// <param name="Recipients">The recipients to create the 
        /// decryption blobs for.</param>
        /// <param name="Data">The data to be encrypted.</param>
        public JoseWebEncryption(byte[] Data, List<Recipient> Recipients) {
            Encrypt(Data);
            this.Recipients = Recipients;
            }

        /// <summary>
        /// Create a new encryption context and encrypt the data under the 
        /// generated content key and IV.
        /// </summary>
        /// <param name="Data"></param>
        public void Encrypt(byte[] Data) {
            var Encryptor = CryptoCatalog.Default.GetEncryption(BulkAlgorithm);
            Encrypt(Data, Encryptor);
            }

        /// <summary>
        /// Create a new encryption context and encrypt the data under the 
        /// generated content key and IV.
        /// </summary>
        /// <param name="Data">The data to encrypt</param>
        /// <param name="Encryptor">The encryption provider to use.</param>
        public void Encrypt(byte[] Data, CryptoProviderEncryption Encryptor) {
            Trace.WriteHex("Encryption Key", Encryptor.Key);


            CryptoData = Encryptor.Encrypt(Data);
            var Preheader = new Header(Encryptor);
            Protected = Preheader.GetBytes(false); // get the data bytes untagged
            IV = CryptoData.IV;
            JTag = CryptoData.Integrity;
            CipherText = CryptoData.Data;
            }

        /// <summary>
        /// Add an entry for the specified key to the recipient list.
        /// </summary>
        /// <param name="EncryptionKey">The encryption key to create the
        /// entry for.</param>
        public void Add(KeyPair EncryptionKey) {
            var Recipient = new Recipient(EncryptionKey);

            Trace.WriteLine("Create blob for {0}", EncryptionKey.UDF);
            Recipient.EncryptedKey = EncryptKey(EncryptionKey);
            Trace.WriteHex("Created", Recipient.EncryptedKey);

            Recipient.Header = new Header();
            Recipient.Header.kid = EncryptionKey.UDF;
            Add(Recipient);
            return;
            }

        /// <summary>
        /// Add a recipient entry to the recipient list.
        /// </summary>
        /// <param name="Recipient"></param>
        public void Add(Recipient Recipient) {
            Recipients = Recipients == null ? new List<Recipient>() : Recipients;
            Recipients.Add(Recipient);
            }


        private Recipient Find (string KeyID) {
            foreach (var Recipient in Recipients) {
                if (KeyID == Recipient.Header.kid) {
                    return Recipient;
                    }
                }

            return null;
            }

        /// <summary>
        /// Decrypt the content using the corresponding private key in the local 
        /// key store (if found). Throws exception otherwise.
        /// </summary>
        /// <returns>The decrypted data</returns>
        public byte[] Decrypt() {
            return Decrypt(null);
            }

        /// <summary>
        /// Decrypt the content using the specified private key.
        /// </summary>
        /// <returns>The decrypted data</returns>
        public byte[] Decrypt(KeyPair DecryptionKey) {
            // Read the preheader, get the encryption algorithm
            var PreHeader = Header.From(Protected);
            var Recipient = Find(DecryptionKey.UDF);
            var Exchange = DecryptionKey.ExchangeProviderDecrypt;




            CryptoData.Key = Exchange.Decrypt(Recipient.EncryptedKey);

            Trace.WriteHex("Decryption Key", CryptoData.Key);

            CryptoData.IV = IV;

            // get the IV
            var Decryptor = CryptoCatalog.Default.GetEncryption(BulkAlgorithm);

            // decrypt the data
            var Result = Decryptor.Decrypt(CryptoData, CipherText);
            return Result.Data;
            }

        /// <summary>
        /// Return an encrypted key data entry for the specified encryption key.
        /// </summary>
        /// <param name="EncryptionKey">The key to use for encryption.</param>
        /// <returns>The encrypted key data.</returns>
        public byte[] EncryptKey(KeyPair EncryptionKey) {

            var Exchange = EncryptionKey.ExchangeProviderEncrypt;
            var Result = Exchange.Encrypt(CryptoData.Key);

            Trace.WriteHex("Key is ", CryptoData.Key);

            return Result;
            }

        }

    /// <summary>
    /// Represents a JWE recipient
    /// </summary>
    public partial class Recipient {

        /// <summary>
        /// Encrypt to the specified key of the specified profile.
        /// </summary>
        /// <param name="KeyPair">KeyPair for the recipient.</param>
        public Recipient(KeyPair KeyPair) {
            Header = new Header();
            Header.kid = KeyPair.UDF;
            }

        }

    }
