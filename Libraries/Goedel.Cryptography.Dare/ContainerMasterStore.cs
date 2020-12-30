using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Threading;


namespace Goedel.Cryptography.Dare {

    /// <summary>
    /// 
    /// </summary>
    public static class ContainerMasterStore {

        static Dictionary<string, ContainerPersistenceStoreThreadSafe> DictionaryChildren =
                    new Dictionary<string, ContainerPersistenceStoreThreadSafe>();


        static ContainerPersistenceStoreThreadSafe GetPersistenceStore(string ID, bool ReadOnly = false) {

            if (DictionaryChildren.TryGetValue(ID, out var Store)) {
                return Store;
                }

            return null;
            }


        /// <summary>
        /// Return a read-only handle for the specified persistence store.
        /// </summary>
        /// <param name="ID">The store to obtain the handle for.</param>
        /// <param name="ReadOnly">If true, the store is opened in read-only mode. 
        /// This is a global lock and prevents any other thread opening the same store in write mode</param>
        /// <returns>A read handle for the specified persistence store.</returns>
        public static ContainerPersistenceStoreHandleRead GetReadHandle(
                        string ID, bool ReadOnly = false) {

            var PersistenceStore = GetPersistenceStore(ID, ReadOnly);
            return PersistenceStore.GetHandleRead();
            }

        /// <summary>
        /// Return a read-write handle for the specified persistence store. For maximum performance, 
        /// an upgradeable lock is acquired initially and then updated to a write lock if a write
        /// operation is attempted.
        /// </summary>
        /// <param name="ID">The store to obtain the handle for.</param>
        /// <returns>A read/write handle for the specified persistence store.</returns>
        public static ContainerPersistenceStoreHandleWrite GetWriteHandle(
                string ID) {

            var PersistenceStore = GetPersistenceStore(ID);
            return PersistenceStore.GetHandleWrite();
            }

        /// <summary>
        /// Notifies the master store that a handle has been relinquished on a persistence store.
        /// This allows the master to see if the persistence store should be kept in memory or disposed.
        /// It might well make sense to allow stores to persist some length of time until
        /// there is a need to free up memory.
        /// </summary>
        /// <param name="PersistenceStore"></param>
        public static void FreedHandle(ContainerPersistenceStoreThreadSafe PersistenceStore) {
            }

        }

    /// <summary>
    /// A thread safe persistence store read handle.
    /// 
    /// The thread waits to acquire a read lock on the persistence store before proceeding.
    /// </summary>
    public class ContainerPersistenceStoreHandleRead :
                    Disposable, IPersistenceStoreRead, IDisposable {

        /// <summary>
        /// Timeout for lock acquisition in milliseconds. A time span of -1 represents 
        /// a wait forever.
        /// </summary>
        public TimeSpan Timeout { get; set; } = new TimeSpan(-1);

        /// <summary>
        /// If true, the persistence store is pinned and the in-memory structures for 
        /// accessing the store will be maintained even there are no outstanding read or
        /// write handles.
        /// </summary>
        public bool Pinned;

        /// <summary>
        /// The persistence store.
        /// </summary>
        protected ContainerPersistenceStoreThreadSafe PersistenceStore;

        /// <summary>
        /// Protected constructor sets the value of Pinned.
        /// </summary>
        /// <param name="Pinned">If true, maintain the persistence store in memory
        /// even when there are no outstanding access handles.</param>
        protected ContainerPersistenceStoreHandleRead(bool Pinned = true) => this.Pinned = Pinned;

        /// <summary>
        /// Construct a read handle for the specified persistence store.
        /// </summary>
        /// <param name="PersistenceStore">The persistence store to create a handle for.</param>
        /// <param name="Pinned">If true, maintain the persistence store in memory
        /// even when there are no outstanding access handles.</param>
        public ContainerPersistenceStoreHandleRead(
                    ContainerPersistenceStoreThreadSafe PersistenceStore,
                    bool Pinned = true) : this(Pinned) {
            this.PersistenceStore = PersistenceStore;
            PersistenceStore.ReaderWriterLock.TryEnterReadLock(Timeout);
            }

        /// <summary>
        /// The class specific disposal routine. This frees the read lock on the resource
        /// </summary>
        protected override void Disposing() {
            PersistenceStore.ReaderWriterLock.ExitReadLock();
            ContainerMasterStore.FreedHandle(PersistenceStore);
            }

        /// <summary>
        /// Determines if a object instance with the specified unique identifier is registered.
        /// </summary>
        /// <param name="UniqueID">The unique identifier of the object instance to locate.</param>
        /// <returns>True if found, otherwise false.</returns>
        public bool Contains(string UniqueID) => PersistenceStore.Contains(UniqueID);

        /// <summary>
        /// Get object instance by unique identifier
        /// </summary>
        /// <param name="UniqueID">The unique identifier of the object instance to locate.</param>
        /// <returns>True if found, otherwise false.</returns>
        public IPersistenceEntry Get(string UniqueID) => Get(UniqueID);

        /// <summary>
        /// Return an index for the specified key, creating it if necessary.
        /// </summary>
        /// <param name="Key">The key for which the index is requested.</param>
        /// <param name="Create">If true, will create an index if none is found.</param>
        /// <returns>The index.</returns>
        public IPersistenceIndex GetIndex(string Key, bool Create = true) => GetIndex(Key, Create);

        /// <summary>
        /// The last object instance that matches the specified key/value condition.
        /// </summary>
        /// <param name="Key">The key</param>
        /// <param name="Value">The value to match</param>
        /// <returns>The object instance if found, otherwise false.</returns>
        public IPersistenceIndexEntry Last(string Key, string Value) => Last(Key, Value);
        }

    /// <summary>
    /// A thread safe persistence store read/write handle. 
    /// 
    /// The thread waits to acquire an upgradeable lock on the persistence store before proceeding.
    /// This requires that no other thread be in upgradeable or write mode but allows other threads
    /// to have an outstanding read handle. 
    /// 
    /// While in upgradeable mode, the handle supports the same methods as a read handle but will
    /// wait to acquire a write lock on the store before executing any of the write methods.
    /// </summary>
    public class ContainerPersistenceStoreHandleWrite : ContainerPersistenceStoreHandleRead,
                  IPersistenceStoreWrite {

        /// <summary>
        /// Construct a write handle for the specified persistence store.
        /// </summary>
        /// <param name="PersistenceStore">The persistence store to create a handle for.</param>
        /// <param name="Pinned">If true, maintain the persistence store in memory
        /// even when there are no outstanding access handles.</param>
        public ContainerPersistenceStoreHandleWrite(
                ContainerPersistenceStoreThreadSafe PersistenceStore,
                bool Pinned = true) : base(Pinned) {
            this.PersistenceStore = PersistenceStore;
            PersistenceStore.ReaderWriterLock.TryEnterUpgradeableReadLock(Timeout);
            }

        /// <summary>
        /// The class specific disposal routine. This frees the read lock on the resource
        /// </summary>
        protected override void Disposing() {
            if (readMode) {
                PersistenceStore.ReaderWriterLock.ExitUpgradeableReadLock();
                }
            else {
                PersistenceStore.ReaderWriterLock.ExitWriteLock();
                }
            ContainerMasterStore.FreedHandle(PersistenceStore);
            }


        bool readMode = true;
        void GetWrite() {
            if (readMode) {
                PersistenceStore.ReaderWriterLock.TryEnterWriteLock(Timeout);
                readMode = false;
                }
            }

        /// <summary>
        /// Delete a persistence entry
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        /// <param name="UniqueID">The UniqueID of the object to delete</param>
        /// <param name="transaction">Optional transaction context. If specified, the 
        /// data is written in the specified transaction context allowing multiple 
        /// transactions to be staged and committed all or nothing.</param>
        /// <returns>True if the object was updated, otherwise false.</returns>
        public bool Delete(string UniqueID,
                Transaction transaction = null) {
            GetWrite();
            return PersistenceStore.Delete(UniqueID);
            }

        /// <summary>
        /// Create a new persistence entry.
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        /// <param name="Object">Object to create</param>
        /// <param name="transaction">Optional transaction context. If specified, the 
        /// data is written in the specified transaction context allowing multiple 
        /// transactions to be staged and committed all or nothing.</param>
        /// <returns>The persistence entry.</returns>
        public IPersistenceEntry New(JsonObject Object,
                Transaction transaction = null) {
            GetWrite();
            PersistenceStore.New(Object);
            return null;
            }

        /// <summary>
        /// Update an existing persistence entry
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        /// <param name="Object">The new object value</param>
        /// <param name="Create">If true, create a new value if one does not already exist</param>
        /// <param name="transaction">Optional transaction context. If specified, the 
        /// data is written in the specified transaction context allowing multiple 
        /// transactions to be staged and committed all or nothing.</param>
        /// <returns>The persistence entry.</returns>
        public IPersistenceEntry Update(JsonObject Object, bool Create = true,
                Transaction transaction = null) {
            GetWrite();
            PersistenceStore.Update(Object, Create);
            return null;
            }
        }


    /// <summary>
    /// A persistence store with support for thread safe locking.
    /// </summary>
    public class ContainerPersistenceStoreThreadSafe : PersistenceStore {

        #region Locking Mechanism

        /// <summary>
        /// The reader/writer lock
        /// </summary>
        public ReaderWriterLockSlim ReaderWriterLock = new ReaderWriterLockSlim();

        /// <summary>
        /// The identifier assigned by the persistence store directory.
        /// </summary>
        public string ID { get; set; } = null;

        #endregion


        /// <summary>
        /// Open or create a persistence store in specified mode with 
        /// the specified file name, content type and optional comment.
        /// </summary>
        /// <param name="FileName">Log file.</param>
        /// <param name="Type">Type of data to store (the schema name).</param>
        /// <param name="Comment">Comment to be written to the log.</param>
        /// <param name="ContainerType">The Container type.</param>
        /// <param name="policy">The cryptographic policy to be applied to the container.</param>
        /// <param name="DataEncoding">The data encoding.</param>
        /// <param name="FileStatus">The file status in which to open the container.</param>
        public ContainerPersistenceStoreThreadSafe(string FileName, string Type = null,
                    string Comment = null,
                    FileStatus FileStatus = FileStatus.OpenOrCreate,
                    SequenceType ContainerType = SequenceType.Chain,
                    DarePolicy policy = null,
                    DataEncoding DataEncoding = DataEncoding.JSON) : base(
                        FileName, Type, Comment, FileStatus, ContainerType, policy, DataEncoding) {
            }

        /// <summary>
        /// Return a read handle for the persistence store
        /// </summary>
        /// <param name="Pinned">If true, maintain the persistence store in memory
        /// even when there are no outstanding access handles.</param>
        /// <returns>The read handle</returns>
        public ContainerPersistenceStoreHandleRead GetHandleRead(bool Pinned = true) => new ContainerPersistenceStoreHandleRead(this, Pinned);

        /// <summary>
        /// Return a write handle for the persistence store
        /// </summary>
        /// <param name="Pinned">If true, maintain the persistence store in memory
        /// even when there are no outstanding access handles.</param>
        /// <returns>The read handle</returns>
        public ContainerPersistenceStoreHandleWrite GetHandleWrite(bool Pinned = true) => new ContainerPersistenceStoreHandleWrite(this, Pinned);

        }

    }
