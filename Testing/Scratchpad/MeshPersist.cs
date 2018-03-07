using System;
using System.Text;
using System.Collections.Generic;
using Goedel.Cryptography.Container;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Framework;
using Goedel.Cryptography.KeyFile;
using Goedel.IO;
using Goedel.Utilities;
using Goedel.Test;
using Goedel.Mesh.Portal.Server;
using Test.Goedel.Mesh;

namespace Scratchpad {



    partial class Program {


        public void Go () {
            // Test persistence store for Portal Accounts

            // Create new
            var MeshPersist = new MeshPersist("example.com");

            // Check for existence of 'alice@example.com' - should fail
            Assert.False(MeshPersist.CheckAccount(AccountAlice));


            // Create alice 
            var DeviceProfile = new DeviceProfile("testDevice", "A testy Device");
            var PersonalProfile = new PersonalProfile(DeviceProfile);
            MeshPersist.CreateAccount(AccountAlice, PersonalProfile.SignedPersonalProfile);
            
            // check for alice - should succeed
            Assert.True(MeshPersist.CheckAccount(AccountAlice));

            // check for bob - should fail
            Assert.False(MeshPersist.CheckAccount(AccountBob));

            MeshPersist.DeleteAccount(AccountAlice);
            Assert.False(MeshPersist.CheckAccount(AccountAlice));

            MeshPersist.CreateAccount(AccountAlice, PersonalProfile.SignedPersonalProfile);
            Assert.True(MeshPersist.CheckAccount(AccountAlice));

            // update alice

            var DeviceProfile2 = new DeviceProfile("testDevice2", "Another testy Device");
            PersonalProfile.Add(DeviceProfile2);
            MeshPersist.UpdateProfile(PersonalProfile);

            // check update
            var TestProfile = MeshPersist.GetPersonalProfile(AccountAlice);
            // ToDo: check these are actually equal.

            // create bob
            var DeviceProfileBob = new DeviceProfile("testDevice", "A testy Device");
            var PersonalProfileBob = new PersonalProfile(DeviceProfileBob);
            MeshPersist.CreateAccount(AccountBob, PersonalProfileBob.SignedPersonalProfile);

            // check for bob - should succeed
            Assert.True(MeshPersist.CheckAccount(AccountBob));

            // check alice
            Assert.True(MeshPersist.CheckAccount(AccountAlice));

            }


        public void Go2 () {
            // Test our persistence store.

            var FileTest = "TestStore.jcx";
            var AccountIDAlice = "alice@whatever";
            var AccountIDBob = "bob@whatever";
            var AccountIDInvalid = "invalid";

            // create new
            var Now = DateTime.Now;
            var AccountAlice = new TestItem() {
                AccountID = AccountIDAlice,
                Status = "Open",
                Created = Now,
                Modified = Now,
                UserProfileUDF = AccountIDAlice.ToBytes().ToUDF32String()
                };

            var AccountBob = new TestItem() {
                AccountID = AccountIDBob,
                Status = "Open",
                Created = Now,
                Modified = Now,
                UserProfileUDF = AccountIDBob.ToBytes().ToUDF32String()
                };

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

        public void CheckContainer (string FileName, byte[] Constant = null, KeyPair Encrypt = null) {

            using (var FileStream = FileName.FileStream(FileStatus.Read)) {

                var JBCDStream = new JBCDStreamDebug(FileStream) { Active = true };

                var Container = Goedel.Cryptography.Container.Container.OpenExisting(JBCDStream);

                Console.WriteLine("--Container Header--");
                Console.WriteLine(Container.ContainerHeaderFirst.ToString());

                JBCDStream.Active = true;
                Container.First();
                while (!Container.EOF) {

                    Console.WriteLine("--Header--");
                    Console.WriteLine(Container.ContainerHeader.ToString());

                    if (Container.FrameData != null) {
                        Console.WriteLine($"--Data-- [{Container.FrameData.Length} bytes]");
                        }

                    Console.WriteLine("---End Frame---");
                    Console.WriteLine("");
                    Container.Next();
                    }


                }
            }



        public void TestPersistence () {

            var Container = new ContainerPersistenceStore("test1", "application/mmm-portal", "Testy test container");

            var PortalEntry = new Account() {
                Created = DateTime.Now,
                AccountID = "Alice@example.com",
                Status = "Bogus"
                };


            Container.New(PortalEntry);
            }


        }
    }
