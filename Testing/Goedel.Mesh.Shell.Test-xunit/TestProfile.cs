using Goedel.Mesh;
using Goedel.Test;
using Goedel.Mesh.Shell;
using Goedel.Utilities;
using System.Threading;

using Xunit;

#pragma warning disable IDE0059
namespace Goedel.XUnit {
    public partial class ShellTests {
        string AccountA => "alice@example.com";
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

            device1.Dispatch($"account create {AccountA}");

            device1.CheckHostCatalogExtended();

            device1.Dispatch($"account sync");


            device2.Dispatch($"device request {AccountA}");
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

            device3.Dispatch($"device request {AccountA}  /new");
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


            device1.Dispatch($"account create {AccountA}");

            device1.Connect(device2, accountA);
            device1.Connect(device3, accountA);
            }


        [Fact]
        public void TestProfileConnectPinExpired() {
            var accountA = "alice@example.com";

            var device1 = GetTestCLI("Device1");
            var device2 = GetTestCLI("Device2");


            device1.Dispatch($"account create {AccountA}");

            var result = device1.Dispatch($"account pin /expire 0") as ResultPIN;
            Thread.Sleep(1000); // make sure that the PIN expires

            var pin = result.MessagePIN.PIN;
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


            device1.Dispatch($"account create {AccountA}");

            var result = device1.Dispatch($"account pin") as ResultPIN;

            var pin = result.MessagePIN.PIN.CorruptedPIN();


            device2.Dispatch($"device request {accountA} /pin {pin}");
            device1.Dispatch($"account sync /auto");

            // The connection MUST be rejected as the PIN has expired.
            device2.Dispatch($"device complete", fail: true);
            device2.Dispatch($"account sync", fail: true);
            }

        [Fact]
        public void TestProfileConnectPinReused() {
            var accountA = "alice@example.com";

            var device1 = GetTestCLI("Device1");
            var device2 = GetTestCLI("Device2");
            var device3 = GetTestCLI("Device3");


            device1.Dispatch($"account create {AccountA}");

            var result = device1.Dispatch($"account pin") as ResultPIN;


            var pin = result.MessagePIN.PIN;
            device2.Dispatch($"device request {accountA} /pin {pin}");
            device1.Dispatch($"account sync /auto");

            // This connection MUST be accepted.
            device2.Dispatch($"device complete", fail: true);
            device2.Dispatch($"account sync", fail: true);

            // The connection MUST be rejected as the PIN was already used.
            device3.Dispatch($"device request {accountA} /pin {pin}");
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


            deviceAdmin.Dispatch($"account create {AccountA}");

            // create the connection QR code
            var invite = deviceAdmin.Dispatch($"account invite") as ResultPIN;


            var result1 = deviceConnect1.Dispatch($"device join {invite.Uri}");
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


            deviceAdmin.Dispatch($"account create {AccountA}");
            var deviceInit = deviceQ.Dispatch($"device preconfig") as ResultPublishDevice;


            deviceConnect1.Dispatch($"device install {deviceInit.FileName}");

            deviceAdmin.Dispatch($"mesh create /service={AccountA}");


            deviceAdmin.Dispatch($"account connect {deviceInit.Uri} ");


            var result2 = deviceConnect1.Dispatch($"device complete");

            }







        [Fact]
        public void TestProfileConnectAuth() {
            CreateAlice(out var device1, out var device2);

            device1.Dispatch($"device auth deviceName2 /bookmark");
            device2.Dispatch($"bookmark list");

            device1.Dispatch($"device auth deviceName2 /calendar");
            device2.Dispatch($"calendar list");

            device1.Dispatch($"device auth deviceName2 /contact");
            device2.Dispatch($"contact list");

            device1.Dispatch($"device auth deviceName2 /confirm");
            device2.Dispatch($"message pending");

            device1.Dispatch($"device auth deviceName2 /mail");
            device2.Dispatch($"mail list");

            device1.Dispatch($"device auth deviceName2 /network");
            device2.Dispatch($"network list");

            device1.Dispatch($"device auth deviceName2 /password");
            device2.Dispatch($"password list");

            device1.Dispatch($"device auth deviceName2 /ssh");
            device2.Dispatch($"ssh show host");
            }

        [Fact]
        public void TestProfileConnectAuthAll() {
            CreateAlice(out var device1, out var device2);

            device1.Dispatch($"device auth deviceName2 /all");
            device2.Dispatch($"bookmark list");
            device2.Dispatch($"calendar list");
            device2.Dispatch($"contact list");
            device2.Dispatch($"confirm pending");
            device2.Dispatch($"mail list");
            device2.Dispatch($"network list");
            device2.Dispatch($"password list");
            device2.Dispatch($"ssh show host");
            }

        [Fact]
        public void TestProfileConnectAuthAdmin() {
            CreateAlice(out var device1, out var device2);

            device1.Dispatch($"device auth deviceName2 /admin");
            }

        }
    }
