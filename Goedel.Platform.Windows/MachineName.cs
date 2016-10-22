


namespace Goedel.Platform {

    /// <summary>
    /// Extract machine properties from the platform
    /// </summary>
    public class Environment {

        /// <summary>
        /// The machine name.
        /// </summary>
        public static string MachineName {
            get {
                return System.Environment.MachineName;

                }

            }
        }
    }
