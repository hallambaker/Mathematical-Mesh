using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;

namespace Goedel.Mesh {

    public delegate IMeshMachine GetMachineDelegate();

    public static class MeshMachine {
        public static GetMachineDelegate GetMachine;


        public static string DirectoryProfiles;

        }

    public interface IMeshMachine {

        KeyCollection KeyCollection { get; }
        string DirectoryMesh { get; }
        string DirectoryService { get; }

        void OpenCatalog(Catalog catalog, string Name);


        void Register(ProfileDevice Device);
        void Register(ProfileMaster Device);
        void Register(ProfileApplication Device);
        MeshService GetMeshClient(string account);




        }

    }
