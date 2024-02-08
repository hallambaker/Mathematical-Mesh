using Goedel.Cryptography.Dare;

using System.Collections;
using System.Collections.Specialized;



namespace Goedel.Everything;

public interface IAccountSelector {
    public ContextUser ContextUser { get; }
    }


public partial class AccountSwitch :  IHeadedSelection {

    ///<inheritdoc/>
    public GuiBinding SelectionBinding => _BoundAccount.BaseBinding;
    public override IResult Initialize(Gui gui) {
        var everythingMaui = gui as EverythingMaui;
        ChooseUser = everythingMaui.ChooseUser;

        return NullResult.Initialized;
        }

    }

public partial class AccountSection: IAccountSelector {

    public ContextUser ContextUser => BoundAccount.ContextUser;
    public BoundAccount BoundAccount => EverythingMaui.CurrentAccount;

    public EverythingMaui EverythingMaui { get;  init; }

    public override string ServiceAddress => ContextUser?.ServiceAddress;

    public override string ProfileUdf => ContextUser?.Profile.UdfString;

    public override string LocalAddress => ContextUser?.CatalogedMachine.Local;



    }






#region // Bindings to classes specified through the Guigen schema.


public partial class BoundAccount : IBoundPresentation, IDialog, IAccountSelector {


    public ContextUser ContextUser  { get; }

    #region // Set Contexts

    ///<summary>The messages section context.</summary> 
    public MessageSection MessageSection => messages ?? new MessageSection(this).CacheValue(out messages);
    MessageSection messages;

    ///<summary>The contacts section context.</summary> 
    public ContactSection Contacts => contacts ?? new ContactSection(this).CacheValue(out contacts);
    ContactSection contacts;

    ///<summary>The documents section context.</summary> 
    public DocumentSection Documents => documents ?? new DocumentSection(this).CacheValue(out documents);
    DocumentSection documents;

    ///<summary>The feeds section context.</summary> 
    public FeedSection Feeds => feeds ?? new FeedSection(this).CacheValue(out feeds);
    FeedSection feeds;

    ///<summary>The groups section context.</summary> 
    public GroupSection Groups => groups ?? new GroupSection(this).CacheValue(out groups);
    GroupSection groups;

    ///<summary>The credentials section context.</summary> 
    public CredentialSection Credentials => credentials ?? new CredentialSection(this).CacheValue(out credentials);
    CredentialSection credentials;

    ///<summary>The tasks section context.</summary> 
    public TaskSection Tasks => tasks ?? new TaskSection(this).CacheValue(out tasks);
    TaskSection tasks;

    ///<summary>The calendar section context.</summary> 
    public CalendarSection Calendar => calendar ?? new CalendarSection(this).CacheValue(out calendar);
    CalendarSection calendar;

    ///<summary>The applications section context.</summary> 
    public BookmarkSection Bookmarks => bookmark ?? new BookmarkSection(this).CacheValue(out bookmark);
    BookmarkSection bookmark;

    ///<summary>The applications section context.</summary> 
    public ApplicationSection Applications => applications ?? new ApplicationSection(this).CacheValue(out applications);
    ApplicationSection applications;

    ///<summary>The devices section context.</summary> 
    public DeviceSection Devices => devices ?? new DeviceSection(this).CacheValue(out devices);
    DeviceSection devices;

    ///<summary>The services section context.</summary> 
    public ServiceSection Services => services ?? new ServiceSection(this).CacheValue(out services);
    ServiceSection services;

    #endregion





    public override string Display => ContextUser?.CatalogedMachine.Local;

    public override string Service => ContextUser?.ServiceAddress;

    public override string UDF => ContextUser?.Profile.UdfString;

    public GuiDialog Dialog(Gui gui) => (gui as EverythingMaui).DialogBoundAccount;




    public BoundAccount(ContextUser contextUser =null) {
        ContextUser = contextUser;
        }


    }

#endregion

#region // Selection Catalog backing type.

// ToDo: move this to store / enumerate the Context User entries...
public partial class AccountSelection : ISelectCollection {
    
    EverythingMaui EverythingMaui;
    public ObservableCollection<IBindable> Entries => EverythingMaui.BoundAccounts;



    /// <summary>
    /// Constructor returning an instance of the selection data backer bound to the 
    /// catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog"></param>
    public AccountSelection(EverythingMaui everythingMaui)  {
        EverythingMaui = everythingMaui;
        }

    public void Add(IBoundPresentation item) {
        throw new NotImplementedException();
        }

    public void Remove(IBoundPresentation item) {
        throw new NotImplementedException();
        }

    public void Update(IBoundPresentation item) {
        throw new NotImplementedException();
        }

    public IEnumerator GetEnumerator() {
        throw new NotImplementedException();
        }

    #region // Conversion overrides



    #endregion
    }


#endregion