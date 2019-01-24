using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;
namespace Goedel.Cryptography.Dare {


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

        JSONBCDReader JSONBCDReader;

        /// <summary>
        /// Create a CryptoStack
        /// </summary>
        /// <param name="Stream"></param>
        /// <param name="Mac"></param>
        /// <param name="Digest"></param>
        public CryptoStackStreamReader(
                    JSONBCDReader Stream,
                    HashAlgorithm Mac,
                    HashAlgorithm Digest) : base(Mac, Digest) {
            this.JSONBCDReader = Stream;
            Stream.ReadBinaryToken();
            }


        /// <summary>
        /// Copies bytes from the current buffered stream to an array 
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
            JSONBCDReader.ReadBinaryData(buffer, offset, count);
            



        /// <summary>
        /// Write data to the output stream.(not supported).
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from 
        /// <paramref name="buffer"/> to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
        /// at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();

        }


    /// <summary>
    /// Tracks the cryptography providers used to compute MACs and Digests.
    /// </summary>
    public class CryptoStackJBCDStreamReader : CryptoStackStream {

        /// <summary>
        /// Gets a value indicating whether the current stream supports reading (is always false).
        /// </summary>
        public override bool CanRead => true;

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing(is always true).
        /// </summary>
        public override bool CanWrite => false;

        Stream JBCDFrameReader;

        /// <summary>
        /// Create a CryptoStack
        /// </summary>
        /// <param name="Stream"></param>
        /// <param name="Mac"></param>
        /// <param name="Digest"></param>
        public CryptoStackJBCDStreamReader(
                    Stream Stream,
                    HashAlgorithm Mac,
                    HashAlgorithm Digest) : base(Mac, Digest) => JBCDFrameReader = Stream;


        /// <summary>
        /// Copies bytes from the current buffered stream to an array 
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
        public override int Read(byte[] buffer, int offset, int count) {
            var length = JBCDFrameReader.Read(buffer, offset, count);

            //Console.WriteLine($"Read {buffer} bytes");
            return length;
            }




        /// <summary>
        /// Write data to the output stream.(not supported).
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from 
        /// <paramref name="buffer"/> to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
        /// at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();

        }

    #endregion

    #region //writer
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

        /// <summary>
        /// The stream writer.
        /// </summary>
        public Stream Writer {
            get => CryptoStream ?? (Stream)this;
            set => CryptoStream = value as CryptoStream;
            }

        /// <summary>
        /// Create a CryptoStack
        /// </summary>
        /// <param name="Output">The target stream to be written to. This is wrapped in a pipe to prevent
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


            //Console.Write($"Payload length is {PayloadLength}");

            this.PackagingFormat = PackagingFormat;

            Writer = this;

            this.PayloadLength = PayloadLength;
            if (PayloadLength >= 0 & PackagingFormat != PackagingFormat.Direct) {
                JSONBWriter.WriteTag(Output, JSONBCD.DataTerm, PayloadLength);
                Console.Write($"Written tag for {PayloadLength}");
                }

            StreamMac = Mac== null ? null : new CryptoStream(new CryptoStackStream(), Mac, CryptoStreamMode.Write);

            

            if (Digest != null) {
                StreamDigest = new CryptoStream(
                new CryptoStackStream(Output), Digest, CryptoStreamMode.Write);
                Output = StreamDigest;
                }
            this.Output = Output;

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
                PayloadLength = PayloadLength - count;
                Output.Write(buffer, offset, count);

                //Console.Write($"  Have {count} bytes to stream");
                }
            else {
                JSONBWriter.WriteTag(Output, Final ?JSONBCD.DataTerm: JSONBCD.DataChunk,
                    count);
                Output.Write(buffer, offset, count);

                //Console.Write($"  Have {count} chunk (final:{Final}) to stream");
                }
            }

        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be written 
        /// to the underlying device.
        /// </summary>
        public override void Flush() => Output?.Flush();

        readonly static byte[] Empty = new byte[0];

        bool Closed = false;

        /// <summary>
        /// Closes the current stream, completes calculation of cryptographic values (MAC/Digest)
        /// associated with the current stream. Does not close the target stream because that would
        /// be stupid.
        /// </summary>
        public override void Close() {
            if (Closed) {
                return;
                }
            Closed = true;

            Final = true;
            if (CryptoStream == null) {
                Writer.Write(Empty, 0, 0);
                //Console.Write($"  Written end marker");
                }
            else {
                CryptoStream.FlushFinalBlock();
                }

            if (Digest != null) {
                StreamDigest?.Dispose();
                StreamDigest = null;
                DigestValue = Digest?.Hash;
                Digest?.Dispose();
                Digest = null;
                }


            if (Mac != null) {
                StreamMac?.Dispose();
                StreamMac = null;
                MacValue = Mac?.Hash;
                Mac?.Dispose();
                if (PackagingFormat == PackagingFormat.EDS) {
                    JSONBWriter.WriteBinary(Output, MacValue);
                    }
                }
            }
        }
    #endregion


    }
