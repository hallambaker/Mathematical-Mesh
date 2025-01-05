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

using System.Collections.Generic;

namespace Goedel.Anything;

public class AnythingServicePrototype {

    public CatalogedIdentity Identity { get; init; }

    public string Suffix { get; init; }

    public List<DnsSecondary> LocalDns { get; init; }

    public List<DnsSecondary> PublicDns { get; init; }



    public AnythingServicePrototype() {

        AcmeCreateAccount();
        }


    /// <summary>
    /// Create a private CA root and self signed certificate.
    /// </summary>
    /// <returns>The self signed certificate</returns>
    public bool CreatePrivateRoots (
                    ) {

        return true;
        }


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
    /// Publish the dns addresses for <paramref name="thing"/>.
    /// </summary>
    /// <param name="thing"></param>
    void PublishDnsAddresses(CatalogedThing thing) {
        foreach (var identity in Identity.Identities) {
            var name = thing.LocalName + "." + identity.Name;
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
    /// Create the private certificates for <paramref name="thing"/>
    /// </summary>
    /// <param name="thing">The thing to create certificates for.</param>
    public void CreatePrivateCerts(CatalogedThing thing) {
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
                 bool clear=false) {
        }

    /// <summary>
    /// Publish DNS A and AAAA records for the <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The names</param>
    /// <param name="server">The list of secondary servers to UPDATE</param>
    /// <param name="address">The addresses to bind</param>
    public void PublishIpAddress(
            string name,
            List<DnsSecondary> server,
            List<string> address
            ) {
        }


    }




public record DnsSecondary {

    public string IpAddress { get; init; }

    public byte[] TSig { get; init; }
    }

