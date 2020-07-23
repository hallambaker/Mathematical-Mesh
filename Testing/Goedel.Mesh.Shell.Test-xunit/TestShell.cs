using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Utilities;

namespace Goedel.XUnit {
    public partial class ShellTests {
        string ServiceName { get; set; } = "example.com";
        TestCLI DefaultDevice => defaultDevice ?? GetTestCLI().CacheValue(out defaultDevice);
        TestCLI defaultDevice;

        ///<summary>The test environment, base for all </summary>
        public TestEnvironmentCommon TestEnvironment => testEnvironment ??
            new TestEnvironmentCommon().CacheValue(out testEnvironment);
        TestEnvironmentCommon testEnvironment;

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

