using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
namespace Goedel.Cryptography.Dare {



    /// <summary>
    /// Creates a factory for generating a stack of CryptoStream objects for processing
    /// a stream of data.
    /// </summary>
    public partial class CryptoStack {


        /// <summary>Constant for deriving a MAC key.</summary>
        public static readonly byte[] InfoKeyMAC = "mac".ToBytes();

        /// <summary>Constant for deriving an encryption key.</summary>
        public static readonly byte[] InfoKeyEncrypt = "encrypt".ToBytes();

        /// <summary>Constant for deriving an initialization vector.</summary>
        public static readonly byte[] InfoKeyIV = "iv".ToBytes();


        /// <summary>
        /// The recipient information fields.
        /// </summary>
        public List<DareRecipient> Recipients;

        /// <summary>
        /// The JOSE algorithm identifier for the encryption algorithm.
        /// </summary>
        public string EncryptionAlgorithm = null;

        /// <summary>
        /// The JOSE algorithm identifier for the encryption algorithm.
        /// </summary>
        public string DigestAlgorithm = null;

        /// <summary>
        /// The Keys to be used to sign the message. 
        /// </summary>
        public List<KeyPair> SignerKeys;

        /// <summary>
        /// The base salt value.
        /// </summary>
        public byte[] Salt;

        /// <summary>
        /// The master secret to be used together with the salt data to derive the keys
        /// and initialization vectors for cryptographic operations.
        /// </summary>
        public byte[] MasterSecret;


        /// <summary>
        /// When used to create encryption parameters for a container, specifies the frame
        /// index at which the parameter headers for decrypting the data are to be found.
        /// </summary>
        public int FrameIndex = -1;


        /// <summary>The authentication algorithm to use</summary>
        public CryptoAlgorithmId DigestID {
            get => digestID == CryptoAlgorithmId.Default ? CryptoAlgorithmId.SHA_2_512 : digestID;
            set => digestID = value;
            }
        CryptoAlgorithmId digestID;

        /// <summary>The encryption algorithm to use</summary>
        public CryptoAlgorithmId EncryptID {
            get => encryptID == CryptoAlgorithmId.Default ? CryptoAlgorithmId.AES256CBC : encryptID;
            set => encryptID = value;
            }
        CryptoAlgorithmId encryptID;

        /// <summary>
        /// If true, data is to be encrypted.
        /// </summary>
        public bool Encrypt {
            get => encryptID != CryptoAlgorithmId.NULL;
            set => encryptID = encryptID == CryptoAlgorithmId.NULL ? CryptoAlgorithmId.Default : encryptID;
            }

        /// <summary>
        /// If true, data is to be digested.
        /// </summary>
        public bool Digest {
            get => digestID != CryptoAlgorithmId.NULL;
            set => digestID = digestID == CryptoAlgorithmId.NULL ? CryptoAlgorithmId.Default : digestID;
            }

        int keySize;
        int blockSize;
        int BlockSizeByte => blockSize / 8;

        /// <summary>
        /// Calculate the ciphertext length for a specified plaintext length.
        /// </summary>
        /// <param name="plaintextLength">The input plaintext length.</param>
        /// <returns>The ciphertext length using the current cipher.</returns>
        public long CipherTextLength(long plaintextLength) => EncryptID == CryptoAlgorithmId.NULL ?
            plaintextLength : BlockSizeByte * (1 + (plaintextLength / BlockSizeByte));

        /// <summary>
        /// Create a CryptoStack instance to encode data with the specified cryptographic
        /// parameters.
        /// </summary>
        /// <param name="cryptoParameters">The cryptographic parameters to create the stack from.</param>
        public CryptoStack(
                        CryptoParameters cryptoParameters
                        ) {

            encryptID = cryptoParameters.EncryptID;
            digestID = cryptoParameters.DigestID;

            if (cryptoParameters.EncryptionKeys != null) {
                Salt = Platform.GetRandomBits(128);
                EncryptionAlgorithm = EncryptID.ToJoseID();

                (keySize, blockSize) = EncryptID.GetKeySize();

                (keySize >= 128).AssertTrue(NYI.Throw, "Key size insufficient");

                MasterSecret = Platform.GetRandomBits(keySize);

                Recipients ??= new List<DareRecipient>();
                foreach (var EncryptionKey in cryptoParameters.EncryptionKeys) {
                    MakeRecipient(MasterSecret, EncryptionKey);
                    }

                }

            if (cryptoParameters.SignerKeys != null) {
                SignerKeys = cryptoParameters.SignerKeys;
                DigestAlgorithm = DigestID.ToJoseID();
                }
            }

        /// <summary>
        /// Return a new CryptoStack instance as a child of <paramref name="parent"/>.
        /// The child will incorporate the key exchange data specified in the parent.
        /// </summary>
        /// <param name="parent">The parent CryptoStack</param>
        public CryptoStack(CryptoStack parent) {
            encryptID = parent.encryptID;
            digestID = parent.digestID;

            if (parent.Encrypt) {
                Salt = Platform.GetRandomBits(128);
                EncryptionAlgorithm = EncryptID.ToJoseID();

                (keySize, blockSize) = EncryptID.GetKeySize();
                MasterSecret = parent.MasterSecret;
                }
            }

        /// <summary>
        /// Construct a CryptoStack from a Secret key value.
        /// </summary>
        /// <param name="secret">The secret to use to form the MasterSecret</param>
        /// <param name="encryptID">The encryption algorithm to use.</param>
        public CryptoStack(
                SharedSecret secret,
                CryptoAlgorithmId encryptID = CryptoAlgorithmId.Default) {
            EncryptID = encryptID.DefaultBulk(CryptoAlgorithmId.AES256CBC);
            (keySize, blockSize) = encryptID.GetKeySize();
            MasterSecret = secret.Key;
            Salt = Platform.GetRandomBits(128);
            }


        /// <summary>
        /// Add a recipient.
        /// </summary>
        /// <param name="MasterKey"></param>
        /// <param name="EncryptionKey"></param>
        public virtual void MakeRecipient(byte[] MasterKey, KeyPair EncryptionKey) =>
                Recipients.Add(new DareRecipient(MasterSecret, EncryptionKey));


        /// <summary>
        /// Create a CryptoStack Instance to decode data with the specified cryptographic
        /// parameters.
        /// </summary>
        /// <param name="encryptID">The keyed cryptographic enhancement to be applied to the content.</param>
        /// <param name="digest">The digest algorithm to be applied to the message.</param>
        /// <param name="recipients">The recipient information</param>
        /// <param name="signatures">The message signatures.</param>
        /// <param name="keyCollection">The key collection to be used to resolve private keys.</param>
        /// <param name="decrypt">If true, prepare to decrypt the payload.</param>
        public CryptoStack(
                CryptoAlgorithmId encryptID = CryptoAlgorithmId.NULL,
                CryptoAlgorithmId digest = CryptoAlgorithmId.NULL,
                List<DareRecipient> recipients = null,
                List<DareSignature> signatures = null,
                IKeyLocate keyCollection = null,
                bool decrypt = true
                ) {
            EncryptID = encryptID;
            DigestID = digest;
            (keySize, blockSize) = encryptID.GetKeySize();

            keyCollection ??= KeyCollection.Default;

            if (recipients != null & decrypt) {
                MasterSecret = keyCollection.Decrypt(recipients, encryptID);
                }

            }


        /// <summary>
        /// Calculate key parameters 
        /// </summary>
        /// <param name="thisSalt">The salt value to use</param>
        /// <param name="keyEncrypt">The derrived Encryption key.</param>
        /// <param name="keyMac">The derrived MAC key.</param>
        /// <param name="iv">The derrivedIV.</param>
        protected void CalculateParameters(
                    byte[] thisSalt,
                    out byte[] keyEncrypt,
                    out byte[] keyMac,
                    out byte[] iv
                    ) {
            var KDF = new KeyDeriveHKDF(MasterSecret, thisSalt, CryptoAlgorithmId.HMAC_SHA_2_256);
            keyEncrypt = KDF.Derive(InfoKeyEncrypt, 256);
            keyMac = KDF.Derive(InfoKeyMAC, keySize);
            iv = KDF.Derive(InfoKeyIV, blockSize);
            }



        private void CalculateParameters(
                    bool encrypt,
                    byte[] extraSalt,
                    out ICryptoTransform transformEncrypt,
                    out HashAlgorithm transformMac,
                    out HashAlgorithm transformDigest) {
            transformDigest = DigestID.CreateDigest();
            if (MasterSecret == null) {
                transformMac = null;
                transformEncrypt = null;
                return;
                }
            // The extra salt data is prepended rather than postpended. This ensures that the salt value is changed
            // by the extra salt even if the extra salt value is all zeros.
            var ThisSalt = extraSalt == null ? Salt : extraSalt.Concatenate(Salt);

            CalculateParameters(ThisSalt, out var KeyEncrypt, out var KeyMac, out var IV);

            transformMac = EncryptID.CreateMac(KeyMac);
            transformEncrypt = encrypt ? EncryptID.CreateEncryptor(KeyEncrypt, IV) :
                EncryptID.CreateDecryptor(KeyEncrypt, IV);
            }



        /// <summary>
        /// Construct the trailer value.
        /// </summary>
        /// <param name="writer">The cryptographic stream used to write the payload
        /// data.</param>
        /// <returns>The trailer value.</returns>
        public DareTrailer GetTrailer(CryptoStackStreamWriter writer) {
            DareTrailer Result = null;

            if (writer.DigestValue != null) {
                Result = new DareTrailer() {
                    PayloadDigest = writer.DigestValue
                    };
                }
            //WitnessValue

            var KDF = EncryptID == CryptoAlgorithmId.NULL ? null :
                new KeyDeriveHKDF(MasterSecret, Salt, CryptoAlgorithmId.HMAC_SHA_2_256);

            if (SignerKeys != null) {
                Result ??= new DareTrailer();
                Result.Signatures = new List<DareSignature>();
                foreach (var Key in SignerKeys) {
                    Result.Signatures.Add(new DareSignature(Key, writer.DigestValue, DigestID, KDF));
                    }
                }


            return Result;

            }


        /// <summary>
        /// Construct a stream encoder for the cryptographic parameters. The encoder may
        /// be used in either mode (read/write).
        /// </summary>
        /// <param name="stream">The encoded stream.</param>
        /// <param name="packagingFormat">The packaging format to use.</param>
        /// <param name="contentLength">The content length of the payload data.</param>
        /// <param name="extraSalt">Additional salt material.</param>
        /// <returns>Encoder parameters.</returns>
        public CryptoStackStreamWriter GetEncoder(
                        Stream stream,
                        PackagingFormat packagingFormat,
                        long contentLength = -1,
                        byte[] extraSalt = null
                        ) {
            CalculateParameters(true, extraSalt, out var TransformEncrypt,
                out var TransformMac, out var TransformDigest);

            if (packagingFormat == PackagingFormat.EDS & extraSalt != null) {
                JSONBWriter.WriteBinary(stream, extraSalt);
                }

            CryptoStream CryptoStream = null;


            var PayloadLength = contentLength < 0 ? -1 : CipherTextLength(contentLength);

            var Writer = new CryptoStackStreamWriter(stream, packagingFormat,
                        TransformMac, TransformDigest, PayloadLength);

            if (TransformEncrypt != null) {
                CryptoStream = new CryptoStream(Writer, TransformEncrypt, CryptoStreamMode.Write);
                Writer.Writer = CryptoStream;
                }

            return Writer;
            }

        /// <summary>
        /// Encode a data block
        /// </summary>
        /// <param name="data">The data to encode.</param>
        /// <param name="extraSalt">Additional salt value.</param>
        /// <returns>The encoded data.</returns>
        public byte[] Encode(
                byte[] data,
                byte[] extraSalt = null) {

            using var Input = new MemoryStream(data);
            using var Output = new MemoryStream();

            var EncoderData = GetEncoder(Output, PackagingFormat.EDS,
                        data.LongLength, extraSalt);
            Input.CopyTo(EncoderData.Writer);
            EncoderData.Close();
            Output.Flush();

            return Output.ToArray();
            }

        readonly static byte[] NullArray = new byte[] { };

        /// <summary>
        /// Encode a payload data block
        /// </summary>
        /// <param name="data">The data to encode.</param>
        /// <param name="trailer">Prototype trailer containing the calculated digest value.</param>
        /// <returns>The encoded data.</returns>
        public byte[] Encode(
                    byte[] data,
                    out DareTrailer trailer
                    ) {
            data ??= NullArray;

            using var Input = new MemoryStream(data);
            using var Output = new MemoryStream();

            var EncoderData = GetEncoder(Output, PackagingFormat.Direct, data.LongLength, null);
            Input.CopyTo(EncoderData.Writer);
            EncoderData.Close();
            Output.Flush();
            trailer = GetTrailer(EncoderData);

            return Output.ToArray();
            }


        /// <summary>
        /// Encode a data block as an EDS.
        /// </summary>
        /// <param name="data">The data to encode.</param>
        /// <param name="extraSalt">Additional salt value.</param>
        /// <returns>The encoded data.</returns>
        public byte[] EncodeEDS(
                    byte[] data,
                    byte[] extraSalt = null
                    ) {
            data ??= NullArray;
            using var Input = new MemoryStream(data);
            using var Output = new MemoryStream();
            //var JSONBWriter = new JSONBWriter(Output);
            var EncoderData = GetEncoder(Output, PackagingFormat.EDS, data.LongLength, extraSalt);
            Input.CopyTo(EncoderData.Writer);
            EncoderData.Close();
            Output.Flush();
            //DARETrailer = GetTrailer(EncoderData);

            return Output.ToArray();
            }



        /// <summary>
        /// Construct a stream decoder from the cryptographic data provided. Data is read
        /// from <paramref name="inputStream"/> 
        /// </summary>
        /// <param name="inputStream">The input stream.</param>
        /// <param name="contentLength">The content length if known or -1 if variable length
        /// encoding is to be used.</param>
        /// <param name="outputStream">The stream to read to obtain the decrypted data.</param>
        /// <param name="saltSuffix">Additional value to be added to the beginning of the 
        /// message salt to vary it</param>
        /// <returns>The decoder.</returns>
        public CryptoStackStream GetDecoder(
                        Stream inputStream,
                        out Stream outputStream,
                        long contentLength = -1,
                        byte[] saltSuffix = null
                        ) {


            CalculateParameters(false, saltSuffix, out var TransformEncrypt,
                out var TransformMac, out var TransformDigest);

            var Result = new CryptoStackJBCDStreamReader(inputStream, TransformMac, TransformDigest);
            outputStream = TransformEncrypt == null ? (Stream)Result :
                new CryptoStream(Result, TransformEncrypt, CryptoStreamMode.Read);

            return Result;
            }

        /// <summary>
        /// Construct a stream decoder from the cryptographic data provided.
        /// </summary>
        /// <param name="jsonbcdReader">The stream to decode from.</param>
        /// <param name="contentLength">The content length if known or -1 if variable length
        /// encoding is to be used.</param>
        /// <param name="reader">The stream to read to obtain the decrypted data.</param>
        /// <param name="saltSuffix">Additional value to be added to the end of the 
        /// message salt to vary it</param>
        /// <returns>The decoder.</returns>
        public CryptoStackStream GetDecoder(
                        JsonBcdReader jsonbcdReader,
                        out Stream reader,
                        long contentLength = -1,
                        byte[] saltSuffix = null
                        ) {


            CalculateParameters(false, saltSuffix, out var TransformEncrypt,
                out var TransformMac, out var TransformDigest);

            var Result = new CryptoStackStreamReader(jsonbcdReader, TransformMac, TransformDigest);
            reader = TransformEncrypt == null ? (Stream)Result :
                new CryptoStream(Result, TransformEncrypt, CryptoStreamMode.Read);

            return Result;
            }


        /// <summary>
        /// Decode a data block written as an EDS.
        /// </summary>
        /// <param name="data">The data to encode.</param>
        /// <returns>The decoded data.</returns>
        public byte[] DecodeEDS(byte[] data) {

            using var Input = new JsonBcdReader(data);
            var SaltSuffix = Input.ReadBinary();

            using var Output = new MemoryStream();
            var EncoderData = GetDecoder(Input, out var Reader, data.LongLength, SaltSuffix);
            Reader.CopyTo(Output);
            EncoderData.Close();

            // Check MAC if specified.

            return Output.ToArray();
            }

        /// <summary>
        /// Decode a data block written as an EDS.
        /// </summary>
        /// <param name="data">The data to encode.</param>
        /// <returns>The decoded data.</returns>
        public byte[] DecodeBody(byte[] data) {

            using var Input = new MemoryStream(data);
            using var Output = new MemoryStream();

            var EncoderData = GetDecoder(Input, out var Reader, data.LongLength, null);
            Reader.CopyTo(Output);
            EncoderData.Close();

            // Check MAC if specified.

            return Output.ToArray();
            }

        CryptoProviderDigest DigestProvider {
            get {
                digestProvider ??= CryptoCatalog.Default.GetDigest(DigestID);
                return digestProvider;
                }
            }
        CryptoProviderDigest digestProvider;

        /// <summary>
        /// Get a trailer for an empty payload.
        /// </summary>
        /// <returns>The trailer with a null digest value.</returns>
        public DareTrailer GetNullTrailer() => new DareTrailer() {
            PayloadDigest = DigestProvider.NullDigest
            };

        /// <summary>
        /// Calculate the length of the trailer.
        /// </summary>
        /// <returns></returns>
        public DareTrailer GetDummyTrailer() {
            DareTrailer Result = null;

            var DigestLength = CryptoCatalog.Default.ResultInBytes(DigestID);


            if (DigestLength > 0) {
                Result = new DareTrailer() {
                    PayloadDigest = new byte[DigestLength]
                    };
                }

            return Result;

            }


        /// <summary>
        /// Combine digests to produce the digest for a node.
        /// </summary>
        /// <param name="first">The left hand digest.</param>
        /// <param name="second">The right hand digest.</param>
        /// <returns>The digest value.</returns>
        public byte[] CombineDigest(
                byte[] first,
                byte[] second) {
            var Length = DigestProvider.Size / 8;

            var Buffer = new byte[Length * 2];
            if (first != null) {
                Assert.True(Length == first.Length);
                Array.Copy(first, Buffer, Length);
                }
            if (second != null) {
                Assert.True(Length == second.Length);
                Array.Copy(second, 0, Buffer, Length, Length);
                }


            return DigestProvider.ProcessData(Buffer); ;
            }

        }

    }


