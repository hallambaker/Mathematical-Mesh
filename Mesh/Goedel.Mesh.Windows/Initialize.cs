using System;
using Goedel.Cryptography;
using Goedel.Cryptography.Windows;
namespace Goedel.Mesh {
    public class Mesh {

        public static void Initialize() {


            MeshMachine.Default = new MeshMachineWindows();
            Cryptography.Cryptography.Initialize(true);
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
        }

    }
