using Goedel.Utilities;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace Goedel.Protocol.GenericHost;

/// <summary>
/// Extensions class.
/// </summary>
public static partial class ConsoleLoggerExtensions {

    /// <summary>
    /// Add a hosted console logger.
    /// </summary>
    /// <param name="builder">The host builder</param>
    /// <returns>The value of <paramref name="builder"/> for chaining.</returns>
    public static IHostBuilder AddListenerHosted(this IHostBuilder builder) {

        builder.ConfigureServices((hostContext, services) => {
            services.AddSingleton<IHostedService, ManagedListener>();
        });

        return builder;
        }


    /// <summary>
    /// Add a console logger to <paramref name="builder"/>
    /// </summary>
    /// <param name="builder"></param>
    /// <returns>The value of <paramref name="builder"/> for chaining.</returns>
    public static ILoggingBuilder AddConsoleLogger(
        this ILoggingBuilder builder) {
        builder.AddConfiguration();

        builder.Services.TryAddEnumerable(
            ServiceDescriptor.Singleton<ILoggerProvider, ConsoleLoggerProvider>());

        LoggerProviderOptions.RegisterProviderOptions
            <ConsoleLoggerConfiguration, ConsoleLoggerProvider>(builder.Services);

        return builder;
        }

    /// <summary>
    /// Add a console logger to <paramref name="builder"/>
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="configure">The configure actions.</param>
    /// <returns>The value of <paramref name="builder"/> for chaining.</returns>
    public static ILoggingBuilder AddConsoleLogger(
        this ILoggingBuilder builder,
        Action<ConsoleLoggerConfiguration> configure) {

        builder.AddConsoleLogger();
        builder.Services.Configure(configure);

        return builder;
        }
    }