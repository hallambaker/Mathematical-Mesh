using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Goedel.Protocol.Service;



public readonly struct FatEvent {

    public LogLevel LogLevel { get; }

    public EventId EventId { get; }

    public string? Message { get; }


    public FatEvent(LogLevel logLevel, int id, string name, string? message=null) {
        LogLevel = logLevel;
        EventId = new EventId(id, name);
        Message = message ?? name;
        }


    }

#pragma warning disable CA2254 // Template should be a static expression
public static class Extensions {

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
    }
#pragma warning restore CA2254 // Template should be a static expression

public static class Event {


    public static readonly FatEvent StartListener = 
        new(LogLevel.Information, 1, Resources.StartListener, "Starting listener");

    public static readonly FatEvent EndListener =
        new(LogLevel.Information, 1, Resources.EndListener, "Ending listener");

    public static readonly FatEvent StartService =
        new(LogLevel.Information, 1, Resources.StartListener, "Starting service {ServiceName}");

    public static readonly FatEvent EndService =
        new(LogLevel.Information, 1, Resources.EndService, "Ending service {ServiceName}");

    public static readonly FatEvent StartTransaction =
        new(LogLevel.Trace, 1, Resources.StartTransaction, "Starting transation {TransactionId} {TransactionMethod}");

    public static readonly FatEvent EndTransaction =
        new(LogLevel.Information, 1, Resources.EndTransaction, "Completed transation {TransactionId} {TransactionMethod}");


    public static readonly FatEvent HelloWorld = new(LogLevel.Information, 2, 
        "Hello World!");

    public static readonly FatEvent UnhandledException = new(LogLevel.Error, 1000, 
        "Unhandled Exception");








    }
