using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Utilities;
//using Goedel.Mesh.Shell.ServiceAdmin;


namespace Goedel.XUnit {


    public partial class ShellTestsAdmin : ShellTests {
        TestEnvironmentCommon testEnvironmentCommon;


        protected override void Disposing() {
            testEnvironmentCommon.Dispose();
            base.Disposing();
            }


        // Use the new test environment (when defined.)
        public override TestEnvironmentCommon GetTestEnvironment() {

            //var shell = new Goedel.Mesh.Shell.ServiceAdmin.Shell() {
            //    };



            //throw new NYI();

            testEnvironmentCommon = new TestEnvironmentRdpShell() {
                JpcConnection = Protocol.JpcConnection.Http
                };
            return testEnvironmentCommon;
            }

        public static new ShellTestsAdmin Test() => new();


        public override TestCLI GetTestCLI(string MachineName = null) {
            var testShell = new TestShell(TestEnvironment, MachineName, false);
            return new TestCLI(testShell);
            }


        }



    public partial class ShellTestsHTTP : ShellTests {
        TestEnvironmentCommon testEnvironmentCommon;


        protected override void Disposing() {
            testEnvironmentCommon.Dispose();
            base.Disposing();
            }


        // Use the new test environment (when defined.)
        public override TestEnvironmentCommon GetTestEnvironment() {

            testEnvironmentCommon = new TestEnvironmentRdp() {
                JpcConnection = Protocol.JpcConnection.Http
                };
            return testEnvironmentCommon;
            }

        public static new ShellTestsHTTP Test() => new();


        public override TestCLI GetTestCLI(string MachineName = null) {
            var testShell = new TestShell(TestEnvironment, MachineName, false);
            return new TestCLI(testShell);
            }


        }

    public partial class ShellTests :Disposable{


        public string ServiceDns => TestEnvironment.ServiceDns;

        TestCLI DefaultDevice => defaultDevice ?? GetTestCLI().CacheValue(out defaultDevice);
        TestCLI defaultDevice;


        #region // The test environment specific calls
        public virtual TestEnvironmentCommon GetTestEnvironment() => new();

        public virtual TestCLI GetTestCLI(string MachineName = null) {
            var testShell = new TestShell(TestEnvironment, MachineName);
            return new TestCLI(testShell);
            } 
        #endregion



        ///<summary>The test environment, base for all </summary>
        public TestEnvironmentCommon TestEnvironment => testEnvironment ??
            GetTestEnvironment().CacheValue(out testEnvironment);
        TestEnvironmentCommon testEnvironment;

        public ShellTests() { }


        public Result Dispatch(string command, bool fail = false) =>
            DefaultDevice.Dispatch(command, fail);

        public Result CreateAccount(string account) =>
            Dispatch($"account create {account}");

        public string GetFileUDF(string filename) {
            var result = Dispatch($"hash udf {filename}");
            return (result as ResultDigest).Digest;
            }


        public bool CheckPasswordResult(string site, string username, string password) =>
            DefaultDevice.CheckPasswordResult(site, username, password);
        public bool CheckContactResult(string key, string email) =>
            DefaultDevice.CheckContactResult(key, email);
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

