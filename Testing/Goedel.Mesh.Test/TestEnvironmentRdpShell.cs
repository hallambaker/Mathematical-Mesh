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

using Goedel.Callsign;
using Goedel.Callsign.Resolver;
using Goedel.Carnet.Server;
using Goedel.Mesh.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Goedel.Mesh.Test;

public class TestEnvironmentRdpShell : TestEnvironmentBase {



    public const string ServiceDnsMesh          = "example.com";
    public const string ServiceDnsRegistry      = "registry.example.com";
    public const string ServiceDnsCallsign      = "example.com";
    public const string ServiceDnsPresence      = "example.com";
    public const string ServiceDnsRepository    = "example.com";
    public const string ServiceDnsCarnet        = "example.com";

    public const string ServiceIpMesh           = "127.0.0.1:15099";
    public const string ServiceIpRegistry       = "127.0.0.1:15098";
    public const string ServiceIpCallsign       = "127.0.0.1:15097";
    public const string ServiceIpPresence       = "127.0.0.1:15096";
    public const string ServiceIpRepository     = "127.0.0.1:15095";
    public const string ServiceIpCarnet         = "127.0.0.1:15094";

    public MeshMachineTest HostMachineMesh { get; set; }

    public MeshMachineTest HostMachineRegistry { get; set; }


    public MeshMachineTest HostMachinePresence { get; set; }



    Goedel.Mesh.Shell.ServiceAdmin.Shell ServiceAdminShell { get; set; }

    Goedel.Mesh.Shell.ServiceAdmin.Shell ServiceAdminShellCallSign { get; set; }


    Goedel.Mesh.Shell.ServiceAdmin.CommandLineInterpreter ServiceAdminCLI { get; set; }


    //public override string ServiceDns { get; }

    public TestEnvironmentRdpShell(DeterministicSeed seed = null) : base(seed) { 
        }


    public bool InitializeResolver {get; init;} = false;

    public bool InitializeCarnet { get; init; } = false;


    RudService RudService { get; set; }
    RudService RudServiceCallSign { get; set; }



    IEnumerable<IConfguredService> Providers;
    IEnumerable<IConfguredService> Providers1;


    protected override PublicCallsignResolver GetCallsignResolver() => GetService<PublicCallsignResolver>();

    protected override CarnetServer GetCarnetServer() => GetService<CarnetServer>();



    T GetService<T>() {
        foreach (var provider in Providers) {
            if (provider.JpcInterface is T resolver) {
                return resolver;
                }
            }
        throw new NYI();
        }


    protected override void Disposing() {
        RudService?.Dispose();
        HostMachineMesh?.Dispose();

        RudServiceCallSign?.Dispose();
        HostMachineRegistry?.Dispose();

        ServiceAdminShell?.MeshMachine?.MeshHost?.Dispose();

        if (Providers != null) {
            foreach (var provider in Providers) {
                provider.Dispose();
                }
            }
        if (Providers1 != null) {
            foreach (var provider in Providers1) {
                provider.Dispose();
                }
            }
        base.Disposing();
        }


    //CancellationToken CancellationToken;

    public IHostBuilder DependencyInjectionHostMesh(MeshMachineTest hostMachine) {

        var settings = PublicMeshService.GetService(hostMachine);

        //var builder = Host.CreateDefaultBuilder();
        //var config = builder.ConfigureAppConfiguration((hostingContext, configuration) => {
        //            configuration.Sources.Clear();
        //            IHostEnvironment env = hostingContext.HostingEnvironment;
        //            configuration.AddJsonFile(settings, true, true);
        //        });



        return Host.CreateDefaultBuilder()

                // read in the options file here.
                .ConfigureAppConfiguration((hostingContext, configuration) => {
                    configuration.Sources.Clear();
                    IHostEnvironment env = hostingContext.HostingEnvironment;
                    configuration.AddJsonFile(settings, true, true);
                })
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                    logging.AddConsoleLogger();
                })
                .ConfigureServices((hostContext, services) => {
                    services.AddSingleton<HostMonitor, HostMonitor>();
                    services.AddSingleton<IServiceListener, MeshRudListener>();
                    services.AddSingleton<IMeshMachine, MeshMachineCore>(s => hostMachine);
                });

        }


    public override void StartService() {
        var dnsConfig = "db.meshService";
        var netshConfig = "Service.netsh";

        //CancellationToken = new();


        HostMachineMesh = new MeshMachineTest(this, "hostMesh");




        // initialize the service and host configuration
        ServiceAdminShell = new Shell.ServiceAdmin.Shell() {
            MeshMachine = HostMachineMesh
            };
        ServiceAdminCLI = new();

        var createCommand = $"create {ServiceDnsMesh} /host=host1.{ServiceDnsMesh} " +
            $"/ip={ServiceIpMesh} /admin=admin@{ServiceDnsMesh} /account=Domain\\user";
        if (InitializeResolver) {
            createCommand += $"/resolver /registry={AccountRegistry}";
            }
        if (InitializeCarnet) {
            }

        ServiceAdmin(ServiceAdminShell, createCommand);

        ServiceAdmin(ServiceAdminShell, $"dns {dnsConfig}");
        ServiceAdmin(ServiceAdminShell, $"netsh {netshConfig}");
        var hostbuilder = DependencyInjectionHostMesh(HostMachineMesh);

        using var host = hostbuilder.
            AddGenericHost().
            AddMeshService().
            AddResolverService().Build();




        var services = host.Services;
        var listener = services.GetRequiredService<IServiceListener>() as MeshRudListener;
        Providers = services.GetServices<IConfguredService>();

        RudService = listener.RudService;

        foreach (var provider in Providers) {
            provider.JpcInterface.Initialize(Providers);
            }



        }

    MeshConfiguredService MeshConfiguredService { get; set; }
    public PublicMeshService GetMeshService() {
        foreach (var provider in Providers) {
            if (provider.JpcInterface is PublicMeshService publicMeshService) {
                MeshConfiguredService = provider as MeshConfiguredService;
                return publicMeshService;
                }
            }

        return null;
        }




    public override MeshServiceClient GetMeshClient(
            MeshMachineTest meshMachineTest,
            ICredentialPrivate credential,
             string accountAddress
           ) {

        if (RudService == null) {
            StartService();
            }

        var meshServiceBinding = new ConnectionInitiator(
                credential, ServiceDns, Test, TransportType.Http, MeshServiceClient.WellKnown);
        var client = meshServiceBinding.GetClient<MeshServiceClient>(credential, accountAddress);


        return client;
        }

    public void ServiceAdmin(Shell.ServiceAdmin.Shell shell, string command) {

        var args = command.Split(" ");
        ServiceAdminCLI.MainMethod(shell, args);
        }


    }
