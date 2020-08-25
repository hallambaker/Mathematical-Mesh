using Goedel.Cryptography.Jose;
using Goedel.Protocol;

using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Goedel.Cryptography.Dare {

    // Feature: Support encryption algorithms other than AES256 by including the algorithmID in the header

    public partial class DareHeader {

        byte[] masterSecret;
        long saltValue = 0;


        /// <summary>
        /// Calculate the expected payload length for the specified <paramref name="contentLength"/>.
        /// </summary>
        /// <param name="contentLength">The unencrypted content length.</param>
        /// <returns>The corresponding payload length.</returns>
        public long OutputLength(long contentLength) =>
            CryptoStack == null ? contentLength : CryptoStack.CipherTextLength(contentLength);

        /// <summary>
        /// If true, the header specifies a key exchange.
        /// </summary>
        public bool Encrypt => EncryptionAlgorithm != null;

        /// <summary>
        /// Threadsafe assignment of unique salt under this master secret.
        /// </summary>
        /// <returns></returns>
        /// <threadsafety static="true" instance="true"/>
        public byte[] MakeSalt() {
            if (saltValue >= 0) {

                var Salt = Interlocked.Increment(ref saltValue);
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

        //public override string ToString() => "{Header}";

        ///<summary>The content Metadata.</summary>
        public ContentMeta ContentMeta;

        ///<summary>The content type.</summary>
        public string ContentType => ContentMeta?.ContentType;

        ///<summary>Routine called before serialization.</summary>
        public override void PreEncode() {
            if (ContentMeta != null) {
                ContentMetaData = ContentMeta.GetContentMetaData();
                }
            }

        ///<summary>Routine called after serialization.</summary>
        public override void PostDecode() =>
            ContentMeta = ContentMeta.GetContentInfo(ContentMetaData);


        /// <summary>
        /// Create a message header.
        /// </summary>
        public DareHeader() {
            }

        /// <summary>
        /// Create a message header.
        /// </summary>
        /// <param name="cryptoStack">The cryptographic enhancements to apply.</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public DareHeader(
                    CryptoStack cryptoStack,
                    ContentMeta contentMeta = null,
                    byte[] cloaked = null,
                    List<byte[]> dataSequences = null
                    ) {
            ContentMeta = contentMeta;
            ApplyCryptoStack(cryptoStack, cloaked, dataSequences);
            }

        /// <summary>
        /// Apply the specified cryptographic options.
        /// </summary>
        /// <param name="cryptoStack">The cryptographic enhancements to apply.</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public virtual void ApplyCryptoStack(
                    CryptoStack cryptoStack,
                    byte[] cloaked = null,
                    List<byte[]> dataSequences = null) {
            this.CryptoStack = cryptoStack;

            Salt = cryptoStack.Salt;
            Recipients = cryptoStack.Recipients;
            EncryptionAlgorithm = cryptoStack.EncryptionAlgorithm;
            DigestAlgorithm = cryptoStack.DigestAlgorithm;
            KeyIdentifier = cryptoStack.GetKeyIdentifier();

            if (cloaked != null) {
                this.Cloaked = cryptoStack.Encode(cloaked, MakeSalt());
                }
            if (dataSequences != null) {
                EDSS = new List<byte[]>();
                foreach (var DataSequence in dataSequences) {
                    EDSS.Add(cryptoStack.Encode(DataSequence, MakeSalt()));
                    }
                }

            }


        /// <summary>
        /// Use information from the specified header to speficy defaults.
        /// </summary>
        /// <param name="DAREHeader"></param>
        public virtual void SetDefaultContext(DareHeader DAREHeader) {
            saltValue = -1;
            masterSecret = DAREHeader.masterSecret;

            }

        #region // Consider moving this functionality out to ContextWrite

        CryptoStackStreamWriter currentBodyWriter = null;

        /// <summary>
        /// Construct a stream that will write the body data with whatever crypto stream
        /// modules are required.
        /// </summary>
        /// <param name="output">The ultimate output stream.</param>
        /// <returns></returns>
        public Stream BodyWriter(Stream output) {
            if (CryptoStack == null) {
                return output;
                }
            currentBodyWriter = CryptoStack.GetEncoder(output, PackagingFormat.Direct);
            return currentBodyWriter.Writer;
            }

        /// <summary>
        /// Close the body writer stack and free all associated resources.
        /// </summary>
        public void CloseBodyWriter(out DareTrailer dareTrailer) {
            currentBodyWriter.Close();
            dareTrailer = GetTrailer(currentBodyWriter);
            currentBodyWriter?.Dispose();
            currentBodyWriter = null;
            }


        #endregion

        /// <summary>
        /// Return a binary EDS sequence of the specified plaintext under this header. A
        /// unique salt will be assigned.
        /// </summary>
        /// <param name="Plaintext">The EDS plaintext.</param>
        /// <param name="dareTrailer">Prototype trailer containing the calculated digest value.</param>
        /// <returns>The EDS</returns>
        public byte[] EnhanceBody(byte[] Plaintext, out DareTrailer dareTrailer) =>
            CryptoStack.Encode(Plaintext, out dareTrailer);


        /// <summary>
        /// Convert an int64 counter to a unique salt value.
        /// </summary>
        /// <param name="saltValue"></param>
        /// <returns></returns>
        public static byte[] MakeSalt(long saltValue) {
            var Salt = saltValue;

            var Index = 0;
            while (Salt > 0xFF) {
                Index++;
                Salt >>= 8;
                }

            var Result = new byte[Index + 1];

            Salt = saltValue;
            Index = 0;
            Result[Index++] = (byte)(Salt & 0xFF);
            while (Salt > 0xFF) {
                Result[Index++] = (byte)(Salt & 0xFF);
                Salt >>= 8;
                }
            return Result;

            }

        CryptoAlgorithmId encryptId;



        /// <summary>
        /// Return a decoder for the specified data source.
        /// </summary>
        /// <param name="stream">The data source.</param>
        /// <param name="reader">The stream to read the decoded data from.</param>
        /// <param name="keyCollection">Key collection to be used to resolve private
        /// keys.</param>
        /// <returns>The decoder. </returns>
        public CryptoStackStream GetDecoder(
                        Stream stream,
                        out Stream reader,
                       IKeyLocate keyCollection = null) {

            var EncryptID = EncryptionAlgorithm.FromJoseID();

            CryptoStack = new CryptoStack(EncryptID, CryptoAlgorithmId.NULL,
                Recipients, Signatures, keyCollection) {
                Salt = Salt
                };
            return CryptoStack.GetDecoder(stream, out reader);

            }


        /// <summary>
        /// Return a CryptoStack using key exchange information specified in this 
        /// header.
        /// </summary>
        /// <returns>The created CryptoStack</returns>
        public CryptoStack GetCryptoStack(IKeyLocate keyCollection, bool decrypt = true) {
            var EncryptID = EncryptionAlgorithm.FromJoseID();
            var DigestID = DigestAlgorithm.FromJoseID();

            var CryptoStack = new CryptoStack(EncryptID, DigestID,
                Recipients, Signatures, keyCollection, decrypt: decrypt) {
                Salt = Salt

                };
            return CryptoStack;
            }

        /// <summary>
        /// Return a decoder for the specified data source.
        /// </summary>
        /// <param name="jsonBcdReader">The data source.</param>
        /// <param name="reader">The stream to read the decoded data from.</param>
        /// <param name="keyCollection">Key collection to be used to resolve private
        /// keys.</param>
        /// <returns>The decoder. </returns>
        public CryptoStackStream GetDecoder(
                        JsonBcdReader jsonBcdReader,
                        out Stream reader,
                       IKeyLocate keyCollection = null) {
            CryptoStack = GetCryptoStack(keyCollection);

            return CryptoStack.GetDecoder(jsonBcdReader, out reader);
            }

        /// <summary>
        /// Attempt decryption of the master key by matching a recipient entry to the 
        /// keys in the specified key collection.
        /// </summary>
        /// <param name="keyCollection">The key collection to use or the default collection
        /// if null.</param>
        public void DecryptMaster(IKeyLocate keyCollection) {
            encryptId = EncryptionAlgorithm.FromJoseID();
            masterSecret = keyCollection.Decrypt(Recipients, encryptId);
            }

        /// <summary>
        /// Return the decrypted value of the specified EDSS header.
        /// </summary>
        /// <param name="i">Index of the EDSS entry to decrypt.</param>
        /// <returns>The decrypted data.</returns>
        public byte[] DataSequence(int i) => CryptoStack.DecodeEDS(EDSS[i]);

        }

    /// <summary>
    /// Extensions classes.
    /// </summary>
    public static class Extensions {
        /// <summary>
        /// Attempt to decrypt a decryption blob from a list of recipient entries.
        /// </summary>
        /// <param name="keyCollection">The key collection to be used to resolve keys.</param>
        /// <param name="recipients">The recipient entry.</param>
        /// <param name="algorithmID">The symmetric encryption cipher (used to decrypt the wrapped key).</param>
        /// <returns></returns>
        public static byte[] Decrypt(this IKeyLocate keyCollection,
                    List<DareRecipient> recipients,
                    CryptoAlgorithmId algorithmID) {
            foreach (var recipient in recipients) {

                var decryptionKey = keyCollection.TryFindKeyDecryption(recipient.KeyIdentifier);

                // Recipient has the following fields of interest
                // Recipient.EncryptedKey -- The RFC3394 wrapped symmetric key
                // Recipient.Header.Epk  -- The ephemeral public key
                // Recipient.Header.Epk.KeyPair  -- The ephemeral public key

                if (decryptionKey != null) {
                    return decryptionKey.Decrypt(
                            recipient.WrappedMasterKey, recipient.Epk?.KeyPair,
                            algorithmID: algorithmID, null);
                    }
                }

            // Could not find any decryption key.
            throw new NoAvailableDecryptionKey();
            }
        }

    public partial class DareTrailer {

        /// <summary>
        /// Default constructor used for deserialization.
        /// </summary>
        public DareTrailer() {
            }

        /// <summary>
        /// Prototype trailer containing the  digest value calculated by <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">The crypto stream used to transform the payload.</param>
        /// <returns>The prototype trailer.</returns>
        public static DareTrailer GetTrailer(CryptoStackStreamWriter writer) {
            DareTrailer Result = null;

            if (writer.DigestValue != null) {
                Result = new DareTrailer() {
                    PayloadDigest = writer.DigestValue
                    };
                }
            return Result;

            }

        }



    public partial class ContentMeta {
        const bool TagData = false;

        /// <summary>
        /// Encode the content metadata bytes.
        /// </summary>
        /// <returns>The serialized content metadata.</returns>
        public byte[] GetContentMetaData() => GetBytes(TagData);

        /// <summary>
        /// Decode the content metadata bytes
        /// </summary>
        /// <param name="data">The data to decode.</param>
        /// <returns>The decoded data.</returns>
        public static ContentMeta GetContentInfo(byte[] data) =>
            data == null ? null : FromJson(data.JsonReader(), TagData);

        }

    }
