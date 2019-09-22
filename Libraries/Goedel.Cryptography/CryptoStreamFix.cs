using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Cryptography {

    /// <summary>
    /// This is a dummy stream that simply passes all calls to the underlying
    /// stream set when it is initialized except for Close() and Dispose(). 
    /// Its function is simply to prevent the underlying stream being closed
    /// when a CryptoStream is closed.
    /// </summary>
    public class CryptoStreamFix : Stream {
        /// <summary>
        /// Gets a value indicating whether the current stream supports reading (is always false).
        /// </summary>
        public override bool CanRead => Output.CanRead;

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking(is always false).
        /// </summary>
        public override bool CanSeek => Output.CanSeek;
        /// <summary>
        /// Gets a value indicating whether the current stream supports writing(is always true).
        /// </summary>
        public override bool CanWrite => Output.CanWrite;

        /// <summary>
        /// Gets the stream length in bytes. 
        /// </summary>
        public override long Length => Output.Length;
        /// <summary>
        /// Gets the position within the current stream. The set operation is not supported.
        /// </summary>
        public override long Position {
            get => Output.Position;
            set => Output.Position = value; }

        ///<summary>Declare this stream as a property so as to prevent warnings when it is not disposed.</summary>
        Stream Output { get; set; }

        /// <summary>
        /// Create a dummy stream whose sole purpose is to stop the idiot
        /// implementation of CryptoStream closing the underlying stream
        /// when it is closed.
        /// </summary>
        /// <param name="Output">The output stream.</param>
        public CryptoStreamFix(Stream Output) => this.Output = Output;


        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be written 
        /// to the underlying device.
        /// </summary>
        public override void Flush() => Output.Flush();

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
        public override int Read(byte[] buffer, int offset, int count) => Output.Read(buffer, offset, count);
        
        /// <summary>
        /// Sets the position within the current buffered stream (not supported).
        /// </summary>
        /// <param name="offset">A byte offset relative to the <paramref name="origin"/> parameter.</param>
        /// <param name="origin">A value of type SeekOrigin indicating the reference point used to obtain the new position.</param>
        /// <returns></returns>
        public override long Seek(long offset, SeekOrigin origin) => Output.Seek(offset, origin);

        /// <summary>
        /// Sets the length of the current stream.
        /// </summary>
        /// <param name="value">The desired length of the current stream in bytes.</param>
        public override void SetLength(long value) => Output.SetLength(value);

        /// <summary>
        /// Write data to the output stream.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from 
        /// <paramref name="buffer"/> to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
        /// at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        public override void Write(byte[] buffer, int offset, int count) => Output.Write(buffer, offset, count);

        /// <summary>
        /// Closes the current stream and releases any resources (such as sockets and 
        /// file handles) associated with the current stream. Instead of calling this method, 
        /// ensure that the stream is properly disposed.
        /// </summary>
        public override void Close() => Flush();


        }
    }
