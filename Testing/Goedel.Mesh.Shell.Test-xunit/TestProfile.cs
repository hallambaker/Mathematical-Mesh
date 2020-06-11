using Goedel.Mesh;
using Goedel.Mesh.Shell;
using Goedel.Utilities;

using Xunit;

#pragma warning disable IDE0059
namespace Goedel.XUnit {
    public partial class ShellTests {
        string AccountA => "alice@example.com";
        string AccountB => "bob@example.com";
        string AccountQ => "quartermaster@example.com";
        string DeviceQName => "DeviceQ";
        string DeviceAdminName => "DeviceAdmin";
        string DeviceConnect1Name => "DeviceConnect1";


        string DeviceAliceName => "MachineAlice";
        string DeviceBobName => "MachineBob";

        [Fact]
        public void TestHello() {

            var testCLI = GetTestCLI();

            var result = testCLI.Dispatch("account hello");

            }

        [Fact]
        public void TestProfileEscrow() {
            var account = "alice@example.com";

            Dispatch("profile list");
            // check we have no profiles.

            Dispatch($"profile create {account}");
            //DefaultDevice.AssertAccount(1, account);

            var result = Dispatch("profile escrow test1.escrow /quorum 2 /shares 3");
            //Dispatch("profile delete");
            //DefaultDevice.AssertAccount(0, account, false);
            var resultEscrow = result as ResultEscrow;
            var share1 = resultEscrow.Shares[0];
            var share2 = resultEscrow.Shares[1];
            Dispatch($"profile recover  {share1} {share2} /file test1.escrow /verify");

            //DefaultDevice.AssertAccount(1, account);

            // Goal: implement comprehensive key escrow.
            "Check ability to delete account".TaskTest();
            "Check ability to recover deleted account from the service".TaskTest();
            "Implement ability to store escrow records to service".TaskFunctionality();
            "Implement encryption key escrow".TaskFunctionality();
            "Implement encryption key recovery".TaskFunctionality();

            throw new NYI();
            }


        [Fact]
        public void TestProfileConnect() {
            var accountA = "alice@example.com";



            var device1 = GetTestCLI("Device1");
            var device2 = GetTestCLI("Device2");
            var device3 = GetTestCLI("Device3");

            device1.Dispatch($"mesh create /service={accountA}");

            device1.CheckHostCatalogExtended();

            device1.Dispatch($"account sync");


            device2.Dispatch($"device request {accountA}");
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

            device3.Dispatch($"device request {accountA}  /new");
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

            device1.Dispatch($"mesh create /service={accountA}");

            device1.Connect(device2, accountA);
            device1.Connect(device3, accountA);
            }




        [Fact]
        public void TestProfileConnectPinExpired() => throw new NYI();

        [Fact]
        public void TestProfileConnectPinInvalid() => throw new NYI();

        [Fact]
        public void TestProfileConnectPinReused() => throw new NYI();


        /// <summary>
        /// Test connection by means of a dynamic QR code displayed on an
        /// admin device and scanned by the device requesting connection.
        /// </summary>
        [Fact]
        public void TestProfileConnectDynamicQR() {

            var deviceAdmin     = GetTestCLI(DeviceAdminName);
            var deviceConnect1   = GetTestCLI(DeviceConnect1Name);

            deviceAdmin.Dispatch($"mesh create /service={AccountA}");

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

            deviceQ.Dispatch($"mesh create /service={AccountQ}");
            var deviceInit = deviceQ.Dispatch($"earl device") as ResultPublishDevice;


            deviceConnect1.Dispatch($"device install {deviceInit.FileName}");

            deviceAdmin.Dispatch($"mesh create /service={AccountA}");


            deviceAdmin.Dispatch($"account connect {deviceInit.Uri} ");


            var result2 = deviceConnect1.Dispatch($"device complete");

            }







        [Fact]
        public void TestProfileConnectAuth() {
            var accountA = "alice@example.com";
            var deviceName1 = "Device1";
            var deviceName2 = "Device2";


            var device1 = GetTestCLI(deviceName1);
            var device2 = GetTestCLI(deviceName2);
            device1.Dispatch($"profile create {accountA} ");

            device1.Connect(device2, accountA);
            device1.Dispatch($"device auth deviceName2 /bookmark");
            device2.Dispatch($"bookmark list");

            device1.Dispatch($"device auth deviceName2 /calendar");
            device2.Dispatch($"calendar list");

            device1.Dispatch($"device auth deviceName2 /contact");
            device2.Dispatch($"contact list");

            device1.Dispatch($"device auth deviceName2 /confirm");
            device2.Dispatch($"confirm pending");

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
            var accountA = "alice@example.com";
            var deviceName1 = "Device1";
            var deviceName2 = "Device2";

            var device1 = GetTestCLI(deviceName1);
            var device2 = GetTestCLI(deviceName2);
            device1.Dispatch($"profile create {accountA} ");

            device1.Connect(device2, accountA);
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
            var accountA = "alice@example.com";
            var deviceName1 = "Device1";
            var deviceName2 = "Device2";

            var device1 = GetTestCLI(deviceName1);
            var device2 = GetTestCLI(deviceName2);
            device1.Dispatch($"profile create {accountA} ");

            device1.Connect(device2, accountA);
            device1.Dispatch($"device auth deviceName2 /admin");
            }

        }
    }
