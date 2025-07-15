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


// This file has the methods that operate on the stream
public partial class JbcdStream  {

    #region // Constants

    /// <summary>Basic envelope, just metadata and content</summary>
    public const byte EnvelopeType0     = 0;
    /// <summary>Signed envelope with unauthenticated header and trailer.</summary>
    public const byte EnvelopeType1     = 1;
    /// <summary>Sequence with JSON metadata.</summary>
    public const byte SequenceTypeJson  = 0x10;

    /// <summary>JSON-B Code for unidirectional frame</summary>
    public const byte UFrame = 0xF0;
    /// <summary>JSON-B Code for bidirectional frame</summary>
    public const byte BFrame = 0xF4;

    /// <summary>JSON-B Code for 8 bit length</summary>
    public const byte Length8 = 0x00;
    /// <summary>JSON-B Code for 16 bit length</summary>
    public const byte Length16 = 0x01;
    /// <summary>JSON-B Code for 32 bit length</summary>
    public const byte Length32 = 0x02;
    /// <summary>JSON-B Code for 64 bit length</summary>
    public const byte Length64 = 0x03;

    /// <summary>JSON-B Length mask </summary>
    public const byte LengthMask = 0x03;
    /// <summary>JSON-B Type mask </summary>
    public const byte TypeMask = 0xFC;

    readonly static byte[] CodeSpaces = new byte[] { 2, 3, 5, 9, 4, 6, 10, 18 };
    readonly static byte[] TagSpaces = new byte[] { 1, 2, 4, 8 };


    public bool IsVersion4 => Version == 4;


    #endregion

    #region // All the parts that depend on the framing bytes

    /// <summary>
    /// Return the shortest tag length for the specified production.
    /// </summary>
    /// <param name="length">Length of data to follow.</param>
    /// <returns>The tag length.</returns>
    int TagLength(long length) {
        if (IsVersion4) {
            return Extensions.TagLength(length);
            }
        else {
            if (length < 0x100) {
                return 2;
                }
            if (length < 0x10000) {
                return 3;
                }
            if (length < 0x100000000) {
                return 5;
                }
            return 9;
            }
        }
    /// <summary>
    /// Return the length of a code
    /// </summary>
    /// <param name="code">Base code.</param>
    /// <returns>The number of bytes required.</returns>
    static int TagSpace(int code) => TagSpaces[code & LengthMask];


    /// <summary>
    /// Return the length of a code
    /// </summary>
    /// <param name="code">Base code.</param>
    /// <returns>The number of bytes required.</returns>
    static int CodeSpace(int code) {
        Assert.AssertTrue(code >= UFrame & code <= (BFrame + Length64),
            StreamDataCorrupt.Throw);

        return CodeSpaces[code - UFrame];

        }

    /// <summary>
    /// Read the start length tag of a frame
    /// </summary>
    /// <param name="length">The frame length</param>
    /// <param name="tagLength">The total length of the frame tags, start and end.</param>
    /// <returns>Returns <c>true</c> if successful, otherwise <c>false</c> .</returns>
    public virtual bool ReadTagStartFrame(out long length, out int tagLength) {
        if (IsVersion4 & PositionRead == 0) {
            
            //var firstByte = ReadByte();
            //Version = firstByte == SequenceTypeJson ? 4 : 3;
            //if (!IsVersion4) {
            //    Begin();
            //    }
            }
        if (IsVersion4) {
            length = (long) StreamRead.ReadVarint(out tagLength);
            //tagLength = PositionRead == 1tagLength << 1 : tagLength << 1;

            tagLength <<= 1; // report start AND end tag lengths
            return true;
            }
        else {
            var success = ReadTag(out var code, out length);
            tagLength = CodeSpace(code);
            return true;
            }
        }


    /// <summary>
    /// Read the end length tag of a frame.
    /// </summary>
    /// <param name="length">The frame length given at its start.</param>
    /// <returns>Returns <c>true</c> if successful, otherwise <c>false</c> .</returns>
    /// <param name="tagLength"></param>
    public virtual bool ReadTagEndFrame(long length, int tagLength) {
        if (IsVersion4) {
            var endlength = (long)StreamRead.ReadTnirav(tagLength>>1);
            //endlength <<= 1; // check start AND end tag lengths
            //(length== endlength).AssertTrue(NYI.Throw);
            return true;
            }
        else {
            return CheckReversedLength(BFrame, length);
            }
        }

    /// <summary>
    /// Read the end length tag of the previous frame.
    /// </summary>
    /// <param name="length">The frame length given at its start.</param>
    /// <returns>Returns <c>true</c> if successful, otherwise <c>false</c> .</returns>
    /// <param name="tagLength">Combined length of the start and end tags.</param>
    public virtual bool ReadTagFrameReversed(out long length, out int tagLength) {
        if (IsVersion4) {
            length = (long)StreamRead.ReadTnirav(out tagLength);
            tagLength <<= 1;
            return true;
            }
        else {
            var success = ReadTagReverse(out var code, out length);
            tagLength = CodeSpace(code);
            return success;
            }
        }



    /// <summary>
    /// Read the length tag of a record.
    /// </summary>
    /// <param name="length">The record length.</param>
    /// <param name="codelength">The number of bytes taken up by the tag.</param>
    /// <returns>Returns <c>true</c> if successful, otherwise <c>false</c> .</returns>
    public virtual bool ReadTagStartRecord(out long length, out int codelength) {
        if (IsVersion4) {
            length = (long)StreamRead.ReadVarint(out codelength);
            return true;
            }
        else {
            var success = ReadTag(out var code, out length);
            codelength = CodeSpace(code);
            return success;
            }
        }


    /// <summary>
    /// Write the first tag in a frame, if the file write pointer is at BOF,
    /// and we have a version 4 sequence, write the file version type marker.
    /// </summary>
    /// <param name="Length">The length of the frame.</param>
    public virtual void WriteTagStartFrame(long Length) {
        if (IsVersion4) {
            if (StreamWrite.Position == 0) {
                StreamWrite.WriteByte (SequenceTypeJson);
                }
            //Console.WriteLine($"{StreamWrite.Position}: Start frame {Length}");
            StreamWrite.WriteVarint (Length);
            }
        else {
            WriteTag(BFrame, Length);
            }
        }

    /// <summary>
    /// Write a record to the frame, the length of the record MUST NOT cause it to 
    /// exceed the boundary of the enclosing frame.
    /// </summary>
    /// <param name="Length"></param>
    public virtual void WriteTagStartRecord(long Length) {
        if (IsVersion4) {
            //Console.WriteLine($"{StreamWrite.Position}: Start record {Length}");
            StreamWrite.WriteVarint(Length);

            //throw new NYI();
            }
        else {
            WriteTag(UFrame, Length);
            }
        }

    /// <summary>
    /// Write the end tag to a frame.
    /// </summary>
    /// <param name="Length">The length specified at the frame start, this MUST 
    /// match.</param>
    public virtual void WriteTagEndFrame(long Length) {
        if (IsVersion4) {
            //Console.WriteLine($"{StreamWrite.Position}: End frame {Length}");
            StreamWrite.WriteTnirav(Length);
            //throw new NYI();
            }
        else {
            WriteTagReverse(BFrame, Length);
            }
        }



    #endregion
    #region  // Static methods 

    /// <summary>
    /// Determine Tag length tol encode the array <paramref name="data"/> using the 
    /// shortest possible production encoding a null array as if zero length.
    /// </summary>
    /// <param name="data">Array giving length of data to follow.</param>
    /// <returns>The number of bytes required.</returns>
    long TotalLength(byte[]? data) => data is null ? TagLength (0) :
        data.Length + TagLength(data.Length);

    /// <summary>
    /// Determine Tag length using the shortest possible production
    /// </summary>
    /// <param name="length">Length of data to follow.</param>
    /// <returns>The number of bytes required.</returns>
    long TotalLength(long length) => length + TagLength(length);

    /// <summary>
    /// Determine Tag length using the shortest possible production
    /// </summary>
    /// <param name="length">Length of data to follow.</param>
    /// /// <returns>The number of bytes required.</returns>
    long TotalLength2(long length) => length + 2 * TagLength(length);


    #endregion
    #region  // Write methods

    /// <summary>
    /// Write out a Tag-Length value using the shortest possible production
    /// </summary>
    /// <param name="code">Base code.</param>
    /// <param name="length">Length of data to follow.</param>
    public void WriteTag(byte code, long length) {
        //Console.WriteLine($"Forward {Code} {Length}");


        if (length < 0x100) {
            WriteByte((byte)(code + Length8));
            WriteByte((byte)(length & 0xff));
            }
        else if (length < 0x10000) {
            WriteByte((byte)(code + Length16));
            WriteByte((byte)((length >> 8) & 0xff));
            WriteByte((byte)(length & 0xff));
            }
        else if (length < 0x100000000) {
            WriteByte((byte)(code + Length32));
            WriteByte((byte)((length >> 24) & 0xff));
            WriteByte((byte)((length >> 16) & 0xff));
            WriteByte((byte)((length >> 8) & 0xff));
            WriteByte((byte)(length & 0xff));
            }
        else {
            WriteByte((byte)(code + Length64));
            WriteByte((byte)((length >> 56) & 0xff));
            WriteByte((byte)((length >> 48) & 0xff));
            WriteByte((byte)((length >> 40) & 0xff));
            WriteByte((byte)((length >> 32) & 0xff));
            WriteByte((byte)((length >> 24) & 0xff));
            WriteByte((byte)((length >> 16) & 0xff));
            WriteByte((byte)((length >> 8) & 0xff));
            WriteByte((byte)(length & 0xff));
            }
        }

    /// <summary>
    /// Write out a Tag-Length value using the shortest possible production
    /// </summary>
    /// <param name="code">Base code.</param>
    /// <param name="length">Length of data to follow.</param>
    public void WriteTagReverse(byte code, long length) {
        //Console.WriteLine($"Reverse {Code} {Length}");


        if (length < 0x100) {
            WriteByte((byte)(length & 0xff));
            WriteByte((byte)(code + Length8));
            }
        else if (length < 0x10000) {
            WriteByte((byte)(length & 0xff));
            WriteByte((byte)((length >> 8) & 0xff));
            WriteByte((byte)(code + Length16));
            }
        else if (length < 0x100000000) {
            WriteByte((byte)(length & 0xff));
            WriteByte((byte)((length >> 8) & 0xff));
            WriteByte((byte)((length >> 16) & 0xff));
            WriteByte((byte)((length >> 24) & 0xff));
            WriteByte((byte)(code + Length32));
            }
        else {
            WriteByte((byte)(length & 0xff));
            WriteByte((byte)((length >> 8) & 0xff));
            WriteByte((byte)((length >> 16) & 0xff));
            WriteByte((byte)((length >> 24) & 0xff));
            WriteByte((byte)((length >> 32) & 0xff));
            WriteByte((byte)((length >> 40) & 0xff));
            WriteByte((byte)((length >> 48) & 0xff));
            WriteByte((byte)((length >> 56) & 0xff));
            WriteByte((byte)(code + Length64));
            }

        //Console.WriteLine($"Reverse {Code} {Length} --- {PositionWrite}");
        }


    #endregion
    #region // Write Frame Methods
    /// <summary>
    /// Write a unidirectional or bidirectional frame to the current stream at the current write position. 
    /// The code does not currently support 64 bit frames as it should.
    /// </summary>
    /// <param name="frameData">The data to write.</param>
    /// <param name="offset">Offset within the data.</param>
    /// <param name="length">Number of bytes to write.</param>
    /// <returns>The total size of the frame.</returns>
    public long WriteRecord(
                byte[]? frameData,
                long offset = 0, 
                long length = -1) {
        if (frameData == null) {
            WriteTagStartRecord(0);
            return 0;
            }

        length = length == -1 ? frameData.LongLength : length;
        Assert.AssertTrue(length <= Int32.MaxValue, FrameTooLargeException.Throw);

        WriteTagStartRecord(length);
        Write(frameData, (int)offset, (int)length);

        return TotalLength(length);
        }



    /// <summary>
    /// Write a wrapped frame containing a header and an optional data section
    /// to the current stream at the current write position. 
    /// The code does not currently support 64 bit frames as it should.
    /// </summary>
    /// <param name="frameHeader">The header data to write.</param>
    /// <param name="frameData1">First data record, contains data content.</param>
    /// <param name="frameData2">Second data record, contains protected metadata.</param>
    /// <param name="flush">If true, flush the frame data value to the file.</param>
    /// <returns>The total size of the frame.</returns>
    public long WriteWrappedFrame(
                byte[] frameHeader,
                byte[] frameData1 = null,
                byte[] frameData2 = null,
                bool flush = true) {

        bool lockTaken = false;

        try {

            if (LockGlobal != null) {
                Monitor.Enter(LockGlobal, ref lockTaken);
                LockGlobal.Enter();
                }

            
            var frameLength = TotalLength(frameHeader) +
                               TotalLength(frameData1) +
                               TotalLength(frameData2);

            WriteTagStartFrame(frameLength);

            var check = PositionWrite;
            if (frameHeader != null) {
                WriteRecord(frameHeader);
                }
            else {
                WriteTagStartRecord(0);
                }

            var result = PositionWrite;

            if (frameData1 != null) {

                result += TagLength(frameData1.LongLength);

                WriteRecord(frameData1);
                }
            else {
                WriteTagStartRecord(0);
                }
            if (frameData2 != null) {
                WriteRecord(frameData2);
                }
            else {
                WriteTagStartRecord(0);
                }

            Assert.AssertTrue(PositionWrite == check + frameLength, Internal.Throw);

            WriteTagEndFrame(frameLength);

            if (flush) {
                StreamWrite.Flush();
                }

            return result;
            }

        catch (Exception exception) {
            exception.Future();
            throw;
            }
        finally {
            LockGlobal?.Exit();
            if (lockTaken) {
                Monitor.Exit(LockGlobal);
                }
            }
        }


    long frameLength;
    long check;
    long hl;
    long dl;
    long tl;
    /// <summary>
    /// Write a wrapped frame containing a header and an optional data section
    /// to the current stream at the current write position. 
    /// The code does not currently support 64 bit frames as it should.
    /// </summary>
    /// <param name="frameHeader">The header data to write.</param>
    /// <param name="frameDataLength">Length of the frame payload.</param>
    /// <param name="frameTrailerLength">Length of the frame trailer.</param>
    /// <returns>The total size of the frame.</returns>
    public (long, long) WriteWrappedFrameBegin(
                byte[] frameHeader,
                long frameDataLength,
                long frameTrailerLength) {
        (frameDataLength >= 0 &frameTrailerLength >= 0).AssertTrue(Internal.Throw);


        hl = TotalLength(frameHeader);
        dl = TotalLength(frameDataLength);
        tl = TotalLength(frameTrailerLength);

        frameLength = hl + dl + tl;

        WriteTagStartFrame(frameLength);

        check = PositionWrite;
        if (frameHeader != null) {
            WriteRecord(frameHeader);
            }

        Assert.AssertTrue(PositionWrite == check + hl, Internal.Throw);

        // here write out the binary marker for the frame data.
        WriteTagStartRecord(frameDataLength);
        var dataPosition = PositionWrite;

        return (TotalLength2(frameLength), dataPosition);
        }

    /// <summary>
    /// Complete writing out a wrapped frame. The frame must previously be started
    /// using a matching call to WriteWrappedFrameBegin. If the content written 
    /// does not match the length originally specified, an error is thrown.
    /// </summary>
    /// <returns>The total size of the frame.</returns>
    public long WriteWrappedFrameEnd(
                byte[] frameTrailer = null) {


        Assert.AssertTrue(PositionWrite == check + hl + dl, Internal.Throw);

        WriteRecord(frameTrailer);

        check += frameLength;
        Assert.AssertTrue(PositionWrite == check, Internal.Throw);
        // Note, if this check fails, check to see if the trailer length is being calculated correctly.
        // Missing or incorrect dummy trailers will cause this check to fail as will incorrect calculation
        // of the payload length.

        WriteTagEndFrame(frameLength);
        StreamWrite.Flush(); // Force output of data

        return TotalLength2(frameLength);
        }

    #endregion

    #region // Read methods

    /// <summary>
    /// Read a length value of known length in the forward direction.
    /// </summary>
    /// <param name="lengthLength">The number of bytes to read.</param>
    /// <param name="length">The length value read.</param>
    /// <returns>Always true. All failures trigger exceptions.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public virtual bool ReadLength(
                int lengthLength, 
                out long length) {
        length = 0;
        for (var i = 0; i < lengthLength; i++) {
            var value = ReadByte();
            Assert.AssertFalse(value < 0, InvalidFileFormatException.Throw);
            length = (length << 8) + value;
            }
        return true;
        }

    /// <summary>
    /// Check a reversed length value of known length in the forward direction (from the start of the
    /// file to the end).
    /// </summary>
    /// <param name="code">The code that was read</param>
    /// <param name="lengthin">The length value read.</param>
    /// <returns>Always true. All failures trigger exceptions.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public virtual bool CheckReversedLength(
                int code, 
                long lengthin) {

        var lengthCount = TagLength(lengthin) - 1;
        long length = 0;
        for (var i = 0; i < lengthCount; i++) {
            var value = (long)ReadByte();
            Assert.AssertFalse(value < 0, InvalidFileFormatException.Throw);
            length += (value >> 8 * i);
            }
        var checkTag = ReadByte() & TypeMask;
        Assert.AssertTrue(checkTag == code, InvalidFileFormatException.Throw);
        return length == lengthin;
        }

    /// <summary>
    /// Read a length value of known length in the Reverse direction.
    /// </summary>
    /// <param name="lengthLength">The number of bytes to read.</param>
    /// <param name="length">The length value read.</param>
    /// <returns>Always true. All failures trigger exceptions.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public bool ReadLengthReverse(
                int lengthLength, 
                out long length) {
        length = 0;

        for (var i = 0; i < lengthLength; i++) {
            var value = ReadByteReverse();
            Assert.AssertFalse(value < 0, InvalidFileFormatException.Throw);
            length = (length << 8) + value;
            }
        return true;
        }

    /// <summary>
    /// Read a forward length tag in the forward direction
    /// </summary>
    /// <param name="code">The tag code that was read</param>
    /// <param name="length">The length that was read</param>
    /// <returns>True if a tag was read or false if EOF was encountered.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public virtual bool ReadTag(
                out int code, 
                out long length) {
        code = ReadByte();

        if (code < 0) {
            length = 0;
            return false;
            }

        return ReadLength(TagSpace(code), out length);

        }


    /// <summary>
    /// Read a forward length tag in the Reverse direction
    /// </summary>
    /// <param name="code">The tag code that was read</param>
    /// <param name="length">The length that was read</param>
    /// <returns>True if a tag was read or false if EOF was encountered.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public bool ReadTagReverse(out int code, out long length) {
        //Console.WriteLine($"Read Reverse from {PositionRead}");


        if (PositionRead <= 0) {
            code = -1;
            length = -1;
            return false;
            }

        code = ReadByteReverse();

        if (code < 0) {
            length = 0;
            return false;
            }

        return ReadLengthReverse(TagSpace(code), out length);

        }

    static readonly byte[] Empty = Array.Empty<byte>();


    #endregion
    #region // Read Frame Methods

    /// <summary>
    ///  Read a frame in the forward direction.
    /// </summary>
    /// <param name="maxLength">The maximum length of data to read including the tags</param>
    /// <param name="data">The data that was read.</param>
    /// <returns>True if a tag was read or false if EOF was encountered.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public bool ReadRecord(
                ref long maxLength, 
                out byte[] data) {
        data = null;
        var success = ReadTagStartRecord(out var length, out var codelength);
        if (!success) {
            return false;
            }

        maxLength -= codelength;
        Assert.AssertTrue(length <= maxLength, InvalidFileFormatException.Throw);
        if (length > 0) {
            data = new byte[length];
            var bytes = Read(data, 0, (int)length);
            Assert.AssertTrue(bytes == length, InvalidFileFormatException.Throw);
            maxLength -= length;
            }
        else {
            data = Empty;
            }

        //if ((Code & TypeMask) == BFrame) {
        //    CheckReversedLength(Code, Length);
        //    }

        return true;
        }

    /// <summary>
    /// Read a pair of wrapped frames in the forward direction.
    /// </summary>
    /// <param name="frameData">The payload data that was read.</param>
    /// <param name="frameHeader">The header data that was read.</param>
    /// <param name="frameTrailer">The trailer data that was read.</param>
    /// <returns>True if a tag was read or false if EOF was encountered.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public bool ReadFrame(
                out byte[] frameHeader, 
                out byte[] authenticatedHeader, 
                out byte[] frameData, 
                out byte[] frameTrailer) {
        frameHeader = null;
        frameData = null;
        frameTrailer = null;
        authenticatedHeader = null;

        var success = ReadTagStartFrame(out var Length, out var tagLength);
        var originalLength = Length;
        if (!success) {
            return false;
            }
        if (Length > 0) {
            ReadRecord(ref Length, out frameHeader);
            }
        if (Length > 0) {
            ReadRecord(ref Length, out frameData);
            }
        if (Length > 0) {
            ReadRecord(ref Length, out frameTrailer);
            }
        //if ((Code & TypeMask) == BFrame) {

        //    }
        ReadTagEndFrame(originalLength, tagLength);

        return true;
        }



    /// <summary>
    /// Move to the next position in the stream without reading any part of it.
    /// </summary>
    /// <returns></returns>
    public bool Next() {
        StartLastFrameRead = PositionRead;

        var success = ReadTagStartFrame(out var length, out var tagLength);
        var originalLength = length;
        if (!success) {
            return false;
            }
        if (length > 0) {
            StreamRead.Seek(length, System.IO.SeekOrigin.Current);
            }
        ReadTagEndFrame(originalLength, tagLength);
        return true;
        }


    /// <summary>
    /// Move to the previous position in the stream without reading any part of it.
    /// </summary>
    /// <returns></returns>
    public bool Previous() {
        var success = ReadTagFrameReversed(out var length, out var tagLength);
        if (!success) {
            return false;
            }

        // Sanity check
        var thePosition = PositionRead;
        Assert.AssertTrue(thePosition >= length, InvalidFileFormatException.Throw);

        ReadTagStartFrame(out var checkLength, out var checkTagLength);
        Assert.AssertTrue(length == checkLength, InvalidFileFormatException.Throw);
        Assert.AssertTrue(tagLength == checkTagLength, InvalidFileFormatException.Throw);

        return true;
        }

    #endregion

    #region // The new framer methods???


    /// <summary>
    /// Records the start position of the last frame that was read.
    /// </summary>
    public long StartLastFrameRead { get; private set; } = 0;


    long framerFrameStart;
    long framerFrameLength;
    long framerRecordsEnd;          // end of the records.
    long framerFrameNext;
    long framerRecordStart;
    long framerRecordData;
    long framerRecordNext;
    long framerRecordLength;
    int framerCode;

    /// <summary>
    /// Open a frame reader at the position indicated by <paramref name="position"/>
    /// and return the frame length.
    /// </summary>
    /// <param name="position">The file position at which to begin reading.</param>
    /// <param name="previous">Read the previous frame.</param>
    /// <returns>The length of the frame if it could be read, otherwise an error
    /// is thrown.</returns>
    public long FramerOpen(
                long position = 0, 
                bool previous = false) {


        // move the read position.
        PositionRead = position;
        bool success = false;

        if (!previous) {
            //framerFrameStart = position;
            //StreamRead.Seek(framerFrameStart, System.IO.SeekOrigin.Begin);
            StreamRead.Seek(position, System.IO.SeekOrigin.Begin);
            //success = ReadTag(out framerCode, out framerFrameLength);
            framerFrameStart = StreamRead.Position;
            success = ReadTagStartFrame(out framerFrameLength, out var tagLength);


            framerRecordsEnd = StreamRead.Position + framerFrameLength;

            //var tagLength = PositionRead - framerFrameStart;
            framerFrameNext = framerFrameStart + tagLength + framerFrameLength;
            }
        else {
            framerFrameNext = position;

            success = ReadTagFrameReversed(out var length, out var tagLength);
            framerRecordsEnd = PositionRead;

            //var tagLength = framerFrameNext - PositionRead;
            framerFrameStart = framerFrameNext - length - tagLength;

            //Console.WriteLine($"Frame is [ {framerFrameStart}-{framerFrameNext}] ");

            // sanity check, cannot read past the start of the file.
            (framerFrameStart >= StartFirstFrame).AssertTrue(InvalidFileFormatException.Throw);

            PositionRead = framerFrameStart;

            // read the start tag and verify it is correct.
            success = ReadTagStartFrame(out framerFrameLength, out var checkTagLength);
            //(code == framerCode).AssertTrue(InvalidFileFormatException.Throw);
            (length == framerFrameLength).AssertTrue(InvalidFileFormatException.Throw);
            (tagLength == checkTagLength).AssertTrue(InvalidFileFormatException.Throw);
            }


        framerRecordNext = PositionRead;
        return framerFrameNext - framerFrameStart;
        }





    bool FramerOpenRecord() {
        framerRecordStart = framerRecordNext;
        if (framerRecordStart >= framerRecordsEnd) {
            return false;
            }

        StreamRead.Seek(framerRecordStart, SeekOrigin.Begin);
        var success = ReadTagStartRecord(out framerRecordLength, out _);
        if (!success) {
            return false;
            }
        framerRecordData = PositionRead;
        framerRecordNext = framerRecordData + framerRecordLength;
        return true;
        }

    /// <summary>
    /// Read the next frame record and return the data as a byte array.
    /// </summary>
    /// <returns>The frame record data or <code>null</code> if the data could
    /// not be read.</returns>
    public byte[] FramerGetData() {
        if (!FramerOpenRecord()) {
            return null;
            }

        var result = new byte[framerRecordLength];
        var offset = 0;
        var length = StreamRead.Read(result, offset, framerRecordLength);
        while (length > 0) {
            offset += (int)length;
            length = StreamRead.Read(result, offset, framerRecordLength - offset);
            }
        Assert.AssertTrue(length == 0, DataRecordTruncated.Throw);

        return result;
        }


    /// <summary>
    /// Read the next frame and return the starting and ending frame markers.
    /// </summary>
    /// <param name="dataPosition"></param>
    /// <param name="dataLength"></param>
    public bool FramerGetFrameIndex(
                out long dataPosition, 
                out long dataLength) {
        if (!FramerOpenRecord()) {
            dataPosition = framerRecordStart;
            dataLength = 0;
            return false;
            }

        dataPosition = framerRecordData;
        dataLength = framerRecordLength;

        PositionRead = framerRecordNext;

        return true;

        }

    /// <summary>
    /// Return a bounded stream reader for the frame payload data.
    /// </summary>
    /// <param name="dataPosition">The position of the first byte of data.</param>
    /// <param name="dataLength">The number of bytes to be read.</param>
    /// <returns>The bounded stream reader.</returns>
    public StreamReaderBounded FramerGetReader(
                long dataPosition, 
                long dataLength) =>
        new(StreamRead, dataPosition, dataLength);

    /// <summary>
    /// Skip all remaining records in the frame and move to the next record.
    /// The
    /// </summary>
    /// <returns>If <code>true</code>, there are more frames to be read. If 
    /// <code>false</code> the end of the stream has been reached.</returns>
    public bool FramerNext() {
        StreamRead.Seek(framerRecordsEnd, System.IO.SeekOrigin.Begin);
        if ((framerCode & TypeMask) == BFrame) {
            CheckReversedLength(framerCode, framerFrameLength);
            }
        framerFrameStart = StreamRead.Position;
        return StreamRead.Length > StreamRead.Position;
        }


    /// <summary>
    /// Skip all remaining records in the frame and move to the next record.
    /// The
    /// </summary>
    /// <returns>If <code>true</code>, there are more frames to be read. If 
    /// <code>false</code> the end of the stream has been reached.</returns>
    public bool FramerPrevious() {
        StreamRead.Seek(framerFrameStart, System.IO.SeekOrigin.Begin);
        var success = ReadTagReverse(out var Code, out var length);
        if (!success) {
            return false;
            }

        // Sanity check
        var thePosition = PositionRead;
        Assert.AssertTrue(thePosition >= length, InvalidFileFormatException.Throw);

        // Make sure we return to the same position.
        long Start = thePosition - length - TagSpace(Code) - 1;
        framerFrameStart = Start;
        PositionRead = Start;

        return true;
        }




    #endregion


    #region // Frame oriented

    /// <summary>
    /// Read a pair of wrapped frames in the forward direction.
    /// </summary>
    /// <param name="frameHeader">The header data that was read.</param>
    /// <param name="first">If true, this is a first frame.</param>
    /// <returns>True if a tag was read or false if EOF was encountered.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public long ReadFrame(
                out byte[] frameHeader,
                bool first = false) {
        frameHeader = null;
        StartLastFrameRead = PositionRead;

        var success = ReadTagStartFrame(out var length, out var tagLength);
        var originalLength = length;
        if (!success) {
            return -1;
            }
        if (length > 0) {
            ReadRecord(ref length, out frameHeader);
            }
        if (length > 0) {
            //FrameDataPosition = StreamRead.PositionRead;
            StreamRead.Seek(length, System.IO.SeekOrigin.Current);
            }
        ReadTagEndFrame(originalLength, tagLength);

        //if ((Code & TypeMask) == BFrame) {
        //    CheckReversedLength(Code, originalLength);
        //    }

        return length;
        }



    /// <summary>
    /// Read a pair of wrapped frames in the Reverse direction. This is typically done to read the last
    /// record in a file to see how the file should be extended.
    /// </summary>
    /// <param name="frameHeader">The header data that was read.</param>
    /// <returns>True if a tag was read or false if EOF was encountered.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public long ReadFrameReverse(
                out byte[] frameHeader) {
        var success = ReadTagReverse(out var Code, out var Length);
        if (!success) {
            frameHeader = null;
            return -1;
            }

        // Sanity check
        var thePosition = PositionRead;
        Assert.AssertTrue(thePosition >= Length, InvalidFileFormatException.Throw);

        // Make sure we return to the same position.
        long Start = thePosition - Length - TagSpace(Code) - 1;

        PositionRead = Start;
        var result = ReadFrame(out frameHeader);
        PositionRead = Start;

        return result;
        }

    /// <summary>
    /// Move a frame in the Reverse direction.
    /// </summary>
    /// <returns></returns>
    public long MoveFrameReverse() {
        var success = ReadTagReverse(out var Code, out var Length);
        if (!success) {
            return -1;
            }
        // Sanity check
        var thePosition = PositionRead;
        Assert.AssertTrue(thePosition >= Length, InvalidFileFormatException.Throw);

        // Make sure we return to the same position.
        long Start = thePosition - Length - TagSpace(Code) - 1;

        PositionRead = Start;
        return PositionRead;
        }


    /// <summary>
    /// Read the current frame header
    /// </summary>
    /// <returns>The current frame header</returns>
    public DareHeader ReadFrameHeader(bool first = false) {
        var position = PositionRead;
        var length = ReadFrame(out var HeaderData);

        var header = JsonObject.StreamParseTag<DareHeader>(HeaderData, false);

        return header;
        }


    /// <summary>
    /// Read the final frame header
    /// </summary>
    /// <returns>The last frame header</returns>
    public DareHeader ReadFirstFrameHeader() {
        Begin();
        return ReadFrameHeader(true);
        }

    /// <summary>
    /// Read the final frame header
    /// </summary>
    /// <returns>The last frame header</returns>
    public DareHeader ReadLastFrameHeader() {
        End();
        var position = PositionRead;
        var length = ReadFrameReverse(out var HeaderData);
        End();

        var header = JsonObject.StreamParseTag<DareHeader>(HeaderData, false);
        //header.FrameStart = position - length;
        //header.FrameLength = length;

        return header;
        }

    #endregion
    #region // Read Envelope
    /// <summary>
    /// Return the current Sequence frame as a DareEnvelope.
    /// </summary>
    /// <returns>The Sequence data.</returns>
    public Enveloped ReadDareEnvelope() {
        var found = ReadFrame(out var headerData, out _, out var FrameData, out var trailerData);
        if (!found) {
            return null;
            }
        var message = new Enveloped() { Body = FrameData };
        if (headerData != null) {
            message.Header = JsonObject.StreamParseTag<DareHeader>(headerData, false);
            }
        if (trailerData != null) {
            //JSONReader.Trace = true;
            //Console.WriteLine(trailerData.ToUTF8());
            message.Trailer = JsonObject.StreamParseTag<DareTrailer>(trailerData, false);
            }
        return message;
        }


    #endregion

    }
