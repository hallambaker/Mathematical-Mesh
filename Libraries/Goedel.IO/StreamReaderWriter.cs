﻿#region // Copyright - MIT License
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

namespace Goedel.IO;

/// <summary>
/// Base class for various stream reader classes to avoid the need to override the
/// unused methods every time.
/// </summary>
public abstract class StreamReaderBase : Stream {

    /// <summary>
    /// Gets a value indicating whether the current stream supports reading (is always false).
    /// </summary>
    public override bool CanRead => true;

    /// <summary>
    /// Gets a value indicating whether the current stream supports seeking(is always false).
    /// </summary>
    public override bool CanSeek => false;

    /// <summary>
    /// Gets a value indicating whether the current stream supports writing(is always true).
    /// </summary>
    public override bool CanWrite => false;

    /// <summary>
    /// Gets the position within the current stream. The set operation is not supported.
    /// </summary>
    public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    /// <summary>
    /// Clears all buffers for this stream and causes any buffered data to be written 
    /// to the underlying device.
    /// </summary>
    public override void Flush() { return; }

    /// <summary>
    /// Sets the position within the current buffered stream (not supported).
    /// </summary>
    /// <param name="offset">A byte offset relative to the <paramref name="origin"/> parameter.</param>
    /// <param name="origin">A value of type SeekOrigin indicating the reference point used to obtain the new position.</param>
    /// <returns></returns>
    public override long Seek(long offset, SeekOrigin origin) => throw new NotImplementedException();

    /// <summary>
    /// Sets the length of the output frame.
    /// </summary>
    /// <param name="value"></param>
    public override void SetLength(long value) => throw new NotImplementedException();

    /// <summary>
    /// Write data to the output stream.
    /// </summary>
    /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from 
    /// <paramref name="buffer"/> to the current stream.</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
    /// at which to begin copying bytes to the current stream.</param>
    /// <param name="count">The number of bytes to be written to the current stream.</param>

    public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();

    }

/// <summary>
/// Base class for various stream reader classes to avoid the need to override the
/// unused methods every time.
/// </summary>
public abstract class StreamWriterBase : Stream {

    /// <summary>
    /// Gets a value indicating whether the current stream supports reading (is always false).
    /// </summary>
    public override bool CanRead => false;

    /// <summary>
    /// Gets a value indicating whether the current stream supports seeking(is always false).
    /// </summary>
    public override bool CanSeek => false;

    /// <summary>
    /// Gets a value indicating whether the current stream supports writing(is always true).
    /// </summary>
    public override bool CanWrite => true;

    /// <summary>
    /// Gets the position within the current stream. The set operation is not supported.
    /// </summary>
    public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    /// <summary>
    /// Clears all buffers for this stream and causes any buffered data to be written 
    /// to the underlying device.
    /// </summary>
    public override void Flush() { return; }

    /// <summary>
    /// Sets the position within the current buffered stream (not supported).
    /// </summary>
    /// <param name="offset">A byte offset relative to the <paramref name="origin"/> parameter.</param>
    /// <param name="origin">A value of type SeekOrigin indicating the reference point used to obtain the new position.</param>
    /// <returns></returns>
    public override long Seek(long offset, SeekOrigin origin) => throw new NotImplementedException();

    /// <summary>
    /// Sets the length of the output frame.
    /// </summary>
    /// <param name="value"></param>
    public override void SetLength(long value) => throw new NotImplementedException();

    /// <summary>
    /// Copies bytes from the stream to an array.
    /// </summary>
    /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the 
    /// specified byte array with the values between <paramref name="offset"/> and 
    /// (<paramref name="offset"/> + <paramref name="count"/> - 1) 
    /// replaced by the bytes read from the current source.</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing 
    /// the data read from the current stream.</param>
    /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
    /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes 
    /// requested if that many bytes are not currently available, or zero (0) if the end of the stream 
    /// has been reached.</returns>
    public override int Read(byte[] buffer, int offset, int count) => throw new NotImplementedException();
    }
