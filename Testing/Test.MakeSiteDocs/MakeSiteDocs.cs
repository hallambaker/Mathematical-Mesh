
using ExampleGenerator;

using Goedel.Mesh.Test;

using Xunit;


namespace Goedel.XUnit {
    public class MakeSiteDocs : CreateExamples {
        public static MakeSiteDocs Test() => new();


        public MakeSiteDocs() {

            Service = new LayerService(this);
            Account = new LayerAccount(this);
            Connect = new LayerConnect(this);

            Apps = new LayerApps(this);
            base.Contact = new LayerContact(this);
            Confirm = new LayerConfirm(this);
            Group = new LayerGroup(this);
            NYI = new LayerNYI(this);

            TestEnvironment = new TestEnvironmentCommon();
            }



        [Fact]

        public void FullTest() {
            ServiceConnect();
            CreateAliceAccount();
            EncodeDecodeFile();

            PasswordCatalog();
            BookmarkCatalog();
            ContactCatalog();
            NetworkCatalog();
            TaskCatalog();
            ConnectDeviceCompare(out var deviceId);



            TestConnectDisconnect(deviceId);
            SSHApp();
            MailApp();
            CreateBobAccount();
            ContactExchange();


            Confirmation();
            GroupOperations();
            ConnectPINDynamicQR();
            ConnectStaticQR();
            EscrowAndRecover();
            }

        [Fact]
        public void CiphertextVerify() {

            ServiceConnect();
            CreateAliceAccount();
            EncodeDecodeFile();


            }



        [Fact]
        public void DeleteDevice() {

            ServiceConnect();
            CreateAliceAccount();
            EncodeDecodeFile();
            ConnectDeviceCompare(out var deviceId);
            TestConnectDisconnect(deviceId);
            }

        [Fact]
        public void DecodeSecondDevice() {


            ServiceConnect();
            CreateAliceAccount();
            EncodeDecodeFile();
            ConnectDeviceCompare(out _);



            }


        [Fact]
        public void CreateSSH() {
            ServiceConnect();
            CreateAliceAccount();
            SSHApp();
            }


        [Fact]
        public void CreateMail() {
            ServiceConnect();
            CreateAliceAccount();
            MailApp();
            }

        [Fact]
        public void TestContact() {
            ServiceConnect();
            CreateAliceAccount();
            CreateBobAccount();
            ContactExchange();
            }

        [Fact]
        public void TestConfirmation() {
            ServiceConnect();
            CreateAliceAccount();
            Confirmation();
            }

        [Fact]
        public void GroupTests() {
            ServiceConnect();
            CreateAliceAccount();
            CreateBobAccount();
            ContactExchange();

            GroupOperations();
            }

        [Fact]
        public void Recover() {
            ServiceConnect();
            CreateAliceAccount();
            EscrowAndRecover();
            }




        }
    }
