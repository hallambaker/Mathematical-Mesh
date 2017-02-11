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


            //DeviceProfile = new DeviceProfile(TestConstant.Device1, TestConstant.Device1Description);
            //PersonalProfile = new PersonalProfile(DeviceProfile);

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
            var PersonalRegistration = MeshCatalog.AddPersonal(TestConstant.AccountID, PersonalProfile1);

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
            var PersonalRegistration = MeshCatalog.AddPersonal(TestConstant.AccountID, PersonalProfile1);

            UT.Assert.IsNotNull(PersonalRegistration);
            UT.Assert.IsNotNull(PersonalRegistration.SignedPersonalProfile);


            // Push the update(s) to the portal.
            PersonalRegistration.Update();


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

            MeshCatalog.Recover(TestConstant.AccountID, RecoveryKey);

            // NYI: add the assertions here.

            }


        /// <summary>
        /// Test the Web profile generation
        /// </summary>
        [TestMethod]
        public void TestWeb () {
            var PersonalProfile = RegistrationPersonal.PersonalProfile;

            var PasswordProfile = new PasswordProfile(true);
            //var ApplicationProfileEntry = PersonalProfile.Add(PasswordProfile);

            var ApplicationRegistration = RegistrationPersonal.Add(PasswordProfile, Delay: true);


            PasswordProfile.Add("example.com", "alice", "secret");
            PasswordProfile.Add("cnn.com", "alice1", "secret");
            ApplicationRegistration.Update();

            TestPasswordAdd(PasswordProfile.UDF);
            TestPasswordDelete(PasswordProfile.UDF);
            TestPasswordRead(PasswordProfile.UDF);
            }

        string TestSite1 = "blog.example.com";
        string TestSite2 = "news.example.net";

        void TestPasswordAdd (string UDF) {
            var ApplicationRegistration = MeshCatalog.GetApplication(UDF);
            var PasswordProfile = ApplicationRegistration.ApplicationProfile as PasswordProfile;
            UT.Assert.IsNotNull(PasswordProfile);

            PasswordProfile.Add(TestSite1, "alice", "secret");
            PasswordProfile.Add(TestSite2, "alice1", "secret");
            ApplicationRegistration.Update();
            }

        void TestPasswordDelete(string UDF) {
            var ApplicationRegistration = MeshCatalog.GetApplication(UDF);
            var PasswordProfile = ApplicationRegistration.ApplicationProfile as PasswordProfile;
            UT.Assert.IsNotNull(PasswordProfile);

            string Username, Password;
            PasswordEntry Found;
            Found = PasswordProfile.GetEntry(TestSite1, out Username, out Password);

            PasswordProfile.Delete(TestSite1);
            Found = PasswordProfile.GetEntry(TestSite1, out Username, out Password);

            Found = PasswordProfile.GetEntry(TestSite2, out Username, out Password);
            PasswordProfile.Add(TestSite2, "alice1", "secret2");
            ApplicationRegistration.Update();
            }

        void TestPasswordRead(string UDF) {
            var ApplicationRegistration = MeshCatalog.GetApplication(UDF);
            var PasswordProfile = ApplicationRegistration.ApplicationProfile as PasswordProfile;
            UT.Assert.IsNotNull(PasswordProfile);

            string Username, Password;
            PasswordEntry Found;

            Found = PasswordProfile.GetEntry(TestSite1, out Username, out Password);
            Found = PasswordProfile.GetEntry(TestSite2, out Username, out Password);

            }


        /// <summary>
        /// Test the SSH profile generation
        /// </summary>
        [TestMethod]
        public void TestSSH() {
            var PersonalProfile = RegistrationPersonal.PersonalProfile;

            var SSHProfile = new SSHProfile();
            var ApplicationRegistration = RegistrationPersonal.Add(SSHProfile, Delay:true);

            // Create key for each device in the profile


            // Generate the authorized hosts entry for this profile

            ApplicationRegistration.Update();
            }

        /// <summary>
        /// Test the Mail profile generation
        /// </summary>
        [TestMethod]
        public void TestMail() {
            var PersonalProfile = RegistrationPersonal.PersonalProfile;


            var MailProfilePrivate = new MailProfilePrivate(TestConstant.MailAccountInfoAlice);
            var MailProfile = new MailProfile(MailProfilePrivate);

            var ApplicationRegistration = RegistrationPersonal.Add(MailProfile, Delay: true);

            // Generate S/MIME certificates for account

            // Generate access blob for each device

            ApplicationRegistration.Update();
            }


        /// <summary>
        /// Test the Mesh/Confirm profile generation
        /// </summary>
        [TestMethod]
        public void TestConfirm() {
            var PersonalProfile = RegistrationPersonal.PersonalProfile;

            var ConfirmProfile = new ConfirmProfile();
            var ApplicationRegistration = RegistrationPersonal.Add(ConfirmProfile, Delay: true);


            // Generate Keyset for this device

            // Add to application entry

            // Update
            ApplicationRegistration.Update();
            }

        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestRecrypt() {
            var PersonalProfile = RegistrationPersonal.PersonalProfile;

            var RecryptProfile = new RecryptProfile();
            var ApplicationRegistration = RegistrationPersonal.Add(RecryptProfile, Delay: true);

            // Generate Keyset for this device

            // Add to application entry

            // Update
            ApplicationRegistration.Update();
            }


        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestConnect1() {
            // Get the registration. Note that it will be automatically registered with the
            // corresponding portal when we complete.
            var Registration = MeshCatalog.AddPersonal(TestConstant.AccountID, DeviceNew: true,
                        DeviceID: TestConstant.Device1,
                        DeviceDescription: TestConstant.Device1Description);
            ConnectDevice(Registration);
            }

        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestConnect4() {
            // Get the registration. Note that it will be automatically registered with the
            // corresponding portal when we complete.
            var Registration = MeshCatalog.AddPersonal(TestConstant.AccountID, DeviceNew: true,
                        DeviceID: TestConstant.Device1,
                        DeviceDescription: TestConstant.Device1Description);
            ConnectDevice(Registration);
            ConnectDevice(Registration);
            ConnectDevice(Registration);
            ConnectDevice(Registration);
            }



        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestConnect0Apps() {
            // Get the registration. Note that it will be automatically registered with the
            // corresponding portal when we complete.
            var Registration = MeshCatalog.AddPersonal(TestConstant.AccountID, DeviceNew: true,
                        DeviceID: TestConstant.Device1,
                        DeviceDescription: TestConstant.Device1Description);
            ConnectDevice(Registration);
            CheckApplications(Registration, 0);
            }


        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestConnect1Apps() {
            // Get the registration. Note that it will be automatically registered with the
            // corresponding portal when we complete.
            var Registration = MeshCatalog.AddPersonal(TestConstant.AccountID, DeviceNew: true,
                        DeviceID: TestConstant.Device1,
                        DeviceDescription: TestConstant.Device1Description);
            ConnectDevice(Registration);
            ConnectApplications(Registration);
            CheckApplications(Registration, 1);
            }


        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestConnect1AppsPost() {
            // Get the registration. Note that it will be automatically registered with the
            // corresponding portal when we complete.
            var Registration = MeshCatalog.AddPersonal(TestConstant.AccountID, DeviceNew: true,
                        DeviceID: TestConstant.Device1,
                        DeviceDescription: TestConstant.Device1Description);
            ConnectApplications(Registration);
            ConnectDevice(Registration);
            CheckApplications(Registration, 1);
            }


        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestConnect4Apps() {
            // Get the registration. Note that it will be automatically registered with the
            // corresponding portal when we complete.
            var Registration = MeshCatalog.AddPersonal(TestConstant.AccountID, DeviceNew: true,
                        DeviceID: TestConstant.Device1,
                        DeviceDescription: TestConstant.Device1Description);
            ConnectDevice(Registration);
            ConnectDevice(Registration);
            ConnectApplications(Registration);
            ConnectDevice(Registration);
            ConnectDevice(Registration);
            CheckApplications(Registration, 4);
            }


        void ConnectDevice (RegistrationPersonal Personal) {

            }


        void ConnectApplications(RegistrationPersonal Personal) {

            }

        void CheckApplications(RegistrationPersonal Personal, int Connected) {

            }


        }
    }
