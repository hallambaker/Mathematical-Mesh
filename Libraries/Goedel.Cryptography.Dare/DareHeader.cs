using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using System.Threading;
using Goedel.Cryptography;
using Goedel.Protocol;
using Goedel.Cryptography.Jose;
using System.Security.Cryptography;

namespace Goedel.Cryptography.Dare {

    public partial class DAREHeader {

        byte[] MasterSecret;

        /// <summary>
        /// The cryptography provider.
        /// </summary>
        protected CryptoProviderEncryption ProviderEncryption = null;

        /// <summary>
        /// If true, the header specifies a key exchange.
        /// </summary>
        public bool Encrypt => ProviderEncryption != null;

        /// <summary>
        /// The encryption key size
        /// </summary>
        public int EncryptionKeySize => ProviderEncryption.KeySize;


        long SaltValue;

        /// <summary>
        /// Threadsafe assignment of unique salt under this master secret.
        /// </summary>
        /// <returns></returns>
        /// <threadsafety static="true" instance="true"/>
        public byte[] MakeSalt () {
            if (SaltValue >= 0) {

                var Salt = Interlocked.Increment(ref SaltValue);
                return MakeSalt(Salt);
                }
            else {

                return Platform.GetRandomBits(128);
                }
            }

        /// <summary>
        /// Create a message header with a new key exchange
        /// </summary>
        /// <param name="EncryptionKeys">The keys to be used to encrypt the message body.</param>
        /// <param name="SignerKeys">The keys to be used to sign the message body.</param>
        /// <param name="EncryptID">The bulk encryption algorithm to use.</param>
        /// <param name="AuthenticateID">The bulk authentication algorithm to use. If the 
        /// encryption algorithm is an authenticated encryption algorithm, and 
        /// CryptoAlgorithmID.Default is specified, the value CryptoAlgorithmID.NULL
        /// is used.</param>
        /// <param name="ContentType">The payload content type.</param>
        /// <param name="Cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="DataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public DAREHeader (
                    List<KeyPair> EncryptionKeys = null,
                    List<KeyPair> SignerKeys = null,
                    CryptoAlgorithmID EncryptID = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID AuthenticateID = CryptoAlgorithmID.Default,
                    string ContentType = null,
                    byte[] Cloaked = null,
                    List<byte[]> DataSequences = null
                    ) {
            SetRecipients(EncryptionKeys, EncryptID);
            SetSigners(SignerKeys, AuthenticateID);
            SetEnhancedData(Cloaked, DataSequences);
            this.ContentType = ContentType;
            }






        /// <summary>
        /// Create a message header under a prior key exchange
        /// </summary>
        /// <param name="Master">Header instance defining the Master secret and associated context.</param>
        /// <param name="SignerKeys"></param>
        /// <param name="ContentType">The payload content type.</param>
        /// <param name="AuthenticateID">The bulk authentication algorithm to use. If the 
        /// encryption algorithm is an authenticated encryption algorithm, and 
        /// CryptoAlgorithmID.Default is specified, the value CryptoAlgorithmID.NULL
        /// is used.</param>
        /// <param name="Cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="DataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public DAREHeader (
                    DAREHeader Master,
                    List<KeyPair> SignerKeys = null,
                    CryptoAlgorithmID AuthenticateID = CryptoAlgorithmID.Default,
                    string ContentType = null,
                    byte[] Cloaked = null,
                    List<byte[]> DataSequences = null
                    ) {

            SetDefaultContext(Master);
            SetSigners(SignerKeys, AuthenticateID);
            SetEnhancedData(Cloaked, DataSequences);
            this.ContentType = ContentType;
            }

        void KeyExchange (
                    List<KeyPair> EncryptionKeys) {

            var KeyBits = ProviderEncryption.KeySize;
            MasterSecret = Platform.GetRandomBits(KeyBits);
            Recipients = Recipients ?? new List<DARERecipient>();
            foreach (var EncryptionKey in EncryptionKeys) {
                Recipients.Add(new DARERecipient(MasterSecret, EncryptionKey));
                }

           
            }

        /// <summary>
        /// Use information from the specified 
        /// </summary>
        /// <param name="DAREHeader"></param>
        public virtual void SetDefaultContext (DAREHeader DAREHeader) {
            SaltValue = -1;
            ProviderEncryption = DAREHeader.ProviderEncryption;
            MasterSecret = DAREHeader.MasterSecret;

            }

        /// <summary>
        /// Initialize the encryption context.
        /// </summary>
        /// <param name="EncryptionKeys">The keys to be used to encrypt the message body.</param>
        /// <param name="EncryptID">The bulk encryption algorithm to use.</param>
        public virtual void SetRecipients (
            List<KeyPair> EncryptionKeys,
            CryptoAlgorithmID EncryptID = CryptoAlgorithmID.Default) {
            if (EncryptionKeys == null) {
                return;
                }

            EncryptID = EncryptID == CryptoAlgorithmID.Default ? CryptoAlgorithmID.AES256CBC : EncryptID;
            EncryptionAlgorithm = EncryptID.ToJoseID();
            ProviderEncryption = CryptoCatalog.Default.GetEncryption(EncryptID);
            KeyExchange(EncryptionKeys);
            SaltValue = 0;
            }

        /// <summary>
        /// Initialize the signing context.
        /// </summary>
        /// <param name="SignerKeys">The keys to be used to sign the message body.</param>
        /// <param name="AuthenticateID">The bulk authentication algorithm to use. If the 
        /// encryption algorithm is an authenticated encryption algorithm, and 
        /// CryptoAlgorithmID.Default is specified, the value CryptoAlgorithmID.NULL
        /// is used.</param>
        public virtual void SetSigners (
                    List<KeyPair> SignerKeys = null,
                    CryptoAlgorithmID AuthenticateID = CryptoAlgorithmID.Default) {
            if (SignerKeys == null) {
                return;
                }
            throw new NYI();
            }

        /// <summary>
        /// Create encrypted header entries under the specified key.
        /// </summary>
        /// <param name="Cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="DataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public void SetEnhancedData (
                    byte[] Cloaked = null,
                    List<byte[]> DataSequences = null) {

            if (Cloaked != null) {
                this.Cloaked = Enhance(Cloaked);
                }
            if (DataSequences != null) {
                this.EDSS = new List<byte[]>();
                foreach (var DataSequence in DataSequences) {
                    EDSS.Add (Enhance(DataSequence));
                    }
                }

            }

        /// <summary>
        /// Return a binary EDS sequence of the specified plaintext under this header. A
        /// unique salt will be assigned.
        /// </summary>
        /// <param name="Plaintext">The EDS plaintext.</param>
        /// <returns>The EDS</returns>
        public byte[] Enhance(byte[] Plaintext) => ProviderEncryption == null ? Plaintext :
                EnhancedDataSequence.Enhance(MasterSecret, Plaintext, MakeSalt(), ProviderEncryption);
        /// <summary>
        /// Return an EDSWriter to output the message body.
        /// </summary>
        /// <param name="OutputStream"></param>
        /// <param name="ContentLength"></param>
        /// <returns></returns>
        public EnhancedDataSequence EnhancedDataSequenceWriter(
                    JSONWriter OutputStream,
                    long ContentLength = -1) => MasterSecret == null ?
                new EnhancedDataSequenceWriter(OutputStream, ContentLength: ContentLength) :
                new EnhancedDataSequenceWriter(OutputStream, MasterSecret, ProviderEncryption,
                        MakeSalt(), ContentLength: ContentLength);





        /// <summary>
        /// Convert an int64 counter to a unique salt value.
        /// </summary>
        /// <param name="SaltValue"></param>
        /// <returns></returns>
        public static byte[] MakeSalt (long SaltValue) {
            var Salt = SaltValue;

            var Index = 0;
            while (Salt > 0xFF) {
                Index++;
                Salt = Salt >> 8;
                }

            var Result = new byte[Index+1];

            Salt = SaltValue;
            Index = 0;
            while (Salt > 0xFF) {
                Result[Index++] = (byte) (Salt & 0xFF);
                Salt = Salt >> 8; 
                }
            return Result;

            }


        ///// <summary>
        ///// Create encryption info
        ///// </summary>
        ///// <param name="Data">Data to be encrypted.</param>
        ///// <param name="Recipients">The recipient information entries.</param>
        ///// <param name="Protected">The protected encryption header</param>
        ///// <param name="EncryptionKeys">The encryption key.</param>
        ///// <param name="ContentType">Content type identifier.</param>
        ///// <param name="EncryptID">Encryption algorithm to use.</param>
        ///// <returns>The encrypted data info block.</returns>
        //public static CryptoData Encrypt (byte[] Data,
        //            out List<DARERecipient> Recipients,
        //            out Header Protected,
        //            List<KeyPair> EncryptionKeys = null,
        //            string ContentType = null,
        //            CryptoAlgorithmID EncryptID = CryptoAlgorithmID.Default
        //            ) {

        //    throw new NYI();

        //    //var Provider = CryptoCatalog.Default.GetEncryption(EncryptID);
        //    //var EncryptEncoder = Provider.MakeEncoder(Algorithm: EncryptID);
        //    //Protected = JoseWebEncryption.ProtectedHeader(EncryptEncoder, ContentType, null);

        //    //Recipients = new List<Cryptography.Jose.Recipient>();

        //    //foreach (var EncryptionKey in EncryptionKeys) {
        //    //    var KID = EncryptionKey.Name ?? EncryptionKey.UDF;
        //    //    var Recipient = JoseWebEncryption.Recipient(
        //    //            EncryptEncoder, EncryptionKey, KID: KID, ProviderAlgorithm: EncryptID);
        //    //    Recipients.Add(Recipient);
        //    //    }

        //    //EncryptEncoder.Write(Data);
        //    //EncryptEncoder.Complete();

        //    //return EncryptEncoder;
        //    }




        }

    }
