
using Goedel.IO;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test;
using Goedel.Utilities;

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

            Dispatch($"dare decode {result1.Filename}");
            var file2UDF = GetFileUDF(filename);
            file1UDF.AssertEqual(file2UDF);

            if (corrupt) {
                result1.Filename.CorruptDareMessage();
                }

            var resultVerify = Dispatch($"dare verify {result1.Filename}") as ResultFile;
            corrupt.AssertEqual(!resultVerify.Verified);

            return true;
            }

        [Fact]
        public void TestContainerCatalogBase() {
            var filename = Files.GetFilenameUnique();

            Dispatch($"container create {filename}");
            TestContainerCatalog(filename);

            }

        [Fact]
        public void TestContainerCatalogEncrypt() {
            var filename = Files.GetFilenameUnique();
            var account = "alice@example.com";
            CreateAccount(account);

            Dispatch($"container create {filename} /encrypt {account}");
            TestContainerCatalog(filename);
            }

        bool TestContainerCatalog(string filename) {


            var filename1 = "Test data 1".ToFileUnique();
            var filename2 = "Test data 2".ToFileUnique();
            var filename3 = "Test data 3".ToFileUnique();
            var filename4 = "Test data 4".ToFileUnique();
            var key1 = "key1";
            var key2 = "key2";
            // create catalog


            Dispatch($"container append {filename} {filename1} /key {key1}");
            Dispatch($"container append {filename} {filename2} /key {key2}");
            Dispatch($"container delete {filename} /key {key1}");
            Dispatch($"container append {filename} {filename3} /key {key1}");
            Dispatch($"container append {filename} {filename4} /key {key2}");

            // TBS: write code to check the output
            return true;
            }

        [Fact]
        public void TestContainerArchive() {
            var inputDir = @"..\CommonData";
            var output = @"CommonData.darch";
            var outputDir = @"CommonData";


            outputDir.DirectoryDelete();
            Dispatch($"container archive {inputDir} /out {output}");
            Dispatch($"container extract {output} {outputDir}");

            }

        }
    }
