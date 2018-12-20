using System;
using Goedel.Mesh.Shell;
using Goedel.Cryptography;

namespace mesh_core {
    class Program {
        public static void Main(string[] args) {
            Cryptography.Initialize();
            Shell.Main(args);
            }
        }
    }
