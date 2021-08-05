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


namespace Goedel.Protocol {

    /// <summary>
    /// Jpc Ticket record
    /// </summary>

    public record JpcTicket(
            ) {
        ///<summary>Shared secret to which the ticket is bound</summary> 
        public byte[] SharedSecret;

        ///<summary>Ticket data returned by the service</summary> 
        public byte[] Ticket;

        ///<summary>UDP address to which the ticket is bound</summary> 
        public byte[] UdpAddress;

        ///<summary>TCP address to which the ticket is bound</summary> 
        public byte[] TcpAddress;

        ///<summary>Web Service Endpoint to which the ticket is bound</summary> 
        public string WebServiceEndpoint;
        }


    //public class JpcHostBroker {

    //    protected Dictionary<string, JpcTicket> TicketByDiscoveryDomain { get; } =
    //        new Dictionary<string, JpcTicket>();



    //    public JpcHostBroker(string instance = "") {
    //        }
    //    static string GetAccountDiscoveryDomain(string discovery, string domain, string account) =>
    //        $"{account}@{discovery}.{domain}";


    //    public virtual T GetClient<T>(JpcSession session, string discovery, string domain = null)
    //            where T : JpcClientInterface, new() {

    //        switch (session) {

    //            case JpcRemoteSession remoteSession: {
    //                throw new NYI();
    //                return session.GetWebClient<T>();
    //                }

    //            }
    //        throw new NYI();

    //        }



    //    //public virtual JpcSession GetSession(string account, string discovery, string domain = null) =>
    //    //        new JpcSessionDirect(account);

    //    }



    //public class JpcHostBrokerDirect : JpcHostBroker {

    //    ///<summary>Map </summary> 
    //    protected Dictionary<string, JpcInterface> DirectHostByDiscoveryDomain { get; } = 
    //        new Dictionary<string, JpcInterface>();


    //    public JpcHostBrokerDirect(string instance = "") : base (instance) {
    //        }


    //    static string GetDiscoveryDomain(string discovery, string domain) =>
    //        $"{discovery}.{domain}";





    //    public void Register(JpcInterface jpcInterface) {
    //        var discovery = jpcInterface.GetDiscovery;
    //        foreach (var domain in jpcInterface.Domains) {
    //            var discoveryDomain = GetDiscoveryDomain(discovery, domain);
    //            DirectHostByDiscoveryDomain.Add(discoveryDomain, jpcInterface);
    //            }
    //        }


    //    public override T GetClient<T>(JpcSession session, string discovery, string domain = null)  {
    //        var discoveryDomain = GetDiscoveryDomain(discovery, domain);
    //        if (DirectHostByDiscoveryDomain.TryGetValue(discoveryDomain, out var directHost)) {


    //            switch (session) {
    //                case JpcSessionDirect jpcSessionDirect: {
    //                    return directHost.GetDirect(jpcSessionDirect) as T;
    //                    }

    //                case JpcSessionSerialized serialized: {
    //                    //serialized.Host = directHost;
    //                    serialized.Host.AssertNotNull(NYI.Throw);
    //                    return session.GetWebClient<T>();
    //                    }

    //                }


    //            }

    //        return base.GetClient<T>(session, discovery, domain);

    //        }



    //    }





    }

