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

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

/* Unmerged change from project 'Goedel.Discovery'
Before:
using System.Net.NetworkInformation;
using System.Text;

using System.Threading;
After:
using System.Net.Sockets;
using System.Text;
using System.Threading;
*/
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Goedel.Discovery {

    /// <summary>
    /// DNS client implementation
    /// </summary>
    public partial class DnsClientUDP : DnsClient {
        /// <summary>
        /// List of IP addresses to contact.
        /// </summary>
        public List<IPAddress> ListIPAddress;

        /// <summary>
        /// Port number to contact.
        /// </summary>
        public ushort Port;


        void SetIPAddress(IPAddress IPAddress) {
            ListIPAddress = new List<IPAddress>();
            if (IPAddress != null) {
                ListIPAddress.Add(IPAddress);
                }
            }

        /// <summary>
        /// Default constructor using platform default DNS.
        /// </summary>
        public DnsClientUDP() {
            ListIPAddress = GetHostDNS();
            Port = 53;
            }

        /// <summary>
        /// Constructor from server name.
        /// </summary>
        /// <param name="Server">Address of DNS server</param>
        public DnsClientUDP(string Server) {
            if (Server != null) {
                IPAddress.TryParse(Server, out var Address);
                SetIPAddress(Address);
                // Should add in code to query against the ICANN root servers...
                }
            else {
                ListIPAddress = GetHostDNS();
                }
            Port = 53;
            }

        /// <summary>
        /// Constructor from IP Address using default DNS port (53).
        /// </summary>
        /// <param name="IPAddress">Address of DNS server</param>
        public DnsClientUDP(IPAddress IPAddress) :
            this(IPAddress, 53) {
            }

        /// <summary>
        /// Constructor from list of IP Addresses
        /// </summary>
        /// <param name="ListIPAddress">List of addresses of DNS server</param>
        public DnsClientUDP(List<IPAddress> ListIPAddress) {
            this.ListIPAddress = ListIPAddress;
            this.Port = 53;
            }

        /// <summary>
        /// Constructor from IP Address and port.
        /// </summary>
        /// <param name="IPAddress">Address of DNS server</param>
        /// <param name="Port">Port number</param>
        public DnsClientUDP(IPAddress IPAddress, ushort Port) {
            SetIPAddress(IPAddress);
            this.Port = Port;
            }

        /// <summary>
        /// Stub method for non portable function to get the host DNS server address.
        /// </summary>
        /// <returns>List of DNS servers.</returns>
        static public List<IPAddress> GetHostDNS() {

            List<IPAddress> DNSServices = new List<IPAddress>();

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters) {
                if (adapter.OperationalStatus == OperationalStatus.Up) {
                    IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                    IPAddressCollection dnsServers = adapterProperties.DnsAddresses;
                    UnicastIPAddressInformationCollection uniCast = adapterProperties.UnicastAddresses;
                    if (dnsServers.Count > 0) {
                        //Console.WriteLine(adapter.Description);
                        foreach (IPAddress dns in dnsServers) {
                            if (!dns.IsIPv6SiteLocal) {
                                //Console.WriteLine("  DNS Servers ............................. : {0}",
                                //    dns.ToString());
                                DNSServices.Add(dns);
                                }
                            }
                        //string lifeTimeFormat = "dddd, MMMM dd, yyyy  hh:mm:ss tt";
                        foreach (UnicastIPAddressInformation uni in uniCast) {
                            DateTime when;

                            //Console.WriteLine("  Unicast Address ......................... : {0}", uni.Address);
                            //Console.WriteLine("     Prefix Origin ........................ : {0}", uni.PrefixOrigin);
                            //Console.WriteLine("     Suffix Origin ........................ : {0}", uni.SuffixOrigin);
                            //Console.WriteLine("     Duplicate Address Detection .......... : {0}",
                            //    uni.DuplicateAddressDetectionState);

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
                            //Console.WriteLine("     DHCP Leased Life Time ................ : {0}",
                            //    when.ToString(lifeTimeFormat, System.Globalization.CultureInfo.CurrentCulture)
                            //);
                            }
                        //Console.WriteLine();
                        }
                    }
                }

            return DNSServices;
            }



        /// <summary>Return a DNS Client Context in which to make a set of queries.
        /// </summary>
        /// <returns>The DNS Client Context</returns>
        public override DNSContext GetContext() => new DNSContextUDP(ListIPAddress, Port);



        }


    /// <summary>
    /// DNS client implementation
    /// </summary>
    public partial class DNSContextUDP : DNSContext {
        UdpClient UdpClient = null;

        /// <summary>
        /// The disposal method, frees the UdpClient if allocated.
        /// </summary>
        protected override void Disposing() {
            base.Disposing();
            UdpClient?.Dispose();
            }


        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="ListIPAddress">List of IP addresses to contact.</param>
        /// <param name="Port">Port number.</param>
        public DNSContextUDP(List<IPAddress> ListIPAddress, ushort Port) {
            UdpClient = GetUDPClient(ListIPAddress[0], Port);
            TaskListen = GetResponseRawAsync();
            }

        /// <summary>
        /// Close the context.
        /// </summary>
        public override void Close() {
            if (UdpClient != null) {
                UdpClient.Close();
                }
            }


        /// <summary>
        /// Make a DNS request to the default client without waiting for a response
        /// </summary>
        /// <param name="Request">DNS request set</param>
        /// <returns>Task instance.</returns>
        public override void SendRequest(DNSRequest Request) => UdpClient.Send(Request.Buffer.Buffer, Request.Buffer.Length);


        /// <summary>
        /// Make DNS query and wait for response.
        /// </summary>

        /// <returns>The first valid response received.</returns>
        public override async Task<DNSResponse> GetResponseAsync() {
            var ReceiveTask = UdpClient.ReceiveAsync();
            await ReceiveTask;

            try {
                byte[] Result = ReceiveTask.Result.Buffer;
                return new DNSResponse(Result);
                }
            catch {
                return null;
                }

            }


        /// <summary>
        /// Get asynchronous raw response.
        /// </summary>
        /// <returns>The first valid response received.</returns>
        public override async Task<byte[]> GetResponseRawAsync() => (await UdpClient.ReceiveAsync()).Buffer;


        // This is the blocking version of the query implementation that is used to 
        // build the async interfaces


        private static UdpClient GetUDPClient(IPAddress Address, int Port) {
            UdpClient UdpClient;
            try {
                // attempt to allocate a randomly allocated port
                var port = Goedel.Cryptography.Platform.GetRandomPort();
                UdpClient = new UdpClient(port);
                }
            catch {
                // port was already allocated, take a default port off the system.
                UdpClient = new UdpClient();
                }


            UdpClient.Connect(Address, Port);
            return UdpClient;
            }


        }


    }
