using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Goedel.Utilities;

namespace Goedel.Protocol {

    /// <summary>
    /// JSON reader supporting JSON-B, JSON-C and JSON-D extended encodings.
    /// </summary>
    public class JSONBCDReader : JSONReader {

        /// <summary>
        /// Returns a factory delegate that returns a reader of this type.
        /// </summary>
        public static new JSONReaderFactoryDelegate JSONReaderFactory => ReaderFactoryMethod;
        static JSONReader ReaderFactoryMethod(byte[] Data) => new JSONBCDReader(Data);




        IBinaryStream ByteInput => CharacterInput as IBinaryStream;

        /// <summary>
        /// Construct a JSONReader from a byte Stream.
        /// </summary>
        /// <param name="Input">The stream to be read.</param>
        public JSONBCDReader(Stream Input) : base(Input) {}

        /// <summary>
        /// Construct a JSONReader from a byte array.
        /// </summary>
        /// <param name="Input">The data to be read.</param>
        public JSONBCDReader(byte[] Input) : base(Input) { }




        int ModifierToLength (int c) {
            var Code = c & 0x03;
            switch (Code) {
                case 0: return 1;
                case 1: return 2;
                case 2: return 4;
                case 3: return 8;
                }
            throw new NYI();
            }



        bool IsWhitespace(byte c) =>
            (c == ' ') | (c == '\t') | (c == '\r') | (c == '\n') | (c == '\f') | (c == '\b');

        /// <summary>Get the next lexical token.</summary>
        protected override Token Lexer () {

            var b = ByteInput.PeekByte();
            while (IsWhitespace(b) & (!ByteInput.EOF)) {
                ByteInput.ReadByte();
                b = ByteInput.PeekByte();
                }

            if (b < 0x80) {
                return base.Lexer();
                }

            var Dictionary = false;

            do {
                b = ByteInput.ReadByte();

                if (b < 0x80) {
                    return base.Lexer();
                    }
                switch (b & 0xFC) {
                    case JSONBCD.PositiveInteger: {
                            return LexerInteger(b, true);
                            }
                    case JSONBCD.NegativeInteger: {
                            return LexerInteger(b, false);
                            }
                    case JSONBCD.TagString: {
                        return LexerTag(b, true);
                        }
                    case JSONBCD.StringTerm: {
                            return LexerString(b, true);
                            }
                    case JSONBCD.StringChunk: {
                            return LexerString(b, false);
                            }
                    case JSONBCD.DataTerm: {
                            return LexerBinary(b, true);
                            }
                    case JSONBCD.DataChunk: {
                            return LexerBinary(b, false);
                            }

                    }

                switch (b) {

                    case JSONBCD.True: {
                            return Token.True;
                            }
                    case JSONBCD.False: {
                            return Token.False;
                            }
                    case JSONBCD.Null: {
                            return Token.Null;
                            }
                    case JSONBCD.PositiveBigInteger: {
                            return LexerBigInteger(true);
                            }
                    case JSONBCD.NegativeBigInteger: {
                            return LexerBigInteger(false);
                            }
                    }


                switch (b & 0xF4) {
                    case JSONBCD.TagCode: {
                            return LexerTagCode(b);
                            }
                    case JSONBCD.TagDefinition: {
                            Dictionary = true;
                            LexerTagDefinition(b);
                            break;
                            }
                    case JSONBCD.TagCodeDefinition: {
                            return LexerTagCodeDefinition(b);
                            }
                    case JSONBCD.TagDictionaryDefinition: {
                            Dictionary = true;
                            LexerDictionaryDefinition(b);
                            break;
                            }
                    case JSONBCD.DictionaryHash: {
                            ReadDictionary();
                            Dictionary = true;
                            break;
                            }

                    }


                switch (b) {
                    case JSONBCD.BinaryFloat16: {
                            return LexerRealOther(2);
                            }
                    case JSONBCD.BinaryFloat32: {
                            return LexerReal32();
                            }
                    case JSONBCD.BinaryFloat64: {
                            return LexerReal64();
                            }
                    case JSONBCD.BinaryFloat128: {
                            return LexerRealOther(16);
                            }
                    case JSONBCD.Intel80: {
                            return LexerRealOther(10);
                            }
                    case JSONBCD.DecimalFloat32: {
                            return LexerRealOther(4);
                            }
                    case JSONBCD.DecimalFloat64: {
                            return LexerRealOther(8);
                            }
                    case JSONBCD.DecimalFloat128: {
                            return LexerRealOther(16);
                            }
                    }
                } while (Dictionary);
            throw new UnknownTag();
            }

        byte[] DataBuffer = new byte[16];
        ulong GetInteger (int Code) {
            ulong Result=0;

            var Count = ModifierToLength(Code);
            for (var i = 0; i < Count; i++) {
                var c = ByteInput.ReadByte();
                Result = (Result << 8) | c;
                }
            return Result;
            }

        Token LexerInteger (int Code, bool Positive) {
            ResultInt64 = Positive ? (long)GetInteger(Code) : -(long)GetInteger(Code);
            return Token.Integer;
            }


        Token LexerTag(int Code, bool Terminal) {
            var Length = (int)GetInteger(Code);
            var Buffer = ByteInput.ReadBinary(Length);
            ResultString = Buffer.ToUTF8();
            this.Terminal = Terminal;
            return Token.Tag;
            }

        Token LexerString (int Code, bool Terminal) {
            var Length = (int) GetInteger(Code);
            var Buffer = ByteInput.ReadBinary(Length);
            ResultString = Buffer.ToUTF8();
            this.Terminal = Terminal;
            return Token.String;
            }

        int LengthRemainingRead=-1;
        int BinaryBuffer = -1;

        Token LexerBinary (int Code, bool Terminal) {
            LengthRemainingRead = (int)GetInteger(Code);
            this.Terminal = Terminal;
            return Token.Binary;
            }

        /// <summary>
        /// Read binary data in monolithic mode, i.e. return the entire chunk.
        /// </summary>
        /// <returns>The binary data.</returns>
        public override byte[] ReadBinaryData() {
            ResultBinary = ByteInput.ReadBinary(LengthRemainingRead);
            LengthRemainingRead = -1;
            return ResultBinary;
            }

        /// <summary>
        /// Begin reading data chunk in incremental mode.
        /// </summary>
        /// <returns>If true, this is a terminal chunk and there is no more data to be read.</returns>
        public virtual bool ReadBinaryToken() {
            GetToken(true);

            switch (TokenType) {
                case Token.String: {
                    BinaryBuffer = 0;
                    return true;
                    }
                case Token.Binary: {
                    BinaryBuffer = -1;
                    return Terminal;
                    }
                }

            return Terminal;
            }


        /// <summary>
        /// Read a partial binary value.
        /// </summary>
        /// <param name="Data">Buffer to write the data read to.</param>
        /// <param name="Offset">Byte offset from start of <paramref name="Data"/></param>
        /// <param name="Count">Number of bytes to be read.</param>
        /// <returns>Number of bytes read or 0 if the end of the stream is reached.</returns>

        public virtual int ReadBinaryData(
            byte[] Data, int Offset, int Count) {
            int Length;

            if (BinaryBuffer >= 0) {
                Length = Math.Min(Count, ResultBinary.Length - BinaryBuffer);

                Buffer.BlockCopy(ResultBinary, BinaryBuffer, Data, Offset, Length);
                BinaryBuffer += Length;

                return Length;
                }


            if (LengthRemainingRead < 0) {
                return 0; // Have completed reading the data.
                }

            if (LengthRemainingRead == 0) {
                if (Terminal) {
                    return 0;
                    }
                ReadBinaryToken();
                }

            // reduce the read count to the smaller of count and the remaining data.
            Length = Math.Min(Count, LengthRemainingRead);

            LengthRemainingRead -= Length;
            var Read = ByteInput.ReadBinary(Data, Offset, Length);

            //Console.WriteLine("Read ${Read} bytes");

            return Read;
            }


        // JSON-B (currently unused)
        Token LexerReal32() => throw new NYI();

        Token LexerReal64() => throw new NYI();

        Token LexerBigInteger(bool Positive) => throw new NYI();

        // JSON-C (currently unused)
        Token LexerTagCode(int Code) => throw new NYI();

        void LexerTagDefinition(int Code) => throw new NYI();

        Token LexerTagCodeDefinition(int Code) => throw new NYI();

        void LexerDictionaryDefinition(int Code) => throw new NYI();

        void ReadDictionary() { }

        // JSON-D (currently unused)
        Token LexerRealOther(int length) => throw new NYI();

        // Reader methods
        /// <summary>
        /// Attempt to read an object from input.
        /// </summary>
        /// <returns>True if there is a next object.</returns>
        public override bool NextObject() {
            PeekToken();
            switch (TokenType) {
                case Token.Comma: {
                    GetToken();
                    return true; // another tag to come
                    }
                case Token.EndObject: {
                    GetToken();
                    return false; // end of object reached
                    }
                }
            return true;
            }

        /// <summary>
        /// Return true if there is a following array item.
        /// </summary>
        /// <returns>True if there is a following array item, otherwise 
        /// false</returns>
        public override bool NextArray() {
            PeekToken();
            switch (TokenType) {
                case Token.Comma: {
                    GetToken();
                    return true; // another tag to come
                    }
                case Token.EndArray: {
                    GetToken();
                    return false; // end of object reached
                    }
                }
            return true;
            }

        /// <summary>
        /// Attempt to read a binary object in incremental mode.
        /// </summary>
        /// <param name="Chunk">The data read.</param>
        /// <returns>True if there is more data to be read</returns>
        public override bool ReadBinaryIncremental(out byte[] Chunk) {
            Chunk = ReadBinary();
            return !Terminal;
            }


        /// <summary>
        /// Attempt to read binary data from input.
        /// </summary>
        /// <returns>The data read</returns>
        public override byte[] ReadBinary() => base.ReadBinary();

        /// <summary>
        /// Attempt to read string from input.
        /// </summary>
        /// <returns>The data read</returns>
        public override string ReadString() => base.ReadString();


        }

    }
