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
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PKIX;
using Goedel.Mesh.Portal.Client;
using Goedel.Protocol;

namespace Goedel.Recrypt {

    /// <summary>Extension methods for recryption</summary>
    public static partial class Extension {

        /// <summary>
        /// Convenience function that converts a generic Signed Profile returned
        /// by the Mesh to a PasswordProfile.
        /// </summary>
        /// <param name="SignedProfile">Generic signed profile</param>
        /// <returns>Inner PasswordProfile if the Signed Profile contains one,
        /// otherwise null.</returns>
        public static RecryptProfile RecryptProfile (this SignedProfile SignedProfile) {
            return SignedProfile.Profile as RecryptProfile;
            }





        }


    // Convenience routines for our two applications defined to date

    // In general it is useful to be able to consider a bundle of passwords 
    // as being part of the same application profile. 
    public partial class RecryptProfile : ApplicationProfile {

        public override string ShortID => Account;


        /// <summary>
        /// The root of trust to which the profile is bound
        /// </summary>
        public string PersonalUDF => PersonalProfile?.UDF;

        /// <summary>
        /// Create a new recryption profile.
        /// </summary>
        public RecryptProfile () {
            }

        /// <summary>The encryption pair</summary>
        public PublicKey EncryptPair {set; private get;}

        /// <summary>The signature pair</summary>
        public PublicKey SignPair { set; private get; }

        /// <summary>
        /// Create a new recryption profile with private profiles for the specified device.
        /// At present a single recryption key is generated that is accessible to every 
        /// authorized device.
        /// </summary>
        /// <param name="PersonalProfile">The personal profile</param>
        /// <param name="AccountID">The account identifier</param>
        /// <param name="Friendly">The friendly name</param>
        public RecryptProfile (PersonalProfile PersonalProfile, string AccountID, string Friendly = null) {
            Account = AccountID;
            this.PersonalProfile = PersonalProfile;

            EncryptPair = PublicKey.Generate(KeyType.AEK, CryptoAlgorithmID.RSAExch);
            var EncryptPublic = new PublicKey() { PublicParameters = EncryptPair.PublicParameters };

            SignPair = PublicKey.Generate(KeyType.ASK, CryptoAlgorithmID.RSASign);
            var SignPublic = new PublicKey() { PublicParameters = SignPair.PublicParameters };

            EncryptKeys = new List<PublicKey>() { EncryptPublic };
            AuthKeys = new List<PublicKey>() { SignPublic };

            // Register with the application.
            ApplicationProfileEntry = PersonalProfile.Add(this);
            ApplicationProfileEntry.Friendly = Friendly ?? AccountID;



            }


        /// <summary>
        /// Create device specific data.
        /// </summary>
        /// <param name="Device">The device to add.</param>
        /// <param name="Administration">If true, create an administration entry</param>
        public override void AddDevice (DeviceProfile Device, 
                    bool Administration=true,
                    ApplicationDevicePublic ApplicationDevicePublic = null) {

            DevicePrivate = DevicePrivate ?? new List<JoseWebEncryption>();

            var EncryptPrivate = MakeDevicePrivateKey(EncryptPair, Device);
            var SignPrivate = MakeDevicePrivateKey(SignPair, Device);

            var DevicePrivateEntry = new RecryptDevicePrivate() {
                DecryptKeys = new List<PublicKey> { EncryptPrivate },
                SignKeys = new List<PublicKey> { SignPrivate }
                };

            var EncryptedDevicePrivate = Device.Encrypt(DevicePrivateEntry);
            DevicePrivate.Add(EncryptedDevicePrivate);

            // Create entries for administrative, decryption keys
            ApplicationProfileEntry.AddDevice(Device, Administration);
            }
        }
    }
