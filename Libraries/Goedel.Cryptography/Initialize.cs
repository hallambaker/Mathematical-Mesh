
using System.Runtime.CompilerServices;

using Goedel.Cryptography.Standard;

namespace Goedel.Cryptography {

    ///<summary>Static class whose only function is to contain the initialization 
    ///routine.</summary>
    public static class Initialization {

        ///<summary>Initialization witness flag. This may be used to force initialization
        ///of the module prior to other modules being initialized.</summary> 
        public static bool Initialized { get; private set; }

        /// <summary>
        /// Initialization routine for cryptographic functions on the dotNet Core platform.
        /// </summary>

        [ModuleInitializer]
        internal static void Initialize() {
            Initialized = Platform.Initialized;


            CryptoProviderSHAKE128.Register();
            CryptoProviderSHAKE256.Register();
            }
        }
    }
