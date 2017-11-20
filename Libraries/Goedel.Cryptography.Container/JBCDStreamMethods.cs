using System;
//using System.IO;
using Goedel.Utilities;
using Goedel.Protocol;


namespace Goedel.Cryptography.Container {


    // This file has the methods that operate on the stream
    public partial class JBCDStream {

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
        public static int CodeSpace (int Code) {
            Assert.True(Code >= UFrame & Code <= (BFrame + Length64));

            return CodeSpaces[Code - UFrame];

            }


        /// <summary>
        /// Determine Tag length using the shortest possible production
        /// </summary>
        /// <param name="Length">Length of data to follow.</param>
        /// <returns>The number of bytes required.</returns>
        public static long TotalLength (long Length) {
            return Length + TagLength(Length);
            }

        /// <summary>
        /// Determine Tag length using the shortest possible production
        /// </summary>
        /// <param name="Length">Length of data to follow.</param>
        /// /// <returns>The number of bytes required.</returns>
        public static long TotalLength2 (long Length) {
            return Length + 2 * TagLength(Length);
            }


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
        /// <param name="FrameData">The payload data to write.</param>
        /// <param name="FrameHeader">The header data to write.</param>
        /// <returns>The total size of the frame.</returns>
        public long WriteWrappedFrame (byte[] FrameHeader, byte[] FrameData = null) {

            var FrameLength = (FrameHeader == null ? 0 : TotalLength(FrameHeader.Length)) +
                                (FrameData == null ? 0 : TotalLength(FrameData.Length));

            WriteTag(BFrame, FrameLength);

            var Check = Position;
            if (FrameHeader != null) {
                WriteFrame(FrameHeader);
                }
            if (FrameData != null) {
                WriteFrame(FrameData);
                }

            Assert.True(Position == Check + FrameLength, Internal.Throw);

            WriteTagReverse(BFrame, FrameLength);

            return TotalLength2(FrameLength);
            }


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

            var LengthCode = Code & LengthMask;

            switch (LengthCode) {
                case Length8: {
                    return ReadLength(1, out Length);
                    }
                case Length16: {
                    return ReadLength(2, out Length);
                    }
                case Length32: {
                    return ReadLength(4, out Length);
                    }
                default: {
                    return ReadLength(8, out Length);
                    }
                }

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

            var LengthCode = Code & LengthMask;

            switch (LengthCode) {
                case Length8: {
                    return ReadLengthReverse(1, out Length);
                    }
                case Length16: {
                    return ReadLengthReverse(2, out Length);
                    }
                case Length32: {
                    return ReadLengthReverse(4, out Length);
                    }
                default: {
                    return ReadLengthReverse(8, out Length);
                    }
                }

            }

        /// <summary>
        ///  Read a frame in the forward direction.
        /// </summary>
        /// <param name="MaxLength">The maximum length of data to read including the tags</param>
        /// <param name="Data">The data that was read.</param>
        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public bool ReadFrame (ref long MaxLength, out byte[] Data) {
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

            if ((Code & TypeMask) == BFrame) {
                CheckReversedLength(Code, Length);
                }


            return true;
            }

        /// <summary>
        /// Read a pair of wrapped frames in the forward direction.
        /// </summary>
        /// <param name="FrameData">The payload data that was read.</param>
        /// <param name="FrameHeader">The header data that was read.</param>
        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public bool ReadWrappedFrame (out byte[] FrameHeader, out byte[] FrameData) {
            FrameHeader = null;
            FrameData = null;

            var Success = ReadTag(out var Code, out var Length);
            var OriginalLength = Length;
            if (!Success) {
                return false;
                }
            if (Length > 0) {
                ReadFrame(ref Length, out FrameHeader);
                }
            if (Length > 0) {
                ReadFrame(ref Length, out FrameData);
                }
            if ((Code & TypeMask) == BFrame) {
                CheckReversedLength(Code, OriginalLength);
                }

            return true;
            }


        /// <summary>
        /// Read a pair of wrapped frames in the reverse direction. This is typically done to read the last
        /// record in a file to see how the file should be extended.
        /// </summary>
        /// <param name="FrameData">The payload data that was read.</param>
        /// <param name="FrameHeader">The header data that was read.</param>
        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
        public bool ReadWrappedFrameReverse (out byte[] FrameHeader, out byte[] FrameData) {
            var Success = ReadTagReverse(out var Code, out var Length);
            if (!Success) {
                FrameHeader = null;
                FrameData = null;
                return false;
                }
 
            // Sanity check
            var ThePosition = Position;
            Assert.True(ThePosition >= Length, InvalidFileFormatException.Throw);

            // Make sure we return to the same position.
            long Start = ThePosition - Length;

            Position = Start;
            ReadWrappedFrame(out FrameHeader, out FrameData);
            Position = Start;

            return true;
            }

        }

    }
