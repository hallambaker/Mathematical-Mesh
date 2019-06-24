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
        public const string Label = "mmm_Contact";

        public CatalogEntryContact Self;



        public override string ContainerDefault => Label;

        public AsCatalogEntryContact AsCatalogEntryContact => new AsCatalogEntryContact(this);


        public CatalogEntryContact LocateByID(string Key) => Locate(Key) as CatalogEntryContact;


        public CatalogContact(string directory, string ContainerName = null,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null) :
            base(directory, ContainerName, cryptoParameters, keyCollection) {
            }

        public void Add(DareEnvelope contact, bool self = false) {
            var entry = new CatalogEntryContact(contact) {
                Self=self
                };
            New(entry);
            }

        public void Add(Contact contact, bool self = false) => Add(contact.DareEnvelope ?? DareEnvelope.Encode(contact.GetBytes(true)), self);



        }

    // NYI should all be DareMessages to allow them to be signed.
    public partial class CatalogEntryContact {


        public override string _PrimaryKey => Key;

        public CatalogEntryContact() => Key = UDF.Nonce();

        public CatalogEntryContact(DareEnvelope contact) : this() => EnvelopedContact = contact;

        public CatalogEntryContact(Contact contact) : this() => EnvelopedContact = DareEnvelope.Encode(contact.GetBytes(tag: true),
                    contentType: "application/mmm");
        }

    public partial class Contact {


        }

    }
