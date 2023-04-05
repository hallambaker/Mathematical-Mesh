
using Goedel.Test;
using Goedel.Mesh.Test;
using Goedel.Utilities;
using Goedel.Presence.Client;
using Goedel.Mesh.Client;
using Goedel.Mesh.Shell;
using System;
using Goedel.Mesh.Server;
using Goedel.Mesh.ServiceAdmin;
using Goedel.Protocol.Service;
using Goedel.Presence.Server;
using Goedel.Test.Core;
using Microsoft.Extensions.Logging;

namespace Goedel.XUnit;


//public class TestMini : Disposable{
//    public string CallerMethod { get; }
//    public TestRandom Random { get; }

    
//    public TestMini(string parameters = null, int count = 0) {
//        CallerMethod = AssemblyStack.GetMethodCallingConstructorName();
//        Random = new(CallerMethod, parameters, count);
//        }

//    public byte[] GetBytes(int length, string tag = null) =>
//            Random.GetBytes(length, tag);

//    }
public class TestEnvironmentPresence : TestEnvironmentCommon {

    public CommunicationConditions CommunicationConditions { get; set; }

    PresenceServer PresenceServer;


    public TestEnvironmentPresence (DeterministicSeed seed) : base(seed) { }

    protected override void Disposing() {
        base.Disposing();
        PresenceServer.Dispose();
        }


    protected override PublicMeshService GetPublicMeshService() {
        // create the Mesh service

        //ServiceAdmin($"create example.com /host=host1.example.com /admin=alice.example.com /account=Domain\\user");
        // PublicMeshService.Create(MeshMachine, multiConfig, serviceDns, hostConfig, hostIp, hostDns, admin, runAs);


        MeshMachineHost = new MeshMachineTest(this, "host1");

        HostFile = System.IO.Path.Combine(MeshMachineHost.DirectoryMesh, "mmmconfiguration.json");
        Configuration = MeshMachineHost.CreatePublicMeshService(HostFile, ServiceDns);

        Logger = new LogService(Configuration.GenericHost, Configuration.MeshService, null);

        PresenceServer = new PresenceServerTesting(
            Configuration.GenericHost,
            Configuration.PresenceService,
            CommunicationConditions);

        return new PublicMeshService(MeshMachineHost,
            Configuration.GenericHost, 
            Configuration.MeshService, 
            Logger, PresenceServer);
        }


    }


