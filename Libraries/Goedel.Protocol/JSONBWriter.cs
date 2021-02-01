//   Copyright © 2015 by Comodo Group Inc.
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
//  
//  

using Goedel.Utilities;

using System.IO;

namespace Goedel.Protocol {


    ///// <summary>
    ///// A Stream that packages data as a JSON-B Stream.
    ///// </summary>
    //public class JSONBStreamWriter : Stream {

    //    #region // Boilerplate implementations
    //    /// <summary>
    //    /// Gets a value indicating whether the current stream supports reading (is always false).
    //    /// </summary>
    //    public override bool CanRead => false;

    //    /// <summary>
    //    /// Gets a value indicating whether the current stream supports seeking(is always false).
    //    /// </summary>
    //    public override bool CanSeek => false;

    //    /// <summary>
    //    /// Gets a value indicating whether the current stream supports writing(is always true).
    //    /// </summary>
    //    public override bool CanWrite => true;

    //    /// <summary>
    //    /// Gets the position within the current stream. The set operation is not supported.
    //    /// </summary>
    //    public override long Position {
    //        get => Output.Position;
    //        set => throw new NotImplementedException(); }

    //    /// <summary>
    //    /// Copies bytes from the current buffered stream to an array (not supported).
    //    /// </summary>
    //    /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the 
    //    /// specified byte array with the values between <paramref name="offset"/> and 
    //    /// (<paramref name="offset"/> + <paramref name="count"/> - 1) 
    //    /// replaced by the bytes read from the current source.</param>
    //    /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing 
    //    /// the data read from the current stream.</param>
    //    /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
    //    /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes 
    //    /// requested if that many bytes are not currently available, or zero (0) if the end of the stream 
    //    /// has been reached.</returns>
    //    public override int Read(byte[] buffer, int offset, int count) => throw new NotImplementedException();

    //    /// <summary>
    //    /// Sets the position within the current buffered stream (not supported).
    //    /// </summary>
    //    /// <param name="offset">A byte offset relative to the <paramref name="origin"/> parameter.</param>
    //    /// <param name="origin">A value of type SeekOrigin indicating the reference point used to obtain the new position.</param>
    //    /// <returns></returns>
    //    public override long Seek(long offset, SeekOrigin origin) => throw new NotImplementedException();


    //    #endregion

    //    Stream Output;

    //    /// <summary>
    //    /// Construct a JSONBStreamWriter as a pipe writing to the specified output stream.
    //    /// </summary>
    //    /// <param name="Output"></param>
    //    /// <param name="FrameLength"></param>
    //    /// <param name="BufferSize">The suggested buffer size.</param>
    //    public JSONBStreamWriter(
    //            Stream Output,
    //            long FrameLength=-1,
    //            int BufferSize=4096) {
    //        this.Output = Output;
    //        StartFrame(FrameLength);
    //        }

    //    /// <summary>
    //    /// Sets the length of the output frame.
    //    /// </summary>
    //    /// <param name="value"></param>
    //    public override void SetLength(long value) => StartFrame(value);

    //    /// <summary>
    //    /// Gets the frame length in bytes. 
    //    /// </summary>
    //    public override long Length => _Length;
    //    long _Length = 0;

    //    /// <summary>
    //    /// Start wrtiting a new fixed length frame.
    //    /// </summary>
    //    /// <param name="Length"></param>
    //    void StartFrame(long Length) => _Length = Length;

    //    /// <summary>
    //    /// Write data to the output stream.
    //    /// </summary>
    //    /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from 
    //    /// <paramref name="buffer"/> to the current stream.</param>
    //    /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
    //    /// at which to begin copying bytes to the current stream.</param>
    //    /// <param name="count">The number of bytes to be written to the current stream.</param>
    //    public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();

    //    /// <summary>
    //    /// Clears all buffers for this stream and causes any buffered data to be written 
    //    /// to the underlying device.
    //    /// </summary>
    //    public override void Flush() => throw new NotImplementedException();

    //    }

    /// <summary>
    /// JSON Writer for JSON-B, a superset of JSON encoding with codes that permit
    /// efficient encoding of binary data and strings and encoding of floating point
    /// values without loss of precision.
    /// </summary>
    public class JSONBWriter : JsonWriter {



        /// <summary>
        /// Create a new JSON Writer.
        /// </summary>
        public JSONBWriter() => Output = new MemoryStream();

        /// <summary>
        /// Create a new JSON Writer using the specified output buffer. If the buffer has
        /// an output stream defined, text will be written to the stream.
        /// </summary>
        /// <param name="Output">Output buffer</param> 
        public JSONBWriter(MemoryStream Output) => this.Output = Output;

        /// <summary>
        /// Create a new JSON Writer using the specified output buffer. If the buffer has
        /// an output stream defined, text will be written to the stream. Note that
        /// the property GetBytes will return null unless the specified stream is a 
        /// memory stream.
        /// </summary>
        /// <param name="Output">Output buffer</param> 
        public JSONBWriter(Stream Output) => this.Output = Output;



        /// <summary>
        /// Write out a Tag-Length value using the shortest possible production
        /// </summary>
        /// <param name="Code">Base code.</param>
        /// <param name="Length">Length of data to follow.</param>
        public void WriteTag(byte Code, long Length) => WriteTag(Output, Code, Length);


        /// <summary>
        /// Write out a Tag-Length value using the shortest possible production
        /// to <paramref name="Output"/>.
        /// </summary>
        /// <param name="Output">The output stream to write to.</param>
        /// <param name="Code">Base code.</param>
        /// <param name="Length">Length of data to follow.</param>
        public static void WriteTag(Stream Output, byte Code, long Length) {
            if (Length < 0x100) {
                Output.Write((byte)(Code + JSONBCD.Length8));
                Output.Write((byte)(Length & 0xff));
                }
            else if (Length < 0x10000) {
                Output.Write((byte)(Code + JSONBCD.Length16));
                Output.Write((byte)((Length >> 8) & 0xff));
                Output.Write((byte)(Length & 0xff));
                }
            else if (Length < 0x100000000) {
                Output.Write((byte)(Code + JSONBCD.Length32));
                Output.Write((byte)((Length >> 24) & 0xff));
                Output.Write((byte)((Length >> 16) & 0xff));
                Output.Write((byte)((Length >> 8) & 0xff));
                Output.Write((byte)(Length & 0xff));
                }
            else {
                Output.Write((byte)(Code + JSONBCD.Length64));
                Output.Write((byte)((Length >> 56) & 0xff));
                Output.Write((byte)((Length >> 48) & 0xff));
                Output.Write((byte)((Length >> 40) & 0xff));
                Output.Write((byte)((Length >> 32) & 0xff));
                Output.Write((byte)((Length >> 24) & 0xff));
                Output.Write((byte)((Length >> 16) & 0xff));
                Output.Write((byte)((Length >> 8) & 0xff));
                Output.Write((byte)(Length & 0xff));
                }
            }

        /// <summary>Write integer.</summary>
        /// <param name="Data">Value to write</param>
        protected void WriteInteger(long Data) {
            if (Data >= 0) {
                WriteTag(JSONBCD.PositiveInteger, Data);
                }
            else {
                WriteTag(JSONBCD.NegativeInteger, -Data);
                }
            }

        /// <summary>
        /// Write Tag to the stream
        /// </summary>
        /// <param name="Tag">Tag text.</param>
        /// <param name="IndentIn">Current indent level.</param>
        public override void WriteToken(string Tag, int IndentIn) {
            WriteTag(JSONBCD.TagString, Tag.Length);
            Output.Write(Tag);
            }

        /// <summary>Write 32 bit integer.</summary>
        /// <param name="Data">Value to write</param>
        public override void WriteInteger32(int Data) => WriteInteger(Data);

        /// <summary>Write 64 bit integer.</summary>
        /// <param name="Data">Value to write</param>
        public override void WriteInteger64(long Data) => WriteInteger(Data);

        /// <summary>Write float32</summary>
        /// <param name="Data">Value to write</param>
        public override void WriteFloat32(float Data) => Output.Write(Data.ToString());

        /// <summary>Write float64</summary>
        /// <param name="Data">Value to write</param>
        public override void WriteFloat64(double Data) => Output.Write(Data.ToString());

        /// <summary>Write boolean.</summary>
        /// <param name="Data">Value to write</param>
        public override void WriteBoolean(bool Data) {
            if (Data) {
                Output.Write(JSONBCD.True);
                }
            else {
                Output.Write(JSONBCD.False);
                }
            }

        /// <summary>Write string without escaping.</summary>
        /// <param name="Data">Value to write</param>
        public override void WriteString(string Data) {
            WriteTag(JSONBCD.StringTerm, Data.Length);
            Output.Write(Data);
            }


        /// <summary>Write binary data as length-data item.</summary>
        /// <param name="buffer">Value to write</param>
        /// <param name="Stream">The output stream.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
        /// at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param> 
        public static void WriteBinary(Stream Stream, byte[] buffer, int offset = 0, int count = -1) {
            var Length = count < 0 ? buffer.Length : count;
            WriteTag(Stream, JSONBCD.DataTerm, Length);
            Stream.Write(buffer, offset, Length);
            }

        /// <summary>Write binary data as length-data item.</summary>
        /// <param name="buffer">Value to write</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
        /// at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param> 

        public override void WriteBinary(byte[] buffer, int offset = 0, int count = -1) {
            var Length = count < 0 ? buffer.Length : count;
            WriteTag(JSONBCD.DataTerm, Length);
            Output.Write(buffer);
            }

        long PartLength = 0;
        /// <summary>Write binary data as length-data item.</summary>
        /// <param name="Length">The length of the chunk to be written.</param>
        /// <param name="Terminal">If true, this is the last chunk in a sequence.</param>
        public override void WriteBinaryBegin(long Length, bool Terminal = true) {
            WriteTag(Terminal ? JSONBCD.DataTerm : JSONBCD.DataChunk, Length);
            PartLength = Length;
            }

        /// <summary>Write binary data as length-data item.</summary>
        /// <param name="Data">Value to write</param>
        /// <param name="First">The index position of the first byte in the input data to process</param>
        /// <param name="Length">The number of bytes to process</param>
        public override void WriteBinaryPart(byte[] Data, long First = 0, long Length = -1) {
            Length = Length < 0 ? Data.Length : Length;

            PartLength -= Length;
            Assert.AssertTrue(PartLength >= 0, BadPartLength.Throw);
            Output.Write(Data, (int)First, (int)Length);
            }


        /// <summary>Mark start of array element</summary>
        public override void WriteArrayStart() => Output.Write("[");

        /// <summary>Mark middle of array element</summary>
        /// <param name="first">If true, this is the first element. 
        /// The value is set false on each call</param>
        public override void WriteArraySeparator(ref bool first) {
            }


        /// <summary>Mark end of array element</summary>
        public override void WriteArrayEnd() => Output.Write("]");

        /// <summary>Mark start of object element</summary>
        // Mark the start, middle and end of object elements
        public override void WriteObjectStart() => Output.Write("{");

        /// <summary>Mark middle of object element</summary>
        /// <param name="first">If true, this is the first element. 
        /// The value is set false on each call</param>
        public override void WriteObjectSeparator(ref bool first) {
            }

        /// <summary>Mark end of object element</summary>
        public override void WriteObjectEnd() => Output.Write("}");
        }
    }
