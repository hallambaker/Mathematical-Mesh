//   Copyright © 2015 by Comodo Group Inc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  

using System;
using System.Collections.Generic;
using Goedel.Registry;
using Goedel.Persistence;
using Goedel.LibCrypto;
using Goedel.LibCrypto.PKIX;

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

        /// <summary>
        /// Returns the private profile as a block of JSON encoded bytes ready for
        /// encryption.
        /// </summary>
        protected override byte[] GetPrivateData {
            get { return _Private.GetBytes(); }
            }

        /// <summary>
        /// Construct an empty network profile for the specified personal profile.
        /// </summary>
        /// <param name="UserProfile"></param>
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

        ///// <summary>
        ///// Make a device entry for the application
        ///// </summary>
        ///// <param name="DeviceProfile">Device profile of device to add.</param>
        ///// <returns>The device entry.</returns>
        //public override DeviceEntry MakeEntry(SignedDeviceProfile DeviceProfile) {
        //    var DeviceEntry = base.MakeEntry(DeviceProfile);
        //    //DeviceEntry.EncryptedKey = MakeDecryptInfo(DeviceProfile.Signed);
        //    return DeviceEntry;
        //    }

        /// <summary>
        /// Add a DNS entry to the network configuration.
        /// </summary>
        /// <param name="Connection">The DNS connection data to use.</param>
        public void AddDNS(Connection Connection) {
            Private.DNS = Private.DNS == null ? new List<Connection>() : Private.DNS;
            Private.DNS.Add(Connection);
            }

        }

    public partial class NetworkProfilePrivate {

        }


    }
