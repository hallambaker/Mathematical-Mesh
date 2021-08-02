using System;
using System.IO;
using System.Text;

using Goedel.Utilities;

namespace Goedel.Protocol {

    /// <summary>
    /// A character stream reader that takes a TextReader as the input source.
    /// The input stream is only read in the forward direction.
    /// </summary>
    public class CharacterStreamTextReader : ICharacterStream {

        #region // Properties
        /// <summary>If true, end of file has been reached. </summary>
        public bool EOF { get; private set; } = false;
        #endregion

        TextReader Input;

        /// <summary>
        /// Creatre an instance from the specified TextReader.
        /// </summary>
        /// <param name="Input">The input stream.</param>
        public CharacterStreamTextReader(TextReader Input) => this.Input = Input;

        #region // methods

        /// <summary>Return the next character in the stream without advancing the stream</summary>
        /// <returns>The next character in the stream</returns>
        public char PeekChar() {
            var Next = Input.Peek();
            if (Next < 0) {
                EOF = true;
                }
            return (char)Next;
            }

        /// <summary>Return the next character in the stream and advance the stream.</summary>
        /// <returns>The next character in the stream</returns>
        public char ReadChar() {
            var Next = Input.Read();
            if (Next < 0) {
                EOF = true;
                }
            return (char)Next;
            }

        /// <summary>
        /// Get the next byte in the stream without advancing the reader position.
        /// </summary>
        /// <returns>The next byte.</returns>
        public byte PeekByte() => (byte)PeekChar();

        /// <summary>
        /// Get the next byte in the stream and advance the reader position.
        /// </summary>
        /// <returns>The next byte.</returns>
        public byte ReadByte() => (byte)ReadChar();


        /// <summary>
        /// Read the stream from the current position as a JSON string completion containing
        /// base64 encoded binary data and return the number of bytes necessary to store the
        /// result. The initial open quote is assumed.
        /// </summary>
        /// <returns>The decoded data</returns>
        public byte[] GetBinaryBase64() => CharacterStreamRead.GetBinaryBase64(this);

        /// <summary>
        /// Read the stream from the current position as a JSON string completion and return the 
        /// resulting string. The initial open quote is assumed.
        /// </summary>
        /// <returns>The decoded string</returns>
        public string GetStringJSON() => CharacterStreamRead.GetStringJSON(this);

        #endregion
        }

    /// <summary>
    /// A character stream reader that takes a string as the input source.
    /// </summary>
    public class CharacterStreamStringReader : ICharacterBufferedStream {

        #region // Properties
        /// <summary>If true, end of file has been reached. </summary>
        public bool EOF { get; private set; } = false;
        #endregion

        string Input;
        int Position = 0;

        /// <summary>
        /// Create a CharacterStreamStringReader from the specified string.
        /// </summary>
        /// <param name="Input">The string to be read.</param>
        public CharacterStreamStringReader(string Input) => this.Input = Input;

        #region // methods
        /// <summary>Return the next character in the stream without advancing the stream</summary>
        /// <returns>The next character in the stream</returns>
        public char PeekChar() {
            if (Position >= Input.Length) {
                EOF = true;
                return (char)0;
                }
            return Input[Position];
            }

        /// <summary>Return the next character in the stream and advance the stream.</summary>
        /// <returns>The next character in the stream</returns>
        public char ReadChar() {
            if (Position >= Input.Length) {
                EOF = true;
                return (char)0;
                }
            return Input[Position++];
            }

        /// <summary>
        /// Get the next byte in the stream without advancing the reader position.
        /// </summary>
        /// <returns>The next byte.</returns>
        public byte PeekByte() => (byte)PeekChar();

        /// <summary>
        /// Get the next byte in the stream and advance the reader position.
        /// </summary>
        /// <returns>The next byte.</returns>
        public byte ReadByte() => (byte)ReadChar();

        int MarkedPosition = -1;

        /// <summary>Create a restore point in the stream.</summary>
        public void Mark() {
            Assert.AssertTrue(MarkedPosition < 0, StreamMarkerError.Throw);
            MarkedPosition = Position;
            }

        /// <summary>Return the stream to the position that the reader was at the last time
        /// Mark() was called.</summary>
        public void Restore() {
            Assert.AssertTrue(MarkedPosition >= 0, StreamMarkerError.Throw);
            Position = MarkedPosition;
            EOF = false;
            MarkedPosition = -1;
            }

        /// <summary>
        /// Read the stream from the current position as a JSON string completion containing
        /// base64 encoded binary data and return the number of bytes necessary to store the
        /// result. The initial open quote is assumed.
        /// </summary>
        /// <returns>The decoded data</returns>
        public byte[] GetBinaryBase64() => CharacterStreamRead.GetBase64StringBuffered(this);

        /// <summary>
        /// Read the stream from the current position as a JSON string completion and return the 
        /// resulting string. The initial open quote is assumed.
        /// </summary>
        /// <returns>The decoded string</returns>
        public string GetStringJSON() => CharacterStreamRead.GetJSONStringBuffered(this);

        #endregion
        }

    /// <summary>
    /// A binary and character stream reader that takes a binary stream as the input
    /// source. The stream is only read in the forward direction.
    /// </summary>
    public abstract class BinaryStreamReader : IBinaryStream {
        #region // Properties
        /// <summary>
        /// If positive, contains the second character in a two character UTF16 character 
        /// sequence.
        /// </summary>
        public int UTF16Shift { get; set; }

        /// <summary>If true, end of file has been reached. </summary>
        public bool EOF { get; protected set; } = false;

        /// <summary>
        /// Read a complete binary value.
        /// </summary>
        /// <param name="Length">The number of bytes to read.</param>
        /// <returns>The binary data that was read.</returns>
        public abstract byte[] ReadBinary(int Length);


        /// <summary>
        /// Read a partial binary value.
        /// </summary>
        /// <param name="Buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public abstract int ReadBinary(byte[] Buffer, int offset, int count);

        /// <summary>
        /// Get the next byte in the stream and advance the stream.
        /// </summary>
        /// <returns>The next byte.</returns>
        public abstract byte ReadByte();

        /// <summary>
        /// Get the next byte in the stream without advancing the stream.
        /// </summary>
        /// <returns>The next byte.</returns>
        public abstract byte PeekByte();


        #endregion

        #region // methods
        int Buffered = -1;

        /// <summary>Return the next character in the stream without advancing the stream</summary>
        /// <returns>The next character in the stream</returns>
        public virtual char PeekChar() {
            if (Buffered < 0) {
                Buffered = this.Read();
                }
            return Buffered < 0 ? (char)0 : (char)Buffered;
            }

        /// <summary>Return the next character in the stream and advance the stream.</summary>
        /// <returns>The next character in the stream</returns>
        public virtual char ReadChar() {
            int Next = Buffered < 0 ? this.Read() : Buffered;
            Buffered = -1;
            return Next < 0 ? (char)0 : (char)Next;
            }

        /// <summary>
        /// Read a complete string value.
        /// </summary>
        /// <param name="Length">The number of bytes to read.</param>
        /// <returns>The string that was read.</returns>
        public virtual string ReadStringUTF8(int Length) {
            var Builder = new StringBuilder();

            for (var i = 0; i < Length; i++) {
                Builder.Append(ReadChar());
                }

            return Builder.ToString();
            }


        /// <summary>
        /// Read the stream from the current position as a JSON string completion and return the 
        /// resulting string. The initial open quote is assumed.
        /// </summary>
        /// <returns>The decoded string</returns>
        public virtual string GetStringJSON() => CharacterStreamRead.GetStringJSON(this);

        /// <summary>
        /// Read the stream from the current position as a JSON string completion containing
        /// base64 encoded binary data and return the resulting string. The initial open quote is assumed.
        /// </summary>
        /// <returns>The decoded data</returns>
        public virtual byte[] GetBinaryBase64() => CharacterStreamRead.GetBinaryBase64(this);
        #endregion
        }

    /// <summary>
    /// A binary and character stream reader that takes a binary stream as the input
    /// source. The stream is only read in the forward direction.
    /// </summary>
    public class CharacterStreamReader : BinaryStreamReader {


        /// <summary>
        /// The underlying input stream.
        /// </summary>
        protected Stream Input;

        /// <summary>
        /// Return a CharacterStreamReader for the specified input source which may be
        /// any stream source that supports read operations.
        /// </summary>
        /// <param name="Input">The stream to be read</param>
        public CharacterStreamReader(Stream Input) => this.Input = Input;

        #region // methods

        int Lookahead = -1;

        /// <summary>
        /// Get the next byte in the stream and advance the reader position.
        /// </summary>
        /// <returns>The next byte.</returns>
        public override byte ReadByte() {
            if (Lookahead >= 0) {
                var Result = (byte)Lookahead;
                Lookahead = -1;
                return Result;
                }

            var Byte = Input.ReadByte();

            if (Byte < 0) {
                EOF = true;
                return 0;
                }

            return (byte)Byte;
            }

        /// <summary>
        /// Get the next byte in the stream without advancing the reader position.
        /// </summary>
        /// <returns>The next byte.</returns>
        public override byte PeekByte() {



            if (Lookahead < 0) {
                Lookahead = Input.ReadByte();
                }
            if (Lookahead < 0) {
                EOF = true;
                return 0;
                }
            return (byte)Lookahead;
            }



        /// <summary>
        /// Read a complete binary value, buffering partial chunk values if necessary.
        /// </summary>
        /// <param name="Length">The number of bytes to read.</param>
        /// <returns>The binary data that was read.</returns>
        public override byte[] ReadBinary(int Length) {
            var Result = new byte[Length];
            Input.Read(Result, 0, Length);
            return Result;
            }

        /// <summary>
        /// Read a partial binary value.
        /// </summary>
        /// <param name="Buffer">Buffer to write the data read to.</param>
        /// <param name="offset">Byte offset from start of <paramref name="Buffer"/></param>
        /// <param name="count">Number of bytes to be read.</param>
        /// <returns>Number of bytes read or 0 if the end of the stream is reached.</returns>
        public override int ReadBinary(byte[] Buffer, int offset, int count) => Input.Read(Buffer, offset, count);






        #endregion
        }

    /// <summary>
    /// A binary and character stream reader that takes a binary stream as the input
    /// source. The stream MUST support the seek operation.
    /// </summary>
    public class CharacterStreamSeekReader : CharacterStreamReader, IBufferedStream {
        #region // Properties
        #endregion

        /// <summary>
        /// Return a CharacterStreamReader for the specified input source which must
        /// be a stream source that supports seek operations.
        /// </summary>
        /// <param name="Input">The stream to be read</param>
        public CharacterStreamSeekReader(Stream Input) : base(Input) {
            }

        long MarkedPosition = -1;

        /// <summary>Create a restore point in the stream.</summary>
        public virtual void Mark() {
            Assert.AssertTrue(MarkedPosition < 0, StreamMarkerError.Throw);
            MarkedPosition = Input.Position;
            }

        /// <summary>Return the stream to the position that the reader was at the last time
        /// Mark() was called.</summary>
        public virtual void Restore() {
            Assert.AssertTrue(MarkedPosition >= 0, StreamMarkerError.Throw);
            Input.Position = MarkedPosition;
            EOF = false;
            MarkedPosition = -1;
            }

        #region // methods


        #endregion
        }



    /// <summary>
    /// An IBinaryStream that reads from a byte array.
    /// </summary>
    public class CharacterStreamDataReader : BinaryStreamReader {

        byte[] Input;
        int Position;
        int Last;

        /// <summary>
        /// Return a CharacterStreamDataReader for the specified byte array.
        /// </summary>
        /// <param name="Input">The input data to be read.</param>
        /// <param name="Start">The first byte to be read.</param>
        /// <param name="Length">The maximum number of bytes to read.</param>
        public CharacterStreamDataReader(byte[] Input, int Start = 0, int Length = -1) {
            this.Input = Input;
            Position = Start;
            Last = Input.GetLast(Start, Length);
            }

        #region // methods

        int MarkedPosition = -1;
        /// <summary>Create a restore point in the stream.</summary>
        public virtual void Mark() {
            Assert.AssertTrue(MarkedPosition < 0, StreamMarkerError.Throw);
            MarkedPosition = Position;
            }

        /// <summary>Return the stream to the position that the reader was at the last time
        /// Mark() was called.</summary>
        public virtual void Restore() {
            Assert.AssertTrue(MarkedPosition >= 0, StreamMarkerError.Throw);
            Position = MarkedPosition;
            MarkedPosition = -1;
            EOF = false;
            }

        /// <summary>
        /// Get the next byte in the stream and advance the stream.
        /// </summary>
        /// <returns>The next byte.</returns>
        public override byte ReadByte() {
            if (Position >= Last) {
                EOF = true;
                return 0;
                }
            return Input[Position++];
            }

        /// <summary>
        /// Get the next byte in the stream and advance the stream.
        /// </summary>
        /// <returns>The next byte.</returns>
        public override byte PeekByte() {
            if (Position >= Last) {
                EOF = true;
                return 0;
                }
            return Input[Position];
            }


        /// <summary>
        /// Read a complete binary value, buffering partial chunk values if necessary.
        /// </summary>
        /// <param name="Length">The number of bytes to read.</param>
        /// <returns>The binary data that was read.</returns>
        public override byte[] ReadBinary(int Length) {

            Length = Math.Min(Length, Input.Length - Position);
            var Result = new byte[Length];
            Buffer.BlockCopy(Input, Position, Result, 0, Length);
            Position += Length;

            return Result;
            }

        /// <summary>
        /// Read a partial binary value.
        /// </summary>
        /// <param name="Data">Buffer to write the data read to.</param>
        /// <param name="offset">Byte offset from start of <paramref name="Data"/></param>
        /// <param name="Length">Number of bytes to be read.</param>
        /// <returns>Number of bytes read or 0 if the end of the stream is reached.</returns>
        public override int ReadBinary(byte[] Data, int offset, int Length) {
            Length = Math.Min(Length, Input.Length - Position);

            Buffer.BlockCopy(Input, Position, Data, offset, Length);
            Position += Length;
            return Length;
            }


        #endregion
        }

    }
