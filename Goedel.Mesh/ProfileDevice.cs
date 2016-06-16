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
using Goedel.Debug;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PKIX;

namespace Goedel.Mesh {

    /// <summary>
    /// Partial class for Device Profile
    /// </summary>
    public partial class DeviceProfile : Profile {


        /// <summary>
        /// The profile fingerprint value is the device signature key.
        /// </summary>
        public override string UDF {
            get { return DeviceSignatureKey.UDF; }
            }

        /// <summary>
        /// Construct profile for the specified device.
        /// </summary>
        /// <param name="Name">The name of the device within profiles.</param>
        /// <param name="Description">Description of the device.</param>
        public DeviceProfile(string Name, string Description) : this 
              (Name, Description,
                        CryptoCatalog.Default.AlgorithmSignature,
                        CryptoCatalog.Default.AlgorithmExchange) {
            }

        /// <summary>
        /// Construct profile for the specified device.
        /// </summary>
        /// <param name="Name">The name of the device within profiles.</param>
        /// <param name="Description">Description of the device.</param>
        /// <param name="SignatureAlgorithmID">The public key algorithm to use for signature keys.</param>
        /// <param name="ExchangeAlgorithmID">The public key algorithm to use for encryption keys.</param>
        public DeviceProfile(string Name, string Description,
                    CryptoAlgorithmID SignatureAlgorithmID, 
                    CryptoAlgorithmID ExchangeAlgorithmID) {
            this.Names = new List<string>();
            this.Names.Add(Name);
            this.Description = Description;

            DeviceSignatureKey = PublicKey.Generate (KeyType.DSK, SignatureAlgorithmID);

            DeviceAuthenticationKey = PublicKey.Generate(KeyType.DAK,
                    SignatureAlgorithmID);

            DeviceEncryptiontionKey = PublicKey.Generate(KeyType.DEK, ExchangeAlgorithmID);

            Identifier = DeviceSignatureKey.UDF;
            }
        }
    }
