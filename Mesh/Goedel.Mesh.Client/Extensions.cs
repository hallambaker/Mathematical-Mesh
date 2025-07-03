#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


using Goedel.Discovery;

namespace Goedel.Mesh.Client;

/// <summary>
/// Extensions class containing static extension methods
/// </summary>
/// 
public static partial class Extensions {







    ///<summary>Extension for hosts and services configuration files.</summary> 
    public const string ConfigurationFileExtension = ".json";

    static string GetFilePath(
            this IMeshMachineClient meshMachine,
            string fileSpec,
            string type) {
        var defaulted = fileSpec.ApplyExtensionDefault(ConfigurationFileExtension);

        if (Path.IsPathRooted(fileSpec) | Path.HasExtension(fileSpec)) {
            return defaulted;
            }
        return Path.Combine(meshMachine.DirectoryMesh, type, defaulted);


        }

    /// <summary>
    /// Return the file path for the service description <paramref name="fileSpec"/>.
    /// <para>If <paramref name="fileSpec"/> contains no file path specifier, it is
    /// interpreted as a named service description to be stored in the location 
    /// specified by <paramref name="meshMachine"/>. Otherwise, the specified file
    /// path is used.
    /// </para>
    /// </summary>
    /// <param name="meshMachine">The Mesh machine specification (used to determine
    /// the location of system configuration files).</param>
    /// <param name="defaultConfiguration">Default name for the configuration file
    /// for this service.</param>
    /// <param name="fileSpec">The service description specifier.</param>
    /// <returns>The file path.</returns>
    public static string GetService(
            this IMeshMachineClient meshMachine,
            string defaultConfiguration = null,
            string fileSpec = null) => GetFilePath(
                meshMachine, fileSpec ?? defaultConfiguration, "Service");

    /// <summary>
    /// Initialize a base service configuration file for use on <paramref name="meshMachine"/>.
    /// </summary>
    /// <param name="meshMachine">The mesh Machine on which the service is to run.</param>
    /// <param name="configuration">The configuration to initialize.</param>
    /// <param name="serviceDns">The service DNS address to use.</param>
    /// <param name="hostIp">The host IP addreess</param>
    /// <param name="hostDns">The host DNS address,</param>
    /// <param name="hostAccount">Optional host account.</param>
    /// <returns>The configuration created.</returns>
    public static void Initialize(
                this IServiceConfiguration configuration,
                IMeshMachineClient meshMachine,
                string serviceDns,
                string hostIp = null,
                string hostDns = null,
                string? hostAccount = null
                ) {

        hostDns ??= Dns.GetHostName();
        hostDns ??= serviceDns;

        var localEndPoints = HostNetwork.GetLocalEndpoints();
        var ip = new List<string>();

        if (hostIp is null) {
            foreach (var localEndpoint in localEndPoints) {
                ip.Add(localEndpoint.ToString());
                }
            }
        else {
            ip.Add(hostIp);
            }

        var pathHost = GetHost(meshMachine, hostDns);
        var pathLog = GetHost(meshMachine, "Logs");


        var hostConfiguration = new GenericHostConfiguration {
            // HostUdf later
            // DeviceUdf later
            Description = $"New service configuration created on {DateTime.UtcNow.ToRFC3339()}",
            HostDns = hostDns,
            IP = ip,
            RunAs = hostAccount,
            HostPath = pathHost
            };

        var dareLogger = new DareLoggerConfiguration {
            Path = pathLog,
            };
        var consoleLogger = new ConsoleLoggerConfiguration {
            Default = LogLevel.Trace
            };

        var logging = new Dictionary<string, object> {
                { "Default", "Trace" },
                { "Dare", dareLogger },
                { "Console", consoleLogger },
            };


        // Create the initial service application
        //var configuration = new Configuration();
        configuration.Add(hostConfiguration);
        configuration.Add(dareLogger);
        }

    
    /// <summary>
    /// Return the file path for the service specified <paramref name="hostname"/>. The
    /// host description is always stored in a location determined by 
    /// <paramref name="meshMachine"/>.
    /// </summary>
    /// <param name="meshMachine">The Mesh machine specification (used to determine
    /// the location of system configuration files).</param>
    /// <param name="hostname">The host name.</param>
    /// <returns>The file path.</returns>
    public static string GetHost(
        IMeshMachineClient meshMachine, string hostname) =>
        Path.Combine(meshMachine.DirectoryMesh, "Hosts", hostname);

    }