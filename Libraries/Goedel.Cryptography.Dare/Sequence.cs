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

#region // enumerations


/// <summary>File index modes</summary>
public enum IndexType {
    /// <summary>No index</summary>
    None,
    /// <summary>Index table of frame positions</summary>
    Position,
    /// <summary>There is an index table of positions and an index table for some specified labels.</summary>
    Partial,
    /// <summary>There is an index table of positions and an index table for all labels specified in the file.</summary>
    Complete
    }


/// <summary>
/// Class to allow enumeration of Sequence frames
/// </summary>
public class SequenceFrame {
    /// <summary>The current write frame index (writes are always
    /// appended to the end of the file.</summary>
    public long FrameCount;

    /// <summary>The byte offset from the start of the file for the 
    /// first byte of the current frame.</summary>
    public long Position;

    /// <summary>The current frame data</summary>
    public byte[] FrameData;

    /// <summary>The current frame headerData as binary data</summary>
    public byte[] FrameHeader;

    /// <summary>The current frame headerData as a parsed object.</summary>
    public DareHeader Header;

    /// <summary>The current frame trailerData as a parsed object.</summary>
    public DareTrailer Trailer;
    }

#endregion

/// <summary>
/// Interface describing methods used by <see cref="PersistenceStore"/> and related
/// object stores to update status.
/// </summary>
public interface IInternSequenceIndexEntry {

    /// <summary>
    /// Factory delegate returning a new <see cref="SequenceIndexEntry"/> instance.
    /// </summary>
    public SequenceIndexEntryFactoryDelegate SequenceIndexEntryFactory { get; }


    /// <summary>
    /// Intern the element <paramref name="sequenceIndexEntry"/> in the store.
    /// </summary>
    /// <param name="sequenceIndexEntry">The element to intern.</param>
    public void Intern(SequenceIndexEntry sequenceIndexEntry);



    }


/// <summary>
/// Base class for Sequence file implementations
/// </summary>
public abstract class Sequence : Disposable, IEnumerable<SequenceIndexEntry> {

    #region // Properties
    #region // File and stream related

    ///<summary>Name of the underlying file (may be used to reconnect to file)</summary> 
    public string Filename { get; set; }

    /// <summary>The underlying file stream</summary>
    protected JbcdStream JbcdStream { get; init; }

    ///<summary>The current read position.</summary> 
    public long PositionRead => JbcdStream.PositionRead;

    ///<summary>The current write position.</summary> 
    public long PositionWrite => JbcdStream.PositionWrite;

    ///<summary>The length.</summary> 
    public long Length => JbcdStream.Length;

    ///<summary>If true, the underlying JCBDStream has been disposed.</summary> 
    public bool StreamDisposed { get; protected set; } = false;

    ///<summary>If true, the underlying stream has been disposed.</summary> 
    public bool StreamIsDisposed => JbcdStream.IsDisposed;
    /// <summary>
    /// The underlying stream reader/writer for the Sequence. This will be disposed of when
    /// the Sequence is released.
    /// </summary>
    protected JbcdStream DisposeJBCDStream { get; set; }

    /// <summary>
    /// If set to true, the instance will dispose the underlying <see cref="JbcdStream"/>
    /// instance when disposed, otherwise not.
    /// </summary>
    public bool DisposeStream {
        get => DisposeJBCDStream != null;
        set => DisposeJBCDStream = value ? JbcdStream : null;
        }

    #endregion
    #region // Cryptography
    /// <summary>The encoding to use for creating the FrameHeader entry</summary>
    public DataEncoding DataEncoding { get; protected set; }

    ///<summary>If true, decrypt payload contents.</summary> 
    public bool Decrypt { get; init; }

    ///<summary>If true, the Sequence type requires a digest calculated on the payload.</summary> 
    public virtual bool DigestRequired => false;

    /// <summary>
    /// The cryptography parameters.
    /// </summary>
    public CryptoParametersSequence CryptoParametersSequence = null;

    /// <summary>
    /// The default cryptographic stack
    /// </summary>
    public CryptoStack CryptoStack = null;

    ///<summary>The key location instance.</summary>
    public IKeyLocate KeyLocate { get; protected set; }

    ///<summary>The policy to apply when adding to the sequence.</summary> 
    public DarePolicy DarePolicy { get; protected set; }


    #endregion
    #region // Indexing and convenience accessors

    ///<summary>Index entry of the first frame.</summary> 
    public SequenceIndexEntry SequenceIndexEntryFirst { get; protected set; }

    ///<summary>Index entry of the last frame.</summary> 
    public SequenceIndexEntry SequenceIndexEntryLast { get; protected set; }

    /// <summary>
    /// The first Sequence headerData. This is read only since it is fixed after
    /// the record is written.
    /// </summary>
    public DareHeader HeaderFirst => SequenceIndexEntryFirst.Header;

    ///<summary>The last Sequence headerData.</summary>
    public DareHeader HeaderFinal => SequenceIndexEntryLast?.Header;

    ///<summary>The trailerData section of the last envelope in the Sequence.</summary> 
    public DareTrailer TrailerLast => SequenceIndexEntryLast.Trailer;

    /// <summary>The value of the last frame index plus 1</summary>
    public virtual long FrameCount => FrameIndexLast + 1;

    ///<summary>The last frame in the Sequence</summary>
    public virtual long FrameIndexLast => HeaderFinal?.Index ?? 0;

    ///<summary>The bitmask identifier of the Sequence.</summary> 
    public byte[] Bitmask => HeaderFirst.Bitmask;

    ///<summary>The last frame indexed in the forwards direction</summary> 
    protected SequenceIndexEntry IndexedFromStart { get; set; } = null;

    ///<summary>The last frame indexed in the backwards direction</summary> 
    protected SequenceIndexEntry IndexedFromEnd { get; set; } = null;


    #endregion
    #region // Dictionaries

    ///<summary>First index number to index entry.</summary> 
    public Dictionary<long, SequenceIndexEntry> FrameIndexToEntry = new();

    ///<summary>Sequence position to index entry.</summary> 
    public Dictionary<long, SequenceIndexEntry> SequencePositionStartToEntry = new();

    ///<summary>Sequence position to index entry.</summary> 
    public Dictionary<long, SequenceIndexEntry> SequencePositionEndToEntry = new();

    #endregion
    #region // Delegates

    ///<summary>Delegate called to create a Sequence entry for a catalog or store.</summary> 
    public SequenceIndexEntryFactoryDelegate SequenceIndexEntryFactoryDelegate { get; init; } = SequenceIndexEntry.Factory;

    ///<summary>Delegate to intern an entry into a sequence backing store.</summary> 
    public IInternSequenceIndexEntry InternDelegate { get; set; }

    #endregion
    #endregion
    /// <summary>
    /// Default constructor.
    /// </summary>
    public Sequence() {
        }


    #region // IDisposable
    /// <summary>
    /// The class specific disposal routine.
    /// </summary>
    protected override void Disposing() {
        if (DisposeJBCDStream is not null) {
            DisposeJBCDStream.Dispose();
            StreamDisposed = true;
            }
        }
    #endregion
    #region // IEnumerable and filtering enumerations

    /// <summary>
    /// Returns an enumerator over the Sequence contents starting with the
    /// first frame.
    /// </summary>
    /// <returns>The enumerator</returns>
    public virtual IEnumerator<SequenceIndexEntry> GetEnumerator() =>
        new SequenceEnumeratorIndex(this, SequenceIndexEntryFirst, false);

    // Must also implement IEnumerable.GetEnumerator, but implement as a private method.
    private IEnumerator GetEnumerator1() => this.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();


    /// <summary>
    /// Constructor, returns an enumerator on this sequence, starting
    /// with the frame numbered <paramref name="start"/>. If <paramref name="reverse"/> is true, 
    /// results are returned from the last match first.
    /// </summary>
    /// <param name="start">The starting point for the enumeration. If it matches, this will 
    /// be the first result returned.</param>
    /// <param name="reverse">If true, return results in the reverse order.</param>
    /// <param name="filter">If not null, specifies a filtering function on the 
    /// store entries.</param>
    /// <param name="skip">If true, the search MAY optimize search time by performing a binary
    /// search on the records. Note however that since this will cause entry update entries to
    /// be skipped, the status might be affected by one or more skipped records.</param>
    /// <param name="count">Maximum number of records to return.</param>
    public virtual IEnumerable<SequenceIndexEntry> Select(
                long start,
                bool reverse = true,
                long count = -1,
                FilterIndexDelegate filter = null,
                bool skip = false) => new SequenceEnumeratorIndex(
                    this, start, reverse, count, filter, skip);

    /// <summary>
    /// Return an enumerator that reads the spool from frame 1 (the second frame) in the 
    /// forwards direction.
    /// </summary>
    public virtual IEnumerable<SequenceIndexEntry> ReadForward =>
            Select(1, false);


    /// <summary>
    /// Return an enumerator that returns items that have not previously been read.
    /// </summary>
    public virtual IEnumerable<SequenceIndexEntry> SelectFromUnread(
            FilterIndexDelegate evaluate = null) => new SequenceEnumeratorIndex(
                    this, IndexedFromEnd.Previous(), true);

    /// <summary>
    /// Returns an enumerator over the Sequence contents starting with the
    /// first frame.
    /// </summary>
    /// <returns>The enumerator</returns>
    public virtual IEnumerable<SequenceIndexEntry> SelectIndex(long first, long count = -1) =>
            new SequenceEnumeratorIndex(this, first, count: count);


    /// <summary>
    /// Return an enumerator with the specified selectors.
    /// </summary>
    /// <param name="minIndex">The minimum index.</param>
    /// <param name="reverse">If true, read the Sequence from the end.</param>
    /// <returns>The enumerator.</returns>
    public IEnumerable<DareEnvelope> SelectEnvelope(long minIndex, bool reverse = false) =>
        new SequenceEnumerateEnvelope(this, minIndex, reverse);




    #endregion

    #region // Parameterized factory methods

    /// <summary>
    /// Open or create Sequence according to the setting of FileStatus. The underlying 
    /// filestreams will be disposed of automatically when the Sequence is disposed.
    /// </summary>
    /// <param name="fileName">The file name.</param>
    /// <param name="fileStatus">The file access mode.</param>
    /// <param name="keyLocate">The key collection to be used to resolve requests
    /// for decryption keys. If unspecified, the default KeyCollection is used.</param>
    /// <param name="policy">The cryptographic policy to govern the Sequence.</param>
    /// <param name="sequenceType">The Sequence type to create if the Sequence does
    /// not already exist.</param>
    /// <param name="contentType">The content type to declare if a new Sequence is
    /// created.</param>
    /// <param name="decrypt">If true, enable decryption of Sequence payload,
    /// otherwise return payload contents as plaintext.</param>
    /// <param name="create">If true, create a Sequence file if none already exists</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    /// <param name="store">Context information to be passed in when creating sequence index entries.</param>
    /// <returns>The new Sequence.</returns>
    public static Sequence Open(
                    string fileName,
                    FileStatus fileStatus = FileStatus.Read,
                    IKeyLocate? keyLocate = null,
                    //CryptoParameters cryptoParameters = null,
                    SequenceType sequenceType = SequenceType.Unknown,
                    DarePolicy? policy = null,
                    string? contentType = null,
                    bool decrypt = true,
                    bool create = true,
                    byte[] bitmask = null,
                    IInternSequenceIndexEntry store = null) {

        if (!create && !File.Exists(fileName)) {
            return null;
            }
        var jbcdStream = new JbcdStream(fileName, fileStatus: fileStatus);
        try {
            Sequence sequence;

            // Create new Sequence if empty or read the old one.
            if (jbcdStream.Length == 0) {
                keyLocate ??= policy?.KeyLocation;
                sequence = NewSequence(jbcdStream, decrypt: decrypt,
                    keyLocate: keyLocate, sequenceType: sequenceType, policy: policy,
                    contentType: contentType, bitmask: bitmask,
                    store: store
                    );
                }
            else {
                sequence = OpenExisting(jbcdStream, keyLocate, decrypt: decrypt,
                    store: store);
                }
            (sequence.KeyCollection == keyLocate).AssertTrue(NYI.Throw);
            sequence.DisposeJBCDStream = jbcdStream;
            sequence.Filename = fileName;
            sequence.IndexedFromStart = sequence.SequenceIndexEntryFirst;
            sequence.IndexedFromEnd = sequence.SequenceIndexEntryLast;
            sequence.DarePolicy = policy;
            return sequence;
            }
        catch (Exception exception) {
            jbcdStream?.Dispose();

            throw new AccessRefused($"Failed to open {fileName}", exception);
            }
        }

    /// <summary>
    /// Open or create Sequence according to the setting of FileStatus. The underlying 
    /// filestreams will be disposed of automatically when the Sequence is disposed.
    /// </summary>
    /// <param name="jbcdStream">The stream to use to access the Sequence.</param>
    /// <param name="keyLocate">The key collection to be used to resolve keys</param>
    /// <returns>The new Sequence.</returns>
    public static Sequence Open(
                    JbcdStream jbcdStream,
                    IKeyLocate keyLocate = null) {


        var sequence = OpenExisting(jbcdStream, keyLocate);
        sequence.DisposeJBCDStream = jbcdStream;

        return sequence;
        }

    /// <summary>
    /// Return the frame count of the sequence in the file <paramref name="fileName"/> if it exists,
    /// otherwise zero.
    /// </summary>
    /// <param name="fileName">The sequence to report the frame count of.</param>
    /// <returns>The value of the last frame index plus 1.</returns>
    public static long GetFrameCount(
                    string fileName) {
        if (!File.Exists(fileName)) {
            return 0;
            }
        var jbcdStream = new JbcdStream(fileName, FileStatus.Read);
        var sequenceIndexEntryLast = SequenceIndexEntry.ReadLast(jbcdStream, sequence: SequenceDummy);
        return sequenceIndexEntryLast.Index + 1;

        }



    /// <summary>
    /// The default key collection to use for decryption
    /// </summary>
    protected IKeyLocate KeyCollection;

    /// <summary>
    /// Open an existing Sequence file.
    /// </summary>
    /// <param name="fileName">The file to open as a Sequence.</param>
    /// <param name="fileStatus">The file status.</param>
    /// <param name="keyCollection">The key collection to be used to decrypt the contents
    /// of the Sequence.</param>
    /// <param name="decrypt">If true configure to enable decryption of bodies.</param>
    /// <param name="store">Context information to be passed in when creating sequence index entries.</param>
    /// <returns>The Sequence object if found. Otherwise, an exception is thrown.</returns>
    public static Sequence OpenExisting(
            string fileName,
            FileStatus fileStatus = FileStatus.Read,
            IKeyLocate keyCollection = null, bool decrypt = true,
                    IInternSequenceIndexEntry store = null) {
        var jbcdStream = new JbcdStream(fileName, fileStatus: fileStatus);
        if (jbcdStream.Length == 0) {
            return new SequenceNull();
            }
        var sequence = OpenExisting(jbcdStream, keyCollection, decrypt: decrypt, store: store);
        sequence.DisposeJBCDStream = jbcdStream;

        return sequence;
        }

    static Sequence SequenceDummy = new SequenceList() {
        SequenceIndexEntryFactoryDelegate = SequenceIndexEntry.Factory
        };


    /// <summary>
    /// Open an existing Sequence according to the information contained in the next frame to be read.
    /// </summary>
    /// <param name="jbcdStream">The frame reader. Since this is passed to the
    /// method to create the class it is not disposed with the Sequence using it.</param>
    /// <param name="keyCollection">The key collection to be used to resolve requests
    /// for decryption keys. If unspecified, the default KeyCollection is used.</param>
    /// <param name="decrypt">If true, enable decryption of Sequence payload,
    /// otherwise return payload contents as plaintext.</param>
    /// <param name="store">Context information to be passed in when creating sequence index entries.</param>
    /// <returns>The sequence created</returns>
    public static Sequence OpenExisting(
                    JbcdStream jbcdStream,
                    IKeyLocate? keyCollection = null,
                    bool decrypt = true,
                    IInternSequenceIndexEntry store = null) {
        var sequenceIndexEntryFactoryDelegate = store?.SequenceIndexEntryFactory ?? SequenceIndexEntry.Factory;
        decrypt.Future();

        var sequenceIndexEntryFirst = SequenceIndexEntry.Read(jbcdStream, 0, sequence: SequenceDummy);

        SequenceIndexEntry sequenceIndexEntryLast = null;
        if (jbcdStream.Length > sequenceIndexEntryFirst.FramePositionNext) {
            sequenceIndexEntryLast = SequenceIndexEntry.ReadLast(jbcdStream, sequence: SequenceDummy);
            }

        //var frameZero = jbcdStream.ReadDareEnvelope();
        var sequenceHeaderFirst = sequenceIndexEntryFirst.Header;
        var sequenceInfo = sequenceHeaderFirst.SequenceInfo;
        var sequenceType = sequenceInfo.ContainerType.ToSequenceType();


        var cryptoParametersSequence =
            new CryptoParametersSequence(sequenceType, sequenceHeaderFirst, true, keyCollection);

        // Create the Sequence.
        var sequence = MakeNewSequence(jbcdStream, decrypt,
                     sequenceIndexEntryFactoryDelegate,
                     sequenceType: sequenceType);
        sequence.InternDelegate = store;

        // Common initialization
        sequenceIndexEntryFirst.Sequence = sequence;

        sequence.SequenceIndexEntryFirst = SequenceIndexEntry.Bind(sequenceIndexEntryFirst,
                    sequenceIndexEntryFactoryDelegate);

        if (sequenceIndexEntryLast is not null) {
            sequenceIndexEntryLast.Sequence = sequence;
            sequence.SequenceIndexEntryLast = SequenceIndexEntry.Bind(sequenceIndexEntryLast,
                            sequenceIndexEntryFactoryDelegate);
            }
        else {
            sequence.SequenceIndexEntryLast = sequence.SequenceIndexEntryFirst;
            }

        sequence.KeyLocate = keyCollection;
        sequence.KeyCollection = keyCollection;
        sequence.CryptoParametersSequence = cryptoParametersSequence;

        sequence.FillDictionary();

        return sequence;
        }

    /// <summary>
    /// Create a new Sequence file of the specified type and write the initial
    /// data record
    /// </summary>
    /// <param name="filename">The file to open</param>
    /// <param name="fileStatus">The file status.</param>
    /// <param name="payload">Optional data payload. </param>
    /// <param name="contentType">Content type of the optional data payload</param>
    /// <param name="sequenceType">The Sequence type.</param>
    /// <param name="policy">The cryptographic policy to be applied to the Sequence.</param>
    /// <param name="dataEncoding">The data encoding.</param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked headerData.</param>
    /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
    ///     as an EDSS headerData entry.</param>
    /// <param name="decrypt">If true, decrypt the Sequence payload contents.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    /// <exception cref="InvalidFileModeException">The file mode specified was not valid.</exception>
    public static Sequence NewSequence(
                    string filename,
                    FileStatus fileStatus,
                    SequenceType sequenceType = SequenceType.Chain,
                    DarePolicy? policy = null,
                    byte[]? payload = null,
                    string? contentType = null,
                    DataEncoding dataEncoding = DataEncoding.JSON,
                    byte[]? cloaked = null,
                    List<byte[]>? dataSequences = null,
                    bool decrypt = true,
                    byte[] bitmask = null
                    ) {

        Assert.AssertTrue(fileStatus == FileStatus.New | fileStatus == FileStatus.Overwrite,
            InvalidFileModeException.Throw);

        var jbcdStream = new JbcdStream(filename, fileStatus);
        var sequence = NewSequence(
            jbcdStream, decrypt: decrypt, sequenceType: sequenceType, policy: policy, payload: payload, contentType: contentType, dataEncoding: dataEncoding,
            cloaked: cloaked, dataSequences: dataSequences);

        sequence.DisposeJBCDStream = jbcdStream;

        return sequence;
        }



    /// <summary>
    /// Create a new Sequence file of the specified type and write the initial
    /// data record
    /// </summary>
    /// <param name="jbcdStream">The underlying file stream. This MUST be opened
    /// in a read access mode and should have exclusive write access. All existing
    /// content in the file will be overwritten.</param>
    /// <param name="keyLocate">The key collection to be used to resolve requests
    /// for decryption keys. If unspecified, the default KeyCollection is used.</param>
    /// <param name="payload">Optional data payload. </param>
    /// <param name="dataEncoding">The data encoding.</param>
    /// <param name="contentType">Content type of the optional data payload</param>
    /// <param name="sequenceType">The Sequence type. This determines whether
    /// a tree index is to be created or not and if so, whether </param>
    /// <param name="policy">The cryptographic policy to govern the Sequence.</param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked headerData.</param>
    /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
    ///     as an EDSS headerData entry.</param>
    /// <param name="decrypt">If true, decrypt the Sequence payload contents.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    /// <param name="store">Context information to be passed in when creating sequence index entries.</param>
    /// <param name="jsonObject">An object to be serialized to form the first payload value.</param>
    public static Sequence NewSequence(
                    JbcdStream jbcdStream,
                    IKeyLocate? keyLocate = null,
                    SequenceType sequenceType = SequenceType.Chain,
                    DarePolicy? policy = null,
                    byte[]? payload = null,
                    string? contentType = null,
                    DataEncoding dataEncoding = DataEncoding.JSON,
                    byte[]? cloaked = null,
                    List<byte[]>? dataSequences = null,
                    bool decrypt = true,
                    byte[] bitmask = null,
                    JsonObject jsonObject = null,
                    IInternSequenceIndexEntry store = null) {
        var sequenceIndexEntryFactoryDelegate = store?.SequenceIndexEntryFactory ?? SequenceIndexEntry.Factory;
        dataEncoding = dataEncoding.Default();

        // Initialize the header
        var sequenceInfo = new SequenceInfo() {
            ContainerType = sequenceType.ToLabel(),
            Index = 0,
            DataEncoding = dataEncoding.ToString()
            };

        var header = new DareHeader() {
            SequenceInfo = sequenceInfo,
            Policy = policy,
            ContentMeta = new ContentMeta() {
                ContentType = contentType
                },
            Bitmask = bitmask
            };

        // Initialize the sequence
        var sequence = MakeNewSequence(jbcdStream, decrypt,
                     sequenceIndexEntryFactoryDelegate,
                     sequenceType: sequenceType);


        sequence.InternDelegate = store;
        sequence.CryptoParametersSequence =
            new CryptoParametersSequence(sequenceType, header);
        sequence.DataEncoding = dataEncoding;
        sequence.KeyCollection = keyLocate ?? policy?.KeyLocation;
        sequence.CryptoStack = header.BindEncoder(sequence.CryptoParametersSequence,
                cloaked, dataSequences);

        // prepare the payload
        payload ??= jsonObject?.GetBytes(dataEncoding, true);
        payload = header.EnhanceBody(payload, out var trailer);

        // Finish trailer
        sequence.MakeTrailer(ref trailer);

        // Write out the first frame to the container.
        sequence.SequenceIndexEntryFirst = sequence.Append(header,
            payload, trailer, dataEncoding, jsonObject);
        (sequence.SequenceIndexEntryLast == sequence.SequenceIndexEntryFirst).AssertTrue(NYI.Throw);

        return sequence;
        }




    /// <summary>
    /// Create a new Sequence file of the specified type and write the initial
    /// data record
    /// </summary>
    /// <param name="jbcdStream">The underlying JBCDStream stream. This MUST be opened
    /// in a read access mode and should have exclusive read access. All existing
    /// content in the file will be overwritten.</param>
    /// <param name="sequenceType">The Sequence type. This determines whether
    /// a tree index is to be created or not and if so, whether </param>
    /// <returns>The newly constructed Sequence.</returns>
    /// <param name="decrypt">If true, decrypt the Sequence payload contents.</param>
    /// <param name="sequenceIndexEntryFactoryDelegate">Delegate to create index entries for
    /// items in the sequence.</param>
    public static Sequence MakeNewSequence(
                    JbcdStream jbcdStream,
                    bool decrypt,
                    SequenceIndexEntryFactoryDelegate sequenceIndexEntryFactoryDelegate
,
                    SequenceType sequenceType = SequenceType.Merkle) =>
        sequenceType switch {
            SequenceType.List => new SequenceList() {
                JbcdStream = jbcdStream,
                Decrypt = decrypt,
                SequenceIndexEntryFactoryDelegate = sequenceIndexEntryFactoryDelegate

                },
            SequenceType.Digest => new SequenceDigest() {
                JbcdStream = jbcdStream,
                Decrypt = decrypt,
                SequenceIndexEntryFactoryDelegate = sequenceIndexEntryFactoryDelegate
                },
            SequenceType.Chain => new SequenceChain() {
                JbcdStream = jbcdStream,
                Decrypt = decrypt,
                SequenceIndexEntryFactoryDelegate = sequenceIndexEntryFactoryDelegate
                },
            SequenceType.Tree => new SequenceTree() {
                JbcdStream = jbcdStream,
                Decrypt = decrypt,
                SequenceIndexEntryFactoryDelegate = sequenceIndexEntryFactoryDelegate
                },
            SequenceType.Merkle => new SequenceMerkleTree() {
                JbcdStream = jbcdStream,
                Decrypt = decrypt,
                SequenceIndexEntryFactoryDelegate = sequenceIndexEntryFactoryDelegate
                },
            _ => throw new InvalidContainerTypeException()
            };





    /// <summary>
    /// Create a new Sequence with the name <paramref name="fileName"/> and
    /// append <paramref name="envelopes"/> to the end of the Sequence.
    /// </summary>
    /// <param name="fileName">Name of the Sequence to create</param>
    /// <param name="envelopes">Envelopes to add</param>
    /// <param name="fileStatus">File status (used for concurrency locking)</param>
    /// <param name="keyLocate">The key location collection to be used to resolve keys.</param>
    /// <returns>The created Sequence</returns>
    public static Sequence MakeNewSequence(
                    string fileName,
                    IKeyLocate keyLocate,
                    List<DareEnvelope> envelopes,
                    FileStatus fileStatus = FileStatus.CreateNew) {
        var jbcdStream = new JbcdStream(fileName, fileStatus: fileStatus);
        var sequence = new SequenceMerkleTree() {
            JbcdStream = jbcdStream,
            KeyLocate = keyLocate,
            DisposeJBCDStream = jbcdStream
            };

        // Append the envelopes setting the first sequence entry index correctly.

        var first = envelopes[0];
        sequence.SequenceIndexEntryFirst = sequence.Append(first.Header, first.Body, first.Trailer);
        sequence.Append(envelopes, 1);

        return sequence;
        }

    #endregion
    #region // Navigation and enumeration methods




    /// <summary>
    /// The number of bytes to be reserved for the trailerData.
    /// </summary>
    /// <returns>The number of bytes to reserve</returns>
    public virtual DareTrailer FillDummyTrailer(CryptoStack cryptoStack) => null;

    /// <summary>
    /// The dummy trailerData to add to the end of the frame.
    /// </summary>
    /// <returns></returns>
    public virtual void MakeTrailer(ref DareTrailer trailer) {
        }

    /// <summary>
    /// Return a bounded reader on the sequence data.
    /// </summary>
    /// <param name="DataPosition">The start position for reading.</param>
    /// <param name="DataLength">The maximum number of bytes to read (will return
    /// EOF if exceeded)</param>
    /// <returns>The bounded reader.</returns>
    public StreamReaderBounded FramerGetReader(long DataPosition, long DataLength) =>
        JbcdStream.FramerGetReader(DataPosition, DataLength);

    /// <summary>
    /// Initialize a <see cref="SequenceInfo"/> instance for the current Sequence
    /// position.
    /// </summary>
    /// <returns>The initialized instance.</returns>
    public virtual SequenceInfo MakeSequenceInfo() => new() {
        Index = FrameCount
        };







    /// <summary>
    /// Prepare the Sequence frame information in <paramref name="sequenceInfo"/>.
    /// </summary>
    /// <param name="sequenceInfo">The Sequence information to be prepared.</param>
    protected virtual void PrepareFrame(SequenceInfo sequenceInfo) {
        }



    /// <summary>
    /// Read the frame at the position <paramref name="position"/>. If <paramref name="previous"/>
    /// is true, return the previous frame, otherwise return the next frame.
    /// </summary>
    /// <param name="position">The position to read from.</param>
    /// <param name="previous">If true read the previous frame, otherwise, read the
    /// next.</param>
    /// <returns>The frame read.</returns>
    protected SequenceIndexEntry ReadAtPosition(
                long position,
                bool previous = false) {
        if (position >= JbcdStream.Length | position < 0) {
            return null;
            }

        var result = SequenceIndexEntry.Read(JbcdStream, position, previous, this);

        // Update the dictionaries
        Intern(result, previous);

        return result;

        }


    #endregion

    #region // Write Methods

    /// <summary>
    /// Intern the entry <paramref name="indexEntry"/> in the sequence dictionaries.
    /// 
    /// </summary>
    /// <param name="indexEntry"></param>
    protected void Intern(SequenceIndexEntry indexEntry) {
        SequencePositionStartToEntry.Add(indexEntry.FramePosition, indexEntry);
        SequencePositionEndToEntry.Add(indexEntry.FramePosition + indexEntry.FrameLength, indexEntry);
        FrameIndexToEntry.Add(indexEntry.Index, indexEntry);


        InternDelegate?.Intern(indexEntry);
        }


    /// <summary>
    /// Intern the element <paramref name="indexEntry"/> into the sequence.
    /// </summary>
    /// <param name="indexEntry">The index entry.</param>
    /// <param name="previous">Prior instance of the underlying object.</param>
    protected virtual void Intern(SequenceIndexEntry indexEntry, bool previous) {
        Intern(indexEntry);
        }

    #region // Atomic Append from envelope or data





    /// <summary>
    /// Append a fixed or empty payload to the sequence.
    /// </summary>
    /// <param name="header">The header data.</param>
    /// <param name="payload">The payload as bytes.</param>
    /// <param name="trailer">The trailer data.</param>
    /// <param name="dataEncoding">The encoding to use.</param>
    /// <param name="jsonObject">The object represented by the payload bytes. If
    /// <paramref name="jsonObject"/> is specified without <paramref name="payload"/>,
    /// the payload bytes are calculated automatically. Otherwise, it is assumed
    /// the value of <paramref name="payload"/> is correct.</param>
    /// <returns></returns>
    SequenceIndexEntry Append(
            DareHeader header,
            byte[] payload = null,
            DareTrailer trailer = null,
            DataEncoding dataEncoding = DataEncoding.Default,
            JsonObject jsonObject = null) {

        var framePosition = JbcdStream.Length;
        PrepareFrame(header, framePosition);

        // Change the signature so that what is passed in is ContentMeta and the header is
        // calculated from that.



        dataEncoding = dataEncoding == DataEncoding.Default ?
            DataEncoding : dataEncoding;

        var headerData = header?.GetBytes(dataEncoding, false);
        var trailerData = trailer?.GetBytes(dataEncoding, false);
        var dataPosition = JbcdStream.WriteWrappedFrame(headerData, payload, trailerData);
        var frameLength = JbcdStream.Length - framePosition;

        var result = SequenceIndexEntryFactoryDelegate(
                sequence: this,
                framePosition: framePosition,
                frameLength: frameLength,
                dataPosition: dataPosition,
                dataLength: payload?.Length ?? 0,
                header: header,
                trailer: trailer,
                jsonObject: jsonObject
                );

        SequenceIndexEntryLast = result;

        Intern(result);
        return result;
        }

    /// <summary>
    /// Write a previously prepared or validated Dare Envelope to the Sequence directly.
    /// </summary>
    /// <param name="envelope">The envelope to append to the Sequence</param>
    /// <param name="updateEnvelope">If true, update the headerData and trailerData of 
    /// <paramref name="envelope"/> to the computed values.</param>
    public virtual SequenceIndexEntry Append(DareEnvelope envelope, bool updateEnvelope = false) {

        //var headerData = envelope.Header as DareHeader; // fails ! need to copy over !!
        var headerIn = envelope.Header;
        var trailerIn = envelope.Trailer;

        var header = new DareHeader() {
            SequenceInfo = MakeSequenceInfo(),

            EnvelopeId = headerIn.EnvelopeId,
            EncryptionAlgorithm = headerIn.EncryptionAlgorithm,
            Salt = headerIn.Salt,
            Cloaked = headerIn.Cloaked,
            EDSS = headerIn.EDSS,
            Recipients = headerIn.Recipients,
            ContentMeta = headerIn.ContentMeta,
            ContentMetaData = headerIn.ContentMetaData,
            Received = headerIn.Received ?? System.DateTime.Now,
            WitnessValue = trailerIn?.WitnessValue ?? headerIn.WitnessValue,
            Signatures = trailerIn?.Signatures ?? headerIn.Signatures,
            SignedData = trailerIn?.SignedData ?? headerIn.SignedData,
            PayloadDigest = trailerIn?.PayloadDigest ?? headerIn.PayloadDigest,
            ApexDigest = trailerIn?.ApexDigest ?? headerIn.ApexDigest,
            DigestAlgorithm = headerIn.DigestAlgorithm
            };

        // we need to recompute the PayloadDigest under the Sequence DigestAlgorithm
        var trailer = new DareTrailer() {
            };
        //MakeTrailer(ref trailer);

        var result = Append(header, envelope.Body, trailer, jsonObject: envelope.JsonObject);

        if (updateEnvelope) {
            envelope.Header = header;
            envelope.Trailer = trailer;
            }

        return result;

        }


    /// <summary>
    /// Append the envelopes <paramref name="envelopes"/> to the Sequence starting
    /// with the <paramref name="index"/>th envelope.
    /// </summary>
    /// <param name="envelopes">The enveolpes to append</param>
    /// <param name="index">The starting point at which to begin appending.</param>
    /// <param name="unverified">If true, do not attempt to verify the integrity or authenticity
    /// of the envelopes being appended.</param>
    public void Append(List<DareEnvelope> envelopes, long index = 0, bool unverified = true) {

        for (var i = (int)index; i < envelopes.Count; i++) {

            if (unverified | envelopes[i].Index > FrameIndexLast) {

                Append(envelopes[i]);
                }
            //else {
            //    Console.WriteLine($"   $$$$$$ >>>> {envelopes[i].Index} already added");
            //    }
            }
        }



    #endregion
    #region // Incremental append from stream


    /// <summary>
    /// Header of the framer being written
    /// </summary>

    SequenceIndexEntry IncrementalAppendIndex;


    /// <summary>
    /// Begin appending a data frame.
    /// </summary>
    /// <remarks>This call is not thread safe. It is the responsibility of the caller
    /// to ensure that only one process writes to the Sequence at once and that no other
    /// process has access.</remarks>
    /// <param name="dataLength">The plaintext payload data length. the final payload
    /// length may be longer as a result of padding.</param>
    /// <param name="contentInfo">Pre-populated Sequence headerData.</param>
    /// <param name="contentType">The payload content type.</param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked headerData.</param>
    /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
    ///     as an EDSS headerData entry.</param>
    /// <param name="cryptoParameters">The cryptographic parameters.</param>
    /// <returns>The number of bytes written</returns>
    public long AppendBegin(
                    long dataLength,

                    ContentMeta contentInfo = null,
                    string contentType = null,
                    byte[] cloaked = null,
                    List<byte[]> dataSequences = null,
                    CryptoParameters cryptoParameters = null) {

        var index = FrameCount;

        contentInfo ??= new ContentMeta() {
            ContentType = contentType
            };

        var sequenceInfo = new SequenceInfo() {
            Index = index
            };

        var header = new DareHeader() {
            SequenceInfo = sequenceInfo,
            ContentMeta = contentInfo
            };


        var framePosition = JbcdStream.PositionWrite;

        // These should be paired.
        CryptoStack = header.BindEncoder(cryptoParameters ?? CryptoParametersSequence,
            cloaked, dataSequences);
        PrepareFrame(header, framePosition); // Perform Sequence type specific processing.

        var payloadLength = header.OutputLength(dataLength);
        var dummyTrailer = FillDummyTrailer(CryptoStack);
        var lengthTrailer = dummyTrailer == null ? -1 : dummyTrailer.GetBytes(false).Length;
        var dataPayload = header.GetBytes(false);
        var (frameLength, dataPosition) = JbcdStream.WriteWrappedFrameBegin(dataPayload, payloadLength, lengthTrailer);
        header.MakeBodyWriter(JbcdStream.StreamWrite);

        IncrementalAppendIndex = SequenceIndexEntryFactoryDelegate(
            sequence: this,
            framePosition: framePosition,
            frameLength: frameLength,
            dataPosition: dataPosition,
            dataLength: dataLength,
            header: header);

        return index;
        }

    /// <summary>
    /// Process record data. This method may be called any number
    /// of times but the total count of the number of items must match
    /// the Content Length specified in the original call.
    /// </summary>
    /// <param name="data">The data to procees</param>
    /// <param name="offset">Index of first byte to process.</param>
    /// <param name="count">Number of bytes to process.</param>
    void AppendProcess(byte[] data, int offset, int count) =>
        IncrementalAppendIndex.Header.BodyWriter.Writer.Write(data, offset, count);

    /// <summary>
    /// Complete appending a record.
    /// </summary>
    SequenceIndexEntry AppendEnd() {
        IncrementalAppendIndex.Header.CloseBodyWriter(out var trailer);
        MakeTrailer(ref trailer);
        var trailerData = trailer?.GetBytes(false);
        JbcdStream.WriteWrappedFrameEnd(trailerData);

        IncrementalAppendIndex.Trailer = trailer;
        SequenceIndexEntryLast = IncrementalAppendIndex;
        Intern(IncrementalAppendIndex);

        //Console.WriteLine($"Make frame [{IncrementalAppendIndex.FramePosition}+{IncrementalAppendIndex.FrameLength}]");

        return IncrementalAppendIndex;
        }

    /// <summary>
    /// Create a DareEnvelope to be added to the Sequence in deferred write mode.
    /// </summary>
    /// <param name="contextWrite">The Sequence write context the envelope is to be written in.</param>
    /// <param name="contentMeta">The content metadata.</param>
    /// <param name="data">The data plaintext payload.</param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked headerData.</param>
    /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
    ///     as an EDSS headerData entry.</param>
    /// <returns>The created envelope</returns>
    public static DareEnvelope Defer(
        SequenceWriterDeferred contextWrite,
        ContentMeta contentMeta,
        byte[] data,
        byte[] cloaked = null,
                    List<byte[]> dataSequences = null) {

        var sequenceInfo = contextWrite.PrepareSequenceInfo();
        contextWrite.SequenceHeader = new DareHeader() {
            SequenceInfo = sequenceInfo,
            ContentMeta = contentMeta
            };

        contextWrite.SequenceHeader.BindEncoder(contextWrite.CryptoParametersSequence, cloaked, dataSequences);
        contextWrite.StreamOpen();

        if (data != null) {
            using var buffer = new MemoryStream(data.Length + 32);
            var stream = contextWrite.SequenceHeader.MakeBodyWriter(buffer);
            stream.Write(data);
            contextWrite.StreamClose();
            return contextWrite.End(buffer.ToArray());
            }
        return contextWrite.End(null);
        }




    ///// <summary>
    ///// Append the headerData to the frame. This is called after the payload data
    ///// has been passed using AppendPreprocess.
    ///// </summary>
    //public virtual void CommitHeader(DareHeader sequenceHeader, SequenceWriter contextWrite) {
    //    }
    #endregion
    #region // Convenience methods to read/write to sequences.


    /// <summary>
    /// Append a new data frame payload to the end of the file.
    /// </summary>
    /// <param name="data">Ciphertext data to append.</param>
    /// <param name="contentMeta">Content metadata.</param>
    /// <param name="contentType">The payload content type.</param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked headerData.</param>
    /// <param name="dataSequences">Data sequences to be converted to an EDS and presented </param>
    /// <param name="cryptoParameters">The cryptographic parameters.</param>
    /// <returns>The number of bytes written.</returns>
    public SequenceIndexEntry Append(
                byte[] data,
                ContentMeta contentMeta = null,
                string contentType = null,
                byte[] cloaked = null,
                List<byte[]> dataSequences = null,
                CryptoParameters cryptoParameters = null) {

        using var InputStream = new MemoryStream(data) {
            Position = 0
            };

        var ContentLength = InputStream.Length;

        return AppendFromStream(InputStream, ContentLength, contentMeta, //cryptoParameters,
                contentType, cloaked, dataSequences, cryptoParameters);
        }


    /// <summary>
    /// Read data from the specified file and append to the Sequence.
    /// </summary>
    /// <param name="fileName">The file to append</param>
    /// <param name="contentInfo">Sequence headerData data.</param>
    /// <param name="contentType">The payload content type.</param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked headerData.</param>
    /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
    ///     as an EDSS headerData entry.</param>
    /// <returns>The number of bytes written.</returns>
    public SequenceIndexEntry AppendFile(string fileName,
            ContentMeta contentInfo = null,
            //CryptoParameters cryptoParameters = null,
            string contentType = null,
            byte[] cloaked = null,
            List<byte[]> dataSequences = null) {

        using var FileStream = fileName.OpenFileRead();
        var ContentLength = FileStream.Length;
        return AppendFromStream(FileStream, ContentLength, contentInfo, //cryptoParameters,
                contentType, cloaked, dataSequences);
        }


    /// <summary>
    /// Read data from the specified file and append to the Sequence.
    /// </summary>
    /// <param name="input">The stream to be read.</param>
    /// <param name="contentLength"> The number of bytes to read from <paramref name="input"/>.</param>
    /// <param name="contentMeta">Sequence headerData data.</param>
    /// <param name="contentType">The payload content type.</param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked headerData.</param>
    /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
    ///     as an EDSS headerData entry.</param>
    /// <param name="cryptoParameters">The cryptographic parameters.</param>
    /// <returns>The number of bytes written.</returns>
    /// <remarks>At present, the file stream MUST support the seek operation
    /// which is an issue that has to be removed.</remarks>
    public SequenceIndexEntry AppendFromStream(Stream input,
            long contentLength,
            ContentMeta contentMeta = null,
            string contentType = null,
            byte[] cloaked = null,
            List<byte[]> dataSequences = null,
                    CryptoParameters cryptoParameters = null) {
        var index = AppendBegin(contentLength, contentMeta,
                contentType, cloaked, dataSequences, cryptoParameters);
        input.ProcessRead(AppendProcess);
        var result = AppendEnd();

        return result;
        }

    #endregion

    #endregion

    #region // Abstract and Virtual methods

    /// <summary>
    /// Prepare the headerData information to write an envelope to a Sequence.
    /// </summary>
    public virtual void PrepareFrame(SequenceWriter contextWrite) {
        }

    /// <summary>
    /// Prepare the headerData information to write an envelope to a Sequence.
    /// </summary>
    public virtual void PrepareFrame(DareHeader header, long framePosition) {
        header.SequenceInfo ??= MakeSequenceInfo();
        }



    /// <summary>
    /// Return the headerData of frame with index <paramref name="index"/>.
    /// </summary>
    /// <param name="index">The index of the frame to be returned.</param>
    /// <returns>The requested headerData.</returns>
    public DareHeader GetHeader(long index) {
        var frame = Frame(index);
        return frame.Header;
        }


    /// <summary>
    /// Initialize the dictionaries used to manage the tree by registering the set
    /// of values leading up to the apex value.
    /// </summary>
    /// <param name="header">Final frame headerData</param>
    /// <param name="firstPosition">PositionRead of frame 1</param>
    /// <param name="positionLast">PositionRead of the last frame</param>
    protected abstract void FillDictionary(
                SequenceInfo header, long firstPosition, long positionLast);


    /// <summary>
    /// Initialize the dictionaries used to manage the tree by registering the set
    /// of values leading up to the apex value.
    /// </summary>
    protected abstract void FillDictionary();


    /// <summary>
    /// Verify that the file <paramref name="filename"/> is a DARE Sequence that
    /// is in compliance with its specified policy.
    /// </summary>
    /// <param name="filename">The Sequence to verify.</param>
    /// <param name="keyLocate">Key location to be used to resolve keys.</param>
    public static void VerifyPolicy(string filename, IKeyLocate keyLocate) {



        // open the Sequence
        using var sequence = Sequence.Open(filename, FileStatus.Read, keyLocate);

        sequence.VerifyPolicy();

        }

    /// <summary>
    /// Verify policy on the Sequence.
    /// </summary>
    public void VerifyPolicy() {
        var dictionary = new Dictionary<long, SequenceIndexEntry>();
        var darePolicy = HeaderFirst.Policy;
        SequenceIndexEntry lastFrame = null;

        var record = 0;
        // read each record in turn
        foreach (var frameIndex in this) {
            Verify(this, darePolicy, frameIndex, record, KeyCollection, dictionary);
            dictionary.Add(record, frameIndex);
            lastFrame = frameIndex;
            record++;
            }

        VerifyFinal(this, darePolicy, lastFrame);
        }

    static bool VerifyFinal(
            Sequence sequence,
            DarePolicy darePolicy,
            SequenceIndexEntry frameIndex) {
        sequence.Future();
        darePolicy.Future();
        frameIndex.Future();
        // here perform policy checks on the very last frame.

        return true;
        }

    static bool Verify(
        Sequence sequence,
        DarePolicy darePolicy,
        SequenceIndexEntry frameIndex,
        int record,

        IKeyLocate keyCollection,
        Dictionary<long, SequenceIndexEntry> dictionary) {

        keyCollection.Future();
        dictionary.Future();
        sequence.Future();


        bool encrypt = true;
        bool? keyExchange = null;

        var header = frameIndex.Header;
        header.AssertNotNull(SequenceDataCorrupt.Throw);

        var sequenceInfo = header.SequenceInfo;
        sequenceInfo.AssertNotNull(SequenceDataCorrupt.Throw);

        switch (darePolicy?.Encryption) {
            case DareConstants.PolicyEncryptionOnceTag: {
                keyExchange = (header.Index == 0);
                break;
                }
            case DareConstants.PolicyEncryptionIsolatedTag: {
                keyExchange = true;
                break;
                }

            case DareConstants.PolicyEncryptionNoneTag: {
                encrypt = false;
                break;
                }
            case DareConstants.PolicyEncryptionSessionTag: {
                keyExchange = null;
                break;
                }
            default: {
                encrypt = false;
                break;
                }
            }

        // check frame data
        (sequenceInfo.LIndex == record).AssertTrue(SequenceDataCorrupt.Throw);

        //TreePosition
        //ExchangePosition
        //IndexPosition


        // check payload digest (if present)



        // check compliance with encryption policy
        (frameIndex.IsEncrypted == encrypt).AssertTrue(SequenceDataCorrupt.Throw);
        (keyExchange == null || keyExchange == frameIndex.KeyExchange).AssertTrue(SequenceDataCorrupt.Throw);

        // check compliance with authentication policy



        return true;
        }


    /// <summary>
    /// Perform sanity checking on a list of Sequence headers.
    /// </summary>
    /// <param name="headers">List of headers to check</param>
    public abstract void CheckSequence(List<DareHeader> headers);

    /// <summary>
    /// Return the next entry folowing the index <paramref name="indexEntry"/>.
    /// </summary>
    /// <param name="indexEntry">The index entry.</param>
    /// <returns>The next index entry.</returns>
    public SequenceIndexEntry Next(SequenceIndexEntry indexEntry) {

        if (SequencePositionStartToEntry.TryGetValue(indexEntry.FramePositionNext, out var entry)) {
            return entry;
            }
        return ReadAtPosition(indexEntry.FramePositionNext);
        }


    /// <summary>
    /// Return the previous entry prior to the index <paramref name="indexEntry"/>.
    /// </summary>
    /// <param name="indexEntry">The index entry.</param>
    /// <returns>The previous index entry.</returns>
    public SequenceIndexEntry Previous(SequenceIndexEntry indexEntry) {

        if (SequencePositionEndToEntry.TryGetValue(indexEntry.FramePosition, out var entry)) {
            return entry;
            }
        if (indexEntry.FramePosition <= 0) {
            return null;
            }

        return ReadAtPosition(indexEntry.FramePosition, true);
        }

    /// <summary>
    /// Return a <see cref="SequenceIndexEntry"/> for the frame with index
    /// <paramref name="Index"/>
    /// </summary>
    /// <param name="Index">Index of the frame to return.</param>
    /// <param name="skip">If true, search process may skip entries to 
    /// locate faster (this may cause entry status to be missed).</param>
    /// <returns>The Frame index.</returns>
    public abstract SequenceIndexEntry Frame(long Index, bool skip = true);

    /// <summary>
    /// Return a <see cref="SequenceIndexEntry"/> for the last frame in the sequence.
    /// </summary>
    /// <returns>The Frame index.</returns>
    public abstract SequenceIndexEntry FrameLast();

    /// <summary>
    /// Return a <see cref="SequenceIndexEntry"/> for the frame at byte position 
    /// <paramref name="position"/> in the sequence file.
    /// </summary>
    /// <param name="position">The position from which to return the frame index.</param>
    /// <returns>The frame index.</returns>
    public abstract SequenceIndexEntry Position(long position);


    /// <summary>
    /// Verify Sequence contents by reading every frame starting with the first and checking
    /// for integrity. This is likely to take a very long time.
    /// </summary>
    public virtual void VerifySequence() {
        }

    #endregion

    #region // Utility and convenience methods

    /// <summary>
    /// Pretty print the Sequence specified to the console
    /// </summary>
    /// <param name="fileName">The Sequence file.</param>
    public static void ToConsole(string fileName) {
        var builder = new StringBuilder();
        ToBuilder(fileName, builder, 0);
        //Console.WriteLine(builder);
        }


    /// <summary>
    /// Pretty print the Sequence specified.
    /// </summary>
    /// <param name="fileName">The Sequence file.</param>
    /// <param name="builder">The stringbuilder to use.</param>
    /// <param name="indent">The indent level.</param>
    public static void ToBuilder(string fileName, StringBuilder builder, int indent) {
        using var jbcdStream = new JbcdStream(fileName, fileStatus: FileStatus.Read);
        var positionRead = jbcdStream.PositionRead;
        var envelope = jbcdStream.ReadDareEnvelope();
        while (envelope != null) {
            if (envelope?.Header?.SequenceInfo is var sequenceInfo) {
                builder.AppendIndent(indent, $"[{sequenceInfo.LIndex}]  <{positionRead}-{jbcdStream.PositionRead}>");
                builder.AppendIndent(indent + 1, $"Tree Position:{sequenceInfo.TreePosition}");
                }
            else {
                builder.AppendIndent(indent + 1, $"No Sequence header");
                }

            builder.AppendIndent(indent + 1, $"Body Length:{envelope.Body?.Length}");

            if (envelope.Trailer is var trailer) {
                builder.AppendIndent(indent + 1, $"Payload: {trailer.PayloadDigest?.ToStringBase64url()}");
                builder.AppendIndent(indent + 1, $"Tree:    {trailer.ApexDigest?.ToStringBase64url()}");
                }

            positionRead = jbcdStream.PositionRead;
            envelope = jbcdStream.ReadDareEnvelope();
            }
        }

    #endregion

    }
