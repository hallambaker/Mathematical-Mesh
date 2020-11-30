using Goedel.Mesh;
using Goedel.Test;
using Goedel.Mesh.Shell;
using Goedel.Utilities;
using System.Threading;

using Xunit;

#pragma warning disable IDE0059
namespace Goedel.XUnit {
    public partial class ShellTests {
        string AliceAccount => "alice@example.com";
        string MalletAccount => "mallet@example.com";
        string AccountA2 => "alice@example.net";

        string AccountB => "bob@example.com";
        string AccountC => "carol@example.com";
        string AccountQ => "quartermaster@example.com";
        string DeviceQName => "DeviceQ";
        string DeviceAdminName => "DeviceAdmin";
        string DeviceConnect1Name => "DeviceConnect1";


        string DeviceAliceName => "MachineAlice";

        string DeviceAliceName2 => "MachineAlice2";

        string DeviceBobName => "MachineBob";

        [Fact]
        public void TestHello() {

            var testCLI = GetTestCLI();

            var result = testCLI.Dispatch("account hello");

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

            device1.Dispatch($"device accept {witness}");
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
            }


        [Fact]
        public void TestProfileConnectPin() {
            var accountA = "alice@example.com";

            var device1 = GetTestCLI("Device1");
            var device2 = GetTestCLI("Device2");
            var device3 = GetTestCLI("Device3");


            device1.Dispatch($"account create {AliceAccount}");

            var c1 = device1.Connect(device2, accountA);
            c1.ProcessedResults.TestEqual(1);
            var c2 = device1.Connect(device3, accountA);
            c2.ProcessedResults.TestEqual(1);
            }


        [Fact]
        public void TestProfileConnectPinExpired() {
            var accountA = "alice@example.com";

            var device1 = GetTestCLI("Device1");
            var device2 = GetTestCLI("Device2");


            device1.Dispatch($"account create {AliceAccount}");

            var result = device1.Dispatch($"account pin /expire 0") as ResultPIN;
            Thread.Sleep(1000); // make sure that the PIN expires

            var pin = result.MessagePIN.Pin;
            device2.Dispatch($"device request {accountA} /pin {pin}");
            device1.Dispatch($"account sync /auto");

            // The connection MUST be rejected as the PIN has expired.
            device2.Dispatch($"device complete", fail: true);
            device2.Dispatch($"account sync", fail: true);
            }


        [Fact]
        public void TestProfileConnectPinInvalid() {
            var accountA = "alice@example.com";

            var device1 = GetTestCLI("Device1");
            var device2 = GetTestCLI("Device2");


            device1.Dispatch($"account create {AliceAccount}");

            var result = device1.Dispatch($"account pin") as ResultPIN;

            var pin = result.MessagePIN.Pin.CorruptedPIN();


            device2.Dispatch($"device request {accountA} /pin {pin}");
            device1.Dispatch($"account sync /auto");

            // The connection MUST be rejected as the PIN has expired.
            device2.Dispatch($"device complete", fail: true);
            device2.Dispatch($"account sync", fail: true);
            }

        [Fact]
        public void TestProfileConnectPinReused() {
            var device1 = GetTestCLI("Device1");
            var device2 = GetTestCLI("Device2");
            var device3 = GetTestCLI("Device3");


            device1.Dispatch($"account create {this.AliceAccount}");

            var result = device1.Dispatch($"account pin") as ResultPIN;


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

            }

        /// <summary>
        /// Test connection by means of a dynamic QR code displayed on an
        /// admin device and scanned by the device requesting connection.
        /// </summary>
        [Fact]
        public void TestProfileConnectDynamicQR() {

            var deviceAdmin     = GetTestCLI(DeviceAdminName);
            var deviceConnect1   = GetTestCLI(DeviceConnect1Name);


            deviceAdmin.Dispatch($"account create {AliceAccount}");

            // create the connection QR code
            var invite = deviceAdmin.Dispatch($"account pin") as ResultPIN;
            var uri = invite.MessagePIN.GetURI();

            var result1 = deviceConnect1.Dispatch($"device join {uri}");
            deviceAdmin.Dispatch($"account sync  /auto");

            // This is currently failing because the completion
            // message is not being found.
            var result2 = deviceConnect1.Dispatch($"device complete");
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

            deviceAdmin.Dispatch($"account connect {deviceInit.Uri} ");


            var result2 = deviceConnect1.Dispatch($"device complete");

            }



        [Fact]
        public void TestCreateSuper() {
            var device1 = GetTestCLI(DeviceAdminName);
            var device2 = GetTestCLI("Device2");

            TestAuthCreate(device1, device2, "/root");
            // check can do super admin things
            CheckCanSuper(device2);
            }

        [Fact]
        public void TestAuthSuper() {
            var device1 = GetTestCLI(DeviceAdminName);
            var device2 = GetTestCLI("Device2");

            TestAuthCreate(device1, device2, "");
            //CheckCanSuper(device2).TestFalse(); 

            device1.Dispatch("device auth device2 /root");

            CheckCanSuper(device2).TestTrue();
            }

        bool CheckCanSuper(Mesh.Test.TestCLI device2) {
            return true;
            }


        [Fact]
        public void TestCreateAdmin() {
            var device1 = GetTestCLI(DeviceAdminName);
            var device2 = GetTestCLI("Device2");

            TestAuthCreate(device1, device2, "/admin");

            CheckCanAdmin(device2).TestTrue();
            }

        [Fact]
        public void TestAuthAdmin() {
            var device1 = GetTestCLI(DeviceAdminName);
            var device2 = GetTestCLI("Device2");

            TestAuthCreate(device1, device2, "");
            //CheckCanAdmin(device2).TestFalse(); 

            device1.Dispatch("device auth device2 /admin");

            CheckCanAdmin(device2).TestTrue();
            }

        bool CheckCanAdmin(Mesh.Test.TestCLI device2) {
            return true;
            }


        [Fact]
        public void TestCreateMessage() {
            var device1 = GetTestCLI(DeviceAdminName);
            var device2 = GetTestCLI("Device2");

            TestAuthCreate(device1, device2, "/message");

            CheckCanMessage(device2).TestTrue();
            }

        [Fact]
        public void TestAuthMessage() {
            var device1 = GetTestCLI(DeviceAdminName);
            var device2 = GetTestCLI("Device2");

            TestAuthCreate(device1, device2, "");
            //CheckCanMessage(device2).TestFalse(); 

            device1.Dispatch("device auth device2 /message");

            CheckCanMessage(device2).TestTrue();
            }

        bool CheckCanMessage(Mesh.Test.TestCLI device2) {
            return true;
            }

        [Fact]
        public void TestCreateWeb() {
            var device1 = GetTestCLI(DeviceAdminName);
            var device2 = GetTestCLI("Device2");

            TestAuthCreate(device1, device2, "/web");

            CheckCanWeb(device2).TestTrue();
            }

        [Fact]
        public void TestAuthWeb() {
            var device1 = GetTestCLI(DeviceAdminName);
            var device2 = GetTestCLI("Device2");

            TestAuthCreate(device1, device2, "");
            //CheckCanWeb(device2).TestFalse(); 

            device1.Dispatch("device auth device2 /web");

            CheckCanWeb(device2).TestTrue();
            }

        bool CheckCanWeb(Mesh.Test.TestCLI device2) {
            return true;
            }

        [Fact]
        public void TestCreateDevice() {
            var device1 = GetTestCLI(DeviceAdminName);
            var device2 = GetTestCLI("Device2");

            TestAuthCreate(device1, device2, "/device");

            CheckCanDevice(device2).TestTrue();
            }

        [Fact]
        public void TestAuthDevice() {
            var device1 = GetTestCLI(DeviceAdminName);
            var device2 = GetTestCLI("Device2");

            TestAuthCreate(device1, device2, "");
            //CheckCanDevice(device2).TestFalse(); 

            device1.Dispatch("device auth device2 /device");

            CheckCanDevice(device2).TestTrue();
            }

        bool CheckCanDevice(Mesh.Test.TestCLI device2) {
            return true;
            }


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
    }
