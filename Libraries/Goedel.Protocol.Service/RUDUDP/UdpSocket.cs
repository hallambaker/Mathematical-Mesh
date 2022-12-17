//#region // Copyright - MIT License
////  © 2021 by Phill Hallam-Baker
////  
////  Permission is hereby granted, free of charge, to any person obtaining a copy
////  of this software and associated documentation files (the "Software"), to deal
////  in the Software without restriction, including without limitation the rights
////  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
////  copies of the Software, and to permit persons to whom the Software is
////  furnished to do so, subject to the following conditions:
////  
////  The above copyright notice and this permission notice shall be included in
////  all copies or substantial portions of the Software.
////  
////  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
////  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
////  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
////  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
////  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
////  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
////  THE SOFTWARE.
//#endregion


//using Goedel.Cryptography;
//using Goedel.Protocol.Presentation;
//using System.Net;
//using System.Net.Sockets;
//using System.Threading.Tasks;
//using System.Threading.Tasks.Dataflow;

//namespace Goedel.Protocol.Service;

//public delegate byte[] ServiceDispatchDelgate(PacketStream streamId, byte[] request);


///// <summary>
///// UDP socket capable of supporting both the client and service modes.
///// </summary>

//public class UdpSocket : Disposable {

//    ///<summary>Maximum number of tries to obtain a UDP port.</summary> 
//    public static int MaxUdpPortAttempts { get; set; } = 200;

//    ///<summary>The default number of listener tasks.</summary> 
//    public static int DefaultListenerTasks = 10;

//    ///<summary>Minimum time to wait in ticks.</summary> 
//    public static int MinimumWait { get; set; } = 15;


//    #region // Default connection parameters
//    ///<summary>The default initial retransmision timeout in milliseconds.</summary> 
//    public static int DefaultInitialTimeoutData { get; set; } = 3000;


//    ///<summary>The default number of data retransmissions.</summary> 
//    public static int DefaultMaxRetransmissionData { get; set; } = 5;

//    ///<summary>For a connection configured to perform NAT Keepalive, the
//    ///default minimum time between retransmission in milliseconds.</summary> 
//    public static int DefaultTimeoutNatKeepalive { get; set; } = 30000;

//    ///<summary>The default number of data retransmissions.</summary> 
//    public static int DefaultMaxRetransmissionNatKeepalive { get; set; } = 5;

//    ///<summary>The default maximum connection request queue size.</summary> 
//    public static int DefaultMaxQueueConnection { get; set; } = 5;
//    #endregion

//    #region // Connection parameters

//    ///<summary>The retransmision timeout in milliseconds.</summary> 
//    public int TimeoutData { get; set; } = DefaultInitialTimeoutData;


//    ///<summary>The default number of data retransmissions.</summary> 
//    public int MaxRetransmissionData { get; set; } = DefaultMaxRetransmissionData;

//    ///<summary>For a connection configured to perform NAT Keepalive, the
//    ///default minimum time between retransmission in milliseconds.</summary> 
//    public int TimeoutNatKeepalive { get; set; } = DefaultTimeoutNatKeepalive;

//    ///<summary>The default number of data retransmissions.</summary> 
//    public int MaxRetransmissionNatKeepalive { get; set; } = DefaultMaxRetransmissionNatKeepalive;

//    ///<summary>The default maximum connection request queue size.</summary> 
//    public int MaxQueueConnection { get; set; } = DefaultMaxQueueConnection;

//    #endregion

//    ///<summary>The total number of UDP receive tasks.</summary> 
//    public int TotalReceiveTasks => ListenerTasks.Length;

//    ///<summary>The number of receive tasks that were in an idle state.</summary> 
//    public int IdleReceiveTasks { get; private set; } = 0;



//    private UdpClient UdpClient { get; }
//    private CancellationTokenSource CancellationTokenSource { get; }


//    Task<PacketInbound>[] ListenerTasks;



//    // These values are only for use within the receiver.
//    Task TaskListener, TaskSender;

//    bool active = true;
//    ConnectionIdGenerator ConnectionIdNext { get; } 
//    ICryptoTransform Encryptor { get; }
//    ICryptoTransform Decryptor { get; }

//    Dictionary<ConnectionId, PacketConnection> ReceiverDictionary { get; } = new();

//    ///<summary>The IP Endpoint (Address, port).</summary> 
//    public IPEndPoint IPEndPoint { get; }


//    CancellationToken CancellationToken { get; }

//    BufferBlock<PacketConnection> OutboundConnectionQueue { get; } = new();

//    BufferBlock<OutboundData> OutboundDataQueue { get; }

//    ///<summary>Dispatch queue for receipt of inbound connections.</summary> 
//    BufferBlock<PacketConnection> InboundConnectionQueue { get; } = new();

//    int TimeOut {  get; set; } = 1000;



//    SortedList<QueueEntry, PacketConnection> PendingConnections { get; } = new();



//    /// <summary>
//    /// Disposing method. Performs shutdown on the listener.
//    /// </summary>
//    protected override void Disposing() {
//        active = false;
//        CancellationTokenSource.Cancel();

//        }

//    #region // Constructor
//    /// <summary>
//    /// Return a UDP listener socket bound to a randomly chosen port. If 
//    /// <paramref name="address"/> is not null, the listener is bound to that address,
//    /// otherwise the listener is bound to all inbound addresses.
//    /// </summary>
//    /// <param name="address">The inbound address.</param>
//    public UdpSocket(
//                IPAddress address = null,
//                int listenerTaskCount = 0,
//                byte[]? randomSeed = null) {

//        CancellationTokenSource = new CancellationTokenSource();
//        CancellationToken = CancellationTokenSource.Token;

//        int port = 0;
//        address ??= IPAddress.Any;
//        UdpClient = GetUdpPort(address, ref port);
//        IPEndPoint = new IPEndPoint(address, port);

//        (Encryptor, Decryptor) = Cryptography.Platform.GetAes128FromSeed("UdpSocket", randomSeed);

//        Decryptor = new NullTransform16();
//        Encryptor = new NullTransform16();
//        ConnectionIdNext = new(Decryptor);


//        // set up the listener tasks to buffer UDP input.
//        listenerTaskCount = listenerTaskCount > 0 ? listenerTaskCount : DefaultListenerTasks;
//        ListenerTasks = new Task<PacketInbound>[listenerTaskCount];
//        for (var i = 0; i < ListenerTasks.Length; i++) {
//            ListenerTasks[i] = GetPacketAsync();
//            }

//        // start the listener process.
//        TaskListener = WaitListenerAsync();
//        TaskSender = WaitSenderAsync();
//        }


//    #endregion




//    /// <summary>
//    /// Return the next connection handle. 
//    /// </summary>
//    /// <param name="initiator">If true, the connection was initiated locally, otherwise,
//    /// the connection was initiated remotely.</param>
//    /// <returns></returns>
//    PacketConnection GetNextConnection(bool initiator) {
//        lock (ReceiverDictionary) {
//            var connectionId = ConnectionIdNext.GetNext();
//            var result = new PacketConnection(this, connectionId, initiator);
//            ReceiverDictionary.Add(connectionId, result);
//            return result;
//            }
//        }

//    #region // Receive dispatch loop

//    /// <summary>
//    /// Begin servicing tasks.
//    /// </summary>
//    /// <returns>The listener task.</returns>
//    public async Task WaitListenerAsync() {
//        while (active) {
//            try {
//                await Task.WhenAny(ListenerTasks);
//                Console.WriteLine("Received Packet");

//                var idle = ListenerTasks.Length;
//                for (var i = 0; i < ListenerTasks.Length; i++) {
//                    var task = ListenerTasks[i];
//                    if (task.IsCompleted) {
//                        var packet = task.Result;
//                        if (packet.ConnectionId.IsInitial) {
//                            var connection = GetNextConnection(false);
//                            Console.WriteLine("Got connection - post");
//                            connection.ProcessInitial(packet);

//                            InboundConnectionQueue.Post(connection);

//                            connection.ProcessPacket(packet);
//                            }
//                        else {
//                            if (TryGetReceiverId(packet.ConnectionId, out var connection)) {
//                                connection.ProcessPacket(packet);
//                                }
//                            else {
//                                HandleUnknownStream(packet);
//                                }
//                            }
//                        // requeue request
//                        ListenerTasks[i] = GetPacketAsync();
//                        idle--;
//                        }
//                    }
//                IdleReceiveTasks = idle;
//                }
//            catch (OperationCanceledException) {
//                }
//            }
//        }

//    bool TryGetReceiverId (ConnectionId connectionId, out PacketConnection connection) {
//        lock (ReceiverDictionary) {
//            return ReceiverDictionary.TryGetValue(connectionId, out connection);
//            }
//        }




//    /// <summary>
//    /// Await receipt of a packet, extract the stream ID and return the result.
//    /// </summary>
//    /// <returns></returns>
//    async Task<PacketInbound> GetPacketAsync() {
//        var udpResult = await UdpClient.ReceiveAsync(CancellationToken);
//        return new PacketInbound(udpResult, Decryptor);
//        }

//    /// <summary>
//    /// Handle an inbound request with an unknown stream ID.
//    /// </summary>
//    /// <param name="inboundPacket"></param>
//    async void HandleUnknownStream(PacketInbound inboundPacket) {
//        // Do nothing for now
//        inboundPacket.Future();
//        this.Future();
//        await Task.Delay(0);  // avoid compiler nagging.
//        }



//    #endregion
//    #region // Sender dispatch loop

//    ///<summary>Maximum wait time. This is <see cref="Int32.MaxValue"/> ticks for
//    ///reasons internal to the stack.</summary> 
//    readonly TimeSpan MaxWait = new (Int32.MaxValue);



//    /// <summary>
//    /// The sender dispatch loop
//    /// </summary>
//    /// <returns>Task handle.</returns>
//    public async Task WaitSenderAsync() {


//        //var waitInterval = new TimeSpan(nextWake - timeNow);
//        TimeSpan waitInterval;

//        // change this so that the loop waits for the next connection with work to do.
//        // then construct the next packet to send
//        // send the next packet
//        // ?? wait if more than n packets are in the send queue

//        //ValueTask<int>? SendTask = null;


//        Task<PacketConnection> task=null;
//        while (active) {
//            try {
//                if (PendingConnections.Count == 0) {
//                    waitInterval = MaxWait;
//                    }
//                else {
//                    var wake = NextWake();

//                    while (wake <= 0) {
//                        ProcessQueueHead();

//                        // Check to see if a new request was received.
//                        if (OutboundConnectionQueue.TryReceive(out var waiting)) {
//                            lock (waiting) {
//                                waiting.QueuedPending = false; // reset the wake up toggle.

//                                // Queue the connection for processing if either it wasn't
//                                // queued already or the attention time has changed.
//                                if (!PendingConnections.ContainsKey(waiting.QueueEntry)) {
//                                    PendingConnections.Add(waiting.QueueEntry, waiting);
//                                    }
//                                }
//                            }

//                        wake = NextWake();
//                        }

//                    waitInterval = wake > Int32.MaxValue ? MaxWait : new TimeSpan(wake);
//                    }



//                task = OutboundConnectionQueue.ReceiveAsync(waitInterval, CancellationToken);
//                //var task = OutboundConnectionQueue.ReceiveAsync(CancellationToken);
//                Console.WriteLine("Wait Sender");
//                var connection = await task;


//                if (task.IsCompleted) {
//                    Console.WriteLine("Got work");
//                    // here check to see if we have filled the transmit window.

//                    Console.WriteLine("Compiled Packet");
//                    SendPackets(connection);

//                    Console.WriteLine("Sent Packet");
//                    // process the new work items here
//                    }

//                else {
//                    Console.WriteLine("timeout");
//                    }

//                }

//            catch (OperationCanceledException) {
//                Console.WriteLine("cancelled");
//                }
//            catch (Exception e){
//                Console.WriteLine($"timeout! {task?.IsCompleted}");
//                SendPackets(connection);
//                }
//            }


//        Console.WriteLine("Terminate Sender");

//        }

//    long NextWake() {
//        return PendingConnections.Keys[0].NextWakeTicks - DateTime.Now.Ticks;
//        }

//    void ProcessQueueHead() {
//        // take the work item from the head of the queue.

//        // Are we ready to process it?


//        // Remove from head of queue


//        // Dispatch it.


//        // Requeue?
//        }



//    async void SendPackets(PacketConnection connection) {
//        ValueTask<int> SendTask;


//        var packet = connection.QueueOutbound();
//        SendTask = UdpClient.SendAsync(packet, connection.InitialEndpoint);

//        await SendTask;


//        }




//    public async Task Queue(PacketConnection packetConnection) {
//        OutboundConnectionQueue.Post(packetConnection);

//        //var queued = await OutboundConnectionQueue.SendAsync(packetConnection);
//        Console.WriteLine($"Queued");
//        }

//    #endregion

//    /// <summary>
//    /// Create an outbound connection request for the 
//    /// </summary>
//    /// <param name="ipEndPoint"></param>
//    /// <returns></returns>
//    public PacketConnection ReserveConnection(IPEndPoint ipEndPoint) {

//        var result = GetNextConnection(true);
//        result.ConnectionState = ConnectionState.OutboundInitial;
//        result.InitialEndpoint = ipEndPoint;
//        return result;
//        }

//    /// <summary>
//    /// Wait asynchronously for an inbound connection request.
//    /// </summary>
//    /// <returns>The first request received if requests are pending, otherwise,
//    /// waits asynchronously for the next request.</returns>
//    public async Task<PacketConnection> GetConnectionAsync() =>
//        await InboundConnectionQueue.ReceiveAsync();


//    public async Task<PacketConnection> GetConnection(IPEndPoint IPEndPoint) {
//        throw new NYI();
//        }



//    public ServiceBinding BindService(
//            string serviceName,
//            ServiceDispatchDelgate serviceDispatchDelgate) {
//        throw new NYI();
//        }






//    public async Task<Frame> PostTransactionAsync(Frame frame) {

//        // 


//        throw new NYI();
//        }


//    /// <summary>
//    /// Resolve a DNS name to an address and service characteristics.
//    /// </summary>
//    /// <param name="address">The address to use</param>
//    /// <param name="service">The DNS service prefix</param>
//    /// <param name="port">The default DNS port number</param>
//    /// <param name="fallback">The fallback mode to use if SRV lookup fails</param>
//    /// <returns>IP Destination describing the resolution results</returns>
//    public async Task<ServiceEntry> GetServiceAsync(
//            string address, 
//            string service = null,
//            int? port = null, 
//            DNSFallback fallback = DNSFallback.Prefix) {


//        // form the request

//        var request = new Frame() {
//            };

//        var response = PostTransactionAsync(request);


//        throw new NYI();
//        }

//    public static UdpClient GetUdpPort(IPAddress address, ref int port) {

//        for (var tries = 0; tries < MaxUdpPortAttempts; tries++) {
//            try {
//                // attempt to allocate a randomly allocated port
//                port = Goedel.Cryptography.Platform.GetRandomPort();
//                var UdpClient = new UdpClient(port);
//                return UdpClient;
//                }
//            catch {
//                }
//            }

//        port = Goedel.Cryptography.Platform.GetRandomPort();
//        return new UdpClient(port);
//        }



//    }
