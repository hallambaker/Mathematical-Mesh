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
using Goedel.Cryptography.PKIX;

using System.Security.Cryptography;

namespace Goedel.Cryptography.Standard {

    /// <summary>
    /// Formatting class for representing RSA Public Keys in ASN.1 and
    /// calculating the PKIX keyinfo version of the UDF fingerprint.
    /// </summary>
    public partial class Factory {

        /// <summary>
        /// Create instance from RSAParameters structure.
        /// </summary>
        /// <param name="RSAParameters">Input parameters in System.Security.Cryotography format</param>
        /// <returns>The public key</returns>
        public static PkixPublicKeyRsa RSAPublicKey(RSAParameters RSAParameters) {
            var RSAPublicKey = new PkixPublicKeyRsa() {
                Modulus = RSAParameters.Modulus,
                PublicExponent = RSAParameters.Exponent
                };
            return RSAPublicKey;
            }

        }
    }
