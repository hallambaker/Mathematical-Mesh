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
using Goedel.Protocol;

namespace Goedel.XUnit {
    public partial class ShellTests {
        string ServiceName = "example.com";

        /// <summary>
        /// If the test requires a Mesh service, a separate service is instantiated
        /// and shared across all shells.
        /// </summary>
        public MeshPortalDirect MeshPortalDirect => meshPortalDirect ??
            new MeshPortalDirect(ServiceName).CacheValue(out meshPortalDirect);
        MeshPortalDirect meshPortalDirect;

        public ShellTests(string serviceName = null) => ServiceName = serviceName ?? ServiceName;


        public TestCLI GetTestCLI(string MachineName = null) {
            var testShell = new TestShell(this, MachineName);
            return new TestCLI(testShell);
            }

        }
    public partial class TestShell : Shell {
        static string ServiceName = "example.com";
        public MeshPortalDirect MeshPortalDirect => ShellTests.MeshPortalDirect;
        public string MachineName = "Test";
        ShellTests ShellTests;

        public override IMeshMachine MeshMachine => MeshMachineTest;

        public MeshMachineTest MeshMachineTest => meshMachineTest ??
            new MeshMachineTest(MachineEnvironment, MachineName).CacheValue(out meshMachineTest);
        MeshMachineTest meshMachineTest;

        TestMachineEnvironment MachineEnvironment => machineEnvironment ??
            new TestMachineEnvironment(MachineName, MeshPortalDirect).CacheValue(out machineEnvironment);
        TestMachineEnvironment machineEnvironment;

        MeshService MeshClient => meshClient ??
            MeshPortalDirect.GetService(ServiceName).CacheValue(out meshClient);
        MeshService meshClient;

        /// <summary>
        /// Create a new test shell
        /// </summary>
        /// <param name="meshPortalDirect"></param>
        public TestShell(ShellTests shellTests, string machineName = null) {
            MachineName = machineName ?? MachineName;
            ShellTests = shellTests;
            }

        public override MeshService GetMeshClient(IAccountOptions Options) => MeshClient;



        public override JpcSession GetJpcSession(IAccountOptions Options) => new MeshClientSession();

        public override ContextDevice GetContextDevice(IAccountOptions Options) => throw new NYI();

        public override ContextMaster GetContextMaster(IAccountOptions Options) => throw new NYI();


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

        public TestCLI(TestShell shell) : base() => Shell = shell;

        public ShellResult Dispatch(string command) {
            var Args = command.Split(' ');
            Dispatcher(Entries, DefaultCommand, Shell, Args, 0);
            return Shell.ShellResult;
            }

        }


    }
