using System.Runtime.CompilerServices;

namespace Goedel.Cryptography.Windows {

    /// <summary>
    /// Initialization class.
    /// </summary>
    public static class Initialization {

        ///<summary>Always returns true. Requesting this value forces initialization.</summary> 
        public static bool Initialized => true;

        [ModuleInitializer]
        internal static void Initialize() {
            }
        }


    }
