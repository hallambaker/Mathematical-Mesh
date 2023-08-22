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

using System.Threading;

using Goedel.Mesh;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test;
using Goedel.Test.Core;
using Goedel.Utilities;

using Xunit;

#pragma warning disable IDE0059
#pragma warning disable IDE0060

namespace Goedel.XUnit;






public partial class ShellTests  {


    //public void TestHello1() {

    //    var MeshMachine = new MeshMachineCore();
    //    MeshMachine.MeshHost.ConfigureMesh("alice@example.com", "null");

    //    EndTest();

    //    }




    [Fact]
    public void TestHello() {

        var testCLI = GetTestCLI();

        var result = testCLI.Dispatch($"account hello {AliceAccount}");

        EndTest();

        }


    [Fact]
    public void TestHelloFail() {

        var testCLI = GetTestCLI();

        var result = testCLI.Dispatch("account hello", fail:true);

        EndTest();

        }
    [Fact]
    public void TestProfileConnect() {




        var device1 = GetTestCLI("Device1");
        var device2 = GetTestCLI("Device2");
        var device3 = GetTestCLI("Device3");

        device1.Dispatch($"account create {AliceAccount}");

        device1.CheckHostCatalogExtended();

        device1.Dispatch($"account sync");


        device2.Dispatch($"device request {AliceAccount}");
        device2.CheckHostCatalogExtended();

        device2.Dispatch($"account sync", fail: true);

        device1.Dispatch($"account sync");
        var result2 = device1.Dispatch($"message pending");
        var message = (result2 as ResultPending).Messages[0] as AcknowledgeConnection;
        var witness = message.Witness;

        device1.Dispatch($"device accept {witness} /web");
        device2.Dispatch($"device complete");

        device2.CheckHostCatalogExtended();

        device2.Dispatch($"account sync");

        device3.Dispatch($"device request {AliceAccount}  /new");
        device3.Dispatch($"account sync", fail: true);

        var result3 = device1.Dispatch($"device pending");

        message = (result3 as ResultPending).Messages[0] as AcknowledgeConnection;
        witness = message.Witness;
        device1.Dispatch($"device reject {witness}");
        device3.Dispatch($"account sync", fail: true);

        EndTest();
        }


    [Fact]
    public void TestProfileConnectPin() {


        var device1 = GetTestCLI("Device1");
        var device2 = GetTestCLI("Device2");
        var device3 = GetTestCLI("Device3");


        device1.Dispatch($"account create {AliceAccount}");

        var c1 = device1.Connect(device2, AliceAccount, true);
        c1.ProcessedResults.TestEqual(1);
        var c2 = device1.Connect(device3, AliceAccount);
        c2.ProcessedResults.TestEqual(1);

        EndTest();
        }


    [Fact]
    public void TestProfileConnectPinExpired() {


        var device1 = GetTestCLI("Device1");
        var device2 = GetTestCLI("Device2");


        device1.Dispatch($"account create {AliceAccount}");

        var result = device1.Dispatch($"account pin /expire=0 /web") as ResultPIN;
        Thread.Sleep(1000); // make sure that the PIN expires

        var pin = result.MessagePIN.Pin;
        device2.Dispatch($"device request {AliceAccount} /pin {pin}");
        device1.Dispatch($"account sync /auto");

        // The connection MUST be rejected as the PIN has expired.
        device2.Dispatch($"device complete", fail: true);
        device2.Dispatch($"account sync", fail: true);

        EndTest();
        }


    [Fact]
    public void TestProfileConnectPinInvalid() {
        var device1 = GetTestCLI("Device1");
        var device2 = GetTestCLI("Device2");


        device1.Dispatch($"account create {AliceAccount}");

        var result = device1.Dispatch($"account pin  /web") as ResultPIN;

        var pin = result.MessagePIN.Pin.CorruptedPIN();


        device2.Dispatch($"device request {AliceAccount} /pin {pin}");
        device1.Dispatch($"account sync /auto");

        // The connection MUST be rejected as the PIN has expired.
        device2.Dispatch($"device complete", fail: true);
        device2.Dispatch($"account sync", fail: true);

        EndTest();
        }

    [Fact]
    public void TestProfileConnectPinReused() {
        var device1 = GetTestCLI("Device1");
        var device2 = GetTestCLI("Device2");
        var device3 = GetTestCLI("Device3");


        device1.Dispatch($"account create {AliceAccount}");

        var result = device1.Dispatch($"account pin /web") as ResultPIN;


        var pin = result.MessagePIN.Pin;
        device2.Dispatch($"device request {AliceAccount} /pin {pin}");
        device1.Dispatch($"account sync /auto");

        // This connection MUST be accepted.
        device2.Dispatch($"device complete");
        device2.Dispatch($"account sync");

        // The connection MUST be rejected as the PIN was already used.
        device3.Dispatch($"device request {AliceAccount} /pin {pin}");
        device1.Dispatch($"account sync /auto");

        // The connection MUST be rejected as the PIN has expired.
        device3.Dispatch($"device complete", fail: true);
        device3.Dispatch($"account sync", fail: true);

        EndTest();

        }

    /// <summary>
    /// Test connection by means of a dynamic QR code displayed on an
    /// admin device and scanned by the device requesting connection.
    /// </summary>
    [Fact]
    public void TestProfileConnectDynamicQR() {

        var deviceAdmin = GetTestCLI(DeviceAdminName);
        var deviceConnect1 = GetTestCLI(DeviceConnect1Name);


        deviceAdmin.Dispatch($"account create {AliceAccount}");

        // create the connection QR code
        var invite = deviceAdmin.Dispatch($"account pin /web") as ResultPIN;
        var uri = invite.MessagePIN.GetURI();

        var result1 = deviceConnect1.Dispatch($"device join {uri}");
        deviceAdmin.Dispatch($"account sync  /auto");

        // This is currently failing because the completion
        // message is not being found.
        var result2 = deviceConnect1.Dispatch($"device complete");

        EndTest();
        }

    /// <summary>
    /// Test connection by means of a static QR code which specifies
    /// the fingerprint of the device profile and a secret key to be used
    /// both to authenticate the connection and to specify a 'hailing 
    /// identifier' that may be used to establish a wireless connection to 
    /// the device.
    /// </summary>
    [Fact]
    public void TestProfileConnectStaticQR() {

        var deviceQ = GetTestCLI(DeviceQName);
        var deviceAdmin = GetTestCLI(DeviceAdminName);
        var deviceConnect1 = GetTestCLI(DeviceConnect1Name);

        deviceQ.Dispatch($"account create {AccountQ}");


        var deviceInit = deviceQ.Dispatch($"device preconfig") as ResultPublishDevice;
        deviceConnect1.Dispatch($"device install {deviceInit.FileName}");

        deviceAdmin.Dispatch($"account create {AliceAccount}");

        deviceAdmin.Dispatch($"account connect {deviceInit.Uri} /web");


        var result2 = deviceConnect1.Dispatch($"device complete");

        EndTest();

        }



    [Fact]
    public void TestCreateSuper() {
        var device1 = GetTestCLI(DeviceAdminName);
        var device2 = GetTestCLI("Device2");

        TestAuthCreate(device1, device2, "/root");
        // check can do super admin things
        CheckCanSuper(device2);

        EndTest();
        }


    static bool CheckCanSuper(Mesh.Test.TestCLI device2) => true;


    [Fact]
    public void TestCreateAdmin() {
        var device1 = GetTestCLI(DeviceAdminName);
        var device2 = GetTestCLI("Device2");

        TestAuthCreate(device1, device2, "/admin");

        CheckCanAdmin(device2).TestTrue();

        EndTest();
        }


    static bool CheckCanAdmin(Mesh.Test.TestCLI device2) => true;


    [Fact]
    public void TestCreateMessage() {
        var device1 = GetTestCLI(DeviceAdminName);
        var device2 = GetTestCLI("Device2");

        TestAuthCreate(device1, device2, "/message");

        CheckCanMessage(device2).TestTrue();

        EndTest();
        }


    static bool CheckCanMessage(Mesh.Test.TestCLI device2) => true;

    [Fact]
    public void TestCreateWeb() {
        var device1 = GetTestCLI(DeviceAdminName);
        var device2 = GetTestCLI("Device2");

        TestAuthCreate(device1, device2, "/web");

        CheckCanWeb(device2).TestTrue();

        EndTest();
        }


    static bool CheckCanWeb(Mesh.Test.TestCLI device2) => true;

    [Fact]
    public void TestCreateDevice() {
        var device1 = GetTestCLI(DeviceAdminName);
        var device2 = GetTestCLI("Device2");

        TestAuthCreate(device1, device2, "/device");

        CheckCanDevice(device2).TestTrue();

        EndTest();
        }


    static bool CheckCanDevice(Mesh.Test.TestCLI device2) => true;


    bool TestAuthCreate(Mesh.Test.TestCLI device1, Mesh.Test.TestCLI device2, string auth) {


        device1.Dispatch($"account create {AliceAccount} ");
        device1.CheckHostCatalogExtended();

        device2.Dispatch($"device request {AliceAccount} ");
        device2.CheckHostCatalogExtended();

        device1.Dispatch($"account sync");
        var result2 = device1.Dispatch($"message pending");
        var message = (result2 as ResultPending).Messages[0] as AcknowledgeConnection;
        var witness = message.Witness;

        device1.Dispatch($"device accept {witness} device2 {auth}");

        device2.Dispatch($"device complete");
        device2.Dispatch($"account sync");

        return true;
        }

    }
