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
    public string Rotate { get; set; } = "";

    ///<summary>Directory to which log files are to be written</summary> 
    public string Path { get; set; } = "";

    }




public class GenericServiceConfiguration : GenericHostConfiguration {

    public string ServiceUdf { get; set; } = "";

    public string ServicePath { get; set; } = "";

    ///<summary>Service DNS addresses</summary> 
    public string[] ServiceDNS { get; set; } = Array.Empty<string>();

    }





/// <summary>
/// Service configuration
/// </summary>
public class GenericHostConfiguration {

    public string HostUdf { get; set; } = "";

    public string DeviceUdf { get; set; } = "";

    public string HostPath { get; set; } = "";

    ///<summary>Host DNS address</summary> 
    public string HostDns { get; set; } = null!;

    ///<summary>The IP address and port numbers</summary> 
    public string[] IP { get; set; } = Array.Empty<string>();
    }

