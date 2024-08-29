using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

namespace Goedel.Protocol.GenericHost;

/// <summary>
/// Extensions class.
/// </summary>
public static partial class ConsoleLoggerExtensions {

    /// <summary>
    /// Add a console logger to <paramref name="builder"/>
    /// </summary>
    /// <param name="builder"></param>
    /// <returns>The value of <paramref name="builder"/> for chaining.</returns>
    public static ILoggingBuilder AddDareLogger(
        this ILoggingBuilder builder) {
        builder.AddConfiguration();

        builder.Services.TryAddEnumerable(
            ServiceDescriptor.Singleton<ILoggerProvider, DareLoggerProvider>());

        LoggerProviderOptions.RegisterProviderOptions
            <DareLoggerConfiguration, DareLoggerProvider>(builder.Services);

        return builder;
        }

    /// <summary>
    /// Add a console logger to <paramref name="builder"/>
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="configure">The configure actions.</param>
    /// <returns>The value of <paramref name="builder"/> for chaining.</returns>
    public static ILoggingBuilder AddDareLogger(
        this ILoggingBuilder builder,
        Action<DareLoggerConfiguration> configure) {
        builder.AddConsoleLogger();
        builder.Services.Configure(configure);

        return builder;
        }
    }