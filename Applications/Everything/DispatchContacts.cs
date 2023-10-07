using Goedel.Cryptography.Dare;

using System.Collections;
using System.Collections.Specialized;

using Contact = Goedel.Mesh.Contact;

namespace Goedel.Everything;


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
                IMeshClient meshClient = null,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) =>
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

    }


public partial class Contacts {

    Account Account { get; }
    ContextUser ContextUser => Account.ContextUser;



    public Contacts(Account account) {
        Account = account;

        ContextUser.DictionaryCatalogDelegates.Replace(CatalogContact.Label, GuigenCatalogContact.Factory);


        var catalog = ContextUser.GetStore(CatalogContact.Label, create:false) as GuigenCatalogContact;
        ChooseContact = new ContactSelection(catalog);

        //ChooseSelf = null;
        //ContactMessage = null;
        //ChooseOther = null;
        }

    }


public abstract class Selection<T> : ISelectCollection 
                    where T : Store{

    public T Store { get; }

    public ObservableCollection<object> Entries { get; } = new();


    public Selection(T store) {
        Store = store;
        }


    public abstract IEnumerator GetEnumerator();


    public virtual void Add(IBindable item) { 
        }

    public virtual void Remove(IBindable item) { }
    }

public partial class BoundContactPerson : ISelectSummary {

    public override string Display => (First ?? "") + " " + (Last ?? "");

    public string? LabelValue => Display;

    public string? IconValue => "account.png";


    }


public partial class ContactSelection : Selection<GuigenCatalogContact>, INotifyCollectionChanged {

    GuigenCatalogContact CatalogContact => Store;



    ///<summary>Specify the entry dialog</summary> 
    //public GuiBinding EntryDialog => _BoundContactPerson.BaseBinding;

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    ///<summary>Factory method</summary> 
    //public IBindable Factory() => new BindingBoundContactPerson();

    ///<summary>Type check</summary> 
    public bool IsType (object data) => data is CatalogedContact;

    ///<summary>Convert the Gui contact form to a cataloged contact</summary> 
    public CatalogedContact ConvertFromDialog (IBindable contact) => throw new NYI();

    ///<summary>Convert the Gui contact form to a cataloged contact</summary> 
    public IBindable ConvertToDialog(CatalogedContact cataloged) => throw new NYI();

    ///<summary>Return an enumerator</summary>
    ///<param name="filter">Optional filter.</param>
    public IEnumerator GetEnumerator(string filter = null) => Entries.GetEnumerator();




    public ContactSelection(GuigenCatalogContact contacts) : base (contacts){

        }


    CatalogedContact Make(string name) => new CatalogedContact {
        Contact = new Goedel.Mesh.ContactPerson() {
            Local = name
            }
        };


    public override void Add(IBindable item) {

        var contact = Convert(item);
        CatalogContact.Add(contact);

        Entries.Add(item);

        }

    public Contact Convert(IBindable contact) {
        switch (contact) {
            case BoundContactPerson boundContactPerson:
            return Convert(boundContactPerson);
            }
        return null;
        }

    public Contact Convert(BoundContactPerson input) {

        var personName = new PersonName() {
            FullName = input.Display,
            Prefix = input.Prefix,
            Suffix = input.Suffix,
            First = input.First,
            Last = input.Last
            };


        var result = new ContactPerson() {
            CommonNames = new List<PersonName>() { personName },
            NetworkAddresses = new()
            };

        // should add in a second listbox for additional names.

        return result;
        }


    public override IEnumerator GetEnumerator() => Entries.GetEnumerator();
    }


public abstract class BoundEntry<T> {

    public T Value { get; }


    public GuiBinding SummaryBinding { get; }


    }

public class BoundContact {

    public CatalogedContact CatalogedContact;

    public Mesh.Contact? Contact => CatalogedContact?.Contact;
    public string? FullName { get; set; }

    public BoundContact(CatalogedContact catalogedContact) {
        CatalogedContact = catalogedContact;
        FullName = Contact?.Local;


        }
    }