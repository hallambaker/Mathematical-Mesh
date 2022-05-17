namespace Goedel.Presence.Server;

/// <summary>
/// The Mesh service configuration.
/// </summary>
public class PresenceServiceConfiguration : ServiceConfiguration {

    ///<summary>The configuration entry.</summary> 
    public static readonly ConfigurationEntry ConfigurationEntry =
        new("PersistanceService", typeof(PresenceServiceConfiguration),
            PresenceService.Discovery, PresenceService.WellKnown);

    ///<inheritdoc/>
    public override ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;


    }
