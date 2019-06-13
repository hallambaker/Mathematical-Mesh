using System;
using Goedel.Cryptography;
using Goedel.Cryptography.Windows;
using Goedel.Utilities;
using Goedel.Protocol;
using Goedel.Cryptography.Dare;

namespace Goedel.Mesh {
    public class Mesh {

        public static void Initialize() {


            //MeshMachine.Default = new MeshMachineWindows();
            Cryptography.Cryptography.Initialize(true);

            throw new NYI();
            }





        }

    public class MeshMachineWindows : IMeshMachine {

        public string DirectoryMesh => throw new NYI();
        public string DirectoryService => throw new NYI();
        public KeyCollection KeyCollection { get; }

        public KeyCollection GetKeyCollection() => new KeyCollectionWindows();



        public void OpenCatalog(Catalog catalog, string Name) { }

        public MeshService GetMeshClient(string address) => throw new NotImplementedException();
        //public AssertionAccount GetConnection(string accountName = null, string deviceUDF = null) => throw new NotImplementedException();
        //public void Register(DareEnvelope entry) => throw new NotImplementedException();
        public KeyPair CreateKeyPair(CryptoAlgorithmID algorithmID, KeySecurity keySecurity, int keySize = 0, KeyUses keyUses = KeyUses.Any) => throw new NotImplementedException();
        }

    }
