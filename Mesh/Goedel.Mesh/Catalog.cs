using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Goedel.Mesh {
    /// <summary>
    /// Enumeration describing the actions that catalogs support.
    /// </summary>
    public enum CatalogAction {
        ///<summary>Create a new entry.</summary>
        New,
        ///<summary>Update an existing entry</summary>
        Update,
        ///<summary>Delete an entry.</summary>
        Delete
        }


    /// <summary>
    /// Interface to catalog functionality.
    /// </summary>
    public interface ICatalog : IEnumerable<CatalogedEntry> {

        ///<summary>The container</summary>
        Container Container { get; }

        ///<summary>The container identifier. Must be unique within a given account.</summary>
        string ContainerName { get; }

        /// <summary>
        /// Prepare the set of catalog updates <paramref name="updates"/> returning a list
        /// of <see cref="DareEnvelope"/> applying the updates to the sequence.
        /// </summary>
        /// <param name="updates">The updates to apply.</param>
        /// <returns>The processed updates.</returns>
        List<DareEnvelope> Prepare(List<CatalogUpdate> updates);



        /// <summary>
        /// Commit the updates in <paramref name="envelopes"/> to the local persistence store.
        /// </summary>
        /// <param name="envelopes">The updates to apply.</param>
        /// <param name="updates">The updates to apply.</param>
        void Commit(List<DareEnvelope> envelopes, List<CatalogUpdate> updates);
        }

    /// <summary>
    /// Describes a single update to be applied to a single catalog. 
    /// </summary>
    public struct CatalogUpdate {

        ///<summary>The catalog to which this update will be applied.</summary>
        public ICatalog Catalog;

        ///<summary>The action to apply</summary>
        public CatalogAction Action { get; set; }
        
        ///<summary>The entry to apply the action to</summary>
        public CatalogedEntry CatalogEntry { get; set; }
        ///<summary>The primary key under which the entry is cataloged.</summary>
        public string PrimaryKey { get; set; }

        /// <summary>
        /// Construct a catalog update.
        /// </summary>
        /// <param name="action">The action to apply</param>
        /// <param name="catalogEntry">The entry to apply the action to</param>
        /// <param name="catalog">The catalog to apply the update to</param>
        public CatalogUpdate(ICatalog catalog, CatalogAction action, CatalogedEntry catalogEntry) {
            Action = action;
            CatalogEntry = catalogEntry;
            PrimaryKey = catalogEntry?._PrimaryKey;
            Catalog = catalog;
            }

        /// <summary>
        /// Construct a catalog delete update.
        /// </summary>
        /// <param name="primaryKey">The primary key of the entry to delete.</param>
        /// <param name="catalog">The catalog to apply the update to</param>
        public CatalogUpdate(ICatalog catalog, string primaryKey) {
            Action = CatalogAction.Delete;
            CatalogEntry = null;
            PrimaryKey = primaryKey;
            Catalog = catalog;
            }




        }

    #region // The data classes Catalog, CatalogedEntry

    /// <summary>
    /// Base class for catalogs.
    /// </summary>
    public abstract class Catalog<T> : Store, IEnumerable<CatalogedEntry>, ICatalog 
                where T : CatalogedEntry {

        ///<summary>Class exposing the Mesh Client locate interface.</summary>
        public IMeshClient MeshClient;


        ///<summary>The persistence store.</summary>
        public PersistenceStore PersistenceStore { get; set;  } = null;


        ///<summary>Enumerate the catalog as the cataloged type.</summary>
        public AsCatalogedType<T> AsCatalogedType =>
                new AsCatalogedType<T>(PersistenceStore);


        /// <summary>
        /// Disposal method, disposes the underlying persistence store if defined.
        /// </summary>
        protected override void Disposing() {
            PersistenceStore?.Dispose();
            base.Disposing();
            }

        /// <summary>
        /// Base constuctor.
        /// </summary>
        /// <param name="directory">Directory to create the catalog in.</param>
        /// <param name="containerName">Container name.</param>
        /// <param name="cryptoParameters">Cryptographic parameters.</param>
        /// <param name="keyCollection">Key collection to use for decryption.</param>
        /// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
        /// <param name="readContainer">If true, read the container.</param>
        /// <param name="decrypt">If true, attempt decryption of bodies to payloads.</param>
        /// <param name="create">If true, create a container if it does not already exist.</param>
        public Catalog(string directory, string containerName,
                    CryptoParameters cryptoParameters = null,
                    IKeyCollection keyCollection = null,
                    IMeshClient meshClient = null,
                    bool readContainer = true,
                    bool decrypt = true,
                    bool create = true) :
                base(directory, containerName, cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
            if (!create & Container == null) {
                return;
                }
            MeshClient = meshClient;

            PersistenceStore = new PersistenceStore(Container, keyCollection, readContainer);

            if (readContainer) {
                foreach (var indexEntry in PersistenceStore.ObjectIndex) {
                    var objectData = indexEntry.Value.JsonObject as CatalogedEntry;
                    NewEntry(objectData);
                    }
                }

            }




        /// <summary>
        /// Prepare the set of catalog updates <paramref name="updates"/> returning a list
        /// of <see cref="DareEnvelope"/> applying the updates to the sequence.
        /// </summary>
        /// <param name="updates">The updates to apply.</param>
        /// <returns>The processed updates.</returns>
        public List<DareEnvelope> Prepare(List<CatalogUpdate> updates) {
            var result = new List<DareEnvelope>();
            foreach (var update in updates) {
                switch (update.Action) {
                    case CatalogAction.New: {
                        var envelope = PersistenceStore.PrepareNew(update.CatalogEntry);
                        envelope.JSONObject = update.CatalogEntry;
                        result.Add(envelope);
                        break;
                        }
                    case CatalogAction.Update: {
                        var envelope = PersistenceStore.PrepareUpdate(out _, update.CatalogEntry);
                        envelope.JSONObject = update.CatalogEntry;
                        result.Add(envelope);
                        break;
                        }
                    case CatalogAction.Delete: {
                        var envelope = PersistenceStore.PrepareDelete(out _, update.PrimaryKey);
                        if (envelope != null) {
                            result.Add(envelope);
                            }
                        break;
                        }

                    default:
                        break;
                    }
                }

            return result;

            }

        /// <summary>
        /// Commit the updates in <paramref name="envelopes"/> to the local persistence store.
        /// </summary>
        /// <param name="envelopes">The envelopes to append.</param>
        /// <param name="updates">The updates to apply</param>
        public void Commit(List<DareEnvelope> envelopes, List<CatalogUpdate> updates) {

            foreach (var envelope in envelopes) {
                PersistenceStore.Apply(envelope);
                // error - this is not updating the persistence store index 
                }
            foreach (var update in updates) {
                switch (update.Action) {
                    case CatalogAction.New: {
                        NewEntry(update.CatalogEntry);
                        break;
                        }
                    case CatalogAction.Update: {
                        UpdateEntry(update.CatalogEntry);
                        break;
                        }
                    case CatalogAction.Delete: {
                        DeleteEntry(update.PrimaryKey);
                        break;
                        }

                    default:
                    break;
                    }
                }

            }

        /// <summary>
        /// Apply the transactions specified in <paramref name="updates"/> to the catalog
        /// <paramref name="catalog"/>.
        /// </summary>
        /// <param name="catalog">The catalog to apply the transactions to.</param>
        /// <param name="updates">The updates to apply</param>
        /// <returns>True if the transactions were accepted, otherwise false.</returns>
        public virtual bool Transact(Catalog<T> catalog, List<CatalogUpdate> updates) {
            foreach (var update in updates) {
                switch (update.Action) {
                    case CatalogAction.New: {
                        NewEntry(update.CatalogEntry);
                        catalog.PersistenceStore.New(update.CatalogEntry);
                        break;
                        }
                    case CatalogAction.Update: {
                        UpdateEntry(update.CatalogEntry);
                        catalog.PersistenceStore.Update(update.CatalogEntry);
                        break;
                        }
                    case CatalogAction.Delete: {
                        DeleteEntry(update.PrimaryKey);
                        catalog.PersistenceStore.Delete(update.PrimaryKey);
                        break;
                        }

                    default:
                        break;
                    }
                }
            return true;
            }

        /// <summary>
        /// Callback called before adding a new entry to the catalog. May be overriden in 
        /// derrived classes to update local indexes.
        /// </summary>
        /// <param name="catalogedEntry">The entry being added.</param>
        protected virtual void NewEntry(CatalogedEntry catalogedEntry) { }

        /// <summary>
        /// Callback called before updating an entry in the catalog. May be overriden in 
        /// derrived classes to update local indexes.
        /// </summary>
        /// <param name="catalogedEntry">The entry being updated.</param>
        protected virtual void UpdateEntry(CatalogedEntry catalogedEntry) { }

        /// <summary>
        /// Callback called before deleting an entry from the catalog. May be overriden in 
        /// derrived classes to update local indexes.
        /// </summary>
        /// <param name="Key">The entry being deleted.</param>
        protected virtual void DeleteEntry(string Key) { }


        // Test: Check what happens when an attempt is made to perform conflicting updates to a store.

        /// <summary>
        /// Apply the update in <paramref name="dareMessage"/> to the persistence store.
        /// </summary>
        /// <param name="dareMessage">The update to apply.</param>
        public void Apply(DareEnvelope dareMessage) => PersistenceStore.Apply(dareMessage);


        /// <summary>
        /// Add <paramref name="catalogEntry"/> to the catalog as a new entry.
        /// </summary>
        /// <param name="catalogEntry">The entry to add.</param>
        public bool TryNew(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(this, CatalogAction.New, catalogEntry);

            try {
                Transact(this, new List<CatalogUpdate> { catalogUpdate });
                return true;
                }
            catch {
                return false;
                }
            }



        /// <summary>
        /// Add <paramref name="catalogEntry"/> to the catalog as a new entry.
        /// </summary>
        /// <param name="catalogEntry">The entry to add.</param>
        /// <param name="encryptionKey">Key under which the item is to be encrypted.</param>
        public void New(CatalogedEntry catalogEntry, CryptoKey encryptionKey = null) {
            encryptionKey.AssertNull(NYI.Throw); // for later use

            var catalogUpdate = new CatalogUpdate(this, CatalogAction.New, catalogEntry);
            Transact(this, new List<CatalogUpdate> { catalogUpdate });
            }


        /// <summary>
        /// Update <paramref name="catalogEntry"/> in the catalog.
        /// </summary>
        /// <param name="catalogEntry">The entry to update.</param>
        /// <param name="encryptionKey">Key under which the item is to be encrypted.</param>
        public void Update(CatalogedEntry catalogEntry, CryptoKey encryptionKey = null) {
            encryptionKey.AssertNull(NYI.Throw); // for later use


            var catalogUpdate = new CatalogUpdate(this, CatalogAction.Update, catalogEntry);

            Transact(this, new List<CatalogUpdate> { catalogUpdate });
            }

        /// <summary>
        /// Delete <paramref name="catalogEntry"/> from the catalog.
        /// </summary>
        /// <param name="catalogEntry">The entry to delete.</param>
        public void Delete(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(this, catalogEntry._PrimaryKey);
            Transact(this, new List<CatalogUpdate> { catalogUpdate });
            }



        /// <summary>
        /// Return the catalogued entry with key <paramref name="key"/> as the catalogued type.
        /// </summary>
        /// <param name="key">Unique identifier of the device to return.</param>
        /// <returns>The <see cref="CatalogedDevice"/> entry.</returns>
        public virtual T Get(string key) => Locate(key) as T;




        /// <summary>
        /// Add the catalog entry data speficied in the file <paramref name="fileName"/>. If 
        /// <paramref name="merge"/> is true, merge this contact information.
        /// </summary>
        /// <param name="fileName">The file to fetch the contact data from.</param>
        /// <param name="format">The file format to write the output in.</param>
        /// <param name="localName">Short name for the contact to distinguish it from
        /// others.</param>
        /// <param name="merge">Add this data to the existing contact.</param>
        /// <returns></returns>
        public T AddFromStream(
                    Stream stream,
                    CatalogedEntryFormat format = CatalogedEntryFormat.Unknown,
                    bool merge = true,
                    string localName = null) {
            if (ReadFromStream(stream, format).NotNull(out var entry)) {
                UpdateEntry(entry);
                return entry;
                }
            throw new NYI();
            }


        public virtual T ReadFromStream(
                    Stream stream,
                    CatalogedEntryFormat format = CatalogedEntryFormat.Unknown) {
            switch (format) {
                case CatalogedEntryFormat.Unknown:
                case CatalogedEntryFormat.Default: {
                    using var reader = new JsonBcdReader(stream);
                    var result = CatalogedEntry.FromJson(reader, true);
                    return result as T;
                    }
                }



            // here do the dare format

            // here do the json format

            // format is not supported


            throw new NYI();
            }

        public virtual List<T> ReadListFromFile(
            string fileName,
            CatalogedEntryFormat format = CatalogedEntryFormat.Unknown) {

            // here do the dare format

            // here do the json format

            // format is not supported


            throw new NYI();
            }




        /// <summary>
        /// Write the catalog entry data speficied in the file <paramref name="stream"/>. If 
        /// <paramref name="merge"/> is true, merge this contact information.
        /// </summary>
        /// <param name="stream">The stream to write the entry data to.</param>
        /// <param name="format">The file format to write the output in.</param>
        /// <returns></returns>
        public virtual void WriteToStream(
                    Stream stream,
                    T data,
                    CatalogedEntryFormat format = CatalogedEntryFormat.Default) =>
            data.WriteToStream(stream, format);

        /// <summary>
        /// Write the catalog entry data speficied in the file <paramref name="stream"/>. If 
        /// <paramref name="merge"/> is true, merge this contact information.
        /// </summary>
        /// <param name="stream">The stream to write the entry data to.</param>
        /// <param name="format">The file format to write the output in.</param>
        /// <returns></returns>
        public virtual void WriteToStream(
                    Stream stream,
                    List<T> data,
                    CatalogedEntryFormat format = CatalogedEntryFormat.Default) {
            throw new NYI();
            }


        /// <summary>
        /// Locate the entry with key <paramref name="key"/>.
        /// </summary>
        /// <param name="key">Unique identifier of the entry to locate.</param>
        /// <returns>The entry (if found).</returns>
        public CatalogedEntry Locate(string key) =>
            (PersistenceStore.Get(key) as StoreEntry)?.JsonObject as CatalogedEntry;


        /// <summary>
        /// Return the entry with unique identifier <paramref name="key"/>.
        /// </summary>
        /// <param name="key">Unique identifier of entry to return.</param>
        /// <returns>The entry.</returns>
        public StoreEntry GetEntry(string key) => PersistenceStore.Get(key) as StoreEntry;


        /// <summary>
        /// Returns an enumerator over the catalog entries. Most catalog classes offer typed
        /// enumerators as an alternative.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<CatalogedEntry> GetEnumerator() => new EnumeratorCatalogEntry(PersistenceStore);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();

        }



    #endregion

    #region // Enumerators and associated classes

    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedEntry"/> over a persistence
    /// store.
    /// </summary>
    public class EnumeratorCatalogEntry : IEnumerator<CatalogedEntry> {
        IEnumerator<StoreEntry> baseEnumerator;

        ///<summary>The current item in the enumeration.</summary>
        public CatalogedEntry Current => baseEnumerator.Current.JsonObject as CatalogedEntry;
        object IEnumerator.Current => Current;

        /// <summary>
        /// Disposal method.
        /// </summary>
        public void Dispose() => baseEnumerator.Dispose();

        /// <summary>
        /// Move to the next item in the enumeration.
        /// </summary>
        /// <returns>The next item in the enumeration</returns>
        public bool MoveNext() => baseEnumerator.MoveNext();

        /// <summary>
        /// Restart the enumeration.
        /// </summary>
        public void Reset() => throw new NotImplementedException();

        /// <summary>
        /// Construct enumerator from <see cref="PersistenceStore"/>,
        /// <paramref name="persistenceStore"/>.
        /// </summary>
        /// <param name="persistenceStore">The persistence store to enumerate.</param>
        public EnumeratorCatalogEntry(PersistenceStore persistenceStore) =>
            baseEnumerator = persistenceStore.GetEnumerator();
        }
    #endregion

    }
