//using System;
//using System.IO;
//using Goedel.Utilities;
//using Goedel.Protocol;


//namespace Goedel.Cryptography.Container {

//    /// <summary>
//    /// Interface to generalized stream writer. This interface is not satisfactory as write chunks
//    /// are limited to 2^32 bytes. Making use of this interface should make eventual transition to a 
//    /// memory mapped approach easier.
//    /// </summary>
//    public interface IWriteStream {

//        /// <summary>
//        /// When implemented in a derived class, sets the position within the current stream.
//        /// </summary>
//        /// <param name="offset">A byte offset relative to the origin parameter.</param>
//        /// <param name="origin">A value of type SeekOrigin indicating the reference point used to obtain the new position.</param>
//        /// <returns>The new position within the current stream.</returns>
//        long Seek (long offset, SeekOrigin origin);

//        /// <summary>
//        /// Writes a byte to the current position in the stream and advances the position within the stream by one byte.
//        /// </summary>
//        /// <param name="value">The byte to write to the stream.</param>
//        void WriteByte (byte value);

//        /// <summary>
//        /// When implemented in a derived class, writes a sequence of bytes to the current stream and advances the 
//        /// current position within this stream by the number of bytes written.
//        /// </summary>
//        /// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
//        /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
//        /// <param name="count">The number of bytes to be written to the current stream.</param>
//        void Write (byte[] buffer, int offset, int count);
//        }


//    /// <summary>
//    /// 
//    /// </summary>
//    public static class JBCDExtensions {
//        public const byte UFrame = 0xF0;
//        public const byte BFrame = 0xF4;

//        public const byte Length8 = 0x00;
//        public const byte Length16 = 0x01;
//        public const byte Length32 = 0x02;
//        public const byte Length64 = 0x03;

//        public const byte LengthMask = 0x03;
//        public const byte TypeMask = 0xFC;

//        public readonly static byte[] CodeSpaces = new byte[] { 1, 2, 4, 8, 2, 4, 8, 16 };

//        /// <summary>
//        /// Return the shortest tag length for the specified production.
//        /// </summary>
//        /// <param name="Code">Base code.</param>
//        /// <param name="Length">Length of data to follow.</param>
//        public static int TagLength (long Length) {
//            if (Length < 0x100) {
//                return 2;
//                }
//            else if (Length < 0x10000) {
//                return 3;
//                }
//            else if (Length < 0x100000000) {
//                return 5;
//                }
//            else {
//                return 9;
//                }

//            }

//        /// <summary>
//        /// Write out a Tag-Length value using the shortest possible production
//        /// </summary>
//        /// <param name="Code">Base code.</param>
//        /// <param name="Length">Length of data to follow.</param>
//        public static int CodeSpace (int Code) {
//            Assert.True(Code >= UFrame & Code <= (BFrame + Length64));

//            return CodeSpaces[Code - UFrame];

//            }


//        /// <summary>
//        /// Write out a Tag-Length value using the shortest possible production
//        /// </summary>
//        /// <param name="Code">Base code.</param>
//        /// <param name="Length">Length of data to follow.</param>
//        public static long TotalLength (long Length) {
//            return Length + TagLength(Length);
//            }

//        /// <summary>
//        /// Write out a Tag-Length value using the shortest possible production
//        /// </summary>
//        /// <param name="Code">Base code.</param>
//        /// <param name="Length">Length of data to follow.</param>
//        public static long TotalLength2 (long Length) {
//            return Length + 2 * TagLength(Length);
//            }

//        /// <summary>
//        /// Write out a Tag-Length value using the shortest possible production
//        /// </summary>
//        /// <param name="Code">Base code.</param>
//        /// <param name="Length">Length of data to follow.</param>
//        public static void WriteTag (this Stream Output, byte Code, long Length) {
//            if (Length < 0x100) {
//                Output.WriteByte((byte)(Code + Length8));
//                Output.WriteByte((byte)(Length & 0xff));
//                }
//            else if (Length < 0x10000) {
//                Output.WriteByte((byte)(Code + Length16));
//                Output.WriteByte((byte)((Length >> 8) & 0xff));
//                Output.WriteByte((byte)(Length & 0xff));
//                }
//            else if (Length < 0x100000000) {
//                Output.WriteByte((byte)(Code + Length32));
//                Output.WriteByte((byte)((Length >> 24) & 0xff));
//                Output.WriteByte((byte)((Length >> 16) & 0xff));
//                Output.WriteByte((byte)((Length >> 8) & 0xff));
//                Output.WriteByte((byte)(Length & 0xff));
//                }
//            else {
//                Output.WriteByte((byte)(Code + Length64));
//                Output.WriteByte((byte)((Length >> 56) & 0xff));
//                Output.WriteByte((byte)((Length >> 48) & 0xff));
//                Output.WriteByte((byte)((Length >> 40) & 0xff));
//                Output.WriteByte((byte)((Length >> 32) & 0xff));
//                Output.WriteByte((byte)((Length >> 24) & 0xff));
//                Output.WriteByte((byte)((Length >> 16) & 0xff));
//                Output.WriteByte((byte)((Length >> 8) & 0xff));
//                Output.WriteByte((byte)(Length & 0xff));
//                }
//            }

//        /// <summary>
//        /// Write out a Tag-Length value using the shortest possible production
//        /// </summary>
//        /// <param name="Code">Base code.</param>
//        /// <param name="Length">Length of data to follow.</param>
//        public static void WriteTagReverse (this Stream Output, byte Code, long Length) {
//            if (Length < 0x100) {
//                Output.WriteByte((byte)(Length & 0xff));
//                Output.WriteByte((byte)(Code + Length8));
//                }
//            else if (Length < 0x10000) {
//                Output.WriteByte((byte)(Length & 0xff));
//                Output.WriteByte((byte)((Length >> 8) & 0xff));
//                Output.WriteByte((byte)(Code + Length16));
//                }
//            else if (Length < 0x100000000) {
//                Output.WriteByte((byte)(Length & 0xff));
//                Output.WriteByte((byte)((Length >> 8) & 0xff));
//                Output.WriteByte((byte)((Length >> 16) & 0xff));
//                Output.WriteByte((byte)((Length >> 24) & 0xff));
//                Output.WriteByte((byte)(Code + Length32));
//                }
//            else {
//                Output.WriteByte((byte)(Length & 0xff));
//                Output.WriteByte((byte)((Length >> 8) & 0xff));
//                Output.WriteByte((byte)((Length >> 16) & 0xff));
//                Output.WriteByte((byte)((Length >> 24) & 0xff));
//                Output.WriteByte((byte)((Length >> 32) & 0xff));
//                Output.WriteByte((byte)((Length >> 40) & 0xff));
//                Output.WriteByte((byte)((Length >> 48) & 0xff));
//                Output.WriteByte((byte)((Length >> 56) & 0xff));
//                Output.WriteByte((byte)(Code + Length64));
//                }
//            }


//        /// <summary>
//        /// Write a unidirectional or bidirectional frame to the current stream at the current write position. 
//        /// The code does not currently support 64 bit frames as it should.
//        /// </summary>
//        /// <param name="Output">The output stream.</param>
//        /// <param name="FrameData">The data to write.</param>
//        /// <param name="Offset">Offset within the data.</param>
//        /// <param name="Length">Number of bytes to write.</param>
//        /// <param name="Bidirectional">If true, a bidirectional frame is written.</param>
//        public static long WriteFrame (this Stream Output, byte[] FrameData,
//                long Offset = 0, long Length = -1, bool Bidirectional = false) {
//            Length = Length == -1 ? FrameData.LongLength : Length;

//            Assert.True(Length <= Int32.MaxValue, FrameTooLargeException.Throw);

//            if (Bidirectional) {
//                Output.WriteTag(BFrame, Length);
//                }
//            else {
//                Output.WriteTag(UFrame, Length);
//                }
//            Output.Write(FrameData, (int)Offset, (int)Length); // Hack: Does not yet support 64 bit lengths as it should
//            if (Bidirectional) {
//                Output.WriteTagReverse(BFrame, Length);
//                return TotalLength2(Length);
//                }
//            else {
//                return TotalLength(Length);
//                }
//            }

//        /// <summary>
//        /// Write a wrapped frame containing a header and an optional data section
//        /// to the current stream at the current write position. 
//        /// The code does not currently support 64 bit frames as it should.
//        /// </summary>
//        /// <param name="Output">The output stream.</param>
//        /// <param name="FrameData">The payload data to write.</param>
//        /// <param name="FrameHeader">The header data to write.</param>
//        public static long WriteWrappedFrame (this Stream Output, byte[] FrameHeader, byte[] FrameData = null) {

//            var FrameLength = (FrameHeader == null ? 0 : TotalLength(FrameHeader.Length)) +
//                                (FrameData == null ? 0 : TotalLength(FrameData.Length));

//            Output.WriteTag(BFrame, FrameLength);
//            if (FrameHeader != null) {
//                Output.WriteFrame(FrameHeader);
//                }
//            if (FrameData != null) {
//                Output.WriteFrame(FrameData);
//                }
//            Output.WriteTagReverse(BFrame, FrameLength);

//            return TotalLength2(FrameLength);
//            }

//        /// <summary>
//        /// Read a byte in the reverse direction, i.e. the byte immediately preceding the 
//        /// current position.
//        /// </summary>
//        /// <param name="Input">The input stream</param>
//        /// <returns>The byte read or -1.</returns>
//        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
//        public static int ReadByteReverse (this Stream Input) {
//            Assert.True(Input.Position > 0, InvalidFileFormatException.Throw);
//            Input.Seek(-1, SeekOrigin.Current);
//            var Value = Input.ReadByte();
//            Input.Seek(-1, SeekOrigin.Current);
//            return Value;
//            }

//        /// <summary>
//        /// Read a length value of known length in the forward direction.
//        /// </summary>
//        /// <param name="Input">The input stream</param>
//        /// <param name="LengthLength">The number of bytes to read.</param>
//        /// <param name="Length">The length value read.</param>
//        /// <returns>Always true. All failures trigger exceptions.</returns>
//        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
//        public static bool ReadLength (this Stream Input, int LengthLength, out long Length) {
//            Length = 0;
//            for (var i = 0; i < LengthLength; i++) {
//                var Value = Input.ReadByte();
//                Assert.False(Value < 0, InvalidFileFormatException.Throw);
//                Length = (Length << 8) + Value;
//                }
//            return true;
//            }

//        /// <summary>
//        /// Check a reversed length value of known length in the forward direction (from the start of the
//        /// file to the end).
//        /// </summary>
//        /// <param name="Input">The input stream</param>
//        /// <param name="LengthLength">The number of bytes to read.</param>
//        /// <param name="Length">The length value read.</param>
//        /// <returns>Always true. All failures trigger exceptions.</returns>
//        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
//        public static bool CheckReversedLength (this Stream Input, int LengthLength, long LengthIn) {
//            long Length = 0;
//            for (var i = 0; i < LengthLength; i++) {
//                var Value = (long)Input.ReadByte();
//                Assert.False(Value < 0, InvalidFileFormatException.Throw);
//                Length = Length + (Value >> 8 * i);
//                }
//            return Length == LengthIn;
//            }

//        /// <summary>
//        /// Read a length value of known length in the reverse direction.
//        /// </summary>
//        /// <param name="Input">The input stream</param>
//        /// <param name="LengthLength">The number of bytes to read.</param>
//        /// <param name="Length">The length value read.</param>
//        /// <returns>Always true. All failures trigger exceptions.</returns>
//        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
//        public static bool ReadLengthReverse (this Stream Input, int LengthLength, out long Length) {
//            Length = 0;

//            for (var i = 0; i < LengthLength; i++) {
//                var Value = Input.ReadByteReverse();
//                Assert.False(Value < 0, InvalidFileFormatException.Throw);
//                Length = (Length << 8) + Value;
//                }
//            return true;
//            }

//        /// <summary>
//        /// Read a forward length tag in the forward direction
//        /// </summary>
//        /// <param name="Input">The input stream</param>
//        /// <param name="Code">The tag code that was read</param>
//        /// <param name="Length">The length that was read</param>
//        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
//        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
//        public static bool ReadTag (this Stream Input, out int Code, out long Length) {
//            Code = Input.ReadByte();

//            if (Code < 0) {
//                Length = 0;
//                return false;
//                }

//            var LengthCode = Code & LengthMask;

//            switch (LengthCode) {
//                case Length8: {
//                    return ReadLength(Input, 1, out Length);
//                    }
//                case Length16: {
//                    return ReadLength(Input, 2, out Length);
//                    }
//                case Length32: {
//                    return ReadLength(Input, 4, out Length);
//                    }
//                default: {
//                    return ReadLength(Input, 8, out Length);
//                    }
//                }

//            }


//        /// <summary>
//        /// Read a forward length tag in the Reverse direction
//        /// </summary>
//        /// <param name="Input">The input stream</param>
//        /// <param name="Code">The tag code that was read</param>
//        /// <param name="Length">The length that was read</param>
//        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
//        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
//        public static bool ReadTagReverse (this Stream Input, out int Code, out long Length) {
//            Code = Input.ReadByteReverse();

//            if (Code < 0) {
//                Length = 0;
//                return false;
//                }

//            var LengthCode = Code & LengthMask;

//            switch (LengthCode) {
//                case Length8: {
//                    return ReadLengthReverse(Input, 1, out Length);
//                    }
//                case Length16: {
//                    return ReadLengthReverse(Input, 2, out Length);
//                    }
//                case Length32: {
//                    return ReadLengthReverse(Input, 4, out Length);
//                    }
//                default: {
//                    return ReadLengthReverse(Input, 8, out Length);
//                    }
//                }

//            }

//        /// <summary>
//        ///  Read a frame in the forward direction.
//        /// </summary>
//        /// <param name="Input">The input stream</param>
//        /// <param name="MaxLength">The maximum length of data to read including the tags</param>
//        /// <param name="Data">The data that was read.</param>
//        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
//        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
//        public static bool ReadFrame (this Stream Input, ref long MaxLength, out byte[] Data) {
//            Data = null;
//            var Read = Input.ReadTag(out var Code, out var Length);
//            if (!Read) {
//                return false;
//                }

//            MaxLength = MaxLength - CodeSpace(Code);
//            Assert.True(Length <= MaxLength, InvalidFileFormatException.Throw);
//            if (Length > 0) {
//                Data = new byte[Length];
//                var Bytes = Input.Read(Data, 0, (int)Length);
//                Assert.True(Bytes == Length, InvalidFileFormatException.Throw);
//                MaxLength -= Length;
//                }


//            if ((Code & TypeMask) == BFrame) {
//                Input.CheckReversedLength(TagLength(Code), Length);
//                var CheckCode = Input.ReadByte();
//                Assert.True(Code == CheckCode, InvalidFileFormatException.Throw);
//                }


//            return true;
//            }

//        /// <summary>
//        /// Read a pair of wrapped frames in the forward direction.
//        /// </summary>
//        /// <param name="Input">The input stream</param>
//        /// <param name="FrameData">The payload data that was read.</param>
//        /// <param name="FrameHeader">The header data that was read.</param>
//        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
//        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
//        public static bool ReadWrappedFrame (this Stream Input, out byte[] FrameHeader, out byte[] FrameData) {
//            FrameHeader = null;
//            FrameData = null;

//            var Read = Input.ReadTag(out var Code, out var Length);
//            if (!Read) {
//                return false;
//                }
//            if (Length > 0) {
//                Input.ReadFrame(ref Length, out FrameHeader);
//                Length = Length - FrameHeader.LongLength;
//                }
//            if (Length > 0) {
//                Input.ReadFrame(ref Length, out FrameData);
//                Length = Length - FrameData.LongLength;
//                }
//            if ((Code & TypeMask) == BFrame) {
//                Input.CheckReversedLength(TagLength(Code), Length);
//                }

//            return true;
//            }


//        /// <summary>
//        /// Read a pair of wrapped frames in the reverse direction. This is typically done to read the last
//        /// record in a file to see how the file should be extended.
//        /// </summary>
//        /// <param name="Input">The input stream</param>
//        /// <param name="FrameData">The payload data that was read.</param>
//        /// <param name="FrameHeader">The header data that was read.</param>
//        /// <returns>True if a tag was read or false if EOF was encountered.</returns>
//        /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
//        public static bool ReadWrappedFrameReverse (this Stream Input, out byte[] FrameHeader, out byte[] FrameData) {
//            var Read = Input.ReadTagReverse(out var Code, out var Length);
//            if (!Read) {
//                FrameHeader = null;
//                FrameData = null;
//                return false;
//                }
 
//            // Sanity check
//            var Position = Input.Position;
//            Assert.True(Position >= Length, InvalidFileFormatException.Throw);

//            // Make sure we return to the same position.
//            long Start = Input.Position - Length;
           
//            Input.Seek(Start, SeekOrigin.Begin);
//            Input.ReadWrappedFrame(out FrameHeader, out FrameData);
//            Input.Seek(Start, SeekOrigin.Begin);

//            return true;
//            }

//        }

//    }
