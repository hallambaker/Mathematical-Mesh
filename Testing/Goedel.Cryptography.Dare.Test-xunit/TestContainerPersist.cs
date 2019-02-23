using System;
using System.Text;
using System.Collections.Generic;
using Xunit;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.IO;

namespace Goedel.XUnit {
    public partial class TestDare {



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
        public void TestPersistenceStore () {
            using (var TestStore = new TestItemContainerPersistenceStore(
            FileTest, "application/test", "A testy store", FileStatus: FileStatus.Overwrite)) {
                // retrieve by master key -fail
                Utilities.Assert.False(TestStore.Contains(AccountIDAlice));
                TestStore.New(AccountAlice);

                Utilities.Assert.True(TestStore.Contains(AccountIDAlice));
                Utilities.Assert.False(TestStore.Contains(AccountIDInvalid));

                var AccountTest = TestStore.GetAccountID(AccountIDAlice);
                Utilities.Assert.True(CheckEqual(AccountAlice, AccountTest));

                var AccountTest2 = TestStore.GetUserProfileUDF(AccountAlice.UserProfileUDF);
                Utilities.Assert.True(CheckEqual(AccountAlice, AccountTest2));
                }

            //Check we can read record back when opening the file in create or use existing mode
            using (var TestStore = new TestItemContainerPersistenceStore(
                    FileTest, "application/test", "A testy store", FileStatus: FileStatus.Append)) {
                Utilities.Assert.True(TestStore.Contains(AccountIDAlice));
                Utilities.Assert.False(TestStore.Contains(AccountIDInvalid));

                var AccountTest = TestStore.GetAccountID(AccountIDAlice);
                Utilities.Assert.True(CheckEqual(AccountAlice, AccountTest));

                var AccountTest2 = TestStore.GetUserProfileUDF(AccountAlice.UserProfileUDF);
                Utilities.Assert.True(CheckEqual(AccountAlice, AccountTest2));

                }

            //Check we can read record back when opening the file in create or use existing mode
            using (var TestStore = new TestItemContainerPersistenceStore(FileTest)) {
                Utilities.Assert.True(TestStore.Contains(AccountIDAlice));
                Utilities.Assert.False(TestStore.Contains(AccountIDInvalid));

                var AccountTest = TestStore.GetAccountID(AccountIDAlice);
                Utilities.Assert.True(CheckEqual(AccountAlice, AccountTest));
                }

            //Check we can read record back when opening the file in create or use existing mode
            using (var TestStore = new TestItemContainerPersistenceStore(FileTest)) {
                // retrieve by master key -fail
                Utilities.Assert.False(TestStore.Contains(AccountIDBob));
                TestStore.New(AccountBob);

                Utilities.Assert.True(TestStore.Contains(AccountIDBob));
                Utilities.Assert.False(TestStore.Contains(AccountIDInvalid));

                var AccountTestA = TestStore.GetAccountID(AccountIDAlice);
                Utilities.Assert.True(CheckEqual(AccountAlice, AccountTestA));

                var AccountTestB = TestStore.GetAccountID(AccountIDBob);
                Utilities.Assert.True(CheckEqual(AccountBob, AccountTestB));
                }

            // Check we can delete an entry
            using (var TestStore = new TestItemContainerPersistenceStore(FileTest)) {
                // retrieve by master key -fail
                Utilities.Assert.True(TestStore.Contains(AccountIDBob));
                TestStore.Delete(AccountIDBob);

                Utilities.Assert.True(TestStore.Contains(AccountIDAlice));
                Utilities.Assert.False(TestStore.Contains(AccountIDBob));
                Utilities.Assert.False(TestStore.Contains(AccountIDInvalid));

                var AccountTestA = TestStore.GetAccountID(AccountIDAlice);
                Utilities.Assert.True(CheckEqual(AccountAlice, AccountTestA));

                var AccountTestB = TestStore.GetAccountID(AccountIDBob);
                Utilities.Assert.Null(AccountTestB);
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
