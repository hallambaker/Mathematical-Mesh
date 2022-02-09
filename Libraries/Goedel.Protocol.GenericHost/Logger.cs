using Microsoft.Extensions.Logging;

namespace Goedel.Protocol.GenericHost;

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