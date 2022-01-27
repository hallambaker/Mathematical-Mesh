using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Configuration;

namespace Goedel.Protocol.GenericHost;

public static class ConsoleLoggerExtensions {

    public static IHostBuilder AddConsoleHosted(this IHostBuilder host) {

        //host.ConfigureAppConfiguration((hostingContext, configuration) => {
        //    //configuration.Sources.Clear();

        //    //IHostEnvironment env = hostingContext.HostingEnvironment;

        //    //configuration
        //    //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //    //    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

        //    //IConfigurationRoot configurationRoot = configuration.Build();

        //    //GenericServiceConfiguration options = new();
        //    //configurationRoot.GetSection("Host")
        //    //                 .Bind(options);
        //});


        host.ConfigureServices((hostContext, services) => {
            services.AddSingleton<IHostedService, RudHostedService>();
        });

        return host;
        }



    public static ILoggingBuilder AddConsoleLogger(
        this ILoggingBuilder builder) {
        builder.AddConfiguration();

        builder.Services.TryAddEnumerable(
            ServiceDescriptor.Singleton<ILoggerProvider, ConsoleLoggerProvider>());

        LoggerProviderOptions.RegisterProviderOptions
            <ConsoleLoggerConfiguration, ConsoleLoggerProvider>(builder.Services);

        return builder;
        }

    public static ILoggingBuilder AddConsoleLogger(
        this ILoggingBuilder builder,
        Action<ConsoleLoggerConfiguration> configure) {
        builder.AddConsoleLogger();
        builder.Services.Configure(configure);

        return builder;
        }
    }