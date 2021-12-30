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
/// Class to allow enumeration of sequence frames
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

    /// <summary>The current frame header as binary data</summary>
    public byte[] FrameHeader;

    /// <summary>The current frame header as a parsed object.</summary>
    public DareHeader Header;

    /// <summary>The current frame trailer as a parsed object.</summary>
    public DareTrailer Trailer;
    }

#endregion


/// <summary>
/// Base class for Sequence file implementations
/// </summary>
public abstract class Sequence : Disposable, IEnumerable<SequenceFrameIndex> {

    #region // Properties

    ///<summary>If true, decrypt payload contents.</summary> 
    public bool Decrypt { get; }


    ///<summary>The apex digest value of the sequence as written to the file.</summary>
    public byte[] Digest;

    ///<summary>If true, the Sequence type requires a digest calculated on the payload.</summary> 
    public virtual bool DigestRequired => false;

    ///<summary>The first frame in the sequence</summary>
    public DareEnvelope FrameZero;

    /// <summary>The underlying file stream</summary>
    public JbcdStream JbcdStream { get; set; }

    /// <summary>The byte offset from the start of the file for Record 1</summary>
    public virtual long StartOfData { get; protected set; }

    /// <summary>The encoding to use for creating the FrameHeader entry</summary>
    public DataEncoding DataEncoding { get; protected set; }

    /// <summary>The value of the last frame index</summary>
    public virtual long FrameCount { get; protected set; }

    ///<summary>The start of the last frame.</summary>
    public virtual long PositionFinalFrameStart { get; private set; }

    ///<summary>The last frame in the sequence</summary>
    public virtual int FrameIndexLast => HeaderFinal.Index;

    ///<summary>The key location instance.</summary>
    public IKeyLocate KeyLocate { get; protected set; }

    ///<summary>The current read position.</summary> 
    public long Position => JbcdStream.PositionRead;



    ///<summary>Position of the last index in the file.</summary> 
    public long PositionIndex { get; set; }

    ///<summary>The last sequence index found.</summary> 
    public SequenceIndex SequenceIndex { get; set; }

    ///<summary>The trailer section of the last envelope in the sequence.</summary> 
    public DareTrailer TrailerLast { get; set; }

    /// <summary>The current frame header as binary data</summary>
    public virtual byte[] HeaderBytes {
        get => headerBytes;
        protected set {
            headerBytes = value;
            header = null;
            }
        }
    byte[] headerBytes = null;

    /// <summary>
    /// The cryptography parameters.
    /// </summary>
    public CryptoParametersSequence CryptoParametersSequence = null;

    /// <summary>
    /// The default cryptographic stack
    /// </summary>
    public CryptoStack CryptoStack = null;

    /// <summary>The current frame header as a parsed object.</summary>
    public virtual DareHeader Header {
        get {
            if (headerBytes == null) {
                return null;
                }
            header ??= DareHeader.FromJson(headerBytes.JsonReader(), false);
            return header;
            }
        }
    DareHeader header = null;

    ///<summary>Convenience accessor for the SequenceInfo field of the sequence.</summary>
    protected SequenceInfo SequenceInfo => Header?.SequenceInfo;


    /// <summary>
    /// The first sequence header. This is read only since it is fixed after
    /// the record is written.
    /// </summary>
    public DareHeader HeaderFirst { get; protected set; }


    ///<summary>The last sequence header.</summary>
    public DareHeader HeaderFinal { get; protected set; }

    /// <summary>
    /// The underlying stream reader/writer for the sequence. This will be disposed of when
    /// the sequence is released.
    /// </summary>
    public JbcdStream DisposeJBCDStream;

    ///<summary>Name of the underlying file (may be used to reconnect to file)</summary> 
    public string Filename { get; set; }


    #endregion
    /// <summary>
    /// Default constructor.
    /// </summary>

    public Sequence(bool decrypt) { 
        Decrypt=decrypt;
        }


    #region // IDisposable
    /// <summary>
    /// The class specific disposal routine.
    /// </summary>
    protected override void Disposing() =>
        DisposeJBCDStream?.Dispose();
    #endregion
    #region // IEnumerable

    /// <summary>
    /// Returns an enumerator over the sequence contents starting with the
    /// first frame.
    /// </summary>
    /// <returns>The enumerator</returns>
    public virtual IEnumerator<SequenceFrameIndex> GetEnumerator() =>
        new ContainerEnumerator(this);

    // Must also implement IEnumerable.GetEnumerator, but implement as a private method.
    private IEnumerator GetEnumerator1() => this.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
    #endregion

    #region // Parameterized factory methods

    /// <summary>
    /// Open or create sequence according to the setting of FileStatus. The underlying 
    /// filestreams will be disposed of automatically when the sequence is disposed.
    /// </summary>
    /// <param name="fileName">The file name.</param>
    /// <param name="fileStatus">The file access mode.</param>
    /// <param name="keyLocate">The key collection to be used to resolve requests
    /// for decryption keys. If unspecified, the default KeyCollection is used.</param>
    /// <param name="policy">The cryptographic policy to govern the sequence.</param>
    /// <param name="sequenceType">The sequence type to create if the sequence does
    /// not already exist.</param>
    /// <param name="contentType">The content type to declare if a new sequence is
    /// created.</param>
    /// <param name="decrypt">If true, enable decryption of sequence payload,
    /// otherwise return payload contents as plaintext.</param>
    /// <param name="create">If true, create a sequence file if none already exists</param>
    /// <returns>The new sequence.</returns>
    public static Sequence Open(
                    string fileName,
                    FileStatus fileStatus = FileStatus.Read,
                    IKeyLocate keyLocate = null,
                    //CryptoParameters cryptoParameters = null,
                    SequenceType sequenceType = SequenceType.Unknown,
                    DarePolicy policy = null,
                    string contentType = null,
                    bool decrypt = true,
                    bool create = true) {

        if (!create && !File.Exists(fileName)) {
            return null;
            }
        var jbcdStream = new JbcdStream(fileName, fileStatus: fileStatus);
        try {
            Sequence Container;

            // Create new sequence if empty or read the old one.
            if (jbcdStream.Length == 0) {
                Container = NewContainer(jbcdStream, decrypt:decrypt,
                    keyLocate: keyLocate, sequenceType: sequenceType, policy: policy, contentType: contentType);
                }
            else {
                Container = OpenExisting(jbcdStream, keyLocate, decrypt: decrypt);
                }
            (Container.KeyCollection == keyLocate).AssertTrue(NYI.Throw);
            Container.DisposeJBCDStream = jbcdStream;
            Container.Filename = fileName;

            return Container;
            }
        catch (Exception exception) {
            jbcdStream?.Dispose();

            throw new AccessRefused($"Failed to open {fileName}", exception);
            }
        }
    #endregion
    #region // 
    #endregion
    #region // Open sequence 

    /// <summary>
    /// Open or create sequence according to the setting of FileStatus. The underlying 
    /// filestreams will be disposed of automatically when the sequence is disposed.
    /// </summary>
    /// <param name="jbcdStream">The stream to use to access the sequence.</param>
    /// <param name="keyLocate">The key collection to be used to resolve keys</param>
    /// <returns>The new sequence.</returns>
    public static Sequence Open(
                    JbcdStream jbcdStream,
                    IKeyLocate keyLocate = null) {


        var sequence = OpenExisting(jbcdStream, keyLocate);
        sequence.DisposeJBCDStream = jbcdStream;

        return sequence;
        }

    /// <summary>
    /// The default key collection to use for decryption
    /// </summary>
    protected IKeyLocate KeyCollection;

    /// <summary>
    /// Open an existing sequence file.
    /// </summary>
    /// <param name="fileName">The file to open as a sequence.</param>
    /// <param name="fileStatus">The file status.</param>
    /// <param name="keyCollection">The key collection to be used to decrypt the contents
    /// of the sequence.</param>
    /// <param name="decrypt">If true configure to enable decryption of bodies.</param>
    /// <returns>The sequence object if found. Otherwise, an exception is thrown.</returns>
    public static Sequence OpenExisting(
            string fileName,
            FileStatus fileStatus = FileStatus.Read,
            IKeyLocate keyCollection = null, bool decrypt = true) {
        var jbcdStream = new JbcdStream(fileName, fileStatus: fileStatus);

        var sequence = OpenExisting(jbcdStream, keyCollection, decrypt: decrypt);
        sequence.DisposeJBCDStream = jbcdStream;

        return sequence;
        }


    /// <summary>
    /// Open an existing sequence according to the information contained in the next frame to be read.
    /// </summary>
    /// <param name="jbcdStream">The frame reader. Since this is passed to the
    /// method to create the class it is not disposed with the sequence using it.</param>
    /// <param name="keyCollection">The key collection to be used to resolve requests
    /// for decryption keys. If unspecified, the default KeyCollection is used.</param>
    /// <param name="decrypt">If true, enable decryption of sequence payload,
    /// otherwise return payload contents as plaintext.</param>
    /// <returns></returns>
    public static Sequence OpenExisting(
                    JbcdStream jbcdStream,
                    IKeyLocate keyCollection = null, bool decrypt = true) {

        decrypt.Future();

        // Initialize frame zero
        var frameZero = jbcdStream.ReadDareEnvelope();

        var sequenceHeaderFirst = frameZero.Header;

        var position1 = jbcdStream.PositionRead; // is always positioned after the first record on entry.
                                                 //CryptoProviderDigest DigestProvider = CryptoCatalog.Default.GetDigest(CryptoAlgorithmID.Default);

        long frameCount = 1;
        DareHeader finalHeader;
        DareTrailer finalTrailer;
        if (position1 < jbcdStream.Length) {
            finalHeader = jbcdStream.ReadLastFrameHeader();
            frameCount = finalHeader.SequenceInfo.Index + 1;
            // need to set finalTrailer here!
            finalTrailer = null;
            }
        else {
            finalHeader = sequenceHeaderFirst;
            finalTrailer = frameZero.Trailer;
            }

        var sequenceInfo = sequenceHeaderFirst.SequenceInfo;
        var sequenceType = sequenceInfo.ContainerType.ToSequenceType();

        var cryptoParametersContainer =
            new CryptoParametersSequence(sequenceType, sequenceHeaderFirst, true, keyCollection);

        var positionFinalFrameStart = jbcdStream.StartLastFrameRead;

        Sequence sequence;
        switch (sequenceInfo.ContainerType) {
            case DareConstants.SequenceTypeListTag: {
                    sequence = new ContainerList(decrypt) {
                        JbcdStream = jbcdStream,
                        HeaderFirst = sequenceHeaderFirst,
                        StartOfData = position1,
                        FrameCount = frameCount,
                        CryptoParametersSequence = cryptoParametersContainer
                        };
                    break;
                    }
            case DareConstants.SequenceTypeDigestTag: {
                    cryptoParametersContainer.SetDigest();
                    sequence = new ContainerDigest(decrypt) {
                        JbcdStream = jbcdStream,
                        //DigestProvider = DigestProvider,
                        HeaderFirst = sequenceHeaderFirst,
                        StartOfData = position1,
                        FrameCount = frameCount,
                        CryptoParametersSequence = cryptoParametersContainer
                        };
                    break;
                    }
            case DareConstants.SequenceTypeChainTag: {
                    cryptoParametersContainer.SetDigest();
                    sequence = new ContainerChain(decrypt) {
                        JbcdStream = jbcdStream,
                        //DigestProvider = DigestProvider,
                        HeaderFirst = sequenceHeaderFirst,
                        StartOfData = position1,
                        FrameCount = frameCount,
                        CryptoParametersSequence = cryptoParametersContainer
                        };
                    break;
                    }
            case DareConstants.SequenceTypeTreeTag: {
                    sequence = new ContainerTree(decrypt) {
                        JbcdStream = jbcdStream,
                        //DigestProvider = DigestProvider,
                        HeaderFirst = sequenceHeaderFirst,
                        StartOfData = position1,
                        FrameCount = frameCount,
                        CryptoParametersSequence = cryptoParametersContainer
                        };
                    break;
                    }
            case DareConstants.SequenceTypeMerkleTag: {
                    cryptoParametersContainer.SetDigest();
                    sequence = new ContainerMerkleTree(decrypt) {
                        JbcdStream = jbcdStream,
                        //DigestProvider = DigestProvider,
                        HeaderFirst = sequenceHeaderFirst,
                        StartOfData = position1,
                        FrameCount = frameCount,
                        CryptoParametersSequence = cryptoParametersContainer
                        };
                    break;
                    }
            default: {
                    throw new NYI();
                    }
            }

        // initialize the Frame index dictionary

        sequence.KeyLocate = keyCollection;
        sequence.FrameZero = frameZero;
        sequence.HeaderFinal = finalHeader;
        sequence.TrailerLast = finalTrailer;
        sequence.PositionFinalFrameStart = positionFinalFrameStart;
        sequence.FillDictionary(finalHeader.SequenceInfo, position1, positionFinalFrameStart);
        sequence.KeyCollection = keyCollection;

        sequence.SequenceIndex = finalHeader.SequenceIndex;
        if (finalHeader.SequenceInfo != null) {
            sequence.PositionIndex = finalHeader.SequenceInfo.IndexPosition;
            }
        jbcdStream.PositionRead = position1;

        return sequence;
        }

    /// <summary>
    /// Create a new sequence file of the specified type and write the initial
    /// data record
    /// </summary>
    /// <param name="filename">The file to open</param>
    /// <param name="fileStatus">The file status.</param>
    /// <param name="payload">Optional data payload. </param>
    /// <param name="contentType">Content type of the optional data payload</param>
    /// <param name="sequenceType">The sequence type.</param>
    /// <param name="policy">The cryptographic policy to be applied to the sequence.</param>
    /// <param name="dataEncoding">The data encoding.</param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
    /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
    ///     as an EDSS header entry.</param>
    /// <exception cref="InvalidFileModeException">The file mode specified was not valid.</exception>
    public static Sequence NewContainer(
                    string filename,
                    FileStatus fileStatus,
                    SequenceType sequenceType = SequenceType.Chain,
                    DarePolicy policy = null,
                    byte[] payload = null,
                    string contentType = null,
                    DataEncoding dataEncoding = DataEncoding.JSON,
                    byte[] cloaked = null,
                    List<byte[]> dataSequences = null,
                    bool decrypt=true
                    ) {

        Assert.AssertTrue(fileStatus == FileStatus.New | fileStatus == FileStatus.Overwrite,
            InvalidFileModeException.Throw);

        var jbcdStream = new JbcdStream(filename, fileStatus);
        var sequence = NewContainer(
            jbcdStream, decrypt:decrypt, sequenceType: sequenceType, policy: policy, payload: payload, contentType: contentType, dataEncoding: dataEncoding,
            cloaked: cloaked, dataSequences: dataSequences);

        sequence.DisposeJBCDStream = jbcdStream;

        return sequence;
        }



    /// <summary>
    /// Create a new sequence file of the specified type and write the initial
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
    /// <param name="sequenceType">The sequence type. This determines whether
    /// a tree index is to be created or not and if so, whether </param>
    /// <param name="policy">The cryptographic policy to govern the sequence.</param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
    /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
    ///     as an EDSS header entry.</param>
    public static Sequence NewContainer(
                    JbcdStream jbcdStream,
                    IKeyLocate keyLocate = null,
                    SequenceType sequenceType = SequenceType.Chain,
                    DarePolicy policy = null,
                    byte[] payload = null,
                    string contentType = null,
                    DataEncoding dataEncoding = DataEncoding.JSON,
                    byte[] cloaked = null,
                    List<byte[]> dataSequences = null,
                    bool decrypt=true) {
        var sequence = MakeNewSequence(jbcdStream, decrypt, sequenceType: sequenceType);
        var sequenceHeaderFirst = sequence.HeaderFirst;
        var sequenceInfoFirst = sequenceHeaderFirst.SequenceInfo;

        // set the encryption policy
        sequenceHeaderFirst.Policy = policy;

        // The cryptographic parameters that will be kept between calls.
        sequence.CryptoParametersSequence =
            new CryptoParametersSequence(sequenceType, sequenceHeaderFirst);

        sequence.DataEncoding = dataEncoding;
        sequence.FrameCount = 0;

        sequenceInfoFirst.DataEncoding = dataEncoding.ToString();

        sequenceHeaderFirst.ContentMeta = new ContentMeta() {
            ContentType = contentType
            };



        sequence.CryptoStack = sequenceHeaderFirst.BindEncoder(sequence.CryptoParametersSequence,
                cloaked, dataSequences);

        payload = sequenceHeaderFirst.EnhanceBody(payload, out var Trailer);
        sequence.MakeTrailer(ref Trailer);

        var headerBytes = sequenceHeaderFirst.GetBytes(dataEncoding, false);
        var trailerBytes = Trailer?.GetBytes(dataEncoding, false);

        sequence.AppendFrame(headerBytes, payload, trailerBytes);
        sequence.FrameCount++;

        sequence.KeyCollection = keyLocate ?? policy?.KeyLocation;

        sequence.FrameZero = new DareEnvelope() {
            Header = sequenceHeaderFirst,
            Body = payload,
            Trailer = Trailer
            };

        sequence.TrailerLast = Trailer;

        return sequence;
        }

    /// <summary>
    /// Create a new sequence file of the specified type and write the initial
    /// data record
    /// </summary>
    /// <param name="jbcdStream">The underlying JBCDStream stream. This MUST be opened
    /// in a read access mode and should have exclusive read access. All existing
    /// content in the file will be overwritten.</param>
    /// <param name="sequenceType">The sequence type. This determines whether
    /// a tree index is to be created or not and if so, whether </param>
    /// <returns>The newly constructed sequence.</returns>
    public static Sequence MakeNewSequence(
                    JbcdStream jbcdStream,
                    bool decrypt,
                    SequenceType sequenceType = SequenceType.Merkle) {
        Sequence result;

        switch (sequenceType) {
            case SequenceType.List: {
                    result = ContainerList.MakeNewContainer(jbcdStream, decrypt);
                    break;
                    }
            case SequenceType.Digest: {
                    result = ContainerDigest.MakeNewContainer(jbcdStream, decrypt);
                    break;
                    }
            case SequenceType.Chain: {
                    result = ContainerChain.MakeNewContainer(jbcdStream, decrypt);
                    break;
                    }
            case SequenceType.Tree: {
                    result = ContainerTree.MakeNewContainer(jbcdStream, decrypt);
                    break;
                    }
            case SequenceType.Merkle: {
                    result = ContainerMerkleTree.MakeNewContainer(jbcdStream, decrypt);
                    break;
                    }
            default: {
                    throw new InvalidContainerTypeException();
                    }
            }
        return result;

        }

    /// <summary>
    /// Create a new sequence with the name <paramref name="fileName"/> and
    /// append <paramref name="envelopes"/> to the end of the sequence.
    /// </summary>
    /// <param name="fileName">Name of the sequence to create</param>
    /// <param name="envelopes">Envelopes to add</param>
    /// <param name="fileStatus">File status (used for concurrency locking)</param>
    /// <param name="keyLocate">The key location collection to be used to resolve keys.</param>
    /// <returns>The created sequence</returns>
    public static Sequence MakeNewSequence(
                    string fileName,
                    IKeyLocate keyLocate,
                    List<DareEnvelope> envelopes,
                    FileStatus fileStatus = FileStatus.CreateNew) {

        var jbcdStream = new JbcdStream(fileName, fileStatus: fileStatus);
        var sequence = new ContainerMerkleTree() {
            JbcdStream = jbcdStream,
            HeaderFirst = envelopes[0].Header,
            KeyLocate = keyLocate,
            DisposeJBCDStream = jbcdStream
            };

        sequence.Append(envelopes);

        return sequence;
        }

    #endregion
    #region // Navigation and enumeration methods


    /// <summary>
    /// Return an enumerator with the specified selectors.
    /// </summary>
    /// <param name="minIndex">The minimum index.</param>
    /// <param name="reverse">If true, read the sequence from the end.</param>
    /// <returns>The enumerator.</returns>
    public SequenceEnumeratorRaw Select(int minIndex, bool reverse = false) =>
        new(this, minIndex, reverse);


    /// <summary>
    /// Dictionary of frame index to frame position.
    /// </summary>
    public Dictionary<long, long> FrameIndexToPositionDictionary =
        new();

    /// <summary>
    /// Register a frame in the sequence access dictionaries.
    /// </summary>
    /// <param name="sequenceInfo">Frame header</param>
    /// <param name="position">Position of the frame</param>
    protected virtual void RegisterFrame(SequenceInfo sequenceInfo, long position) {
        var index = sequenceInfo.Index;
        FrameIndexToPositionDictionary.AddSafe(index, position);
        }

    /// <summary>
    /// Get the frame position.
    /// </summary>
    /// <param name="frame">The frame index</param>
    /// <returns>The frame position.</returns>
    public virtual long GetFramePosition(long frame) {
        FrameIndexToPositionDictionary.TryGetValue(frame, out var position);
        return position;
        }

    /// <summary>
    /// The number of bytes to be reserved for the trailer.
    /// </summary>
    /// <returns>The number of bytes to reserve</returns>
    public virtual DareTrailer FillDummyTrailer(CryptoStack cryptoStack) => null;

    /// <summary>
    /// The dummy trailer to add to the end of the frame.
    /// </summary>
    /// <returns></returns>
    public virtual void MakeTrailer(ref DareTrailer trailer) {
        }


    /// <summary>
    /// Append a new data frame payload to the end of the file.
    /// </summary>
    /// <param name="payload">The frame payload data value.</param>
    /// <param name="header">The frame header value.</param>
    /// <param name="trailer">The frame trailer value.</param>
    /// <returns>The number of bytes written.</returns>
    long AppendFrame(byte[] header, byte[] payload = null, byte[] trailer = null) =>
            JbcdStream.WriteWrappedFrame(header, payload, trailer);







    /// <summary>
    /// Append the envelopes <paramref name="envelopes"/> to the sequence starting
    /// with the <paramref name="index"/>th envelope.
    /// </summary>
    /// <param name="envelopes">The enveolpes to append</param>
    /// <param name="index">The starting point at which to begin appending.</param>
    public void Append(List<DareEnvelope> envelopes, int index = 0) {

        for (var i = index; i < envelopes.Count; i++) {
            Append(envelopes[i]);
            }
        }

    /// <summary>
    /// Initialize a <see cref="SequenceInfo"/> instance for the current sequence
    /// position.
    /// </summary>
    /// <returns>The initialized instance.</returns>
    public virtual SequenceInfo MakeSequenceInfo() => new() {
        Index = (int)FrameCount++
        };

    /// <summary>
    /// Append an empty frame containing sequence index or content information.
    /// </summary>
    /// <param name="sequenceIndex">The SequenceIndex to append.</param>
    /// <param name="contentMeta">The ContentMeta to append.</param>
    public void Append(SequenceIndex sequenceIndex = null, ContentMeta contentMeta = null) {

        var header = new DareHeader() {
            SequenceInfo = MakeSequenceInfo(),
            ContentMeta = contentMeta,
            SequenceIndex = sequenceIndex
            };


        var trailer = new DareTrailer() {
            };

        AppendEnvelope(null, header, trailer);
        }


    /// <summary>
    /// Write a previously prepared or validated Dare Envelope to the sequence directly.
    /// </summary>
    /// <param name="envelope">The envelope to append to the sequence</param>
    /// <param name="updateEnvelope">If true, update the header and trailer of 
    /// <paramref name="envelope"/> to the computed values.</param>
    public virtual SequenceFrameIndex Append(DareEnvelope envelope, bool updateEnvelope = false) {



        //var header = envelope.Header as DareHeader; // fails ! need to copy over !!
        var headerIn = envelope.Header;
        var trailerIn = envelope.Trailer;

        var header = new DareHeader() {
            SequenceInfo = MakeSequenceInfo(),

            EnvelopeId = headerIn.EnvelopeId,
            EncryptionAlgorithm = headerIn.EncryptionAlgorithm,
            Salt = headerIn.Salt,
            Cloaked = headerIn.Cloaked,
            EDSS = headerIn.EDSS,
            Signers = headerIn.Signers,
            Recipients = headerIn.Recipients,
            ContentMeta = headerIn.ContentMeta,
            ContentMetaData = headerIn.ContentMetaData,
            Received = headerIn.Received ?? DateTime.Now,

            Signatures = trailerIn?.Signatures ?? headerIn.Signatures,
            SignedData = trailerIn?.SignedData ?? headerIn.SignedData,
            PayloadDigest = trailerIn?.PayloadDigest ?? headerIn.PayloadDigest,

            DigestAlgorithm = headerIn.DigestAlgorithm
            };

        // we need to recompute the PayloadDigest under the sequence DigestAlgorithm
        var trailer = new DareTrailer() {
            };


        // Hack: should check that the digest algorithm is the same as the sequence
        // Hack: should verify the digest value and signature.


        var dataPosition = AppendEnvelope(envelope.Body, header, trailer);
        var sequenceFrameIndex = new SequenceFrameIndex(this, envelope, dataPosition);


        if (updateEnvelope) {
            envelope.Header = header;
            envelope.Trailer = trailer;
            }

        //ContainerFrameIndex.dataPosition = JBCDStream.PositionWrite + 

        return sequenceFrameIndex;

        }

    private long AppendEnvelope(byte[] body, DareHeader header, DareTrailer trailer) {
        PrepareFrame(header.SequenceInfo);
        var contextWrite = new SequenceWriterFile(this, header, JbcdStream);
        contextWrite.CommitFrame(trailer);

        //Console.WriteLine($"   {header.ContainerInfo.TreePosition} ");

        //Apply(header, envelope.Body, envelope.Trailer);
        var dataHeader = header.GetBytes(false);
        var dataTrailer = trailer.GetBytes(false);
        return AppendFrame(dataHeader, body, dataTrailer);
        }

    /// <summary>
    /// Prepare the sequence frame information in <paramref name="sequenceInfo"/>.
    /// </summary>
    /// <param name="sequenceInfo">The sequence information to be prepared.</param>
    protected virtual void PrepareFrame(SequenceInfo sequenceInfo) {
        }


    /// <summary>
    /// Obtain a ContainerFrameIndex instance for <paramref name="index"/> if
    /// specified or <paramref name="position"/> otherwise.
    /// </summary>
    /// <param name="index">The sequence index to obtain the frame index for.</param>
    /// <param name="position">The sequence position to obtain the frame index for.</param>
    /// <returns>The created ContainerFrameIndex instance,</returns>
    public abstract SequenceFrameIndex GetSequenceFrameIndex(
        long index = -1, long position = -1);



    #endregion
    #region // Convenience methods to read/write to sequences.


    /// <summary>
    /// Append a new data frame payload to the end of the file.
    /// </summary>
    /// <param name="data">Ciphertext data to append.</param>
    /// <param name="contentMeta">Content metadata.</param>
    /// <param name="contentType">The payload content type.</param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
    /// <param name="dataSequences">Data sequences to be converted to an EDS and presented </param>
    /// <param name="cryptoParameters">The cryptographic parameters.</param>
    /// <returns>The number of bytes written.</returns>
    public long Append(

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
    /// Read data from the specified file and append to the sequence.
    /// </summary>
    /// <param name="fileName">The file to append</param>
    /// <param name="contentInfo">Container header data.</param>
    /// <param name="contentType">The payload content type.</param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
    /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
    ///     as an EDSS header entry.</param>
    /// <returns>The number of bytes written.</returns>
    public long AppendFile(string fileName,
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
    /// Read data from the specified file and append to the sequence.
    /// </summary>
    /// <param name="input">The stream to be read.</param>
    /// <param name="contentLength"> The number of bytes to read from <paramref name="input"/>.</param>
    /// <param name="contentInfo">Container header data.</param>
    /// <param name="contentType">The payload content type.</param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
    /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
    ///     as an EDSS header entry.</param>
    /// <param name="cryptoParameters">The cryptographic parameters.</param>
    /// <returns>The number of bytes written.</returns>
    /// <remarks>At present, the file stream MUST support the seek operation
    /// which is an issue that has to be removed.</remarks>
    public long AppendFromStream(Stream input,
            long contentLength,
            ContentMeta contentInfo = null,
            string contentType = null,
            byte[] cloaked = null,
            List<byte[]> dataSequences = null,
                    CryptoParameters cryptoParameters = null) {
        var index = AppendBegin(contentLength, contentInfo,
                contentType, cloaked, dataSequences, cryptoParameters);
        input.ProcessRead(AppendProcess);
        AppendEnd();

        return index;
        }

    #endregion

    #region // Methods to append data from a stream of known length


    /// <summary>
    /// Header of the framer being written
    /// </summary>
    SequenceWriterFile contextWrite;
    Stream bodyWrite;

    /// <summary>
    /// Begin appending a data frame.
    /// </summary>
    /// <remarks>This call is not thread safe. It is the responsibility of the caller
    /// to ensure that only one process writes to the sequence at once and that no other
    /// process has access.</remarks>
    /// <param name="contentLength">The plaintext payload data length. the final payload
    /// length may be longer as a result of padding.</param>
    /// <param name="contentInfo">Pre-populated sequence header.</param>
    /// <param name="contentType">The payload content type.</param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
    /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
    ///     as an EDSS header entry.</param>
    /// <param name="cryptoParameters">The cryptographic parameters.</param>
    /// <returns>The number of bytes written</returns>
    public long AppendBegin(
                    long contentLength,

                    ContentMeta contentInfo = null,
                    string contentType = null,
                    byte[] cloaked = null,
                    List<byte[]> dataSequences = null,
                    CryptoParameters cryptoParameters = null) {

        var index = (int)FrameCount++;



        contentInfo ??= new ContentMeta() {
            ContentType = contentType
            };

        var sequenceInfo = new SequenceInfo() {
            Index = index
            };

        var appendContainerHeader = new DareHeader() {
            SequenceInfo = sequenceInfo,
            ContentMeta = contentInfo
            };

        // These should be paired.
        CryptoStack = appendContainerHeader.BindEncoder(cryptoParameters ?? CryptoParametersSequence,
            cloaked, dataSequences);



        //appendContainerHeader.ApplyCryptoStack(CryptoStackContainer, cloaked, dataSequences);

        contextWrite = new SequenceWriterFile(this, appendContainerHeader, JbcdStream);

        PrepareFrame(contextWrite); // Perform sequence type specific processing.

        var payloadLength = appendContainerHeader.OutputLength(contentLength);
        var dummyTrailer = FillDummyTrailer(CryptoStack);
        var lengthTrailer = dummyTrailer == null ? -1 : dummyTrailer.GetBytes(false).Length;
        var dataPayload = appendContainerHeader.GetBytes(false);

        JbcdStream.WriteWrappedFrameBegin(dataPayload, payloadLength, lengthTrailer);
        bodyWrite = appendContainerHeader.BodyWriter(JbcdStream.StreamWrite);

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
        bodyWrite.Write(data, offset, count);

    /// <summary>
    /// Complete appending a record.
    /// </summary>
    void AppendEnd() {
        contextWrite.SequenceHeader.CloseBodyWriter(out var trailer);
        MakeTrailer(ref trailer);
        var trailerData = trailer?.GetBytes(false);
        JbcdStream.WriteWrappedFrameEnd(trailerData);
        contextWrite.CommitFrame(trailer);

        TrailerLast = trailer;
        }

    /// <summary>
    /// Create a DareEnvelope to be added to the sequence in deferred write mode.
    /// </summary>
    /// <param name="contextWrite">The sequence write context the envelope is to be written in.</param>
    /// <param name="contentMeta">The content metadata.</param>
    /// <param name="data">The data plaintext payload.</param>
    /// <param name="cloaked">Data to be converted to an EDS and presented as a cloaked header.</param>
    /// <param name="dataSequences">Data sequences to be converted to an EDS and presented 
    ///     as an EDSS header entry.</param>
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
            var stream = contextWrite.SequenceHeader.BodyWriter(buffer);
            stream.Write(data);
            contextWrite.StreamClose();
            return contextWrite.End(buffer.ToArray());
            }
        return contextWrite.End(null);
        }

    /// <summary>
    /// Prepare the header information to write an envelope to a sequence.
    /// </summary>
    public virtual void PrepareFrame(SequenceWriter contextWrite) {
        }

    /// <summary>
    /// Validate a frame to be added to the sequence.
    /// </summary>
    public virtual void ValidateFrame(SequenceWriter contextWrite) {
        }


    /// <summary>
    /// Append the header to the frame. This is called after the payload data
    /// has been passed using AppendPreprocess.
    /// </summary>
    public virtual void CommitHeader(DareHeader sequenceHeader, SequenceWriter contextWrite) {
        }


    #endregion

    #region // Abstract and Virtual methods

    /// <summary>
    /// Return the header of frame with index <paramref name="frame"/>.
    /// </summary>
    /// <param name="frame">The index of the frame to be returned.</param>
    /// <returns>The requested header.</returns>
    public DareHeader GetHeader(int frame) {
        MoveToIndex(frame).AssertTrue(InvalidFrameIndex.Throw);

        return JbcdStream.ReadFrameHeader();

        }


    /// <summary>
    /// Initialize the dictionaries used to manage the tree by registering the set
    /// of values leading up to the apex value.
    /// </summary>
    /// <param name="header">Final frame header</param>
    /// <param name="firstPosition">Position of frame 1</param>
    /// <param name="positionLast">Position of the last frame</param>
    protected abstract void FillDictionary(
                SequenceInfo header, long firstPosition, long positionLast);


    /// <summary>
    /// Verify that the file <paramref name="filename"/> is a DARE Sequence that
    /// is in compliance with its specified policy.
    /// </summary>
    /// <param name="filename">The sequence to verify.</param>
    /// <param name="keyLocate">Key location to be used to resolve keys.</param>
    public static void VerifyPolicy(string filename, IKeyLocate keyLocate) {



        // open the sequence
        using var sequence = Sequence.Open(filename, FileStatus.Read, keyLocate);

        sequence.VerifyPolicy();

        }

    /// <summary>
    /// Verify policy on the sequence.
    /// </summary>
    public void VerifyPolicy() {
        var dictionary = new Dictionary<int, SequenceFrameIndex>();
        var darePolicy = HeaderFirst.Policy;
        SequenceFrameIndex lastFrame = null;

        var record = 0;
        // read each record in turn
        foreach (var frameIndex in this) {
            record++;
            Verify(this, darePolicy, frameIndex, record, KeyCollection, dictionary);
            dictionary.Add(record, frameIndex);
            lastFrame = frameIndex;
            }

        VerifyFinal(this, darePolicy, lastFrame);
        }

    static bool VerifyFinal(
            Sequence sequence,
            DarePolicy darePolicy,
            SequenceFrameIndex frameIndex) {
        sequence.Future();
        darePolicy.Future();
        frameIndex.Future();
        // here perform policy checks on the very last frame.

        return true;
        }

    static bool Verify(
        Sequence sequence,
        DarePolicy darePolicy,
        SequenceFrameIndex frameIndex,
        int record,

        IKeyLocate keyCollection,
        Dictionary<int, SequenceFrameIndex> dictionary) {

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
        (sequenceInfo.Index == record).AssertTrue(SequenceDataCorrupt.Throw);

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
    /// Perform sanity checking on a list of sequence headers.
    /// </summary>
    /// <param name="headers">List of headers to check</param>
    public abstract void CheckSequence(List<DareHeader> headers);

    /// <summary>
    /// Read the data in the current file 
    /// </summary>
    /// <param name="direction">Direction in which to perform check.
    /// <list type="bullet"><item>1 = forward</item><item>-1 = forward</item>
    /// <item>0 = forward then backward.</item></list></param>
    /// <returns>True if the validation succeded, otherwise false.</returns>
    public virtual bool Validate(int direction) => throw new NYI();

    /// <summary>
    /// Move read pointer to Frame 1.
    /// </summary>
    /// <returns>True if a next frame exists, otherwise false</returns>
    public virtual bool Start() {
        JbcdStream.Begin();
        return JbcdStream.EOF;
        }

    /// <summary>
    /// Read the next frame in the file.
    /// </summary>
    /// <returns>True if a next frame exists, otherwise false</returns>
    public abstract bool NextFrame();

    /// <summary>
    /// Read the next frame in the file.
    /// </summary>
    /// <returns>True if a next frame exists, otherwise false</returns>
    public abstract bool PreviousFrame();

    /// <summary>
    /// Read the previous frame in the file.
    /// </summary>
    /// <returns>True if a previous frame exists, otherwise false</returns>
    public abstract bool Previous();

    /// <summary>
    /// Move to the frame with index Position in the file. 
    /// <para>If the tree positioning mechanism is in use, the
    /// time complexity for this operation is log2(n) where n is
    /// the difference between the current position and the new 
    /// position.</para>
    /// </summary>
    /// <param name="frameIndex">Frame index to move to.</param>
    /// <returns>True if the position exists.</returns>
    public abstract bool MoveToIndex(long frameIndex);

    /// <summary>
    /// Move to begin reading the last frame in the sequence.
    /// </summary>
    /// <returns></returns>
    public bool MoveToLast() {
        JbcdStream.End();
        return JbcdStream.PositionRead > 0;
        }

    /// <summary>
    /// Verify sequence contents by reading every frame starting with the first and checking
    /// for integrity. This is likely to take a very long time.
    /// </summary>
    public virtual void VerifySequence() {
        }

    #endregion

    #region // Utility and convenience methods

    /// <summary>
    /// Move to the start of the previous frame and save the reader position.
    /// Then read the frame and return the reader position to the start of
    /// the frame.
    /// </summary>
    /// <returns></returns>
    public DareEnvelope ReadDirectReverse() {
        //Console.WriteLine($"Position Read {JBCDStream.PositionRead}");

        var position = JbcdStream.MoveFrameReverse();
        if (position <= 0) {
            return null; // Exclude the first frame from reverse enumeration.
            }

        //Console.WriteLine($"Position ReadII {position}");

        var message = ReadDirect();
        JbcdStream.PositionRead = position;
        return message;
        }

    /// <summary>
    /// Return the current sequence frame as a DareEnvelope.
    /// </summary>
    /// <returns>The sequence data.</returns>
    public DareEnvelope ReadDirect() => JbcdStream.ReadDareEnvelope();


    /// <summary>
    /// Pretty print the sequence specified to the console
    /// </summary>
    /// <param name="fileName">The sequence file.</param>
    public static void ToConsole(string fileName) {
        var builder = new StringBuilder();
        ToBuilder(fileName, builder, 0);
        Console.WriteLine(builder);
        }


    /// <summary>
    /// Pretty print the sequence specified.
    /// </summary>
    /// <param name="fileName">The sequence file.</param>
    /// <param name="builder">The stringbuilder to use.</param>
    /// <param name="indent">The indent level.</param>
    public static void ToBuilder(string fileName, StringBuilder builder, int indent) {
        using var jbcdStream = new JbcdStream(fileName, fileStatus: FileStatus.Read);
        var positionRead = jbcdStream.PositionRead;
        var envelope = jbcdStream.ReadDareEnvelope();
        while (envelope != null) {
            if (envelope?.Header?.SequenceInfo is var sequenceInfo) {
                builder.AppendIndent(indent, $"[{sequenceInfo.Index}]  <{positionRead}-{jbcdStream.PositionRead}>");
                builder.AppendIndent(indent + 1, $"Tree Position:{sequenceInfo.TreePosition}");
                }
            else {
                builder.AppendIndent(indent + 1, $"No Sequence header");
                }

            builder.AppendIndent(indent + 1, $"Body Length:{envelope.Body?.Length}");

            if (envelope.Trailer is var trailer) {
                builder.AppendIndent(indent + 1, $"Payload: {trailer.PayloadDigest?.ToStringBase64url()}");
                builder.AppendIndent(indent + 1, $"Tree:    {trailer.TreeDigest?.ToStringBase64url()}");
                }

            positionRead = jbcdStream.PositionRead;
            envelope = jbcdStream.ReadDareEnvelope();
            }
        }

    #endregion

    }
