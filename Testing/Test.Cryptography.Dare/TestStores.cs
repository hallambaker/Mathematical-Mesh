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


using Goedel.Cryptography.Dare;
using Goedel.Test;
using Goedel.Mesh;
using System.Diagnostics;
using Xunit;
using System.Drawing;

namespace Goedel.XUnit;


public enum TestStoreType {

    Spool,

    Catalog

    }


public record TestStoreParams(
            int Records = 1, 
            int Length = 100, 
            bool Randomsize = true,
            int RandomChecks = 0, 
            int AdditionalChunks = 0,
            int Updates = 0,
            bool MakeCopy = false) {

    public override string ToString() {
        return $"{Records}-{Length}-{Randomsize}-{RandomChecks}-{AdditionalChunks}-{Updates}-{MakeCopy}";
        }


    }


public partial class TestStores {

    public static TestStores Test() => new();


    [Theory]
    [InlineData(null)]
    public void TestSpoolBasic(
            TestStoreParams testParams = null) {
        testParams ??= new();

        var seed = DeterministicSeed.AutoClean(testParams);
        var context = new TestContext(seed);
        var testStore = new TestSpool(context, testParams);

        // Create testStore, add initial messages and verify while open.
            {
            using var spool = testStore.Create();
            AddItems(testStore, spool);
            }

        Exercise(testStore);
        }

    [Theory]
    [InlineData(null)]
    public void TestCatalogBasic(
        TestStoreParams testParams = null) {
        testParams ??= new();

        var seed = DeterministicSeed.AutoClean(testParams);
        var context = new TestContext(seed);
        var testStore = new TestCatalog(context, testParams);

        // Create testStore, add initial messages and verify while open.
            {
            using var spool = testStore.Create();
            AddItems(testStore, spool);
            }

        Exercise(testStore);
        }


    #region // Static test routines

    static void Exercise(
                TestBaseStore testStore) {
        var testParams = testStore.TestParams;

        // [optional] Sync to the shaddow copy using direct access
        VerifyRandom(testStore);


        // [optional] Perform checks on randomly chosen messages in the testStore.
        Sync(testStore);

        // [optional] Add in additional chunks
        for (var j = 0; j < testParams.AdditionalChunks; j++) {
            using var spool = testStore.Open();

            AddItems(testStore, spool);

            // [optional] SetStatus status on sets of randomly chosen messages.
            Update(testStore, spool, j);

            testStore.Verify(spool, false);

            // [optional] Sync to the shaddow copy using direct access
            Sync(testStore);
            }
        }

    static void Sync(TestBaseStore testStore) {
        if (testStore.TestParams.MakeCopy) {
            using var copy = testStore.SyncCopy();
            testStore.Verify(copy, false);
            }
        }

    static void VerifyRandom(TestBaseStore testStore, int group = 0) {
        for (var i = 0; i < testStore.TestParams.RandomChecks; i++) {
            testStore.VerifyRandom(i, group);
            }
        }

    static void Update(TestBaseStore testStore, Store store, int group = 0) {
        for (var i = 0; i < testStore.TestParams.RandomChecks; i++) {
            testStore.Update(store, i, group);
            }
        }

    static void AddItems(TestBaseStore testStore, Store store) {
        for (var i = 0; i < testStore.TestParams.Records; i++) {
            testStore.AddItem(store);
            }
        testStore.Verify(store);
        } 
    #endregion
    }