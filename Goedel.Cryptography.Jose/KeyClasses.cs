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
using System.Security.Cryptography;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;

namespace Goedel.Cryptography.Jose {

    public partial class Key {

        /// <summary>
        /// Extract a KeyPair object from the JOSE data structure.
        /// </summary>
        /// <returns></returns>
        public virtual KeyPair GetKeyPair () {
            return null;
            }

        /// <summary>
        /// Return the public portion of the key pair.
        /// </summary>
        /// <param name="KeyPair">The key pair.</param>
        /// <returns>Public portion.</returns>
        public static Key GetPublic(KeyPair KeyPair) {
            if (KeyPair as RSAKeyPair != null) {
                return new PublicKeyRSA(KeyPair as RSAKeyPair);
                }
            return null;
            }

        /// <summary>
        /// Return the private portion of the keypair.
        /// </summary>
        /// <param name="KeyPair">The key pair.</param>
        /// <returns>The private data.</returns>
        public static Key GetPrivate(KeyPair KeyPair) {
            if (KeyPair as RSAKeyPair != null) {
                return new PrivateKeyRSA(KeyPair as RSAKeyPair);
                }
            return null;
            }

        }


    public partial class PublicKeyRSA  {

        /// <summary>
        /// Construct from the spcified RSA Key
        /// </summary>
        /// <param name="KeyPair">An RSA key Pair.</param>
        public PublicKeyRSA(RSAKeyPair KeyPair) {
            kid = KeyPair.UDF;
            var Provider = KeyPair.Provider;
            var Parameters = Provider.ExportParameters(false);

            n = Parameters.Modulus;
            e = Parameters.Exponent;
            }

        /// <summary>
        /// Return the RSAParameters object.
        /// </summary>
        public virtual RSAParameters RSAParameters() {
            var RSAParameters = new RSAParameters();
            RSAParameters.Modulus = n;
            RSAParameters.Exponent = e;

            return RSAParameters;
            }

        /// <summary>
        /// Extract an RSA KeyPair.
        /// </summary>
        /// <returns></returns>
        public override KeyPair GetKeyPair() {
            var Parameters = RSAParameters();
            return new RSAKeyPair(Parameters);
            }

        }


    public partial class PrivateKeyRSA {

        /// <summary>
        /// Construct from the spcified RSA Key
        /// </summary>
        /// <param name="KeyPair">An RSA key Pair.</param>
        public PrivateKeyRSA(RSAKeyPair KeyPair) {
            kid = KeyPair.UDF;
            var Provider = KeyPair.Provider;
            var Parameters = Provider.ExportParameters(true);

            n = Parameters.Modulus;
            e = Parameters.Exponent;
            d = Parameters.D;
            p = Parameters.P;
            q = Parameters.Q;
            dp = Parameters.DP;
            dq = Parameters.DQ;
            qi = Parameters.InverseQ;
            }

        /// <summary>
        /// Return the RSAParameters object.
        /// </summary>
        public override RSAParameters RSAParameters() {

            var RSAParameters = new RSAParameters();
            RSAParameters.Modulus = n;
            RSAParameters.Exponent = e;
            RSAParameters.D = d;
            RSAParameters.P = p;
            RSAParameters.Q = q;
            RSAParameters.DP = dp;
            RSAParameters.DQ = dq;
            RSAParameters.InverseQ = qi;

            return RSAParameters;
            }

        }

    }
