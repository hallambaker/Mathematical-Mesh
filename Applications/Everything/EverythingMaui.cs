using Everything.Resources;

using Goedel.Mesh.Client;

using System.Net.NetworkInformation;
using System.Resources;

namespace Goedel.Everything;

// List entries
// ToDo: Clean up display of list items. Use four cornered presentation
// ToDo: Fix ListBox scroll bars
// ToDo: Validate inputs to list box add before adding
// ToDo: Filter enumerated results to entries of a particular type

// Nit: Better icons for passwords/passkeys.

// ToDo: Password / Contact / Bookmark / etc. - create useful display format
// ToDo: Copy Uid etc into restored cataloged object on copy.



public partial class EverythingMaui {
    ResourceManager ResourceManager;


    public override bool StateDefault => ContextUser != null;



    public IMeshMachineClient MeshMachine;
    public MeshHost MeshHost => MeshMachine?.MeshHost;


    public ContextUser ContextUser { get; set; }

    public SettingSection Settings { get; } = new();

    public Dictionary<string, IMessageable> WaitingOnMessage { get; } = new();

    public EverythingMaui() {
        ResourceManager = Sketch_resources.ResourceManager;

        MeshMachine = new MeshMachineCore();
        //MeshHost.ConfigureMesh("alice@example.com", "null");


        SectionSettingSection.Data = Settings;
        SetContext(MeshHost.GetContext(MeshHost.DefaultAccount) as ContextUser);

        }


    public void SetContext(ContextUser contextUser) {
        if (contextUser == null) {
            return;
            }

        ContextUser = contextUser;

        var accounts = new AccountSection(contextUser);
        SectionAccountSection.Data = accounts;


        SectionMessageSection.BindData = () => accounts.MessageSection;
        SectionContactSection.BindData = () => accounts.Contacts;
        SectionBookmarkSection.BindData = () => accounts.Bookmarks;
        SectionDocumentSection.BindData = () => accounts.Documents;
        SectionGroupSection.BindData = () => accounts.Groups;
        SectionFeedSection.BindData = () => accounts.Feeds;
        SectionCredentialSection.BindData = () => accounts.Credentials;
        SectionTaskSection.BindData = () => accounts.Tasks;
        SectionCalendarSection.BindData = () => accounts.Calendar;
        SectionApplicationSection.BindData = () => accounts.Applications;
        SectionDeviceSection.BindData = () => accounts.Devices;
        SectionServiceSection.BindData = () => accounts.Services;

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

    Task<IResult> TaskResult(IResult result) => Task.FromResult<IResult>(result);


    T? GetIndexOrNull<T>(T[] array, int index) =>
        index < array.Length ? array[index] : default(T);



    public GuiQR GetQrContact(IMessageable source) {
        if (ContextUser == null) {
            return null;
            }
        var combinedKey = new CryptoKeySymmetricSigner();
        var pin = combinedKey.SecretKey;

        var qr = MeshUri.ConnectUriUser(ContextUser.ServiceAddress, pin);


        return Register(pin, qr, source);

        }

    public GuiQR GetQrDevice(IMessageable source) {
        if (ContextUser == null) {
            return null;
            }
        var combinedKey = new CryptoKeySymmetricSigner();
        var pin = combinedKey.SecretKey;

        return new GuiQR() {
            Offer = MeshUri.ConnectUriDevice(ContextUser.ServiceAddress, pin)
            };


        }

    GuiQR Register(string id, string qr, IMessageable source) {
        WaitingOnMessage.TryAdd(id, source);

        return new GuiQR() {
            Identifier = id,
            Offer = qr
            };
        }

    public bool UnRegister(GuiQR guiQR) =>  WaitingOnMessage.Remove(guiQR.Identifier);


    // need to have a continuous poll loop going and a mechanism to refresh the
    // output data if changed.

    // QR code thingies will be subscribed on the message spool, as will messages.

    // Most other stuff will be subscribed on the relevant catalog.
    public async Task<long> Poll (){

        // we would typically only need to poll on the inbound spool.
        // set up a delay and retry.
        // need a cancellation mechasnism as well.

        if (ContextUser == null) {
            return 0;
            }
        var x = await ContextUser.SynchronizeAsync();
        return x;
        }


    //public string GetDeviceConnect() {
    //    }



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








public partial class SettingsSection {


    public SettingsSection() {

        }

    }



