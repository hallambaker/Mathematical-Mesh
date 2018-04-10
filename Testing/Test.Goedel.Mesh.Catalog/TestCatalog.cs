

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




    [TestClass]
    public class TestMail {

        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect () {

            InitializeClass();
            var Instance = new TestMail();

            Instance.CatalogCredential();

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


        //static SessionPersonal AlicePersonal;

        static SessionPersonal AliceMeshDevice1=null;
        static SessionPersonal AliceMeshDevice2=null;


        public static void InitializeClass () {

            //MeshConfirm.Initialize();

            //MakeUser(AliceAccountID, out AlicePersonal);
            }

        //static void MakeUser (string AccountID, out SessionPersonal SessionPersonal) {
        //    SessionPersonal = MeshProfiles.CreateAndRegister(AccountID);
        //    SessionPersonal.Write();
        //    }


        #endregion


        [TestMethod]
        public void CatalogCredential () {

            // create profile
            var CredentialProfile = new CredentialProfile() { };
            var CredentialSession = AliceMeshDevice1.Create(CredentialProfile);

            // add  entry
            var CatalogEntry = new CredentialEntry() {
                    Sites=new List<string>() { "Site"},
                    Password="First"};
            CredentialSession.Add(CatalogEntry);

            // get  entry
            var CredentialSession2 = AliceMeshDevice2.SessionCredential();
            var Result1 = CredentialSession.Get ("Site");


            // update  entry
            CatalogEntry.Password = "new";
            CredentialSession.Update(CatalogEntry);

            // get  entry
            var CredentialSession3 = AliceMeshDevice2.SessionCredential();
            var Result2 = CredentialSession.Get("Site");

            // delete entry - not found
            CredentialSession.Delete("Site");
            var Result3 = CredentialSession.Get("Site");

            throw new NYI();
            }


        [TestMethod]
        public void CatalogBookmark () {
            throw new NYI();
            // create profile

            // add  entry

            // get  entry

            // update  entry

            // get  entry

            // delete entry

            // not found
            }

        [TestMethod]
        public void CatalogContact () {
            throw new NYI();
            // create profile

            // add  entry

            // get  entry

            // update  entry

            // get  entry

            // delete entry

            // not found
            }

        [TestMethod]
        public void CatalogWiFi () {
            throw new NYI();
            // create profile

            // add  entry

            // get  entry

            // update  entry

            // get  entry

            // delete entry

            // not found
            }

        [TestMethod]
        public void CatalogVPN () {
            throw new NYI();
            // create profile

            // add  entry

            // get  entry

            // update  entry

            // get  entry

            // delete entry

            // not found
            }
        }
    }

