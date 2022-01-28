using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Goedel.Protocol.GenericHost;



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


    public static readonly FatEvent Starting = 
        new(LogLevel.Information, 1, Resources.HelloWorld, "Starting with arguments: {arguments}");
    public static readonly FatEvent HelloWorld = new(LogLevel.Information, 2, 
        "Hello World!");


    public static readonly FatEvent UnhandledException = new(LogLevel.Error, 1000, 
        "Unhandled Exception");








    }
