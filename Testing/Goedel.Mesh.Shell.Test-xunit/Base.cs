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

using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Utilities;

using Xunit;
//using Goedel.Mesh.Shell.ServiceAdmin;


namespace Goedel.XUnit;

[Collection("Sequential")]
public partial class ShellTestsAdmin : ShellTests {
    TestEnvironmentBase testEnvironmentCommon;


    protected override void Disposing() {
        testEnvironmentCommon.Dispose();
        base.Disposing();
        }


    // Use the new test environment (when defined.)
    public override TestEnvironmentBase GetTestEnvironment() {

        //var shell = new Goedel.Mesh.Shell.ServiceAdmin.Shell() {
        //    };

        //throw new NYI();

        testEnvironmentCommon = new TestEnvironmentRdpShell() {
            JpcConnection = Protocol.JpcConnection.Http
            };
        return testEnvironmentCommon;
        }

    public static new ShellTestsAdmin Test() => new();


    [Fact]
    public void TestDns() {

        var testCLI = GetTestCLI();

        var result = testCLI.Dispatch("account hello alice@example.com");

        EndTest();

        }


    }




public partial class ShellTests : Disposable {

    static ShellTests() {
        }

    public static ShellTests Test() => new();

    protected virtual void EndTest() {
        testEnvironment?.Dispose();
        testEnvironment = null;
        }

    public string ServiceDns => TestEnvironment.ServiceDns;

    TestCLI DefaultDevice => defaultDevice ?? GetTestCLI().CacheValue(out defaultDevice);
    TestCLI defaultDevice;


    #region // The test environment specific calls
    public virtual TestEnvironmentBase GetTestEnvironment() => new TestEnvironmentCommon();

    public virtual TestCLI GetTestCLI(string machineName = null) => 
        TestEnvironment.GetTestCLI(machineName);

        //{
        //var testShell = new TestShell(TestEnvironment, MachineName);
        //return new TestCLI(testShell);
        //}
    #endregion



    ///<summary>The test environment, base for all </summary>
    public TestEnvironmentBase TestEnvironment => testEnvironment ??
        GetTestEnvironment().CacheValue(out testEnvironment);
    TestEnvironmentBase testEnvironment;

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


    public bool CheckBookmarkResult(string uri, string title, string local) =>
        DefaultDevice.CheckBookmarkResult(uri, title, local);

    public bool CheckTaskResult(string key, string title) =>
        DefaultDevice.CheckTaskResult(key, title);
    public bool CheckNetworkResult(string service, string key, string password) =>
        DefaultDevice.CheckNetworkResult(service, key, password);

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

