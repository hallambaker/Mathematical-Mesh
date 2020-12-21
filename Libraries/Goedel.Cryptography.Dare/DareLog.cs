using Goedel.Cryptography.Jose;
using Goedel.IO;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// Record tracking a file in an archive.
    /// </summary>
    public record FileEntry {

        ///<summary>The file path in canonical form.</summary> 
        public string Path;

        ///<summary>The creation time.</summary> 
        public DateTime? CreationTimeUtc;

        ///<summary>The last access time.</summary> 
        public DateTime? LastAccessTimeUtc;

        ///<summary>The last write time.</summary> 
        public DateTime? LastWriteTimeUtc;

        ///<summary>The file attributes mask.</summary> 
        public int Attributes;

        ///<summary>The index in the log.</summary> 
        public long Index;

        ///<summary>The position within the container.</summary> 
        public long Position;

        ///<summary>The index of the previous version of this file in the log.</summary> 
        public long Previous;

        ///<summary>The previous position within the container.</summary> 
        public long PreviousPosition;
        }

    /// <summary>
    /// Class tracking a set of files in a sequence.
    /// </summary>
    public class FileCollection {

        ///<summary>Dictionary mapping full names to file entries.</summary> 
        public SortedDictionary<string, FileEntry> DictionaryByPath = new ();

        /// <summary>
        /// Add an entry described by <paramref name="fileInfo"/> to the collection using
        /// <paramref name="relativeTo"/> as the relative path.
        /// </summary>
        /// <param name="fileInfo">File information block.</param>
        /// <param name="relativeTo">Point that the path is relative to.</param>
        /// <param name="index">Index of the frame in the sequence.</param>
        /// <param name="position">Position of the first byte of the frame.</param>
        /// <returns>The file entry created. This will contain relative links to the
        /// previous entry (if it exists).</returns>
        public FileEntry Add(FileInfo fileInfo, string relativeTo, long index, long position) {

            var path = Path.GetRelativePath(relativeTo, fileInfo.FullName);
            var result = new FileEntry() {
                Path = path,
                CreationTimeUtc = fileInfo.CreationTimeUtc,
                LastAccessTimeUtc = fileInfo.LastAccessTimeUtc,
                LastWriteTimeUtc = fileInfo.LastWriteTimeUtc,
                Attributes = (int)fileInfo.Attributes,
                Index = index,
                Position = position
                };

            if (DictionaryByPath.TryGetValue(path, out var previous)) {
                result.Previous = previous.Index;
                result.PreviousPosition = previous.Position;
                DictionaryByPath.Remove(path);
                }
            DictionaryByPath.Add(path, result);

            return result;
            }

        /// <summary>
        /// Delete the file entry <paramref name="path"/> from the sequence.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public FileEntry Delete(string path) {
            if (DictionaryByPath.TryGetValue(path, out var entry)) {
                DictionaryByPath.Remove(path);
                return entry;
                }
            else {
                return null;
                }

            }

        /// <summary>
        /// Make a sequence index from the specified values.
        /// </summary>
        /// <returns>The created index.</returns>
        public SequenceIndex MakeIndex() {

            var index = new SequenceIndex() {
                Positions = new List<IndexPosition>(),
                };

            Screen.WriteLine($"Start index {DictionaryByPath.Count} items");
            foreach (var item in DictionaryByPath) {
                var entry = item.Value;
                Screen.WriteLine($"    {entry.Index} {entry.Path}");

                var position = new IndexPosition() {
                    Index = (int) entry.Index,
                    Position = (int)entry.Position,
                    UniqueId = entry.Path
                    };
                index.Positions.Add(position);
                }

            return index;
            }

        }



    /// <summary>
    /// 
    /// </summary>
    public abstract class DareLog : Disposable {

        ///<summary>The archive index</summary> 
        public FileCollection FileCollection = new ();

        ///<summary>The index position of the first file in the dictionary.</summary> 
        public int DictionaryStart;

        #region IDisposable
        /// <summary>
        /// The class specific disposal routine.
        /// </summary>
        protected override void Disposing() {
            }
        #endregion

        }

    /// <summary>
    /// 
    /// </summary>
    public class DareLogWriter : DareLog {
        Sequence Sequence = null;

        /// <summary>
        /// The class specific disposal routine.
        /// </summary>
        protected override void Disposing() {
            Sequence?.Dispose();
            jbcdStream.Dispose();
            }


        JbcdStream jbcdStream = null;


        /// <summary>
        /// Open a new file container for write access.
        /// </summary>
        /// <param name="fileName">The file name to create</param>
        /// <param name="archive">If true, the container is intended to be used to create a multi-file
        /// archive.</param>
        /// <param name="digest">If true, construct a digest </param>
        /// <param name="fileStatus">The mode to open the file in, this must be a mode
        /// that permits write access.</param>
        /// <param name="containerType">The container type to use. If unspecified,
        /// a type appropriate for the type of use will be selected.</param>
        /// <returns>File Container instance</returns>
        /// <param name="policy">The cryptographic policy to be applied to the container.</param>
        /// <returns>The newly constructed container.</returns>
        public DareLogWriter(
                string fileName,
                DarePolicy policy,
                bool archive = false,
                bool digest = true,
                FileStatus fileStatus = FileStatus.Overwrite,
                ContainerType containerType = ContainerType.Unknown) :
                        this(new JbcdStream(fileName, fileStatus), archive, digest, containerType) { }


        /// <summary>
        /// Open a new file container for write access.
        /// </summary>
        /// <param name="jbcdStream">The stream to use to write the container.</param>
        /// <param name="archive">If true, the container is intended to be used to create a multi-file
        /// archive.</param>
        /// <param name="digest">If true, construct a digest </param>
        /// <param name="containerType">The container type to use. If unspecified,
        /// a type appropriate for the type of use will be selected.</param>
        /// <returns>File Container instance</returns>
        public DareLogWriter(
                JbcdStream jbcdStream,
                bool archive = false,
                bool digest = true,
                ContainerType containerType = ContainerType.Unknown) {

            if (containerType == ContainerType.Unknown) {
                containerType = digest ? archive ? ContainerType.Merkle : ContainerType.Chain :
                    archive ? ContainerType.Tree : ContainerType.List;
                }

            Sequence container;
            if (jbcdStream.Length == 0) {
                
                container = Sequence.NewContainer(jbcdStream, containerType: containerType);
                DictionaryStart = 0;
                }
            else {
                container = Sequence.Open(jbcdStream, null);
                DictionaryStart = container.FrameIndexLast;
                }

            }


        /// <summary>
        /// Open a new file container for write access and write a single file entry.
        /// </summary>
        /// <param name="fileName">The file name to create</param>
        /// <param name="data">The content data</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <param name="fileStatus">The mode to open the file in, this must be a mode
        /// that permits write access.</param>
        /// <param name="policy">The cryptographic policy to be applied to the container.</param>
        /// <returns>File Container instance</returns>
        public static void File(
                string fileName,
                DarePolicy policy,
                byte[] data,
                ContentMeta contentMeta = null,
                FileStatus fileStatus = FileStatus.Overwrite
                ) {

            using var Writer = new DareLogWriter(
                        fileName,
                        policy,
                        archive: false,
                        digest: false,
                        fileStatus: fileStatus, containerType: ContainerType.List);
            Writer.Add(data, contentMeta);
            }


        /// <summary>
        /// Open a new file container for write access and write a single file entry.
        /// </summary>
        /// <param name="dataIn">The content data</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <returns>File Container instance</returns>
        public static byte[] Data(
                byte[] dataIn,
                ContentMeta contentMeta = null
                ) {

            var Stream = new MemoryStream();
            var JBCDStream = new JbcdStream(null, Stream);

            using (var Writer = new DareLogWriter(JBCDStream, archive: false, digest: false,
                            containerType: ContainerType.List)) {
                Writer.Add(dataIn, contentMeta);
                }

            return Stream.ToArray();
            }


        /// <summary>
        /// Append a file entry.
        /// </summary>
        /// <param name="data">The content data</param>
        /// <param name="contentInfo">The content metadata</param>
        public void Add(
                byte[] data,
                ContentMeta contentInfo = null) => Sequence.Append(
                    data,
                    contentInfo);

        /// <summary>
        /// Add a file entry
        /// </summary>
        /// <param name="file">The file to add</param>
        /// <param name="path">The path name attribute to give the file in the container</param>
        public void Add(
                FileInfo file,
                string path = null) => Add(file.FullName, path);

        /// <summary>
        /// Add a file entry
        /// </summary>
        /// <param name="file">The file to add</param>
        /// <param name="path">The path name attribute to give the file in the container</param>
        public void Add(
                string file,
                string path = null) {


            var contentInfo = new ContentMeta() {
                Filename = file,
                Paths = new List<string> { path }
                };

            Sequence.AppendFile(file, contentInfo);
            ArchiveIndex.Add(file, Sequence.FrameIndexLast);
            }

        /// <summary>
        /// Delete a file entry
        /// </summary>
        /// <param name="path">The path name attribute to give the file in the container</param>
        public static void Delete(string path) {
            path.Future();
            throw new NYI();
            }

        /// <summary>
        /// Read a container data entry from one container and add it to this one.
        /// </summary>Add 
        /// <param name="containerDataReader">Frame reader from which the
        /// container data is to be read.</param>
        /// <param name="cryptoParameters">The new crypto parameters to be used to 
        /// write the container data.</param>
        public void Add(SequenceFrameIndex containerDataReader,
                CryptoParameters cryptoParameters = null) {
            containerDataReader.Future();
            cryptoParameters.Future();
            throw new NYI();
            }

        /// <summary>
        /// Append an archive frame to the container.
        /// </summary>
        /// <param name="signatures">List of JWS signatures. Since this is the first block, the signature
        /// is always over the payload data only.</param>
        public void AddIndex(List<KeyPair> signatures = null) {
            signatures.Future();
            throw new NYI();
            }


        public void MakeIndex() {

            }


        

        }


    /// <summary>
    /// 
    /// </summary>
    public class DareLogReader : DareLog, IEnumerable<SequenceFrameIndex> {

        Sequence container = null;

        /// <summary>
        /// The class specific disposal routine.
        /// </summary>
        protected override void Disposing() => container?.Dispose();

        /// <summary>
        /// The number of entries in the container. Note that this will have to be 
        /// changed when entries spanning multiple frames are supported.
        /// </summary>
        public long Count => container.FrameCount;

        /// <summary>
        /// Enumerate over the archive contents.
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<SequenceFrameIndex> GetEnumerator() => container.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();


        /// <summary>
        /// Open an existing file container in read mode.
        /// </summary>
        /// <param name="fileName">The file name to read</param>
        /// <param name="fileStatus">The mode to open the file in, this must be a mode
        /// that permits read access.</param>
        /// <param name="keyCollection">Key collection to be used to resolve private key references.</param>
        /// <returns>File Container instance</returns>
        public DareLogReader(
                string fileName,
                IKeyLocate keyCollection = null,
                FileStatus fileStatus = FileStatus.Read) {

            var JBCDStream = new JbcdStream(fileName, fileStatus);
            container = Sequence.OpenExisting(JBCDStream, keyCollection);
            }


        /// <summary>
        /// Open an existing file container in read mode.
        /// </summary>
        /// <param name="Data">The container data.</param>
        /// <param name="KeyCollection">Key collection to be used to resolve private key references.</param>
        public DareLogReader(
                byte[] Data,
                IKeyLocate KeyCollection = null) {

            var Stream = new MemoryStream(Data, 0, Data.Length, false);
            var JBCDStream = new JbcdStream(Stream, null);
            container = Sequence.OpenExisting(JBCDStream, KeyCollection);

            }

        /// <summary>
        /// Open a file container and then read and return the last entry in the file.
        /// </summary>
        /// <param name="FileName">The file name to create</param>
        /// <param name="Data">The content data</param>
        /// <param name="ContentMeta">The content metadata</param>
        /// <param name="KeyCollection">Key collection to be used to resolve private key references.</param>
        public static void File(
                string FileName,
                IKeyLocate KeyCollection,
                out byte[] Data,
                out ContentMeta ContentMeta) {

            using var Reader = new DareLogReader(FileName, KeyCollection);

            var container = Reader.container;
            var ContainerDataReader = container.GetContainerFrameIndex(
                        position: container.PositionFinalFrameStart);
            Data = ContainerDataReader.GetPayload(container, KeyCollection);
            ContentMeta = ContainerDataReader?.Header.ContentMeta;
            }


        /// <summary>
        /// Create a FileReader for an in memory data source.
        /// </summary>
        /// <param name="DataIn"></param>
        /// <param name="Data"></param>
        /// <param name="ContentMeta"></param>
        /// <param name="keyLocate">The key collection to be used to resolve keys</param>
        public static void Data(
                IKeyLocate keyLocate,
                byte[] DataIn,

                out byte[] Data,
                out ContentMeta ContentMeta) {

            using var Reader = new DareLogReader(DataIn);
            Reader.Read(keyLocate, out Data, out ContentMeta);

            }

        /// <summary>
        /// Read an entry from a container. 
        /// </summary>
        /// <param name="Data">The data read.</param>
        /// <param name="contentMeta">The metadata of the entry.</param>
        /// <param name="index">Specify the index of the entry to read</param>
        /// <param name="path">Specify a path value of an entry to read.</param>
        /// <param name="keyLocate">Key location instance.</param>
        public void Read(
                IKeyLocate keyLocate,
                out byte[] Data,
                out ContentMeta contentMeta,
                int index = -1,
                string path = null) {
            path.Future();

            var ContainerDataReader = container.GetContainerFrameIndex(index);
            Data = ContainerDataReader.GetPayload(container, keyLocate);
            contentMeta = ContainerDataReader?.Header.ContentMeta;
            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputFile"></param>
        /// <param name="index"></param>
        /// <param name="path"></param>
        public void ReadToFile(
                string outputFile = null,
                int index = -1,
                string path = null) {
            path.Future();

            var ContainerDataReader = container.GetContainerFrameIndex(index);
            SequenceFrameIndex.CopyToFile(outputFile);
            }

        /// <summary>
        /// Unpack a file archive
        /// </summary>
        /// <param name="outputDirectory">The output directory path to which the
        /// data is to be written.</param>
        /// <param name="selector">Optional selector to be used for filtering 
        /// (not implemented).</param>
        public void UnpackArchive(
            string outputDirectory,
            string selector = null) {
            
            selector.Future();

            foreach (var ContainerDataReader in container) {
                //Console.WriteLine($"Found entry");

                if (ContainerDataReader.HasPayload) {

                    var FilePath = ContainerDataReader?.Header?.ContentMeta?.Paths;
                    Assert.AssertTrue(FilePath != null && FilePath.Count > 0,
                        ArchiveEntryMissingFileName.Throw);

                    var OutputFile = Path.Combine(outputDirectory, FilePath[0]);


                    SequenceFrameIndex.CopyToFile(OutputFile);
                    //Container.WriteFrameToFile2(OutputFile);
                    }
                }
            }

        /// <summary>
        /// Copy data from this container to the specified container writer.
        /// </summary>
        /// <param name="fileContainerWriter">The container to be written to.</param>
        public void CopyArchive(DareLogWriter fileContainerWriter) {
            foreach (var ContainerDataReader in container) {
                fileContainerWriter.Add(ContainerDataReader);

                }

            }


        /// <summary>
        /// Perform a Key Exchange
        /// </summary>
        /// <param name="recipients">The list of recipients</param>
        /// <param name="algorithmID">The bulk encryption algorithm</param>
        /// <returns>The result of the key exchange.</returns>
        public virtual byte[] GetExchange(
                List<Recipient> recipients, 
                CryptoAlgorithmId algorithmID) => Decrypt(recipients, algorithmID);



        /// <summary>
        /// Attempt to decrypt a decryption blob from a list of recipient entries.
        /// </summary>
        /// <param name="recipients">The recipient entry.</param>
        /// <param name="algorithmID">The symmetric encryption cipher (used to decrypt the wrapped key).</param>
        /// <returns></returns>
        public static byte[] Decrypt(
                List<Recipient> recipients, 
                CryptoAlgorithmId algorithmID) {
            foreach (var Recipient in recipients) {

                if (KeyCollection.Default.TryFindKeyDecryption(Recipient.Header.Kid.Trim(), out var DecryptionKey)) {

                // Recipient has the following fields of interest
                // Recipient.EncryptedKey -- The RFC3394 wrapped symmetric key
                // Recipient.Header.Epk  -- The ephemeral public key
                // Recipient.Header.Epk.KeyPair  -- The ephemeral public key

                    return DecryptionKey.Decrypt(Recipient.EncryptedKey, Recipient.Header.Epk.KeyPair, algorithmID: algorithmID);
                    }
                }


            throw new NoAvailableDecryptionKey();
            }


        }

    }
