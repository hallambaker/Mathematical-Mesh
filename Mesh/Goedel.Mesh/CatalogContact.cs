#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


namespace Goedel.Mesh;

#region // The data classes CatalogContact, CatalogedContact

/// <summary>
/// Device catalog. Describes the properties of all devices connected to the user's Mesh account.
/// </summary>

public class CatalogContact : Catalog<CatalogedContact> {

    #region // Properties
    ///<summary>The canonical label for the catalog</summary>
    public const string Label = MeshConstants.MMM_Contact;

    ///<summary>Dictionary mapping email addresses to contacts.</summary>
    public Dictionary<string, NetworkProtocolEntry> DictionaryByNetworkAddress { get; set; } =
                new Dictionary<string, NetworkProtocolEntry>();

    ///<inheritdoc/>
    public override string ContainerDefault => Label;

    ///<summary>Dictionary for locating capabilities for use.</summary>
    public Dictionary<string, CapabilityDecrypt> DictionaryDecryptByKeyId =
            new();

    #endregion
    #region // Factory methods and constructors
    /// <summary>
    /// Factory delegate
    /// </summary>
    /// <param name="directory">Directory of store file on local machine.</param>
    /// <param name="storeId">Store identifier.</param>
    /// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">Key collection to be used to resolve keys</param>
    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
    /// <param name="create">If true, create a new file if none exists.</param>
    /// <param name="meshClient">The mesh client.</param>
    public static new Store Factory(
            string directory,
                string storeId,
                IMeshClient meshClient = null,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true) =>
        new CatalogContact(directory, storeId, policy, cryptoParameters, keyCollection, decrypt, create);

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
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">The key collection to be used to resolve keys when reading entries.</param>
    public CatalogContact(
                string directory,
                string storeName = null,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true) :
        base(directory, storeName ?? Label,
                    policy, cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
        }
    #endregion
    #region // Override methods
    ///<inheritdoc/>
    public override void NewEntry(CatalogedContact catalogedEntry) => UpdateLocal(catalogedEntry);

    ///<inheritdoc/>
    public override void UpdateEntry(CatalogedContact catalogedEntry) => UpdateLocal(catalogedEntry);

    #endregion
    #region // Class methods

    ///<inheritdoc/>
    public override void UpdateLocal(CatalogedEntry catalogedEntry) {

        base.UpdateLocal(catalogedEntry);

        var catalogedContact = catalogedEntry as CatalogedContact;
        var contact = catalogedContact.Contact;

        foreach (var networkAddress in contact.NetworkAddresses) {
            DictionaryByNetworkAddress.AddSafe(networkAddress.Address,
                new NetworkProtocolEntry(catalogedContact, networkAddress));

            if (networkAddress.Capabilities != null) {
                foreach (var capability in networkAddress.Capabilities) {
                    capability.KeyCollection = KeyCollection;
                    switch (capability) {
                        case CapabilityDecrypt capabilityDecrypt: {
                                //Console.WriteLine($"Key {networkAddress.Address} -> {capability.Id}");

                                if (DictionaryDecryptByKeyId.TryGetValue(capability.Id, out var existing) ){
                                    if (capabilityDecrypt.Issued > existing.Issued) {
                                        DictionaryDecryptByKeyId.Remove(capability.Id);
                                        DictionaryDecryptByKeyId.Add(capability.Id, capabilityDecrypt);
                                        }
                                    }
                                else {
                                    DictionaryDecryptByKeyId.Add(capability.Id, capabilityDecrypt);
                                    }

                                //DictionaryDecryptByKeyId.Replace(capability.Id, capabilityDecrypt);
                                break;
                                }
                        }
                    }
                }


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
    /// Fetch the existing contact from the catalog and merge with values from
    /// <paramref name="contact"/>. 
    /// </summary>
    /// <param name="contact">The contact whose values are to be merged.</param>
    /// <param name="self">If true set the self marker.</param>
    /// <returns>The updated contact.</returns>
    public static CatalogedContact GetUpdated(Contact contact, bool self = false) {
        var cataloged = new CatalogedContact(contact, self);

        "Need to merge catalog data intelligently".TaskFunctionality();

        return cataloged;
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

    /// <summary>
    /// Return the contact with identifier <paramref name="key"/>.
    /// </summary>
    /// <param name="key">specifies the identifier to return.</param>
    /// <returns>The contact, if found. Otherwise null.</returns>
    public override CatalogedContact Get(string key) {
        if (base.Get(key).NotNull(out var result)) {
            return result;
            }
        if (DictionaryByNetworkAddress.TryGetValue(key, out var networkEntry)) {
            return networkEntry.CatalogedContact;
            }
        return null;
        }

    /// <summary>
    /// Return the network entry for the address <paramref name="networkAddress"/>
    /// </summary>
    /// <param name="networkAddress">The address to return the entry for.</param>
    /// <returns>The network entry if found, otherwise, null.</returns>
    public NetworkProtocolEntry GetNetworkEntry(string networkAddress) {
        DictionaryByNetworkAddress.TryGetValue(networkAddress, out var catalogedContact);
        return catalogedContact;
        }

    /// <summary>
    /// Retuen the mesh account encryption key for the address <paramref name="networkAddress"/>
    /// </summary>
    /// <param name="networkAddress">The address to return the entry for.</param>
    /// <returns>The mesh account encryption key if found, otherwise, null.</returns>
    public CryptoKey GetByAccountEncrypt(string networkAddress) {

        if (!DictionaryByNetworkAddress.TryGetValue(networkAddress, out var catalogedContact)) {
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


    /// <summary>
    /// Resolve a decryption capability corresponding to the key <paramref name="keyId"/>.
    /// </summary>
    /// <param name="keyId">The identifier of the public key to obtain a decryption 
    /// capability against.</param>
    /// <param name="keyDecrypt">The decryption key if found, otherwise null.</param>
    /// <returns>true if a key is found, otherwise false.</returns>
    public bool TryFindKeyDecryption(string keyId, out IKeyDecrypt keyDecrypt) {
        var found = DictionaryDecryptByKeyId.TryGetValue(keyId, out var key);
        keyDecrypt = key;
        return found;
        }




    #endregion
    }

public partial class CatalogedContact {

    #region // Properties
    /// <summary>
    /// The primary key used to catalog the entry. This is the UDF of the authentication key.
    /// </summary>

    public override string _PrimaryKey => Key;

    ///<summary>Typed enveloped data</summary> 
    public Enveloped<CatalogedContact> GetEnvelopedCatalogedContact() =>
        new(DareEnvelope);



    #endregion
    #region // Factory methods and constructors

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

    #endregion
    #region // Override methods

    /// <summary>
    /// Describe the entry, appending the output to <paramref name="builder"/>.
    /// </summary>
    /// <param name="builder">The output stream.</param>
    /// <param name="detail">If true, provide a detailed description.</param>
    public override void Describe(StringBuilder builder, bool detail = false) {
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
            case ContactOrganization contactOrganization: {
                    builder.AppendLine($"  Organization {contactOrganization.Id}");
                    break;
                    }
            case ContactGroup ContactGroup: {
                    builder.AppendLine($"  Group {ContactGroup.Id}");
                    break;
                    }
            }
        foreach (var anchor in Contact.Anchors) {
            builder.AppendLine($"  Anchor {anchor.Udf}");
            }
        foreach (var address in Contact.NetworkAddresses) {
            builder.AppendLine($"  Address {address.Address}");
            }


        }

    #endregion
    }
#endregion
#region // Contact and sub classes

public partial class Contact {

    ///<summary>Typed enveloped data</summary> 
    public Enveloped<Contact> EnvelopedContact =>
        new(DareEnvelope);

    /// <summary>
    /// Decode <paramref name="envelope"/> and return the inner <see cref="Contact"/>
    /// </summary>
    /// <param name="envelope">The envelope to decode.</param>
    /// <param name="keyCollection">Key collection to use to obtain decryption keys.</param>
    /// <returns>The decoded profile.</returns>
    /// <remarks>Keep this convenience decoder because it is necessary to decode contacts
    /// from EARL envelopes.</remarks>
    public static new Contact Decode(DareEnvelope envelope,
                IKeyCollection keyCollection = null) =>
                    MeshItem.Decode(envelope, keyCollection) as Contact;

    /// <summary>
    /// Convenience constructor, wrap a cataloged contact arround this contact.
    /// </summary>
    /// <param name="self">If true, the contact is for the owner of the account.</param>
    /// <returns>The cataloged contact.</returns>
    public CatalogedContact CatalogedContact(bool self = false) =>
        new(this, self);

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
    public NetworkAddress(string address, ProfileAccount profile) {

        List<CryptographicCapability> keyList = null;

        EnvelopedProfileAccount = profile.GetEnvelopedProfileAccount();


        Address = address;
        Protocols = new List<NetworkProtocol>() {
                    new NetworkProtocol() {
                    Protocol = "mmm",
                    Capabilities = keyList
                    }
                };
        }

    }

public partial class PersonName {

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

    static void Unspaced(StringBuilder builder, string value) {
        if (value != null) {
            builder.Append(value);
            }

        }

    static void SpaceAfter(StringBuilder builder, string value) {
        if (value != null) {
            builder.Append(value);
            builder.Append(' ');
            }

        }

    static void SpaceBefore(StringBuilder builder, string value) {
        if (value != null) {
            builder.Append(' ');
            builder.Append(value);

            }

        }
    }

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
    public CryptoKey MeshKeyEncryption => Expire.Expired(meshKeyEncryption) ??
         SetKeys(ref meshKeyEncryption);

    CryptoKey meshKeyEncryption;

    ///<summary>The signature root of trust to use for this contact.</summary>
    public CryptoKey MeshKeyAdministrator => Expire.Expired(meshKeyAdministrator) ??
         SetKeys(ref meshKeyAdministrator);
    CryptoKey meshKeyAdministrator;

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

    CryptoKey SetKeys(ref CryptoKey keyPair) {
        if (NetworkAddress.EnvelopedProfileAccount != null) {
            var profileAccount = NetworkAddress.EnvelopedProfileAccount.Decode();
            meshKeyEncryption = profileAccount.CommonEncryption.CryptoKey;
            meshKeyAdministrator = profileAccount.ProfileSignature.CryptoKey;
            }
        return keyPair;
        }


    }
#endregion