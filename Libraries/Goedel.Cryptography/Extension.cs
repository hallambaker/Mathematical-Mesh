﻿using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;


namespace Goedel.Cryptography {
    /// <summary>
    /// A general parking ground for methods converting from platform to
    /// portable structures.
    /// </summary>
    public static class ExtensionMethods {

        /// <summary>
        /// Create PKIX RSAPrivateKey from RSAParameters structure.
        /// </summary>
        /// <param name="RSAParameters">The RSA Parameters in .NET format.</param>
        /// <returns>The private key in Goedel format.</returns> 
        public static PKIXPrivateKeyRSA RSAPrivateKey(this RSAParameters RSAParameters) => new PKIXPrivateKeyRSA() {

            Modulus = RSAParameters.Modulus,
            PublicExponent = RSAParameters.Exponent,
            PrivateExponent = RSAParameters.D,
            Prime1 = RSAParameters.P,
            Prime2 = RSAParameters.Q,
            Exponent1 = RSAParameters.DP,
            Exponent2 = RSAParameters.DQ,
            Coefficient = RSAParameters.InverseQ
            };

        /// <summary>
        /// Convert PKIX RSAPrivateKey to RSAParameters structure.
        /// </summary>
        /// <param name="RSAPrivateKey">RSA key  in System.Security.Cryptography form</param>
        /// <returns>The RSA parameters in PKIX format.</returns>
        public static RSAParameters RSAParameters(this PKIXPrivateKeyRSA RSAPrivateKey) => new RSAParameters {
            Modulus = RSAPrivateKey.Modulus,
            Exponent = RSAPrivateKey.PublicExponent,
            D = RSAPrivateKey.PrivateExponent,
            P = RSAPrivateKey.Prime1,
            Q = RSAPrivateKey.Prime2,
            DP = RSAPrivateKey.Exponent1,
            DQ = RSAPrivateKey.Exponent2,
            InverseQ = RSAPrivateKey.Coefficient,
            };

        /// <summary>
        /// Create PKIX RSAPublicKey from RSAParameters structure.
        /// </summary>
        /// <param name="RSAParameters">Input parameters  in System.Security.Cryptography form</param>
        /// <returns>The public key in Goedel format.</returns>
        public static PKIXPublicKeyRSA RSAPublicKey(this RSAParameters RSAParameters) => new PKIXPublicKeyRSA() {

            Modulus = RSAParameters.Modulus,
            PublicExponent = RSAParameters.Exponent
            };

        /// <summary>
        /// Convert PKIX RSAPublicKey to RSAParameters structure.
        /// </summary>
        /// <param name="RSAPublicKey">The RSA public key</param>
        /// <returns>The RSA parameters in System.Security.Cryotography. format.</returns>
        public static RSAParameters RSAParameters(this PKIXPublicKeyRSA RSAPublicKey) => new RSAParameters {
            Modulus = RSAPublicKey.Modulus,
            Exponent = RSAPublicKey.PublicExponent,
            };


        /// <summary>
        /// Convert binary data to portable certificate.
        /// </summary>
        /// <param name="Data">Input data</param>
        /// <returns>The certificate</returns>
        public static Certificate Certificate(this byte[] Data) {

            var X509Cert = new X509Certificate2(Data);
            var TBSCertificate = X509Cert.TBSCertificate();
            return new Certificate(Data, TBSCertificate);
            }

        /// <summary>
        /// Create a TBSCertificate item from a X509Certificate2 object.
        /// </summary>
        /// <param name="X509Cert">The X509 certificate to form TBS certificate from</param>
        /// <returns>The TBS certificate structure</returns>
        public static TBSCertificate TBSCertificate(this X509Certificate2 X509Cert) {

            var TBSCertificate = new TBSCertificate() {
                Version = X509Cert.Version,
                SerialNumber = BaseConvert.FromBase16(X509Cert.SerialNumber),
                Signature = X509Cert.SignatureAlgorithm.AlgorithmIdentifier(),
                //Issuer = Parse(X509Cert.IssuerName),
                Validity = new Validity(X509Cert.NotBefore, X509Cert.NotAfter),
                //Subject = Parse(X509Cert.SubjectName),
                Extensions = new List<Goedel.Cryptography.PKIX.Extension>(),
                };
            foreach (var Extension in X509Cert.Extensions) {
                //TBSCertificate.Extensions.Add(Parse(Extension));
                }
            return TBSCertificate;
            }

        /// <summary>
        /// Convert .NET OID to portable OID
        /// </summary>
        /// <param name="Oid">OID structure in System.Security.Cryptography form</param>
        /// <returns>Portable OID structure</returns>
        public static AlgorithmIdentifier AlgorithmIdentifier(this Oid Oid) => new AlgorithmIdentifier(Oid.ToString());

        /// <summary>
        /// Convert .NET Distinguished Name to portable list of names.
        /// </summary>
        /// <remarks>NOT IMPLEMENTED STUB</remarks>
        /// <param name="DN">Distinguished Name in System.Security.Cryptography form</param>
        /// <returns>Portable list of Names.</returns>
        public static List<Name> Names(this X500DistinguishedName DN) => null;

        /// <summary>
        /// Convert .NET extension to portable extensions 
        /// </summary>
        /// <remarks>NOT IMPLEMENTED STUB</remarks>
        /// <param name="X509Extension">The X509 extension in System.Security.Cryptography form</param>
        /// <returns>Portable extension representation.</returns>
        public static PKIX.Extension Extension(this X509Extension X509Extension) => null;





        /// <summary>
        /// Convert CryptoAlgorithmID <paramref name="cryptoAlgorithmID"/> to the 
        /// corresponding UDF identifier.
        /// </summary>
        /// <param name="cryptoAlgorithmID">The identifier to convert</param>
        /// <param name="keysize">Key size (if needed)</param>
        /// <returns>The UDF identifier.</returns>
        public static UDFAlgorithmIdentifier ToUDFID (
                this CryptoAlgorithmID cryptoAlgorithmID, int keysize = 0) {
            return cryptoAlgorithmID switch
                {
                    CryptoAlgorithmID.X25519 => UDFAlgorithmIdentifier.X25519,
                    CryptoAlgorithmID.X448 => UDFAlgorithmIdentifier.X448,
                    CryptoAlgorithmID.Ed25519 => UDFAlgorithmIdentifier.Ed25519,
                    CryptoAlgorithmID.Ed448 => UDFAlgorithmIdentifier.Ed448,
                    _ => UDFAlgorithmIdentifier.Any,
                    };
            }


        }

    }
