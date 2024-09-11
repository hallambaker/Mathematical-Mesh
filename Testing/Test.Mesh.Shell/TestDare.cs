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

using Goedel.Mesh.Shell;
using Goedel.Protocol;
using Goedel.Test.Core;

#pragma warning disable IDE0060

namespace Goedel.XUnit;


public partial class ShellTests {

    public static string CommonData => "../../../CommonData/";



    [Theory]
    [InlineData(false, false)]

    public void TestParseFile(
                    bool encrypt = false,
                    bool sign = false) {
        StartTest(Mode, encrypt, sign);


        var alice = CreateMasterDevice("Device1A", AliceAccount);

        var filename = Seed.GetTempFileName();

        // make a file 


        Seed.MakeTestFile(filename, 100);


        var options = encrypt ? $" /encrypt={alice.ContextUser.ServiceAddress}" : "";
        options += sign ? $" /sign={alice.ContextUser.ServiceAddress}" : "";


        var fileEncoded = Seed.GetTempFileName();
        alice.Dispatch($"dare encode {filename} {fileEncoded} {options}");

        //using var input = fileEncoded.OpenFileRead();
        //var envelope = DareEnvelope.FromJSON(input);


        var corruptedFile = CorruptFile(fileEncoded, encrypt, sign);

        var redactedFile = RedactFile(fileEncoded, encrypt, sign);

        }


    [Fact]
    public void NewFileTestAll() {
        StartTest(Mode);
        CreateAliceBobMallet(out var alice, out var bob, out var mallet);

        NewFileTest(Seed, false, true, false, alice, bob, mallet, info: "sign");


        // Plaintext
        NewFileTest(Seed, false, false, false, alice, bob, mallet, info: "plaintext");

        // Encrypted
        NewFileTest(Seed, true, false, false, alice, bob, mallet, info: "encrypt");

        // Signed
        NewFileTest(Seed, false, true, false, alice, bob, mallet, info: "sign");

        // Notarized
        NewFileTest(Seed, false, false, true, alice, bob, mallet, info: "notarize");

        EndTest();
        }


    [Theory]
    [InlineData(true, false, false)]
    public void NewFileTestOnce(
                    bool encrypt = false,
                    bool sign = false,
                    bool notarize = false) {
        StartTest(Mode, encrypt, sign, notarize);

        CreateAliceBobMallet(out var alice, out var bob, out var mallet);

        NewFileTest(Seed, encrypt, sign, notarize, alice, bob, mallet);

        EndTest();
        }


    static void NewFileTest(
                    DeterministicSeed seed,
                    bool encrypt,
                    bool sign,
                    bool notarize,
                    TestCLI alice,
                    TestCLI bob,
                    TestCLI mallet,
                    int length = 1000,
                    string info = ""
                    ) {


        var filename = seed.GetTempFilePath();

        // make a file 
        seed.MakeTestFile(filename, length, info);

        var options = encrypt ? $" /encrypt={alice.ContextUser.ServiceAddress}" : "";
        options += sign ? $" /sign={alice.ContextUser.ServiceAddress}" : "";

        // encode
        var fileEncoded = seed.GetTempFilePath();
        alice.Dispatch($"dare encode {filename} {fileEncoded} {options}");

        // decode as Alice
        var aliceDecoded = seed.GetTempFilePath();
        alice.Dispatch($"dare decode {fileEncoded} {aliceDecoded}");
        seed.CheckTestFile(aliceDecoded, length, info);

        //// decode as Bob
        //var bobDecoded = seed.GetTempFileName();
        //bob.Dispatch($"dare decode {fileEncoded} {bobDecoded}");
        //seed.CheckTestFile(bobDecoded, length, info);

        if (encrypt) {
            var malletDecoded = seed.GetTempFilePath();
            mallet.Dispatch($"dare decode {fileEncoded} {malletDecoded}", fail: true);
            seed.CheckTestFileNotExist(malletDecoded);
            }

        if (sign | notarize) {
            var corruptedFile = CorruptFile(fileEncoded, encrypt, sign);
            var aliceDecoded2 = seed.GetTempFilePath();
            alice.Dispatch($"dare decode {corruptedFile} {aliceDecoded2} /verify", fail: true);
            seed.CheckTestFileNotExist(aliceDecoded2);
            }

        }

    static string CorruptFile(string file1, bool encrypt, bool sign) {
        var result = file1 + ".corrupt";
        using var inputStream = file1.OpenFileReadWrite();
        var document = JbcdDocumentFile.Parse(inputStream);
        var envelope = new JcbdEnvelope(document);

        inputStream.Position = 0;
        using var outputStream = result.OpenFileNewRW();

        inputStream.CopyTo(outputStream);

        outputStream.CorruptDigestAlg(envelope);
        outputStream.CorruptDigestValue(envelope);
        outputStream.CorruptPayloadValue(envelope);

        if (encrypt) {
            outputStream.CorruptSalt(envelope);
            }

        if (sign) {
            outputStream.CorruptSignature(envelope);
            outputStream.CorruptSigner(envelope);
            }

        return result;
        }

    static string RedactFile(string file1, bool encrypt, bool sign) {
        var result = file1 + ".redact";
        using var inputStream = file1.OpenFileReadWrite();
        var document = JbcdDocumentFile.Parse(inputStream);
        var envelope = new JcbdEnvelope(document);

        inputStream.Position = 0;
        using var outputStream = result.OpenFileNewRW();

        inputStream.CopyTo(outputStream);

        if (encrypt) {
            outputStream.EraseSalt(envelope);
            }

        if (sign) {
            outputStream.CorruptMissingSignature(envelope);
            }

        return result;
        }


    //static void CorruptDigestAlg(Stream file, JcbdEnvelope envelope) {

    //    var digest = envelope.Header.GetProperty("dig");
    //    digest.AssertNotNull(NYI.Throw);

    //    file.Position = digest.Value.DataStartPosition;
    //    for (var i = 0; i < digest.Value.DataLength; i++) {
    //        var b = file.ReadByte();
    //        Console.WriteLine($"[b]  -> {(char) b}");
    //        }

    //    }


    [Theory]
    [InlineData(true, false, false, false)]
    [InlineData(true, true, false, false)]
    public void NewArchiveTestOnce(
                    bool encrypt,
                    bool self,
                    bool sign,
                    bool notarize,
                    bool checkErase = false) {

        Seed = DeterministicSeed.AutoClean(Mode, encrypt, self, sign, notarize, checkErase);
        CreateAliceBobMallet(out var alice, out var bob, out var mallet);


        NewArchiveTest(Seed, encrypt, self, sign, notarize, alice, bob, mallet);

        EndTest();
        }


    static void NewArchiveTest(DeterministicSeed seed,
                    bool encrypt,
                    bool self,
                    bool sign,
                    bool notarize,

                    TestCLI alice,
                    TestCLI bob,
                    TestCLI mallet,
                    int length = 1000,
                    bool checkErase = false) {
        var sourceDir = TestEnvironmentBase.CommonData;
        var sourcePath = TestArchive.Archive1;

        var source = Path.Combine(sourceDir, sourcePath);
        var archive = seed.GetTempFilePath();
        var extraFile = seed.GetTempFilePath();
        var deleteFile = Path.Combine(sourcePath, "Test_Key_RSA_Alice.prv");
        var eraseFile = Path.Combine(sourcePath, "Test_Key_RSA_Bob.prv");

        var testArchive = new TestArchiveShell() {
            Filename = archive,
            Encrypt = encrypt,
            Sign = sign,
            Notarize = notarize,
            Alice = alice,
            Bob = bob,
            Mallet = mallet,
            Seed = seed
            };

        var options = encrypt ? $" /encrypt={bob.ContextUser.ServiceAddress} " : "";
        options += self ? $" /self={alice.ContextUser.ServiceAddress} " : "";

        bool checkSelf = !encrypt | self;

        // Create an archive from a directory
        alice.Dispatch($"archive create {archive} {source}{options}");
        testArchive.Add(sourceDir, sourcePath);
        testArchive.CheckArchive(self: checkSelf);

        // Add a file
        seed.MakeTestFile(extraFile, length);
        alice.Dispatch($"archive append {archive} {extraFile}");
        testArchive.AddFile(extraFile, "");
        testArchive.CheckArchive(self: checkSelf);

        // Delete a file
        alice.Dispatch($"archive delete {archive} {deleteFile}");
        testArchive.Delete(deleteFile);
        testArchive.CheckArchive(self: checkSelf);
        //testArchive.CheckFile(deleteFile);

        if (encrypt & checkErase) {
            // Erasure only works if the archive is encrypted.

            // Erase a file
            alice.Dispatch($"archive delete {archive} {eraseFile} /erase");
            testArchive.Erase(eraseFile);
            testArchive.CheckArchive(self: checkSelf);
            //testArchive.CheckFile(eraseFile);

            // Erase the deleted file
            alice.Dispatch($"archive delete {archive} {deleteFile} /erase");
            testArchive.Erase(deleteFile);
            testArchive.CheckArchive(self: checkSelf);
            //testArchive.CheckFile(deleteFile);
            }
        }







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

        var filename = Seed.GetFilename("TestFile");
        Seed.MakeTestFile(filename, 1000);

        var result = Seed.GetFilename("Encoded");

        var contentClause = contentType == null ? "" : $" /cty {contentType}";
        var encryptClause = encrypt == null ? "" : $" /encrypt {encrypt}";
        var signClause = sign == null ? "" : $" /sign {sign}";

        var file1UDF = GetFileUDF(filename);

        var result1 = Dispatch($"dare encode {filename} {result} {contentClause}{encryptClause}{signClause}") as ResultFile;


        System.IO.File.Delete(filename);

        Dispatch($"dare decode {result} {filename}");
        var file2UDF = GetFileUDF(filename);
        file1UDF.TestEqual(file2UDF);

        if (corrupt) {
            result.CorruptDareMessage();
            }

        var resultVerify = Dispatch($"dare verify {result1.Filename}") as ResultFile;
        resultVerify.Verified.TestEqual(!corrupt);
        return true;
        }


    //public void TestArchive() => TestSequence();

    readonly int[] counts = { 10, 20 };

    [Fact]
    public void TestLog() => LogTest(counts);

    readonly string archive1 = CommonData + "Archive1";
    readonly string archive2 = CommonData + "Archive2";
    readonly string archive3 = CommonData + "Archive3";

    [Theory(Skip = "Duplicate except for purge functionality")]
    [InlineData()]
    public void TestSequence(

                string encrypt = null,
                string sign = null,
                bool purge = false,
                bool index = false,
                string initial = "Archive1") {


        initial = initial == null ? null : CommonData + initial;

        // create Alice account
        var accountAlice = AliceAccount;
        CreateAccount(accountAlice);

        // create Mallet account
        var mallet = GetTestCLI("Mallet");
        MakeAccount(mallet, MalletAccount);


        var entries = new SortedDictionary<string, string>();
        var filename = $"archive-{encrypt}-{sign}-{purge}-{index}";

        var options = encrypt == null ? "" : $" /encrypt={encrypt}" +
                    sign == null ? "" : $" /sign={sign}";

        var staleFrames = 0;

        options = initial == null ? options : $" {initial}" + options;
        Dispatch($"archive create {filename} {options}");

        AddEntries(entries, initial);

        VerifyArchive(filename, entries, sign, encrypt, mallet, archive1);
        //VerifyArchive(filename, entries, sign, encrypt, mallet, initial);

        // Update old file.
        var filepath = getItem(entries, 0);
        var update = Path.Combine(archive2, Path.GetFileName(filepath));
        Dispatch($"archive append {filename} {update} ");

        // update the entries directory
        entries.Remove(filepath);
        entries.Add(filepath, update);
        VerifyArchive(filename, entries, sign, encrypt, mallet, initial, archive2);
        staleFrames++;

        // Delete file
        var filepathd = getItem(entries, 2); ;
        Dispatch($"archive delete {filename} filepathd");
        entries.Remove(filepathd);
        VerifyArchive(filename, entries, sign, encrypt, mallet, initial, archive3);
        staleFrames++;

        var original = Dispatch($"archive dir {filename}") as ResultArchive;
        if (purge) {
            // Test Purge
            var purgefile = "purged_" + filename;
            Dispatch($"archive copy {filename} {purgefile} /purge");
            VerifyArchive(purgefile, entries, sign, encrypt, mallet, initial, archive3);
            var purged = Dispatch($"archive dir {purgefile}") as ResultArchive;

            purged.Deleted.TestEqual(0);
            purged.Frames.TestEqual(original.Frames - staleFrames);

            System.IO.File.Delete(purgefile);
            }

        (index ? original.IndexFrame > 0 : original.IndexFrame == null).TestTrue();

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

        Seed = DeterministicSeed.AutoClean(Mode, encrypt, sign);
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

        var filename = Seed.GetFilename(ct);

        var options = encrypt == null ? "" : $" /encrypt={encrypt}" +
                    sign == null ? "" : $" /sign={sign}";

        Dispatch($"log create {filename} {options}");

        var entries = new List<string>();
        foreach (var count in counts) {
            for (var i = 0; i < count; i++) {
                var bytes = Platform.GetRandomBytes(10, 80);
                var entry = bytes.ToStringBase32();
                Dispatch($"log append {filename} {entry}");
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
        var output = Seed.GetTempFilePath();

        var listArchive = Dispatch($"log list {filename} {output}") as ResultListLog;

        listArchive.Count.TestEqual(entries.Count);

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
