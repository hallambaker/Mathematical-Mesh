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
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Discovery;

using System.Net;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

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



/// <summary>
/// Thing service client, interfaces to the DNS and to ACME services.
/// </summary>
public class ServiceThingClient {

    /// <summary>
    /// Constructor, 
    /// </summary>
    public ServiceThingClient() {
        // get the DNS client

        }



    public async Task<ServiceThingResult> BindContact(
                    string handle,
                    JsContact contact) {

        throw new NYI();
        }


    public string GetName(
                    string zone,
                    string baseName) => (baseName ?? "iot") + "1." + zone;

    /// <summary>
    /// Obtain credentials for a host providing the services <paramref name="services"/>
    /// from addresses <paramref name="addresses"/> on domain <paramref name="domain"/>
    /// and publish the DNS settings for the services.
    /// </summary>
    /// <param name="domain">The domain to provision the device to.</param>
    /// <param name="addresses">The IP addresses of the device.</param>
    /// <param name="services">The services supported by the device.</param>
    /// <returns>Task returning a <see cref="ServiceThingResult"/> on completion.</returns>
    public async Task<ServiceThingResult> NewDeviceAsync(
                    string domain, 
                    List<IPAddress> addresses,
                    IEnumerable<ServiceDescription> services) {

        var result = new ServiceThingResult (domain, addresses, services);
        result = await PrepareAsync(domain, addresses, services);

        // Callers may prefer to split these up so the device can initialize the
        // services before publishing the DNS entries.

        result = await PublishAsync(result);
        return result;
        }


    /// <summary>
    /// Obtain credentials for a host providing the services <paramref name="services"/>
    /// from addresses <paramref name="addresses"/> on domain <paramref name="domain"/>.
    /// </summary>
    /// <param name="domain">The domain to provision the device to.</param>
    /// <param name="addresses">The IP addresses of the device.</param>
    /// <param name="services">The services supported by the device.</param>
    /// <returns>Task returning a <see cref="ServiceThingResult"/> on completion.</returns>
    public async Task<ServiceThingResult> PrepareAsync(
                    string domain,
                    List<IPAddress> addresses,
                    IEnumerable<ServiceDescription> services) {

        var result = new ServiceThingResult(domain, addresses, services);
        result = await PrepareAsync(result);


        return result;
        }

    /// <summary>
    /// Obtain credentials for a host providing the services
    /// <paramref name="services"/>. The DNS records to allow service discovery are not
    /// published so as to allow the caller to start the services before publishing the
    /// discovery record.
    /// </summary>
    /// <param name="services">The service descriptions.</param>
    /// <returns>Task returning a <see cref="ServiceThingResult"/> on completion.</returns>
    public async Task<ServiceThingResult> PrepareAsync(
                        ServiceThingResult services) {

        // Do the ACME stuff here


        return services;
        }

    /// <summary>
    /// Publish the DNS settings for the services previously credentialed in 
    /// <paramref name="services"/>.
    /// </summary>
    /// <param name="services">The service descriptions.</param>
    /// <returns>Task returning a <see cref="ServiceThingResult"/> on completion.</returns>
    public async Task<ServiceThingResult> PublishAsync(
                            ServiceThingResult services) {

        // Delete the A and AAAA records for the zone (if they exist)

        // Create the A/AAAA records for the zone

        // Add the service entries.



        return services;
        }




    public async Task<ServiceThingResult> NewDeviceHttpsAsync(string domain, string ipaddress) =>
        await NewDeviceAsync(domain, [IPAddress.Parse(ipaddress)], [new(WellKnownService.HTTPS)]);
    }

public record ServiceThingResult {
    public string Domain { get; }
    public List<IPAddress> Addresses { get; } = [];
    public List<ServiceServiceEntry> Services { get; } = [];

    public ServiceThingResult (
                    string domain,
                    List<IPAddress> addresses,
                    IEnumerable<ServiceDescription> services) {
        Domain = domain;
        Addresses = addresses;
        foreach (var service in services) {
            Services.Add(new(service));
            }

        }




    }


public record ServiceServiceEntry (
                ServiceDescription ServiceDescription) {

    public KeyPair Key { get; set; }
    public Key Credential { get; set; }


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
