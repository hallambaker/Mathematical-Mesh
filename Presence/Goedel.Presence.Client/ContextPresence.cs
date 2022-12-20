

using Goedel.Mesh;

namespace Goedel.Presence.Client;

/// <summary>
/// Message identifier, returned when a message is sent, used to wait for 
/// confirmation of message receipt.
/// </summary>
public record MessageId {
    }


/// <summary>
/// Result of polling the presence service for context.
/// </summary>
public record ContextPoll {
    }



/// <summary>
/// Context for a presence service connection.
/// </summary>
public class ContextPresence : Disposable {

    CancellationTokenSource ListenerCancel { get; }

    ///<inheritdoc/>
    protected override void Disposing() {
        ListenerActive = false;
        ListenerCancel.Cancel();
        }


    bool ListenerActive {get; set;} = false;

    ///<summary>Keepalive timer in Ticks. Default value is 1 second.</summary> 
    public int Heartbeat { get; set; } =(int) TimeSpan.TicksPerSecond;


    UdpClient UdpClient {get; set;}

    Task ListenerTask;


    /// <summary>
    /// Initializes a new instance of the <see cref="ContextPresence"/> class.
    /// </summary>
    public ContextPresence() {

        UdpClient = new();

        ListenerCancel = new CancellationTokenSource();
        }

    /// <summary>
    /// Factory method returning a new presence context on the presence service
    /// provided to the account <paramref name="contextAccount"/>.
    /// </summary>
    /// <param name="contextAccount">The account under which the presence service 
    /// is provided.</param>
    /// <returns>The presence context.</returns>
    /// <exception cref="NYI"></exception>
    public static ContextPresence GetContext(ContextUser contextAccount) {

        var statusRequest = new StatusRequest() {
            Services = new List<String>() { "mmm_presence" }
            };
        contextAccount.Sync(statusRequest);

        "Here do a status call".TaskFunctionality(true);


        var presenceServiceEndpoints = contextAccount.GetPresenceEndpoints();


        var result = new ContextPresence {
            };

        result.BindPresence(presenceServiceEndpoints[0]);

        return result;
        }


    /// <summary>
    /// Bind a presence service provider. A presence context may have multiple presence
    /// providers bound simultaneously???
    /// </summary>
    /// <param name="udpServiceEndpoint"></param>
    public async void BindPresence(UdpServiceEndpoint udpServiceEndpoint  ) {

        // send a message to the presence service requesting binding.
        var bytes = new byte[1024];
        var sendTask = UdpClient.Send (bytes, bytes.Length, udpServiceEndpoint.IPEndPoint);

        // wait for acknowledgement should spice this up with retry, etc.
        var receiveTask = UdpClient.ReceiveAsync();
        var receive = await receiveTask;

        // here add in timeout and retry stuff...

        ListenerTask = Listener();
        }


    /// <summary>
    /// The listener task.
    /// </summary>
    /// <returns></returns>
    async Task Listener() {
        ListenerActive = true;
        var token = ListenerCancel.Token;

        // ToDo: add in cancellation token for gracefull termination.
        // Needs to be from a source established in the context account.


        try {
            var receiveTask = UdpClient.ReceiveAsync(token).AsTask();
            var timerTask = Task.Delay(Heartbeat);
            while (ListenerActive) {

                // timer task here

                await Task.WhenAny(receiveTask, timerTask);

                if (receiveTask.IsCompleted) {
                    // process received data

                    receiveTask = UdpClient.ReceiveAsync(token).AsTask();
                    }
                if (timerTask.IsCompleted) {
                    // send out a heartbeat

                    timerTask = Task.Delay(Heartbeat);
                    }


                }
            }
        catch (TaskCanceledException) {
            // The presence context was disposed, carry on.
            }

        }



    /// <summary>
    /// Force sending a poll message to the presence service.
    /// </summary>
    /// <returns>Asynchronous poll result.</returns>
    public async Task<ContextPoll> Poll () => throw new NYI();


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
