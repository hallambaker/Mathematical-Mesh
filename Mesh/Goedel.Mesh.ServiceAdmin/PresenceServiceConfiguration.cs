namespace Goedel.Mesh.ServiceAdmin;

/// <summary>
/// The Mesh service configuration.
/// </summary>
public class PresenceServiceConfiguration : ServiceConfiguration {

    ///<summary>The configuration entry.</summary> 
    public static readonly ConfigurationEntry ConfigurationEntry =
        new("PersistanceService", typeof(PersistanceServiceConfiguration),
            PresenceService.Discovery, PresenceService.WellKnown);

    ///<inheritdoc/>
    public override ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;


    }
