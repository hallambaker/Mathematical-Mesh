
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

            Dispatch($"dare decode {result1.Filename}");
            var file2UDF = GetFileUDF(filename);
            file1UDF.TestEqual(file2UDF);

            if (corrupt) {
                result1.Filename.CorruptDareMessage();
                }

            var resultVerify = Dispatch($"dare verify {result1.Filename}") as ResultFile;
            corrupt.TestEqual(!resultVerify.Verified);

            return true;
            }


        }
    }
