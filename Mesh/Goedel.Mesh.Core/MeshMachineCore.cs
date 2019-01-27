using System;
using System.IO;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Core;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Mesh;
using Goedel.Mesh.Protocol;
using Goedel.Protocol;
using Goedel.Mesh.Protocol.Client;

namespace Goedel.Mesh {

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>This implementation does not currently support concurrent access to the Mesh profile files
    /// from separate processes. This support should be added my introducing a system wide lock that is
    /// obtained before attempting a write operation and while opening a container.</remarks>
    public class MeshMachineCore: IMeshMachine, IMeshMachineClient {

        public CatalogHost CatalogHost { get; }


        public virtual string DirectoryMaster { get; }
        public virtual string DirectoryMesh { get; }
        public virtual string DirectoryKeys { get; }
        public virtual string DirectoryService { get; }



        public const string FileTypeHost = "application/mmm-host";


        public string FileNameHost => Path.Combine(DirectoryMesh, "host.dare");

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
            var containerHost = new ContainerHost(FileNameHost, FileTypeHost,
                fileStatus: FileStatus.OpenOrCreate,
                containerType: ContainerType.MerkleTree);

            CatalogHost = new CatalogHost(containerHost, this);
            }


        #region // Implementation
        public static  IMeshMachine GetMachine() => new MeshMachineCore();

        public virtual KeyCollection KeyCollection { get; }

        public virtual KeyCollection GetKeyCollection() => 
            new KeyCollectionCore();

        public virtual void OpenCatalog(Catalog catalog, string Name) { }


        public virtual void Register (Profile profile) =>
                CatalogHost.Register(profile);

        public virtual void Delete(Profile profile) =>
                CatalogHost.Delete(profile);

        public virtual ProfileMesh GetConnection(
                    string accountName = null,
                    string deviceUDF = null) => CatalogHost.GetConnection(accountName, deviceUDF);


        public virtual MeshService GetMeshClient(string account) => 
            MeshService.GetService(account);
        #endregion

        }

    }
