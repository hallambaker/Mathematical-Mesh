using Everything.Resources;

using Goedel.Cryptography.Dare;
using Goedel.Mesh.Client;

using Microsoft.Maui.Controls;

using System.Net.NetworkInformation;
using System.Resources;

namespace Goedel.Everything;



// Focus: 001 Add name to create widget
// Focus: 002 Put name in contact list properly
// Focus: 003 Switch account context on create account
// Focus: 004 Enumerate accounts to display selector
// Focus: 005 Add to enumeration of accounts on create account.




// Focus: 003 Delete entry on device dialog
// Focus: 004 Update button on device dialog
// Focus: 005 Read only fields
// Focus: 006 Fill in platform field in create account
// Focus: 007 Rights field in device dialog
// Focus: 020 Implement camera on QR
// Focus: 021 Implement Confirmation transaction
// Focus: 022 Implement Contact request transaction
// Focus: 023 Implement Device connect transaction
// Focus: 030 Upload document
// Focus: 031 Send mail message
// Focus: 032 Send Mail attachment
// Focus: 033 Application SSH 
// Focus: 034 Application SMTP
// Focus: 035 Application Developer
// Focus: 036 Comment feed
// Focus: 036 Annotation feed
// Focus: 040 Rights
// Focus: 041 Message polling
// Focus: 042 Presence push
// Focus: 043 Chat
// Focus: 044 WebRTC voice/video
// Focus: 050 Windows
// Focus: 051 macOS
// Focus: 052 iOs
// Focus: 053 Android


// List entries
// ToDo: Clean up display of list items. Use four cornered presentation
// ToDo: Fix ListBox scroll bars
// ToDo: Validate inputs to list box add before adding
// ToDo: Filter enumerated results to entries of a particular type

// ToDo: Password / Contact / Bookmark / etc. - create useful display format
// ToDo: Copy Uid etc into restored cataloged object on copy.



public partial class EverythingMaui {
    ResourceManager ResourceManager;


    public override bool StateDefault => ContextUser != null;



    public IMeshMachineClient MeshMachine;
    public MeshHost MeshHost => MeshMachine?.MeshHost;


    public ContextUser ContextUser => CurrentAccount.ContextUser;

    public SettingSection Settings { get; } = new();

    public Dictionary<string, IMessageable> WaitingOnMessage { get; } = new();


    public ObservableCollection<IBindable> BoundAccounts { get; } = new();

    public BoundAccount CurrentAccount = null;
    AccountSection AccountSection { get; }

    public ISelectCollection ChooseUser { get; }


    public EverythingMaui() {
        ResourceManager = Sketch_resources.ResourceManager;

        MeshMachine = new MeshMachineCore();
        //MeshHost.ConfigureMesh("alice@example.com", "null");
        
        //var accounts = new AccountSection(null);
        //accounts
        foreach (var entry in MeshHost.ObjectIndex) {
            var catalogedMachine = entry.Value.JsonObject as CatalogedMachine;
            switch (catalogedMachine) {
                case CatalogedStandard standardEntry: {
                    var bound = GetContextUser(standardEntry);
                    BoundAccounts.Add(bound);

                    CurrentAccount ??= bound;
                    break;
                    }
                }
            }

        AccountSection = new AccountSection(this);
        ChooseUser = new AccountSelection(this);
        SectionAccountSection.Data = AccountSection;

        SectionSettingSection.Data = Settings;
        //SetContext(MeshHost.GetContext(MeshHost.DefaultAccount) as ContextUser);
        SetContext(CurrentAccount);
        }


    BoundAccount GetContextUser(CatalogedStandard catalogedStandard ) {
        var contextUser = MeshHost.GetContext(catalogedStandard) as ContextUser;

        contextUser.DictionaryCatalogDelegates.Replace(CatalogContact.Label, GuigenCatalogContact.Factory);
        contextUser.DictionaryCatalogDelegates.Replace(CatalogDocument.Label, GuigenCatalogApplication.Factory);
        // Feeds is a subset of Bookmarks
        // Groups is a subset of Application
        contextUser.DictionaryCatalogDelegates.Replace(CatalogCredential.Label, GuigenCatalogCredential.Factory);
        contextUser.DictionaryCatalogDelegates.Replace(CatalogTask.Label, GuigenCatalogTasks.Factory);
        // Calendar is just a different presentation for tasks
        contextUser.DictionaryCatalogDelegates.Replace(CatalogBookmark.Label, GuigenCatalogBookmark.Factory);
        contextUser.DictionaryCatalogDelegates.Replace(CatalogApplication.Label, GuigenCatalogApplication.Factory);
        contextUser.DictionaryCatalogDelegates.Replace(CatalogDevice.Label, GuigenCatalogDevice.Factory);
        // Services is a subset of Application
        contextUser.DictionarySpoolDelegates.Replace(SpoolInbound.Label, GuigenSpoolInbound.Factory);
        contextUser.DictionarySpoolDelegates.Replace(SpoolOutbound.Label, GuigenSpoolOutbound.Factory);
        contextUser.DictionarySpoolDelegates.Replace(SpoolLocal.Label, GuigenSpoolLocal.Factory);

        return new BoundAccount(contextUser);
        }



    public void SetDefaultAccount() {
        CurrentAccount = null;
        }


    public void SetContext(BoundAccount boundAccount) {

        CurrentAccount = boundAccount;


        SectionMessageSection.BindData = () => CurrentAccount.MessageSection;
        SectionContactSection.BindData = () => CurrentAccount.Contacts;
        SectionBookmarkSection.BindData = () => CurrentAccount.Bookmarks;
        SectionDocumentSection.BindData = () => CurrentAccount.Documents;
        SectionGroupSection.BindData = () => CurrentAccount.Groups;
        SectionFeedSection.BindData = () => CurrentAccount.Feeds;
        SectionCredentialSection.BindData = () => CurrentAccount.Credentials;
        SectionTaskSection.BindData = () => CurrentAccount.Tasks;
        SectionCalendarSection.BindData = () => CurrentAccount.Calendar;
        SectionApplicationSection.BindData = () => CurrentAccount.Applications;
        SectionDeviceSection.BindData = () => CurrentAccount.Devices;
        SectionServiceSection.BindData = () => CurrentAccount.Services;

        }



    public override string GetPrompt(GuiPrompt guiPrompt) {

        return ResourceManager.GetString(guiPrompt.Id);


        }

    //public static Dictionary<Type, GuiBinding> BindingDictionary = new() {
    //        { typeof(CatalogedCredential), BindingCatalogedCredential }
    //    };

    //public static GuiBinding GetBinding(object data) {
    //    if (BindingDictionary.TryGetValue(data.GetType(), out var binding)) return binding;

    //    throw new NotImplementedException();
    //    }

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

    public bool UnRegister(GuiQR guiQR) {
        if (WaitingOnMessage.ContainsKey(guiQR.Identifier)) {
            WaitingOnMessage.Remove(guiQR.Identifier);
            return true;
            }
        return false;
        }


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

    public DeviceDescription GetDeviceDescription() {


        var device = DeviceInfo.Current;
        // ToDo: Device specific grab of Model reaching into the registry to fetch "Baseboard Product" etc. on Windows


        var deviceDescription = new DeviceDescription() {
            Idiom = device.Idiom.AsToken(),
            Manufacturer = device.Manufacturer,
            Model = device.Model,
            Name = device.Name,
            Platform = device.Platform.AsToken(),
            Version = device.VersionString


            };

        return deviceDescription;
        }


    }











public partial class SettingsSection {


    public SettingsSection() {

        }

    }



