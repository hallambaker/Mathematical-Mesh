#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


using Goedel.Cryptography.Dare;
using Goedel.IO;
using Microsoft.Extensions.Logging;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;

namespace Goedel.Mesh.Client;

// This is the operation point to address merging the mesh and account profiles.


/// <summary>
/// Manages the host catalog, i.e. the catalog of Meshes that the device is 
/// connected to.
/// 
/// 
/// This should be merged with CatalogHost.
/// 
/// </summary>
public class MeshHost : Disposable {

    #region // fields and properties

    ///<summary>The Mesh machine client.</summary>
    public IMeshMachineClient MeshMachine;

    ///<summary>The Key Collection of the Mesh Machine.</summary>
    public IKeyCollection KeyCollection => MeshMachine.KeyCollection;


    ///<summary>The object index</summary> 
    protected Dictionary<string, StoreEntry> ObjectIndex = new();

    ///<summary>Dictionary mapping mesh UDF to Context.</summary>
    protected Dictionary<string, ContextAccount> DictionaryUDFContextMesh = new();

    ///<summary>Dictionary mapping mesh local name to Context.</summary>
    protected Dictionary<string, ContextAccount> DictionaryLocalContextMesh = new();

    ///<summary>The default context</summary> 
    public CatalogedStandard DefaultAccount=> defaultAccount;
    CatalogedStandard defaultAccount;
    ///<summary>The default context</summary> 
    public CatalogedService DefaultService => defaultService;
    CatalogedService defaultService;
    ///<summary>The default context</summary> 
    public CatalogedPending DefaultPending => defaultPending; 
    CatalogedPending defaultPending;
    ///<summary>The default context</summary> 
    public CatalogedPreconfigured DefaultPreconfigured => defaultPreconfigured;
    CatalogedPreconfigured defaultPreconfigured;
    static ILogger Logger => Component.Logger;

    //bool SuppressDispose { get; }  = false;


    string Filename { get; }


    //keyCollection ??
    //        new KeyCollectionClient(this, MeshMachine.KeyCollection).CacheValue(out keyCollection);
    //KeyCollection keyCollection;
    ///<summary>The IANA media type for the host file data.</summary>
    public const string FileTypeHost = "application/mmm-host";

    #endregion
    #region // Boilerplate for disposal etc.
    ///<summary>Disposal routine.</summary>
    protected override void Disposing() {
        //PersistHost.Dispose();
        foreach (var item in DictionaryLocalContextMesh) {
            item.Value.Dispose();
            }
        base.Disposing();
        }
    #endregion
    #region // Constructors and factories

    /// <summary>
    /// Constructor returning an instance that will read the hosts file 
    /// <paramref name="fileName"/>.
    /// </summary>
    /// <param name="fileName">The hosts file.</param>
    /// <param name="meshMachine">The machine binding.</param>
    public MeshHost(string fileName, IMeshMachineClient meshMachine) {
        MeshMachine = meshMachine;
        Filename = fileName;
        ReadHost();
        }


    void SetDefault<T>(ref T current, T update) where T: CatalogedMachine {
        if (update.Default) {
            current = update;
            }
        else {
            current ??= update;
            }
        
        }


    /// <summary>
    /// Read or re-read the hosts data.
    /// </summary>
    public void ReadHost() {

        var old = DictionaryUDFContextMesh;


        DictionaryUDFContextMesh = new();
        DictionaryLocalContextMesh = new();
        ObjectIndex = new();

        using var persistHost = new PersistHost(Filename, FileTypeHost,
            fileStatus: FileStatus.ConcurrentLocked,
            containerType: SequenceType.Merkle);

        Logger.ReloadHost();

        foreach (var entry in persistHost.ObjectIndex) {
            ObjectIndex.Add(entry.Key, entry.Value);

            var catalogedMachine = entry.Value.JsonObject as CatalogedMachine;
            SetDefaults(catalogedMachine);

            if (old.TryGetValue(catalogedMachine.Id, out var contextMesh)) {
                // Context was already loaded - reuse
                DictionaryUDFContextMesh.Add(catalogedMachine.Id, contextMesh);
                if (catalogedMachine.Local != null) {
                    DictionaryLocalContextMesh.AddSafe(catalogedMachine.Local, contextMesh);
                    }
                old.Remove(catalogedMachine.Id);
                }
            else {
                // add the new context
                GetContext(catalogedMachine);
                }
            }

        // Delete any deleted contexts
        foreach (var entry in old.Values) {
            entry.Dispose();
            }
        }

    /// <summary>
    /// Force disposal of all contexts and re-load the hosts file.
    /// </summary>
    public void ReloadContexts() {

        foreach (var entry in DictionaryUDFContextMesh.Values) {
            entry.Dispose();
            }
        ReadHost();

        }

    ///// <summary>
    ///// Get the host catalog from the specified mesh machine.
    ///// </summary>
    ///// <param name="meshMachine">The Mesh Machine.</param>
    ///// <param name="containerHost">The host catalog.</param>
    //public MeshHost(PersistHost containerHost, IMeshMachineClient meshMachine) {
    //    this.MeshMachine = meshMachine;
    //    this.PersistHost = containerHost;

    //    foreach (var entry in containerHost.ObjectIndex) {
    //        var catalogedMachine = entry.Value.JsonObject as CatalogedMachine;
    //        GetContext(catalogedMachine);
    //        }

    //    }

    /// <summary>
    /// Return a new MeshHost instance with the fields and properties of <paramref name="parent"/>
    /// but with the mesh machine <paramref name="meshMachine"/>. This is used during service
    /// creation to allow for operations such as creating an administration account.
    /// </summary>
    /// <param name="parent">The parent MeshHost instance.</param>
    /// <param name="meshMachine">The substitute MeshMachine.</param>
    public MeshHost(MeshHost parent, IMeshMachineClient meshMachine) {
        this.MeshMachine = meshMachine;
        //PersistHost = parent.PersistHost;
        DictionaryUDFContextMesh = parent.DictionaryUDFContextMesh;
        DictionaryLocalContextMesh = parent.DictionaryLocalContextMesh;
        //SuppressDispose = true;
        Filename = parent.Filename;
        }



    /// <summary>
    /// Create a context for the machine entry <paramref name="catalogedMachine"/>.
    /// </summary>
    /// <param name="catalogedMachine">The machine to create the context for.</param>
    /// <returns>The context created.</returns>
    public ContextAccount GetContext(CatalogedMachine catalogedMachine) {
        switch (catalogedMachine) {
            // consider adding a machine catalog entry for a group...
            case CatalogedStandard standardEntry: {
                    var context = new ContextUser(this, standardEntry);
                    Logger.HostCreateContext(context.Profile.Udf, context.AccountAddress);
                    Register(context);
                    return context;
                    }
            case CatalogedPending pendingEntry: {
                    var context = new ContextMeshPending(this, pendingEntry);
                    Logger.HostCreatePending(context.AccountAddress);
                    Register(context);
                    return context;
                    }
            default:
                return null;
            }
        }

    /// <summary>
    /// Get the host catalog from the specified mesh machine.
    /// </summary>
    /// <param name="meshMachine"></param>
    public static MeshHost GetCatalogHost(IMeshMachine meshMachine) {
        var meshMachineClient = meshMachine as IMeshMachineClient;
        return meshMachineClient?.MeshHost;

        }

    #endregion
    #region // Methods

    /// <summary>
    /// Get the store entry corresponding to key <paramref name="key"/> as the corresponding 
    /// <see cref="JsonObject"/>.
    /// </summary>
    /// <param name="key">The primary key of the object selected.</param>
    /// <returns>The object selected, if found, otherwise null.</returns>
    public JsonObject? GetStoreEntry(string key) {
        if (ObjectIndex.TryGetValue (key, out var storeEntry) ){
            return storeEntry.JsonObject;

            }
        return null;
        }
    void Register(ContextAccount contextMesh) {
        var machine = contextMesh.CatalogedMachine;
        DictionaryUDFContextMesh.Remove(machine.Id);
        DictionaryUDFContextMesh.Add(machine.Id, contextMesh);

        if (contextMesh.AccountAddress != null) {
            DictionaryLocalContextMesh.AddSafe(contextMesh.AccountAddress, contextMesh);
            }
        if (contextMesh.Profile != null) {
            DictionaryUDFContextMesh.AddSafe(contextMesh.Profile.Udf, contextMesh);
            }

        if (machine.Local != null) {
            DictionaryLocalContextMesh.AddSafe(machine.Local, contextMesh);
            }
        }

    /// <summary>
    /// Unregister the mesh <paramref name="contextMesh"/>.
    /// </summary>
    /// <param name="contextMesh">The mesh to be deleted.</param>
    public void Deregister(ContextAccount contextMesh) {
        var machine = contextMesh.CatalogedMachine;
        DictionaryUDFContextMesh.Remove(machine.Id);

        if (contextMesh.AccountAddress != null) {
            DictionaryLocalContextMesh.Remove(contextMesh.AccountAddress);
            }
        if (contextMesh.Profile != null) {
            DictionaryUDFContextMesh.Remove(contextMesh.Profile.Udf);
            }

        if (machine.Local != null) {
            DictionaryLocalContextMesh.Remove(machine.Local);
            }
        }


    /// <summary>
    /// Locate context by UDF or localname. The context acquired is owned by the MeshHost instance
    /// and MUST NOT be disposed of by the caller.
    /// </summary>
    /// <param name="key">The UDF or name to resolve.</param>
    /// <param name="useLocal">If true, match against UDF or local name. Otherwise
    /// match on UDF alone.</param>
    /// <returns>The context, if a matching context is found. Otherwise null.</returns>
    public ContextAccount LocateMesh(string key, bool useLocal = true) {
        key.AssertNotNull(MeshNotFound.Throw);


        if (DictionaryUDFContextMesh.TryGetValue(key, out var context)) {
            return context;
            }

        if (useLocal && DictionaryLocalContextMesh.TryGetValue(key, out context)) {
            return context;
            }

        return null;
        }

    void SetDefaults(CatalogedMachine catalogedMachine) {
        switch (catalogedMachine) {
            case CatalogedPending catalogedPending: {
                    Logger.HostCatalogedPending(catalogedMachine.Id[0..8],
                        catalogedPending.AccountAddress, catalogedMachine.Default);
                    SetDefault(ref defaultPending, catalogedPending);
                    break;
                    }
            case CatalogedPreconfigured catalogedPreconfigured: {
                    Logger.HostCatalogedPreconfigured(catalogedMachine.Id[0..8],
                        catalogedPreconfigured.AccountAddress, catalogedMachine.Default);
                    SetDefault(ref defaultPreconfigured, catalogedPreconfigured);
                    break;
                    }
            case CatalogedStandard catalogedStandard: {
                    Logger.HostCatalogedAccount(catalogedMachine.Id[0..8],
                        catalogedStandard.Local, catalogedMachine.Default);
                    SetDefault(ref defaultAccount, catalogedStandard);
                    break;
                    }
            case CatalogedService catalogedService: {
                    Logger.HostCatalogedService(catalogedMachine.Id[0..8],
                        catalogedService.Local, catalogedMachine.Default);
                    SetDefault(ref defaultService, catalogedService);
                    break;
                    }
            }
        }


    /// <summary>
    /// Register <paramref name="catalogItem"/> in the host catalog.
    /// </summary>
    /// <param name="catalogItem">The item to be created.</param>
    /// <param name="create">If true, a new item will be created if it does not
    /// already exist.</param>
    /// <param name="context">The dynamic context that interfaces to the catalog item.</param>
    public void Register(HostCatalogItem catalogItem, ContextAccount context = null, bool create = true) {
        using var persistHost = new PersistHost(Filename, FileTypeHost,
                fileStatus: FileStatus.ConcurrentLocked, containerType: SequenceType.Merkle);
        // persist the permanent record.
        var entry = persistHost.Update(catalogItem, create) as StoreEntry;
        var catalogedMachine = entry.JsonObject as CatalogedMachine;
        SetDefaults(catalogedMachine);

        if (ObjectIndex.ContainsKey(catalogItem._PrimaryKey)) {
            ObjectIndex.Remove(catalogItem._PrimaryKey);
            }
        ObjectIndex.Add(catalogItem._PrimaryKey, entry);
        if (context != null) {
            Register(context);
            }

        }


    /// <summary>
    /// Delete <paramref name="key"/> from the host catalog.
    /// </summary>
    /// <param name="key">The profile to delete</param>
    public virtual void Delete(string key) {
        using var persistHost = new PersistHost(Filename, FileTypeHost,
                fileStatus: FileStatus.ConcurrentLocked, containerType: SequenceType.Merkle);
        persistHost.Delete(key);
        ObjectIndex.Remove(key);
        }
    #endregion





    /// <summary>
    /// Create a new Mesh master profile and bind to a Mesh service at <paramref name="accountAddress"/>.
    /// </summary>
    ///<param name="accountAddress">Account address to bind to.</param>
    /// <param name="localName">Local name for easy reference.</param>
    /// <param name="accountSeed">Specifies the secret seed and algorithms used to generate private keys.</param>
    /// <param name="profileDevice">Specify the device profile. This allows use of a device 
    /// profile bound to the machine hardware.</param>
    /// <param name="rights">The rights to be granted to the initial connected device.</param>
    /// <param name="create">If true, create a new mesh, otherwise attempt recovery from the
    /// service.</param>
    /// <returns>Context for administering the Mesh</returns>
    public ContextUser ConfigureMesh(
            string accountAddress,
            string localName = null,
            PrivateKeyUDF accountSeed = null,
            ProfileDevice profileDevice = null,
            List<string> rights = null,
            bool create = true) {


        using var contextUser = InitializeAdminContext(accountAddress, localName,
            ref accountSeed, ref profileDevice, ref rights,
             out var _);


        

        if (create) {
            contextUser.SetService(accountAddress);
            contextUser.BindService(accountAddress);
            }
        else {

            // Here need to set the credential to use the profile auth key.



            contextUser.Sync();
            }
        contextUser.MakeAdministrator(rights);

        // Return to normal privilege.
        contextUser.MeshClient = null;

        //// Register the mesh description on the local machine.
        //Register(contextUser.CatalogedMachine, contextUser);

        var result = GetContext(contextUser.CatalogedMachine) as ContextUser;

        return result;
        }


    private ContextUser InitializeAdminContext(
                string accountAddress,
                string localName,
                ref PrivateKeyUDF commonSeed,
                ref ProfileDevice profileDevice,
                ref List<string> rights,

                out ActivationCommon activationCommon) {
        // Generate the initial seed for the account if not already specified.
        commonSeed ??= new PrivateKeyUDF(udfAlgorithmIdentifier: UdfAlgorithmIdentifier.MeshProfileAccount);

        // Generate a device profile if needed
        var persistDevice = profileDevice == null;
        profileDevice ??= ProfileDevice.Generate(
            algorithmSign: commonSeed.AlgorithmSignID,
            algorithmEncrypt: commonSeed.AlgorithmEncryptID,
            algorithmAuthenticate: commonSeed.AlgorithmAuthenticateID);

        Logger.CreateDevice(profileDevice.Udf, profileDevice.KeyAuthentication?.KeyIdentifier);
        Logger.DeviceSeed(profileDevice.SecretSeed.KeyId);

        // Check that the profile is valid before using it.
        profileDevice.Validate();

        // Create the set of cryptographic keys to initialize the account.
        // create the root activation.
        activationCommon = new ActivationCommon(KeyCollection, commonSeed) {
            DefaultActive = true

            };

        // create the initial profile
        var profileUser = new ProfileUser(accountAddress, activationCommon);
        Logger.CreateAccount(profileUser.Udf, profileUser.AccountAuthenticationKey?.KeyIdentifier);
        Logger.CommonSeed(commonSeed.KeyId);


        // Check that the profile is valid before using it.
        profileUser.Validate();

        // Create the account directory.
        ContextUser.CreateDirectory(this, profileUser, activationCommon, KeyCollection);


        rights ??= new List<string> {
                Rights.IdRolesSuper,
                Rights.IdRolesAdmin,
                Rights.IdRolesWeb
                };


        var activationAccount = new ActivationAccount(profileDevice);

        // create a Cataloged activationRoot.Device entry for the admin device
        var catalogedDevice = activationCommon.CreateCataloguedDevice(
                profileUser, profileDevice, activationAccount, activationCommon,
                activationCommon.AdministratorSignatureKey);




        // Create the host catalog entry and apply to the context user.
        var catalogedMachine = new CatalogedStandard() {
            Id = profileDevice.Udf,
            Local = localName,
            CatalogedDevice = catalogedDevice,
            EnvelopedProfileAccount = profileUser.GetEnvelopedProfileAccount()
            };

        //Persist the results.
        if (persistDevice) {
            profileDevice.PersistSeed(KeyCollection);
            }
        KeyCollection.Persist(profileUser.Udf, commonSeed, false);


        // Return a user context. It is necessary to ovewrite the activation records
        // because the cataloged device entry in catalogedMachine is not yet final. 
        return new ContextUser(this, catalogedMachine) {
            ActivationCommon = activationCommon,
            ActivationAccount = activationAccount
            };
        }







    /// <summary>
    /// Create a new management context for the specified Mesh profile.
    /// </summary>
    /// <param name="localName">The friendly name for the profile</param>
    /// <param name="admin">Enable administration privileges (if available).</param>
    /// <returns>Context for administering the Mesh</returns>
    public ContextAccount GetContextMesh(string localName = null, bool admin = true) {

        admin.Future();

        var key = localName ?? DefaultAccount?.Id;
        return key == null ? null : LocateMesh(key);
        }

    /// <summary>
    /// Attempt to complete the connection to a Mesh profile. If successful. update the local host persistence store
    /// and return a context for the newly acquired connection. Otherwise return null.
    /// </summary>
    /// <param name="localName"></param>
    /// <returns>Context for the newly bound account.</returns>
    public ContextUser Complete(
            string localName = null) {

        var machine = GetForCompletion(localName);

        switch (machine) {
            case CatalogedPending catalogedPending: {
                    var contextPending = LocateMesh(catalogedPending.Id) as ContextMeshPending;
                    return contextPending.Complete();
                    }
            case CatalogedPreconfigured catalogedPreconfigured: {
                    var contextPreconfigured = new ContextMeshPreconfigured(this, catalogedPreconfigured);
                    return contextPreconfigured.Complete();
                    }
            }
        return null;
        }

    /// <summary>
    /// Gets the machine waiting for completion that mactches <paramref name="localName"/> if
    /// specified, or the default pending machine otherwise or the default preconfigured
    /// machine if not found.
    /// </summary>
    /// <param name="localName">The machine to fetch.</param>
    /// <returns>The machine if found, otherwise null.</returns>
    public CatalogedMachine GetForCompletion(string localName = null) {
        if (localName != null) {
            foreach (var containerStoreEntry in ObjectIndex.Values) {
                var catalogItem = containerStoreEntry.JsonObject as CatalogedMachine;

                if (localName != null & catalogItem.Local == localName) {
                    return catalogItem;
                    }
                }
            return null;
            }

        CatalogedMachine preconfiguredMachine = null;
        foreach (var containerStoreEntry in ObjectIndex.Values) {
            var catalogItem = containerStoreEntry.JsonObject as CatalogedMachine;

            switch (catalogItem) {
                case CatalogedPending _: {
                        return catalogItem;

                        // Hack: Should have a mechanism to time out connection attempts.
                        }
                case CatalogedPreconfigured _: {
                        preconfiguredMachine = catalogItem;
                        break;
                        }
                }

            }
        return preconfiguredMachine;
        }


    /// <summary>
    /// Begin connection to a service.
    /// </summary>
    /// <returns>Context for administering the Mesh account via the service</returns>
    public ContextMeshPending Connect(
            string accountAddress,
            string localName = null,
            string pin = null,
            List<string> rights = null) => ContextMeshPending.ConnectService(this, accountAddress, localName, pin,
                rights: rights);

    /// <summary>
    /// Begin connection to a service.
    /// </summary>
    /// <returns>Context for administering the Mesh account via the service</returns>
    public ContextMeshPending Join(
            string uriAddress,
            string localName = null,
            CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
            CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
            CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default) {

        algorithmSign.Future();
        algorithmEncrypt.Future();
        algorithmAuthenticate.Future();

        (var accountAddress, var pin) = MeshUri.ParseConnectUri(uriAddress);

        // connect to alice@example.com using pin NACE-ZMVM-L6FV-NCHE-LY
        return ContextMeshPending.ConnectService(this, accountAddress, localName, pin);

        }

    /// <summary>
    /// Install a pre-configured device profile. This is typically performed during 
    /// manufacture.
    /// </summary>
    /// <returns>Context for administering the Mesh account via the service</returns>
    public ContextMeshPreconfigured Install(
            string filename,
            string localName = null,
            CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
            CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
            CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default) {
        localName.Future();
        filename.Future();
        algorithmSign.Future();
        algorithmEncrypt.Future();
        algorithmAuthenticate.Future();

        // read the device file
        var devicePreconfiguration = DevicePreconfigurationPrivate.FromFile(filename);

        // create a ContextMeshPending for it.
        var context = ContextMeshPreconfigured.Install(this, devicePreconfiguration);
        return context;

        }


    /// <summary>
    /// Create a new Mesh master profile and account without binding to a service
    /// </summary>
    /// <returns>Context for administering the Mesh account</returns>
    public ContextUser CreateMeshWithAccount(
            string localName,
            CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
            CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
            CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default) {

        algorithmSign.Future();
        algorithmEncrypt.Future();
        algorithmAuthenticate.Future();


        var contextMeshAdmin = ConfigureMesh(localName);

        return contextMeshAdmin;


        //throw new NYI();
        //return contextMeshAdmin.CreateAccount(localName);

        }

    }
