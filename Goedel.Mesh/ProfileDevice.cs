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
using Goedel.Protocol;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PKIX;

namespace Goedel.Mesh {

    /// <summary>
    /// Partial class for Device Profile
    /// </summary>
    public partial class DeviceProfile : Profile {

        /// <summary>
        /// The signed device profile
        /// </summary>
        public SignedDeviceProfile SignedDeviceProfile { get; set; }


        /// <summary>
        /// The profile fingerprint value is the device signature key.
        /// </summary>
        public override string UDF {
            get => DeviceSignatureKey?.UDF; 
            }


        /// <summary>
        /// Construct profile for the specified device.
        /// </summary>
        /// <param name="Name">The name of the device within profiles.</param>
        /// <param name="Description">Description of the device.</param>
        /// <param name="SignatureAlgorithmID">The public key algorithm to use for signature keys.</param>
        /// <param name="ExchangeAlgorithmID">The public key algorithm to use for encryption keys.</param>
        /// <param name="SignedDeviceProfile">The enclosing signed device profile</param>
        public DeviceProfile(string Name, string Description,
                    CryptoAlgorithmID SignatureAlgorithmID = CryptoAlgorithmID.Default, 
                    CryptoAlgorithmID ExchangeAlgorithmID = CryptoAlgorithmID.Default,
                    SignedDeviceProfile SignedDeviceProfile = null) {

            Names = new List<string>() { Name};

            this.Description = Description;

            DeviceSignatureKey = PublicKey.Generate (KeyType.DSK, SignatureAlgorithmID);
            DeviceAuthenticationKey = PublicKey.Generate(KeyType.DAK, SignatureAlgorithmID);
            DeviceEncryptiontionKey = PublicKey.Generate(KeyType.DEK, ExchangeAlgorithmID);

            Identifier = DeviceSignatureKey.UDF;

            Sign();
            }


        /// <summary>
        /// Sign the current profile. It is not necessary to specify the signature
        /// key because the only valid signature key for a device profile is the
        /// one identified by the UDF of the profile.
        /// </summary>
        /// <param name="UDF">Specify the signature key by identifier</param>
        /// <param name="KeyPair">Specify the signature key by key handle</param>
        /// <param name="Encoding">The encoding for the inner data</param>
        public override SignedProfile Sign (string UDF = null, KeyPair KeyPair = null,
                        DataEncoding Encoding = DataEncoding.JSON) {
            SignedDeviceProfile = new SignedDeviceProfile(this, Encoding);
            return SignedDeviceProfile;
            }

        }
    }
