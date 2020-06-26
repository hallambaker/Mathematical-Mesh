using Goedel.Cryptography;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh.Client {



    // Today - cache all account contexts so only have one context per account!!!!


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
                case CatalogedAdmin adminEntry: {
                    var context = new ContextMeshAdmin(this, adminEntry);
                    Register(context);
                    break;
                    }
                case CatalogedStandard standardEntry: {
                    var context = new ContextMesh(this, standardEntry);
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
        protected Dictionary<string, ContextMesh> DictionaryUDFContextMesh = new Dictionary<string, ContextMesh>();

        ///<summary>Dictionary mapping mesh local name to Context.</summary>
        protected Dictionary<string, ContextMesh> DictionaryLocalContextMesh = new Dictionary<string, ContextMesh>();

        void Register(ContextMesh contextMesh) {
            var machine = contextMesh.CatalogedMachine;
            DictionaryUDFContextMesh.Remove(machine.ID);
            DictionaryUDFContextMesh.Add(machine.ID, contextMesh);
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
        public ContextMesh LocateMesh(string key) {
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
        public void Register(HostCatalogItem catalogItem, ContextMesh context, bool create = true) {
            
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
        /// Create a new Mesh master profile without account or service.
        /// </summary>
        /// <returns>Context for administering the Mesh</returns>
        public ContextMeshAdmin CreateMesh(
                string localName,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default,
                byte[] masterSecret = null,
                bool? persist = null) {

            localName.Future();

            var context = ContextMeshAdmin.CreateMesh(
                    this, null, algorithmSign, algorithmEncrypt, algorithmAuthenticate,
                    masterSecret, persist: persist);

            Register(context);
            //Console.WriteLine($"Created profile {context.ProfileMesh.UDF}");

            return context;

            }


        /// <summary>
        /// Create a new management context for the specified Mesh profile.
        /// </summary>
        /// <param name="localName">The friendly name for the profile</param>
        /// <param name="admin">Enable administration privileges (if available).</param>
        /// <returns>Context for administering the Mesh</returns>
        public ContextMesh GetContextMesh(string localName = null, bool admin = true) {

            admin.Future();

            var key = localName ?? ContainerHost?.DefaultEntry?.ID;
            return LocateMesh(key);
            }

        /// <summary>
        /// Attempt to complete the connection to a Mesh profile. If successful. update the local host persistence store
        /// and return a context for the newly acquired connection. Otherwise return null.
        /// </summary>
        /// <param name="localName"></param>
        /// <returns>Context for the newly bound account.</returns>
        public ContextAccount Complete(
                string localName = null) {

            var machine = ContainerHost.GetForCompletion(localName);

            switch (machine) {
                case CatalogedPending catalogedPending: {
                    var contextPending = LocateMesh(catalogedPending.ID) as ContextMeshPending;
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
        public ContextMeshAdmin RecoverMesh(
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
        public ContextAccount CreateMeshWithAccount(
                string localName,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default) {

            algorithmSign.Future();
            algorithmEncrypt.Future();
            algorithmAuthenticate.Future();


            var contextMeshAdmin = CreateMesh(localName);
            return contextMeshAdmin.CreateAccount(localName);

            }

        }
    }
