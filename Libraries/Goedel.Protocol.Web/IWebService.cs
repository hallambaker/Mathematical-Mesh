


namespace Goedel.Protocol.Web;

/// <summary>
/// Interface for a WebService.
/// </summary>
public interface IWebService<T> {

    ///<summary>The resource map</summary> 
    Dictionary<string, WebResource<T>> ResourceMap { get; }
    }
