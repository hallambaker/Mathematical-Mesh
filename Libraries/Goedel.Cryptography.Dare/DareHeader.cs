using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Cryptography.Dare {

    // Feature: Support encryption algorithms other than AES256 by including the algorithmID in the header

    public partial class DAREHeader {

        byte[] MasterSecret;

        /// <summary>
        /// The cryptography provider.
        /// </summary>
        protected CryptoProviderEncryption ProviderEncryption = null;

        /// <summary>
        /// Calculate the expected payload length for the specified <paramref name="ContentLength"/>.
        /// </summary>
        /// <param name="ContentLength">The unencrypted content length.</param>
        /// <returns>The corresponding payload length.</returns>
        public long OutputLength(long ContentLength) =>
            CryptoStack == null ? ContentLength : CryptoStack.CipherTextLength(ContentLength);

        /// <summary>
        /// If true, the header specifies a key exchange.
        /// </summary>
        public bool Encrypt => EncryptionAlgorithm!=null;

        /// <summary>
        /// The encryption key size
        /// </summary>
        public int EncryptionKeySize => ProviderEncryption.KeySize;


        long SaltValue=0;

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
        /// Cryptographic parameters and stream generator for the header.
        /// </summary>
        public CryptoStack CryptoStack;

        /// <summary>
        /// Create a message header with a new key exchange
        /// </summary>
        /// <param name="CryptoStack">The cryptographic enhancements to apply.</param>
        /// <param name="ContentType">The payload content type.</param>
        /// <param name="Cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="DataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public DAREHeader(
                    CryptoStack CryptoStack=null,
                    string ContentType = null,
                    byte[] Cloaked = null,
                    List<byte[]> DataSequences = null
                    ) {
            this.ContentType = ContentType;
            ApplyCryptoStack(CryptoStack, Cloaked, DataSequences);
            }

        /// <summary>
        /// Apply the specified cryptographic options.
        /// </summary>
        /// <param name="CryptoStack">The cryptographic enhancements to apply.</param>
        /// <param name="Cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="DataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public void ApplyCryptoStack(
                    CryptoStack CryptoStack,
                    byte[] Cloaked = null,
                    List<byte[]> DataSequences = null) {
            this.CryptoStack = CryptoStack;

            if (CryptoStack == null) {
                EncryptionAlgorithm = null;
                return; // Hack no EDS on plaintext messages.
                }

            Salt = CryptoStack.Salt;
            Recipients = CryptoStack.Recipients;
            EncryptionAlgorithm = CryptoStack.EncryptionAlgorithm;

            if (Cloaked != null) {
                this.Cloaked = CryptoStack.Encode(Cloaked, MakeSalt());
                }
            if (DataSequences != null) {
                EDSS = new List<byte[]>();
                foreach (var DataSequence in DataSequences) {
                    EDSS.Add(CryptoStack.Encode(DataSequence, MakeSalt()));
                    }
                }
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
        /// Construct a stream that will write the body data with whatever crypto stream
        /// modules are required.
        /// </summary>
        /// <param name="Output">The ultimate output stream.</param>
        /// <returns></returns>
        public Stream BodyWriter(Stream Output) {
            if (CryptoStack == null) {
                return Output;
                }
            CurrentBodyWriter = CryptoStack.GetEncoder(Output, PackagingFormat.Direct);
            return CurrentBodyWriter.Writer;
            }

        CryptoStackStreamWriter CurrentBodyWriter = null;

        /// <summary>
        /// Close the body writer stack and free all associated resources.
        /// </summary>
        public void CloseBodyWriter(out DARETrailer DARETrailer) {
            CurrentBodyWriter.Close();
            DARETrailer = GetTrailer(CurrentBodyWriter);
            CurrentBodyWriter?.Dispose();
            CurrentBodyWriter = null;
            }

        /// <summary>
        /// Return a binary EDS sequence of the specified plaintext under this header. A
        /// unique salt will be assigned.
        /// </summary>
        /// <param name="Plaintext">The EDS plaintext.</param>
        /// <returns>The EDS</returns>
        public byte[] EnhanceBody(byte[] Plaintext, out DARETrailer DARETrailer) => 
            CryptoStack.Encode(Plaintext, out DARETrailer, PackagingFormat:PackagingFormat.Direct);


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
            Result[Index++] = (byte)(Salt & 0xFF);
            while (Salt > 0xFF) {
                Result[Index++] = (byte) (Salt & 0xFF);
                Salt = Salt >> 8; 
                }
            return Result;

            }

        CryptoAlgorithmID EncryptId;



        /// <summary>
        /// Return a decoder for the specified data source.
        /// </summary>
        /// <param name="JBCDFrameReader">The data source.</param>
        /// <param name="Reader">The stream to read the decoded data from.</param>
        /// <param name="KeyCollection">Key collection to be used to resolve private
        /// keys.</param>
        /// <returns>The decoder. </returns>
        public CryptoStackStream GetDecoder(
                        Stream JBCDFrameReader,
                        out Stream Reader,
                       KeyCollection KeyCollection = null) {

            var EncryptID = EncryptionAlgorithm.FromJoseID();

            CryptoStack = new CryptoStack(EncryptID, CryptoAlgorithmID.NULL,
                Recipients, Signatures, KeyCollection) {
                Salt = Salt
                };
            return CryptoStack.GetDecoder(JBCDFrameReader, out Reader);

            }

        /// <summary>
        /// Return a decoder for the specified data source.
        /// </summary>
        /// <param name="JSONBCDReader">The data source.</param>
        /// <param name="Reader">The stream to read the decoded data from.</param>
        /// <param name="KeyCollection">Key collection to be used to resolve private
        /// keys.</param>
        /// <returns>The decoder. </returns>
        public CryptoStackStream GetDecoder(
                        JSONBCDReader JSONBCDReader,
                        out Stream Reader,
                       KeyCollection KeyCollection = null) {

            var EncryptID = EncryptionAlgorithm.FromJoseID();

            CryptoStack = new CryptoStack(EncryptID, CryptoAlgorithmID.NULL,
                Recipients, Signatures, KeyCollection) {
                    Salt = Salt
                    };
            return CryptoStack.GetDecoder(JSONBCDReader, out Reader);
            }

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
        /// Return the decrypted value of the specified EDSS header.
        /// </summary>
        /// <param name="i">Index of the EDSS entry to decrypt.</param>
        /// <returns>The decrypted data.</returns>
        public byte[] DataSequence(int i) => CryptoStack.Decode(EDSS[i]);

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

    public partial class DARETrailer {

        public DARETrailer() {
            }

        public static DARETrailer GetTrailer(CryptoStackStreamWriter Writer) {
            DARETrailer Result = null;

            if (Writer.DigestValue != null) {
                Result = new DARETrailer() {
                    PayloadDigest = Writer.DigestValue
                    };
                }
            return Result;

            }

        }

    }
