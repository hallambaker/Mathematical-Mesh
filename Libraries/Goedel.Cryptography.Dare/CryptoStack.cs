using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;
namespace Goedel.Cryptography.Dare {

/*
 *  SOD THIS
 *  
 *  ENCRYPT == ENCODE == WRITE ONLY
 *  DECRYPT == DECODE == READ ONLY
 *  
 */


    /// <summary>
    /// Packing formats
    /// </summary>
    public enum PackagingFormat {
        /// <summary>
        /// Package directly without padding
        /// </summary>
        Direct,

        /// <summary>
        /// Package as an Enhanced Data Sequence.
        /// </summary>
        EDS,

        /// <summary>
        /// Package as a container payload entry.
        /// </summary>
        Container

        }


    /// <summary>
    /// Tracks the cryptography providers used to compute MACs and Digests.
    /// </summary>
    public class CryptoStackStream : Stream {

        /// <summary>
        /// Gets a value indicating whether the current stream supports reading.
        /// </summary>
        public override bool CanRead => Stream != null;

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing.
        /// </summary>
        public override bool CanWrite => true;

        /// <summary>
        /// The externally accessible stream.
        /// </summary>
        protected Stream Stream;

        /// <summary>
        /// The Massage Authentication Code Transform.
        /// </summary>
        protected HashAlgorithm Mac;

        /// <summary>
        /// The Digest Transform.
        /// </summary>
        protected HashAlgorithm Digest;

        /// <summary>
        /// The computed MAC value.
        /// </summary>
        public byte[] MacValue { get; protected set; }

        /// <summary>
        /// The computed Digest value.
        /// </summary>
        public byte[] DigestValue { get; protected set; }



        /// <summary>
        /// Create a CryptoStack
        /// </summary>
        /// <param name="Stream">The target stream.</param>
        /// <param name="Mac">The Message Authentication Code Transform.</param>
        /// <param name="Digest">The Digest Transform.</param>
        protected CryptoStackStream(
                    HashAlgorithm Mac,
                    HashAlgorithm Digest) {
            this.Mac = Mac;
            this.Digest = Digest;
            }

        /// <summary>
        /// Creates a dummy stream. This may be a sink that simply discards the data (for 
        /// calculating digest values) or a passthrough that keeps the target stream open
        /// when the encryption stream is closed.
        /// </summary>
        /// <param name="Stream">The target stream. If null, output is simply discarded.</param>
        public CryptoStackStream(Stream Stream = null) => this.Stream = Stream;

        #region IDisposable boilerplate code.

        bool disposed = false;
        /// <summary>
        /// Dispose method, frees resources when disposing, 
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; 
        /// false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing) {
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
        ~CryptoStackStream() {
            Dispose(false);
            }
        #endregion

        /// <summary>
        /// The class specific disposal routine.
        /// </summary>
        protected virtual void Disposing() => Close();

        /// <summary>
        /// Copies bytes from the current buffered stream to an array (not supported).
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the 
        /// specified byte array with the values between <paramref name="offset"/> and 
        /// (<paramref name="offset"/> + <paramref name="count"/> - 1) 
        /// replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing 
        /// the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes 
        /// requested if that many bytes are not currently available, or zero (0) if the end of the stream 
        /// has been reached.</returns>
        public override int Read(byte[] buffer, int offset, int count) =>
                    Stream == null ? 0 : Stream.Read(buffer, offset, count);


        /// <summary>
        /// Write data to the output stream.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from 
        /// <paramref name="buffer"/> to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
        /// at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public override void Write(byte[] buffer, int offset, int count) => Stream?.Write(buffer, offset, count);

        /// <summary>
        /// Closes the current stream, completes calculation of cryptographic values (MAC/Digest)
        /// associated with the current stream. Does not close the target stream because that would
        /// be stupid.
        /// </summary>
        public override void Close() {
            }

        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be written 
        /// to the underlying device.
        /// </summary>
        public override void Flush() => Stream?.Flush();

        #region // Boilerplate implementations

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking(is always false).
        /// </summary>
        public override bool CanSeek => false;

        /// <summary>
        /// Gets the position within the current stream. The set operation is not supported.
        /// </summary>
        public override long Position {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
            }


        /// <summary>
        /// Sets the position within the current buffered stream (not supported).
        /// </summary>
        /// <param name="offset">A byte offset relative to the <paramref name="origin"/> parameter.</param>
        /// <param name="origin">A value of type SeekOrigin indicating the reference point used to obtain the new position.</param>
        /// <returns></returns>
        public override long Seek(long offset, SeekOrigin origin) => throw new NotImplementedException();

        /// <summary>
        /// Sets the length of the output frame.
        /// </summary>
        /// <param name="value"></param>
        public override void SetLength(long value) => throw new NotImplementedException();

        /// <summary>
        /// Gets the frame length in bytes. 
        /// </summary>
        public override long Length => throw new NotImplementedException();



        #endregion

        }

    #region //reader
    /// <summary>
    /// Tracks the cryptography providers used to compute MACs and Digests.
    /// </summary>
    public class CryptoStackStreamReader : CryptoStackStream {

        /// <summary>
        /// Gets a value indicating whether the current stream supports reading (is always false).
        /// </summary>
        public override bool CanRead => true;

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing(is always true).
        /// </summary>
        public override bool CanWrite => false;


        /// <summary>
        /// Create a CryptoStack
        /// </summary>
        /// <param name="Stream"></param>
        /// <param name="Mac"></param>
        /// <param name="Digest"></param>
        /// <param name="PackagingFormat"></param>
        public CryptoStackStreamReader(
                    Stream Stream,
                    PackagingFormat PackagingFormat, 
                    HashAlgorithm Mac,
                    HashAlgorithm Digest) : base(Mac, Digest) {
            }


        /// <summary>
        /// Copies bytes from the current buffered stream to an array (not supported).
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the 
        /// specified byte array with the values between <paramref name="offset"/> and 
        /// (<paramref name="offset"/> + <paramref name="count"/> - 1) 
        /// replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing 
        /// the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes 
        /// requested if that many bytes are not currently available, or zero (0) if the end of the stream 
        /// has been reached.</returns>
        public override int Read(byte[] buffer, int offset, int count) => throw new NotImplementedException();


        /// <summary>
        /// Write data to the output stream.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from 
        /// <paramref name="buffer"/> to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
        /// at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();

        }
    #endregion

    /// <summary>
    /// Tracks the cryptography providers used to compute MACs and Digests.
    /// </summary>
    public class CryptoStackStreamWriter : CryptoStackStream {

        /// <summary>
        /// Gets a value indicating whether the current stream supports reading (is always false).
        /// </summary>
        public override bool CanRead => false;

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing(is always true).
        /// </summary>
        public override bool CanWrite => true;

        CryptoStream StreamMac;
        CryptoStream StreamDigest;
        Stream Output;
        PackagingFormat PackagingFormat;
        long PayloadLength;
        CryptoStream CryptoStream = null;
        //JSONBWriter JSONWriter;


        public Stream Writer {
            get => CryptoStream ?? (Stream)this;
            set => CryptoStream = value as CryptoStream;
            }

        /// <summary>
        /// Create a CryptoStack
        /// </summary>
        /// <param name="BinaryOutput">The target stream to be written to. This is wrapped in a pipe to prevent
        /// it being closed when the encryption stream is closed.</param>
        /// <param name="Mac">The Message Authentication Code Transform.</param>
        /// <param name="Digest">The Digest Transform.</param>
        /// <param name="PackagingFormat">The packing format to use on the output.</param>
        /// <param name="PayloadLength">The payload length including cryptographic
        /// enhancements.</param>
        public CryptoStackStreamWriter(
                    Stream Output,
                    PackagingFormat PackagingFormat,
                    HashAlgorithm Mac,
                    HashAlgorithm Digest,
                    long PayloadLength) : base (Mac, Digest) {

            //this.JSONWriter = JSONWriter;

            this.PackagingFormat = PackagingFormat;

            Writer = this;

            this.PayloadLength = PayloadLength;
            if (PayloadLength >= 0 & PackagingFormat != PackagingFormat.Direct) {
                JSONBWriter.WriteTag(Output, JSONBCD.DataTerm, PayloadLength);
                }

            StreamMac = Mac== null ? null : new CryptoStream(new CryptoStackStream(), Mac, CryptoStreamMode.Write);

            this.Output = Output;

            if (Digest != null) {
                StreamDigest = new CryptoStream(
                new CryptoStackStream(Output), Digest, CryptoStreamMode.Write);
                Output = StreamDigest;
                }
            }


        /// <summary>
        /// Copies bytes from the current buffered stream to an array (not supported).
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the 
        /// specified byte array with the values between <paramref name="offset"/> and 
        /// (<paramref name="offset"/> + <paramref name="count"/> - 1) 
        /// replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing 
        /// the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes 
        /// requested if that many bytes are not currently available, or zero (0) if the end of the stream 
        /// has been reached.</returns>
        public override int Read(byte[] buffer, int offset, int count) => throw new NotImplementedException();

        bool Final = false;
        /// <summary>
        /// Write data to the output stream.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from 
        /// <paramref name="buffer"/> to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
        /// at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public override void Write(byte[] buffer, int offset, int count) {
            StreamMac?.Write(buffer, offset, count);
            if (PayloadLength > 0 | PackagingFormat == PackagingFormat.Direct) {
                // ToDo: It would be more efficient to introduce a buffer of 4096 bytes or so to avoid short writes.

                PayloadLength = PayloadLength - count;
                Output.Write(buffer, offset, count);
                }
            else {
                JSONBWriter.WriteTag(Output, Final ?JSONBCD.DataTerm: JSONBCD.DataChunk,
                    count);
                Output.Write(buffer, offset, count);
                }
            }

        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be written 
        /// to the underlying device.
        /// </summary>
        public override void Flush() => Output?.Flush();

        readonly static byte[] Empty = new byte[0];

        /// <summary>
        /// Closes the current stream, completes calculation of cryptographic values (MAC/Digest)
        /// associated with the current stream. Does not close the target stream because that would
        /// be stupid.
        /// </summary>
        public override void Close() {
            Final = true;
            if (CryptoStream == null) {
                Writer.Write(Empty, 0, 0);
                }
            else {
                CryptoStream.FlushFinalBlock();
                }

            // CHECK HERE TO SEE IF THE CORRECT LENGTH WAS CALCULATED

            // The wrong number of bytes was written to the stream, 
            // should have been 992, was 1000


            if (Mac != null) {
                StreamMac?.Dispose();
                StreamMac = null;
                MacValue = Mac?.Hash;
                Mac?.Dispose();
                if (PackagingFormat == PackagingFormat.EDS) {
                    JSONBWriter.WriteBinary(Output, MacValue);
                    }
                }

            StreamDigest?.Dispose();
            StreamDigest = null;
            DigestValue = Digest?.Hash;
            Digest?.Dispose();
            }
        }


    /// <summary>
    /// Creates a factory for generating a stack of CryptoStream objects for processing
    /// a stream of data.
    /// </summary>
    public partial class CryptoStack {

        /// <summary>
        /// The recipient information fields.
        /// </summary>
        public List<DARERecipient> Recipients;

        /// <summary>
        /// The JOSE algorithm identifier for the encryption algorithm.
        /// </summary>
        public string EncryptionAlgorithm=null;


        /// <summary>
        /// The Keys to be used to sign the message. 
        /// </summary>
        public List<KeyPair> SignerKeys;

        /// <summary>
        /// The base salt value.
        /// </summary>
        public byte[] Salt;

        byte[] MasterSecret;
        CryptoAlgorithmID EncryptID;
        CryptoAlgorithmID AuthenticateID;
        int KeySize;
        int BlockSize;
        int BlockSizeByte => BlockSize / 8;

        /// <summary>
        /// Calculate the ciphertext length for a specified plaintext length.
        /// </summary>
        /// <param name="PlaintextLength">The input plaintext length.</param>
        /// <returns>The ciphertext length using the current cipher.</returns>
        public long CipherTextLength(long PlaintextLength) => EncryptID == CryptoAlgorithmID.NULL ?
            PlaintextLength : BlockSizeByte * (1+ (PlaintextLength / BlockSizeByte));


        /// <summary>
        /// Create a CryptoStack instance to encode data with the specified cryptographic
        /// parameters.
        /// </summary>
        /// <param name="EncryptionKeys">The public keys to be used to encrypt.</param>
        /// <param name="SignerKeys">The private keys to be used in signing.</param>
        /// <param name="EncryptID">The cryptographic enhancement to be applied to the
        /// content.</param>
        /// <param name="AuthenticateID">The digest algorithm to be applied to the message
        /// encoding.</param>
        public CryptoStack(
                        List<KeyPair> EncryptionKeys = null,
                        List<KeyPair> SignerKeys = null,
                        CryptoAlgorithmID EncryptID = CryptoAlgorithmID.Default,
                        CryptoAlgorithmID AuthenticateID = CryptoAlgorithmID.Default
                        ) {

            if (EncryptionKeys != null) {

                Salt = Platform.GetRandomBits(128);
                EncryptID = EncryptID == CryptoAlgorithmID.Default ? CryptoAlgorithmID.AES256HMAC : EncryptID;
                this.EncryptID = EncryptID;

                this.AuthenticateID = AuthenticateID;

                EncryptionAlgorithm = EncryptID.ToJoseID();

                (KeySize, BlockSize) = EncryptID.GetKeySize();
                MasterSecret = Platform.GetRandomBits(KeySize);

                //MasterSecret = new byte[32]; // HACK - FOR TESTING

                Recipients = Recipients ?? new List<DARERecipient>();
                foreach (var EncryptionKey in EncryptionKeys) {
                    Recipients.Add(new DARERecipient(MasterSecret, EncryptionKey));
                    }

                }
            else {
                this.EncryptID = CryptoAlgorithmID.NULL;
                this.AuthenticateID = CryptoAlgorithmID.NULL;
                }

            this.SignerKeys = SignerKeys;

            }

        /// <summary>
        /// Create a CryptoStack Instance to decode data with the specified cryptographic
        /// parameters.
        /// </summary>
        /// <param name="EncryptID">The keyed cryptographic enhancement to be applied to the content.</param>
        /// <param name="AuthenticateID">The digest algorithm to be applied to the message.</param>
        /// <param name="Recipients">The recipient information</param>
        /// <param name="Signatures">The message signatures.</param>
        public CryptoStack(
                CryptoAlgorithmID EncryptID,
                CryptoAlgorithmID AuthenticateID,
                List<DARERecipient> Recipients,
                List<DARESignature> Signatures
                ) {
            }


        private void CalculateParameters(
                    bool Encrypt,        
                    byte[] ExtraSalt,
                    out ICryptoTransform TransformEncrypt,
                    out HashAlgorithm TransformMac,
                    out HashAlgorithm TransformDigest) {
            TransformDigest = AuthenticateID.CreateDigest();
            if (MasterSecret == null) {
                TransformMac = null;
                TransformEncrypt = null;
                return;
                }

            var ThisSalt = ExtraSalt == null ? Salt : Salt.Concatenate(ExtraSalt);

            EnhancedDataSequence.CalculateParameters(KeySize, BlockSize,
                MasterSecret, ThisSalt, out var KeyEncrypt, out var KeyMac, out var IV);

            
            TransformMac = EncryptID.CreateMac(KeyMac);
            TransformEncrypt = Encrypt ? EncryptID.CreateEncryptor(KeyEncrypt, IV) :
                EncryptID.CreateDecryptor(KeyEncrypt, IV);
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
                        Stream Output,
                        PackagingFormat PackagingFormat,
                        long ContentLength = -1,
                        byte[] ExtraSalt=null
                        ) {
            CalculateParameters(true, ExtraSalt, out var TransformEncrypt,
                out var TransformMac, out var TransformDigest);

            if (PackagingFormat == PackagingFormat.EDS & ExtraSalt!=null) {
                JSONBWriter.WriteBinary(Output, ExtraSalt);
                }

            CryptoStream CryptoStream = null;


            var PayloadLength = ContentLength < 0 ? -1 : CipherTextLength(ContentLength);

            var Writer = new CryptoStackStreamWriter(Output, PackagingFormat, 
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
        /// <param name="PackagingFormat">The packaging format to use.</param>
        /// <param name="ExtraSalt">Additional salt value.</param>
        /// <returns>The encoded data.</returns>
        public byte[] Encode(byte[] Data, byte[] ExtraSalt=null, 
                    PackagingFormat PackagingFormat=PackagingFormat.EDS) {
            
            using (var Input = new MemoryStream(Data)) {
                using (var Output = new MemoryStream()) {
                    //var JSONBWriter = new JSONBWriter(Output);
                    var EncoderData = GetEncoder(Output, PackagingFormat, Data.LongLength, ExtraSalt);
                    Input.CopyTo(EncoderData.Writer);
                    EncoderData.Close();
                    Output.Flush();
                    return Output.ToArray();
                        
                    }
                }
            }


        /// <summary>
        /// Construct a stream decoder from the cryptographic data provided.
        /// </summary>
        /// <param name="Stream">The stream to decode from.</param>
        /// <param name="PackagingFormat">The packaging format.</param>
        /// <param name="ContentLength">The content length if known or -1 if variable length
        /// encoding is to be used.</param>
        /// <param name="KeyCollection">A Key collection object providing access to keys
        /// decryption keys by identifier.</param>
        /// <param name="Reader">The stream to read to obtain the decrypted data.</param>
        /// <returns>The decoder.</returns>
        public CryptoStackStream GetDecoder(
                        Stream Stream,
                        out Stream Reader,
                        PackagingFormat PackagingFormat,
                        long ContentLength = -1,
                        KeyCollection KeyCollection = null
                        ) {

            // read the salt from the stream!
            byte[] ExtraSalt = null; 

            CalculateParameters(false, ExtraSalt, out var TransformEncrypt,
                out var TransformMac, out var TransformDigest);

            var Result = new CryptoStackStreamReader(Stream, PackagingFormat, TransformMac, TransformDigest);
            Reader = TransformEncrypt == null ? (Stream) Result : 
                new CryptoStream(Result, TransformEncrypt, CryptoStreamMode.Read);

            return Result;
            }


        /// <summary>
        /// Decode a data block
        /// </summary>
        /// <param name="Data">The data to encode.</param>
        /// <param name="PackagingFormat">The packaging format to use.</param>
        /// <param name="KeyCollection">A Key collection object providing access to keys
        /// decryption keys by identifier.</param>
        /// <returns>The decoded data.</returns>
        public byte[] Decode(byte[] Data, PackagingFormat PackagingFormat, KeyCollection KeyCollection = null) {

            using (var Input = new MemoryStream(Data)) {
                using (var Output = new MemoryStream()) {
                    var EncoderData = GetDecoder(Output, out var Reader, PackagingFormat, Data.LongLength,KeyCollection);
                    Reader.CopyTo(Output);
                    EncoderData.Close();

                    // Check MAC if specified.

                    return Output.ToArray();
                    }
                }
            }


        }


    }
