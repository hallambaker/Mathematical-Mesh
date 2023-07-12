using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
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
    private readonly IDisposable? _onChangeToken;
    private DareLoggerConfiguration _currentConfig;
    private readonly ConcurrentDictionary<string, DareLogger> _loggers =
        new(StringComparer.OrdinalIgnoreCase);
    

    Sequence? LogSequence { get; } = null;


    /// <summary>
    /// Constructor returns instance via dependency injection.
    /// </summary>
    /// <param name="config">The console logger configuration.</param>
    public DareLoggerProvider(
                IOptionsMonitor<DareLoggerConfiguration> config) {
        _currentConfig = config.CurrentValue;
        _onChangeToken = config.OnChange(updatedConfig => _currentConfig = updatedConfig);

        if (_currentConfig.Path != null && _currentConfig.Path != "") {
            Directory.CreateDirectory(_currentConfig.Path);
            var filename = Path.Join(_currentConfig.Path, "Log.dlog");

            // set the policy here...

            LogSequence = Sequence.Open(filename, IO.FileStatus.OpenOrCreate,
                sequenceType: SequenceType.Merkle, decrypt: false);

            }
        }

    ///<inheritdoc/>
    public ILogger CreateLogger(string categoryName) {
        if (LogSequence is not null) {
            return _loggers.GetOrAdd(categoryName, name => new DareLogger(name, GetCurrentConfig, LogSequence));
            }
        return NullLogger.Instance;
        }

    private DareLoggerConfiguration GetCurrentConfig() => _currentConfig;

    ///<inheritdoc/>
    public void Dispose() {
        _loggers.Clear();
        _onChangeToken?.Dispose();
        }
    }
#endregion
#region // DareLoggerConfiguration


/// <summary>
/// The DARE file logger configuration.
/// </summary>
public class DareLoggerConfiguration : IConfigurationEntry {

    ///<summary>Return configuration entry description.</summary> 
    public readonly static ConfigurationEntry ConfigurationEntry =
        new("Dare", typeof(DareLoggerConfiguration));

    ///<inheritdoc/>
    public ConfigurationEntry GetConfigurationEntry() => ConfigurationEntry;

    ///<summary>List of recipients for which decryption blocks are to be created in the log.</summary> 
    public List<string> Recipients { get; set; } = new ();

    ///<summary>Log rotation period</summary> 
    public string? Rotate { get; set; } = null;

    ///<summary>Directory to which log files are to be written</summary> 
    public string? Path { get; set; } = null;

    ///<summary>Logging level, only events of this level or less will be recorded.</summary> 
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

    Sequence LogSequence { get; }




    /// <summary>
    /// Dependency injector constructor.
    /// </summary>
    /// <param name="name">The name of the logger.</param>
    /// <param name="getCurrentConfig">Return the current configuration.</param>
    /// <param name="logSequence">The sequence to write the output to.</param>
    public DareLogger(
        string name,
        Func<DareLoggerConfiguration> getCurrentConfig,
        Sequence logSequence) {
        (_name, _getCurrentConfig) = (name, getCurrentConfig);
        config = _getCurrentConfig();
        LogSequence = logSequence;
        // open the sequence here.


       }
    //public static DareLogger Factory(
    //        string name, 
    //        DareLoggerConfiguration? config = null) {
    //    config ??= new();
    //    return new DareLogger(name, function);

    //    DareLoggerConfiguration function() => config;

    //    }


    ///<inheritdoc/>
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull {
        return null;
        }

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

        //Console.Write(builder.ToString());

        var bytes = builder.ToString().ToUTF8();
        //LogSequence.Append(bytes);

        }
    }
#endregion


