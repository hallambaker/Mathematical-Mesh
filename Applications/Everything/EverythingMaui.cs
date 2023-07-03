using Everything.Resources;

using System.Resources;

namespace Goedel.Everything;
public partial class EverythingMaui {
    ResourceManager ResourceManager;


    public IMeshMachineClient MeshMachine;
    public MeshHost MeshHost => MeshMachine.MeshHost;


    public ContextUser ContextUser { get; set; }

    public Settings Settings { get; } = new();

    public EverythingMaui() {
        ResourceManager = Sketch_resources.ResourceManager;

        MeshMachine = new MeshMachineCore();

        

        SectionSettings.Data = Settings;
        SetContext(MeshHost.GetContext(MeshHost.DefaultAccount) as ContextUser);

        }


    public void SetContext(ContextUser contextUser) {
        ContextUser = contextUser;

        var accounts = new Account(contextUser);

        SectionAccounts.Data = accounts;


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





    public override string ServiceAddress => ContextUser.ServiceAddress;

    public override string ProfileUDF => ContextUser.Profile.UdfString;

    public override string LocalAddress => ContextUser.CatalogedMachine.Local;


    public Account(ContextUser contextUser) {
        ContextUser = contextUser;
        }
    }


public partial class Messages {

    Account Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public Messages(Account account) {
        Account = account;
        UrgentMessage = null;
        ContactRequests = null;
        OtherMessage = null;
        }

    }

public partial class Contacts {

    Account Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public Contacts(Account account) {
        Account = account;
        ChooseSelf = null;
        ContactMessage = null;
        ChooseOther = null;
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

        ChooseCredential = new CatalogSelector(ContextUser.GetStore(CatalogCredential.Label));
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

        ChooseDevice = new CatalogSelector(ContextUser.GetStore(CatalogDevice.Label));
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



