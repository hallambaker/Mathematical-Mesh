using Goedel.Discovery;
using Goedel.Mesh.Client;
using Goedel.Mesh.Core;

using Microsoft.Extensions.Logging;

using System.Net;

namespace Goedel.Mesh.ServiceAdmin;


/// <summary>
/// Static class containing convenience extensions.
/// </summary>
public static class Extensions {





    /// <summary>
    /// Build the service configuration described in <paramref name="configuration"/> on
    /// <paramref name="meshMachine"/>.
    /// </summary>
    /// <param name="meshMachine">The mesh machine supporting the host.</param>
    /// <param name="configuration">The service configuration.</param>
    /// <param name="admin">Administration account service address.</param>
    public static void BuildConfiguration(
                    this IMeshMachineClient meshMachine,
                    Configuration configuration,
                    string admin) {


        // first build the host profile and activate.


        // Phase 1: Create the Mesh Service
        using var service = PublicMeshService.Create(meshMachine,
            configuration.MeshService, configuration.GenericHost);

        // Mesh machine with captive direct mesh host.
        using var directMachine = new MeshMachineDirect(meshMachine, service);

        ProfileAccount profileRegistry = null;


        // Phase 2: create the administration account and add layered application admin controls.
        if (admin != null) {
            using var contextUser = service.AddAdministratorDirect(directMachine,
                admin, configuration.MeshService,
                configuration.DareLogger);

            if (configuration.CallsignRegistry != null) {
                using var contextRegistry = contextUser.CreateRegistry(
                        configuration.CallsignRegistry.ServiceAddress);
                profileRegistry = contextRegistry.ProfileRegistryCallsign;
                var envelope = contextRegistry.ProfileRegistryCallsign.DareEnvelope;
                configuration.MeshService.AddProfileRegistryCallsign(envelope);
                }

            if (configuration.CarnetService != null) {
                throw new NYI();
                //using var contextCarnet = contextUser.CreateRegistry(
                //        configuration.CarnetServiceConfiguration.AdminAccount);
                }

            // Must deregister the administration context or bad things will happen.
            meshMachine.MeshHost.Deregister(contextUser);
            }



        // Phase 3: Initialize the Mesh services
        if (configuration.CallsignResolver != null) {
            var resolver = PublicCallsignResolver.Create(directMachine, profileRegistry.GetEnvelopedProfileAccount(),
                    configuration.GenericHost, configuration.CallsignResolver, service.LogService);
            }
        if (configuration.CarnetService != null) {
            }
        if (configuration.RepositoryService != null) {
            }
        if (configuration.PresenceService != null) {
            }


        // At this point, all the services have been created on disk, none has been started.
        }

    /// <summary>
    /// Create a base service configuration file for use on <paramref name="meshMachine"/>.
    /// </summary>
    /// <param name="meshMachine">The mesh Machine on which the service is to run.</param>
    /// <param name="serviceDns">The service DNS address to use.</param>
    /// <param name="hostIp">The host IP addreess</param>
    /// <param name="hostDns">The host DNS address,</param>
    /// <param name="hostAccount">Optional host account.</param>
    /// <returns>The configuration created.</returns>
    public static Configuration CreateConfig(
                this IMeshMachineClient meshMachine,
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
            Description = $"New service configuration created on {DateTime.Now.ToRFC3339()}",
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
        var configuration = new Configuration();
        configuration.Add(hostConfiguration);
        configuration.Add(dareLogger);

        return configuration;
        }


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


        configuration.Add(serviceConfiguration);
        configuration.Add(presenceServiceConfiguration);
        configuration.Add(hostConfiguration);
        //configuration.Dictionary.Add("Logging", logging);

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
