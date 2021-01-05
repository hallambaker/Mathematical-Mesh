using Goedel.Cryptography.Jose;
using Goedel.IO;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Cryptography.Dare {




    /// <summary>
    /// Log reader
    /// </summary>
    public class DareLogReader : Disposable, IEnumerable<SequenceFrameIndex> {

        ///<summary>The underlying sequence</summary> 
        public Sequence Sequence { get; protected set; }


        /// <summary>
        /// The class specific disposal routine.
        /// </summary>
        protected override void Disposing() => Sequence?.Dispose();

        /// <summary>
        /// The number of entries in the container. Note that this will have to be 
        /// changed when entries spanning multiple frames are supported.
        /// </summary>
        public long Count => Sequence.FrameCount;

        /// <summary>
        /// Enumerate over the archive contents.
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<SequenceFrameIndex> GetEnumerator() => Sequence.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();


        ///<summary>The archive index</summary> 
        public FileCollection FileCollection = new ();

        ///<summary>The index position of the first file in the dictionary.</summary> 
        public int DictionaryStart { get; protected set; }


        ///<summary>Base constructor</summary> 
        protected DareLogReader() {
            }


        /// <summary>
        /// Open an existing file sequence in read mode.
        /// </summary>
        /// <param name="fileName">The file name to read</param>
        /// <param name="fileStatus">The mode to open the file in, this must be a mode
        /// that permits read access.</param>
        /// <param name="keyCollection">Key collection to be used to resolve private key references.</param>
        /// <param name="decrypt">If true attempt to decrypt the sequence contents.</param>
        /// <returns>File Container instance</returns>
        public DareLogReader(
                string fileName,
                IKeyLocate keyCollection = null,
                FileStatus fileStatus = FileStatus.Read, bool decrypt = true)  {
            Sequence = Sequence.OpenExisting(fileName, fileStatus, keyCollection, decrypt);
            DictionaryStart = Sequence.FrameIndexLast;
            }

        /// <summary>
        /// Compile an index over the sequence.
        /// </summary>
        public void GetIndex() {
            // Did we compile a complete index?
            if (DictionaryStart <= 0) {
                return; // already indexed
                }


            FileCollection.Add(Sequence.GetHeader(DictionaryStart), Sequence.Position);
            while (Sequence.Previous()) {
                FileCollection.Add(Sequence.Header, Sequence.Position);
                } 
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

            using var reader = new DareLogReader(FileName, KeyCollection);

            var container = reader.Sequence;
            var containerDataReader = container.GetSequenceFrameIndex(
                        position: container.PositionFinalFrameStart);
            Data = containerDataReader.GetPayload(container, KeyCollection);
            ContentMeta = containerDataReader?.Header.ContentMeta;
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

            var ContainerDataReader = Sequence.GetSequenceFrameIndex(index);
            Data = ContainerDataReader.GetPayload(Sequence, keyLocate);
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
                long index = -1,
                string path = null) {
            if (path != null) {
                GetIndex();
                FileCollection.DictionaryByPath.TryGetValue(path, out var entry).AssertTrue(FileNotFound.Throw);
                index = entry.Index;
                }

            var containerDataReader = Sequence.GetSequenceFrameIndex(index);
            containerDataReader.CopyToFile(Sequence, outputFile);
            }

        /// <summary>
        /// Unpack a file archive
        /// </summary>
        /// <param name="outputPath">The output directory path to which the
        /// data is to be written.</param>
        /// <param name="selector">Optional selector to be used for filtering 
        /// (not implemented).</param>
        public void UnpackArchive(
            string outputPath,
            string selector = null) {

            selector.Future();
            GetIndex();
            var outputDirectory = Path.GetFullPath(outputPath) + Path.DirectorySeparatorChar;

            // no, have to iterate over the archive.
            foreach (var entry in FileCollection.DictionaryByPath) {
                var fileEntry = entry.Value;

                // form the path here
                var destination = Path.Combine(outputDirectory, fileEntry.Path);

                var destinationInfo = new FileInfo(destination);
                var destinationDir = destinationInfo.Directory;

                // verify that the destination is a subdirectory of outputDirectory
                destinationDir.FullName.StartsWith(outputDirectory).AssertTrue(NYI.Throw);

                // Create the directory (if needed)
                if (!destinationDir.Exists) {
                    Directory.CreateDirectory(destinationDir.FullName);
                    }

                // unpack the file
                Screen.WriteLine($"File: {fileEntry.Path} Position is {fileEntry.Index}");
                var containerDataReader = Sequence.GetSequenceFrameIndex(fileEntry.Index);
                containerDataReader.CopyToFile(Sequence, destination);
                }

            }

        /// <summary>
        /// Copy data from this container to the specified container writer.
        /// </summary>
        /// <param name="fileContainerWriter">The container to be written to.</param>
        public void CopyArchive(DareLogWriter fileContainerWriter) {
            foreach (var ContainerDataReader in Sequence) {
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

    /// <summary>
    /// 
    /// </summary>
    public class DareLogWriter : DareLogReader {


        /// <summary>
        /// The class specific disposal routine.
        /// </summary>
        protected override void Disposing() => Sequence?.Dispose();


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
                SequenceType containerType = SequenceType.Unknown) :
                        this(new JbcdStream(fileName, fileStatus), archive, digest, containerType) {
            Sequence.DisposeJBCDStream = Sequence.JbcdStream;
            }


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
                SequenceType containerType = SequenceType.Unknown) {

            if (containerType == SequenceType.Unknown) {
                containerType = digest ? archive ? SequenceType.Merkle : SequenceType.Chain :
                    archive ? SequenceType.Tree : SequenceType.List;
                }

            if (jbcdStream.Length == 0) {

                Sequence = Sequence.NewContainer(jbcdStream, sequenceType: containerType);
                DictionaryStart = 0;
                }
            else {
                Sequence = Sequence.Open(jbcdStream, null);
                DictionaryStart = Sequence.FrameIndexLast;
                }

            }


        /// <summary>
        /// Append a file entry.
        /// </summary>
        /// <param name="data">The content data</param>
        /// <param name="contentInfo">The content metadata</param>
        public void AddData(
                byte[] data,
                ContentMeta contentInfo = null) => Sequence.Append(data, contentInfo);

        /// <summary>
        /// Add a file entry
        /// </summary>
        /// <param name="basePath">The base path of the file.</param>
        /// <param name="relativePath">The path of the file within the archive.</param>
        /// <param name="contentMeta">Metadata describing the content.</param>
        public void AddFile(
                string basePath,
                string relativePath,
                ContentMeta contentMeta = null) {
            var path = Path.Combine(basePath, relativePath);
            var fileinfo = new FileInfo(path);
            AddFile(basePath, fileinfo, contentMeta);
            }

        /// <summary>
        /// Add a file entry
        /// </summary>
        /// <param name="file">The file to add</param>
        /// <param name="path">The path name attribute to give the file in the container</param>
        /// <param name="contentMeta">Metadata describing the content.</param>
        public void AddFile(
                string path,
                FileInfo file,
                ContentMeta contentMeta = null) {

            var filename = Path.Combine(path, file.Name);
            contentMeta ??= new ContentMeta() {
                Filename = filename,
                };

            var index = Sequence.FrameCount;
            var position = Sequence.JbcdStream.PositionWrite;

            Sequence.AppendFile(file.FullName, contentMeta);


            FileCollection.Add(file, contentMeta.Filename, index, position);
            }

        /// <summary>
        /// Delete a file entry
        /// </summary>
        /// <param name="path">The path name attribute to give the file in the container</param>
        public bool Delete(string path) {
            GetIndex();

            if (FileCollection.DictionaryByPath.TryGetValue(path, out var fileEntry)) {
                return false;
                }

            var contentMeta = new ContentMeta() {
                Filename = path,
                Event = DareConstants.SequenceEventDeleteTag
                };
            var index = Sequence.FrameCount;

            Sequence.Append(contentMeta: contentMeta);

            FileCollection.Delete(path, index);

            return true;
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
            this.Future();

            throw new NYI();
            }

        /// <summary>
        /// Append an archive frame to the container.
        /// </summary>
        /// <param name="signatures">List of JWS signatures. Since this is the first block, the signature
        /// is always over the payload data only.</param>
        public void AddIndex(List<KeyPair> signatures = null) {

            GetIndex();
            var index = FileCollection.MakeIndex();

            Sequence.Append(index);


            signatures.Future();
            //throw new NYI();
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
        public static void ArchiveFile(
                string fileName,
                DarePolicy policy,
                byte[] data,
                ContentMeta contentMeta = null,
                FileStatus fileStatus = FileStatus.Overwrite
                ) {
            using var writer = new DareLogWriter(fileName, policy, true, true, fileStatus, SequenceType.Digest);
            writer.AddData(data, contentMeta);
            }

        /// <summary>
        /// Open a new file container for write access and append all the files in the directory 
        /// <paramref name="directory"/>.
        /// </summary>
        /// <param name="fileName">The file name to create</param>
        /// <param name="directory">The directory to append files from.</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <param name="fileStatus">The mode to open the file in, this must be a mode
        /// that permits write access.</param>
        /// <param name="policy">The cryptographic policy to be applied to the container.</param>
        /// <param name="index">If true add an index record to the end of the archive.</param>
        /// <returns>File Container instance</returns>
        public static void ArchiveDirectory(
                string fileName,
                DarePolicy policy,
                string directory,
                ContentMeta contentMeta = null,
                FileStatus fileStatus = FileStatus.Overwrite,
                bool index = true
                ) {

            using var writer = new DareLogWriter(fileName, policy, true, true, fileStatus, SequenceType.Merkle);

            var directoryInfo = new DirectoryInfo(directory);
            directoryInfo.Exists.AssertTrue(DirectoryNotFound.Throw);
            writer.AddDirectory(directoryInfo.Name, directoryInfo, contentMeta);

            if (index) {
                writer.AddIndex();
                }
            }

        /// <summary>
        /// Append all the files in the directory 
        /// <paramref name="directory"/>.
        /// </summary>
        /// <param name="directory">The directory to append files from.</param>
        /// <param name="directoryInfo">The directory descriptor.</param>
        /// <param name="contentMeta">The content metadata</param>
        public void AddDirectory(string directory, DirectoryInfo directoryInfo, ContentMeta contentMeta) {
            foreach (var fileInfo in directoryInfo.EnumerateFiles()) {
                AddFile(directory, fileInfo, contentMeta);

                }
            foreach (var directgoryInfo in directoryInfo.EnumerateDirectories()) {
                
                AddDirectory(Path.Combine(directory, directgoryInfo.Name), directgoryInfo, contentMeta);

                }
            }
        }




    }
