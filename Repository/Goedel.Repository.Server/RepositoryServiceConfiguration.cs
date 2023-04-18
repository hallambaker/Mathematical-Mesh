using Goedel.Mesh.Client;
using Goedel.Protocol;

namespace Goedel.Repository.Server;

/// <summary>
/// The Mesh service configuration.
/// </summary>
public class RepositoryServiceConfiguration : ServiceConfiguration {


    ///<summary>The sevice address of the registry to resolve.</summary> 
    public string Service { get; set; }


    ///<summary>The configuration entry.</summary> 
    public static readonly ConfigurationEntry ConfigurationEntry =
        new("PersistanceService", typeof(RepositoryServiceConfiguration),
            RepositoryService.Discovery, RepositoryService.WellKnown);

    ///<inheritdoc/>
    public override ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;


    /// <summary>
    /// Create a new instance and return the corresponding configuration file.
    /// </summary>
    /// <param name="meshMachine">The Mesh machine.</param>
    /// <param name="GenericHostConfiguration">Generic service configuration.</param>
    /// <param name="service">The service endpoing.</param>
    /// <returns>The configuration setting,</returns>
    public static RepositoryServiceConfiguration Create(
                IMeshMachineClient meshMachine,
                GenericHostConfiguration GenericHostConfiguration,
                string service) {

        return new RepositoryServiceConfiguration() {
            Service = service
            };
        }
    }
