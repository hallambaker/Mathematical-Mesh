using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Goedel.Protocol.Service;
using System.Text;
using Goedel.Mesh;
using Goedel.Utilities;
using Microsoft.Extensions.Options;

namespace Goedel.Protocol.GenericHost;



public class RudHostedService : IHostedService {
    private ILogger Logger { get; }
    private IHostApplicationLifetime AppLifetime { get; }
    //private List<ConfiguredService> ConfiguredServices { get; } = new List<ConfiguredService>();

    IEnumerable<IProvider> ConfigurableServices{ get; }

    RudService RudService { get; set; }
    //NewHostConfiguration HostConfiguration { get; }
    IMeshMachine MeshMachine { get; }

    IProviderHost ProviderHost { get; }
    public RudHostedService(
            ILogger<RudHostedService> logger,
            IMeshMachine meshMachine,
            IHostApplicationLifetime appLifetime,
            IEnumerable<IProvider> configurableServices,
            IProviderHost providerHost) {
        Logger = logger;
        AppLifetime = appLifetime;
        ConfigurableServices = configurableServices;
        MeshMachine = meshMachine;
        ProviderHost = providerHost;
        }

    //IConfigurableService GetConfigurableService(string name) {
    //    foreach (var configurableService in ConfigurableServices) {
    //        if (configurableService.Name.ToLower() == name.ToLower()) {
    //            return configurableService;
    //            }
    //        }
    //    return null!;
    //    }

    //NewHostConfiguration GetHostConfiguration() {

    //    var hostName = Environment.MachineName;
    //    if (ServiceAdminConfiguration.Hosts.TryGetValue(hostName, out var result)) {
    //        return result;
    //        }
    //    if (ServiceAdminConfiguration.Hosts.TryGetValue("", out result)) {
    //        return result;
    //        }

    //    return null!;
    //    }




    public Task StartAsync(CancellationToken cancellationToken) {

        var arguments = string.Join(" ", Environment.GetCommandLineArgs());
        Logger.LogDebug(Event.Starting.EventId, "Starting with arguments: {arguments}", arguments);


        AppLifetime.ApplicationStarted.Register(() => {
            Task.Run(async () => {
                try {
                    Logger.LogInformation(Event.HelloWorld.EventId, "Hello World!");

                    //var credential = hostConfiguration.GetCredential(MeshMachine);


                    await ProviderHost.StartAsync(cancellationToken, ConfigurableServices);



                    //var services = new Task [ConfigurableServices.Count()];
                    //var i = 0;
                    //foreach (var service in ConfigurableServices) {
                    //    services [i++] = service.StartServiceAsync();
                    //    }
                    //await Task.WhenAll (services);
                    }
                catch (Exception ex) {
                    Logger.LogError(Event.UnhandledException.EventId, ex, "Unhandled exception!");
                    }
                finally {
                    AppLifetime.StopApplication();
                    }
            });
        });

        return Task.CompletedTask;
        }

    public Task StopAsync(CancellationToken cancellationToken) {
        return Task.CompletedTask;
        }
    }