//   Copyright © 2015 by Comodo Group Inc.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace Goedel.Mesh {

    /// <summary>
    /// Get information on the system network configuration. This includes the number 
    /// of adapters, DNS services, etc.
    /// </summary>
    public class SystemNetworkProfile {

        /// <summary>
        /// Write DNS configuration data to the console.
        /// </summary>
        public static void DisplayDnsAddresses() {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in adapters) {
                if ((adapter.OperationalStatus == OperationalStatus.Up) &
                    (adapter.NetworkInterfaceType != NetworkInterfaceType.Tunnel)) {



                    IPInterfaceProperties adapterProperties = adapter.GetIPProperties();

                    Console.WriteLine("Enabled {0}", adapterProperties.IsDnsEnabled);

                    IPAddressCollection dnsServers = adapterProperties.DnsAddresses;
                    if (dnsServers.Count > 0) {
                        Console.WriteLine(adapter.Description);
                        foreach (var dns in dnsServers) {
                            Console.WriteLine("  DNS Servers ............................. : {0}",
                                dns.ToString());
                            }
                        Console.WriteLine();
                        }
                    }
                }
            }

        /// <summary>
        /// Get the list of DNS server IP Addresses for the first active IP address that is
        /// not a tunnel.
        /// </summary>
        /// <returns>the set of IP addresses.</returns>

        public static IPAddressCollection GetDnsAddresses() {
            var Adapters = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface Adapter in Adapters) {
                if ((Adapter.OperationalStatus == OperationalStatus.Up) &
                    (Adapter.NetworkInterfaceType != NetworkInterfaceType.Tunnel)) {
                    var AdapterProperties = Adapter.GetIPProperties();
                    var DnsServers = AdapterProperties.DnsAddresses;
                    if (DnsServers.Count > 0) {
                        return DnsServers;
                        }
                    }
                }
            return null;
            }

        }
    }