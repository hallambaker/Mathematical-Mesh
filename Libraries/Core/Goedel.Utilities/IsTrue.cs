namespace Goedel.Utilities {


    public static partial class Extension {

        /// <summary>
        /// Tell compiler that an object is reserved.
        /// </summary>
        /// <param name="o">Object to reserve.</param>
        /// <returns>true if the object is not null, false otherwise.</returns>
        public static bool Keep(this object o) => o != null;

        /// <summary>
        /// Tell compiler that an object is reserved for future use.
        /// </summary>
        /// <param name="o">Object to reserve.</param>
        /// <returns>true if the object is not null, false otherwise.</returns>
        public static bool Future(this object o) => o != null;


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
        public static bool True(this bool Value) => (Value & AlwaysTrue);

        /// <summary>
        /// Convert constant truth value to static. This allows the programmer 
        /// to prevent unreachable code being removed.
        /// </summary>
        /// <param name="Value">The test value</param>
        /// <returns>False if the test value is true, true otherwise.</returns>
        public static bool False(this bool Value) => (!Value & AlwaysTrue);
        }
    }
