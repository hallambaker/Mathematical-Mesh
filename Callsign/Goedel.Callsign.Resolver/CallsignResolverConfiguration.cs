

namespace Goedel.Callsign.Resolver;

/// <summary>
/// The Mesh service configuration.
/// </summary>
public class CallsignResolverConfiguration : ServiceConfiguration {

    ///<summary>The configuration entry.</summary> 
    public static readonly ConfigurationEntry ConfigurationEntry =
        new("CallsignResolver", typeof(CallsignResolverConfiguration),
            ResolverService.Discovery, ResolverService.WellKnown);

    ///<inheritdoc/>
    public override ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;


    ///<summary>The sevice address of the registry to resolve.</summary> 
    public string RegistryServiceAddress { get; set; }

    ///<summary>The resolver service DNS.</summary> 
    public string ResolverDNS { get; set; }

    /// <summary>
    /// Create a callsign resolver configuration.
    /// </summary>
    /// <param name="meshMachine">The mesh machine for which the configuration is to be created.</param>
    /// <param name="GenericHostConfiguration">The generic host configuration.</param>
    /// <param name="registry">The registry service address.</param>
    /// <param name="resolver">The resolver DNS address.</param>
    /// <returns></returns>
    public static CallsignResolverConfiguration Create(
                IMeshMachineClient meshMachine,
                GenericHostConfiguration GenericHostConfiguration,
                string registry,
                string resolver) {

        return new CallsignResolverConfiguration() {
            RegistryServiceAddress = registry,
            ResolverDNS = resolver,
            HostPath = meshMachine.GetServiceDirectory(MeshConstants.DirectoryResolver),
            ServicePath = meshMachine.GetServiceDirectory(MeshConstants.DirectoryResolver),
            };
        }
    }
