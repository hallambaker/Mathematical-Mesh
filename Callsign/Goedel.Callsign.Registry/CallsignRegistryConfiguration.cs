namespace Goedel.Callsign.Registry;

/// <summary>
/// The Mesh service configuration.
/// </summary>
public class CallsignRegistryConfiguration : IConfigurationEntry {

    ///<summary>The configuration entry.</summary> 
    public static readonly ConfigurationEntry ConfigurationEntry =
        new("CallsignRegistry", typeof(CallsignRegistryConfiguration),
            null, null);
    ///<inheritdoc/>
    public ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;

    ///<summary>The service address by which the registry is reached.</summary> 
    public string ServiceAddress { get; set; }

    ///<summary>The signature schedule</summary> 
    public string SignatureSchedule { get; set; } = "1h";


    /// <summary>
    /// Create a new instance and return the corresponding configuration file.
    /// </summary>
    /// <param name="meshMachine">The Mesh machine to which the registry 
    /// account context is to be saved..</param>
    /// <param name="serviceAddress">The service endpoing.</param>
    /// <returns>The configuration setting,</returns>
    public static CallsignRegistryConfiguration Create(
                IMeshMachineClient meshMachine,
                string serviceAddress) {

        return new CallsignRegistryConfiguration() {
            ServiceAddress = serviceAddress
            };
        }

    }

