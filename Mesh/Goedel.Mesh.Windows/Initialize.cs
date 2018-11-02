using System;
using Goedel.Cryptography;
using Goedel.Cryptography.Windows;
using Goedel.Utilities;

namespace Goedel.Mesh {
    public class Mesh {

        public static void Initialize() {


            //MeshMachine.Default = new MeshMachineWindows();
            Cryptography.Cryptography.Initialize(true);

            throw new NYI();
            }





        }

    public class MeshMachineWindows : IMeshMachine {
        public KeyCollection KeyCollection { get; }

        public KeyCollection GetKeyCollection() => new KeyCollectionWindows();

        public void Register(ProfileDevice Device) {
            }

        public void Register(ProfileMaster Device) {
            }
        public void Register(ProfileApplication Device) {
            }

        public void OpenCatalog(Catalog catalog, string Name) { }
        }

    }
