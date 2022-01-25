using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Goedel.Protocol.GenericHost;



public readonly struct FatEvent {

    public LogLevel LogLevel { get; }

    public EventId EventId { get; }



    public FatEvent(LogLevel logLevel, int id, string name) {
        LogLevel = logLevel;
        EventId = new EventId(id, name);

        }


    }




public static class Event {


    public static readonly FatEvent Starting = new(LogLevel.Information, 1, Resources.HelloWorld);
    public static readonly FatEvent HelloWorld = new(LogLevel.Information, 2, "Hello World!");


    public static readonly FatEvent UnhandledException = new(LogLevel.Error, 1000, "Unhandled Exception");



    public static void Log (this ILogger logger, FatEvent fatEvent) {


        //return logger.Log(fatEvent.LogLevel, fatEvent.EventId, typeof(TState), exception, formatter);
        }


    }
