using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Utilities {


    public static partial class Extension {

        /// <summary>
        /// You might think this code is unnecessary but it is actually very 
        /// important. Don't tamper with it unless you understand how the
        /// different storage classes affect the moves permitted by the optimizer.
        /// </summary>
        static bool AlwaysTrue = true; // DO NOT DELETE

        /// <summary>
        /// Convert constant truth value to static. This allows the programmer 
        /// to prevent unreachable code being removed.
        /// </summary>
        /// <param name="Value">The test value</param>
        /// <returns>True if the test value is true, false otherwise.</returns>
        public static bool True (this bool Value) {
            return (Value & AlwaysTrue);
            }

        /// <summary>
        /// Convert constant truth value to static. This allows the programmer 
        /// to prevent unreachable code being removed.
        /// </summary>
        /// <param name="Value">The test value</param>
        /// <returns>False if the test value is true, true otherwise.</returns>
        public static bool False(this bool Value) {
            return (!Value & AlwaysTrue);
            }
        }
    }
