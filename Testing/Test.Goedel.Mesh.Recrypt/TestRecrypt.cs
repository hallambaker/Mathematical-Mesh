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
using Goedel.Recrypt;
using Goedel.Recrypt.Client;
using Goedel.Recrypt.Server;
using Goedel.Account;
using Goedel.Account.Server;
using Goedel.Cryptography.Container;

namespace Test.Goedel.Mesh {



    // Recrypt:
    // TTest: Add application to profile - Recrypt
    // TTest: Create recryption set
    // TTest: Add user to recryption set
    // TTest: Delete user from recryption set
    // TTest: Encrypt directory under encryption key
    // TTest: Decrypt directory using recryption key set.

    [TestClass]
    public class TestRecrypt {

        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect () {

            InitializeClass();
            var Instance = new TestRecrypt();

            Instance.TestRecryption();

            }

        #region // Initialization


        static TestConstant TestConstant = MeshProfiles.TestConstant;
        static MeshProfiles MeshProfiles = new MeshProfiles();

        [ClassInitialize]
        public static void InitializeClass (TestContext context) {
            InitializeClass();
            }

        static string ServicePortalDNS = "portal.example.com";
        static string ServiceAccountDNS = "account.example.com";
        static string ServiceRecryptDNS = "recrypt.example.com";

        static string IDAlice           = $"AliceRecrypt";
        static string IDBob             = $"BobRecrypt";
        static string IDCarol           = $"CarolRecrypt";

        static string IDPortalAlice     = $"{IDAlice}@{ServicePortalDNS}";
        static string IDPortalBob       = $"{IDBob}@{ServicePortalDNS}";
        static string IDPortalCarol     = $"{IDCarol}@{ServicePortalDNS}";

        static string IDAccountAlice    = $"{IDAlice}@{ServiceAccountDNS}";
        static string IDAccountBob      = $"{IDBob}@{ServiceAccountDNS}";
        static string IDAccountCarol    = $"{IDCarol}@{ServiceAccountDNS}";



        static SessionPersonal AliceSessionPersonal;
        static SessionPersonal BobSessionPersonal;
        static SessionPersonal CarolSessionPersonal;

        public static void InitializeClass () {
            MeshRecrypt.Initialize();

            var AccountPortal = new AccountPortalDirect(ServiceRecryptDNS);
            global::Goedel.Account.AccountPortal.Default = AccountPortal;

            var RecryptPortal = new RecryptPortalDirect(ServiceRecryptDNS);
            global::Goedel.Recrypt.RecryptPortal.Default = RecryptPortal;


            //MeshConfirm.Initialize();

            MakeUser(IDPortalAlice, IDAccountAlice, out AliceSessionPersonal);
            MakeUser(IDPortalBob, IDAccountBob, out BobSessionPersonal);
            MakeUser(IDPortalCarol, IDAccountCarol, out CarolSessionPersonal);
            }

        static void MakeUser (string PortalID, string AccountID, out SessionPersonal SessionPersonal) {
            SessionPersonal = MeshProfiles.CreateAndRegister(PortalID);
            var Recrypt = SessionPersonal.CreateRecryptProfile(AccountID);

            SessionAccount.Create(SessionPersonal, AccountID,
                new List<string> { PortalID },
                new List<SignedApplicationProfile> { Recrypt.SignedApplicationProfile });

            }


        #endregion



        byte[] CreateBytes (int Length) => CryptoCatalog.GetBytes(Length);

        [TestMethod]
        public void TestEncryption () {
            var GroupName = $"recrypt1@{ServiceRecryptDNS}";
            var Filename = "recrypt_test_encrypt.jcx";
            var TestData = CreateBytes(10000);

            // Implement this as an extension method
            var AliceRecryptSession = AliceSessionPersonal.SessionRecryption(IDAccountAlice);

            // Create the recryption group

            var RecryptProfiles = new List<RecryptProfile>() { AliceRecryptSession.RecryptProfile };
            var Response = AliceRecryptSession.CreateGroup(GroupName);
            
            // Bob encrypts content 
            // specify 
            var BobRecryptSession = BobSessionPersonal.SessionRecryption(IDAccountBob);
            var RecryptionKey = BobSessionPersonal.GetEncryptionKey(GroupName);

            // The encryption is a method off the recryption key
            RecryptionKey.Encrypt(TestData, Filename);

            // Alice decrypts content
            using (var Reader = AliceSessionPersonal.DecryptReader(Filename)) {
                Reader.Read(out var ReadData, out var contentMeta);
                UT.Assert.IsTrue(ReadData.IsEqualTo(TestData));
                }
            }

        [TestMethod]
        public void TestRecryption () {
            var GroupName = $"recrypt2@{ServiceRecryptDNS}";
            var Filename = "recrypt_test_encrypt_2.jcx";
            var TestData = CreateBytes(2000);

            // Implement this as an extension method
            var AliceRecryptSession = AliceSessionPersonal.SessionRecryption(IDAccountAlice);

            // Create the recryption group
            var AliceGroup = AliceRecryptSession.CreateGroup(GroupName);

            // Bob encrypts content 
            // specify 
            var BobRecryptSession = BobSessionPersonal.SessionRecryption(IDAccountBob);
            var RecryptionKey = BobSessionPersonal.GetEncryptionKey(GroupName);

            // The encryption is a method off the recryption key
            RecryptionKey.Encrypt(TestData, Filename);

            // Alice decrypts content
                {
                AliceSessionPersonal.DecryptDARE(Filename, out var ReadData, out var contentMeta);
                UT.Assert.IsTrue(ReadData.IsEqualTo(TestData));
                }


            // var AliceGroup2 = AliceRecryptSession.FindGroup(GroupName);

            // Add Bob, test
            AliceRecryptSession.AddMember(AliceGroup, IDAccountBob);

                {
                BobSessionPersonal.RecryptDARE(Filename, out var ReadData, out var contentMeta);
                UT.Assert.IsTrue(ReadData.IsEqualTo(TestData));
                }

            // Add Carol, test
            AliceRecryptSession.AddMember(AliceGroup, IDAccountCarol);

                {
                CarolSessionPersonal.RecryptDARE(Filename, out var ReadData, out var contentMeta);
                UT.Assert.IsTrue(ReadData.IsEqualTo(TestData));
                }


            // Remove Carol, test
            AliceRecryptSession.RemoveMember(AliceGroup, IDAccountCarol);

            // check Alice can decrypt
                {
                AliceSessionPersonal.DecryptDARE(Filename, out var ReadData, out var contentMeta);
                UT.Assert.IsTrue(ReadData.IsEqualTo(TestData));
                }


            // check Bob can decrypt
                {
                BobSessionPersonal.DecryptDARE(Filename, out var ReadData, out var contentMeta);
                UT.Assert.IsTrue(ReadData.IsEqualTo(TestData));
                }


            }


        [TestMethod]
        [ExpectedException (typeof(AccessRefused))]
        public void TestRecryptionAuthorizationWithdrawn () {
            var GroupName = "recrypt3@example.com";
            var Filename = "recrypt_test_encrypt_3.jcx";
            var TestData = CreateBytes(2000);

            // Implement this as an extension method
            var AliceRecryptSession = AliceSessionPersonal.SessionRecryption(IDAccountAlice);

            // Create the recryption group
            var AliceGroup = AliceRecryptSession.CreateGroup(GroupName);

            // Bob encrypts content 
            // specify 
            var BobRecryptSession = BobSessionPersonal.SessionRecryption(IDAccountBob);
            var RecryptionKey = BobSessionPersonal.GetEncryptionKey(GroupName);

            // The encryption is a method off the recryption key
            RecryptionKey.Encrypt(TestData, Filename);


            // Add Bob, test
            AliceRecryptSession.AddMember(AliceGroup, IDAccountBob);
            // Add Carol, test
            AliceRecryptSession.AddMember(AliceGroup, IDAccountCarol);

            AliceRecryptSession.RemoveMember(AliceGroup, IDAccountCarol);

            // check Carol cannot decrypt
            using (var Reader = CarolSessionPersonal.DecryptReader(Filename)) {
                Reader.Read(out var ReadData, out var contentMeta);
                }

            }

        [TestMethod]
        [ExpectedException(typeof(NoAvailableDecryptionKey))]
        public void FailRecryptionNeverAuthorized() {
            var GroupName = "recrypt3@example.com";
            var Filename = "recrypt_test_encrypt_3.jcx";
            var TestData = CreateBytes(2000);

            // Implement this as an extension method
            var AliceRecryptSession = AliceSessionPersonal.SessionRecryption(IDAccountAlice);

            // Create the recryption group
            var Response = AliceRecryptSession.CreateGroup(GroupName);

            // Bob encrypts content 
            // specify 
            var BobRecryptSession = BobSessionPersonal.SessionRecryption(IDAccountBob);
            var RecryptionKey = BobSessionPersonal.GetEncryptionKey(GroupName);

            // The encryption is a method off the recryption key
            RecryptionKey.Encrypt(TestData, Filename);

            // check Carol cannot decrypt
            using (var Reader = CarolSessionPersonal.DecryptReader(Filename)) {
                Reader.Read(out var ReadData, out var contentMeta);

                }

            }

        }
    }
