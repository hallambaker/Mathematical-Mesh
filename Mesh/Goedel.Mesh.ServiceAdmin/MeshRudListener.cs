using Goedel.Protocol.GenericHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Goedel.Protocol.Presentation;
using Goedel.Mesh;
using Goedel.Protocol.Service;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Goedel.Mesh.ServiceAdmin;

/// <summary>
/// Dependency injection wrapper that 
/// </summary>
public class MeshRudListener : IServiceListener {

    public GenericHostConfiguration GenericHostConfiguration { get; }

    public RudService RudService { get; set; }

    ICredentialPrivate Credential { get; set; }

    IMeshMachine MeshMachine { get; }

    private IEnumerable<IConfguredService> ConfiguredServices { get; }

    public MeshRudListener(
                IOptionsMonitor<GenericHostConfiguration> genericHostConfiguration,
                IEnumerable<IConfguredService> configuredServices,
                IMeshMachine meshMachine) {
        //var credential = MeshMachine.GetCredential();


        //RudService = new RudService(cancellationToken, ConfigurableServices,
        //    null, null);
        GenericHostConfiguration = genericHostConfiguration.CurrentValue;
        MeshMachine = meshMachine;
        ConfiguredServices = configuredServices;

        Screen.WriteLine($"Configure Listener");

        Credential = MeshMachine.GetCredential(
                GenericHostConfiguration.DeviceUdf,
                GenericHostConfiguration.HostUdf);

        RudService = new RudService(
                ConfiguredServices, Credential,
                maxCores: GenericHostConfiguration.MaxCores);
        }



    ///<inheritdoc/>
    public async Task StartAsync(
            CancellationToken cancellationToken) {

        Credential = MeshMachine.GetCredential(
                GenericHostConfiguration.DeviceUdf,
                GenericHostConfiguration.HostUdf);

        // create http endpoints here...


        Screen.WriteLine($"Start Listener");



        await RudService.WaitServiceAsync();


        Screen.WriteLine($"Stop Listener");
        }

    }
