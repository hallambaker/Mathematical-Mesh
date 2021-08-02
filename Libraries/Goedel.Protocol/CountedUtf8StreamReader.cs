//  © 2021 by Phill Hallam-Baker
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

using System;
using System.IO;


namespace Goedel.Protocol {

    /// <summary>
    /// Returns stream reader that tracks line and column numbers.
    /// </summary>
    public class CountedUtf8StreamReader : Stream {
        #region // Properties

        Stream Stream { get; }

        ///<summary>The line number.</summary> 
        public int Line { get; set; } = 1;

        ///<summary>The column number taking into account UTF8 encoding.</summary> 
        public int Column { get; set; } = 1;


        bool utf8Prefix = false;

        ///<inheritdoc/>
        public override bool CanRead => true;

        ///<inheritdoc/>
        public override bool CanSeek => false;

        ///<inheritdoc/>
        public override bool CanWrite => false;

        ///<inheritdoc/>
        public override long Length => Stream.Length;

        ///<inheritdoc/>
        public override long Position {
            get => Stream.Position;
            set => Stream.Position = value;
            }

        #endregion

        #region // Constructors

        /// <summary>
        /// Return a counter wrapper for <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The stream to wrap.</param>
        public CountedUtf8StreamReader(Stream stream) => Stream = stream;

        //{



        //var buffer = new byte[Stream.Length];
        //stream.Read(buffer, 0, stream.Length);
        //var text = buffer.ToUTF8();
        //Screen.Write(text);

        //}
        #endregion

        #region // local methods

        /// <summary>
        /// The counter method, increment the line and colum counters according to the UTF8 status of 
        /// <paramref name="b"/>.
        /// </summary>
        /// <param name="b">The byte read.</param>
        void Count(byte b) {
            if (b >= 0x80) {
                utf8Prefix = true;
                }
            else {
                utf8Prefix = false;
                //Screen.Write($"{b}={(char)b}");
                if (utf8Prefix) {
                    Column++;
                    }
                else if (b == 13) {
                    Line++;
                    Column = 1;
                    }
                else if (b >= 32) {
                    Column++;
                    }
                }
            }

        #endregion

        #region // Implement abstract methods of Stream.

        ///<inheritdoc/>
        public override int Read(byte[] buffer, int offset, int count) {
            var length = Stream.Read(buffer, offset, count);

            // Count the UTF8 characters.
            for (int i = 0; i < length; i++) {
                Count(buffer[offset + i]);

                }

            return length;
            }

        ///<inheritdoc/>
        public override void Flush() => Stream.Flush();

        ///<inheritdoc/>
        public override long Seek(long offset, SeekOrigin origin) => throw new NotImplementedException();

        ///<inheritdoc/>
        public override void SetLength(long value) => throw new NotImplementedException();

        ///<inheritdoc/>
        public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();






        #endregion

        }
    }
