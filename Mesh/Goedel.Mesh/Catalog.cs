using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Goedel.Utilities;
using System.Threading;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Protocol;


namespace Goedel.Mesh {

    public enum CatalogAction {
        New,
        Update,
        Delete
        }

    public struct CatalogUpdate {
        public CatalogAction Action;
        public CatalogedEntry CatalogEntry;
        public string PrimaryKey;
        public CatalogUpdate(CatalogAction action, CatalogedEntry catalogEntry) {
            Action = action;
            CatalogEntry = catalogEntry;
            PrimaryKey = catalogEntry._PrimaryKey;
            }

        public CatalogUpdate(string primaryKey) {
            Action = CatalogAction.Delete;
            CatalogEntry = null;
            PrimaryKey = primaryKey;
            }

        }

    public delegate bool CatalogTransactDelegate (Catalog catalog, List<CatalogUpdate> updates);

    public class Catalog : Store, IEnumerable<CatalogedEntry> {

        public ContainerPersistenceStore ContainerPersistence = null;


        //public CatalogTransactDelegate TransactDelegate;

        protected override void Disposing() {
            ContainerPersistence?.Dispose();
            base.Disposing();
            }

        //public Dictionary<string, CatalogEntry> EntriesByUniqueId = new Dictionary<string, CatalogEntry>();
        private readonly object CatalogLock = new object();

        //public Catalog(IMeshMachine machine, string containerName) : this(machine.DirectoryMesh, containerName) { }


        public Catalog(string directory, string containerName,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null, bool readContainer = true) :
                base(directory, containerName, cryptoParameters, keyCollection) {
            ContainerPersistence = new ContainerPersistenceStore(Container, readContainer);
            //TransactDelegate = Transact;
            }

        //public DareEnvelope ContainerEntry(CatalogedEntry catalogEntry, string eventID) {

        //    var body = catalogEntry.GetBytes(tagged: true);

        //    var header = new ContentInfo() {
        //        Event = eventID,
        //        UniqueID = catalogEntry._PrimaryKey,
        //        KeyValues = catalogEntry._KeyValues.ToKeyValues()
        //        };

        //    // here au
        //    throw new NYI();
        //    //return new DareEnvelope() {
        //    //    Header = header,
        //    //    Body = body
        //    //    };

        //    }




        public static ContainerStatus Status(string directory, string containerName) {
            using (var container = new Catalog(directory, containerName)) {

                return new ContainerStatus() {
                    Index = (int)container.ContainerPersistence.FrameCount,
                    Container = containerName
                    };
                }
            }



        DareEnvelope MakeFrame(
                ContentInfo containerHeader,
                JSONObject item) {

            throw new NYI();

            //return  new DareEnvelope() {
            //    Header = containerHeader,
            //    Body = item?.GetBytes(ContainerPersistence.Encoding, true)
            //    };

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
                        if (envelope!= null) {
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
            foreach (var update in updates) {
                switch (update.Action) {
                    case CatalogAction.New: {
                        catalog.ContainerPersistence.New(update.CatalogEntry);
                        break;
                        }
                    case CatalogAction.Update: {
                        catalog.ContainerPersistence.Update(update.CatalogEntry);
                        break;
                        }
                    case CatalogAction.Delete: {
                        catalog.ContainerPersistence.Delete(update.PrimaryKey);
                        break;
                        }
                    }


                }
            return true;
            }



        // Test: Check what happens when an attempt is made to perform conflicting updates to a store.
        public  void Apply(DareEnvelope dareMessage) => ContainerPersistence.Apply(dareMessage);



        public  void New(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(CatalogAction.New, catalogEntry);
            Transact(this, new List<CatalogUpdate> { catalogUpdate });
            }


        public  void Update(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(CatalogAction.Update, catalogEntry);

            Transact(this, new List<CatalogUpdate> { catalogUpdate });
            }


        public void Delete(CatalogedEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(catalogEntry._PrimaryKey);
            Transact(this, new List<CatalogUpdate> { catalogUpdate });
            }

        public CatalogedEntry Locate(string key) => 
            (ContainerPersistence.Get(key) as ContainerStoreEntry)?.JsonObject as CatalogedEntry;


        public IEnumerator<CatalogedEntry> GetEnumerator() => new EnumeratorCatalogEntry (ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();

        }

    #region // Enumerators and associated classes
    public class EnumeratorCatalogEntry : IEnumerator<CatalogedEntry> {
        IEnumerator<ContainerStoreEntry> BaseEnumerator;

        public CatalogedEntry Current => BaseEnumerator.Current.JsonObject as CatalogedEntry;
        object IEnumerator.Current => Current;
        public void Dispose() => BaseEnumerator.Dispose();
        public bool MoveNext() => BaseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogEntry(ContainerPersistenceStore container) => 
            BaseEnumerator = container.GetEnumerator();
        }


    #endregion

    public partial class CatalogedEntry {


        }



    }
