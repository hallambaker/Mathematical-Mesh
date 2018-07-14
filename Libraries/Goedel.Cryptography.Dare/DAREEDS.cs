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

    /// <summary>
    /// Create an Enhanced Data Sequence.
    /// </summary>
    public abstract class EnhancedDataSequence : IDisposable {

        /// <summary>Constant for deriving a MAC key.</summary>
        public static readonly byte[] InfoKeyMAC = "mac".ToBytes();

        /// <summary>Constant for deriving an encryption key.</summary>
        public static readonly byte[] InfoKeyEncrypt = "encrypt".ToBytes();

        /// <summary>Constant for deriving an initialization vector.</summary>
        public static readonly byte[] InfoKeyIV = "iv".ToBytes();

        /// <summary>The Initialization Vector</summary>
        protected byte[] IV { get; private set; }

        /// <summary>The Encryption Key</summary>
        protected byte[] KeyEncrypt { get; private set; }

        /// <summary>The Initialization Vector</summary>
        protected byte[] KeyMac { get; private set; }

        /// <summary>The computed length of the message payload. This is only known if the
        /// message content or content length was specified when the object instance was created.
        /// That is, the length of the ciphertext, padding and authentication tag (if present)
        /// but not the token specifying the payload length.</summary>
        public long PayloadLength { get; protected set; } = -1;



        /// <summary>
        /// The encryption transform.
        /// </summary>
        protected ICryptoTransform EncryptionTransform = null;
        

        /// <summary>
        /// Create a new EnhancedDataSequence with no cryptographic parameters.
        /// </summary>
        public EnhancedDataSequence(
                    ) {
            }

        /// <summary>
        /// Create a new EnhancedDataSequence with the specified cryptographic parameters.
        /// </summary>
        /// <param name="ProviderEncrypt">Crypto algorithm provider</param>
        /// <param name="MasterSecret">The Master Secret</param>
        /// <param name="Salt">The salt used to derive keys from the Master Secret.</param>
        /// <param name="Encrypt">If true, set parameters for encryption.</param>
        public EnhancedDataSequence(
                CryptoProviderEncryption ProviderEncrypt,
                byte[] MasterSecret,
                bool Encrypt,
                byte[] Salt = null
                ) => SetParameters(ProviderEncrypt, MasterSecret, Encrypt, Salt);

        /// <summary>
        /// Set the cryptographic parameters for the encryption context.
        /// </summary>
        /// <param name="ProviderEncrypt"></param>
        /// <param name="MasterSecret"></param>
        /// <param name="Salt"></param>
        /// <param name="Encrypt">If true, set parameters for encryption.</param>
        protected void SetParameters(
                CryptoProviderEncryption ProviderEncrypt,
                byte[] MasterSecret,
                bool Encrypt,
                byte[] Salt) {

            if (ProviderEncrypt == null) {
                return;
                }

            CalculateParameters(ProviderEncrypt, MasterSecret, Salt,
                    out var _KeyEncrypt, out var _KeyMac, out var _IV);
            KeyEncrypt = _KeyEncrypt;
            KeyMac = _KeyMac;
            IV = _IV;
            // Hack
            //EncryptionTransform = Encrypt ? ProviderEncrypt?.CreateEncryptor(KeyEncrypt, IV) :
            //    ProviderEncrypt?.CreateDecryptor(KeyEncrypt, IV);

            var Provider = Aes.Create();
            Provider.Mode = CipherMode.CBC;
            Provider.Padding = PaddingMode.PKCS7;

            EncryptionTransform = Encrypt ? Provider.CreateEncryptor(KeyEncrypt, IV) :
                 Provider.CreateDecryptor(KeyEncrypt, IV);

            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProviderEncrypt"></param>
        /// <param name="MasterSecret"></param>
        /// <param name="Salt"></param>
        /// <param name="KeyEncrypt"></param>
        /// <param name="KeyMac"></param>
        /// <param name="IV"></param>
        public static void CalculateParameters(
                CryptoProviderEncryption ProviderEncrypt, byte[] MasterSecret, byte[] Salt,
                out byte[] KeyEncrypt, out byte[] KeyMac, out byte[] IV) =>
            CalculateParameters (ProviderEncrypt.KeySize, ProviderEncrypt.BlockSize,
                MasterSecret, Salt, out KeyEncrypt, out KeyMac, out IV) ;
            

        /// <summary>
        /// 
        /// </summary>
        /// <param name="KeySize"></param>
        /// <param name="BlockSize"></param>
        /// <param name="MasterSecret"></param>
        /// <param name="Salt"></param>
        /// <param name="KeyEncrypt"></param>
        /// <param name="KeyMac"></param>
        /// <param name="IV"></param>
        public static void CalculateParameters(
                int KeySize, int BlockSize, byte[] MasterSecret, byte[] Salt,
                out byte[] KeyEncrypt, out byte[] KeyMac, out byte[] IV) {

            var KDF = new KeyDeriveHKDF(MasterSecret, Salt, CryptoAlgorithmID.HMAC_SHA_2_256);
            KeyEncrypt = KDF.Derive(InfoKeyEncrypt, 256);
            KeyMac = KDF.Derive(InfoKeyMAC, KeySize);
            IV = KDF.Derive(InfoKeyIV, BlockSize);
            Console.WriteLine($"Encryption Session\n   Master {MasterSecret.ToStringBase16()}\n  Salt{Salt.ToStringBase16()}\n  IV  {IV.ToStringBase16()}\n  Key {KeyEncrypt.ToStringBase16()}");
            }

        /// <summary>
        /// Create a .NET CryptoStream for the specified parameters.
        /// </summary>
        /// <param name="Stream">The stream to bind.</param>
        /// <param name="ProviderEncrypt">The encryption provider.</param>
        /// <param name="MasterSecret">The master secret value.</param>
        /// <param name="Salt">The salt value to be used to derrive the specififc parameters.</param>
        /// <param name="Write">If true, this is a write stream and the <paramref name="Stream"/> is 
        /// only written to. Otherwise, it is a read stream and only read operations are
        /// performed.</param>
        /// <param name="Encrypt">If true, create an encryption stream, otherwise
        /// create a decryption stream.</param>
        /// <returns>The CryptoStream that was created.</returns>
        public static CryptoStream GetCryptoStream(
                Stream Stream, 
                CryptoProviderEncryption ProviderEncrypt,
                byte[] MasterSecret,
                byte[] Salt,
                bool Write,
                bool Encrypt) {
            CalculateParameters(ProviderEncrypt, MasterSecret, Salt,
                    out var KeyEncrypt, out var KeyMac, out var IV);
            var Mode = Write ? CryptoStreamMode.Write : CryptoStreamMode.Read;
            return Encrypt ? ProviderEncrypt.GetEncryptionStream(Stream, KeyEncrypt, IV, Mode) :
                ProviderEncrypt.GetDecryptionStream(Stream, KeyEncrypt, IV, Mode);
            }


        /// <summary>
        /// Encrypt an array of bytes using the specified crypto provider, key and salt.
        /// </summary>
        /// <param name="ProviderEncrypt">The encryption provider to use</param>
        /// <param name="MasterSecret">The master secret from which the key and IV are derived.</param>
        /// <param name="Salt">The salt value</param>
        /// <param name="Data">The data to encrypt.</param>
        /// <returns>The encrypted data without any additional padding beyond that required by the
        /// encryption mode.</returns>
        public static byte[] Encrypt(
                CryptoProviderEncryption ProviderEncrypt,
                byte[] MasterSecret,
                byte[] Salt,
                byte[] Data) {
            CalculateParameters(ProviderEncrypt, MasterSecret, Salt,
                    out var KeyEncrypt, out var _KeyMac, out var IV);
            return ProviderEncrypt.Encrypt(Data, KeyEncrypt, IV);
            }

        /// <summary>
        /// Encrypt an array of bytes using the specified crypto provider, key and salt.
        /// </summary>
        /// <param name="Output">The stream to which the output is to be written</param>
        /// <param name="ProviderEncrypt">The encryption provider to use</param>
        /// <param name="MasterSecret">The master secret from which the key and IV are derived.</param>
        /// <param name="Salt">The salt value</param>
        /// <returns>The encrypted data without any additional padding beyond that required by the
        /// encryption mode.</returns>
        public static CryptoStream GetEncryptor (
                Stream Output,
                CryptoProviderEncryption ProviderEncrypt,
                byte[] MasterSecret,
                byte[] Salt) {
            CalculateParameters(ProviderEncrypt, MasterSecret, Salt,
                    out var KeyEncrypt, out var _KeyMac, out var IV);
            var EncryptionTransform = ProviderEncrypt.CreateEncryptor(KeyEncrypt, IV);
            return new CryptoStream(Output, EncryptionTransform, CryptoStreamMode.Write);
            }



        /// <summary>
        /// Encrypt an array of bytes using the specified crypto provider, key and salt.
        /// </summary>
        /// <param name="ProviderEncrypt">The encryption provider to use</param>
        /// <param name="MasterSecret">The master secret from which the key and IV are derived.</param>
        /// <param name="Salt">The salt value</param>
        /// <param name="Data">The data to encrypt.</param>
        /// <returns>The encrypted data without any additional padding beyond that required by the
        /// encryption mode.</returns>
        public static byte[] Decrypt(
                CryptoProviderEncryption ProviderEncrypt,
                byte[] MasterSecret,
                byte[] Salt,
                byte[] Data) {
            CalculateParameters(ProviderEncrypt, MasterSecret, Salt,
                    out var KeyEncrypt, out var _KeyMac, out var IV);
            return ProviderEncrypt.Decrypt(Data, KeyEncrypt, IV);
            }

        /// <summary>
        /// The output crypto stream.
        /// </summary>
        protected CryptoStream CryptoStreamWrite;
        bool Finalized = false;

        /// <summary>
        /// Process a data chunk and obtain a partial result.
        /// </summary>
        /// <param name="Input">The input data to process. Currently limited to 2^32 bytes. This is unlikely to
        /// be a concern since the need to buffer the data internally makes presenting input data in large chunks 
        /// highly undesirable.</param>
        /// <param name="Final">If true, this is the final data chunk.</param>
        /// <param name="First">The index position of the first byte in the input data to process</param>
        /// <param name="Length">The number of bytes to process</param>
        /// <returns>The result of processing the partial message. 
        /// This MAY be a zero length byte array.</returns>
        public virtual void Process(byte[] Input, bool Final, long First = 0, long Length = -1) {

            Assert.False(Finalized);
            Assert.True(Input.LongLength < Int32.MaxValue);

            Length = Length < 0 ? Input.LongLength - First : Length;

            CryptoStreamWrite.Write(Input, (int)First, (int)Length);
            if (Final) {
                CryptoStreamWrite.Close();
                CryptoStreamWrite.Dispose();
                Finalized = true;
                }
            }

        /// <summary>
        /// Enhance the specified plaintext data under the specified Master Secret and Sale (if specified).
        /// </summary>
        /// <param name="MasterSecret">The Master Secret from which the necessary cryptographic parameters 
        /// are generated.</param>
        /// <param name="ProviderEncrypt">Crypto algorithm provider</param>
        /// <param name="Plaintext">The input</param>
        /// <param name="Salt"></param>
        /// <returns>The result of applying the enhancement.</returns>
        /// <param name="BodyMode">If true, write the salt value into the stream.</param>
        public static byte[] Enhance(
                    byte[] MasterSecret,
                    byte[] Plaintext,
                    byte[] Salt = null,
                    CryptoProviderEncryption ProviderEncrypt = null,
                    bool BodyMode = true
                    ) {
            var Output = new MemoryStream();
            var JSONBWriter = new JSONBWriter(Output);
            var EDS = new EnhancedDataSequenceWriter(
                JSONBWriter, MasterSecret, ProviderEncrypt, Salt, Plaintext, BodyMode: BodyMode);
            return Output.ToArray();
            }

        #region IDisposable boilerplate code.
        /// <summary>
        /// Dispose method, frees all resources.
        /// </summary>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
            }

        bool disposed = false;
        /// <summary>
        /// Dispose method, frees resources when disposing, 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing) {
            if (disposed) {
                return;
                }

            if (disposing) {
                Disposing();
                }

            disposed = true;
            }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~EnhancedDataSequence() {
            Dispose(false);
            }
        #endregion

        /// <summary>
        /// The class specific disposal routine.
        /// </summary>
        protected virtual void Disposing() {
            }
        }

    /// <summary>
    /// Write an Enhanced Data Sequence to a buffered output stream.
    /// </summary>
    public class EnhancedDataSequenceWriter : EnhancedDataSequence {

        bool Finalized = false;
        JSONWriter OutputStream;


        /// <summary>
        /// Return the final length of the specified input minus padding. This is used
        /// as an input to PackedLength which returns the total length of a packed data 
        /// item including all packing.
        /// </summary>
        /// <param name="Length">The content length</param>
        /// <returns>The length of the processed content.</returns>
        public int EnhancedContentLength(int Length) {
            if (EncryptionTransform == null) {
                return Length;
                }

            int BlockSize = EncryptionTransform.InputBlockSize;
            int Blocks = Length / BlockSize;
            return (Blocks + 1) * BlockSize;
            }


        /// <summary>
        /// Dispose resources allocated by the class.
        /// </summary>
        protected override void Disposing() => EncryptionTransform?.Dispose();        // Dispose of the encryption transform.

        /// <summary>
        /// Create a buffered writer for an Enhanced Data Sequence
        /// </summary>
        /// <param name="MasterSecret"></param>
        /// <param name="ProviderEncrypt">Crypto algorithm provider</param>
        /// <param name="Salt"></param>
        /// <param name="Plaintext"></param>
        /// <param name="OutputStream">The output stream</param>
        /// <param name="ContentLength">The content length. If this value is 0 or greater, the 
        /// PayloadLength property will be set to the value of the payload data length field. </param>
        /// <param name="BodyMode">If true, write the salt value into the stream.</param>
        public EnhancedDataSequenceWriter(
                    JSONWriter OutputStream,
                    byte[] MasterSecret,
                    CryptoProviderEncryption ProviderEncrypt = null,
                    byte[] Salt = null,
                    byte[] Plaintext = null,
                    long ContentLength = -1,
                    bool BodyMode = true
                    ) : base(ProviderEncrypt, MasterSecret, true, Salt) {
            this.OutputStream = OutputStream;

            // write the salt to the output stream
            if (!BodyMode) {
                OutputStream.WriteBinary(Salt);
                }

            if (Plaintext != null) {
                ContentLength = Plaintext.LongLength;
                }

            if (ContentLength >= 0) {
                PayloadLength = ProviderEncrypt == null ? ContentLength :
                        ProviderEncrypt.OutputLength(ContentLength);
                OutputStream.WriteBinaryBegin(PayloadLength, true);
                }
            else {
                PayloadLength = -1;
                }

            if (Plaintext != null) {
                Process(Plaintext, true);
                }

            }



        JBCDStream JBCDStream;

        /// <summary>
        /// Create a buffered writer for an Enhanced Data Sequence
        /// </summary>
        /// <param name="MasterSecret"></param>
        /// <param name="ProviderEncrypt">Crypto algorithm provider</param>
        /// <param name="Salt"></param>
        /// <param name="OutputStream">The output stream</param>
        /// <param name="ContentLength">The content length. If this value is 0 or greater, the 
        /// PayloadLength property will be set to the value of the payload data length field. </param>
        public EnhancedDataSequenceWriter(
                    JBCDStream OutputStream,
                    byte[] MasterSecret,
                    CryptoProviderEncryption ProviderEncrypt = null,
                    byte[] Salt = null,
                    long ContentLength = -1
                    ) : base(ProviderEncrypt, MasterSecret, true, Salt) => JBCDStream = OutputStream;


        /// <summary>
        /// Process a data chunk and obtain a partial result.
        /// </summary>
        /// <param name="Input">The input data to process. Currently limited to 2^32 bytes. This is unlikely to
        /// be a concern since the need to buffer the data internally makes presenting input data in large chunks 
        /// highly undesirable.</param>
        /// <param name="Final">If true, this is the final data chunk.</param>
        /// <param name="First">The index position of the first byte in the input data to process</param>
        /// <param name="Length">The number of bytes to process</param>
        /// <returns>The result of processing the partial message. 
        /// This MAY be a zero length byte array.</returns>
        public override void Process(byte[] Input, bool Final, long First = 0, long Length = -1) {

            Assert.False(Finalized);
            Assert.True(Input.LongLength < Int32.MaxValue);

            Length = Length < 0 ? Input.LongLength - First : Length;

            if (EncryptionTransform == null) {
                if (PayloadLength < 0) {
                    OutputStream.WriteBinaryBegin(Length, Final);
                    OutputStream.WriteBinaryPart(Input, First, Length);

                    }
                else {
                    OutputStream.WriteBinaryPart(Input, First, Length);
                    }
                if (Final) {
                    OutputStream.WriteArrayEnd();
                    Finalized = true;
                    }

                return;
                }

            int BlockSize = EncryptionTransform.InputBlockSize;
            int Blocks = (int)Length / BlockSize;
            int InputLength = Blocks * BlockSize;
            int Remainder = (int)Length - InputLength;

            Assert.True(Final | Remainder == 0); // Hack, constrain input length to multiple of whole blocks

            if (Final) {
                var FinalBlock = EncryptionTransform.TransformFinalBlock(Input, (int)First, (int)Length);
                if (PayloadLength < 0) {
                    OutputStream.WriteBinaryBegin(FinalBlock.Length, true);
                    }
                OutputStream.WriteBinaryPart(FinalBlock);
                Finalized = true;
                }
            else {
                var OutputBuffer = new byte[InputLength];
                EncryptionTransform.TransformBlock(Input, (int)First, InputLength, OutputBuffer, 0);
                if (PayloadLength < 0) {
                    OutputStream.WriteBinaryBegin(OutputBuffer.Length, true);
                    }
                OutputStream.WriteBinaryPart(OutputBuffer);
                }
            }





        /// <summary>
        /// Create a buffered writer for an Enhanced Data Sequence
        /// </summary>
        /// <param name="Plaintext"></param>
        /// <param name="OutputStream">The output stream</param>
        /// <param name="ContentLength">The content length. If this value is 0 or greater, the 
        /// PayloadLength property will be set to the value of the payload data length field. </param>
        public EnhancedDataSequenceWriter(
                    JSONWriter OutputStream,
                    byte[] Plaintext = null,
                    long ContentLength = -1
                    ) : base() {
            this.OutputStream = OutputStream;

            if (Plaintext != null) {
                ContentLength = Plaintext.LongLength;
                }

            if (ContentLength >= 0) {
                OutputStream.WriteBinaryBegin(ContentLength, true);
                PayloadLength = ContentLength;
                }
            else {
                PayloadLength = -1;
                }

            if (Plaintext != null) {
                Process(Plaintext, true);
                }

            }


        }
    /// <summary>
    /// 
    /// </summary>
    public class EnhancedDataSequenceReader : EnhancedDataSequence {


        Stream OutputStream;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OutputStream"></param>
        /// <param name="MasterSecret"></param>
        /// <param name="ProviderDecrypt"></param>
        /// <param name="Salt"></param>
        /// <param name="Write"></param>
        public EnhancedDataSequenceReader(
                    Stream OutputStream,
                    byte[] MasterSecret,
                    CryptoProviderEncryption ProviderDecrypt = null,
                    byte[] Salt = null,
                    bool Write=true) : base () {
            this.OutputStream = OutputStream;
            if (Salt == null) {
                // read the salt from the stream
                }

            SetParameters(ProviderDecrypt, MasterSecret, false, Salt);

            CryptoStreamWrite = new CryptoStream(OutputStream, EncryptionTransform, 
                    Write ? CryptoStreamMode.Write : CryptoStreamMode.Read);
            }

        }
    }
