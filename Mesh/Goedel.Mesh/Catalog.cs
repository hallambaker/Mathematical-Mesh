using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;


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
    /// Describes a single update to be applied to a single catalog. 
    /// </summary>
    public struct CatalogUpdate {
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
        public CatalogUpdate(CatalogAction action, CatalogedEntry catalogEntry) {
            Action = action;
            CatalogEntry = catalogEntry;
            PrimaryKey = catalogEntry?._PrimaryKey;
            }

        /// <summary>
        /// Construct a catalog delete update.
        /// </summary>
        /// <param name="primaryKey">The primary key of the entry to delete.</param>
        public CatalogUpdate(string primaryKey) {
            Action = CatalogAction.Delete;
            CatalogEntry = null;
            PrimaryKey = primaryKey;
            }
        }

    #region // The data classes Catalog, CatalogedEntry

    /// <summary>
    /// Base class for catalogs.
    /// </summary>
    public class Catalog : Store, IEnumerable<CatalogedEntry> {

        ///<summary>The persistence store.</summary>
        public PersistenceStore PersistenceStore { get; set;  } = null;

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
        /// <param name="readContainer">If true, read the container.</param>
        /// <param name="decrypt">If true, attempt decryption of bodies to payloads.</param>
        /// <param name="create">If true, create a container if it does not already exist.</param>
        public Catalog(string directory, string containerName,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null,
                    bool readContainer = true,
                    bool decrypt = true,
                    bool create = true) :
                base(directory, containerName, cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
            if (!create & Container == null) {
                return;
                }

            PersistenceStore = new PersistenceStore(Container, readContainer);
            }

        /// <summary>
        /// Returns the status of the underlying persistence store without binding to it.
        /// </summary>
        /// <param name="directory">The directory in which the store is held.</param>
        /// <param name="storeName">The store name.</param>
        /// <returns>A <see cref="ContainerStatus"/> reporting the current status of the store.</returns>
        public static ContainerStatus Status(string directory, string storeName) {
            using var container = new Catalog(directory, storeName, decrypt: false);
            return new ContainerStatus() {
                Index = (int)container.PersistenceStore.FrameCount,
                Container = storeName
                };
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
                        result.Add(envelope);
                        break;
                        }
                    case CatalogAction.Update: {
                        var envelope = PersistenceStore.PrepareUpdate(out _, update.CatalogEntry);
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
                    }
                }

            return result;

            }

        /// <summary>
        /// Commit the updates in <paramref name="updates"/> to the local persistence store.
        /// </summary>
        /// <param name="updates">The updates to apply.</param>
        public void Commit(List<DareEnvelope> updates) {

            foreach (var update in updates) {
                PersistenceStore.Apply(update);
                }


            }

        /// <summary>
        /// Apply the transactions specified in <paramref name="updates"/> to the catalog
        /// <paramref name="catalog"/>.
        /// </summary>
        /// <param name="catalog">The catalog to apply the transactions to.</param>
        /// <param name="updates">The updates to apply</param>
        /// <returns>True if the transactions were accepted, otherwise false.</returns>
        public virtual bool Transact(Catalog catalog, List<CatalogUpdate> updates) {
            foreach (var update in updates) {
                switch (update.Action) {
                    case CatalogAction.New: {
                        catalog.PersistenceStore.New(update.CatalogEntry);
                        NewEntry(update.CatalogEntry);
                        break;
                        }
                    case CatalogAction.Update: {
                        catalog.PersistenceStore.Update(update.CatalogEntry);
                        UpdateEntry(update.CatalogEntry);
                        break;
                        }
                    case CatalogAction.Delete: {
                        catalog.PersistenceStore.Delete(update.PrimaryKey);
                        DeleteEntry(update.PrimaryKey);
                        break;
                        }
                    }
                }
            return true;
            }

        /// <summary>
        /// Add <paramref name="catalogedEntry"/> to the catalog as a new entry.
        /// </summary>
        /// <param name="catalogedEntry">The entry to add.</param>
        protected virtual void NewEntry(CatalogedEntry catalogedEntry) =>
            "Is this redundant code".TaskRedundant();

        /// <summary>
        /// Update <paramref name="catalogedEntry"/> in the catalog.
        /// </summary>
        /// <param name="catalogedEntry">The entry to update.</param>
        protected virtual void UpdateEntry(CatalogedEntry catalogedEntry) => 
            "Is this redundant code".TaskRedundant();

        /// <summary>
        /// Delete the entry with unique id <paramref name="Key"/> from the catalog.
        /// </summary>
        /// <param name="Key">The entry to delete.</param>
        protected virtual void DeleteEntry(string Key) =>
            "Is this redundant code".TaskRedundant();


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
        public void New(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(CatalogAction.New, catalogEntry);
            Transact(this, new List<CatalogUpdate> { catalogUpdate });
            }


        /// <summary>
        /// Update <paramref name="catalogEntry"/> in the catalog.
        /// </summary>
        /// <param name="catalogEntry">The entry to update.</param>
        public void Update(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(CatalogAction.Update, catalogEntry);

            Transact(this, new List<CatalogUpdate> { catalogUpdate });
            }

        /// <summary>
        /// Delete <paramref name="catalogEntry"/> from the catalog.
        /// </summary>
        /// <param name="catalogEntry">The entry to delete.</param>
        public void Delete(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(catalogEntry._PrimaryKey);
            Transact(this, new List<CatalogUpdate> { catalogUpdate });
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

    public partial class CatalogedEntry {
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
