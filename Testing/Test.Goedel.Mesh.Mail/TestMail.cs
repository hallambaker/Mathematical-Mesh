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


    // Mail:
    // TTest: Add application to profile - Mail
    // TTest: Create S/MIME credential
    // TTest: Create CSR
    // TTest: Submit CSR, respond to challenge, retrieve cert
    // TTest: Create OpenPGP key
    // TTest: Create OpenPGP key and submit to MIT key servers

    [TestClass]
    public class TestMail {

        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect () {

            InitializeClass();
            var Instance = new TestMail();

            Instance.MailCreateSelfSigned();

            }


        #region // Initialization

        static string ServicePortalDNS = "portal.example.com";
        static string ServiceSSHDNS = "mail.example.com";

        static string IDAlice = $"AliceMail";



        static string IDPortalAlice = $"{IDAlice}@{ServicePortalDNS}";

        static string IDMailAlice = $"{IDAlice}@{ServiceSSHDNS}";

        static SessionPersonal AliceMeshDevice1=null;
        static SessionPersonal AliceMeshDevice2;

        //static MailProfile AliceMailProfile;
        static MeshProfiles MeshProfiles;

        public static void InitializeClass () {
            MeshProfiles = new MeshProfiles();


            //MakeUser(IDMailAlice, out AliceMeshDevice1);
            }

        //static void MakeUser (string AccountID, out SessionPersonal SessionPersonal) {
        //    //SessionPersonal = MeshProfiles.CreateAndRegister(AccountID);
        //    //SessionPersonal.Write();
        //    }


        #endregion


        [TestMethod]
        public void MailCreateSelfSigned () {
            // Add mail profile for account
            var AliceMailProfile = new MailProfile() { };

            var AliceMailSession = AliceMeshDevice1.Create(AliceMailProfile);
            MakeFiles("SelfSigned_", AliceMailSession);
            }


        [TestMethod]
        public void MailCreateSelfSignedConnect () {

            // Add mail profile for account
            var AliceMailProfile = new MailProfile() { };

            var AliceMailSession = AliceMeshDevice1.Create(AliceMailProfile);

            // Check S/Mime credential
            MakeFiles("SelfSigned_Device1", AliceMailSession);

            // Add second device
            AliceMeshDevice2 = MeshProfiles.ConnectDevice(AliceMeshDevice1, IDPortalAlice);

            var AliceMailSession2 = AliceMeshDevice2.SessionMail(IDMailAlice);

            // Check S/Mime credential
            MakeFiles("SelfSigned_Device2", AliceMailSession);

            }


        void MakeFiles (string Base, SessionMail SessionMail) {
            // Check S/Mime credential
            SessionMail.Export(Base + "PEMPrivate", KeyFileFormat.PEMPrivate, true);
            SessionMail.Export(Base + "PEMPublic", KeyFileFormat.PEMPublic, true);
            SessionMail.Export(Base + "X509DER", KeyFileFormat.X509DER, true);
            SessionMail.Export(Base + "PKCS12", KeyFileFormat.PKCS12, true);
            SessionMail.Export(Base + "PKCS7", KeyFileFormat.PKCS7, true);
            }


        [TestMethod]
        public void MailCreateCA () {

            throw new NYI();

            // Add mail profile for account

            // Check S/Mime credential

            // Check OpenPGP Credential

            // Add second device

            // Check S/Mime credential

            // Check OpenPGP Credential

            }


        }
    }
