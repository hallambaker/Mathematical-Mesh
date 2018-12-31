using System;
using System.Collections.Generic;
using Xunit;
using Goedel.Mesh.Shell;
using Goedel.Cryptography;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;
using Goedel.Mesh.Protocol.Client;
using Goedel.Mesh.Protocol.Server;
using Goedel.Mesh;

namespace Goedel.XUnit {

    public partial class TestShell : Shell {
        static string ServiceName = "example.com";
        public MeshPortalDirect MeshPortalDirect ;


        TestMachineEnvironment MachineEnvironment => machineEnvironment ??
            new TestMachineEnvironment(meshPortalDirect: MeshPortalDirect).CacheValue(out machineEnvironment);
        TestMachineEnvironment machineEnvironment;

        MeshService MeshClient => meshClient ??
            MeshPortalDirect.GetService(ServiceName).CacheValue(out meshClient);
        MeshService meshClient;

        MeshService MeshClientB => meshClientB ??
            MeshPortalDirect.GetService(ServiceName).CacheValue(out meshClientB);
        MeshService meshClientB;

        /// <summary>
        /// Create a new test shell
        /// </summary>
        /// <param name="meshPortalDirect"></param>
        public TestShell(MeshPortalDirect meshPortalDirect=null) {
            MeshPortalDirect = meshPortalDirect ?? new MeshPortalDirect (ServiceName);
            }

        public override ContextDevice GetContextDevice(IAccountOptions Options) {
            throw new NYI();
            }

        public override ContextMaster GetContextMaster(IAccountOptions Options) {
            throw new NYI();
            }


        public ShellResult ShellResult;

        /// <summary>
        /// Override the post processing hook to save the result.
        /// </summary>
        /// <param name="shellResult"></param>
        public override void _PostProcess(ShellResult shellResult) {
            Console.WriteLine(shellResult.ToString());
            ShellResult = shellResult;
            }
        }

    public partial class TestCLI : CommandLineInterpreter {
        TestShell Shell;

        public TestCLI(TestShell shell = null) : base() {
            Shell = shell ?? new TestShell();
            }

        public ShellResult Dispatch(string command) {
            var Args = command.Split(' ');
            Dispatcher(Entries, DefaultCommand, Shell, Args, 0);
            return Shell.ShellResult;
            }

        }


    }
