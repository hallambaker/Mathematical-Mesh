using Goedel.Cryptography;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh.Client {

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
        PersistHost ContainerHost { get; }

        ///<summary>The Key Collection of the Mesh Machine.</summary>
        public IKeyCollection KeyCollection => MeshMachine.KeyCollection;
        
        //keyCollection ??
        //        new KeyCollectionClient(this, MeshMachine.KeyCollection).CacheValue(out keyCollection);
        //KeyCollection keyCollection;


        #endregion
        #region // Boilerplate for disposal etc.
        ///<summary>Disposal routine.</summary>
        protected override void Disposing() => ContainerHost.Dispose();
        #endregion
        #region // Constructors and factories

        /// <summary>
        /// Get the host catalog from the specified mesh machine.
        /// </summary>
        /// <param name="meshMachine">The Mesh Machine.</param>
        /// <param name="containerHost">The host catalog.</param>
        public MeshHost(PersistHost containerHost, IMeshMachineClient meshMachine) {
            this.MeshMachine = meshMachine;
            ContainerHost = containerHost;

            foreach (var entry in containerHost.ObjectIndex) {
                var catalogedMachine = entry.Value.JsonObject as CatalogedMachine;
                Register(catalogedMachine);
                //Console.WriteLine($"Container  {entry.Key}  of {entry.Value.GetType()}");
                }

            }

        void Register(CatalogedMachine catalogedMachine) {
            switch (catalogedMachine) {
                // consider adding a machine catalog entry for a group...
                case CatalogedStandard standardEntry: {
                    var context = new ContextUser(this, standardEntry);
                    Register(context);
                    break;
                    }
                case CatalogedPending pendingEntry: {
                    var context = new ContextMeshPending(this, pendingEntry);
                    Register(context);
                    break;
                    }

                default:
                    break;
                }
            }

        /// <summary>
        /// Get the host catalog from the specified mesh machine.
        /// </summary>
        /// <param name="meshMachine"></param>
        public static MeshHost GetCatalogHost(IMeshMachine meshMachine) {
            var meshMachineClient = meshMachine as IMeshMachineClient;
            return meshMachineClient.MeshHost;

            }

        #endregion
        #region // Methods



        ///<summary>Dictionary mapping mesh UDF to Context.</summary>
        protected Dictionary<string, ContextAccount> DictionaryUDFContextMesh = new Dictionary<string, ContextAccount>();

        ///<summary>Dictionary mapping mesh local name to Context.</summary>
        protected Dictionary<string, ContextAccount> DictionaryLocalContextMesh = new Dictionary<string, ContextAccount>();

        void Register(ContextAccount contextMesh) {
            var machine = contextMesh.CatalogedMachine;
            DictionaryUDFContextMesh.Remove(machine.Id);
            DictionaryUDFContextMesh.Add(machine.Id, contextMesh);
            if (machine.Local != null) {
                DictionaryLocalContextMesh.AddSafe(machine.Local, contextMesh);
                }
            }

        /// <summary>
        /// Locate context by UDF or localname. The context acquired is owned by the MeshHost instance
        /// and MUST NOT be disposed of by the caller.
        /// </summary>
        /// <param name="key">The UDF or name to resolve.</param>
        /// <returns>The context, if a matching context is found. Otherwise null.</returns>
        public ContextAccount LocateMesh(string key) {
            key.AssertNotNull(MeshNotFound.Throw);


            if (DictionaryUDFContextMesh.TryGetValue(key, out var context)) {
                return context;
                }
            if (DictionaryLocalContextMesh.TryGetValue(key, out context)) {
                return context;
                }

            return null;
            }


        /// <summary>
        /// Register <paramref name="catalogItem"/> in the host catalog.
        /// </summary>
        /// <param name="catalogItem">The item to be created.</param>
        /// <param name="create">If true, a new item will be created if it does not
        /// already exist.</param>
        /// <param name="context">The dynamic context that interfaces to the catalog item.</param>
        public void Register(HostCatalogItem catalogItem, ContextAccount context, bool create = true) {
            
            // persist the permanent record.
            var machine = ContainerHost.Update(catalogItem, create);
            if (machine.JsonObject is CatalogedMachine catalogedMachine) {
                Register(catalogedMachine);
                }

            // register the dynamic context
            Register(context);

            }


        /// <summary>
        /// Delete <paramref name="profile"/> from the host catalog.
        /// </summary>
        /// <param name="profile">The profile to delete</param>
        public virtual void Delete(HostCatalogItem profile) =>
                ContainerHost.Delete(profile._PrimaryKey);
        #endregion





        /// <summary>
        /// Create a new Mesh master profile and bind to a Mesh service at <paramref name="accountAddress"/>.
        /// </summary>
        ///<param name="accountAddress">Account address to bind to.</param>
        /// <param name="localName">Local name for easy reference.</param>
        /// <param name="algorithmSign">Signature algorithm.</param>
        /// <param name="algorithmEncrypt">Encryption algorithm</param>
        /// <param name="algorithmAuthenticate">Authentication algorithm</param>
        /// <param name="secretSeed">Secret seed used to generate private keys.</param>
        /// <param name="profileDevice">Specify the device profile.</param>
        /// <returns>Context for administering the Mesh</returns>
        public ContextUser CreateMesh(
                string accountAddress,
                string localName=null,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default,
                byte[] secretSeed = null,
                ProfileDevice profileDevice = null) {

            // create the initial online signature key bound to this device
            var keyPairOnlineSignature = 
                KeyPair.FactorySignature(algorithmSign, KeySecurity.Device, KeyCollection);

            // Create the Mesh for the user
            var contextUser = ContextUser.CreateMesh(
                    this,
                    keyPairOnlineSignature,
                    localName,
                    algorithmSign: algorithmSign, 
                    algorithmEncrypt: algorithmEncrypt, 
                    algorithmAuthenticate: algorithmAuthenticate,
                    masterSecret: secretSeed);


            // Set the service 
            contextUser.SetService(accountAddress);

            // Create a device and catalog entry.
            var persistDevice = profileDevice == null;
            profileDevice ??= new ProfileDevice(KeyCollection, 
                    algorithmSign, algorithmEncrypt, algorithmAuthenticate);
            var catalogedDevice = contextUser.AddDevice(profileDevice, keyPairOnlineSignature, true);

            //Persist the results.
            if (persistDevice) {
                profileDevice.PersistSeed(KeyCollection);
                }
            contextUser.Persist(catalogedDevice);
            contextUser.PersistSeed();
            Register(contextUser);

            return contextUser;
            }


        /// <summary>
        /// Create a new management context for the specified Mesh profile.
        /// </summary>
        /// <param name="localName">The friendly name for the profile</param>
        /// <param name="admin">Enable administration privileges (if available).</param>
        /// <returns>Context for administering the Mesh</returns>
        public ContextAccount GetContextMesh(string localName = null, bool admin = true) {

            admin.Future();

            var key = localName ?? ContainerHost?.DefaultEntry?.Id;
            return LocateMesh(key);
            }

        /// <summary>
        /// Attempt to complete the connection to a Mesh profile. If successful. update the local host persistence store
        /// and return a context for the newly acquired connection. Otherwise return null.
        /// </summary>
        /// <param name="localName"></param>
        /// <returns>Context for the newly bound account.</returns>
        public ContextUser Complete(
                string localName = null) {

            var machine = ContainerHost.GetForCompletion(localName);

            switch (machine) {
                case CatalogedPending catalogedPending: {
                    var contextPending = LocateMesh(catalogedPending.Id) as ContextMeshPending;
                    return contextPending.Complete();
                    }
                case CatalogedPreconfigured catalogedPreconfigured: {
                    var contextPreconfigured = new ContextMeshPreconfigured (this, catalogedPreconfigured);
                    return contextPreconfigured.Complete();
                    }
                }
            return null;
            }

        //ContextAccount Complete(CatalogedPending catalogedPending) {
        //    var contextPending = LocateMesh(key) as ContextMeshPending;
        //    return contextPending.Complete();
        //    }



        /// <summary>
        /// Begin connection to a service.
        /// </summary>
        /// <returns>Context for administering the Mesh account via the service</returns>
        public ContextMeshPending Connect(
                string accountAddress,
                string localName = null,
                string PIN = null,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default) {

            algorithmSign.Future();
            algorithmEncrypt.Future();
            algorithmAuthenticate.Future();

            return ContextMeshPending.ConnectService(this, accountAddress, localName, PIN);
            }

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

            filename.Future();
            algorithmSign.Future();
            algorithmEncrypt.Future();
            algorithmAuthenticate.Future();

            // read the device file
            var devicePreconfiguration = DevicePreconfiguration.FromFile(filename);

            // create a ContextMeshPending for it.
            var context = ContextMeshPreconfigured.Install(this, devicePreconfiguration);
            return context;

            }


        /// <summary>
        /// Create a new Mesh master profile without account or service
        /// </summary>
        /// <returns>Context for administering the Mesh</returns>
        public ContextAccount RecoverMesh(
                string localName,
                IEnumerable<string> shares = null,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default
                ) {
            var secret = new SharedSecret(shares);
            secret.Future();
            localName.Future();
            algorithmSign.Future();
            algorithmEncrypt.Future();
            algorithmAuthenticate.Future();

            throw new NYI();

            //return ContextMeshAdmin.RecoverMesh(
            //         this, secret, null, escrow, algorithmSign, algorithmEncrypt, algorithmAuthenticate);
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


            var contextMeshAdmin = CreateMesh(localName);

            throw new NYI();
            //return contextMeshAdmin.CreateAccount(localName);

            }

        }
    }
