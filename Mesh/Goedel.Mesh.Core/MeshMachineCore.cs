using System;
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
    public class MeshMachineCore: Disposable, IMeshMachine, IMeshMachineClient {


        public const string FileTypeHost = "application/mmm-host";


        public string FileNameHost => Path.Combine(DirectoryMesh, "host.dare");

        #region // Disposing
        protected override void Disposing() {
            CatalogHost.Dispose();
            }
        #endregion


        public AdminEntry GetAdmin(string local = null) => CatalogHost.GetAdmin(local);
        public AccountEntry GetAccount(string local = null) => CatalogHost.GetAccount(local);
        public PendingEntry GetPending(string local = null) => CatalogHost.GetPending(local);

        public ContextAccount GetContextAccount(string local = null) =>
            new ContextAccount(this, GetAccount(local));




        public CatalogHost CatalogHost { get; }




        public virtual string DirectoryMaster { get; }
        public virtual string DirectoryMesh { get; }
        public virtual string DirectoryKeys { get; }
        public virtual string DirectoryService { get; }

        //public ContainerHost ContainerHost { get; }


        public MeshMachineCore() : this (MeshMachine.DirectoryProfiles) {
            }

        protected MeshMachineCore(string directory) {
            DirectoryMaster = directory;
            DirectoryMesh = Path.Combine(directory, "Profiles");
            DirectoryKeys = Path.Combine(directory, "Keys");
            Directory.CreateDirectory(DirectoryMesh);
            Directory.CreateDirectory(DirectoryKeys);

            KeyCollection = GetKeyCollection();

            // Now read the container to get the directories.
            var containerHost = new ContainerProfile(FileNameHost, FileTypeHost,
                fileStatus: FileStatus.ConcurrentLocked,
                containerType: ContainerType.MerkleTree);

            CatalogHost = new CatalogHost(containerHost, this);
            }

        #region // Convenience accessors
        public ContextAdmin GenerateAdmin() => ContextAdmin.Generate(this);

        public ContextAccount GenerateAccount(ContextAdmin contextAdmin,
                string localName,
                ProfileDevice profileDevice = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) =>
            ContextAccount.Generate(contextAdmin, localName, this, profileDevice,
                algorithmSign, algorithmEncrypt, algorithmAuthenticate);

        public ContextAccount Connect(
                string  ServiceId,
                string PIN = null
            ) {
            throw new NYI();
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

        public virtual void Register(CatalogItem catalogItem) =>
                CatalogHost.Register(catalogItem);

        public virtual void Delete(CatalogItem catalogItem) =>
                CatalogHost.Delete(catalogItem);










        // *********** Old
        public virtual void Register (DareMessage entry) =>
                CatalogHost.Register(entry);

        public virtual AssertionAccount GetConnection(
                    string accountName = null,
                    string deviceUDF = null) => CatalogHost.GetConnection(accountName, deviceUDF);

        //  ******


        public virtual MeshService GetMeshClient(string account) => 
            MeshService.GetService(account);




        #endregion

        }

    }
