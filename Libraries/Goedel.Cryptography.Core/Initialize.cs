﻿using Goedel.IO;

using System.Runtime.CompilerServices;

namespace Goedel.Cryptography.Core {

    ///<summary>Static class whose only function is to contain the initialization 
    ///routine.</summary>
    public static class Initialization {

        ///<summary>Initialization witness flag.</summary> 
        public static bool Initialized { get; private set; }

        /// <summary>
        /// Initialization routine for cryptographic functions on the dotNet Core platform.
        /// </summary>

        [ModuleInitializer]
        internal static void Initialize() {
            Initialized = true;
            KeyCollection.Default = new Core.KeyCollectionCore();
            }
        }
    }
