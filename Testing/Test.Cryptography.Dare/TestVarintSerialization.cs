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
using Goedel.Test;

using Xunit;

namespace Goedel.XUnit;

public class TestVarintSerialization : UnitTestSet {

    /// <summary>Constructor method</summary>
    /// <returns>Returns a new instance of the class.</returns>
    public static TestVarintSerialization Test() => new();


    [Theory]
    [InlineData()]
    public void TestEnvelope(
            bool sign=false, 
            bool encrypt=false,
            int size=100) {

        Seed = DeterministicSeed.Auto();

        var filename = Seed.GetFilename("JBCD");
        var data = Seed.GetTestBytes(size, "This is a test");

        // Write file 
        EarlEnvelopeWriter.Write(filename, data);

        // Read file back
        var envelope= EarlEnvelopeReader.Read (filename, Console.Out);

        // check for equality.
        data.TestEqual(envelope.Payload);
        }

    [Theory]
    [InlineData()]
    public void TestSequence(
            bool sign = false,
            bool encrypt = false,
            int size = 100,
            int count = 0,
            bool variable = false) {

        Seed = DeterministicSeed.Auto();
        var filename = Seed.GetFilename("TestSequence");
        List<byte[]> dataList = [];

        // create the sequence
        using var sequence = EarlSequence.Create(filename);

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




    bool Append(EarlSequence sequence, List<byte[]> dataList, int size, bool variable) {

        var data = Seed.GetTestBytes(size, "This is a test");
        dataList.Add(data);
        sequence.Append(data);


        return true;
        }


    bool Verify(EarlSequence sequence1, List<byte[]> dataList) {
        Console.WriteLine();
        Console.WriteLine();

        var filename = sequence1.Filename;
        sequence1.CloseStream(); // close the stream so we can reopen for read.

        using var sequence = EarlSequence.Open(filename);
        foreach (var data in dataList) {
            var envelope = sequence.ReadNext();
            data.TestEqual(envelope.Payload);
            }


        // check that we have read all the elements.

        return true;
        }



    [Theory]
    [InlineData()]
    public void TestArchive(
            bool sign = false,
            bool encrypt = false,
            int size = 0,
            int count = 0,
            bool variable = false,
            SequenceIndexMode index = SequenceIndexMode.None) {

        Seed = DeterministicSeed.Auto();
        var filename = Seed.GetFilename("TestArchive");

        var testDirectory = "..\\..\\CommonData\\Archive1";
        var targetArchive = "Unpacked";

        var directoryIndex = DirectoryIndex.ReadDirectory(testDirectory);
        directoryIndex.IsEqual(directoryIndex).TestTrue();

        // Create Archive
        using (var archive = EarlArchive.Create(filename)) {

            // Append directory
            archive.AppendDirectory(testDirectory);
            archive.AppendIndex();

            directoryIndex.IsEqual(archive.DirectoryIndex);

            }

        // Read back the index
        using (var archive = EarlArchive.OpenRead(filename)) {
            archive.ReadIndex();
            directoryIndex.IsEqual(archive.DirectoryIndex);
            }

        // Extract and verify files
        using (var archive = EarlArchive.OpenRead(filename)) {
            archive.Extract(targetArchive);
            var unpackedDirectoryIndex = DirectoryIndex.ReadDirectory(testDirectory);

            directoryIndex.IsEqual(archive.DirectoryIndex);
            directoryIndex.IsEqual(unpackedDirectoryIndex);

            }




        }





    [Theory]
    [InlineData()]
    public void TestCatalog(
            bool sign = false,
            bool encrypt = false,
            int size = 0,
            int count = 0,
            bool variable = false,
            SequenceIndexMode index = SequenceIndexMode.None) {
        }

    [Fact]
    public void TestCatalogSingle() {



        }

    }
