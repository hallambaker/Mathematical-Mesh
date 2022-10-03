

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


    bool ListenerActive {get; set;} = false;

    public int Heartbeat { get; set; } = 1000;


    UdpClient UdpClient {get; set;}

    Task ListenerTask;

    public ContextPresence() {

        UdpClient = new();
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



    public async Task Listener() {
        ListenerActive = true;


        while (ListenerActive) {
            var receiveTask = UdpClient.ReceiveAsync();
            var timerTask = Task.Delay(Heartbeat);
            // timer task here

            await Task.WhenAny(receiveTask, timerTask);

            if (receiveTask.IsCompleted) {
                // process received data

                receiveTask = UdpClient.ReceiveAsync();
                }
            if (timerTask.IsCompleted) {
                // process received data

                timerTask = Task.Delay(Heartbeat);
                }


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
