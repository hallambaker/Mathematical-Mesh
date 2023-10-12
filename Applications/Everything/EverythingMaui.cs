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

        var accounts = new AccountSection(contextUser);
        SectionAccount.Data = accounts;


        SectionMessages.BindData = () => accounts.MessageSection;
        SectionContactsSection.BindData = () => accounts.Contacts;
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





public partial class AccountSection {
    public ContextUser ContextUser { get; }

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


    public override string ServiceAddress => ContextUser?.ServiceAddress;

    public override string ProfileUdf => ContextUser?.Profile.UdfString;

    public override string LocalAddress => ContextUser?.CatalogedMachine.Local;


    public AccountSection(ContextUser contextUser) {
        ContextUser = contextUser;

        ContextUser.DictionaryCatalogDelegates.Replace(CatalogContact.Label, GuigenCatalogContact.Factory);
        ContextUser.DictionaryCatalogDelegates.Replace(CatalogDocument.Label, GuigenCatalogApplication.Factory);
        // Feeds is a subset of Bookmarks
        // Groups is a subset of Application
        ContextUser.DictionaryCatalogDelegates.Replace(CatalogCredential.Label, GuigenCatalogCredential.Factory);
        ContextUser.DictionaryCatalogDelegates.Replace(CatalogTask.Label, GuigenCatalogTasks.Factory);
        // Calendar is just a different presentation for tasks
        ContextUser.DictionaryCatalogDelegates.Replace(CatalogBookmark.Label, GuigenCatalogBookmark.Factory);
        ContextUser.DictionaryCatalogDelegates.Replace(CatalogApplication.Label, GuigenCatalogApplication.Factory);
        ContextUser.DictionaryCatalogDelegates.Replace(CatalogDevice.Label, GuigenCatalogDevice.Factory);
        // Services is a subset of Application

        }
    }








public partial class Settings {


    public Settings() {

        }

    }



