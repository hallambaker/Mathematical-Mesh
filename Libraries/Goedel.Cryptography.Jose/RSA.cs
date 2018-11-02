using System;
using System.Collections.Generic;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;

namespace Goedel.Cryptography.Jose {

    /// <summary>
    /// Represents an RSA Public Key.
    /// </summary>
    public partial class PublicKeyRSA : Key {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public PublicKeyRSA () { }

        /// <summary>
        /// Construct from the specified RSA Key
        /// </summary>
        /// <param name="KeyPair">An RSA key Pair.</param>
        public PublicKeyRSA(KeyPairBaseRSA KeyPair) {
            Kid = KeyPair.UDF;
            var RSAPublicKey = KeyPair.PKIXPublicKeyRSA;

            N = RSAPublicKey.Modulus;
            E = RSAPublicKey.PublicExponent;
            }

        /// <summary>
        /// Construct from a PKIX RSAPublicKey structure.
        /// </summary>
        /// <param name="RSAPublicKey">RSA Public Key.</param>
        public PublicKeyRSA(PKIXPublicKeyRSA RSAPublicKey) {
            this.N = RSAPublicKey.Modulus;
            this.E = RSAPublicKey.PublicExponent;
            }


        /// <summary>
        /// Return the parameters as a PKIX RSAPublicKey structure;
        /// </summary>
        public virtual PKIXPublicKeyRSA PKIXPublicKeyRSA => new PKIXPublicKeyRSA() {
            Modulus = N,
            PublicExponent = E
            };

        /// <summary>
        /// Extract a KeyPair object from the JOSE data structure.
        /// </summary>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="keySecurity"/></param>
        /// <returns>The extracted key pair</returns>
        public override KeyPair GetKeyPair(KeySecurity keySecurity, KeyCollection keyCollection) {

            var PKIXParams = PKIXPublicKeyRSA;
            var KeyPair = KeyPairBaseRSA.KeyPairPublicFactory(PKIXParams);

            return KeyPair;
            }

        }

    /// <summary>
    /// Represents an RSA Private Key.
    /// </summary>
    public partial class PrivateKeyRSA {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public PrivateKeyRSA () { }

        /// <summary>
        /// Construct from the specified RSA Key
        /// </summary>
        /// <param name="KeyPair">An RSA key Pair.</param>
        public PrivateKeyRSA(KeyPairBaseRSA KeyPair) {
            Kid = KeyPair.UDF;
            var RSAPrivateKey = KeyPair.PKIXPrivateKeyRSA;
            N = RSAPrivateKey.Modulus;
            E = RSAPrivateKey.PublicExponent;
            D = RSAPrivateKey.PrivateExponent;
            P = RSAPrivateKey.Prime1;
            Q = RSAPrivateKey.Prime2;
            DP = RSAPrivateKey.Exponent1;
            DQ = RSAPrivateKey.Exponent2;
            QI = RSAPrivateKey.Coefficient;
            }


        /// <summary>
        /// Construct from a PKIX RSAPublicKey structure.
        /// </summary>
        /// <param name="RSAPrivateKey">RSA Public Key.</param>
        public PrivateKeyRSA(PKIXPrivateKeyRSA RSAPrivateKey) {
            N = RSAPrivateKey.Modulus;
            E = RSAPrivateKey.PublicExponent;
            D = RSAPrivateKey.PrivateExponent;
            P = RSAPrivateKey.Prime1;
            Q = RSAPrivateKey.Prime2;
            DP = RSAPrivateKey.Exponent1;
            DQ = RSAPrivateKey.Exponent2;
            QI = RSAPrivateKey.Coefficient;
            }

        /// <summary>
        /// Return the parameters as PKIX RSAPrivateKey structure;
        /// </summary>
        public virtual PKIXPrivateKeyRSA PKIXPrivateKeyRSA => new PKIXPrivateKeyRSA() {
            Modulus = N,
            PublicExponent = E,
            PrivateExponent = D,
            Prime1 = P,
            Prime2 = Q,
            Exponent1 = DP,
            Exponent2 = DQ,
            Coefficient = QI
            };



        /// <summary>
        /// Extract a KeyPair object from the JOSE data structure.
        /// </summary>
        /// <param name="keySecurity">The key security model</param>
        /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
        /// the value of <paramref name="keySecurity"/></param>
        /// <returns>The extracted key pair</returns>
        public override KeyPair GetKeyPair (KeySecurity keySecurity, KeyCollection keyCollection) {

            var PKIXParams = PKIXPublicKeyRSA;
            var KeyPair = KeyPairBaseRSA.KeyPairPrivateFactory(PKIXPrivateKeyRSA, keySecurity, keyCollection);

            return KeyPair;
            }

        }

    }
