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


public enum CertificateType {
    Root,
    Intermediate0,
    Intermediate1,
    EndEntity
    }

public class AnythingCa {



    ///<summary>The set of names under which devices and services are to be registered</summary> 
    public CatalogedIdentity Identity { get; }

    public X509Certificate2 CallsignRoot { get; set; }
    public X509Certificate2 CallsignIssuer { get; set; }

    public X509Certificate2 PrivateRoot { get; set; }
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

    public X509Certificate2 CreateCallsignRoot(ECDsa key = null) {
        throw new NYI();
        }

    public X509Certificate2 CreateCallsignIntermediate(ECDsa key = null) {
        throw new NYI();
        }

    public X509Certificate2 CreateCallsignCrossCertificate(X509Certificate2 target) {
        throw new NYI();
        }

    /// <summary>
    /// Create a new private root certificate
    /// </summary>
    public X509Certificate2 CreatePrivateRoot(ECDsa key = null) {
        var commonName = Identity.GetPrivateName();
        return ConstructCertificate($"Anything Private for {commonName}", "Root", 
            CertificateType.Root, RootLifetime, key);
        }


    public X509Certificate2 CreatePrivateIntermediate(ECDsa key = null) {
        var commonName = Identity.GetPrivateName();
        return ConstructCertificate($"Anything Private for {commonName}", "Root",
            CertificateType.Intermediate0, IntermediateLifetime, key);
        }


    public X509Certificate2 CreateEndEntity(CatalogedThing thing, ECDsa key = null) {
        var commonName = Identity.GetPrivateName();
        return ConstructCertificate($"Anything {commonName}", thing.LocalName,
            CertificateType.EndEntity, EndEntityLifetime, key);
        }


    X509Certificate2 ConstructCertificate(
                string organizationName,
                string commonName,
                CertificateType type,
                TimeSpan lifespan,
                ECDsa key = null) {

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
            CertificateType.Intermediate1 or
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
            }


        var authorityKeyIdentifier = new X509AuthorityKeyIdentifierExtension();
        var subjectKeyIdentifier = new X509SubjectKeyIdentifierExtension();
        var subjectAltName = new X509SubjectAlternativeNameExtension();
        var authorityInformationAccess = new X509AuthorityInformationAccessExtension();

        var cert = request.CreateSelfSigned(notBefore, notAfter);
        return cert;


        }


    }

