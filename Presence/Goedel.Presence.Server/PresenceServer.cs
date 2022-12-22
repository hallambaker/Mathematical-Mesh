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

using Goedel.Utilities;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.Mesh.Server;
using System.Net.Sockets;
using Goedel.Discovery;
using System.Net;
using Goedel.Protocol.Presentation;
using System.Threading.Tasks.Dataflow;
using Goedel.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.Presence.Server;





/// <summary>
/// Tracks the state of a device connection.
/// </summary>
public enum DeviceState {
    
    ///<summary>Connection requested, no contact.</summary> 
    Initial,

    ///<summary>Device has sent information within the timeout window.</summary> 
    Connected,

    ///<summary>Device was sent first overdue notice.</summary> 
    Overdue1,

    ///<summary>Device was sent first overdue notice.</summary> 
    Overdue2,

    ///<summary>Connection pending deletion.</summary> 
    Closed

    }

/// <summary>
/// Tracks a device connected to the service.
/// </summary>
public record DeviceBinding : IQueuableTask {
    
    ///<summary>State of the device connection</summary> 
    public DeviceState DeviceState {get; set; } = DeviceState.Initial;

    ///<summary>The unique connection ID assigned by the service.</summary> 
    public ulong ConnectionId;

    ///<summary>The device profile UDF.</summary> 
    public string DeviceId;

    ///<summary>The corresponding account binding.</summary> 
    public AccountBinding AccountBinding { get; init; }

    ///<summary>Time at which the binding was created.</summary> 
    public DateTime FirstContact { get; } = DateTime.Now;

    ///<summary>Time at which the binding was last used.</summary> 
    public DateTime LastContact { get; set; } = DateTime.Now;

    ///<summary>The last endpoint from which the device was accessed.</summary> 
    public IPEndPoint CurrentEndpoint { get; set; }

    ///<summary>Monotonically increasing connection request counter. To prevent replay
    ///attacks, a connection request MUST be rejected unless it contains a greater or equal
    ///serial number.</summary> 
    public int LastConnectionSerial { get; set; } = -1;

    ///<summary>When set, there is a pending notification to be sent to the device.</summary> 
    public bool Notify { get; set; } = false;


    ///<summary>The shared secret to be used to encrypt outbound messages</summary> 
    public byte[] EncryptKey { get; }

    ///<summary>The shared secret to be used to decrypt inbound messages</summary>
    public byte[] DecryptKey { get; }

    /// <summary>
    /// Compile a packet sequence providing notification of the current status.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NYI"></exception>
    public List<byte[]> GetPackets() => throw new NYI();

    #region // Implement IQueuableTask

    ///<inheritdoc/>
    public DateTime WakeAt { get; set; }

    ///<inheritdoc/>
    public int CompareTo(object obj) {
        var other = obj as DeviceBinding;

        if (other == null) {
            throw new ArgumentException ($"Argument not of type {nameof(DeviceBinding)}");
            }

        var compare = WakeAt.CompareTo( other.WakeAt );
        return compare != 0 ? compare : ConnectionId.CompareTo(other.ConnectionId);


        } 
    #endregion
    }

/// <summary>
/// Tracks an account with device(s) connected to the service.
/// </summary>
public class AccountBinding {

    ///<summary></summary> 
    public string AccountId;

    ///<summary>Time at which the binding was created.</summary> 
    public DateTime FirstContact { get; } = DateTime.Now;

    ///<summary>Time at which the binding was last used.</summary> 
    public DateTime LastContact { get; set;  } = DateTime.Now;

    ///<summary>Dictionary of connected devices.</summary> 
    public Dictionary<ulong, DeviceBinding> ConnectedDevices { get;  }  = new();

    }


/// <summary>
/// The presence service.
/// </summary>
public class PresenceServer : Disposable, IPresence {
    #region // Properties and fields
    UdpClient UdpServiceIpv4;
    UdpClient UdpServiceIpv6;

    int PortIpv4;
    int PortIpv6;

    bool ListenIpv4 { get; } = false;
    bool ListenIpv6 { get; } = false;


    List<string> IP { get; }

    List<string> Endpoints { get; } = new();


    Dictionary<string, AccountBinding> Accounts { get; } = new();

    Dictionary <ulong, DeviceBinding>Devices { get; } = new();
    ulong ConnectionID = 0;

    ///<summary>Time to wait before cancelling connection request.</summary> 
    public int TimeOutInitial { get; set; } = (int)TimeSpan.TicksPerSecond * 60;

    ///<summary>Time to wait before the first overdue notice is sent.</summary> 
    public int TimeOut1 { get; set; } = (int) TimeSpan.TicksPerSecond * 60;

    ///<summary>Time to wait before the second overdue notice is sent.</summary> 
    public int TimeOut2 { get; set; } = (int)TimeSpan.TicksPerSecond * 60;


    public int UdpSocketListeners { get; }

    ///<summary>The queue of pending items associated with a device.</summary> 
    PendingQueue<DeviceBinding> PendingQueue = new();


    ManualResetEventSlim PendingEvent = new ManualResetEventSlim();

    ///<summary>Queue of items for immediate processing.</summary> 
    BufferBlock<DeviceBinding> ImmediateQueue { get; }

    bool active = true;
    CancellationTokenSource CancellationTokenSource= new CancellationTokenSource();


    Thread SenderThread { get; }
    Thread ReceiverThread { get; }
    Thread ThreadQueuedTasks { get; }
    #endregion

    ///<inheritdoc/>
    protected override void Disposing() {

        // dispose the send and receive threads.
        active = false;
        CancellationTokenSource.Cancel();
        PendingEvent.Set();

        base.Disposing();
        }

    #region // Constructors


    /// <summary>
    /// Default constructor, returns an empty instance.
    /// </summary>
    public PresenceServer(
            GenericHostConfiguration hostConfiguration,
            PresenceServiceConfiguration presenceServiceConfiguration) {
 
        // Assign a service port.
        UdpServiceIpv4 = HostNetwork.GetUDPClient();
        UdpServiceIpv6 = HostNetwork.GetUDPClient(AddressFamily.InterNetworkV6);

        PortIpv4 = GetPort(UdpServiceIpv4);
        PortIpv6 = GetPort(UdpServiceIpv6);

        // Set the number of UDP socket listeners.
        UdpSocketListeners = presenceServiceConfiguration.UdpSocketListeners > 0 ?
            presenceServiceConfiguration.UdpSocketListeners : 8;


        IP = presenceServiceConfiguration?.IP ?? hostConfiguration?.IP;

        if (IP is null) {
            IP = new();
            var localEndPoints = HostNetwork.GetLocalEndpoints();
            foreach (var localEndpoint in localEndPoints) {
                IP.Add(localEndpoint.ToString());
                }
            }

        foreach (var ip in IP) {
            if (IPEndPoint.TryParse(ip, out var endpoint)) {
                if (endpoint.Port <= 0) {
                    endpoint.Port = endpoint.AddressFamily == AddressFamily.InterNetwork ?
                        PortIpv4 : PortIpv6;
                    }

                if (endpoint.AddressFamily == AddressFamily.InterNetworkV6) {
                    ListenIpv6 = true;
                    }
                else {
                    ListenIpv4 = true;
                    }
                Endpoints.Add(endpoint.ToString());
                }
            }

        // Set up the outbound message queue with a cancellation token.
        var queueOptions = new DataflowBlockOptions() {
            CancellationToken = CancellationTokenSource.Token
            };
        ImmediateQueue = new BufferBlock<DeviceBinding>(queueOptions);

        SenderThread = Start(UdpSender);
        ReceiverThread = Start(UdpReceiver);
        ThreadQueuedTasks = Start(WaitQueuedTasks);
        }


    static Thread Start(ThreadStart start) {
        var thread = new Thread(start);
        thread.Start();
        return thread;
        }

    int GetPort(UdpClient udpClient) {
        var endpoint = udpClient?.Client?.LocalEndPoint as IPEndPoint;
        if (endpoint is null) {
            return -1;
            }
        return endpoint.Port;
        }


    #endregion
    #region // Outbound and inbound processing tasks


    /// <summary>
    /// Thread to process queued tasks.
    /// </summary>
    void WaitQueuedTasks() {

        //var cancellationToken = CancellationTokenSource.Token;
        var waitHandle = PendingEvent.WaitHandle;

        while (active) {
            waitHandle.WaitOne();

            if (!active) {
                return;
                }

            // make sure we can process any inbound requests.
            PendingEvent.Reset();

            // drain the queue of pending tasks.
            for (var next = PendingQueue.Next(); next != null; next = PendingQueue.Next()) {
                QueueNotification(next);
                }
            }
        }


    void UdpSender() {
        try {
            while (active) {
                var task = ImmediateQueue.Receive(CancellationTokenSource.Token);
                Process(task).Wait();
                }
            }

        catch (OperationCanceledException) {
            // We are disposing.
            }
        }


    void UdpReceiver() {
        int listeners = (ListenIpv4 ? UdpSocketListeners : 0) +
            (ListenIpv6 ? UdpSocketListeners : 0);

        if (listeners < 0) {
            return;
            }

        var clients = new UdpClient[listeners];
        var tasks = new Task[listeners];

        var listener = 0;
        if (ListenIpv4) {
            for (; listener < UdpSocketListeners; listener++) {
                clients[listener] = UdpServiceIpv4;
                tasks[listener] = UdpSocketListener(UdpServiceIpv4);
                }
            }
        if (ListenIpv6) {
            for (; listener < listeners; listener++) {
                clients[listener] = UdpServiceIpv6;
                tasks[listener] = UdpSocketListener(UdpServiceIpv6);
                }
            }

        while (active) {
            var index = Task.WaitAny(tasks);
            tasks[index] = UdpSocketListener(clients[index]);
            }

        }


    async Task UdpSocketListener(UdpClient udpClient) {
        try {
            var udpRequest = await udpClient.ReceiveAsync(CancellationTokenSource.Token);

            // pre-process the request here
            var connectionId = GetConnectionId(udpRequest.Buffer);

            // identify the device
            DeviceBinding deviceBinding = null;
            lock (Devices) {
                if (!Devices.TryGetValue(connectionId, out deviceBinding)) {
                    return; // unrecognized connection id, ignore.
                    }
                }

            var request = ParseBuffer(udpRequest, deviceBinding.DecryptKey);

            switch (request) {
                case ConnectRequest connectRequest: {
                    break;
                    }

                }

            // lock whatever resource is required

            // Send response if required

            // Reset pending queue
                    }
        catch (OperationCanceledException) {
            return; // We are disposing, abort.
            }
        }

    ulong GetConnectionId(byte[] data) {
        throw new NYI();

        }

    


    async Task Process(DeviceBinding deviceBinding) {
        if (deviceBinding.DeviceState == DeviceState.Initial) {
            // we do not have an endpoint yet.
            return;
            }

        var client = GetClient(deviceBinding.CurrentEndpoint);

        var packets = deviceBinding.GetPackets();
        foreach (var packet in packets) {
            await client.SendAsync (packet, packet.Length, deviceBinding.CurrentEndpoint);

            }

        }


    UdpClient GetClient(IPEndPoint iPEndPoint) =>
        iPEndPoint.AddressFamily == AddressFamily.InterNetwork ? UdpServiceIpv4 :
            UdpServiceIpv6;

    #endregion


    #region // Implement Inteface IPresence
    ///<inheritdoc/>
    public (ulong, ServiceAccessToken) GetEndPoint(AccountHandleLocked accountHandle) {

        var connectionId = Interlocked.Increment(ref ConnectionID);

        lock (Accounts) {
            if (!Accounts.TryGetValue(accountHandle.AccountAddress, out var accountBinding)) {
                accountBinding = new AccountBinding() {
                    AccountId = accountHandle.AccountAddress
                    };
                Accounts.Add(accountHandle.AccountAddress, accountBinding);
                }
            accountBinding.LastContact = DateTime.Now;

            var deviceBinding = new DeviceBinding() {
                DeviceId = accountHandle.EnvelopedCatalogedDevice.EnvelopeId,
                AccountBinding = accountBinding,
                ConnectionId = connectionId,
                LastContact = DateTime.Now
                };

            accountBinding.ConnectedDevices.Add(connectionId, deviceBinding);
            Devices.Add(connectionId, deviceBinding);
            PendingQueue.Insert(deviceBinding, TimeOutInitial);
            // ToDo, add a connection deletion action to the events queue.
            }

        var tokenId = connectionId.BigEndian();

        var result = new ServiceAccessToken() {
            Prefix = MeshConstants.MeshPresenceService,
            SharedSecret = null, // ToDo Make a key and pass in the token!!!
            Token = tokenId,
            Endpoints = Endpoints
            };
        return (connectionId, result);

        }

    ///<inheritdoc/>
    public List<string> GetDevices(ulong connectionId) {

        var result = new List<string>();
        lock (Accounts) {
            if (!Devices.TryGetValue (connectionId, out var deviceBinding)) {
                return null; // Connection ID is not in use.
                }
            var accountBinding = deviceBinding.AccountBinding;

            foreach (var deviceEntry in accountBinding.ConnectedDevices) {
                result.Add(deviceEntry.Value.DeviceId);
                // ToDo: consider adding more information here.
                }
            }

        return result;
        }

    ///<inheritdoc/>
    public void Notify(ulong connectionId) {
        lock (Accounts) {
            if (!Devices.TryGetValue(connectionId, out var deviceBinding)) {
                return;
                }
            var accountBinding = deviceBinding.AccountBinding;

            foreach (var deviceEntry in accountBinding.ConnectedDevices) {
                QueueNotification(deviceBinding);
                }
            }
        }


    /// <summary>
    /// Queue a notification to a device unless there is a pending notification already.
    /// </summary>
    /// <param name="deviceBinding"></param>
    void QueueNotification(DeviceBinding deviceBinding) {
        // add another notification to the work queue.
        // This is locked on the device binding, probably unnecessary as the worst
        // that can happen is an additional packet is sent out.
        lock (deviceBinding) {
            if (deviceBinding.Notify) {
                // We already have a notification pending so return.
                // This will need to be expanded to merge notification data in future.
                return;
                }
            deviceBinding.Notify = true;
            ImmediateQueue.Post(deviceBinding);
            }

        }

    #endregion
    #region // Message Parsing
    PresenceFromClient ParseBuffer(UdpReceiveResult udpReceive, byte[] key) => throw new NYI();


    #endregion
    #region // Methods


    void QueueResponse (DeviceBinding deviceBinding, PresenceFromClient connectRequest,
                PresenceFromService message) => throw new NYI();

    void Connect(DeviceBinding deviceBinding, ConnectRequest connectRequest) {
        lock (deviceBinding) {
            if (connectRequest.Serial <= deviceBinding.LastConnectionSerial) {
                var error = new ErrorInvalidSerial() {
                    Serial = deviceBinding.LastConnectionSerial
                    };
                QueueResponse(deviceBinding, connectRequest, error);
                return;
                }
            var response = new ConnectResponse() {
                ConnectionTimeout = TimeOut1
                };
            QueueResponse(deviceBinding, connectRequest, response);
            }
        }


    void Heartbeat(DeviceBinding deviceBinding, Heartbeat heartbeat) {
        lock (deviceBinding) {
            // have recieved a keepalive here so update the connection state

            }
        }

    void Acknowledge(DeviceBinding deviceBinding, Acknowledge acknowledge) {
        lock (deviceBinding) {
            // have recieved a keepalive here so update the connection state

            }
        }

    void Resolve(DeviceBinding deviceBinding, ResolveRequest resolveRequest) {
        }

    /////<inheritdoc/>
    //public override ConnectResponse Connect(ConnectRequest request, IJpcSession session) {
    //    throw new NotImplementedException();
    //    }



    /////<inheritdoc/>
    //public override QueryResponse Query(QueryRequest request, IJpcSession session) {
    //    throw new NotImplementedException();
    //    }
    #endregion
    }


