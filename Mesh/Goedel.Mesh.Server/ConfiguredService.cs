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
using Goedel.Protocol.Service;

namespace Goedel.Mesh.Server;



public static class ConsoleLoggerExtensions {

    public static IHostBuilder AddMeshService(this IHostBuilder host) {

        //host.ConfigureAppConfiguration((hostingContext, configuration) => {
        //});


        host.ConfigureServices((hostContext, services) => {

            services.AddSingleton<IConfguredService, MeshConfiguredService>();
            var configurationService = services.Configure <MeshHostConfiguration> (
                hostContext.Configuration.GetSection("MeshService"));
            var configurationHost = services.Configure<GenericHostConfiguration>(
                hostContext.Configuration.GetSection("Host"));
        });

        return host;
        }
    }





public class MeshConfiguredService : IConfguredService {



    MeshHostConfiguration MeshHostConfiguration { get; }

    GenericHostConfiguration GenericHostConfiguration { get; }

    IOptionsMonitor<MeshHostConfiguration> MeshHostConfigurationMonitor;
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
                IOptionsMonitor<MeshHostConfiguration> meshHostConfiguration,
                IOptionsMonitor<GenericHostConfiguration> genericHostConfiguration
                ) {

        //IConfigurationRoot configurationRoot = configuration.Build();

        MeshMachine = meshMachine;
        Logger = logger;

        MeshHostConfigurationMonitor = meshHostConfiguration;
        MeshHostConfigurationMonitor.OnChange(
            config => Register(config));


        MeshHostConfiguration = meshHostConfiguration.CurrentValue;
        GenericHostConfiguration = genericHostConfiguration.CurrentValue;


        var serviceConfiguration = new ServiceConfiguration() {
            Id = null!,
            ProfileUdf = MeshHostConfiguration.ServiceUdf,
            Path = MeshHostConfiguration.ServicePath,
            DNS = MeshHostConfiguration.ServiceDNS.ToList()
            // ignore the logs for now
            };
        var hostConfiguration = new HostConfiguration() {
            Id = null!,
            ProfileUdf = GenericHostConfiguration.HostUdf,
            DeviceUdf = GenericHostConfiguration.DeviceUdf,
            Path = MeshHostConfiguration.HostPath,
            DNS = new List<string>() { GenericHostConfiguration.HostDns },
            IP = GenericHostConfiguration.IP.ToList()
            };

        // Build the HTTP endpoints for the service
        // The service [protocol] at [example.com] with hosts
        // [host1.example.net, host2.example.net] will be bound to the following URIs:
        //
        // https://example.com/.well-known/protocol/
        // https://protocol.example.com/.well-known/protocol/
        // https://host1.example.net:15099/.well-known/protocol/
        // https://host2.example.net:15099/.well-known/protocol/


        var transactionLogger = new LogServiceGeneric
            (serviceConfiguration, hostConfiguration, null, logger);


        PublicMeshService = new PublicMeshService(MeshMachine, 
            GenericHostConfiguration, MeshHostConfiguration, transactionLogger);
        Endpoints = PublicMeshService.Endpoints;

        //PublicMeshService = new PublicMeshService(MeshMachine, serviceConfiguration, hostConfiguration);

        }

    void Register(MeshHostConfiguration meshHostConfiguration) {

        // the only thing we are going to be able to change with the service
        // running is the administrator list

        }


    }


public class MeshHostConfiguration : GenericServiceConfiguration {

    public string[] Administrators { get; set; } = Array.Empty<string>();

    public string? HostPath { get; set; } = null;

    }