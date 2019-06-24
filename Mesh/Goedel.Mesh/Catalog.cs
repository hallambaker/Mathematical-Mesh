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
        public CatalogEntry CatalogEntry;
        public string PrimaryKey;
        public CatalogUpdate(CatalogAction action, CatalogEntry catalogEntry) {
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

    public delegate bool CatalogTransactDelegate (List<CatalogUpdate> Updates);

    public class Catalog : Store, IEnumerable<CatalogEntry> {

        public ContainerPersistenceStore ContainerPersistence = null;


        public CatalogTransactDelegate TransactDelegate;

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
            TransactDelegate = Transact;
            }

        public DareEnvelope ContainerEntry(CatalogEntry catalogEntry, string eventID) {

            var body = catalogEntry.GetBytes(tagged: true);

            var header = new DareHeader() {
                Event = eventID,
                UniqueID = catalogEntry._PrimaryKey,
                KeyValues = catalogEntry._KeyValues.ToKeyValues()
                };

            // here au

            return new DareEnvelope() {
                Header = header,
                Body = body
                };

            }




        public static ContainerStatus Status(string directory, string containerName) {
            using (var container = new Catalog(directory, containerName)) {

                return new ContainerStatus() {
                    Index = (int)container.ContainerPersistence.FrameCount,
                    Container = containerName
                    };
                }
            }


        public bool Transact(List<CatalogUpdate> updates) {
            foreach (var update in updates) {
                switch (update.Action) {
                    case CatalogAction.New: {
                        ContainerPersistence.New(update.CatalogEntry);
                        break;
                        }
                    case CatalogAction.Update: {
                        ContainerPersistence.Update(update.CatalogEntry);
                        break;
                        }
                    case CatalogAction.Delete: {
                        ContainerPersistence.Delete(update.PrimaryKey);
                        break;
                        }
                    }


                }
            return true;
            }



        // Test: Check what happens when an attempt is made to perform conflicting updates to a store.
        public  void Apply(DareEnvelope dareMessage) => ContainerPersistence.Apply(dareMessage);



        public void New(CatalogEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(CatalogAction.New, catalogEntry);
            TransactDelegate(new List<CatalogUpdate> { catalogUpdate });
            }


        public  void Update(CatalogEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(CatalogAction.Update, catalogEntry);

            TransactDelegate(new List<CatalogUpdate> { catalogUpdate });
            }


        public void Delete(CatalogEntry catalogEntry) {
            var catalogUpdate = new CatalogUpdate(catalogEntry._PrimaryKey);
            TransactDelegate(new List<CatalogUpdate> { catalogUpdate });
            }

        public CatalogEntry Locate(string key) => 
            (ContainerPersistence.Get(key) as ContainerStoreEntry)?.JsonObject as CatalogEntry;


        public IEnumerator<CatalogEntry> GetEnumerator() => new EnumeratorCatalogEntry (ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();

        }

    #region // Enumerators and associated classes
    public class EnumeratorCatalogEntry : IEnumerator<CatalogEntry> {
        IEnumerator<ContainerStoreEntry> BaseEnumerator;

        public CatalogEntry Current => BaseEnumerator.Current.JsonObject as CatalogEntry;
        object IEnumerator.Current => Current;
        public void Dispose() => BaseEnumerator.Dispose();
        public bool MoveNext() => BaseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogEntry(ContainerPersistenceStore container) => 
            BaseEnumerator = container.GetEnumerator();
        }


    #endregion

    public partial class CatalogEntry {


        }



    }
