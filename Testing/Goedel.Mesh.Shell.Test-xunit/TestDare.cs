using System.IO;
using Goedel.IO;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test;
using Goedel.Utilities;
using Goedel.Cryptography.Dare;
using System.Collections.Generic;
using Xunit;

namespace Goedel.XUnit {
    public partial class ShellTests {


        [Fact]
        public void TestFilePlain() => TestFile("Hello world");


        ///<summary>This is failing because the shell command profile create has been changed.
        ///Need to also work out what the process for the account key is.</summary>

        [Fact]
        public void TestFileEncrypt() {
            var account = "alice@example.com";
            CreateAccount(account);

            TestFile("Hello world", encrypt: account);
            }

        [Fact]
        public void TestFileSign() {
            var account = "alice@example.com";
            CreateAccount(account);

            TestFile("Hello world", sign: account);

            "Need to test file gest signed".TaskTest();
            "Need to test signature is actually valid".TaskTest();
            }

        [Fact]
        public void TestFileSignEncrypt() {
            var account = "alice@example.com";
            CreateAccount(account);

            TestFile("Hello world", encrypt: account, sign: account);
            }

        public bool TestFile(string content, string contentType = null,
            string encrypt = null, string sign = null, bool corrupt = false) {

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
        public void TestArchive() => TestSequence(true);

        [Fact]
        public void TestLog() => TestSequence(false);


        [Theory]
        [InlineData(true, 100)]
        public void TestSequence(
                    bool archive = true,
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
            var filename = $"seq-{archive}-{encrypt}-{sign}-{count}-{purge}-{index}";

            var options = encrypt == null ? "" : $" /encrypt={encrypt}" +
                        sign == null ? "" : $" /sign={sign}";

            // Create archive with specified security policy

            if (archive) {
                ArchiveTest(encrypt, sign, purge, index, initial, mallet, entries, filename, options);
                }
            else {
                LogTest(encrypt, sign, purge, index, initial, mallet, entries, filename, options);
                }

            }

        string archive1 = "../CommonData/Archive1";
        string archive2 = "../CommonData/Archive2";
        string archive3 = "../CommonData/Archive3";

        private void ArchiveTest(string encrypt, 
                string sign, 
                bool purge, 
                bool index, 
                string initial, 
                TestCLI mallet,
                SortedDictionary<string, string> entries, 
                string filename, 
                string options) {
            // add the initial values (if any);
            var staleFrames = 0;

            options = initial == null ? options : $" {initial}" + options;
            Dispatch($"dare archive {options} /out={filename}");

            AddEntries(entries, initial);

            VerifyArchive(filename, entries, sign, encrypt, mallet, archive1);
            //VerifyArchive(filename, entries, sign, encrypt, mallet, initial);

            // Update old file.
            var filepath = getItem(entries,0);
            var update = Path.Combine (archive2, Path.GetFileName(filepath));
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

            var original = Dispatch($"dare list {filename}") as ResultArchive;
            if (purge) {
                // Test Purge
                var purgefile = "purged_" + filename;
                Dispatch($"dare purge {filename} {purgefile}");
                VerifyArchive(purgefile, entries, sign, encrypt, mallet, initial, archive3);
                var purged = Dispatch($"dare list {purgefile}") as ResultArchive;

                purged.Deleted.TestEqual(0);
                purged.Frames.TestEqual(original.Frames - staleFrames);

                System.IO.File.Delete(purgefile);
                }

            (index ? original.IndexFrame > 0 : original.IndexFrame == 0).TestTrue();



            string getItem (SortedDictionary<string, string> entries, int index) {
                var count = 0;
                foreach (var entry in entries) {
                    if (count++ == index) {
                        return entry.Key;
                        }
                    }
                return null;

                }

            }

        private void LogTest(string encrypt, string sign, bool purge, bool index, string initial, TestCLI mallet, SortedDictionary<string, string> entries, string filename, string options) {

                Dispatch($"dare log {options}");



            if (purge) {
                // Test Purge
                }

            if (index) {
                // Test Index
                }
            throw new NYI();
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
                TestCLI mallet, string initial, string test=null) {

            test ??= initial;

            using var archive = new DareLogReader(filename);
            archive.Sequence.VerifyPolicy();
            archive.GetIndex();

            entries.TestEqualKeys(archive.FileCollection.DictionaryByPath);

            //extract all files to directory
            var unpack = filename + "_unpack";
            var unpackDir = Path.Combine(unpack, Path.GetFileName(initial));
            Dispatch($"dare extract {filename} {unpack}");

            var listArchive = Dispatch($"dare list {filename} ");


            unpackDir.CheckDirectroriesEqual(test);
            Directory.Delete(unpack, true);

            var source = new DirectoryInfo(initial);

            // Extract single files and test.
            foreach (var entry in entries) {
                var subFile = entry.Key;
                var initialFile = entry.Value;

                Dispatch($"dare extract {filename} /file={entry.Key}");

                var recoverFile = Path.GetFileName(entry.Key);

                recoverFile.CheckFilesEqual (initialFile);
                System.IO.File.Delete(recoverFile);
                }


            Dispatch($"dare list {filename}");


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
    }
