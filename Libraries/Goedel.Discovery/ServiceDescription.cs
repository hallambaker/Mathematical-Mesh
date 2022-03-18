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


namespace Goedel.Discovery;

/// <summary>
/// Represents an Internet destination, this may be a single IPv4 or IPv6 
/// address or a sequence of prioritized IP addresses.
/// </summary>
public class ServiceDescription {
    readonly Random Random = new();

    /// <summary>The list of policy entries</summary>
    public List<ServiceEntry> Entries = new();

    /// <summary>Sorted Array of policy entries</summary>
    public ServiceEntry[] SortedEntries = null;

    /// <summary>The list of policy entries</summary>
    public ServiceEntry Default { get; set; }

    /// <summary>The target address for discovery</summary>
    public string Address { get; set; }

    /// <summary>The service being discovered</summary>
    public string Service { get; set; }

    /// <summary>The service prefix</summary>
    public string Prefix => "_" + Service + "._tcp.";

    /// <summary>The service address being discovered</summary>
    public string ServiceAddress => (Prefix + Address).ToLower();

    /// <summary>The default path for the Web Service Endpoint</summary>
    string DefaultPath => "/.well-known/" + Service + "/";

    readonly List<string> _TXT = new();
    /// <summary>Text policy records</summary>
    public virtual List<string> TXT => _TXT;

    int Index;
    /// <summary>Returns the next service entry</summary>
    /// <returns>The next service entry.</returns>
    public ServiceEntry Next() {
        if (Entries.Count <= 0) {
            return Default;
            }
        if (SortedEntries == null) {
            Sort();
            Index = 0;
            }
        return Index < SortedEntries.Length ? SortedEntries[Index++] : null;
        }

    /// <summary>
    /// Standard constructor, used for when policy description data is found
    /// </summary>
    /// <param name="address">DNS address of service</param>
    /// <param name="service">Service identifier (without decorations)</param>
    public ServiceDescription(string address, string service) {
        this.Service = service;
        this.Address = address;
        }

    /// <summary>
    /// Fallback constructor, construct entry with no policy information.
    /// </summary>
    /// <param name="address">DNS address of service</param>
    /// <param name="service">Service identifier (without decorations)</param>
    /// <param name="port">IP port number</param>
    /// <param name="fallback">Fallback mode for if no SRV record is found</param>
    public ServiceDescription(string address, string service, int? port,
                    DNSFallback fallback = DNSFallback.Prefix) {
        this.Address = address;
        this.Service = service;
        this.Fallback(port, fallback);
        }

    /// <summary>
    /// Fallback discovery for if no SRV records are found.
    /// </summary>
    /// <param name="port">IP port number</param>
    /// <param name="fallback">Fallback mode for if no SRV record is found</param>
    public void Fallback(int? port = null, DNSFallback fallback = DNSFallback.Prefix) {
        var ServiceEntry = new ServiceEntry() {
            Address = ServiceDescription.Fallback(Address, Service, fallback),
            Port = port,
            Path = DefaultPath
            };
        Default = ServiceEntry;
        }

    /// <summary>
    /// Add a service entry. NB a service entry can only be attached to one
    /// description.
    /// </summary>
    /// <param name="serviceEntry">The service entry to add</param>
    public void Add(ServiceEntry serviceEntry) {
        serviceEntry.ServiceDescription = this;
        Entries.Add(serviceEntry);
        }


    /// <summary>
    /// Sort the entries into order using the SRV weightings and priorities.
    /// </summary>
    public void Sort() {
        Index = 0;

        SortedEntries = new ServiceEntry[Entries.Count];

        for (var i = 0; i < Entries.Count; i++) {
            int Weight = 0;
            int Priority = UInt16.MaxValue;
            int Pick = 0;
            for (var j = 0; j < Entries.Count; j++) {
                var Entry = Entries[j];
                if (!Entry.Flag & (Entry.Priority <= Priority)) {
                    Priority = Entry.Priority;
                    Weight += Entry.Weight;
                    Pick = j;
                    }
                if (Weight > 0) {
                    var Score = Random.Next(Weight);
                    Weight = 0;
                    // Weighted selection
                    for (var k = 0; k < Entries.Count; k++) {
                        var Entry2 = Entries[j];
                        if (!Entry.Flag & (Entry.Priority == Priority)) {
                            Score -= Entry2.Weight;
                            if (Score < 0) {
                                Pick = k;
                                break; // quit for(k) loop
                                }
                            }
                        }
                    }
                SortedEntries[j] = Entries[Pick];
                Entries[Pick].Flag = true;
                }
            }

        }

    /// <summary>
    /// Calculate fallback address if SRV resolution is not available
    /// </summary>
    /// <param name="address">The stem address</param>
    /// <param name="service">The IANA assigned service identifier. This is the actual
    /// identifier as assigned and not the SRV prefix formed from the identifier.</param>
    /// <param name="fallback">The fallback mode.</param>
    /// <returns>The constructed string</returns>
    public static string Fallback(string address, string service, DNSFallback fallback) {
        if (service == null) {
            return address;
            }
        return fallback switch {
            DNSFallback.Address => address,
            DNSFallback.Prefix => service + "." + address,
            DNSFallback.None => null,
            _ => null,
            };
        }

    public string GetUri() =>
        Entries.Count > 0 ? Entries[0].HTTPEndpoint : Default.HTTPEndpoint;


    }



/// <summary>
/// Represents an Internet destination, this may be a single IPv4 or IPv6 
/// address or a sequence of prioritized IP addresses.
/// </summary>
public class ServiceEntry {

    /// <summary>The prefixed Host address</summary>
    public string HostAddress {
        get {
            var Text = ServiceDescription?.Prefix + Address;
            return Text.ToLower();
            }
        }

    string _Address;
    /// <summary>The DNS Address to resolve</summary>
    public virtual string Address {
        get => _Address ?? ServiceDescription?.Default.Address;
        set => _Address = value;
        }

    int? _Port;
    /// <summary>The port number to connect to</summary>
    public virtual int? Port {
        get => _Port ?? ServiceDescription?.Default.Port;
        set => _Port = value;
        }

    /// <summary>Priority of this service entry</summary>
    public virtual int Priority { get; set; }
    /// <summary>Weight of this service entry</summary>
    public virtual int Weight { get; set; }

    string _Path;
    /// <summary>URI path to connect to (will default to /.well-known/&lt;Service&gt;</summary>
    public virtual string Path {
        get => _Path ?? ServiceDescription?.Default.Path;
        set => _Path = value;
        }

    TransportSecurity? _TransportSecurity;
    /// <summary>Transport security setting</summary>
    public virtual TransportSecurity? TransportSecurity {
        get => _TransportSecurity ?? ServiceDescription?.Default.TransportSecurity;
        set => _TransportSecurity = value;
        }

    Transport? _Transport;
    /// <summary>Transport setting</summary>
    public virtual Transport? Transport {
        get => _Transport ?? ServiceDescription?.Default.Transport;
        set => _Transport = value;
        }

    string _URI;
    /// <summary>Security policy URI</summary>
    public virtual string URI {
        get => _URI ?? ServiceDescription?.Default.URI;
        set => _URI = value;
        }

    string _UDF;
    /// <summary>Security policy fingerprint</summary>
    public virtual string UDF {
        get => _UDF ?? ServiceDescription?.Default.UDF;
        set => _UDF = value;
        }

    readonly List<string> _TXT = new();
    /// <summary>Text policy records</summary>
    public virtual List<string> TXT => _TXT;

    /// <summary>Internal flag used in the sorting algorithm to mark allocated entries. </summary>
    public bool Flag { get; set; } = false;


    /// <summary>The service description to which this entry is attached</summary>
    public ServiceDescription ServiceDescription { get; set; }


    /// <summary>Calculate the Web Service Endpoint for a HTTP binding</summary>
    public string HTTPEndpoint {
        get {
            if (_Port == null) {
                return "http://" + Address + Path;
                }
            else {
                return "http://" + Address + ":" + Port.ToString() + Path;
                }
            }
        }

    }
