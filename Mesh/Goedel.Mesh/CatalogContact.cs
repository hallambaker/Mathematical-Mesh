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

    public class EnumeratorCatalogEntryContact : IEnumerator<CatalogEntryContact> {
        IEnumerator<ContainerStoreEntry> BaseEnumerator;

        public CatalogEntryContact Current => BaseEnumerator.Current.JsonObject as CatalogEntryContact;
        object IEnumerator.Current => Current;
        public void Dispose() => BaseEnumerator.Dispose();
        public bool MoveNext() => BaseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogEntryContact(ContainerPersistenceStore container) =>
            BaseEnumerator = container.GetEnumerator();
        }

    public class AsCatalogEntryContact : IEnumerable<CatalogEntryContact> {
        CatalogContact Catalog;

        public AsCatalogEntryContact(CatalogContact catalog) => Catalog = catalog;

        public IEnumerator<CatalogEntryContact> GetEnumerator() =>
                    new EnumeratorCatalogEntryContact(Catalog.ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion



    public class CatalogContact : Catalog {
        public static string Label = "CatalogContact";

        public override string ContainerDefault => Label;

        public AsCatalogEntryContact AsCatalogEntryContact => new AsCatalogEntryContact(this);


        public CatalogEntryContact LocateBySite(string Key) => Locate(Key) as CatalogEntryContact;


        public CatalogContact(string directory, string ContainerName = null,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null) :
            base(directory, ContainerName, cryptoParameters, keyCollection) {
            }
        public static Store Factory(string directory, string containerName = null) =>
        new CatalogContact(directory, containerName);
        }

    // NYI should all be DareMessages to allow them to be signed.
    public partial class CatalogEntryContact {


        public override string _PrimaryKey => Key;

        public CatalogEntryContact() => Key = UDF.Random();

        public CatalogEntryContact(DareMessage contact) : this() {
            Contact = contact;
            }

        public CatalogEntryContact(Contact contact) : this() {
            Contact = DareMessage.Encode(contact.GetBytes(tag: true),
                    ContentType: "application/mmm");
            }
        }

    }
