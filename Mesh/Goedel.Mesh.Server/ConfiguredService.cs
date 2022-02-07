using Goedel.Protocol.GenericHost;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Mesh.ServiceAdmin;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Goedel.Protocol.GenericHost;

namespace Goedel.Mesh.Server;



public static class ConsoleLoggerExtensions {

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

        var transactionLogger = new LogServiceGeneric
            (GenericHostConfiguration, MeshHostConfiguration, hostMonitor, logger);

        PublicMeshService = new PublicMeshService(MeshMachine, 
            GenericHostConfiguration, MeshHostConfiguration, transactionLogger);
        Endpoints = PublicMeshService.Endpoints;

        }

    void Register(MeshServiceConfiguration meshHostConfiguration) {

        // the only thing we are going to be able to change with the service
        // running is the administrator list

        }


    }


