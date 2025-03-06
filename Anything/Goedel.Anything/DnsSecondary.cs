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


using Goedel.Cryptography.Nist;
using Goedel.Discovery;

using System.Net;

namespace Goedel.Anything;




/// <summary>
/// Manage a DNS secondary publishing data from a zone
/// </summary>
public class DnsSecondary {

    ///<summary>Prefix used to construct glue records</summary> 
    public static string GlueRecordPrefix { get; set; } = "ns";

    ///<summary>Prefix for admin records</summary> 
    public static string AdminRecordPrefix { get; set; } = "admin";

    ///<summary>The address of the primary DNS authoritative.</summary> 
    public IPAddress Primary { get; init; }

    ///<summary>List od secondary DNS authoritative.</summary> 
    public List<IPAddress> Additional { get; init; }

    ///<summary>The TSIG shared secret (to be replaced with GSS API).</summary> 
    public byte[] TSig { get; init; }

    ///<summary>Value of the last serial published.</summary> 
    private ulong lastSerial;

    ///<summary>Number of seconds after which secondary name servers should query the 
    ///master for the SOA record, to detect zone changes Recommendation for small and 
    ///stable zones 86400 seconds (24 hours)</summary> 
    public uint Refresh { get; set; } = 86400;

    ///<summary></summary> 
    public uint Retry { get; set; } = 7200;

    ///<summary></summary> 
    public uint Expire { get; set; } = 3600000;

    ///<summary></summary> 
    public uint Minimum { get; set; } = 172800;

    /// <summary>
    /// Publish or update the start of authority record.
    /// </summary>
    /// <param name="name">The domain to update.</param>
    /// <param name="initial">If true, this is an initial publication and the existing
    /// records should be overwritten</param>
    public void PublishSoa(string name, bool initial= false) {
        Canonicalize(ref name);



        var nameNs = $"{GlueRecordPrefix}1.{name}";
        var nameAdmin = $"{AdminRecordPrefix}.{name}";

        var domain = new Domain(name);
        var domainNs = new Domain(nameNs);
        var domainAdmin = new Domain(nameAdmin);

        var serial = GetSerial();


        var recordSoa = new DNSRecord_SOA() {
            Domain = domain,
            MNAME = domainNs,
            RNAME = domainAdmin,
            SERIAL = serial,
            REFRESH = Refresh,
            RETRY = Retry,
            EXPIRE = Expire,
            MINIMUM = Minimum
            };

        RecordUpdate(recordSoa);

        if (initial) {
            var nsRecords = new List<DNSRecord>();
            var aRecords = new List<DNSRecord>();

            // add the primary 
            nsRecords.Add(new DNSRecord_NS() {
                Domain = domain,
                NSDNAME = domainNs
                });
            aRecords.Add(GetRecord(domainNs, Primary));

            if (Additional is not null) {
                for (var i = 0; i < Additional.Count; i++) {

                    name = $"{GlueRecordPrefix}{i + 1}";
                    var aname = new Domain(name);

                    nsRecords.Add(new DNSRecord_NS() {
                        Domain = domain,
                        NSDNAME = aname
                        });
                    aRecords.Add(GetRecord(aname, Additional[i]));
                    }
                }
            RecordUpdate(nsRecords);
            RecordUpdate(aRecords);
            }

        }


    /// <summary>
    /// Publish DNS A and AAAA records for the <paramref name="name"/>.
    /// </summary>
    /// <param name="name">The names</param>
    /// <param name="addresses">The addresses to bind</param>
    public void PublishIpAddress(
                    string name, 
                    List<string> addresses) {
        if (addresses is null) {
            return;
            }
        var domain = new Domain(name);
        var records = new List<DNSRecord>();
        foreach (var address in addresses) {
            var ipAddress = IPAddress.Parse (address);
            records.Add(GetRecord(domain, ipAddress));
            }
        RecordUpdate(records);
        }

    /// <summary>
    /// Utility function, returns a A or AAAA record for the address <paramref name="address"/>.
    /// </summary>
    /// <param name="address">The address to return the record for.</param>
    /// <returns>The record.</returns>
    /// <exception cref="NotImplementedException">The address type is not supported.</exception>
    /// <param name="domain">Domain to fetch the record for.</param>
    public DNSRecord GetRecord(Domain domain, IPAddress address) =>
        address.AddressFamily switch {
            AddressFamily.InterNetwork => new DNSRecord_A() {
                Domain = domain,
                Address = address
                },
            AddressFamily.InterNetworkV6 => new DNSRecord_AAAA() {
                Domain = domain,
                Address = address
                },
            _ => throw new NotImplementedException()
            };


    /// <summary>
    /// Push updates for the record <paramref name="record"/>.
    /// </summary>
    /// <param name="record">The record to push the update for.</param>
    public void RecordUpdate(DNSRecord record) {

        var writer = new DnsConfigWriter();
        writer.Encode(record);


        }

    /// <summary>
    /// Push updates for the record <paramref name="records"/>.
    /// </summary>
    /// <param name="records">The records to push the update for.</param>
    public void RecordUpdate(List<DNSRecord> records) {
        foreach (var record in records) {
            RecordUpdate(record);
            }


        }

    /// <summary>
    /// Canonicalize the DNS name <paramref name="name"/> so that it is a fully qualified
    /// lower case DNS name ending in a period.
    /// </summary>
    /// <param name="name">The DNS name to canonicalize.</param>
    private void Canonicalize(ref string name) =>
        name = name[name.Length - 1] == '.' ? name.ToLower() : name.ToLower() + ".";


    private uint GetSerial() {
        var timeLong = (ulong)DateTimeOffset.UtcNow.ToUnixTimeSeconds() ;

        var oldLast = Interlocked.Exchange (ref lastSerial, timeLong);
        if (timeLong <= oldLast) {
            // in rare circumstances, the previous serial number is equal to or ahead of time now
            // so increment 

            timeLong = Interlocked.Increment (ref lastSerial);
            }

        var timeshort = (uint)(timeLong % UInt32.MaxValue);
        return timeshort;

        }


    }

