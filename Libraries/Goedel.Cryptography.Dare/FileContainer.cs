using Goedel.Cryptography.Jose;
using Goedel.IO;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Cryptography.Dare {

    // Feature: Record filenames when creating containers
    // Feature: Extract file by name
    // Feature: Sign and verify archives by Merkle tree
    // Feature: Use cloaked headers to conceal file names

    /// <summary>Specify chunking mode.</summary>
    public enum ChunkMode {
        /// <summary>The frame carries the complete data entry.</summary>
        Full,
        /// <summary>The frame carries a partial, non terminal chunk.</summary>
        Chunk,
        /// <summary>The frame carries the last chunk.</summary>
        Last
        }


    /// <summary>
    /// 
    /// </summary>
    public abstract class FileContainer : Disposable {


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
    public class FileContainerWriter : FileContainer {
        Container container = null;

        /// <summary>
        /// The class specific disposal routine.
        /// </summary>
        protected override void Disposing() {
            container?.Dispose();
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
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <returns>The newly constructed container.</returns>
        public FileContainerWriter(
                string fileName,
                CryptoParameters cryptoParameters,
                bool archive = false,
                bool digest = true,
                FileStatus fileStatus = FileStatus.Overwrite,
                ContainerType containerType = ContainerType.Unknown) {

            jbcdStream = new JbcdStream(fileName, fileStatus);
            container = BindContainer(jbcdStream, cryptoParameters, archive, digest, containerType);
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
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        public FileContainerWriter(
                JbcdStream jbcdStream,
                CryptoParameters cryptoParameters,
                bool archive = false,
                bool digest = true,
                ContainerType containerType = ContainerType.Unknown) => container = BindContainer(
                    jbcdStream, cryptoParameters, archive, digest, containerType);

        Container BindContainer(
                    JbcdStream jbcdStream,
                    CryptoParameters cryptoParameters,
                    bool archive = false,
                    bool digest = true,
                    ContainerType containerType = ContainerType.Unknown) {

            if (containerType == ContainerType.Unknown) {
                containerType = digest ? archive ? ContainerType.MerkleTree : ContainerType.Chain :
                    archive ? ContainerType.Tree : ContainerType.List;
                }

            if (jbcdStream.Length == 0) {
                return Container.NewContainer(jbcdStream, cryptoParameters, containerType);

                }
            else {
                return Container.Open(jbcdStream, null);
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
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <returns>File Container instance</returns>
        public static void File(
                string fileName,
                CryptoParameters cryptoParameters,
                byte[] data,
                ContentMeta contentMeta = null,
                FileStatus fileStatus = FileStatus.Overwrite
                ) {

            using var Writer = new FileContainerWriter(
                        fileName, cryptoParameters,
                        archive: false,
                        digest: false,
                        fileStatus: fileStatus, containerType: ContainerType.List);
            Writer.Add(data, cryptoParameters, contentMeta);
            }


        /// <summary>
        /// Open a new file container for write access and write a single file entry.
        /// </summary>
        /// <param name="dataIn">The content data</param>
        /// <param name="contentMeta">The content metadata</param>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <returns>File Container instance</returns>
        public static byte[] Data(
                byte[] dataIn,
                ContentMeta contentMeta = null,
                CryptoParameters cryptoParameters = null
                ) {

            var Stream = new MemoryStream();
            var JBCDStream = new JbcdStream(null, Stream);

            using (var Writer = new FileContainerWriter(JBCDStream, cryptoParameters, archive: false, digest: false,
                            containerType: ContainerType.List)) {
                Writer.Add(dataIn, cryptoParameters, contentMeta);
                }

            return Stream.ToArray();
            }


        /// <summary>
        /// Append a file entry.
        /// </summary>
        /// <param name="data">The content data</param>
        /// <param name="contentInfo">The content metadata</param>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        public void Add(
                byte[] data,
                CryptoParameters cryptoParameters,
                ContentMeta contentInfo = null) => container.Append(
                    data,
                    cryptoParameters,
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

            container.AppendFile(file, contentInfo);
            }

        /// <summary>
        /// Delete a file entry
        /// </summary>
        /// <param name="path">The path name attribute to give the file in the container</param>
        public void Delete(string path) => throw new NYI();

        /// <summary>
        /// Read a container data entry from one container and add it to this one.
        /// </summary>Add 
        /// <param name="containerDataReader">Frame reader from which the
        /// container data is to be read.</param>
        /// <param name="CryptoParameters">The new crypto parameters to be used to 
        /// write the container data.</param>
        public void Add(ContainerFrameIndex containerDataReader,
                CryptoParameters CryptoParameters = null) => throw new NYI();


        /// <summary>
        /// Append an archive frame to the container.
        /// </summary>
        /// <param name="signatures">List of JWS signatures. Since this is the first block, the signature
        /// is always over the payload data only.</param>
        public void AddIndex(List<KeyPair> signatures = null) => throw new NYI();


        }


    /// <summary>
    /// 
    /// </summary>
    public class FileContainerReader : FileContainer, IEnumerable<ContainerFrameIndex> {

        Container container = null;

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
        public IEnumerator<ContainerFrameIndex> GetEnumerator() => container.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();


        /// <summary>
        /// Open an existing file container in read mode.
        /// </summary>
        /// <param name="FileName">The file name to read</param>
        /// <param name="FileStatus">The mode to open the file in, this must be a mode
        /// that permits read access.</param>
        /// <param name="KeyCollection">Key collection to be used to resolve private key references.</param>
        /// <returns>File Container instance</returns>
        public FileContainerReader(
                string FileName,
                KeyCollection KeyCollection = null,
                FileStatus FileStatus = FileStatus.Read) {

            var JBCDStream = new JbcdStream(FileName, FileStatus);
            container = Goedel.Cryptography.Dare.Container.OpenExisting(JBCDStream, KeyCollection);
            }


        /// <summary>
        /// Open an existing file container in read mode.
        /// </summary>
        /// <param name="Data">The container data.</param>
        /// <param name="KeyCollection">Key collection to be used to resolve private key references.</param>
        public FileContainerReader(
                byte[] Data,
                KeyCollection KeyCollection = null) {

            var Stream = new MemoryStream(Data, 0, Data.Length, false);
            var JBCDStream = new JbcdStream(Stream, null);
            container = Goedel.Cryptography.Dare.Container.OpenExisting(JBCDStream, KeyCollection);

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
                KeyCollection KeyCollection,
                out byte[] Data,
                out ContentMeta ContentMeta) {

            using var Reader = new FileContainerReader(FileName, KeyCollection);
            var ContainerDataReader = Reader.container.GetContainerFrameIndex(
position: Reader.container.PositionFinalFrameStart);
            Data = ContainerDataReader.Payload;
            ContentMeta = ContainerDataReader?.Header.ContentMeta;
            }


        /// <summary>
        /// Create a FileReader for an in memory data source.
        /// </summary>
        /// <param name="DataIn"></param>
        /// <param name="Data"></param>
        /// <param name="ContentMeta"></param>
        public static void Data(
                byte[] DataIn,

                out byte[] Data,
                out ContentMeta ContentMeta) {

            using var Reader = new FileContainerReader(DataIn);
            Reader.Read(out Data, out ContentMeta);

            }

        /// <summary>
        /// Read an entry from a container. 
        /// </summary>
        /// <param name="Data">The data read.</param>
        /// <param name="ContentMeta">The metadata of the entry.</param>
        /// <param name="Index">Specify the index of the entry to read</param>
        /// <param name="Path">Specify a path value of an entry to read.</param>
        public void Read(
                out byte[] Data,
                out ContentMeta ContentMeta,
                int Index = -1,
                string Path = null) {

            var ContainerDataReader = container.GetContainerFrameIndex(Index);
            Data = ContainerDataReader.Payload;
            ContentMeta = ContainerDataReader?.Header.ContentMeta;


            }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="OutputFile"></param>
        /// <param name="Index"></param>
        /// <param name="Path"></param>
        public void ReadToFile(
                string OutputFile = null,
                int Index = -1,
                string Path = null) {
            var ContainerDataReader = container.GetContainerFrameIndex(Index);
            ContainerDataReader.CopyToFile(OutputFile);
            }

        /// <summary>
        /// Unpack a file archive
        /// </summary>
        /// <param name="OutputDirectory">The output directory path to which the
        /// data is to be written.</param>
        /// <param name="Selector">Optional selector to be used for filtering 
        /// (not implemented).</param>
        public void UnpackArchive(
            string OutputDirectory,
            string Selector = null) {

            foreach (var ContainerDataReader in container) {
                //Console.WriteLine($"Found entry");

                if (ContainerDataReader.HasPayload) {

                    var FilePath = ContainerDataReader?.Header?.ContentMeta?.Paths;
                    Assert.True(FilePath != null && FilePath.Count > 0);

                    var OutputFile = Path.Combine(OutputDirectory, FilePath[0]);


                    ContainerDataReader.CopyToFile(OutputFile);
                    //Container.WriteFrameToFile2(OutputFile);
                    }
                }
            }

        /// <summary>
        /// Copy data from this container to the specified container writer.
        /// </summary>
        /// <param name="FileContainerWriter">The container to be written to.</param>
        public void CopyArchive(FileContainerWriter FileContainerWriter) {
            foreach (var ContainerDataReader in container) {
                FileContainerWriter.Add(ContainerDataReader);

                }

            }


        /// <summary>
        /// Perform a Key Exchange
        /// </summary>
        /// <param name="Recipients">The list of recipients</param>
        /// <param name="AlgorithmID">The bulk encryption algorithm</param>
        /// <returns>The result of the key exchange.</returns>
        public virtual byte[] GetExchange(List<Recipient> Recipients, CryptoAlgorithmId AlgorithmID) => Decrypt(Recipients, AlgorithmID);



        /// <summary>
        /// Attempt to decrypt a decryption blob from a list of recipient entries.
        /// </summary>
        /// <param name="Recipients">The recipient entry.</param>
        /// <param name="AlgorithmID">The symmetric encryption cipher (used to decrypt the wrapped key).</param>
        /// <returns></returns>
        public byte[] Decrypt(List<Recipient> Recipients, CryptoAlgorithmId AlgorithmID) {
            foreach (var Recipient in Recipients) {

                var DecryptionKey = KeyCollection.Default.TryMatchRecipient(Recipient.Header.Kid);

                // Recipient has the following fields of interest
                // Recipient.EncryptedKey -- The RFC3394 wrapped symmetric key
                // Recipient.Header.Epk  -- The ephemeral public key
                // Recipient.Header.Epk.KeyPair  -- The ephemeral public key

                if (DecryptionKey != null) {
                    return DecryptionKey.Decrypt(Recipient.EncryptedKey, Recipient.Header.Epk.KeyPair, algorithmID: AlgorithmID);
                    }
                }


            throw new NoAvailableDecryptionKey();
            }


        }

    }
