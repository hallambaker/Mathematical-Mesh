using System;
using System.Collections.Generic;
using Goedel.Registry;

namespace Goedel.Mesh {
    public partial class DeviceEntry {

        public DeviceEntry(DeviceProfile DeviceProfile) {
            UDF = DeviceProfile.UDF;
            }

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

        public void MakeAuthentication(PublicKey Signer) {
            }

        }
    }
