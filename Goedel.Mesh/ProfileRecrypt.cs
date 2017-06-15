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
    public partial class RecryptProfile : ApplicationProfile {

        /// <summary>
        /// The portion of the profile that is encrypted in the mesh.
        /// </summary>
        public RecryptProfilePrivate Private {
            get => ApplicationProfilePrivate as RecryptProfilePrivate;
            set => ApplicationProfilePrivate = value;
            }

        /// <summary>
        /// Create a new personal profile.
        /// </summary>
        /// <param name="MakePrivate">If true, a private profile will be created.</param>
        public RecryptProfile(bool MakePrivate=false) {
            if (MakePrivate) {
                Private = new RecryptProfilePrivate();
                }
            }


        /// <summary>
        /// Convenience function that converts a generic Signed Profile returned
        /// by the Mesh to a PasswordProfile.
        /// </summary>
        /// <param name="SignedProfile">Generic signed profile</param>
        /// <returns>Inner PasswordProfile if the Signed Profile contains one,
        /// otherwise null.</returns>
        public static RecryptProfile Get(SignedProfile SignedProfile) {
            return SignedProfile.Profile as RecryptProfile;
            }


        /// <summary>
        /// Create the public (and private) profiles for a device. This may be called by either
        /// the administrator or on the device itself, depending on when the application is being
        /// initialized.
        /// </summary>
        /// <param name="Device">The profile of the device to initialize</param>
        /// <param name="ApplicationDevicePrivate"></param>
        /// <returns></returns>
        public override ApplicationDevicePublic CreateDeviceProfiles(
                    DeviceProfile Device,
                    out ApplicationDevicePrivate ApplicationDevicePrivate) {

            var EncryptPair = PublicKey.Generate(KeyType.AEK, CryptoAlgorithmID.DH);
            var EncryptPrivate = new PublicKey() { PrivateParameters = EncryptPair.PrivateParameters };
            var EncryptPublic = new PublicKey() { PrivateParameters = EncryptPair.PublicParameters };

            var AuthPair = PublicKey.Generate(KeyType.AAK, CryptoAlgorithmID.RSASign);
            var AuthPrivate = new PublicKey() { PrivateParameters = AuthPair.PrivateParameters };
            var AuthPublic = new PublicKey() { PrivateParameters = AuthPair.PublicParameters };

            ApplicationDevicePrivate = new RecryptDevicePrivate() {
                EncryptKey = EncryptPrivate,
                AuthKey = EncryptPublic
                };

            var ApplicationDevicePublic = new RecryptDevicePublic() {
                Identifier = Device.UDF,
                EncryptKey = AuthPublic,
                AuthKey = AuthPublic
                };

            return ApplicationDevicePublic;
            }


        }



    }
