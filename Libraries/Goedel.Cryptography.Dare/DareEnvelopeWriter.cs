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

internal class DareEnvelopeWriter : Stream {
    /// <summary>
    ///     Gets a value indicating whether the current stream supports reading.
    /// </summary>
    public override bool CanRead => false;

    /// <summary>
    ///     Gets a value indicating whether the current stream supports seeking(is always false).
    /// </summary>
    public override bool CanSeek => false;

    /// <summary>
    ///     Gets a value indicating whether the current stream supports writing.
    /// </summary>
    public override bool CanWrite => true;

    /// <summary>
    ///     Gets the length written in bytes (not implemented).
    /// </summary>
    public override long Length => throw new NotImplementedException();

    /// <summary>
    ///     Gets the position within the current stream.  (not implemented).
    /// </summary>
    public override long Position {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
        }

    private readonly DareHeader dareHeader;
    //private readonly CryptoStack cryptoStack;
    private readonly CryptoStackStreamWriter cryptoStackStreamWriter;
    private readonly JsonWriter outputStream;
    private readonly Stream writer;
    private bool disposed;

    /// <summary>Create a writer to output a DARE Message to a stream.</summary>
    /// <param name="cryptoParameters">
    ///     Specifies the cryptographic enhancements to
    ///     be applied to this message.
    /// </param>
    /// <param name="outputStream">The stream to which the output will be written.</param>
    /// <param name="contentMeta">The Content metadata</param>
    /// <param name="contentLength">
    ///     The content length. This value is ignored if the Plaintext
    ///     parameter is not null. If the value is less than 0, chunked encoding
    ///     will be used for the payload data.
    /// </param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
    /// <param name="dataSequences">
    ///     Data sequences to be converted to an EDS and presented
    ///     as an EDSS header entry.
    /// </param>
    /// <param name="cover">Optional Sequence of plaintext bytes specifying a cover page
    /// to be presented in place of an encrypted document if it cannot be decrypted.</param>
    public DareEnvelopeWriter(
        CryptoParameters cryptoParameters,
        Stream outputStream,
        ContentMeta contentMeta = null,
        long contentLength = -1,
        byte[] cloaked = null,
        List<byte[]> dataSequences = null,
        byte[] cover = null) : this(cryptoParameters,
                new JsonWriter(outputStream), contentMeta, contentLength, cloaked, dataSequences, cover) {
        }


    /// <summary>
    ///     Create a writer to output a DARE Message to a stream.
    /// </summary>
    /// <param name="cryptoParameters">
    ///     Specifies the cryptographic enhancements to
    ///     be applied to this message.
    /// </param>
    /// <param name="outputStream">The stream to which the output will be written.</param>
    /// <param name="contentMeta">The Content metadata</param>
    /// <param name="contentLength">
    ///     The content length. This value is ignored if the Plaintext
    ///     parameter is not null. If the value is less than 0, chunked encoding
    ///     will be used for the payload data.
    /// </param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
    /// <param name="dataSequences">
    ///     Data sequences to be converted to an EDS and presented
    ///     as an EDSS header entry.
    /// </param>
    /// <param name="cover">Optional Sequence of plaintext bytes specifying a cover page
    /// to be presented in place of an encrypted document if it cannot be decrypted.</param>
    public DareEnvelopeWriter(
        CryptoParameters cryptoParameters,
        JsonWriter outputStream,
        ContentMeta contentMeta = null,
        long contentLength = -1,
        byte[] cloaked = null,
        List<byte[]> dataSequences = null,
        byte[] cover = null) {
        this.outputStream = outputStream;

        dareHeader = new DareHeader() {
            Cover = cover
            };
        dareHeader.BindEncoder(cryptoParameters, cloaked, dataSequences);

        //cryptoStack = new CryptoStackEncode(cryptoParameters, dareHeader, cloaked, dataSequences);

        outputStream.WriteArrayStart();
        dareHeader.Serialize(outputStream);
        outputStream.WriteArraySeparator();

        cryptoStackStreamWriter = dareHeader.CryptoStack.GetEncoder(
            outputStream.Output, PackagingFormat.Body, contentLength);
        writer = cryptoStackStreamWriter.Writer;
        }

    /// <summary>
    ///     Write data to the output stream.
    /// </summary>
    /// <param name="buffer">
    ///     An array of bytes. This method copies <paramref name="count" /> bytes from
    ///     <paramref name="buffer" /> to the current stream.
    /// </param>
    /// <param name="offset">
    ///     The zero-based byte offset in <paramref name="buffer" />
    ///     at which to begin copying bytes to the current stream.
    /// </param>
    /// <param name="count">The number of bytes to be written to the current stream.</param>
    public override void Write(byte[] buffer,
        int offset,
        int count) => writer.Write(buffer, offset, count);

    /// <summary>
    ///     Closes the current stream, completes calculation of cryptographic values (MAC/Digest)
    ///     associated with the current stream. Does not close the target stream because that would
    ///     be stupid.
    /// </summary>
    public override void Close() {
        // write out the trailer
        cryptoStackStreamWriter.Close();


        var trailer = dareHeader.CryptoStackEncode.GetTrailer(cryptoStackStreamWriter);
        if (trailer != null) {
            outputStream.WriteArraySeparator();
            trailer.Serialize(outputStream);
            }

        // Close the message Sequence.
        outputStream.WriteArrayEnd();

        // Force writes to the output stream.
        Flush();
        }


    /// <summary>
    ///     Clears all buffers for this stream and causes any buffered data to be written
    ///     to the underlying device.
    /// </summary>
    public override void Flush() => outputStream.Flush();

    /// <summary>
    ///     Copies bytes from the current buffered stream to an array (not supported).
    /// </summary>
    /// <param name="buffer">
    ///     An array of bytes. When this method returns, the buffer contains the
    ///     specified byte array with the values between <paramref name="offset" /> and
    ///     (<paramref name="offset" /> + <paramref name="count" /> - 1)
    ///     replaced by the bytes read from the current source.
    /// </param>
    /// <param name="offset">
    ///     The zero-based byte offset in <paramref name="buffer" /> at which to begin storing
    ///     the data read from the current stream.
    /// </param>
    /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
    /// <returns>
    ///     The total number of bytes read into the buffer. This can be less than the number of bytes
    ///     requested if that many bytes are not currently available, or zero (0) if the end of the stream
    ///     has been reached.
    /// </returns>
    public override int Read(byte[] buffer,
        int offset,
        int count) => throw new NotImplementedException();


    /// <summary>
    ///     Sets the position within the current buffered stream (not supported).
    /// </summary>
    /// <param name="offset">A byte offset relative to the <paramref name="origin" /> parameter.</param>
    /// <param name="origin">A value of type SeekOrigin indicating the reference point used to obtain the new position.</param>
    /// <returns></returns>
    public override long Seek(long offset,
        SeekOrigin origin) => throw new NotImplementedException();

    /// <summary>
    ///     Sets the length of the output frame (not implemented).
    /// </summary>
    /// <param name="value"></param>
    public override void SetLength(long value) => throw new NotImplementedException();

    /// <summary>
    ///     Dispose method, frees resources when disposing,
    /// </summary>
    /// <param name="disposing">
    ///     true to release both managed and unmanaged resources;
    ///     false to release only unmanaged resources.
    /// </param>
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
    ///     The class specific disposal routine.
    /// </summary>
    protected virtual void Disposing() => Close();

    /// <summary>
    ///     Destructor.
    /// </summary>
    ~DareEnvelopeWriter() {
        Dispose(false);
        }
    }
