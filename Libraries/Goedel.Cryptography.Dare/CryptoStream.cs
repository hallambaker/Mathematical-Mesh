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
namespace Goedel.Cryptography.Dare;


/// <summary>
/// Packing formats
/// </summary>
public enum PackagingFormat {
    /// <summary>
    /// Package directly without padding
    /// </summary>
    Direct,

    /// <summary>
    /// Package as an Enhanced Data Sequence.
    /// </summary>
    EDS,

    /// <summary>
    /// Package as an envelope body.
    /// </summary>
    Body

    }


/// <summary>
/// Tracks the cryptography providers used to compute MACs and Digests.
/// </summary>
public class CryptoStackStream : Stream {

    /// <summary>
    /// Gets a value indicating whether the current stream supports reading.
    /// </summary>
    public override bool CanRead => Stream != null;

    /// <summary>
    /// Gets a value indicating whether the current stream supports writing.
    /// </summary>
    public override bool CanWrite => true;

    /// <summary>
    /// The externally accessible stream.
    /// </summary>
    protected Stream Stream { get; }

    /// <summary>
    /// The Massage Authentication Code Transform.
    /// </summary>
    protected HashAlgorithm Mac;

    /// <summary>
    /// The Digest Transform.
    /// </summary>
    protected HashAlgorithm Digest;

    /// <summary>
    /// The computed MAC value.
    /// </summary>
    public byte[] MacValue { get; protected set; }

    /// <summary>
    /// The computed Digest value.
    /// </summary>
    public byte[] DigestValue { get; protected set; }

    ///<summary>The number of bytes read</summary> 
    public long BytesRead { get; protected set; } = 0;

    ///<summary>The number of bytes read</summary> 
    public long BytesWrite { get; protected set; } = 0;

    /// <summary>
    /// Create a CryptoStack
    /// </summary>
    /// <param name="Mac">The Message Authentication Code Transform.</param>
    /// <param name="Digest">The Digest Transform.</param>
    protected CryptoStackStream(
                HashAlgorithm Mac,
                HashAlgorithm Digest) {
        this.Mac = Mac;
        this.Digest = Digest;
        }

    /// <summary>
    /// Creates a dummy stream. This may be a sink that simply discards the data (for 
    /// calculating digest values) or a passthrough that keeps the target stream open
    /// when the encryption stream is closed.
    /// </summary>
    /// <param name="Stream">The target stream. If null, output is simply discarded.</param>
    public CryptoStackStream(Stream Stream = null) => this.Stream = Stream;

    #region IDisposable boilerplate code.

    bool disposed = false;
    /// <summary>
    /// Dispose method, frees resources when disposing, 
    /// </summary>
    /// <param name="disposing">true to release both managed and unmanaged resources; 
    /// false to release only unmanaged resources.</param>
    protected override void Dispose(bool disposing) {
        if (disposed) {
            return;
            }

        if (disposing) {
            Disposing();
            }

        disposed = true;
        }

    /// <summary>
    /// Destructor.
    /// </summary>
    ~CryptoStackStream() {
        Dispose(false);
        }
    #endregion

    /// <summary>
    /// The class specific disposal routine.
    /// </summary>
    protected virtual void Disposing() => Close();

    /// <summary>
    /// Copies bytes from the current buffered stream to an array (not supported).
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
    public override int Read(byte[] buffer, int offset, int count) {
        var read = Stream == null ? 0 : Stream.Read(buffer, offset, count);
        BytesRead += read;
        return read;
        }


    /// <summary>
    /// Write data to the output stream.
    /// </summary>
    /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from 
    /// <paramref name="buffer"/> to the current stream.</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
    /// at which to begin copying bytes to the current stream.</param>
    /// <param name="count">The number of bytes to be written to the current stream.</param>
    public override void Write(byte[] buffer, int offset, int count) {
        BytesWrite += count;
        Stream?.Write(buffer, offset, count);
        }

    /// <summary>
    /// Closes the current stream, completes calculation of cryptographic values (MAC/Digest)
    /// associated with the current stream. Does not close the target stream because that would
    /// be stupid.
    /// </summary>
    public override void Close() {

        }

    /// <summary>
    /// Clears all buffers for this stream and causes any buffered data to be written 
    /// to the underlying device.
    /// </summary>
    public override void Flush() => Stream?.Flush();

    #region // Boilerplate implementations

    /// <summary>
    /// Gets a value indicating whether the current stream supports seeking(is always false).
    /// </summary>
    public override bool CanSeek => false;

    /// <summary>
    /// Gets the position within the current stream. The set operation is not supported.
    /// </summary>
    public override long Position {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
        }


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
    /// Gets the frame length in bytes. 
    /// </summary>
    public override long Length => throw new NotImplementedException();



    #endregion

    }

#region //reader
/// <summary>
/// Tracks the cryptography providers used to compute MACs and Digests.
/// </summary>
public class CryptoStackStreamReader : CryptoStackStream {

    /// <summary>
    /// Gets a value indicating whether the current stream supports reading (is always true).
    /// </summary>
    public override bool CanRead => true;

    /// <summary>
    /// Gets a value indicating whether the current stream supports writing (is always false).
    /// </summary>
    public override bool CanWrite => false;

    JsonBcdReader jbcdReader;
    CryptoStream streamMac;
    CryptoStream streamDigest;

    /// <summary>
    /// Create a CryptoStack
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="mac"></param>
    /// <param name="digest"></param>
    public CryptoStackStreamReader(
                JsonBcdReader stream,
                HashAlgorithm mac,
                HashAlgorithm digest) : base(mac, digest) {
        this.jbcdReader = stream;
        stream.ReadBinaryToken();

        if (Mac != null) {
            streamMac = new CryptoStream(Stream.Null, Mac, CryptoStreamMode.Write);
            }
        if (Digest != null) {
            streamDigest = new CryptoStream(Stream.Null, Digest, CryptoStreamMode.Write);
            }
        }


    /// <summary>
    /// Copies bytes from the current buffered stream to an array 
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
    public override int Read(byte[] buffer, int offset, int count) {
        var length = jbcdReader.ReadBinaryData(buffer, offset, count);
        BytesRead += length;
        streamMac?.Write(buffer, offset, length);
        streamDigest?.Write(buffer, offset, length);

        //Console.WriteLine($"Read {buffer} bytes");
        return length;
        }



    /// <summary>
    /// Write data to the output stream.(not supported).
    /// </summary>
    /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from 
    /// <paramref name="buffer"/> to the current stream.</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
    /// at which to begin copying bytes to the current stream.</param>
    /// <param name="count">The number of bytes to be written to the current stream.</param>
    public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();


    /// <summary>
    /// Closes the current stream, completes calculation of cryptographic values (MAC/Digest)
    /// associated with the current stream. Does not close the target stream because that would
    /// be stupid.
    /// </summary>
    public override void Close() {
        if (streamMac != null) {
            streamMac.FlushFinalBlock();
            MacValue = Mac?.Hash;
            }
        if (streamDigest != null) {
            streamDigest.FlushFinalBlock();
            DigestValue = Digest?.Hash;
            }
        }


    }


/// <summary>
/// Tracks the cryptography providers used to compute MACs and Digests.
/// </summary>
public class CryptoStackJBCDStreamReader : CryptoStackStream {

    /// <summary>
    /// Gets a value indicating whether the current stream supports reading (is always false).
    /// </summary>
    public override bool CanRead => true;

    /// <summary>
    /// Gets a value indicating whether the current stream supports writing(is always true).
    /// </summary>
    public override bool CanWrite => false;

    Stream inputStream;
    CryptoStream streamMac;
    CryptoStream streamDigest;


    /// <summary>
    /// Create a CryptoStack
    /// </summary>
    /// <param name="inputStream"></param>
    /// <param name="Mac"></param>
    /// <param name="Digest"></param>
    public CryptoStackJBCDStreamReader(
                Stream inputStream,
                HashAlgorithm Mac,
                HashAlgorithm Digest) : base(Mac, Digest) {
        this.inputStream = inputStream;

        if (Mac != null) {
            streamMac = new CryptoStream(Stream.Null, Mac, CryptoStreamMode.Write);
            }
        if (Digest != null) {
            streamDigest = new CryptoStream(Stream.Null, Digest, CryptoStreamMode.Write);
            }
        }


    /// <summary>
    /// Copies bytes from the current buffered stream to an array 
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
    public override int Read(byte[] buffer, int offset, int count) {
        var length = inputStream.Read(buffer, offset, count);

        BytesRead += length;
        streamMac?.Write(buffer, offset, length);
        streamDigest?.Write(buffer, offset, length);

        //Console.WriteLine($"Read {buffer} bytes");
        return length;
        }




    /// <summary>
    /// Write data to the output stream.(not supported).
    /// </summary>
    /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from 
    /// <paramref name="buffer"/> to the current stream.</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
    /// at which to begin copying bytes to the current stream.</param>
    /// <param name="count">The number of bytes to be written to the current stream.</param>
    public override void Write(byte[] buffer, int offset, int count) =>
        throw new NotImplementedException();

    }

#endregion

#region //writer
/// <summary>
/// Tracks the cryptography providers used to compute MACs and Digests.
/// </summary>
public class CryptoStackStreamWriter : CryptoStackStream {

    /// <summary>
    /// Gets a value indicating whether the current stream supports reading (is always false).
    /// </summary>
    public override bool CanRead => false;

    /// <summary>
    /// Gets a value indicating whether the current stream supports writing(is always true).
    /// </summary>
    public override bool CanWrite => true;

    /////<summary>The trailer object (if required)</summary> 
    //public DareTrailer Trailer = null;


    CryptoStream streamMac;
    CryptoStream streamDigest;
    Stream output;
    PackagingFormat packagingFormat;
    long payloadLength;

    bool specifiedLength;

    CryptoStream CryptoStream { get; set; }


    /// <summary>
    /// The stream writer.
    /// </summary>
    public Stream Writer {
        get => CryptoStream ?? (Stream)this;
        set => CryptoStream = value as CryptoStream;
        }

    /// <summary>
    /// Create a CryptoStack
    /// </summary>
    /// <param name="output">The target stream to be written to. This is wrapped in a pipe to prevent
    /// it being closed when the encryption stream is closed.</param>
    /// <param name="mac">The Message Authentication Code Transform.</param>
    /// <param name="digest">The Digest Transform.</param>
    /// <param name="packagingFormat">The packing format to use on the output.</param>
    /// <param name="payloadLength">The payload length including cryptographic
    /// enhancements.</param>
    public CryptoStackStreamWriter(
                Stream output,
                PackagingFormat packagingFormat,
                HashAlgorithm mac,
                HashAlgorithm digest,
                long payloadLength) : base(mac, digest) {

        //this.JSONWriter = JSONWriter;


        //Console.Write($"Payload length is {PayloadLength}");

        this.packagingFormat = packagingFormat;

        Writer = this;

        this.payloadLength = payloadLength;
        if (payloadLength >= 0 & packagingFormat != PackagingFormat.Direct) {
            JsonBWriter.WriteTag(output, JSONBCD.DataTerm, payloadLength);
            specifiedLength = true;
            //Console.Write($"Written tag for {PayloadLength}");
            }
        else {
            specifiedLength = false;
            }


        streamMac = mac == null ? null : new CryptoStream(new CryptoStackStream(), mac, CryptoStreamMode.Write);



        if (digest != null) {
            streamDigest = new CryptoStream(
            new CryptoStackStream(output), digest, CryptoStreamMode.Write);
            output = streamDigest;
            }
        this.output = output;

        }


    /// <summary>
    /// Copies bytes from the current buffered stream to an array (not supported).
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

    bool final = false;
    /// <summary>
    /// Write data to the output stream.
    /// </summary>
    /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from 
    /// <paramref name="buffer"/> to the current stream.</param>
    /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/>
    /// at which to begin copying bytes to the current stream.</param>
    /// <param name="count">The number of bytes to be written to the current stream.</param>
    public override void Write(byte[] buffer, int offset, int count) {
        streamMac?.Write(buffer, offset, count);
        BytesWrite += count;

        if (payloadLength > 0 | packagingFormat == PackagingFormat.Direct) {
            payloadLength -= count;
            output.Write(buffer, offset, count);

            //Console.Write($"  Have {count} bytes to stream");
            }
        else {
            JsonBWriter.WriteTag(output, final ? JSONBCD.DataTerm : JSONBCD.DataChunk,
                count);
            output.Write(buffer, offset, count);

            //Console.Write($"  Have {count} chunk (final:{Final}) to stream");
            }
        }

    /// <summary>
    /// Clears all buffers for this stream and causes any buffered data to be written 
    /// to the underlying device.
    /// </summary>
    public override void Flush() => output?.Flush();

    readonly static byte[] Empty = new byte[0];

    bool closed = false;

    /// <summary>
    /// Closes the current stream, completes calculation of cryptographic values (MAC/Digest)
    /// associated with the current stream. Does not close the target stream because that would
    /// be stupid.
    /// </summary>
    public override void Close() {
        if (closed) {
            return;
            }
        closed = true;

        final = true;

        // flush the final blocks of data and write end of stream.
        if (CryptoStream != null) {
            CryptoStream.FlushFinalBlock();
            }
        else if (!specifiedLength) {
            Writer.Write(Empty, 0, 0);
            }


        if (Digest != null) {
            streamDigest?.Dispose();
            streamDigest = null;
            DigestValue = Digest?.Hash;
            Digest?.Dispose();
            Digest = null;
            }


        if (Mac != null) {
            streamMac?.Dispose();
            streamMac = null;
            MacValue = Mac?.Hash;
            Mac?.Dispose();
            if (packagingFormat == PackagingFormat.EDS) {
                JsonBWriter.WriteBinary(output, MacValue);
                }
            }
        }
    }
#endregion
