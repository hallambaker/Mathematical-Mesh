

using Goedel.Cryptography.Dare;
using Goedel.Discovery;
using Goedel.Mesh;
using Goedel.Protocol;
using System.Net;
using System.Threading.Tasks.Dataflow;

namespace Goedel.Presence.Client;

/// <summary>
/// Message identifier, returned when a message is sent, used to wait for 
/// confirmation of message receipt.
/// </summary>
public record MessageId {
    }


/// <summary>
/// Presence listener state.
/// </summary>
public enum PresenceListenerState {
    
    ///<summary>Listener has yet to receive contact from the service.</summary> 
    Initial,

    ///<summary>Listener has recently received a valid contact message from the service
    ///</summary> 
    Connected,

    ///<summary>Listener has not acknowledged request sent to it.</summary> 
    Unacknowledged,

    ///<summary>Listener has not recently received a valid contact message.</summary> 
    Disconnected,


    ///<summary>The presence association was aborted.</summary> 
    Aborted

    }



/// <summary>
/// Context for a presence service connection.
/// </summary>
public class ContextPresence : Disposable {

    CancellationTokenSource ListenerCancel { get; }

    ///<inheritdoc/>
    protected override void Disposing() {
        ListenerActive = false;
        WaitPoll.Set();
        ListenerCancel.Cancel();
        }


    bool ListenerActive { get; set; } = true;

    UdpClient UdpClient { get; set; }



    ServiceAccessToken ServiceAccessToken { get; }

    List<IPEndPoint> IPEndpoints { get; } = new();


    ///<summary>The current local endpoint</summary> 
    public IPEndPoint? LocalEndPoint { get; private set; } = null;

    ///<summary>Timestamp of last packet received.</summary> 
    public System.DateTime? LastTimeStamp { get; private set; } = null;


    int currentEndPoint = 0;

    ///<summary>The state of the presence listener.</summary> 
    public PresenceListenerState PresenceListenerState { get; private set; } =
        PresenceListenerState.Initial;





    BufferBlock<UdpReceiveResult> UdpReceiveBuffer { get; } = new();


    ManualResetEventSlim WaitPoll = new(false);
    int waitPollWaiting = 0;

    ///<summary></summary> 
    public int UdpListenerTasks { get; init; } = 4;


    ///<summary>Maximum number of retry requests.</summary> 
    public int RetransmitConnectRequestTries { get; init; } = 3;

    ///<summary>Maximum number of retry requests.</summary> 
    public int RetransmitHeartbeatTries { get; init; } = 3;



    ///<summary>Time delay before retrying a connection request in milliseconds.</summary> 
    public int RetransmitConnectRequestMilliSeconds { get; init; } = 1_000;

    ///<summary>Connection heartbeat timer in milliseconds.</summary> 
    public int HeartbeatMilliSeconds { get; set; } = 60_000;

    ///<summary>Connection heartbeat timer in milliseconds.</summary> 
    public int RetransmitHeartbeatMilliSeconds { get; set; } = 1_000;

    ///<summary>Connection heartbeat timer in milliseconds.</summary> 
    public int ReconnectAttemptMilliSeconds { get; set; } = 60_000;

    ///<summary>If true, client is connected to the presence4 service.</summary> 
    public bool Connected => PresenceListenerState != PresenceListenerState.Disconnected;


    int RetransmitOrReconnect => Connected ? RetransmitHeartbeatMilliSeconds :
        ReconnectAttemptMilliSeconds;



    ///<summary>Request retransmission timeout in milliseconds</summary> 
    public int RetransmitRequestMilliSeconds { get; set; } = 1_000;

    ///<summary>Serial number of the last message sent</summary> 
    public int MessageSerial { get; set; } = 0;

    ///<summary>Serial number of the pending acknowledgement we are waiting on.</summary> 
    public int AcknowledgmentSerial { get; set; } = 0;


    int retryCount = 0;
    System.DateTime WakeupHeartbeat { get; set; } = System.DateTime.Now;

    System.DateTime WakeupUnacknowledged { get; set; } = System.DateTime.Now;



    ContextUser ContextUser;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContextPresence"/> class.
    /// </summary>
    public ContextPresence(
                ContextUser contextUser,
                ServiceAccessToken serviceAccessToken) {
        ContextUser = contextUser;
        ServiceAccessToken = serviceAccessToken;
        UdpClient = HostNetwork.GetUDPClient();

        ListenerCancel = new CancellationTokenSource();

        serviceAccessToken?.Endpoints.AssertNotNull(NYI.Throw);
        foreach (var endPoint in serviceAccessToken.Endpoints) {
            if (IPEndPoint.TryParse(endPoint, out var iPEndPoint)) {
                IPEndpoints.Add(iPEndPoint);
                }
            }
        (IPEndpoints.Count > 0).AssertTrue(NYI.Throw);
        }


    /// <summary>
    /// Start the presence listener. Waiting for an explicit start allows the
    /// caller to adjust the listener parameters as init parameters.
    /// </summary>
    public void Start() {
        Listen();
        }


    /// <summary>
    /// Get a presence service client for the user context <paramref name="contextAccount"/>.
    /// </summary>
    /// <param name="contextAccount">The user context.</param>
    /// <returns>The context created.</returns>
    public static ServiceAccessToken GetService(
                ContextUser contextAccount) {
        var statusRequest = new StatusRequest() {
            Services = new List<String>() { MeshConstants.MeshPresenceService }
            };
        var status = contextAccount.Sync(statusRequest);
        return status.GetService(MeshConstants.MeshPresenceService);
        }


    /// <summary>
    /// Factory method returning a new presence context on the presence service
    /// provided to the account <paramref name="contextAccount"/>.
    /// </summary>
    /// <param name="contextAccount">The account under which the presence service 
    /// is provided.</param>
    /// <returns>The presence context.</returns>
    public static ContextPresence GetContext(ContextUser contextAccount) {
        var service = GetService(contextAccount);

        service.AssertNotNull(NYI.Throw);

        var result = new ContextPresence(contextAccount, service);
        result.Start();

        return result;
        }


    /// <summary>
    /// The listener task.
    /// </summary>
    async void Listen() {

        // Set up listeners to wait on the UDP client and post to the buffer
        // This might not be necessary, the Microsoft documentation doesn't make
        // clear and testing on one does not guarantee it works on all platforms.
        for (var i = 0; i < UdpListenerTasks; i++) {
            UdpListener();
            }

        // Send out the original connection request.
        MakeConnectRequest();
        System.DateTime wakeTime = System.DateTime.Now;
        while (ListenerActive) {
            try {
                var wakeup = GetDateTime().Subtract(DateTime.Now);
                while (wakeup <= TimeSpan.Zero) {
                    Timeout();
                    wakeup = GetDateTime().Subtract(DateTime.Now);
                    }
                
                var waitTask = UdpReceiveBuffer.ReceiveAsync(wakeup, ListenerCancel.Token);
                await waitTask;


                if (waitTask.IsCompleted) {
                    Console.WriteLine("Client got data");
                    Process(waitTask.Result);
                    }
                }
            catch (TimeoutException) {
                Timeout();
                }
            catch (OperationCanceledException) {
                return;
                }

            }
        }

    // Have received a message from the service.
    void Process(UdpReceiveResult receiveResult) {

        // process the result first
        var message = PresenceFromService.FromBytes(
            receiveResult.Buffer, 0);
        switch (message) {
            case PresenceConnectResponse presenceConnectResponse: {
                Process(presenceConnectResponse);

                break;
                }
            case PresenceErrorInvalidSerial errorInvalidSerial: {
                Process(errorInvalidSerial);
                break;
                }
            case PresenceStatus status : {
                Process(status);
                break;
                }
            case PresenceNotify notify: {
                Process(notify);

                break;
                }
            case PresenceResolveResponse resolveResponse: {
                Process(resolveResponse);

                break;
                }

            }
        }

    void ReleaseWait() {
        //Console.WriteLine("Release wait");
        WaitPoll.Set();

        }


    void Process(PresenceConnectResponse presenceConnectResponse) {
        PresenceListenerState = PresenceListenerState.Connected;


        if (presenceConnectResponse.EndPoint != null) {
            
            var address = new IPAddress(presenceConnectResponse.EndPoint.IpAddress);
            var port = presenceConnectResponse.EndPoint.Port ?? 0;

            LocalEndPoint = new IPEndPoint(address, port);
            }


        ReleaseWait();
        }
    void Process(PresenceErrorInvalidSerial errorInvalidSerial) {
        }
    void Process(PresenceStatus status) {
        ProcessStatus(status);
        }
    void Process(PresenceNotify notify) {
        Console.WriteLine("Got notification");
        ProcessStatus(notify);

        var message = new PresenceAcknowledge() {
            Acknowledge = notify.Serial
            };
        SendData(message, ServiceAccessToken.Token);
        ContextUser.Sync();
        ReleaseWait();
        }

    void ProcessStatus(PresenceFromService message) {
        if ((message.Acknowledge ??0)  < AcknowledgmentSerial) {
            return;
            }
        PresenceListenerState = PresenceListenerState.Connected;
        WakeupHeartbeat = System.DateTime.Now.AddMilliseconds(HeartbeatMilliSeconds);
        ReleaseWait();
        }

    void Process(PresenceResolveResponse resolveResponse) {
        }

    // Wait timed out.
    DateTime GetDateTime() =>
        // Here check to see if we are really past our wakeup time

        PresenceListenerState switch {
            PresenceListenerState.Initial => WakeupUnacknowledged,
            PresenceListenerState.Unacknowledged => WakeupUnacknowledged,
            PresenceListenerState.Connected => WakeupHeartbeat,
            PresenceListenerState.Disconnected => WakeupHeartbeat,
            _ => WakeupHeartbeat
            };



    // Wait timed out.
    void Timeout() {
        // Here check to see if we are really past our wakeup time


        switch (PresenceListenerState) {
            case PresenceListenerState.Initial: {
                MakeConnectRequest();
                break;
                }
            case PresenceListenerState.Unacknowledged: {
                if (System.DateTime.Now > WakeupUnacknowledged) {
                    TimeoutUnacknowledged();
                    }
                break;
                }
            case PresenceListenerState.Connected:
            case PresenceListenerState.Disconnected: {
                if (System.DateTime.Now > WakeupHeartbeat) {
                    TimeoutHeartbeat();
                    }
                break;
                }
            }
        }




    void TimeoutUnacknowledged() {
        if (retryCount++ < RetransmitHeartbeatTries) {
            SendHeartbeat();
            }
        else {
            PresenceListenerState = PresenceListenerState.Disconnected;
            }
        }

    void TimeoutHeartbeat() {
        PresenceListenerState = PresenceListenerState.Unacknowledged;
        retryCount = 0;
        SendHeartbeat();

        }


    /// <summary>
    /// Send initial connect request.
    /// </summary>
    void MakeConnectRequest() {
        if (retryCount > RetransmitConnectRequestTries) {
            // No response from the presence service, abort.
            PresenceListenerState = PresenceListenerState.Aborted;

            ListenerActive = false;
            return;
            }

        WakeupUnacknowledged = DateTime.Now.AddMilliseconds(RetransmitOrReconnect);
        var connectRequest = new PresenceConnectRequest() {
            };
        SendData(connectRequest, ServiceAccessToken.Token);
        Console.WriteLine($"Send ConnectRequest: {connectRequest.ToString()}");
        }


    /// <summary>
    /// Send the heartbeat message. No telemetry at this point.
    /// </summary>
    void SendHeartbeat() {
        var heartbeat = new PresenceHeartbeat() {
            };
        
        WakeupUnacknowledged = DateTime.Now.AddMilliseconds(RetransmitOrReconnect);
        SendData(heartbeat, ServiceAccessToken.Token);
        Console.WriteLine($"Send Heartbeat: {heartbeat.ToString()}");
        }

    /// <summary>
    /// Udp client listener, read requests and post to <see cref="UdpReceiveBuffer"/>
    /// </summary>
    async void UdpListener() {
        try {
            while (ListenerActive) {
                var receive = await UdpClient.ReceiveAsync(ListenerCancel.Token);
                UdpReceiveBuffer.Post(receive);
                }
            }
        catch {
            return;
            }
        
        }

    /// <summary>
    /// Send the message <paramref name="message"/> with connection token 
    /// <paramref name="token"/> to the service on the persistent connection.
    /// </summary>
    /// <param name="message">The message to send.</param>
    /// <param name="token">Connection token.</param>
    protected virtual void SendData(PresenceFromClient message, byte[] token) =>
        SendData(UdpClient, message, token);

    void SendData(UdpClient udpClient, PresenceFromClient message, byte[] token) {
        message.Serial = MessageSerial++;
        var data = message.ToBytes(token);
        udpClient.Send(data, data.Length, IPEndpoints[currentEndPoint]);

        }



    /// <summary>
    /// Force sending a poll message to the presence service.
    /// </summary>
    /// <returns>Asynchronous poll result.</returns>
    public bool Poll() {

        lock (WaitPoll) {
            waitPollWaiting++;
            }
        
        WaitPoll.Wait();
        
        lock (WaitPoll) {
            waitPollWaiting--;
            if (waitPollWaiting <= 0) {
                WaitPoll.Reset();
                }
            }
        return ListenerActive;

        }


    /// <summary>
    /// Query the presence service to obtain the external endpoint to which 
    /// <paramref name="local"/> is connected.
    /// </summary>
    /// <param name="local">The client whose external endpoint is to be discovered.</param>
    /// <returns>The endpoint.</returns>
    public UdpEndpoint RemoteEndpoint(
                UdpClient local) {

        var task = RemoteEndpointAsync(local);
        task.Wait();
        return task.Result;
        }

    /// <summary>
    /// Query the presence service to obtain the external endpoint to which 
    /// <paramref name="local"/> is connected and return the result asynchronously.
    /// </summary>
    /// <param name="local">The client whose external endpoint is to be discovered.</param>
    /// <returns>The endpoint.</returns>
    public async Task<UdpEndpoint> RemoteEndpointAsync(
                UdpClient local) {
        var attempt = 0;

        var endpointRequest = new PresenceEndpointRequest() {
            };
        SendData(local, endpointRequest, ServiceAccessToken.Token);

        var timeout = TimeSpan.FromMilliseconds(RetransmitRequestMilliSeconds);
        while (ListenerActive) {
            try {
                var receiveResult = await local.ReceiveAsync(ListenerCancel.Token);
                var message = PresenceFromService.FromBytes(receiveResult.Buffer, 0);

                if (message is PresenceEndpointResponse) {
                    return message.EndPoint;
                    }
                }
            catch (TimeoutException) {
                attempt++;
                if (attempt >= RetransmitHeartbeatTries) {
                    return null;
                    }
                }
            }
        return null;

        }




    /// <summary>
    /// Wait for the client to receive a new message of type <paramref name="messageType"/>.
    /// </summary>
    /// <param name="messageType">The type of message to wait for.</param>
    /// <param name="outBoxCount">The starting point for the count, ignore messages 
    /// earlier than this.</param>
    /// <returns>The message received.</returns>
    public Message MessageWait (Type messageType, long outBoxCount) {

        var inbound = ContextUser.GetSpoolInbound();
        // wait on notification of an update.
        while (ListenerActive) {
            foreach (var envelope in inbound.Select(1)) {
                var message = Message.Decode(envelope, ContextUser.KeyCollection);
                Console.WriteLine($"{ContextUser.AccountAddress}: Message {envelope.Header.Index} type {message.GetType()} (Want {messageType})");

                if (message.GetType() == messageType) {
                    return message;
                    }
                outBoxCount = inbound.FrameCount;
                }



            //if (inbound.FrameCount > outBoxCount) {
            //    foreach (var envelope in inbound.Select((int)outBoxCount + 1)) {
            //        var message = Message.Decode(envelope, ContextUser.KeyCollection);

            //        if (message.GetType() == messageType) { 
            //            return message; 
            //            }
            //        outBoxCount = inbound.FrameCount;
            //        }
            //    }
            Poll();
            }

        return null;
        }

    long GetInboxCount() {
        ContextUser.Sync();
        var inbound = ContextUser.GetSpoolInbound();
        return inbound.FrameCount;

        }

    /// <summary>
    /// Request creation of an outbound session to the account <paramref name="account"/>
    /// and return the result asynchronously.
    /// </summary>
    /// <param name="account">The account to connect to.</param>
    /// <returns>The created session context (asynchronously).</returns>
    public async Task<ContextSession> SessionRequestAsync(string account) {
        var t = new Task<ContextSession>(
                      () => SessionRequest(account));
        t.Start();
        await t;
        return t.Result;
        }


    /// <summary>
    /// Request creation of an outbound session to the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account to connect to.</param>
    /// <returns>The created session context (asynchronously).</returns>
    public ContextSession SessionRequest(string account) {
        Console.WriteLine($"SessionRequestAsync {account}");

        // Create a local endpoint
        var udpClient = HostNetwork.GetUDPClient();

        // Get external endpoint(s)
        var externalEndpoint = RemoteEndpoint(udpClient);
        externalEndpoint.AssertNotNull(PresenceServiceNotResponding.Throw);


        var inboxCount = GetInboxCount();

        // Post connection request to account
        var sessionRequest = new SessionRequest() {
            Inbound = externalEndpoint
            };

        ContextUser.SendMessage(account, sessionRequest);

        // Wait for response
        var sessionResponse = MessageWait(typeof(SessionResponse), inboxCount) as SessionResponse;

        // Build session for request/response and endpoint bindings
        var result = new ContextSession(sessionRequest, sessionResponse) {
            UdpClient = udpClient,
            ExternalEndpoint = externalEndpoint
            };
        return result;


        }

    /// <summary>
    /// Wait for an external session creation request and return when received asynchronously.
    /// </summary>
    /// <returns>The created session context (asynchronously).</returns>
    public async Task<ContextSession> GetSessionRequestAsync() {
        return await Task.Run<ContextSession>(GetSessionRequest);

        //var t = new Task<ContextSession>(GetSessionRequest);
        //t.Start();
        //await t;
        //return t.Result;
        }

    /// <summary>
    /// Wait for an external session creation request and return when received.
    /// </summary>
    /// <returns>The created session context (asynchronously).</returns>
    public ContextSession GetSessionRequest() {
        Console.WriteLine("GetSessionRequestAsync");

        var inboxCount = GetInboxCount();

        // Wait for response
        var sessionRequest = MessageWait(typeof(SessionRequest), inboxCount) as SessionRequest;

        // obtain necessary endpoints
        var udpClient = HostNetwork.GetUDPClient();
        var externalEndpoint = RemoteEndpoint(udpClient);
        externalEndpoint.AssertNotNull(PresenceServiceNotResponding.Throw);

        // Send response
        var sessionResponse = new SessionResponse() {
            Inbound = externalEndpoint
            };

        // Build session for request/response and endpoint bindings
        var result = new ContextSession(sessionRequest, sessionResponse) {
            UdpClient = udpClient,
            ExternalEndpoint = externalEndpoint
            };
        return result;


        }

    }
