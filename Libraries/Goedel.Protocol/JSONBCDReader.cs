using Goedel.Utilities;

using System;
using System.IO;

namespace Goedel.Protocol {

    /// <summary>
    /// JSON reader supporting JSON-B, JSON-C and JSON-D extended encodings.
    /// </summary>
    public class JsonBcdReader : JSONReader {

        /// <summary>
        /// Returns a factory delegate that returns a reader of this type.
        /// </summary>
        public static new JSONReaderFactoryDelegate JSONReaderFactory => ReaderFactoryMethod;
        static JSONReader ReaderFactoryMethod(byte[] Data) => new JsonBcdReader(Data);




        IBinaryStream ByteInput => CharacterInput as IBinaryStream;

        /// <summary>
        /// Construct a JSONReader from a byte Stream.
        /// </summary>
        /// <param name="Input">The stream to be read.</param>
        public JsonBcdReader(Stream Input) : base(Input) { }

        /// <summary>
        /// Construct a JSONReader from a byte array.
        /// </summary>
        /// <param name="Input">The data to be read.</param>
        public JsonBcdReader(byte[] Input) : base(Input) { }




        int ModifierToLength(int c) {
            var Code = c & 0x03;
            return Code switch
                {
                    0 => 1,
                    1 => 2,
                    2 => 4,
                    3 => 8,
                    _ => throw new NYI(),
                    };
            }



        bool IsWhitespace(byte c) =>
            (c == ' ') | (c == '\t') | (c == '\r') | (c == '\n') | (c == '\f') | (c == '\b');

        /// <summary>Get the next lexical token.</summary>
        protected override Token Lexer() {

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

                    default:
                        break;
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

                    default:
                        break;
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

                    default:
                        break;
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

                    default:
                        break;
                    }
                } while (Dictionary);
            throw new UnknownTag();
            }

        ulong GetInteger(int Code) {
            ulong Result = 0;

            var Count = ModifierToLength(Code);
            for (var i = 0; i < Count; i++) {
                var c = ByteInput.ReadByte();
                Result = (Result << 8) | c;
                }
            return Result;
            }

        Token LexerInteger(int Code, bool Positive) {
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

        Token LexerString(int Code, bool Terminal) {
            var Length = (int)GetInteger(Code);
            var Buffer = ByteInput.ReadBinary(Length);
            ResultString = Buffer.ToUTF8();
            this.Terminal = Terminal;
            return Token.String;
            }

        int lengthRemainingRead = -1;
        int binaryBuffer = -1;

        Token LexerBinary(int Code, bool Terminal) {
            lengthRemainingRead = (int)GetInteger(Code);
            this.Terminal = Terminal;
            return Token.Binary;
            }

        /// <summary>
        /// Read binary data in monolithic mode, i.e. return the entire chunk.
        /// </summary>
        /// <returns>The binary data.</returns>
        public override byte[] ReadBinaryData() {
            ResultBinary = ByteInput.ReadBinary(lengthRemainingRead);
            lengthRemainingRead = -1;
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
                    binaryBuffer = 0;
                    return true;
                    }
                case Token.Binary: {
                    binaryBuffer = -1;
                    return Terminal;
                    }

                case Token.Invalid:
                    break;
                case Token.StartObject:
                    break;
                case Token.EndObject:
                    break;
                case Token.StartArray:
                    break;
                case Token.EndArray:
                    break;
                case Token.Colon:
                    break;
                case Token.Comma:
                    break;
                case Token.Tag:
                    break;
                case Token.Number:
                    break;
                case Token.Integer:
                    break;
                case Token.Real32:
                    break;
                case Token.Real64:
                    break;
                case Token.Litteral:
                    break;
                case Token.True:
                    break;
                case Token.False:
                    break;
                case Token.Null:
                    break;
                case Token.EndRecord:
                    break;
                case Token.JSONBCD:
                    break;
                case Token.Empty:
                    break;
                default:
                    break;
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

            if (binaryBuffer >= 0) {
                Length = Math.Min(Count, ResultBinary.Length - binaryBuffer);

                Buffer.BlockCopy(ResultBinary, binaryBuffer, Data, Offset, Length);
                binaryBuffer += Length;

                return Length;
                }


            if (lengthRemainingRead < 0) {
                return 0; // Have completed reading the data.
                }

            if (lengthRemainingRead == 0) {
                if (Terminal) {
                    return 0;
                    }
                ReadBinaryToken();
                }

            // reduce the read count to the smaller of count and the remaining data.
            Length = Math.Min(Count, lengthRemainingRead);

            lengthRemainingRead -= Length;
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

                case Token.Invalid:
                    break;
                case Token.StartObject:
                    break;
                case Token.StartArray:
                    break;
                case Token.EndArray:
                    break;
                case Token.Colon:
                    break;
                case Token.String:
                    break;
                case Token.Tag:
                    break;
                case Token.Number:
                    break;
                case Token.Integer:
                    break;
                case Token.Real32:
                    break;
                case Token.Real64:
                    break;
                case Token.Litteral:
                    break;
                case Token.True:
                    break;
                case Token.False:
                    break;
                case Token.Null:
                    break;
                case Token.EndRecord:
                    break;
                case Token.Binary:
                    break;
                case Token.JSONBCD:
                    break;
                case Token.Empty:
                    break;
                default:
                    break;
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

                case Token.Invalid:
                    break;
                case Token.StartObject:
                    break;
                case Token.EndObject:
                    break;
                case Token.StartArray:
                    break;
                case Token.Colon:
                    break;
                case Token.String:
                    break;
                case Token.Tag:
                    break;
                case Token.Number:
                    break;
                case Token.Integer:
                    break;
                case Token.Real32:
                    break;
                case Token.Real64:
                    break;
                case Token.Litteral:
                    break;
                case Token.True:
                    break;
                case Token.False:
                    break;
                case Token.Null:
                    break;
                case Token.EndRecord:
                    break;
                case Token.Binary:
                    break;
                case Token.JSONBCD:
                    break;
                case Token.Empty:
                    break;
                default:
                    break;
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
