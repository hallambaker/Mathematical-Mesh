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
using Goedel.Mesh;
using Goedel.Test;
using System.IO;

namespace Goedel.XUnit;

public abstract record TestBase {
    public DeterministicSeed Seed => TestContext.Seed;
    public TestContext TestContext { get; }

    public TestBase(TestContext context) {
        TestContext = context;
        }
    }



public abstract record TestBaseStore: TestBase {


    public TestStoreParams TestParams { get; }

    public ReferenceStore ReferenceStore { get; }

    public string Directory { get; }

    public TestBaseStore(TestContext context,
                TestStoreParams testParams = null) : base (context) {

        TestParams = testParams ?? new();
        ReferenceStore = new ReferenceStore(this) {
            Length = TestParams.Length,
            RandomSize = TestParams.Randomsize
            };
        Directory = Seed.Directory;
        }

    public abstract Store Create();


    public abstract Store Open();

    public abstract Store MakeCopy();

    public abstract Store SyncCopy();

    public abstract void Verify(Store spool, bool plaintext = true);

    public abstract void VerifyRandom(
            int index = 1,
            int group = 0);

    public abstract DareEnvelope AddItem(Store spool, int? length = null, bool? randomSize = null);


    public abstract void Update(
        Store spool,
        int index = 1,
        int group = 0);
    }


public record TestSpool : TestBaseStore {

    string StoreName => "TestSpool";

    string CopyName => "CopySpool";

    public int Serial => ReferenceStore.Serial;


    public TestSpool(
                TestContext context,
                TestStoreParams testParams = null) : base(context) {
        }

    public override Store Create() {
        var result = new Spool(Directory, StoreName);

        return result;
        }


    public override Store Open() {
        var result = new Spool(Directory, StoreName);

        return result;
        }

    public override Store MakeCopy() {
        var result = new Spool(Directory, CopyName);

        return result;
        }

    public override Store SyncCopy() {
        var result = new Spool(Directory, CopyName);

        return result;
        }


    /// <summary>
    /// Verify the contents of <paramref name="spool"/> against the reference store.
    /// </summary>
    /// <param name="spool">The catalog to use for verification.</param>
    /// <param name="plaintext">Check that the decrypted plaintext matches the original.</param>
    public override void Verify(Store spool, bool plaintext = true) {

        // iterate forwards


        // iterate bacwards

        }

    public override void VerifyRandom(
                    int index = 1,
                    int group = 0) {


        var serial = Seed.GetInt32(Serial, group, index);
        var uniqueId = ReferenceStore.GetUniqueId(serial);

        using var spool = new Spool(Directory, StoreName);


        // get serial


        // check it is the same as 

        }

    public override void Update(
        Store spool,
                int index = 1,
                int group = 0) {


        var serial = Seed.GetInt32(Serial, group, index);
        var uniqueId = ReferenceStore.GetUniqueId(serial);




        }



    public override DareEnvelope AddItem(Store spool, int? length = null, bool? randomSize = null) {
        var message = ReferenceStore.AddMessage(length, randomSize);

        // here add to the catalog


        return message;
        }


    /// <summary>
    /// Set the status of a random selection of <paramref name="count"/> messages
    /// in the catalog to the value 
    /// </summary>
    /// <param name="spool"></param>
    /// <param name="count"></param>
    public void SetStatus(
                    Store spool,
                    int count = 1,
                    int group = 0,
                    string status = MeshConstants.StateSpoolInboundReadTag) {

        for (var i = 0; i < count; i++) {
            var serial = Seed.GetInt32(Serial, group, i);
            ReferenceStore.SetStatus(serial, status);
            }


        }




    }


public record TestCatalog : TestBaseStore {


    string StoreName => "TestCatalog";

    string CopyName => "CopyCatalog";


    public int Serial => ReferenceStore.Serial;
    public int Count => ReferenceStore.Count;

    public TestCatalog(
                TestContext context,
                TestStoreParams testParams = null) : base(context) {

        }



    public override Store Create() {
        var result = new CatalogTest(Directory, StoreName);

        return result;
        }


    public override Store Open() {
        var result = new CatalogTest(Directory, StoreName);

        return result;
        }

    public override Store MakeCopy() {
        var result = new CatalogTest(Directory, CopyName);

        return result;
        }

    public override Store SyncCopy() {
        var result = new CatalogTest(Directory, CopyName);

        return result;
        }

    /// <summary>
    /// Verify the contents of <paramref name="spool"/> against the reference store.
    /// </summary>
    /// <param name="spool">The catalog to use for verification.</param>
    /// <param name="plaintext">Check that the decrypted plaintext matches the original.</param>
    public override void Verify(Store spool, bool plaintext = true) {

        // iterate forwards


        // iterate bacwards

        }

    public override void VerifyRandom(
                    int index = 1,
                    int group = 0) {


        var serial = Seed.GetInt32(Serial, group, index);
        var uniqueId = ReferenceStore.GetUniqueId(serial);

        using var spool = new CatalogTest(Directory, StoreName);


        // get serial


        // check it is the same as 

        }


    public override DareEnvelope AddItem(Store spool, int? length = null, bool? randomSize = null) {
        var message = ReferenceStore.AddItem(length, randomSize);

        // here add to the catalog


        return message;
        }


    public DareEnvelope Update(Store spool, int? length = null, bool? randomSize = null) {
        var message = ReferenceStore.AddItem(length, randomSize);

        // here add to the catalog


        return message;
        }


    public override void Update(
        Store spool,
            int index = 1,
            int group = 0) {


        var serial = Seed.GetInt32(Serial, group, index);
        var uniqueId = ReferenceStore.GetUniqueId(serial);

        }

    }


/// <summary>
/// Bookmark catalog. Describes the bookmarks in the user's Mesh account.
/// </summary>
public class CatalogTest : Catalog<CatalogEntryTest> {
    #region // Properties
    ///<summary>The canonical label for the catalog</summary>
    public const string Label = "TestyTest";


    ///<summary>The catalog label</summary>
    public override string SequenceDefault => Label;
    #endregion
    #region // Factory methods and constructors


    /// <summary>
    /// Constructor for a catalog named <paramref name="storeName"/> in directory
    /// <paramref name="directory"/> using the cryptographic parameters <paramref name="cryptoParameters"/>
    /// and key collection <paramref name="keyCollection"/>.
    /// </summary>
    /// <param name="create">Create a new persistence store on disk if it does not already exist.</param>
    /// <param name="decrypt">Attempt to decrypt the contents of the catalog if encrypted.</param>
    /// <param name="directory">The directory in which the catalog persistence container is stored.</param>
    /// <param name="storeName">The catalog persistence container file name.</param>
    /// <param name="cryptoParameters">The default cryptographic enhancements to be applied to container entries.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">The key collection to be used to resolve keys when reading entries.</param>
    /// <param name="meshClient">Parent account context used to obtain a mesh client.</param>
    public CatalogTest(
                string directory,
                string storeName = null,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                IMeshClient meshClient = null,
                bool decrypt = true,
                bool create = true) :
        base(directory, storeName ?? Label,
                    policy, cryptoParameters, keyCollection, decrypt: decrypt, create: create) {
        }

    #endregion
    }