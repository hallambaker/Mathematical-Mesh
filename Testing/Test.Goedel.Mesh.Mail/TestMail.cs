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

            Instance.MailCreate();

            }


        #region // Initialization

        static MeshSession MeshCatalog => MeshProfiles.MeshCatalog;
        static TestConstant TestConstant = MeshProfiles.TestConstant;
        static MeshProfiles MeshProfiles = new MeshProfiles();

        [ClassInitialize]
        public static void InitializeClass (TestContext context) {
            InitializeClass();
            }

        static string AccountServiceDNS = "example.com";

        static string AliceAccountID = $"AliceRecrypt@{AccountServiceDNS}";
        static string BobAccountID = $"BobRecrypt@{AccountServiceDNS}";
        static string CarolAccountID = $"CarolRecrypt@{AccountServiceDNS}";


        static SessionPersonal AlicePersonal;
        static SessionPersonal BobPersonal;
        static SessionPersonal CarolPersonal;


        public static void InitializeClass () {

            //MeshConfirm.Initialize();

            MakeUser(AliceAccountID, out AlicePersonal);
            MakeUser(BobAccountID, out BobPersonal);
            MakeUser(CarolAccountID, out CarolPersonal);
            }

        static void MakeUser (string AccountID, out SessionPersonal SessionPersonal) {
            SessionPersonal = MeshProfiles.CreateAndRegister(AccountID);
            SessionPersonal.Write();
            }


        #endregion


        [TestMethod]
        public void MailCreate() {
            }
        }
    }
