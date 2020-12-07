using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

namespace Goedel.Cryptography.Dare {


    public partial class CryptoStackEncode : CryptoStack {
        CryptoParameters CryptoParameters;

        /// <summary>
        /// The Keys to be used to sign the message. 
        /// </summary>
        public override List<CryptoKey> SignerKeys => CryptoParameters.SignerKeys;

        /// <summary>
        /// The base seed provided as a verbatim value or provided through a key exchange to be 
        /// used together with the salt data to derive the keys and initialization data for 
        /// cryptographic operations.
        /// </summary>
        public override byte[] BaseSeed => CryptoParameters.BaseSeed;


        /// <summary>The authentication algorithm to use</summary>
        public override CryptoAlgorithmId DigestId => CryptoParameters.DigestId;


        /// <summary>The encryption algorithm to use</summary>
        public override CryptoAlgorithmId EncryptId => CryptoParameters.EncryptId;

        ///<summary>The block size in bytes.</summary> 
        protected override int BlockSizeByte => CryptoParameters.BlockSizeByte;


        ///<summary>The key size in bits determined by the value of <see cref="EncryptId"/></summary> 
        public override int KeySize => CryptoParameters.KeySize;

        ///<summary>The block size in bits determined by the value of <see cref="EncryptId"/></summary> 
        public override int BlockSize => CryptoParameters.BlockSize;

        /// <summary>
        /// Create a CryptoStack instance to encode data with the specified cryptographic
        /// parameters.
        /// </summary>
        /// <param name="cryptoParameters">The cryptographic parameters to create the stack from.</param>
        /// <param name="header">Header to write the key exchange information to</param>
        /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        ///     as an EDSS header entry.</param>
        public CryptoStackEncode(
                CryptoParameters cryptoParameters,
                DareHeader header,
                byte[] cloaked = null,
                List<byte[]> dataSequences = null) {

            CryptoParameters = cryptoParameters;

            header.CryptoStack = this;

            if (cryptoParameters.Encrypt) {
                header.EncryptionAlgorithm = EncryptId.ToJoseID();

                Salt = Platform.GetRandomBits(128);
                header.Salt = Salt;
                header.KeyIdentifier = GetKeyIdentifier();

                // make this conditional
                cryptoParameters.SetKeyExchange(header);

                long saltValue = 0;
                if (cloaked != null) {
                    header.Cloaked = Encode(cloaked, MakeSalt(saltValue++));
                    }
                if (dataSequences != null) {
                    header.EDSS = new List<byte[]>();
                    foreach (var DataSequence in dataSequences) {
                        header.EDSS.Add(Encode(DataSequence, MakeSalt(saltValue++)));
                        }
                    }
                }

            if (DigestId != CryptoAlgorithmId.NULL) {
                header.DigestAlgorithm = DigestId.ToJoseID();
                }
            }


        }

    public partial class CryptoStackDecode : CryptoStack {

        /// <summary>
        /// The Keys to be used to sign the message. 
        /// </summary>
        public override List<CryptoKey> SignerKeys { get; }


        /// <summary>
        /// The base seed provided as a verbatim value or provided through a key exchange to be 
        /// used together with the salt data to derive the keys and initialization data for 
        /// cryptographic operations.
        /// </summary>
        public override byte[] BaseSeed => baseSeed;
        byte[] baseSeed;

        /// <summary>The authentication algorithm to use</summary>
        public override CryptoAlgorithmId DigestId { get; }
        CryptoAlgorithmId digestId;

        /// <summary>The encryption algorithm to use</summary>
        public override CryptoAlgorithmId EncryptId { get; }

        ///<summary>The block size in bytes.</summary> 
        protected override int BlockSizeByte { get; }

        ///<summary>The key size in bits determined by the value of <see cref="EncryptId"/></summary> 
        public override int KeySize { get; }

        ///<summary>The block size in bits determined by the value of <see cref="EncryptId"/></summary> 
        public override int BlockSize { get; }

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
        public CryptoStackDecode(
                CryptoAlgorithmId encryptID = CryptoAlgorithmId.NULL,
                CryptoAlgorithmId digest = CryptoAlgorithmId.NULL,
                List<DareRecipient> recipients = null,
                List<DareSignature> signatures = null,
                IKeyLocate keyCollection = null,
                bool decrypt = true) {

            throw new NYI();


            EncryptId = encryptID;
            DigestId = digest;
            (KeySize, BlockSize) = encryptID.GetKeySize();

            keyCollection ??= Cryptography.KeyCollection.Default;

            if (recipients != null & decrypt) {
                baseSeed = keyCollection.Decrypt(recipients, encryptID);
                }

            signatures.Future(); // Build a list of the verified signatures??
            }


        }


    /// <summary>
    /// Creates a factory for generating a stack of CryptoStream objects for processing
    /// a stream of data.
    /// </summary>
    public abstract partial class CryptoStack {

        /// <summary>Constant for deriving a MAC key.</summary>
        public static readonly byte[] InfoKeyMac = "mac".ToBytes();

        /// <summary>Constant for deriving an encryption key.</summary>
        public static readonly byte[] InfoKeyEncrypt = "encrypt".ToBytes();

        /// <summary>Constant for deriving an initialization vector.</summary>
        public static readonly byte[] InfoKeyIv = "iv".ToBytes();


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
        /// The base salt value.
        /// </summary>
        public byte[] Salt;


        /// <summary>
        /// The Keys to be used to sign the message. 
        /// </summary>
        public abstract List<CryptoKey> SignerKeys { get; }

        /// <summary>
        /// The base seed provided as a verbatim value or provided through a key exchange to be 
        /// used together with the salt data to derive the keys and initialization data for 
        /// cryptographic operations.
        /// </summary>
        public abstract byte[] BaseSeed { get; }

        /// <summary>The authentication algorithm to use</summary>
        public abstract CryptoAlgorithmId DigestId { get; }

        /// <summary>The encryption algorithm to use</summary>
        public abstract CryptoAlgorithmId EncryptId { get; }

        ///<summary>The key size in bits determined by the value of <see cref="EncryptId"/></summary> 
        public abstract int KeySize { get; }

        ///<summary>The block size in bits determined by the value of <see cref="EncryptId"/></summary> 
        public abstract int BlockSize { get; }



        ///<summary>The block size in bytes.</summary> 
        protected abstract int BlockSizeByte { get; }

        ///<summary>Returns a UDF key identifier for the master secret</summary>
        public string GetKeyIdentifier() => BaseSeed == null ? null : UDF.SymetricKeyId(BaseSeed);


        /// <summary>
        /// Calculate the ciphertext length for a specified plaintext length.
        /// </summary>
        /// <param name="plaintextLength">The input plaintext length.</param>
        /// <returns>The ciphertext length using the current cipher.</returns>
        public long CipherTextLength(long plaintextLength) => EncryptId == CryptoAlgorithmId.NULL
            ? plaintextLength
            : BlockSizeByte * (1 + (plaintextLength / BlockSizeByte));


        /// <summary>
        /// Convert an int64 counter to a unique salt value.
        /// </summary>
        /// <param name="saltValue"></param>
        /// <returns></returns>
        public static byte[] MakeSalt(long saltValue) {
            var salt = saltValue;

            var Index = 0;
            while (salt > 0xFF) {
                Index++;
                salt >>= 8;
                }

            var Result = new byte[Index + 1];

            salt = saltValue;
            Index = 0;
            Result[Index++] = (byte)(salt & 0xFF);
            while (salt > 0xFF) {
                Result[Index++] = (byte)(salt & 0xFF);
                salt >>= 8;
                }
            return Result;

            }


        ///// <summary>
        ///// Apply the specified cryptographic options.
        ///// </summary>
        ///// <param name="cryptoStack">The cryptographic enhancements to apply.</param>
        ///// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
        ///// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
        /////     as an EDSS header entry.</param>
        //public virtual void ApplyCryptoStack(
        //            CryptoStack cryptoStack,
        //            byte[] cloaked = null,
        //            List<byte[]> dataSequences = null) {
        //    this.CryptoStack = cryptoStack;

        //    Salt = cryptoStack.Salt;
        //    Recipients = cryptoStack.Recipients;
        //    EncryptionAlgorithm = cryptoStack.EncryptionAlgorithm;
        //    DigestAlgorithm = cryptoStack.DigestAlgorithm;
        //    KeyIdentifier = cryptoStack.GetKeyIdentifier();

        //    if (cloaked != null) {
        //        this.Cloaked = cryptoStack.Encode(cloaked, MakeSalt());
        //        }
        //    if (dataSequences != null) {
        //        EDSS = new List<byte[]>();
        //        foreach (var DataSequence in dataSequences) {
        //            EDSS.Add(cryptoStack.Encode(DataSequence, MakeSalt()));
        //            }
        //        }

        //    }



        ///*
        // * 
        // * 
        // * This is the wrong way to go about this
        // *
        // * Should create an augmented cryptoparameters and populate from it.
        // * 
        // * This would in turn determine if the Master secret was to be reused etc.
        // * 
        // */

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="policy"></param>
        ///// <param name="digestRequired"></param>

        //public CryptoStack(
        //        DarePolicy policy,
        //        bool digestRequired
        //        ) {

        //    if (policy == null) {
        //        encryptId = CryptoAlgorithmId.NULL;
        //        digestId = digestRequired ? CryptoAlgorithmId.Default : CryptoAlgorithmId.NULL;
        //        return;
        //        }

        //    // process the encryption policy
        //    if (policy.EncryptKeys != null) {
        //        var encryptId = CryptoAlgorithmId.AES256CBC;
        //        if (policy.EncryptionAlgorithm == null) {
        //            EncryptionAlgorithm = encryptId.ToJoseID();
        //            }
        //        else {
        //            encryptId = EncryptionAlgorithm.FromJoseID();
        //            }
        //        SetEncryptId(encryptId);

        //        foreach (var key in policy.EncryptKeys) {
        //            var encryptionKey = key.KeyPair;
        //            MakeRecipient(MasterSecret, encryptionKey);
        //            }
        //        }

        //    // process the signature policy
        //    if (policy.SignKeys != null) {
        //        digestRequired = true;
        //        SignerKeys = new List<CryptoKey>();
        //        foreach (var key in policy.SignKeys) {
        //            var signKey = key.KeyPair;
        //            SignerKeys.Add(signKey);
        //            }

        //        }

        //    digestId = policy.DigestAlgorithm != null ? policy.DigestAlgorithm.FromJoseID() :
        //        (digestRequired ? CryptoAlgorithmId.Default : CryptoAlgorithmId.NULL);

        //    }



        //void SetEncryptId(CryptoAlgorithmId encryptId) {
        //    EncryptId = encryptId;
        //    Salt = Platform.GetRandomBits(128);
        //    (keySize, blockSize) = EncryptId.GetKeySize();
        //    (keySize >= 128).AssertTrue(InsufficientKeySize.Throw, "Key size insufficient");
        //    BaseSeed = Platform.GetRandomBits(keySize);
        //    }


        ///// <summary>
        ///// Create a CryptoParameters instance to encode data for the specified recipients and
        ///// signers using the specified KeyCollection to resolve the identifiers.
        ///// </summary>
        ///// <param name="pin"></param>
        //public CryptoStack(string pin) {
        //    Salt = Platform.GetRandomBits(128);
        //    EncryptionAlgorithm = EncryptId.ToJoseID();

        //    Salt = Platform.GetRandomBits(128);

        //    BaseSeed = UDF.Parse(pin, out var _);

        //    Recipients ??= new List<DareRecipient>();
        //    Recipients.Add(new DareRecipient(BaseSeed));
        //    }

        ///// <summary>
        ///// Construct a CryptoStack from a Secret key value.
        ///// </summary>
        ///// <param name="secret">The secret to use to form the MasterSecret</param>
        ///// <param name="encryptID">The encryption algorithm to use.</param>
        //public CryptoStack(
        //        SharedSecret secret,
        //        CryptoAlgorithmId encryptID = CryptoAlgorithmId.Default) {
        //    EncryptId = encryptID.DefaultBulk(CryptoAlgorithmId.AES256CBC);
        //    (keySize, blockSize) = encryptID.GetKeySize();
        //    BaseSeed = secret.Key;
        //    Salt = Platform.GetRandomBits(128);
        //    }

        ///// <summary>
        ///// Add a recipient.
        ///// </summary>
        ///// <param name="MasterKey"></param>
        ///// <param name="EncryptionKey"></param>
        //public virtual void MakeRecipient(byte[] MasterKey,
        //    CryptoKey EncryptionKey) =>
        //        Recipients.Add(new DareRecipient(BaseSeed, EncryptionKey));




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
            var KDF = new KeyDeriveHKDF(BaseSeed, thisSalt, CryptoAlgorithmId.HMAC_SHA_2_256);
            keyEncrypt = KDF.Derive(InfoKeyEncrypt, 256);
            keyMac = KDF.Derive(InfoKeyMac, KeySize);
            iv = KDF.Derive(InfoKeyIv, BlockSize);
            }


        private void CalculateParameters(
            bool encrypt,
            byte[] extraSalt,
            out ICryptoTransform transformEncrypt,
            out HashAlgorithm transformMac,
            out HashAlgorithm transformDigest) {
            transformDigest = DigestId.CreateDigest();
            if (BaseSeed == null) {
                transformMac = null;
                transformEncrypt = null;
                return;
                }
            // The extra salt data is prepended rather than postpended. This ensures that the salt value is changed
            // by the extra salt even if the extra salt value is all zeros.
            var ThisSalt = extraSalt == null ? Salt : extraSalt.Concatenate(Salt);

            CalculateParameters(ThisSalt, out var KeyEncrypt, out var KeyMac, out var IV);

            transformMac = EncryptId.CreateMac(KeyMac);
            transformEncrypt = encrypt
                ? EncryptId.CreateEncryptor(KeyEncrypt, IV)
                : EncryptId.CreateDecryptor(KeyEncrypt, IV);
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

            var KDF = EncryptId == CryptoAlgorithmId.NULL
                ? null
                : new KeyDeriveHKDF(BaseSeed, Salt, CryptoAlgorithmId.HMAC_SHA_2_256);

            if (SignerKeys != null) {
                Result ??= new DareTrailer();
                Result.Signatures = new List<DareSignature>();
                foreach (var Key in SignerKeys) {
                    Result.Signatures.Add(new DareSignature(Key, writer.DigestValue, DigestId, KDF));
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
            CalculateParameters(
                true, extraSalt, out var transformEncrypt,
                out var transformMac, out var transformDigest);

            if (packagingFormat == PackagingFormat.EDS & extraSalt != null) {
                JSONBWriter.WriteBinary(stream, extraSalt);
                }



            var payloadLength = contentLength < 0 ? -1 : CipherTextLength(contentLength);

            var writer = new CryptoStackStreamWriter(
                stream, packagingFormat,
                transformMac, transformDigest, payloadLength);

            if (transformEncrypt != null) {
                writer.Writer = new CryptoStream(writer, transformEncrypt, CryptoStreamMode.Write);
                }

            return writer;
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
            using var input = new MemoryStream(data);
            using var output = new MemoryStream();

            var encoderData = GetEncoder(
                output, PackagingFormat.EDS,
                data.LongLength, extraSalt);
            input.CopyTo(encoderData.Writer);
            encoderData.Close();
            output.Flush();

            return output.ToArray();
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

            using var input = new MemoryStream(data);
            using var output = new MemoryStream();

            var EncoderData = GetEncoder(output, PackagingFormat.Direct, data.LongLength, null);
            input.CopyTo(EncoderData.Writer);
            EncoderData.Close();
            output.Flush();
            trailer = GetTrailer(EncoderData);


            return output.ToArray();
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
            using var input = new MemoryStream(data);
            using var output = new MemoryStream();
            //var JSONBWriter = new JSONBWriter(Output);
            var encoderData = GetEncoder(output, PackagingFormat.EDS, data.LongLength, extraSalt);
            input.CopyTo(encoderData.Writer);
            encoderData.Close();
            output.Flush();
            //DARETrailer = GetTrailer(EncoderData);

            return output.ToArray();
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
                byte[] saltSuffix = null) {
            contentLength.Future();

            CalculateParameters(
                false, saltSuffix, out var TransformEncrypt,
                out var TransformMac, out var TransformDigest);

            var result = new CryptoStackJBCDStreamReader(inputStream, TransformMac, TransformDigest);
            outputStream = TransformEncrypt == null
                ? (Stream)result
                : new CryptoStream(result, TransformEncrypt, CryptoStreamMode.Read);

            return result;
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
        /// <param name="decrypt">If true, attempt decryption and throw an exception if
        /// this fails.</param>
        /// <returns>The decoder.</returns>
        public CryptoStackStream GetDecoder(
                JsonBcdReader jsonbcdReader,
                out Stream reader,
                long contentLength = -1,
                byte[] saltSuffix = null,
                bool decrypt = true) {

            contentLength.Future();
            decrypt.Future();

            CalculateParameters(
                false, saltSuffix, out var TransformEncrypt,
                out var TransformMac, out var TransformDigest);

            var result = new CryptoStackStreamReader(jsonbcdReader, TransformMac, TransformDigest);

            //// Create the stack.
            //reader = TransformDigest == null ? (Stream)Result :
            //    new CryptoStream(Result, TransformDigest, CryptoStreamMode.Read);
            //reader = TransformMac == null ? reader :
            //    new CryptoStream(Result, TransformMac, CryptoStreamMode.Read);


            reader = TransformEncrypt == null
                ? (Stream)result
                : new CryptoStream(result, TransformEncrypt, CryptoStreamMode.Read);

            return result;
            }


        /// <summary>
        /// Decode a data block written as an EDS.
        /// </summary>
        /// <param name="data">The data to encode.</param>
        /// <returns>The decoded data.</returns>
        public byte[] DecodeEDS(byte[] data) {
            using var input = new JsonBcdReader(data);
            var saltSuffix = input.ReadBinary();

            using var output = new MemoryStream();
            var encoderData = GetDecoder(input, out var Reader, data.LongLength, saltSuffix);
            Reader.CopyTo(output);
            encoderData.Close();

            // Check MAC if specified.

            return output.ToArray();
            }

        /// <summary>
        /// Decode a data block written as an EDS.
        /// </summary>
        /// <param name="data">The data to encode.</param>
        /// <returns>The decoded data.</returns>
        public byte[] DecodeBody(byte[] data) {
            using var input = new MemoryStream(data);
            using var output = new MemoryStream();

            var EncoderData = GetDecoder(input, out var Reader, data.LongLength, null);
            Reader.CopyTo(output);
            EncoderData.Close();

            // Check MAC if specified.

            return output.ToArray();
            }

        CryptoProviderDigest DigestProvider {
            get {
                digestProvider ??= CryptoCatalog.Default.GetDigest(DigestId);
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
            DareTrailer result = null;

            var digestLength = CryptoCatalog.Default.ResultInBytes(DigestId);


            if (digestLength > 0) {
                result = new DareTrailer() {
                    PayloadDigest = new byte[digestLength]
                    };
                }

            return result;
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
            var length = DigestProvider.Size / 8;

            var buffer = new byte[length * 2];
            if (first != null) {
                Assert.AssertTrue(
                    length == first.Length,
                    CryptographicException.Throw);
                Array.Copy(first, buffer, length);
                }
            if (second != null) {
                Assert.AssertTrue(
                    length == second.Length,
                    CryptographicException.Throw);
                Array.Copy(second, 0, buffer, length, length);
                }


            return DigestProvider.ProcessData(buffer);
            ;
            }
        }
    }