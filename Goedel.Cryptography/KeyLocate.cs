using System.Security.Cryptography;


/*
 * This file collects all the delegation points where a platform 
 * specific implementation needs to provide overrides.
 * 
 */
namespace Goedel.Cryptography {
    partial class KeyPair {

        static string ContainerPrefix {
            get { return _TestMode ? "TEST:" : "mmm:"; }
            }

        /// <summary>
        /// Generate a key container name from a UDF fingerprint.
        /// </summary>
        /// <param name="UDF">UDF fingerprint value.</param>
        /// <returns>The container name.</returns>
        public static string ContainerName(string UDF) {
            return (ContainerPrefix + UDF);
            }

        }

    public partial class RSAKeyPair {


        /// <summary>
        /// Locate a key stored in the platform cryptographic key store.
        /// </summary>
        /// <param name="UDF"></param>
        /// <returns>cryptographic provider matching the specified fingerprint</returns>
        static RSACryptoServiceProvider PlatformLocateRSAProvider(string UDF) {
            var Parameters = new CspParameters();
            Parameters.KeyContainerName = ContainerName(UDF);
            return new RSACryptoServiceProvider(Parameters);
            }

        /// <summary>
        /// Retrieve the private key from local storage.
        /// </summary>
        public override void GetPrivate() {
            if (Provider.PublicOnly == false) {
                return;
                }
            Goedel.Debug.Trace.WriteLine("Get Private for {0}", UDF);

            var cp = new CspParameters();
            cp.KeyContainerName = ContainerName(UDF);

            _Provider = new RSACryptoServiceProvider(cp);

            }


        }
    }
