using Goedel.Mesh.Client;
using Goedel.Protocol.GenericHost;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Goedel.Discovery;

namespace Goedel.Mesh.ServiceAdmin;


/// <summary>
/// Static class containing convenience extensions.
/// </summary>
public static class Extensions {


    /// <summary>
    /// Create a new Mesh Service
    /// </summary>
    /// <param name="meshMachine">The Mesh Machine</param>
    /// <param name="serviceConfig">The service configuration file.</param>
    /// <param name="serviceDns">The canonical DNS name of the service</param>
    /// <param name="hostIp">The host IP address</param>
    /// <param name="hostDns">The host DNS name</param>
    /// <param name="admin">The administrative account to create.</param>
    /// <param name="hostAccount">The platform account under which the host process is to run.</param>
    /// <returns>The created service</returns>
    public static Configuration CreatePublicMeshService(
        this IMeshMachineClient meshMachine,
        string serviceConfig,
        string serviceDns,
        string hostIp = null,
        string hostDns = null,
        string admin = null,
        string? hostAccount = null) {

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

        // Create the initial service application
        var configuration = new Configuration();


        var serviceConfiguration = new MeshServiceConfiguration {
            // ServiceUdf later
            // Administrators later
            ServiceDNS = new List<string> { serviceDns },
            ServicePath = meshMachine.DirectoryMesh,
            HostPath = pathHost
            };

        var presenceServiceConfiguration = new PresenceServiceConfiguration {
            };





        var hostConfiguration = new GenericHostConfiguration {
            // HostUdf later
            // DeviceUdf later
            Description = $"New service configuration created on {DateTime.Now.ToRFC3339()}",
            HostDns = hostDns,
            IP = ip,
            RunAs = hostAccount
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


        configuration.Add(MeshServiceConfiguration.ConfigurationEntry, serviceConfiguration);
        configuration.Add(PresenceServiceConfiguration.ConfigurationEntry, presenceServiceConfiguration);
        configuration.Add(GenericHostConfiguration.ConfigurationEntry, hostConfiguration);
        configuration.Dictionary.Add("Logging", logging);

        // create the service. This will populate the UDF fields.
        using var service = PublicMeshService.Create(meshMachine, serviceConfiguration, hostConfiguration);

        if (admin != null) {
            ContextUser contextUser = service.AddAdministrator(meshMachine, 
                admin, serviceConfiguration, dareLogger);
            }

        // Write the configuration out to the file
        serviceConfig.MakePath();
        configuration.ToFile(serviceConfig);

        return configuration;
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
