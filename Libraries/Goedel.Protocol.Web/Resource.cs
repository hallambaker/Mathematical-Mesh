


namespace Goedel.Protocol.Web;

/// <summary>
/// Web Service resource descriptor.
/// </summary>
/// <param name="Method">The callback method for the resource.</param>
public record Resource(
            Func<IWebService, HttpListenerContext, Task> Method
            ) {
    }