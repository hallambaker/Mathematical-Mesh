using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

using System;
using System.Collections.Generic;

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
        public IMeshMachineClient MeshMachine;
        PersistHost containerProfile;

        ///<summary>The Key Collection of the Mesh Machine.</summary>
        public KeyCollection KeyCollection => keyCollection ??
                new KeyCollectionClient(this, MeshMachine.KeyCollection).CacheValue(out keyCollection);
        KeyCollection keyCollection;


        #endregion
        #region // Boilerplate for disposal etc.
        ///<summary>Disposal routine.</summary>
        protected override void Disposing() => containerProfile.Dispose();
        #endregion
        #region // Constructors and factories

        /// <summary>
        /// Get the host catalog from the specified mesh machine.
        /// </summary>
        /// <param name="meshMachine">The Mesh Machine.</param>
        /// <param name="containerHost">The host catalog.</param>
        public MeshHost(PersistHost containerHost, IMeshMachineClient meshMachine) {
            this.MeshMachine = meshMachine;
            containerProfile = containerHost;

            foreach (var entry in containerHost.ObjectIndex) {
                var catalogedMachine = entry.Value.JsonObject as CatalogedMachine;
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
                        var context = new ContextMesh(this, pendingEntry);
                        Register(context);
                        break;
                        }
                    }
                Console.WriteLine($"Container  {entry.Key}  of {entry.Value.GetType()}");
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
            DictionaryUDFContextMesh.AddSafe(machine.ID, contextMesh);
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
        public virtual void Register(HostCatalogItem catalogItem, bool create = true) =>
                containerProfile.Update(catalogItem, create);


        /// <summary>
        /// Delete <paramref name="profile"/> from the host catalog.
        /// </summary>
        /// <param name="profile">The profile to delete</param>
        public virtual void Delete(HostCatalogItem profile) =>
                containerProfile.Delete(profile._PrimaryKey);
        #endregion





        /// <summary>
        /// Create a new Mesh master profile without account or service.
        /// </summary>
        /// <returns>Context for administering the Mesh</returns>
        public ContextMeshAdmin CreateMesh(
                string localName,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default,
                byte[] masterSecret = null,
                bool? persist = null) {

            var context = ContextMeshAdmin.CreateMesh(
                    this, null, algorithmSign, algorithmEncrypt, algorithmAuthenticate,
                    masterSecret, persist);

            Register(context);
            Console.WriteLine($"Created profile {context.ProfileMesh.UDF}");

            return context;

            }


        /// <summary>
        /// Create a new management context for the specified Mesh profile.
        /// </summary>
        /// <param name="localName">The friendly name for the profile</param>
        /// <param name="admin">Enable administration privileges (if available).</param>
        /// <returns>Context for administering the Mesh</returns>
        public ContextMesh GetContextMesh(string localName = null, bool admin = true) {
            var key = localName ?? containerProfile.DefaultEntry.ID;
            return LocateMesh(key);
            }

        /// <summary>
        /// Attempt to complete the connection to a Mesh profile. If successful. update the local host persistence store
        /// and return a context for the newly acquired connection. Otherwise return null.
        /// </summary>
        /// <param name="serviceID"></param>
        /// <param name="localName"></param>
        /// <returns></returns>
        public ContextAccount Complete(
                string localName = null) {

            var key = localName ?? containerProfile.DefaultPendingEntry.ID;
            var contextPending = LocateMesh(key) as ContextMeshPending;
            return contextPending.Complete();
            }


        /// <summary>
        /// Begin connection to a service.
        /// </summary>
        /// <returns>Context for administering the Mesh account via the service</returns>
        public ContextMeshPending Connect(
                string serviceID,
                string localName = null,
                string PIN = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) =>
            ContextMeshPending.ConnectService(this, serviceID, localName, PIN);



        /// <summary>
        /// Create a new Mesh master profile without account or service
        /// </summary>
        /// <returns>Context for administering the Mesh</returns>
        public ContextMeshAdmin RecoverMesh(
                string localName,
                IEnumerable<string> shares = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default
                ) {
            var secret = new SharedSecret(shares);
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
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {
            var contextMeshAdmin = CreateMesh(localName);
            return contextMeshAdmin.CreateAccount(localName);

            }


        public ContextAccount AddAccount(
                    ContextMesh contextMesh, AccountEntry accountEntry,
                    string serviceID = null) {

            var contextAccount = new ContextAccount(contextMesh, accountEntry, serviceID);


            return contextAccount;
            }



        #region // Store dictionary - might be the wrong tack
        //public Dictionary<string, SyncStatus> DictionaryStores = new Dictionary<string, SyncStatus>();


        //public string DirectoryAccount(string accountName) =>
        //    Path.Combine(MeshMachine.DirectoryMesh, accountName);

        //public Store GetStore(string accountName, string storeName, bool blind = false) {
        //    var directoryAccount = DirectoryAccount (accountName);

        //    if (DictionaryStores.TryGetValue(storeName, out var syncStore)) {
        //        if (!blind & (syncStore.Store is CatalogBlind)) {
        //            // if we have a blind store from a sync operation but need a populated one,
        //            // remake it.
        //            syncStore.Store.Dispose();
        //            syncStore.Store = MakeStore(accountName, storeName);
        //            }
        //        return syncStore.Store;

        //        }

        //    var store = blind ? new CatalogBlind(directoryAccount, storeName) : MakeStore(accountName, storeName);

        //    syncStore = new SyncStatus(store);
        //    DictionaryStores.Add(storeName, syncStore);

        //    return syncStore.Store;
        //    }

        //Store MakeStore(string accountName, string name) {
        //    switch (name) {
        //        case Spool.SpoolInbound: return new Spool(DirectoryAccount, name, containerCryptoParameters, KeyCollection);
        //        case Spool.SpoolOutbound: return new Spool(DirectoryAccount, name, containerCryptoParameters, KeyCollection);
        //        case Spool.SpoolArchive: return new Spool(DirectoryAccount, name, containerCryptoParameters, KeyCollection);

        //        case CatalogCredential.Label: return new CatalogCredential(DirectoryAccount, name, containerCryptoParameters, KeyCollection);
        //        case CatalogContact.Label: return new CatalogContact(DirectoryAccount, name, containerCryptoParameters, KeyCollection);
        //        case CatalogCalendar.Label: return new CatalogCalendar(DirectoryAccount, name, containerCryptoParameters, KeyCollection);
        //        case CatalogBookmark.Label: return new CatalogBookmark(DirectoryAccount, name, containerCryptoParameters, KeyCollection);
        //        case CatalogNetwork.Label: return new CatalogNetwork(DirectoryAccount, name, containerCryptoParameters, KeyCollection);
        //        case CatalogApplication.Label: return new CatalogApplication(DirectoryAccount, name, containerCryptoParameters, KeyCollection);
        //        case CatalogDevice.Label: return new CatalogDevice(DirectoryAccount, name, containerCryptoParameters, KeyCollection);
        //        }

        //    throw new NYI();
        //    }

        #endregion 


        }
    }
