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

namespace Goedel.Mesh {

    // Convenience routines for our two applications defined to date

    // In general it is useful to be able to consider a bundle of passwords 
    // as being part of the same application profile. 
    public partial class SSHProfile : ApplicationProfile {

        /// <summary>
        /// The public type tag as a static element for efficiency
        /// </summary>
        public static string TypeTag { get => "SSHProfile"; } 

        private SSHProfilePrivate _Private;

        /// <summary>
        /// The portion of the profile that is encrypted in the mesh.
        /// </summary>
        public SSHProfilePrivate Private {
            get {
                if (_Private == null) {
                    var Plaintext = DecryptPrivate();
                    _Private = SSHProfilePrivate.FromTagged(Plaintext);
                    }
                return _Private;
                }
            }

        /// <summary>
        /// Returns the private profile as a block of JSON encoded bytes ready for
        /// encryption.
        /// </summary>
        protected override byte[] GetPrivateData {
            get => Private.GetBytes();
            }

        /// <summary>
        /// Create a new personal profile.
        /// </summary>
        /// <param name="MakePrivate">If true, a private profile will be created.</param>
        public SSHProfile(bool MakePrivate) {
            if (MakePrivate) {
                _Private = new SSHProfilePrivate();
                }
            }

        /// <summary>
        /// Initialize the private data
        /// </summary>
        protected override void _Initialize() {
            base._Initialize();
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

        ///// <summary>
        ///// Convenience function that converts a generic Signed Profile returned
        ///// by the Mesh to a PasswordProfile.
        ///// </summary>
        ///// <param name="SignedProfile">Generic signed profile</param>
        ///// <param name="PersonalProfile">The personal profile to link the Password Profile to.</param>
        ///// <returns>Inner PasswordProfile if the Signed Profile contains one,
        ///// otherwise null.</returns>
        //public static SSHProfile Get(SignedProfile SignedProfile,
        //            PersonalProfile PersonalProfile) {
        //    var Result = SignedProfile.Profile as SSHProfile;

        //    Assert.NotNull(Result, NotValidProfile.Throw);

        //    Result.Link(PersonalProfile);
        //    return (Result);
        //    }


        /// <summary>
        /// Add the specified device to the linked personal profile and 
        /// create any device specific entries in the private profile.
        /// </summary>
        /// <param name="DeviceProfile">The device to add.</param>
        /// <param name="Administration">If true, enroll as an administration device.</param>
        /// <param name="ApplicationDevicePublic">Per device public data,  if required.</param>

        public override void AddDevice(
                        DeviceProfile DeviceProfile, 
                        bool Administration = false,
                        ApplicationDevicePublic ApplicationDevicePublic = null) {
            SignedDeviceProfile SignedDevice = DeviceProfile.SignedDeviceProfile;

            if (ApplicationDevicePublic == null) {
                ApplicationDevicePublic = CreateDeviceProfiles(
                            DeviceProfile, out var ApplicationDevicePrivate);

                if (ApplicationDevicePrivate != null) {
                    // NYI: wrap private and add to DevicePrivate

                    var DevicePrivateBytes = ApplicationDevicePrivate.GetBytes();

                    var DeviceEncrypt = new JoseWebEncryption(DevicePrivateBytes);
                    DeviceEncrypt.AddRecipient(DeviceProfile.DeviceEncryptiontionKey.KeyPair);
                    DevicePrivate = DevicePrivate ?? new List<JoseWebEncryption>();
                    DevicePrivate.Add(DeviceEncrypt);
                    }

                }

            switch (ApplicationDevicePublic) {
                case SSHDevicePublic SSHDevicePublic: {
                    Devices = Devices ?? new List<SSHDevicePublic>();
                    Devices.Add(SSHDevicePublic);
                    break;
                    }
                }

            if (ApplicationProfileEntry != null) {
                ApplicationProfileEntry.AddDevice(DeviceProfile, Administration);
                }
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

            var KeyPair = PublicKey.Generate(KeyType.AAK, CryptoAlgorithmID.RSASign);
            var KeyPrivate = new PublicKey() { PrivateParameters = KeyPair.PrivateParameters };
            var KeyPublic = new PublicKey() { PrivateParameters = KeyPair.PublicParameters };

            ApplicationDevicePrivate = new SSHDevicePrivate() {
                DevicePrivateKey = KeyPrivate
                };

            var ApplicationDevicePublic = new SSHDevicePublic() {
                Identifier = Device.UDF,
                PublicKey = KeyPublic
                };

            return ApplicationDevicePublic;
            }


        }




    public partial class SSHProfilePrivate {
        /// <summary>
        /// Initializer
        /// </summary>
        protected override void _Initialize () {
            HostEntries = new List<HostEntry>();
            }
        }

    }
