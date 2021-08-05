#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion
using System;
using System.Collections;
using System.Collections.Generic;

using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Cryptography.Dare {





    /// <summary>
    /// Persistence store based on a container interface.
    /// </summary>
    public class PersistenceStore : Disposable, IPersistenceStoreWrite, IEnumerable<StoreEntry> {

        // Test: Addition of signed frames to persistence stores (is failing)

        // Test: enumeration mechanisms, forward and reverse.

        // Goal: Implement indexing of containers, archives, etc.

        // Goal: Make use of Indexes.

        // Goal: implement locking mechanism


        #region --- Disposable objects
        //// Objects that MUST be disposed correctly when leaving a using section.
        //JBCDStream JBCDStream;

        ///<summary>The underlying container.</summary>
        public Sequence Container;



        /// <summary>The value of the last frame index</summary>
        public long FrameCount => Container.FrameCount;



        /// <summary>
        /// The disposal routine. This is wrapped to provide the IDisposable interface. 
        /// </summary>
        protected override void Disposing() => 
                    Container?.Dispose();
        #endregion


        /// <summary>Tag for new event</summary>
        public const string EventNew = "New";

        /// <summary>Tag for Update event</summary>
        public const string EventUpdate = "Update";

        /// <summary>Tag for Delete event</summary>
        public const string EventDelete = "Delete";

        /// <summary>
        /// The default data encoding of payload items.
        /// </summary>
        public DataEncoding Encoding = DataEncoding.JSON;

        /// <summary>
        /// Index of items by _PrimaryKey
        /// </summary>
        public Dictionary<string, StoreEntry> ObjectIndex = new();

        /// <summary>
        /// Index of items by _PrimaryKey
        /// </summary>
        public Dictionary<string, StoreEntry> DeletedObjects = new();

        /// <summary>
        /// Dictionary mapping keywords to index for that keyword.
        /// </summary>
        public Dictionary<string, StoreIndex> IndexDictionary =
                                new();

        #region --- IEnumerable Implementation 
        ///<summary>Return an enumerator over a set of catalog items</summary>
        public IEnumerator<StoreEntry> GetEnumerator() => new EnumeratorContainerStoreEntry(ObjectIndex);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();

        private class EnumeratorContainerStoreEntry : IEnumerator<StoreEntry> {
            Dictionary<string, StoreEntry>.Enumerator baseEnumerator;
            public StoreEntry Current => baseEnumerator.Current.Value;
            object IEnumerator.Current => baseEnumerator.Current.Value;
            public void Dispose() => baseEnumerator.Dispose();
            public bool MoveNext() => baseEnumerator.MoveNext();
            public void Reset() => throw new NotImplementedException();
            public EnumeratorContainerStoreEntry(Dictionary<string, StoreEntry> baseEnumerator) =>
                this.baseEnumerator = baseEnumerator.GetEnumerator();
            }

        #endregion



        /// <summary>
        /// Open or create a persistence store in specified mode with 
        /// the specified file name, content type and optional comment.
        /// </summary>
        /// <param name="policy">The cryptographic policy to be applied to the container.</param>
        /// <param name="fileName">Log file.</param>
        /// <param name="contentType">Type of data to store (the schema name).</param>
        /// <param name="comment">Comment to be written to the log.</param>
        /// <param name="containerType">The Container type.</param>
        /// <param name="dataEncoding">The data encoding.</param>
        /// <param name="fileStatus">The file status in which to open the container.</param>
        /// <param name="keyCollection">The key collection to use to resolve private keys.</param>
        /// <param name="readContainer">If true read the container to initialize the persistence store.</param>
        /// <param name="decrypt">If false, the contents of the store will never be decrypted (deprecated, use CatalogBlind)</param>
        public PersistenceStore(string fileName, string contentType = null,
                    string comment = null,
                    FileStatus fileStatus = FileStatus.OpenOrCreate,
                    SequenceType containerType = SequenceType.Chain,
                    DarePolicy policy = null,
                    DataEncoding dataEncoding = DataEncoding.JSON,
                    IKeyLocate keyCollection = null,
                    bool readContainer = true,
                    bool decrypt = true) : this(
                        Sequence.Open(
                            fileName,
                            fileStatus,
                            keyCollection,
                            containerType,
                            policy,
                            contentType,
                            decrypt
                            ), keyCollection, readContainer) { }


        /// <summary>
        /// Create a persisetence store round an already opened container.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="readContainer"></param>
        /// <param name="keyLocate">The key collection to be used to resolve keys</param>
        public PersistenceStore(Sequence container, IKeyLocate keyLocate, bool readContainer = true) {
            container.AssertNotNull(NoAvailableDecryptionKey.Throw);

            Container = container;

            // Barfing in the docs because we do not have the key required to decrypt the container

            if (readContainer & container.JbcdStream.Length > 0) {
                ReadContainer(keyLocate);
                }
            }


        /// <summary>
        /// Read the container contents in fast mode generating indexes only without reading contents.
        /// </summary>
        public void FastReadContainer() {
            foreach (var frameIndex in Container) {
                var contentMeta = frameIndex.Header.ContentMeta;
                //var containerInfo = frameIndex.Header.SequenceInfo;

                var uniqueID = contentMeta.UniqueId;

                ObjectIndex.TryGetValue(uniqueID, out var previous);
                var ContainerStoreEntry = new StoreEntry(frameIndex, previous, Container);


                ObjectIndex.Remove(uniqueID);
                switch (contentMeta.Event) {
                    case EventUpdate:
                    case EventNew: {
                        ObjectIndex.Add(uniqueID, ContainerStoreEntry);
                        break;
                        }

                    default:
                    break;
                    }

                }

            }


        /// <summary>
        /// Read a container from the first frame to the last.
        /// </summary>
        /// <param name="containerIntegrity">Specifies the degree of container integrity checking to perform.</param>
        /// <param name="keyLocate">The key collection to be used to resolve keys</param>
        void ReadContainer(IKeyLocate keyLocate, SequenceIntegrity containerIntegrity = SequenceIntegrity.None) {

            foreach (var frameIndex in Container) {

                var item = frameIndex.GetJSONObject(Container);

                // This is failing on encrypted objects because the object isn't being decrypted.
                CommitTransaction(frameIndex, item);


                if (containerIntegrity != SequenceIntegrity.None) {
                    throw new NYI();
                    }

                }


            }


        /// <summary>
        /// Apply the specified message to the container.
        /// </summary>
        /// <param name="dareMessage"></param>
        public virtual void Apply(DareEnvelope dareMessage) {
            var frameIndex = Container.Append(dareMessage);

            CommitTransaction(frameIndex, dareMessage.JsonObject);
            }

        #region Commit transaction to memory

        /// <summary>
        /// Commit a transaction to memory.
        /// </summary>
        /// <param name="frameIndex">The container position</param>
        /// <param name="jSONObject">The object being committed in deserialized form.</param>
        public virtual void CommitTransaction(SequenceFrameIndex frameIndex, JsonObject jSONObject) {
            var contentMeta = frameIndex.Header.ContentMeta;

            ObjectIndex.TryGetValue(contentMeta.UniqueId, out var Previous);
            var ContainerStoreEntry = new StoreEntry(frameIndex, Previous, Container, jSONObject);

            switch (contentMeta.Event) {
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
                    throw new UndefinedStoreAction(contentMeta.Event);
                    }
                }
            }

        /// <summary>
        /// Commit a New transaction to memory
        /// </summary>
        /// <param name="containerStoreEntry">The container store entry representing the transaction</param>
        protected virtual void MemoryCommitNew(StoreEntry containerStoreEntry) {
            // Check to make sure the object does not already exist
            Assert.AssertFalse(ObjectIndex.ContainsKey(containerStoreEntry.UniqueID), EntryAlreadyExists.Throw);
            ObjectIndex.Add(containerStoreEntry.UniqueID, containerStoreEntry);

            KeyValueIndexAdd(containerStoreEntry);
            }

        /// <summary>
        /// Commit an Update transaction to memory
        /// </summary>
        /// <param name="containerStoreEntry">The container store entry representing the transaction</param>
        protected virtual void MemoryCommitUpdate(StoreEntry containerStoreEntry) {
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
        protected virtual void MemoryCommitDelete(StoreEntry containerStoreEntry) {
            // Check to make sure the object does not already exist
            Assert.AssertTrue(ObjectIndex.ContainsKey(containerStoreEntry.UniqueID), EntryNotFound.Throw);
            ObjectIndex.Remove(containerStoreEntry.UniqueID);
            DeletedObjects.Add(containerStoreEntry.UniqueID, containerStoreEntry);

            KeyValueIndexDelete(containerStoreEntry);
            }


        // Hack: Right now the key value pairs are only indexed when the object is initially
        // interned. These are immutable subsequently.
        void KeyValueIndexAdd(StoreEntry containerStoreEntry) {
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
        void KeyValueIndexDelete(StoreEntry containerStoreEntry) {
            var First = containerStoreEntry.First as StoreEntry;
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

        /// <summary>
        /// Prepare a transaction to be committed.
        /// </summary>
        /// <param name="contentInfo">The content metadata</param>
        /// <param name="jsonObject">The object.</param>
        /// 
        /// <returns>The prepared envelope.</returns>
        public DareEnvelope Prepare(
                ContentMeta contentInfo,
                JsonObject jsonObject) {

            var contextWrite = new SequenceWriterDeferred(Container);

            var data = jsonObject?.GetBytes();
            var envelope = Sequence.Defer(contextWrite, contentInfo, data);
            envelope.JsonObject = jsonObject;
            return envelope;
            }


        /// <summary>
        /// Write a persistence entry to the container.
        /// </summary>
        /// <param name="item">The object to write.</param>
        /// <param name="previous">The previous entry.</param>
        /// <param name="dareEnvelope">The serialized persistence data.</param>
        /// <returns></returns>
        public virtual StoreEntry CommitToContainer(
                DareEnvelope dareEnvelope,
                JsonObject item,
                StoreEntry previous = null) {

            Container.Append(dareEnvelope);
            return new StoreEntry(Container, dareEnvelope, previous, item);
            }


        #endregion

        #region Entry points for specific transactions

        /// <summary>
        /// Create a new persistence entry.
        /// </summary>
        /// <param name="jsonObject">Object to create</param>
        /// <param name="encryptionKey">Key under which the item is to be encrypted.</param>
        public virtual DareEnvelope PrepareNew(
                JsonObject jsonObject, CryptoKey encryptionKey = null) {

            encryptionKey.Future();

            // Precondition UniqueID does not exist
            var Exists = ObjectIndex.TryGetValue(jsonObject._PrimaryKey, out var Previous);
            Assert.AssertFalse(Exists, ObjectIdentifierNotUnique.Throw);

            // Create new container
            var contentInfo = new ContentMeta() {
                Event = EventNew,
                UniqueId = jsonObject._PrimaryKey,
                KeyValues = jsonObject._KeyValues.ToKeyValues()
                };

            return Prepare(contentInfo, jsonObject);
            }

        /// <summary>
        /// Create a container header to update an existing persistence entry
        /// </summary>

        /// <param name="previous">The previous container store entry for this object</param>
        /// <param name="jsonObject">The new object value</param>
        /// <param name="create">If true, create a new value if one does not already exist</param>
        /// <param name="encryptionKey">Key under which the item is to be encrypted.</param>
        public virtual DareEnvelope PrepareUpdate(
                    out StoreEntry previous,
                    JsonObject jsonObject,
                    bool create = true, CryptoKey encryptionKey = null) {

            encryptionKey.Future();

            // Precondition UniqueID does not exist
            var Exists = ObjectIndex.TryGetValue(jsonObject._PrimaryKey, out previous);
            Assert.AssertTrue(Exists | create, EntryNotFound.Throw);

            // Create new container
            var contentInfo = new ContentMeta() {
                Event = Exists ? EventUpdate : EventNew,
                UniqueId = jsonObject._PrimaryKey,
                KeyValues = jsonObject._KeyValues.ToKeyValues(),
                };

            if (Exists) {
                var First = previous?.First as StoreEntry;
                contentInfo.First = (int)First?.FrameCount;
                contentInfo.Previous = (int)previous?.FrameCount;
                }
            return Prepare(contentInfo, jsonObject);
            }

        /// <summary>
        /// Delete a persistence entry
        /// </summary>
        /// <param name="previous">The previous container store entry for this object</param>
        /// <param name="uniqueID">The UniqueID of the object to delete</param>
        /// <returns>True if the object was updated, otherwise false.</returns>
        /// 
        public DareEnvelope PrepareDelete(
            out StoreEntry previous, string uniqueID) {
            var Exists = ObjectIndex.TryGetValue(uniqueID, out previous);
            if (!Exists) {
                return null;
                }

            var First = previous?.First as StoreEntry;
            // Create new container
            var contentInfo = new ContentMeta() {
                Event = EventDelete,
                UniqueId = uniqueID,
                Previous = (int)previous?.FrameCount,
                First = (int)First?.FrameCount
                };

            return Prepare(contentInfo, null);

            }

        /// <summary>
        /// Create a new persistence entry.
        /// </summary>
        /// <param name="jsonObject">Object to create</param>
        /// <param name="transaction">The transaction context in which to prepare the update.</param>
        public virtual IPersistenceEntry New(JsonObject jsonObject, Transaction transaction = null) {
            var envelope = PrepareNew(jsonObject);
            var ContainerStoreEntry = CommitToContainer(envelope, jsonObject);
            MemoryCommitNew(ContainerStoreEntry);

            return ContainerStoreEntry;
            }


        /// <summary>
        /// Update an existing persistence entry
        /// </summary>
        /// <param name="jsonObject">The new object value</param>
        /// <param name="create">If true, create a new value if one does not already exist</param>
        /// <param name="transaction">The transaction context in which to perform the update.</param>
        public virtual IPersistenceEntry Update(JsonObject jsonObject, bool create = true, Transaction transaction = null) {

            var envelope = PrepareUpdate(out var Previous, jsonObject, create);

            var ContainerStoreEntry = CommitToContainer(envelope, jsonObject, Previous);
            MemoryCommitUpdate(ContainerStoreEntry);

            return ContainerStoreEntry;
            }

        /// <summary>
        /// Delete a persistence entry
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        /// <param name="uniqueID">The UniqueID of the object to delete</param>
        /// <param name="transaction">The transaction context in which to perform the update.</param>
        /// <returns>True if the object was updated, otherwise false.</returns>
        public virtual bool Delete(string uniqueID, Transaction transaction = null) {
            var envelope = PrepareDelete(out var Previous, uniqueID);
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
        public virtual StoreIndex GetContainerStoreIndex(string key, bool create = true) {
            var found = IndexDictionary.TryGetValue(key, out var Index);

            if (!found & create) {
                Index = new StoreIndex();
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
            ObjectIndex.TryGetValue(uniqueID, out var result);
            return result;
            }

        /// <summary>
        /// Determines if a object instance with the specified unique identifier is registered.
        /// </summary>
        /// <param name="uniqueID">The unique identifier of the object instance to locate.</param>
        /// <returns>True if found, otherwise false.</returns>
        public bool Contains(string uniqueID) => ObjectIndex.TryGetValue(uniqueID, out var _);

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

    /// <summary>
    /// Base class for transactions.
    /// </summary>
    public class Transaction {





        }

    }


