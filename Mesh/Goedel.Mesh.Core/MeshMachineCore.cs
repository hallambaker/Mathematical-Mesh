using System;
using System.Collections.Generic;
using System.IO;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Core;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Mesh;
using Goedel.Protocol;
using Goedel.Mesh.Client;

namespace Goedel.Mesh {

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>This implementation does not currently support concurrent access to the Mesh profile files
    /// from separate processes. This support should be added my introducing a system wide lock that is
    /// obtained before attempting a write operation and while opening a container.</remarks>
    public class MeshMachineCore : Disposable, IMeshMachineClient {


        public const string FileTypeHost = "application/mmm-host";


        public string FileNameHost => Path.Combine(DirectoryMesh, "host.dare");

        #region // Disposing
        protected override void Disposing() {
            CatalogHost.Dispose();
            }
        #endregion


        public CatalogedMachine GetConnection(string local = null) => CatalogHost.GetConnection(local);
        public CatalogedPending GetPending(string local = null) => CatalogHost.GetPending(local);


        /// <summary>
        /// Create a new management context for the specified Mesh profile.
        /// </summary>
        /// <param name="localName">The friendly name for the profile</param>
        /// <param name="admin">Enable administration privileges (if available).</param>
        /// <returns>Context for administering the Mesh</returns>
        public ContextMesh GetContextMesh(string localName = null, bool admin = true) {

            var entry = CatalogHost.GetConnection(localName);
            switch (entry) {
                case CatalogedAdmin adminEntry: return new ContextMeshAdmin(this, adminEntry);
                default:  return new ContextMesh(this, entry);
                }

            
            }

        ///// <summary>
        ///// Create a new management context for the specified Mesh account.
        ///// </summary>
        ///// <param name="localName">The friendly name for the account</param>
        ///// <param name="serviceID">The account service id</param>
        ///// <returns>Context for administering the Mesh account</returns>
        //public ContextAccount GetContextAccount(
        //        string localName=null, string serviceID = null) => throw new NYI();


        public CatalogHost CatalogHost { get; }




        public virtual string DirectoryMaster { get; }
        public virtual string DirectoryMesh { get; }
        public virtual string DirectoryKeys { get; }
        public virtual string DirectoryService { get; }

        //public ContainerHost ContainerHost { get; }


        public MeshMachineCore() : this(MeshMachine.DirectoryProfiles) {
            }

        protected MeshMachineCore(string directory) {
            DirectoryMaster = directory;
            DirectoryMesh = Path.Combine(directory, "Profiles");
            DirectoryKeys = Path.Combine(directory, "Keys");
            Directory.CreateDirectory(DirectoryMesh);
            Directory.CreateDirectory(DirectoryKeys);

            KeyCollection = GetKeyCollection();

            // Now read the container to get the directories.
            var containerHost = new PersistConnection(FileNameHost, FileTypeHost,
                fileStatus: FileStatus.ConcurrentLocked,
                containerType: ContainerType.MerkleTree);

            CatalogHost = new CatalogHost(containerHost, this);
            }

        #region // Convenience accessors


        /// <summary>
        /// Register <paramref name="profileEntry"/> in the persistence store. An error is
        /// reported if the entry does not exist and the <paramref name="create"/> is true.
        /// </summary>
        /// <param name="profileEntry">The entry to add or update.</param>
        /// <param name="create">Report an error if the object identifier does not already exist.</param>
        public void Register(CatalogedMachine profileEntry, bool create = true) {
            CatalogHost.Register(profileEntry, create);
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
                    this, null, algorithmSign, algorithmEncrypt, algorithmAuthenticate);


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
                    this, secret, null, escrow, algorithmSign, algorithmEncrypt, algorithmAuthenticate);
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
            var contextMeshAdmin = CreateMesh(localName);
            return contextMeshAdmin.CreateAccount(localName);
            }

        /// <summary>
        /// Create a new Mesh master profile and account and bind to a service
        /// </summary>
        /// <returns>Context for administering the Mesh account via the service</returns>
        public ContextAccount CreateService(
                string localName,
                string accountName=null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {
            var contextMeshAdmin = CreateMesh(localName);
            var contextAccount = contextMeshAdmin.CreateAccount(localName);
            contextAccount.AddService(accountName ?? localName);
            return contextAccount;
            }


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
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {
            return ContextMeshPending.ConnectService(this, serviceID, localName, PIN);
            }

        #endregion


        #region // Implementation

        /// <summary>
        /// Generate a keypair of a type specified by <paramref name="algorithmID"/> and bind to the 
        /// KeyCollection of the machine instance.
        /// </summary>
        /// <param name="algorithmID">The type of keypair to create.</param>
        /// <param name="keySize">The key size (ignored if the algorithm supports only one key size)</param>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="keySecurity"/></param>
        /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
        /// <returns>The created key pair</returns>
        public KeyPair CreateKeyPair(
                    CryptoAlgorithmID algorithmID,
                    KeySecurity keySecurity,
                    int keySize = 0,
                    KeyUses keyUses = KeyUses.Any) => KeyPair.Factory(algorithmID, keySecurity,
                        KeyCollection, keySize, keyUses);




        public static  IMeshMachine GetMachine() => new MeshMachineCore();

        public virtual KeyCollection KeyCollection { get; }

        public virtual KeyCollection GetKeyCollection() => 
            new KeyCollectionCore();

        public virtual void OpenCatalog(Catalog catalog, string Name) { }

        public virtual void Register(ConnectionItem catalogItem) =>
                CatalogHost.Register(catalogItem);

        public virtual void Delete(ConnectionItem catalogItem) =>
                CatalogHost.Delete(catalogItem);




        /// <summary>
        /// Return a MeshService client for the service ID <paramref name="serviceID"/>
        /// using the authentication key <paramref name="keyAuthentication"/> and credential
        /// <paramref name="assertionAccountConnection"/>. 
        /// </summary>
        /// <param name="serviceID">The service identifier to connect to.</param>
        /// <param name="keyAuthentication">The private key to be used for authentication
        /// (encryption).</param>
        /// <param name="assertionAccountConnection">The credential binding the device
        /// to the account.</param>
        /// <param name="profileMaster">The master profile. This is required when requesting
        /// an inbound connection or requesting that a new account be created and optional
        /// otherwise.</param>
        /// <returns></returns>
        public virtual MeshService GetMeshClient(
                string serviceID,
            KeyPair keyAuthentication,
            ConnectionAccount assertionAccountConnection,
            Profile profile = null) =>
                    MeshService.GetService(serviceID);



        #endregion

        }

    }
