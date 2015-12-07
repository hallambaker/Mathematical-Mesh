using System;
using System.Collections.Generic;
using Goedel.Protocol;
using Goedel.LibCrypto;
using NET = System.Security.Cryptography;

namespace Goedel.Cryptography.Jose {

    /// <summary>
    /// Represents a JOSE KeyData structure
    /// </summary>
    public partial class KeyData {

        /// <summary>
        /// Build a KeyData object from a reference to a key. This may be a certificate,
        /// a certificate reference (URL and hash), a UDF value, etc.
        /// </summary>
        /// <param name="KeyHandle"></param>
        public KeyData(KeyHandle KeyHandle) {


            kid = KeyHandle.UDF; // The Key identifier is always the UDF of the key.


            }

        /// <summary>
        /// Builds a KeyData object from a key.
        /// </summary>
        /// <param name="CryptoKey"></param>
        public KeyData(CryptoKey CryptoKey) {


            }


        /// <summary>
        /// Returns a key handle for the specified Key Data.
        /// </summary>
        public KeyHandle KeyHandle {
            get {
                return GetKeyHandle ();
                }
            }

        KeyHandle GetKeyHandle() {
            return null;
            }


        }



    /// <summary>
    /// Represents an RSA Private Key.
    /// </summary>
    public partial class PublicKeyRSA {

        /// <summary>
        /// Construct from a .NET RSA Parameters structure.
        /// </summary>
        /// <param name="RSAParameters"></param>
        public PublicKeyRSA(NET.RSAParameters RSAParameters) {
            this.n = RSAParameters.Modulus;
            this.e = RSAParameters.Exponent;
            }
        }

    /// <summary>
    /// Represents an RSA Private Key.
    /// </summary>
    public partial class PrivateKeyRSA {

        /// <summary>
        /// Construct from a .NET RSA Parameters structure.
        /// </summary>
        /// <param name="RSAParameters"></param>
        public PrivateKeyRSA(NET.RSAParameters RSAParameters) : base (RSAParameters) {
            this.d = RSAParameters.D;
            this.p = RSAParameters.P;
            this.q = RSAParameters.Q;
            this.dp = RSAParameters.DP;
            this.dq = RSAParameters.DQ;
            this.qi = RSAParameters.Q;
            }


        }
    }
