using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Protocol;

namespace Goedel.Mesh {

    public delegate IMeshMachine GetMachineDelegate();

    public static class MeshMachine {
        public static GetMachineDelegate GetMachine;


        public static string DirectoryProfiles;

        }

    public interface IMeshMachine {


        string DirectoryMesh { get; }

        string DirectoryService { get; }

        KeyCollection KeyCollection { get; }

        void OpenCatalog(Catalog catalog, string Name);

        void Register(Profile profile);

        MeshService GetMeshClient(string account);

        ProfileMesh GetConnection(
                    string accountName = null,
                    string deviceUDF = null);

        }

    }
