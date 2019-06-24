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



    public class AsCatalogEntryApplication: IEnumerable<CatalogEntryApplication> {
        CatalogContact Catalog;

        public AsCatalogEntryApplication(CatalogContact catalog) => Catalog = catalog;

        public IEnumerator<CatalogEntryApplication> GetEnumerator() =>
                    new EnumeratorCatalogEntryApplication(Catalog.ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();


        private class EnumeratorCatalogEntryApplication : IEnumerator<CatalogEntryApplication> {
            IEnumerator<ContainerStoreEntry> BaseEnumerator;

            public CatalogEntryApplication Current => BaseEnumerator.Current.JsonObject as CatalogEntryApplication;
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


        public void Update(AssertionAccount assertionAccount) {
            var catalogEntryApplicationAccount = new CatalogEntryApplicationAccount() {
                Key = assertionAccount.UDF,
                EnvelopedAccountAssertion = assertionAccount.DareEnvelope
                };
            Update(catalogEntryApplicationAccount);

            }


        public AssertionAccount GetAssertionAccount(string Key) {
            var entry = Locate(Key) as CatalogEntryApplicationAccount;
            return AssertionAccount.Decode(entry.EnvelopedAccountAssertion);
            }


        public CatalogEntryApplication LocateBySite(string Key) => Locate(Key) as CatalogEntryApplication;


        public CatalogApplication(string directory, string ContainerName=null,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null) :
            base(directory, ContainerName, cryptoParameters, keyCollection) {
            }
        public static Store Factory(string directory, string containerName = null) =>
        new CatalogApplication(directory, containerName);
        }

    public partial class CatalogEntryApplication {


        public override string _PrimaryKey => Key;



        }

    public partial class CatalogEntryApplicationAccount {


        public override string _PrimaryKey => Key;



        }

    }
