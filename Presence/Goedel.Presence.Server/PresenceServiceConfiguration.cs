namespace Goedel.Presence.Server;

/// <summary>
/// The Mesh service configuration.
/// </summary>
public class PresenceServiceConfiguration : ServiceConfiguration {


    ///<summary>The IP address and port numbers</summary> 
    public List<string> IP { get; set; } = new();

    ///<summary>Number of UDP socket listeners per protocol.</summary> 
    public int UdpSocketListeners = 0;

    ///<summary>The configuration entry.</summary> 
    public static readonly ConfigurationEntry ConfigurationEntry =
        new("PersistanceService", typeof(PresenceServiceConfiguration),
            MeshConstants.MeshPresenceService, null);

    ///<inheritdoc/>
    public override ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;


    }
