
//namespace Goedel.Cryptography.Dare;

//public interface IJsonbinaryStream {
//    bool EOF { get; }
//    string Filename { get; }
//    long Length { get; }
//    long PositionRead { get; set; }
//    long PositionWrite { get; set; }
//    long StartLastFrameRead { get; }


//    long Begin();
//    bool CheckReversedLength(int Code, long LengthIn);
//    long End();
//    void Flush();
//    byte[] FramerGetData();
//    bool FramerGetFrameIndex(out long DataPosition, out long DataLength);
//    StreamReaderBounded FramerGetReader(long DataPosition, long DataLength);
//    bool FramerNext();
//    long FramerOpen(long position = 0, bool previous = false);
//    bool FramerPrevious();
//    long MoveFrameReverse();
//    bool Next();
//    bool Previous();
//    int Read(byte[] Buffer, int Offset, int Count);
//    int ReadByte();
//    int ReadByteReverse();
//    DareEnvelope ReadDareEnvelope();
//    DareHeader ReadFirstFrameHeader();
//    long ReadFrame(out byte[] FrameHeader);
//    bool ReadFrame(out byte[] FrameHeader, out byte[] FrameData, out byte[] FrameTrailer);
//    DareHeader ReadFrameHeader();
//    long ReadFrameReverse(out byte[] FrameHeader);
//    bool ReadFrameReverse(out byte[] FrameHeader, out byte[] FrameData);
//    DareHeader ReadLastFrameHeader();
//    bool ReadLength(int LengthLength, out long Length);
//    bool ReadLengthReverse(int LengthLength, out long Length);
//    bool ReadRecord(ref long MaxLength, out byte[] Data);
//    bool ReadTag(out int Code, out long Length);
//    bool ReadTagReverse(out int Code, out long Length);
//    long Seek(long Offset, SeekOrigin Origin);
//    void SeekWrite();
//    void Write(byte[] Buffer, int Offset = 0, int Count = -1);
//    void WriteBinaryBegin(long Length, bool Terminal = true);
//    void WriteBinaryPart(byte[] Data, long First = 0, long Length = -1);
//    void WriteByte(byte Value);
//    long WriteFrame(byte[] FrameData, long Offset = 0, long Length = -1, bool Bidirectional = false);
//    void WriteTag(byte Code, long Length);
//    void WriteTagReverse(byte Code, long Length);
//    long WriteWrappedFrame(byte[] FrameHeader, byte[] FrameData1 = null, byte[] FrameData2 = null, bool flush = true);
//    (long, long) WriteWrappedFrameBegin(byte[] FrameHeader, long FrameDataLength = -1, long FrameTrailerLength = -1);
//    long WriteWrappedFrameEnd(byte[] FrameTrailer = null);
//    }