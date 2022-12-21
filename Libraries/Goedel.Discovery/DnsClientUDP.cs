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

namespace Goedel.Discovery;

/// <summary>
/// Convenience wrapper to extract the pertinent information from the host network
/// configuration, assign ports, etc. etc.
/// </summary>
public static class HostNetwork {

    /// <summary>
    /// Stub method for non portable function to get the host DNS server address.
    /// </summary>
    /// <returns>List of DNS servers.</returns>
    static public List<IPAddress> GetHostDNS() {

        List<IPAddress> DNSServices = new();

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
                    //foreach (UnicastIPAddressInformation uni in uniCast) {
                    //    //DateTime when;

                    //    //Console.WriteLine("  Unicast Address ......................... : {0}", uni.Address);
                    //    //Console.WriteLine("     Prefix Origin ........................ : {0}", uni.PrefixOrigin);
                    //    //Console.WriteLine("     Suffix Origin ........................ : {0}", uni.SuffixOrigin);
                    //    //Console.WriteLine("     Duplicate Address Detection .......... : {0}",
                    //    //    uni.DuplicateAddressDetectionState);

                    //    // Format the lifetimes as Sunday, February 16, 2003 11:33:44 PM 
                    //    // if en-us is the current culture. 

                    //    //// Calculate the date and time at the end of the lifetimes.    
                    //    //when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.AddressValidLifetime);
                    //    //when = when.ToLocalTime();    
                    //    //Console.WriteLine("     Valid Life Time ...................... : {0}", 
                    //    //    when.ToString(lifeTimeFormat,System.Globalization.CultureInfo.CurrentCulture)
                    //    //);
                    //    //when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.AddressPreferredLifetime);   
                    //    //when = when.ToLocalTime();
                    //    //Console.WriteLine("     Preferred life time .................. : {0}", 
                    //    //    when.ToString(lifeTimeFormat,System.Globalization.CultureInfo.CurrentCulture)
                    //    //); 

                    //    //when = DateTime.UtcNow + TimeSpan.FromSeconds(uni.DhcpLeaseLifetime);
                    //    //when = when.ToLocalTime();
                    //    //Console.WriteLine("     DHCP Leased Life Time ................ : {0}",
                    //    //    when.ToString(lifeTimeFormat, System.Globalization.CultureInfo.CurrentCulture)
                    //    //);
                    //    }
                    //Console.WriteLine();
                    }
                }
            }

        return DNSServices;
        }

    /// <summary>
    /// Return a UDP client for the address family <paramref name="addressFamily"/>
    /// with a randomly selected local port.
    /// </summary>
    /// <param name="addressFamily">The address family, either   
    /// <see cref="AddressFamily.InterNetwork"/> or <see cref="AddressFamily.InterNetworkV6"/>.</param>
    /// <returns></returns>
    public static UdpClient GetUDPClient(AddressFamily addressFamily = AddressFamily.InterNetwork) {

        for (var tries = 0; tries < 200; tries++) {
            try {
                var randomPort = Goedel.Cryptography.Platform.GetRandomPort();
                var UdpClient = new UdpClient(randomPort, addressFamily);
                return UdpClient;
                }
            catch {
                }
            }

        return new UdpClient(Goedel.Cryptography.Platform.GetRandomPort(), addressFamily);
        }



    /// <summary>
    /// Return a list of the local IP endpoints.
    /// </summary>
    /// <returns>The list of endpoints.</returns>
    public static List<IPAddress> GetLocalEndpoints(bool includeLoopback = false) {
        var result = new List<IPAddress>();

        NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface adapter in adapters) {
            if (adapter.OperationalStatus == OperationalStatus.Up) {
                var adapterProperties = adapter.GetIPProperties();
                var unicast = adapterProperties?.UnicastAddresses;

                foreach (var ip in unicast) {
                    var address = ip.Address;
                    if (Filter(address, includeLoopback)) {
                        result.Add(address);
                        }
                    }
                }
            }


        return result;
        }

    /// <summary>
    /// Filter the address <paramref name="address"/> according to the setting of
    /// <paramref name="includeLoopback"/>.
    /// </summary>
    /// <param name="address">The address to filter.</param>
    /// <param name="includeLoopback">If true, include loopback addresses.</param>
    /// <returns>true if the address meets the filtering criteria,
    /// otherwise false.</returns>
    static bool Filter(IPAddress address, bool includeLoopback = false) {
        if (address == null) return false;

        if (IPAddress.IsLoopback(address)) {
            return includeLoopback;
            }

        return true;
        }

    }



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


    void SetIPAddress(IPAddress iPAddress) {
        ListIPAddress = new List<IPAddress>();
        if (iPAddress != null) {
            ListIPAddress.Add(iPAddress);
            }
        }

    /// <summary>
    /// Default constructor using platform default DNS.
    /// </summary>
    public DnsClientUDP() {
        ListIPAddress = HostNetwork.GetHostDNS();
        Port = 53;
        }

    /// <summary>
    /// Constructor from server name.
    /// </summary>
    /// <param name="server">Address of DNS server</param>
    public DnsClientUDP(string server) {
        if (server != null) {
            IPAddress.TryParse(server, out var Address);
            SetIPAddress(Address);
            // Should add in code to query against the ICANN root servers...
            }
        else {
            ListIPAddress = HostNetwork.GetHostDNS();
            }
        Port = 53;
        }

    /// <summary>
    /// Constructor from IP Address using default DNS port (53).
    /// </summary>
    /// <param name="iPAddress">Address of DNS server</param>
    public DnsClientUDP(IPAddress iPAddress) :
        this(iPAddress, 53) {
        }

    /// <summary>
    /// Constructor from list of IP Addresses
    /// </summary>
    /// <param name="listIPAddress">List of addresses of DNS server</param>
    public DnsClientUDP(List<IPAddress> listIPAddress) {
        this.ListIPAddress = listIPAddress;
        this.Port = 53;
        }

    /// <summary>
    /// Constructor from IP Address and port.
    /// </summary>
    /// <param name="iPAddress">Address of DNS server</param>
    /// <param name="port">Port number</param>
    public DnsClientUDP(IPAddress iPAddress, ushort port) {
        SetIPAddress(iPAddress);
        this.Port = port;
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
    readonly UdpClient UdpClient = null;
    IPEndPoint[] IPEndpoints;
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
    /// <param name="listIPAddress">List of IP addresses to contact.</param>
    /// <param name="port">Port number.</param>
    public DNSContextUDP(List<IPAddress> listIPAddress, ushort port) {
        //Console.WriteLine("Create UDP Context");

        IPEndpoints = new IPEndPoint[listIPAddress.Count];
        var index = 0;
        foreach (var address in listIPAddress) {
            IPEndpoints[index++] = new IPEndPoint(address, 53);
            }

        UdpClient = HostNetwork.GetUDPClient();
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


    ///<inheritdoc/>
    public override void SendRequest(DNSRequest request, int index = 0) {
        var ipEndpoint = IPEndpoints[index % IPEndpoints.Length];
        //Console.WriteLine($"DNS request {ipEndpoint}");

        UdpClient.Send(request.Buffer.Buffer, request.Buffer.Length,                                                                
            ipEndpoint);

        }
    ///<inheritdoc/>
    public override async Task<DNSResponse> GetResponseAsync() {
        //Console.WriteLine($"Await respondse {UdpClient.Client.LocalEndPoint}");

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
    public override async Task<byte[]> GetResponseRawAsync() {
        //Console.WriteLine($"Await response {UdpClient.Client.LocalEndPoint}");

        return (await UdpClient.ReceiveAsync()).Buffer;
        }

    // This is the blocking version of the query implementation that is used to 
    // build the async interfaces

    }
