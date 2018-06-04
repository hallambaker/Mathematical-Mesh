using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Cryptography.PKIX;

namespace Goedel.Cryptography {



    /// <summary>
    /// Extensions class for deriving UDF from key parameters
    /// </summary>
    public static class KeyExtensions {

        /// <summary>
        /// Calculate UDF data value for public key parameters
        /// </summary>
        /// <param name="Key">The key to calculate the fingerprint of</param>
        /// <returns>The binary fingerprint value</returns>
        public static byte[] UDFBytes(this IPKIXPublicKey Key) => Cryptography.UDF.FromKeyInfo(Key.PublicParameters.DER());

        /// <summary>
        /// Calculate UDF fingerprint presentation for public key parameters
        /// </summary>
        /// <param name="Key">The key to calculate the fingerprint of</param>
        /// <returns>The fingerprint presentation</returns>
        public static string UDF(this IPKIXPublicKey Key) {
            var Bytes = Key.UDFBytes();
            return Cryptography.UDF.ToString(Bytes);
            }


        /// <summary>
        /// Wrap key in a PrivateKeyInfo structure (unencrypted).
        /// </summary>
        /// <param name="Key">Key to wrap.</param>
        /// <returns>The PrivateKeyInfo structure.</returns>
        public static PrivateKeyInfo PrivateKeyInfo(this IPKIXPrivateKey Key) => new PrivateKeyInfo() {
            Version = 0,
            PrivateKeyAlgorithm = new AlgorithmIdentifier(Key.OID),
            PrivateKey = Key.DER(),
            Attributes = null
            };


        /// <summary>
        /// Returns true if the key is exportable, otherwise false.
        /// </summary>
        /// <param name="KeySecurity">The key security specifier.</param>
        /// <returns>True if the value is KeySecurity.Master or Exportable</returns>
        public static bool IsExportable(this KeySecurity KeySecurity) => (KeySecurity == KeySecurity.Master | KeySecurity == KeySecurity.Exportable
                | KeySecurity == KeySecurity.Application);

        /// <summary>
        /// Returns true if the key is persisted, otherwise false.
        /// </summary>
        /// <param name="KeySecurity">The key security specifier.</param>
        /// <returns>True if the value is KeySecurity.Master, Admin or Device</returns>
        public static bool IsPersisted(this KeySecurity KeySecurity) => (KeySecurity == KeySecurity.Master | KeySecurity == KeySecurity.Admin |
                    KeySecurity == KeySecurity.Device | KeySecurity == KeySecurity.Application);


        }
    }
