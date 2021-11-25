#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
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
#endregion
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

using Goedel.Cryptography.PKIX;
using Goedel.Utilities;


namespace Goedel.Cryptography;

/// <summary>
/// A general parking ground for methods converting from platform to
/// portable structures.
/// </summary>
public static class ExtensionMethods {

    /// <summary>
    /// If <paramref name="buffer"/> is not null, present the entire contents to
    /// the digest function <paramref name="hashAlgorithm"/>.
    /// </summary>
    /// <param name="hashAlgorithm">The digest function to use.</param>
    /// <param name="buffer">The data to be digested.</param>
    public static void Digest(this HashAlgorithm hashAlgorithm, byte[] buffer) {
        if (buffer != null) {
            hashAlgorithm.TransformBlock(buffer, 0, buffer.Length, buffer, 0);
            }
        }

    /// <summary>
    /// Create PKIX RSAPrivateKey from RSAParameters structure.
    /// </summary>
    /// <param name="parameters">The RSA Parameters in .NET format.</param>
    /// <returns>The private key in Goedel format.</returns> 
    public static PkixPrivateKeyRsa GetPkixPrivateKeyRSA(this RSAParameters parameters) => new() {

        Modulus = parameters.Modulus,
        PublicExponent = parameters.Exponent,
        PrivateExponent = parameters.D,
        Prime1 = parameters.P,
        Prime2 = parameters.Q,
        Exponent1 = parameters.DP,
        Exponent2 = parameters.DQ,
        Coefficient = parameters.InverseQ
        };

    /// <summary>
    /// Convert PKIX RSAPrivateKey to RSAParameters structure.
    /// </summary>
    /// <param name="privateKey">RSA key  in System.Security.Cryptography form</param>
    /// <returns>The RSA parameters in PKIX format.</returns>
    public static RSAParameters GetRsaParameters(this PkixPrivateKeyRsa privateKey) => new() {
        Modulus = privateKey.Modulus,
        Exponent = privateKey.PublicExponent,
        D = privateKey.PrivateExponent,
        P = privateKey.Prime1,
        Q = privateKey.Prime2,
        DP = privateKey.Exponent1,
        DQ = privateKey.Exponent2,
        InverseQ = privateKey.Coefficient,
        };

    /// <summary>
    /// Create PKIX RSAPublicKey from RSAParameters structure.
    /// </summary>
    /// <param name="parameters">Input parameters  in System.Security.Cryptography form</param>
    /// <returns>The public key in Goedel format.</returns>
    public static PkixPublicKeyRsa GetPkixPublicKeyRsa(this RSAParameters parameters) => new() {

        Modulus = parameters.Modulus,
        PublicExponent = parameters.Exponent
        };

    /// <summary>
    /// Convert PKIX RSAPublicKey to RSAParameters structure.
    /// </summary>
    /// <param name="publicKey">The RSA public key</param>
    /// <returns>The RSA parameters in System.Security.Cryotography. format.</returns>
    public static RSAParameters GetRsaParameters(this PkixPublicKeyRsa publicKey) => new() {
        Modulus = publicKey.Modulus,
        Exponent = publicKey.PublicExponent,
        };


    /// <summary>
    /// Convert binary data to portable certificate.
    /// </summary>
    /// <param name="data">Input data</param>
    /// <returns>The certificate</returns>
    public static Certificate Certificate(this byte[] data) {

        var X509Cert = new X509Certificate2(data);
        var TBSCertificate = X509Cert.TBSCertificate();
        return new Certificate(data, TBSCertificate);
        }

    /// <summary>
    /// Create a TBSCertificate item from a X509Certificate2 object.
    /// </summary>
    /// <param name="x509Cert">The X509 certificate to form TBS certificate from</param>
    /// <returns>The TBS certificate structure</returns>
    public static TBSCertificate TBSCertificate(this X509Certificate2 x509Cert) {

        var TBSCertificate = new TBSCertificate() {
            Version = x509Cert.Version,
            SerialNumber = BaseConvert.FromBase16(x509Cert.SerialNumber),
            Signature = x509Cert.SignatureAlgorithm.AlgorithmIdentifier(),
            //Issuer = Parse(X509Cert.IssuerName),
            Validity = new Validity(x509Cert.NotBefore, x509Cert.NotAfter),
            //Subject = Parse(X509Cert.SubjectName),
            Extensions = new List<Goedel.Cryptography.PKIX.Extension>(),
            };
        foreach (var Extension in x509Cert.Extensions) {
            //TBSCertificate.Extensions.Add(Parse(Extension));
            }
        return TBSCertificate;
        }

    /// <summary>
    /// Convert .NET OID to portable OID
    /// </summary>
    /// <param name="Oid">OID structure in System.Security.Cryptography form</param>
    /// <returns>Portable OID structure</returns>
    public static AlgorithmIdentifier AlgorithmIdentifier(this Oid Oid) => new(Oid.ToString());

    /// <summary>
    /// Convert .NET Distinguished Name to portable list of names.
    /// </summary>
    /// <remarks>NOT IMPLEMENTED STUB</remarks>
    /// <param name="DN">Distinguished Name in System.Security.Cryptography form</param>
    /// <returns>Portable list of Names.</returns>
    public static List<Name> Names(this X500DistinguishedName DN) => throw new NYI();

    /// <summary>
    /// Convert .NET extension to portable extensions 
    /// </summary>
    /// <remarks>NOT IMPLEMENTED STUB</remarks>
    /// <param name="X509Extension">The X509 extension in System.Security.Cryptography form</param>
    /// <returns>Portable extension representation.</returns>
    public static PKIX.Extension Extension(this X509Extension X509Extension) => throw new NYI();

    /// <summary>
    /// Convert CryptoAlgorithmID <paramref name="cryptoAlgorithmID"/> to the 
    /// corresponding UDF identifier.
    /// </summary>
    /// <param name="cryptoAlgorithmID">The identifier to convert</param>
    /// <param name="keysize">Key size (if needed)</param>
    /// <returns>The UDF identifier.</returns>
    public static UdfAlgorithmIdentifier ToUDFID(
            this CryptoAlgorithmId cryptoAlgorithmID, int keysize = 0) => cryptoAlgorithmID switch {
                CryptoAlgorithmId.X25519 => UdfAlgorithmIdentifier.X25519,
                CryptoAlgorithmId.X448 => UdfAlgorithmIdentifier.X448,
                CryptoAlgorithmId.Ed25519 => UdfAlgorithmIdentifier.Ed25519,
                CryptoAlgorithmId.Ed448 => UdfAlgorithmIdentifier.Ed448,
                _ => UdfAlgorithmIdentifier.Any,
                };
    }
