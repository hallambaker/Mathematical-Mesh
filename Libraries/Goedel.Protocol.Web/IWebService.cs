


namespace Goedel.Protocol.Web;

/// <summary>
/// Interface for a WebService.
/// </summary>
public interface IWebService<U> {

    ///<summary>The resource map</summary> 
    Dictionary<string, WebResource<U>> ResourceMap { get; }
    }
