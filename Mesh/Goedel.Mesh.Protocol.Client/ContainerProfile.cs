using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Persistence;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh.Client {

    public class AccountDescription {
        public string Account;
        public AssertionAccount ProfileMesh;
        public ProfileDevice DefaultProfileDevice;
        public Dictionary<string, CatalogEntryDevice> Devices = new Dictionary<string, CatalogEntryDevice>();

        }

    public partial class CatalogItem {
        public static object Initialize => null;

        static CatalogItem() => ContainerPersistenceStore.AddDictionary(_TagDictionary);
        }


    public class ContainerProfile : ContainerPersistenceStore {


        //public ProfileDevice DefaultDeviceProfile =>
        //            DefaultAccountEntry.ProfileDevice ??
        //            DefaultPendingEntry.ProfileDevice ??
        //            DefaultAdminEntry.ProfileDevice;

        ///<summary></summary>
        public AdminEntry DefaultAdminEntry { get; private set; }

        ///<summary></summary>
        public AccountEntry DefaultAccountEntry { get; private set; }

        ///<summary></summary>
        public PendingEntry DefaultPendingEntry { get; private set; }


        static ContainerProfile() {
            _ = MeshItem.Initialize;
            _ = CatalogItem.Initialize;
            }

        /// <summary>
        /// Open or create a persistence store in specified mode with 
        /// the specified file name, content type and optional comment.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="fileName">Log file.</param>
        /// <param name="readOnly">If true, persistence store must exist
        /// and will be opened in read-only mode. If false, persistence store
        /// is opened in read/write mode and a new store will be created
        /// if none exists.</param>
        /// <param name="type">Type of data to store (the schema name).</param>
        /// <param name="comment">Comment to be written to the log.</param>
        /// <param name="containerType">The Container type.</param>
        /// <param name="dataEncoding">The data encoding.</param>
        /// <param name="fileStatus">The file status in which to open the container.</param>
        /// <param name="keyCollection">The key collection to use to resolve private keys.</param>
        /// <param name="readContainer">If true read the container to initialize the persistence store.</param>
        public ContainerProfile(string fileName, string type = null,
                    string comment = null, bool readOnly = false,
                    FileStatus fileStatus = FileStatus.ConcurrentLocked,
                    ContainerType containerType = ContainerType.Chain,
                    DataEncoding dataEncoding = DataEncoding.JSON,
                    CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null,
                    bool readContainer = true) : base(
                        fileName, type, comment, 
                        fileStatus, containerType, dataEncoding, cryptoParameters,
                        keyCollection, readContainer) {
            }



        /// <summary>
        /// Commit a New transaction to memory
        /// </summary>
        /// <param name="containerStoreEntry">The container store entry representing the transaction</param>
        protected override void MemoryCommitNew(ContainerStoreEntry containerStoreEntry) =>
            MemoryCommitUpdate(containerStoreEntry);


        protected override void MemoryCommitUpdate(ContainerStoreEntry containerStoreEntry) {
            var catalogItem = containerStoreEntry.JsonObject as CatalogItem;

            switch (catalogItem) {
                case AccountEntry accountEntry: {
                    DefaultAccountEntry = accountEntry.Default ? accountEntry : DefaultAccountEntry ?? accountEntry;
                    break;
                    }
                case AdminEntry adminEntry: {
                    DefaultAdminEntry = adminEntry.Default ? adminEntry : DefaultAdminEntry ?? adminEntry;
                    break;
                    }
                case PendingEntry pendingEntry: {
                    DefaultPendingEntry = pendingEntry.Default ? pendingEntry : DefaultPendingEntry ?? pendingEntry;
                    break;
                    }
                }


            }

        /// <summary>
        /// Commit a Delete transaction to memory
        /// </summary>
        /// <param name="containerStoreEntry">The container store entry representing the transaction</param>
        protected override void MemoryCommitDelete(ContainerStoreEntry containerStoreEntry) {

            }

        /// <summary>
        /// These are hacks of course because they only ever return the default profile.
        /// </summary>
        /// <param name="local"></param>
        /// <returns></returns>
        public AdminEntry GetAdmin(string local = null) => DefaultAdminEntry;
        public AccountEntry GetAccount(string local = null) => DefaultAccountEntry;
        public PendingEntry GetPending(string local = null) => DefaultPendingEntry;

        }
    }
