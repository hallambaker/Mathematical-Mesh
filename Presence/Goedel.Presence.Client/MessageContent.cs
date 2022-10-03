namespace Goedel.Presence.Client;


/// <summary>
/// Message content type identifiers.
/// </summary>
public enum MessageContentType  {

    ///<summary>Raw binary data.</summary> 
    Binary = 0,
    
    ///<summary>Plaintext message without formatting.</summary> 
    Plaintext = 1,
    
    ///<summary>Message with limited formatting.</summary> 
    Richtext = 2,

    }

/// <summary>
/// Base class for message content.
/// </summary>
/// <param name="ContentType">Content type identifier.</param>
/// <param name="Payload">The message payload.</param>
public record MessageContent(
            MessageContentType ContentType,
            byte[] Payload)  {




    }
