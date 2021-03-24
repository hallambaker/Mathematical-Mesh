using Goedel.Cryptography;
using Goedel.Cryptography.Core;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Mesh.Client;
using Goedel.Utilities;
using Goedel.Protocol;

using System.IO;

namespace Goedel.Mesh {

    /// <summary>
    /// The  Mesh server.
    /// </summary>
    public class MeshMachineCoreServer : Disposable, IMeshMachine {

        #region // Properties

        ///<summary>The directory used to store the master data.</summary>
        public virtual string DirectoryMaster { get; }

        ///<summary>The directory used to store the account mesh data.</summary>
        public virtual string DirectoryMesh { get; }

        ///<summary>The directory used to store host keys.</summary>
        public virtual string DirectoryKeys { get; }

        ///<summary>The host key collection.</summary>
        public virtual IKeyCollection KeyCollection { get; }

        ///<summary>The IANA media type for the host file data.</summary>
        public const string FileTypeHost = "application/mmm-host";
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="directory">Directory to store the server information.</param>
        public MeshMachineCoreServer(string directory) {
            DirectoryMaster = directory;
            DirectoryMesh = Path.Combine(directory, "Profiles");
            DirectoryKeys = Path.Combine(directory, "Keys");
            Directory.CreateDirectory(DirectoryMesh);
            Directory.CreateDirectory(DirectoryKeys);

            KeyCollection = GetKeyCollection();
            }



        #region // Disposing (Currently null)
        //protected override void Disposing() {
        //    //CatalogHost.Dispose();
        //    }
        #endregion

        /// <summary>
        /// Get the host key collection.
        /// </summary>
        /// <returns></returns>
        public virtual IKeyCollection GetKeyCollection() =>
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
                    CryptoAlgorithmId algorithmID,
                    KeySecurity keySecurity,
                    int keySize = 0,
                    KeyUses keyUses = KeyUses.Any) => KeyPair.Factory(algorithmID, keySecurity,
                        KeyCollection, keySize, keyUses);
        #endregion 
        }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>This implementation does not currently support concurrent access to the Mesh profile files
    /// from separate processes. This support should be added my introducing a system wide lock that is
    /// obtained before attempting a write operation and while opening a container.</remarks>
    public class MeshMachineCore : MeshMachineCoreServer, IMeshMachineClient {

        #region // Properties
        ///<summary>The Mesh Host</summary>
        public MeshHost MeshHost { get; }

        ///<summary>The file name of the host catalog.</summary>

        public string FileNameHost => Path.Combine(DirectoryMesh, "host.dare");


        //JpcHostBroker JpcHostBroker { get; } = new JpcHostBroker();


        #endregion


        #region // Disposing

        /// <summary>
        /// Disposing routine. Feee internal resources  and shut down the Mesh Host.
        /// </summary>
        protected override void Disposing() => MeshHost.Dispose();
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public MeshMachineCore() : this(MeshMachine.DirectoryProfiles) {
            }

        /// <summary>
        /// Constructor, creating a service instance using <paramref name="directory"/>
        /// to store persistent data.
        /// </summary>
        /// <param name="directory">Directory to store persistence data.</param>
        protected MeshMachineCore(string directory) : base(directory) {
            // Now read the container to get the directories.
            var containerHost = new PersistHost(FileNameHost, FileTypeHost,
                fileStatus: FileStatus.ConcurrentLocked,
                containerType: SequenceType.Merkle);

            MeshHost = new MeshHost(containerHost, this);
            }

        #region // Convenience accessors



        #endregion


        #region // Implementation

        /// <summary>
        /// Factory constructor.
        /// </summary>
        /// <returns></returns>
        public static IMeshMachine GetMachine() => new MeshMachineCore();


        /// <summary>
        /// Return a MeshService client for the service ID <paramref name="accountAddress"/>. 
        /// </summary>
        /// <param name="accountAddress">The service identifier to connect to.</param>

        /// <returns></returns>
        public virtual MeshServiceClient GetMeshClient(
                string accountAddress) {


            throw new NYI();

            //var session = new JpcSessionHTTP(accountAddress);
            //return session.GetWebClient<MeshServiceClient>();

                //JpcHostBroker.GetClient<MeshServiceClient>(session, MeshService.Discovery, null);

            }



        #endregion

        }

    }
