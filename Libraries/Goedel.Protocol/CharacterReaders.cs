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

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Goedel.Protocol {

    /// <summary>
    /// Base class for character stream reader.
    /// </summary>
    public abstract class CharacterStream {

        /// <summary>Number of characters read</summary>
        public long Count = 0;
        /// <summary>If true, end of file has been reached</summary>
        public abstract bool EOF { get; }

        /// <summary>Return the next character in the stream without advancing the stream</summary>
        /// <returns>The next character in the stream</returns>
        public abstract char LookNext();

        /// <summary>Return the next character in the stream and advance the stream.</summary>
        /// <returns>The next character in the stream</returns>
        public abstract char GetNext();

        }

    /// <summary>
    /// Buffered character stream, can be restored to a previous position.
    /// </summary>
    public abstract class BufferedCharacterStream : CharacterStream {

        /// <summary>Create a restore point in the stream.</summary>
        public abstract void Mark();

        /// <summary>Return the stream to the position that the reader was at the last time
        /// Mark() was called.</summary>
        public abstract void Restore();
        }

    /// <summary>
    /// String character stream can be restored to a previous position and
    /// can look ahead to the next character
    /// </summary>
    public class StringCharacterStream : BufferedCharacterStream {
        string Source;
        int Position = 0;

        /// <summary>If true, end of file has been reached</summary>
        public override bool EOF => Position >= Source.Length; 

        /// <summary>Construct stream from string source.</summary>
        /// <param name="Source">Input string</param>
        public StringCharacterStream(string Source) {
            this.Source = Source;
            }

        /// <summary>Return the next character in the stream without advancing the stream</summary>
        /// <returns>The next character in the stream</returns>
        public override char LookNext() {
            return Source[Position];
            }

        /// <summary>Return the next character in the stream and advance the stream.</summary>
        /// <returns>The next character in the stream</returns>
        public override char GetNext() {
            return Source[Position++];
            }


        int MarkPosition = -1;
        /// <summary>Create a restore point in the stream.</summary>
        public override void Mark() {
            MarkPosition = Position;
            }

        /// <summary>Return the stream to the position that the reader was at the last time
        /// Mark() was called.</summary>
        public override void Restore() {
            if (MarkPosition >= 0) {
                Position = MarkPosition;
                }
            }

        }

    /// <summary>
    /// Text character stream
    /// </summary>
    public class TextCharacterTextStream : CharacterStream {
        TextReader Source;
        bool _EOF;

        /// <summary>If true, end of file has been reached</summary>
        public override bool EOF=>  _EOF; 

        /// <summary>Create instance from specified source</summary>
        /// <param name="Source">Input stream</param>
        public TextCharacterTextStream(TextReader Source) {
            this.Source = Source;
            _EOF = false;
            }

        /// <summary>Return the next character in the stream without advancing the stream</summary>
        /// <returns>The next character in the stream</returns>
        public override char LookNext() {
            var Char = Source.Peek();
            if (Char < 0) {
                _EOF = true;
                return (char)0;
                }
            return (char)Char;
            }

        /// <summary>Return the next character in the stream and advance the stream.</summary>
        /// <returns>The next character in the stream</returns>
        public override char GetNext() {
            var Char = Source.Read();
            if (Char < 0) {
                _EOF = true;
                return (char)0;
                }
            return (char)Char;
            }

        }


    /// <summary>Buffered character stream reading from byte oriented source
    /// with unicode character conversion. Supports 32 bit Unicode.</summary>
    public abstract class CharacterTextStream : BufferedCharacterStream {
        //byte[] Source;
        //long Position;

        /// <summary>Marked position in stream</summary>
        protected long MarkPosition = -1;
        /// <summary>Buffered character</summary>
        protected int MarkBuffer;
        /// <summary>Number of buffered characters</summary>
        protected int Buffer = -1;

        /// <summary>If true, end of file has been reached</summary>
        protected bool _EOF = false;
        /// <summary>If true, end of file has been reached</summary>
        public override bool EOF => _EOF; 

        /// <summary>Return the next character in the stream and advance the stream.</summary>
        /// <returns>The next character in the stream as an integer.</returns>
        protected abstract int ReadChar();


        /// <summary>Return the next character in the stream without advancing the stream</summary>
        /// <returns>The next character in the stream</returns>
        public override char LookNext() {
            Peek();
            return (char)Buffer;
            }

        /// <summary>Get next character in the stream as Unicode character</summary>
        /// <returns>The character returned.</returns>
        public override char GetNext() {
            Peek();
            Buffer = -1;
            return (char)Buffer;
            }

        void Peek() {
            if (Buffer > 0) {
                return;
                }

            var Byte1 = ReadChar();
            if (_EOF) {
                return;
                }

            if (Byte1 >= 0xf0) {
                // 4 byte sequence
                var Byte2 = ReadChar();
                var Byte3 = ReadChar();
                var Byte4 = ReadChar();
                Buffer = ((Byte1 & 0x1f) << 15) | ((Byte2 & 0x3f) << 12) |
                    ((Byte3 & 0x1f) << 6) | (Byte4 & 0x3f);
                }
            else if (Byte1 >= 0xe0) {
                // 3 byte sequence
                var Byte2 = ReadChar();
                var Byte3 = ReadChar();
                Buffer = ((Byte1 & 0x1f) << 12) | ((Byte2 & 0x3f) << 6) |
                    (Byte3 & 0x1f);
                }
            else if (Byte1 >= 0xc0) {
                // 2 byte sequence
                var Byte2 = ReadChar();
                Buffer = ((Byte1 & 0x1f) << 6) | (Byte2 & 0x3f);
                }
            else {
                Buffer = Byte1;
                }

            }

        }



    /// <summary>
    /// Character stream supporting character and data access.
    /// </summary>
    public class DataCharacterTextStream : CharacterTextStream {
        byte[] Source;
        long Position;

        /// <summary>Create a restore point in the stream.</summary>
        public override void Mark() {
            MarkPosition = Position;
            MarkBuffer = Buffer;
            }

        /// <summary>Return the stream to the position that the reader was at the last time
        /// Mark() was called.</summary>
        public override void Restore() {
            if (MarkPosition >= 0) {
                Position = MarkPosition;
                Buffer = MarkBuffer;
                }
            }


        /// <summary>Default constructor, from byte array.</summary>
        /// <param name="Source">The input source.</param>
        public DataCharacterTextStream(byte[] Source) {
            this.Source = Source;
            Position = 0;
            }

        /// <summary>Read character.</summary>
        /// <returns>32 bit character value</returns>
        protected override int ReadChar() {
            if (Position >= Source.Length) {
                _EOF = true;
                return -1;
                }
            var C1 = Source[Position++];
            return C1;
            }

        }


    }
   