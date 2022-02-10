using Goedel.Utilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.Runtime.Versioning;

namespace Goedel.Protocol.GenericHost;

#region // ConsoleLoggerProvider

/// <summary>
/// Console logger provider.
/// </summary>
[UnsupportedOSPlatform("browser")]
[ProviderAlias("Dare")]
public sealed class DareLoggerProvider : ILoggerProvider {
    private readonly IDisposable _onChangeToken;
    private DareLoggerConfiguration _currentConfig;
    private readonly ConcurrentDictionary<string, DareLogger> _loggers =
        new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Constructor returns instance via dependency injection.
    /// </summary>
    /// <param name="config">The console logger configuration.</param>
    public DareLoggerProvider(
        IOptionsMonitor<DareLoggerConfiguration> config) {
        _currentConfig = config.CurrentValue;
        _onChangeToken = config.OnChange(updatedConfig => _currentConfig = updatedConfig);
        }

    ///<inheritdoc/>
    public ILogger CreateLogger(string categoryName) =>
        _loggers.GetOrAdd(categoryName, name => new DareLogger(name, GetCurrentConfig));

    private DareLoggerConfiguration GetCurrentConfig() => _currentConfig;

    ///<inheritdoc/>
    public void Dispose() {
        _loggers.Clear();
        _onChangeToken.Dispose();
        }
    }
#endregion
#region // DareLoggerConfiguration


/// <summary>
/// The DARE file logger configuration.
/// </summary>
public class DareLoggerConfiguration {

    ///<summary>Return configuration entry description.</summary> 
    public readonly static ConfigurationEntry ConfigurationEntry =
        new("Dare", typeof(DareLoggerConfiguration));

    ///<summary>List of recipients for which decryption blocks are to be created in the log.</summary> 
    public List<string> Recipients { get; set; } = new List<string>();

    ///<summary>Log rotation period</summary> 
    public string Rotate { get; set; } = string.Empty;

    ///<summary>Directory to which log files are to be written</summary> 
    public string Path { get; set; } = "";

    public LogLevel LogLevel { get; set; } = LogLevel.Information;
    }

#endregion
#region MyRegion

/// <summary>
/// The console logger.
/// </summary>
public sealed class DareLogger : ILogger {
    private readonly string _name;
    private readonly Func<DareLoggerConfiguration> _getCurrentConfig;
    DareLoggerConfiguration config;

    /// <summary>
    /// Dependency injector constructor.
    /// </summary>
    /// <param name="name">The name of the logger.</param>
    /// <param name="getCurrentConfig">Return the current configuration.</param>
    public DareLogger(
        string name,
        Func<DareLoggerConfiguration> getCurrentConfig) {
        (_name, _getCurrentConfig) = (name, getCurrentConfig);
        config = _getCurrentConfig();
        }
    public static DareLogger Factory(string name, DareLoggerConfiguration? config = null) {
        config ??= new();
        return new DareLogger(name, function);

        DareLoggerConfiguration function() => config;

        }


    ///<inheritdoc/>
    public IDisposable BeginScope<TState>(TState state) => default!;

    ///<inheritdoc/> 
    public bool IsEnabled(LogLevel logLevel) => logLevel <= config.LogLevel;

    ///<summary>Return configuration entry description.</summary> 
    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter) {
        
        if (!IsEnabled(logLevel)) {
            return;
            }


        var builder = new StringBuilder();

        builder.AppendLine("{");
        builder.AppendLine($"    \"Event\" = \"{eventId.Name}\",");
        builder.AppendLine($"    \"LogLevel\" = \"{logLevel}\",");
        if (exception != null) {
            builder.AppendLine($"    \"Exception\" = \"{exception}\",");
            }
        if (state is IReadOnlyList<KeyValuePair<string, object>> list) {
            for (var i = 0; i < list.Count-1; i++) {
                builder.AppendLine($"    \"{list[i].Key}\" = \"{list[i].Value}\",");
                }
            }
        else {
            builder.AppendLine($"    \"Message\" = \"{formatter(state, exception)}\",");
            }
        builder.AppendLine($"    \"EventId\" = \"{eventId.Id}\"");
        builder.AppendLine("  }");

        Console.Write(builder.ToString());
        }
    }
#endregion


