using Goedel.Cryptography;
using Goedel.Cryptography.Dare;

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
        public CatalogAction Action;
        
        ///<summary>The entry to apply the action to</summary>
        public CatalogedEntry CatalogEntry;
        ///<summary>The primary key under which the entry is cataloged.</summary>
        public string PrimaryKey;

        /// <summary>
        /// Construct a catalog update.
        /// </summary>
        /// <param name="action">The action to apply</param>
        /// <param name="catalogEntry">The entry to apply the action to</param>
        public CatalogUpdate(CatalogAction action, CatalogedEntry catalogEntry) {
            Action = action;
            CatalogEntry = catalogEntry;
            PrimaryKey = catalogEntry._PrimaryKey;
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

    //public delegate bool CatalogTransactDelegate (Catalog catalog, List<CatalogUpdate> updates);

    public class Catalog : Store, IEnumerable<CatalogedEntry> {

        public ContainerPersistenceStore ContainerPersistence = null;


        protected override void Disposing() {
            ContainerPersistence?.Dispose();
            base.Disposing();
            }

        //public Dictionary<string, CatalogEntry> EntriesByUniqueId = new Dictionary<string, CatalogEntry>();
        //private readonly object CatalogLock = new object();

        //public Catalog(IMeshMachine machine, string containerName) : this(machine.DirectoryMesh, containerName) { }


        /// <summary>
        /// Constuctor
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


            ContainerPersistence = new ContainerPersistenceStore(Container, readContainer);
            //TransactDelegate = Transact;
            }


        public static ContainerStatus Status(string directory, string containerName) {
            using var container = new Catalog(directory, containerName, decrypt: false);
            return new ContainerStatus() {
                Index = (int)container.ContainerPersistence.FrameCount,
                Container = containerName
                };
            }



        public List<DareEnvelope> Prepare(List<CatalogUpdate> updates) {
            //"Commit changes AFTER they have been accepted by the service".TaskFunctionality();

            var result = new List<DareEnvelope>();

            foreach (var update in updates) {
                switch (update.Action) {

                    case CatalogAction.New: {

                        var envelope = ContainerPersistence.PrepareNew(update.CatalogEntry);
                        result.Add(envelope);

                        break;
                        }
                    case CatalogAction.Update: {
                        var envelope = ContainerPersistence.PrepareUpdate(out _, update.CatalogEntry);
                        result.Add(envelope);
                        break;
                        }
                    case CatalogAction.Delete: {
                        var envelope = ContainerPersistence.PrepareDelete(out _, update.PrimaryKey);
                        if (envelope != null) {
                            result.Add(envelope);
                            }
                        break;
                        }
                    }


                }

            return result;

            }
        public void Commit(List<DareEnvelope> updates) {

            foreach (var update in updates) {
                ContainerPersistence.Apply(update);
                }


            }

        public virtual bool Transact(Catalog catalog, List<CatalogUpdate> updates) {

            /// if we are connected to a service, perfom the update here.



            foreach (var update in updates) {
                switch (update.Action) {
                    case CatalogAction.New: {
                        catalog.ContainerPersistence.New(update.CatalogEntry);
                        NewEntry(update.CatalogEntry);
                        break;
                        }
                    case CatalogAction.Update: {
                        catalog.ContainerPersistence.Update(update.CatalogEntry);
                        UpdateEntry(update.CatalogEntry);
                        break;
                        }
                    case CatalogAction.Delete: {
                        catalog.ContainerPersistence.Delete(update.PrimaryKey);
                        DeleteEntry(update.PrimaryKey);
                        break;
                        }
                    }


                }
            return true;
            }


        protected virtual void NewEntry(CatalogedEntry catalogedEntry) {
            }

        protected virtual void UpdateEntry(CatalogedEntry catalogedEntry) {
            }

        protected virtual void DeleteEntry(string Key) {
            }


        // Test: Check what happens when an attempt is made to perform conflicting updates to a store.
        public void Apply(DareEnvelope dareMessage) => ContainerPersistence.Apply(dareMessage);



        public void New(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(CatalogAction.New, catalogEntry);
            Transact(this, new List<CatalogUpdate> { catalogUpdate });
            }


        public void Update(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(CatalogAction.Update, catalogEntry);

            Transact(this, new List<CatalogUpdate> { catalogUpdate });
            }


        public void Delete(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(catalogEntry._PrimaryKey);
            Transact(this, new List<CatalogUpdate> { catalogUpdate });
            }

        public CatalogedEntry Locate(string key) =>
            (ContainerPersistence.Get(key) as ContainerStoreEntry)?.JsonObject as CatalogedEntry;

        public ContainerStoreEntry GetEntry(string key) => ContainerPersistence.Get(key) as ContainerStoreEntry;



        public IEnumerator<CatalogedEntry> GetEnumerator() => new EnumeratorCatalogEntry(ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();

        }

    #region // Enumerators and associated classes
    public class EnumeratorCatalogEntry : IEnumerator<CatalogedEntry> {
        IEnumerator<ContainerStoreEntry> baseEnumerator;

        public CatalogedEntry Current => baseEnumerator.Current.JsonObject as CatalogedEntry;
        object IEnumerator.Current => Current;
        public void Dispose() => baseEnumerator.Dispose();
        public bool MoveNext() => baseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogEntry(ContainerPersistenceStore container) =>
            baseEnumerator = container.GetEnumerator();
        }


    #endregion

    public partial class CatalogedEntry {


        }



    }
