using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Goedel.Protocol.Service;


/// <summary>
/// Structure describing a complete event.
/// </summary>
public readonly struct FatEvent {

    ///<summary>The log level for the event.</summary> 
    public LogLevel LogLevel { get; }

    ///<summary>The event identifier (should be unique for a given application)</summary> 
    public EventId EventId { get; }

    ///<summary>The event message.</summary> 
    public string? Message { get; }

    /// <summary>
    /// Constructor returning an instance.
    /// </summary>
    /// <param name="logLevel">The log level for the event.</param>
    /// <param name="id">The event identifier (should be unique for a given application)</param>
    /// <param name="name">The event name (written to the log)</param>
    /// <param name="message">The event message.</param>
    public FatEvent(LogLevel logLevel, int id, string name, string? message=null) {
        LogLevel = logLevel;
        EventId = new EventId(id, name);
        Message = message ?? name;
        }


    }


/// <summary>
/// Extension class to make loggin an event straightforward.
/// </summary>
public static class Extensions {

    /// <summary>
    /// Log an event.
    /// </summary>
    /// <param name="logger">The event logger.</param>
    /// <param name="logEvent">The event to log.</param>
    /// <param name="args">The event arguments.</param>
    public static void Log(this ILogger logger, FatEvent logEvent, params object[] args) {

        switch (logEvent.LogLevel) {

            case LogLevel.Trace: {
                    logger.LogTrace(logEvent.EventId, logEvent.Message, args);
                    break;
                    }
            case LogLevel.Debug: {
                    logger.LogDebug(logEvent.EventId, logEvent.Message, args);
                    break;
                    }
            case LogLevel.Information: {
                    logger.LogInformation(logEvent.EventId, logEvent.Message, args);
                    break;
                    }
            case LogLevel.Warning: {
                    logger.LogWarning(logEvent.EventId, logEvent.Message, args);
                    break;
                    }
            case LogLevel.Error: {
                    logger.LogError(logEvent.EventId, logEvent.Message, args);
                    break;
                    }
            case LogLevel.Critical: {
                    logger.LogCritical(logEvent.EventId, logEvent.Message, args);
                    break;
                    }
            }
        }

    /// <summary>
    /// Log an event.
    /// </summary>
    /// <param name="logger">The event logger.</param>
    /// <param name="logEvent">The event to log.</param>
    /// <param name="args">The event arguments.</param>
    /// <param name="exception">Exception returned.</param>
    public static void Log(this ILogger logger, Exception exception, FatEvent logEvent, params object[] args) {

        switch (logEvent.LogLevel) {

            case LogLevel.Trace: {
                    logger.LogTrace(logEvent.EventId, logEvent.Message, args);
                    break;
                    }
            case LogLevel.Debug: {
                    logger.LogDebug(logEvent.EventId, logEvent.Message, args);
                    break;
                    }
            case LogLevel.Information: {
                    logger.LogInformation(logEvent.EventId, logEvent.Message, args);
                    break;
                    }
            case LogLevel.Warning: {
                    logger.LogWarning(logEvent.EventId, logEvent.Message, args);
                    break;
                    }
            case LogLevel.Error: {
                    logger.LogError(logEvent.EventId, logEvent.Message, args);
                    break;
                    }
            case LogLevel.Critical: {
                    logger.LogCritical(logEvent.EventId, logEvent.Message, args);
                    break;
                    }
            }
        }
    }


/// <summary>
/// Logging events for the Goedel Host.
/// </summary>
public static class Event {




    //private static readonly Action<ILogger, Exception> indexPageRequested;

    //static Event() {

    //    indexPageRequested = LoggerMessage.Define(
    //        LogLevel.Information,
    //        new EventId(1, nameof(IndexPageRequested)),
    //        "GET request for Index page");
    //        }

    ///// <summary>
    ///// Write an event of type #{event.Name} to the <paramref name="logger"/>
    ///// </summary>
    ///// <param name="logger"></param>
    //public static void IndexPageRequested(this ILogger logger) {
    //    indexPageRequested(logger, null);
    //    }












    /////<summary>Starting listener</summary> 
    //public static readonly FatEvent StartListener = 
    //    new(LogLevel.Information, 1, Resources.StartListener, "Starting listener");

    /////<summary>Ending listener</summary> 
    //public static readonly FatEvent EndListener =
    //    new(LogLevel.Information, 2, Resources.EndListener, "Ending listener");

    /////<summary>Starting service</summary> 
    //public static readonly FatEvent StartService =
    //    new(LogLevel.Information, 3, Resources.StartService, "Starting service {ServiceName}");

    /////<summary>Ending service</summary> 
    //public static readonly FatEvent EndService =
    //    new(LogLevel.Information, 4, Resources.EndService, "Ending service {ServiceName}");

    /////<summary>Starting transation</summary> 
    //public static readonly FatEvent StartTransaction =
    //    new(LogLevel.Trace, 5, Resources.StartTransaction, "Starting transation {TransactionId} {TransactionMethod}");

    /////<summary>Completed transation</summary> 
    //public static readonly FatEvent EndTransaction =
    //    new(LogLevel.Information, 6, Resources.EndTransaction, "Completed transation {TransactionId} {TransactionMethod}");

    /////<summary>Completed transation</summary> 
    //public static readonly FatEvent FailTransaction =
    //    new(LogLevel.Information, 7, Resources.FailTransaction, "Failed transation {TransactionId} {TransactionMethod}");

    ///////<summary>Hello World</summary> 
    ////public static readonly FatEvent HelloWorld = new(LogLevel.Information, 2,
    ////    Resources.StartTransaction, "Hello World!");

    /////<summary>Unhandled Exception</summary> 
    //public static readonly FatEvent UnhandledException = new(LogLevel.Error, 1000,
    //    Resources.UnhandledException, "Unhandled Exception");


    /////<summary>Unhandled Exception</summary> 
    //public static readonly FatEvent CommandNotSupported = new(LogLevel.Error, 1001,
    //    Resources.CommandNotSupported, "Command not supported");

    /////<summary>Unhandled Exception</summary> 
    //public static readonly FatEvent UnknownCommand = new(LogLevel.Error, 1002,
    //    Resources.UnknownCommand, "Command unknown");




    }
