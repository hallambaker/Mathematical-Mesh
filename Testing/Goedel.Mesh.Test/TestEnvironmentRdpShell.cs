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

using System.Net;

namespace Goedel.Mesh.Test;

public class TestEnvironmentRdpShell : TestEnvironmentBase {
    MeshMachineTest HostMachine { get; set; }
    Goedel.Mesh.Shell.ServiceAdmin.Shell ServiceAdminShell { get; set; }
    Goedel.Mesh.Shell.ServiceAdmin.CommandLineInterpreter ServiceAdminCLI { get; set; }


    //public override string ServiceDns { get; }

    public TestEnvironmentRdpShell() { }
    //=> ServiceDns = "localhost";

    RudService RudService { get; set; }

    IEnumerable<IConfguredService> Providers;
    protected override void Disposing() {
        RudService?.Dispose();
        HostMachine?.Dispose();
        ServiceAdminShell?.MeshMachine?.MeshHost?.Dispose();

        if (Providers != null) {
            foreach (var provider in Providers) {
                provider.Dispose();
                }
            }

        base.Disposing();
        }


    //CancellationToken CancellationToken;

    public MeshRudListener DependencyInjectionHostAsync() {

        var settings = PublicMeshService.GetService(HostMachine);

        using var host = Host.CreateDefaultBuilder()

                // read in the options file here.
                .ConfigureAppConfiguration((hostingContext, configuration) => {
                    configuration.Sources.Clear();
                    IHostEnvironment env = hostingContext.HostingEnvironment;
                    configuration
                        .AddJsonFile(settings, true, true);
                })
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                    //logging.AddDareLogger();
                    logging.AddConsoleLogger();
                })
                .ConfigureServices((hostContext, services) => {
                    services.AddSingleton<HostMonitor, HostMonitor>();
                    services.AddSingleton<IServiceListener, MeshRudListener>();
                    services.AddSingleton<IMeshMachine, MeshMachineCore>(
                            s => HostMachine);
                })
            .AddMeshService()
        .Build();

        var services = host.Services;
        var listener = services.GetRequiredService<IServiceListener>() as MeshRudListener;
        Providers = services.GetServices<IConfguredService>() ;
        return listener;
        }


    public override void StartService() {
        var dnsConfig = "db.meshService";
        var netshConfig = "Service.netsh";

        //CancellationToken = new();


        HostMachine = new MeshMachineTest(this, "host1");

        // initialize the service and host configuration
        ServiceAdminShell = new Shell.ServiceAdmin.Shell() {
            MeshMachine = HostMachine
            };
        ServiceAdminCLI = new();
        ServiceAdmin($"create example.com /host=host1.example.com /admin=admin@example.com /account=Domain\\user");

        ServiceAdmin($"dns {dnsConfig}");
        ServiceAdmin($"netsh {netshConfig}");
        var listener = DependencyInjectionHostAsync();


        RudService = listener.RudService;


        }


    public override MeshServiceClient GetMeshClient(
            MeshMachineTest meshMachineTest,
            ICredentialPrivate credential,
             string accountAddress,
            string service
           ) {

        if (RudService == null) {
            StartService();
            }

        var meshServiceBinding = new ConnectionInitiator(
                credential, ServiceDns, Test, TransportType.Http, MeshServiceClient.WellKnown);
        var client = meshServiceBinding.GetClient<MeshServiceClient>();


        return client;
        }

    public void ServiceAdmin(string command) {

        var args = command.Split(" ");
        ServiceAdminCLI.MainMethod(ServiceAdminShell, args);
        }

    //public Goedel.Mesh.Shell.Host.ShellResult OldHost(string command) {

    //    var args = command.Split(" ");
    //    HostAdminCLI.MainMethod(HostShell, args);
    //    return HostShell.ShellResult as Goedel.Mesh.Shell.Host.ResultStartService;
    //    }


    }
