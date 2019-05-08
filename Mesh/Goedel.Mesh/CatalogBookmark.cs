using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using System.Threading;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;

namespace Goedel.Mesh {

    #region // Enumerators and associated classes

    public class EnumeratorCatalogEntryBookmark : IEnumerator<CatalogEntryBookmark> {
        IEnumerator<ContainerStoreEntry> BaseEnumerator;

        public CatalogEntryBookmark Current => BaseEnumerator.Current.JsonObject as CatalogEntryBookmark;
        object IEnumerator.Current => Current;
        public void Dispose() => BaseEnumerator.Dispose();
        public bool MoveNext() => BaseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogEntryBookmark(ContainerPersistenceStore container) =>
            BaseEnumerator = container.GetEnumerator();
        }

    public class AsCatalogEntryBookmark : IEnumerable<CatalogEntryBookmark> {
        CatalogBookmark Catalog;

        public AsCatalogEntryBookmark(CatalogBookmark catalog) => Catalog = catalog;

        public IEnumerator<CatalogEntryBookmark> GetEnumerator() =>
                    new EnumeratorCatalogEntryBookmark(Catalog.ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion



    public class CatalogBookmark : Catalog {
        protected override void Dispose(bool disposing) => base.Dispose(disposing);
        public const string Label = "CatalogBookmark";

        public override string ContainerDefault => Label;
        public AsCatalogEntryBookmark AsCatalogEntryBookmark => new AsCatalogEntryBookmark(this);

        public CatalogBookmark(string directory, string ContainerName=null,
            CryptoParameters cryptoParameters = null,
                    keyCollection keyCollection = null) :
            base(directory, ContainerName, cryptoParameters, keyCollection) {
            }

        }


    public partial class CatalogEntryBookmark {
        ///<summary>The primary key is protocol:site </summary>
        public override string _PrimaryKey => Path;

        //public override string ToString() {
        //    throw new NYI();


        //    }

        }
    }
