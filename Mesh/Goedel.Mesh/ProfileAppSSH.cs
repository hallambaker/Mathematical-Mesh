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

    public static partial class Extension {

        /// <summary>
        /// Convenience function that converts a generic Signed Profile returned
        /// by the Mesh to a PasswordProfile.
        /// </summary>
        /// <param name="SignedProfile">Generic signed profile</param>
        /// <returns>Inner PasswordProfile if the Signed Profile contains one,
        /// otherwise null.</returns>
        public static SSHProfile SSHProfile (this SignedProfile SignedProfile) {
            return SignedProfile.Profile as SSHProfile;
            }
        }


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
        public SSHProfile () {
            }


        /// <summary>
        /// Create a new personal profile.
        /// </summary>
        /// <param name="PersonalProfile">The parent personal profile</param>
        public SSHProfile (PersonalProfile PersonalProfile) {
            Private = new SSHProfilePrivate() { };

            // Register with the application.
            ApplicationProfileEntry = PersonalProfile.Add(this);
            }

        /// <summary>
        /// Add the specified device to the linked personal profile and 
        /// create any device specific entries in the private profile.
        /// </summary>
        /// <param name="Device">The device to add.</param>
        /// <param name="Administration">If true, enroll as an administration device.</param>
        /// <param name="ApplicationDevicePublic">Per device public data,  if required.</param>
        public override void AddDevice (
                DeviceProfile Device,
                bool Administration = false,
                ApplicationDevicePublic ApplicationDevicePublic = null) {

            Devices = Devices ?? new List<ApplicationDevicePublic>();
            DevicePrivate = DevicePrivate ?? new List<JoseWebEncryption>();

            var DevicePublic = ApplicationDevicePublic as SSHDevicePublic ?? new SSHDevicePublic();

            var EncryptKeyPair = MakeApplicationKeyPair(KeyType.AAK, CryptoAlgorithmID.RSAExch, Device,
                    out var PublicKey, out var PrivateKey);

            DevicePublic.DeviceUDF = Device.UDF;
            DevicePublic.DeviceDescription = DevicePublic.DeviceDescription ?? Device.Name;
            DevicePublic.PublicKey = PublicKey;
            Devices.Add(DevicePublic);

            var SSHDevicePrivate = new SSHDevicePrivate() {
                DevicePrivateKey = PrivateKey
                };

            var EncryptedDevicePrivate = Device.Encrypt(SSHDevicePrivate);
            DevicePrivate.Add(EncryptedDevicePrivate);

            // Create entries for administrative, decryption keys
            ApplicationProfileEntry.AddDevice(Device, Administration);
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
