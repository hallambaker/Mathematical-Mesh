using System;
using System.IO;
using Goedel.Utilities;
using Goedel.Protocol;


namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// A stream that reads from a container record.
    /// </summary>
    public partial class JBCDFrameReader : Stream {
        #region // Boilerplate implementations
        /// <summary>
        /// Gets a value indicating whether the current stream supports reading (is always false).
        /// </summary>
        public override bool CanRead => true;

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking(is always false).
        /// </summary>
        public override bool CanSeek => false;

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing(is always true).
        /// </summary>
        public override bool CanWrite => false;

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
        public JBCDFrameReader(JBCDStream JBCDStream, ref long FrameRemaining) {
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

        #region // unsupported

        /// <summary>
        /// Gets the position within the current stream. The set operation is not supported.
        /// </summary>
        public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be written 
        /// to the underlying device.
        /// </summary>
        public override void Flush() { return; }

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
        /// Write data to the output stream.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from 
        /// <paramref name="buffer"/> to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
        /// at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>

        public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();
        #endregion
        }


    // This file has the methods that operate on the stream
    public partial class JBCDStream  {

        /// <summary>JSON-B Code for unidirectional frame</summary>
        public const byte UFrame = 0xF0;
        /// <summary>JSON-B Code for bidirectional frame</summary>
        public const byte BFrame = 0xF4;

        /// <summary>JSON-B Code for 8 bit length</summary>
        public const byte Length8 = 0x00;
        /// <summary>JSON-B Code for 16 bit length</summary>
        public const byte Length16 = 0x01;
        /// <summary>JSON-B Code for 32 bit length</summary>
        public const byte Length32 = 0x02;
        /// <summary>JSON-B Code for 64 bit length</summary>
        public const byte Length64 = 0x03;

        /// <summary>JSON-B Length mask </summary>
        public const byte LengthMask = 0x03;
        /// <summary>JSON-B Type mask </summary>
        public const byte TypeMask = 0xFC;

        readonly static byte[] CodeSpaces = new byte[] { 2, 3, 5, 9, 4, 6, 10, 18 };
        readonly static byte[] TagSpaces = new byte[] { 1, 2, 4, 8 };

        /* Static methods */

        /// <summary>
        /// Return the shortest tag length for the specified production.
        /// </summary>
        /// <param name="Length">Length of data to follow.</param>
        /// <returns>The tag length.</returns>
        public static int TagLength (long Length) {
            if (Length < 0x100) {
                return 2;
                }
            else if (Length < 0x10000) {
                return 3;
                }
            else if (Length < 0x100000000) {
                return 5;
                }
            else {
                return 9;
                }

            }
        /// <summary>
        /// Return the length of a code
        /// </summary>
        /// <param name="Code">Base code.</param>
        /// <returns>The number of bytes required.</returns>
        public static int TagSpace (int Code) => TagSpaces[Code & LengthMask];


        /// <summary>
        /// Return the length of a code
        /// </summary>
        /// <param name="Code">Base code.</param>
        /// <returns>The number of bytes required.</returns>
        public static int CodeSpace (int Code) {
            Assert.True(Code >= UFrame & Code <= (BFrame + Length64));

            return CodeSpaces[Code - UFrame];

            }


        /// <summary>
        /// Determine Tag length using the shortest possible production
        /// </summary>
        /// <param name="Length">Length of data to follow.</param>
        /// <returns>The number of bytes required.</returns>
        public static long TotalLength(long Length) => Length + TagLength(Length);

        /// <summary>
        /// Determine Tag length using the shortest possible production
        /// </summary>
        /// <param name="Length">Length of data to follow.</param>
        /// /// <returns>The number of bytes required.</returns>
        public static long TotalLength2(long Length) => Length + 2 * TagLength(Length);


        /* Write methods */


        /// <summary>
        /// Write out a Tag-Length value using the shortest possible production
        /// </summary>
        /// <param name="Code">Base code.</param>
        /// <param name="Length">Length of data to follow.</param>
        public void WriteTag (byte Code, long Length) {
            if (Length < 0x100) {
                WriteByte((byte)(Code + Length8));
                WriteByte((byte)(Length & 0xff));
                }
            else if (Length < 0x10000) {
                WriteByte((byte)(Code + Length16));
                WriteByte((byte)((Length >> 8) & 0xff));
                WriteByte((byte)(Length & 0xff));
                }
            else if (Length < 0x100000000) {
                WriteByte((byte)(Code + Length32));
                WriteByte((byte)((Length >> 24) & 0xff));
                WriteByte((byte)((Length >> 16) & 0xff));
                WriteByte((byte)((Length >> 8) & 0xff));
                WriteByte((byte)(Length & 0xff));
                }
            else {
                WriteByte((byte)(Code + Length64));
                WriteByte((byte)((Length >> 56) & 0xff));
                WriteByte((byte)((Length >> 48) & 0xff));
                WriteByte((byte)((Length >> 40) & 0xff));
                WriteByte((byte)((Length >> 32) & 0xff));
                WriteByte((byte)((Length >> 24) & 0xff));
                WriteByte((byte)((Length >> 16) & 0xff));
                WriteByte((byte)((Length >> 8) & 0xff));
                WriteByte((byte)(Length & 0xff));
                }
            }

        /// <summary>
        /// Write out a Tag-Length value using the shortest possible production
        /// </summary>
        /// <param name="Code">Base code.</param>
        /// <param name="Length">Length of data to follow.</param>
        public void WriteTagReverse (byte Code, long Length) {
            if (Length < 0x100) {
                WriteByte((byte)(Length & 0xff));
                WriteByte((byte)(Code + Length8));
                }
            else if (Length < 0x10000) {
                WriteByte((byte)(Length & 0xff));
                WriteByte((byte)((Length >> 8) & 0xff));
                WriteByte((byte)(Code + Length16));
                }
            else if (Length < 0x100000000) {
                WriteByte((byte)(Length & 0xff));
                WriteByte((byte)((Length >> 8) & 0xff));
                WriteByte((byte)((Length >> 16) & 0xff));
                WriteByte((byte)((Length >> 24) & 0xff));
                WriteByte((byte)(Code + Length32));
                }
            else {
                WriteByte((byte)(Length & 0xff));
                WriteByte((byte)((Length >> 8) & 0xff));
                WriteByte((byte)((Length >> 16) & 0xff));
                WriteByte((byte)((Length >> 24) & 0xff));
                WriteByte((byte)((Length >> 32) & 0xff));
                WriteByte((byte)((Length >> 40) & 0xff));
                WriteByte((byte)((Length >> 48) & 0xff));
                WriteByte((byte)((Length >> 56) & 0xff));
                WriteByte((byte)(Code + Length64));
                }
            }


        /// <summary>
        /// Write a unidirectional or bidirectional frame to the current stream at the current write position. 
        /// The code does not currently support 64 bit frames as it should.
        /// </summary>
        /// <param name="FrameData">The data to write.</param>
        /// <param name="Offset">Offset within the data.</param>
        /// <param name="Length">Number of bytes to write.</param>
        /// <param name="Bidirectional">If true, a bidirectional frame is written.</param>
        /// <returns>The total size of the frame.</returns>
        public long WriteFrame (byte[] FrameData,
                long Offset = 0, long Length = -1, bool Bidirectional = false) {
            Length = Length == -1 ? FrameData.LongLength : Length;

            Assert.True(Length <= Int32.MaxValue, FrameTooLargeException.Throw);

            if (Bidirectional) {
                WriteTag(BFrame, Length);
                }
            else {
                WriteTag(UFrame, Length);
                }
            Write(FrameData, (int)Offset, (int)Length); // Hack: Does not yet support 64 bit lengths as it should
            if (Bidirectional) {
                WriteTagReverse(BFrame, Length);
                return TotalLength2(Length);
                }
            else {
                return TotalLength(Length);
                }
            }

        /// <summary>
        /// Write a wrapped frame containing a header and an optional data section
        /// to the current stream at the current write position. 
        /// The code does not currently support 64 bit frames as it should.
        /// </summary>
        /// <param name="FrameHeader">The header data to write.</param>
        /// <param name="FrameData1">First data record, contains data content.</param>
        /// <param name="FrameData2">Second data record, contains protected metadata.</param>
        /// <returns>The total size of the frame.</returns>
        public long WriteWrappedFrame (
                    byte[] FrameHeader, 
                    byte[] FrameData1 = null,
                    byte[] FrameData2 = null) {

            var FrameLength = (FrameHeader == null ? 0 : TotalLength(FrameHeader.Length)) +
                                (FrameData1 == null ? 0 : TotalLength(FrameData1.Length)) +
                                (FrameData2 == null ? 0 : TotalLength(FrameData2.Length));

            WriteTag(BFrame, FrameLength);

            var Check = PositionWrite;
            if (FrameHeader != null) {
                WriteFrame(FrameHeader);
                }
            if (FrameData1 != null) {
                WriteFrame(FrameData1);
                }
            if (FrameData2 != null) {
                WriteFrame(FrameData2);
                }

            Assert.True(PositionWrite == Check + FrameLength, Internal.Throw);

            WriteTagReverse(BFrame, FrameLength);

            return TotalLength2(FrameLength);
            }


        long FrameLength;
        long Check;

        /// <summary>
        /// Write a wrapped frame containing a header and an optional data section
        /// to the current stream at the current write position. 
        /// The code does not currently support 64 bit frames as it should.
        /// </summary>
        /// <param name="FrameHeader">The header data to write.</param>
        /// <param name="FrameDataLength1">Length of the first data record, contains data content.</param>
        /// <returns>The total size of the frame.</returns>
        public long WriteWrappedFrameBegin(
                    byte[] FrameHeader,
                    long FrameDataLength1=-1) {

            FrameLength = (FrameHeader == null ? 0 : TotalLength(FrameHeader.Length)) +
                                (FrameDataLength1 < 0 ? 0 : TotalLength(FrameDataLength1));

            WriteTag(BFrame, FrameLength);

            Check = PositionWrite;
            if (FrameHeader != null) {
                WriteFrame(FrameHeader);
                }
            // here write out the binary marker for the frame data.
            WriteTag(UFrame, FrameDataLength1);

            return TotalLength2(FrameLength);
            }

        /// <summary>
        /// Complete writing out a wrapped frame. The frame must previously be started
        /// using a matching call to WriteWrappedFrameBegin. If the content written 
        /// does not match the length originally specified, an error is thrown.
        /// </summary>
        /// <returns>The total size of the frame.</returns>
        public long WriteWrappedFrameEnd() {
            Assert.True(PositionWrite == Check + FrameLength, Internal.Throw);

            WriteTagReverse(BFrame, FrameLength);

            return TotalLength2(FrameLength);
            }


        /// <summary>Begin partial write of binary data. 
        /// This is not yet implemented for standard streams.</summary>
        public virtual void WriteBinaryBegin(long Length, bool Terminal = true) => throw new NYI();

        /// <summary>Write binary data as length-data item.</summary>
        /// <param name="Data">Value to write</param>
        /// <param name="First">The index position of the first byte in the input data to process</param>
        /// <param name="Length">The number of bytes to process</param>
        public virtual void WriteBinaryPart(byte[] Data, long First = 0, long Length = -1) => throw new NYI();


        /// <summary>
        /// Read a length value of known length in the forward direction.
        /// </summary>
        /// <param name="LengthLength">The number of bytes to read.</param>
        /// <param name="Length">The length value read.</param>
        /// <returns>Always true. All failures trigger exceptions.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public virtual bool ReadLength (int LengthLength, out long Length) {
            Length = 0;
            for (var i = 0; i < LengthLength; i++) {
                var Value = ReadByte();
                Assert.False(Value < 0, InvalidFileFormatException.Throw);
                Length = (Length << 8) + Value;
                }
            return true;
            }

        /// <summary>
        /// Check a reversed length value of known length in the forward direction (from the start of the
        /// file to the end).
        /// </summary>
        /// <param name="Code">The code that was read</param>
        /// <param name="LengthIn">The length value read.</param>
        /// <returns>Always true. All failures trigger exceptions.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public virtual bool CheckReversedLength (int Code, long LengthIn) {

            var LengthCount = TagLength(LengthIn)-1;
            long Length = 0;
            for (var i = 0; i < LengthCount; i++) {
                var Value = (long)ReadByte();
                Assert.False(Value < 0, InvalidFileFormatException.Throw);
                Length = Length + (Value >> 8 * i);
                }
            var CheckTag = ReadByte();
            Assert.True(CheckTag == Code, InvalidFileFormatException.Throw);
            return Length == LengthIn;
            }

        /// <summary>
        /// Read a length value of known length in the reverse direction.
        /// </summary>
        /// <param name="LengthLength">The number of bytes to read.</param>
        /// <param name="Length">The length value read.</param>
        /// <returns>Always true. All failures trigger exceptions.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public bool ReadLengthReverse (int LengthLength, out long Length) {
            Length = 0;

            for (var i = 0; i < LengthLength; i++) {
                var Value = ReadByteReverse();
                Assert.False(Value < 0, InvalidFileFormatException.Throw);
                Length = (Length << 8) + Value;
                }
            return true;
            }

        /// <summary>
        /// Read a forward length tag in the forward direction
        /// </summary>
        /// <param name="Code">The tag code that was read</param>
        /// <param name="Length">The length that was read</param>
        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public virtual bool ReadTag (out int Code, out long Length) {
            Code = ReadByte();

            if (Code < 0) {
                Length = 0;
                return false;
                }

            return ReadLength(TagSpace(Code), out Length);

            }


        /// <summary>
        /// Read a forward length tag in the Reverse direction
        /// </summary>
        /// <param name="Code">The tag code that was read</param>
        /// <param name="Length">The length that was read</param>
        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public bool ReadTagReverse (out int Code, out long Length) {

            Code = ReadByteReverse();

            if (Code < 0) {
                Length = 0;
                return false;
                }

            return ReadLengthReverse(TagSpace(Code), out Length);

            }

        static byte[] Empty = new byte[0];

        /// <summary>
        ///  Read a frame in the forward direction.
        /// </summary>
        /// <param name="MaxLength">The maximum length of data to read including the tags</param>
        /// <param name="Data">The data that was read.</param>
        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public bool ReadRecord (ref long MaxLength, out byte[] Data) {
            Data = null;
            var Success = ReadTag(out var Code, out var Length);
            if (!Success) {
                return false;
                }

            MaxLength = MaxLength - CodeSpace(Code);
            Assert.True(Length <= MaxLength, InvalidFileFormatException.Throw);
            if (Length > 0) {
                Data = new byte[Length];
                var Bytes = Read(Data, 0, (int)Length);
                Assert.True(Bytes == Length, InvalidFileFormatException.Throw);
                MaxLength -= Length;
                }
            else {
                Data = Empty;
                }

            if ((Code & TypeMask) == BFrame) {
                CheckReversedLength(Code, Length);
                }

            return true;
            }

        /// <summary>
        /// Begin reading a record frame.
        /// </summary>
        /// <param name="MaxLength"></param>
        /// <returns></returns>
        public long ReadRecordBegin(ref long MaxLength) {
            StreamRead.Seek(FrameDataPosition, System.IO.SeekOrigin.Begin);

            var Success = ReadTag(out var Code, out var Length);
            if (!Success) {
                return -1;
                }
            MaxLength = MaxLength - CodeSpace(Code);
            Assert.True(Length <= MaxLength, InvalidFileFormatException.Throw);
            RecordDataRemaining = Length;
            MaxLength = MaxLength - Length;

            return Length;
            }


        /// <summary>
        /// Read record data.
        /// </summary>
        /// <param name="Buffer">Buffer to store record data.</param>
        /// <param name="Offset">Index to begin storing data.</param>
        /// <param name="Length">Maximum number of bytes to read. This will 
        /// be reduced if necessary to the remaining record to be read.</param>
        /// <returns>The number of bytes read.</returns>
        public int ReadRecordData(byte[] Buffer, int Offset=0, int Length=-1) {
            Length = Length < 0 ? Buffer.Length - Offset : Length;
            Length = (Length > RecordDataRemaining) ? (int)RecordDataRemaining : Length;
            RecordDataRemaining -= Length;
            return Read(Buffer, Offset, Length);
            }

        long FrameDataPosition;
        long RecordDataRemaining;


        /// <summary>
        /// Read a pair of wrapped frames in the forward direction.
        /// </summary>
        /// <param name="FrameData">The payload data that was read.</param>
        /// <param name="FrameHeader">The header data that was read.</param>
        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public bool ReadFrame (out byte[] FrameHeader, out byte[] FrameData) {
            FrameHeader = null;
            FrameData = null;

            var Success = ReadTag(out var Code, out var Length);
            var OriginalLength = Length;
            if (!Success) {
                return false;
                }
            if (Length > 0) {
                ReadRecord(ref Length, out FrameHeader);
                }
            if (Length > 0) {
                ReadRecord(ref Length, out FrameData);
                }
            if ((Code & TypeMask) == BFrame) {
                CheckReversedLength(Code, OriginalLength);
                }

            return true;
            }

        /// <summary>
        /// Records the start position of the last frame that was read.
        /// </summary>
        public long StartLastFrameRead { get; private set; } = 0;

        /// <summary>
        /// Move to the next position in the stream without reading any part of it.
        /// </summary>
        /// <returns></returns>
        public bool Next () {
            StartLastFrameRead = PositionRead;

            var Success = ReadTag(out var Code, out var Length);
            var OriginalLength = Length;
            if (!Success) {
                return false;
                }
            if (Length > 0) {
                StreamRead.Seek(Length, System.IO.SeekOrigin.Current);
                }
            if ((Code & TypeMask) == BFrame) {
                CheckReversedLength(Code, OriginalLength);
                }
            return true;
            }


        /// <summary>
        /// Move to the previous position in the stream without reading any part of it.
        /// </summary>
        /// <returns></returns>
        public bool Previous () {
            var Success = ReadTagReverse(out var Code, out var Length);
            if (!Success) {
                return false;
                }

            // Sanity check
            var ThePosition = PositionRead;
            Assert.True(ThePosition >= Length, InvalidFileFormatException.Throw);

            // Make sure we return to the same position.
            long Start = ThePosition - Length - TagSpace(Code) - 1;
            PositionRead = Start;

            return true;
            }



        /// <summary>
        /// Read a pair of wrapped frames in the forward direction.
        /// </summary>
        /// <param name="FrameHeader">The header data that was read.</param>
        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public long ReadFrame (out byte[] FrameHeader) {
            FrameHeader = null;
            StartLastFrameRead = PositionRead;

            var Success = ReadTag(out var Code, out var Length);
            var OriginalLength = Length;
            if (!Success) {
                return -1;
                }
            if (Length > 0) {
                ReadRecord(ref Length, out FrameHeader);
                }
            if (Length > 0) {
                FrameDataPosition = StreamRead.Position;
                StreamRead.Seek(Length, System.IO.SeekOrigin.Current);
                }
            if ((Code & TypeMask) == BFrame) {
                CheckReversedLength(Code, OriginalLength);
                }

            return Length;
            }


        /// <summary>
        /// Read a pair of wrapped frames in the reverse direction. This is typically done to read the last
        /// record in a file to see how the file should be extended.
        /// </summary>
        /// <param name="FrameData">The payload data that was read.</param>
        /// <param name="FrameHeader">The header data that was read.</param>
        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public bool ReadFrameReverse (out byte[] FrameHeader, out byte[] FrameData) {
            var Success = ReadTagReverse(out var Code, out var Length);
            if (!Success) {
                FrameHeader = null;
                FrameData = null;
                return false;
                }
 
            // Sanity check
            var ThePosition = PositionRead;
            Assert.True(ThePosition >= Length, InvalidFileFormatException.Throw);

            // Make sure we return to the same position.
            long Start = ThePosition - Length - TagSpace(Code)-1;

            PositionRead = Start;
            ReadFrame(out FrameHeader, out FrameData);
            PositionRead = Start;

            return true;
            }


        /// <summary>
        /// Read a pair of wrapped frames in the reverse direction. This is typically done to read the last
        /// record in a file to see how the file should be extended.
        /// </summary>
        /// <param name="FrameHeader">The header data that was read.</param>
        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public long ReadFrameReverse (out byte[] FrameHeader) {
            var Success = ReadTagReverse(out var Code, out var Length);
            if (!Success) {
                FrameHeader = null;
                return -1;
                }

            // Sanity check
            var ThePosition = PositionRead;
            Assert.True(ThePosition >= Length, InvalidFileFormatException.Throw);

            // Make sure we return to the same position.
            long Start = ThePosition - Length - TagSpace(Code) -1;

            PositionRead = Start;
            var Result = ReadFrame(out FrameHeader);
            PositionRead = Start;

            return Result;
            }



        /// <summary>
        /// Read the final frame header
        /// </summary>
        /// <returns>The last frame header</returns>
        public ContainerHeader ReadFrameHeader () {
            ReadFrame(out var HeaderData);
            return ContainerHeader.FromJSON(HeaderData.JSONReader(), false);
            }


        /// <summary>
        /// Read the final frame header
        /// </summary>
        /// <returns>The last frame header</returns>
        public ContainerHeader ReadFirstFrameHeader () {
            Begin();
            ReadFrame(out var HeaderData);
            return ContainerHeaderFirst.FromJSON(HeaderData.JSONReader(), false);
            }

        /// <summary>
        /// Read the final frame header
        /// </summary>
        /// <returns>The last frame header</returns>
        public ContainerHeader ReadLastFrameHeader () {
            End();
            ReadFrameReverse(out var HeaderData);
            End();

            var HeaderText = HeaderData.ToUTF8();

            return ContainerHeader.FromJSON(HeaderData.JSONReader(), false);
            }

        }

    }
