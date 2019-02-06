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


    public class Catalog : Store, IEnumerable<CatalogEntry> {

        public ContainerPersistenceStore ContainerPersistence = null;

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
                base(directory, containerName, cryptoParameters, keyCollection) => 
            ContainerPersistence = new ContainerPersistenceStore(Container, readContainer);



        public DareMessage ContainerEntry(CatalogEntry catalogEntry, string eventID) {

            var body = catalogEntry.GetBytes(Tagged: true);

            var header = new DareHeader() {
                Event = eventID,
                UniqueID = catalogEntry._PrimaryKey,
                KeyValues = catalogEntry._KeyValues.ToKeyValues()
                };

            // here au

            return new DareMessage() {
                Header = header,
                Body = body
                };

            }




        public static ContainerStatus Status(string directory, string containerName) {
            using (var container = new Catalog(directory, containerName)) {

                return new ContainerStatus() {
                    Index = (int) container.ContainerPersistence.FrameCount,
                    Container = containerName
                    };
                }
            }



        // Test: Check what happens when an attempt is made to perform conflicting updates to a store.
        public virtual void Apply(DareMessage dareMessage) => ContainerPersistence.Apply(dareMessage);



        public virtual void Add(CatalogEntry catalogEntry) => ContainerPersistence.New(catalogEntry);


        public virtual void Update(CatalogEntry catalogEntry) => ContainerPersistence.Update(catalogEntry, true);


        public virtual void Delete(CatalogEntry catalogEntry) => ContainerPersistence.Delete(catalogEntry._PrimaryKey);


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
