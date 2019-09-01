using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.Dare {





    /// <summary>
    /// Persistence store based on a container interface.
    /// </summary>
    public class ContainerPersistenceStore : Disposable, IPersistenceStoreWrite, IEnumerable<ContainerStoreEntry> {

        // Test: Addition of signed frames to persistence stores (is failing)

        // Test: enumeration mechanisms, forward and reverse.

        // Goal: Implement indexing of containers, archives, etc.

        // Goal: Make use of Indexes.

        // Goal: implement locking mechanism


        #region --- Disposable objects
        //// Objects that MUST be disposed correctly when leaving a using section.
        //JBCDStream JBCDStream;

        ///<summary>The underlying container.</summary>
        public Container Container;



        /// <summary>The value of the last frame index</summary>
        public long FrameCount => Container.FrameCount;



        /// <summary>
        /// The disposal routine. This is wrapped to provide the IDisposable interface. 
        /// </summary>
        protected override void Disposing() => Container?.Dispose();
        #endregion


        /// <summary>Tag for new event</summary>
        public const string EventNew = "New";

        /// <summary>Tag for Update event</summary>
        public const string EventUpdate = "Update";

        /// <summary>Tag for Delete event</summary>
        public const string EventDelete = "Delete";

        /////<summary>The tag dictionary for decoding entries.</summary>
        //public static Dictionary<string, JSONFactoryDelegate> TagDictionary = tagDictionary ??
        //    new Dictionary<string, JSONFactoryDelegate>().CacheValue(out tagDictionary);
        //static Dictionary<string, JSONFactoryDelegate> tagDictionary;

        /// <summary>
        /// Add a dictionary to the persistence store decoder.
        /// </summary>
        /// <param name="dictionary">The dictionary to add</param>
        //public static Dictionary<string, JSONFactoryDelegate> AddDictionary(
        //            Dictionary<string, JSONFactoryDelegate> dictionary) {
        //    JSONObject.Append(TagDictionary, dictionary);
        //    return TagDictionary;
        //    }

        /// <summary>
        /// The default data encoding of payload items.
        /// </summary>
        public DataEncoding Encoding = DataEncoding.JSON;

        /// <summary>
        /// Index of items by _PrimaryKey
        /// </summary>
        Dictionary<string, ContainerStoreEntry> ObjectIndex = new Dictionary<string, ContainerStoreEntry>();

        /// <summary>
        /// Index of items by _PrimaryKey
        /// </summary>
        Dictionary<string, ContainerStoreEntry> DeletedObjects = new Dictionary<string, ContainerStoreEntry>();

        /// <summary>
        /// Dictionary mapping keywords to index for that keyword.
        /// </summary>
        Dictionary<string, ContainerStoreIndex> IndexDictionary =
                                new Dictionary<string, ContainerStoreIndex>();

        #region --- IEnumerable Implementation 
        ///<summary>Return an enumerator over a set of catalog items</summary>
        public IEnumerator<ContainerStoreEntry> GetEnumerator() => new EnumeratorContainerStoreEntry(ObjectIndex);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();

        private class EnumeratorContainerStoreEntry : IEnumerator<ContainerStoreEntry> {
            Dictionary<string, ContainerStoreEntry>.Enumerator BaseEnumerator;
            public ContainerStoreEntry Current => BaseEnumerator.Current.Value;
            object IEnumerator.Current => BaseEnumerator.Current.Value;
            public void Dispose() => BaseEnumerator.Dispose();
            public bool MoveNext() => BaseEnumerator.MoveNext();
            public void Reset() => throw new NotImplementedException();
            public EnumeratorContainerStoreEntry(Dictionary<string, ContainerStoreEntry> baseEnumerator) =>
                BaseEnumerator = baseEnumerator.GetEnumerator();
            }

        #endregion



        /// <summary>
        /// Open or create a persistence store in specified mode with 
        /// the specified file name, content type and optional comment.
        /// </summary>
        /// <param name="cryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="fileName">Log file.</param>
        /// <param name="contentType">Type of data to store (the schema name).</param>
        /// <param name="comment">Comment to be written to the log.</param>
        /// <param name="containerType">The Container type.</param>
        /// <param name="dataEncoding">The data encoding.</param>
        /// <param name="fileStatus">The file status in which to open the container.</param>
        /// <param name="keyCollection">The key collection to use to resolve private keys.</param>
        /// <param name="readContainer">If true read the container to initialize the persistence store.</param>
        public ContainerPersistenceStore(string fileName, string contentType = null,
                    string comment = null,
                    FileStatus fileStatus = FileStatus.OpenOrCreate,
                    ContainerType containerType = ContainerType.Chain,
                    DataEncoding dataEncoding = DataEncoding.JSON,
                    CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null,
                    bool readContainer = true) : this(
                        Container.Open(
                fileName,
                fileStatus,
                keyCollection ?? cryptoParameters?.KeyCollection,
                cryptoParameters,
                containerType,
                contentType
                ), readContainer) { }


        /// <summary>
        /// Create a persisetence store round an already opened container.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="readContainer"></param>
        public ContainerPersistenceStore(Container container, bool readContainer = true) {
            Container = container;
            try {
                if (readContainer & container.JBCDStream.Length > 0) {
                    ReadContainer(container.JBCDStream);
                    }
                }
            catch {
                Disposing();
                }
            }


        /// <summary>
        /// Read a container from the first frame to the last.
        /// </summary>
        /// <param name="Stream">The stream to read</param>
        void ReadContainer(JBCDStream Stream, ContainerIntegrity containerIntegrity = ContainerIntegrity.None) {

            foreach (var frameIndex in Container) {
                CommitTransaction(frameIndex);


                if (containerIntegrity != ContainerIntegrity.None) {
                    throw new NYI();
                    }

                }


            }


        /// <summary>
        /// Apply the specified message to the container.
        /// </summary>
        /// <param name="dareMessage"></param>
        public virtual void Apply(DareEnvelope dareMessage) {
            Container.Append(dareMessage);

            }


        #region Commit transaction to memory

        /// <summary>
        /// Commit a transaction to memory.
        /// </summary>
        /// <param name="contentInfo">The container header</param>
        /// <param name="data">The data to commit.</param>
        public virtual void CommitTransaction(ContainerFrameIndex frameIndex) {
            var contentInfo = frameIndex.Header.ContentInfo;

            ObjectIndex.TryGetValue(contentInfo.UniqueID, out var Previous);
            var ContainerStoreEntry = new ContainerStoreEntry(frameIndex, Previous, Container);

            switch (contentInfo.Event) {
                case EventNew: {
                    MemoryCommitNew(ContainerStoreEntry);
                    break;
                    }
                case EventUpdate: {
                    MemoryCommitUpdate(ContainerStoreEntry);
                    break;
                    }
                case EventDelete: {
                    MemoryCommitDelete(ContainerStoreEntry);
                    break;
                    }
                default: {
                    throw new NYI();
                    }
                }
            }

        /// <summary>
        /// Commit a New transaction to memory
        /// </summary>
        /// <param name="containerStoreEntry">The container store entry representing the transaction</param>
        protected virtual void MemoryCommitNew(ContainerStoreEntry containerStoreEntry) {
            // Check to make sure the object does not already exist
            Assert.False(ObjectIndex.ContainsKey(containerStoreEntry.UniqueID), NYI.Throw);
            ObjectIndex.Add(containerStoreEntry.UniqueID, containerStoreEntry);

            KeyValueIndexAdd(containerStoreEntry);
            }

        /// <summary>
        /// Commit an Update transaction to memory
        /// </summary>
        /// <param name="containerStoreEntry">The container store entry representing the transaction</param>
        protected virtual void MemoryCommitUpdate(ContainerStoreEntry containerStoreEntry) {
            // Check to make sure the object does not already exist
            if (ObjectIndex.ContainsKey(containerStoreEntry.UniqueID)) {
                ObjectIndex.Remove(containerStoreEntry.UniqueID);
                }
            ObjectIndex.Add(containerStoreEntry.UniqueID, containerStoreEntry);
            KeyValueIndexAdd(containerStoreEntry);
            }

        /// <summary>
        /// Commit a Delete transaction to memory
        /// </summary>
        /// <param name="containerStoreEntry">The container store entry representing the transaction</param>
        protected virtual void MemoryCommitDelete(ContainerStoreEntry containerStoreEntry) {
            // Check to make sure the object does not already exist
            Assert.True(ObjectIndex.ContainsKey(containerStoreEntry.UniqueID), NYI.Throw);
            ObjectIndex.Remove(containerStoreEntry.UniqueID);
            DeletedObjects.Add(containerStoreEntry.UniqueID, containerStoreEntry);

            KeyValueIndexDelete(containerStoreEntry);
            }


        // Hack: Right now the key value pairs are only indexed when the object is initially
        // interned. These are immutable subsequently.
        void KeyValueIndexAdd(ContainerStoreEntry containerStoreEntry) {
            if (containerStoreEntry.ContentInfo.KeyValues == null) {
                return;
                }

            foreach (var KeyValue in containerStoreEntry.ContentInfo.KeyValues) {
                var Index = GetContainerStoreIndex(KeyValue.Key, true);
                Index.Add(containerStoreEntry, KeyValue.Value);
                }
            }


        // Hack: Right now the key value pairs are only indexed when the object is initially
        // interned. These are immutable subsequently.
        void KeyValueIndexDelete(ContainerStoreEntry containerStoreEntry) {
            var First = containerStoreEntry.First as ContainerStoreEntry;
            if (First.ContentInfo.KeyValues == null) {
                return;
                }

            foreach (var KeyValue in First.ContentInfo.KeyValues) {
                var Index = GetContainerStoreIndex(KeyValue.Key, true);
                Index.Delete(containerStoreEntry, KeyValue.Value);
                }
            }

        #endregion

        #region Prepare and commit transaction to container

        public DareEnvelope Prepare(
                ContentInfo contentInfo, 
                JSONObject jsonObject, 
                Transaction transaction = null) {

            var contextWrite = new ContextWriteDeferred(Container);

            var data = jsonObject.GetBytes();
            return Container.Defer(contextWrite, contentInfo, data);

            }


        /// <summary>
        /// Write a persistence entry to the container.
        /// </summary>
        /// <param name="item">The object to write.</param>
        /// <param name="previous">The previous entry.</param>
        /// <returns></returns>
        public virtual ContainerStoreEntry CommitToContainer(
                DareEnvelope dareEnvelope,
                JSONObject item,
                ContainerStoreEntry previous=null) {

            Container.Append(dareEnvelope);
            return new ContainerStoreEntry(Container, dareEnvelope, previous, item);
            }


        #endregion

        #region Entry points for specific transactions

        /// <summary>
        /// Create a new persistence entry.
        /// </summary>
        /// <param name="jsonObject">Object to create</param>
        public virtual DareEnvelope PrepareNew(
                JSONObject jsonObject, Transaction transaction = null) {

            // Precondition UniqueID does not exist
            var Exists = ObjectIndex.TryGetValue(jsonObject._PrimaryKey, out var Previous);
            Assert.False(Exists, ObjectIdentifierNotUnique.Throw);

            // Create new container
            var contentInfo = new ContentInfo() {
                Event = EventNew,
                UniqueID = jsonObject._PrimaryKey,
                KeyValues = jsonObject._KeyValues.ToKeyValues()
                };

            return Prepare(contentInfo, jsonObject, transaction);
            }

        /// <summary>
        /// Create a container header to update an existing persistence entry
        /// </summary>

        /// <param name="previous">The previous container store entry for this object</param>
        /// <param name="jsonObject">The new object value</param>
        /// <param name="create">If true, create a new value if one does not already exist</param>
        public virtual DareEnvelope PrepareUpdate(
                    out ContainerStoreEntry previous,
                    JSONObject jsonObject,
                    bool create = true, Transaction transaction = null) {
            // Precondition UniqueID does not exist
            var Exists = ObjectIndex.TryGetValue(jsonObject._PrimaryKey, out previous);
            Assert.True(Exists | create, NYI.Throw);

            // Create new container
            var contentInfo = new ContentInfo() {
                Event = Exists ? EventUpdate : EventNew,
                UniqueID = jsonObject._PrimaryKey,
                KeyValues = jsonObject._KeyValues.ToKeyValues(),
                };

            if (Exists) {
                var First = previous?.First as ContainerStoreEntry;
                contentInfo.First = (int)First?.FrameCount;
                contentInfo.Previous = (int)previous?.FrameCount;
                }
            return Prepare(contentInfo, jsonObject, transaction);
            }

        /// <summary>
        /// Delete a persistence entry
        /// </summary>
        /// <param name="previous">The previous container store entry for this object</param>
        /// <param name="uniqueID">The UniqueID of the object to delete</param>
        /// <returns>True if the object was updated, otherwise false.</returns>
        public DareEnvelope PrepareDelete(
            out ContainerStoreEntry previous, string uniqueID, Transaction transaction = null) {
            var Exists = ObjectIndex.TryGetValue(uniqueID, out previous);
            if (!Exists) {
                return null;
                }

            var First = previous?.First as ContainerStoreEntry;
            // Create new container
            var contentInfo = new ContentInfo() {
                Event = EventDelete,
                UniqueID = uniqueID,
                Previous = (int)previous?.FrameCount,
                First = (int)First?.FrameCount
                };

            return Prepare(contentInfo, null, transaction);

            }

        /// <summary>
        /// Create a new persistence entry.
        /// </summary>
        /// <param name="jsonObject">Object to create</param>
        public virtual IPersistenceEntry New(JSONObject jsonObject, Transaction transaction = null) {
            var envelope = PrepareNew(jsonObject, transaction);
            var ContainerStoreEntry = CommitToContainer(envelope, jsonObject);
            MemoryCommitNew(ContainerStoreEntry);

            return ContainerStoreEntry;
            }


        /// <summary>
        /// Update an existing persistence entry
        /// </summary>
        /// <param name="jsonObject">The new object value</param>
        /// <param name="create">If true, create a new value if one does not already exist</param>
        public virtual IPersistenceEntry Update(JSONObject jsonObject, bool create = true, Transaction transaction = null) {

            var envelope = PrepareUpdate(out var Previous, jsonObject, create, transaction);

            var ContainerStoreEntry = CommitToContainer(envelope, jsonObject, Previous);
            MemoryCommitUpdate(ContainerStoreEntry);

            return ContainerStoreEntry;
            }

        /// <summary>
        /// Delete a persistence entry
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        /// <param name="uniqueID">The UniqueID of the object to delete</param>
        /// <returns>True if the object was updated, otherwise false.</returns>
        public virtual bool Delete(string uniqueID, Transaction transaction = null) {
            var envelope = PrepareDelete(out var Previous, uniqueID, transaction);
            if (envelope == null) {
                return false;
                }

            var ContainerStoreEntry = CommitToContainer(envelope, null, Previous);
            MemoryCommitDelete(ContainerStoreEntry);
            return true;
            }



        #endregion

        #region Navigation


        /// <summary>
        /// Return an index for the specified key, creating it if necessary.
        /// </summary>
        /// <param name="key">The key for which the index is requested.</param>
        /// <param name="create">If true, will create an index if none is found.</param>
        /// <returns>The index.</returns>
        public virtual ContainerStoreIndex GetContainerStoreIndex(string key, bool create = true) {
            var found = IndexDictionary.TryGetValue(key, out var Index);

            if (!found & create) {
                Index = new ContainerStoreIndex();
                IndexDictionary.Add(key, Index);
                }

            return (Index);
            }



        /// <summary>
        /// Return an index for the specified key, creating it if necessary.
        /// </summary>
        /// <param name="key">The key for which the index is requested.</param>
        /// <param name="create">If true, will create an index if none is found.</param>
        /// <returns>The index.</returns>
        public virtual IPersistenceIndex GetIndex(string key, bool create = true) =>
            GetContainerStoreIndex(key, create);


        /// <summary>
        /// Get object instance by unique identifier
        /// </summary>
        /// <param name="uniqueID">The unique identifier of the object instance to locate.</param>
        /// <returns>True if found, otherwise false.</returns>
        public IPersistenceEntry Get(string uniqueID) {
            var found = ObjectIndex.TryGetValue(uniqueID, out var result);
            return result;
            }

        /// <summary>
        /// Determines if a object instance with the specified unique identifier is registered.
        /// </summary>
        /// <param name="uniqueID">The unique identifier of the object instance to locate.</param>
        /// <returns>True if found, otherwise false.</returns>
        public bool Contains(string uniqueID) => ObjectIndex.TryGetValue(uniqueID, out var result);

        /// <summary>
        /// The last object instance that matches the specified key/value condition.
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value to match</param>
        /// <returns>The object instance if found, otherwise false.</returns>
        public IPersistenceIndexEntry Last(string key, string value) {
            var found = IndexDictionary.TryGetValue(key, out var Index);
            if (!found) {
                return null;
                }
            return Index.Last(value);
            }


        #endregion


        }


    public class Transaction {
        }

    }


