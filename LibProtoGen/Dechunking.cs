//Sample license text.

using System.IO;
using System.Text;

namespace Goedel.Protocol {

    // This is intended to be the start of a dechunker class to be expanded later.

    public class Dechunk {


        public static string ReadString(long Length, Stream Stream) {
            return Encoding.UTF8.GetString(ReadBytes(Length, Stream));
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
        public static byte [] ReadBytes (long Length, Stream Stream) {

            if (Length < 0) return ReadChunked(Stream);
            if (Length > int.MaxValue) throw new Throw("Message too big");

            byte[] Buffer = new byte[Length];
            int Counter = 0;


            while (Counter < Length) {
                int Bytes = Stream.Read(Buffer, Counter, (int) Length - Counter);
                Counter += Bytes;
                }

            return Buffer;
            }


        public static byte [] ReadChunked (Stream Stream) {
            throw new Throw("Not Yet Implemented");
            }




        }
    }
