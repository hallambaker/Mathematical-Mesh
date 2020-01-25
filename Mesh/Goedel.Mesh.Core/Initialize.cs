using Goedel.IO;

namespace Goedel.Mesh {

    /// <summary>
    /// Initialization class. Applications should perform a call to Mesh.Initialize 
    /// before using Mesh library functions.
    /// </summary>
    public class Mesh : Initialization {

        static bool Flag = false;

        /// <summary>
        /// Thread safe generic initialization, calls the initialization for the
        /// cryptographic support libraries exactly once. 
        /// </summary>
        /// <remarks>This method is defined in each of the platform specific packages, to
        /// allow use of shared libraries for cross-platform support. If an implementation
        /// is linked to multiple platform packages, the platform specific initialization must
        /// be called for each.</remarks>
        public static void Initialize(bool TestMode = false) =>
            Initialize(ref Flag, InitializationCore, TestMode);

        /// <summary>
        /// Initialization routine for all Mesh functions on the dotNet Core platform.
        /// </summary>
        public static void InitializationCore(bool TestMode = false) {
            MeshMachine.IMeshMachineFactory = MeshMachineCore.GetMachine;
            Cryptography.Cryptography.Initialize(true);
            }

        }

    }
