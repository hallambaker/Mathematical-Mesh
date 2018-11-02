using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Persistence;
using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.Dare {


    /// <summary>
    /// Persistence store based on a container interface.
    /// </summary>
    public class ContainerPersistenceStore : Disposable, IPersistenceStoreWrite,  IEnumerable<ContainerStoreEntry> {

        #region --- Disposable objects
        // Objects that MUST be disposed correctly when leaving a using section.
        JBCDStream JBCDStream;
        Container Container;

        /// <summary>
        /// The disposal routine. This is wrapped to provide the IDisposable interface. 
        /// </summary>
        protected override void Disposing () {
            JBCDStream?.Dispose();
            Container?.Dispose();
            }
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
        /// <param name="CryptoParameters">Specifies the cryptographic enhancements to
        /// be applied to this message.</param>
        /// <param name="FileName">Log file.</param>
        /// <param name="ReadOnly">If true, persistence store must exist
        /// and will be opened in read-only mode. If false, persistence store
        /// is opened in read/write mode and a new store will be created
        /// if none exists.</param>
        /// <param name="Type">Type of data to store (the schema name).</param>
        /// <param name="Comment">Comment to be written to the log.</param>
        /// <param name="containerType">The Container type.</param>
        /// <param name="DataEncoding">The data encoding.</param>
        /// <param name="fileStatus">The file status in which to open the container.</param>
        /// <param name="KeyCollection">The key collection to use to resolve private keys.</param>
        public ContainerPersistenceStore (string FileName, string Type = null,
                    string Comment = null, bool ReadOnly = false,
                    FileStatus fileStatus = FileStatus.OpenOrCreate,
                    ContainerType containerType = ContainerType.Chain,
                    DataEncoding DataEncoding = DataEncoding.JSON,
                    CryptoParameters CryptoParameters = null,
                    KeyCollection KeyCollection=null) : base() {
            ReadOnly = ReadOnly & (Type != null);

            // Attempt to open file.
            JBCDStream = new JBCDStreamDebug(FileName, FileStatus: fileStatus);

            // Create new container if empty or read the old one.
            if (JBCDStream.Length == 0) {
                Container = Container.NewContainer(JBCDStream, CryptoParameters, 
                    containerType, ContentType: Type);
                }
            else {
                KeyCollection = KeyCollection ?? CryptoParameters?.KeyCollection;
                Container = Container.OpenExisting(JBCDStream, KeyCollection);
                ReadContainer(JBCDStream);
                }
            }

        /// <summary>
        /// Read a container from the first frame to the last.
        /// </summary>
        /// <param name="Stream">The stream to read</param>
        void ReadContainer(JBCDStream Stream) {

            foreach (var ContainerDataReader in Container) {
                if (ContainerDataReader.HasPayload) {
                    var Data = ContainerDataReader.ToArray();
                    CommitTransaction(ContainerDataReader.Header, Data);
                    // here check the trailer.
                    }
                }

            //for (var Found = Container.First(); Found; Found = Container.Next()) {
            //    var Data = Container.ReadFrameData();
            //    CommitTransaction(Container.ContainerHeader, Data);
            //    }

            }

        /// <summary>
        /// Commit a transaction to memory.
        /// </summary>
        /// <param name="ContainerHeader">The container header</param>
        /// <param name="Data">The data to commit.</param>
        public virtual void CommitTransaction (ContainerHeader ContainerHeader, byte[] Data) {
            var Exists = ObjectIndex.TryGetValue(ContainerHeader.UniqueID, out var Previous);
            var ContainerStoreEntry = new ContainerStoreEntry(ContainerHeader, Previous, Data);

            switch (ContainerHeader.Event) {
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
                }


            }

        /// <summary>
        /// Commit a New transaction to memory
        /// </summary>
        /// <param name="ContainerStoreEntry">The container store entry representing the transaction</param>
        protected void MemoryCommitNew (ContainerStoreEntry ContainerStoreEntry) {
            // Check to make sure the object does not already exist
            Assert.False(ObjectIndex.ContainsKey(ContainerStoreEntry.UniqueID), NYI.Throw);
            ObjectIndex.Add(ContainerStoreEntry.UniqueID, ContainerStoreEntry);

            KeyValueIndexAdd(ContainerStoreEntry);
            }

        /// <summary>
        /// Commit an Update transaction to memory
        /// </summary>
        /// <param name="ContainerStoreEntry">The container store entry representing the transaction</param>
        protected void MemoryCommitUpdate (ContainerStoreEntry ContainerStoreEntry) {
            // Check to make sure the object does not already exist
            if (ObjectIndex.ContainsKey(ContainerStoreEntry.UniqueID)) {
                ObjectIndex.Remove(ContainerStoreEntry.UniqueID);
                }
            ObjectIndex.Add(ContainerStoreEntry.UniqueID, ContainerStoreEntry);
            KeyValueIndexAdd(ContainerStoreEntry);
            }

        /// <summary>
        /// Commit a Delete transaction to memory
        /// </summary>
        /// <param name="ContainerStoreEntry">The container store entry representing the transaction</param>
        protected void MemoryCommitDelete (ContainerStoreEntry ContainerStoreEntry) {
            // Check to make sure the object does not already exist
            Assert.True(ObjectIndex.ContainsKey(ContainerStoreEntry.UniqueID), NYI.Throw);
            ObjectIndex.Remove(ContainerStoreEntry.UniqueID);
            DeletedObjects.Add(ContainerStoreEntry.UniqueID, ContainerStoreEntry);

            KeyValueIndexDelete(ContainerStoreEntry);
            }


        // ToDo: Right now the key value pairs are only indexed when the object is initially
        // interned. These are immutable subsequently.
        void KeyValueIndexAdd (ContainerStoreEntry ContainerStoreEntry) {
            if (ContainerStoreEntry.ContainerHeader.KeyValues == null) {
                return;
                }

            foreach (var KeyValue in ContainerStoreEntry.ContainerHeader.KeyValues) {
                var Index = GetContainerStoreIndex(KeyValue.Key, true);
                Index.Add(ContainerStoreEntry, KeyValue.Value);
                }
            }


        // ToDo: Right now the key value pairs are only indexed when the object is initially
        // interned. These are immutable subsequently.
        void KeyValueIndexDelete (ContainerStoreEntry ContainerStoreEntry) {
            var First = ContainerStoreEntry.First as ContainerStoreEntry;
            if (First.ContainerHeader.KeyValues == null) {
                return;
                }

            foreach (var KeyValue in First.ContainerHeader.KeyValues) {
                var Index = GetContainerStoreIndex(KeyValue.Key, true);
                Index.Delete(ContainerStoreEntry, KeyValue.Value);
                }
            }

        /// <summary>
        /// Write a persistence entry
        /// </summary>
        /// <param name="containerHeader">The container header to write</param>
        /// <param name="item">The object to write.</param>
        /// <param name="previous">The previous entry.</param>
        /// <returns></returns>
        public virtual ContainerStoreEntry WriteFrame (
                ContainerHeader containerHeader,
                JSONObject item,
                ContainerStoreEntry previous) {

            var Header = containerHeader.GetBytes(Encoding, false);
            var Data = item?.GetBytes(Encoding, true);

            Container.AppendFrame(Header, Data);

            var Result = new ContainerStoreEntry(containerHeader, previous, Data, item);
            return Result;
            }


        /// <summary>
        /// Create a new persistence entry.
        /// </summary>
        /// <param name="containerHeader">The constructed container header.</param>
        /// <param name="object">Object to create</param>
        public virtual void New (out ContainerHeader containerHeader, JSONObject @object) {
            // Precondition UniqueID does not exist
            var Exists = ObjectIndex.TryGetValue(@object._PrimaryKey, out var Previous);
            Assert.False(Exists, ObjectIdentifierNotUnique.Throw);

            // Create new container
            containerHeader = new ContainerHeader() {
                Event = EventNew,
                UniqueID = @object._PrimaryKey,
                KeyValues = @object._KeyValues.ToKeyValues()
                };
            }

        /// <summary>
        /// Create a new persistence entry.
        /// </summary>
        /// <param name="Object">Object to create</param>
        public virtual void New (JSONObject Object) {
            New(out var ContainterHeader, Object);

            var ContainerStoreEntry = WriteFrame(ContainterHeader, Object, null);
            MemoryCommitNew(ContainerStoreEntry);

            }

        /// <summary>
        /// Create a container header to update an existing persistence entry
        /// </summary>
        /// <param name="ContainerHeader">The constructed container header.</param>
        /// <param name="Previous">The previous container store entry for this object</param>
        /// <param name="Object">The new object value</param>
        /// <param name="Create">If true, create a new value if one does not already exist</param>
        public virtual void Update (out ContainerHeader ContainerHeader, 
                    out ContainerStoreEntry Previous, 
                    JSONObject Object, 
                    bool Create = true) {
            // Precondition UniqueID does not exist
            var Exists = ObjectIndex.TryGetValue(Object._PrimaryKey, out Previous);
            Assert.True(Exists | Create, NYI.Throw);

            // Create new container
            ContainerHeader = new ContainerHeader() {
                Event = Exists ? EventUpdate : EventNew,
                UniqueID = Object._PrimaryKey,
                KeyValues = Object._KeyValues.ToKeyValues(),
                };

            if (Exists) {
                var First = Previous?.First as ContainerStoreEntry;
                ContainerHeader.First = (int)First?.FrameCount;
                ContainerHeader.Previous = (int)Previous?.FrameCount;
                }

            }

        /// <summary>
        /// Update an existing persistence entry
        /// </summary>
        /// <param name="Object">The new object value</param>
        /// <param name="Create">If true, create a new value if one does not already exist</param>
        public virtual void Update (JSONObject Object, bool Create = true) {

            Update(out var ContainerHeader, out var Previous, Object);

            var ContainerStoreEntry = WriteFrame(ContainerHeader, Object, Previous);
            MemoryCommitUpdate(ContainerStoreEntry);
            }


        /// <summary>
        /// Delete a persistence entry
        /// </summary>
        /// <param name="ContainerHeader">The constructed container header.</param>
        /// <param name="Previous">The previous container store entry for this object</param>
        /// <param name="UniqueID">The UniqueID of the object to delete</param>
        /// <returns>True if the object was updated, otherwise false.</returns>
        public virtual bool Delete (out ContainerHeader ContainerHeader, out ContainerStoreEntry Previous, string UniqueID) {
            var Exists = ObjectIndex.TryGetValue(UniqueID, out Previous);
            if (!Exists) {
                ContainerHeader = null;
                return false;
                }

            var First = Previous?.First as ContainerStoreEntry;
            // Create new container
            ContainerHeader = new ContainerHeader() {
                Event = EventDelete,
                UniqueID = UniqueID,
                Previous = (int)Previous?.FrameCount,
                First = (int)First?.FrameCount
                };
            return true;

            }

        /// <summary>
        /// Delete a persistence entry
        /// </summary>
        /// <threadsafety static="true" instance="true"/>
        /// <param name="UniqueID">The UniqueID of the object to delete</param>
        /// <returns>True if the object was updated, otherwise false.</returns>
        public virtual bool Delete (string UniqueID) {

            if (!Delete(out var ContainerHeader, out var Previous, UniqueID)) {
                return false;
                }

            var ContainerStoreEntry = WriteFrame(ContainerHeader, null, Previous);
            MemoryCommitDelete(ContainerStoreEntry);
            return true;
            }


        /// <summary>
        /// Return an index for the specified key, creating it if necessary.
        /// </summary>
        /// <param name="Key">The key for which the index is requested.</param>
        /// <param name="Create">If true, will create an index if none is found.</param>
        /// <returns>The index.</returns>
        public virtual ContainerStoreIndex GetContainerStoreIndex (string Key, bool Create = true) {
            var Found = IndexDictionary.TryGetValue(Key, out var Index);

            if (!Found & Create) {
                Index = new ContainerStoreIndex();
                IndexDictionary.Add(Key, Index);
                }

            return (Index);
            }



        /// <summary>
        /// Return an index for the specified key, creating it if necessary.
        /// </summary>
        /// <param name="Key">The key for which the index is requested.</param>
        /// <param name="Create">If true, will create an index if none is found.</param>
        /// <returns>The index.</returns>
        public virtual IPersistenceIndex GetIndex (string Key, bool Create=true) =>  
            GetContainerStoreIndex(Key, Create);
 

        /// <summary>
        /// Get object instance by unique identifier
        /// </summary>
        /// <param name="UniqueID">The unique identifier of the object instance to locate.</param>
        /// <returns>True if found, otherwise false.</returns>
        public IPersistenceEntry Get (string UniqueID) {
            var Found = ObjectIndex.TryGetValue(UniqueID, out var Result);
            return Result;
            }

        /// <summary>
        /// Determines if a object instance with the specified unique identifier is registered.
        /// </summary>
        /// <param name="UniqueID">The unique identifier of the object instance to locate.</param>
        /// <returns>True if found, otherwise false.</returns>
        public bool Contains(string UniqueID) => ObjectIndex.TryGetValue(UniqueID, out var Result);

        /// <summary>
        /// The last object instance that matches the specified key/value condition.
        /// </summary>
        /// <param name="Key">The key</param>
        /// <param name="Value">The value to match</param>
        /// <returns>The object instance if found, otherwise false.</returns>
        public IPersistenceIndexEntry Last (string Key, string Value) {
            var Found = IndexDictionary.TryGetValue(Key, out var Index);
            if (!Found) {
                return null;
                }
            return Index.Last(Value);
            }
        }
    }


