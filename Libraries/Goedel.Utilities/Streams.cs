#region // Copyright - MIT License
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

namespace Goedel.Utilities;




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
        Assert.AssertTrue(offset <= Int32.MaxValue & count <= Int32.MaxValue, Not64Bit.Throw);
        return Stream.Read(buffer, (int)offset, (int)count);
        }

    /// <summary>
    /// Writes a sequence of bytes to the current CryptoStream and advances the 
    /// position within the stream by the number of bytes written.
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
        Assert.AssertTrue(offset <= Int32.MaxValue & count <= Int32.MaxValue, Not64Bit.Throw);
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
