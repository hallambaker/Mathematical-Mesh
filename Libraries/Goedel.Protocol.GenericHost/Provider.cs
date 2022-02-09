using System.Collections.Concurrent;
using System.Runtime.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Goedel.Protocol.GenericHost;


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