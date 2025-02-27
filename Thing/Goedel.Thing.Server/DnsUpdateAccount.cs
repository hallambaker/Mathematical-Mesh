//  Copyright © 2021 by Threshold Secrets Llc.
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

using Goedel.Contacts;
using Goedel.Discovery;

using System.Net;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;

using static System.Net.Mime.MediaTypeNames;

namespace Goedel.Acme;

public record ServiceDescription(
            string Protocol,
            int Port=0,
            string Configuration=null) {


    public ServiceDescription(
                WellKnownService service,
                int port = 0,
                string configuration = null) : this (
                    service.GetProtocol(), 
                    service.GetPort(port), 
                    service.GetConfiguration(configuration)) {
        }


    }


public class ServiceThingDispatch() {


    public ServiceThingTask NewDevice(
                    string domain, 
                    IEnumerable<ServiceDescription> services) {

        return new ServiceThingTask() {

            };
        }

    public ServiceThingTask NewDeviceHttps(string domain, string ipaddress) {

        return new ServiceThingTask() {

            };
        }
    }

public record ServiceThingTask {

    public bool IsCompleted { get; set; }

    public int RetryMs { get; private set; } = 500;


    int count = 5;

    public bool Poll() {
        IsCompleted = count-- > 0;
        
        return IsCompleted;
        }

    }


public record DnsUpdateRequest {

    public uint TTL { get; set; }

    public List<DNSRecord> Records { get; }  = [];


    private uint getTTl(uint ttl) => ttl >0 ? ttl : TTL;




    public void AddIpAddress(
                string domain,
                List<IPAddress> addresses,
                bool reverse = false,
                uint ttl = 0) {
        foreach (var address in addresses) {
            AddIpAddress (domain, addresses, reverse, ttl);
            }
        }

    public void AddIpAddress(
                    string domain,
                    IPAddress address,
                    bool reverse=false,
                    uint ttl = 0) {

        if (address.AddressFamily == AddressFamily.InterNetwork) {
            var record = new DNSRecord_A() {
                Address = address,
                TTL = getTTl(ttl)
                };
            Records.Add(record);
            }
        else if (address.AddressFamily == AddressFamily.InterNetworkV6) {
            var record = new DNSRecord_AAAA() {
                Address = address,
                TTL = getTTl(ttl)
                };
            Records.Add(record);
            }
        }

    public void AddCaa(
        string domain,
        string value,
        byte flag,
        string type,
        uint ttl = 0) {
        }

    public void AddCname(
            string domain,
            string host,
            uint ttl = 0) {
        }


    public void AddMx(
                string domain,
                string host,
                int priority,
                uint ttl = 0) {
        }

    public void AddService(
                string domain,
                string host,
                int priority,
                int weight,
                int port,
                uint ttl = 0) {
        }

    public void AddTxt(
                string domain,
                string text,
                uint ttl = 0) {

        var record = new DNSRecord_TXT() {
            Domain = new(domain),
            Text = [text]
            };
        Records.Add(record);
        }

    }


public class DnsUpdateAccount {

    public string Name { get; }
    public IPAddress Primary { get; }
    public string TsigKey { get; }



    public DnsUpdateAccount(
                string name,
                IPAddress primary,
                string tsigKey) {
        Name = name;
        Primary = primary;
        TsigKey = tsigKey;
        }


    public void Initialize() {

        }


    private void Prepare (DNSRecord record) { 
        }

    public void Publish(DnsUpdateRequest request) {
        var records = request.Records;


        // calculate the total record length
        foreach (DNSRecord record in records) {
            }
        var tsig = new DNSRecord_TSIG();

        // Construct the update record


        // add the preamble


        // splice in the records


        // Calculate the TSIG

        }

    private void Verify(DnsUpdateRequest request) {
        }






    public void PublishTxt(string domain, string text) {

        var update = new DnsUpdateRequest();
        update.AddTxt(domain, text);
        Publish(update);

        Verify(update);
        }


    public void PublishA(string domain, List<IPAddress> addresses) {

        var update = new DnsUpdateRequest();
        update.AddIpAddress (domain, addresses);
        Publish(update);


        }


    }
