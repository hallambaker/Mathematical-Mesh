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


using Goedel.Cryptography.PKIX;
using Goedel.IO;

using System.Collections.Generic;

namespace Goedel.Anything;
/// <summary>
/// Prototype of the Anything service
/// </summary>
public class AnythingServicePrototype {

    ///<summary>The set of names under which devices and services are to be registered</summary> 
    public CatalogedIdentity Identity { get; }


    //public string Suffix { get; init; }

    ///<summary>List of DNS servers through which names are to be published on the local DNS.</summary> 
    public List<DnsSecondary> LocalDns { get; }

    ///<summary>List of DNS servers through which names are to be published on the public DNS.</summary> 
    public List<DnsSecondary> PublicDns { get; }

    ///<summary>The captive private CA</summary> 
    public AnythingCa AnythingCa { get; }
    /// <summary>
    /// Constructor.
    /// </summary>
    public AnythingServicePrototype(
                    CatalogedIdentity identity,
                    List<DnsSecondary> localDns,
                    List<DnsSecondary> publicDns
                    ) {
        Identity = identity;
        LocalDns = localDns;
        PublicDns = publicDns;

        PublishZoneAuthority();
        AcmeCreateAccount();
        AnythingCa = new(Identity);
        }

    #region // Device registration request

    /// <summary>
    /// Begin a registration request for <paramref name="thing"/>.
    /// </summary>
    /// <param name="thing">The thing to be credentialed and published.</param>
    /// <returns>The request context.</returns>
    public AnythingRequestContext RegistrationBegin(
                    CatalogedThing thing
                    ) {

        var state = AnythingState.Complete;

        PublishDnsAddresses(thing);
        CreatePrivateCerts(thing);

        var names = new List<string>();
        foreach (var identity in Identity.Identities) {
            switch (identity) {
                case DnsIdentity callsignIdentity: {
                    var name = thing.LocalName + "." + identity.Name;
                    names.Add(name);
                    break;
                    }
                }
            }

        List<AcmeChallenge>? chalenges = null;
        if (names.Count > 0) {
            state = AnythingState.WaitValidate;
            chalenges = GetAcmeChallenge(names);
            PublishAcmeChallenge(chalenges);
            }

        return new AnythingRequestContext() {
            Id = Udf.Nonce(),
            State = state,
            Thing = thing,
            TryAfter = DateTime.UtcNow + TimeSpan.FromSeconds(2),
            Challenges = chalenges
            };
        }

    /// <summary>
    /// Continue the registration request <paramref name="context"/>.
    /// </summary>
    /// <param name="context">Request to progress</param>
    /// <returns>true if the request progressed to the next state.</returns>
    public bool RegistrationContinue(
                AnythingRequestContext context) {

        switch (context.State) {
            case AnythingState.Complete: {
                return true;
                }

            case AnythingState.WaitValidate: {
                if (AcmeTryGetCsr(context)) {
                    context.State = AnythingState.WaitCsr;
                    return true;
                    }
                return false;
                }
            case AnythingState.CsrReady: {
                if (AcmeTryGetCertificate(context)) {
                    context.State = AnythingState.WaitCertificate;
                    return true;
                    }
                return false;
                }

            }


        return false;
        }


    #endregion
    #region // DNS host and service related

    void PublishZoneAuthority() {
        foreach (var secondary in LocalDns) {

            foreach (var identity in Identity.Identities) {
                Console.WriteLine();
                Console.WriteLine($"# Local for {identity.DnsRoot}");
                switch (identity) {
                    case CallsignIdentity callsignIdentity:
                    case LocalIdentity localIdentity:
                    case DnsIdentity dnsIdentity: {
                        secondary.PublishSoa(identity.DnsRoot, true);
                        break;
                        }
                    }
                }
            }

        foreach (var secondary in PublicDns) {
            foreach (var identity in Identity.Identities) {
                Console.WriteLine();
                Console.WriteLine($"# Public for {identity.DnsRoot}");
                switch (identity) {
                    case CallsignIdentity callsignIdentity:
                    case DnsIdentity dnsIdentity: {
                        secondary.PublishSoa(identity.DnsRoot, true);
                        break;
                        }
                    }
                }
            }
        }



    /// <summary>
    /// Publish the dns addresses for <paramref name="thing"/>.
    /// </summary>
    /// <param name="thing"></param>
    void PublishDnsAddresses(CatalogedThing thing) {

        foreach (var identity in Identity.Identities) {
            var name = identity.GetDnsName(thing.LocalName);
            switch (identity) {
                case DnsIdentity dnsIdentity: {
                    PublishIpAddress(name, LocalDns, thing.InternalIp);
                    PublishIpAddress(name, PublicDns, thing.ExternalIp);
                    break;
                    }
                case LocalIdentity localIdentity: {
                    PublishIpAddress(name, LocalDns, thing.InternalIp);
                    break;
                    }
                case CallsignIdentity callsignIdentity: {
                    PublishIpAddress(name, LocalDns, thing.InternalIp);
                    PublishIpAddress(name, PublicDns, thing.ExternalIp);
                    break;
                    }
                }
            }
        }


    /// <summary>
    /// Publish DNS A and AAAA records for the <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The names</param>
    /// <param name="servers">The list of secondary servers to UPDATE</param>
    /// <param name="addresses">The addresses to bind</param>
    public void PublishIpAddress(
            string name,
            List<DnsSecondary> servers,
            List<string> addresses
            ) {

        foreach (var server in servers) {
            server.PublishIpAddress(name, addresses);
            }

        }

    #endregion
    #region // Private CA related

    /// <summary>
    /// Create a private CA root and self signed certificate.
    /// </summary>
    /// <returns>The self signed certificate</returns>
    public bool CreatePrivateRoots(
                    ) {

        AnythingCa.CreatePrivateRoot();
        "PrivateRoot.cer".WriteFileNew(AnythingCa.PrivateRoot.RawData);
        

        AnythingCa.CreatePrivateIntermediate();
        "PrivateIssuer.cer".WriteFileNew(AnythingCa.PrivateIssuer.RawData);

        return true;
        }


    /// <summary>
    /// Create the private certificates for <paramref name="thing"/>
    /// </summary>
    /// <param name="thing">The thing to create certificates for.</param>
    public void CreatePrivateCerts(CatalogedThing thing) {
        var endEntity = AnythingCa.CreateEndEntity(thing);

        "PrivateDevice.cer".WriteFileNew(endEntity.RawData);
        }



    #endregion
    #region // ACME related


    /// <summary>
    /// Create an acme account to the issuer endpoint
    /// </summary>
    /// <returns></returns>
    bool AcmeCreateAccount() {

        return true;
        }

    /// <summary>
    /// Attempt to obtain CSRs for the request bundle <paramref name="context"/>
    /// </summary>
    /// <param name="context">The request to obtain CSRs in</param>
    /// <returns></returns>
    bool AcmeTryGetCsr(AnythingRequestContext context) {

        // if success, clear the challenges
        PublishAcmeChallenge(context.Challenges, true);
        return true;
        }

    /// <summary>
    /// Try to get certificates for the request <paramref name="context"/>
    /// </summary>
    /// <param name="context">The request to obtain certificates for</param>
    /// <returns></returns>
    bool AcmeTryGetCertificate(AnythingRequestContext context) {

        return true;
        }


    /// <summary>
    /// Get the acme challenges for <paramref name="names"/>
    /// </summary>
    /// <param name="names">The names to get challenges for</param>
    /// <returns>The correspondiong challenge strings.</returns>
    public List<AcmeChallenge> GetAcmeChallenge(List<string> names) {
        Console.WriteLine($"Get Acme challenge for {names}");

        return [ new AcmeChallenge() {
            Value = "FromAcme",
            Label = "_acme.name"
            }
            ];
        }

    /// <summary>
    /// Publish or clear the acme challenge for <paramref name="challenges"/>
    /// </summary>
    /// <param name="challenges"></param>
    /// <param name="clear">If true, clear the challenge.</param>
    public void PublishAcmeChallenge(
                 List<AcmeChallenge> challenges,
                 bool clear = false) {
        }


    #endregion


    }

