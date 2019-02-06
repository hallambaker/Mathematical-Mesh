using System.IO;
using System.Collections.Generic;
using Xunit;
using Goedel.Mesh.Shell;
using Goedel.Cryptography;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;

namespace Goedel.XUnit {
    public partial class ShellTests {


        [Fact]
        public void TestFilePlain() => TestFile("Hello world");

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

        public bool TestFile(string content, string contentType=null, 
            string encrypt=null, string sign = null, bool corrupt = false) {

            var filename = content.ToFileUnique();
            var contentClause = contentType == null ? "" : $" /cty {contentType}";
            var encryptClause = encrypt == null ? "" : $" /encrypt {encrypt}";
            var signClause = sign == null ? "" : $" /sign {sign}";

            var file1UDF = GetFileUDF(filename);

            var result1 = Dispatch($"dare encode {filename}{contentClause}{encryptClause}{signClause}") as ResultFile;


            File.Delete(filename);

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

            Dispatch($"dare container create {filename}");
            TestContainerCatalog(filename);

            }

        [Fact]
        public void TestContainerCatalogEncrypt() {
            var filename = Files.GetFilenameUnique();
            var account = "alice@example.com";
            CreateAccount(account);

            Dispatch($"dare container create {filename} /encrypt {account}");
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


            Dispatch($"dare container append {filename} {filename1} /key {key1}");
            Dispatch($"dare container append {filename} {filename2} /key {key2}");
            Dispatch($"dare container delete {filename} /key {key1}");
            Dispatch($"dare container append {filename} {filename3} /key {key1}");
            Dispatch($"dare container append {filename} {filename4} /key {key2}");

            // TBS: write code to check the output
            throw new NYI();
            }

        [Fact]
        public void TestContainerSpool() {

            var filename = Files.GetFilenameUnique();
            var filename1 = "Test data 1".ToFileUnique();
            var filename2 = "Test data 2".ToFileUnique();
            var filename3 = "Test data 3".ToFileUnique();
            var filename4 = "Test data 4".ToFileUnique();
            // create catalog
            Dispatch($"dare container create {filename}");

            Dispatch($"dare container append {filename} {filename1}");
            Dispatch($"dare container append {filename} {filename2}");
            Dispatch($"dare container append {filename} {filename3}");
            Dispatch($"dare container append {filename} {filename4}");
            
            // TBS: write code to check the output
            throw new NYI();
            }

        [Fact]
        public void TestContainerArchive() {
            var inputDir = @"..\CommonData";
            var output = @"CommonData.darch";

            Dispatch($"dare container archive {inputDir} /out {output}");
            Dispatch($"dare container archive {output}");

            // TBS: write code to check the output
            throw new NYI();
            }

        }
    }
