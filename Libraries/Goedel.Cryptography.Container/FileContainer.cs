using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.Container {

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
        Container Container;

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

            Container = Container.NewContainer(FileName, FileStatus, ContainerType);

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

            if (EncryptionKeys != null) {
                var Encoder = JoseWebEncryption.Encrypt(Data, out var Recipients, out var Protected, EncryptionKeys);

                var ContainerHeader = new ContainerHeader() {
                    ContentMeta = ContentMeta,
                    Recipients = Recipients,
                    Protected = Protected.ToJson(),
                    IV = Encoder.IV
                    };
                Container.Append(Encoder.OutputData, ContainerHeader);
                }
            else {

                var ContainerHeader = new ContainerHeader() {
                    ContentMeta = ContentMeta
                    };
                Container.Append(Data, ContainerHeader);
                }

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

        Container Container;

        /// <summary>
        /// The number of entries in the container. Note that this will have to be 
        /// changed when entries spanning multiple frames are supported.
        /// </summary>
        public long Count => Container.FrameCount;


        /// <summary>
        /// Open an existing file container in read mode.
        /// </summary>
        /// <param name="FileName">The file name to read</param>
        /// <param name="ReadIndex">If true, read the container index to permit random access</param>
        /// <param name="FileStatus">The mode to open the file in, this must be a mode
        /// that permits read access.</param>
        /// <returns>File Container instance</returns>
        public FileContainerReader (
                string FileName,
                bool ReadIndex = true,
                FileStatus FileStatus = FileStatus.Read) {

            var JBCDStream = new JBCDStream(FileName, FileStatus);
            Container = Goedel.Cryptography.Container.Container.OpenExisting(JBCDStream);

            if (ReadIndex) {
                // here we read in the container index. Either from an archive referenced 
                // in the last frame or by scanning the entier container.
                throw new NYI();
                }
            }


        /// <summary>
        /// Open 
        /// </summary>
        /// <param name="Data"></param>
        public FileContainerReader (
                byte[] Data) {

            var Stream = new MemoryStream(Data, 0, Data.Length, false);
            var JBCDStream = new JBCDStream(Stream, null);
            Container = Goedel.Cryptography.Container.Container.OpenExisting(JBCDStream);

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

            using (var Reader = new FileContainerReader(FileName, ReadIndex: false)) {
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
        /// <param name="Index">Specify the index of the entry to read.</param>
        /// <param name="Path">Specify a path value of an entry to read.</param>
        public void Read (
                out byte[] Data,
                out ContentMeta ContentMeta,
                int Index = -1,
                string Path = null) {

            if (Index >= 0 | Path != null) {
                throw new NYI();
                }
            else {
                Container.Last();
                }

            var ContainerHeader = Container.ContainerHeader;
            ContentMeta = ContainerHeader.ContentMeta;

            if (ContainerHeader.Protected == null) {
                Data = Container.FrameData;    
                return;
                }

            var Protected = Header.FromJSON(ContainerHeader.Protected.JSONReader(),false);
            var BulkID = Protected.Enc.FromJoseID();


            // This is breaking here because we don't yet know how to translate the key ID to a Key.
            var Exchange = GetExchange(ContainerHeader.Recipients, AlgorithmID: BulkID);

            var Provider = CryptoCatalog.Default.GetEncryption(BulkID);

            Data = Provider.Decrypt(Container.FrameData, Exchange, ContainerHeader.IV);

            }

        /// <summary>
        /// Perform a Key Exchange
        /// </summary>
        /// <param name="Recipients">The list of recipients</param>
        /// <param name="AlgorithmID">The bulk encryption algorithm</param>
        /// <returns>The result of the key exchange.</returns>
        public virtual byte[] GetExchange (List<Recipient> Recipients, CryptoAlgorithmID AlgorithmID) {
            return KeyCollection.Default.Decrypt(Recipients, AlgorithmID);
            }



        }

    /// <summary>
    /// Track a collection of keys from various sources allowing recall when required for recryption use.
    /// </summary>
    public class KeyCollection {

        /// <summary>
        /// The default collection.
        /// </summary>
        public static KeyCollection Default = new KeyCollection();

        Dictionary<string, KeyPair> DictionaryKeyPairByUDF = new Dictionary<string, KeyPair>();
        Dictionary<string, KeyPair> DictionaryKeyPairBySIN = new Dictionary<string, KeyPair>();
        Dictionary<string, KeyPair> DictionaryKeyPairByAccount = new Dictionary<string, KeyPair>();

        /// <summary>
        /// Add a keypair to the collection.
        /// </summary>
        /// <param name="KeyPair">The key pair to add.</param>
        public void Add (KeyPair KeyPair) {
            DictionaryKeyPairByUDF.AddSafe(KeyPair.UDF, KeyPair);
            if (KeyPair.Locator != null) {
                DictionaryKeyPairBySIN.AddSafe(KeyPair.StrongInternetName, KeyPair);
                DictionaryKeyPairByAccount.AddSafe(KeyPair.Locator, KeyPair);
                }

            }

        /// <summary>
        /// Add a recryption group account to the group.
        /// </summary>
        /// <param name="RecryptionGroup"></param>
        public void Add (string RecryptionGroup) {
            }




        /// <summary>
        /// Attempt to decrypt a decryption blob from a list of recipient entries.
        /// </summary>
        /// <param name="Recipients">The recipient entry.</param>
        /// <param name="AlgorithmID">The symmetric encryption cipher (used to decrypt the wrapped key).</param>
        /// <returns></returns>
        public byte[] Decrypt (List<Recipient> Recipients, CryptoAlgorithmID AlgorithmID) {
            foreach (var Recipient in Recipients) {

                var DecryptionKey = TryMatchRecipient(Recipient);

                // Recipient has the following fields of interest
                // Recipient.EncryptedKey -- The RFC3394 wrapped symmetric key
                // Recipient.Header.Epk  -- The ephemeral public key
                // Recipient.Header.Epk.KeyPair  -- The ephemeral public key

                if (DecryptionKey != null) {
                    return DecryptionKey.Decrypt(Recipient.EncryptedKey, Recipient.Header.Epk.KeyPair, AlgorithmID: AlgorithmID);
                    }
                }


            return null;
            }



        /// <summary>
        /// Attempt to find a private key for the specified recipient entry.
        /// </summary>
        /// <param name="Recipient">The recipient to match</param>
        /// <returns>True if a match is found, otherwise false.</returns>
        public KeyPair TryMatchRecipient (Recipient Recipient) {
            var KID = Recipient.Header.Kid;

            // Search our this.SessionPersonal = SessionPersonal;
            if (DictionaryKeyPairByUDF.TryGetValue(KID, out var KeyPair)) {
                return KeyPair;
                }
            if (DictionaryKeyPairBySIN.TryGetValue(KID, out KeyPair)) {
                return KeyPair;
                }
            if (DictionaryKeyPairByAccount.TryGetValue(KID, out KeyPair)) {
                return KeyPair;
                }

            // finally search local persistence stores.
            return KeyPair.FindLocal(KID);
            }
        }
    }
