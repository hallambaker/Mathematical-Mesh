using Goedel.IO;

using System;
using System.IO;


namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// Debugging version of JBCDStream
    /// </summary>
    public class JBCDStreamDebug : JBCDStream {
        TextWriter Output;

        /// <summary>
        /// Output flag. 
        /// </summary>
        public bool Active = true;

        /// <summary>
        /// Constructor from a file
        /// </summary>
        /// <param name="FileName">The file to open.</param>
        /// <param name="FileStatus">The file access mode.</param>
        /// <param name="WriteOnly">If true, the file is only opened in write mode.</param>
        /// <param name="Output">The additional output stream.</param>
        public JBCDStreamDebug(string FileName, FileStatus FileStatus = FileStatus.Read,
                            bool WriteOnly = false, TextWriter Output = null)
            : base(FileName, FileStatus, WriteOnly) {
            Output ??= Console.Out;

            this.Output = Output;
            }
        /// <summary>
        /// Constructor from a stream
        /// </summary>
        /// <param name="Stream">The underlying stream. This must support the seek operation.</param>
        /// <param name="Output">The additional output stream.</param>
        public JBCDStreamDebug(Stream Stream, TextWriter Output = null) : base(Stream, null) {
            Output ??= Console.Out;

            this.Output = Output;
            }

        /// <summary>
        /// Reads a byte from the stream and advances the position within the stream by one byte, or returns -1 if 
        /// at the end of the stream.
        /// </summary>
        /// <returns>The unsigned byte cast to an Int32, or -1 if at the end of the stream.</returns>
        public override int ReadByte() {
            var Result = base.ReadByte();

            if (Active) {
                if (Result < 0) {
                    Output.Write("[EOF] ");
                    }
                else {
                    Output.Write("{0:x2} ", Result);
                    }
                }


            return Result;
            }

        /// <summary>
        /// Read a byte in the reverse direction, i.e. the byte immediately preceding the 
        /// current position.
        /// </summary>
        /// <returns>The byte read or -1.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public override int ReadByteReverse() {
            if (Active) {
                Output.Write(" >");
                }
            var Result = base.ReadByteReverse();
            if (Active) {
                Output.Write("< ");
                }
            return Result;
            }

        /// <summary>
        /// Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
        /// </summary>
        /// <param name="Buffer"> An array of bytes. When this method returns, the buffer contains the specified byte array with the values between 
        /// offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
        /// <param name="Offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="Count">Number of bytes to read.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes requested 
        /// if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.</returns>
        public override int Read(byte[] Buffer, int Offset, int Count) {
            var Result = base.Read(Buffer, Offset, Count);


            WriteBytes(Buffer, Offset, Count);

            return Result;
            }

        /// <summary>
        /// Maximum number of bytes to display before turning on summary mode.
        /// </summary>
        public int DisplayBytesMax { get; set; } = 80;

        /// <summary>
        /// Number of bytes to display in summary mode.
        /// </summary>
        public int DisplayBytesSummary { get; set; } = 28;

        void WriteBytes(byte[] Buffer, int Offset, int Count) {

            if (!Active) {
                return;
                }

            if (DisplayBytesMax >= 0 & (Count > DisplayBytesMax)) {
                WriteBytes(Buffer, Offset, DisplayBytesSummary);
                Output.WriteLine("  ...");
                WriteBytes(Buffer, Offset + Count - DisplayBytesSummary, DisplayBytesSummary);

                DisplayBytesMax = -1;
                }
            else {

                for (var i = 0; i < Count; i++) {
                    if ((i % 8) == 0) {
                        Output.Write("  ");
                        }
                    Output.Write("{0:x2} ", Buffer[Offset + i]);
                    if (((i + 1) % 16) == 0) {
                        Output.WriteLine();
                        }
                    }
                Output.WriteLine();
                }
            }


        /// <summary>
        /// Read a forward length tag in the forward direction
        /// </summary>
        /// <param name="Code">The tag code that was read</param>
        /// <param name="Length">The length that was read</param>
        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public override bool ReadTag(out int Code, out long Length) {
            var Result = base.ReadTag(out Code, out Length);
            if (Active) {
                Output.WriteLine();
                }
            return Result;
            }

        /// <summary>
        /// Check a reversed length value of known length in the forward direction (from the start of the
        /// file to the end).
        /// </summary>
        /// <param name="Code">The tag code that was read</param>
        /// <param name="LengthIn">The length that was read</param>
        /// <returns>Always true. All failures trigger exceptions.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public override bool CheckReversedLength(int Code, long LengthIn) {
            var Result = base.CheckReversedLength(Code, LengthIn);
            if (Active) {
                Output.WriteLine();
                }
            return Result;
            }


        }
    }
