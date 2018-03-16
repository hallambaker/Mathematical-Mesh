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
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PKIX;
using Goedel.Mesh;

namespace Goedel.Confirm {



    /// <summary>
    /// Describes the profile for the Mesh/Confirm application. 
    /// </summary>
    public partial class ConfirmProfile : ApplicationProfile {

        /// <summary>
        /// The public parameter entry for this particular device.
        /// </summary>
        public ConfirmDevicePublic ConfirmDevicePublic => ApplicationDevicePublic as ConfirmDevicePublic;

        /// <summary>
        /// The portion of the profile that is encrypted in the mesh.
        /// </summary>
        public ConfirmPrivate Private {
            get => ApplicationProfilePrivate as ConfirmPrivate;
            set => ApplicationProfilePrivate = value;
            }

        /// <summary>
        /// The portion of the profile that is encrypted in the mesh.
        /// </summary>
        public ConfirmDevicePrivate DecryptedDevicePrivate => ApplicationDevicePrivate as ConfirmDevicePrivate;


        /// <summary>
        /// Returns the private profile as a block of JSON encoded bytes ready for
        /// encryption.
        /// </summary>
        protected override byte[] GetPrivateData => Private?.GetBytes();


        /// <summary>
        /// Create a new personal profile.
        /// </summary>
        public ConfirmProfile () {
            }


        /// <summary>
        /// Create a new recryption profile with private profiles for the specified device.
        /// </summary>
        /// <param name="PersonalProfile">The personal profile to create this under</param>
        /// <param name="AccountID">The account ID for this entry</param>
        /// <param name="Friendly">Friendly Name (defaults to AccountID)</param>
        public ConfirmProfile (PersonalProfile PersonalProfile, string AccountID, string Friendly = null) {
            Account = AccountID;
            this.PersonalProfile = PersonalProfile;

            AuthenticationKeys = new List<PublicKey>();
            SignatureKeys = new List<PublicKey>();
            DevicePrivate = new List<JoseWebEncryption>();

            ApplicationProfileEntry = PersonalProfile.Add(this);
            ApplicationProfileEntry.Friendly = Friendly ?? AccountID;
            }

        /// <summary>
        /// Create device specific data.
        /// </summary>
        /// <param name="Device">The device to add.</param>
        /// <param name="Administration">If true, create an administration entry</param>
        public void AddDevice (DeviceProfile Device, bool Administration = true) {
            DevicePrivate = DevicePrivate ?? new List<JoseWebEncryption>();

            var AuthPair = PublicKey.Generate(KeyType.AAK, CryptoAlgorithmID.RSAExch);
            var AuthPublic = new PublicKey() { PublicParameters = AuthPair.PublicParameters };
            var AuthPrivate = MakeDevicePrivateKey(AuthPair, Device);

            var SignPair = PublicKey.Generate(KeyType.ASK, CryptoAlgorithmID.RSASign);
            var SignPublic = new PublicKey() { PublicParameters = SignPair.PublicParameters };
            var SignPrivate = MakeDevicePrivateKey(SignPair, Device);

            AuthenticationKeys.Add(AuthPublic);
            SignatureKeys.Add(SignPublic);

            var DevicePrivateEntry = new ConfirmDevicePrivate() {
                AuthPrivateKey = AuthPrivate ,
                SignPrivateKey = SignPrivate 
                };

            var EncryptedDevicePrivate = Device.Encrypt(DevicePrivateEntry);
            DevicePrivate.Add(EncryptedDevicePrivate);

            // Create entries for administrative, decryption keys
            ApplicationProfileEntry.AddDevice(Device, Administration);
            }

        }



    }
