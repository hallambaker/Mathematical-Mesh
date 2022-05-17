namespace Goedel.Repository.Server;

/// <summary>
/// The Mesh service configuration.
/// </summary>
public class RepositoryServiceConfiguration : ServiceConfiguration {

    ///<summary>The configuration entry.</summary> 
    public static readonly ConfigurationEntry ConfigurationEntry =
        new("PersistanceService", typeof(RepositoryServiceConfiguration),
            RepositoryService.Discovery, RepositoryService.WellKnown);

    ///<inheritdoc/>
    public override ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;


    }
