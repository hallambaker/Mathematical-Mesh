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
using Goedel.IO;
using System.Net.Mime;

namespace Goedel.Cryptography.Dare;





/// <summary>
/// Enumerator over the objects in a persistence store.
/// </summary>
/// <typeparam name="T">The type of the objects contained in the store.</typeparam>
public class PersistenceStoreEnumerateObject<T> : IEnumerator<T>, IEnumerable<T> where T : class {

    #region // Properties
    IEnumerator<KeyValuePair<string, PersistentIndexEntry>> Enumerator { get; }

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
                Dictionary<string, PersistentIndexEntry> dictionary) {
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
/// A persistence store that closes and reopens the underlying sequence automatically
/// on each action.
/// </summary>
public class PersistenceStoreEphemeral : PersistenceStore {

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
    /// <param name="keyLocate">The key collection to use to resolve private keys.</param>
    /// <param name="read">If true read the Sequence to initialize the persistence store.</param>
    /// <param name="decrypt">If false, the contents of the store will never be decrypted (deprecated, use CatalogBlind)</param>
    public PersistenceStoreEphemeral(string fileName, string contentType = null,
                FileStatus fileStatus = FileStatus.OpenOrCreate,
                SequenceType sequenceType = SequenceType.Chain,
                DarePolicy policy = null,
                DataEncoding dataEncoding = DataEncoding.JSON,
                IKeyLocate keyLocate = null,
                bool decrypt = true) : base (fileName, contentType, fileStatus, sequenceType,
                    policy, dataEncoding, keyLocate, true, decrypt){
        Unload();
        }

    #region // Override update accessors so as to wrap with callse to open/close the sequence.
    ///<inheritdoc/>
    public override IPersistenceEntry New(JsonObject jsonObject, Transaction transaction = null) {
        Reload();
        var result = base.New(jsonObject, transaction);
        Unload();
        return result;
        }

    ///<inheritdoc/>
    public override IPersistenceEntry Update(JsonObject jsonObject, bool create = true, Transaction transaction = null) {
        Reload();
        var result = base.Update(jsonObject, create, transaction);
        Unload();
        return result;
        }

    ///<inheritdoc/>
    public override bool Delete(string uniqueID, Transaction transaction = null) {
        Reload();
        var result = base.Delete(uniqueID, transaction);
        Unload();
        return result;
        }


    #endregion

    }



/// <summary>
/// Persistence store based on a Sequence interface.
/// </summary>
public class PersistenceStore : Disposable, IPersistenceStoreWrite, IInternSequenceIndexEntry {

    // Test: Addition of signed frames to persistence stores (is failing)

    // Goal: Implement indexing of sequences, archives, etc.

    // Goal: Make use of Indexes.

    // Goal: implement locking mechanism


    #region --- Disposable objects
    //// Objects that MUST be disposed correctly when leaving a using section.
    //JBCDStream JBCDStream;

    ///<summary>The underlying Sequence.</summary>
    public Sequence Sequence => sequence;
    Sequence sequence = null;


    string Filename { get; }
    IKeyLocate KeyLocate { get; }

    bool Decrypt { get; }


    /// <summary>The value of the last frame index</summary>
    public long FrameCount => Sequence.FrameCount;



    /// <summary>
    /// The disposal routine. This is wrapped to provide the IDisposable interface. 
    /// </summary>
    protected override void Disposing() => sequence?.Dispose();
    #endregion

    ///<inheritdoc/>
    public virtual SequenceIndexEntryFactoryDelegate SequenceIndexEntryFactory => PersistentIndexEntry.Factory;



    ///<summary>The default data encoding of payload items.</summary> 
    public DataEncoding Encoding = DataEncoding.JSON;

    ///<summary>Index of current objects by _PrimaryKey</summary> 
    public Dictionary<string, PersistentIndexEntry> ObjectIndex = new();

    /////<summary>Index of deleted objects by _PrimaryKey</summary> 
    //public Dictionary<string, SequenceIndexEntry> DeletedObjectIndex = new();

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
    /// <param name="keyLocate">The key collection to use to resolve private keys.</param>
    /// <param name="read">If true read the Sequence to initialize the persistence store.</param>
    /// <param name="decrypt">If false, the contents of the store will never be decrypted (deprecated, use CatalogBlind)</param>
    public PersistenceStore(string fileName, string contentType = null,
                FileStatus fileStatus = FileStatus.OpenOrCreate,
                SequenceType sequenceType = SequenceType.Chain,
                DarePolicy policy = null,
                DataEncoding dataEncoding = DataEncoding.JSON,
                IKeyLocate keyLocate = null,
                bool read = true,
                bool decrypt = true) {
        Filename = fileName;
        KeyLocate = keyLocate;
        Decrypt = decrypt;
        sequence = Sequence.Open(
                        fileName,
                        fileStatus,
                        keyLocate,
                        sequenceType,
                        policy,
                        contentType,
                        decrypt,
                        store: this
                        );
        if (read & Sequence.Length > 0) {
            Read();
            }
        }

    /// <summary>
    /// Close the underlying sequence so as to save file handles.
    /// </summary>
    protected void Unload() {
        sequence?.Dispose();
        sequence = null;
        }

    /// <summary>
    /// Reopen the underlying sequence.
    /// </summary>
    protected void Reload() {
        sequence = Sequence.Open(
                Filename,
                FileStatus.ConcurrentLocked,
                KeyLocate,
                decrypt: Decrypt,
                store: this
                );
        }


    /// <summary>
    /// Create a persisetence store round an already opened Sequence.
    /// </summary>
    /// <param name="sequence"></param>
    /// <param name="read"></param>
    /// <param name="keyLocate">The key collection to be used to resolve keys</param>
    public PersistenceStore(Sequence sequence, IKeyLocate keyLocate, bool read = true) {
        sequence.AssertNotNull(NoAvailableDecryptionKey.Throw);
        this.sequence = sequence;

        if (read & sequence.Length > 0) {
            Read();
            }
        }

    ///<inheritdoc/>
    public void Intern(
                SequenceIndexEntry indexEntry) {
        var persistentIndexEntry = indexEntry as PersistentIndexEntry;

        if (persistentIndexEntry.Event == null) { // no event means no update to persistence store.
            return;
            }

        var contentMeta = indexEntry.Header.ContentMeta;
        var uniqueID = contentMeta.UniqueId;

        if (ObjectIndex.TryGetValue(uniqueID, out var existingItem)) {
            if (indexEntry.Index > existingItem.Index) {
                ObjectIndex.Remove(uniqueID);
                ObjectIndex.Add(uniqueID, persistentIndexEntry);
                }
            }
        else {
            ObjectIndex.Add(uniqueID, persistentIndexEntry);
            }
        }

    /// <summary>
    /// Read a Sequence from the first frame to the last.
    /// </summary>
    /// <param name="integrity">Specifies the degree of Sequence integrity checking to perform.</param>
    public int Read(SequenceIntegrity integrity = SequenceIntegrity.None) {
        // todo: check if can 
        var count = 0;
        foreach (var frameIndex in Sequence.Select(1,false)) {
            count++;
            if (integrity != SequenceIntegrity.None) {
                // Todo: implement checks here.
                throw new NYI();
                }
            }
        return count;
        }

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

    #endregion

    #region Entry points for specific transactions

    /// <summary>
    /// Create a new persistence entry.
    /// </summary>
    /// <param name="jsonObject">Object to create</param>

    public virtual DareEnvelope PrepareNew(
            JsonObject jsonObject) {

        // Precondition UniqueID does not exist
        if (ObjectIndex.TryGetValue(jsonObject._PrimaryKey, out var previous)) {
            throw new ObjectIdentifierNotUnique();
            }

        // Create new Sequence
        var contentInfo = new ContentMeta() {
            Event = DareConstants.SequenceEventNewTag,
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
                out PersistentIndexEntry previous,
                JsonObject jsonObject,
                bool create = true, CryptoKey encryptionKey = null,
                List<KeyPair> additionalRecipients = null) {

        encryptionKey.Future();

        var exists = ObjectIndex.TryGetValue(jsonObject._PrimaryKey, out previous);

        // Create new Sequence
        var contentInfo = new ContentMeta() {
            Event = exists ? DareConstants.SequenceEventUpdateTag : DareConstants.SequenceEventNewTag,
            UniqueId = jsonObject._PrimaryKey,
            KeyValues = jsonObject._KeyValues.ToKeyValues(),
            };

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
        out PersistentIndexEntry previous, string uniqueID) {

        var exists = ObjectIndex.TryGetValue(uniqueID, out previous);
        if (!exists) {
            return null;
            }

        // Create new Sequence
        var contentInfo = new ContentMeta() {
            Event = DareConstants.SequenceEventDeleteTag,
            UniqueId = uniqueID,
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
        var result = Sequence.Append(envelope) as PersistentIndexEntry;

        return result;
        }


    /// <summary>
    /// Update an existing persistence entry
    /// </summary>
    /// <param name="jsonObject">The new object value</param>
    /// <param name="create">If true, create a new value if one does not already exist</param>
    /// <param name="transaction">The transaction context in which to perform the update.</param>
    public virtual IPersistenceEntry Update(JsonObject jsonObject, bool create = true, Transaction transaction = null) {

        var envelope = PrepareUpdate(out _, jsonObject, create);
        var result = Sequence.Append(envelope) as PersistentIndexEntry;

        return result;

        //var storeEntry = CommitToSequence(envelope, jsonObject, Previous);
        //MemoryCommitUpdate(storeEntry);

        //return storeEntry;
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
        Sequence.Append(envelope);
        return true;
        }



    #endregion

    #region Navigation

    /// <summary>
    /// Determines if a object instance with the specified unique identifier is registered
    /// and has not been deleted.
    /// </summary>
    /// <param name="uniqueID">The unique identifier of the object instance to locate.</param>
    /// <returns>True if found, otherwise false.</returns>
    public bool Contains(string uniqueID) {
        if (ObjectIndex.TryGetValue(uniqueID, out var entry)) {
            return entry.SequenceEvent != SequenceEvent.Delete;
            }
        return false;
        }



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

    #region // Hot mess to be deleted.


    ///// <summary>
    ///// Return an index for the specified key, creating it if necessary.
    ///// </summary>
    ///// <param name="key">The key for which the index is requested.</param>
    ///// <param name="create">If true, will create an index if none is found.</param>
    ///// <returns>The index.</returns>
    //public virtual IPersistenceIndex GetIndex(string key, bool create = true) =>
    //    GetStoreIndex(key, create);

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


    #region Commit transaction to memory



    /// <summary>
    /// Apply the specified message to the Sequence.
    /// </summary>
    /// <param name="dareMessage"></param>
    public virtual SequenceIndexEntry Apply(DareEnvelope dareMessage) {

        //Console.WriteLine($"Append");
        var frameIndex = Sequence.Append(dareMessage);
        //Console.WriteLine($"Commit");
        //return CommitTransaction(frameIndex, dareMessage.JsonObject);
        return frameIndex;
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
        var First = storeEntry.X_First as StoreEntry;
        if (First.ContentInfo.KeyValues == null) {
            return;
            }

        foreach (var KeyValue in First.ContentInfo.KeyValues) {
            var Index = GetStoreIndex(KeyValue.Key, true);
            Index.Delete(storeEntry, KeyValue.Value);
            }
        }

    #endregion

    /// <summary>
    /// Commit a transaction to memory.
    /// </summary>
    /// <param name="frameIndex">The Sequence position</param>
    /// <param name="jSONObject">The object being committed in deserialized form.</param>
    StoreEntry CommitTransaction(SequenceIndexEntry frameIndex, JsonObject jSONObject) {

        // This needs some rework here. Probably superfluous as we can overload the intern method.
        throw new NYI();


        //if (frameIndex.Header.Index == 0) {
        //    return null; // we do not commit fram zero transactions to memory.
        //    }

        //var contentMeta = frameIndex.Header.ContentMeta;

        //X_ObjectIndex.TryGetValue(contentMeta.UniqueId, out var Previous);
        //var storeEntry = new StoreEntry(frameIndex, Previous, Sequence, jSONObject);



        //switch (contentMeta.Event) {
        //    case EventNew: {
        //            //MemoryCommitNew(storeEntry);
        //            MemoryCommitUpdate(storeEntry);
        //            break;
        //            }
        //    case EventUpdate: {
        //            MemoryCommitUpdate(storeEntry);
        //            break;
        //            }
        //    case EventDelete: {
        //            MemoryCommitDelete(storeEntry);
        //            break;
        //            }
        //    default: {
        //            throw new UndefinedStoreAction(contentMeta.Event);
        //            }
        //    }
        //return storeEntry;
        }

    #endregion
    }

/// <summary>
/// Base class for transactions.
/// </summary>
public class Transaction {





    }


