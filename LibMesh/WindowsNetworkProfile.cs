//Sample license text.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace Goedel.Mesh {

    /// <summary>
    /// 
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