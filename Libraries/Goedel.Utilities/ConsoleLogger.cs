using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;

// Crib: https://andrewlock.net/defining-custom-logging-messages-with-loggermessage-define-in-asp-net-core/

using System.Collections.Generic;
using System.Runtime.Versioning;

namespace Goedel.Utilities;


/// <summary>
/// A configuration entry for a service.
/// </summary>
/// <param name="Name">The name used to describe the configuration in the options file.</param>
/// <param name="Type">The type to which the configuration data is bound.</param>
/// <param name="Discovery">For a network service, specifies the DNS discovery prefix.</param>
/// <param name="WellKnown">For a network service, specifies the HTTP .well-known prefix</param>
public record struct ConfigurationEntry(
            string Name,
            Type Type,
            string? Discovery = null,
            string? WellKnown = null
            ) {



    }


#region // ConsoleLoggerProvider

/// <summary>
/// Console logger provider.
/// </summary>
[UnsupportedOSPlatform("browser")]
[ProviderAlias("Console")]
public sealed class ConsoleLoggerProvider : ILoggerProvider {
    private readonly IDisposable _onChangeToken;
    private ConsoleLoggerConfiguration _currentConfig;
    private readonly ConcurrentDictionary<string, ConsoleLogger> _loggers =
        new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Constructor returns instance via dependency injection.
    /// </summary>
    /// <param name="config">The console logger configuration.</param>
    public ConsoleLoggerProvider(
        IOptionsMonitor<ConsoleLoggerConfiguration> config) {
        _currentConfig = config.CurrentValue;
        _onChangeToken = config.OnChange(updatedConfig => _currentConfig = updatedConfig);
        }

    ///<inheritdoc/>
    public ILogger CreateLogger(string categoryName) =>
        _loggers.GetOrAdd(categoryName, name => new ConsoleLogger(name, GetCurrentConfig));

    private ConsoleLoggerConfiguration GetCurrentConfig() => _currentConfig;

    ///<inheritdoc/>
    public void Dispose() {
        _loggers.Clear();
        _onChangeToken.Dispose();
        }
    }
#endregion
#region // ConsoleLoggerConfiguration
/// <summary>
/// The console logger configuration.
/// </summary>
public class ConsoleLoggerConfiguration {


    ///<summary>Return configuration entry description.</summary> 
    public readonly static ConfigurationEntry ConfigurationEntry =
        new("Console", typeof(ConsoleLoggerConfiguration));

    ///<summary>The event to which this configuration applies.</summary> 
    public int EventId { get; set; }

    ///<summary>The default log level.</summary> 
    public LogLevel Default {get; set; }

    ///<summary>Specify log levels for specific log categories.</summary> 
    public Dictionary<string,string> LogLevel { get; set; }


    ///<summary>Dictionary specifying mapping of log levels to colors.</summary> 
    public Dictionary<LogLevel, ConsoleColor> LogLevels { get; set; } = new() {
        [Microsoft.Extensions.Logging.LogLevel.Trace] = ConsoleColor.Blue,
        [Microsoft.Extensions.Logging.LogLevel.Debug] = ConsoleColor.Cyan,
        [Microsoft.Extensions.Logging.LogLevel.Information] = ConsoleColor.Green,
        [Microsoft.Extensions.Logging.LogLevel.Warning] = ConsoleColor.Yellow,
        [Microsoft.Extensions.Logging.LogLevel.Error] = ConsoleColor.Red,
        [Microsoft.Extensions.Logging.LogLevel.Critical] = ConsoleColor.White,
        [Microsoft.Extensions.Logging.LogLevel.None] = ConsoleColor.White
        };

    }
#endregion


#region // ConsoleLogger
/// <summary>
/// The console logger.
/// </summary>
public sealed class ConsoleLogger : ILogger {
    private readonly string _name;
    private readonly Func<ConsoleLoggerConfiguration> _getCurrentConfig;




    /// <summary>
    /// Dependency injector constructor.
    /// </summary>
    /// <param name="name">The name of the logger.</param>
    /// <param name="getCurrentConfig">Return the current configuration.</param>
    public ConsoleLogger(
        string name,
        Func<ConsoleLoggerConfiguration> getCurrentConfig) =>
        (_name, _getCurrentConfig) = (name, getCurrentConfig);

    /// <summary>
    /// Factory method, return a new logger instance.
    /// </summary>
    /// <param name="name">The name of the instance (for configuration)</param>
    /// <param name="config">The configureation</param>
    /// <param name="logLevel">The minimum logging level to display.</param>
    /// <returns></returns>
    public static ConsoleLogger Factory(string name, 
            ConsoleLoggerConfiguration? config = null, LogLevel logLevel = LogLevel.Trace) {

        config ??= new() {
            Default = logLevel
            };
        return new ConsoleLogger(name, function);

        ConsoleLoggerConfiguration function() => config;

        }


    ///<inheritdoc/>
    public IDisposable BeginScope<TState>(TState state) => default!;

    ///<inheritdoc/> 
    public bool IsEnabled(LogLevel logLevel) => logLevel >= _getCurrentConfig().Default &
        _getCurrentConfig().LogLevels.ContainsKey(logLevel);

    ///<summary>Return configuration entry description.</summary> 
    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter) {


        var list = state as IReadOnlyList<KeyValuePair<string, object>>;

        if (!IsEnabled(logLevel)) {
            return;
            }

        var config = _getCurrentConfig();
        if (config.EventId == 0 || config.EventId == eventId.Id) {
            ConsoleColor originalColor = Console.ForegroundColor;

            Console.ForegroundColor = config.LogLevels[logLevel];
            Console.WriteLine($"[{eventId.Id,2}: {logLevel,-12}]");

            Console.ForegroundColor = originalColor;
            Console.Write($"     {_name} - ");

            Console.ForegroundColor = config.LogLevels[logLevel];
            Console.Write($"{formatter(state, exception)}");

            Console.ForegroundColor = originalColor;
            Console.WriteLine();
            }
        }
    } 
#endregion