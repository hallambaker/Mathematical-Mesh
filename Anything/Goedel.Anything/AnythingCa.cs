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


using Goedel.Cryptography.Jose;

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Goedel.Anything;

/// <summary>
/// Certificate types, describes position in path.
/// </summary>
public enum CertificateType {

    ///<summary>Self signed root certificate.</summary> 
    Root,

    ///<summary>Certificate signing certificate constrained to disallow signaing of
    ///certificate signing certificates.</summary> 
    Intermediate0,

    ///<summary>Certificate signing certificate constrained to allow signing of one
    ///intermediate certificate signing certificate between it and an end-entity 
    ///certificate.</summary> 
    Intermediate1,

    ///<summary>End entity certificate.</summary> 
    EndEntity
    }

/// <summary>
/// Prototype captive CA for @nything.
/// </summary>
public class AnythingCa {



    ///<summary>The set of names under which devices and services are to be registered</summary> 
    public CatalogedIdentity Identity { get; }
    
    ///<summary>Root of trust for callsign issue.</summary> 
    public X509Certificate2 CallsignRoot { get; set; }

    ///<summary>Online certificate issuer for callsign.</summary> 
    public X509Certificate2 CallsignIssuer { get; set; }

    ///<summary>Cross certificate from callsign to private.</summary> 
    public X509Certificate2 CallsignCross { get; set; }

    ///<summary>Root for personal private issue CA.</summary> 
    public X509Certificate2 PrivateRoot { get; set; }

    ///<summary>Online certificate issuer for personal private issue CA.</summary> 
    public X509Certificate2 PrivateIssuer { get; set; }

    TimeSpan RootLifetime { get; init; } = TimeSpan.FromDays(365 * 10);
    TimeSpan IntermediateLifetime { get; init; } = TimeSpan.FromDays(365 * 2);
    TimeSpan EndEntityLifetime { get; init; } = TimeSpan.FromDays(365 * 1);


    readonly static OidCollection KeyUsage = [
        new ("1.3.6.1.5.5.7.3.1"),  // WWW TLS Server
        new ("1.3.6.1.5.5.7.3.2")   // WWW TLS Client
        ];

    /// <summary>
    /// Constructor, return a new private CA entity for the identity <paramref name="identity"/>.
    /// </summary>
    /// <param name="identity">The identity to provide services for.</param>
    public AnythingCa(CatalogedIdentity identity) {
        Identity = identity;
        }

    /// <summary>
    /// Create a callsign root certificate.
    /// </summary>
    /// <param name="key">The signature key.</param>
    /// <returns>The root certificate created.</returns>
    public X509Certificate2 CreateCallsignRoot(ECDsa key = null) {
        var commonName = Identity.GetPrivateName();
        CallsignRoot = ConstructCertificate($"Mesh CallSign Federated CA", "Root",
            CertificateType.Root, RootLifetime,
            key: key);
        return CallsignRoot;
        }

    /// <summary>
    /// Create a callsign online intermediate certificate used to issue cross certificates.
    /// </summary>
    /// <param name="key">The signature key.</param>
    /// <returns>The root certificate created.</returns>
    public X509Certificate2 CreateCallsignIntermediate(ECDsa key = null) {
        var commonName = Identity.GetPrivateName();
        CallsignIssuer = ConstructCertificate($"Mesh CallSign Intermediate CA", "Issuer",
            CertificateType.Intermediate1, IntermediateLifetime,
            issuer: PrivateRoot, key: key);
        return CallsignIssuer;
        }

    /// <summary>
    /// Create a callsign cross certificates.
    /// </summary>
    /// <param name="target">The private root to cross certify.</param>
    /// <returns>The root certificate created.</returns>
    public X509Certificate2 CreateCallsignCrossCertificate(X509Certificate2 target) {
        var commonName = Identity.GetPrivateName();
        CallsignCross = ConstructCertificate($"Mesh CallSign Intermediate CA", "Cross",
            CertificateType.Intermediate0, IntermediateLifetime,
            issuer: CallsignIssuer);
        return CallsignCross;
        }

    /// <summary>
    /// Create a new private root certificate
    /// </summary>
    /// <param name="key">The signature key.</param>
    public X509Certificate2 CreatePrivateRoot(ECDsa key = null) {
        var commonName = Identity.GetPrivateName();
        PrivateRoot = ConstructCertificate($"Anything Private for {commonName}", "Root", 
            CertificateType.Root, RootLifetime, 
            key:key);
        return PrivateRoot;
        }

    /// <summary>
    /// Create a new private online issuer certificate
    /// </summary>
    /// <param name="key">The signature key.</param>
    public X509Certificate2 CreatePrivateIntermediate(ECDsa key = null) {
        var commonName = Identity.GetPrivateName();
        PrivateIssuer = ConstructCertificate($"Anything Private for {commonName}", "Issuer",
            CertificateType.Intermediate0, IntermediateLifetime, 
            issuer: PrivateRoot, key: key);
        return PrivateIssuer;
        }

    /// <summary>
    /// Create a new private end entity certificate
    /// </summary>
    /// <param name="key">The signature key.</param>
    public X509Certificate2 CreateEndEntity(CatalogedThing thing, ECDsa key = null) {
        var commonName = Identity.GetPrivateName();

        List<string> names = ["coffee.local", "coffee.phb.mesh"];

        return ConstructCertificate($"Anything {commonName}", thing.LocalName,
            CertificateType.EndEntity, EndEntityLifetime, 
            subjectDnsNames: names, issuer: PrivateIssuer, key: key);
        }


    X509Certificate2 ConstructCertificate(
                string organizationName,
                string commonName,
                CertificateType type,
                TimeSpan lifespan,
                IEnumerable<string>? subjectDnsNames = null,
                X509Certificate2? issuer = null,
                ECDsa key = null) {

        // must specify the issuer unless the certificate is of type CertificateType.Root
        (issuer is not null | type == CertificateType.Root).AssertTrue(NYI.Throw);


        var builder = new X500DistinguishedNameBuilder();
        builder.AddCountryOrRegion("ZZ");
        builder.AddOrganizationName(organizationName);
        builder.AddCommonName(commonName);
        var x500 = builder.Build();

        var ecDsa = key ?? ECDsa.Create(ECCurve.CreateFromFriendlyName("nistP384"));
        var hashAlg = new HashAlgorithmName("SHA384");
        var request = new CertificateRequest(x500, ecDsa, hashAlg);

        var notBefore = DateTime.UtcNow - TimeSpan.FromHours(25);
        var notAfter = DateTime.UtcNow + lifespan;

        var subjectKeyHash = SHA256.HashData(ecDsa.ExportSubjectPublicKeyInfo());

        // now we set the extensions

        var basicConstraints = type switch {
            CertificateType.Root => new X509BasicConstraintsExtension(true, false, 0, true),
            CertificateType.Intermediate1 => new X509BasicConstraintsExtension(true, true, 1, true),
            CertificateType.Intermediate0 => new X509BasicConstraintsExtension(true, true, 1, true),
            CertificateType.EndEntity => new X509BasicConstraintsExtension(false, false, 0, true),
            _ => throw new NYI()
            };
        request.CertificateExtensions.Add(basicConstraints);

        var keyUsage = type switch {
            CertificateType.Root or
            CertificateType.Intermediate0 or
            CertificateType.Intermediate1 => new X509KeyUsageExtension(
                X509KeyUsageFlags.DigitalSignature | X509KeyUsageFlags.CrlSign |
                X509KeyUsageFlags.KeyCertSign, true),
            CertificateType.EndEntity => new X509KeyUsageExtension(
                X509KeyUsageFlags.DigitalSignature, true),
            };
        request.CertificateExtensions.Add(keyUsage);

        if (type != CertificateType.Root) {
            var enhancedKeyUsage = new X509EnhancedKeyUsageExtension(KeyUsage, false);
            request.CertificateExtensions.Add(enhancedKeyUsage);

            var subjectKeyIdentifier = new X509SubjectKeyIdentifierExtension(subjectKeyHash, false);
            request.CertificateExtensions.Add(subjectKeyIdentifier);


            var issuerSubject = issuer.Extensions[subjectKeyIdentifier.Oid.Value] as X509SubjectKeyIdentifierExtension;
            if (issuerSubject is not null) {
                var authorityId = X509AuthorityKeyIdentifierExtension.CreateFromSubjectKeyIdentifier(issuerSubject);
                request.CertificateExtensions.Add(authorityId);
                }
            }

        if (subjectDnsNames != null) {
            var data = Helper.GetSubjectAltNameDer(subjectDnsNames);


            var subjectAltName = new X509SubjectAlternativeNameExtension(data, false);
            request.CertificateExtensions.Add(subjectAltName);
            }




        // ToDo: implement OCSP and CRL

        // var authorityInformationAccess = new X509AuthorityInformationAccessExtension();

        var cert = request.CreateSelfSigned(notBefore, notAfter);
        return cert;


        }


    }


