namespace Goedel.Callsign.Registry;

/// <summary>
/// The Mesh service configuration.
/// </summary>
public class CallsignRegistryConfiguration  : IConfigurationEntry {

    ///<summary>The configuration entry.</summary> 
    public static readonly ConfigurationEntry ConfigurationEntry =
        new("CallsignRegistry", typeof(CallsignRegistryConfiguration),
            null, null);
    ///<inheritdoc/>
    public ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;
    public string RegistryAccount { get; set; }

    ///<summary>The signature schedule</summary> 
    public string SignatureSchedule { get; set; } = "1h";


    /// <summary>
    /// Create a new instance and return the corresponding configuration file.
    /// </summary>
    /// <param name="GenericHostConfiguration">Generic service configuration.</param>
    /// <param name="service">The service endpoing.</param>
    /// <returns>The configuration setting,</returns>
    public static CallsignRegistryConfiguration Create(
                IMeshMachineClient meshMachine,
                string accountAddress) {

        return new CallsignRegistryConfiguration() {
            RegistryAccount = accountAddress
            };
        }

    }

