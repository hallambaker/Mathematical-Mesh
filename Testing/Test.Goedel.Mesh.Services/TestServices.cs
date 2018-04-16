using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Mesh;
using Goedel.Mesh.Platform;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Test.Common;
using Goedel.Mesh.Portal;
using Goedel.Mesh.Portal.Client;
using Goedel.Mesh.Portal.Server;
using Goedel.Test;

namespace Test.Goedel.Mesh {
    [TestClass]
    public class TestServices {

        static MeshMachine MeshCatalog => MeshMachine.Current;
        static TestConstant TestConstant = MeshProfiles.TestConstant;
        static MeshProfiles MeshProfiles = new MeshProfiles ();

        SessionPersonal RegistrationPersonal = null;

        /// <summary>
        /// 
        /// </summary>
        public static void TestServicesDirect () {

            InitializeClass();
            var TestServices = new TestServices();

            TestServices.TestConnect4();

            }


        [ClassInitialize]
        public static void InitializeClass (TestContext context) {
            InitializeClass();
            }

        public static void InitializeClass () {
            }


        [AssemblyCleanup]
        public static void Cleanup () {
            MeshCatalog.EraseTest();
            }

        /// <summary>
        /// It is not possible to perform more than one test simultaneously when testing the 
        /// per-account O/S integration. Thus unit testing does not work
        /// </summary>
        [TestMethod]
        public void CombinedTests () {
            MeshProfiles.NewDevice();
            MeshProfiles.NewPersonal();
            MeshProfiles.NewPersonal();
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
        public void TestEscrow() {
            var AccountID = TestConstant.AccountID.MakeUnique();

            var DeviceRegistration = MeshCatalog.GetDevice(DeviceNew: true,
                        DeviceID: TestConstant.Device1,
                        DeviceDescription: TestConstant.Device1Description);

            var PersonalProfile1 = new PersonalProfile(DeviceRegistration.DeviceProfile);
            var PersonalRegistration = MeshCatalog.CreateAccount(AccountID, PersonalProfile1);
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
            //var PersonalProfile = RegistrationPersonal.PersonalProfile;

            //var PasswordProfile = new PasswordProfile(true);
            ////var ApplicationProfileEntry = PersonalProfile.Add(PasswordProfile);

            //var ApplicationRegistration = RegistrationPersonal.Add(PasswordProfile);


            //PasswordProfile.Add("example.com", "alice", "secret");
            //PasswordProfile.Add("cnn.com", "alice1", "secret");
            //ApplicationRegistration.WriteToPortal();

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
            var PersonalRegistration = MeshProfiles.CreateAndRegister("TestSSH@example.com");

            var SSHProfile = new SSHProfile();
            var ApplicationRegistration = new SessionSSH(PersonalRegistration, SSHProfile);


            }

        /// <summary>
        /// Test the Mail profile generation
        /// </summary>
        [TestMethod]
        public void TestMail() {
            var PersonalProfile = RegistrationPersonal.PersonalProfile;


            var MailProfile = new MailProfile();


            var ApplicationRegistration = new SessionMail(RegistrationPersonal, MailProfile);

            // Generate S/MIME certificates for account

            // Generate access blob for each device

            ApplicationRegistration.WriteToPortal();
            }




        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestConnect1() {
            var AccountID = TestConstant.AccountID.MakeUnique();

            var BaseCatalog = MeshProfiles.NewCatalog();
            var MeshClient = new MeshClient(TestConstant.Service);
            var Registration = MeshProfiles.CreateAndRegister(BaseCatalog, MeshClient, 
                TestConstant.Device1, TestConstant.Device1Description,
                AccountID);

            var Devs = new List<SessionPersonal>() {
                Registration,
                MeshProfiles.ConnectDevice(Registration, AccountID)
                };

            UT.Assert.IsTrue(Registration.PersonalProfile.Devices.Count == 2);
            var Personal2 = MeshProfiles.FromData(Registration.PersonalProfile);
            UT.Assert.IsTrue(Personal2.Devices.Count == 2);

            // Check that no applications are connected
            MeshProfiles.CheckApplications(Devs, 0);
            }

        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestConnect4() {
            var AccountID = TestConstant.AccountID.MakeUnique();

            var BaseCatalog = MeshProfiles.NewCatalog();
            var MeshClient = new MeshClient(TestConstant.Service);
            var Registration = MeshProfiles.CreateAndRegister(BaseCatalog, MeshClient, 
                TestConstant.Device1, TestConstant.Device1Description,
                AccountID);

            var D1 = MeshProfiles.ConnectDevice(Registration, AccountID);
            var D2 = MeshProfiles.ConnectDevice(Registration, AccountID);
            var D3 = MeshProfiles.ConnectDevice(Registration, AccountID);
            var D4 = MeshProfiles.ConnectDevice(Registration, AccountID);

            var Devs = new List<SessionPersonal>() {
                                Registration, D1, D2, D3, D4
                };

            MeshProfiles.CheckApplications(Devs, 0);
            }




        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestConnect1Apps() {
            var AccountID = TestConstant.AccountID.MakeUnique();

            var BaseCatalog = MeshProfiles.NewCatalog();
            var MeshClient = new MeshClient(TestConstant.Service);
            var Registration = MeshProfiles.CreateAndRegister(BaseCatalog, MeshClient, 
                        TestConstant.Device1, TestConstant.Device1Description,
                        AccountID);

            var Devs = new List<SessionPersonal>() {
                Registration,
                MeshProfiles.ConnectDevice(Registration, AccountID)
                };

            // Check that no applications are connected
            MeshProfiles.CheckApplications(Devs, 0);

            MeshProfiles.ConnectApplications(Registration);

            // Check again
            MeshProfiles.CheckApplications(Devs, 1);
            }


        /// <summary>
        /// Test the Mesh/Recrypt profile generation
        /// </summary>
        [TestMethod]
        public void TestConnect4Apps() {
            var AccountID = TestConstant.AccountID.MakeUnique();

            var BaseCatalog = MeshProfiles.NewCatalog();
            var MeshClient = new MeshClient(TestConstant.Service);
            var Registration = MeshProfiles.CreateAndRegister(BaseCatalog, MeshClient, 
                        TestConstant.Device1, TestConstant.Device1Description,
                        AccountID);

            var Devs = new List<SessionPersonal>() {
                Registration,
                MeshProfiles.ConnectDevice(Registration, AccountID),
                MeshProfiles.ConnectDevice(Registration, AccountID),
                };


            MeshProfiles.CheckApplications(Devs, 0);
            MeshProfiles.ConnectApplications(Registration);
            Devs.Add(MeshProfiles.ConnectDevice(Registration, AccountID));
            Devs.Add(MeshProfiles.ConnectDevice(Registration, AccountID));
            MeshProfiles.CheckApplications(Devs, 1);
            }


        }
    }
