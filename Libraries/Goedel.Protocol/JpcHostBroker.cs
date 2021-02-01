//  Copyright © 2021 Threshold Secrets Llc
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
//  
//  
using Goedel.Utilities;
using System.Collections.Generic;

namespace Goedel.Protocol {


    public record JpcTicket (
            byte[] Ticket,
            byte[] UdpAddress,
            byte[] TcpAddress,
            string WebServiceEndpoint) {


        }
    
    
    public class JpcHostBroker {

        protected Dictionary<string, JpcTicket> TicketByDiscoveryDomain { get; } =
            new Dictionary<string, JpcTicket>();



        public JpcHostBroker(string instance = "") {
            }
        static string GetAccountDiscoveryDomain(string discovery, string domain, string account) =>
            $"{account}@{discovery}.{domain}";

        //public virtual T GetClient<T> (
        //        string account, 
        //        string discovery, 
        //        string domain=null,
        //            JpcConnection jpcConnection = JpcConnection.Http) where T : JpcClientInterface, new() {
        //    var client = new T();

        //    JpcSession session;
        //    switch (jpcConnection) {
        //        case JpcConnection.Http: {
        //            client.JpcSession = new JpcSessionHTTP(
        //                    client.GetDiscovery, client.GetWellKnown, account);
        //            break;
        //            }
        //        case JpcConnection.Ticketed: {
        //            var index = GetAccountDiscoveryDomain(client.GetDiscovery, client.GetWellKnown, account);
        //            if (TicketByDiscoveryDomain.TryGetValue(index, out var ticket)) {
        //                client.JpcSession = new JpcSessionTicketed(ticket, account);
        //                }
        //            else {
        //                client.JpcSession = new JpcSessionHTTP(
        //                    client.GetDiscovery, client.GetWellKnown, account);
        //                }
        //            break;
        //            }
        //        default: {
        //            throw new NYI();
        //            }
        //        }

        //    return client;
        //    }

        public virtual T GetClient<T>(JpcSession session, string discovery, string domain = null)
                where T : JpcClientInterface, new() {

            switch (session) {

                case JpcRemoteSession remoteSession: {

                    return session.GetWebClient<T>();
                    }

                }
            throw new NYI();

            }



        public virtual JpcSession GetSession(string account, string discovery, string domain = null) =>
                new JpcSessionDirect(account);

        }



    public class JpcHostBrokerDirect : JpcHostBroker {

        ///<summary>Map </summary> 
        protected Dictionary<string, JpcInterface> DirectHostByDiscoveryDomain { get; } = 
            new Dictionary<string, JpcInterface>();


        public JpcHostBrokerDirect(string instance = "") : base (instance) {
            }


        static string GetDiscoveryDomain(string discovery, string domain) =>
            $"{discovery}.{domain}";





        public void Register(JpcInterface jpcInterface) {
            var discovery = jpcInterface.GetDiscovery;
            foreach (var domain in jpcInterface.Domains) {
                var discoveryDomain = GetDiscoveryDomain(discovery, domain);
                DirectHostByDiscoveryDomain.Add(discoveryDomain, jpcInterface);
                }


            }

        ///// <summary>
        ///// Obtain a client of type <typeparamref name="T"/> with to the account 
        ///// <paramref name="account"/> at DNS domain <paramref name="domain"/>.
        ///// </summary>
        ///// <typeparam name="T">The type of the parameter to return.</typeparam>
        ///// <param name="account">The account name.</param>
        ///// <param name="discovery">The SRV discovery identifier.</param>
        ///// <param name="domain">The DNS domain.</param>
        ///// <returns></returns>
        //public override T GetClient<T>(string account, string discovery, string domain = null, 
        //            JpcConnection jpcConnection=JpcConnection.Http) {
        //    var discoveryDomain = GetDiscoveryDomain(discovery, domain);
        //    if (DirectHostByDiscoveryDomain.TryGetValue(discoveryDomain, out var directHost)) {
        //        switch (jpcConnection) {
        //            case JpcConnection.Direct: {
        //                var session = new JpcSessionDirect(account);

        //                return directHost.GetDirect(session) as T;
        //                }
        //            case JpcConnection.Serialized: {
        //                var session = new JpcSessionSerialized(directHost, account);
        //                return session.GetWebClient<T>();
        //                }
        //            }
        //        }

        //    return base.GetClient<T>(account, discovery, domain);
        //    }


        public override T GetClient<T>(JpcSession session, string discovery, string domain = null)  {
            var discoveryDomain = GetDiscoveryDomain(discovery, domain);
            if (DirectHostByDiscoveryDomain.TryGetValue(discoveryDomain, out var directHost)) {


                switch (session) {
                    case JpcSessionDirect jpcSessionDirect: {
                        return directHost.GetDirect(jpcSessionDirect) as T;
                        }

                    case JpcSessionSerialized serialized: {
                        serialized.Host = directHost;
                        return session.GetWebClient<T>();
                        }

                    }


                }

            return base.GetClient<T>(session, discovery, domain);

            }



        }





    }

