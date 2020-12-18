
using ExampleGenerator;

using Goedel.IO;
using Goedel.Mesh;
using Goedel.Mesh.Test;
using Goedel.Utilities;
using Goedel.Test.Core;
using System.Collections.Generic;
using Goedel.Test;
using Xunit;


namespace Goedel.XUnit {
    public class MakeSiteDocs : CreateExamples {

        //public virtual TestCLI Alice1 { get; private set; }
        //public virtual TestCLI Alice2 { get; private set; }
        //public virtual TestCLI Alice3 { get; private set; }
        //public virtual TestCLI Alice4 { get; private set; }
        //public virtual TestCLI Bob1 { get; private set; }
        //public virtual TestCLI Mallet1 { get; private set; }
        //public virtual TestCLI Console1 { get; private set; }
        //public virtual TestCLI Maker1 { get; private set; }

        public static MakeSiteDocs Test() => new MakeSiteDocs();


        public MakeSiteDocs() {

            Service = new LayerService(this);
            Account = new LayerAccount(this);
            Connect = new LayerConnect(this);

            Apps = new LayerApps(this);
            base.Contact = new LayerContact(this);
            Confirm = new LayerConfirm(this);
            Group = new LayerGroup(this);
            NYI = new LayerNYI(this);

            Goedel.IO.Debug.Initialize();
            Goedel.Cryptography.Cryptography.Initialize();

            TestEnvironment = new TestEnvironmentCommon();
            }



        [Fact]

        public void FullTest () {
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

            ConnectDeviceCompare(out var deviceId);
            TestConnectDisconnect(deviceId);
            }
        
        [Fact]
        public void DecodeSecondDevice() {


            ServiceConnect();
            CreateAliceAccount();
            EncodeDecodeFile();
            ConnectDeviceCompare(out var deviceId);



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
