using Goedel.Utilities;
using System.Collections.Generic;
namespace Goedel.Cryptography.Dare {


    /// <summary>
    /// Specifies a set of cryptographic parameters to be used to create 
    /// CryptoStacks
    /// </summary>
    public partial class CryptoParameters {

        /// <summary>The key collection to use to resolve names to keys</summary>
        public IKeyLocate KeyLocate;
        /// <summary>The set of keys to encrypt to.</summary>
        public List<CryptoKey> EncryptionKeys {
            get => encryptionKeys;
            set {
                encryptionKeys = value;
                SetEncrypt();
                }
            }
        List<CryptoKey> encryptionKeys;


        /// <summary>The set of keys to use to sign</summary>
        public List<CryptoKey> SignerKeys {
            get => signerKeys;
            set {
                signerKeys = value;
                SetDigest();
                }
            }
        List<CryptoKey> signerKeys;

        /// <summary>The authentication algorithm to use</summary>
        public CryptoAlgorithmId DigestID;

        /// <summary>The encryption algorithm to use</summary>
        public CryptoAlgorithmId EncryptID;



        /// <summary>
        /// If true, data is to be encrypted.
        /// </summary>
        public bool Encrypt => EncryptID != CryptoAlgorithmId.NULL;

        /// <summary>
        /// If true, data is to be digested.
        /// </summary>
        public bool Digest => DigestID != CryptoAlgorithmId.NULL;



        void SetEncrypt() => EncryptID = EncryptID == CryptoAlgorithmId.NULL ? CryptoAlgorithmId.Default : EncryptID;
        void SetDigest() => DigestID = DigestID == CryptoAlgorithmId.NULL ? CryptoAlgorithmId.Default : DigestID;

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
        /// <param name="keyCollection">The Key collection to be used to resolve names.</param>
        /// <param name="recipients">The public keys to be used to encrypt.</param>
        /// <param name="signers">The private keys to be used in signing.</param>
        /// <param name="recipient">The public keys to be used to encrypt.</param>
        /// <param name="signer">The private keys to be used in signing.</param>
        /// <param name="encryptID">The cryptographic enhancement to be applied to the
        /// content.</param>
        /// <param name="digestID">The digest algorithm to be applied to the message
        /// encoding.</param>
        public CryptoParameters(
                        IKeyLocate keyCollection = null,
                        List<string> recipients = null,
                        List<string> signers = null,
                        CryptoKey recipient = null,
                        CryptoKey signer = null,
                        CryptoAlgorithmId encryptID = CryptoAlgorithmId.NULL,
                        CryptoAlgorithmId digestID = CryptoAlgorithmId.NULL) {
            this.DigestID = digestID;
            this.EncryptID = encryptID;

            this.KeyLocate = keyCollection;

            if (recipients != null) {
                EncryptionKeys = new List<CryptoKey>();
                foreach (var Entry in recipients) {
                    AddEncrypt(Entry);
                    }
                }
            else if (recipient != null) {
                EncryptionKeys = new List<CryptoKey>() { recipient };
                }
            if (signers != null) {
                SignerKeys = new List<CryptoKey>();
                foreach (var Entry in signers) {
                    AddSign(Entry);
                    }
                }
            else if (signer != null) {
                SignerKeys = new List<CryptoKey>() { signer };
                }
            }









        /// <summary>
        /// Add a recipient entry.
        /// </summary>
        /// <param name="AccountId">Identifier of the key to add.</param>
        protected virtual void AddEncrypt(string AccountId) {
            var key = KeyLocate.TryFindKeyEncryption(AccountId);
            key.AssertNotNull(NoAvailableDecryptionKey.Throw);


            EncryptionKeys ??= new List<CryptoKey>();
            EncryptionKeys.Add(key);
            }

        /// <summary>
        /// Add a signer entry.
        /// </summary>
        /// <param name="AccountId">Identifier of the key to add.</param>
        protected virtual void AddSign(string AccountId) {
            SignerKeys ??= new List<CryptoKey>();
            SignerKeys.Add(KeyLocate.TryFindKeySignature(AccountId));
            }


        /// <summary>
        /// Generate a new CryptoStack for this parameter set.
        /// </summary>
        /// <returns>The created CryptoStack.</returns>
        public CryptoStack GetCryptoStack() => new CryptoStack(this);


        }


    }
