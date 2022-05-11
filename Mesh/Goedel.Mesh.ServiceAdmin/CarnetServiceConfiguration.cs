namespace Goedel.Mesh.ServiceAdmin;

/// <summary>
/// The Mesh service configuration.
/// </summary>
public class CarnetServiceConfiguration : ServiceConfiguration {

    ///<summary>The configuration entry.</summary> 
    public static readonly ConfigurationEntry ConfigurationEntry =
        new("CarnetService", typeof(CarnetServiceConfiguration),
            CarnetService.Discovery, CarnetService.WellKnown);

    ///<inheritdoc/>
    public override ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;


    }
