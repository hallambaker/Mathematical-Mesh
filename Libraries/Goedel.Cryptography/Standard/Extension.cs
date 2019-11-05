namespace Goedel.Cryptography.Standard {

    /// <summary>
    /// Utility class for addressing containers.
    /// </summary>
    public static class ContainerFramework {

        /// <summary>
        /// Prefix for test containers
        /// </summary>
        public const string PrefixTest = "TEST:mmm:";

        /// <summary>
        /// Prefix for production containers.
        /// </summary>
        public const string PrefixProduction = "mmm:";


        /// <summary>
        /// Container prefix
        /// </summary>
        /// <returns>The container prefix</returns>
        public static string Prefix() => Goedel.Cryptography.KeyPair.TestMode ? PrefixTest : PrefixProduction;

        /// <summary>
        /// Generate a key container name from a UDF fingerprint.
        /// </summary>
        /// <param name="UDF">UDF fingerprint value.</param>
        /// <returns>The container name.</returns>
        public static string Name(string UDF) => (Prefix() + UDF);
        }
    }
