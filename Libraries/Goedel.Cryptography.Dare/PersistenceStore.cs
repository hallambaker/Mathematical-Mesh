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

using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.Dare;


/// <summary>
/// Enumerator over the objects in a persistence store.
/// </summary>
/// <typeparam name="T">The type of the objects contained in the store.</typeparam>
public class PersistenceStoreEnumerateObject<T> : IEnumerator<T>, IEnumerable<T> where T : class {

    #region // Properties
    IEnumerator<KeyValuePair<string, SequenceIndexEntry>> Enumerator { get; }

    ///<inheritdoc/>
    public T Current => Enumerator.Current.Value.JsonObject as T;

    ///<inheritdoc/>
    public IEnumerator<T> GetEnumerator() => this;

    ///<inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => this;

    object IEnumerator.Current => Current;
    #endregion
    #region // Constructor

    /// <summary>
    /// Constructor returning an enumerator for the objects in the dictionary <paramref name="dictionary"/>.
    /// </summary>
    /// <param name="dictionary">The dictionary to enumerate.</param>
    public PersistenceStoreEnumerateObject(
                Dictionary<string, SequenceIndexEntry> dictionary) {
        Enumerator = dictionary.GetEnumerator();
        }



    #endregion
    #region // Implementation
    ///<inheritdoc/>
    public bool MoveNext() => Enumerator.MoveNext();

    ///<inheritdoc/>
    public void Reset() => Enumerator.Reset();

    ///<inheritdoc/>
    public void Dispose() => Enumerator.Dispose();
    #endregion

    }

/// <summary>
/// Persistence store based on a Sequence interface.
/// </summary>
public class PersistenceStore : Disposable, IPersistenceStoreWrite {

    // Test: Addition of signed frames to persistence stores (is failing)

    // Goal: Implement indexing of sequences, archives, etc.

    // Goal: Make use of Indexes.

    // Goal: implement locking mechanism


    #region --- Disposable objects
    //// Objects that MUST be disposed correctly when leaving a using section.
    //JBCDStream JBCDStream;

    ///<summary>The underlying Sequence.</summary>
    public Sequence Sequence;



    /// <summary>The value of the last frame index</summary>
    public long FrameCount => Sequence.FrameCount;



    /// <summary>
    /// The disposal routine. This is wrapped to provide the IDisposable interface. 
    /// </summary>
    protected override void Disposing() =>
                Sequence?.Dispose();
    #endregion


    /// <summary>Tag for new event</summary>
    public const string EventNew = "New";

    /// <summary>Tag for Update event</summary>
    public const string EventUpdate = "Update";

    /// <summary>Tag for Delete event</summary>
    public const string EventDelete = "Delete";

    ///<summary>The default data encoding of payload items.</summary> 
    public DataEncoding Encoding = DataEncoding.JSON;

    ///<summary>Index of current objects by _PrimaryKey</summary> 
    public Dictionary<string, SequenceIndexEntry> ObjectIndex = new();

    ///<summary>Index of deleted objects by _PrimaryKey</summary> 
    public Dictionary<string, SequenceIndexEntry> DeletedObjectIndex = new();

    /// <summary>
    /// Index of items by _PrimaryKey
    /// </summary>
    public Dictionary<string, StoreEntry> X_ObjectIndex = new();

    /// <summary>
    /// Index of items by _PrimaryKey
    /// </summary>
    public Dictionary<string, StoreEntry> X_DeletedObjects = new();

    /// <summary>
    /// Dictionary mapping keywords to index for that keyword.
    /// </summary>
    public Dictionary<string, StoreIndex> X_IndexDictionary =
                            new();


    /// <summary>
    /// Open or create a persistence store in specified mode with 
    /// the specified file name, content type and optional comment.
    /// </summary>
    /// <param name="policy">The cryptographic policy to be applied to the Sequence.</param>
    /// <param name="fileName">Log file.</param>
    /// <param name="contentType">Type of data to store (the schema name).</param>
    /// <param name="sequenceType">The Sequence type.</param>
    /// <param name="dataEncoding">The data encoding.</param>
    /// <param name="fileStatus">The file status in which to open the Sequence.</param>
    /// <param name="keyCollection">The key collection to use to resolve private keys.</param>
    /// <param name="read">If true read the Sequence to initialize the persistence store.</param>
    /// <param name="decrypt">If false, the contents of the store will never be decrypted (deprecated, use CatalogBlind)</param>
    public PersistenceStore(string fileName, string contentType = null,
                FileStatus fileStatus = FileStatus.OpenOrCreate,
                SequenceType sequenceType = SequenceType.Chain,
                DarePolicy policy = null,
                DataEncoding dataEncoding = DataEncoding.JSON,
                IKeyLocate keyCollection = null,
                bool read = true,
                bool decrypt = true) : this(
                    Sequence.Open(
                        fileName,
                        fileStatus,
                        keyCollection,
                        sequenceType,
                        policy,
                        contentType,
                        decrypt
                        ), keyCollection, read) { }


    /// <summary>
    /// Create a persisetence store round an already opened Sequence.
    /// </summary>
    /// <param name="sequence"></param>
    /// <param name="read"></param>
    /// <param name="keyLocate">The key collection to be used to resolve keys</param>
    public PersistenceStore(Sequence sequence, IKeyLocate keyLocate, bool read = true) {
        sequence.AssertNotNull(NoAvailableDecryptionKey.Throw);

        Sequence = sequence;


        foreach (var x in ObjectIndex) {
            
            }

        // Barfing in the docs because we do not have the key required to decrypt the Sequence

        if (read & sequence.Length > 0) {
            Read(keyLocate);
            }
        }

    public void Intern(
                SequenceIndexEntry indexEntry) {
        "Here we need to update the dictionaries".TaskFunctionality(true);
        
        }






    /// <summary>
    /// Read the Sequence contents in fast mode generating indexes only without reading contents.
    /// </summary>
    public void FastRead() {
        foreach (var frameIndex in Sequence) {
            var contentMeta = frameIndex.Header.ContentMeta;

            var uniqueID = contentMeta.UniqueId;

            X_ObjectIndex.TryGetValue(uniqueID, out var previous);
            var storeEntry = new StoreEntry(frameIndex, previous, Sequence);


            X_ObjectIndex.Remove(uniqueID);
            switch (contentMeta.Event) {
                case EventUpdate:
                case EventNew: {
                        X_ObjectIndex.Add(uniqueID, storeEntry);
                        break;
                        }

                default:
                    break;
                }

            }

        }


    /// <summary>
    /// Read a Sequence from the first frame to the last.
    /// </summary>
    /// <param name="integrity">Specifies the degree of Sequence integrity checking to perform.</param>
    /// <param name="keyLocate">The key collection to be used to resolve keys</param>
    void Read(IKeyLocate keyLocate, SequenceIntegrity integrity = SequenceIntegrity.None) {
        foreach (var frameIndex in Sequence) {

            var item = frameIndex.GetJSONObject(Sequence);

            CommitTransaction(frameIndex, item);
            if (integrity != SequenceIntegrity.None) {
                throw new NYI();
                }
            }
        }


    /// <summary>
    /// Apply the specified message to the Sequence.
    /// </summary>
    /// <param name="dareMessage"></param>
    public virtual StoreEntry Apply(DareEnvelope dareMessage) {

        //Console.WriteLine($"Append");
        var frameIndex = Sequence.Append(dareMessage);
        //Console.WriteLine($"Commit");
        return CommitTransaction(frameIndex, dareMessage.JsonObject);
        }

    #region Commit transaction to memory

    /// <summary>
    /// Commit a transaction to memory.
    /// </summary>
    /// <param name="frameIndex">The Sequence position</param>
    /// <param name="jSONObject">The object being committed in deserialized form.</param>
    public virtual StoreEntry CommitTransaction(SequenceIndexEntry frameIndex, JsonObject jSONObject) {
        if (frameIndex.Header.Index == 0) {
            return null; // we do not commit fram zero transactions to memory.
            }

        var contentMeta = frameIndex.Header.ContentMeta;

        X_ObjectIndex.TryGetValue(contentMeta.UniqueId, out var Previous);
        var storeEntry = new StoreEntry(frameIndex, Previous, Sequence, jSONObject);

        switch (contentMeta.Event) {
            case EventNew: {
                    //MemoryCommitNew(storeEntry);
                    MemoryCommitUpdate(storeEntry);
                    break;
                    }
            case EventUpdate: {
                    MemoryCommitUpdate(storeEntry);
                    break;
                    }
            case EventDelete: {
                    MemoryCommitDelete(storeEntry);
                    break;
                    }
            default: {
                    throw new UndefinedStoreAction(contentMeta.Event);
                    }
            }
        return storeEntry;
        }

    /// <summary>
    /// Commit a New transaction to memory
    /// </summary>
    /// <param name="storeEntry">The Sequence store entry representing the transaction</param>
    protected virtual void MemoryCommitNew(StoreEntry storeEntry) {
        // Check to make sure the object does not already exist
        Assert.AssertFalse(X_ObjectIndex.ContainsKey(storeEntry.UniqueID), EntryAlreadyExists.Throw);
        X_ObjectIndex.Add(storeEntry.UniqueID, storeEntry);

        KeyValueIndexAdd(storeEntry);
        }

    /// <summary>
    /// Commit an Update transaction to memory
    /// </summary>
    /// <param name="storeEntry">The Sequence store entry representing the transaction</param>
    protected virtual void MemoryCommitUpdate(StoreEntry storeEntry) {
        // Check to make sure the object does not already exist
        if (X_ObjectIndex.ContainsKey(storeEntry.UniqueID)) {
            X_ObjectIndex.Remove(storeEntry.UniqueID);
            }
        X_ObjectIndex.Add(storeEntry.UniqueID, storeEntry);
        KeyValueIndexAdd(storeEntry);
        }

    /// <summary>
    /// Commit a Delete transaction to memory
    /// </summary>
    /// <param name="storeEntry">The Sequence store entry representing the transaction</param>
    protected virtual void MemoryCommitDelete(StoreEntry storeEntry) {
        // Check to make sure the object does not already exist
        Assert.AssertTrue(X_ObjectIndex.ContainsKey(storeEntry.UniqueID), EntryNotFound.Throw);
        X_ObjectIndex.Remove(storeEntry.UniqueID);
        //DeletedObjects.Add(storeEntry.UniqueID, storeEntry);

        KeyValueIndexDelete(storeEntry);
        }


    // Hack: Right now the key value pairs are only indexed when the object is initially
    // interned. These are immutable subsequently.
    void KeyValueIndexAdd(StoreEntry storeEntry) {
        if (storeEntry.ContentInfo.KeyValues == null) {
            return;
            }

        foreach (var KeyValue in storeEntry.ContentInfo.KeyValues) {
            var Index = GetStoreIndex(KeyValue.Key, true);
            Index.Add(storeEntry, KeyValue.Value);
            }
        }


    // Hack: Right now the key value pairs are only indexed when the object is initially
    // interned. These are immutable subsequently.
    void KeyValueIndexDelete(StoreEntry storeEntry) {
        var First = storeEntry.First as StoreEntry;
        if (First.ContentInfo.KeyValues == null) {
            return;
            }

        foreach (var KeyValue in First.ContentInfo.KeyValues) {
            var Index = GetStoreIndex(KeyValue.Key, true);
            Index.Delete(storeEntry, KeyValue.Value);
            }
        }

    #endregion

    #region Prepare and commit transaction to sequence

    /// <summary>
    /// Prepare a transaction to be committed.
    /// </summary>
    /// <param name="contentInfo">The content metadata</param>
    /// <param name="jsonObject">The object.</param>
    /// <param name="additionalRecipients">Encryption keys of additional recipients.</param>
    /// <returns>The prepared envelope.</returns>
    public DareEnvelope Prepare(
            ContentMeta contentInfo,
            JsonObject jsonObject,
                List<KeyPair> additionalRecipients = null) {

        var contextWrite = new SequenceWriterDeferred(Sequence) {
            AdditionalRecipients = additionalRecipients
            };

        var data = jsonObject?.GetBytes();
        var envelope = Sequence.Defer(contextWrite, contentInfo, data);
        envelope.JsonObject = jsonObject;

        if (envelope.Trailer != null) {
            envelope.Header.ChainDigest = envelope.Trailer.ChainDigest;
            envelope.Header.PayloadDigest = envelope.Trailer.PayloadDigest;
            envelope.Header.TreeDigest = envelope.Trailer.TreeDigest;
            envelope.Header.Signatures = envelope.Trailer.Signatures;
            envelope.Header.SignedData = envelope.Trailer.SignedData;
            envelope.Trailer = null;
            }

        return envelope;
        }


    /// <summary>
    /// Write a persistence entry to the Sequence.
    /// </summary>
    /// <param name="item">The object to write.</param>
    /// <param name="previous">The previous entry.</param>
    /// <param name="dareEnvelope">The serialized persistence data.</param>
    /// <returns></returns>
    public virtual StoreEntry CommitToSequence(
            DareEnvelope dareEnvelope,
            JsonObject item,
            StoreEntry previous = null) {

        Sequence.Append(dareEnvelope);
        return new StoreEntry(Sequence, dareEnvelope, previous, item);
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
        var Exists = X_ObjectIndex.TryGetValue(jsonObject._PrimaryKey, out var Previous);
        Assert.AssertFalse(Exists, ObjectIdentifierNotUnique.Throw);

        // Create new Sequence
        var contentInfo = new ContentMeta() {
            Event = EventNew,
            UniqueId = jsonObject._PrimaryKey,
            KeyValues = jsonObject._KeyValues.ToKeyValues()
            };

        return Prepare(contentInfo, jsonObject);
        }

    /// <summary>
    /// Create a Sequence header to update an existing persistence entry
    /// </summary>

    /// <param name="previous">The previous Sequence store entry for this object</param>
    /// <param name="jsonObject">The new object value</param>
    /// <param name="create">If true, create a new value if one does not already exist</param>
    /// <param name="encryptionKey">Key under which the item is to be encrypted.</param>
    /// <param name="additionalRecipients">Additional encryption keys for which recipient
    /// entries are to be created.</param>
    public virtual DareEnvelope PrepareUpdate(
                out StoreEntry previous,
                JsonObject jsonObject,
                bool create = true, CryptoKey encryptionKey = null,
                List<KeyPair> additionalRecipients = null) {

        encryptionKey.Future();

        // Precondition UniqueID does not exist
        var Exists = X_ObjectIndex.TryGetValue(jsonObject._PrimaryKey, out previous);
        Assert.AssertTrue(Exists | create, EntryNotFound.Throw);

        // Create new Sequence
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
        return Prepare(contentInfo, jsonObject, additionalRecipients);
        }

    /// <summary>
    /// Delete a persistence entry
    /// </summary>
    /// <param name="previous">The previous Sequence store entry for this object</param>
    /// <param name="uniqueID">The UniqueID of the object to delete</param>
    /// <returns>True if the object was updated, otherwise false.</returns>
    /// 
    public DareEnvelope PrepareDelete(
        out StoreEntry previous, string uniqueID) {
        var Exists = X_ObjectIndex.TryGetValue(uniqueID, out previous);
        if (!Exists) {
            return null;
            }

        var First = previous?.First as StoreEntry;
        // Create new Sequence
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
        var storeEntry = CommitToSequence(envelope, jsonObject);
        MemoryCommitNew(storeEntry);

        return storeEntry;
        }


    /// <summary>
    /// Update an existing persistence entry
    /// </summary>
    /// <param name="jsonObject">The new object value</param>
    /// <param name="create">If true, create a new value if one does not already exist</param>
    /// <param name="transaction">The transaction context in which to perform the update.</param>
    public virtual IPersistenceEntry Update(JsonObject jsonObject, bool create = true, Transaction transaction = null) {

        var envelope = PrepareUpdate(out var Previous, jsonObject, create);

        var storeEntry = CommitToSequence(envelope, jsonObject, Previous);
        MemoryCommitUpdate(storeEntry);

        return storeEntry;
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

        var storeEntry = CommitToSequence(envelope, null, Previous);
        MemoryCommitDelete(storeEntry);
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
    public virtual StoreIndex GetStoreIndex(string key, bool create = true) {
        var found = X_IndexDictionary.TryGetValue(key, out var Index);

        if (!found & create) {
            Index = new StoreIndex();
            X_IndexDictionary.Add(key, Index);
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
        GetStoreIndex(key, create);


    /// <summary>
    /// Get object instance by unique identifier
    /// </summary>
    /// <param name="uniqueID">The unique identifier of the object instance to locate.</param>
    /// <returns>True if found, otherwise false.</returns>
    public IPersistenceEntry Get(string uniqueID) {
        X_ObjectIndex.TryGetValue(uniqueID, out var result);
        return result;
        }

    /// <summary>
    /// Determines if a object instance with the specified unique identifier is registered.
    /// </summary>
    /// <param name="uniqueID">The unique identifier of the object instance to locate.</param>
    /// <returns>True if found, otherwise false.</returns>
    public bool Contains(string uniqueID) => X_ObjectIndex.TryGetValue(uniqueID, out var _);

    /// <summary>
    /// The last object instance that matches the specified key/value condition.
    /// </summary>
    /// <param name="key">The key</param>
    /// <param name="value">The value to match</param>
    /// <returns>The object instance if found, otherwise false.</returns>
    public IPersistenceIndexEntry Last(string key, string value) {
        var found = X_IndexDictionary.TryGetValue(key, out var Index);
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


