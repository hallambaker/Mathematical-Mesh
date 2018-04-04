using System;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Mesh.Portal.Client;
using Goedel.Recrypt;
using Goedel.Utilities;

namespace Goedel.Recrypt.Client {







    /// <summary>
    /// Extensions class
    /// </summary>
    public static partial class Extension {


        /// <summary>
        /// Create a new recryption session
        /// </summary>
        /// <param name="SessionPersonal"></param>
        /// <param name="AccountID"></param>
        /// <param name="Devices"></param>
        /// <returns></returns>
        public static SessionRecrypt CreateRecryptProfile (
                this SessionPersonal SessionPersonal,
                string AccountID = null,
                List<SignedDeviceProfile> Devices = null) {


            var RecryptProfile = new RecryptProfile(SessionPersonal.PersonalProfile, AccountID);

            Devices = Devices ?? SessionPersonal.PersonalProfile.Devices;

            // Add all devices as administrator devices
            foreach (var Device in Devices) {
                RecryptProfile.AddDevice(Device.DeviceProfile, true);
                }

            var SessionRecrypt = new SessionRecrypt(SessionPersonal, RecryptProfile);

            SessionRecrypt.Write();
            SessionPersonal.Write();

            return SessionRecrypt;
            }


        public static RecryptionKey GetEncryptionKey (
                this SessionPersonal SessionPersonal,
                string RecryptionGroup) {

            // create a client 
            var Client = new RecryptClient(RecryptionGroup);

            // request the recryption key
            var Response = Client.RecryptKey(RecryptionGroup);

            var RecryptionKey = Response.RecryptionKey;

            RecryptionKey.RecrytionGroup = RecryptionGroup;

            return RecryptionKey;
            }


        public static RecryptionGroup GetRecryptionGroup (
                this SessionPersonal SessionPersonal,
                string RecryptionGroup) {

            // create a client 
            var Client = new RecryptClient(RecryptionGroup);

            // request the recryption key
            var Response = Client.GetGroup(RecryptionGroup);

            return Response.RecryptionGroup;
            }
        }
    }
