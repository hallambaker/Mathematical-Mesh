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
        /// 

        /// <summary>
        /// The base seed provided as a verbatim value or provided through a key exchange to be 
        /// used together with the salt data to derive the keys and initialization data for 
        /// cryptographic operations.
        /// </summary>
        public byte[] BaseSeed;

        ///<summary>The key size in bits determined by the value of <see cref="EncryptId"/></summary> 
        public int KeySize { get; private set; }

        ///<summary>The block size in bits determined by the value of <see cref="EncryptId"/></summary> 
        public int BlockSize { get; private set; }

        ///<summary>The block size in bytes determined by the value of <see cref="EncryptId"/></summary> 
        public int BlockSizeByte => BlockSize / 8;


        ///<summary>The last frame in which a key exchange was performed.</summary> 
        public int KeyExchangeIndex = -1;

        ///<summary>The set of encryption keys under which key exchanges are to be performed.</summary> 
        ///<remarks>If the value <see cref="EncryptId"/> is to be overriden, this should be done
        ///first so as to avoid recalculating the parameters.</remarks>
        public List<CryptoKey> EncryptionKeys {
            get => encryptionKeys;
            set {
                encryptionKeys = value;
                if (value != null) {
                    SetEncrypt();
                    }
                }
            }
        List<CryptoKey> encryptionKeys;

        /// <summary>The set of keys to use to sign</summary>
        ///<remarks>If the value <see cref="DigestId"/> is to be overriden, this should be done
        ///first so as to avoid recalculating the parameters.</remarks>
        public List<CryptoKey> SignerKeys {
            get => signerKeys;
            set {
                signerKeys = value;
                SetDigest();
                }
            }
        List<CryptoKey> signerKeys;

        /// <summary>The payload digest algorithm.</summary>
        public CryptoAlgorithmId DigestId;

        /// <summary>The payload encryption algorithm.</summary>
        public CryptoAlgorithmId EncryptId {
            get => encryptId;
            set => SetEncryptId(value);
            }
        CryptoAlgorithmId encryptId;

        void SetEncryptId(CryptoAlgorithmId encryptId) {
            this.encryptId = encryptId;
            if (encryptId != CryptoAlgorithmId.NULL) {
                (KeySize, BlockSize) = EncryptId.GetKeySize();
                (KeySize >= 128).AssertTrue(InsufficientKeySize.Throw, "Key size insufficient");
                BaseSeed = Platform.GetRandomBits(KeySize);
                }
            }

        /// <summary>
        /// If true, data is to be encrypted.
        /// </summary>
        public bool Encrypt => EncryptId != CryptoAlgorithmId.NULL;

        /// <summary>
        /// If true, data is to be digested.
        /// </summary>
        public bool Digest => DigestId != CryptoAlgorithmId.NULL;

        ///<summary>Require payload encryption.</summary> 
        public void SetEncrypt() {
            if (EncryptId == CryptoAlgorithmId.NULL) {
                EncryptId = CryptoAlgorithmId.Default;
                }
            }

        ///<summary>Require payload digest.</summary> 
        public void SetDigest() {
                if (DigestId == CryptoAlgorithmId.NULL) {
                    DigestId = CryptoAlgorithmId.Default;
                    }
                }

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
            this.DigestId = digestID;
            this.EncryptId = encryptID;

            this.KeyLocate = keyCollection;

            if (recipients != null) {
                EncryptionKeys = new List<CryptoKey>();
                foreach (var Entry in recipients) {
                    AddEncrypt(Entry);
                    }
                SetEncrypt();
                }
            else if (recipient != null) {
                EncryptionKeys = new List<CryptoKey>() { recipient };
                SetEncrypt();
                }
            EncryptId = EncryptId == CryptoAlgorithmId.Default ? CryptoID.DefaultEncryptionId : EncryptId;

            if (signers != null) {
                SignerKeys = new List<CryptoKey>();
                foreach (var Entry in signers) {
                    AddSign(Entry);
                    }
                }
            else if (signer != null) {
                SignerKeys = new List<CryptoKey>() { signer };
                }

            DigestId = DigestId == CryptoAlgorithmId.Default ? CryptoID.DefaultDigestId : DigestId;
            }







        /// <summary>
        /// Add a recipient entry.
        /// </summary>
        /// <param name="AccountId">Identifier of the key to add.</param>
        protected virtual void AddEncrypt(string AccountId) {
            KeyLocate.TryFindKeyEncryption(AccountId, out var key).AssertTrue(
                        NoAvailableEncryptionKey.Throw);

            EncryptionKeys ??= new List<CryptoKey>();
            EncryptionKeys.Add(key);
            }

        /// <summary>
        /// Add a signer entry.
        /// </summary>
        /// <param name="AccountId">Identifier of the key to add.</param>
        protected virtual void AddSign(string AccountId) {
            SignerKeys ??= new List<CryptoKey>();
            if (KeyLocate.TryFindKeySignature(AccountId, out var key)) {
                SignerKeys.Add(key);
                }
            }


        ///// <summary>
        ///// Generate a new CryptoStack for this parameter set.
        ///// </summary>
        ///// <returns>The created CryptoStack.</returns>
        //public CryptoStack GetCryptoStack() => new CryptoStack(this);


        /// <summary>
        /// Perform the steps necessary to 
        /// </summary>
        /// <param name="header"></param>
        public virtual void SetKeyExchange(DareHeader header) {

            header.Recipients = KeyExchange();

            }


        /// <summary>
        /// Perform a new key exchange and 
        /// </summary>
        /// <returns></returns>
        protected virtual List<DareRecipient> KeyExchange() {
            // create the new base seed.
            BaseSeed = Platform.GetRandomBits(KeySize);

            // perform a key exchange for each recipient.
            var result = new List<DareRecipient>();
            foreach (var encryptionKey in EncryptionKeys) {
                result.Add(new DareRecipient(BaseSeed, encryptionKey));
                }

            return result;
            }




        }
    }
