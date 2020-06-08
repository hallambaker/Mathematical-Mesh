using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh {

    #region // The data classes CatalogContact, CatalogedContact
    /// <summary>
    /// Device catalog. Describes the properties of all devices connected to the user's Mesh account.
    /// </summary>

    public class CatalogContact : Catalog {



        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm_Contact";

        //public CatalogedContact Self { get; set; }

        ///<summary>Dictionary mapping email addresses to contacts.</summary>
        public Dictionary<string, CatalogedContact> DictionaryByNetworkAddress { get; set; } =
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
            var catalogedContact = catalogedEntry as CatalogedContact;
            var contact = catalogedContact.Contact;

            foreach (var networkAddress in contact.NetworkAddresses) {
                DictionaryByNetworkAddress.AddSafe(networkAddress.Address, catalogedContact);
                }
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


        public CatalogedContact AddFromFile(string fileName, bool self = false) {
            throw new NYI();

            }

        public CatalogedContact GetSelf(string localName) {
            throw new NYI();
            }

        }

    public partial class CatalogedContact {
        /// <summary>
        /// The primary key used to catalog the entry. This is the UDF of the authentication key.
        /// </summary>

        public override string _PrimaryKey => Key;

        // ///<summary>Returns the inner contact value.</summary>
        //public Contact Contact => Contact.Decode(EnvelopedContact);

        /// <summary>
        /// Default constructor for deserializers.
        /// </summary>

        public CatalogedContact() => Key = UDF.Nonce();

        /// <summary>
        /// Create a cataloged contact from <paramref name="contact"/>.
        /// </summary>
        /// <param name="contact">Dare Envelope containing the contact to create a catalog wrapper for.</param>

        public CatalogedContact(DareEnvelope contact) {
            throw new NYI();

            }
        //=> EnvelopedContact = contact;


        /// <summary>
        /// Create a cataloged contact from <paramref name="contact"/>.
        /// </summary>
        /// <param name="contact">The contact to create a catalog wrapper for.</param>
        public CatalogedContact(Contact contact) {
            throw new NYI();
            }

        //=> EnvelopedContact = DareEnvelope.Encode(contact.GetBytes(tag: true),
        //            contentType: "application/mmm");

        }


    public partial class Contact {

        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="Contact"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new Contact Decode(DareEnvelope envelope,
                    KeyCollection keyCollection = null) =>
                        MeshItem.Decode(envelope, keyCollection) as Contact;


        }



    public partial class ContactPerson {
        ///<summary>Base constructor</summary>
        public ContactPerson() {
            }

        /// <summary>
        /// Convenience constructor filling in basic fields
        /// </summary>
        /// <param name="first">The first name</param>
        /// <param name="last">The last name</param>
        /// <param name="prefix">Optional prefix</param>
        /// <param name="suffix">Optional suffix</param>
        /// <param name="email">Optional SMTP email address</param>
        public ContactPerson(
                        string first,
                        string last,
                        string prefix=null,
                        string suffix=null,
                        string email=null) {

            var personName = new PersonName() {
                First = first,
                Last = last,
                Prefix = prefix,
                Suffix = suffix
                };
            personName.SetFullName();
            var networkAddress = new NetworkAddress {
                Address = email,
                Protocols = new List<string> { "SMTP" }
                };
            CommonNames = new List<PersonName> { personName };
            NetworkAddresses = new List<NetworkAddress> { networkAddress };
            }
        }



    public partial class PersonName{

        ///<summary>Set the full name.</summary>
        public void SetFullName() {

            var builder = new StringBuilder();

            SpaceAfter(builder, Prefix);
            SpaceAfter(builder, First);
            foreach (var middle in Middle) {
                SpaceAfter(builder, middle);
                }
            Unspaced(builder, Last);
            SpaceBefore(builder, Suffix);
            SpaceBefore(builder, PostNominal);

            FullName = builder.ToString();
            }

        void Unspaced(StringBuilder builder, string value) {
            if (value != null) {
                builder.Append(value);
                }

            }


        void SpaceAfter(StringBuilder builder, string value) {
            if (value != null) {
                builder.Append(value);
                builder.Append(' ');
                }

            }

        void SpaceBefore(StringBuilder builder, string value) {
            if (value != null) {
                builder.Append(' ');
                builder.Append(value);
                
                }

            }
        }


    #endregion

    #region // Enumerators and associated classes

    /// <summary>
    /// Enumerator class for sequences of <see cref="CatalogedContact"/> over a persistence
    /// store.
    /// </summary>
    public class EnumeratorCatalogEntryContact : IEnumerator<CatalogedContact> {
        IEnumerator<StoreEntry> baseEnumerator;

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
