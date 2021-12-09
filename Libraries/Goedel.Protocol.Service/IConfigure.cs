using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goedel.Protocol.Service;

/// <summary>
/// Service configuration
/// </summary>
public interface IServiceConfiguration {
    
    ///<summary>The IANA well known service name.</summary> 
    string WellKnown { get; }

    ///<summary>List of service addresses.</summary> 
    List<string> Addresses { get; }
    }

/// <summary>
/// Host configuration
/// </summary>
public interface IHostConfiguration {

    ///<summary>The console output mode</summary> 
    ReportMode ConsoleOutput { get; }

    ///<summary>Path to the host data store.</summary> 
    string Path { get; }

    ///<summary>The UDF of the sevice profile.</summary> 
    string ProfileUdf { get; }

    ///<summary>The UDF of the device profile.</summary> 
    string DeviceUdf { get; }

    ///<summary>The Host name.</summary> 
    string Id { get; }

    ///<summary>List of DNS addresses of the host.</summary> 
    List<string> DNS { get; }

    ///<summary>The port number.</summary> 
    int Port { get; }
    }