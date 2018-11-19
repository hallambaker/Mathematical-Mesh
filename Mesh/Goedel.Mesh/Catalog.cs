using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Goedel.Utilities;
using System.Threading;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Protocol;


namespace Goedel.Mesh {

    public abstract class Store : Disposable {
        public virtual string ContainerDefault => throw new NYI();
        public ContainerPersistenceStore Container = null;
        protected override void Disposing() => Container?.Dispose();
        }


    public class Catalog : Store, IEnumerable<CatalogEntry> {




        //public Dictionary<string, CatalogEntry> EntriesByUniqueId = new Dictionary<string, CatalogEntry>();
        private readonly object CatalogLock = new object();

        //public Catalog(IMeshMachine machine, string containerName) : this(machine.DirectoryMesh, containerName) { }


        public Catalog(string directory, string containerName) {

            containerName = containerName ?? ContainerDefault;
            var fileName = Path.Combine (directory, Path.ChangeExtension(containerName, ".cat"));
               

            Container = new ContainerPersistenceStore(fileName, "application/mmm-catalog",
                fileStatus: FileStatus.OpenOrCreate,
                containerType: ContainerType.MerkleTree
                );



            }



        public static ContainerStatus Status(string directory, string containerName) {
            using (var container = new Catalog(directory, containerName)) {

                return new ContainerStatus() {
                    Index = (int) container.Container.FrameCount,
                    Container = containerName
                    };
                }
            }


        public virtual void Add(CatalogEntry catalogEntry) => Container.New(catalogEntry);


        public virtual void Update(CatalogEntry catalogEntry) => Container.Update(catalogEntry, true);


        public virtual void Delete(CatalogEntry catalogEntry) => Container.Delete(catalogEntry._PrimaryKey);


        public CatalogEntry Locate(string key) => (Container.Get(key) as ContainerStoreEntry).JsonObject as CatalogEntry;


        public IEnumerator<CatalogEntry> GetEnumerator() => new EnumeratorCatalogEntry (Container);

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
