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

using System.Linq;

using Goedel.Cryptography.Dare;
using Goedel.Mesh;
using Goedel.Protocol;
using Goedel.Test;

using Xunit;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Goedel.XUnit;


#pragma warning disable xUnit1026
#pragma warning disable IDE0060

public class TestVarintSerialization : UnitTestSet {

    /// <summary>Constructor method</summary>
    /// <returns>Returns a new instance of the class.</returns>
    public static TestVarintSerialization Test() => new();

    static TestVarintSerialization() {
        TestSchema._Initialized.TestTrue();
        }


    #region -- Envelope Testing

    [Theory]
    [InlineData(false, false, 100)]
    public void TestEnvelope(
            bool sign = false,
            bool encrypt = false,
            int size = 100) {

        Seed = DeterministicSeed.Auto();

        var filename = Seed.GetFilename("JBCD.dare");
        var data = Seed.GetTestBytes(size, "This is a test");

        // Write file 
        VDareEnvelopeWriter.Write(filename, data);

        // Read file back
        var envelope = VDareEnvelopeReader.Read(filename);

        // check for equality.
        data.TestEqual(envelope.Payload);
        }

    #endregion
    #region -- Sequence

    [Theory]
    [InlineData(false, false, 100, 0, false)]
    public void TestSequence(
            bool sign = false,
            bool encrypt = false,
            int size = 100,
            int count = 0,
            bool variable = false) {

        Seed = DeterministicSeed.Auto();
        var filename = Seed.GetFilename("TestSequence.darl");
        List<byte[]> dataList = [];

        // create the sequence
        using var sequence = VDareSequence.Create(filename);

        // add the first item
        Append(sequence, dataList, size, variable);
        Verify(sequence, dataList).TestTrue();

        // add four more items without closing the stream.
        Append(sequence, dataList, size, variable);
        Append(sequence, dataList, size, variable);
        Append(sequence, dataList, size, variable);
        Append(sequence, dataList, size, variable);
        Verify(sequence, dataList).TestTrue();

        TestArchive();
        }




    bool Append(VDareSequence sequence, List<byte[]> dataList, int size, bool variable) {

        var data = Seed.GetTestBytes(size, "This is a test");
        dataList.Add(data);
        sequence.Append(data);


        return true;
        }


    static bool Verify(VDareSequence sequence1, List<byte[]> dataList) {
        var filename = sequence1.Filename;
        sequence1.CloseStream(); // close the stream so we can reopen for read.

        using var sequence = VDareSequence.Open(filename);
        foreach (var data in dataList) {
            var envelope = sequence.ReadNext();
            data.TestEqual(envelope.Payload);
            }

        return true;
        }


    #endregion
    #region -- Archive

    [Theory]
    [InlineData(false, false, 100,0, false, SequenceIndexMode.None)]
    public void TestArchive(
            bool sign = false,
            bool encrypt = false,
            int size = 0,
            int count = 0,
            bool variable = false,
            SequenceIndexMode index = SequenceIndexMode.None) {

        Seed = DeterministicSeed.Auto();
        var filename = Seed.GetFilename("TestArchive.dara");

        var testDirectory = "..\\..\\CommonData\\Archive1";
        var targetArchive = "Unpacked";

        var directoryIndex = DirectoryIndex.ReadDirectory(testDirectory);
        directoryIndex.IsEqual(directoryIndex).TestTrue();

        // Create Archive
        using (var archive = VDareArchive.Create(filename)) {

            // Append directory
            archive.AppendDirectory(testDirectory);
            archive.AppendIndex();

            directoryIndex.IsEqual(archive.DirectoryIndex);

            }

        // Read back the index
        using (var archive = VDareArchive.OpenRead(filename)) {
            archive.ReadIndex();
            directoryIndex.IsEqual(archive.DirectoryIndex);
            }

        // Extract and verify files
        using (var archive = VDareArchive.OpenRead(filename)) {
            archive.Extract(targetArchive);
            var unpackedDirectoryIndex = DirectoryIndex.ReadDirectory(testDirectory);

            directoryIndex.IsEqual(archive.DirectoryIndex);
            directoryIndex.IsEqual(unpackedDirectoryIndex);

            }
        }

    #endregion
    #region -- Log

    [Theory]
    [InlineData(false, false, 100, 0, false, SequenceIndexMode.None)]
    public void TestLog(
        bool sign = false,
        bool encrypt = false,
        int size = 100,
        int count = 0,
        bool variable = false,
        SequenceIndexMode index = SequenceIndexMode.None) {

        Seed = DeterministicSeed.Auto();
        var filename = Seed.GetFilename("TestLog.darl");
        List<TestItem> dataList = [];

        // create the sequence
        using var sequence = VDareLog.Create<TestItem>(filename);
        Append(sequence, dataList, size, variable);
        Verify(sequence, dataList);

        Append(sequence, dataList, size, variable);
        Verify(sequence, dataList);

        Append(sequence, dataList, size, variable);
        Append(sequence, dataList, size, variable);
        Append(sequence, dataList, size, variable);
        Verify(sequence, dataList);

        Append(sequence, dataList, size, variable);
        Append(sequence, dataList, size, variable);
        Append(sequence, dataList, size, variable);
        Append(sequence, dataList, size, variable);
        Append(sequence, dataList, size, variable);
        Append(sequence, dataList, size, variable);
        Append(sequence, dataList, size, variable);
        Append(sequence, dataList, size, variable);
        Append(sequence, dataList, size, variable);
        Verify(sequence, dataList);
        }


    bool Append(VDareLog<TestItem> log, List<TestItem> dataList, int size, bool variable) {

        var data = Seed.GetTestBytes(size, "This is a test");
        var entry = new TestItem() {
            Created = DateTime.Now,
            Data = data
            };
        dataList.Add(entry);
        log.Add(entry);

        return true;
        }



    static bool Verify(VDareLog<TestItem> logIn, List<TestItem> dataList) {
        //Console.WriteLine();
        //Console.WriteLine();

        var filename = logIn.Filename;
        logIn.CloseStream(); // close the stream so we can reopen for read.

        using var log = VDareLog.Open<TestItem>(filename);
        foreach (var data in dataList) {
            var obj = log.ReadNextObject();

            data.Data.TestEqual(obj.Data);

            //data.TestEqual(envelope.Payload);
            }


        // check that we have read all the elements.

        return true;
        }


    #endregion
    #region -- Spool

    [Theory]
    [InlineData(false, false, 100, 0, false, SequenceIndexMode.None)]
    public void TestSpool(
            bool sign = false,
            bool encrypt = false,
            int size = 100,
            int count = 0,
            bool variable = false,
            SequenceIndexMode index = SequenceIndexMode.None) {

        Seed = DeterministicSeed.Auto();
        var filename = Seed.GetFilename("TestSpool.dars");
        Dictionary<string, MessageTest> dataDictionary = [];

        // create the sequence
        using var spool = VDareSpool.Create<MessageTest>(filename);

        var id1 = Append(spool, dataDictionary, size, variable);
        Verify(spool, dataDictionary);

        Update(spool, dataDictionary, [new(id1, SequenceEvent.Read)]);

        Verify(spool, dataDictionary);

        }



    string Append(VDareSpool<MessageTest> spool, Dictionary<string, MessageTest> dataDictionary,
                    int size, bool variable) {


        var data = Seed.GetTestBytes(size, "This is a test");
        var entry = new MessageTest() {
            UniqueId = Udf.Nonce(),
            Data = data,
            };
        dataDictionary.Add(entry.UniqueId, entry);
        spool.Add(entry);

        return entry.UniqueId;
        }

    static void Update(VDareSpool<MessageTest> spool,
                Dictionary<string, MessageTest> dataDictionary,
                List<EntryUpdate> updates) {

        foreach (var update in updates) {
            dataDictionary.TryGetValue(update.Id, out var entry).TestTrue();
            entry._State = update.Event.ToSequenceEvent();
            }
        spool.Update(updates);
        }

    static bool Verify(VDareSpool<MessageTest> spoolIn, Dictionary<string, MessageTest> dataDictionary) {
        //Console.WriteLine();
        //Console.WriteLine();

        var filename = spoolIn.Filename;
        spoolIn.CloseStream(); // close the stream so we can reopen for read.


        var matched = new Dictionary<string, MessageTest>();
        using var spool = VDareSpool.Open<MessageTest>(filename);

        var count = 0;
        foreach (var index in spool.EntriesReverse()) {
            var entry = spool.GetValue(index);
            if (entry != null) {
                if (!matched.TryGetValue(entry.UniqueId, out var match)) {
                    dataDictionary.TryGetValue(entry.UniqueId, out match).TestTrue();
                    (match._State == entry._State).TestTrue();
                    entry.Data.TestEqual(match.Data);
                    count++;
                    // check values are same
                    }
                }
            }

        // check we have the same number of elements
        dataDictionary.Count.TestEqual(count);

        return true;
        }



    #endregion
    #region -- Catalog

    [Theory]
    [InlineData(false, false, 100, 0, false, SequenceIndexMode.None)]
    public void TestCatalog(
            bool sign = false,
            bool encrypt = false,
            int size = 100,
            int count = 0,
            bool variable = false,
            SequenceIndexMode index = SequenceIndexMode.None) {

        Seed = DeterministicSeed.Auto();
        var filename = Seed.GetFilename("TestCatalog.dara");
        Dictionary<string, CatalogEntryTest> dataDictionary = [];

        // create the sequence
        using var catalog = EarlCatalog.Create<CatalogEntryTest>(filename);

        var id1 = Add(catalog, dataDictionary, size, variable);
        Verify(catalog, dataDictionary);

        Update(catalog, dataDictionary, size, variable, id1);
        Verify(catalog, dataDictionary);

        CheckById(catalog, dataDictionary, id1).TestTrue() ;

        Delete(catalog, dataDictionary, id1);
        CheckById(catalog, dataDictionary, id1).TestFalse();

        Verify(catalog, dataDictionary);

        // Retrieve by ID


        // Retrieve by secondary ID

        var id2 = Add(catalog, dataDictionary, size, variable);
        var id3 = Add(catalog, dataDictionary, size, variable);
        var id4 = Add(catalog, dataDictionary, size, variable);
        var id5 = Add(catalog, dataDictionary, size, variable);

        CheckById(catalog, dataDictionary, id2).TestTrue();
        Verify(catalog, dataDictionary);

        Update(catalog, dataDictionary, size, variable, id2);
        Update(catalog, dataDictionary, size, variable, id3);
        Update(catalog, dataDictionary, size, variable, id4);
        Update(catalog, dataDictionary, size, variable, id5);
        Verify(catalog, dataDictionary);

        Delete(catalog, dataDictionary, id2);
        Verify(catalog, dataDictionary);


        Delete(catalog, dataDictionary, id4);
        Verify(catalog, dataDictionary);

        }


    string Add(EarlCatalog<CatalogEntryTest> catalog, Dictionary<string, CatalogEntryTest> dataDictionary,
        int size, bool variable, string id=null) {
        id ??= Udf.Nonce();
        var data = Seed.GetTestBytes(size, "This is a test");
        var entry = new CatalogEntryTest() {
            UniqueId = id,
            SecondaryIds = [Udf.Nonce()],
            Data = data
            };
        dataDictionary.Add(entry.UniqueId, entry);
        catalog.Add(entry);

        return entry.UniqueId;
        }

    string Update(EarlCatalog<CatalogEntryTest> catalog, Dictionary<string, CatalogEntryTest> dataDictionary,
            int size, bool variable, string id) {

        var data = Seed.GetTestBytes(size, "This is a test");
        // get value
        dataDictionary.TryGetValue(id, out var old).TestTrue();

        var entry = new CatalogEntryTest() {
            UniqueId = id,
            SecondaryIds = old.SecondaryIds,
            Data = data
            };
        dataDictionary.AddSafe(entry.UniqueId, entry);
        catalog.Update(entry);

        return entry.UniqueId;
        }


    static bool CheckById(
                EarlCatalog<CatalogEntryTest> catalog, 
                Dictionary<string, CatalogEntryTest> dataDictionary, 
                string id) {

        var inDictionary = dataDictionary.TryGetValue(id, out var dictionaryValue);

        // Check the appearances.
        (catalog.TryGetById(id, out var catalogValue) == inDictionary).TestTrue();
        if (inDictionary) {
            dictionaryValue.ToBytes().TestEqual(catalogValue.ToBytes());

            // verify that we retrieve correctly 
            if (catalogValue.SecondaryIds != null) {
                foreach (var sid in catalogValue.SecondaryIds) {
                    catalog.TryGetBySecondaryId(sid, out catalogValue).TestTrue();
                    dictionaryValue.ToBytes().TestEqual(catalogValue.ToBytes());

                    }
                }
            }
        return inDictionary;
        }





    static bool Delete(EarlCatalog<CatalogEntryTest> catalog, Dictionary<string, CatalogEntryTest> dataDictionary, string id) {
        
        dataDictionary.Remove(id);
        catalog.Delete(id);

        return true;
        }

    static bool Verify(EarlCatalog<CatalogEntryTest> catalogIn, Dictionary<string, CatalogEntryTest> dataDictionary) {
        //Console.WriteLine();
        //Console.WriteLine();

        var filename = catalogIn.Filename;
        catalogIn.CloseStream(); // close the stream so we can reopen for read.


        var matched = new Dictionary<string, CatalogEntryTest>();
        using var catalog = EarlCatalog.Open<CatalogEntryTest>(filename);

        var count = 0;
        foreach (var index in catalog.EntriesReverse()) {
            var entry = catalog.GetValue(index);
            if (entry != null) {
                if (!matched.TryGetValue(entry.UniqueId, out var match)) {
                    dataDictionary.TryGetValue(entry.UniqueId, out match).TestTrue();
                    entry.Data.TestEqual(match.Data);

                    count++;
                    // check values are same
                    }
                }
            }

        // check we have the same number of elements
        dataDictionary.Count.TestEqual(count);

        return true;
        }


    #endregion

    }
