using System;
using System.Collections.Generic;
using Xunit;
using Goedel.Mesh.Shell;
using Goedel.Cryptography;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;
using Goedel.Mesh.Client;
using Goedel.Mesh.Server;
using Goedel.Mesh;
using Goedel.Protocol;

namespace Goedel.XUnit {
    public partial class ShellTests {
        string ServiceName = "example.com";
        TestCLI DefaultDevice => defaultDevice ?? GetTestCLI().CacheValue(out defaultDevice);
        TestCLI defaultDevice;

        ///<summary>The test environment, base for all </summary>
        public TestEnvironmentCommon TestEnvironment => testEnvironment ??
            new TestEnvironmentCommon().CacheValue(out testEnvironment);
        TestEnvironmentCommon testEnvironment;

        //public string ServiceDirectory => System.IO.Path.Combine(TestEnvironment.Path, "ServiceDirectory");

        ///// <summary>
        ///// If the test requires a Mesh service, a separate service is instantiated
        ///// and shared across all shells.
        ///// </summary>
        //public MeshPortalDirect MeshPortalDirect => meshPortalDirect ??
        //    new MeshPortalDirect(ServiceName, ServiceDirectory).CacheValue(out meshPortalDirect);
        //MeshPortalDirect meshPortalDirect;

        public ShellTests(string serviceName = null) =>
                    ServiceName = serviceName ?? ServiceName;


        public TestCLI GetTestCLI(string MachineName = null) {
            var testShell = new TestShell(TestEnvironment, MachineName);
            return new TestCLI(testShell);
            }

        public Result Dispatch(string command, bool fail = false) =>
            DefaultDevice.Dispatch(command, fail);


        public Result CreateAccount(string account) =>
            Dispatch($"mesh create /service={account}");

        public string GetFileUDF(string filename) {
            var result = Dispatch($"hash udf {filename}");
            return (result as ResultDigest).Digest;
            }


        public bool CheckPasswordResult(string site, string username, string password) =>
            DefaultDevice.CheckPasswordResult(site, username, password);
        public bool CheckContactResult(string key) =>
            DefaultDevice.CheckContactResult(key);
        public bool CheckBookmarkResult(string uri, string title, string path) =>
            DefaultDevice.CheckBookmarkResult(uri, title, path);

        public bool CheckTaskResult(string key, string title) =>
            DefaultDevice.CheckTaskResult(key, title);
        public bool CheckNetworkResult(string key, string password) =>
            DefaultDevice.CheckNetworkResult(key, password);

        public bool FailPasswordResult(string site) =>
            DefaultDevice.FailPasswordResult(site);
        public bool FailContactResult(string key) =>
            DefaultDevice.FailContactResult(key);
        public bool FailBookmarkResult(string key) =>
            DefaultDevice.FailBookmarkResult(key);

        public bool FailTaskResult(string key) =>
            DefaultDevice.FailTaskResult(key);
        public bool FailNetworkResult(string key) =>
            DefaultDevice.FailNetworkResult(key);
        }
    }
//public partial class TestShell : Shell {
//        static string ServiceName = "example.com";
//        public MeshPortalDirect MeshPortalDirect => TestEnvironmentCommon.MeshPortalDirect;
//        public string MachineName = "Test";
//        ShellTests ShellTests;

//        public TestEnvironmentCommon TestEnvironmentCommon => ShellTests.TestEnvironment;

//        public override IMeshMachine MeshMachine => MeshMachineTest;

//        public MeshMachineTest MeshMachineTest => meshMachineTest ??
//            new MeshMachineTest(MachineEnvironment, MachineName).CacheValue(out meshMachineTest);
//        MeshMachineTest meshMachineTest;

//        TestEnvironmentMachine MachineEnvironment => machineEnvironment ??
//            new TestEnvironmentMachine(TestEnvironmentCommon, MachineName).CacheValue(out machineEnvironment);
//        TestEnvironmentMachine machineEnvironment;

//        MeshService MeshClient => meshClient ??
//            MeshPortalDirect.GetService(ServiceName).CacheValue(out meshClient);
//        MeshService meshClient;

//        /// <summary>
//        /// Create a new test shell
//        /// </summary>
//        /// <param name="meshPortalDirect"></param>
//        public TestShell(ShellTests shellTests, string machineName = null) {
//            MachineName = machineName ?? MachineName;
//            ShellTests = shellTests;
//            }



//        public override MeshService GetMeshClient(IAccountOptions Options) => MeshClient;

//        public override JpcSession GetJpcSession(IAccountOptions Options) => new MeshClientSession();





//        //public override ContextDevice GetContextDevice(IAccountOptions Options) => throw new NYI();

//        //public override ContextMaster GetContextMaster(IAccountOptions Options) => throw new NYI();


//        public ShellResult ShellResult;

//        /// <summary>
//        /// Override the post processing hook to save the result.
//        /// </summary>
//        /// <param name="shellResult"></param>
//        public override void _PostProcess(ShellResult shellResult) {
//            Console.WriteLine(shellResult.ToString());
//            ShellResult = shellResult;
//            }
//        }

//    public partial class TestCLI : CommandLineInterpreter {
//        TestShell Shell;

//        public List<Result> Results = new List<Result>();
//        public Result Last => Results[Results.Count - 1];


//        public TestCLI(TestShell shell) : base() => Shell = shell;

//        public Result Dispatch(string command, bool fail = false) {
//            var Args = command.Split(' ');
//            Dispatcher(Entries, DefaultCommand, Shell, Args, 0);
//            var result = Shell.ShellResult as Result;

//            (result.Success != fail).AssertTrue();
//            return result;
//            }


//        public bool AssertAccount(int count = -1, string account = null, bool exists = true) {
//            throw new NYI();
//            }

//        public bool FailPasswordResult(string site) {
//            var result = Dispatch($"password get {site}", fail: true) as ResultEntry;
//            return true;
//            }

//        public bool CheckPasswordResult(string site, string username, string password) {
//            var result = Dispatch($"password get {site}") as ResultEntry;
//            var entry = result.CatalogEntry as CatalogEntryCredential;

//            (site == entry.Service).AssertTrue();
//            (username == entry.Username).AssertTrue();
//            (password == entry.Password).AssertTrue();
//            return true;
//            }

//        public bool FailContactResult(string site) {
//            var result = Dispatch($"contact get {site}", fail: true) as ResultEntry;
//            return true;
//            }

//        public bool CheckContactResult(string key) {
//            var result = Dispatch($"contact get {key}") as ResultEntry;
//            var entry = result.CatalogEntry as CatalogEntryContact;

//            (key == entry.Key).AssertTrue();
//            return true;
//            }

//        public bool FailBookmarkResult(string path) {
//            var result = Dispatch($"bookmark get {path}", fail: true) as ResultEntry;
//            return true;
//            }

//        public bool CheckBookmarkResult(string path, string uri, string title) {
//            var result = Dispatch($"bookmark get {path}") as ResultEntry;
//            var entry = result.CatalogEntry as CatalogEntryBookmark;

//            (uri == entry.Uri).AssertTrue();
//            (title == entry.Title).AssertTrue();
//            (path == entry.Path).AssertTrue();
//            return true;
//            }

//        public bool FailTaskResult(string site) {
//            var result = Dispatch($"calendar get {site}", fail: true) as ResultEntry;
//            return true;
//            }

//        public bool CheckTaskResult(string key, string title) {
//            var result = Dispatch($"calendar get {key}") as ResultEntry;
//            var entry = result.CatalogEntry as CatalogEntryTask;

//            (key == entry.Key).AssertTrue();
//            return true;
//            }

//        public bool FailNetworkResult(string site) {
//            var result = Dispatch($"network get {site}", fail:true) as ResultEntry;
//            return true;
//            }

//        public bool CheckNetworkResult(string key, string password) {
//            var result = Dispatch($"network get {key}") as ResultEntry;
//            var entry = result.CatalogEntry as CatalogEntryTask;

//            (key == entry.Key).AssertTrue();
//            return true;
//            }


//        public void Connect(TestCLI newDevice, string account) {
//            var result = Dispatch($"profile pin") as ResultPIN;
//            var pin = result.MessageConnectionPIN.PIN;
//            newDevice.Dispatch($"profile connect {account} /new /pin {pin}");
//            Dispatch($"profile sync");
//            newDevice.Dispatch($"profile sync");

//            }


//        }


//    }
