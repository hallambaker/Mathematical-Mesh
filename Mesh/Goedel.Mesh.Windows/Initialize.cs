using System;
using Goedel.Cryptography;
namespace Goedel.Mesh {
    public class Mesh {

        public static void Initialize() {


            MeshMachine.Default = new MeshMachineWindows();
            Cryptography.Cryptography.Initialize(true);
            }





        }

    public class MeshMachineWindows : IMeshMachine {


        public KeyCollection GetKeyCollection() => new KeyCollection();

        public void Register(ProfileDevice Device) {
            }
        }

    }
