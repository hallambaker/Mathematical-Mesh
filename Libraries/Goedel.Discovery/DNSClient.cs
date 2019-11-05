using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;


namespace Goedel.Discovery {




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
    public abstract class DNSClient {

        /// <summary>Return a DNS Client Context in which to make a set of queries.
        /// </summary>
        /// <returns>The DNS Client Context</returns>
        public abstract DNSContext GetContext();





        /// <summary>
        /// Resolve a DNS name to an address and service characteristics.
        /// </summary>
        /// <param name="Address">The address to use</param>
        /// <param name="Service">The DNS service prefix</param>
        /// <param name="Port">The default DNS port number</param>
        /// <param name="Fallback">The fallback mode to use if SRV lookup fails</param>
        /// <returns>IP Destination describing the resolution results</returns>
        public static ServiceDescription ResolveService(string Address, string Service = null,
                    int? Port = null, DNSFallback Fallback = DNSFallback.Prefix) {

            var TaskService = ResolveServiceAsync(Address, Service, Port, Fallback);
            TaskService.Wait();

            return TaskService.Result;

            }

        /// <summary>
        /// Perform Asynchronous query for Service discovery and description records
        /// using the platform default DNSClient.
        /// </summary>
        /// <param name="Address">The address to query</param>
        /// <param name="Service">The IANA service name</param>
        /// <param name="Port">The default DNS port number</param>
        /// <param name="Fallback">The fallback mode to use if SRV lookup fails</param> 
        /// <returns>Description of the discovered services.</returns>
        public static async Task<ServiceDescription> ResolveServiceAsync(string Address,
                        string Service = null,
                        int? Port = null, DNSFallback Fallback = DNSFallback.Prefix) {

            var Context = Platform.DNSClient.GetContext();
            return await Context.QueryServiceAsync(Address, Service, Port, Fallback);
            }

        }


    /// <summary>
    /// Multiple managed DNS queries.
    /// </summary>
    public abstract class DNSContext : Disposable {

        /// <summary>The DNS client to use</summary>
        public DNSClient DNSClient = Platform.DNSClient;

        /// <summary>Scoreboard of current requests.</summary>
        List<DNSRequest> pendingRequests = new List<DNSRequest>();

        /// <summary>The timeout value</summary>
        int timeout;
        int retry;

        CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();

        Task taskRetry; // A task that expires when it is time to retry requests
        Task taskTimeout; // A task that expires when it is time to give up

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
        public DNSContext(int timeout = 5000, int retry = 1000) {
            this.timeout = timeout;
            this.retry = retry;
            iDCounter = Platform.GetRandom16();

            taskTimeout = Task.Delay(this.timeout);
            taskRetry = Task.Delay(this.retry);

            }

        /// <summary>
        /// Make a DNS request to the default client without waiting for a response
        /// </summary>
        /// <param name="Request">DNS request set</param>
        /// <returns>Task instance.</returns>
        public abstract void SendRequest(DNSRequest Request);


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
        public virtual async Task<DNSResponse> NextAsync() {

            while (Active) {
                await Task.WhenAny(TaskListen, taskTimeout);

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
                    Debug.WriteLine("Problem");
                    }
                if (taskTimeout.IsCompleted) { // query has expired
                    Active = false;
                    return null;
                    }

                if (taskRetry.IsCompleted) { // attempt a retransmit of the query
                    taskRetry = Task.Delay(retry);
                    }
                }
            return null;
            }


        /// <summary>
        /// Make a DNS request to the default client without waiting for a response
        /// </summary>
        /// <param name="Request">DNS request set</param>
        /// <returns>Task instance.</returns>
        public void QueueRequest(DNSRequest Request) {
            pendingRequests.Add(Request); // always add to the queue first
            SendRequest(Request);
            }

        /// <summary>
        /// Make a DNS request to the default client without waiting for a response
        /// </summary>
        /// <param name="Address">The DNS address to query</param>
        /// <param name="DNSTypeCode">The DNS Type code to query</param>
        /// <returns>Task instance.</returns>
        public void QueueRequest(string Address, DNSTypeCode DNSTypeCode) {
            var Request = new DNSRequest(Address, DNSTypeCode) {
                Flags = DNSFlags.RD | DNSFlags.OPCODE_QUERY,
                ID = NextID
                };
            QueueRequest(Request);
            }


        /// <summary>
        /// Perform Asynchronous query for Service discovery and description records.
        /// </summary>
        /// <param name="Address">The address to query</param>
        /// <param name="Service">The IANA service name</param>
        /// <param name="Port">The default port number to use if no SRV record is found</param>
        /// <param name="Fallback">Fallback mode for if no SRV record is found</param>
        /// <returns>Description of the discovered services.</returns>
        public async Task<ServiceDescription> QueryServiceAsync(string Address,
                        string Service = null, int? Port = null,
                        DNSFallback Fallback = DNSFallback.Prefix) {

            var ServiceDescription = new ServiceDescription(Address, Service, Port, Fallback);

            if (Service == null) {
                return ServiceDescription;
                }

            QueueRequest(ServiceDescription.ServiceAddress, DNSTypeCode.SRV);
            QueueRequest(ServiceDescription.ServiceAddress, DNSTypeCode.TXT);

            while (Pending) {
                var Result = await NextAsync();
                if (Result != null) {
                    foreach (var Record in Result.Answers) {
                        Add(ServiceDescription, Record);
                        }
                    foreach (var Record in Result.Additional) {
                        Add(ServiceDescription, Record);
                        }
                    }
                else {
                    Debug.WriteLine("timed out");
                    }
                }

            if (ServiceDescription.Entries.Count == 0) {
                ServiceDescription.Fallback(Port, Fallback);
                }

            return ServiceDescription;
            }


        /// <summary>
        /// Add information from the received record iff it is within the baliwick.
        /// </summary>
        /// <param name="ServiceDescription">The service description to add to</param>
        /// <param name="Record">DNS record to add data from</param>
        void Add(ServiceDescription ServiceDescription, DNSRecord Record) {
            var Domain = Record.Domain.Name.ToLower();

            if (Record.Code == DNSTypeCode.SRV) {
                var RecordSRV = Record as DNSRecord_SRV;

                Debug.WriteLine(String.Format("SRV {0} -> {1}",
                        Domain, RecordSRV.Target.Name));

                if (Domain == ServiceDescription.ServiceAddress) {
                    var Entry = new ServiceEntry() {
                        Address = RecordSRV.Target.Name,
                        Port = RecordSRV.Port,
                        Priority = RecordSRV.Priority,
                        Weight = RecordSRV.Weight
                        };
                    ServiceDescription.Add(Entry);
                    QueueRequest(Entry.HostAddress, DNSTypeCode.TXT);
                    }
                }
            else if (Record.Code == DNSTypeCode.TXT) {

                var RecordTXT = Record as DNSRecord_TXT;


                foreach (var Text in RecordTXT.Text) {
                    Debug.WriteLine(String.Format("TXT {0} -> {1}",
                            Domain, Text));
                    }


                if (Domain == ServiceDescription.ServiceAddress) {
                    foreach (var TXT in RecordTXT.Text) {
                        ServiceDescription.TXT.Add(TXT);
                        }
                    }

                else {
                    foreach (var Entry in ServiceDescription.Entries) {
                        if (Domain == Entry.HostAddress) {
                            foreach (var TXT in RecordTXT.Text) {
                                Entry.TXT.Add(TXT);
                                }
                            }
                        }
                    }
                }
            else if (Record.Code == DNSTypeCode.A) {


                }
            else if (Record.Code == DNSTypeCode.AAAA) {


                }

            }


        }




    }
