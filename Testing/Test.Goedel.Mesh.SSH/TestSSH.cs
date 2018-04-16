
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
using Goedel.Cryptography.KeyFile;

namespace Goedel.Mesh.Mail.Test {

    // To make these tests feasible, it is going to be necessary to import keys from 
    // a file rather than generating new ones.


    [TestClass]
    public class TestMail {

        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect () {

            InitializeClass();
            var Instance = new TestMail();

            Instance.SSHTestSingleDevice();

            }


        #region // Initialization

        static TestConstant TestConstant = MeshProfiles.TestConstant;
        static MeshProfiles MeshProfiles = new MeshProfiles();

        [ClassInitialize]
        public static void InitializeClass (TestContext context) {
            InitializeClass();
            }

        static string ServicePortalDNS = "portal.example.com";
        static string ServiceSSHDNS = "ssh.example.com";

        static string IDAlice = $"AliceMail";



        static string IDPortalAlice = $"{IDAlice}@{ServicePortalDNS}";

        static string IDSSHAlice = $"{IDAlice}@{ServiceSSHDNS}";

        static SessionPersonal AliceMeshDevice1;
        //static SessionPersonal AliceMeshDevice2=null;

        static SessionPersonal ServerDevice=null;

        //static MailProfile AliceRecryptProfile;

        public static void InitializeClass () {

            //MeshConfirm.Initialize();

            MakeUser(IDSSHAlice, out AliceMeshDevice1);

            }

        static void MakeUser (string AccountID, out SessionPersonal SessionPersonal) {
            SessionPersonal = MeshProfiles.CreateAndRegister(AccountID);
            SessionPersonal.Write();
            }


        #endregion


        [TestMethod]
        public void SSHTestSingleDevice () {

            // Add ssh profile for account
            var AliceSSHProfile = new SSHProfile() { };

            var AliceSSHSession = AliceMeshDevice1.Create(AliceSSHProfile);

            // Export private key
            // Export public key
            AliceSSHSession.Export("SSH_Public", KeyFileFormat.OpenSSH, false );
            AliceSSHSession.Export("SSH_Private", KeyFileFormat.OpenSSH, true);
            AliceSSHSession.Export("PEM_Public", KeyFileFormat.PEMPublic, false);
            AliceSSHSession.Export("PEM_Private", KeyFileFormat.PEMPrivate, true);


            // Check expansion of authorized keys - blank base file
            ServerDevice.SSHExpand("file_1");

            // Check expansion of authorized keys - base file has existing entries
            ServerDevice.SSHExpand("file_2");

            // Rekey the profile
            AliceSSHSession.Rekey();

            // Check correct update 
            // Check expansion of authorized keys - blank base file
            ServerDevice.SSHExpand("file_1");

            // Check expansion of authorized keys - base file has existing entries
            ServerDevice.SSHExpand("file_2");

            throw new NYI();
            }


        [TestMethod]
        public void SSHTestMultiDevice () {
            throw new NYI();

            // Create a profile

            // Add second device


            // Check expansion of authorized keys - blank base file

            // Check expansion of authorized keys - base file has existing entries

            // Rekey first device

            // Check correct update 

            // Remove second device

            // Check correct update 

            }



        }
    }

