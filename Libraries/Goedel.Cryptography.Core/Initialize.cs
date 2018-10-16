using System;
using System.IO;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using System.Threading;
using Goedel.Utilities;

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
        /// Initialization routine for all cryptographic and Mesh functions on the dotNet Core platform.
        /// </summary>
        public static void InitializationCore(bool TestMode = false) {
            CryptographyCommon.Initialize();
            KeyCollection.Default = new Core.KeyCollectionCore();
            //Platform.GetPlatformInformation = Core.KeyLocationsCore.GetPlatformInformation;

            //var home = Platform.GetPlatformInformation(PlatformInformation.DirectoryApplicationHome);
            }
        }
    }
