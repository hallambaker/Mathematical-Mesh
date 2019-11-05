namespace Goedel.Mesh {
    public class Mesh {

        public static void Initialize() {


            MeshMachine.GetMachine = MeshMachineCore.GetMachine;
            Cryptography.Cryptography.Initialize(true);
            }

        }

    }
