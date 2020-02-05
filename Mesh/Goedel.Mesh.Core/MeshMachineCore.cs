using Goedel.Cryptography;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Mesh.Client;
using Goedel.Utilities;

using System.IO;

namespace Goedel.Mesh {


    public class MeshMachineCoreServer : Disposable, IMeshMachine {

        #region // Properties
        public virtual string DirectoryMaster { get; }
        public virtual string DirectoryMesh { get; }
        public virtual string DirectoryKeys { get; }
        public virtual string DirectoryService { get; }

        public virtual KeyCollection KeyCollection { get; }

        public const string FileTypeHost = "application/mmm-host";
        #endregion


        public MeshMachineCoreServer(string directory) {
            DirectoryMaster = directory;
            DirectoryMesh = Path.Combine(directory, "Profiles");
            DirectoryKeys = Path.Combine(directory, "Keys");
            Directory.CreateDirectory(DirectoryMesh);
            Directory.CreateDirectory(DirectoryKeys);

            KeyCollection = GetKeyCollection();
            }



        #region // Disposing
        protected override void Disposing() {
            //CatalogHost.Dispose();
            }
        #endregion

        public virtual KeyCollection GetKeyCollection() =>
            new KeyCollectionCore();

        #region // Implementation

        /// <summary>
        /// Generate a keypair of a type specified by <paramref name="algorithmID"/> and bind to the 
        /// KeyCollection of the machine instance.
        /// </summary>
        /// <param name="algorithmID">The type of keypair to create.</param>
        /// <param name="keySize">The key size (ignored if the algorithm supports only one key size)</param>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
        /// <returns>The created key pair</returns>
        public virtual KeyPair CreateKeyPair(
                    CryptoAlgorithmID algorithmID,
                    KeySecurity keySecurity,
                    int keySize = 0,
                    KeyUses keyUses = KeyUses.Any) => KeyPair.Factory(algorithmID, keySecurity,
                        KeyCollection, keySize, keyUses);
        #endregion 

        public virtual void OpenCatalog(Catalog catalog, string Name) { }
        }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>This implementation does not currently support concurrent access to the Mesh profile files
    /// from separate processes. This support should be added my introducing a system wide lock that is
    /// obtained before attempting a write operation and while opening a container.</remarks>
    public class MeshMachineCore : MeshMachineCoreServer, IMeshMachineClient {

        #region // Properties

        public MeshHost MeshHost { get; }

        public string FileNameHost => Path.Combine(DirectoryMesh, "host.dare");
        #endregion


        #region // Disposing
        protected override void Disposing() => MeshHost.Dispose();
        #endregion


        public MeshMachineCore() : this(MeshMachine.DirectoryProfiles) {
            }

        protected MeshMachineCore(string directory) : base(directory) {
            // Now read the container to get the directories.
            var containerHost = new PersistHost(FileNameHost, FileTypeHost,
                fileStatus: FileStatus.ConcurrentLocked,
                containerType: ContainerType.MerkleTree);

            MeshHost = new MeshHost(containerHost, this);
            }

        #region // Convenience accessors



        #endregion


        #region // Implementation

        public static IMeshMachine GetMachine() => new MeshMachineCore();

        public virtual void Register(HostCatalogItem catalogItem) =>
                MeshHost.Register(catalogItem);

        public virtual void Delete(HostCatalogItem catalogItem) =>
                MeshHost.Delete(catalogItem);


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
        /// <param name="profile">The profile. This is required when requesting
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
