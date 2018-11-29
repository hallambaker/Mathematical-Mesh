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


        public string FileNameHost => Path.Combine(DirectoryMesh, "host.dare");

        public ContainerPersistenceStore ContainerHost { get; }


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
            ContainerHost = new ContainerPersistenceStore(FileNameHost, FileTypeHost,
                fileStatus: FileStatus.OpenOrCreate,
                containerType: ContainerType.MerkleTree,
                readContainer:false);

            foreach (var ContainerDataReader in ContainerHost.Container) {
                if (ContainerDataReader.HasPayload) {
                    var Data = ContainerDataReader.ToArray();
                    CommitTransaction(ContainerDataReader.Header, Data);
                    // here check the trailer.
                    }
                }

            }


        void CommitTransaction(ContainerHeader ContainerHeader, byte[] Data) {

            var profile = Profile.FromJSON(Data.JSONReader());

            switch (profile) {
                case ProfileMesh profileMesh:  {
                    Assert.Fail();
                    break;
                    }
                case ProfileMeshConnect profileMeshConnect: {
                    Assert.Fail();
                    break;
                    }
                case ProfileApplication profileApplication: {
                    Assert.Fail();
                    break;
                    }

                }

            }




        #region // Implementation
        public static  IMeshMachine GetMachine() => new MeshMachineCore();

        public virtual KeyCollection KeyCollection { get; }

        public virtual KeyCollection GetKeyCollection() => 
            new KeyCollectionCore();


        public virtual void Register (Profile profile) => 
                ContainerHost.Update(profile);

        public virtual void Delete(Profile profile) =>
                ContainerHost.Delete(profile._PrimaryKey);


        public virtual void OpenCatalog(Catalog catalog, string Name) { }


        public virtual ProfileAccount GetConnection(
                    string accountName = null,
                    string deviceUDF = null) {
            if (accountName != null) {

                }
            if (deviceUDF != null) {

                }


            throw new NYI();

            }


        public virtual MeshService GetMeshClient(string account) => MeshService.GetService(account);
        #endregion

        }

    }
