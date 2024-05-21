using Goedel.Cryptography.Dare;

using System.Collections;
using System.Threading;

namespace Goedel.Everything;
#region // Bindings to classes specified through the Guigen schema.

public partial class ContactSection : IHeadedSelection{

    IAccountSelector? Account { get; }
    ContextUser? ContextUser => Account?.ContextUser;

    public ContactSelection? ContactSelection { get; }

    public GuigenCatalogContact? Catalog { get; }

    ///<inheritdoc/>
    public override ISelectCollection? ChooseContact { get => ContactSelection; set { } }

    ///<inheritdoc/>
    public GuiBinding SelectionBinding => _BoundContact.BaseBinding;

    /// <summary>
    /// Return an instance bound to the Contacts catalog of the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account whose contacts are to be used.</param>
    public ContactSection(IAccountSelector? account = null) {
        Account = account;
        Catalog = ContextUser?.GetStore(CatalogContact.Label, create: false) as GuigenCatalogContact;
        ContactSelection = Catalog is null ? null : new ContactSelection(ContextUser, Catalog);
        }

    public async Task AddAsync(CatalogedContact entry) {
        ContactSelection.AssertNotNull(NYI.Throw);
        var bound = BoundContact.Factory(entry);
        await ContactSelection.AddAsync(bound);
        }

    public async Task UpdateAsync(BoundContact entry) {
        ContactSelection.AssertNotNull(NYI.Throw);
        await ContactSelection.UpdateAsync(entry);
        }

    public async Task DeleteAsync(BoundContact entry) {
        ContactSelection.AssertNotNull(NYI.Throw);
        await ContactSelection.RemoveAsync(entry);
        }

    }
#endregion
#region // Bindings to classes specified through the Guigen schema.


public partial class ContactNetworkAddress : IBoundPresentation {

    public NetworkAddress NetworkAddress => (Bound as NetworkAddress)!;

    public static ContactNetworkAddress Factory(NetworkAddress address) {
        switch (address) {
            case NetworkProfile networkProfile: {
                return new ContactNetworkCredential(networkProfile) {
                    Bound = address,
                    //Protocol = "TBS",
                    //Address = networkProfile.Address,
                    //Fingerprint = null
                    };
                }
            default: {
                return new ContactNetworkIdentifier() {
                    Bound = address,
                    Protocol = "TBS",
                    Address = address.Address,
                    Fingerprint = null
                    };
                }

            }


        }

    public virtual void Fill() {
        }

    public IDataActions GetActions(string? protocol) =>
        protocol is null ? null : new DataActions(protocol);
    }

public record DataActions(string? Protocol): IDataActions {
    }


public partial class ContactNetworkIdentifier {

    NetworkAddress NetworkAddress => (Bound as NetworkAddress)!;

    public override IDataActions? Actions => GetActions(Protocol);


    public override IFieldIcon? Type => GetFieldIcon();

    IFieldIcon GetFieldIcon() {
        if (Protocol is null) {
            return FieldIcons.MessageGeneric;
            }

        if (FieldIcons.ProtocolToImag.TryGetValue(Protocol.ToLower(), out var icon)) 
                    return icon;



        return FieldIcons.MessageGeneric;

        }

    public override void Fill() {
        Bound ??= new NetworkAddress();

        NetworkAddress.Address = Address;
        NetworkAddress.Protocol = Protocol;


        base.Fill();

        }
    }



public partial class ContactNetworkCredential {


    public override IDataActions? Actions => GetActions(Protocol);

    NetworkProfile NetworkProfile => (Bound as NetworkProfile)!;

    public override IFieldIcon? Type => FieldIcons.ContactMesh;


    public ContactNetworkCredential() {
        }

    public ContactNetworkCredential(NetworkProfile networkProfile) : base(networkProfile) {
        }

    public override void Fill() {
        Bound ??= new NetworkProfile();

        NetworkProfile.Address = Address;


        NetworkProfile.Protocol = Protocol;


        base.Fill();
        
        }

    }

public partial class _ContactNetworkCredential {
    public _ContactNetworkCredential() {
        }

    public _ContactNetworkCredential(NetworkProfile networkProfile) {
        Bound = networkProfile;
        Protocol = "mmm";
        Address = networkProfile.Address;

        var profile = networkProfile.EnvelopedProfileAccount?.EnvelopedObject;
        Fingerprint = profile?.UdfString;

        }
    }

public partial class ContactPhysicalAddress : IBoundPresentation {
    public virtual void Fill() {
        }
    }


public partial class BoundContact : IBoundPresentation, IDialog {

    public CatalogedContact CatalogedContact => Bound as CatalogedContact;
    public GuiDialog Dialog(Gui gui) => (gui as EverythingMaui).DialogBoundContact;

    public static BoundContact Factory(CatalogedContact contact) {
        var result = new BoundContact();
        result.Bound = contact;
        result.ReadBound();
        return result;
        }

    public virtual void ReadBound() {
        //Title = CatalogedContact.Title;
        //Description = CatalogedContact.Description;
        //Path = CatalogedContact.Path;
        }
    public virtual void SetBound() {
        //CatalogedContact.Title = Title;
        //CatalogedContact.Description = Description;
        //CatalogedContact.Path = Path;
        }



    }

public partial class BoundContactBusiness : IBoundPresentation, IDialog {

    public override IFieldIcon Type => FieldIcons.ContactBusiness;

    }

public partial class BoundContactPlace : IBoundPresentation, IDialog {

    public override IFieldIcon Type => FieldIcons.ContactPlace;

    }


public partial class BoundContactPerson : IBoundPresentation, IDialog {

    public GuiDialog Dialog(Gui gui) => (gui as EverythingMaui).DialogBoundContactPerson;


    public override IFieldIcon Type => FieldIcons.ContactPerson;

    //static BoundContactPerson() {
    //    IsBacker = isBacker;
    //    }


    static bool isBacker(object data) => data is CatalogedContact;

    public CatalogedEntry CatalogedEntry { get; set; }


    public string? FullName;
    public override string Display => Local ?? FullName;


    static PersonName Default = new PersonName() {
        First = "Unspecified",
        Last = "Contact"
        };

    public virtual CatalogedContact Convert() {
        var result = new CatalogedContact() {
            Key = Udf.Nonce()
            };
        Fill();
        return result;
        }

    public static BoundContactPerson Convert(CatalogedContact input) {
        var contact = input.Contact as ContactPerson;

        if (contact == null) {
            return null!; // should never happen
            }

        var name = contact.CommonNames?.FirstOrDefault();

        if (name is not null) {
            name.SetFullName();
            return new BoundContactPerson() {
                FullName = name.FullName,
                First = name.First,
                Last = name.Last,
                Prefix = name.Prefix,
                Suffix = name.Suffix,
                NetworkAddresses = Bind(contact.NetworkAddresses)
                };
            }

        var address = contact.NetworkAddresses?.FirstOrDefault();
        return  new BoundContactPerson() {
            Local = address?.Address,
            NetworkAddresses = Bind(contact.NetworkAddresses)
            };

        }



    public static ISelectList Bind(IEnumerable<NetworkAddress>? input) {
        if (input == null) { 
            return null!; 
            }

        var result = new SelectList();

        foreach (var inputItem in input) {
            var entry =  ContactNetworkAddress.Factory(inputItem) ;
            result.Add(entry);
            }


        return result;



        }


    public virtual void Fill() {
        var bound = Bound as CatalogedContact;

        var personName = new PersonName() {
            FullName = Display,
            Prefix = Prefix,
            Suffix = Suffix,
            First = First,
            Last = Last
            };

        var addresses = FillNetworkAddress(NetworkAddresses);
        var locations = FillLocations(PhysicalAddresses);

        var contact = new ContactPerson() {
            CommonNames = new List<PersonName>() { personName },
            NetworkAddresses = addresses,
            Locations = locations
            };

        bound.Contact = contact;
        }


    List<NetworkAddress> FillNetworkAddress(ISelectList? addresses) {
        if (addresses == null) { 
            return null!; 
            }

        var result = new List<NetworkAddress>();

        foreach (var entry in addresses.Entries) {
            var address = entry as ContactNetworkAddress;
            // here we have to do the transmogrification.
            address.Fill();
            result.Add(address.NetworkAddress);

            }

        return result;

        }

    List<Location> FillLocations(ISelectList? locations) {
        if (locations == null) {
            return null!;
            }

        var result = new List<Location>();

        foreach (var entry in locations.Entries) {
            var address = entry as ContactPhysicalAddress;
            address.Fill();
            result.Add(address.Bound as Location);
            // here we have to do the transmogrification.

            }

        return result;


        }
    }




#endregion




#region // Binding to classes specified in the Mesh schema

/// <summary>
/// Extends <see cref="CatalogContact"/> to override the <see cref="Intern"/> method
/// so as to allow the bound selection boxes to be updated.
/// </summary>
public class GuigenCatalogContact : CatalogContact {

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
                IMeshClient? meshClient = null,
                DarePolicy? policy = null,
                CryptoParameters? cryptoParameters = null,
                IKeyCollection? keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[]? bitmask = null) =>
        new GuigenCatalogContact(directory, storeId, policy, cryptoParameters, keyCollection,
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
    public GuigenCatalogContact(
                string directory,
                string? storeName = null,
                DarePolicy? policy = null,
                CryptoParameters? cryptoParameters = null,
                IKeyCollection? keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[]? bitmask = null) :
        base(directory, storeName ?? Label,
                    policy, cryptoParameters, keyCollection,
                    decrypt: decrypt, create: create, bitmask: bitmask) {
        }

    public override void Intern(SequenceIndexEntry indexEntry) {
        base.Intern(indexEntry);
        }



    }


#endregion


#region // Selection Catalog backing type.

public partial class ContactSelection : SelectionCatalog<GuigenCatalogContact,
            CatalogedContact, BoundContactPerson> {


    static PersonName Default = new PersonName() {
        First = "Unspecified",
        Last = "Contact"
        };


    /// <summary>
    /// Constructor returning an instance of the selection data backer bound to the 
    /// catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog"></param>
    public ContactSelection(ContextAccount contextAccount,
                GuigenCatalogContact catalog) : base(contextAccount,catalog) {
        }

    #region // Conversion overrides
    //public override CatalogedContact CreateFromBindable(IBindable input) =>
    //        (input as BoundContactPerson)?.Convert();


    public override BoundContactPerson ConvertToBindable(CatalogedContact input) =>
        BoundContactPerson.Convert(input);

    public override CatalogedContact UpdateWithBindable(IBindable entry) {
        var binding = entry as BoundContactPerson;
        binding.Fill();
        return binding.Bound as CatalogedContact;
        }
    #endregion




    }

public partial class QrContact : IMessageable {

    public IResult MessageReceived() {
        throw new NYI();
        }

    public override IResult TearDown(Gui gui) {
        if (QrCode != null) {
            var everything = gui as EverythingMaui;
            everything.UnRegister(QrCode);
            }

        return NullResult.Teardown;
        }

    public override IResult Initialize(Gui gui) {
        var everything = gui as EverythingMaui;
        QrCode = everything.GetQrContact(this);

        return NullResult.Initialized;
        }

    }


#endregion







