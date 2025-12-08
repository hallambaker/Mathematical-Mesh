
namespace Goedel.Cryptography.Dare;

public interface ISequence {
    byte[] Bitmask { get; }
    DarePolicy DarePolicy { get; }
    DataEncoding DataEncoding { get; }
    bool Decrypt { get; init; }
    bool DigestRequired { get; }
    bool DisposeStream { get; set; }
    string Filename { get; set; }
    long FrameCount { get; }
    long FrameIndexLast { get; }
    DareHeader HeaderFinal { get; }
    DareHeader HeaderFirst { get; }
    IInternSequenceIndexEntry InternDelegate { get; set; }
    IKeyLocate KeyLocate { get; }
    long Length { get; }
    long PositionRead { get; }
    long PositionWrite { get; }
    IEnumerable<SequenceIndexEntry> ReadForward { get; }
    SequenceIndexEntryFactoryDelegate SequenceIndexEntryFactoryDelegate { get; init; }
    SequenceIndexEntry SequenceIndexEntryFirst { get; }
    SequenceIndexEntry SequenceIndexEntryLast { get; }
    bool StreamDisposed { get; }
    bool StreamIsDisposed { get; }
    DareTrailer TrailerLast { get; }

    static abstract Enveloped Defer(SequenceWriterDeferred contextWrite, ContentMeta contentMeta, byte[] data, byte[] cloaked = null, List<byte[]> dataSequences = null);
    static abstract long GetFrameCount(string fileName);
    static abstract Sequence MakeNewSequence(JbcdStream jbcdStream, bool decrypt, SequenceIndexEntryFactoryDelegate sequenceIndexEntryFactoryDelegate, SequenceType sequenceType = SequenceType.Merkle);
    static abstract Sequence MakeNewSequence(string fileName, IKeyLocate keyLocate, List<Enveloped> envelopes, FileStatus fileStatus = FileStatus.New);
    static abstract Sequence NewSequence(JbcdStream jbcdStream, IKeyLocate keyLocate = null, SequenceType sequenceType = SequenceType.Chain, DarePolicy policy = null, byte[] payload = null, string contentType = null, DataEncoding dataEncoding = DataEncoding.JSON, byte[] cloaked = null, List<byte[]> dataSequences = null, bool decrypt = true, byte[] bitmask = null, JsonObject jsonObject = null, IInternSequenceIndexEntry store = null);
    static abstract Sequence NewSequence(string filename, FileStatus fileStatus, SequenceType sequenceType = SequenceType.Chain, DarePolicy policy = null, byte[] payload = null, string contentType = null, DataEncoding dataEncoding = DataEncoding.JSON, byte[] cloaked = null, List<byte[]> dataSequences = null, bool decrypt = true, byte[] bitmask = null);
    static abstract Sequence Open(JbcdStream jbcdStream, IKeyLocate keyLocate = null);
    static abstract Sequence Open(string fileName, FileStatus fileStatus = FileStatus.Read, IKeyLocate keyLocate = null, SequenceType sequenceType = SequenceType.Unknown, DarePolicy policy = null, string contentType = null, bool decrypt = true, bool create = true, byte[] bitmask = null, IInternSequenceIndexEntry store = null);
    static abstract Sequence OpenExisting(JbcdStream jbcdStream, IKeyLocate keyCollection = null, bool decrypt = true, IInternSequenceIndexEntry store = null);
    static abstract Sequence OpenExisting(string fileName, FileStatus fileStatus = FileStatus.Read, IKeyLocate keyCollection = null, bool decrypt = true, IInternSequenceIndexEntry store = null);
    static abstract void ToBuilder(string fileName, StringBuilder builder, int indent);
    static abstract void ToConsole(string fileName);
    static abstract void VerifyPolicy(string filename, IKeyLocate keyLocate);
    SequenceIndexEntry Append(byte[] data, ContentMeta contentMeta = null, string contentType = null, byte[] cloaked = null, List<byte[]> dataSequences = null, CryptoParameters cryptoParameters = null);
    SequenceIndexEntry Append(Enveloped envelope, bool updateEnvelope = false);
    void Append(List<Enveloped> envelopes, long index = 0, bool unverified = true);
    long AppendBegin(long dataLength, ContentMeta contentInfo = null, string contentType = null, byte[] cloaked = null, List<byte[]> dataSequences = null, CryptoParameters cryptoParameters = null);
    SequenceIndexEntry AppendFile(string fileName, ContentMeta contentInfo = null, string contentType = null, byte[] cloaked = null, List<byte[]> dataSequences = null);
    SequenceIndexEntry AppendFromStream(Stream input, long contentLength, ContentMeta contentMeta = null, string contentType = null, byte[] cloaked = null, List<byte[]> dataSequences = null, CryptoParameters cryptoParameters = null);
    void CheckSequence(List<DareHeader> headers);
    DareTrailer FillDummyTrailer(CryptoStack cryptoStack);
    SequenceIndexEntry Frame(long Index, bool skip = true);
    SequenceIndexEntry FrameLast();
    StreamReaderBounded FramerGetReader(long DataPosition, long DataLength);
    IEnumerator<SequenceIndexEntry> GetEnumerator();
    DareHeader GetHeader(long index);
    SequenceInfo MakeSequenceInfo();
    void MakeTrailer(ref DareTrailer trailer);
    SequenceIndexEntry Next(SequenceIndexEntry indexEntry);
    SequenceIndexEntry Position(long position);
    void PrepareFrame(DareHeader header, long framePosition);
    void PrepareFrame(SequenceWriter contextWrite);
    SequenceIndexEntry Previous(SequenceIndexEntry indexEntry);
    IEnumerable<SequenceIndexEntry> Select(long start, bool reverse = true, long count = -1, FilterIndexDelegate filter = null, bool skip = false);
    IEnumerable<Enveloped> SelectEnvelope(long minIndex, bool reverse = false);
    IEnumerable<SequenceIndexEntry> SelectFromUnread(FilterIndexDelegate evaluate = null);
    IEnumerable<SequenceIndexEntry> SelectIndex(long first, long count = -1);
    void VerifyPolicy();
    void VerifySequence();
    }