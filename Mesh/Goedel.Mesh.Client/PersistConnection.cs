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

        ///<summary>The default entry</summary>
        public CatalogedMachine DefaultEntry { get; private set; }

        /////<summary></summary>
        //public CatalogedPending DefaultPendingEntry { get; private set; }

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
        /// Get Mesh machine with the localname <paramref name="localName"/>
        /// </summary>
        /// <param name="localName">Name of the machine to fetch.</param>
        /// <returns>The machine if found, otherwise null.</returns>
        public CatalogedMachine GetByName(string localName) {
            foreach (var containerStoreEntry in this) {
                var catalogItem = containerStoreEntry.JsonObject as CatalogedMachine;

                if (localName != null & catalogItem.Local == localName) {
                    return catalogItem;
                    }
                }
            return null;
            }

        /// <summary>
        /// Get Mesh machine that matches <paramref name="localName"/> if specified, otherwise
        /// the default machine.
        /// </summary>
        /// <param name="localName">The machine to fetch.</param>
        /// <returns>The machine if found, otherwise null.</returns>
        public CatalogedMachine GetMachine(string localName = null) {
            if (localName != null) {
                return GetByName(localName);
                }

            CatalogedMachine defaultMachine = null;

            foreach (var containerStoreEntry in this) {
                var catalogItem = containerStoreEntry.JsonObject as CatalogedMachine;

                if (catalogItem.Default) {
                    defaultMachine = catalogItem;
                    }
                }
            return defaultMachine;
            }

        /// <summary>
        /// Gets the machine waiting for completion that mactches <paramref name="localName"/> if
        /// specified, or the default pending machine otherwise or the default preconfigured
        /// machine if not found.
        /// </summary>
        /// <param name="localName">The machine to fetch.</param>
        /// <returns>The machine if found, otherwise null.</returns>
        public CatalogedMachine GetForCompletion(string localName = null) {
            if (localName != null) {
                return GetByName(localName);
                }

            CatalogedMachine preconfiguredMachine = null;
            foreach (var containerStoreEntry in this) {
                var catalogItem = containerStoreEntry.JsonObject as CatalogedMachine;

                switch (catalogItem) {
                    case CatalogedPending _: {
                        return catalogItem;

                        // Hack: Should have a mechanism to time out connection attempts.
                        }
                    case CatalogedPreconfigured _: {
                        preconfiguredMachine = catalogItem;
                        break;
                        }
                    }

                }
            return preconfiguredMachine;
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
                //case CatalogedPending pendingEntry: {
                //    DefaultPendingEntry = pendingEntry.Default ? pendingEntry : DefaultPendingEntry ?? pendingEntry;
                //    break;
                //    }
                case CatalogedStandard adminEntry: {
                    if (DefaultEntry == null || adminEntry.Default || DefaultEntry.Id == adminEntry.Id) {
                        DefaultEntry = adminEntry;
                        }
                    break;
                    }
                case CatalogedMachine adminEntry: {
                    if (DefaultEntry == null || adminEntry.Default || DefaultEntry.Id == adminEntry.Id) {
                        DefaultEntry = adminEntry;
                        }
                    break;
                    }

                default:
                    break;
                }

            base.MemoryCommitUpdate(containerStoreEntry);
            }

        /// <summary>
        /// Commit a Delete transaction to memory
        /// </summary>
        /// <param name="containerStoreEntry">The container store entry representing the transaction</param>
        protected override void MemoryCommitDelete(StoreEntry containerStoreEntry) {

            }


        }
    }
