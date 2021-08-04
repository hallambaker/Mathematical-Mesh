#region // Copyright
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
#endregion


using System.IO;

using Goedel.Utilities;

namespace Goedel.Protocol {

    /// <summary>
    /// Read and buffer data chunks from a stream. This could be made a lot
    /// more efficient for longer streams but is acceptable for small ones.
    /// </summary>
    public class Dechunk {

        /// <summary>
        /// Tead a string from the stream
        /// </summary>
        /// <param name="Length">Length of stream. If less than zero,
        /// HTTP chunked encoding is assumed.</param>
        /// <param name="Stream">The stream to be read.</param>
        /// <returns>The array data.</returns>
        /// <returns>Data read from stream</returns>
        public static string ReadString(long Length, Stream Stream) {
            var Buffer = ReadBytes(Length, Stream);
            return System.Text.Encoding.UTF8.GetString(Buffer, 0, Buffer.Length);
            }

        /// <summary>
        /// Read an array of bytes from a stream. Note that the length
        /// of the byte array is limited to 2GB internally. For longer 
        /// streams, some form of processing pipeline is advised.
        /// </summary>
        /// <param name="Length">Length of stream. If less than zero,
        /// HTTP chunked encoding is assumed.</param>
        /// <param name="Stream">The stream to be read.</param>
        /// <returns>The array data.</returns>
        public static byte[] ReadBytes(long Length, Stream Stream) {

            if (Length < 0) {
                return ReadChunked(Stream);
                }
            Assert.AssertFalse(Length > int.MaxValue, MessageTooBig.Throw);



            byte[] Buffer = new byte[Length];
            int Counter = 0;


            while (Counter < Length) {
                int Bytes = Stream.Read(Buffer, Counter, (int)Length - Counter);
                Counter += Bytes;
                }

            return Buffer;
            }

        /// <summary>
        /// Read an array of bytes from a stream. Note that the length
        /// of the byte array is limited to 2GB internally. For longer 
        /// streams, some form of processing pipeline is advised.
        /// </summary>
        /// <param name="Stream">The stream to be read.</param>
        /// <returns>The array data.</returns>
        public static byte[] ReadChunked(Stream Stream) => throw new NYI();

        }
    }
