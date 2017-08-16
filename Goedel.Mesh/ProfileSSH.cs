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
using Goedel.Utilities;
using Goedel.Registry;
using Goedel.Persistence;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography.KeyFile;

namespace Goedel.Mesh {

    // Convenience routines for our two applications defined to date

    // In general it is useful to be able to consider a bundle of passwords 
    // as being part of the same application profile. 
    public partial class SSHProfile : ApplicationProfile {

        /// <summary>
        /// The public parameter entry for this particular device.
        /// </summary>
        public SSHDevicePublic SSHDevicePublic {
            get => ApplicationDevicePublic as SSHDevicePublic;
            }

        /// <summary>
        /// The portion of the profile that is encrypted in the mesh.
        /// </summary>
        public SSHProfilePrivate Private {
            get => ApplicationProfilePrivate as SSHProfilePrivate;
            set => ApplicationProfilePrivate = value;
            }

        /// <summary>
        /// The portion of the profile that is encrypted in the mesh.
        /// </summary>
        public SSHDevicePrivate DecryptedDevicePrivate {
            get => ApplicationDevicePrivate as SSHDevicePrivate;
            }

        /// <summary>
        /// Create a new personal profile.
        /// </summary>
        /// <param name="MakePrivate">If true, a private profile will be created.</param>
        public SSHProfile (bool MakePrivate = false) {
            if (MakePrivate) {
                Private = new SSHProfilePrivate();
                }
            }


        

        /// <summary>
        /// Create new SSH profile
        /// </summary>
        /// <param name="PersonalProfile"></param>
        /// <returns></returns>
        public static SSHProfile Create (PersonalProfile PersonalProfile) {
            return new SSHProfile(true);
            }

        /// <summary>
        /// Convenience function that converts a generic Signed Profile returned
        /// by the Mesh to a PasswordProfile.
        /// </summary>
        /// <param name="SignedProfile">Generic signed profile</param>
        /// <returns>Inner PasswordProfile if the Signed Profile contains one,
        /// otherwise null.</returns>
        public static SSHProfile Get(SignedProfile SignedProfile) {
            return SignedProfile.Profile as SSHProfile;
            }


        /// <summary>
        /// Create the public (and private) profiles for a device. This may be called by either
        /// the administrator or on the device itself, depending on when the application is being
        /// initialized.
        /// </summary>
        /// <param name="Device">The profile of the device to initialize</param>
        /// <param name="ApplicationDevicePrivate"></param>
        /// <returns></returns>
        public override ApplicationDevicePublic CreateDeviceProfiles (DeviceProfile Device, 
                    out ApplicationDevicePrivate ApplicationDevicePrivate) {

            var IsLocal = Device.DeviceSignatureKey.PrivateKey != null;

            //var KeyStorage = IsLocal ? KeyType.DAK : KeyType.AAK;
            var KeyStorage = KeyType.AAK;
            var KeyPair = PublicKey.Generate(KeyStorage, CryptoAlgorithmID.RSASign);

            var KeyPublic = new PublicKey() {
                PublicParameters = KeyPair.PublicParameters
                };

            ApplicationDevicePrivate = null;
            if (IsLocal) {
                ApplicationDevicePrivate = new SSHDevicePrivate() {
                    KeyUDF = KeyPair.UDF
                    };
                }
            else {
                var KeyPrivate = new PublicKey() { PrivateParameters = KeyPair.PrivateParameters };
                ApplicationDevicePrivate = new SSHDevicePrivate() {
                    DevicePrivateKey = KeyPrivate
                    };
                }

            var ApplicationDevicePublic = new SSHDevicePublic() {
                DeviceUDF = Device.UDF,
                DeviceDescription = Device.Name,
                PublicKey = KeyPublic
                };

            return ApplicationDevicePublic;
            }


        }


    public partial class SSHDevicePublic {

        /// <summary>
        /// Convert to SSH file entry.
        /// </summary>
        /// <param name="PortalID"></param>
        /// <returns></returns>
        public string ToOpenSSH (string PortalID) {
            var KeyPair = PublicKey.KeyPair;
            var Text = KeyPair.ToOpenSSH();
            var DeviceDescription = this.DeviceDescription ?? "-";
            return String.Format("{0} mmm:{1} [{2}]", Text, PortalID, DeviceDescription);
            }

        }



    public partial class SSHProfilePrivate {
        /// <summary>
        /// Initializer
        /// </summary>
        public SSHProfilePrivate () {
            HostEntries = new List<HostEntry>();
            }
        }

    }
