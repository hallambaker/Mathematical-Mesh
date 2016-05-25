using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Text;
using System.Security.Cryptography;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace Goedel.DNS {





    public partial class DNSClient {
        public List<IPAddress>          ListIPAddress;
        public ushort                   Port;

        private RNGCryptoServiceProvider RNGCryptoServiceProvider = new RNGCryptoServiceProvider ();

        void SetIPAddress(IPAddress IPAddress) {
            ListIPAddress = new List<IPAddress>();
            if (IPAddress != null) {
                ListIPAddress.Add(IPAddress);
                }
            }

        public DNSClient() {
            ListIPAddress = GetHostDNS ();
            Port = 53;
            }

        public DNSClient(string Server) {
            if (Server != null) {
                IPAddress IPAddress;
                IPAddress.TryParse(Server, out IPAddress);
                SetIPAddress (IPAddress);
                // Should add in code to query against the ICANN root servers...
                }
            else {
                ListIPAddress = GetHostDNS ();
                }
            Port = 53;
            }

        public DNSClient(IPAddress IPAddress) :
            this (IPAddress, 53) {
            }

        public DNSClient(List<IPAddress> ListIPAddress) {
            this.ListIPAddress = ListIPAddress;
            this.Port = 53;
            }

        public DNSClient(IPAddress IPAddress, ushort Port) {
            SetIPAddress (IPAddress);
            this.Port = Port;
            }

        static public List<IPAddress> GetHostDNS() {

            List<IPAddress> DNSServices = new List<IPAddress>();

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters) {
                if (adapter.OperationalStatus == OperationalStatus.Up) {
                    IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                    IPAddressCollection dnsServers = adapterProperties.DnsAddresses;
                    UnicastIPAddressInformationCollection uniCast = adapterProperties.UnicastAddresses;
                    if (dnsServers.Count > 0) {
                        Console.WriteLine(adapter.Description);
                        foreach (IPAddress dns in dnsServers) {
                            if (!dns.IsIPv6SiteLocal) {
                                Console.WriteLine("  DNS Servers ............................. : {0}",
                                    dns.ToString());
                                DNSServices.Add(dns);
                                }
                            }
                        string lifeTimeFormat = "dddd, MMMM dd, yyyy  hh:mm:ss tt";
                        foreach (UnicastIPAddressInformation uni in uniCast) {
                            DateTime when;

                            Console.WriteLine("  Unicast Address ......................... : {0}", uni.Address);
                            Console.WriteLine("     Prefix Origin ........................ : {0}", uni.PrefixOrigin);
                            Console.WriteLine("     Suffix Origin ........................ : {0}", uni.SuffixOrigin);
                            Console.WriteLine("     Duplicate Address Detection .......... : {0}",
                                uni.DuplicateAddressDetectionState);

                            // Format the lifetimes as Sunday, February 16, 2003 11:33:44 PM 
                            // if en-us is the current culture. 

                            //// Calculate the date and time at the end of the lifetimes.    
                            //when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.AddressValidLifetime);
                            //when = when.ToLocalTime();    
                            //Console.WriteLine("     Valid Life Time ...................... : {0}", 
                            //    when.ToString(lifeTimeFormat,System.Globalization.CultureInfo.CurrentCulture)
                            //);
                            //when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.AddressPreferredLifetime);   
                            //when = when.ToLocalTime();
                            //Console.WriteLine("     Preferred life time .................. : {0}", 
                            //    when.ToString(lifeTimeFormat,System.Globalization.CultureInfo.CurrentCulture)
                            //); 

                            when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.DhcpLeaseLifetime);
                            when = when.ToLocalTime();
                            Console.WriteLine("     DHCP Leased Life Time ................ : {0}",
                                when.ToString(lifeTimeFormat, System.Globalization.CultureInfo.CurrentCulture)
                            );
                            }
                        Console.WriteLine();
                        }
                    }
                }

            return DNSServices;
            }


        // This is the blocking version of the query implementatio that is used to 
        // build the async interfaces


        private UdpClient GetUDPClient(IPAddress Address, int Port) {
            UdpClient UdpClient = new UdpClient (GetPort());
            UdpClient.Connect (Address, Port);
            return UdpClient;
            }


        private int GetPort() {
            byte[] Bytes = new byte[3];

            RNGCryptoServiceProvider.GetBytes (Bytes);
            int Result = Bytes[0] + 256 * Bytes [1];

            // Avoid allocating a well known port number 
            if (Result < 4096) {
                Result = Result + 256 * ( Bytes [2] | 0x10 ) ;
                }


            Console.WriteLine ("Use port {0}", Result);
            return Result;
            }





        //
        // This should be set up to do things like divide up the queries across the services
        // and try failover etc. And do things in async mode etc.

        public DNSResponse Query(DNSRequest Request) {
            UdpClient UdpClient = GetUDPClient (ListIPAddress[0], Port);

            UdpClient.Send (Request.Buffer.Buffer, Request.Buffer.Length);

            IPEndPoint Sender = new IPEndPoint(IPAddress.Any, 0);;
            byte [] Result = UdpClient.Receive (ref Sender);


            return new DNSResponse (Result);
            }

        public delegate DNSResponse AsyncQuery(DNSRequest Request);



        //public DNSRecord[] Query(string Domain, DNSTypeCode Type) {
        //    return null;
        //    }


        public IAsyncResult BeginQuery(DNSRequest Request, 
                            AsyncCallback requestCallback, Object state) {
            AsyncQuery Caller = new AsyncQuery (this.Query);
            IAsyncResult Result = Caller.BeginInvoke (Request, requestCallback, state);
            return Result;
            }

        public IAsyncResult BeginQuery(string Domain, DNSTypeCode Type, 
                            AsyncCallback requestCallback, Object state) {

            DNSRequest Request = new DNSRequest (Domain, Type);

            return BeginQuery (Request, requestCallback, state);
            }

        public DNSResponse EndQuery(IAsyncResult IResult) {
            AsyncResult result = (AsyncResult) IResult;
            AsyncQuery Caller = (AsyncQuery) result.AsyncDelegate;

            DNSResponse returnValue = Caller.EndInvoke (IResult);

            return returnValue;
            }
        }
    }
