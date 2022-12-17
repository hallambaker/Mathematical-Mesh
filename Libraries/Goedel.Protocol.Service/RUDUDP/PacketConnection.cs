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


//using System.Diagnostics.Metrics;
//using System.Runtime.CompilerServices;

//namespace Goedel.Protocol.Service;

///// <summary>
///// Connection states
///// </summary>
//public enum ConnectionState {
//    ///<summary>The connection hasw been established.</summary> 
//    Connected = 0,

//    ///<summary>The connection identifier has been reserved but
//    ///contact has not yet been made.</summary> 
//    OutboundInitial = 1,

//    ///<summary>The initial connection request has been sent.</summary> 
//    OutboundSent = 2,

//    ///<summary>A connection request has been received.</summary> 
//    InboundReceived = 16,


//    ///<summary>A connection request with an invalid connection identifier 
//    ///was received.</summary> 
//    Invalid = -1
//    }


///// <summary>
///// Record tracking the position in the queue.
///// </summary>
//public record QueueEntry : IComparable {

//    private static uint index = 0;

//    ///<summary>The next time at which to wake in ticks.</summary> 
//    public long NextWakeTicks { get; private set; } = 0;

//    ///<summary>Unique serial number.</summary> 
//    public long Serial { get; private set; } = Interlocked.Increment(ref index);

//    /// <summary>
//    /// Perform thread safe comparison of this instance to <paramref name="obj"/>.
//    /// If the instances are equal, return 0, otherwise if this instance is earliest, 
//    /// return -1, otherwise return 1.
//    /// </summary>
//    /// <param name="obj">An object of type QueueEntry to compare with this instance.</param>
//    /// <returns>The result of the comparison.</returns>
//    /// <exception cref="ArgumentNullException"><paramref name="obj"/> is null.</exception>
//    /// <exception cref="ArgumentException"><paramref name="obj"/> </exception>
//    public int CompareTo(object? obj) {
//        if (obj == null) {
//            throw new ArgumentNullException(nameof(obj));
//            }
//        var other = obj as QueueEntry;
//        if (other == null)  {
//            throw new ArgumentException($"Argument not of type {nameof(QueueEntry)}", nameof(obj));
//            }

//        if (NextWakeTicks < other.NextWakeTicks) {
//            return -1;
//            }

//        if (NextWakeTicks > other.NextWakeTicks) {
//            return 1;
//            }

//        if (Serial == other.Serial) {
//            return 0;
//            }

//        var index2 = index;

//        return ((Serial + NextWakeTicks) % index2) > other.Serial ? -1 : 1;

//        }
//    }


///// <summary>
///// Record representing and processing stream identifiers.
///// </summary>
//public class PacketConnection {


//    #region // Connection description.
//    ///<summary>The connection state.</summary> 
//    public ConnectionState ConnectionState { get; set; }



//    #endregion
//    #region // Track outbound packets.
//    ///<summary>Specify the next wake time.</summary> 
//    ///<remarks>MUST lock the PacketConnection instance before reading or
//    ///writing.</remarks>
//    public QueueEntry QueueEntry = new ();

//    ///<summary>If true, the connection has pending items to send.</summary> 
//    public bool IsPending => QueueEntry.NextWakeTicks > 0;

//    ///<summary>List of pending work items not scheduled to packets.</summary> 
//    List<PendingItem> PendingItems { get; } = new();

//    ///<summary>Sorted list of unacknowledged packets, earliest first.</summary> 
//    ///<remarks>MUST lock the PacketConnection instance before reading or
//    ///writing.</remarks>
//    List<PacketOutbound> Unacknowledged = new();


//    ///<summary>Flag set when we already have pending work items queued for
//    ///processing by the socket.</summary> 
//    ///<remarks>MUST lock the PacketConnection instance before reading or
//    ///writing.</remarks>
//    public bool QueuedPending { get; set; } = false;

//    ///<summary>The packet serial number.</summary> 
//    public ulong PacketOutboundSerial { get; private set; } = 0;

//    ///<summary>Acknowledgements have been received for all outbound 
//    ///packets with this serial or less.</summary> 
//    public ulong Acknowledge { get; private set; } = 0;

//    ///<summary>Counterparty has acknowledged receipt of packet
//    ///containing this acknowledgement field.</summary> 
//    public ulong AcknowledgeAcknowledged { get; private set; } = 0;


//    #endregion
//    #region // Inbound packet management
//    ///<summary>The next packet serial number expected</summary> 
//    public ulong PacketExpecting { get; private set; } = 0;
    
//    ///<summary>The serial number of the latest inbound packet. We only 
//    ///process acknowledgements on the very latest packet received.</summary> 
//    public ulong PacketInboundLatest { get; private set; } = 0;


//    #endregion

//    ///<summary>The next time at which a UDP packet can be sent in ticks.</summary> 
//    public long NextSendTicks { get; private set; } = 0;


//    ///<summary>The first IP endpoint to which a connection request is issued or
//    ///from which a request was received.</summary> 
//    public IPEndPoint InitialEndpoint { get; set; }

//    ///<summary>Packet length in bytes for the connection.</summary> 
//    public int PacketLengthBytes { get; private set; } = 1200;


//    ///<summary>The connection identifier.</summary> 
//    public ConnectionId ConnectionID { get; set; }



//    ///<summary>Stream identifier generator, returns a unique serial number each time
//    ///it is called.</summary> 
//    public StreamIdGenerator StreamIdGenerator { get; }

//    ///<summary>The parent socket.</summary> 
//    public UdpSocket UdpSocket { get; }


//    ///<summary>Buffer used to store inbound packet stream being offered.</summary> 
//    public BufferBlock<PacketStream> PacketStreamBuffer { get; } = new();

//    ///<summary>Maps from the stream identifier assigned by the local end of the connection
//    ///to the stream handle.</summary> 
//    Dictionary<StreamId, PacketStream> DictionaryStream{ get; } = new();


//    ///<summary>The maximum window size</summary> 
//    public ushort WindowSize { get; private set; }


//    ICryptoTransform Encryptor { get; set; }

//    ICryptoTransform Decryptor { get; set; }



//    /// <summary>
//    /// Constructor returning a stream identifier for the endpoint <paramref name="connectionID"/>.
//    /// </summary>
//    /// <param name="connectionID">The connection identifier.</param>
//    /// <param name="initiator">If true, the connection was created locally and will have an 
//    /// even stream ID. Otherwise, the streamID will be false.</param>
//    /// <param name="udpSocket">The parent UDP socket</param>
//    /// <param name="windowSize">The window size (if 0, the default value is used).</param>
//    public PacketConnection(UdpSocket udpSocket, ConnectionId connectionID, bool initiator, int windowSize = 0) {
//        UdpSocket = udpSocket;
//        StreamIdGenerator = new (initiator);
//        ConnectionState = ConnectionState.OutboundInitial;
//        ConnectionID = connectionID;
//        WindowSize = (ushort) (windowSize == 0 ? PacketUDP.DefaultWindowSize : windowSize);
//        }


//    /// <summary>
//    /// Return a new container for preparing a set of pending items.
//    /// </summary>
//    /// <param name="priority">The priority to assign to the list. Higher values
//    /// have higher priority.</param>
//    /// <returns>Pending items container.</returns>
//    public Pending BeginPending(int priority=0) => new(this, priority);

//    /// <summary>
//    /// Thread safe commit of a series of work items specified in
//    /// <paramref name="pendingItems"/>.
//    /// </summary>
//    /// <param name="pendingItems">The work items to add.</param>
//    public async Task CommitAsync(List<PendingItem> pendingItems) {
//        if (pendingItems.Count == 0) ;

//        bool queuedPending;
//        lock (this) {
//            queuedPending = QueuedPending;
//            QueuedPending = true;
//            foreach (var item in pendingItems) {
//                PendingItems.Add(item); 
//                // NYI: Should add code so that lists can be insrted according to priority.
//                }
//            }
//        if (queuedPending) {
//            await UdpSocket.Queue(this);
//            }
//        }


//    /// <summary>
//    /// Thread safe commit of a work item specified in <paramref name="item"/>.
//    /// </summary>
//    /// <param name="item">The work item to add.</param>
//    public async Task CommitAsync(PendingItem item) {
//        bool queuedPending;
//        lock (this) {
//            queuedPending = QueuedPending;
//            QueuedPending = true;
//            PendingItems.Add(item);
//            // NYI: Should add code so that lists can be inserted according to priority.
//            }
//        if (queuedPending) {
//            await UdpSocket.Queue(this);
//            }
//        }

//    /// <summary>
//    /// Asynchronously queue this connection as an outbound work item.
//    /// </summary>
//    /// <returns></returns>
//    public async Task CommitAsync() {

//        if (!QueuedPending) {
//            // we always set QueuedPending before queuing ourselves as a work item.
//            QueuedPending = true;
//            await UdpSocket.Queue(this);
//            }
//        }


//    /// <summary>
//    /// 
//    /// </summary>
//    /// <remarks>This routine is NOT thread safe as it is only to be called by the 
//    /// sender task that services the connection.</remarks>
//    /// <returns></returns>
//    public byte[]? QueueOutbound() {


//        // first check to see if we have any expired pending acknowledgment.

//        // now find the first 


//        if (Unacknowledged[PacketOutboundSerial % WindowSize] != null) {
//            return null;
//            }



//        // construct the next outbound packet to be sent to connection.

//        var packetOutbound = new PacketOutbound (PacketLengthBytes);
//        byte[] token = null;

//        switch (ConnectionState) {
//            case ConnectionState.OutboundInitial: {
//                token = ConnectionId.InitialPacket;
//                break;
//                }
//            case ConnectionState.InboundReceived: {
//                break;
//                }
//            default: throw new NYI();
//            }

//        bool pending = PendingItems.Count > 0;
//        while (pending){
//            Console.WriteLine("Add item");

//            var item = PendingItems[0];
//            var completed = false;

//            switch (item) {
//                case PendingStream pendingStream: {
//                    completed = packetOutbound.OpenStream(pendingStream);
//                    break;
//                    }
//                case PendingPost pendingPost: {
//                    completed = packetOutbound.PostData(pendingPost);
//                    break;
//                    }
//                }

//            if (completed) {
//                PendingItems.RemoveAt(0);
//                pending = PendingItems.Count > 0;
//                }
//            else {
//                pending = false;
//                }

//            }


//        Unacknowledged[PacketOutboundSerial % WindowSize] = packetOutbound;

//        packetOutbound.Pad();
//        switch (ConnectionState) {
//            case ConnectionState.OutboundInitial: {
//                return packetOutbound.Plaintext;
//                }
//            default: {
//                return packetOutbound.Encrypt(token, PacketOutboundSerial++, PacketExpecting,
//                    Acknowledge, Encryptor);

//                }
//            }
//        }


//    public bool TryGetStream (StreamId streamId, out PacketStream packetStream) =>
//        DictionaryStream.TryGetValue (streamId, out  packetStream);




//    /// <summary>
//    /// Post the request data <paramref name="message"/> to the service 
//    /// <paramref name="serviceId"/> and return the response asynchronously.
//    /// </summary>
//    /// <param name="serviceId"></param>
//    /// <param name="message"></param>
//    /// <returns></returns>
//    /// <exception cref="NotImplementedException"></exception>
//    public Task<byte[]> ServiceRequest (string serviceId, byte[] message) {
//        throw new NotImplementedException();
//        }


//    /// <summary>
//    /// Wait asynchronously for an inbound request to create a stream and return a 
//    /// <see cref="PacketStream"/> handle for the stream created.
//    /// </summary>
//    /// <returns>The next stream request received.</returns>
//    public Task<PacketStream> GetStreamAsync() => PacketStreamBuffer.ReceiveAsync();



//    /// <summary>
//    /// Process the packet <paramref name="inboundPacket"/> as connection creation
//    /// request packet.
//    /// </summary>
//    /// <param name="inboundPacket">The packet to process.</param>
//    public void ProcessInitial(PacketInbound inboundPacket) {

//        // Here we put all the code to handle setting up the cryptography.

//        }



//    public void ProcessPacket(PacketInbound inboundPacket) {

//        inboundPacket.ParseHeader(Decryptor);

//        var serial = inboundPacket.Serial;
//        if (serial < AcknowledgeAcknowledged) {
//            serial += ushort.MaxValue;
//            }

//        // is this the next packet we are expecting?
//        if (serial < PacketExpecting) {
//            return; // Have already handled this packet, ignore.
//            }


//        if (serial >= PacketInboundLatest) {
//            // here we handle acknowledgements
//            ProcessAcknowledgements(inboundPacket, serial);
//            }

//        if (serial > PacketExpecting) {
//            Queue(inboundPacket);
//            return; // This packet was received out of order, ignore it.
//            }



//        // if so, we can process the entire queue


//        // otherwise we have to postpone processing till we have a complete set.
//        Process(inboundPacket);



//        }


//    void ProcessAcknowledgements(PacketInbound inboundPacket, int serial) {
//        }

//    void Process(PacketInbound inboundPacket) {
//        bool active = true;

//        while (active) {
//            active = inboundPacket.GetChunk (this);
//            }
//        }


//    internal void Error(PendingItem pendingItem) {
//        }

//    void Queue(PacketInbound inboundPacket) {
//        }


//    internal void Deliver(StreamId streamId, byte[] label) {
//        var stream = new PacketStream() {
//            PacketConnection = this,
//            StreamId = streamId,
//            Label = label
//            };

//        DictionaryStream.Add(streamId, stream);

//        PacketStreamBuffer.Post(stream);
//        }

//    }
