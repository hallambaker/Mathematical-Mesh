using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Test;
using Goedel.Test.Core;
using Goedel.Utilities;

using System;

using Xunit;

namespace Goedel.XUnit {
    public partial class TestPersist {



        ///<summary>Initialization property. Access this property to force initialization 
        ///of the static method.</summary>
        public static object Initialize => null;

        static TestPersist() {
            Cryptography.Cryptography.Initialize();
            _ = Goedel.XUnit.TestItem.Initialize;
            }



        public TestPersist() => TestEnvironmentCommon.Initialize(true);
        public static TestPersist Test() => new TestPersist();

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
            UserProfileUDF = UDF.PresentationBase32(AccountIDAlice.ToBytes())
            };

        readonly static TestItem AccountBob = new TestItem() {
            AccountID = AccountIDBob,
            Status = "Open",
            Created = Now,
            Modified = Now,
            UserProfileUDF = UDF.PresentationBase32(AccountIDBob.ToBytes())
            };



        [Fact]
        public void TestPersistenceStoreCreate() {
            using var TestStore = new TestItemContainerPersistenceStore(
            FileTest, "application/test", "A testy store", FileStatus: FileStatus.Overwrite);
            // retrieve by master key -fail
            AssertTest.TestFalse(TestStore.Contains(AccountIDAlice));
            }


        [Fact]
        public void TestPersistenceStoreAdd() {
            using var TestStore = new TestItemContainerPersistenceStore(
            FileTest, "application/test", "A testy store", FileStatus: FileStatus.Overwrite);
            // retrieve by master key -fail
            AssertTest.TestFalse(TestStore.Contains(AccountIDAlice));
            (TestStore.Container.FrameCount == 1).TestTrue();


            TestStore.New(AccountAlice);

            (TestStore.Container.FrameCount == 2).TestTrue();


            AssertTest.TestTrue(TestStore.Contains(AccountIDAlice));
            AssertTest.TestFalse(TestStore.Contains(AccountIDInvalid));

            var AccountTest = TestStore.GetAccountID(AccountIDAlice);
            AssertTest.TestTrue(CheckEqual(AccountAlice, AccountTest));

            var AccountTest2 = TestStore.GetUserProfileUDF(AccountAlice.UserProfileUDF);
            AssertTest.TestTrue(CheckEqual(AccountAlice, AccountTest2));
            }


        [Fact]
        public void TestPersistenceStoreAll() {
            using (var TestStore = new TestItemContainerPersistenceStore(
            FileTest, "application/test", "A testy store", FileStatus: FileStatus.Overwrite)) {
                // retrieve by master key -fail
                AssertTest.TestFalse(TestStore.Contains(AccountIDAlice));
                TestStore.New(AccountAlice);

                AssertTest.TestTrue(TestStore.Contains(AccountIDAlice));
                AssertTest.TestFalse(TestStore.Contains(AccountIDInvalid));

                var AccountTest = TestStore.GetAccountID(AccountIDAlice);
                AssertTest.TestTrue(CheckEqual(AccountAlice, AccountTest));

                var AccountTest2 = TestStore.GetUserProfileUDF(AccountAlice.UserProfileUDF);
                AssertTest.TestTrue(CheckEqual(AccountAlice, AccountTest2));
                }

            //Check we can read record back when opening the file in create or use existing mode
            using (var TestStore = new TestItemContainerPersistenceStore(
                    FileTest, "application/test", "A testy store", FileStatus: FileStatus.Append)) {
                AssertTest.TestTrue(TestStore.Contains(AccountIDAlice));
                AssertTest.TestFalse(TestStore.Contains(AccountIDInvalid));

                var AccountTest = TestStore.GetAccountID(AccountIDAlice);
                AssertTest.TestTrue(CheckEqual(AccountAlice, AccountTest));

                var AccountTest2 = TestStore.GetUserProfileUDF(AccountAlice.UserProfileUDF);
                AssertTest.TestTrue(CheckEqual(AccountAlice, AccountTest2));

                }

            //Check we can read record back when opening the file in create or use existing mode
            using (var TestStore = new TestItemContainerPersistenceStore(FileTest)) {
                AssertTest.TestTrue(TestStore.Contains(AccountIDAlice));
                AssertTest.TestFalse(TestStore.Contains(AccountIDInvalid));

                var AccountTest = TestStore.GetAccountID(AccountIDAlice);
                AssertTest.TestTrue(CheckEqual(AccountAlice, AccountTest));
                }

            //Check we can read record back when opening the file in create or use existing mode
            using (var TestStore = new TestItemContainerPersistenceStore(FileTest)) {
                // retrieve by master key -fail
                AssertTest.TestFalse(TestStore.Contains(AccountIDBob));
                TestStore.New(AccountBob);

                AssertTest.TestTrue(TestStore.Contains(AccountIDBob));
                AssertTest.TestFalse(TestStore.Contains(AccountIDInvalid));

                var AccountTestA = TestStore.GetAccountID(AccountIDAlice);
                AssertTest.TestTrue(CheckEqual(AccountAlice, AccountTestA));

                var AccountTestB = TestStore.GetAccountID(AccountIDBob);
                AssertTest.TestTrue(CheckEqual(AccountBob, AccountTestB));
                }

            // Check we can delete an entry
            using (var TestStore = new TestItemContainerPersistenceStore(FileTest)) {
                // retrieve by master key -fail
                AssertTest.TestTrue(TestStore.Contains(AccountIDBob));
                TestStore.Delete(AccountIDBob);

                AssertTest.TestTrue(TestStore.Contains(AccountIDAlice));
                AssertTest.TestFalse(TestStore.Contains(AccountIDBob));
                AssertTest.TestFalse(TestStore.Contains(AccountIDInvalid));

                var AccountTestA = TestStore.GetAccountID(AccountIDAlice);
                AssertTest.TestTrue(CheckEqual(AccountAlice, AccountTestA));

                var AccountTestB = TestStore.GetAccountID(AccountIDBob);

                AccountTestB.TestNull();
                }


            }


        bool CheckEqual(TestItem v1, TestItem v2) {
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
