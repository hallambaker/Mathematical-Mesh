using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;

namespace Goedel.Mesh {

    #region // The data classes CatalogContact, CatalogedContact
    /// <summary>
    /// Device catalog. Describes the properties of all devices connected to the user's Mesh account.
    /// </summary>

    public class CatalogContact : Catalog {



        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm/Contact";

        //public CatalogedContact Self { get; set; }

        ///<summary>Dictionary mapping email addresses to contacts.</summary>
        public Dictionary<string, CatalogedContact> DictionaryByEmail { get; set; } =
                    new Dictionary<string, CatalogedContact>();


        ///<summary>The catalog label</summary>
        public override string ContainerDefault => Label;

        ///<summary>Enumerate the catalog as CatalogedContact instances.</summary>
        public AsCatalogEntryContact AsCatalogEntryContact => new AsCatalogEntryContact(this);


        //public CatalogedContact LocateByID(string Key) => Locate(Key) as CatalogedContact;

        /// <summary>
        /// Constructor for a catalog named <paramref name="storeName"/> in directory
        /// <paramref name="directory"/> using the cryptographic parameters <paramref name="cryptoParameters"/>
        /// and key collection <paramref name="keyCollection"/>.
        /// </summary>
        /// <param name="create">Create a new persistence store on disk if it does not already exist.</param>
        /// <param name="decrypt">Attempt to decrypt the contents of the catalog if encrypted.</param>
        /// <param name="directory">The directory in which the catalog persistence container is stored.</param>
        /// <param name="storeName">The catalog persistence container file name.</param>
        /// <param name="cryptoParameters">The default cryptographic enhancements to be applied to container entries.</param>
        /// <param name="keyCollection">The key collection to be used to resolve keys when reading entries.</param>
        public CatalogContact(
                    string directory,
                    string storeName = null,
                    CryptoParameters cryptoParameters = null,
                    KeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true) :
            base(directory, storeName ?? Label,
                cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
            }

        /// <summary>
        /// Update <paramref name="catalogedEntry"/>. This is overriden to manage the lookup 
        /// by email dictionary.
        /// </summary>
        /// <param name="catalogedEntry">The entry to update.</param>
        protected override void UpdateEntry(CatalogedEntry catalogedEntry) {
            var CatalogedContact = catalogedEntry as CatalogedContact;
            var Contact = CatalogedContact.Contact;

            DictionaryByEmail.AddSafe(Contact.Email, CatalogedContact);
            }


        /// <summary>
        /// Add <paramref name="contact"/> to the catalog. If <paramref name="self"/> is true, this
        /// is the user's own contact.
        /// </summary>
        /// <param name="contact">The enveloped contact to add.</param>
        /// <param name="self">If true, mark as the user's own contact.</param>
        /// <returns>The CatalogedContact entry.</returns>
        public CatalogedContact Add(DareEnvelope contact, bool self = false) {
            var entry = new CatalogedContact(contact) {
                Self = self
                };
            New(entry);

            return entry;
            }

        /// <summary>
        /// Add <paramref name="contact"/> to the catalog. If <paramref name="self"/> is true, this
        /// is the user's own contact.
        /// </summary>
        /// <param name="contact">The contact to add.</param>
        /// <param name="self">If true, mark as the user's own contact.</param>
        /// <returns>The CatalogedContact entry.</returns>
        public CatalogedContact Add(Contact contact, bool self = false) =>
            Add(contact.DareEnvelope ?? DareEnvelope.Encode(contact.GetBytes(true)), self);



        }

    public partial class CatalogedContact {
        /// <summary>
        /// The primary key used to catalog the entry. This is the UDF of the authentication key.
        /// </summary>

        public override string _PrimaryKey => Key;

        ///<summary>Returns the inner contact value.</summary>
        public Contact Contact => Contact.Decode(EnvelopedContact);

        /// <summary>
        /// Default constructor for deserializers.
        /// </summary>

        public CatalogedContact() => Key = UDF.Nonce();

        /// <summary>
        /// Create a cataloged contact from <paramref name="contact"/>.
        /// </summary>
        /// <param name="contact">Dare Envelope containing the contact to create a catalog wrapper for.</param>

        public CatalogedContact(DareEnvelope contact) : this() => EnvelopedContact = contact;


        /// <summary>
        /// Create a cataloged contact from <paramref name="contact"/>.
        /// </summary>
        /// <param name="contact">The contact to create a catalog wrapper for.</param>
        public CatalogedContact(Contact contact) : this() => EnvelopedContact = DareEnvelope.Encode(contact.GetBytes(tag: true),
                    contentType: "application/mmm");

        }


    public partial class Contact {

        /// <summary>
        /// Decode an enveloped <see cref="Contact"/> from the DareEnvelope <paramref name="envelope"/>.
        /// </summary>
        /// <param name="envelope">The envelope containing the contact</param>
        /// <returns>The created contact.</returns>
        public static new Contact Decode(DareEnvelope envelope) {
            if (envelope == null) {
                return null;
                }
            var result = FromJSON(envelope.GetBodyReader(), true);
            result.DareEnvelope = envelope;
            return result;
            }

        }

    #endregion

    #region // Enumerators and associated classes

    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedContact"/> over a persistence
    /// store.
    /// </summary>
    public class EnumeratorCatalogEntryContact : IEnumerator<CatalogedContact> {
        IEnumerator<ContainerStoreEntry> baseEnumerator;

        ///<summary>The current item in the enumeration.</summary>
        public CatalogedContact Current => baseEnumerator.Current.JsonObject as CatalogedContact;
        object IEnumerator.Current => Current;

        /// <summary>
        /// Disposal method.
        /// </summary>
        public void Dispose() => baseEnumerator.Dispose();

        /// <summary>
        /// Move to the next item in the enumeration.
        /// </summary>
        /// <returns><see langword="true"/> if there was a next item to return, otherwise,
        /// <see langword="false"/>.</returns>
        public bool MoveNext() => baseEnumerator.MoveNext();

        /// <summary>
        /// Restart the enumeration.
        /// </summary>
        public void Reset() => throw new NotImplementedException();

        /// <summary>
        /// Construct enumerator from <see cref="PersistenceStore"/>,
        /// <paramref name="persistenceStore"/>.
        /// </summary>
        /// <param name="persistenceStore">The persistence store to enumerate.</param>

        public EnumeratorCatalogEntryContact(PersistenceStore persistenceStore) =>
            baseEnumerator = persistenceStore.GetEnumerator();
        }

    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedContact"/> over a Catalog
    /// </summary>
    public class AsCatalogEntryContact : IEnumerable<CatalogedContact> {
        CatalogContact catalog;

        /// <summary>
        /// Construct enumerator from <see cref="CatalogContact"/>,
        /// <paramref name="catalog"/>.
        /// </summary>
        /// <param name="catalog">The catalog to enumerate.</param>
        public AsCatalogEntryContact(CatalogContact catalog) => this.catalog = catalog;

        /// <summary>
        /// Return an enumerator for the catalog.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<CatalogedContact> GetEnumerator() =>
                    new EnumeratorCatalogEntryContact(catalog.PersistenceStore);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
        private IEnumerator GetEnumerator1() => this.GetEnumerator();
        }

    #endregion



    }
