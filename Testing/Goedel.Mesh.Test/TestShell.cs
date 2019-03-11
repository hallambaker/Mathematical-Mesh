using System;
using System.Collections.Generic;
using Goedel.Mesh.Shell;
using Goedel.Cryptography;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;
using Goedel.Mesh.Protocol.Client;
using Goedel.Mesh.Protocol.Server;
using Goedel.Protocol;

namespace Goedel.Mesh.Test {

    public partial class TestShell : Goedel.Mesh.Shell.Shell {
        static string ServiceName = "example.com";
        public MeshPortalDirect MeshPortalDirect => TestEnvironmentCommon.MeshPortalDirect;
        public string MachineName = "Test";


        public TestEnvironmentCommon TestEnvironmentCommon;

        public override IMeshMachine MeshMachine => MeshMachineTest;

        public MeshMachineTest MeshMachineTest => meshMachineTest ??
            new MeshMachineTest(MachineEnvironment, MachineName).CacheValue(out meshMachineTest);
        MeshMachineTest meshMachineTest;

        TestEnvironmentMachine MachineEnvironment => machineEnvironment ??
            new TestEnvironmentMachine(TestEnvironmentCommon, MachineName).CacheValue(out machineEnvironment);
        TestEnvironmentMachine machineEnvironment;

        MeshService MeshClient => meshClient ??
            MeshPortalDirect.GetService(ServiceName).CacheValue(out meshClient);
        MeshService meshClient;

        /// <summary>
        /// Create a new test shell
        /// </summary>
        /// <param name="meshPortalDirect"></param>
        public TestShell(TestEnvironmentCommon testEnvironment, string machineName = null) {
            MachineName = machineName ?? MachineName;
            TestEnvironmentCommon = testEnvironment;
            }



        public override MeshService GetMeshClient(IAccountOptions Options) => MeshClient;

        public override JpcSession GetJpcSession(IAccountOptions Options) => new MeshClientSession();





        //public override ContextDevice GetContextDevice(IAccountOptions Options) => throw new NYI();

        //public override ContextMaster GetContextMaster(IAccountOptions Options) => throw new NYI();


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

    public partial class ExampleResult {
        public Result Result;
        public string ResultType => Result._Tag;
        public string Command;
        public string ResultText => Result.ToString();
        public string ResultJSON => Result.GetJson(true).ToUTF8();


        public ExampleResult(string command, Result result) {
            Result = result;
            Command = command;
            }

        }

    public partial class TestCLI : CommandLineInterpreter {
        TestShell Shell;

        public List<Result> Results = new List<Result>();
        public Result Last => Results[Results.Count - 1];


        public TestCLI(TestShell shell) : base() => Shell = shell;


        //public ExampleResult Example(string command, bool fail = false) {
        //    var Args = command.Split(' ');
        //    Dispatcher(Entries, DefaultCommand, Shell, Args, 0);
        //    var result = Shell.ShellResult as Result;

        //    (result.Success != fail).AssertTrue();
        //    return new ExampleResult(command, result);
        //    }

        public List<ExampleResult> Example(params string [] commands) {
            var result = new List<ExampleResult>();

            //var Args = command.Split(' ');
            //Dispatcher(Entries, DefaultCommand, Shell, Args, 0);
            //result.Add(new ExampleResult(command, Shell.ShellResult as Result));

            foreach (var cmd in commands) {
                Dispatcher(Entries, DefaultCommand, Shell, cmd.Split(' '), 0);
                result.Add(new ExampleResult(cmd, Shell.ShellResult as Result));
                }

            return result;
            }


        public Result Dispatch(string command, bool fail = false) {
            var Args = command.Split(' ');
            Dispatcher(Entries, DefaultCommand, Shell, Args, 0);
            var result = Shell.ShellResult as Result;

            (result.Success != fail).AssertTrue();
            return result;
            }


        public bool AssertAccount(int count = -1, string account = null, bool exists = true) {
            throw new NYI();
            }

        public bool FailPasswordResult(string site) {
            var result = Dispatch($"password get {site}", fail: true) as ResultEntry;
            return true;
            }

        public bool CheckPasswordResult(string site, string username, string password) {
            var result = Dispatch($"password get {site}") as ResultEntry;
            var entry = result.CatalogEntry as CatalogEntryCredential;

            (site == entry.Service).AssertTrue();
            (username == entry.Username).AssertTrue();
            (password == entry.Password).AssertTrue();
            return true;
            }

        public bool FailContactResult(string site) {
            var result = Dispatch($"contact get {site}", fail: true) as ResultEntry;
            return true;
            }

        public bool CheckContactResult(string key) {
            var result = Dispatch($"contact get {key}") as ResultEntry;
            var entry = result.CatalogEntry as CatalogEntryContact;

            (key == entry.Key).AssertTrue();
            return true;
            }

        public bool FailBookmarkResult(string path) {
            var result = Dispatch($"bookmark get {path}", fail: true) as ResultEntry;
            return true;
            }

        public bool CheckBookmarkResult(string path, string uri, string title) {
            var result = Dispatch($"bookmark get {path}") as ResultEntry;
            var entry = result.CatalogEntry as CatalogEntryBookmark;

            (uri == entry.Uri).AssertTrue();
            (title == entry.Title).AssertTrue();
            (path == entry.Path).AssertTrue();
            return true;
            }

        public bool FailTaskResult(string site) {
            var result = Dispatch($"calendar get {site}", fail: true) as ResultEntry;
            return true;
            }

        public bool CheckTaskResult(string key, string title) {
            var result = Dispatch($"calendar get {key}") as ResultEntry;
            var entry = result.CatalogEntry as CatalogEntryTask;

            (key == entry.Key).AssertTrue();
            return true;
            }

        public bool FailNetworkResult(string site) {
            var result = Dispatch($"network get {site}", fail:true) as ResultEntry;
            return true;
            }

        public bool CheckNetworkResult(string key, string password) {
            var result = Dispatch($"network get {key}") as ResultEntry;
            var entry = result.CatalogEntry as CatalogEntryTask;

            (key == entry.Key).AssertTrue();
            return true;
            }


        public void Connect(TestCLI newDevice, string account) {
            var result = Dispatch($"profile pin") as ResultPIN;
            var pin = result.MessageConnectionPIN.PIN;
            newDevice.Dispatch($"profile connect {account} /new /pin {pin}");
            Dispatch($"profile sync");
            newDevice.Dispatch($"profile sync");

            }


        }


    }
