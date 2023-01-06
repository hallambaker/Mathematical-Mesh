namespace Goedel.Presence.Client;

/// <summary>
/// Messaging session context. Used to exchange messages with a single endpoint.
/// </summary>
public class ContextSession {

    ///<summary>The UdpClient used to control the session.</summary> 
    public UdpClient UdpClient { get; init; }

    ///<summary>The external address associated with the endpoint.</summary> 

    public UdpEndpoint ExternalEndpoint { get; init; }


    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="sessionRequest">The session request message.</param>
    /// <param name="sessionResponse">The session response message.</param>
    public ContextSession(
                    SessionRequest sessionRequest,
                    SessionResponse sessionResponse) {
        }




    /// <summary>
    /// Respond to session creation request.
    /// </summary>
    /// <param name="accept">If true, session request was accepted, otherwise false.</param>
    public void SessionResponse(bool accept = true) {
        }


    /// <summary>
    /// Send the message <paramref name="messageContent"/> to the session endpoint.
    /// </summary>
    /// <param name="messageContent">The message to send.</param>
    /// <returns>Message identifier that can be used to create an an asynchronous
    /// wait task for confirmation of receipt.</returns>
    public MessageId SendMessage(MessageContent messageContent) => throw new NYI();

    /// <summary>
    /// If one or more messages have been received but not delivered, return
    /// the first. Otherwise wait asynchronously for arival of a message.
    /// </summary>
    /// <returns>The message content (synchronously)</returns>
    public async Task<MessageContent> GetMessage () => throw new NYI();

    /// <summary>
    /// Return a task waiting on confirmation of receipt of the message 
    /// <paramref name="messageId"/>.
    /// </summary>
    /// <param name="messageId">The message to await receipt of.</param>
    /// <returns>The message receipt (asynchronously).</returns>
    public async Task<MessageId> Synchronize(MessageId messageId) => throw new NYI();

    }
