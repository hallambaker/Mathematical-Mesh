using Goedel.Cryptography.Core;

namespace Goedel.Mesh.Server;

/// <summary>
/// The Mesh service configuration.
/// </summary>
public class MeshServiceConfiguration : ServiceConfiguration {


    /// <summary>
    /// File in which the callsign registry profile is recorded.
    /// </summary>
    public string ProfileRegistryCallsign { get; set; }

    ///<summary>The configuration entry.</summary> 
    public static readonly ConfigurationEntry ConfigurationEntry =
        new("MeshService", typeof(MeshServiceConfiguration),
            MeshService.Discovery, MeshService.WellKnown);

    ///<inheritdoc/>
    public override ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;


    /// <summary>
    /// Create a new instance and return the corresponding configuration file.
    /// </summary>
    /// <param name="GenericHostConfiguration">Generic service configuration.</param>
    /// <param name="service">The service endpoing.</param>
    /// <returns>The configuration setting,</returns>
    public static MeshServiceConfiguration Create(
                IMeshMachineClient meshMachine,
                GenericHostConfiguration GenericHostConfiguration,
                string serviceDns) {

        //var hostPath = KeyCollectionCore.DirectoryAccount;

        return new MeshServiceConfiguration() {
            //HostPath = hostPath,
            ServiceDNS = new List<string> { serviceDns },
            ServicePath = meshMachine.DirectoryAccounts,
            };
        }



    /// <summary>
    /// Save the callsign registry profile <paramref name="profileAccount"/> to a file and record the file
    /// location in <paramref name="filename"/>.
    /// </summary>
    /// <param name="profileAccount">The callsign registry profile.</param>
    /// <param name="filename">The file to save the profile to.</param>
    public void AddProfileRegistryCallsign(
                DareEnvelope profileAccount, 
                string filename = "CallsignRegistryProfile.dare") {
        var path = Path.Combine (ServicePath, filename);
        profileAccount.ToFile(path);
        ProfileRegistryCallsign = path;
        }


    }
