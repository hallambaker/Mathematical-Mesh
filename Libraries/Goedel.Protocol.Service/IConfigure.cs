namespace Goedel.Protocol.Service;

/// <summary>
/// Service configuration
/// </summary>
public interface IServiceConfiguration {

    ///<summary>The IANA well known service name.</summary> 
    string WellKnown { get; }

    ///<summary>List of service addresses.</summary> 
    List<string> Addresses { get; }
    }

