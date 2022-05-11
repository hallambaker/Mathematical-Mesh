namespace Goedel.Mesh.ServiceAdmin;

/// <summary>
/// The Mesh service configuration.
/// </summary>
public class PersistanceServiceConfiguration : ServiceConfiguration {

    ///<summary>The configuration entry.</summary> 
    public static readonly ConfigurationEntry ConfigurationEntry =
        new("PersistanceService", typeof(PersistanceServiceConfiguration),
            PersistanceService.Discovery, PersistanceService.WellKnown);

    ///<inheritdoc/>
    public override ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;


    }
