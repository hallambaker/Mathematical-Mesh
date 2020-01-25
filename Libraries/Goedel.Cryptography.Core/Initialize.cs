using Goedel.IO;

namespace Goedel.Cryptography {

    ///<summary>Static class whose only function is to contain the initialization 
    ///routine.</summary>
    public class Cryptography : Initialization {

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
        /// Initialization routine for all cryptographic functions on the dotNet Core platform.
        /// </summary>
        public static void InitializationCore(bool TestMode = false) {
            CryptographyCommon.Initialize();
            KeyCollection.Default = new Core.KeyCollectionCore();
            }
        }
    }
