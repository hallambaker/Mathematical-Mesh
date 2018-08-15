using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;
namespace Goedel.Cryptography.Dare {


    /// <summary>
    /// Specifies a set of cryptographic parameters to be used to create 
    /// CryptoStacks
    /// </summary>
    public partial class CryptoParameters {

        /// <summary>The key collection to use to resolve names to keys</summary>
        public KeyCollection KeyCollection;
        /// <summary>The set of keys to encrypt to.</summary>
        public List<KeyPair> EncryptionKeys;
        /// <summary>The set of keys to use to sign</summary>
        public List<KeyPair> SignerKeys;
        /// <summary>The encryption algorithm to use</summary>
        public CryptoAlgorithmID EncryptID;
        /// <summary>The authentication algorithm to use</summary>
        public CryptoAlgorithmID DigestID;


        CryptoAlgorithmID _AuthenticateID;
        /// <summary>
        /// If true, data is to be encrypted.
        /// </summary>
        public bool Encrypt => EncryptionKeys != null;

        /// <summary>
        /// If true, data is to be encrypted.
        /// </summary>
        public bool Sign => SignerKeys != null;

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected CryptoParameters() {
            }

        /// <summary>
        /// Create a CryptoStack instance to encode data for the specified recipients and
        /// signers using the specified KeyCollection to resolve the identifiers.
        /// </summary>
        /// <param name="KeyCollection">The Key collection to be used to resolve names.</param>
        /// <param name="Recipients">The public keys to be used to encrypt.</param>
        /// <param name="Signers">The private keys to be used in signing.</param>
        /// <param name="EncryptID">The cryptographic enhancement to be applied to the
        /// content.</param>
        /// <param name="DigestID">The digest algorithm to be applied to the message
        /// encoding.</param>
        public CryptoParameters(
                        KeyCollection KeyCollection = null,
                        List<string> Recipients = null,
                        List<string> Signers = null,
                        CryptoAlgorithmID EncryptID = CryptoAlgorithmID.NULL,
                        CryptoAlgorithmID DigestID = CryptoAlgorithmID.NULL) {

            this.KeyCollection = KeyCollection;

            if (Recipients != null) {
                EncryptID = EncryptID == CryptoAlgorithmID.NULL ? CryptoAlgorithmID.Default : EncryptID;
                EncryptID = EncryptID == CryptoAlgorithmID.Default ? CryptoAlgorithmID.AES256CBC : EncryptID;

                EncryptionKeys = new List<KeyPair>();
                foreach (var Entry in Recipients) {
                    AddEncrypt(Entry);
                    }
                }

            if (Signers != null) {
                DigestID = DigestID == CryptoAlgorithmID.NULL ? CryptoAlgorithmID.Default : DigestID;

                SignerKeys = new List<KeyPair>();
                foreach (var Entry in Signers) {
                    AddSign(Entry);
                    }
                }

            this.EncryptID = EncryptID;
            this.DigestID = DigestID == CryptoAlgorithmID.Default ? CryptoAlgorithmID.SHA_2_512 : DigestID;
            }

        protected virtual void AddEncrypt(string AccountId) {
            EncryptionKeys.Add(KeyCollection.MatchPublic(AccountId));
            }

        protected virtual void AddSign(string AccountId) {
            SignerKeys.Add(KeyCollection.MatchPrivate(AccountId));
            }


        /// <summary>
        /// Generate a new CryptoStack for this parameter set.
        /// </summary>
        /// <returns>The created CryptoStack.</returns>
        public CryptoStack GetCryptoStack() => new CryptoStack(this);



        public int GetTrailerLength() {
            DARETrailer Result = null;

            var DigestLength = CryptoCatalog.Default.ResultInBytes(DigestID);


            if (DigestLength > 0) {
                Result = new DARETrailer() {
                    PayloadDigest = new byte[DigestLength]
                    };
                }

            return Result == null ? -1 : Result.GetBytes().Length;

            }
        }



    }
