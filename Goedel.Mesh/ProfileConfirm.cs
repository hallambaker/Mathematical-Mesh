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

    /// <summary>
    /// Describes the profile for the Mesh/Confirm application. 
    /// </summary>
    public partial class ConfirmProfile : ApplicationProfile {

        /// <summary>
        /// The public parameter entry for this particular device.
        /// </summary>
        public ConfirmDevicePublic ConfirmDevicePublic {
            get => ApplicationDevicePublic as ConfirmDevicePublic;
            }

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
        public ConfirmDevicePrivate DecryptedDevicePrivate {
            get => ApplicationDevicePrivate as ConfirmDevicePrivate;
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
        public ConfirmProfile(bool MakePrivate=false) {
            if (MakePrivate) {
                Private = new ConfirmPrivate();
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
        public override ApplicationDevicePublic CreateDeviceProfiles(DeviceProfile Device,
                    out ApplicationDevicePrivate ApplicationDevicePrivate) {

            var SignPair = PublicKey.Generate(KeyType.AAK, CryptoAlgorithmID.RSASign);
            var SignPrivate = new PublicKey() { PrivateParameters = SignPair.PrivateParameters };
            var SignPublic = new PublicKey() { PrivateParameters = SignPair.PublicParameters };

            var AuthPair = PublicKey.Generate(KeyType.AAK, CryptoAlgorithmID.RSASign);
            var AuthPrivate = new PublicKey() { PrivateParameters = AuthPair.PrivateParameters };
            var AuthPublic = new PublicKey() { PrivateParameters = AuthPair.PublicParameters };

            ApplicationDevicePrivate = new ConfirmDevicePrivate() {
                SignPrivateKey = SignPrivate,
                AuthPrivateKey = AuthPrivate
                };

            var ApplicationDevicePublic = new ConfirmDevicePublic() {
                Identifier = Device.UDF,
                SignPublicKey = SignPublic,
                AuthPublicKey = AuthPublic
                };

            return ApplicationDevicePublic;
            }


        }



    }
