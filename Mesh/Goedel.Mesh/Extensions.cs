using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {
    public static class Extensions {

        public static ProfileMesh GetProfileMaster(this DareEnvelope dareMessage) {
            var profile = ProfileMesh.FromJSON(dareMessage.GetBodyReader(), true);
            // Task: here put code to verify the signature of the message against the master signature.

            return profile;
            }

        public static ProfileDevice GetProfileDevice(this DareEnvelope dareMessage) {
            var profile = ProfileDevice.FromJSON(dareMessage.GetBodyReader(), true);
            // Task: here put code to verify the signature of the message against the master signature.

            return profile;
            }

        public static KeyPair LocatePrivate(this KeyCollection keyCollection, List<PublicKey> publicKeys) {

            foreach (var publicKey in publicKeys) {
                var keyPair = keyCollection.LocatePrivate(publicKey.UDF);
                if (keyPair != null) {
                    return keyPair;
                    }
                
                }
            return null;

            }
        }
    }
