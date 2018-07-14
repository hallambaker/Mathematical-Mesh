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
        protected override void Disposing() => Container?.Dispose();

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
        /// <param name="Recipients">List of JWE recipient decryption entries.</param>
        /// <returns>The newly constructed container.</returns>
        public FileContainerWriter (
                string FileName,
                bool Archive = false,
                bool Digest = true,
                FileStatus FileStatus = FileStatus.Overwrite,
                List<KeyPair> Recipients = null,
                ContainerType ContainerType = ContainerType.Unknown) {

            if (ContainerType == ContainerType.Unknown) {
                ContainerType = Digest ? Archive ? ContainerType.MerkleTree : ContainerType.Chain :
                    Archive ? ContainerType.Tree : ContainerType.List;
                }

            Container = Container.NewContainer(FileName, 
                    FileStatus, ContainerType, EncryptionKeys: Recipients);

            }


        /// <summary>
        /// Open a new file container for write access.
        /// </summary>
        /// <param name="JBCDStream">The stream to use to write the container.</param>
        /// <param name="Archive">If true, the container is intended to be used to create a multi-file
        /// archive.</param>
        /// <param name="Digest">If true, construct a digest </param>
        /// <param name="FileStatus">The mode to open the file in, this must be a mode
        /// that permits write access.</param>
        /// <param name="ContainerType">The container type to use. If unspecified,
        /// a type appropriate for the type of use will be selected.</param>
        /// <returns>File Container instance</returns>
        /// <param name="Recipients">List of JWE recipient decryption entries.</param>
        /// <returns>The newly constructed container.</returns>
        public FileContainerWriter (
                JBCDStream JBCDStream,
                bool Archive = false,
                bool Digest = true,
                FileStatus FileStatus = FileStatus.Overwrite,
                List<KeyPair> Recipients = null,
                ContainerType ContainerType = ContainerType.Unknown) {
            if (ContainerType == ContainerType.Unknown) {
                ContainerType = Digest ? Archive ? ContainerType.MerkleTree : ContainerType.Chain :
                    Archive ? ContainerType.Tree : ContainerType.List;
                }
            Container = Container.NewContainer(JBCDStream, ContainerType);
            }

        /// <summary>
        /// Open a new file container for write access and write a single file entry.
        /// </summary>
        /// <param name="FileName">The file name to create</param>
        /// <param name="Data">The content data</param>
        /// <param name="ContentMeta">The content metadata</param>
        /// <param name="FileStatus">The mode to open the file in, this must be a mode
        /// that permits write access.</param>
        /// <param name="Recipients">List of JWE recipient decryption entries.</param>
        /// <returns>The newly constructed container.</returns>
        /// <returns>File Container instance</returns>
        public static void File (
                string FileName,
                byte[] Data,
                ContentMeta ContentMeta=null,
                FileStatus FileStatus = FileStatus.Overwrite,
                List<KeyPair> Recipients = null
                ) {

            using (var Writer = new FileContainerWriter(FileName, Archive: false, Digest: false,
                            FileStatus: FileStatus, ContainerType: ContainerType.List)) {
                Writer.Add(Data, ContentMeta, Recipients);
                }
            }


        /// <summary>
        /// Open a new file container for write access and write a single file entry.
        /// </summary>
        /// <param name="DataIn">The content data</param>
        /// <param name="ContentMeta">The content metadata</param>
        /// <param name="FileStatus">The mode to open the file in, this must be a mode
        /// that permits write access.</param>
        /// <param name="Recipients">List of JWE recipient decryption entries.</param>
        /// <returns>The newly constructed container.</returns>
        /// <returns>File Container instance</returns>
        public static byte[] Data (
                byte[] DataIn,
                ContentMeta ContentMeta=null,
                FileStatus FileStatus = FileStatus.Overwrite,
                List<KeyPair> Recipients = null
                ) {

            var Stream = new MemoryStream();
            var JBCDStream = new JBCDStream(null, Stream);

            using (var Writer = new FileContainerWriter(JBCDStream, Archive: false, Digest: false,
                            FileStatus: FileStatus, ContainerType: ContainerType.List)) {
                Writer.Add(DataIn, ContentMeta, Recipients);
                }

            return Stream.ToArray();
            }


        /// <summary>
        /// Append a file entry.
        /// </summary>
        /// <param name="Data">The content data</param>
        /// <param name="ContentMeta">The content metadata</param>
        /// <param name="EncryptionKeys">List of JWE recipient decryption entries.
        /// If null, the default key will be used if specified in the container
        /// header.</param>
        public void Add (
                byte[] Data,
                ContentMeta ContentMeta,
                List<KeyPair> EncryptionKeys = null) {
            var ContainerHeader = new ContainerHeader() {
                ContentMeta = ContentMeta
                };
            Container.Append(
                    Data, 
                    ContainerHeader: ContainerHeader, 
                    EncryptionKeys:EncryptionKeys);

            }




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

        Container Container=null;

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
        /// <returns>File Container instance</returns>
        public FileContainerReader (
                string FileName,
                FileStatus FileStatus = FileStatus.Read) {

            var JBCDStream = new JBCDStream(FileName, FileStatus);
            Container = Goedel.Cryptography.Dare.Container.OpenExisting(JBCDStream);

            //if (ReadIndex) {
            //    // here we read in the container index. Either from an archive referenced 
            //    // in the last frame or by scanning the entier container.
            //    throw new NYI();
            //    }
            }


        /// <summary>
        /// Open 
        /// </summary>
        /// <param name="Data"></param>
        public FileContainerReader (
                byte[] Data) {

            var Stream = new MemoryStream(Data, 0, Data.Length, false);
            var JBCDStream = new JBCDStream(Stream, null);
            Container = Goedel.Cryptography.Dare.Container.OpenExisting(JBCDStream);

            }

        /// <summary>
        /// Open a file container and then read and return the last entry in the file.
        /// </summary>
        /// <param name="FileName">The file name to create</param>
        /// <param name="Data">The content data</param>
        /// <param name="ContentMeta">The content metadata</param>
        public static void File (
                string FileName,
                out byte[] Data,
                out ContentMeta ContentMeta) {

            using (var Reader = new FileContainerReader(FileName)) {
                Reader.Read(out Data, out ContentMeta);
                }

            }

        /// <summary>
        /// Create a FileReader for an in memory data source.
        /// </summary>
        /// <param name="DataIn"></param>
        /// <param name="Data"></param>
        /// <param name="ContentMeta"></param>
        public static void Data (
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
        public void Read (
                out byte[] Data,
                out ContentMeta ContentMeta,
                int Index = -1,
                string Path = null) {

            if (Index >= 0) {
                Container.Move(Index);
                }
            else if(Path != null) {
                throw new NYI();  // ToDo: retrieve index by path val
                }
            else {
                Container.Last();
                }

            Data = Container.ReadFrameData();
            ContentMeta = Container.ContainerHeader.ContentMeta;
            }

        /// <summary>
        /// Perform a Key Exchange
        /// </summary>
        /// <param name="Recipients">The list of recipients</param>
        /// <param name="AlgorithmID">The bulk encryption algorithm</param>
        /// <returns>The result of the key exchange.</returns>
        public virtual byte[] GetExchange(List<Recipient> Recipients, CryptoAlgorithmID AlgorithmID) => KeyCollection.Default.Decrypt(Recipients, AlgorithmID);



        }

    }
