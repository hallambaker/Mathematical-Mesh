using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;

using System.Collections.Generic;

namespace Goedel.Mesh.Client {


    //public class AccountDescription {
    //    public string Account;
    //    public ProfileAccount ProfileMesh;
    //    public ProfileDevice DefaultProfileDevice;
    //    public Dictionary<string, Mesh.CatalogedDevice> Devices = new Dictionary<string, Mesh.CatalogedDevice>();

    //    }




    /// <summary>
    /// Container persisting entries for the connection catalog. This is the only type of catalog that
    /// is never synchronized to a service under any circumstance.
    /// </summary>
    public class PersistHost : PersistenceStore {

        ///<summary></summary>
        public CatalogedMachine DefaultEntry { get; private set; }

        ///<summary></summary>
        public CatalogedPending DefaultPendingEntry { get; private set; }

        Dictionary<string, CatalogedMachine> DictionaryLocal2Connection = new Dictionary<string, CatalogedMachine>();

        ///<summary>Static initiaialization to force the static initialization of MeshItem and CatalogItem.</summary>
        static PersistHost() {
            _ = MeshItem.Initialize;
            _ = HostCatalogItem.Initialize;
            _ = MeshProtocol.Initialize;
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
        public PersistHost(string fileName, string type = null,
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
        protected override void MemoryCommitNew(StoreEntry containerStoreEntry) =>
            MemoryCommitUpdate(containerStoreEntry);

        /// <summary>
        /// Commit update to memory.
        /// </summary>
        /// <param name="containerStoreEntry">The store entry to commit.</param>
        protected override void MemoryCommitUpdate(StoreEntry containerStoreEntry) {
            var catalogItem = containerStoreEntry.JsonObject as CatalogedMachine;

            if (catalogItem.Local != null) {
                DictionaryLocal2Connection.AddSafe(catalogItem.Local, catalogItem);
                }

            switch (catalogItem) {
                case CatalogedPending pendingEntry: {
                    DefaultPendingEntry = pendingEntry.Default ? pendingEntry : DefaultPendingEntry ?? pendingEntry;
                    break;
                    }
                case CatalogedStandard adminEntry: {
                    if (DefaultEntry == null || adminEntry.Default || DefaultEntry.ID == adminEntry.ID) {
                        DefaultEntry = adminEntry;
                        }
                    break;
                    }
                case CatalogedMachine adminEntry: {
                    if (DefaultEntry == null || adminEntry.Default || DefaultEntry.ID == adminEntry.ID) {
                        DefaultEntry = adminEntry;
                        }
                    break;
                    }



                }

            base.MemoryCommitUpdate(containerStoreEntry);
            }

        /// <summary>
        /// Commit a Delete transaction to memory
        /// </summary>
        /// <param name="containerStoreEntry">The container store entry representing the transaction</param>
        protected override void MemoryCommitDelete(StoreEntry containerStoreEntry) {

            }

        ///// <summary>
        ///// Return a connection from the catalog by local name.
        ///// </summary>
        ///// <param name="local"></param>
        ///// <returns></returns>
        //public CatalogedMachine GetConnection(string local = null) =>
        //    (local == null) ? DefaultEntry : DictionaryLocal2Connection.GetValue(local, null);


        //public CatalogedPending GetPending(string local = null) =>
        //    (local == null) ? DefaultPendingEntry : (DictionaryLocal2Connection.GetValue(local, null) as CatalogedPending);


        }
    }
