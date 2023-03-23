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
using Goedel.Mesh.Core;

namespace Goedel.Mesh.Test;







public class TestEnvironmentCommon : TestEnvironmentBase {
    protected LogService Logger { get; set; }
    protected Configuration Configuration { get; set; }


    public string CallsignRegistry { get; set; }

    protected override void Disposing() {
        base.Disposing();
        MeshService.Dispose();
        }

    public virtual PublicMeshService MeshService => meshService ?? GetPublicMeshService().CacheValue(out meshService);
    PublicMeshService meshService;
    
    public virtual TestServiceRud TestServiceRud => testServiceRud ??
    new TestServiceRud(MeshService, null).CacheValue(out testServiceRud);
    TestServiceRud testServiceRud;




    public IMeshMachineClient MeshMachineHost { get; set; }


    protected string HostFile = "whatev";
    public TestEnvironmentCommon(DeterministicSeed seed = null) : base (seed){

        }


    


    protected virtual PublicMeshService GetPublicMeshService() {
        // create the Mesh service

        //ServiceAdmin($"create example.com /host=host1.example.com /admin=alice.example.com /account=Domain\\user");
        // PublicMeshService.Create(MeshMachine, multiConfig, serviceDns, hostConfig, hostIp, hostDns, admin, runAs);


        MeshMachineHost = new MeshMachineTest(this, "host1");

        HostFile = System.IO.Path.Combine(MeshMachineHost.DirectoryMesh, "mmmconfiguration.json");
        Configuration = MeshMachineHost.CreatePublicMeshService( HostFile, ServiceDns);

        Logger = new LogService(Configuration.GenericHostConfiguration, Configuration.MeshServiceConfiguration, null);


        return new PublicMeshService(MeshMachineHost,
            Configuration.GenericHostConfiguration, Configuration.MeshServiceConfiguration, Logger);
        }

    protected override PublicCallsignResolver GetCallsignResolver() {
        _ = MeshService;


        var pathHost = System.IO.Path.Combine(
                MeshMachineHost.DirectoryMesh, CallsignResolver.__Tag) ; ;

        Configuration.CallsignResolverConfiguration = new CallsignResolverConfiguration() {
            Registry = CallsignRegistry,
            HostPath = pathHost
            };

        var result = PublicCallsignResolver.Create(MeshMachineHost,
                    Configuration.GenericHostConfiguration,
                    Configuration.CallsignResolverConfiguration,
                    Logger);

        if (MeshMachineHost is MeshMachineDirect meshMachineDirect) {
            meshMachineDirect.AddService(result.PublicResolverService);
            }


        return result;

        //return new PublicCallsignResolver(MeshMachineHost,
        //    Configuration.GenericHostConfiguration, Configuration.CallsignResolverConfiguration, Logger);

        }




    //protected virtual 

    public override MeshServiceClient GetMeshClient(
        MeshMachineTest meshMachineTest,
        ICredentialPrivate credential,
        string accountAddress
        ) {

        JpcSession session = JpcConnection switch {
            JpcConnection.Direct => new JpcSessionDirect(MeshService, credential) {
                TargetAccount = accountAddress
                },
            JpcConnection.Serialized => new TestSession(MeshService, credential,
                    meshMachineTest.MeshProtocolMessages, meshMachineTest) {
                TargetAccount = accountAddress
                },
            JpcConnection.Rud => new TestSessionRud(TestServiceRud, credential,
                    meshMachineTest.MeshProtocolMessages, meshMachineTest) {
                TargetAccount = accountAddress
                },


            _ => throw new NYI()
            };

        return session.GetWebClient<MeshServiceClient>();
        }
    }
