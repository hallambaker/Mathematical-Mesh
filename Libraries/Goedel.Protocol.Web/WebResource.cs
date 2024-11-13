


namespace Goedel.Protocol.Web;



/// <summary>
/// Web Service resource descriptor.
/// </summary>
/// <param name="Method">The callback method for the resource.</param>
/// <param name="SignedIn">If true, the user must be signed in to access this page.</param>
public record WebResource<U>(
            Func<HttpListenerContext, U, Task> Method,
            bool SignedIn = true
            ) {
    }