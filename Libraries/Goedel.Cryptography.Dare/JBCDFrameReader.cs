using System;
using System.IO;
using Goedel.IO;
using Goedel.Utilities;
using Goedel.Protocol;
using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// 
    /// </summary>
    public partial class ContainerFramerReader : ContainerDataReader {

        StreamReaderBounded StreamReader=null;
        JBCDStream JBCDStream;
        Stream Reader;
        
        CryptoStackStream CryptoStackStreamReader = null;

        /// <summary></summary>
        public override long Length { get; }

        /// <summary></summary>
        public DareTrailer Trailer;

        /// <summary>
        /// Construct a ContainerDataReader for a JBCDStream using the Framer interface.
        /// The 
        /// </summary>
        /// <param name="JBCDStream"></param>
        /// <param name="KeyCollection"></param>
        /// <param name="Position">The byte position in the file from 
        /// which to begin reading.</param>
        public ContainerFramerReader(JBCDStream JBCDStream,
                        KeyCollection KeyCollection,
                        long Position = -1) {

            this.JBCDStream = JBCDStream;

            Console.WriteLine($"Begin Framer.");
            Length = JBCDStream.FramerOpen(Position);

            var HeaderBytes = JBCDStream.FramerGetData();
            var HeaderText = HeaderBytes.ToUTF8();
            Header = ContainerHeaderFirst.FromJSON(HeaderBytes.JSONReader(), false);

            StreamReader = JBCDStream.FramerGetReader();
            HasPayload = StreamReader != null;
            CryptoStackStreamReader = HasPayload ?
                Header.GetDecoder(StreamReader, out Reader,
                        KeyCollection: KeyCollection) : null;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DareTrailer GetTrailer() {
            var HeaderBytes = JBCDStream.FramerGetData();
            if (HeaderBytes != null) {
                Trailer = DareTrailer.FromJSON(HeaderBytes.JSONReader(), false);
                }
            return Trailer;
            }

        /// <summary>
        /// 
        /// </summary>
        public override void Close() => CryptoStackStreamReader?.Close();

        /// <summary>
        /// Copies bytes from the stream to an array.
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
            var Bytes = Reader==null ? 0 : Reader.Read(buffer, offset, count);
            Console.WriteLine($"Read {Bytes} Bytes");
            return Bytes;
            }

        }

    /// <summary>
    /// 
    /// </summary>
    public partial class ContainerDataReader : StreamReaderBase {

        /// <summary></summary>
        public bool HasPayload;
        JBCDRecordDataReader JBCDFrameReader = null;
        CryptoStackStream CryptoStackStreamReader = null;
        Stream Reader;

        /// <summary></summary>
        public ContainerHeader Header;

        /// <summary>
        /// 
        /// </summary>
        public ContainerDataReader() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="JBCDStream"></param>
        /// <param name="FrameRemaining"></param>
        /// <param name="Header"></param>
        /// <param name="KeyCollection"></param>
        public ContainerDataReader(JBCDStream JBCDStream, ref long FrameRemaining,
                        ContainerHeader Header, KeyCollection KeyCollection) {
            this.Header = Header;
            JBCDFrameReader = new JBCDRecordDataReader(JBCDStream, ref FrameRemaining);
            CryptoStackStreamReader = Header.GetDecoder(JBCDFrameReader, out Reader,
                            KeyCollection: KeyCollection);
            Console.WriteLine($"Begin Reading {FrameRemaining} / Index {Header.Index}");
            }

        /// <summary>
        /// Close the strem and finaliza all cryptographic contexts.
        /// </summary>
        public override void Close() {
            JBCDFrameReader?.Close();
            CryptoStackStreamReader?.Close();
            }

        /// <summary>
        /// Get the length of the stream in bytes.
        /// </summary>
        public override long Length => throw new NotImplementedException();

        /// <summary>
        /// Copies bytes from the stream to an array.
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
            var Bytes = Reader.Read(buffer, offset, count);
            Console.WriteLine($"Read {Bytes} Bytes");
            return Bytes;
            }

        /// <summary>
        /// Return the remaining stream data to an array and return it.
        /// </summary>
        /// <returns>The data read from the stream.</returns>
        public byte[] ToArray() {
            byte[] Result;
            using (var Buffer = new MemoryStream()) {
                CopyTo(Buffer);
                Result = Buffer.ToArray();
                }
            return Result;
            }
        }

    /// <summary>
    /// A stream that reads from a container record.
    /// </summary>
    public partial class StreamReaderBounded : StreamReaderBase {
        #region // Boilerplate implementations
        /// <summary>
        /// Gets the frame length in bytes. 
        /// </summary>
        public override long Length { get; }
        #endregion

        Stream Stream;
        long Start;

        /// <summary>
        /// The number of bytes remaining to be read.
        /// </summary>
        public long Remaining => Length - (Stream.Position - Start);

        /// <summary>
        /// Construct a bounded reader for the frame.
        /// </summary>
        /// <param name="Stream">The underlying stream to be read</param>
        /// <param name="Start">The position at which to begin reading the file.</param>
        /// <param name="Length">The maximum number of bytes to be read.</param>
        public StreamReaderBounded(Stream Stream, long Start, long Length) {
            Stream.Seek(Start, SeekOrigin.Begin);
            this.Length = Length;
            this.Stream = Stream;
            this.Start = Start;
            }

        /// <summary>
        /// Copies bytes from the current buffered stream to an array.
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the 
        /// specified byte array with the values between <paramref name="offset"/> and 
        /// (<paramref name="offset"/> + <paramref name="Count"/> - 1) 
        /// replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing 
        /// the data read from the current stream.</param>
        /// <param name="Count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes 
        /// requested if that many bytes are not currently available, or zero (0) if the end of the stream 
        /// has been reached.</returns>
        public override int Read(byte[] buffer, int offset, int Count) {
            Count = Math.Min(Count, (int)Remaining);
            return Stream.Read(buffer, offset, Count);
            }

        }



    /// <summary>
    /// A stream that reads from a container record.
    /// </summary>
    public partial class JBCDRecordDataReader : StreamReaderBase {
        #region // Boilerplate implementations
        /// <summary>
        /// Gets the frame length in bytes. 
        /// </summary>
        public override long Length { get; }
        #endregion

        JBCDStream JBCDStream;

        /// <summary>
        /// Construct a reader for the specified frame data.
        /// </summary>
        /// <param name="JBCDStream">The stream to be read.</param>
        /// <param name="FrameRemaining">The remaining bytes to be read from the record.
        /// </param>
        public JBCDRecordDataReader(JBCDStream JBCDStream, ref long FrameRemaining) {
            Length = JBCDStream.ReadRecordBegin(ref FrameRemaining);
            this.JBCDStream = JBCDStream;
            }

        /// <summary>
        /// Copies bytes from the current buffered stream to an array.
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
            JBCDStream.ReadRecordData(buffer, offset, count);


        }


    }
