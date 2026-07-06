
namespace Goedel.Cryptography.Dare;

/// <summary>Sequence interface.</summary>
public interface ISequence {

    /// <summary>Count of the number of frames.</summary>
    long FrameCount { get; }

    /// <summary>Length of the sequence in bytes.</summary>
    long Length { get; }

    /// <summary>Deferred write.</summary>
    /// <param name="contextWrite">The write context.</param>
    /// <param name="contentMeta">The content metadata</param>
    /// <param name="data">The data</param>
    /// <param name="cloaked">Encrypted data.</param>
    /// <param name="dataSequences">Additional data sequences.</param>
    /// <returns>The envelope</returns>
    static abstract Enveloped Defer(
            SequenceWriterDeferred contextWrite, 
            ContentMeta contentMeta, 
            byte[] data, byte[] cloaked = null, List<byte[]> dataSequences = null);
    
    /// <summary>Append an entry.</summary>
    /// <param name="envelope">The envelope to append.</param>
    /// <param name="updateEnvelope">If true, updates a previous envelope.</param>
    /// <returns>Index of the appended entry.</returns>
    SequenceIndexEntry Append(Enveloped envelope, bool updateEnvelope = false);

    /// <summary>Append an entry from a data stream.</summary>
    /// <param name="input">The stream containing the data</param>
    /// <param name="contentLength">Length of the data</param>
    /// <param name="contentMeta">Content metadata</param>
    /// <param name="contentType">The content type</param>
    /// <param name="cloaked">Encrypted data.</param>
    /// <param name="dataSequences">Additional data sequences.</param>
    /// <param name="cryptoParameters">Cryptographic enhancements.</param>
    /// <returns>Index of the appended entry.</returns>
    SequenceIndexEntry AppendFromStream(Stream input, long contentLength, ContentMeta contentMeta = null, string contentType = null, byte[] cloaked = null, List<byte[]> dataSequences = null, CryptoParameters cryptoParameters = null);

    /// <summary>Get the header of the frame number <paramref name="index"/></summary>
    /// <param name="index">The frame to return.</param>
    /// <returns>The header data.</returns>
    DareHeader GetHeader(long index);

    /// <summary>Select data from the sequence.</summary>
    /// <param name="start">The start of the sequence.</param>
    /// <param name="reverse">If true, return selections backwards.</param>
    /// <param name="count">Number of entries to return.</param>
    /// <param name="filter">Optional filter delegate.</param>
    /// <param name="skip"></param>
    /// <returns>The enumerable.</returns>
    IEnumerable<SequenceIndexEntry> Select(
            long start, 
            bool reverse = true, 
            long count = -1, 
            FilterIndexDelegate filter = null, 
            bool skip = false);

    }