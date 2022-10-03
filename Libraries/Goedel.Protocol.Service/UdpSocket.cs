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


using Goedel.Protocol.Presentation;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Goedel.Protocol.Service;

public delegate byte[] ServiceDispatchDelgate(PacketStream streamId, byte[] request);


/// <summary>
/// UDP socket capable of supporting both the client and service modes.
/// </summary>
public class UdpSocket : Disposable {

    ///<summary>Maximum number of tries to obtain a UDP port.</summary> 
    public static int MaxUdpPortAttempts { get; set; } = 200;

    ///<summary>The default number of listener tasks.</summary> 
    public static int DefaultListenerTasks = 10;


    ///<summary>Minimum time to wait in ticks.</summary> 
    public static int MinimumWait { get; set; } = 15;


    ///<summary>The total number of UDP receive tasks.</summary> 
    public int TotalReceiveTasks => ListenerTasks.Length;

    ///<summary>The number of receive tasks that were in an idle state.</summary> 
    public int IdleReceiveTasks { get; private set; } = 0;



    private UdpClient UdpClient { get; }
    private CancellationTokenSource CancellationTokenSource { get; }


    Task<InboundPacket>[] ListenerTasks;



    // These values are only for use within the receiver.
    Task TaskListener, TaskSender;

    bool active = true;
    ConnectionIdGenerator ConnectionIdNext { get; } 
    ICryptoTransform Encryptor { get; }
    ICryptoTransform Decryptor { get; }

    Dictionary<ConnectionId, PacketConnection> ReceiverDictionary { get; } = new();

    ///<summary>The IP Endpoint (Address, port).</summary> 
    public IPEndPoint IPEndPoint { get; }


    CancellationToken CancellationToken { get; }

    BufferBlock<PacketConnection> OutboundConnectionQueue { get; } = new();

    BufferBlock<OutboundData> OutboundDataQueue { get; } 

    BufferBlock<PacketConnection> InboundConnectionQueue { get; } = new();

    int TimeOut {  get; set; } = 1000;

    /// <summary>
    /// Disposing method. Performs shutdown on the listener.
    /// </summary>
    protected override void Disposing() {
        active = false;
        CancellationTokenSource.Cancel();

        }

    #region // Constructor
    /// <summary>
    /// Return a UDP listener socket bound to a randomly chosen port. If 
    /// <paramref name="address"/> is not null, the listener is bound to that address,
    /// otherwise the listener is bound to all inbound addresses.
    /// </summary>
    /// <param name="address">The inbound address.</param>
    public UdpSocket(
                IPAddress address = null,
                int listenerTaskCount = 0,
                byte[]? randomSeed = null) {

        CancellationTokenSource = new CancellationTokenSource();
        CancellationToken = CancellationTokenSource.Token;

        int port = 0;
        address ??= IPAddress.Any;
        UdpClient = GetUdpPort(address, ref port);
        IPEndPoint = new IPEndPoint(address, port);

        (Encryptor, Decryptor) = Cryptography.Platform.GetAes128FromSeed("UdpSocket", randomSeed);

        Decryptor = new NullTransform16();
        Encryptor = new NullTransform16();
        ConnectionIdNext = new(Decryptor);


        // set up the listener tasks to buffer UDP input.
        listenerTaskCount = listenerTaskCount > 0 ? listenerTaskCount : DefaultListenerTasks;
        ListenerTasks = new Task<InboundPacket>[listenerTaskCount];
        for (var i = 0; i < ListenerTasks.Length; i++) {
            ListenerTasks[i] = GetPacketAsync();
            }

        // start the listener process.
        TaskListener = WaitListenerAsync();
        TaskSender = WaitSenderAsync();
        }


    #endregion




    /// <summary>
    /// Return the next connection handle. 
    /// </summary>
    /// <param name="initiator">If true, the connection was initiated locally, otherwise,
    /// the connection was initiated remotely.</param>
    /// <returns></returns>
    PacketConnection GetNextConnection(bool initiator) {
        lock (ReceiverDictionary) {
            var connectionId = ConnectionIdNext.GetNext();
            var result = new PacketConnection(this, connectionId, initiator);
            ReceiverDictionary.Add(connectionId, result);
            return result;
            }
        }

    #region // Receive dispatch loop

    /// <summary>
    /// Begin servicing tasks.
    /// </summary>
    /// <returns>The listener task.</returns>
    public async Task WaitListenerAsync() {
        // ??? Should probably kill outbound data here.
        //var outboundData = new OutboundData();

        while (active) {
            try {
                await Task.WhenAny(ListenerTasks);

                var idle = ListenerTasks.Length;
                for (var i = 0; i < ListenerTasks.Length; i++) {
                    var task = ListenerTasks[i];
                    if (task.IsCompleted) {
                        var packet = task.Result;
                        if (packet.ConnectionId.IsInitial) {
                            var connection = GetNextConnection(false);
                            connection.ProcessInitial(packet);
                            }
                        else {
                            if (TryGetReceiverId(packet.ConnectionId, out var connection)) {
                                connection.ProcessPacket(packet);
                                }
                            else {
                                HandleUnknownStream(packet);
                                }
                            }
                        // requeue request
                        ListenerTasks[i] = GetPacketAsync();
                        idle--;
                        }
                    }
                //if (outboundData.HasPending) {
                //    OutboundDataQueue.Post(outboundData);
                //    outboundData = new OutboundData();
                //    }
                IdleReceiveTasks = idle;
                }
            catch (OperationCanceledException) {
                }
            }
        }

    bool TryGetReceiverId (ConnectionId connectionId, out PacketConnection connection) {
        lock (ReceiverDictionary) {
            return ReceiverDictionary.TryGetValue(connectionId, out connection);
            }
        }




    /// <summary>
    /// Await receipt of a packet, extract the stream ID and return the result.
    /// </summary>
    /// <returns></returns>
    async Task<InboundPacket> GetPacketAsync() {
        var udpResult = await UdpClient.ReceiveAsync(CancellationToken);
        return new InboundPacket(udpResult, Decryptor);
        }

    /// <summary>
    /// Handle an inbound request with an unknown stream ID.
    /// </summary>
    /// <param name="inboundPacket"></param>
    async void HandleUnknownStream(InboundPacket inboundPacket) {
        // Do nothing for now
        inboundPacket.Future();
        this.Future();
        await Task.Delay(0);  // avoid compiler nagging.
        }



    #endregion
    #region // Sender dispatch loop

    /// <summary>
    /// The sender dispatch loop
    /// </summary>
    /// <returns>Task handle.</returns>
    public async Task WaitSenderAsync() {

        var nextWake = DateTime.MaxValue.Ticks;
        var timeNow = DateTime.Now.Ticks;

        var waitInterval = new TimeSpan(nextWake - timeNow);


        // change this so that the loop waits for the next connection with work to do.
        // then construct the next packet to send
        // send the next packet
        // ?? wait if more than n packets are in the send queue




        while (active) {
            try {
                var task = OutboundConnectionQueue.ReceiveAsync(waitInterval, CancellationToken);
                await task;

                if (task.IsCompleted) {
                    // process the new work items here
                    }

                // Initialize the timer
                timeNow = DateTime.Now.Ticks;

                // Perform all actions defered until this time.
                var expired = timeNow + MinimumWait;
                waitInterval = new TimeSpan(nextWake - timeNow);
                }

            catch (OperationCanceledException) {
                }
            }

        }

    public async Task Queue(PacketConnection packetConnection) => await
        OutboundConnectionQueue.SendAsync(packetConnection);


    #endregion

    /// <summary>
    /// Create an outbound connection request for the 
    /// </summary>
    /// <param name="ipEndPoint"></param>
    /// <returns></returns>
    public PacketConnection ReserveConnection(IPEndPoint ipEndPoint) {

        var result = GetNextConnection(true);
        result.ConnectionState = ConnectionState.OutboundInitial;
        result.InitialEndpoint = ipEndPoint;
        return result;
        }

    /// <summary>
    /// Wait asynchronously for an inbound connection request.
    /// </summary>
    /// <returns>The first request received if requests are pending, otherwise,
    /// waits asynchronously for the next request.</returns>
    public async Task<PacketConnection> GetConnectionAsync() =>
        await InboundConnectionQueue.ReceiveAsync();


    public async Task<PacketConnection> GetConnection(IPEndPoint IPEndPoint) {
        throw new NYI();
        }



    public ServiceBinding BindService(
            string serviceName,
            ServiceDispatchDelgate serviceDispatchDelgate) {
        throw new NYI();
        }






    public async Task<Frame> PostTransactionAsync(Frame frame) {

        // 


        throw new NYI();
        }


    /// <summary>
    /// Resolve a DNS name to an address and service characteristics.
    /// </summary>
    /// <param name="address">The address to use</param>
    /// <param name="service">The DNS service prefix</param>
    /// <param name="port">The default DNS port number</param>
    /// <param name="fallback">The fallback mode to use if SRV lookup fails</param>
    /// <returns>IP Destination describing the resolution results</returns>
    public async Task<ServiceEntry> GetServiceAsync(
            string address, 
            string service = null,
            int? port = null, 
            DNSFallback fallback = DNSFallback.Prefix) {


        // form the request

        var request = new Frame() {
            };

        var response = PostTransactionAsync(request);


        throw new NYI();
        }

    public static UdpClient GetUdpPort(IPAddress address, ref int port) {

        for (var tries = 0; tries < MaxUdpPortAttempts; tries++) {
            try {
                // attempt to allocate a randomly allocated port
                port = Goedel.Cryptography.Platform.GetRandomPort();
                var UdpClient = new UdpClient(port);
                return UdpClient;
                }
            catch {
                }
            }

        port = Goedel.Cryptography.Platform.GetRandomPort();
        return new UdpClient(port);
        }



    }
