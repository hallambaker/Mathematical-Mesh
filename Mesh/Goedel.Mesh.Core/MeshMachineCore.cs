using System;
using System.IO;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Core;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Mesh;
using Goedel.Mesh.Protocol;

namespace Goedel.Mesh {

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>This implementation does not currently support concurrent access to the Mesh profile files
    /// from separate processes. This support should be added my introducing a system wide lock that is
    /// obtained before attempting a write operation and while opening a container.</remarks>
    public class MeshMachineCore: IMeshMachine {



        public virtual string DirectoryMaster { get; }
        public virtual string DirectoryMesh { get; }
        public virtual string DirectoryKeys { get; }
        public virtual string DirectoryService { get; }



        public const string FileTypeHost = "application/mmm-host";
        //public const string FileTypeDevices = "application/mmm-devices";
        //public const string FileTypeContacts = "application/mmm-contacts";
        //public const string FileTypeCredentials = "application/mmm-credentials";

        public string FileNameHost => Path.Combine(DirectoryMesh, "host.dare");
        //public string FileNameDevices => Path.Combine(DirectoryMesh, "devices.dare");
        //public string FileNameContacts => Path.Combine(DirectoryMesh, "contacts.dare");
        //public string FileNameCredentials => Path.Combine(DirectoryMesh, "credentials.dare");


        public ContainerPersistenceStore ContainerHost => containerHost ?? 
            OpenContainer(FileNameHost, FileTypeHost).CacheValue(out containerHost);
        ContainerPersistenceStore containerHost;

        //public ContainerPersistenceStore ContainerDevices => containerDevices ?? 
        //    OpenContainer(FileNameDevices, FileTypeDevices).CacheValue(out containerDevices);
        //ContainerPersistenceStore containerDevices;

        //public ContainerPersistenceStore ContainerContacts => containerContacts ?? 
        //    OpenContainer(FileNameContacts, FileTypeContacts).CacheValue(out containerContacts);
        //ContainerPersistenceStore containerContacts;

        //public ContainerPersistenceStore ContainerCredentials => containerCredentials ?? 
        //    OpenContainer(FileNameCredentials, FileTypeCredentials).CacheValue(out containerCredentials);
        //ContainerPersistenceStore containerCredentials;

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

            }

        ContainerPersistenceStore OpenContainer(string fileName, string type) =>
            new ContainerPersistenceStore(fileName, type, 
                fileStatus:FileStatus.OpenOrCreate,
                containerType:ContainerType.MerkleTree
                );

            //{




        #region // Implementation
        public static  IMeshMachine GetMachine() => new MeshMachineCore();

        public virtual KeyCollection KeyCollection { get; }

        public virtual KeyCollection GetKeyCollection() => new KeyCollectionCore();

        public virtual void Register(ProfileDevice profile) => ContainerHost.New(profile);

        public virtual void Register(ProfileMaster profile) => ContainerHost.New(profile);

        public virtual void Register(ProfileApplication profile) => ContainerHost.New(profile);


        public virtual void OpenCatalog(Catalog catalog, string Name) { }



        public virtual MeshService GetMeshClient(string account) => MeshService.GetService(account);
        #endregion

        }

    }
