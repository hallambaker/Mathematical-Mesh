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

namespace Goedel.Mesh.Server;



public static class ConsoleLoggerExtensions {

    public static IHostBuilder AddMeshService(this IHostBuilder host) {

        //host.ConfigureAppConfiguration((hostingContext, configuration) => {
        //});


        host.ConfigureServices((hostContext, services) => {
            services.AddSingleton<IConfiguredService, MeshConfiguredService>();
            var configurationService = services.Configure <MeshHostConfiguration> (
                hostContext.Configuration.GetSection("MeshService"));
        });

        return host;
        }
    }
public class MeshConfiguredService : IConfiguredService {

    public string Name => "MeshService";

    MeshHostConfiguration MeshHostConfiguration { get; }

    IOptionsMonitor<MeshHostConfiguration> MeshHostConfigurationMonitor;


    public MeshConfiguredService(
            ILogger<ConsoleHostedService> logger,
            IOptionsMonitor<MeshHostConfiguration> meshHostConfiguration
            ) {

        //IConfigurationRoot configurationRoot = configuration.Build();

        MeshHostConfigurationMonitor = meshHostConfiguration;
        MeshHostConfigurationMonitor.OnChange(
            config => Register(config));


        MeshHostConfiguration = meshHostConfiguration.CurrentValue;


        //var configurationHost = configuration.GetSection("Host");
        //configurationHost.Bind (meshHostConfiguration);

        //var configurationService = configuration.GetSection("MeshService");
        //configurationService.Bind(meshHostConfiguration);

        }

    void Register(MeshHostConfiguration meshHostConfiguration) {

        // the only thing we are going to be able to change with the service
        // running is the administrator list

        }


    public async Task StartServiceAsync() {

        await Task.Delay(50000);

        //throw new NotImplementedException();
        }
    }


public class MeshHostConfiguration : GenericServiceConfiguration {

    public string[] Administrators { get; set; } = Array.Empty<string>();

    }