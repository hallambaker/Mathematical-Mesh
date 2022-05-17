namespace Goedel.Callsign.Registry;

/// <summary>
/// The Mesh service configuration.
/// </summary>
public class CallsignRegistryConfiguration : ServiceConfiguration {

    ///<summary>The configuration entry.</summary> 
    public static readonly ConfigurationEntry ConfigurationEntry =
        new("CallsignRegistry", typeof(CallsignRegistryConfiguration),
            RegistryService.Discovery, RegistryService.WellKnown);

    ///<inheritdoc/>
    public override ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;


    ///<summary>The signature schedule</summary> 
    public string SignatureSchedule { get; set; } = "1h";

    ///<summary>Cross certifiers.</summary> 
    public List<CrossCertifier> CrossCertifiers { get; set; } = new();


    ///<summary>Service addresses of resolver services to which the callsign data is to be
    ///immediately published via a push notification.</summary> 
    public List<string> Publish { get; set; } = new();


    }


/// <summary>
/// Cross certification entry.
/// </summary>
public class CrossCertifier {

    ///<summary>The cross certification frequency (defaults to value specified in enclosing 
    ///<see cref="CallsignRegistryConfiguration.SignatureSchedule"/></summary>.
    public string Frequency { get; set; } = "1h";


    ///<summary>Party to which the signature request is directed.</summary> 
    public string Signer { get; set; }
    }