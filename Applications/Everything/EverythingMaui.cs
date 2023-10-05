using Everything.Resources;

using System.Resources;

namespace Goedel.Everything;



// ToDo: Suppress display of the Account if there is no account yet.

// ToDo: Test Service
// ToDo: Create Account - Basic implementation
// ToDo: Create Account - Account name rejected
// ToDo: Create account - Server not found
// ToDo: Create account - Timeout

// ToDo: Select different account

// ToDo: Connect via activation code
// ToDo: Display dynamic QR code on admin device
// ToDo: Scan static QR code on IoT device

// ToDo: List Connected Devices

// ToDo: Create default contact
// ToDo: Select contact
// ToDo: Remote contact exchange
// ToDo: QR code contact exchange

// ToDo: Set permissions for contact

// ToDo: Create Email credentials
// ToDo: Create Developer credentials

// ToDo: Confirmation challenge


// ToDo: Bookmarks
// ToDo: Credentials
// ToDo: Settings
// ToDo: Feeds

// ToDo: Documents
// ToDo: Document upload
// ToDo: Document download

// ToDo: Document annotation

// ToDo: File Viewer - image
// ToDo: File Viewer - video
// ToDo: File Viewer - sequence

// ToDo: Group create
// ToDo: Group list
// ToDo: Group add / delete members
// ToDo: Group accounting


// ToDo: Discussions - start
// ToDo: Discussions - list
// ToDo: Discussions - add user
// ToDo: Start voice
// ToDo: Start video

// ToDo: Server upload document
// ToDo: Server enroll signature in notary chain
// ToDo: Server maintain notary chain
// ToDo: Client create notary attestation chain
// ToDo: Client verify notary atestation chain.


public partial class EverythingMaui {
    ResourceManager ResourceManager;


    public override bool StateDefault => ContextUser!= null;



    public IMeshMachineClient MeshMachine;
    public MeshHost MeshHost => MeshMachine?.MeshHost;


    public ContextUser ContextUser { get; set; }

    public Settings Settings { get; } = new();

    public EverythingMaui() {
        ResourceManager = Sketch_resources.ResourceManager;

        MeshMachine = new MeshMachineCore();
        //MeshHost.ConfigureMesh("alice@example.com", "null");


        SectionSettings.Data = Settings;
        SetContext(MeshHost.GetContext(MeshHost.DefaultAccount) as ContextUser);

        }


    public void SetContext(ContextUser contextUser) {
        if (contextUser == null) {
            return;
            }

        ContextUser = contextUser;


        var accounts = new Account(contextUser);

        SectionAccount.Data = accounts;


        SectionMessages.BindData = () => accounts.Messages;
        SectionContacts.BindData = () => accounts.Contacts;
        SectionDocuments.BindData = () => accounts.Documents;
        SectionGroups.BindData = () => accounts.Groups;
        SectionFeeds.BindData = () => accounts.Feeds;
        SectionCredentials.BindData = () => accounts.Credentials;
        SectionTasks.BindData = () => accounts.Tasks;
        SectionCalendar.BindData = () => accounts.Calendar;
        SectionApplications.BindData = () => accounts.Applications;
        SectionDevices.BindData = () => accounts.Devices;
        SectionServices.BindData = () => accounts.Services;


        }



    public override string GetPrompt(GuiPrompt guiPrompt) {

        return ResourceManager.GetString(guiPrompt.Id);


        }

    public static Dictionary<Type, GuiBinding> BindingDictionary = new() {
            { typeof(CatalogedCredential), BindingCatalogedCredential }
        };

    public static GuiBinding GetBinding(object data) {
        if (BindingDictionary.TryGetValue(data.GetType(), out var binding)) return binding;

        throw new NotImplementedException();
        }

    Task<IResult> TaskResult (IResult result) => Task.FromResult<IResult>(result);


    T? GetIndexOrNull<T>(T[] array, int index) =>
        index < array.Length ? array[index] : default(T);

    }





public partial class Account {
    public ContextUser ContextUser { get; }


    public Messages Messages => messages ?? new Messages(this).CacheValue(out messages);
    Messages messages;

    public Contacts Contacts => contacts ?? new Contacts(this).CacheValue(out contacts);
    Contacts contacts;
    public Documents Documents => documents ?? new Documents(this).CacheValue(out documents);
    Documents documents;
    public Groups Groups => groups ?? new Groups(this).CacheValue(out groups);
    Groups groups;
    public Feeds Feeds => feeds ?? new Feeds(this).CacheValue(out feeds);
    Feeds feeds;
    public Credentials Credentials => credentials ?? new Credentials(this).CacheValue(out credentials);
    Credentials credentials;
    public Tasks Tasks => tasks ?? new Tasks(this).CacheValue(out tasks);
    Tasks tasks;
    public Calendar Calendar => calendar ?? new Calendar(this).CacheValue(out calendar);
    Calendar calendar;
    public Applications Applications => applications ?? new Applications(this).CacheValue(out applications);
    Applications applications;
    public Devices Devices => devices ?? new Devices(this).CacheValue(out devices);
    Devices devices;
    public Services Services => services ?? new Services(this).CacheValue(out services);
    Services services;





    public override string ServiceAddress => ContextUser?.ServiceAddress;

    public override string ProfileUdf => ContextUser?.Profile.UdfString;

    public override string LocalAddress => ContextUser?.CatalogedMachine.Local;


    public Account(ContextUser contextUser) {
        ContextUser = contextUser;
        }
    }





public partial class Messages {

    Account Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public Messages(Account account) {
        Account = account;
        //UrgentMessage = null;
        //ContactRequests = null;
        //OtherMessage = null;
        }

    }


public partial class Documents {

    Account Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public Documents(Account account) {
        Account = account;
        ChooseDocuments = null;
        }

    }

public partial class Groups {

    Account Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public Groups(Account account) {
        Account = account;
        ChooseGroup = null;
        }

    }

public partial class Feeds {

    Account Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public Feeds(Account account) {
        Account = account;
        ChooseFeed = null;
        }

    }

public partial class Credentials {
    Account Account { get; }
    ContextUser ContextUser => Account.ContextUser;
    public Credentials(Account account) {
        Account = account;

        //ChooseCredential = new CatalogSelector(ContextUser.GetStore(CatalogCredential.Label));
        }

    }

public partial class Tasks {

    Account Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public Tasks(Account account) {
        Account = account;
        ChooseTask = null;
        }

    }

public partial class Calendar {

    Account Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public Calendar(Account account) {
        Account = account;
        ChooseAppointment = null;
        }

    }

public partial class Applications {

    Account Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public Applications(Account account) {
        Account = account;

        ChooseApplication = null;
        }

    }

public partial class Devices {

    Account Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public Devices(Account account) {
        Account = account;

        //ChooseDevice = new CatalogSelector(ContextUser.GetStore(CatalogDevice.Label));
        }




    }

public partial class Services {

    Account Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public Services(Account account) {
        Account = account;
        ChooseService = null;
        }

    }

public partial class Settings {


    public Settings() {

        }

    }



