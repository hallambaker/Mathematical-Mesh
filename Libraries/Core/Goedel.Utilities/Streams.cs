using System;
using System.
/* Unmerged change from project 'Goedel.Utilities'
Before:
using System.Text;
using System.IO;
After:
using System.IO;
using System.Text;
*/
IO;

namespace Goedel.Utilities {




    public static partial class Extension {

        /// <summary>
        /// Reads a sequence of bytes from the current stream and advances the position 
        /// within the stream by the number of bytes read using index pointers that
        /// are 64 bits.
        /// </summary>
        /// <param name="Stream">The stream to be read.</param>
        /// <param name="buffer">An array of bytes. A maximum of count bytes are read 
        /// from the current stream and stored in <paramref name="buffer"/>.</param>
        /// <param name="offset">The byte offset in <paramref name="buffer"/> at which 
        /// to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current 
        /// stream.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less 
        /// than the number of bytes requested if that many bytes are not currently available, 
        /// or zero if the end of the stream has been reached.</returns>
        /// <remarks>This routine does not currently implement 64 bit clean processing,
        /// it merely provides a single point through which such processing may introduced 
        /// should it prove necessary.</remarks>
        public static long Read(
                this Stream Stream,
                byte[] buffer,
                long offset,
                long count) {
            Assert.AssertTrue(offset <= Int32.MaxValue & count <= Int32.MaxValue, Not64Bit.ThrowNew);
            return Stream.Read(buffer, (int)offset, (int)count);
            }

        /// <summary>
        /// Writes a sequence of bytes to the current CryptoStream and advances the 
        /// current position within the stream by the number of bytes written.
        /// </summary>
        /// <param name="Stream">The stream to be written to.</param>
        /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from <paramref name="buffer"/> to the current stream.</param>
        /// <param name="offset">The byte offset in <paramref name="buffer"/> at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        /// <remarks>This routine does not currently implement 64 bit clean processing,
        /// it merely provides a single point through which such processing may introduced 
        /// should it prove necessary.</remarks>
        public static void Write(
            this Stream Stream,
            byte[] buffer,
            long offset,
            long count) {
            Assert.AssertTrue(offset <= Int32.MaxValue & count <= Int32.MaxValue, Not64Bit.ThrowNew);
            Stream.Write(buffer, (int)offset, (int)count);
            }


        /// <summary>
        /// Write the entire contents of <paramref name="buffer"/> to <paramref name="stream"/>
        /// </summary>
        /// <param name="stream">Stream to write to.</param>
        /// <param name="buffer">the data to be written.</param>
        public static void Write(
            this Stream stream,
            byte[] buffer) {

            if (buffer != null) {
                stream.Write(buffer, 0, buffer.Length);
                }
            }

        }
    }
