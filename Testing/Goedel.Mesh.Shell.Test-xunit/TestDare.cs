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

using System.Collections.Generic;
using System.IO;

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;

#pragma warning disable IDE0060

namespace Goedel.XUnit;

public partial class ShellTests {


    [Fact]
    public void TestFilePlain() => TestFile("Hello world");


    ///<summary>This is failing because the shell command profile create has been changed.
    ///Need to also work out what the process for the account key is.</summary>

    [Fact]
    public void TestFileEncrypt() {

        CreateAccount(AliceAccount);

        TestFile("Hello world", encrypt: AliceAccount);
        }

    [Fact]
    public void TestFileSign() {

        CreateAccount(AliceAccount);

        TestFile("Hello world", sign: AliceAccount);

        "Need to test file gest signed".TaskTest();
        "Need to test signature is actually valid".TaskTest();
        }

    [Fact]
    public void TestFileSignEncrypt() {

        CreateAccount(AliceAccount);

        TestFile("Hello world", encrypt: AliceAccount, sign: AliceAccount);
        }

    public bool TestFile(string content, string contentType = null,


        string encrypt = null, string sign = null, bool corrupt = false) {

        _ = DefaultDevice;

        var filename = content.ToFileUnique();
        var contentClause = contentType == null ? "" : $" /cty {contentType}";
        var encryptClause = encrypt == null ? "" : $" /encrypt {encrypt}";
        var signClause = sign == null ? "" : $" /sign {sign}";

        var file1UDF = GetFileUDF(filename);

        var result1 = Dispatch($"dare encode {filename}{contentClause}{encryptClause}{signClause}") as ResultFile;


        System.IO.File.Delete(filename);

        Dispatch($"dare decode {result1.Filename} {filename}");
        var file2UDF = GetFileUDF(filename);
        file1UDF.TestEqual(file2UDF);

        if (corrupt) {
            result1.Filename.CorruptDareMessage();
            }

        var resultVerify = Dispatch($"dare verify {result1.Filename}") as ResultFile;
        corrupt.TestEqual(!resultVerify.Verified);

        return true;
        }

    [Fact]
    public void TestArchive() => TestSequence();

    readonly int[] counts = { 10, 20 };

    [Fact]
    public void TestLog() => LogTest(counts);

    readonly string archive1 = "../CommonData/Archive1";
    readonly string archive2 = "../CommonData/Archive2";
    readonly string archive3 = "../CommonData/Archive3";

    [Theory]
    [InlineData(100)]
    public void TestSequence(
                int count = 10,
                string encrypt = null,
                string sign = null,
                bool purge = false,
                bool index = false,
                string initial = "Archive1") {


        initial = initial == null ? null : "../CommonData/" + initial;

        // create Alice account
        var accountAlice = AliceAccount;
        CreateAccount(accountAlice);

        // create Mallet account
        var mallet = GetTestCLI("Mallet");
        MakeAccount(mallet, MalletAccount);


        var entries = new SortedDictionary<string, string>();
        var filename = $"archive-{encrypt}-{sign}-{count}-{purge}-{index}";

        var options = encrypt == null ? "" : $" /encrypt={encrypt}" +
                    sign == null ? "" : $" /sign={sign}";

        var staleFrames = 0;

        options = initial == null ? options : $" {initial}" + options;
        Dispatch($"dare archive {options} /out={filename}");

        AddEntries(entries, initial);

        VerifyArchive(filename, entries, sign, encrypt, mallet, archive1);
        //VerifyArchive(filename, entries, sign, encrypt, mallet, initial);

        // Update old file.
        var filepath = getItem(entries, 0);
        var update = Path.Combine(archive2, Path.GetFileName(filepath));
        Dispatch($"dare append {filename} {update} /key={filepath}");

        // update the entries directory
        entries.Remove(filepath);
        entries.Add(filepath, update);
        VerifyArchive(filename, entries, sign, encrypt, mallet, initial, archive2);
        staleFrames++;

        // Delete file
        var filepathd = getItem(entries, 2); ;
        Dispatch($"dare delete {filename} /file={filepathd}");
        entries.Remove(filepathd);
        VerifyArchive(filename, entries, sign, encrypt, mallet, initial, archive3);
        staleFrames++;

        var original = Dispatch($"dare dir {filename}") as ResultArchive;
        if (purge) {
            // Test Purge
            var purgefile = "purged_" + filename;
            Dispatch($"dare purge {filename} {purgefile}");
            VerifyArchive(purgefile, entries, sign, encrypt, mallet, initial, archive3);
            var purged = Dispatch($"dare dir {purgefile}") as ResultArchive;

            purged.Deleted.TestEqual(0);
            purged.Frames.TestEqual(original.Frames - staleFrames);

            System.IO.File.Delete(purgefile);
            }

        (index ? original.IndexFrame > 0 : original.IndexFrame == 0).TestTrue();

        static string getItem(SortedDictionary<string, string> entries, int index) {
            var count = 0;
            foreach (var entry in entries) {
                if (count++ == index) {
                    return entry.Key;
                    }
                }
            return null;

            }
        EndTest();
        }




    private void LogTest(
        int[] counts,
                string encrypt = null,
                string sign = null
        ) {


        // create Alice account
        var accountAlice = AliceAccount;
        CreateAccount(accountAlice);

        // create Mallet account
        var mallet = GetTestCLI("Mallet");
        MakeAccount(mallet, MalletAccount);

        var ct = "";
        foreach (var count in counts) {
            ct += $"-{count}";
            }

        var filename = $"log-{encrypt}-{sign}{ct}";

        var options = encrypt == null ? "" : $" /encrypt={encrypt}" +
                    sign == null ? "" : $" /sign={sign}";

        Dispatch($"dare sequence {filename} {options}");

        var entries = new List<string>();
        foreach (var count in counts) {
            for (var i = 0; i < count; i++) {
                var bytes = Platform.GetRandomBytes(10, 80);
                var entry = bytes.ToStringBase32();
                Dispatch($"dare log {filename} {entry}");
                entries.Add(entry);
                }
            VerifyLog(encrypt, sign, filename, entries, mallet);
            // test
            }

        EndTest();
        }



    void VerifyLog(
            string encrypt,
            string sign,
            string filename,
            List<string> entries,
            TestCLI mallet) {
        var output = "output_" + filename;
        var listArchive = Dispatch($"dare list {filename} {output}") as ResultListLog;

        entries.Count.TestEqual(listArchive.Count);

        using (var reader = output.OpenTextReader()) {
            foreach (var entry in entries) {
                var line = reader.ReadLine();
                line.Separate(',', out var date, out var value);
                value.TestEqual(entry);

                }


            }


        System.IO.File.Delete(output);



        }



    static void AddEntries(SortedDictionary<string, string> dictionary, string directory) {
        if (directory == null) {
            return;
            }
        var directoryInfo = new DirectoryInfo(directory);
        AddEntries(dictionary, directoryInfo, directoryInfo.Name);
        }

    static void AddEntries(SortedDictionary<string, string> dictionary, DirectoryInfo directoryInfo,
                string path) {
        foreach (var file in directoryInfo.GetFiles()) {
            dictionary.Add(Path.Combine(path, file.Name),
                        Path.Combine(directoryInfo.Name, file.FullName));
            }
        foreach (var subDirectory in directoryInfo.GetDirectories()) {
            AddEntries(dictionary, subDirectory, Path.Combine(path, subDirectory.Name));
            }
        }


    bool VerifyArchive(string filename, SortedDictionary<string, string> entries, string sign, string encrypt,
            TestCLI mallet, string initial, string test = null) {

        test ??= initial;

        using var archive = new DareLogReader(filename);
        archive.Sequence.VerifyPolicy();
        archive.GetIndex();

        entries.TestEqualKeys(archive.FileCollection.DictionaryByPath);

        //extract all files to directory
        var unpack = filename + "_unpack";
        var unpackDir = Path.Combine(unpack, Path.GetFileName(initial));
        Dispatch($"dare extract {filename} {unpack}");

        var listArchive = Dispatch($"dare dir {filename} ");


        unpackDir.CheckDirectroriesEqual(test);
        Directory.Delete(unpack, true);

        var source = new DirectoryInfo(initial);

        // Extract single files and test.
        foreach (var entry in entries) {
            var subFile = entry.Key;
            var initialFile = entry.Value;

            Dispatch($"dare extract {filename} /file={entry.Key}");

            var recoverFile = Path.GetFileName(entry.Key);

            recoverFile.CheckFilesEqual(initialFile);
            System.IO.File.Delete(recoverFile);
            }


        Dispatch($"dare dir {filename}");


        return true;
        }

    static bool VerifyPolicy(string filename, string encrypt, string sign) {

        "Test that the file matches the policy".TaskTest();


        filename.Future();
        encrypt.Future();
        sign.Future();

        throw new NYI();
        }
    }
