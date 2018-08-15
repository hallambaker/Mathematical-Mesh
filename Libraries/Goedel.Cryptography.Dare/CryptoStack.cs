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
        public List<DARERecipient> Recipients;

        /// <summary>
        /// The JOSE algorithm identifier for the encryption algorithm.
        /// </summary>
        public string EncryptionAlgorithm = null;


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

        CryptoAlgorithmID EncryptID;
        CryptoAlgorithmID DigestID;
        CryptoAlgorithmID SignID;
        int KeySize;
        int BlockSize;
        int BlockSizeByte => BlockSize / 8;

        /// <summary>
        /// Calculate the ciphertext length for a specified plaintext length.
        /// </summary>
        /// <param name="PlaintextLength">The input plaintext length.</param>
        /// <returns>The ciphertext length using the current cipher.</returns>
        public long CipherTextLength(long PlaintextLength) => EncryptID == CryptoAlgorithmID.NULL ?
            PlaintextLength : BlockSizeByte * (1 + (PlaintextLength / BlockSizeByte));

        /// <summary>
        /// Create a CryptoStack instance to encode data with the specified cryptographic
        /// parameters.
        /// </summary>
        public CryptoStack(
            CryptoParameters CryptoParameters
                        ) {

            EncryptID = CryptoParameters.EncryptID;
            DigestID = CryptoParameters.DigestID;

            if (CryptoParameters.EncryptionKeys != null) {
                Salt = Platform.GetRandomBits(128);
                EncryptionAlgorithm = EncryptID.ToJoseID();

                (KeySize, BlockSize) = EncryptID.GetKeySize();
                MasterSecret = Platform.GetRandomBits(KeySize);

                Recipients = Recipients ?? new List<DARERecipient>();
                foreach (var EncryptionKey in CryptoParameters.EncryptionKeys) {
                    Recipients.Add(new DARERecipient(MasterSecret, EncryptionKey));
                    }

                }

            DigestID = CryptoParameters.DigestID;

            if (SignerKeys != null) {
                SignerKeys = CryptoParameters.SignerKeys;
                }
            }

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
                List<DARERecipient> Recipients = null,
                List<DARESignature> Signatures = null,
                KeyCollection KeyCollection = null
                ) {
            this.EncryptID = EncryptID;
            this.DigestID = Digest;
            (KeySize, BlockSize) = EncryptID.GetKeySize();

            KeyCollection = KeyCollection ?? KeyCollection.Default;

            if (Recipients != null) {
                MasterSecret = KeyCollection.Decrypt(Recipients, EncryptID);
                }

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

            //CalculateParameters(KeySize, BlockSize,
            //    MasterSecret, ThisSalt, out var KeyEncrypt, out var KeyMac, out var IV);

            var KDF = new KeyDeriveHKDF(MasterSecret, Salt, CryptoAlgorithmID.HMAC_SHA_2_256);
            var KeyEncrypt = KDF.Derive(InfoKeyEncrypt, 256);
            var KeyMac = KDF.Derive(InfoKeyMAC, KeySize);
            var IV = KDF.Derive(InfoKeyIV, BlockSize);
            Console.WriteLine($"Encryption Session\n   Master {MasterSecret.ToStringBase16()}\n  Salt{Salt.ToStringBase16()}\n  IV  {IV.ToStringBase16()}\n  Key {KeyEncrypt.ToStringBase16()}");



            TransformMac = EncryptID.CreateMac(KeyMac);
            TransformEncrypt = Encrypt ? EncryptID.CreateEncryptor(KeyEncrypt, IV) :
                EncryptID.CreateDecryptor(KeyEncrypt, IV);
            }




        public DARETrailer GetTrailer(CryptoStackStreamWriter Writer) {
            DARETrailer Result = null;

            if (Writer.DigestValue != null) {
                Result = new DARETrailer() {
                    PayloadDigest = Writer.DigestValue
                    };
                }

            if (SignerKeys != null) {
                Result = Result ?? new DARETrailer();
                Result.Signatures = new List<DARESignature>();
                foreach (var Key in SignerKeys) {
                    Result.Signatures.Add(new DARESignature(Key, Writer.DigestValue, DigestID));
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
        /// Encode a data block
        /// </summary>
        /// <param name="Data">The data to encode.</param>
        /// <param name="PackagingFormat">The packaging format to use.</param>
        /// <param name="ExtraSalt">Additional salt value.</param>
        /// <returns>The encoded data.</returns>
        public byte[] Encode(byte[] Data, out DARETrailer DARETrailer,
                    byte[] ExtraSalt = null,
                    PackagingFormat PackagingFormat = PackagingFormat.EDS
                    
                    ) {
            Data = Data ?? NullArray;
            using (var Input = new MemoryStream(Data )) {
                using (var Output = new MemoryStream()) {
                    //var JSONBWriter = new JSONBWriter(Output);
                    var EncoderData = GetEncoder(Output, PackagingFormat, Data.LongLength, ExtraSalt);
                    Input.CopyTo(EncoderData.Writer);
                    EncoderData.Close();
                    Output.Flush();
                    DARETrailer = GetTrailer(EncoderData);

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
        /// <param name="JSONBCDReader">The stream to decode from.</param>
        /// <param name="ContentLength">The content length if known or -1 if variable length
        /// encoding is to be used.</param>
        /// <param name="Reader">The stream to read to obtain the decrypted data.</param>
        /// <param name="SaltSuffix">Additional value to be added to the end of the 
        /// message salt to vary it</param>
        /// <returns>The decoder.</returns>
        public CryptoStackStream GetDecoder(
                        JSONBCDReader JSONBCDReader,
                        out Stream Reader,
                        long ContentLength = -1,
                        byte[] SaltSuffix = null
                        ) {


            CalculateParameters(false, SaltSuffix, out var TransformEncrypt,
                out var TransformMac, out var TransformDigest);

            var Result = new CryptoStackStreamReader(JSONBCDReader, TransformMac, TransformDigest);
            Reader = TransformEncrypt == null ? (Stream)Result :
                new CryptoStream(Result, TransformEncrypt, CryptoStreamMode.Read);

            return Result;
            }


        /// <summary>
        /// Decode a data block written as an EDS.
        /// </summary>
        /// <param name="Data">The data to encode.</param>
        /// <returns>The decoded data.</returns>
        public byte[] Decode(byte[] Data) {

            using (var Input = new JSONBCDReader(Data)) {

                var SaltSuffix = Input.ReadBinary();

                using (var Output = new MemoryStream()) {
                    var EncoderData = GetDecoder(Input, out var Reader, Data.LongLength, SaltSuffix);
                    Reader.CopyTo(Output);
                    EncoderData.Close();

                    // Check MAC if specified.

                    return Output.ToArray();
                    }
                }
            }


        }


    }
