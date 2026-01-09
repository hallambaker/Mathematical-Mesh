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

public class EarlStream : Disposable {

    protected Stream Stream {
        get => stream ?? OpenStream().CacheValue(out stream);
        set => stream = value;
        }

    Stream? stream = null;

    public bool EOF => Stream.Position >= Stream.Length;


    public long Position {
        get => Stream.Position;
        set => Stream.Position = value;
        }



    FileMode FileMode { get; }
    FileAccess FileAccess { get; }

    FileShare FileShare { get; }
    public string Filename { get; }

    protected override void Disposing() {
        CloseStream();
        base.Disposing();
        }


    public EarlStream(Stream stream) {
        Stream = stream;
        }

    public EarlStream(byte[] data) {
        stream = new MemoryStream(data);
        }


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

    //public static EarlStream Reader(byte[] bytes) {
    //    }

    //public static EarlStream Factory(
    //    string fileName,
    //    FileMode fileMode,
    //    FileAccess fileAccess,
    //    FileShare fileShare) => new EarlStream(fileName, fileMode, fileAccess, fileShare);




    public static EarlStream Create(
                string fileName,
                byte[] typeIdentifier) {
        var fileStream = fileName.OpenFileNew();

        var stream = new EarlStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read, fileStream);
        stream.WriteTypeIdentifier(typeIdentifier);
        return stream;

        }


    public static EarlStream OpenRead(
                string fileName) => new EarlStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
    public static EarlStream OpenWrite(
            string fileName) => new EarlStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

    public static EarlStream OpenReadWrite(
            string fileName) => new EarlStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

    private Stream OpenStream() => new FileStream(Filename, FileMode, FileAccess, FileShare);


    /// <summary>Close the underlying file stream, is used to save file stream 
    /// handles.</summary>
    public void CloseStream() {
        Stream?.Flush();
        stream?.Close();
        stream = null;
        }


    public void Seek(long position) => Stream.Position = position;
    public void SeekEnd() => Stream.Seek(0,SeekOrigin.End);

    #region -- Read methods

    public virtual ulong ReadTypeIdentifier() => Stream.ReadTypeIdentifier();

    public virtual ulong ReadVarint() => Stream.ReadVarint();


    public virtual byte[] ReadBlock() {
        var length = Stream.ReadVarint();
        var buffer = new byte[length];
        Stream.ReadExactly(buffer, 0, (int)length);
        return buffer;
        }


    public virtual long ReadBytes(byte[] buffer, int length) => Stream.Read(buffer, 0, length);

    public virtual (long,long) ReadBlockLength() {
        var length = Stream.ReadVarint();
        var start = Stream.Position;
        Stream.Position += (long)length;
        return (start,(long)length);
        }

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
    public async Task WriteAsync(byte[] buffer) => await Stream.WriteAsync(buffer, 0, buffer.Length);

    public async Task WriteAsync(JsonObject jsonObject) {
        if (jsonObject is null) {
            WriteBytesAsync(null);
            return;
            }

        var bytes = jsonObject.GetBytes(false);
        WriteBytesAsync(bytes);
        }

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

    public async Task FlushAsync() => Stream.FlushAsync();

    #endregion
    #region -- Synchronous write

    public virtual void WriteTypeIdentifier(byte[] bytes) => Stream.Write(bytes);

    public virtual void WriteVarint(long data) => Stream.WriteVarint(data);



    public void Write(byte[] buffer) => Stream.Write(buffer, 0, buffer.Length);

    public virtual void Write(JsonObject jsonObject) {
        if (jsonObject is null) {
            WriteBytes(null);
            return;
            }

        var bytes = jsonObject.GetBytes(false);
        WriteBytes(bytes);
        }

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


    public virtual void WritePayloadBytes(
            byte[]? data) {

        if (data is not null && data.Length >0){
            WriteBytes(data);
            }

        }



    public EarlEntryIndex Append(
            EarlEnvelope entry, 
            long? frame) {

        var unprotected =  Copy(entry.UnsignedHeader);
        unprotected.Frame = frame;

        return Append(unprotected, entry.SignedHeader, entry.Payload, entry.Trailer);
        }

    Unprotected Copy(Unprotected? obj) => obj is null ? new() : new() {
        DigestAlgorithm = obj.DigestAlgorithm,
        Signers = obj.Signers,
        Signatures = obj.Signatures
        };


    public EarlEntryIndex Append(
        Unprotected unprotected,
        ContentMeta contentMeta,
            JsonObject obj,
        Unprotected trailer) {

        var payloadBytes = obj?.GetBytes(false);
        return Append(unprotected, contentMeta, payloadBytes, trailer);
        }

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

    public EarlEntryIndex AppendEntryStart(
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


        return new EarlEntryIndex(
                0, entryStart, length, payloadStart, payloadLength, null);
        }


    public void AppendEntryPayload(
                byte[] data, int offset, int length) {
        payloadLength -= length;
        (payloadLength >= 0).AssertTrue(NYI.Throw);

        Stream.Write(data, offset, length);
        }

    public void AppendEntryEnd(
        Unprotected trailer) {

        var trailerBytes = trailer?.GetBytes(false);
        AppendEntryEnd(trailerBytes);
        }



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

        }

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
        var Framelength = (long)Stream.ReadTnirav(codeLength);

        var end = Stream.Position -start;

        var frame = -1;


        var envelope = new EarlEnvelope(unprotected, contentMeta, trailer);

        return new EarlEntryIndex(frame, start, Framelength, payloadStart, payloadLength, "") {
            EarlEnvelope = envelope
            };
        }

    public EarlEntryIndex? ReadIndexPrevious(long last=0) {
        if (Stream.Position <= last) {
            return null;
            }


        var length = (long)Stream.ReadTnirav(out var codeLength);
        Stream.Seek(-(length+codeLength), SeekOrigin.Current);
        var position = Stream.Position;
        var result = ReadIndexNext();
        Stream.Position = position;

        return result;
        }




    public EarlEnvelope ReadFrameNext() {
        var length = Stream.ReadVarint(out var codeLength);
        return ReadFrame(codeLength);
        }

    EarlEnvelope ReadFrame(int codeLength) {
        var unprotected = ReadJson<Unprotected>();
        var contentMeta = ReadJson<ContentMeta>();
        var payload = ReadBlock();
        var trailer = ReadJson<Unprotected>();
        var length = (long)Stream.ReadTnirav(codeLength);

        return new EarlEnvelope(unprotected, contentMeta, trailer, payload);
        }


    public EarlEnvelope ReadFramePrev() {
        var length = (long)Stream.ReadTnirav(out var codeLength);
        Stream.Seek(-length, SeekOrigin.Current);
        return ReadFrame(codeLength);
        }

    public EarlEnvelope ReadFrameLast() {
        Stream.Seek(0, SeekOrigin.End);
        return ReadFramePrev();
        }



    public void Flush() => Stream.Flush();

    #endregion
    #endregion
    }

public class EarlStreamDebug : EarlStream {


    EarlStreamDebug(
            string fileName,
            FileMode fileMode,
            FileAccess fileAccess,
            FileShare fileShare,
                Stream stream = null) : base(fileName, fileMode, fileAccess, fileShare, stream) {
        int data = Stream.ReadByte();
        int count = 0;
        while (data >= 0) {

            Console.Write($"{data} ");

            if ((++count % 16) == 0) {
                Console.WriteLine();
                }
            data = Stream.ReadByte();
            }
        if ((count % 16) != 0) {
            Console.WriteLine();
            }

        Stream.Seek(0, SeekOrigin.Begin);

        }

    //public new static EarlStream Factory(
    //        string fileName,
    //        FileMode fileMode,
    //        FileAccess fileAccess,
    //        FileShare fileShare) => new EarlStreamDebug(fileName, fileMode, fileAccess, fileShare);


    public static EarlStream Create(
            string fileName,
            byte[] typeIdentifier) {

        var fileStream = fileName.OpenFileNewRW();

        var stream = new EarlStreamDebug(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read, fileStream);
        stream.WriteTypeIdentifier(typeIdentifier);

        return stream;
        }


    public static EarlStream OpenRead(
                string fileName) => new EarlStreamDebug(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
    public static EarlStream OpenWrite(
            string fileName) => new EarlStreamDebug(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

    public static EarlStream OpenReadWrite(
            string fileName) => new EarlStreamDebug(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);



    public virtual ulong ReadVarint() {
        var length = Stream.ReadVarint();
        Console.WriteLine($"ReadVarint: {length}");
        return length;
        }


    public virtual byte[] ReadBlock() {
        var length = Stream.ReadVarint();
        var buffer = new byte[length];
        Stream.ReadExactly(buffer, 0, (int)length);


        Console.WriteLine($"ReadBlock: {length}");
        return buffer;


        }


    void Dump(byte[] bytes) {
        foreach (var b in bytes) {
            Console.Write($"{b} ");
            }

        }

    public override void WriteTypeIdentifier(byte[] bytes) {
        Dump(bytes);
        Stream.Write(bytes);
        }

    public override void WriteVarint(long data) => Stream.WriteVarint(data);



    }