#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using System;

using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;

namespace Goedel.XUnit;

public partial class TestPersist : UnitTestSet {



    /////<summary>Initialization property. Access this property to force initialization 
    /////of the static method.</summary>
    //public static object Initialize => null;

    //static TestPersist() {
    //    Cryptography.Cryptography.Initialize();
    //    _ = Goedel.XUnit.TestItem.Initialize;
    //    }FileTest



    public static TestPersist Test() => new();

    static readonly string FileTest = "TestStore.jcx";
    static readonly string AccountIDAlice = "alice@whatever";
    static readonly string AccountIDBob = "bob@whatever";
    static readonly string AccountIDInvalid = "invalid";

    // create new
    readonly static System.DateTime Now = System.DateTime.Now;
    readonly static TestItem AccountAlice = new() {
        AccountID = AccountIDAlice,
        Status = "Open",
        Created = Now,
        Modified = Now,
        UserProfileUDF = UDF.PresentationBase32(AccountIDAlice.ToBytes())
        };

    readonly static TestItem AccountBob = new() {
        AccountID = AccountIDBob,
        Status = "Open",
        Created = Now,
        Modified = Now,
        UserProfileUDF = UDF.PresentationBase32(AccountIDBob.ToBytes())
        };



    [Fact]
    public void TestPersistenceStoreCreate() {
        var filename = base.Seed.GetFilename(FileTest);

        using var TestStore = new TestItemContainerPersistenceStore(
        filename, "application/test", FileStatus: FileStatus.Overwrite);
        // retrieve by master key -fail
        AssertTest.TestFalse(TestStore.Contains(AccountIDAlice));
        }


    [Fact]
    public void TestPersistenceStoreAdd() {
        var filename = base.Seed.GetFilename(FileTest);

        using var TestStore = new TestItemContainerPersistenceStore(
        filename, "application/test", FileStatus: FileStatus.Overwrite);
        // retrieve by master key -fail
        AssertTest.TestFalse(TestStore.Contains(AccountIDAlice));
        (TestStore.Sequence.FrameCount == 1).TestTrue();


        TestStore.New(AccountAlice);

        (TestStore.Sequence.FrameCount == 2).TestTrue();


        AssertTest.TestTrue(TestStore.Contains(AccountIDAlice));
        AssertTest.TestFalse(TestStore.Contains(AccountIDInvalid));

        var AccountTest = TestStore.GetAccountID(AccountIDAlice);
        AssertTest.TestTrue(CheckEqual(AccountAlice, AccountTest));

        var AccountTest2 = TestStore.GetUserProfileUDF(AccountAlice.UserProfileUDF);
        AssertTest.TestTrue(CheckEqual(AccountAlice, AccountTest2));
        }


    [Fact]
    public void TestPersistenceStoreAll() {
        var filename = base.Seed.GetFilename(FileTest);

        using (var TestStore = new TestItemContainerPersistenceStore(
                filename, "application/test", FileStatus: FileStatus.Overwrite)) {
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
                filename, "application/test", FileStatus: FileStatus.Append)) {
            AssertTest.TestTrue(TestStore.Contains(AccountIDAlice));
            AssertTest.TestFalse(TestStore.Contains(AccountIDInvalid));

            var AccountTest = TestStore.GetAccountID(AccountIDAlice);
            AssertTest.TestTrue(CheckEqual(AccountAlice, AccountTest));

            var AccountTest2 = TestStore.GetUserProfileUDF(AccountAlice.UserProfileUDF);
            AssertTest.TestTrue(CheckEqual(AccountAlice, AccountTest2));

            }

        //Check we can read record back when opening the file in create or use existing mode
        using (var TestStore = new TestItemContainerPersistenceStore(filename)) {
            AssertTest.TestTrue(TestStore.Contains(AccountIDAlice));
            AssertTest.TestFalse(TestStore.Contains(AccountIDInvalid));

            var AccountTest = TestStore.GetAccountID(AccountIDAlice);
            AssertTest.TestTrue(CheckEqual(AccountAlice, AccountTest));
            }

        //Check we can read record back when opening the file in create or use existing mode
        using (var TestStore = new TestItemContainerPersistenceStore(filename)) {
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
        using (var TestStore = new TestItemContainerPersistenceStore(filename)) {
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

    static bool CheckEqual(TestItem v1, TestItem v2) {
        var t1 = (v1.AccountID == v2.AccountID);
        var t2 = (v1.Status == v2.Status);
        var t3 = (v1.Created.ToString() == v2.Created.ToString());
        var t4 = (v1.Modified.ToString() == v2.Modified.ToString());
        var t5 = (v1.UserProfileUDF == v2.UserProfileUDF);
        var Result = t1 & t2 & t3 & t4 & t5;

        return Result;
        }
    }
