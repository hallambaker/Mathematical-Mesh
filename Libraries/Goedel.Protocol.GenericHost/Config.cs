using Goedel.Utilities;
using Microsoft.Extensions.Logging;

namespace Goedel.Protocol.GenericHost;
public class ConsoleLoggerConfiguration {
    public int EventId { get; set; }

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


public class DareLoggerConfiguration {

    ///<summary>List of recipients for which decryption blocks are to be created in the log.</summary> 
    public string[] Recipients { get; set; } = Array.Empty<string>();

    ///<summary>Log rotation period</summary> 
    public string Rotate { get; set; } = string.Empty;

    ///<summary>Directory to which log files are to be written</summary> 
    public string Path { get; set; } = "";

    }




public class GenericServiceConfiguration  {

    public string ServiceUdf { get; set; } = string.Empty;

    public string ServicePath { get; set; } = string.Empty;

    ///<summary>Service DNS addresses</summary> 
    public string[] ServiceDNS { get; set; } = Array.Empty<string>();

    }





