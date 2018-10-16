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


        /// <summary>The authentication algorithm to use</summary>
        public CryptoAlgorithmID DigestID;

        /// <summary>The encryption algorithm to use</summary>
        public CryptoAlgorithmID EncryptID;



        /// <summary>
        /// If true, data is to be encrypted.
        /// </summary>
        public bool Encrypt => EncryptID != CryptoAlgorithmID.NULL;

        /// <summary>
        /// If true, data is to be digested.
        /// </summary>
        public bool Digest => DigestID != CryptoAlgorithmID.NULL;



        void SetEncrypt() => EncryptID = EncryptID == CryptoAlgorithmID.NULL ? CryptoAlgorithmID.Default : EncryptID;
        void SetDigest() => DigestID = DigestID == CryptoAlgorithmID.NULL ? CryptoAlgorithmID.Default : DigestID;

        /// <summary>
        /// If true, data is to be signed.
        /// </summary>
        public bool Sign => SignerKeys != null;

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected CryptoParameters() {
            }

        /// <summary>
        /// Create a CryptoParameters instance to encode data for the specified recipients and
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
                        KeyCollection KeyCollection,
                        List<string> Recipients = null,
                        List<string> Signers = null,
                        CryptoAlgorithmID EncryptID = CryptoAlgorithmID.NULL,
                        CryptoAlgorithmID DigestID = CryptoAlgorithmID.NULL) {
            this.DigestID = DigestID;
            this.EncryptID = EncryptID;

            this.KeyCollection = KeyCollection;

            if (Recipients != null) {
                SetEncrypt();

                EncryptionKeys = new List<KeyPair>();
                foreach (var Entry in Recipients) {
                    AddEncrypt(Entry);
                    }
                }

            if (Signers != null) {
                SetDigest();

                SignerKeys = new List<KeyPair>();
                foreach (var Entry in Signers) {
                    AddSign(Entry);
                    }
                }
            }


        /// <summary>
        /// Create a CryptoParameters instance to encode data for the specified recipients and
        /// signers using the specified KeyCollection to resolve the identifiers.
        /// </summary>
        /// <param name="Recipient">The public keys to be used to encrypt.</param>
        /// <param name="Signer">The private keys to be used in signing.</param>
        /// <param name="EncryptID">The cryptographic enhancement to be applied to the
        /// content.</param>
        /// <param name="DigestID">The digest algorithm to be applied to the message
        /// encoding.</param>
        public CryptoParameters(
                KeyPair Recipient = null,
                KeyPair Signer = null,
                CryptoAlgorithmID EncryptID = CryptoAlgorithmID.NULL,
                CryptoAlgorithmID DigestID = CryptoAlgorithmID.NULL) {

            this.DigestID = DigestID;
            this.EncryptID = EncryptID;

            if (Recipient != null) {
                SetEncrypt();
                EncryptionKeys = new List<KeyPair>() { Recipient };
                }
            if (Signer != null) {
                SetDigest();
                SignerKeys = new List<KeyPair>() { Signer };
                }
            }






        /// <summary>
        /// Add a recipient entry.
        /// </summary>
        /// <param name="AccountId">Identifier of the key to add.</param>
        protected virtual void AddEncrypt(string AccountId) {
            EncryptionKeys = EncryptionKeys ?? new List<KeyPair>();
            EncryptionKeys.Add(KeyCollection.MatchPublicEncrypt(AccountId));
            }

        /// <summary>
        /// Ad a signer entry.
        /// </summary>
        /// <param name="AccountId">Identifier of the key to add.</param>
        protected virtual void AddSign(string AccountId) {
            SignerKeys = SignerKeys ?? new List<KeyPair>();
            SignerKeys.Add(KeyCollection.MatchPrivateSign(AccountId));
            }


        /// <summary>
        /// Generate a new CryptoStack for this parameter set.
        /// </summary>
        /// <returns>The created CryptoStack.</returns>
        public CryptoStack GetCryptoStack() => new CryptoStack(this);


        }


    }
