using System;
using System.Text;
using System.Collections.Generic;
using MT = Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.IO;
using Test.Goedel.Mesh;

namespace Test.Goedel.Cryptography.Container {
    [MT.TestClass]
    public partial class TestDare {

        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect () {
            InitializeClass();
            var Instance = new TestDare();
            Instance.MessagePlaintext();
            }

        [MT.AssemblyInitialize]
        public static void Initialize (MT.TestContext Context) {
            InitializeClass();
            }

        public static void InitializeClass () {
            CryptographyWindows.Initialize();
            }


        static string FileTest = "TestStore.jcx";
        static string AccountIDAlice = "alice@whatever";
        static string AccountIDBob = "bob@whatever";
        static string AccountIDInvalid = "invalid";

        // create new
        readonly static DateTime Now = DateTime.Now;
        readonly static TestItem AccountAlice = new TestItem() {
            AccountID = AccountIDAlice,
            Status = "Open",
            Created = Now,
            Modified = Now,
            UserProfileUDF = AccountIDAlice.ToBytes().ToStringUDF32()
            };

        readonly static TestItem AccountBob = new TestItem() {
            AccountID = AccountIDBob,
            Status = "Open",
            Created = Now,
            Modified = Now,
            UserProfileUDF = AccountIDBob.ToBytes().ToStringUDF32()
            };

        [MT.TestMethod]
        public void TestPersistenceStore () {
            using (var TestStore = new TestItemContainerPersistenceStore(
            FileTest, "application/test", "A testy store", FileStatus: FileStatus.Overwrite)) {
                // retrieve by master key -fail
                Assert.False(TestStore.Contains(AccountIDAlice));
                TestStore.New(AccountAlice);

                Assert.True(TestStore.Contains(AccountIDAlice));
                Assert.False(TestStore.Contains(AccountIDInvalid));

                var AccountTest = TestStore.GetAccountID(AccountIDAlice);
                Assert.True(CheckEqual(AccountAlice, AccountTest));

                var AccountTest2 = TestStore.GetUserProfileUDF(AccountAlice.UserProfileUDF);
                Assert.True(CheckEqual(AccountAlice, AccountTest2));
                }

            //Check we can read record back when opening the file in create or use existing mode
            using (var TestStore = new TestItemContainerPersistenceStore(
                    FileTest, "application/test", "A testy store", FileStatus: FileStatus.Append)) {
                Assert.True(TestStore.Contains(AccountIDAlice));
                Assert.False(TestStore.Contains(AccountIDInvalid));

                var AccountTest = TestStore.GetAccountID(AccountIDAlice);
                Assert.True(CheckEqual(AccountAlice, AccountTest));

                var AccountTest2 = TestStore.GetUserProfileUDF(AccountAlice.UserProfileUDF);
                Assert.True(CheckEqual(AccountAlice, AccountTest2));

                }

            //Check we can read record back when opening the file in create or use existing mode
            using (var TestStore = new TestItemContainerPersistenceStore(FileTest)) {
                Assert.True(TestStore.Contains(AccountIDAlice));
                Assert.False(TestStore.Contains(AccountIDInvalid));

                var AccountTest = TestStore.GetAccountID(AccountIDAlice);
                Assert.True(CheckEqual(AccountAlice, AccountTest));
                }

            //Check we can read record back when opening the file in create or use existing mode
            using (var TestStore = new TestItemContainerPersistenceStore(FileTest)) {
                // retrieve by master key -fail
                Assert.False(TestStore.Contains(AccountIDBob));
                TestStore.New(AccountBob);

                Assert.True(TestStore.Contains(AccountIDBob));
                Assert.False(TestStore.Contains(AccountIDInvalid));

                var AccountTestA = TestStore.GetAccountID(AccountIDAlice);
                Assert.True(CheckEqual(AccountAlice, AccountTestA));

                var AccountTestB = TestStore.GetAccountID(AccountIDBob);
                Assert.True(CheckEqual(AccountBob, AccountTestB));
                }

            // Check we can delete an entry
            using (var TestStore = new TestItemContainerPersistenceStore(FileTest)) {
                // retrieve by master key -fail
                Assert.True(TestStore.Contains(AccountIDBob));
                TestStore.Delete(AccountIDBob);

                Assert.True(TestStore.Contains(AccountIDAlice));
                Assert.False(TestStore.Contains(AccountIDBob));
                Assert.False(TestStore.Contains(AccountIDInvalid));

                var AccountTestA = TestStore.GetAccountID(AccountIDAlice);
                Assert.True(CheckEqual(AccountAlice, AccountTestA));

                var AccountTestB = TestStore.GetAccountID(AccountIDBob);
                Assert.Null(AccountTestB);
                }


            }


        bool CheckEqual (TestItem v1, TestItem v2) {
            var t1 = (v1.AccountID == v2.AccountID);
            var t2 = (v1.Status == v2.Status);
            var t3 = (v1.Created.ToString() == v2.Created.ToString());
            var t4 = (v1.Modified.ToString() == v2.Modified.ToString());
            var t5 = (v1.UserProfileUDF == v2.UserProfileUDF);
            var Result = t1 & t2 & t3 & t4 & t5;

            return Result;
            }
        }
    }
