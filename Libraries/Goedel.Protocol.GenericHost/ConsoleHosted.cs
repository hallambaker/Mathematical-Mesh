using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goedel.Utilities;
using Microsoft.Extensions.Options;

namespace Goedel.Protocol.GenericHost;



public class ConsoleHostedService : IHostedService {
    private ILogger Logger { get; }
    private IHostApplicationLifetime AppLifetime { get; }
    //private List<ConfiguredService> ConfiguredServices { get; } = new List<ConfiguredService>();

    IEnumerable<IConfiguredService> ConfigurableServices{ get; }


    //NewHostConfiguration HostConfiguration { get; }

    public ConsoleHostedService(
            ILogger<ConsoleHostedService> logger,
            IHostApplicationLifetime appLifetime,
            IEnumerable<IConfiguredService> configurableServices) {
        Logger = logger;
        AppLifetime = appLifetime;
        ConfigurableServices = configurableServices;

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

                    var services = new Task [ConfigurableServices.Count()];
                    var i = 0;
                    foreach (var service in ConfigurableServices) {
                        services [i++] = service.StartServiceAsync();
                        }
                    await Task.WhenAll (services);
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