

namespace Goedel.Mesh.Server;


/// <summary>
/// Extensions class for adding a Mesh Service Provider to a host.
/// </summary>
public static class ConsoleLoggerExtensions {

    /// <summary>
    /// Inject Mesh service and options to the builder <paramref name="host"/>
    /// </summary>
    /// <param name="host">The service to inject.</param>
    /// <returns>The value of <paramref name="host"/> for chaining.</returns>

    public static IHostBuilder AddMeshService(this IHostBuilder host) {

        //host.ConfigureAppConfiguration((hostingContext, configuration) => {
        //});

        Screen.WriteLine($"Add Mesh Service");

        host.ConfigureServices((hostContext, services) => {

            services.AddSingleton<IConfguredService, MeshConfiguredService>();
            var configurationService = services.Configure <MeshServiceConfiguration> (
                hostContext.Configuration.GetSection("MeshService"));
            var configurationHost = services.Configure<GenericHostConfiguration>(
                hostContext.Configuration.GetSection("Host"));
        });

        return host;
        }
    }




/// <summary>
/// A Mesh service provider in a form suited for dependency injection.
/// </summary>
public class MeshConfiguredService : IConfguredService {



    MeshServiceConfiguration MeshHostConfiguration { get; }

    GenericHostConfiguration GenericHostConfiguration { get; }

    IOptionsMonitor<MeshServiceConfiguration> MeshHostConfigurationMonitor;
    IMeshMachine MeshMachine { get; }
    ILogger<ManagedListener> Logger { get; }

    PublicMeshService PublicMeshService { get; set; }

    ///<inheritdoc/>
    public JpcInterface JpcInterface => PublicMeshService;

    ///<inheritdoc/>
    public List<Endpoint> Endpoints { get; }




    /// <summary>
    /// Mesh service provider instance configured with options specifie in 
    /// <paramref name="meshHostConfiguration"/> and <paramref name="genericHostConfiguration"/>.
    /// </summary>
    /// <param name="logger">The system logger service.</param>
    /// <param name="meshMachine">The Mesh machine instance.</param>
    /// <param name="hostMonitor">The host monitor for tracking host load and performance.</param>
    /// <param name="meshHostConfiguration">The Mesh service configuration.</param>
    /// <param name="genericHostConfiguration">The host configuration.</param>
    public MeshConfiguredService(
                ILogger<ManagedListener> logger,
                IMeshMachine meshMachine,
                HostMonitor hostMonitor,
                IOptionsMonitor<MeshServiceConfiguration> meshHostConfiguration,
                IOptionsMonitor<GenericHostConfiguration> genericHostConfiguration
                ) {

        MeshMachine = meshMachine;
        Logger = logger;

        MeshHostConfigurationMonitor = meshHostConfiguration;
        MeshHostConfigurationMonitor.OnChange(
            config => Register(config));


        MeshHostConfiguration = meshHostConfiguration.CurrentValue;
        GenericHostConfiguration = genericHostConfiguration.CurrentValue;

        var transactionLogger = new LogService
            (GenericHostConfiguration, MeshHostConfiguration, hostMonitor);

        PublicMeshService = new PublicMeshService(MeshMachine, 
            GenericHostConfiguration, MeshHostConfiguration, transactionLogger);
        Endpoints = PublicMeshService.Endpoints;

        }

    void Register(MeshServiceConfiguration meshHostConfiguration) {

        // the only thing we are going to be able to change with the service
        // running is the administrator list

        }


    }


