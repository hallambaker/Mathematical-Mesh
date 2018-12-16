using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography.Dare;


namespace Goedel.Mesh {
    public static class Extensions {

        public static ProfileMaster GetProfileMaster(this DareMessage dareMessage) {
            var profile = ProfileMaster.FromJSON(dareMessage.GetBodyReader(), true);
            // Task: here put code to verify the signature of the message against the master signature.

            return profile;
            }

        public static ProfileDevice GetProfileDevice(this DareMessage dareMessage) {
            var profile = ProfileDevice.FromJSON(dareMessage.GetBodyReader(), true);
            // Task: here put code to verify the signature of the message against the master signature.

            return profile;
            }


        }
    }
