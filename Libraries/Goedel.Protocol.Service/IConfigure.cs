namespace Goedel.Protocol.Service;

///// <summary>
///// Service configuration
///// </summary>
//public interface IServiceConfiguration {

//    ///<summary>The IANA well known service name.</summary> 
//    string WellKnown { get; }

//    ///<summary>List of service addresses.</summary> 
//    List<string> Addresses { get; }
//    }


/// <summary>
/// Service configuration
/// </summary>
public interface IServiceConfiguration {
    ///<summary>Maps configuration entry to configuration.</summary> 
    public Dictionary<string, object> Dictionary { get; }

    ///<summary>The host configuration.</summary> 
    public GenericHostConfiguration GenericHost { get; set; }


    }
