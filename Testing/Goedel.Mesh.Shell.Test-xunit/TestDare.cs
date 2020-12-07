using System.IO;
using Goedel.IO;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test;
using Goedel.Utilities;

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


            var entries = new Dictionary<string, bool>();
            var filename = $"seq-{archive}-{encrypt}-{sign}-{count}-{purge}-{index}";

            "Exercise a file archive".TaskTest();

            var options = encrypt == null ? "" : $" /encrypt={encrypt}" +
                        sign == null ? "" : $" /sign={sign}";

            // Create archive with specified security policy

            if (archive) {
                // add the initial values (if any);
                options = initial == null ? options : $" {initial}" + options;
                Dispatch($"dare archive {options} /out={filename}");
                AddEntries(entries, initial);
                }
            else {
                Dispatch($"dare log {filename}");
                }

            VerifyArchive(filename, entries, sign, encrypt, mallet);

            if (archive) {
                // add count new file

                // Update old file.
                }
            else {


                // add count log entries

                }



            VerifyArchive(filename, entries, sign, encrypt, mallet);

            if (archive) {
                // Delete file

                VerifyArchive(filename, entries, sign, encrypt, mallet);
                }
            


            if (purge) {
                // Test Purge
                }

            if (index) {
                // Test Index
                }


            throw new NYI();
            }

        static void AddEntries(Dictionary<string, bool> dictionary, string directory) {
            if (directory == null) {
                return;
                }

            var files = Directory.GetFiles(directory);

            foreach (var file in files) {
                var filename = Path.GetFileName(file);
                dictionary.Add(filename, true);
                }

            }


        bool VerifyArchive(string filename, Dictionary<string, bool> entries, string sign, string encrypt,
                TestCLI mallet) {
            VerifyPolicy(filename, sign, encrypt);

            // Extract all files and test.
            foreach (var entry in entries) {
                var subFile = entry.Key;
                // extract

                VerifyPolicy(subFile, sign, encrypt);
                }

            // Extract single files and test.
            foreach (var entry in entries) {
                var subFile = entry.Key;
                // extract

                VerifyPolicy(subFile, sign, encrypt);
                }

            throw new NYI();
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
