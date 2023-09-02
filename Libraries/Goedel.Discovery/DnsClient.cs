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
using System.Threading;


namespace Goedel.Discovery;




/// <summary>DNS Fallback Options</summary>
public enum DNSFallback {
    /// <summary>Do not attempt fallback if no SRV record exists</summary>
    None,
    /// <summary>Attempt to resolve &lt;Address&gt; if SRV resolution fails</summary>
    Address,
    /// <summary>Attempt to resolve &lt;Service&gt;.&lt;Address&gt; if SRV resolution fails</summary>
    Prefix

    }

/// <summary>Transport security policy</summary>
public enum TransportSecurity {
    /// <summary>Do not accept TLX</summary>
    Refuse = 0,
    /// <summary>Allow any transport security protocol</summary>
    Any = 0x8FFE,
    /// <summary>Require transport security</summary>
    Require = 1,
    /// <summary>Accept TLS 1.1 or earlier</summary>
    TLS_1_1 = 0x2,
    /// <summary>Accept TLS 1.2</summary>
    TLS_1_2 = 0x4,
    /// <summary>Accept TLS 1.3</summary>
    TLS_1_3 = 0x8,

    /// <summary>No value specified</summary>
    NULL = -1
    }


/// <summary>Transport protocol</summary>
public enum Transport {
    /// <summary>Accept HTTP 1.1</summary>
    HTTP = 1,
    /// <summary>Accept HTTP/2</summary>
    HTTP2 = 2,
    /// <summary>Accept QUIC</summary>
    QUIC = 4,

    /// <summary>No value specified</summary>
    NULL = -1
    }


/// <summary>
/// DNS client.
/// </summary>
public abstract class DnsClient {

    /// <summary>Default client context for DNS query (result is cached for reuse)</summary>
    public static DnsClient Default => defaultClient ?? new DnsClientUDP().CacheValue(out defaultClient);
    static DnsClient defaultClient = null;

    /// <summary>Return a DNS Client Context in which to make a set of queries.
    /// </summary>
    /// <returns>The DNS Client Context</returns>
    public abstract DNSContext GetContext();

    ILogger Logger => Component.Logger;

    ///// <summary>
    ///// Resolve a DNS name to an address and service characteristics.
    ///// </summary>
    ///// <param name="address">The address to use</param>
    ///// <param name="service">The DNS service prefix</param>
    ///// <param name="port">The default DNS port number</param>
    ///// <param name="fallback">The fallback mode to use if SRV lookup fails</param>
    ///// <returns>IP Destination describing the resolution results</returns>
    //public static ServiceDescription ResolveService(string address, string service = null,
    //            int? port = null, DNSFallback fallback = DNSFallback.Prefix) =>
    //        ResolveServiceAsync(address, service, port, fallback).Sync();


    /// <summary>
    /// Perform Asynchronous query for Service discovery and description records
    /// using the platform default DNSClient.
    /// </summary>
    /// <param name="address">The address to query</param>
    /// <param name="service">The IANA service name</param>
    /// <param name="port">The default DNS port number</param>
    /// <param name="fallback">The fallback mode to use if SRV lookup fails</param> 
    /// <returns>Description of the discovered services.</returns>
    public static async Task<ServiceDescription> ResolveServiceAsync(string address,
                    string service = null,
                    int? port = null, DNSFallback fallback = DNSFallback.Prefix) {

        using var context = Default.GetContext();
        var task = await context.QueryServiceAsync(address, service, port, fallback);
        return task;
        }

    }


/// <summary>
/// Multiple managed DNS queries.
/// </summary>
public abstract class DNSContext : Disposable {

    ///// <summary>The DNS client to use</summary>
    //public DnsClient DNSClient = Goedel.Discovery.DNSClient.Default;

    /// <summary>Scoreboard of current requests.</summary>
    readonly List<DNSRequest> pendingRequests = new();

    /// <summary>The timeout value</summary>
    readonly int timeout;
    readonly int retry;


    static ILogger Logger => Component.Logger;

    CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();

    //Task taskRetry; // A task that expires when it is time to retry requests
    //readonly Task taskTimeout; // A task that expires when it is time to give up

    /// <summary>
    /// A task listening on the DNS port
    /// </summary>
    protected Task<byte[]> TaskListen = null; // listen to the DNS port

    /// <summary>
    /// If true there are pending requests and the context has not timed out
    /// </summary>
    public bool Pending => Active & (pendingRequests.Count > 0);


    /// <summary>
    /// If true, the context has not timed out
    /// </summary>
    public bool Active = true;

    ushort iDCounter;
    ushort NextID {
        get {
            iDCounter = (ushort)((iDCounter + 1) & 0xffff);
            return iDCounter;
            }
        }

    /// <summary>
    /// Dispose allocated resources.
    /// </summary>
    protected override void Disposing() => CancellationTokenSource?.Dispose();

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="timeout">The maximum length of time to wait for a query to be satisfied</param>
    /// <param name="retry">Retry interval.</param>
    public DNSContext(int timeout = 2000, int retry = 500) {
        this.timeout = timeout;
        this.retry = retry;
        iDCounter = (ushort)Goedel.Cryptography.Platform.GetRandomInteger(0x10000);

        //taskTimeout = Task.Delay(this.timeout);
        //taskRetry = Task.Delay(this.retry);

        }

    /// <summary>
    /// Make a DNS request to the default client without waiting for a response
    /// </summary>
    /// <param name="request">DNS request set</param>
    /// <param name="index">The number of times the request has been 
    /// repeated.</param>
    /// <returns>Task instance.</returns>
    public abstract void SendRequest(DNSRequest request, int index=0);


    /// <summary>
    /// Get the next DNS response
    /// </summary>
    /// <returns>The first valid response received.</returns>
    public abstract Task<DNSResponse> GetResponseAsync();


    /// <summary>
    /// Get the next DNS response
    /// </summary>
    /// <returns>The first valid response received.</returns>
    public abstract Task<byte[]> GetResponseRawAsync();

    /// <summary>
    /// Close the context.
    /// </summary>
    public virtual void Close() {
        }

    /// <summary>
    /// Return the next response to a pending DNS request.
    /// </summary>
    /// <returns>Task instance.</returns>
    public virtual async Task<DNSResponse> NextAsync(Task taskTimeout, Task taskRetry) {
        var index = 0;
        while (Active) {
            //Console.WriteLine("Start Any");
            await Task.WhenAny(TaskListen, taskRetry, taskTimeout);
            //Console.WriteLine("Finish Any");


            if (TaskListen.IsCompleted) {
                var Data = TaskListen.Result;
                TaskListen = GetResponseRawAsync();
                var Response = new DNSResponse(Data);

                for (var i = 0; i < pendingRequests.Count; i++) {
                    if (pendingRequests[i].ID == Response.ID) {
                        pendingRequests.RemoveAt(i);
                        return Response;
                        }
                    }
                }

            else {

                //Debug.WriteLine("Problem");
                }
            if (taskTimeout.IsCompleted) { // query has expired
                //Console.WriteLine("Timeout");
                Logger.Timeout(timeout);
                Active = false;
                return null;
                }

            if (taskRetry.IsCompleted) { // attempt a retransmit of the query
                //Console.WriteLine("Resend DNS request");
                foreach (var request in pendingRequests) {
                    index++;
                    SendRequest(request, index);
                    }
                
                taskRetry = Task.Delay(retry);
                }
            }
        return null;
        }


    /// <summary>
    /// Make a DNS request to the default client without waiting for a response
    /// </summary>
    /// <param name="request">DNS request set</param>
    /// <returns>Task instance.</returns>
    public void QueueRequest(DNSRequest request) {
        pendingRequests.Add(request); // always add to the queue first
        SendRequest(request);
        }

    /// <summary>
    /// Make a DNS request to the default client without waiting for a response
    /// </summary>
    /// <param name="address">The DNS address to query</param>
    /// <param name="dnsTypeCode">The DNS Type code to query</param>
    /// <returns>Task instance.</returns>
    public void QueueRequest(string address, DNSTypeCode dnsTypeCode) {
        var request = new DNSRequest(address, dnsTypeCode) {
            Flags = DNSFlags.RD | DNSFlags.OPCODE_QUERY,
            ID = NextID
            };
        QueueRequest(request);
        }


    /// <summary>
    /// Perform Asynchronous query for Service discovery and description records.
    /// </summary>
    /// <param name="address">The address to query</param>
    /// <param name="service">The IANA service name</param>
    /// <param name="port">The default port number to use if no SRV record is found</param>
    /// <param name="fallback">Fallback mode for if no SRV record is found</param>
    /// <returns>Description of the discovered services.</returns>
    public async Task<ServiceDescription> QueryServiceAsync(string address,
                    string service = null, int? port = null,
                    DNSFallback fallback = DNSFallback.Prefix) {

        Logger.Resolution(address, service);
        //Console.WriteLine("Try resolve");
        var serviceDescription = new ServiceDescription(address, service, port, fallback);

        if (service == null) {
            return serviceDescription;
            }



        var taskTimeout = Task.Delay(0);
        var taskRetry = Task.Delay(0);
        //Console.WriteLine($"Timeouts {timeout} {retry}");

        await taskRetry;
        //Console.WriteLine("Retry complete");

        QueueRequest(serviceDescription.ServiceAddress, DNSTypeCode.SRV);
        QueueRequest(serviceDescription.ServiceAddress, DNSTypeCode.TXT);

        while (Pending) {
            //Console.WriteLine("Pending");

            var result = await NextAsync(taskTimeout, taskRetry);
            if (result != null) {
                foreach (var Record in result.Answers) {
                    Add(serviceDescription, Record);
                    }
                foreach (var Record in result.Additional) {
                    Add(serviceDescription, Record);
                    }
                }
            else {
                //Console.WriteLine("timed out");
                }
            }
        //Console.WriteLine("abort");
        if (serviceDescription.Entries.Count == 0) {
            serviceDescription.Fallback(port, fallback);
            }

        return serviceDescription;
        }


    /// <summary>
    /// Add information from the received record iff it is within the baliwick.
    /// </summary>
    /// <param name="serviceDescription">The service description to add to</param>
    /// <param name="record">DNS record to add data from</param>
    void Add(ServiceDescription serviceDescription, DNSRecord record) {
        var domain = record.Domain.Name.ToLower();

        if (record.Code == DNSTypeCode.SRV) {
            var recordSRV = record as DNSRecord_SRV;

            Logger.FoundSrv(domain, recordSRV.Target.Name, recordSRV.Port);

            //Console.WriteLine(String.Format("SRV {0} -> {1}",
            //        Domain, RecordSRV.Target.Name));

            if (domain == serviceDescription.ServiceAddress) {
                var entry = new ServiceEntry() {
                    Address = recordSRV.Target.Name,
                    Port = recordSRV.Port,
                    Priority = recordSRV.Priority,
                    Weight = recordSRV.Weight
                    };
                serviceDescription.Add(entry);
                QueueRequest(entry.HostAddress, DNSTypeCode.TXT);
                }
            }
        else if (record.Code == DNSTypeCode.TXT) {

            var RecordTXT = record as DNSRecord_TXT;


            foreach (var Text in RecordTXT.Text) {
                //Logger.FoundTxt (RecordTXT.Domain, RecordTXT.Text)

                //Debug.WriteLine(String.Format("TXT {0} -> {1}",
                //        domain, Text));
                }


            if (domain == serviceDescription.ServiceAddress) {
                foreach (var txt in RecordTXT.Text) {
                    Logger.FoundTxt(domain, txt);
                    serviceDescription.TXT.Add(txt);
                    }
                }

            else {
                foreach (var entry in serviceDescription.Entries) {
                    if (domain == entry.HostAddress) {
                        foreach (var TXT in RecordTXT.Text) {
                            entry.TXT.Add(TXT);
                            }
                        }
                    }
                }
            }
        else if (record.Code == DNSTypeCode.A) {


            }
        else if (record.Code == DNSTypeCode.AAAA) {


            }

        }


    }
