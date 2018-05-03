using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Protocol;
using Goedel.IO;
using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.Dare {



    /// <summary>
    /// Enumeration describing a container type.
    /// </summary>
    public enum ContainerType {
        /// <summary>The type is not defined.</summary>
        Unknown,
        ///<summary>A double linked list container. It can be read efficiently in
        ///the forward or the reverse direction. It does not provide protection against
        ///an insertion attack or efficient random access.</summary>
        List,
        ///<summary>A double linked list container. It can be read efficiently in
        ///the forward or the reverse direction. It does not provide protection against
        ///an insertion attack or efficient random access. A digest checksum is calculated
        ///over the frame payload value but this is not linked to any other digest.</summary>
        Digest,
        ///<summary>A double linked list container indexed by a binary tree.It can be read efficiently in
        ///the forward or the reverse direction or as a random access file. It does not provide protection against
        ///an insertion attack.</summary>
        Tree,
        ///<summary>A double linked list container. It can be read efficiently in
        ///the forward or the reverse direction and incorporates a digest chain to
        ///provide protection against insertion attacks. It does not supporrt efficient random access.</summary>
        Chain,
        ///<summary>A double linked list container indexed by a binary tree.It can be read efficiently in
        ///the forward or the reverse direction or as a random access file and incorporates a Merkle tree to
        ///provide protection against insertion attacks.</summary>
        MerkleTree,
        }

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

    public partial class ContainerHeader {

        /// <summary>The container payload. Note that this is not a serialized field of the container
        /// header.</summary>
        public byte[] Payload;

        }


    /// <summary>
    /// Class to allow enumeration of container frames
    /// </summary>
    public class ContainerFrame {
        /// <summary>The current write frame index (writes are always
        /// appended to the end of the file.</summary>
        long FrameCount { get; }

        /// <summary>The byte offset from the start of the file for the 
        /// first byte of the current frame.</summary>
        long Position { get; }

        /// <summary>The current frame data</summary>
        byte[] FrameData { get; }

        /// <summary>The current frame header as binary data</summary>
        byte[] FrameHeader { get; }

        /// <summary>The current frame header as a parsed object.</summary>
        ContainerHeader ContainerHeader { get; }
        }



    /// <summary>
    /// Base class for container file implementations
    /// </summary>
    public interface IContainer {

        /// <summary>The current write frame index (writes are always
        /// appended to the end of the file.</summary>
        long FrameCount { get; }

        /// <summary>The byte offset from the start of the file for the 
        /// first byte of the current frame.</summary>
        long Position { get; }

        /// <summary>The current frame data</summary>
        byte[] FrameData { get; }

        /// <summary>The current frame header as binary data</summary>
        byte[] FrameHeader { get; }

        /// <summary>The current frame header as a parsed object.</summary>
        ContainerHeader ContainerHeader { get; }


        /// <summary>True if the read position is at the end of the file.</summary>
        bool EOF { get; }

        /// <summary>
        /// Append a new data frame payload to the end of the file.
        /// </summary>
        /// <param name="Data">Data to append.</param>
        /// <param name="Header">The container header value</param>
        /// <returns>The number of bytes written.</returns>
        long Append (byte[] Data, ContainerHeader Header = null);

        /// <summary>
        /// Append a new data frame payload to the end of the file.
        /// </summary>
        /// <param name="Data">Data to append.</param>
        /// <param name="Header">The container header value</param>
        /// <returns>The number of bytes written.</returns>
        long Append (JSONObject Data, ContainerHeader Header = null);

        /// <summary>
        /// Read the data in the current file 
        /// </summary>
        /// <param name="Direction">Direction in which to perform check.
        /// <list type="bullet"><item>1 = forward</item><item>-1 = forward</item>
        /// <item>0 = forward then backward.</item></list></param>
        /// <returns>True if the validation succeded, otherwise false.</returns>
        bool Validate (int Direction);

        /// <summary>
        /// Read the next frame in the file.
        /// </summary>
        /// <returns>True if a next frame exists, otherwise false</returns>
        bool Next ();

        /// <summary>
        /// Read the previous frame in the file.
        /// </summary>
        /// <returns>True if a previous frame exists, otherwise false</returns>
        bool Previous ();

        /// <summary>
        /// Read the first frame in the file.
        /// </summary>
        /// <returns>True if a first frame exists, otherwise false</returns>
        bool First ();

        /// <summary>
        /// Read the last frame in the file.
        /// </summary>
        /// <returns>True if a last frame exists, otherwise false</returns>
        bool Last ();

        /// <summary>
        /// Move to the frame with index Position in the file. 
        /// <para>If the tree positioning mechanism is in use, the
        /// time complexity for this operation is log2(n) where n is
        /// the difference between the current position and the new 
        /// position.</para>
        /// </summary>
        /// <param name="FrameIndex">Frame Index to move to</param>
        /// <returns>True if the move succeeded, otherwise false.</returns>
        bool Move (long FrameIndex);

        }



    /// <summary>
    /// Base class for container file implementations
    /// </summary>
    public abstract class Container : IContainer, IDisposable {

        /// <summary>The underlying file stream</summary>
        public JBCDStream JBCDStream { get; protected set; }

        /// <summary>The byte offset from the start of the file for Record 1</summary>
        public virtual long StartOfData { get; protected set; }


        /// <summary>The encoding to use for creating the FrameHeader entry</summary>
        public DataEncoding DataEncoding { get; protected set; }

        /// <summary>The value of the last frame index</summary>
        public virtual long FrameCount { get; protected set; }

        /// <summary>The current frame data</summary>
        public virtual byte[] FrameData { get; protected set; }

        /// <summary>True if the read position is at the end of the file.</summary>
        public virtual bool EOF => JBCDStream.EOF;

        /// <summary>The byte offset from the start of the file for the 
        /// first byte of the current frame.</summary>
        public virtual long Position => JBCDStream.PositionRead;


        /// <summary>The current frame header as binary data</summary>
        public virtual byte[] FrameHeader {
            get {
                return _FrameHeader;
                }
            protected set {
                _FrameHeader = value;
                _ContainerHeader = null;
                }
            }
        byte[] _FrameHeader = null;

        /// <summary>The current frame payload as binary data</summary>
        public virtual byte[] FramePayload { get; protected set; }


        /// <summary>
        /// The container header structure
        /// </summary>
        protected ContainerHeader _ContainerHeader = null;

        /// <summary>The current frame header as a parsed object.</summary>
        public virtual ContainerHeader ContainerHeader {
            get {
                _ContainerHeader = _ContainerHeader ?? ContainerHeader.FromJSON(_FrameHeader.JSONReader(), false);
                return _ContainerHeader;
                }
            }


        /// <summary>
        /// The first container header. This is read only since it is fixed after
        /// the record is written.
        /// </summary>
        public ContainerHeaderFirst ContainerHeaderFirst { get; protected set; }


        /// <summary>
        /// Perform sanity checking on a list of container headers.
        /// </summary>
        /// <param name="Headers">List of headers to check</param>
        public abstract void CheckContainer (List<ContainerHeader> Headers);




        /// <summary>
        /// Dispose method, frees all resources.
        /// </summary>
        public void Dispose () {
            Dispose(true);
            GC.SuppressFinalize(this);
            }

        bool disposed = false;
        /// <summary>
        /// Dispose method, frees resources when disposing, 
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose (bool disposing) {
            if (disposed) {
                return;
                }

            if (disposing) {
                DisposeJBCDStream?.Dispose();
                }

            disposed = true;
            }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~Container () {
            Dispose(false);
            }


        /// <summary>
        /// The underlying stream reader/writer for the container. This will be disposed of when
        /// the container is released.
        /// </summary>
        JBCDStream DisposeJBCDStream = null;

        /// <summary>
        /// Open or create container according to the setting of FileStatus. The underlying 
        /// filestreams will be disposed of automatically when the container is disposed.
        /// </summary>
        /// <param name="Filename">The file name.</param>
        /// <param name="FileStatus">The file access mode.</param>
        /// <param name="ContainerType">Specifies the container type if a new container is to
        /// be created. This setting is ignored if the container already exists.</param>
        /// <returns>The new container.</returns>
        public static Container Open (
                        string Filename,
                        FileStatus FileStatus = FileStatus.Read,
                        ContainerType ContainerType = ContainerType.Chain) {

            var JBCDStream = new JBCDStream(Filename, FileStatus);

            var Container = OpenExisting(JBCDStream);
            Container.DisposeJBCDStream = JBCDStream;

            return Container;
            }


        /// <summary>
        /// Open an existing container according to the information contained in the next frame to be read.
        /// </summary>
        /// <param name="JBCDStream">The frame reader. Since this is passed to the
        /// method to create the class it is not disposed with the container using it.</param>
        /// <returns></returns>
        public static Container OpenExisting (
                        JBCDStream JBCDStream) {
            var Found = JBCDStream.ReadFrame(out var Header, out var FrameData);
            var ContainerHeader = Cryptography.Dare.ContainerHeaderFirst.FromJSON(Header.JSONReader(), false);


            var Position1 = JBCDStream.PositionRead; // is always positioned after the first record on entry.
            CryptoProviderDigest DigestProvider = CryptoCatalog.Default.GetDigest(CryptoAlgorithmID.Default);

            long FrameCount = 0;
            ContainerHeader FinalContainerHeader;
            if (Position1 < JBCDStream.Length) {
                FinalContainerHeader = JBCDStream.ReadLastFrameHeader();
                FrameCount = FinalContainerHeader.Index + 1;
                }
            else {
                FinalContainerHeader = ContainerHeader;
                }

            var LastPosition = JBCDStream.StartLastFrameRead;

            Container Container;
            switch (ContainerHeader.ContainerType) {
                case ContainerSimple.Label: {
                    Container = new ContainerSimple() {
                        JBCDStream = JBCDStream,
                        ContainerHeaderFirst = ContainerHeader,
                        StartOfData = Position1,
                        FrameCount = FrameCount
                        };
                    break;
                    }
                case ContainerSimple.LabelDigest: {
                    Container = new ContainerSimple() {
                        JBCDStream = JBCDStream,
                        DigestProvider = DigestProvider,
                        ContainerHeaderFirst = ContainerHeader,
                        StartOfData = Position1,
                        FrameCount = FrameCount
                        };
                    break;
                    }
                case ContainerChain.Label: {
                    Container = new ContainerChain() {
                        JBCDStream = JBCDStream,
                        DigestProvider = DigestProvider,
                        ContainerHeaderFirst = ContainerHeader,
                        StartOfData = Position1,
                        FrameCount = FrameCount
                        };
                    break;
                    }
                case ContainerTree.Label: {
                    Container = new ContainerTree() {
                        JBCDStream = JBCDStream,
                        DigestProvider = DigestProvider,
                        ContainerHeaderFirst = ContainerHeader,
                        StartOfData = Position1,
                        FrameCount = FrameCount
                        };
                    break;
                    }
                case ContainerMerkleTree.Label: {
                    Container = new ContainerMerkleTree() {
                        JBCDStream = JBCDStream,
                        DigestProvider = DigestProvider,
                        ContainerHeaderFirst = ContainerHeader,
                        StartOfData = Position1,
                        FrameCount = FrameCount
                        };
                    break;
                    }
                default: {
                    throw new NYI();
                    }
                }

            // initialize the Frame index dictionary
            Container.FillDictionary(FinalContainerHeader, Position1, LastPosition);
            JBCDStream.PositionRead = Position1;

            return Container;
            }

        /// <summary>
        /// Create a new container file of the specified type and write the initial
        /// data record
        /// </summary>
        /// <param name="Filename">The file to open</param>
        /// <param name="FileStatus">The file status.</param>
        /// <param name="Payload">Optional data payload. </param>
        /// <param name="ContentType">Content type of the optional data payload</param>
        /// <param name="ContainerType">The container type.</param>
        /// <param name="DataEncoding">The data encoding.</param>
        /// <param name="DigestAlgorithm">The digest algorithm to be used to calculate the PayloadDigest</param>
        /// <param name="EncryptedKey">Key used to encrypt the payload.</param>
        /// <param name="Signatures">List of JWS signatures. Since this is the first block, the signature
        /// is always over the payload data only.</param>
        /// <param name="Recipients">List of JWE recipient decryption entries.</param>
        /// <returns>The newly constructed container.</returns>
        /// <exception cref="InvalidFileModeException">The file mode specified was not valid.</exception>
        public static Container NewContainer (
                        string Filename,
                        FileStatus FileStatus,
                        ContainerType ContainerType = ContainerType.Chain,
                        byte[] Payload = null,
                        string ContentType = null,
                        DataEncoding DataEncoding = DataEncoding.JSON,
                        CryptoAlgorithmID DigestAlgorithm = CryptoAlgorithmID.Default,
                        byte[] EncryptedKey = null,
                        List<Signature> Signatures = null,
                        List<Recipient> Recipients = null
                        ) {

            Assert.True(FileStatus == FileStatus.New | FileStatus == FileStatus.Overwrite,
                InvalidFileModeException.Throw);

            var JBCDStream = new JBCDStream(Filename, FileStatus);
            var Container =  NewContainer(
                JBCDStream, ContainerType, Payload, ContentType, DataEncoding,
                DigestAlgorithm, EncryptedKey, Signatures, Recipients);
            Container.DisposeJBCDStream = JBCDStream;

            return Container;
            }

        /// <summary>
        /// Create a new container file of the specified type and write the initial
        /// data record
        /// </summary>
        /// <param name="JBCDStream">The underlying file stream. This MUST be opened
        /// in a read access mode and should have exclusive write access. All existing
        /// content in the file will be overwritten.</param>
        /// <param name="Payload">Optional data payload. </param>
        /// <param name="DataEncoding">The data encoding.</param>
        /// <param name="ContentType">Content type of the optional data payload</param>
        /// <param name="ContainerType">The container type. This determines whether
        /// a tree index is to be created or not and if so, whether </param>
        /// <param name="DigestAlgorithm">The digest algorithm to be used to calculate the PayloadDigest</param>
        /// <param name="EncryptedKey">Key used to encrypt the payload.</param>
        /// <param name="Signatures">List of JWS signatures. Since this is the first block, the signature
        /// is always over the payload data only.</param>
        /// <param name="Recipients">List of JWE recipient decryption entries.</param>
        /// <returns>The newly constructed container.</returns>
        public static Container NewContainer (
                        JBCDStream JBCDStream,
                        ContainerType ContainerType = ContainerType.Chain,
                        byte[] Payload = null,
                        string ContentType = null,
                        DataEncoding DataEncoding = DataEncoding.JSON,
                        CryptoAlgorithmID DigestAlgorithm = CryptoAlgorithmID.Default,
                        byte[] EncryptedKey = null,
                        List<Signature> Signatures = null,
                        List<Recipient> Recipients = null
                        ) {

            var Container = MakeNewContainer(JBCDStream, ContainerType);
            Container.DataEncoding = DataEncoding;
            Container.FrameData = Payload;

            Container.ContainerHeaderFirst.DataEncoding = DataEncoding.ToString();
            Container.ContainerHeaderFirst.ContentMeta = new ContentMeta() {
                ContentType = ContentType
                } ;
            Container.Append(Payload, Container.ContainerHeaderFirst);

            return Container;
            }

        /// <summary>
        /// Initialize the dictionaries used to manage the tree by registering the set
        /// of values leading up to the apex value.
        /// </summary>
        /// <param name="Header">Final frame header</param>
        /// <param name="FirstPosition">Position of frame 1</param>
        /// <param name="PositionLast">Position of the last frame</param>
        protected abstract void FillDictionary (
                    ContainerHeader Header, long FirstPosition, long PositionLast);



        /// <summary>
        /// Create a new container file of the specified type and write the initial
        /// data record
        /// </summary>
        /// <param name="JBCDStream">The underlying JBCDStream stream. This MUST be opened
        /// in a read access mode and should have exclusive read access. All existing
        /// content in the file will be overwritten.</param>
        /// <param name="ContainerType">The container type. This determines whether
        /// a tree index is to be created or not and if so, whether </param>
        /// <param name="DigestAlgorithm">The digest algorithm to be used to calculate the PayloadDigest</param>
        /// <returns>The newly constructed container.</returns>
        public static Container MakeNewContainer (
                        JBCDStream JBCDStream,
                        ContainerType ContainerType = ContainerType.Chain,
                        CryptoAlgorithmID DigestAlgorithm = CryptoAlgorithmID.Default) {

            switch (ContainerType) {
                case ContainerType.List:
                case ContainerType.Digest: {
                    return ContainerSimple.MakeNewContainer(JBCDStream, ContainerType);
                    }
                case ContainerType.Chain: {
                    return ContainerChain.MakeNewContainer(JBCDStream, ContainerType);
                    }
                case ContainerType.Tree: {
                    return ContainerTree.MakeNewContainer(JBCDStream, ContainerType);
                    }
                case ContainerType.MerkleTree: {
                    return ContainerMerkleTree.MakeNewContainer(JBCDStream, ContainerType);
                    }
                default: {
                    throw new InvalidContainerTypeException();
                    }
                }

            }


        /// <summary>
        /// Dictionary of frame index to frame position.
        /// </summary>
        public Dictionary<long, long> FrameIndexToPositionDictionary = 
            new Dictionary<long, long>();

        /// <summary>
        /// Register a frame in the container access dictionaries.
        /// </summary>
        /// <param name="Header">Frame header</param>
        /// <param name="Position">Position of the frame</param>
        protected virtual void RegisterFrame (ContainerHeader Header, long Position) {
            var Index = Header.Index;
            FrameIndexToPositionDictionary.Add(Index, Position);
            }

        /// <summary>
        /// Get the frame position.
        /// </summary>
        /// <param name="Frame">The frame index</param>
        /// <returns>The frame position.</returns>
        public virtual long GetFramePosition (long Frame) {
            var Found = FrameIndexToPositionDictionary.TryGetValue(Frame, out var Position);
            return Position;
            }

        /// <summary>
        /// Fill in the remaining header fields for the record.
        /// </summary>
        /// <param name="ContainerHeader"></param>
        public virtual void FillHeader (ContainerHeader ContainerHeader) {
            }


        /// <summary>
        /// Append a new data frame payload to the end of the file.
        /// </summary>
        /// <param name="Data">Data to append.</param>
        /// <param name="ContainerHeader">The container header value</param>
        /// <returns>The number of bytes written.</returns>
        public long Append (byte[] Data, ContainerHeader ContainerHeader = null) {
            return AppendFrame(Data, ContainerHeader);
            }

        /// <summary>
        /// Append a new data frame payload to the end of the file.
        /// </summary>
        /// <param name="Data">Data to append.</param>
        /// <param name="ContainerHeader">The container header value</param>
        /// <returns>The number of bytes written.</returns>
        public virtual long AppendFrame (byte[] Data, ContainerHeader ContainerHeader = null) {
            // Get the container header in the specified data encoding 
            // for the container without a type tag prefix.
            var Header = ContainerHeader.GetBytes(DataEncoding, false);

            FrameIndexToPositionDictionary.Add(ContainerHeader.Index, JBCDStream.Length);
            return AppendFrame(Header, Data);
            }


        /// <summary>
        /// Append a new data frame payload to the end of the file.
        /// </summary>
        /// <param name="Data">Data to append.</param>
        /// <param name="Header">The container header value</param>
        /// <returns>The number of bytes written.</returns>
        public long AppendFrame (byte[] Header, byte[] Data = null) {
            // Write the frame ensuring the results get written out.
            var Length = JBCDStream.WriteWrappedFrame(Header, Data);
            JBCDStream.Flush();

            return Length;
            }

        /// <summary>
        /// Append a new data frame payload to the end of the file.
        /// </summary>
        /// <param name="Data">Data to append.</param>
        /// <param name="Header">The container header value</param>
        /// <returns>The number of bytes written.</returns>
        public virtual long Append (JSONObject Data, ContainerHeader Header = null) {
            return Append(Data.GetJson(), Header);
            }

        /// <summary>
        /// Read the data in the current file 
        /// </summary>
        /// <param name="Direction">Direction in which to perform check.
        /// <list type="bullet"><item>1 = forward</item><item>-1 = forward</item>
        /// <item>0 = forward then backward.</item></list></param>
        /// <returns>True if the validation succeded, otherwise false.</returns>
        public virtual bool Validate (int Direction) {

            throw new NYI();
            }


        /// <summary>
        /// Move read pointer to Frame 1.
        /// </summary>
        /// <returns>True if a next frame exists, otherwise false</returns>
        public virtual bool Start () {
            JBCDStream.Seek(StartOfData, SeekOrigin.Begin);
            return JBCDStream.EOF;
            }

        /// <summary>
        /// Read the next frame in the file.
        /// </summary>
        /// <returns>True if a next frame exists, otherwise false</returns>
        public abstract bool Next ();

        /// <summary>
        /// Read the previous frame in the file.
        /// </summary>
        /// <returns>True if a previous frame exists, otherwise false</returns>
        public abstract bool Previous ();

        /// <summary>
        /// Read frame 1 in the file.
        /// </summary>
        /// <returns>True if a first frame exists, otherwise false</returns>
        public virtual bool First () {
            Start();
            return Next();
            }

        /// <summary>
        /// Read the last frame in the file.
        /// </summary>
        /// <returns>True if a last frame exists, otherwise false</returns>
        public virtual bool Last () {
            if (JBCDStream.Length <= StartOfData) {
                return false;
                }

            JBCDStream.End();
            return Previous();
            }

        /// <summary>
        /// Move to the frame with index Position in the file. 
        /// <para>If the tree positioning mechanism is in use, the
        /// time complexity for this operation is log2(n) where n is
        /// the difference between the current position and the new 
        /// position.</para>
        /// </summary>
        /// <param name="FrameIndex">Frame index to move to.</param>
        /// <returns>True if the position exists.</returns>
        public abstract bool Move (long FrameIndex);




        /* Operations on multiple files */

        /// <summary>
        /// Create a new container file of the specified type and write the initial
        /// data record
        /// </summary>
        /// <param name="NewFileStream">The underlying file stream. This MUST be opened
        /// in a read access mode and should have exclusive read access. All existing
        /// content in the file will be overwritten.</param>
        /// <param name="ContentHeader">Optional content header data. If specified this will completely overwrite
        /// the content header in the input files.</param>
        /// <param name="ContainerType">The container type. This determines the authentication mode
        /// to be employed.</param>
        /// <param name="IndexType">The index type.</param>
        /// <param name="FirstInput">If specified, open file stream to a file that will
        /// be used to pre-populate the file.</param>
        /// <param name="AdditionalInputs">If specified, a list of open file stream to files that will
        /// be used to pre-populate the file.</param>
        /// <param name="Filter">If specified, a delegate that is called exactly once for
        /// each container header encountered. Frame</param>
        /// <returns>The created container</returns>
        public static Container NewContainer (
                        JBCDStream NewFileStream,
                        JBCDStream FirstInput,
                        ContainerType ContainerType = ContainerType.Chain,
                        IndexType IndexType = IndexType.None,
                        List<JBCDStream> AdditionalInputs = null,
                        ContainerHeader ContentHeader = null,
                        FrameFilterDelegate Filter= null
                        ) {
            throw new NYI();

            }

        }

    /// <summary>
    /// Filter delegate. Returns true iff the container is of the type required.
    /// </summary>
    /// <param name="ContainerHeader">The container to be examined.</param>
    /// <returns>True if the container is required, otherwise false.</returns>
    public delegate bool FrameFilterDelegate (ContainerHeader ContainerHeader);
    }
