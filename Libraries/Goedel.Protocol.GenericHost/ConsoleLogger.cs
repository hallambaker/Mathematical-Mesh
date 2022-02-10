using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;

// Crib: https://andrewlock.net/defining-custom-logging-messages-with-loggermessage-define-in-asp-net-core/

using System.Collections.Generic;
using System.Runtime.Versioning;

namespace Goedel.Protocol.GenericHost;

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

    ///<summary>Dictionary specifying mapping of log levels to colors.</summary> 
    public Dictionary<LogLevel, ConsoleColor> LogLevels { get; set; } = new() {
        [LogLevel.Trace] = ConsoleColor.DarkBlue,
        [LogLevel.Debug] = ConsoleColor.Blue,
        [LogLevel.Information] = ConsoleColor.Green,
        [LogLevel.Warning] = ConsoleColor.Yellow,
        [LogLevel.Error] = ConsoleColor.Red,
        [LogLevel.Critical] = ConsoleColor.White,
        [LogLevel.None] = ConsoleColor.White
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

    public static ConsoleLogger Factory(string name, ConsoleLoggerConfiguration? config = null) {
        config ??= new ();
        return new ConsoleLogger(name, function);

        ConsoleLoggerConfiguration function() => config;

        }


    ///<inheritdoc/>
    public IDisposable BeginScope<TState>(TState state) => default!;

    ///<inheritdoc/> 
    public bool IsEnabled(LogLevel logLevel) =>
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