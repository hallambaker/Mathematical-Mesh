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

/// <summary>EARL stream reader/writer class.</summary>
public class EarlStream : Disposable {

    /// <summary>The underlying file stream.</summary>
    protected Stream Stream {
        get => stream ?? OpenStream().CacheValue(out stream);
        set => stream = value;
        }

    Stream? stream = null;

    /// <summary>Length of the stream.</summary>
    public long Length => Stream.Length;

    /// <summary>If true, the stream position is at end of file.</summary>
    public bool EOF => Stream.Position >= Stream.Length;

    /// <summary>Get or set the position in the file.</summary>
    public long Position {
        get => Stream.Position;
        set => Stream.Position = value;
        }



    FileMode FileMode { get; }
    FileAccess FileAccess { get; }

    FileShare FileShare { get; }

    /// <summary>The filename of the underlying stream.</summary>
    public string Filename { get; }

    /// <inheritdoc/>

    protected override void Disposing() {
        CloseStream();
        base.Disposing();
        }

    /// <summary>Constructor, return a new instance with underlying stream <paramref name="stream"/>.</summary>
    /// <param name="stream">The stream to uas as a constructor.</param>
    public EarlStream(Stream stream) {
        Stream = stream;
        }

    /// <summary>Constructor, return a new instance reading from the data <paramref name="data"/>.</summary>
    /// <param name="data">The data to read.</param>
    public EarlStream(byte[] data) {
        stream = new MemoryStream(data);
        }

    /// <summary>Constructor, open a new stream with filename <paramref name="fileName"/>
    /// and the specified file stream attributes.</summary>
    /// <param name="fileName">The name of the file.</param>
    /// <param name="fileMode">The file mode</param>
    /// <param name="fileAccess">Specify read, write or read/write access.(</param>
    /// <param name="fileShare">The file sharing mode.</param>
    /// <param name="stream">The stream to use.</param>
    protected EarlStream(
                string fileName,
                FileMode fileMode,
                FileAccess fileAccess,
                FileShare fileShare,
                Stream stream = null) {
        Filename = fileName;
        FileMode = fileMode;
        FileAccess = fileAccess;
        FileShare = fileShare;
        Stream = stream;
        }

    /// <summary>Create a new file with name <paramref name="fileName"/> and open an
    /// <see cref="EarlStream"/> with type identifier <paramref name="typeIdentifier"/>.</summary>
    /// <param name="fileName">The file name.</param>
    /// <param name="typeIdentifier">The stream type identifier.</param>
    /// <returns>The <see cref="EarlStream"/> created</returns>
    public static EarlStream Create(
                string fileName,
                byte[] typeIdentifier) {
        var fileStream = fileName.OpenFileNew();

        var stream = new EarlStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read, fileStream);
        stream.WriteTypeIdentifier(typeIdentifier);
        return stream;

        }


    //public static EarlStream Reader(byte[] bytes) {
    //    }

    //public static EarlStream Factory(
    //    string fileName,
    //    FileMode fileMode,
    //    FileAccess fileAccess,
    //    FileShare fileShare) => new EarlStream(fileName, fileMode, fileAccess, fileShare);


    public static EarlStream Open(
                string fileName,
                byte[] typeIdentifier) {
        try {
            var fileStream = fileName.OpenFileReadWrite();
            var stream = new EarlStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read, fileStream);

            return stream;
            }
        catch (Exception e) {
            throw new NYI();
            }
        }



    /// <summary>Open the file <paramref name="fileName"/> to read as an <see cref="EarlStream"/>.</summary>
    /// <param name="fileName">The file name.</param>
    /// <returns>The <see cref="EarlStream"/> created</returns>
    public static EarlStream OpenRead(
                string fileName) => new(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

    /// <summary>Open the file <paramref name="fileName"/> to write as an <see cref="EarlStream"/>.</summary>
    /// <param name="fileName">The file name.</param>
    /// <returns>The <see cref="EarlStream"/> created</returns>
    public static EarlStream OpenWrite(
            string fileName) => new (fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

    /// <summary>Open the file <paramref name="fileName"/> to read and write as an <see cref="EarlStream"/>.</summary>
    /// <param name="fileName">The file name.</param>
    /// <returns>The <see cref="EarlStream"/> created</returns>
    public static EarlStream OpenReadWrite(
            string fileName) => new (fileName, FileMode.Open, FileAccess.Read, FileShare.Read);


    private FileStream OpenStream() => new (Filename, FileMode, FileAccess, FileShare);


    /// <summary>Close the underlying file stream, is used to save file stream 
    /// handles.</summary>
    public void CloseStream() {
        Stream?.Flush();
        stream?.Close();
        stream = null;
        }

    /// <summary>Move to <paramref name="position"/> in the file.</summary>
    /// <param name="position">The position from the start of the file to move to.</param>
    public void Seek(long position) => Stream.Position = position;

    /// <summary>Move to the end of the file.</summary>
    public void SeekEnd() => Stream.Seek(0,SeekOrigin.End);

    #region -- Read methods

    /// <summary>Read the type identifier from the stream.</summary>
    /// <returns>The type identifier read.</returns>
    public virtual ulong ReadTypeIdentifier() => Stream.ReadTypeIdentifier();

    /// <summary>Read a varint from the stream.</summary>
    /// <returns>The varint read.</returns>
    public virtual ulong ReadVarint() => Stream.ReadVarint();

    /// <summary>Read a block of data from the stream.</summary>
    /// <returns>The data block read.</returns>
    public virtual byte[] ReadBlock() {
        var length = Stream.ReadVarint();
        var buffer = new byte[length];
        Stream.ReadExactly(buffer, 0, (int)length);
        return buffer;
        }

    /// <summary>Read <paramref name="length"/> bytes from the stream and store in
    /// <paramref name="buffer"/>.</summary>
    /// <param name="buffer">The buffer to store the data that was read.</param>
    /// <param name="length">The number of bytes to read.</param>
    /// <returns>The number of bytes read.</returns>
    public virtual long ReadBytes(byte[] buffer, int length) => Stream.Read(buffer, 0, length);

    /// <summary>Read the next block in the stream and return the start position and 
    /// the block read.</summary>
    /// <returns>The start position and the block of data read.</returns>
    public virtual (long,long) ReadBlockLength() {
        var length = Stream.ReadVarint();
        var start = Stream.Position;
        Stream.Position += (long)length;
        return (start,(long)length);
        }

    /// <summary>Return the payload of <paramref name="index"/>.</summary>
    /// <param name="index">The entry index.</param>
    /// <returns>The payload bytes.</returns>
    public byte[]? GetPayload(EarlEntryIndex index) {
        if (index.PayloadLength == 0) {
            return null;
            }
        if (index.EarlEnvelope.Payload is not null) {
            return index.EarlEnvelope.Payload;
            }
        var position = Stream.Position;
        Stream.Position = index.PayloadStart;
        var buffer = new byte[index.PayloadLength];
        Stream.ReadExactly(buffer, 0, (int)index.PayloadLength);
        Stream.Position = position;

        return buffer;
        }

    /// <summary>Read a block of data from the stream, parse as a JSON object
    /// of type <typeparamref name="T"/> and return the result.</summary>
    /// <typeparam name="T">The type of data to return.</typeparam>
    /// <returns>The returned data.</returns>
    public T ReadJson<T>() where T : JsonObject {
        var bytes = ReadBlock();
        var result = JsonObject.StreamParseTag<T>(bytes, false);
        return result;
        }

    /// <summary>
    /// Reads <paramref name="count"/> number of bytes from the current stream and advances the position within the stream.
    /// </summary>
    /// <param name="buffer">
    /// An array of bytes. When this method returns, the buffer contains the specified byte array with the values
    /// between <paramref name="offset"/> and (<paramref name="offset"/> + <paramref name="count"/> - 1) replaced
    /// by the bytes read from the current stream.
    /// </param>
    /// <param name="offset">The byte offset in <paramref name="buffer"/> at which to begin storing the data read from the current stream.</param>
    /// <param name="count">The number of bytes to be read from the current stream.</param>
    /// <exception cref="ArgumentNullException"><paramref name="buffer"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="offset"/> is outside the bounds of <paramref name="buffer"/>.
    /// -or-
    /// <paramref name="count"/> is negative.
    /// -or-
    /// The range specified by the combination of <paramref name="offset"/> and <paramref name="count"/> exceeds the
    /// length of <paramref name="buffer"/>.
    /// </exception>
    /// <exception cref="EndOfStreamException">
    /// The end of the stream is reached before reading <paramref name="count"/> number of bytes.
    /// </exception>
    /// <remarks>
    /// When <paramref name="count"/> is 0 (zero), this read operation will be completed without waiting for available data in the stream.
    /// </remarks>
    public void ReadExactly(byte[] buffer, int offset, int count) =>
        Stream.ReadExactly(buffer, offset, count);


    /// <summary>
    /// Copy <paramref name="length"/> bytes from the stream to
    /// <paramref name="output"/>.
    /// </summary>
    /// <param name="output">The output stream.</param>
    /// <param name="length">Number of bytres to copy.</param>
    public void CopyTo(
                Stream output,
                ulong length) => Stream.CopyTo(output, length);




    /// <summary>
    /// Copy <paramref name="length"/> bytes from the stream to
    /// <paramref name="output"/>, presenting each block of data to the digest
    /// instance <paramref name="digest"/>.
    /// </summary>
    /// <param name="output">The output stream.</param>
    /// <param name="length">Number of bytres to copy.</param>
    /// <param name="digest">The digest algorithm to apply during the copy.</param>
    public void HashCopyTo(
                Stream output,
                ulong length,
                HashAlgorithm digest) => Stream.HashCopyTo(output, length, digest);



    #endregion
    #region -- Write methods
    #region -- Asynchronous write

    /// <summary>Write the data in <paramref name="buffer"/> asynchronously.</summary>
    /// <param name="buffer">The data to write.</param>
    /// <returns>Task</returns>
    public async Task WriteAsync(byte[] buffer) => await Stream.WriteAsync(buffer);

    /// <summary>Write the data in <paramref name="jsonObject"/> asynchronously.</summary>
    /// <param name="jsonObject">The data to write.</param>
    /// <returns>Task</returns>
    public async Task WriteAsync(JsonObject jsonObject) {
        if (jsonObject is null) {
            await WriteBytesAsync(null);
            return;
            }

        var bytes = jsonObject.GetBytes(false);
        await WriteBytesAsync(bytes);
        }

    /// <summary>Write the data in <paramref name="data"/> asynchronously.</summary>
    /// <param name="data">The data to write.</param>
    /// <returns>Task</returns>
    public async Task WriteBytesAsync(
            byte[]? data) {

        if (data is null) {
            await WriteAsync([0]);
            }
        else if (data.Length == 0) {
            // ignore attempts to write zero length data segments.
            }
        else {
            await Stream.WriteVarintAsync(data.Length);
            await WriteAsync(data);
            }
        }

    /// <summary>Flush the stream write.</summary>
    /// <returns>Task</returns>
    public async Task FlushAsync() => await Stream.FlushAsync();

    #endregion
    #region -- Synchronous write

    /// <summary>Write a type identifier to the stream.</summary>
    /// <param name="bytes">The type identifier bytes.</param>
    public virtual void WriteTypeIdentifier(byte[] bytes) => Stream.Write(bytes);

    /// <summary>Write a varint to the stream</summary>
    /// <param name="data">The varint to write.</param>
    public virtual void WriteVarint(long data) => Stream.WriteVarint(data);


    /// <summary>Write binary data to the stream.</summary>
    /// <param name="buffer">The data to write.</param>
    public void Write(byte[] buffer) => Stream.Write(buffer, 0, buffer.Length);

    /// <summary>Write a JSON object to the stream.</summary>
    /// <param name="jsonObject">The data to write.</param>
    public virtual void Write(JsonObject jsonObject) {
        if (jsonObject is null) {
            WriteBytes(null);
            return;
            }

        var bytes = jsonObject.GetBytes(false);
        WriteBytes(bytes);
        }

    /// <summary>Write a byte array to the stream.</summary>
    /// <param name="data">The data to write.</param>
    public virtual void WriteBytes(
            byte[]? data) {

        if (data is null) {
            Stream.Write([0]);
            }
        else if (data.Length == 0) {
            Stream.Write([0]);
            }
        else {
            WriteVarint(data.Length);
            Write(data);
            }

        }

    /// <summary>Write the payload byte array to the stream.</summary>
    /// <param name="data">The data to write.</param>
    public virtual void WritePayloadBytes(
            byte[]? data) {

        if (data is not null && data.Length >0){
            WriteBytes(data);
            }

        }


    /// <summary>Append data from <paramref name="entry"/> to the stream as frame 
    /// number <paramref name="frame"/></summary>
    /// <param name="entry">The data to write.</param>
    /// <param name="frame">The frame number.</param>
    /// <returns>The entry index.</returns>
    public EarlEntryIndex Append(
            EarlEnvelope entry, 
            long? frame) {

        var unprotected = Copy(entry.UnsignedHeader);
        unprotected.Frame = frame;

        return Append(unprotected, entry.SignedHeader, entry.Payload, entry.Trailer);
        }


    static Unprotected Copy(Unprotected? obj) => obj is null ? new() : new() {
        DigestAlgorithm = obj.DigestAlgorithm,
        Signers = obj.Signers,
        Signatures = obj.Signatures
        };

    /// <summary>Append the frame consisting of <paramref name="unprotected"/>,
    /// <paramref name="contentMeta"/>, <paramref name="obj"/>, <paramref name="trailer"/>
    /// to the stream.</summary>
    /// <param name="unprotected">The unprotected header.</param>
    /// <param name="contentMeta">The content metadata</param>
    /// <param name="obj">The payload.</param>
    /// <param name="trailer">The trailer.</param>
    /// <returns>The entry index.</returns>
    public EarlEntryIndex Append(
        Unprotected unprotected,
        ContentMeta contentMeta,
            JsonObject obj,
        Unprotected trailer) {

        var payloadBytes = obj?.GetBytes(false);
        return Append(unprotected, contentMeta, payloadBytes, trailer);
        }

    /// <summary>Append the frame consisting of <paramref name="unprotected"/>,
    /// <paramref name="contentMeta"/>, <paramref name="payloadBytes"/>, <paramref name="trailer"/>
    /// to the stream.</summary>
    /// <param name="unprotected">The unprotected header.</param>
    /// <param name="contentMeta">The content metadata</param>
    /// <param name="payloadBytes">The payload.</param>
    /// <param name="trailer">The trailer.</param>
    /// <returns>The entry index.</returns>
    public EarlEntryIndex Append(
            Unprotected unprotected,
            ContentMeta contentMeta,
            byte[] payloadBytes,
            Unprotected trailer) {

        var payloadBytesLength = payloadBytes == null ? 0 : payloadBytes.Length;

        var trailerBytes = trailer?.GetBytes(false);
        var trailerBytesLength = trailerBytes == null ? 0 : trailerBytes.Length;

        var index = AppendEntryStart(payloadBytesLength, unprotected, contentMeta,
           trailerBytesLength);

        AppendEntryPayload(payloadBytes, 0, payloadBytes.Length);
        AppendEntryEnd(trailerBytes);

        return index;

        }

    long frameLength;
    long payloadLength;
    int trailerLength;
    long entryStart;

    /// <summary>Start to append an entry of <paramref name="payloadLengthIn"/> payload bytes
    /// and <paramref name="trailerLengthIn"/> trailer bytes. </summary>
    /// <param name="payloadLengthIn">Length of the payload in bytes.</param>
    /// <param name="unprotected">The unprotected header.</param>
    /// <param name="contentMeta">The content metadata.</param>
    /// <param name="trailerLengthIn">Length of the trailer in bytes.</param>
    /// <returns>0, position of first byte of the frame, total length, position of 
    /// the first byte of the content.</returns>

    public (long, long, long, long) AppendEntryStartInner (

            long payloadLengthIn,
            Unprotected unprotected,
            ContentMeta contentMeta,
            int trailerLengthIn) {

        var unprotectedBytes = unprotected?.GetBytes(false);
        var contentMetaBytes = contentMeta?.GetBytes(false);
        payloadLength = payloadLengthIn;
        trailerLength = trailerLengthIn;

        frameLength = unprotectedBytes.TaggedLength() + contentMetaBytes.TaggedLength() +
            payloadLength + Extensions.TagLength(payloadLength) +
            trailerLength + Extensions.TagLength(trailerLength);

        entryStart = Stream.Seek(0, SeekOrigin.End);

        WriteVarint(frameLength);
        WriteBytes(unprotectedBytes);
        WriteBytes(contentMetaBytes);
        WriteVarint(payloadLength);
        var payloadStart = Stream.Position;

        var length = frameLength + 2 * (Extensions.TagLength(frameLength));

        return (0, entryStart, length, payloadStart);
        }


    /// <summary>Start to append an entry of <paramref name="payloadLengthIn"/> payload bytes
    /// and <paramref name="trailerLengthIn"/> trailer bytes. </summary>
    /// <param name="payloadLengthIn">Length of the payload in bytes.</param>
    /// <param name="unprotected">The unprotected header.</param>
    /// <param name="contentMeta">The content metadata.</param>
    /// <param name="trailerLengthIn">Length of the trailer in bytes.</param>
    /// <returns>Entry index.</returns>
    public EarlEntryIndex AppendEntryStart(
                long payloadLengthIn,
                Unprotected unprotected,
                ContentMeta contentMeta,
                int trailerLengthIn) {


        var (_, entryStart, length, payloadStart) =
            AppendEntryStartInner(payloadLengthIn, unprotected, contentMeta, trailerLengthIn);

        return new EarlEntryIndex(
                0, entryStart, length, payloadStart, payloadLength);
        }

    /// <summary>Append the payload after beginning a frame with <see cref="AppendEntryStart"/>
    /// or <see cref="AppendEntryStartInner"/>.</summary>
    /// <param name="data">The data to append.</param>
    /// <param name="offset">Offset within the data.</param>
    /// <param name="length">Number of bytes to append.</param>
    public void AppendEntryPayload(
                byte[] data, int offset, int length) {
        payloadLength -= length;
        (payloadLength >= 0).AssertTrue(NYI.Throw);

        Stream.Write(data, offset, length);
        }


    /// <summary>Append the trailer after beginning a frame with AppendEntryStart.</summary>
    /// <param name="trailerBytes">The trailer to append.</param>
    public void AppendEntryEnd(
            byte[] trailerBytes) {

        // Check we have writen all the bytes.
        (payloadLength == 0).AssertTrue(NYI.Throw);


        var trailerBytesLength = trailerBytes == null ? 0 : trailerBytes.Length;
        (trailerBytesLength == trailerLength).AssertTrue(NYI.Throw);

        WriteBytes(trailerBytes);
        Stream.WriteTnirav(frameLength);
        var length = frameLength + 2 * (Extensions.TagLength(frameLength));

        (Stream.Position == entryStart + length).AssertTrue(NYI.Throw);
        Stream.Flush();
        }

    /// <summary>Read the index information for the next frame in the field.</summary>
    /// <returns>The index record.</returns>
    public EarlEntryIndex? ReadIndexNext() {
        if (EOF) {
            return null;
            }

        var start = Stream.Position;

        var length = Stream.ReadVarint(out var codeLength);
        var unprotected = ReadJson<Unprotected>();
        var contentMeta = ReadJson<ContentMeta>();
        var (payloadStart, payloadLength) = ReadBlockLength();
        var trailer = ReadJson<Unprotected>();
        var framelength = Stream.ReadTnirav(codeLength);

        (length == framelength).AssertTrue(NYI.Throw);  

        //var end = Stream.Position - start;
        var frame = -1;


        var envelope = new EarlEnvelope(unprotected, contentMeta, trailer);

        return new EarlEntryIndex(frame, start, (long)framelength, payloadStart, payloadLength) {
            EarlEnvelope = envelope,
            Id = contentMeta?.UniqueId
            };
        }

    /// <summary>Read the index information for the previous frame in the field.</summary>
    /// <returns>The index record.</returns>
    public EarlEntryIndex? ReadIndexPrevious(long last = 0) {
        if (Stream.Position <= last) {
            return null;
            }


        var length = (long)Stream.ReadTnirav(out var codeLength);
        Stream.Seek(-(length + codeLength), SeekOrigin.Current);
        var position = Stream.Position;
        var result = ReadIndexNext();
        Stream.Position = position;

        return result;
        }

    /// <summary>Read the index information for the next frame in the field.</summary>
    /// <typeparam name="T">The type of the underlying data.</typeparam>
    /// <returns>The index record.</returns>
    public EarlEntryIndex<T>? ReadIndexNext<T>() where T : JsonObject {
        if (EOF) {
            return null;
            }

        var start = Stream.Position;



        var length = Stream.ReadVarint(out var codeLength);
        var unprotected = ReadJson<Unprotected>();
        var contentMeta = ReadJson<ContentMeta>();
        var (payloadStart, payloadLength) = ReadBlockLength();
        var trailer = ReadJson<Unprotected>();
        var framelength = Stream.ReadTnirav(codeLength);

        (length == framelength).AssertTrue(NYI.Throw);


        var frame = -1;


        var envelope = new EarlEnvelope(unprotected, contentMeta, trailer);

        return new EarlEntryIndex<T>(frame, start, (long)framelength, payloadStart, payloadLength) {
            EarlEnvelope = envelope,
            Id = contentMeta?.UniqueId
            };
        }

    /// <summary>Read the index information for the previous frame in the field.</summary>
    /// <typeparam name="T">The type of the underlying data.</typeparam>
    /// <returns>The index record.</returns>
    public EarlEntryIndex<T>? ReadIndexPrevious<T>(long last=0) where T : JsonObject {
        if (Stream.Position <= last) {
            return null;
            }


        var length = (long)Stream.ReadTnirav(out var codeLength);
        Stream.Seek(-(length+codeLength), SeekOrigin.Current);
        var position = Stream.Position;
        var result = ReadIndexNext<T>();
        Stream.Position = position;

        return result;
        }



    /// <summary>Read the next frame.</summary>
    /// <returns>The frame data read.</returns>
    public EarlEnvelope ReadFrameNext() {
        var length = Stream.ReadVarint(out var codeLength);
        return ReadFrame(codeLength, length);
        }

    /// <summary>Read the previous frame.</summary>
    /// <returns>The frame data read.</returns>
    public EarlEnvelope ReadFramePrev() {
        var length = Stream.ReadTnirav(out var codeLength);
        Stream.Seek(-(long)length, SeekOrigin.Current);
        return ReadFrame(codeLength, length);
        }


    EarlEnvelope ReadFrame(int codeLength, ulong lengthIn) {
        var unprotected = ReadJson<Unprotected>();
        var contentMeta = ReadJson<ContentMeta>();
        var payload = ReadBlock();
        var trailer = ReadJson<Unprotected>();
        var length = Stream.ReadTnirav(codeLength);

        (length == lengthIn).AssertTrue(NYI.Throw);

        return new EarlEnvelope(unprotected, contentMeta, trailer, payload);
        }



    /// <summary>Read the last frame.</summary>
    /// <returns>The frame data read.</returns>
    public EarlEnvelope ReadFrameLast() {
        Stream.Seek(0, SeekOrigin.End);
        return ReadFramePrev();
        }


    /// <summary>Flush writes to the stream.</summary>
    public void Flush() => Stream.Flush();

    #endregion
    #endregion
    }
