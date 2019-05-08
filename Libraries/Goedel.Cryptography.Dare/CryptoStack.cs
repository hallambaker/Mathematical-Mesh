using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;
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
        public CryptoAlgorithmID DigestID {
            get => digestID == CryptoAlgorithmID.Default ? CryptoAlgorithmID.SHA_2_512 : digestID;
            set => digestID = value;
            }
        CryptoAlgorithmID digestID;

        /// <summary>The encryption algorithm to use</summary>
        public CryptoAlgorithmID EncryptID {
            get => encryptID == CryptoAlgorithmID.Default ? CryptoAlgorithmID.AES256CBC : encryptID;
            set => encryptID = value;
            }
        CryptoAlgorithmID encryptID;

        /// <summary>
        /// If true, data is to be encrypted.
        /// </summary>
        public bool Encrypt {
            get => encryptID != CryptoAlgorithmID.NULL;
            set => encryptID = encryptID == CryptoAlgorithmID.NULL ? CryptoAlgorithmID.Default : encryptID;
            }

        /// <summary>
        /// If true, data is to be digested.
        /// </summary>
        public bool Digest {
            get => digestID != CryptoAlgorithmID.NULL;
            set => digestID = digestID == CryptoAlgorithmID.NULL ? CryptoAlgorithmID.Default : digestID;
            }

        int KeySize;
        int BlockSize;
        int BlockSizeByte => BlockSize / 8;

        /// <summary>
        /// Calculate the ciphertext length for a specified plaintext length.
        /// </summary>
        /// <param name="plaintextLength">The input plaintext length.</param>
        /// <returns>The ciphertext length using the current cipher.</returns>
        public long CipherTextLength(long plaintextLength) => EncryptID == CryptoAlgorithmID.NULL ?
            plaintextLength : BlockSizeByte * (1 + (plaintextLength / BlockSizeByte));

        /// <summary>
        /// Create a CryptoStack instance to encode data with the specified cryptographic
        /// parameters.
        /// </summary>
        public CryptoStack(
                        CryptoParameters cryptoParameters
                        ) {

            encryptID = cryptoParameters.EncryptID;
            digestID = cryptoParameters.DigestID;

            if (cryptoParameters.EncryptionKeys != null) {
                Salt = Platform.GetRandomBits(128);
                EncryptionAlgorithm = EncryptID.ToJoseID();

                (KeySize, BlockSize) = EncryptID.GetKeySize();
                MasterSecret = Platform.GetRandomBits(KeySize);

                Recipients = Recipients ?? new List<DareRecipient>();
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
        /// Return a new CryptoStack instance as a child of <paramref name="Parent"/>.
        /// The child will incorporate the key exchange data specified in the parent.
        /// </summary>
        /// <param name="Parent">The parent CryptoStack</param>
        public CryptoStack(CryptoStack Parent) {
            encryptID = Parent.encryptID;
            digestID = Parent.digestID;

            if (Parent.Encrypt) {
                Salt = Platform.GetRandomBits(128);
                EncryptionAlgorithm = EncryptID.ToJoseID();

                (KeySize, BlockSize) = EncryptID.GetKeySize();
                MasterSecret = Parent.MasterSecret;
                }
            }

        /// <summary>
        /// Construct a CryptoStack from a Secret key value.
        /// </summary>
        /// <param name="secret">The secret to use to form the MasterSecret</param>
        /// <param name="EncryptID">The encryption algorithm to use.</param>
        public CryptoStack(
                Secret secret,
                CryptoAlgorithmID EncryptID = CryptoAlgorithmID.Default) {
            encryptID = EncryptID.DefaultBulk(CryptoAlgorithmID.AES256CBC);
            (KeySize, BlockSize) = EncryptID.GetKeySize();
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
        /// <param name="EncryptID">The keyed cryptographic enhancement to be applied to the content.</param>
        /// <param name="Digest">The digest algorithm to be applied to the message.</param>
        /// <param name="Recipients">The recipient information</param>
        /// <param name="Signatures">The message signatures.</param>
        /// <param name="KeyCollection">The key collection to be used to resolve private keys.</param>
        public CryptoStack(
                CryptoAlgorithmID EncryptID=CryptoAlgorithmID.NULL,
                CryptoAlgorithmID Digest = CryptoAlgorithmID.NULL,
                List<DareRecipient> Recipients = null,
                List<DareSignature> Signatures = null,
                keyCollection KeyCollection = null
                ) {
            this.EncryptID = EncryptID;
            this.DigestID = Digest;
            (KeySize, BlockSize) = EncryptID.GetKeySize();

            KeyCollection = KeyCollection ?? keyCollection.Default;

            if (Recipients != null) {
                MasterSecret = KeyCollection.Decrypt(Recipients, EncryptID);
                }

            }


        /// <summary>
        /// Calculate key parameters 
        /// </summary>
        /// <param name="ThisSalt">The salt value to use</param>
        /// <param name="KeyEncrypt">The derrived Encryption key.</param>
        /// <param name="KeyMac">The derrived MAC key.</param>
        /// <param name="IV">The derrivedIV.</param>
        protected void CalculateParameters(
                    byte[] ThisSalt,
                    out byte[] KeyEncrypt,
                    out byte[] KeyMac,
                    out byte[] IV
                    ) {
            var KDF = new KeyDeriveHKDF(MasterSecret, ThisSalt, CryptoAlgorithmID.HMAC_SHA_2_256);
            KeyEncrypt = KDF.Derive(InfoKeyEncrypt, 256);
            KeyMac = KDF.Derive(InfoKeyMAC, KeySize);
            IV = KDF.Derive(InfoKeyIV, BlockSize);
            }



        private void CalculateParameters(
                    bool Encrypt,
                    byte[] ExtraSalt,
                    out ICryptoTransform TransformEncrypt,
                    out HashAlgorithm TransformMac,
                    out HashAlgorithm TransformDigest) {
            TransformDigest = DigestID.CreateDigest();
            if (MasterSecret == null) {
                TransformMac = null;
                TransformEncrypt = null;
                return;
                }

            // The extra salt data is prepended rather than postpended. This ensures that the salt value is changed
            // by the extra salt even if the extra salt value is all zeros.
            var ThisSalt = ExtraSalt == null ? Salt : ExtraSalt.Concatenate(Salt);


            CalculateParameters (ThisSalt, out var KeyEncrypt, out var KeyMac, out var IV);

            //CalculateParameters(KeySize, BlockSize,
            //    MasterSecret, ThisSalt, out var KeyEncrypt, out var KeyMac, out var IV);

            //var KDF = new KeyDeriveHKDF(MasterSecret, Salt, CryptoAlgorithmID.HMAC_SHA_2_256);
            //var KeyEncrypt = KDF.Derive(InfoKeyEncrypt, 256);
            //var KeyMac = KDF.Derive(InfoKeyMAC, KeySize);
            //var IV = KDF.Derive(InfoKeyIV, BlockSize);
            //Console.WriteLine($"Encryption Session\n   Master {MasterSecret.ToStringBase16()}\n  Salt{Salt.ToStringBase16()}\n  IV  {IV.ToStringBase16()}\n  Key {KeyEncrypt.ToStringBase16()}");



            TransformMac = EncryptID.CreateMac(KeyMac);
            TransformEncrypt = Encrypt ? EncryptID.CreateEncryptor(KeyEncrypt, IV) :
                EncryptID.CreateDecryptor(KeyEncrypt, IV);
            }



        /// <summary>
        /// Construct the trailer value.
        /// </summary>
        /// <param name="Writer">The cryptographic stream used to write the payload
        /// data.</param>
        /// <returns>The trailer value.</returns>
        public DareTrailer GetTrailer(CryptoStackStreamWriter Writer) {
            DareTrailer Result = null;

            if (Writer.DigestValue != null) {
                Result = new DareTrailer() {
                    PayloadDigest = Writer.DigestValue
                    };
                }
            //WitnessValue

            var KDF = EncryptID == CryptoAlgorithmID.NULL ? null : 
                new KeyDeriveHKDF(MasterSecret, Salt, CryptoAlgorithmID.HMAC_SHA_2_256);

            if (SignerKeys != null) {
                Result = Result ?? new DareTrailer();
                Result.Signatures = new List<DareSignature>();
                foreach (var Key in SignerKeys) {
                    Result.Signatures.Add(new DareSignature(Key, Writer.DigestValue, DigestID, KDF));
                    }
                }


            return Result;

            }


        /// <summary>
        /// Construct a stream encoder for the cryptographic parameters. The encoder may
        /// be used in either mode (read/write).
        /// </summary>
        /// <param name="Stream">The encoded stream.</param>
        /// <param name="PackagingFormat">The packaging format to use.</param>
        /// <param name="ContentLength">The content length of the payload data.</param>
        /// <param name="ExtraSalt">Additional salt material.</param>
        /// <returns>Encoder parameters.</returns>
        public CryptoStackStreamWriter GetEncoder(
                        Stream Stream,
                        PackagingFormat PackagingFormat,
                        long ContentLength = -1,
                        byte[] ExtraSalt = null
                        ) {
            CalculateParameters(true, ExtraSalt, out var TransformEncrypt,
                out var TransformMac, out var TransformDigest);

            if (PackagingFormat == PackagingFormat.EDS & ExtraSalt != null) {
                JSONBWriter.WriteBinary(Stream, ExtraSalt);
                }

            CryptoStream CryptoStream = null;


            var PayloadLength = ContentLength < 0 ? -1 : CipherTextLength(ContentLength);

            var Writer = new CryptoStackStreamWriter(Stream, PackagingFormat,
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
        /// <param name="Data">The data to encode.</param>
        /// <param name="ExtraSalt">Additional salt value.</param>
        /// <returns>The encoded data.</returns>
        public byte[] Encode(byte[] Data, byte[] ExtraSalt = null) {

            using (var Input = new MemoryStream(Data)) {
                using (var Output = new MemoryStream()) {
                    //var JSONBWriter = new JSONBWriter(Output);
                    var EncoderData = GetEncoder(Output, PackagingFormat.EDS, 
                                Data.LongLength, ExtraSalt);
                    Input.CopyTo(EncoderData.Writer);
                    EncoderData.Close();
                    Output.Flush();

                    return Output.ToArray();

                    }
                }
            }

        readonly static byte[] NullArray = new byte[] { };

        /// <summary>
        /// Encode a payload data block
        /// </summary>
        /// <param name="Data">The data to encode.</param>
        /// <param name="DARETrailer">Prototype trailer containing the calculated digest value.</param>
        /// <returns>The encoded data.</returns>
        public byte[] Encode(
                    byte[] Data, 
                    out DareTrailer DARETrailer
                    ) {
            Data = Data ?? NullArray;
            using (var Input = new MemoryStream(Data )) {
                using (var Output = new MemoryStream()) {
                    //var JSONBWriter = new JSONBWriter(Output);
                    var EncoderData = GetEncoder(Output, PackagingFormat.Direct, Data.LongLength, null);
                    Input.CopyTo(EncoderData.Writer);
                    EncoderData.Close();
                    Output.Flush();
                    DARETrailer = GetTrailer(EncoderData);

                    return Output.ToArray();

                    }
                }
            }


        /// <summary>
        /// Encode a data block as an EDS.
        /// </summary>
        /// <param name="Data">The data to encode.</param>
        /// <param name="ExtraSalt">Additional salt value.</param>
        /// <returns>The encoded data.</returns>
        public byte[] EncodeEDS(
                    byte[] Data,
                    byte[] ExtraSalt = null
                    ) {
            Data = Data ?? NullArray;
            using (var Input = new MemoryStream(Data)) {
                using (var Output = new MemoryStream()) {
                    //var JSONBWriter = new JSONBWriter(Output);
                    var EncoderData = GetEncoder(Output, PackagingFormat.EDS, Data.LongLength, ExtraSalt);
                    Input.CopyTo(EncoderData.Writer);
                    EncoderData.Close();
                    Output.Flush();
                    //DARETrailer = GetTrailer(EncoderData);

                    return Output.ToArray();

                    }
                }
            }



        /// <summary>
        /// Construct a stream decoder from the cryptographic data provided.
        /// </summary>
        /// <param name="JBCDFrameReader">The stream to decode from.</param>
        /// <param name="ContentLength">The content length if known or -1 if variable length
        /// encoding is to be used.</param>
        /// <param name="Reader">The stream to read to obtain the decrypted data.</param>
        /// <param name="SaltSuffix">Additional value to be added to the end of the 
        /// message salt to vary it</param>
        /// <returns>The decoder.</returns>
        public CryptoStackStream GetDecoder(
                        Stream JBCDFrameReader,
                        out Stream Reader,
                        long ContentLength = -1,
                        byte[] SaltSuffix = null
                        ) {


            CalculateParameters(false, SaltSuffix, out var TransformEncrypt,
                out var TransformMac, out var TransformDigest);

            var Result = new CryptoStackJBCDStreamReader(JBCDFrameReader, TransformMac, TransformDigest);
            Reader = TransformEncrypt == null ? (Stream)Result :
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
                        JSONBCDReader jsonbcdReader,
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

            using (var Input = new JSONBCDReader(data)) {

                var SaltSuffix = Input.ReadBinary();

                using (var Output = new MemoryStream()) {
                    var EncoderData = GetDecoder(Input, out var Reader, data.LongLength, SaltSuffix);
                    Reader.CopyTo(Output);
                    EncoderData.Close();

                    // Check MAC if specified.

                    return Output.ToArray();
                    }
                }
            }

        /// <summary>
        /// Decode a data block written as an EDS.
        /// </summary>
        /// <param name="data">The data to encode.</param>
        /// <returns>The decoded data.</returns>
        public byte[] DecodeBody(byte[] data) {

            using (var Input = new MemoryStream(data)) {

                using (var Output = new MemoryStream()) {
                    var EncoderData = GetDecoder(Input, out var Reader, data.LongLength, null);
                    Reader.CopyTo(Output);
                    EncoderData.Close();

                    // Check MAC if specified.

                    return Output.ToArray();
                    }
                }
            }

        CryptoProviderDigest DigestProvider {
            get {
                _DigestProvider = _DigestProvider ?? CryptoCatalog.Default.GetDigest(DigestID);
                return _DigestProvider;
                }
            }
        CryptoProviderDigest _DigestProvider;


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
        public byte[] CombineDigest(byte[] first, byte[] second) {
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


