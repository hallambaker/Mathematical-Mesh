using System;
using System.Runtime.CompilerServices;
using Goedel.Cryptography;

namespace Goedel.Cryptography.Test {
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
        internal static void Initialize() =>
            // Force initialization of dependent modules.
            Initialized = Goedel.Cryptography.Initialization.Initialized;


        }
    }
