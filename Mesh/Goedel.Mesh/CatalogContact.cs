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
    /// Describes credentials bound to a network address.
    /// </summary>
    public class NetworkProtocolEntry {

        ///<summary>The contact from which the network protocol data was obtained.
        ///This may be used to update the credential data periodically.</summary>
        public CatalogedContact CatalogedContact { get; }

        ///<summary>The network address entry.</summary>
        public NetworkAddress NetworkAddress { get; }


        ///<summary>The encryption key to use for this contact.</summary>
        public KeyPair MeshKeyEncryption => Expire.Expired(meshKeyEncryption) ??
             SetKeys(ref meshKeyEncryption);

        KeyPair meshKeyEncryption;

        ///<summary>The signature root of trust to use for this contact.</summary>
        public KeyPair MeshKeyAdministrator => Expire.Expired(meshKeyAdministrator) ??
             SetKeys(ref meshKeyAdministrator);
        KeyPair meshKeyAdministrator;
        
        ///<summary>The expiry time for the derived keys.</summary>
        public DateTime? Expire { get; private set; }


        /// <summary>
        /// The constructor, creates a new entry for <paramref name="networkAddress"/> obtained
        /// from <paramref name="catalogedContact"/>.
        /// </summary>
        /// <param name="catalogedContact">The cataloged contact.</param>
        /// <param name="networkAddress">The network address entry.</param>
        public NetworkProtocolEntry(CatalogedContact catalogedContact, NetworkAddress networkAddress) {
            CatalogedContact = catalogedContact;
            NetworkAddress = networkAddress;
            }

        KeyPair SetKeys(ref KeyPair keyPair) {
            if (NetworkAddress.Protocols != null) {

                foreach (var protocol in NetworkAddress?.Protocols) {
                    if (protocol.Protocol == "mmm") {
                        SetKeysMesh(protocol);
                        }

                    }
                }
            return keyPair;
            }


        void SetKeysMesh(NetworkProtocol networkProtocol) {
            if (networkProtocol.Capabilities == null) {
                return;
                }
            foreach (var capability in networkProtocol.Capabilities) {

                switch (capability) {
                    case CapabilityEncryption capabilityEncryption: {
                        meshKeyEncryption = capabilityEncryption.KeyData.KeyPair;
                        break;
                        }
                    case CapabilityAdministrator capabilityAdministrator:     {
                        meshKeyAdministrator = capabilityAdministrator.KeyData.KeyPair;
                        break;
                        }
                    }

                }

            }

        }
    
    /// <summary>
    /// Device catalog. Describes the properties of all devices connected to the user's Mesh account.
    /// </summary>

    public class CatalogContact : Catalog {



        ///<summary>The canonical label for the catalog</summary>
        public const string Label = "mmm_Contact";

        //public CatalogedContact Self { get; set; }

        ///<summary>Dictionary mapping email addresses to contacts.</summary>
        public Dictionary<string, NetworkProtocolEntry> DictionaryByNetworkAddress { get; set; } =
                    new Dictionary<string, NetworkProtocolEntry>();


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
                    IKeyCollection keyCollection = null,
                    bool decrypt = true,
                    bool create = true) :
            base(directory, storeName ?? Label,
                cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
            }

        /// <summary>
        /// Callback called before adding a new entry to the catalog. Overriden to update the values
        /// in <see cref="DictionaryByNetworkAddress"/>.
        /// </summary>
        /// <param name="catalogedEntry">The entry being added.</param>
        protected override void NewEntry(CatalogedEntry catalogedEntry) => UpdateLocal(catalogedEntry);

        /// <summary>
        /// Callback called before updating an entry in the catalog. Overriden to update the values
        /// in <see cref="DictionaryByNetworkAddress"/>.
        /// </summary>
        /// <param name="catalogedEntry">The entry being added.</param>
        protected override void UpdateEntry(CatalogedEntry catalogedEntry) => UpdateLocal(catalogedEntry);

        /// <summary>
        /// Callback called before updating an entry in the catalog. Overriden to update the values
        /// in <see cref="DictionaryByNetworkAddress"/>.
        /// </summary>
        /// <param name="catalogedEntry">The entry being updated.</param>
        void UpdateLocal(CatalogedEntry catalogedEntry) {
            var catalogedContact = catalogedEntry as CatalogedContact;
            var contact = catalogedContact.Contact;

            foreach (var networkAddress in contact.NetworkAddresses) {
                DictionaryByNetworkAddress.AddSafe(networkAddress.Address, 
                    new NetworkProtocolEntry( catalogedContact, networkAddress));
                }
            }



        /// <summary>
        /// Update the entry <paramref name="catalogedContact"/> in the catalog.
        /// </summary>
        /// <param name="catalogedContact">The new catalog values.</param>
        public void Update(CatalogedContact catalogedContact) => UpdateEntry(catalogedContact);

        /// <summary>
        /// Add <paramref name="contact"/> to the catalog. If <paramref name="self"/> is true, this
        /// is the user's own contact.
        /// </summary>
        /// <param name="contact">The contact to add.</param>
        /// <param name="self">If true, mark as the user's own contact.</param>
        /// <returns>The CatalogedContact entry.</returns>
        public (CatalogedContact, bool) TryAdd(Contact contact, bool self = false) {
            if (contact.Id != null) {
                var existing = Locate(contact.Id);
                if (existing != null) {
                    return (existing as CatalogedContact, false);
                    }

                }


            var cataloged = new CatalogedContact(contact, self);
            New(cataloged);
            return (cataloged, true);
            }



        /// <summary>
        /// Add <paramref name="contact"/> to the catalog. If <paramref name="self"/> is true, this
        /// is the user's own contact.
        /// </summary>
        /// <param name="contact">The contact to add.</param>
        /// <param name="self">If true, mark as the user's own contact.</param>
        /// <returns>The CatalogedContact entry.</returns>
        public CatalogedContact Add(Contact contact, bool self = false) {
            var cataloged = new CatalogedContact(contact, self);
            New(cataloged);
            return cataloged;
            }

        /// <summary>
        /// Add the contact contained inside <paramref name="envelope"/> to the catalog.
        /// </summary>
        /// <param name="envelope">The contact to add.</param>

        /// <returns>The CatalogedContact entry.</returns>
        public CatalogedContact Add(DareEnvelope envelope) {
            var contact = Contact.Decode(envelope); // hack: should check the contact info.
            return Add(contact);
            }



        //=>
        //    Add(contact.DareEnvelope ?? DareEnvelope.Encode(contact.GetBytes(true)), self);

        /// <summary>
        /// Add the contact data specified in the file <paramref name="fileName"/>. If 
        /// <paramref name="self"/> is true, register this as the self contact. If
        /// <paramref name="merge"/> is true, merge this contact information.
        /// </summary>
        /// <param name="fileName">The file to fetch the contact data from.</param>
        /// <param name="self">If true, contact data corresponds to this user.</param>
        /// <param name="localName">Short name for the contact to distinguish it from
        /// others.</param>
        /// <param name="merge">Add this data to the existing contact.</param>
        /// <returns></returns>
        public CatalogedContact AddFromFile(
                    string fileName, bool self = false, bool merge=true, string localName=null) {
            throw new NYI();

            }

        public CryptoKey GetByAccountEncrypt(string keyId) {

            if (!DictionaryByNetworkAddress.TryGetValue(keyId, out var catalogedContact)) {
                return null;
                }



            return catalogedContact.MeshKeyEncryption;
            }

        /// <summary>
        /// Attempt to obtain a recipient with identifier <paramref name="keyId"/>.
        /// </summary>
        /// <param name="keyId">The key identifier to match.</param>
        /// <returns>The key pair if found.</returns>
        public CryptoKey TryMatchRecipient(string keyId) {
            if (!DictionaryByNetworkAddress.TryGetValue(keyId, out var catalogedContact)) {
                return null;
                }

            return catalogedContact.MeshKeyEncryption;
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
        /// <param name="self">If true, mark as the user's own contact.</param>
        /// <param name="contact">Dare Envelope containing the contact to create a catalog wrapper for.</param>

        public CatalogedContact(Contact contact, bool self = false) {
            Contact = contact;
            Self = self;
            Key = contact.Id ?? UDF.Nonce();
            }

        /// <summary>
        /// Describe the entry, appending the output to <paramref name="builder"/>.
        /// </summary>
        /// <param name="builder">The output stream.</param>
        /// <param name="detail">If true, provide a detailed description.</param>
        public override void Describe(StringBuilder builder,bool detail = false) {
            builder.AppendLine($"Entry<{_Tag}>: {Key}");
            if (Contact == null) {
                builder.AppendLine($"  EMPTY!");
                return;
                }

            switch (Contact) {
                case ContactPerson contactPerson: {
                    builder.AppendLine($"  Person {contactPerson.Id}");

                    break;
                    }
                case ContactOrganization contactPerson: {
                    break;
                    }
                case ContactGroup contactPerson: {
                    break;
                    }
                }
            foreach (var anchor in Contact.Anchors) {
                builder.AppendLine($"  Anchor {anchor.UDF}");
                }
            foreach (var address in Contact.NetworkAddresses) {
                builder.AppendLine($"  Address {address.Address}");
                }


            }


        }


    public partial class Contact {

        /// <summary>
        /// Decode <paramref name="envelope"/> and return the inner <see cref="Contact"/>
        /// </summary>
        /// <param name="envelope">The envelope to decode.</param>
        /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
        /// <returns>The decoded profile.</returns>
        public static new Contact Decode(DareEnvelope envelope,
                    IKeyLocate keyCollection = null) =>
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
                        string prefix = null,
                        string suffix = null,
                        string email = null) {

            var personName = new PersonName() {
                First = first,
                Last = last,
                Prefix = prefix,
                Suffix = suffix
                };
            personName.SetFullName();
            var networkAddress = new NetworkAddress {
                Address = email,
                Protocols = new List<NetworkProtocol> {
                    new NetworkProtocol() {
                    Protocol = "SMTP" }
                    }
                };
            CommonNames = new List<PersonName> { personName };
            NetworkAddresses = new List<NetworkAddress> { networkAddress };
            }
        }

    public partial class NetworkAddress {

        ///<summary>Serialization constructor</summary>
        public NetworkAddress() {
            }

        /// <summary>
        /// Constructor returning a network address instance for the address
        /// <paramref name="address"/> with keys populated from the Mesh profile
        /// <paramref name="profile"/>.
        /// </summary>
        /// <param name="address">The Mesh account address (account@domain)</param>
        /// <param name="profile">The Mesh profile to obtain public keys from.</param>
        public NetworkAddress(string address, Profile profile) {

            List<CryptographicCapability> keyList = null;

            switch (profile) {
                case ProfileAccount profileAccount: {
                    keyList = new List<CryptographicCapability>() {
                        new CapabilityEncryption () {
                            KeyData = profileAccount.KeyEncryption },
                        new CapabilityAdministrator () {
                            KeyData = profileAccount.KeyOfflineSignature },
                        new CapabilityAuthentication () {
                            KeyData = profileAccount.KeyAuthentication },
                        };
                    break;
                    }
                case ProfileGroup profileGroup: {
                    keyList = new List<CryptographicCapability>() {
                        new CapabilityEncryption () {
                            KeyData = profileGroup.KeyEncryption },
                        new CapabilityAdministrator () {
                            KeyData = profileGroup.KeyOfflineSignature },

                        };
                    break;
                    }
                }

            EnvelopedProfileAccount = profile.DareEnvelope;
            Address = address;
            Protocols = new List<NetworkProtocol>() {
                    new NetworkProtocol() {
                    Protocol = "mmm",
                    Capabilities = keyList
                    }
                };

            }


        }

    public partial class PersonName{

        ///<summary>Set the full name.</summary>
        public void SetFullName() {

            var builder = new StringBuilder();

            SpaceAfter(builder, Prefix);
            SpaceAfter(builder, First);
            if (Middle != null) {
                foreach (var middle in Middle) {
                    SpaceAfter(builder, middle);
                    }
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
