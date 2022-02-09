

namespace Goedel.Mesh.ServiceAdmin;

/// <summary>
/// Dependency injection wrapper for the RUD listener. 
/// </summary>
public class MeshRudListener : IServiceListener {

    ///<summary>The host configuration.</summary> 
    public GenericHostConfiguration GenericHostConfiguration { get; }

    ///<summary>The RUD service.</summary> 
    public RudService RudService { get; set; }

    ///<summary>The host credential.</summary> 
    ICredentialPrivate Credential { get; set; }

    private IMeshMachine MeshMachine { get; }
    private IEnumerable<IConfguredService> ConfiguredServices { get; }

    /// <summary>
    /// A RUD listener presenting Mesh credentials.
    /// </summary>
    /// <param name="genericHostConfiguration">The host configuration.</param>
    /// <param name="configuredServices">The services to be served.</param>
    /// <param name="hostMonitor">The host monitor tracking load and performance.</param>
    /// <param name="meshMachine">The Mesh machine.</param>
    public MeshRudListener(
                IOptionsMonitor<GenericHostConfiguration> genericHostConfiguration,
                IEnumerable<IConfguredService> configuredServices,
                HostMonitor hostMonitor,
                IMeshMachine meshMachine) {
        GenericHostConfiguration = genericHostConfiguration.CurrentValue;
        MeshMachine = meshMachine;
        ConfiguredServices = configuredServices;

        Credential = MeshMachine.GetCredential(
                GenericHostConfiguration.DeviceUdf,
                GenericHostConfiguration.HostUdf);

        RudService = new RudService(
                ConfiguredServices, hostMonitor, Credential,
                maxCores: GenericHostConfiguration.MaxCores);
        }

    ///<inheritdoc/>
    public async Task StartAsync(
            CancellationToken cancellationToken) {

        Credential = MeshMachine.GetCredential(
                GenericHostConfiguration.DeviceUdf,
                GenericHostConfiguration.HostUdf);

        await RudService.WaitServiceAsync();
        }

    }
