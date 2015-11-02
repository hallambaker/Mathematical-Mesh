using System.Collections.Generic;
using Goedel.CryptoLibNG;

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

        public JoseWebEncryption(byte[] Data) {
            Encrypt(Data);
            }

        public JoseWebEncryption(byte[] Data, CryptoProviderEncryption Encryptor) {
            Encrypt(Data, Encryptor);
            }

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
            Recipient.EncryptedKey = EncryptKey(EncryptionKey);
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
            CryptoData.IV = IV;

            // get the IV
            var Decryptor = CryptoCatalog.Default.GetEncryption(BulkAlgorithm);
            var Result = Decryptor.Decrypt(CryptoData, CipherText);

            // decrypt the data


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

            return Result;
            }



        ///// <summary>
        ///// Create a JOSE encryption provider for the specified list of 
        ///// recipients.
        ///// </summary>
        //public JoseWebEncryption(List <Recipient> Recipients) {
        //    }





        ///// <summary>
        ///// Construct JWE structure from a CryptoData Input
        ///// </summary>
        ///// <param name="CryptoData"></param>
        //public JoseWebEncryption(CryptoData CryptoData) {
        //    var HeaderProtected = new Header();
        //    var HeaderUnprotected = new Header();            
            


        //    IV = CryptoData.IV;
        //    CipherText = CryptoData.Data;

        //    Protected = null;
        //    Unprotected = null;

        //    }

        ///// <summary>
        ///// Add a decryption blob for the specified JSON recipient.
        ///// </summary>
        ///// <param name="Recipient"></param>
        //public void Add(Recipient Recipient) {
        //    Recipients.Add(Recipient);
        //    }

        ///// <summary>
        ///// Add a decryption blob for the recipient whose key has the specified UDF
        ///// fingerprint
        ///// </summary>
        ///// <param name="KeyHandle">Key handle of the recipient's key.</param>
        //public void Add(KeyHandle KeyHandle) {
        //    var Recipient = new Recipient(KeyHandle);
        //    Recipients.Add(Recipient);
        //    }


        }

    /// <summary>
    /// Represents a JWE recipient
    /// </summary>
    public partial class Recipient {

        /// <summary>
        /// Encrypt to the specified key of the specified profile.
        /// </summary>
        /// <param name="KeyHandle"></param>
        public Recipient(KeyPair KeyPair) {
            Header = new Header();
            Header.kid = KeyPair.UDF;
            }

        }




    }
