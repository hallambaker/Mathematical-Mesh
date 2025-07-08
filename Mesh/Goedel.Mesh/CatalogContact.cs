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


using Goedel.Contacts;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Discovery;

using System.Security.Principal;

namespace Goedel.Mesh;

#region // The data classes CatalogContact, CatalogedContact

/// <summary>
/// Device catalog. Describes the properties of all devices connected to the user's Mesh account.
/// </summary>

public class CatalogContact : Catalog<CatalogedContact> {

    #region // Properties
    ///<summary>The canonical label for the catalog</summary>
    public const string Label = MeshConstants.StoreTypeContactTag;

    ///<inheritdocs/>
    public override StoreType StoreType => StoreType.Contact;

    ///<summary>Dictionary mapping email addresses to contacts.</summary>
    Dictionary<string, MeshContact> DictionaryByNetworkAddress { get; } = [];

    Dictionary<string, List<CryptoKey>> DictionaryProfiles { get; } = [];

    ///<summary>Contacts for self.</summary> 
    public Dictionary<string, CatalogedContact> DictionaryContactSelf { get; } = [];

    ///<summary>Default contact for self.</summary> 
    public CatalogedContact DefaultContactSelf { get; set; }

    ///<inheritdoc/>
    public override string SequenceDefault => Label;

    ///<summary>Dictionary for locating capabilities for use.</summary>
    public Dictionary<string, CryptoKeyIndex> DictionaryDecryptByKeyId =
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
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    /// <returns>The instance created.</returns>
    public static new Store Factory(
            string directory,
                string storeId,
                IMeshClient meshClient = null,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) =>
        new CatalogContact(directory, storeId, policy, cryptoParameters, keyCollection,
            decrypt, create, bitmask: bitmask);

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
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    public CatalogContact(
                string directory,
                string storeName = null,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) :
        base(directory, storeName ?? Label,
                    policy, cryptoParameters, keyCollection,
                    decrypt: decrypt, create: create, bitmask: bitmask) {
        }
    #endregion
    #region // Override methods
    ///<inheritdoc/>
    protected override void NewEntry(CatalogedContact catalogedEntry) => UpdateEntry(catalogedEntry);




    ///<inheritdoc/>
    protected override void UpdateEntry(CatalogedContact catalogedEntry) {

        base.UpdateEntry(catalogedEntry);

        //var catalogedContact = catalogedEntry as CatalogedContact;
        var contact = catalogedEntry.JsContact;


        if (catalogedEntry.Self == true) {
            DefaultContactSelf ??= catalogedEntry;
            if (catalogedEntry.LocalName != null) {
                DictionaryContactSelf.AddSafe(catalogedEntry.LocalName, catalogedEntry);
                }
            }


        foreach (var entry in catalogedEntry.VerifiedContacts.IfEnumerable()) {
            entry.CatalogedContact ??= catalogedEntry;
            DictionaryByNetworkAddress.AddSafe(entry.ProfileUdf, entry);
            foreach (var address in entry.AccountAddresses) {
                DictionaryByNetworkAddress.AddSafe(address, entry);
                }


            if (entry.ProfileType == ProfileGroup.__Tag) {
                //var profile = JsonObject.StreamParse<ProfileGroup>();



                }
            }
        foreach (var keyShare in catalogedEntry.KeyShares.IfEnumerable()) {
            keyShare.CatalogedContact = catalogedEntry;
            DictionaryDecryptByKeyId.Remove(keyShare.PublicKeyId.ToLower());
            DictionaryDecryptByKeyId.Add(keyShare.PublicKeyId.ToLower(), keyShare);
            }



        foreach (var publicKey in catalogedEntry.PublicKeys.IfEnumerable()) {

            }
        foreach (var privateKey in catalogedEntry.PrivateKeys.IfEnumerable()) {

            //DictionaryDecryptByKeyId.Remove(privateKey.KeyId.ToLower());
            //DictionaryDecryptByKeyId.Add(privateKey.KeyId.ToLower(), privateKey);

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
    /// <param name="localname"></param>
    /// <returns>The CatalogedContact entry.</returns>
    /// <param name="self">If true, mark as the user's own contact.</param>
    public (CatalogedContact, bool) TryAdd(
                    JsContact contact,
                    string localname = null,
                    bool self = false) {

        if (contact.Uid != null) {
            var existing = Locate(contact.Uid);
            if (existing != null) {
                return (existing, false);
                }
            }

        var cataloged = new CatalogedContact(contact, self) {
            Self = self,
            LocalName = localname
            };
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
    public static CatalogedContact GetUpdated(JsContact contact, bool self = false) {
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
    public CatalogedContact Add(JsContact contact, bool self = false) {
        var cataloged = new CatalogedContact(contact, self);
        New(cataloged);
        return cataloged;
        }

    /// <summary>
    /// Add the contact contained inside <paramref name="envelope"/> to the catalog.
    /// </summary>
    /// <param name="envelope">The contact to add.</param>

    /// <returns>The CatalogedContact entry.</returns>
    public CatalogedContact Add(Enveloped envelope) {
        throw new NYI();

        //var contact = Contact.Decode(envelope); // hack: should check the contact info.
        //return Add(contact);
        }

    /// <summary>
    /// Return the contact with identifier <paramref name="key"/>.
    /// </summary>
    /// <param name="key">specifies the identifier to return.</param>
    /// <returns>The contact, if found. Otherwise null.</returns>
    public override CatalogedContact Get(string key) {
        //throw new NYI();


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
    public MeshContact GetNetworkEntry(string networkAddress) {


        DictionaryByNetworkAddress.TryGetValue(networkAddress, out var catalogedContact);
        return catalogedContact;
        }

    /// <summary>
    /// Retuen the mesh account encryption key for the address <paramref name="networkAddress"/>
    /// </summary>
    /// <param name="networkAddress">The address to return the entry for.</param>
    /// <returns>The mesh account encryption key if found, otherwise, null.</returns>
    public CryptographicKey GetByAccountEncrypt(string networkAddress) {
        if (DictionaryByNetworkAddress.TryGetValue(networkAddress, out var verifiedProfile)) {
            return verifiedProfile.CommonEncryption.GetKeyPair();
            }

        return null;
        }


    /// <summary>
    /// Attempt to obtain a recipient with identifier <paramref name="keyId"/>.
    /// </summary>
    /// <param name="keyId">The key identifier to match.</param>
    /// <returns>The key pair if found.</returns>
    public CryptographicKey TryMatchRecipient(string keyId) {
        if (DictionaryByNetworkAddress.TryGetValue(keyId, out var verifiedProfile)) {
            return verifiedProfile.CommonEncryption.GetKeyPair();
            }

        return null;
        }





    /// <summary>
    /// Resolve a decryption capability corresponding to the key <paramref name="keyId"/>.
    /// </summary>
    /// <param name="keyId">The identifier of the public key to obtain a decryption 
    /// capability against.</param>
    /// <param name="keyDecrypt">The decryption key if found, otherwise null.</param>
    /// <returns>true if a key is found, otherwise false.</returns>
    public bool TryFindKeyDecryption(string keyId, out IKeyDecrypt keyDecrypt) {
        if (DictionaryDecryptByKeyId.TryGetValue(keyId.ToLower(), out var key)) {



            keyDecrypt = key.GetKeyPair(KeyCollection);
            return true;
            }
        keyDecrypt = null;
        return false;
        }

    /// <summary>
    /// Attempt to find a contact by its local name key/
    /// </summary>
    /// <param name="key">The local name to search on.</param>
    /// <param name="contact">The contact (if found).</param>
    /// <returns>True if the contact is found, otherwise false.</returns>
    public bool TryFindByLocalName(
                    string key,
                    out CatalogedContact contact) => DictionaryByLocalName.TryGetValue(key, out contact);
    #endregion
    }


public partial class CatalogedContact {

    #region // Properties

    ///<inheritdoc/>
    public override string _PrimaryKey => Key;

    ///<summary>Message sent in exchange. This is only populated in a return from a 
    ///contact exchange method.</summary> 
    public Message Message { get; set; } = null;





    ///<summary>Typed enveloped data</summary> 
    public Enveloped<CatalogedContact> GetEnvelopedCatalogedContact() =>
        new(DareEnvelope);

    public List<CryptoKey> PublicKeys = [];
    public List<PrivateKeyEntry> PrivateKeys = [];

    #endregion
    #region // Factory methods and constructors

    /// <summary>
    /// Default constructor for deserializers.
    /// </summary>

    public CatalogedContact() => Key = Udf.Nonce();



    /// <summary>
    /// Create a cataloged contact from <paramref name="contact"/>.
    /// </summary>
    /// <param name="self">If true, mark as the user's own contact.</param>
    /// <param name="contact">Dare Envelope containing the contact to create a catalog wrapper for.</param>

    public CatalogedContact(JsContact contact, bool self = false) {
        EnvelopedJsContact = new (contact);
        Key = contact.Uid ?? Udf.Nonce();

        if (contact.CryptoKeys is not null) {
            foreach (var service in contact.OnlineServices.IfEnumerable()) {
                if (service.Value.Service == ContactConstant.OnlineServiceMesh) {
                    AddMeshEntry(contact, service.Value);
                    }
                else if (service.Value.Service == ContactConstant.OnlineServiceGroup) {
                    AddMeshEntry(contact, service.Value);
                    }
                }
            }
        }


    void AddMeshEntry(JsContact contact, OnlineService service) {
        foreach (var id in service.CryptoKeyIds.IfEnumerable()) {
            if (contact.CryptoKeys.TryGetValue(id.Key, out var cryptoKey)) {

                if (cryptoKey is JsonWebKeySet jsonWebKeySet) {
                    switch (id.Value) {
                        case ContactConstant.CryptoKeyEncrypt:
                        case ContactConstant.CryptoKeyVerify: {
                            PublicKeys.Add(cryptoKey);
                            break;
                            }
                        case ContactConstant.CryptoKeyDecryptShare: 
                        case ContactConstant.CryptoKeyAuthenticate: 
                        case ContactConstant.CryptoKeySign: {
                            KeyShares ??= new();
                            KeyShares.Add(new CryptoKeyIndex(service, id.Key));

                            //var privateKeyEntry = new PrivateKeyEntry(contact, service, jsonWebKeySet);
                            //PrivateKeys.Add(privateKeyEntry);
                            break;
                            }
                        case ContactConstant.OnlineServiceMesh:
                        case ContactConstant.OnlineServiceGroup: {
                            VerifyProfileBytes(jsonWebKeySet.MeshProfileBytes);
                            break;
                            }

                        case null: {
                            break;
                            }
                        default: {
                            break;
                            }
                        }

                    }


                }
            }
        }


    void VerifyProfileBytes(byte[]? data) {
        if (data is null) {
            return;
            }


        var envelope = JsonObject.StreamParse<Enveloped>(data);

        Console.WriteLine(envelope.Body.ToUTF8());
        var profile = envelope.StreamParseTag<ProfileAccount>();
        profile.Validate();


        VerifiedContacts ??= [];
        VerifiedContacts.Add(new MeshContact (this, profile));
        }


    public MeshContact GetMeshContact() {

        foreach (var entry in VerifiedContacts.IfEnumerable()) {
            if (entry is MeshContact meshContact) {
                return meshContact;
                }

            }

        return null;
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
        if (JsContact == null) {
            builder.AppendLine($"  EMPTY!");
            return;
            }

        //switch (Contact) {
        //    case ContactPerson contactPerson: {
        //        builder.AppendLine($"  Person {contactPerson.Id}");
        //        break;
        //        }
        //    case ContactOrganization contactOrganization: {
        //        builder.AppendLine($"  Organization {contactOrganization.Id}");
        //        break;
        //        }
        //    case ContactGroup ContactGroup: {
        //        builder.AppendLine($"  Group {ContactGroup.Id}");
        //        break;
        //        }
        //    }
        //foreach (var anchor in Contact.Anchors) {
        //    builder.AppendLine($"  Anchor {anchor.Udf}");
        //    }
        //foreach (var address in Contact.NetworkAddresses) {
        //    builder.AppendLine($"  Address {address.Address}");
        //    }


        }




    #endregion
    }
#endregion
#region // Mesh Profile

public record ContactEntryMesh {
    OnlineService OnlineService;
    JsonWebKeySet JsonWebKeySet;
    public Enveloped EnvelopedProfileAccount => envelopedProfileAccount ??
        JsonObject.StreamParse<Enveloped> (JsonWebKeySet.Data);
    Enveloped envelopedProfileAccount;
    public ContactEntryMesh(
            OnlineService onlineService) {
        OnlineService = onlineService;
        if (onlineService.CryptoKey?.Count == 1) {
            JsonWebKeySet = onlineService.CryptoKey[0] as JsonWebKeySet;


            Console.WriteLine(JsonWebKeySet.Data.ToUTF8());
            }



        var x = EnvelopedProfileAccount;

        }


    public CryptographicKey GetMeshKeyEncryption() {


        throw new NotImplementedException();
        }


    }


#endregion
#region // Contact and sub classes



public partial class MeshContact {
    public CatalogedContact CatalogedContact { get; set; }

    public MeshContact() {
        }

    public MeshContact(
                CatalogedContact catalogedContact,
                ProfileAccount profileAccount) {
        CatalogedContact = catalogedContact;
        ProfileUdf = profileAccount.UdfString;
        ProfileType = profileAccount._Tag;
        CommonEncryption = profileAccount.CommonEncryption;
        AdministratorSignature = profileAccount.AdministratorSignature;

        DirectAddress = profileAccount.DirectAddress;
        AccountAddresses = [profileAccount.AccountAddress];
        if (profileAccount.AccountHandle != null) {
            AccountAddresses.Add(profileAccount.AccountHandle);
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


    ///<summary>The address</summary> 
    public string Address => throw new NYI();



    ///<summary>The encryption key to use for this contact.</summary>
    public Cryptography.CryptographicKey MeshKeyEncryption => Expire.Expired(meshKeyEncryption) ??
            SetKeys(ref meshKeyEncryption);

    CryptographicKey meshKeyEncryption;

    /////<summary>The signature root of trust to use for this contact.</summary>
    //public CryptographicKey MeshKeyAdministrator => Expire.Expired(meshKeyAdministrator) ??
    //     SetKeys(ref meshKeyAdministrator);
    //CryptographicKey meshKeyAdministrator;

    ///<summary>The expiry time for the derived keys.</summary>
    public System.DateTime? Expire { get; private set; }


    ///// <summary>
    ///// The constructor, creates a new entry for <paramref name="networkAddress"/> obtained
    ///// from <paramref name="catalogedContact"/>.
    ///// </summary>
    ///// <param name="catalogedContact">The cataloged contact.</param>
    ///// <param name="networkAddress">The network address entry.</param>
    //public NetworkProtocolEntry(JsContact contact, OnlineService service) {
    //    //CatalogedContact = catalogedContact;
    //    //NetworkAddress = networkAddress;
    //    }

    CryptographicKey SetKeys(ref CryptographicKey keyPair) {

        throw new NYI();

        //if (NetworkAddress is NetworkProfile networkProfile) {
        //    var profileAccount = networkProfile.EnvelopedProfileAccount.Decode();
        //    meshKeyEncryption = profileAccount.CommonEncryption.CryptoKey;
        //    meshKeyAdministrator = profileAccount.AdministratorSignature.CryptoKey;
        //    }
        //return keyPair;
        }


    }
    
#endregion