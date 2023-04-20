

namespace Goedel.Presence.Server;

/// <summary>
/// Extensions class for adding a Mesh Service Provider to a host.
/// </summary>
public static class PresenceServiceExtensions {

    /// <summary>
    /// Inject Mesh service and options to the builder <paramref name="host"/>
    /// </summary>
    /// <param name="host">The service to inject.</param>
    /// <returns>The value of <paramref name="host"/> for chaining.</returns>

    public static IHostBuilder AddPresenceService(this IHostBuilder host) {

        //host.ConfigureAppConfiguration((hostingContext, configuration) => {
        //});

        //Screen.WriteLine($"Add Mesh Service");

        host.ConfigureServices((hostContext, services) => {
            var serviceConfig = hostContext.Configuration.GetSection(PresenceServiceConfiguration.ConfigurationEntry.Name);
            services.AddSingleton<IConfguredService, ResolverConfiguredService>();
            var configurationService = services.Configure<PresenceServiceConfiguration>(serviceConfig);
                //var configurationHost = services.Configure<GenericHostConfiguration>(
                //    hostContext.Configuration.GetSection(GenericHostConfiguration.ConfigurationEntry.Name));

            });

        return host;
        }
    }




/// <summary>
/// A Mesh service provider in a form suited for dependency injection.
/// </summary>
public class ResolverConfiguredService : IConfguredService {


    ///<summary>The resolver configuration.</summary> 
    public PresenceServiceConfiguration PresenceServiceConfiguration { get; }

    ///<summary>The generic host configuration.</summary> 
    public GenericHostConfiguration GenericHostConfiguration { get; }


    IOptionsMonitor<PresenceServiceConfiguration> MeshHostConfigurationMonitor { get; }
    IMeshMachine MeshMachine { get; }

    ///<summary>The logger interface.</summary> 
    public ILogger<ManagedListener> Logger { get; }

    ///<summary>The resolver service context.</summary> 
    PresenceServer PresenceServer { get; set; }

    ///<inheritdoc/>
    public JpcInterface JpcInterface => PresenceServer;

    ///<inheritdoc/>
    public List<Endpoint> Endpoints { get; }

    ///<inheritdoc/>
    public void Dispose () => PresenceServer?.Dispose ();

    /// <summary>
    /// Mesh service provider instance configured with options specifie in 
    /// <paramref name="meshHostConfiguration"/> and <paramref name="genericHostConfiguration"/>.
    /// </summary>
    /// <param name="logger">The system logger service.</param>
    /// <param name="meshMachine">The Mesh machine instance.</param>
    /// <param name="hostMonitor">The host monitor for tracking host load and performance.</param>
    /// <param name="meshHostConfiguration">The Mesh service configuration.</param>
    /// <param name="genericHostConfiguration">The host configuration.</param>
    public ResolverConfiguredService(
                ILogger<ManagedListener> logger,
                IMeshMachine meshMachine,
                HostMonitor hostMonitor,
                IOptionsMonitor<PresenceServiceConfiguration> meshHostConfiguration,
                IOptionsMonitor<GenericHostConfiguration> genericHostConfiguration
                ) {
        MeshMachine = meshMachine;
        Logger = logger;

        MeshHostConfigurationMonitor = meshHostConfiguration;
        MeshHostConfigurationMonitor.OnChange(
            config => Register(config));


        PresenceServiceConfiguration = meshHostConfiguration.CurrentValue;
        GenericHostConfiguration = genericHostConfiguration.CurrentValue;

        if ((PresenceServiceConfiguration?.HostPath).IsBlank()) {
            return;
            }


        //var transactionLogger = new LogService
        //    (GenericHostConfiguration, PresenceServiceConfiguration, hostMonitor);

        PresenceServer = new PresenceServer(MeshMachine,
            GenericHostConfiguration, PresenceServiceConfiguration, Logger);
        Endpoints = PresenceServer.Endpoints;

        }

    void Register(PresenceServiceConfiguration meshHostConfiguration) {

        // the only thing we are going to be able to change with the service
        // running is the administrator list

        }


    }

