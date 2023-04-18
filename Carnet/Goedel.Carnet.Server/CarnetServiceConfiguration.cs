using Goedel.Mesh.Client;
using Goedel.Protocol;

namespace Goedel.Carnet.Server;

/// <summary>
/// The Mesh service configuration.
/// </summary>
public class CarnetServiceConfiguration : ServiceConfiguration {

    ///<summary>The administration account service address.</summary> 
    public string AdminServiceAddress { get; set; }

    ///<summary>The configuration entry.</summary> 
    public static readonly ConfigurationEntry ConfigurationEntry =
        new("CarnetService", typeof(CarnetServiceConfiguration),
            CarnetService.Discovery, CarnetService.WellKnown);

    ///<inheritdoc/>
    public override ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;

    ///<summary>The sevice address of the registry to resolve.</summary> 
    public string Service { get; set; }

    /// <summary>
    /// Create a new instance and return the corresponding configuration file.
    /// </summary>
    /// <param name="meshMachine">The mesh machine.</param>
    /// <param name="GenericHostConfiguration">Generic service configuration.</param>
    /// <param name="service">The service endpoing.</param>
    /// <returns>The configuration setting,</returns>
    public static CarnetServiceConfiguration Create(
                IMeshMachineClient meshMachine,
                GenericHostConfiguration GenericHostConfiguration,
                string service) {

        return new CarnetServiceConfiguration() {
            Service = service
            };
        }

    }
