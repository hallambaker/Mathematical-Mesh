using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using System.IO;

namespace Goedel.Mesh.Client {






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
        public IMeshMachine MeshMachine;
        CatalogHost containerProfile;
        
        ///<summary>The Key Collection of the Mesh Machine.</summary>
        public KeyCollection KeyCollection => keyCollection  ?? 
                new KeyCollectionClient (this, MeshMachine.KeyCollection).CacheValue (out keyCollection);
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
        public MeshHost(CatalogHost containerHost, IMeshMachine meshMachine) {
            this.MeshMachine = meshMachine;
            containerProfile = containerHost;

            foreach (var entry in containerHost.ObjectIndex) {

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
        #region // Convenience Methods

        /// <summary>
        /// Convenience routine to return a host description of a mesh connection.
        /// </summary>
        /// <param name="id">The mesh short name or master profile UDF.</param>
        /// <returns>The mesh host description (if found)</returns>
        public CatalogedMachine GetMeshConnection(string id = null) => 
                containerProfile.GetConnection(id);

        /// <summary>
        /// Convenience routine to return a host description of a pending mesh connection request.
        /// </summary>
        /// <param name="id">The mesh short name or master profile UDF.</param>
        /// <returns>The mesh connection request description (if found)</returns>
        public CatalogedPending GetPending(string local = null) => 
                containerProfile.GetPending(local);


        #endregion
        #region // Methods


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
        /// Create a new management context for the specified Mesh profile.
        /// </summary>
        /// <param name="localName">The friendly name for the profile</param>
        /// <param name="admin">Enable administration privileges (if available).</param>
        /// <returns>Context for administering the Mesh</returns>
        public ContextMesh GetContextMesh(string localName = null, bool admin = true) {

            var entry = GetMeshConnection(localName);
            switch (entry) {
                case CatalogedAdmin adminEntry: return new ContextMeshAdmin(MeshMachine as IMeshMachineClient, adminEntry);
                default: return new ContextMesh(MeshMachine as IMeshMachineClient, entry);
                }


            }


        public ContextAccount Complete(
                string serviceID,
                string localName = null) {
            var catalogedPending = GetPending(serviceID);

            var contextPending = new ContextMeshPending(MeshMachine as IMeshMachineClient, catalogedPending);
            return contextPending.Complete();

            }


        /// <summary>
        /// Create a new Mesh master profile without account or service
        /// </summary>
        /// <returns>Context for administering the Mesh</returns>
        public ContextMeshAdmin CreateMesh(
                string localName,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) => ContextMeshAdmin.CreateMesh(
                    MeshMachine as IMeshMachineClient, null, algorithmSign, algorithmEncrypt, algorithmAuthenticate);

        /// <summary>
        /// Create a new Mesh master profile and account and bind to a service
        /// </summary>
        /// <returns>Context for administering the Mesh account via the service</returns>
        public ContextMeshPending Connect(
                string serviceID,
                string localName = null,
                string PIN = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) => 
            ContextMeshPending.ConnectService(MeshMachine as IMeshMachineClient, serviceID, localName, PIN);



        /// <summary>
        /// Create a new Mesh master profile without account or service
        /// </summary>
        /// <returns>Context for administering the Mesh</returns>
        public ContextMeshAdmin RecoverMesh(
                string localName,
                DareEnvelope escrow = null,
                IEnumerable<string> shares = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default
                ) {
            var secret = new Secret(shares);
            return ContextMeshAdmin.RecoverMesh(
                     MeshMachine as IMeshMachineClient, secret, null, escrow, algorithmSign, algorithmEncrypt, algorithmAuthenticate);
            }

        /// <summary>
        /// Create a new Mesh master profile and account without binding to a service
        /// </summary>
        /// <returns>Context for administering the Mesh account</returns>
        public ContextAccount CreateAccount(
                string localName,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {
            using (var contextMeshAdmin = CreateMesh(localName)) {
                return contextMeshAdmin.CreateAccount(localName);
                }
            }

        /// <summary>
        /// Create a new Mesh master profile and account and bind to a service
        /// </summary>
        /// <returns>Context for administering the Mesh account via the service</returns>
        public ContextAccount CreateService(
                string localName,
                string accountName = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {
            using (var contextMeshAdmin = CreateMesh(localName)) {
                var contextAccount = contextMeshAdmin.CreateAccount(localName);
                contextAccount.AddService(accountName ?? localName);
                return contextAccount;
                }
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
