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
using Goedel.Mesh;
using System.Security.Principal;

namespace Goedel.Presence.Server;







/// <summary>
/// The presence service.
/// </summary>
public class PresenceServer : Disposable, IPresence {
    #region // Properties and fields

    ///<summary>Client for IPv4 traffic.</summary> 
    protected UdpClient UdpServiceIpv4 {get; set; }

    ///<summary>Client for IPv6 traffic.</summary> 
    protected UdpClient UdpServiceIpv6 { get; set; }

    int PortIpv4;
    int PortIpv6;

    bool ListenIpv4 { get; } = false;
    bool ListenIpv6 { get; } = false;


    List<string> IP { get; }

    List<string> Endpoints { get; } = new();


    Dictionary<string, PresenceBindingAccount> Accounts { get; } = new();

    Dictionary <ulong, PresenceBindingDevice>Devices { get; } = new();
    ulong ConnectionID = 0;

    ///<summary>Time to wait before cancelling connection request.</summary> 
    public int TimeOutInitialMilliSeconds { get; set; } = 60_000;

    ///<summary>Time to wait before the first heartbeat overdue notice is 
    ///sent in milliseconds.</summary> 
    public int TimeOutHeartbeatMilliSeconds { get; set; } = (int) 60_000;

    ///<summary>Time to wait before the second overdue notice is sent in 
    ///milliseconds.</summary> 
    public int TimeOut2MilliSeconds { get; set; } = 1_000;

    ///<summary>The number of socket listeners to deploy per service.</summary> 
    public int UdpSocketListeners { get; }

    ///<summary>The queue of pending items associated with a device.</summary> 
    PendingQueue<PresenceBindingDevice> PendingQueue = new();


    ManualResetEventSlim PendingEvent = new ManualResetEventSlim();

    ///<summary>Queue of items for immediate processing.</summary> 
    BufferBlock<PresenceFromService> ImmediateQueue { get; }

    bool active = true;
    CancellationTokenSource CancellationTokenSource= new CancellationTokenSource();

    Thread SenderThread { get; }
    Thread ReceiverThread { get; }
    Thread ThreadQueuedTasks { get; }
    #endregion

    ///<inheritdoc/>
    protected override void Disposing() {
        Console.WriteLine("Disposing PresenceServer");

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

        UdpSocketListeners = 2;
        if (presenceServiceConfiguration is not null) {
            if (presenceServiceConfiguration.UdpSocketListeners > 0) {
                UdpSocketListeners = presenceServiceConfiguration.UdpSocketListeners;
                }
            }

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
        ImmediateQueue = new BufferBlock<PresenceFromService>(queueOptions);

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
                Console.WriteLine("Wakeup for device");


                //QueueNotification(next);
                }
            }
        }

    /// <summary>
    /// Send UDP packet. This function is made into a method to allow for testing.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="packet"></param>
    /// <param name="bytes"></param>
    /// <param name="endPoint"></param>
    protected virtual void Send (UdpClient client, byte[]packet, int bytes, IPEndPoint endPoint) =>
        client.Send(packet, packet.Length, endPoint);


    void UdpSender() {
        try {
            while (active) {
                var task = ImmediateQueue.Receive(CancellationTokenSource.Token);
                var client = GetClient(task.Destination);
                foreach (var packet in task.Packets) {
                    Send(client, packet, packet.Length, task.Destination);
                    }
                }
            }

        catch (OperationCanceledException) {
            // We are disposing.
            }
        }


    /// <summary>
    /// Returns the UdpClient to be used to send a packet to the address 
    /// <paramref name="endPoint"/>
    /// </summary>
    /// <param name="endPoint">The endpoint to send to.</param>
    /// <returns>The client to use.</returns>
    protected UdpClient GetClient(IPEndPoint endPoint) =>
        endPoint.AddressFamily switch {
            AddressFamily.InterNetwork => UdpServiceIpv4,
            _ => UdpServiceIpv6
            };



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
            PresenceBindingDevice deviceBinding = null;
            lock (Devices) {
                if (!Devices.TryGetValue(connectionId, out deviceBinding)) {
                    return; // unrecognized connection id, ignore.
                    }
                }

            var request = ParseBuffer(udpRequest, deviceBinding.DecryptKey);
            deviceBinding.LastContact = System.DateTime.UtcNow;
            deviceBinding.LastSerial = deviceBinding.LastSerial.Maximum(
                    request.Serial ?? 0);

            switch (request) {
                case PresenceConnectRequest connectRequest: {
                    Connect(deviceBinding, connectRequest);
                    break;
                    }
                case PresenceHeartbeat presenceHeartbeat: {
                    Heartbeat(deviceBinding, presenceHeartbeat);
                    break;
                    }
                case PresenceEndpointRequest presenceEndpointRequest: {
                    Endpoint(deviceBinding, presenceEndpointRequest);
                    break;
                    }

                case PresenceAcknowledge presenceAcknowledge: {
                    break;
                    }
                case PresenceResolveRequest presenceResolveRequest: {
                    break;
                    }
                }
            }
        catch (OperationCanceledException) {
            return; // We are disposing, abort.
            }
        }

    ulong GetConnectionId(byte[] data) {
        if (data == null | data?.Length < 8) {
            return 0;
            }

        return data.BigEndian64();
        }


    #endregion


    #region // Implement Inteface IPresence
    ///<inheritdoc/>
    public ServiceAccessToken GetEndPoint(
                AccountHandleLocked accountHandle) {

        var connectionId = Interlocked.Increment(ref ConnectionID);


        lock (Accounts) {

            if (!Accounts.TryGetValue(accountHandle.AccountAddress, out var accountBinding)) {
                accountBinding = new PresenceBindingAccount() {
                    AccountId = accountHandle.AccountAddress
                    };
                Accounts.Add(accountHandle.AccountAddress, accountBinding);
                }
            accountBinding.LastContact = System.DateTime.Now;

            var deviceBinding = new PresenceBindingDevice() {
                DeviceId = accountHandle.EnvelopedCatalogedDevice.EnvelopeId,
                AccountBinding = accountBinding,
                ConnectionId = connectionId,
                LastContact = System.DateTime.Now
                };

            accountBinding.ConnectedDevices.Add(connectionId, deviceBinding);
            Devices.Add(connectionId, deviceBinding);
            PendingQueue.Insert(deviceBinding, TimeOutInitialMilliSeconds);
            // ToDo, add a connection deletion action to the events queue.


            }

        var tokenId = connectionId.BigEndian();

        var result = new ServiceAccessToken() {
            Prefix = MeshConstants.MeshPresenceService,
            SharedSecret = null, // ToDo Make a key and pass in the token!!!
            Token = tokenId,
            Endpoints = Endpoints
            };
        return result;

        }

    ///<inheritdoc/>
    public List<DeviceStatus> GetDevices(string accountId) {


        lock (Accounts) {
            if (!Accounts.TryGetValue(accountId, out var accountBinding)) {
                return null;
                }

            var result = new List<DeviceStatus>();
            var now = DateTime.UtcNow;
            foreach (var deviceEntry in accountBinding.ConnectedDevices) {
                if (deviceEntry.Value.Expire < now) {
                    }
                }
            return result;
            }

        }



    ///<inheritdoc/>
    public void Notify(string accountId, byte[] bitmask) {

        lock (Accounts){
            if (!Accounts.TryGetValue(accountId, out var accountBinding)) {
                return;
            }
            accountBinding.Bitmask = bitmask;
            var notification = new PresenceNotify() {
                Bitmask = accountBinding.Bitmask,
                Serial = accountBinding.Serial
                };

            var now = DateTime.UtcNow;
            foreach (var deviceEntry in accountBinding.ConnectedDevices) {
                var device = deviceEntry.Value; ;
                if (device.Expire < now) {

                    QueueResponse(device, notification, device.CurrentEndpoint);
                    }
                }
            }
        }


    #endregion
    #region // Message Parsing
    PresenceFromClient ParseBuffer(UdpReceiveResult udpReceive, byte[] key) {
        var message = PresenceFromClient.FromBytes(udpReceive.Buffer, 8);
        message.AssertNotNull(NYI.Throw);

        message.SourceEndPoint = udpReceive.RemoteEndPoint;
        return message;
        }

    void QueueResponse(
           PresenceBindingDevice deviceBinding,
           PresenceFromService message,
           IPEndPoint endPoint) {
        message.EndPoint = new UdpEndpoint(endPoint);
        message.Destination = endPoint;
        message.Now = System.DateTime.UtcNow;

        message.Packets = message.ToBytes();

        ImmediateQueue.Post(message);
        }


    #endregion
    #region // Methods



    void Connect(PresenceBindingDevice deviceBinding, PresenceConnectRequest connectRequest) {
        Console.WriteLine("Received Connect Request");
        lock (deviceBinding) {

            // Prevent replay attack 
            if (connectRequest.Serial <= deviceBinding.LastConnectionSerial) {
                var error = new PresenceErrorInvalidSerial() {
                    Serial = deviceBinding.LastConnectionSerial
                    };
                QueueResponse(deviceBinding, error, connectRequest.SourceEndPoint);
                return;
                }

            // ToDo: Will require some sophistication to prevent a MitM attack here.
            deviceBinding.CurrentEndpoint = connectRequest.SourceEndPoint;
            deviceBinding.DeviceState = DeviceState.Connected;
            deviceBinding.Expire = DateTime.Now.AddMilliseconds(TimeOutHeartbeatMilliSeconds);

            var response = new PresenceConnectResponse() {
                ConnectionTimeout = TimeOutHeartbeatMilliSeconds
                };
            QueueResponse(deviceBinding, response, connectRequest.SourceEndPoint);
            }
        }


    void Heartbeat(PresenceBindingDevice deviceBinding, PresenceHeartbeat heartbeat) {
        Console.WriteLine($"Received Heartbeat");
        lock (deviceBinding) {
            var message = new PresenceStatus() {
                Acknowledge = heartbeat.Serial
                };
            // have recieved a keepalive here so update the connection state

            QueueResponse(deviceBinding, message, heartbeat.SourceEndPoint);
            deviceBinding.Expire = DateTime.Now.AddMilliseconds(TimeOutHeartbeatMilliSeconds);
            }
        }

    void Endpoint(PresenceBindingDevice deviceBinding, PresenceEndpointRequest request) {
        Console.WriteLine($"Received Endpoint");
        lock (deviceBinding) {
            var message = new PresenceEndpointResponse() {
                Acknowledge = request.Serial
                };
            // have recieved a keepalive here so update the connection state

            QueueResponse(deviceBinding, message, request.SourceEndPoint);
            deviceBinding.Expire = DateTime.Now.AddMilliseconds(TimeOutHeartbeatMilliSeconds);
            }
        }


    void Acknowledge(PresenceBindingDevice deviceBinding, PresenceAcknowledge acknowledge) {
        Console.WriteLine($"Received Acknowledge");
        lock (deviceBinding) {
            // have recieved a keepalive here so update the connection state
            deviceBinding.Expire = DateTime.Now.AddMilliseconds(TimeOutHeartbeatMilliSeconds);
            }
        }

    void Resolve(PresenceBindingDevice deviceBinding, PresenceResolveRequest resolveRequest) {
        Console.WriteLine($"Received Resolve");
        }


    #endregion
    }


