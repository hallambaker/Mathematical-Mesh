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


using System.Runtime.CompilerServices;

namespace Goedel.Protocol.Service;

/// <summary>
/// Connection states
/// </summary>
public enum ConnectionState {
    ///<summary>The connection hasw been established.</summary> 
    Connected = 0,

    ///<summary>The connection identifier has been reserved but
    ///contact has not yet been made.</summary> 
    OutboundInitial = 1,

    ///<summary>The initial connection request has been sent.</summary> 
    OutboundSent = 2,

    ///<summary>A connection request has been received.</summary> 
    InboundReceived = 16,


    ///<summary>A connection request with an invalid connection identifier 
    ///was received.</summary> 
    Invalid = -1
    }


/// <summary>
/// Record representing and processing stream identifiers.
/// </summary>
public class PacketConnection {

    ///<summary>The first IP endpoint to which a connection request is issued or
    ///from which a request was received.</summary> 
    public IPEndPoint InitialEndpoint { get; set; }

    ///<summary>The connection state.</summary> 
    public ConnectionState ConnectionState { get; set; }

    ///<summary>The connection identifier.</summary> 
    public ConnectionId ConnectionID { get; set; }

    ///<summary>Stream identifier generator, returns a unique serial number each time
    ///it is called.</summary> 
    public StreamIdGenerator StreamIdGenerator { get; }

    ///<summary>The parent socket.</summary> 
    public UdpSocket UdpSocket { get; }


    List<PendingItem> PendingItems { get; } = new();

    public BufferBlock<PacketStream> PacketStreamBuffer { get; } = new();

    ///<summary>Maps from the stream identifier assigned by the local end of the connection
    ///to the stream handle.</summary> 
    Dictionary<StreamId, PacketStream> DictionaryStream{ get; } = new();

    public bool QueuedPending { get; set; } = false;

    public ulong PacketSerial { get; private set; } = 0;

    public ulong PacketExpecting { get; private set; } = 0;

    public ulong Acknowledge { get; private set; } = 0;

    ///<summary>Packet length in bytes for the connection.</summary> 
    public int PacketLengthBytes { get; private set; } = 1200;

    ICryptoTransform Encryptor { get; set; }

    ICryptoTransform Decryptor { get; set; }


    /// <summary>
    /// Constructor returning a stream identifier for the endpoint <paramref name="connectionID"/>.
    /// </summary>
    /// <param name="connectionID">The connection identifier.</param>
    /// <param name="initiator">If true, the connection was created locally and will have an 
    /// even stream ID. Otherwise, the streamID will be false.</param>
    public PacketConnection(UdpSocket udpSocket, ConnectionId connectionID, bool initiator) {
        UdpSocket = udpSocket;
        StreamIdGenerator = new (initiator);
        ConnectionState = ConnectionState.OutboundInitial;
        ConnectionID = connectionID;
        }


    /// <summary>
    /// Return a new container for preparing a set of pending items.
    /// </summary>
    /// <param name="priority">The priority to assign to the list. Higher values
    /// have higher priority.</param>
    /// <returns>Pending items container.</returns>
    public Pending BeginPending(int priority=0) => new(this, priority);

    /// <summary>
    /// Thread safe commit of a series of work items specified in
    /// <paramref name="pendingItems"/>.
    /// </summary>
    /// <param name="pendingItems">The work items to add.</param>
    public async Task CommitAsync(List<PendingItem> pendingItems) {
        if (pendingItems.Count == 0) ;
        lock (this) {
            foreach (var item in pendingItems) {
                PendingItems.Add(item); 
                // NYI: Should add code so that lists can be insrted according to priority.
                }
            
            }
        await CommitAsync();
        }


    /// <summary>
    /// Thread safe commit of a work item specified in <paramref name="item"/>.
    /// </summary>
    /// <param name="item">The work item to add.</param>
    public async Task CommitAsync(PendingItem item) {
        lock (this) {

            PendingItems.Add(item);
            // NYI: Should add code so that lists can be inserted according to priority.
            }
        await CommitAsync();
        }

    /// <summary>
    /// Asynchronously queue this connection as an outbound work item.
    /// </summary>
    /// <returns></returns>
    public async Task CommitAsync() {

        if (!QueuedPending) {
            await UdpSocket.Queue(this);
            QueuedPending = true;
            }
        }


    /// <summary>
    /// 
    /// </summary>
    /// <remarks>This routine is NOT thread safe as it is only to be called by the 
    /// sender task that services the connection.</remarks>
    /// <returns></returns>
    public byte[] QueueOutbound() {

        // construct the next outbound packet to be sent to connection.

        var packetOutbound = new PacketOutbound (PacketLengthBytes);
        byte[] token = null;

        switch (ConnectionState) {
            case ConnectionState.OutboundInitial: {
                token = ConnectionId.InitialPacket;

                break;
                }
            case ConnectionState.InboundReceived: {

                break;
                }
            default: throw new NYI();
            }

        bool pending = PendingItems.Count > 0;
        while (pending){
            Console.WriteLine("Add item");


            var item = PendingItems[0];
            var completed = false;

            switch (item) {
                case PendingStream pendingStream: {
                    completed = packetOutbound.OpenStream(pendingStream);
                    break;
                    }
                case PendingPost pendingPost: {
                    completed = packetOutbound.PostData(pendingPost);
                    break;
                    }
                }

            if (completed) {
                PendingItems.RemoveAt(0);
                pending = PendingItems.Count > 0;
                }
            else {
                pending = false;
                }

            }




        switch (ConnectionState) {
            case ConnectionState.OutboundInitial: {
                return packetOutbound.Plaintext;
                }
            default: {
                return packetOutbound.Encrypt(token, PacketSerial++, PacketExpecting,
                    Acknowledge, Encryptor);

                }
            }
        }




    /// <summary>
    /// Post the request data <paramref name="message"/> to the service 
    /// <paramref name="serviceId"/> and return the response asynchronously.
    /// </summary>
    /// <param name="serviceId"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public Task<byte[]> ServiceRequest (string serviceId, byte[] message) {
        throw new NotImplementedException();
        }


    /// <summary>
    /// Wait asynchronously for an inbound request to create a stream and return a 
    /// <see cref="PacketStream"/> handle for the stream created.
    /// </summary>
    /// <returns>The next stream request received.</returns>
    public Task<PacketStream> GetStreamAsync() => PacketStreamBuffer.ReceiveAsync();



    /// <summary>
    /// Process the packet <paramref name="inboundPacket"/> as connection creation
    /// request packet.
    /// </summary>
    /// <param name="inboundPacket">The packet to process.</param>
    public void ProcessInitial(InboundPacket inboundPacket) {
        }



    public void ProcessPacket(InboundPacket inboundPacket) {
        }


    }
