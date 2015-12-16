using System;
using System.Collections.Generic;
using Goedel.Registry;

namespace Goedel.Mesh {
    public partial class DeviceEntry {

        /// <summary>
        /// Create a device entry for the specified profile.
        /// </summary>
        /// <param name="DeviceProfile"></param>
        public DeviceEntry(DeviceProfile DeviceProfile) {
            UDF = DeviceProfile.UDF;
            }

        /// <summary>
        /// Set the decrypt parameters for the specified device.
        /// </summary>
        /// <param name="PublicKey"></param>
        public void SetDecrypt(PublicKey PublicKey) {
            // Here we extract the private key parameters and 
            // encrypt them under the device key.
            }

        /// <summary>
        /// Convenience routine, used in a device entry request
        /// </summary>
        /// <param name="Signer"></param>
        public void MakeSignature(PublicKey Signer) {
            }

        /// <summary>
        /// Create an authentication entry.
        /// </summary>
        /// <param name="Signer"></param>
        public void MakeAuthentication(PublicKey Signer) {
            }

        }
    }
