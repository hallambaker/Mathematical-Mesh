﻿
using Goedel.Cryptography.Dare;
using Goedel.Mesh.Client;

using System.Net.NetworkInformation;
using System.Resources;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Everything;




// Focus: 001 General callback async mechanism
//    Freeze the UI
//    Make the request asynchronously
//    Await the result
//    Process result [Home / Selection / Result value]
// Focus: 002 Bug - missing commit buttons
// Focus: 003 Actions on selected items

// Focus: 010 Delete Account
// Focus: 012 Device Request connect
// Focus: 013 Device Accept connect
// Focus: 014 Set default account
// Focus: 015 Recover account




public partial class EverythingMaui {
    ResourceManager ResourceManager;


    public override bool StateDefault => ContextUser != null;


    ///<summary>The Mesh Machine representation</summary> 
    public IMeshMachineClient MeshMachine;

    ///<summary>Catalog of accounts stored on the Mesh Machine</summary> 
    public MeshHost MeshHost => MeshMachine.MeshHost;

    ///<summary>The current account, null if the device is unbound.</summary> 
    public BoundAccount? CurrentAccount = null;

    ///<summary>The current account user context, null if the device is unbound.</summary> 
    public ContextUser? ContextUser => CurrentAccount?.ContextUser;

    ///<summary>The settings section.</summary> 
    public SettingSection Settings { get; } = new();

    ///<summary>Account bindings to the account contexts on the current machine.</summary> 
    public ObservableCollection<IBindable> BoundAccounts { get; } = [];

    public Dictionary<string, IMessageable> WaitingOnMessage { get; } = [];

    Task SyncTask { get; set; }


    AccountSection AccountSection { get; }

    public ISelectCollection ChooseUser { get; }
    Func<DeviceDescription> GetDeviceDescription { get; }

    public EverythingMaui(
                ResourceManager resourceManager,
                Func<DeviceDescription> getDeviceDescription
                ) {
        ResourceManager = resourceManager;
        GetDeviceDescription = getDeviceDescription;

        MeshMachine = new MeshMachineCore();
        //MeshHost.ConfigureMesh("alice@example.com", "null");

        //var accounts = new AccountSection(null);
        //accounts

        BoundAccount? currentAccount = null;
        foreach (var entry in MeshHost.ObjectIndex) {
            var catalogedMachine = entry.Value.JsonObject as CatalogedMachine;
            switch (catalogedMachine) {
                case CatalogedStandard standardEntry: {
                    var bound = GetBoundAccount(standardEntry);
                    currentAccount ??= bound;
                    break;
                    }
                }
            }

        AccountSection = new AccountSection() {
            EverythingMaui = this
            };

        ChooseUser = new AccountSelection(this);
        SectionAccountSection.Data = AccountSection;
        SectionSettingSection.Data = Settings;
        //SetContext(MeshHost.GetContext(MeshHost.DefaultAccount) as ContextUser);

        SetContext(currentAccount);
        }

    BoundAccount? GetBoundAccount(CatalogedStandard catalogedStandard) {
        var contextUser = MeshHost.GetContext(catalogedStandard) as ContextUser;
        if (contextUser == null) {
            return null;
            }

        return GetBoundAccount(contextUser);
        }
     BoundAccount GetBoundAccount(ContextUser contextUser) {
        //contextUser.StatusAsync().Sync();

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

        var bound = new BoundAccount(contextUser);

        BoundAccounts.Add(bound);
        //CurrentAccount ??= bound;

        return bound;
        }



    public void SetDefaultAccount() {
        CurrentAccount = null;
        }


    public void SetContext(BoundAccount? boundAccount) {
        if (CurrentAccount == boundAccount) {
            return;
            }
        if (CurrentAccount is not null) {
            CurrentAccount.Synchronize = false;
            }
        if (boundAccount is null) {
            return;
            }

        CurrentAccount = boundAccount;

        // Accounts and settings are always active or enabled
        SectionAccountSection.GetButton = () => ButtonStateUnconditional(SectionAccountSection);
        SectionSettingSection.GetButton = () => ButtonStateUnconditional(SectionSettingSection);

        // These sections only available if there is an account
        SectionMessageSection.Reset(() => CurrentAccount?.MessageSection,
                () => ButtonStateConditional(SectionMessageSection));

        SectionContactSection.Reset(() => CurrentAccount?.Contacts,
                () => ButtonStateConditional(SectionContactSection));

        SectionBookmarkSection.Reset(() => CurrentAccount?.Bookmarks,
                () => ButtonStateConditional(SectionBookmarkSection));

        SectionDocumentSection.Reset(() => CurrentAccount?.Documents,
                () => ButtonStateConditional(SectionDocumentSection));


        SectionGroupSection.Reset(() => CurrentAccount?.Groups,
                () => ButtonStateConditional(SectionGroupSection));

        SectionFeedSection.Reset(() => CurrentAccount?.Feeds,
                () => ButtonStateConditional(SectionFeedSection));

        SectionCredentialSection.Reset(() => CurrentAccount?.Credentials,
                () => ButtonStateConditional(SectionCredentialSection));

        SectionTaskSection.Reset(() => CurrentAccount?.Tasks,
                () => ButtonStateConditional(SectionTaskSection));


        SectionCalendarSection.Reset(() => CurrentAccount?.Calendar,
                () => ButtonStateConditional(SectionCalendarSection));

        SectionApplicationSection.Reset(() => CurrentAccount?.Applications,
                () => ButtonStateConditional(SectionApplicationSection));

        SectionDeviceSection.Reset(() => CurrentAccount?.Devices,
                () => ButtonStateConditional(SectionDeviceSection));

        SectionServiceSection.Reset(() => CurrentAccount?.Services,
                () => ButtonStateConditional(SectionServiceSection));

        boundAccount.Synchronize = true;
        SyncTask = boundAccount.StartSync();

        }

    ButtonState ButtonStateUnconditional (GuiSection section) =>
        CurrentSection == section ? ButtonState.Selected : ButtonState.Enabled;

    ButtonState ButtonStateConditional(GuiSection section) =>
        CurrentSection == section ? ButtonState.Selected : 
            (CurrentAccount is null ? ButtonState.Disabled : ButtonState.Enabled);


    public override string? GetPrompt(GuiPrompt guiPrompt) {

        return ResourceManager.GetString(guiPrompt.Id);


        }



    Task<IResult> TaskResult(IResult result) => Task.FromResult<IResult>(result);


    T? GetIndexOrNull<T>(T[] array, int index) =>
        index < array.Length ? array[index] : default(T);



    public GuiQR? GetQrContact(IMessageable source) {
        if (ContextUser == null) {
            return null;
            }
        var combinedKey = new CryptoKeySymmetricSigner();
        var pin = combinedKey.SecretKey;

        var qr = MeshUri.ConnectUriUser(ContextUser.ServiceAddress, pin);


        return Register(pin, qr, source);

        }

    public GuiQR? GetQrDevice(IMessageable source) {
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


    ////public string GetDeviceConnect() {
    ////    }

    //public DeviceDescription GetDeviceDescription() {


    //    var device = DeviceInfo.Current;
    //    // ToDo: Device specific grab of Model reaching into the registry to fetch "Baseboard Product" etc. on Windows


    //    var deviceDescription = new DeviceDescription() {
    //        Idiom = device.Idiom.AsToken(),
    //        Manufacturer = device.Manufacturer,
    //        Model = device.Model,
    //        Name = device.Name,
    //        Platform = device.Platform.AsToken(),
    //        Version = device.VersionString


    //        };

    //    return deviceDescription;
    //    }

    /// <summary>
    /// Attempt to create a canned response for an exception of type <paramref name="exception"/>
    /// thrown by initial input <paramref name="parameters"/>.
    /// </summary>
    /// <param name="exception">The exception to respong to</param>
    /// <param name="parameters">The parameters.</param>
    /// <param name="result">The generated result.</param>
    /// <returns></returns>
    public bool TryProcessException(Exception exception, IParameter parameters, out IResult? result) {

        switch (exception) {
            case HttpRequestException httpRequestException: {
                if (exception.InnerException is System.Net.Sockets.SocketException) {
                    var data = parameters as IServiceAddress;
                    result = new ServiceNotFound() {
                        ServiceName = data.ServiceAddress
                        };
                    return true;
                    }
                else {
                    result = new HttpRequestFail();
                    return true;
                    }

                }
            }
        if (ExceptionDirectory.TryGetValue(exception.GetType().FullName, out var factory)) {
            result = factory();
            return true;
            }

        result = null;
        return false;
        }


    public IResult ProcessException(Exception exception, IParameter parameters) {
        if (TryProcessException(exception, parameters, out var result)) {
            // The value result is never null if TryProcessException returned true.
            return result!;
            }
        return new ErrorResult(exception);
        }

    }



public interface IServiceAddress {

    ///<summary></summary> 
    public string ServiceAddress { get; }
    }

public partial class TestService : IServiceAddress {
    }

public partial class AccountCreate : IServiceAddress {
    }





