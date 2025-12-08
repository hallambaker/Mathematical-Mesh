
namespace Goedel.Cryptography.Dare;

public interface ISequence {

    long FrameCount { get; }

    long Length { get; }

    static abstract Enveloped Defer(SequenceWriterDeferred contextWrite, ContentMeta contentMeta, byte[] data, byte[] cloaked = null, List<byte[]> dataSequences = null);
      SequenceIndexEntry Append(Enveloped envelope, bool updateEnvelope = false);
    SequenceIndexEntry AppendFromStream(Stream input, long contentLength, ContentMeta contentMeta = null, string contentType = null, byte[] cloaked = null, List<byte[]> dataSequences = null, CryptoParameters cryptoParameters = null);

    DareHeader GetHeader(long index);

    IEnumerable<SequenceIndexEntry> Select(long start, bool reverse = true, long count = -1, FilterIndexDelegate filter = null, bool skip = false);

    }