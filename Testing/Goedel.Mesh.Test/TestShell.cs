using System;
using System.Collections.Generic;
using Goedel.Mesh.Shell;
using Goedel.Cryptography;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;
using Goedel.Mesh.Client;
using Goedel.Mesh.Server;
using Goedel.Protocol;

namespace Goedel.Mesh.Test {

    public partial class TestShell : Goedel.Mesh.Shell.Shell {
        static string ServiceName = "example.com";
        public MeshPortalDirect MeshPortalDirect => TestEnvironmentCommon.MeshPortalDirect;
        public string MachineName = "Test";


        public TestEnvironmentCommon TestEnvironmentCommon;

        public override IMeshMachineClient MeshMachine => MeshMachineTest;

        public MeshMachineTest MeshMachineTest => meshMachineTest ??
            new MeshMachineTest(TestEnvironmentCommon, MachineName).CacheValue(out meshMachineTest);
        MeshMachineTest meshMachineTest;

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

        public override JpcSession GetJpcSession(IAccountOptions Options) => new MeshClientSession(null);





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


        public ResultEntry ResultEntry => Result as ResultEntry;

        public ResultMail ResultMail => Result as ResultMail;

        public ResultSSH ResultSSH => Result as ResultSSH;


        public ResultDump ResultDump => Result as ResultDump;
        public ResultList ResultList => Result as ResultList;
        public ResultHello ResultHello => Result as ResultHello;
        public ResultDeviceCreate ResultDeviceCreate => Result as ResultDeviceCreate;
        public ResultMasterCreate ResultMasterCreate => Result as ResultMasterCreate;
        public ResultSync ResultSync => Result as ResultSync;
        public ResultEscrow ResultEscrow => Result as ResultEscrow;
        public ResultConnectProcess ResultConnectProcess => Result as ResultConnectProcess;
        public ResultPending ResultPending => Result as ResultPending;
        public ResultRecover ResultRecover => Result as ResultRecover;
        public ResultConnect ResultConnect => Result as ResultConnect;
        public ResultComplete ResultComplete => Result as ResultComplete;
        public ResultPIN ResultPIN => Result as ResultPIN;

        public ExampleResult(string command, Result result) {
            Result = result;
            Command = command;
            }





        }

    public partial class TestCLI : CommandLineInterpreter {
        TestShell Shell;

        public List<Result> Results = new List<Result>();
        public Result Last => Results[Results.Count - 1];


        public int ErrorCount = 0;
        public static int ErrorCountTotal = 0;


        public int Count = 0;
        public static int CountTotal = 0;

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
                Count++;
                CountTotal++;

                try {
                    Dispatcher(Entries, DefaultCommand, Shell, cmd.Split(' '), 0);
                    result.Add(new ExampleResult(cmd, Shell.ShellResult as Result));
                    }
                catch (Exception exception) {
                    ErrorCount++;
                    ErrorCountTotal++;

                    var cmdresult = new Result() {
                        Success = false,
                        Reason = exception.Message
                        };
                    result.Add(new ExampleResult(cmd, cmdresult));
                    }
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
            var entry = result.CatalogEntry as CatalogedCredential;

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
            var entry = result.CatalogEntry as CatalogedContact;

            (key == entry.Key).AssertTrue();
            return true;
            }

        public bool FailBookmarkResult(string path) {
            var result = Dispatch($"bookmark get {path}", fail: true) as ResultEntry;
            return true;
            }

        public bool CheckBookmarkResult(string path, string uri, string title) {
            var result = Dispatch($"bookmark get {path}") as ResultEntry;
            var entry = result.CatalogEntry as CatalogedBookmark;

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
            var entry = result.CatalogEntry as CatalogedTask;

            (key == entry.Key).AssertTrue();
            return true;
            }

        public bool FailNetworkResult(string site) {
            var result = Dispatch($"network get {site}", fail:true) as ResultEntry;
            return true;
            }

        public bool CheckNetworkResult(string key, string password) {
            var result = Dispatch($"network get {key}") as ResultEntry;
            var entry = result.CatalogEntry as CatalogedTask;

            (key == entry.Key).AssertTrue();
            return true;
            }


        public void Connect(TestCLI newDevice, string account) {
            var result = Dispatch($"device pin") as ResultPIN;
            var pin = result.MessageConnectionPIN.PIN;
            newDevice.Dispatch($"device request {account} /pin {pin}");
            Dispatch($"profile sync");
            newDevice.Dispatch($"profile sync");

            }


        }


    }
