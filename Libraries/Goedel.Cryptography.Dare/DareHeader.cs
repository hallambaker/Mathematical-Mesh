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

    // Feature: Support encryption algorithms other than AES256 by including the algorithmID in the header

    public partial class DAREHeader {

        byte[] MasterSecret;




        /// <summary>
        /// The cryptography provider.
        /// </summary>
        protected CryptoProviderEncryption ProviderEncryption = null;

        /// <summary>
        /// If true, the header specifies a key exchange.
        /// </summary>
        public bool Encrypt => EncryptionAlgorithm!=null;

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

            Salt = Platform.GetRandomBits(128);
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
                this.Cloaked = EnhanceSequence(Cloaked);
                }
            if (DataSequences != null) {
                this.EDSS = new List<byte[]>();
                foreach (var DataSequence in DataSequences) {
                    EDSS.Add (EnhanceSequence(DataSequence));
                    }
                }

            }

        /// <summary>
        /// Return a binary EDS sequence of the specified plaintext under this header. A
        /// unique salt will be assigned.
        /// </summary>
        /// <param name="Plaintext">The EDS plaintext.</param>
        /// <param name="Salt">The salt value to be used.</param>
        /// <returns>The EDS</returns>
        public byte[] EnhanceBody(byte[] Plaintext, byte[] Salt = null) => ProviderEncryption == null ? Plaintext :
                EnhancedDataSequence.Encrypt(ProviderEncryption, MasterSecret,
                        Salt, Plaintext);



            
            //Enhance(MasterSecret, Plaintext, Salt ?? MakeSalt(), ProviderEncryption,
            //        BodyMode: true);

        /// <summary>
        /// Return a binary EDS sequence of the specified plaintext under this header. A
        /// unique salt will be assigned.
        /// </summary>
        /// <param name="Plaintext">The EDS plaintext.</param>
        /// <param name="Salt">The salt value to be used.</param>
        /// <returns>The EDS</returns>
        public byte[] EnhanceSequence(byte[] Plaintext, byte[] Salt = null) => ProviderEncryption == null ? Plaintext :
                EnhancedDataSequence.Enhance(MasterSecret, Plaintext, Salt ?? MakeSalt(), ProviderEncryption,
                    BodyMode: false);



        /// <summary>
        /// Return an EDSWriter to output the message body.
        /// </summary>
        /// <param name="OutputStream"></param>
        /// <param name="ContentLength"></param>
        /// <param name="Salt"></param>
        /// <returns></returns>
        public EnhancedDataSequence EnhancedDataSequenceWriter(
                    JSONWriter OutputStream,
                    long ContentLength = -1,
                    byte[] Salt = null) => MasterSecret == null ?
                new EnhancedDataSequenceWriter(OutputStream, ContentLength: ContentLength) :
                new EnhancedDataSequenceWriter(OutputStream, MasterSecret, ProviderEncryption,
                        Salt??MakeSalt(), ContentLength: ContentLength);





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

        CryptoAlgorithmID EncryptId;

        /// <summary>
        /// Attempt decryption of the master key by matching a recipient entry to the 
        /// keys in the specified key collection.
        /// </summary>
        /// <param name="KeyCollection">The key collection to use or the default collection
        /// if null.</param>
        public void DecryptMaster(KeyCollection KeyCollection) {
            EncryptId = EncryptionAlgorithm.FromJoseID();

            MasterSecret = KeyCollection.Decrypt(Recipients, EncryptId);
            ProviderEncryption = CryptoCatalog.Default.GetEncryption(EncryptId);
            }


        /// <summary>
        /// Obtain an EDS reader for the current key information. 
        /// </summary>
        /// <param name="OutputStream">The output stream</param>
        /// <param name="Salt">The salt value. If null, the first binary data item in the
        /// stream is used as the salt.</param>
        /// <returns>The EDS reader.</returns>
        public EnhancedDataSequenceReader GetReader(Stream OutputStream, byte[] Salt = null) {

            if (Salt == null) {
                // read the salt from the stream.

                }
            return new EnhancedDataSequenceReader(OutputStream, MasterSecret, ProviderEncryption,
                Salt);

            }


        }

    /// <summary>
    /// Extensions classes.
    /// </summary>
    public static class Extensions {
        // ToDo: Make Recipients into an interface...

        /// <summary>
        /// Attempt to decrypt a decryption blob from a list of recipient entries.
        /// </summary>
        /// <param name="KeyCollection">The key collection to be used to resolve keys.</param>
        /// <param name="Recipients">The recipient entry.</param>
        /// <param name="AlgorithmID">The symmetric encryption cipher (used to decrypt the wrapped key).</param>
        /// <returns></returns>
        public static byte[] Decrypt(this KeyCollection KeyCollection, List<DARERecipient> Recipients, CryptoAlgorithmID AlgorithmID) {
            foreach (var Recipient in Recipients) {

                var DecryptionKey = KeyCollection.TryMatchRecipient(Recipient.KeyIdentifier);

                // Recipient has the following fields of interest
                // Recipient.EncryptedKey -- The RFC3394 wrapped symmetric key
                // Recipient.Header.Epk  -- The ephemeral public key
                // Recipient.Header.Epk.KeyPair  -- The ephemeral public key

                if (DecryptionKey != null) {
                    return DecryptionKey.Decrypt(Recipient.WrappedMasterKey, Recipient.Epk.KeyPair, AlgorithmID: AlgorithmID);
                    }
                }


            throw new NoAvailableDecryptionKey();
            }
        }

    }
