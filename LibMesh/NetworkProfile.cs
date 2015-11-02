using System;
using System.Collections.Generic;
using Goedel.Registry;
using Goedel.Persistence;
using Goedel.CryptoLibNG;
using Goedel.CryptoLibNG.PKIX;

namespace Goedel.Mesh {

    // Convenience routines for our two applications defined to date

    // In general it is useful to be able to consider a bundle of passwords 
    // as being part of the same application profile. 
    public partial class NetworkProfile  {
        private NetworkProfilePrivate _Private;


        /// <summary>
        /// The portion of the profile that is encrypted in the mesh.
        /// </summary>
        public NetworkProfilePrivate Private {
            get {
                if (_Private == null) {
                    _Private = NetworkProfilePrivate.FromTagged(DecryptPrivate());
                    }
                return _Private;
                }
            }


        protected override byte[] GetPrivateData {
            get { return _Private.GetBytes(); }
            }

        public NetworkProfile (PersonalProfile UserProfile)
            : base(UserProfile, "NetworkProfile", null) {
            _Private = new NetworkProfilePrivate ();
            }


        /// <summary>
        /// Get the default password profile in the specified personal profile.
        /// </summary>
        /// <param name="UserProfile">Presonal profile to search.</param>
        /// <returns>Password application profile if found, null otherwise.</returns>
        public static NetworkProfile Get(PersonalProfile UserProfile) {
            //return UserProfile.GetApplication(typeof(PersonalProfile)) as NetworkProfile;


            return null;
            }

        /// <summary>
        /// Make a device entry for the application
        /// </summary>
        /// <param name="DeviceProfile">Device profile of device to add.</param>
        /// <returns>The device entry.</returns>
        public override DeviceEntry MakeEntry(SignedDeviceProfile DeviceProfile) {
            var DeviceEntry = base.MakeEntry(DeviceProfile);
            //DeviceEntry.EncryptedKey = MakeDecryptInfo(DeviceProfile.Signed);
            return DeviceEntry;
            }

        public void AddDNS(Connection Connection) {
            Private.DNS = Private.DNS == null ? new List<Connection>() : Private.DNS;
            Private.DNS.Add(Connection);
            }

        }

    public partial class NetworkProfilePrivate {

        }


    }
