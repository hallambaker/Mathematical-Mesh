

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


    }
