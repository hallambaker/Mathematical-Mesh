using Goedel.Mesh.Client;
using Goedel.Protocol;

namespace Goedel.Presence.Server;

/// <summary>
/// The Mesh service configuration.
/// </summary>
public class PresenceServiceConfiguration : ServiceConfiguration {


    ///<summary>The IP address and port numbers</summary> 
    public List<string> IP { get; set; } = new();

    ///<summary>Number of UDP socket listeners per protocol.</summary> 
    public int UdpSocketListeners = 0;


    ///<summary>The sevice address of the registry to resolve.</summary> 
    public string Service { get; set; }


    ///<summary>The configuration entry.</summary> 
    public static readonly ConfigurationEntry ConfigurationEntry =
        new("PersistanceService", typeof(PresenceServiceConfiguration),
            MeshConstants.MeshPresenceService, null);

    ///<inheritdoc/>
    public override ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;


    /// <summary>
    /// Create a new instance and return the corresponding configuration file.
    /// </summary>
    /// <param name="meshMachine">The mesh machine.</param>
    /// <param name="GenericHostConfiguration">Generic service configuration.</param>
    /// <param name="service">The service endpoing.</param>
    /// <returns>The configuration setting,</returns>
    public static PresenceServiceConfiguration Create(
                IMeshMachineClient meshMachine,
                GenericHostConfiguration GenericHostConfiguration,
                string service) {

        return new PresenceServiceConfiguration() {
            Service = service
            };
        }
    }
