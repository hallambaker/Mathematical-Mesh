

using Goedel.Discovery;
using Goedel.Mesh;
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

    public System.DateTime? LastTimeStamp { get; private set; } = null;


    int currentEndPoint = 0;

    ///<summary>The state of the presence listener.</summary> 
    public PresenceListenerState PresenceListenerState { get; private set; } =
        PresenceListenerState.Initial;





    BufferBlock<UdpReceiveResult> UdpReceiveBuffer { get; } = new();


    ManualResetEventSlim WaitPoll = new(false);

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


    public bool Connected => PresenceListenerState != PresenceListenerState.Disconnected;


    int RetransmitOrReconnect => Connected ? RetransmitHeartbeatMilliSeconds :
        ReconnectAttemptMilliSeconds;



    ///<summary>Request retransmission timeout in milliseconds</summary> 
    public int RetransmitRequestMilliSeconds { get; set; } = 150_000;

    ///<summary>Serial number of the last message sent</summary> 
    public int MessageSerial { get; set; } = 0;

    ///<summary>Serial number of the pending acknowledgement we are waiting on.</summary> 
    public int AcknowledgmentSerial { get; set; } = 0;


    int retryCount = 0;
    System.DateTime WakeupHeartbeat { get; set; } = System.DateTime.Now;

    System.DateTime WakeupUnacknowledged { get; set; } = System.DateTime.Now;

    /// <summary>
    /// Initializes a new instance of the <see cref="ContextPresence"/> class.
    /// </summary>
    public ContextPresence(ServiceAccessToken serviceAccessToken) {
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

        var result = new ContextPresence(service);
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
            catch (OperationCanceledException) {
                return;
                }
            catch (TimeoutException e) {
                Timeout();
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
        Console.WriteLine("Release wait");
        WaitPoll.Set();

        }


    void Process(PresenceConnectResponse presenceConnectResponse) {
        PresenceListenerState = PresenceListenerState.Connected;


        if (presenceConnectResponse.SourceIpAddress != null) {
            
            var address = new IPAddress(presenceConnectResponse.SourceIpAddress);
            var port = presenceConnectResponse.Port ?? 0;

            LocalEndPoint = new IPEndPoint(address, port);
            }


        ReleaseWait();
        }
    void Process(PresenceErrorInvalidSerial errorInvalidSerial) {
        }
    void Process(PresenceStatus status) {
        ProcessAcknowledge(status);
        }
    void Process(PresenceNotify notify) {
        ProcessAcknowledge(notify);

        // here trigger any tasks waiting on a notification.
        }

    void ProcessAcknowledge(PresenceFromService message) {
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
            PresenceListenerState.Disconnected => WakeupHeartbeat
            }
        ;



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
        catch (Exception e){
            return;
            }
        
        }

    protected virtual void SendData(PresenceFromClient message, byte[] token) {
        message.Serial = MessageSerial++;
        var data = message.ToBytes(token);
        UdpClient.Send(data, data.Length, IPEndpoints[currentEndPoint]);

        }






    /// <summary>
    /// Force sending a poll message to the presence service.
    /// </summary>
    /// <returns>Asynchronous poll result.</returns>
    public  bool Poll() {
        WaitPoll.Reset();
        WaitPoll.Wait();
        WaitPoll.Reset();

        return ListenerActive;

        }


    public bool TryGetEndpoint(
            out IPEndPoint localEndPoint,
            out IPEndPoint externalEndPoint) {

        

        throw new NYI();
        }


    /// <summary>
    /// Request creation of an outbound session to the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account to connect to.</param>
    /// <returns>The created session context (asynchronously).</returns>
    public async Task<ContextSession> SessionRequest (string account) => throw new NYI();

    /// <summary>
    /// Returns the next inbound session request. If one or more inbound requests 
    /// have already been received, it returns the first request received. Otherwise
    /// waits for the next inbound request to be received and returns asynchronously.
    /// </summary>
    /// <returns></returns>
    public async Task<ContextSession> GetSessionRequest() => throw new NYI();

    }
