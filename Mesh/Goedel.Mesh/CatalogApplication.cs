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



    public class AsCatalogEntryApplication: IEnumerable<CatalogedApplication> {
        CatalogContact Catalog;

        public AsCatalogEntryApplication(CatalogContact catalog) => Catalog = catalog;

        public IEnumerator<CatalogedApplication> GetEnumerator() =>
                    new EnumeratorCatalogEntryApplication(Catalog.ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();


        private class EnumeratorCatalogEntryApplication : IEnumerator<CatalogedApplication> {
            IEnumerator<ContainerStoreEntry> BaseEnumerator;

            public CatalogedApplication Current => BaseEnumerator.Current.JsonObject as CatalogedApplication;
            object IEnumerator.Current => Current;
            public void Dispose() => BaseEnumerator.Dispose();
            public bool MoveNext() => BaseEnumerator.MoveNext();
            public void Reset() => throw new NotImplementedException();

            public EnumeratorCatalogEntryApplication(ContainerPersistenceStore container) =>
                BaseEnumerator = container.GetEnumerator();
            }
        }

    #endregion



    public class CatalogApplication : Catalog {
        public const string Label = "mmm_Application";

        public override string ContainerDefault => Label;

        //public AsCatalogEntryContact AsCatalogEntryContact => new AsCatalogEntryContact(this);


        public void Update(ProfileAccount assertionAccount) {
            //var catalogEntryApplicationAccount = new CatalogedApplicationAccount() {
            //    Key = assertionAccount.UDF,
            //    EnvelopedProfileAccount = assertionAccount.DareEnvelope
            //    };
            //Update(catalogEntryApplicationAccount);

            }



        public CatalogedApplication LocateBySite(string Key) => Locate(Key) as CatalogedApplication;


        public CatalogApplication(string directory, string ContainerName=null,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null,
                    bool create = true) :
            base(directory, ContainerName, cryptoParameters, keyCollection, create: create) {
            }
        public static Store Factory(string directory, string containerName = null) =>
        new CatalogApplication(directory, containerName);
        }

    public partial class CatalogedApplication {


        public override string _PrimaryKey => Key;



        }


    }
