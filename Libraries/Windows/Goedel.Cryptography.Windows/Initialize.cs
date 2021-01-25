using System;
using System.Runtime.CompilerServices;

namespace Goedel.Cryptography.Windows {
    public static class Initialization {

        public static bool Initialized => true;

        [ModuleInitializer]
        internal static void Initialize() {
            }
        }


    }
