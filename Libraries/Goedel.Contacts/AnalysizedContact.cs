namespace Goedel.Contacts;

/// <summary>
/// Convenience class collecting together related parts of a <see cref="JsContact"/>.
/// </summary>
public record AnalysizedContact {

    ///<summary>Service groups this entry is a member of.</summary> 
    public List<OnlineService> Parents { get; } = [];

    ///<summary>Services that are members of this service groups.</summary> 
    public List<OnlineService> Children { get; } = [];


    ///<summary>Email addresses as an <see cref="OnlineService"/></summary> 
    public List<OnlineService> Emails { get; } = [];

    ///<summary>Services of type HTTP or HTTPS</summary> 
    public List<OnlineService> Webs { get; } = [];

    ///<summary>Mesh services</summary> 
    public List<OnlineService> Mesh { get; } = [];



    ///<summary>Services of type SSH</summary> 
    public List<OnlineService> Ssh { get; } = [];


    ///<summary>Services not included in any other category.</summary> 
    public List<OnlineService> Other { get; } = [];




    ///<summary>Groups</summary> 
    public List<OnlineService> Groups { get; } = [];



    ///<summary>Services of type credential</summary> 
    public List<OnlineService> Credentials { get; } = [];
    }
