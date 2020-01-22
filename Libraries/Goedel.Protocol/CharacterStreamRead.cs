using Goedel.Utilities;

using System.IO;
using System.Text;

namespace Goedel.Protocol {

    /// <summary>
    /// Static methods for reading characters and strings from streams.
    /// </summary>
    public static class CharacterStreamRead {

        /// <summary>
        /// Read a character from a binary stream. This enables a binary stream to 
        /// expose a TextReader interface.
        /// </summary>
        /// <param name="Stream"></param>
        /// <returns></returns>
        public static int Read(this IBinaryStream Stream) {

            // Check to see if there is a previous buffered value.
            if (Stream.UTF16Shift > 0) {
                var Result = Stream.UTF16Shift;
                Stream.UTF16Shift = -1;
                return Result;
                }

            // The first byte in the stream specifies the length
            var Byte1 = Stream.ReadByte();
            if (Stream.EOF) {
                return -1;
                }

            int Buffer; // Allow for up to 31 bits;
            if (Byte1 >= 0xf0) {                // 4 byte sequence
                var Byte2 = Stream.ReadByte();
                var Byte3 = Stream.ReadByte();
                var Byte4 = Stream.ReadByte();
                Buffer = ((Byte1 & 0x1f) << 15) | ((Byte2 & 0x3f) << 12) |
                    ((Byte3 & 0x1f) << 6) | (Byte4 & 0x3f);
                }
            else if (Byte1 >= 0xe0) {           // 3 byte sequence
                var Byte2 = Stream.ReadByte();
                var Byte3 = Stream.ReadByte();
                Buffer = ((Byte1 & 0x1f) << 12) | ((Byte2 & 0x3f) << 6) |
                    (Byte3 & 0x1f);
                }
            else if (Byte1 >= 0xc0) {           // 2 byte sequence
                var Byte2 = Stream.ReadByte();
                Buffer = ((Byte1 & 0x1f) << 6) | (Byte2 & 0x3f);
                }
            else {                              // 1 byte sequence, can return immediately
                return Byte1;
                }

            if (Stream.EOF) {               // Could not complete the read operation as EOF encountered
                return -1;
                }

            if (Buffer < 0xD7ff) {              // Basic Multilingual Plane character, single char
                return Buffer;
                }
            else if (Buffer < 0xE000) {         // invalid character, indicates synchronization error
                return -1;
                }
            else if (Buffer < 0x10ffff) {       // Code is on the suplementary plane
                Buffer -= 0x10000;
                Stream.UTF16Shift = 0xDC00 + (Buffer & 0x3fff);
                return 0xD800 + (Buffer >> 10);

                }
            else if (Buffer < 0xffff) {         // Basic Multilingual Plane character, single char
                return Buffer;
                }
            else {                              // characters are not expressible in UTF16
                return -1;
                }

            }

        /// <summary>Convert hex character to hex value</summary>
        /// <param name="c">The hex character</param>
        /// <returns>Integer value.</returns>
        public static int HexCharToInt(this char c) {
            if ((c >= '0') & (c <= '9')) {
                return (c - '0');
                }
            if ((c >= 'a') & (c <= 'f')) {
                return (10 + c - 'a');
                }
            if ((c >= 'A') & (c <= 'F')) {
                return (10 + c - 'A');
                }
            return -1;
            }

        /// <summary>
        /// Read the next 4 characters from the stream and interpret them as hexadecimal
        /// characters.
        /// </summary>
        /// <param name="Stream">The stream to read from</param>
        /// <returns>The character corresponding to the hex value</returns>
        public static char NextHex(ICharacterStream Stream) {
            var H1 = Stream.ReadChar().HexCharToInt();
            var H2 = Stream.ReadChar().HexCharToInt();
            var H3 = Stream.ReadChar().HexCharToInt();
            var H4 = Stream.ReadChar().HexCharToInt();

            return (char)((H1 << 24) | (H2 << 24) | (H3 << 24) | H4);
            }

        /// <summary>
        /// Read characters from the stream as completion of a JSON escaped character sequence 
        /// (i.e excluding the initial escape character).
        /// </summary>
        /// <param name="Stream">The stream to read from</param>
        /// <returns>The character specified by the escape sequence.</returns>
        public static char ReadJSONEscaped(ICharacterStream Stream) {
            var Next = Stream.ReadChar();

            if (Next == 'u') {
                return NextHex(Stream);
                }

            switch (Next) {
                case '\"':
                    return '\"';
                case '\\':
                    return '\\';
                case '/':
                    return '/';
                case '\b':
                    return '\b';
                case '\f':
                    return '\f';
                case '\n':
                    return '\n';
                case '\r':
                    return '\r';
                case '\t':
                    return '\t';
                }
            return (char)0;

            }



        /// <summary>
        /// Read the stream from the current position as a JSON string completion and return the 
        /// number of UTF16 characters. The initial open quote is assumed.
        /// </summary>
        /// <param name="Stream">The stream to read from</param>
        /// <returns>The measured length of the string.</returns>
        public static int GetJSONStringLength(ICharacterStream Stream) {
            int Length = 0;

            for (; !Stream.EOF; Length++) {
                var Next = Stream.ReadChar();

                switch (Next) {
                    case '\"':
                        return Length;
                    case '\\':
                        ReadJSONEscaped(Stream);
                        break;
                    }
                }

            return Length;
            }

        /// <summary>
        /// Read the stream from the current position as a JSON string completion and return the 
        /// resulting string. The initial open quote is assumed.
        /// </summary>
        /// <param name="Stream">The stream to read from</param>
        /// <param name="StringBuilder">Stringbuilder to be used to assemble the string.</param>
        /// <returns>The decoded string</returns>
        public static string GetStringJSON(ICharacterStream Stream, StringBuilder StringBuilder = null) {
            StringBuilder ??= new StringBuilder();

            long Length = 0;

            for (; !Stream.EOF; Length++) {
                var Next = Stream.ReadChar();

                switch (Next) {
                    case '\"':
                        return StringBuilder.ToString();
                    case '\\':
                        StringBuilder.Append(ReadJSONEscaped(Stream));
                        break;
                    default:
                        StringBuilder.Append(Next);
                        break;
                    }
                }

            return StringBuilder.ToString();

            }

        /// <summary>
        /// Read the stream from the current position as a JSON string completion and return the 
        /// resulting string. The initial open quote is assumed.
        /// <para>This method produces the same output as GetJSONString but does so by first
        /// determining the length of the string, allocating a sufficiently large buffer to 
        /// hold the result and re-reading. Depending on the circumstances, this may or may
        /// not be more efficient.</para>
        /// </summary>
        /// <param name="Stream">The stream to read from</param>
        /// <returns>The decoded string</returns>
        public static string GetJSONStringBuffered(ICharacterBufferedStream Stream) {
            Stream.Mark();
            var Length = GetJSONStringLength(Stream);
            Stream.Restore();
            return GetStringJSON(Stream, new StringBuilder(Length));
            }

        /// <summary>
        /// Read the stream from the current position as a JSON string completion containing
        /// base64 encoded binary data and return the number of bytes necessary to store the
        /// result. The initial open quote is assumed.
        /// </summary>
        /// <param name="Stream">The stream to read from</param>
        /// <returns>The decoded data</returns>
        public static long GetBase64StringLength(ICharacterStream Stream) {
            long Length = 0;
            int Count = 0;

            while (!Stream.EOF) {
                char c = Stream.ReadChar();
                if (BaseConvert.BASE64Value[c] < 64) {
                    if ((Count++ % 4) > 0) {
                        Length++;
                        }
                    }
                else if (c == '\"') {
                    return Length;
                    }

                }
            return Length;

            }

        /// <summary>
        /// Read the stream from the current position as a JSON string completion containing
        /// base64 encoded binary data and return the resulting string. The initial open quote is assumed.
        /// </summary>
        /// <param name="Stream">The stream to read from</param>
        /// <returns>The decoded data</returns>
        public static byte[] GetBinaryBase64(ICharacterStream Stream) {
            using var Buffer = new MemoryStream();
            int Count = 0;
            int Last = 0;

            while (!Stream.EOF) {
                var c = Stream.ReadChar();

                //Console.Write ( $".{c}");


                if (c < 127) {
                    var v = BaseConvert.BASE64Value[c];
                    if (v < 64) {
                        if (Count == 0) {
                            Last = v; // 6 bits over
                            Count = 1;
                            }
                        else if (Count == 1) {
                            Buffer.Write((byte)((Last << 2) | (v >> 4)));
                            Last = v & 0xf; // 4 bits over
                            Count = 2;
                            }
                        else if (Count == 2) {
                            Buffer.Write((byte)((Last << 4) | (v >> 2)));
                            Last = v & 0x3; // 2 bits over
                            Count = 3;
                            }
                        else if (Count == 3) {
                            Buffer.Write((byte)((Last << 6) | v));
                            Last = 0; // 0 bits over
                            Count = 0;
                            }
                        }
                    else if (c == '\"') {
                        return Buffer.ToArray();
                        }
                    }

                }

            return Buffer.ToArray();
            }

        /// <summary>
        /// Read the stream from the current position as a JSON string completion containing
        /// base64 encoded binary data and return the resulting string. The initial open quote is assumed.
        /// </summary>
        /// <param name="Result">The array to write the result to.</param>
        /// <param name="Start">The position in the array at which to start writing.</param>
        /// <param name="Stream">The stream to read from</param>
        public static void GetBase64String(ICharacterStream Stream, byte[] Result,
                        int Start = 0) {
            using var Buffer = new MemoryStream();
            int Count = 0;
            int Last = 0;
            int i = Start;

            while (!Stream.EOF) {
                var c = Stream.ReadChar();

                if (c < 127) {
                    var v = BaseConvert.BASE64Value[c];
                    if (v < 64) {
                        if (Count == 0) {
                            Last = v; // 6 bits over
                            Count = 1;
                            }
                        else if (Count == 1) {
                            Result[i++] = (byte)((Last << 2) | (v >> 4));
                            Last = v & 0xf; // 4 bits over
                            Count = 2;
                            }
                        else if (Count == 2) {
                            Result[i++] = (byte)((Last << 4) | (v >> 2));
                            Last = v & 0x3; // 2 bits over
                            Count = 3;
                            }
                        else if (Count == 3) {
                            Result[i++] = (byte)((Last << 6) | v);
                            Last = 0; // 0 bits over
                            Count = 0;
                            }
                        }
                    else if (c == '\"') {
                        return;
                        }
                    }
                }
            }

        /// <summary>
        /// Read the stream from the current position as a JSON string completion containing
        /// base64 encoded binary data and return the resulting string. The initial open quote is assumed.
        /// <para>This method produces the same output as GetJSONString but does so by first
        /// determining the length of the string, allocating a sufficiently large buffer to 
        /// hold the result and re-reading. Depending on the circumstances, this may or may
        /// not be more efficient.</para>
        /// </summary>
        /// <param name="Stream">The stream to read from</param>
        /// <returns>The decoded data</returns>
        public static byte[] GetBase64StringBuffered(ICharacterBufferedStream Stream) {
            Stream.Mark();
            var Length = GetBase64StringLength(Stream);
            Stream.Restore();
            var Result = new byte[Length];
            GetBase64String(Stream, Result);
            return Result;
            }

        }



    }
