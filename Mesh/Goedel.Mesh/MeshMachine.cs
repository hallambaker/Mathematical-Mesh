using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;

namespace Goedel.Mesh {


    public static class MeshMachine {
        public static IMeshMachine Default;

        }

    public interface IMeshMachine {



        void Register(ProfileDevice Device);

        KeyCollection GetKeyCollection();
        }


    /// <summary>
    /// Test machine. The cryptographic keys and persistence stores are only 
    /// stored as in-memory structures and never written to disk.
    /// </summary>
    public class MeshMachineTest: IMeshMachine{

        /// <summary>
        /// Construct a unique test machine with the specified class name.
        /// Separate persistence stores will be created.
        /// </summary>
        /// <param name="Name"></param>
        public MeshMachineTest(string Name) {
            }

        public void Register(ProfileDevice Device) {
            }

        public KeyCollection GetKeyCollection() => new KeyCollection();

        }

    }
