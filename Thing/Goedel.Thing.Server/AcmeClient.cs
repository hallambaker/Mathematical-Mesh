////  Copyright © 2021 by Threshold Secrets Llc.
////  
////  Permission is hereby granted, free of charge, to any person obtaining a copy
////  of this software and associated documentation files (the "Software"), to deal
////  in the Software without restriction, including without limitation the rights
////  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
////  copies of the Software, and to permit persons to whom the Software is
////  furnished to do so, subject to the following conditions:
////  
////  The above copyright notice and this permission notice shall be included in
////  all copies or substantial portions of the Software.
////  
////  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
////  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
////  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
////  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
////  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
////  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
////  THE SOFTWARE.

//namespace Goedel.Acme;
//using Certes.Acme;
//using Certes.Acme.Resource;
//using Certes;
//using Goedel.Mesh;
//using Goedel.Protocol;
//using Org.BouncyCastle.Asn1.X509;
//using System.Security.AccessControl;



///// <summary>
///// ACME account
///// </summary>
//public class AcmeAccount {

//    ///<summary>The PEM key</summary> 
//    public string PemKey { get; init; }

//    ///<summary>The Account context</summary> 
//    public IAccountContext AccountContext { get; init; }

//    ///<summary></summary> 
//    public AcmeContext AcmeContext { get; init; }

//    private AcmeAccount() {

//        }

//    /// <summary>
//    /// Factory method, returns a new account instance to the service at <paramref name="uriString"/>
//    /// </summary>
//    /// <param name="uriString">Uri of the CA service.</param>
//    /// <param name="staging">If true, use the staging/test version of the service.</param>
//    /// <returns></returns>
//    public static async Task<AcmeAccount> Create(
//                        string uriString = null, 
//                        bool staging=false) {

//        var uri = uriString == null ? 
//            (staging ? WellKnownServers.LetsEncryptStagingV2 : WellKnownServers.LetsEncryptV2) :
//            new Uri(uriString);


//        var acme = new AcmeContext(uri);
//        var account = await acme.NewAccount("admin@hallambaker.com", true);

//        // Save the account key for later use
//        var pemKey = acme.AccountKey.ToPem();


//        return new AcmeAccount() {
//            PemKey = pemKey,
//            AcmeContext = acme,
//            AccountContext = account,
//            };
//        }

//    /// <summary>
//    /// Place an order for a certificate with the domains <paramref name="domains"/>
//    /// </summary>
//    /// <param name="domains">List of domains to be included in the certificate.</param>
//    /// <returns>Task returning the order.</returns>
//    public async Task<AcmeOrder> PlaceOrder(
//                List<string> domains) {


//        var order = await AcmeContext.NewOrder(domains);

//        var result = new AcmeOrder() {
//            AcmeAccount = this,
//            OrderContext = order,
//            CommonName = domains[0]
//            };

//        //var AcmeChallengeSet = new AcmeChallengeSet();

//        var authorizations = await order.Authorizations();
//        var i = 0;
//        foreach (var authz in authorizations) {
//            var domain = domains[i++];

//            var dnsChallenge = await authz.Dns();
//            var dnsTxt = AcmeContext.AccountKey.DnsTxt(dnsChallenge.Token);

//            var challengeEntry = new DnsChallenge(domain, dnsTxt) {
//                AuthorizationContext = authz,
//                ChallengeContext = dnsChallenge
//                };
//            result.DictionaryZoneToChallenge.Add(domain, challengeEntry);
//            }

//        return result;
//        }
//    }



///// <summary>Acme order</summary>
//public class AcmeOrder {

//    /// <summary>Common name</summary>
//    public string CommonName { get; init; }

//    /// <summary>Challenge dictionary.</summary>
//    public Dictionary<string, DnsChallenge> DictionaryZoneToChallenge { get; } = [];

//    /// <summary>The account</summary>
//    public AcmeAccount AcmeAccount { get; init; }

//    /// <summary>Order</summary>
//    public IOrderContext OrderContext { get; init; }

//    /// <summary>Returned result.</summary>
//    public byte[] Result;

//    /// <summary>Attempt to complete an order.</summary>
//    /// <param name="filename">File containing the order details.</param>
//    /// <param name="password">Password</param>
//    /// <returns>True if successful, otherwise, false.</returns>
//    public async Task<bool> TryCompleteOrder(string filename, string password) {

//        var waiting = false;

//        foreach (var pair in DictionaryZoneToChallenge) {
//            var challenge = pair.Value;

//            var validation = await challenge.ChallengeContext.Validate();
//            challenge.SetState(validation.Status);

//            waiting |= challenge.Waiting;
//            }


//        while (waiting) {
//            await Task.Delay(1000);

//            foreach (var pair in DictionaryZoneToChallenge) {
//                var challenge = pair.Value;

//                var validation = await challenge.ChallengeContext.Resource();
//                challenge.SetState(validation.Status);

//                waiting |= challenge.Waiting;
//                }
//            }
//        var privateKey = KeyFactory.NewKey(KeyAlgorithm.ES256);
//        var cert = await OrderContext.Generate(new CsrInfo {
//            CountryName = "US",
//            State = "DC",
//            Organization = "Cryptomesh",
//            OrganizationUnit = "Dev"
//            }, privateKey);

//        var pfxBuilder = cert.ToPfx(privateKey);
//        Result = pfxBuilder.Build(filename, password);

//        return true;
//        }




//    }



///// <summary>The challeng state</summary>
//public enum ChallengeState {
//    /// <summary>Initial state.</summary>
//    Initial,

//    /// <summary>Order verified.</summary>
//    Verified,

//    /// <summary>Order pending</summary>
//    Pending,

//    /// <summary>Processing</summary>
//    Processing,

//    /// <summary>Order reported valid</summary>
//    Valid,

//    /// <summary>Order reported invalid</summary>
//    Invalid,

//    /// <summary>Order failed</summary>
//    Fail
//    }


///// <summary>ACME DNS challenge.</summary>
///// <param name="Zone">The zone to be challenged.</param>
///// <param name="Text">Challenge text.</param>
//public record DnsChallenge(
//            string Zone,
//            string Text) {

//    /// <summary>The prefixed version of the challenge.</summary>
//    public string PrefixedDomain => Zone[0] == '*' ? "_acme-challenge" + Zone[1..] : "_acme-challenge." + Zone;

//    /// <summary>Context</summary>
//    public IChallengeContext ChallengeContext { get; init; }

//    /// <summary>Authorization</summary>
//    public IAuthorizationContext AuthorizationContext { get; init;}

//    /// <summary>Challenge state.</summary>
//    public ChallengeState ChallengeState = ChallengeState.Initial;

//    /// <summary>If true, waiting on the service.</summary>
//    public bool Waiting => ChallengeState == ChallengeState.Pending | 
//        ChallengeState == ChallengeState.Processing;

//    /// <summary>The returned error string.</summary>
//    public string Error {get; set;}

//    /// <summary>Set the state of the challenge.</summary>
//    /// <param name="status">The status returned.</param>
//    public void SetState(ChallengeStatus? status) => ChallengeState = status switch {
//        ChallengeStatus.Pending => ChallengeState.Pending,
//        ChallengeStatus.Processing => ChallengeState.Processing,
//        ChallengeStatus.Valid => ChallengeState.Valid,
//        ChallengeStatus.Invalid => ChallengeState.Invalid,
//        _ => ChallengeState.Fail
//        };


//    }