

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
    public string Registry { get; set; }

    public string Resolver { get; set; }
    public static CallsignResolverConfiguration Create(
                IMeshMachineClient meshMachine,
                GenericHostConfiguration GenericHostConfiguration,
                string registry,
                string resolver) {

        return new CallsignResolverConfiguration() {
            Registry = registry,
            Resolver = resolver,
            HostPath = meshMachine.GetServiceDirectory(MeshConstants.DirectoryResolver),
            //ServiceDNS = new List<string> { serviceDns },
            ServicePath = meshMachine.GetServiceDirectory(MeshConstants.DirectoryResolver),
            };
        }
    }
