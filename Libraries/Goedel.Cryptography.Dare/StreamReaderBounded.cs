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
using System.IO;

using Goedel.IO;

namespace Goedel.Cryptography.Dare;


/// <summary>
/// A stream that reads from a container record.
/// </summary>
public partial class StreamReaderBounded : StreamReaderBase {
    #region // Boilerplate implementations
    /// <summary>
    /// Gets the frame length in bytes. 
    /// </summary>
    public override long Length { get; }
    #endregion

    Stream Stream;
    long Start;

    /// <summary>
    /// The number of bytes remaining to be read.
    /// </summary>
    public long Remaining => Length - (Stream.Position - Start);

    /// <summary>
    /// Construct a bounded reader for the frame.
    /// </summary>
    /// <param name="Stream">The underlying stream to be read</param>
    /// <param name="Start">The position at which to begin reading the file.</param>
    /// <param name="Length">The maximum number of bytes to be read.</param>
    public StreamReaderBounded(Stream Stream, long Start, long Length) {
        Stream.Seek(Start, SeekOrigin.Begin);
        this.Length = Length;
        this.Stream = Stream;
        this.Start = Start;
        }

    /// <summary>
    /// Copies bytes from the current buffered stream to an array.
    /// </summary>
    /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the 
    /// specified byte array with the values between <paramref name="offset"/> and 
    /// (<paramref name="offset"/> + <paramref name="Count"/> - 1) 
    /// replaced by the bytes read from the current source.</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing 
    /// the data read from the current stream.</param>
    /// <param name="Count">The maximum number of bytes to be read from the current stream.</param>
    /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes 
    /// requested if that many bytes are not currently available, or zero (0) if the end of the stream 
    /// has been reached.</returns>
    public override int Read(byte[] buffer, int offset, int Count) {
        Count = Math.Min(Count, (int)Remaining);
        return Stream.Read(buffer, offset, Count);
        }

    }
