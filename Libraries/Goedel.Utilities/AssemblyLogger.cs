using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Utilities;

/// <summary>
/// Caching logger class. C
/// </summary>
public class AssemblyLogger : ILogger {
    
    ///<summary>Category name used for filtering logs</summary> 
    string CategoryName { get; }
    
    ///<summary>The default log level</summary> 
    public LogLevel LogLevel { get; set; }

    ///<summary>Get or set the cached logger delegate.</summary> 
    public ILogger CachedLogger {
        get => cachedLogger ?? GetLogger().CacheValue(out cachedLogger);
        set => cachedLogger = value;
        }
    ILogger cachedLogger;

    /// <summary>
    /// Constructor returning a new logger instance. Note that the loger
    /// itself is not created unless needed.
    /// </summary>
    /// <param name="categoryName">Category name used for filtering logs</param>
    public AssemblyLogger(string? categoryName=null) {
        CategoryName = categoryName ?? Assembly.GetCallingAssembly().FullName;
        }

    ILogger GetLogger() {
        return ConsoleLogger.Factory(CategoryName, logLevel: LogLevel);
        }

    #region // Implement ILogger interface

    ///<inheritdoc/>
    public IDisposable BeginScope<TState>(TState state) => cachedLogger.BeginScope(state);

    ///<inheritdoc/>
    public bool IsEnabled(LogLevel logLevel) => CachedLogger.IsEnabled(logLevel);

    ///<inheritdoc/>
    public void Log<TState>(
            LogLevel logLevel, 
            EventId eventId, 
            TState state, 
            Exception exception, 
            Func<TState, Exception, string> formatter) =>
        CachedLogger?.Log(logLevel, eventId, state, exception, formatter);

    #endregion
    #region // Utility routines




    #endregion

    }
