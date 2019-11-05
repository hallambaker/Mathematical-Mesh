using Goedel.Cryptography;
using Goedel.Mesh.Shell;

namespace mesh_core {
    class Program {
        public static void Main(string[] args) {
            Cryptography.Initialize();
            Shell.Main(args);
            }
        }
    }
