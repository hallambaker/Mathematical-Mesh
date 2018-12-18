using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;

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
        protected override void Disposing () {
            }
        #endregion

        }

    /// <summary>
    /// 
    /// </summary>
    public class FileContainerWriter : FileContainer {
        Container Container=null;

        /// <summary>
        /// The class specific disposal routine.
        /// </summary>
        protected override void Disposing() {
            Container?.Dispose();
            JBCDStream.Dispose();
            }


        JBCDStream JBCDStream = null;


        /// <summary>
        /// Open a new file container for write access.
        /// </summary>
        /// <param name="FileName">The file name to create</param>
        /// <param name="Archive">If true, the container is intended to be used to create a multi-file
        /// archive.</param>
        /// <param name="Digest">If true, construct a digest </param>
        /// <param name="FileStatus">The mode to open the file in, this must be a mode
        /// that permits write access.</param>
        /// <param name="ContainerType">The container type to use. If unspecified,
        /// a type appropriate for the type of use will be selected.</param>
        /// <returns>File Container instance</returns>
        /// <param name="CryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <returns>The newly constructed container.</returns>
        public FileContainerWriter(
                string FileName,
                CryptoParameters CryptoParameters,
                bool Archive = false,
                bool Digest = true,
                FileStatus FileStatus = FileStatus.Overwrite,
                ContainerType ContainerType = ContainerType.Unknown)  {

            JBCDStream = new JBCDStream(FileName, FileStatus);
            Container = BindContainer(JBCDStream, CryptoParameters, Archive, Digest, ContainerType);
            }


        /// <summary>
        /// Open a new file container for write access.
        /// </summary>
        /// <param name="JBCDStream">The stream to use to write the container.</param>
        /// <param name="Archive">If true, the container is intended to be used to create a multi-file
        /// archive.</param>
        /// <param name="Digest">If true, construct a digest </param>

        /// <param name="ContainerType">The container type to use. If unspecified,
        /// a type appropriate for the type of use will be selected.</param>
        /// <returns>File Container instance</returns>
        /// <param name="CryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        public FileContainerWriter(
                JBCDStream JBCDStream,
                CryptoParameters CryptoParameters,
                bool Archive = false,
                bool Digest = true,
                ContainerType ContainerType = ContainerType.Unknown) => Container = BindContainer(
                    JBCDStream, CryptoParameters, Archive, Digest, ContainerType);

        Container BindContainer(
                    JBCDStream JBCDStream,
                    CryptoParameters CryptoParameters,
                    bool Archive = false,
                    bool Digest = true,
                    ContainerType ContainerType = ContainerType.Unknown) {

            if (ContainerType == ContainerType.Unknown) {
                ContainerType = Digest ? Archive ? ContainerType.MerkleTree : ContainerType.Chain :
                    Archive ? ContainerType.Tree : ContainerType.List;
                }

            if (JBCDStream.Length == 0) {
                return Container.NewContainer(JBCDStream, CryptoParameters, ContainerType);

                }
            else {
                return Container.Open(JBCDStream, null);
                }
            }


        /// <summary>
        /// Open a new file container for write access and write a single file entry.
        /// </summary>
        /// <param name="FileName">The file name to create</param>
        /// <param name="Data">The content data</param>
        /// <param name="ContentMeta">The content metadata</param>
        /// <param name="FileStatus">The mode to open the file in, this must be a mode
        /// that permits write access.</param>
        /// <param name="CryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <returns>File Container instance</returns>
        public static void File (
                string FileName,
                CryptoParameters CryptoParameters,
                byte[] Data,
                ContentMeta ContentMeta=null,
                FileStatus FileStatus = FileStatus.Overwrite
                ) {

            using (var Writer = new FileContainerWriter(
                        FileName, CryptoParameters,
                        Archive: false, 
                        Digest: false,
                        FileStatus: FileStatus, ContainerType: ContainerType.List)) {
                Writer.Add(Data, CryptoParameters, ContentMeta);
                }
            }


        /// <summary>
        /// Open a new file container for write access and write a single file entry.
        /// </summary>
        /// <param name="DataIn">The content data</param>
        /// <param name="ContentMeta">The content metadata</param>
        /// <param name="CryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <returns>File Container instance</returns>
        public static byte[] Data (
                byte[] DataIn,
                ContentMeta ContentMeta=null,
                CryptoParameters CryptoParameters=null
                ) {

            var Stream = new MemoryStream();
            var JBCDStream = new JBCDStream(null, Stream);

            using (var Writer = new FileContainerWriter(JBCDStream, CryptoParameters, Archive: false, Digest: false,
                            ContainerType: ContainerType.List)) {
                Writer.Add(DataIn, CryptoParameters, ContentMeta);
                }

            return Stream.ToArray();
            }


        /// <summary>
        /// Append a file entry.
        /// </summary>
        /// <param name="Data">The content data</param>
        /// <param name="ContentMeta">The content metadata</param>
        /// <param name="CryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        public void Add(
                byte[] Data,
            CryptoParameters CryptoParameters,
            ContentMeta ContentMeta=null) {
            var ContainerHeader = new ContainerHeader() {
                ContentMeta = ContentMeta
                };

            Container.Append(
                    Data,
                    CryptoParameters,
                    containerHeader: ContainerHeader);

            }

        /// <summary>
        /// Add a file entry
        /// </summary>
        /// <param name="File">The file to add</param>
        /// <param name="Path">The path name attribute to give the file in the container</param>
        public void Add(FileInfo File, string Path=null) => Add(File.FullName, Path);

        /// <summary>
        /// Add a file entry
        /// </summary>
        /// <param name="File">The file to add</param>
        /// <param name="Path">The path name attribute to give the file in the container</param>
        public void Add(string File, string Path = null) {

            var ContainerHeader = Path == null ? null : new ContainerHeader() {
                ContentMeta = new ContentMeta {
                    Paths = new List<string> { Path }
                    }
                };

            Container.AppendFile(File, ContainerHeader);
            }

        /// <summary>
        /// Read a container data entry from one container and add it to this one.
        /// </summary>
        /// <param name="ContainerDataReader">Frame reader from which the
        /// container data is to be read.</param>
        /// <param name="CryptoParameters">The new crypto parameters to be used to 
        /// write the container data.</param>
        public void Add(ContainerDataReader ContainerDataReader,
                CryptoParameters CryptoParameters = null) => Container.AppendFromStream(ContainerDataReader, ContainerDataReader.Length,
                ContainerDataReader.Header, CryptoParameters);

        /// <summary>
        /// Append an archive frame to the container.
        /// </summary>
        /// <param name="Signatures">List of JWS signatures. Since this is the first block, the signature
        /// is always over the payload data only.</param>
        public void AddIndex (List<KeyPair> Signatures = null) {

            }


        }


    /// <summary>
    /// 
    /// </summary>
    public class FileContainerReader : FileContainer {

        Container Container = null;

        /// <summary>
        /// The class specific disposal routine.
        /// </summary>
        protected override void Disposing() => Container?.Dispose();

        /// <summary>
        /// The number of entries in the container. Note that this will have to be 
        /// changed when entries spanning multiple frames are supported.
        /// </summary>
        public long Count => Container.FrameCount;


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

            var JBCDStream = new JBCDStream(FileName, FileStatus);
            Container = Goedel.Cryptography.Dare.Container.OpenExisting(JBCDStream, KeyCollection);

            //if (ReadIndex) {
            //    // here we read in the container index. Either from an archive referenced 
            //    // in the last frame or by scanning the entier container.
            //    throw new NYI();
            //    }
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
            var JBCDStream = new JBCDStream(Stream, null);
            Container = Goedel.Cryptography.Dare.Container.OpenExisting(JBCDStream, KeyCollection);

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

            using (var Reader = new FileContainerReader(FileName, KeyCollection)) {
                using (var ContainerDataReader = Reader.Container.GetFrameDataReader(
                            position:Reader.Container.PositionFinalFrameStart)) {
                    Data = ContainerDataReader.ToArray();
                    ContentMeta = ContainerDataReader?.Header.ContentMeta;
                    }



                //Reader.Read(out Data, out ContentMeta);
                }

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

            using (var Reader = new FileContainerReader(DataIn)) {
                Reader.Read(out Data, out ContentMeta);
                }

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


            var ContainerDataReader = Container.GetFrameDataReader(Index);
            Data = ContainerDataReader.ToArray();
            ContentMeta = ContainerDataReader?.Header.ContentMeta;

            //SetPosition(Index, Path);

            //Data = Container.ReadFrameData();
            //ContentMeta = Container.ContainerHeader.ContentMeta;
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
            //SetPosition(Index, Path);
            //Container.WriteFrameToFile(OutputFile);

            var ContainerDataReader = Container.GetFrameDataReader(Index);
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

            foreach (var ContainerDataReader in Container) {
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
            foreach (var ContainerDataReader in Container) {
                FileContainerWriter.Add(ContainerDataReader);

                }

            }


        /// <summary>
        /// Perform a Key Exchange
        /// </summary>
        /// <param name="Recipients">The list of recipients</param>
        /// <param name="AlgorithmID">The bulk encryption algorithm</param>
        /// <returns>The result of the key exchange.</returns>
        public virtual byte[] GetExchange(List<Recipient> Recipients, CryptoAlgorithmID AlgorithmID) => Decrypt(Recipients, AlgorithmID);



        /// <summary>
        /// Attempt to decrypt a decryption blob from a list of recipient entries.
        /// </summary>
        /// <param name="Recipients">The recipient entry.</param>
        /// <param name="AlgorithmID">The symmetric encryption cipher (used to decrypt the wrapped key).</param>
        /// <returns></returns>
        public byte[] Decrypt(List<Recipient> Recipients, CryptoAlgorithmID AlgorithmID) {
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
