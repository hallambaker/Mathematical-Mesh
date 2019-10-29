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

    public class EnumeratorCatalogEntryContact : IEnumerator<CatalogedContact> {
        IEnumerator<ContainerStoreEntry> BaseEnumerator;

        public CatalogedContact Current => BaseEnumerator.Current.JsonObject as CatalogedContact;
        object IEnumerator.Current => Current;
        public void Dispose() => BaseEnumerator.Dispose();
        public bool MoveNext() => BaseEnumerator.MoveNext();
        public void Reset() => throw new NotImplementedException();

        public EnumeratorCatalogEntryContact(ContainerPersistenceStore container) =>
            BaseEnumerator = container.GetEnumerator();
        }

    public class AsCatalogEntryContact : IEnumerable<CatalogedContact> {
        CatalogContact Catalog;

        public AsCatalogEntryContact(CatalogContact catalog) => Catalog = catalog;

        public IEnumerator<CatalogedContact> GetEnumerator() =>
                    new EnumeratorCatalogEntryContact(Catalog.ContainerPersistence);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion



    public class CatalogContact : Catalog {
        
        
        
        public const string Label = "mmm_Contact";

        public CatalogedContact Self;

        public Dictionary<string, CatalogedContact> DictionaryByEmail = 
                    new Dictionary<string, CatalogedContact>();


        public override string ContainerDefault => Label;

        public AsCatalogEntryContact AsCatalogEntryContact => new AsCatalogEntryContact(this);


        public CatalogedContact LocateByID(string Key) => Locate(Key) as CatalogedContact;


        public CatalogContact(string directory, string ContainerName = null,
            CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null,
                    bool create = true) :
            base(directory, ContainerName, cryptoParameters, keyCollection, create: create) {
            }


        protected override void UpdateEntry(CatalogedEntry catalogedEntry) {
            var CatalogedContact = catalogedEntry as CatalogedContact;
            var Contact = CatalogedContact.Contact;


            DictionaryByEmail.AddSafe(Contact.Email, CatalogedContact);


            }



        public CatalogedContact Add(DareEnvelope contact, bool self = false) {
            var entry = new CatalogedContact(contact) {
                Self=self
                };
            New(entry);

            return entry;
            }

        public CatalogedContact Add(Contact contact, bool self = false) => 
            Add(contact.DareEnvelope ?? DareEnvelope.Encode(contact.GetBytes(true)), self);



        }

    // NYI should all be DareMessages to allow them to be signed.
    public partial class CatalogedContact {


        public override string _PrimaryKey => Key;

        public CatalogedContact() => Key = UDF.Nonce();

        public CatalogedContact(DareEnvelope contact) : this() => EnvelopedContact = contact;

        public CatalogedContact(Contact contact) : this() => EnvelopedContact = DareEnvelope.Encode(contact.GetBytes(tag: true),
                    contentType: "application/mmm");



        public Contact Contact => Contact.Decode(EnvelopedContact);

        }


    public partial class Contact {

        public static new Contact Decode(DareEnvelope message) {
            if (message == null) {
                return null;
                }
            var result = FromJSON(message.GetBodyReader(), true);
            result.DareEnvelope = message;
            return result;
            }

        }


    }
