
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Goedel.Protocol;
using Goedel.Utilities;

namespace Goedel.Persistence {
    // A persistence store consists of a set of DataItems which are
    // indexed via multiple indexes.

    // The persistence store provides ACID guarantees but does not 
    // support the entity-relational data model or SQL.

    // Currently, locking is performed at the global level. This is 
    // overly restrictive for the type of operations required in a 
    // service oriented architecture.

    // Each store may be indexed through multiple indicies as follows
    //     Type.Tag.Value
    // E.g. 
    //     A store has types "acc" and "udf" for account and fingerprint
    //     The "acc" Type has Tags "alice@example.com", "bob@example.com"
    //     The "alice@example.com" Tag has a set of values

    // ToDo: Audit the locking strategy properly


    /// <summary>
    /// The parent class for all persistence stores.
    /// </summary>
    public abstract class PersistenceStore : IEnumerable<DataItem> {

        /// <summary>
        /// Global Reader-Writer lock for accessing the store.
        /// </summary>
        protected static ReaderWriterLockSlim Lock = new ReaderWriterLockSlim();

        /// <summary>
        /// Prefix to be added to transaction identifiers.
        /// </summary>
        public string TransactionIDPrefix = "TID:";

        static long LastTransaction = 0;

        // Default timeout of 5 seconds


        private int _TimeOut = 1000 * 5;

        /// <summary>
        /// Number of read requests processed this session.
        /// </summary>
        protected long Reads = 0;

        /// <summary>
        /// Number of write requests processed this session.
        /// </summary>
        protected long Adds = 0;

        /// <summary>
        /// Number of transactions that timed out this session.
        /// </summary>
        protected long Timeouts = 0;

        // Append only list of entries
        //
        // This can used to enumerate the keystore in thread safe fashion
        // using an index: for (int i = 0 ; i < KeyEntries.Count ; i++) {}
        //
        // This mechanism is encapsulated by the IEnumerator interface

        /// <summary>
        /// The in-memory append only list of entries.
        /// </summary>
        public List<DataItem> Entries = new List<DataItem>();

        /// <summary>
        /// Catalog of active indexes.
        /// </summary>
        protected SortedDictionary<string, PersistenceIndex> Catalog =
                new SortedDictionary<string, PersistenceIndex>();

        /// <summary>
        /// Index of objects by Primary key.
        /// </summary>
        public PersistenceObjectIndex ObjectIndex =
                new PersistenceObjectIndex();


        /// <summary>
        /// Timeout for acquiring lock in miliseconds.
        /// </summary>
        public int TimeOut {
            get {
                return _TimeOut;
                }

            set {
                _TimeOut = value;
                }
            }

        /// <summary>
        /// Returns a globally unique, monotonically increasing transaction ID.
        /// </summary>
        /// <returns>The transaction identifier.</returns>
        protected virtual string GetTransactionID() {
            var ID = Interlocked.Increment(ref LastTransaction);
            return TransactionIDPrefix + ID.ToString();
            }

        /// <summary>
        /// Return an enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<DataItem> GetEnumerator() {
            return new KeyEntryEnum(this);
            }
        //public KeyEntryEnum GetEnumerator() {
        //    return new KeyEntryEnum(this);
        //    }
        private IEnumerator GetEnumerator1() {
            return GetEnumerator();
            }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator1();
            }

        /// <summary>
        /// The enumeration entry.
        /// </summary>
        public class KeyEntryEnum : IEnumerator<DataItem> {
            int Position = -1;
            PersistenceStore KeyStore;

            /// <summary>
            /// Create an enumerator for the specified store.
            /// </summary>
            /// <param name="KeyStore">The store to enumerate.</param>
            public KeyEntryEnum(PersistenceStore KeyStore) {
                this.KeyStore = KeyStore;
                }

            ///// <summary>
            ///// Finalize.
            ///// </summary>
            //~KeyEntryEnum() {
            //    }

            /// <summary>
            /// Get the next entry.
            /// </summary>
            /// <returns>True if successful, false if no more entries exist.</returns>
            public bool MoveNext() {
                //Console.WriteLine("Try read item");


                Position++;
                return (Position < KeyStore.Entries.Count);
                }

            /// <summary>
            /// Return the enumerator to the first entry.
            /// </summary>
            public void Reset() {
                Position = -1;
                }

            private object Current1 => this.Current;
            object IEnumerator.Current => Current1;

            /// <summary>
            /// The current data item.
            /// </summary>
            public DataItem Current {
                get {
                    try {
                        return KeyStore.Entries[Position];
                        }
                    catch (IndexOutOfRangeException) {
                        throw new InvalidOperationException();
                        }
                    }
                }

            /// <summary>
            /// Dispose method.
            /// </summary>
            public void Dispose() {
                }
            }

        /// <summary>
        /// Default constructor (eliminate?)
        /// </summary>
        public PersistenceStore() {
            }

        /// <summary>
        /// Protected write to the store.
        /// </summary>
        /// <param name="DataItem">Data item to write.</param>
        void Store(DataItem DataItem) {
            try {
                Lock.TryEnterWriteLock(_TimeOut);
                try {
                    UnprotectedStore(DataItem);
                    Interlocked.Increment(ref Adds);
                    }
                finally {
                    Lock.ExitWriteLock();
                    }
                }
            catch {
                Interlocked.Increment(ref _TimeOut);
                }
            }

        /// <summary>
        /// Protected index retrieval from the store.
        /// </summary>
        /// <param name="Key">Key to search on.</param>
        /// <param name="Value">Value to find.</param>
        /// <returns>Item if found, null otherwise.</returns>
        public virtual DataItem GetData(string Key, string Value) {
            DataItem Result = null;
            try {
                Lock.TryEnterReadLock(TimeOut);
                try {
                Result = this.UnprotectedGetData(Key, Value);
                    Interlocked.Increment(ref Reads);
                    }
                finally {
                    Lock.ExitReadLock();
                    }
                }
            catch {
                Interlocked.Increment(ref Timeouts);
                }
            return Result;
            }


        
        /// <summary>
        /// Unprotected write to the store. Can only be accessed or 
        /// overriden in delegate classes.
        /// </summary>
        /// <param name="DataItem">Data item to write.</param>
        protected virtual void UnprotectedStore(DataItem DataItem) {
            Entries.Add(DataItem);
            ObjectIndex.Add(DataItem);

            if (DataItem.Keys == null) {
                return;
                }

            foreach (var IndexTerm in DataItem.Keys) {
                PersistenceIndex Index;
                if (IndexTerm.GetType() == typeof(IndexTermExtended)) {
                    var IndexExtended = IndexTerm as IndexTermExtended;
                    Index = IndexExtended.PersistenceIndex;
                    }
                else {
                    Index = GetIndex(IndexTerm.Type, true);
                    }
                if (Index.DictionaryKeyId.TryGetValue(IndexTerm.Term,
                            out var DataCollection)) {
                    DataCollection.Add(DataItem);
                    }
                else {
                    DataCollection = new DataCollection(DataItem);
                    Index.DictionaryKeyId.AddSafe(IndexTerm.Term, DataCollection); // NYI check if null
                    }
                }
            }

        /// <summary>
        /// Unprotected read.
        /// </summary>
        /// <param name="Key">Key to search on.</param>
        /// <param name="Value">Value to find.</param>
        /// <returns>Item if found, null otherwise.</returns>
        protected virtual DataItem UnprotectedGetData(string Key, string Value) {
            DataItem Result = null;
            //DictionaryEmail.TryGetValue(Email, out Result);
            return Result;
            }


        // these methods are operations on the abstract data store

        /// <summary>
        /// Add new JSON object to the store with the specified identifier, unique ID and keys.
        /// </summary>
        /// <param name="Object">Object to add.</param>
        public virtual void New(JSONObject Object) {
            var Key = Object._PrimaryKey;
            var ObjectEncoded = Object.GetUTF8();
            var Keys = Object._KeyValues?.ToIndexTerms();

            var DataItem = new DataItem(
                    GetTransactionID(),                     // Interlocked safe assignment
                    Key,                     // The primary key
                    ObjectEncoded,                       // The data
                    Keys);     // The index terms
            New(DataItem);
            }


        /// <summary>
        /// Add new JSON object to the store with the specified identifier, unique ID and keys.
        /// </summary>
        /// <param name="Object">Object to add.</param>
        public virtual void Update(JSONObject Object) {
            var DataItem = new DataItem(
                GetTransactionID(), 
                Object._PrimaryKey, 
                Object.GetUTF8(),
                Object._KeyValues?.ToIndexTerms());
            Update(DataItem);
            }

        /// <summary>
        /// Add new DataItem to the store.
        /// </summary>
        /// <param name="DataItem">Data item to add.</param>
        public virtual void New(DataItem DataItem) {
            DataItem.Action = "New";
            DataItem.Added = DateTime.Now;
            Store(DataItem);
            }

        /// <summary>
        /// Update existing DataItem in the store.
        /// </summary>
        /// <param name="DataItem">Data item to add.</param>
        public virtual void Update(DataItem DataItem) {
            DataItem.Action = "Update";
            DataItem.Added = DateTime.Now;
            Store(DataItem);
            }

        ///// <summary>
        ///// Delete DataItem from the store.
        ///// </summary>
        ///// <param name="DataItem">Data item to add.</param>
        //public virtual void Delete(DataItem DataItem) {
        //    DataItem.Text = null; // zero out the data
        //    DataItem.Action = "Delete";
        //    DataItem.Added = DateTime.Now;
        //    Store(DataItem);
        //    }


        /// <summary>
        /// Delete DataItem from the store.
        /// </summary>
        /// <param name="UniqueID">Unique ID of Data item to add.</param>
        public virtual bool Delete (string UniqueID) {
            var DataItem = ObjectIndex.Get(UniqueID);
            if (DataItem == null) {
                return false;
                }

            DataItem.Text = null; // zero out the data
            DataItem.Action = "Delete";
            DataItem.Added = DateTime.Now;
            Store(DataItem);

            return true;
            }


        /// <summary>
        /// Locate objects matching the specified key and value.
        /// </summary>
        /// <param name="Key">Key to match.</param>
        /// <param name="Value">Value to match</param>
        /// <returns>Data collection if a match is found, otherwise null.</returns>
        public virtual DataCollection Get(string Key, string Value) {
            var Index = GetIndex(Key, false);
            if (Index == null) {
                return null;
                }
            return Index.Get (Value);
            }


        // Locates the index for the specified type, creating it if specified

        /// <summary>
        /// Return an index for the specified key, creating it if specified.
        /// </summary>
        /// <param name="Type">Key to match.</param>
        /// <param name="Create">If true, will create an index if none is found.</param>
        /// <returns>The index if found or created, otherwise null.</returns>
        public virtual PersistenceIndex GetIndex(string Type, bool Create=true) {

            var Found = Catalog.TryGetValue(Type, out var Index);

            if (Found) {
                return Index;
                }
            if (Create) {
                Index = new PersistenceIndex(this, Type);
                Catalog.AddSafe(Type, Index);   // NYI check if null
                return Index;
                }
            
            return null;
            }


        }
    }
