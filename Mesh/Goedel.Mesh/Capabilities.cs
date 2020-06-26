using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;

using System;
using System.Collections.Generic;
using System.IO;


namespace Goedel.Mesh {
    public partial class CryptographicCapability {

        public CryptographicCapability() {

            }

        public CryptographicCapability(KeyPair keyPair) {
            KeyData = new KeyData(keyPair);
            }

        }

    public partial class CapabilityEncryption {

        public CapabilityEncryption() {

            }


        public CapabilityEncryption(KeyPair keyPair) : base(keyPair) {
            Role = "Encrypt";
            }

        }

    public partial class CapabilityAdministrator {

        public CapabilityAdministrator() {

            }


        public CapabilityAdministrator(KeyPair keyPair) : base(keyPair) {

            }

        }


    public partial class CapabilityVerification {
        public CapabilityVerification() {

            }


        public CapabilityVerification(KeyPair keyPair) : base(keyPair) {

            }
        }

    public partial class CapabilityAuthentication {
        public CapabilityAuthentication() {

            }


        public CapabilityAuthentication(KeyPair keyPair) : base(keyPair) {

            }
        }

    }
