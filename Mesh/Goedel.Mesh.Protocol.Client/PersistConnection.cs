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




    /// <summary>
    /// Container persisting entries for the connection catalog. This is the only type of catalog that
    /// is never synchronized to a service under any circumstance.
    /// </summary>
    public class PersistConnection : ContainerPersistenceStore {

        ///<summary></summary>
        public Connection DefaultEntry { get; private set; }

        ///<summary></summary>
        public PendingConnection DefaultPendingEntry { get; private set; }

        Dictionary<string, Connection> DictionaryLocal2Connection = new Dictionary<string, Connection>();

        ///<summary>Static initiaialization to force the static initialization of MeshItem and CatalogItem.</summary>
        static PersistConnection() {
            _ = MeshItem.Initialize;
            _ = ConnectionItem.Initialize;
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
        public PersistConnection(string fileName, string type = null,
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
            var catalogItem = containerStoreEntry.JsonObject as Connection;

            if (catalogItem.Local != null) {
                DictionaryLocal2Connection.AddSafe(catalogItem.Local, catalogItem);
                }

            switch (catalogItem) {
                case PendingConnection pendingEntry: {
                    DefaultPendingEntry = pendingEntry.Default ? pendingEntry : DefaultPendingEntry ?? pendingEntry;
                    break;
                    }
                case Connection adminEntry: {
                    DefaultEntry = adminEntry.Default ? adminEntry : DefaultEntry ?? adminEntry;
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
        /// Return a connection from the catalog by local name.
        /// </summary>
        /// <param name="local"></param>
        /// <returns></returns>
        public Connection GetConnection(string local = null) =>
            (local == null) ? DefaultEntry : DictionaryLocal2Connection.GetValue(local, null);
            

        public PendingConnection GetPending(string local = null) =>
            (local == null) ? DefaultPendingEntry : (DictionaryLocal2Connection.GetValue(local, null) as PendingConnection);


        }
    }
