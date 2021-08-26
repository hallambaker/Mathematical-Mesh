#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion
using System;
using System.IO;

using Goedel.IO;
using Goedel.Utilities;


namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// Implements a highly restricted stream that supports exactly the functionality
    /// required by the JBCD Reader/Writer extensions. In the base class, the underlying
    /// implementation is supplied by a Stream object (typically a FileStream). It is
    /// expected this will be replaced in the future by a version that performs direct 
    /// memory mapping of the files.
    /// </summary>
    public partial class JbcdStream : Disposable {

        /// <summary>
        /// The underlying stream for stream write operations
        /// </summary>
        public Stream StreamWrite;

        /// <summary>
        /// The underlying stream for stream write operations
        /// </summary>
        public Stream StreamRead;

        Stream disposeStreamRead = null;
        Stream disposeStreamWrite = null;


        string Filename { get; }

        /// <summary>
        /// The current position within the stream.
        /// </summary>
        public long PositionWrite {
            get => StreamWrite.Position;
            set => StreamWrite.Seek(0, SeekOrigin.Begin);
            }

        /// <summary>
        /// The current position within the stream.
        /// </summary>
        public long PositionRead {
            get => StreamRead.Position;
            set => StreamRead.Seek(value, SeekOrigin.Begin);
            }

        /// <summary>
        /// Returns true if and only if the stream reader is at the end of the file.
        /// </summary>
        public bool EOF => StreamRead.Position >= StreamRead.Length;

        /// <summary>
        /// A long value representing the length of the stream in bytes.
        /// </summary>
        public long Length => StreamWrite != null ? StreamWrite.Length : StreamRead.Length;

        ///<summary>The reader writer lock for the underlying file.</summary>
        public LockGlobal LockGlobal = null;

        /// <summary>
        /// Constructor from a file
        /// </summary>
        /// <param name="fileName">The file to open.</param>
        /// <param name="fileStatus">The file access mode.</param>
        /// <param name="writeOnly">If true, the file is only opened in write mode.</param>
        public JbcdStream(string fileName, FileStatus fileStatus = FileStatus.Read, bool writeOnly = false) {
            Filename = fileName;


            if (fileStatus == FileStatus.ConcurrentLocked) {
                LockGlobal = new LockGlobal(UDF.LockName(fileName));
                }

            if (fileStatus != FileStatus.Read) {
                //Screen.WriteLine($"Open for write {fileName}");


                StreamWrite = fileName.FileStream(fileStatus);
                disposeStreamWrite = StreamWrite;
                StreamWrite.Seek(0, SeekOrigin.End);
                }
            if (!writeOnly) {
                //Screen.WriteLine($"Open for read {fileName}");


                StreamRead = fileName.FileStream(FileStatus.Read);
                disposeStreamRead = StreamRead;
                }
            }


        /// <summary>
        /// Constructor from a stream
        /// </summary>
        /// <param name="StreamRead">The underlying stream. This must support the seek operation.</param>
        /// <param name="StreamWrite">The underlying stream. This must support the seek operation.</param>
        public JbcdStream(Stream StreamRead, Stream StreamWrite) {
            this.StreamRead = StreamRead;
            this.StreamWrite = StreamWrite;
            StreamWrite?.Seek(0, SeekOrigin.End);
            }

        /// <summary>
        /// Dispose method, frees all resources.
        /// </summary>
        protected override void Disposing() {
            //Screen.WriteLine($"close {Filename} read {disposeStreamRead != null} write {disposeStreamWrite!=null}");



            disposeStreamWrite?.Dispose();
            disposeStreamRead?.Dispose();
            LockGlobal?.Dispose();
            }


        /// <summary>
        /// Sets the read position within the current stream.
        /// </summary>
        /// <param name="Offset">A byte offset relative to the origin parameter.</param>
        /// <param name="Origin">A value of type SeekOrigin indicating the reference point used to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
        public virtual long Seek(long Offset, SeekOrigin Origin) => StreamRead.Seek(Offset, Origin);

        /// <summary>
        /// Move the read position to the beginning of the stream.
        /// </summary>
        /// <returns>The new position within the current stream.</returns>
        public virtual long Begin() {
            framerFrameStart = StreamRead.Seek(0, SeekOrigin.Begin);
            return framerFrameStart;
            }

        /// <summary>
        /// Move the read position to the end of the stream.
        /// </summary>
        /// <returns>The new position within the current stream.</returns>
        public virtual long End() {
            if (LockGlobal == null) {
                return StreamRead.Seek(0, SeekOrigin.End);
                }
            try {
                LockGlobal.Enter();
                var result = StreamRead.Seek(0, SeekOrigin.End);
                LockGlobal.Exit();
                return result;
                }
            catch (Exception exception) {
                LockGlobal.Exit();
                exception.Future();
                throw;
                }

            }


        /* Write functions */

        /// <summary>
        /// Set the write pointer to the end of the container.
        /// </summary>
        public virtual void SeekWrite() {
            if (StreamWrite != null) {
                StreamWrite.Seek(0, SeekOrigin.End);
                }
            }


        /// <summary>
        /// Writes a byte to the end of the stream.
        /// </summary>
        /// <param name="Value">The byte to write to the stream.</param>
        public virtual void WriteByte(byte Value) => StreamWrite.WriteByte(Value);

        /// <summary>
        /// Writes a sequence of bytes to the current stream and advances
        /// the current position within this stream by the number of bytes written.
        /// </summary>
        /// <param name="Buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
        /// <param name="Offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="Count">The number of bytes to be written to the current stream.</param>
        public virtual void Write(byte[] Buffer, int Offset = 0, int Count = -1) {
            Count = Count < 0 ? Buffer.Length : Count;
            StreamWrite.Write(Buffer, Offset, Count);
            }

        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be written to the underlying device.
        /// </summary>
        public virtual void Flush() => StreamWrite.Flush();

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
        public virtual int Read(byte[] Buffer, int Offset, int Count) => StreamRead.Read(Buffer, Offset, Count);

        /// <summary>
        /// Reads a byte from the stream and advances the position within the stream by one byte, or returns -1 if 
        /// at the end of the stream.
        /// </summary>
        /// <returns>The unsigned byte cast to an Int32, or -1 if at the end of the stream.</returns>
        public virtual int ReadByte() => StreamRead.ReadByte();

        /// <summary>
        /// Read a byte in the reverse direction, i.e. the byte immediately preceding the current position.
        /// </summary>
        /// <returns>The byte read or -1.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public virtual int ReadByteReverse() {
            Assert.AssertTrue(PositionRead > 0, InvalidFileFormatException.Throw);
            Seek(-1, SeekOrigin.Current);
            var Value = ReadByte();
            Seek(-1, SeekOrigin.Current);
            return Value;
            }
        }

    }
