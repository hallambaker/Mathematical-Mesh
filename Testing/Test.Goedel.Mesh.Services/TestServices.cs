using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh;
using Goedel.Mesh.Platform;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Protocol.Framework;
using Test.Common;
using Goedel.Mesh.Server;

namespace Test.Goedel.Mesh {
    [TestClass]
    public class TestServices {

        static MeshCatalog MeshCatalog;
        //static DeviceProfile DeviceProfile;
        //static PersonalProfile PersonalProfile;

        static TestConstant TestConstant;

        RegistrationPersonal RegistrationPersonal = null;

        [AssemblyInitialize]
        public static void InitializeClass(TestContext context) {

            TestConstant = new TestConstant();
            MeshWindows.Initialize(true);

            // List of all the accounts on the current machine
            MeshCatalog = new MeshCatalog();

            MeshCatalog.EraseTest(); // remove previous test data

            // Connect to a direct, in process portal.
            var Portal = new MeshPortalDirect(TestConstant.NameService, TestConstant.LogMesh, TestConstant.LogPortal);
            MeshPortal.Default = Portal;


            }


        [AssemblyCleanup]
        public static void Cleanup() {
            MeshCatalog.EraseTest();
            }



        // Services:
        // TTest: Request Connect device [service]
        // TTest: Accept request device [service]
        // TTest: Refuse connect device [service]
        // TTest: Connected device gets updates
        // TTest: Sync second device

        /// <summary>
        /// This illustrates how we manage profiles using the catalog.
        /// </summary>
        [TestMethod]
        public void NewDevice() {
            var DeviceRegistration = MeshCatalog.GetDevice(DeviceNew: true,
                        DeviceID: TestConstant.Device1,
                        DeviceDescription: TestConstant.Device1Description);

            var UDF = DeviceRegistration.DeviceProfile.UDF;

            var DeviceRegistration2 = MeshCatalog.GetDevice(DeviceUDF: UDF);
            var DeviceProfile1 = DeviceRegistration.DeviceProfile;
            var DeviceProfile2 = DeviceRegistration2.DeviceProfile;

            UT.Assert.AreEqual(DeviceProfile1.UDF, DeviceProfile2.UDF);
            UT.Assert.AreEqual(DeviceProfile1.DeviceAuthenticationKey.UDF, DeviceProfile2.DeviceAuthenticationKey.UDF);
            UT.Assert.AreEqual(DeviceProfile1.DeviceEncryptiontionKey.UDF, DeviceProfile2.DeviceEncryptiontionKey.UDF);
            UT.Assert.AreEqual(DeviceProfile1.DeviceSignatureKey.UDF, DeviceProfile2.DeviceSignatureKey.UDF);
            UT.Assert.AreEqual(DeviceProfile1.Description, DeviceProfile2.Description);
            UT.Assert.IsTrue(DeviceProfile1.Valid);
            UT.Assert.IsTrue(DeviceProfile2.Valid);
            }

        /// <summary>
        /// This illustrates how we manage profiles using the catalog.
        /// </summary>
        [TestMethod]
        public void NewPersonal() {
            var DeviceRegistration = MeshCatalog.GetDevice(DeviceNew: true,
                        DeviceID: TestConstant.Device1,
                        DeviceDescription: TestConstant.Device1Description);

            var PersonalProfile1 = new PersonalProfile(DeviceRegistration.DeviceProfile);
            var PersonalRegistration = MeshCatalog.CreateAccount(TestConstant.AccountID, PersonalProfile1);

            UT.Assert.IsNotNull(PersonalRegistration);
            UT.Assert.IsNotNull(PersonalRegistration.SignedPersonalProfile);

            var MeshCatalog2 = new MeshCatalog();


            var PersonalMesh = MeshCatalog2.GetPersonal(TestConstant.AccountID);
            var PersonalProfile2 = PersonalMesh.PersonalProfile;

            UT.Assert.AreEqual(PersonalProfile1.UDF, PersonalProfile2.UDF);
            UT.Assert.AreEqual(PersonalProfile1.AdministrationKey.UDF, PersonalProfile2.AdministrationKey.UDF);
            UT.Assert.AreEqual(PersonalProfile1.DeviceProfile.UDF, PersonalProfile2.DeviceProfile.UDF);
            UT.Assert.IsTrue(PersonalProfile1.Valid);
            UT.Assert.IsTrue(PersonalProfile2.Valid);
            }


        /// <summary>
        /// This illustrates how we manage profiles using the catalog.
        /// </summary>
        [TestMethod]
        public void TestEscrow() {

            var DeviceRegistration = MeshCatalog.GetDevice(DeviceNew: true,
                        DeviceID: TestConstant.Device1,
                        DeviceDescription: TestConstant.Device1Description);

            var PersonalProfile1 = new PersonalProfile(DeviceRegistration.DeviceProfile);
            var PersonalRegistration = MeshCatalog.CreateAccount(TestConstant.AccountID, PersonalProfile1);
            var Original = PersonalRegistration.PersonalProfile;

            UT.Assert.IsNotNull(PersonalRegistration);
            UT.Assert.IsNotNull(PersonalRegistration.SignedPersonalProfile);


            // Push the update(s) to the portal.
            PersonalRegistration.WriteToPortal();


            var OfflineEscrowEntry = new OfflineEscrowEntry(PersonalProfile1, 3, 2);
            // Push to the Portal
            PersonalRegistration.Escrow(OfflineEscrowEntry);
            PersonalRegistration.Delete();

            // Recover encryption key from two shares
            var share1 = OfflineEscrowEntry.KeyShares[0].Text;
            var share2 = OfflineEscrowEntry.KeyShares[1].Text;

            // Get recovery data
            string[] TestShares = { share1, share2 };
            var RecoveryKey = new Secret(TestShares);

            // Determine identifier
            var Identifier = UDF.ToString(UDF.FromEscrowed(RecoveryKey.Key, 150));

            // Perform the desired operations
            //var RecoveredEscrow = MeshClient.Recover(Identifier);

            var RecoveredPersonal = MeshCatalog.Recover(RecoveryKey);

            var Recovered = RecoveredPersonal.PersonalProfile;

            // NYI: add the assertions here.
            UT.Assert.IsTrue(Original.UDF == Recovered.UDF);
            UT.Assert.IsTrue(Original.MasterProfile.MasterSignatureKey.UDF ==
                Recovered.MasterProfile.MasterSignatureKey.UDF);
            }


        /// <summary>
        /// Test the Web profile generation
        /// </summary>
        [TestMethod]
        public void TestWeb() {
            var PersonalProfile = RegistrationPersonal.PersonalProfile;

            var PasswordProfile = new PasswordProfile(true);
            //var ApplicationProfileEntry = PersonalProfile.Add(PasswordProfile);

            var ApplicationRegistration = RegistrationPersonal.Add(PasswordProfile);


            PasswordProfile.Add("example.com", "alice", "secret");
            PasswordProfile.Add("cnn.com", "alice1", "secret");
            ApplicationRegistration.WriteToPortal();

            //TestPasswordAdd(PasswordProfile.UDF);
            //TestPasswordDelete(PasswordProfile.UDF);
            //TestPasswordRead(PasswordProfile.UDF);
            }

        //string TestSite1 = "blog.example.com";
        //string TestSite2 = "news.example.net";

        //void TestPasswordAdd(string UDF) {
        //    var ApplicationRegistration = MeshCatalog.GetApplication(UDF);
        //    var PasswordProfile = ApplicationRegistration.ApplicationProfile as PasswordProfile;
        //    UT.Assert.IsNotNull(PasswordProfile);

        //    PasswordProfile.Add(TestSite1, "alice", "secret");
        //    PasswordProfile.Add(TestSite2, "alice1", "secret");
        //    ApplicationRegistration.Update();
        //    }

        //void TestPasswordDelete(string UDF) {
        //    var ApplicationRegistration = MeshCatalog.GetApplication(UDF);
        //    var PasswordProfile = ApplicationRegistration.ApplicationProfile as PasswordProfile;
        //    UT.Assert.IsNotNull(PasswordProfile);

        //    PasswordEntry Found;
        //    Found = PasswordProfile.GetEntry(TestSite1, out var Username, out var Password);

        //    PasswordProfile.Delete(TestSite1);
        //    Found = PasswordProfile.GetEntry(TestSite1, out Username, out Password);

        //    Found = PasswordProfile.GetEntry(TestSite2, out Username, out Password);
        //    PasswordProfile.Add(TestSite2, "alice1", "secret2");
        //    ApplicationRegistration.Update();
        //    }

        //void TestPasswordRead(string UDF) {
        //    var ApplicationRegistration = MeshCatalog.GetApplication(UDF);
        //    var PasswordProfile = ApplicationRegistration.ApplicationProfile as PasswordProfile;
        //    UT.Assert.IsNotNull(PasswordProfile);

        //    PasswordEntry Found;

        //    Found = PasswordProfile.GetEntry(TestSite1, out var Username, out var Password);
        //    Found = PasswordProfile.GetEntry(TestSite2, out Username, out Password);

        //    }


        /// <summary>
        /// Test the SSH profile generation
        /// </summary>
        [TestMethod]
        public void TestSSH() {
            var PersonalRegistration = CreateAndRegister("TestSSH@example.com");

            var SSHProfile = new SSHProfile();
            var ApplicationRegistration = PersonalRegistration.Add(SSHProfile);

            // Create key for each device in the profile


            // Generate the authorized hosts entry for this profile
            PersonalRegistration.Write();
            ApplicationRegistration.Write();
            }

        /// <summary>
        /// Test the Mail profile generation
        /// </summary>
        [TestMethod]
        public void TestMail() {
            var PersonalProfile = RegistrationPersonal.PersonalProfile;


            var MailProfile = new MailProfile(true);

            var ApplicationRegistration = RegistrationPersonal.Add(MailProfile);

            // Generate S/MIME certificates for account

            // Generate access blob for each device

            ApplicationRegistration.WriteToPortal();
            }


        /// <summary>
        /// Test the Mesh/Confirm profile generation
        /// </summary>
        [TestMethod]
        public void TestConfirm() {
            var PersonalProfile = RegistrationPersonal.PersonalProfile;

            var ConfirmProfile = new ConfirmProfile();
            var ApplicationRegistration = RegistrationPersonal.Add(ConfirmProfile);


            // Generate Keyset for this device

            // Add to application entry

            // Update
            ApplicationRegistration.WriteToPortal();
            }

        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestRecrypt() {
            var PersonalProfile = RegistrationPersonal.PersonalProfile;

            var RecryptProfile = new RecryptProfile();
            var ApplicationRegistration = RegistrationPersonal.Add(RecryptProfile);

            // Generate Keyset for this device

            // Add to application entry

            // Update
            ApplicationRegistration.WriteToPortal();
            }




        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestConnect1() {
            var BaseCatalog = NewCatalog();
            var MeshClient = new MeshClient(TestConstant.Service);
            var Registration = CreateAndRegister(BaseCatalog, MeshClient, TestConstant.Device1, TestConstant.Device1Description,
                TestConstant.AccountID);

            var Devs = new List<RegistrationPersonal>() {
                Registration,
                ConnectDevice(Registration, TestConstant.AccountID)
                };

            UT.Assert.IsTrue(Registration.PersonalProfile.Devices.Count == 2);
            var Personal2 = FromData(Registration.PersonalProfile);
            UT.Assert.IsTrue(Personal2.Devices.Count == 2);

            // Check that no applications are connected
            CheckApplications(Devs, 0);
            }

        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestConnect4() {
            var BaseCatalog = NewCatalog();
            var MeshClient = new MeshClient(TestConstant.Service);
            var Registration = CreateAndRegister(BaseCatalog, MeshClient, TestConstant.Device1, TestConstant.Device1Description,
                TestConstant.AccountID);

            var Devs = new List<RegistrationPersonal>() {
                                Registration,
                ConnectDevice(Registration, TestConstant.AccountID),
                ConnectDevice(Registration, TestConstant.AccountID),
                ConnectDevice(Registration, TestConstant.AccountID),
                ConnectDevice(Registration, TestConstant.AccountID)
                };

            CheckApplications(Devs, 0);
            }




        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestConnect1Apps() {
            var BaseCatalog = NewCatalog();
            var MeshClient = new MeshClient(TestConstant.Service);
            var Registration = CreateAndRegister(BaseCatalog, MeshClient, TestConstant.Device1, TestConstant.Device1Description,
                TestConstant.AccountID);

            var Devs = new List<RegistrationPersonal>() {
                Registration,
                ConnectDevice(Registration, TestConstant.AccountID)
                };

            // Check that no applications are connected
            CheckApplications(Devs, 0);

            ConnectApplications(Registration);

            // Check again
            CheckApplications(Devs, 1);
            }


        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestConnect4Apps() {
            var BaseCatalog = NewCatalog();
            var MeshClient = new MeshClient(TestConstant.Service);
            var Registration = CreateAndRegister(BaseCatalog, MeshClient, TestConstant.Device1, TestConstant.Device1Description,
                TestConstant.AccountID);

            var Devs = new List<RegistrationPersonal>() {
                Registration,
                ConnectDevice(Registration, TestConstant.AccountID),
                ConnectDevice(Registration, TestConstant.AccountID),
                };


            CheckApplications(Devs, 0);
            ConnectApplications(Registration);
            Devs.Add(ConnectDevice(Registration, TestConstant.AccountID));
            Devs.Add(ConnectDevice(Registration, TestConstant.AccountID));
            CheckApplications(Devs, 1);
            }


        PersonalProfile FromData(PersonalProfile PersonalProfile) {
            var Bytes = PersonalProfile.SignedPersonalProfile.GetBytes();
            return SignedPersonalProfile.FromJSON(Bytes.JSONReader()).PersonalProfile;
            }

        MeshCatalog NewCatalog() {
            var EmptyRegistration = new RegistrationMachineCached();
            return new MeshCatalog(EmptyRegistration);
            }


        RegistrationPersonal CreateAndRegister(string AccountID) {
            var BaseCatalog = NewCatalog();
            var MeshClient = new MeshClient(TestConstant.Service);
            return CreateAndRegister(BaseCatalog, MeshClient, "TestDevice",
                    "Just a test", AccountID);
            }

        RegistrationPersonal CreateAndRegister(MeshCatalog MeshCatalog, MeshClient MeshClient,
                    string DeviceID, string DeviceDescription, string AccountID) {

            var DeviceRegistration = MeshCatalog.GetDevice(DeviceNew: true,
                    DeviceID: DeviceID, DeviceDescription: DeviceDescription);

            var PersonalProfile1 = new PersonalProfile(DeviceRegistration.DeviceProfile);
            return MeshCatalog.CreateAccount(AccountID, PersonalProfile1, MeshClient);
            }

        /// <summary>
        /// Connect a simulated device.
        /// </summary>
        /// <param name="AdminClient">The administration client</param>
        /// <param name="AccountID">The account ID to bind to</param>
        /// <returns>The registration context for the new device.</returns>
        RegistrationPersonal ConnectDevice (RegistrationPersonal Admin, string AccountID) {


            var AdminClient = Admin.MeshClient;
            var DeviceCatalog = NewCatalog();
            var DeviceRegistration = MeshCatalog.GetDevice(DeviceNew: true,
                        DeviceID: TestConstant.Device2,
                        DeviceDescription: TestConstant.Device2Description);
            var Personal = DeviceRegistration.BeginConnect(AccountID);

            var Requests = AdminClient.ConnectPending();
            var Request = Requests.Match(DeviceRegistration.UDF);
            Admin.Confirm(Request);

            Personal.CompleteConnect();

            return Personal;
            }


        void ConnectApplications(RegistrationPersonal Personal) {

            }

        void CheckApplications(List<RegistrationPersonal> Personal, int Connected) {

            }


        }
    }
