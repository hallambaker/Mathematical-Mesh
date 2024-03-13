using Goedel.Cryptography.Dare;

using System.Collections;
using System.Threading;

namespace Goedel.Everything;
#region // Bindings to classes specified through the Guigen schema.

public partial class ContactSection : IHeadedSelection{

    IAccountSelector? Account { get; }
    ContextUser? ContextUser => Account?.ContextUser;


    //public ButtonState ButtonState => Account is null ? ButtonState.Disabled : ButtonState.Enabled;

    public ContactSelection? ContactSelection { get; }

    GuigenCatalogContact? Catalog { get; }

    ///<inheritdoc/>
    public override ISelectCollection ChooseContact { get => ContactSelection; set { } }

    ///<inheritdoc/>
    public GuiBinding SelectionBinding => _BoundContact.BaseBinding;

    /// <summary>
    /// Return an instance bound to the Contacts catalog of the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account whose contacts are to be used.</param>
    public ContactSection(IAccountSelector? account = null) {
        Account = account;
        Catalog = ContextUser.GetStore(CatalogContact.Label, create: false) as GuigenCatalogContact;
        ContactSelection = Catalog is null ? null : new ContactSelection(Catalog);
        }

    public async Task AddAsync(CatalogedContact entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry);
        await transaction.TransactAsync();

        var bound = BoundContact.Factory(entry);
        ContactSelection.Add(bound);
        }


    public async Task UpdateAsync(BoundContact entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry.CatalogedContact);
        await transaction.TransactAsync();

        ContactSelection.Update(entry);
        }


    public async Task DeleteAsync(BoundContact entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry.CatalogedContact);
        await transaction.TransactAsync();

        ContactSelection.Remove(entry);
        }

    }
#endregion
#region // Bindings to classes specified through the Guigen schema.


public partial class ContactNetworkAddress : IBoundPresentation {

    public ContactNetworkAddress () { }
    public ContactNetworkAddress(NetworkAddress address) {
        Bound = address;
        Protocol = "TBS";
        Address = address.Address;
        Fingerprint = null;
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



    public static ISelectCollection Bind(IEnumerable<NetworkAddress>? input) {
        if (input == null) { 
            return null!; 
            }

        var result = new SelectList();

        foreach (var inputItem in input) {
            var entry = new ContactNetworkAddress(inputItem) ;
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

        var contact = new ContactPerson() {
            CommonNames = new List<PersonName>() { personName },
            NetworkAddresses = new()
            };

        bound.Contact = contact;
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
    public ContactSelection(GuigenCatalogContact catalog) : base(catalog) {
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







