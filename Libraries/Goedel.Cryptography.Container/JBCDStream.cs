using System;
using System.IO;
using Goedel.IO;
using Goedel.Utilities;
using Goedel.Protocol;


namespace Goedel.Cryptography.Container {

    /// <summary>
    /// Implements a highly restricted stream that supports exactly the functionality
    /// required by the JBCD Reader/Writer extensions. In the base class, the underlying
    /// implementation is supplied by a Stream object (typically a FileStream). It is
    /// expected this will be replaced in the future by a version that performs direct 
    /// memory mapping of the files.
    /// </summary>
    public partial class JBCDStream {

        Stream Stream;

        /// <summary>
        /// Default constructor, used to allow subclasses to be created that do not use Stream
        /// </summary>

        protected JBCDStream () {
            }

        /// <summary>
        /// Constructor from a stream
        /// </summary>
        /// <param name="Stream">The underlying stream. This must support the seek operation.</param>
        public JBCDStream (Stream Stream) {
            this.Stream = Stream;
            }

        /* Position properties and methods */


        /// <summary>
        /// The current position within the stream.
        /// </summary>
        public long Position {
            get => Stream.Position;
            set => Stream.Seek(0, SeekOrigin.Begin);
            }

        /// <summary>
        /// A long value representing the length of the stream in bytes.
        /// </summary>
        public long Length => Stream.Length;


        /// <summary>
        /// Sets the position within the current stream.
        /// </summary>
        /// <param name="Offset">A byte offset relative to the origin parameter.</param>
        /// <param name="Origin">A value of type SeekOrigin indicating the reference point used to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
        public virtual long Seek (long Offset, SeekOrigin Origin) {
            return Stream.Seek(Offset, Origin);
            }

        /// <summary>
        /// Move to the beginning of the stream.
        /// </summary>
        /// <returns>The new position within the current stream.</returns>
        public virtual long Begin () {
            return Stream.Seek(0, SeekOrigin.Begin);
            }

        /// <summary>
        /// Move to the end of the stream.
        /// </summary>
        /// <returns>The new position within the current stream.</returns>
        public virtual long End () {
            return Stream.Seek(0, SeekOrigin.End);
            }

        /* Write functions */

        /// <summary>
        /// Writes a byte to the current position in the stream and advances the position within the stream by one byte.
        /// </summary>
        /// <param name="Value">The byte to write to the stream.</param>
        public virtual void WriteByte (byte Value) {
            Stream.WriteByte(Value);
            }

        /// <summary>
        /// Writes a sequence of bytes to the current stream and advances the 
        /// current position within this stream by the number of bytes written.
        /// </summary>
        /// <param name="Buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
        /// <param name="Offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="Count">The number of bytes to be written to the current stream.</param>
        public virtual void Write (byte[] Buffer, int Offset = 0, int Count = -1) {
            Count = Count < 0 ? Buffer.Length : Count;
            Stream.Write(Buffer, Offset, Count);
            }

        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be written to the underlying device.
        /// </summary>
        public virtual void Flush () {
            Stream.Flush();
            }

        /* Read functions */

        /// <summary>
        /// Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
        /// </summary>
        /// <param name="Buffer"> An array of bytes. When this method returns, the buffer contains the specified byte array with the values between 
        /// offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
        /// <param name="Offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="Count">Number of bytes to read.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes requested 
        /// if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.</returns>
        public virtual int Read (byte[] Buffer, int Offset, int Count) {
            return Stream.Read(Buffer, Offset, Count);
            }


        /// <summary>
        /// Reads a byte from the stream and advances the position within the stream by one byte, or returns -1 if 
        /// at the end of the stream.
        /// </summary>
        /// <returns>The unsigned byte cast to an Int32, or -1 if at the end of the stream.</returns>
        public virtual int ReadByte () {
            return Stream.ReadByte();
            }


        /// <summary>
        /// Read a byte in the reverse direction, i.e. the byte immediately preceding the 
        /// current position.
        /// </summary>
        /// <returns>The byte read or -1.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public virtual int ReadByteReverse () {
            Assert.True(Position > 0, InvalidFileFormatException.Throw);
            Seek(-1, SeekOrigin.Current);
            var Value = ReadByte();
            Seek(-1, SeekOrigin.Current);
            return Value;
            }


        }

    }
