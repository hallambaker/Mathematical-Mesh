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
using System.Threading;

namespace Goedel.Cryptography.Dare;


// This file has the methods that operate on the stream
public partial class JbcdStream {

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

    /* Static methods */

    /// <summary>
    /// Return the shortest tag length for the specified production.
    /// </summary>
    /// <param name="Length">Length of data to follow.</param>
    /// <returns>The tag length.</returns>
    public static int TagLength(long Length) {
        if (Length < 0x100) {
            return 2;
            }
        else if (Length < 0x10000) {
            return 3;
            }
        else if (Length < 0x100000000) {
            return 5;
            }
        else {
            return 9;
            }

        }
    /// <summary>
    /// Return the length of a code
    /// </summary>
    /// <param name="Code">Base code.</param>
    /// <returns>The number of bytes required.</returns>
    public static int TagSpace(int Code) => TagSpaces[Code & LengthMask];


    /// <summary>
    /// Return the length of a code
    /// </summary>
    /// <param name="Code">Base code.</param>
    /// <returns>The number of bytes required.</returns>
    public static int CodeSpace(int Code) {
        Assert.AssertTrue(Code >= UFrame & Code <= (BFrame + Length64),
            StreamDataCorrupt.Throw);

        return CodeSpaces[Code - UFrame];

        }


    /// <summary>
    /// Determine Tag length using the shortest possible production
    /// </summary>
    /// <param name="Length">Length of data to follow.</param>
    /// <returns>The number of bytes required.</returns>
    public static long TotalLength(long Length) => Length + TagLength(Length);

    /// <summary>
    /// Determine Tag length using the shortest possible production
    /// </summary>
    /// <param name="Length">Length of data to follow.</param>
    /// /// <returns>The number of bytes required.</returns>
    public static long TotalLength2(long Length) => Length + 2 * TagLength(Length);


    /* Write methods */


    /// <summary>
    /// Write out a Tag-Length value using the shortest possible production
    /// </summary>
    /// <param name="Code">Base code.</param>
    /// <param name="Length">Length of data to follow.</param>
    public void WriteTag(byte Code, long Length) {
        if (Length < 0x100) {
            WriteByte((byte)(Code + Length8));
            WriteByte((byte)(Length & 0xff));
            }
        else if (Length < 0x10000) {
            WriteByte((byte)(Code + Length16));
            WriteByte((byte)((Length >> 8) & 0xff));
            WriteByte((byte)(Length & 0xff));
            }
        else if (Length < 0x100000000) {
            WriteByte((byte)(Code + Length32));
            WriteByte((byte)((Length >> 24) & 0xff));
            WriteByte((byte)((Length >> 16) & 0xff));
            WriteByte((byte)((Length >> 8) & 0xff));
            WriteByte((byte)(Length & 0xff));
            }
        else {
            WriteByte((byte)(Code + Length64));
            WriteByte((byte)((Length >> 56) & 0xff));
            WriteByte((byte)((Length >> 48) & 0xff));
            WriteByte((byte)((Length >> 40) & 0xff));
            WriteByte((byte)((Length >> 32) & 0xff));
            WriteByte((byte)((Length >> 24) & 0xff));
            WriteByte((byte)((Length >> 16) & 0xff));
            WriteByte((byte)((Length >> 8) & 0xff));
            WriteByte((byte)(Length & 0xff));
            }
        }

    /// <summary>
    /// Write out a Tag-Length value using the shortest possible production
    /// </summary>
    /// <param name="Code">Base code.</param>
    /// <param name="Length">Length of data to follow.</param>
    public void WriteTagReverse(byte Code, long Length) {
        if (Length < 0x100) {
            WriteByte((byte)(Length & 0xff));
            WriteByte((byte)(Code + Length8));
            }
        else if (Length < 0x10000) {
            WriteByte((byte)(Length & 0xff));
            WriteByte((byte)((Length >> 8) & 0xff));
            WriteByte((byte)(Code + Length16));
            }
        else if (Length < 0x100000000) {
            WriteByte((byte)(Length & 0xff));
            WriteByte((byte)((Length >> 8) & 0xff));
            WriteByte((byte)((Length >> 16) & 0xff));
            WriteByte((byte)((Length >> 24) & 0xff));
            WriteByte((byte)(Code + Length32));
            }
        else {
            WriteByte((byte)(Length & 0xff));
            WriteByte((byte)((Length >> 8) & 0xff));
            WriteByte((byte)((Length >> 16) & 0xff));
            WriteByte((byte)((Length >> 24) & 0xff));
            WriteByte((byte)((Length >> 32) & 0xff));
            WriteByte((byte)((Length >> 40) & 0xff));
            WriteByte((byte)((Length >> 48) & 0xff));
            WriteByte((byte)((Length >> 56) & 0xff));
            WriteByte((byte)(Code + Length64));
            }
        }


    /// <summary>
    /// Write a unidirectional or bidirectional frame to the current stream at the current write position. 
    /// The code does not currently support 64 bit frames as it should.
    /// </summary>
    /// <param name="FrameData">The data to write.</param>
    /// <param name="Offset">Offset within the data.</param>
    /// <param name="Length">Number of bytes to write.</param>
    /// <param name="Bidirectional">If true, a bidirectional frame is written.</param>
    /// <returns>The total size of the frame.</returns>
    public long WriteFrame(byte[] FrameData,
            long Offset = 0, long Length = -1, bool Bidirectional = false) {
        Length = Length == -1 ? FrameData.LongLength : Length;

        Assert.AssertTrue(Length <= Int32.MaxValue, FrameTooLargeException.Throw);

        if (Bidirectional) {
            WriteTag(BFrame, Length);
            }
        else {
            WriteTag(UFrame, Length);
            }
        Write(FrameData, (int)Offset, (int)Length);
        if (Bidirectional) {
            WriteTagReverse(BFrame, Length);
            return TotalLength2(Length);
            }
        else {
            return TotalLength(Length);
            }
        }

    /// <summary>
    /// Write a wrapped frame containing a header and an optional data section
    /// to the current stream at the current write position. 
    /// The code does not currently support 64 bit frames as it should.
    /// </summary>
    /// <param name="FrameHeader">The header data to write.</param>
    /// <param name="FrameData1">First data record, contains data content.</param>
    /// <param name="FrameData2">Second data record, contains protected metadata.</param>
    /// <param name="flush">If true, flush the frame data value to the file.</param>
    /// <returns>The total size of the frame.</returns>
    public long WriteWrappedFrame(
                byte[] FrameHeader,
                byte[] FrameData1 = null,
                byte[] FrameData2 = null,
                bool flush = true) {

        bool lockTaken = false;

        try {

            if (LockGlobal != null) {
                Monitor.Enter(LockGlobal, ref lockTaken);
                LockGlobal.Enter();
                }

            var FrameLength = (FrameHeader == null ? 2 : TotalLength(FrameHeader.Length)) +
                                (FrameData1 == null ? 2 : TotalLength(FrameData1.Length)) +
                                (FrameData2 == null ? 2 : TotalLength(FrameData2.Length));

            WriteTag(BFrame, FrameLength);

            var Check = PositionWrite;
            if (FrameHeader != null) {
                WriteFrame(FrameHeader);
                }
            else {
                WriteTag(UFrame, 0);
                }

            var result = PositionWrite;

            if (FrameData1 != null) {

                result += TagLength(FrameData1.LongLength);

                WriteFrame(FrameData1);
                }
            else {
                WriteTag(UFrame, 0);
                }
            if (FrameData2 != null) {
                WriteFrame(FrameData2);
                }
            else {
                WriteTag(UFrame, 0);
                }

            Assert.AssertTrue(PositionWrite == Check + FrameLength, Internal.Throw);

            WriteTagReverse(BFrame, FrameLength);

            if (flush) {
                StreamWrite.Flush();
                }

            return result;
            }

        catch (Exception exception) {
            LockGlobal?.Exit();
            if (lockTaken) {
                Monitor.Exit(LockGlobal);
                }

            exception.Future();
            throw;
            }

        }


    long frameLength;
    long check;

    /// <summary>
    /// Write a wrapped frame containing a header and an optional data section
    /// to the current stream at the current write position. 
    /// The code does not currently support 64 bit frames as it should.
    /// </summary>
    /// <param name="FrameHeader">The header data to write.</param>
    /// <param name="FrameDataLength">Length of the frame payload.</param>
    /// <param name="FrameTrailerLength">Length of the frame trailer.</param>
    /// <returns>The total size of the frame.</returns>
    public long WriteWrappedFrameBegin(
                byte[] FrameHeader,
                long FrameDataLength = -1,
                long FrameTrailerLength = -1) {

        var HL = (FrameHeader == null ? 0 : TotalLength(FrameHeader.Length));
        var DL = (FrameDataLength < 0 ? 0 : TotalLength(FrameDataLength));
        var TL = (FrameTrailerLength < 0 ? 0 : TotalLength(FrameTrailerLength));

        frameLength = HL + DL + TL;

        WriteTag(BFrame, frameLength);

        check = PositionWrite;
        if (FrameHeader != null) {
            WriteFrame(FrameHeader);
            }

        Assert.AssertTrue(PositionWrite == check + HL, Internal.Throw);

        // here write out the binary marker for the frame data.
        WriteTag(UFrame, FrameDataLength);

        return TotalLength2(frameLength);
        }

    /// <summary>
    /// Complete writing out a wrapped frame. The frame must previously be started
    /// using a matching call to WriteWrappedFrameBegin. If the content written 
    /// does not match the length originally specified, an error is thrown.
    /// </summary>
    /// <returns>The total size of the frame.</returns>
    public long WriteWrappedFrameEnd(byte[] FrameTrailer = null) {
        if (FrameTrailer != null) {
            WriteFrame(FrameTrailer);
            }

        check += frameLength;
        Assert.AssertTrue(PositionWrite == check, Internal.Throw);
        // Note, if this check fails, check to see if the trailer length is being calculated correctly.
        // Missing or incorrect dummy trailers will cause this check to fail as will incorrect calculation
        // of the payload length.

        WriteTagReverse(BFrame, frameLength);
        StreamWrite.Flush(); // Force output of data

        return TotalLength2(frameLength);
        }


    /// <summary>Begin partial write of binary data. 
    /// This is not yet implemented for standard streams.</summary>
    public virtual void WriteBinaryBegin(long Length, bool Terminal = true) => throw new NYI();

    /// <summary>Write binary data as length-data item.</summary>
    /// <param name="Data">Value to write</param>
    /// <param name="First">The index position of the first byte in the input data to process</param>
    /// <param name="Length">The number of bytes to process</param>
    public virtual void WriteBinaryPart(byte[] Data, long First = 0, long Length = -1) => throw new NYI();


    /// <summary>
    /// Read a length value of known length in the forward direction.
    /// </summary>
    /// <param name="LengthLength">The number of bytes to read.</param>
    /// <param name="Length">The length value read.</param>
    /// <returns>Always true. All failures trigger exceptions.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public virtual bool ReadLength(int LengthLength, out long Length) {
        Length = 0;
        for (var i = 0; i < LengthLength; i++) {
            var Value = ReadByte();
            Assert.AssertFalse(Value < 0, InvalidFileFormatException.Throw);
            Length = (Length << 8) + Value;
            }
        return true;
        }

    /// <summary>
    /// Check a reversed length value of known length in the forward direction (from the start of the
    /// file to the end).
    /// </summary>
    /// <param name="Code">The code that was read</param>
    /// <param name="LengthIn">The length value read.</param>
    /// <returns>Always true. All failures trigger exceptions.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public virtual bool CheckReversedLength(int Code, long LengthIn) {

        var LengthCount = TagLength(LengthIn) - 1;
        long Length = 0;
        for (var i = 0; i < LengthCount; i++) {
            var Value = (long)ReadByte();
            Assert.AssertFalse(Value < 0, InvalidFileFormatException.Throw);
            Length += (Value >> 8 * i);
            }
        var CheckTag = ReadByte();
        Assert.AssertTrue(CheckTag == Code, InvalidFileFormatException.Throw);
        return Length == LengthIn;
        }

    /// <summary>
    /// Read a length value of known length in the reverse direction.
    /// </summary>
    /// <param name="LengthLength">The number of bytes to read.</param>
    /// <param name="Length">The length value read.</param>
    /// <returns>Always true. All failures trigger exceptions.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public bool ReadLengthReverse(int LengthLength, out long Length) {
        Length = 0;

        for (var i = 0; i < LengthLength; i++) {
            var Value = ReadByteReverse();
            Assert.AssertFalse(Value < 0, InvalidFileFormatException.Throw);
            Length = (Length << 8) + Value;
            }
        return true;
        }

    /// <summary>
    /// Read a forward length tag in the forward direction
    /// </summary>
    /// <param name="Code">The tag code that was read</param>
    /// <param name="Length">The length that was read</param>
    /// <returns>True if a tag was read or false if EOF was encountered.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public virtual bool ReadTag(out int Code, out long Length) {
        Code = ReadByte();

        if (Code < 0) {
            Length = 0;
            return false;
            }

        return ReadLength(TagSpace(Code), out Length);

        }


    /// <summary>
    /// Read a forward length tag in the Reverse direction
    /// </summary>
    /// <param name="Code">The tag code that was read</param>
    /// <param name="Length">The length that was read</param>
    /// <returns>True if a tag was read or false if EOF was encountered.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public bool ReadTagReverse(out int Code, out long Length) {
        if (PositionRead <= 0) {
            Code = -1;
            Length = -1;
            return false;
            }


        Code = ReadByteReverse();

        if (Code < 0) {
            Length = 0;
            return false;
            }

        return ReadLengthReverse(TagSpace(Code), out Length);

        }

    static byte[] Empty = new byte[0];

    /// <summary>
    ///  Read a frame in the forward direction.
    /// </summary>
    /// <param name="MaxLength">The maximum length of data to read including the tags</param>
    /// <param name="Data">The data that was read.</param>
    /// <returns>True if a tag was read or false if EOF was encountered.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public bool ReadRecord(ref long MaxLength, out byte[] Data) {
        Data = null;
        var Success = ReadTag(out var Code, out var Length);
        if (!Success) {
            return false;
            }

        MaxLength -= CodeSpace(Code);
        Assert.AssertTrue(Length <= MaxLength, InvalidFileFormatException.Throw);
        if (Length > 0) {
            Data = new byte[Length];
            var Bytes = Read(Data, 0, (int)Length);
            Assert.AssertTrue(Bytes == Length, InvalidFileFormatException.Throw);
            MaxLength -= Length;
            }
        else {
            Data = Empty;
            }

        if ((Code & TypeMask) == BFrame) {
            CheckReversedLength(Code, Length);
            }

        return true;
        }

    /// <summary>
    /// Read a pair of wrapped frames in the forward direction.
    /// </summary>
    /// <param name="FrameData">The payload data that was read.</param>
    /// <param name="FrameHeader">The header data that was read.</param>
    /// <param name="FrameTrailer">The trailer data that was read.</param>
    /// <returns>True if a tag was read or false if EOF was encountered.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public bool ReadFrame(out byte[] FrameHeader, out byte[] FrameData, out byte[] FrameTrailer) {
        FrameHeader = null;
        FrameData = null;
        FrameTrailer = null;

        var Success = ReadTag(out var Code, out var Length);
        var OriginalLength = Length;
        if (!Success) {
            return false;
            }
        if (Length > 0) {
            ReadRecord(ref Length, out FrameHeader);
            }
        if (Length > 0) {
            ReadRecord(ref Length, out FrameData);
            }
        if (Length > 0) {
            ReadRecord(ref Length, out FrameTrailer);
            }
        if ((Code & TypeMask) == BFrame) {
            CheckReversedLength(Code, OriginalLength);
            }

        return true;
        }



    /// <summary>
    /// Move to the next position in the stream without reading any part of it.
    /// </summary>
    /// <returns></returns>
    public bool Next() {
        StartLastFrameRead = PositionRead;

        var Success = ReadTag(out var Code, out var Length);
        var OriginalLength = Length;
        if (!Success) {
            return false;
            }
        if (Length > 0) {
            StreamRead.Seek(Length, System.IO.SeekOrigin.Current);
            }
        if ((Code & TypeMask) == BFrame) {
            CheckReversedLength(Code, OriginalLength);
            }
        return true;
        }


    /// <summary>
    /// Move to the previous position in the stream without reading any part of it.
    /// </summary>
    /// <returns></returns>
    public bool Previous() {
        var Success = ReadTagReverse(out var Code, out var Length);
        if (!Success) {
            return false;
            }

        // Sanity check
        var ThePosition = PositionRead;
        Assert.AssertTrue(ThePosition >= Length, InvalidFileFormatException.Throw);

        // Make sure we return to the same position.
        long Start = ThePosition - Length - TagSpace(Code) - 1;
        PositionRead = Start;

        return true;
        }

    #region // Methods that are used by JBCDRecordDataReader


    //long FrameDataPosition; // Start of the current record.
    //long RecordDataRemaining;

    ///// <summary>
    ///// Begin reading a record frame.
    ///// </summary>
    ///// <param name="MaxLength"></param>
    ///// <returns></returns>
    //public long ReadRecordBegin(ref long MaxLength) {
    //    StreamRead.Seek(FrameDataPosition, System.IO.SeekOrigin.Begin);

    //    var Success = ReadTag(out var Code, out var Length);
    //    if (!Success) {
    //        return -1;
    //        }
    //    MaxLength -= CodeSpace(Code);
    //    Assert.True(Length <= MaxLength, InvalidFileFormatException.Throw);
    //    RecordDataRemaining = Length;
    //    MaxLength -= Length;

    //    return Length;
    //    }


    ///// <summary>
    ///// Read record data.
    ///// </summary>
    ///// <param name="Buffer">Buffer to store record data.</param>
    ///// <param name="Offset">Index to begin storing data.</param>
    ///// <param name="Length">Maximum number of bytes to read. This will 
    ///// be reduced if necessary to the remaining record to be read.</param>
    ///// <returns>The number of bytes read.</returns>
    //public int ReadRecordData(byte[] Buffer, int Offset = 0, int Length = -1) {
    //    Length = Length < 0 ? Buffer.Length - Offset : Length;
    //    Length = (Length > RecordDataRemaining) ? (int)RecordDataRemaining : Length;
    //    RecordDataRemaining -= Length;
    //    return Read(Buffer, Offset, Length);
    //    }



    #endregion
    #region // The methods we want to switch to using.


    /// <summary>
    /// Records the start position of the last frame that was read.
    /// </summary>
    public long StartLastFrameRead { get; private set; } = 0;


    long framerFrameStart;
    long framerFrameLength;
    long framerFrameEnd;
    long framerRecordStart;
    long framerRecordData;
    long framerRecordNext;
    long framerRecordLength;
    int framerCode;

    /// <summary>
    /// Open a frame reader at the position indicated by <paramref name="Position"/>
    /// and return the frame length.
    /// </summary>
    /// <param name="Position">The file position at which to begin reading. If
    /// less than 0, the frame reader position is reset. This will cause the last
    /// record read with FramerOpen to be re-read unless FramerClose has been called 
    /// in which case the next frame in the stream will be read.</param>
    /// <returns>The length of the frame if it could be read, otherwise -1.</returns>
    public long FramerOpen(long Position = -1) {

        framerFrameStart = Position < 0 ? framerFrameStart : Position;

        StreamRead.Seek(framerFrameStart, System.IO.SeekOrigin.Begin);
        var Success = ReadTag(out framerCode, out framerFrameLength);
        framerFrameEnd = StreamRead.Position + framerFrameLength;
        framerRecordNext = StreamRead.Position;
        return framerFrameLength;


        }


    bool FramerOpenRecord() {
        framerRecordStart = framerRecordNext;

        //FrameDataPosition = FramerRecordStart; // just in case, legacy.

        if (framerRecordStart >= framerFrameEnd) {
            return false;
            }

        StreamRead.Seek(framerRecordStart, SeekOrigin.Begin);
        var Success = ReadTag(out var Code, out framerRecordLength);
        if (!Success) {
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

        var Result = new byte[framerRecordLength];
        var Offset = 0;
        var Length = StreamRead.Read(Result, Offset, framerRecordLength);
        while (Length > 0) {
            Offset += (int)Length;
            Length = StreamRead.Read(Result, Offset, framerRecordLength - Offset);
            }
        Assert.AssertTrue(Length == 0, DataRecordTruncated.Throw);

        return Result;
        }


    /// <summary>
    /// Read the next frame and return the starting and ending frame markers.
    /// </summary>
    /// <param name="DataPosition"></param>
    /// <param name="DataLength"></param>
    public bool FramerGetFrameIndex(out long DataPosition, out long DataLength) {
        if (!FramerOpenRecord()) {
            DataPosition = framerRecordStart;
            DataLength = 0;
            return false;
            }

        DataPosition = framerRecordData;
        DataLength = framerRecordLength;

        PositionRead = framerRecordNext;

        return true;

        }

    /// <summary>
    /// Return a bounded stream reader for the frame payload data.
    /// </summary>
    /// <param name="DataPosition">The position of the first byte of data.</param>
    /// <param name="DataLength">The number of bytes to be read.</param>
    /// <returns>The bounded stream reader.</returns>
    public StreamReaderBounded FramerGetReader(long DataPosition, long DataLength) =>
        new(StreamRead, DataPosition, DataLength);

    /// <summary>
    /// Skip all remaining records in the frame and move to the next record.
    /// The
    /// </summary>
    /// <returns>If <code>true</code>, there are more frames to be read. If 
    /// <code>false</code> the end of the stream has been reached.</returns>
    public bool FramerNext() {
        StreamRead.Seek(framerFrameEnd, System.IO.SeekOrigin.Begin);
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
        var Success = ReadTagReverse(out var Code, out var Length);
        if (!Success) {
            return false;
            }

        // Sanity check
        var ThePosition = PositionRead;
        Assert.AssertTrue(ThePosition >= Length, InvalidFileFormatException.Throw);

        // Make sure we return to the same position.
        long Start = ThePosition - Length - TagSpace(Code) - 1;
        framerFrameStart = Start;
        PositionRead = Start;

        return true;
        }




    #endregion







    /// <summary>
    /// Read a pair of wrapped frames in the forward direction.
    /// </summary>
    /// <param name="FrameHeader">The header data that was read.</param>
    /// <returns>True if a tag was read or false if EOF was encountered.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public long ReadFrame(out byte[] FrameHeader) {
        FrameHeader = null;
        StartLastFrameRead = PositionRead;

        var Success = ReadTag(out var Code, out var Length);
        var OriginalLength = Length;
        if (!Success) {
            return -1;
            }
        if (Length > 0) {
            ReadRecord(ref Length, out FrameHeader);
            }
        if (Length > 0) {
            //FrameDataPosition = StreamRead.Position;
            StreamRead.Seek(Length, System.IO.SeekOrigin.Current);
            }
        if ((Code & TypeMask) == BFrame) {
            CheckReversedLength(Code, OriginalLength);
            }

        return Length;
        }


    /// <summary>
    /// Read a pair of wrapped frames in the reverse direction. This is typically done to read the last
    /// record in a file to see how the file should be extended.
    /// </summary>
    /// <param name="FrameData">The payload data that was read.</param>
    /// <param name="FrameHeader">The header data that was read.</param>
    /// <returns>True if a tag was read or false if EOF was encountered.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public bool ReadFrameReverse(out byte[] FrameHeader, out byte[] FrameData) {
        var Success = ReadTagReverse(out var Code, out var Length);
        if (!Success) {
            FrameHeader = null;
            FrameData = null;
            return false;
            }

        // Sanity check
        var ThePosition = PositionRead;
        Assert.AssertTrue(ThePosition >= Length, InvalidFileFormatException.Throw);

        // Make sure we return to the same position.
        long Start = ThePosition - Length - TagSpace(Code) - 1;

        PositionRead = Start;
        ReadFrame(out FrameHeader, out FrameData, out var FrameTrailer);
        PositionRead = Start;

        return true;
        }


    /// <summary>
    /// Read a pair of wrapped frames in the reverse direction. This is typically done to read the last
    /// record in a file to see how the file should be extended.
    /// </summary>
    /// <param name="FrameHeader">The header data that was read.</param>
    /// <returns>True if a tag was read or false if EOF was encountered.</returns>
    /// <exception cref="InvalidFileFormatException">The record data read from disk was invalid</exception>
    public long ReadFrameReverse(out byte[] FrameHeader) {
        var Success = ReadTagReverse(out var Code, out var Length);
        if (!Success) {
            FrameHeader = null;
            return -1;
            }

        // Sanity check
        var ThePosition = PositionRead;
        Assert.AssertTrue(ThePosition >= Length, InvalidFileFormatException.Throw);

        // Make sure we return to the same position.
        long Start = ThePosition - Length - TagSpace(Code) - 1;

        PositionRead = Start;
        var Result = ReadFrame(out FrameHeader);
        PositionRead = Start;

        return Result;
        }

    /// <summary>
    /// Move a frame in the reverse direction.
    /// </summary>
    /// <returns></returns>
    public long MoveFrameReverse() {
        var Success = ReadTagReverse(out var Code, out var Length);
        if (!Success) {
            return -1;
            }
        // Sanity check
        var ThePosition = PositionRead;
        Assert.AssertTrue(ThePosition >= Length, InvalidFileFormatException.Throw);

        // Make sure we return to the same position.
        long Start = ThePosition - Length - TagSpace(Code) - 1;

        PositionRead = Start;
        return PositionRead;
        }


    /// <summary>
    /// Read the current frame header
    /// </summary>
    /// <returns>The current frame header</returns>
    public DareHeader ReadFrameHeader() {
        ReadFrame(out var HeaderData);
        return DareHeader.FromJson(HeaderData.JsonReader(), false);
        }


    /// <summary>
    /// Read the final frame header
    /// </summary>
    /// <returns>The last frame header</returns>
    public DareHeader ReadFirstFrameHeader() {
        Begin();
        ReadFrame(out var HeaderData);
        return DareHeader.FromJson(HeaderData.JsonReader(), false);
        }

    /// <summary>
    /// Read the final frame header
    /// </summary>
    /// <returns>The last frame header</returns>
    public DareHeader ReadLastFrameHeader() {
        End();
        ReadFrameReverse(out var HeaderData);
        End();

        var HeaderText = HeaderData.ToUTF8();

        return DareHeader.FromJson(HeaderData.JsonReader(), false);
        }

    /// <summary>
    /// Return the current container frame as a DareEnvelope.
    /// </summary>
    /// <returns>The container data.</returns>
    public DareEnvelope ReadDareEnvelope() {
        var found = ReadFrame(out var headerData, out var FrameData, out var trailerData);
        if (!found) {
            return null;
            }
        var message = new DareEnvelope() { Body = FrameData };
        if (headerData != null) {
            message.Header = DareHeader.FromJson(headerData.JsonReader(), false);
            }
        if (trailerData != null) {
            //JSONReader.Trace = true;
            //Console.WriteLine(trailerData.ToUTF8());
            message.Trailer = DareTrailer.FromJson(trailerData.JsonReader(), false);
            }
        return message;
        }



    }
