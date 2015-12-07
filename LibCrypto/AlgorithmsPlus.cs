using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.Protocol;
using Goedel.LibCrypto;

namespace Goedel.LibCrypto.PKIX {

    /// <summary>
    /// Formatting class for representing RSA Public Keys in ASN.1 and
    /// calculating the PKIX keyinfo version of the UDF fingerprint.
    /// </summary>
    public partial class RSAPublicKey {



        /// <summary>
        /// Create instance from RSAParameters structure.
        /// </summary>
        /// <param name="RSAParameters">Input parameters.</param>
        public RSAPublicKey(RSAParameters RSAParameters) {
            Modulus = RSAParameters.Modulus;
            PublicExponent = RSAParameters.Exponent;
            }

        }
    }
