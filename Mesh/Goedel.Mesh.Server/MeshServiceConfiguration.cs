namespace Goedel.Mesh.Server;

/// <summary>
/// The Mesh service configuration.
/// </summary>
public class MeshServiceConfiguration : ServiceConfiguration {

    ///<summary>The configuration entry.</summary> 
    public static readonly ConfigurationEntry ConfigurationEntry =
        new("MeshService", typeof(MeshServiceConfiguration),
            MeshService.Discovery, MeshService.WellKnown);

    ///<inheritdoc/>
    public override ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;


    }
