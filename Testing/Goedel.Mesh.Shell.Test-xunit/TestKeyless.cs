using System;
using System.Collections.Generic;
using Xunit;
using Goedel.Mesh.Shell;
using Goedel.Cryptography;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;

namespace Goedel.XUnit {

    public partial class TestShell : Shell {
        public ShellResult ShellResult;

        /// <summary>
        /// Override the post processing hook to save the result.
        /// </summary>
        /// <param name="shellResult"></param>
        public override void _PostProcess(ShellResult shellResult) {
            ShellResult = shellResult;
            }
        }

    public partial class TestCLI : CommandLineInterpreter {
        TestShell Shell;

        public TestCLI(TestShell shell = null) : base() {
            Shell = shell ?? new TestShell();
            }

        public ShellResult Dispatch(string command) {
            var Args = command.Split(' ');
            Dispatcher(Entries, DefaultCommand, Shell, Args, 0);
            return Shell.ShellResult;
            }

        }



    public class TestKeyless {

        static TestKeyless() {
            TestEnvironment.Initialize();
            Mesh.Mesh.Initialize();
            }

        public static TestKeyless Test() => new TestKeyless();
        #region // Commitment
        List<TestVectorDigest> CommitmentTests = new List<TestVectorDigest>() {
                //new TestVectorDigest ("Konrad is compromised", "", "", key:"RAA6B-6R32H-5YAQE-IQJHC-KBA4Q"),
                //new TestVectorDigest ("This is the secret", "", "", key:"RD42E-SYQGS-IGHAK-UP22P-GZUBY"),
                //new TestVectorDigest ("Test", "", "", key:"RBQ26-MEZGP-4SVCU-RYOWO-QTURA"),
                new TestVectorDigest ("", "MCQU6-SCKSY-GE33R-UFSIT-ESMB6", "SA3MB-ULUCW-L5VFR-H3D4R-MMLNM", key:"RD5SS-PN2L6-RFTKU-RCLTH-CMP6R") };
        [Fact]
        public void TestCommitment() {
            foreach (var test in CommitmentTests) {
                if (test.SHA2 != null) {
                    var result = TestCommitmentInt(test.Data, test.Key);
                    Console.WriteLine(result);
                    result.Digest.AssertEqual(test.SHA2);
                    var result2 = TestCommitmentInt(test.Data, test.Key, "sha2");
                    result.Digest.AssertEqual(result2.Digest);
                    }
                if (test.SHA3 != null) {
                    var result = TestCommitmentInt(test.Data, test.Key, "sha3");
                    Console.WriteLine(result);
                    result.Digest.AssertEqual(test.SHA3);
                    }
                }
            }

        [Fact]
        public void TestCommitmentRandom() {
            var algs = new List<string>() { null, "sha2", "sha3"};

            foreach (var test in CommitmentTests) {
                foreach (var alg in algs) {
                    var result1 = TestCommitmentInt(test.Data, alg: alg);
                    var result2 = TestCommitmentInt(test.Data, result1.Key, alg: alg);
                    result1.Digest.AssertEqual(result2.Digest);
                    }
                }
            }

        ResultDigest TestCommitmentInt(string content, string key=null, string alg = null) {
            var testCLI = new TestCLI();
            var filename = content.ToFileUnique();
            var keyClause = key == null ? "" : $" /key {key}";
            var algClause = alg == null ? "" : $" /alg {alg}";
            var result = testCLI.Dispatch($"file commit {filename}{keyClause}{algClause}") as ResultDigest;
            result.AssertNotNull();
            return result;

            }

        #endregion
        #region // Random
        [Theory]
        [InlineData()]

        public void TestRandom(int repeat = 10) {
            var results = new HashSet<string>();
            var testCLI = new TestCLI();

            for (var i = 0; i < repeat; i++) {
                var result = testCLI.Dispatch("file random") as ResultDigest; ;
                var random = result.Digest;
                random.Length.AssertEqual(29);
                results.Contains(random).AssertFalse();
                results.Add(random);
                Console.WriteLine(result);
                }
            }

        #endregion
        #region // UDF

        List<TestVectorDigest> UDFTests = new List<TestVectorDigest>() {
            new TestVectorDigest ("UDF Data Value", "MDDK7-N6A72-7AJZN-OSTRX-XKS72", "SCFIN-CQGDR-KG47R-7OVPT-TCHZ5", null),
            new TestVectorDigest ("", "MBIDU-QYL4U-GZZDA-YKFFM-QLANU", "SDBDM-J6CIV-DSPDT-GHEFE-6F3PC", null)
            };

        [Fact]
        public void TestUDF() {
            foreach (var test in UDFTests) {
                if (test.SHA2 != null) {
                    var result = TestUDFInt(test.Data, test.ContentType);
                    result.AssertEqual(test.SHA2);
                    var result2 = TestUDFInt(test.Data, test.ContentType, "sha2");
                    result.AssertEqual(result2);
                    }
                if (test.SHA3 != null) {
                    var result = TestUDFInt(test.Data, test.ContentType, "sha3");
                    result.AssertEqual(test.SHA3);
                    }
                }

            }

        string TestUDFInt(string content, string contentType, string alg = null) {
            var testCLI = new TestCLI();
            var filename = content.ToFileUnique();
            var contentClause = contentType == null ? "" : $" /cty {contentType}";
            var algClause = alg == null ? "" : $" /alg {alg}";
            var result = testCLI.Dispatch($"file udf {filename}{contentClause}{algClause}") as ResultDigest;
            result.AssertNotNull();
            return result.Digest;

            }
        #endregion



        List<TestVectorDigest> DigestTests = new List<TestVectorDigest>() {
            new TestVectorDigest ("abc", 
                "ddaf35a193617abacc417349ae20413112e6fa4e89a97ea20a9eeee64b55d39a2192992a274fc1a836ba3c23a3feebbd454d4423643ce80e2a9ac94fa54ca49f",
                "b751850b1a57168a5693cd924b6b096e08f621827444f70d884f5d0240d2712e10e116e9192af3c91a7ec57647e3934057340b4cf408d5a56592f8274eec53f0"),
            new TestVectorDigest ("",
                "cf83e1357eefb8bdf1542850d66d8007d620e4050b5715dc83f4a921d36ce9ce47d0d13c5d85f2b0ff8318d2877eec2f63b931bd47417a81a538327af927da3e",
                "a69f73cca23a9ac5c8b567dc185a756e97c982164fe25859e0d1dcc1475c80a615b2123af1f5f94c11e3e9402c3ac558f500199d95b6d3e301758586281dcd26")
            };

        [Fact]
        public void TestDigest() {
            foreach (var test in DigestTests) {
                if (test.SHA2 != null) {
                    var result = TestDigestInt(test.Data);
                    result.AssertEqual(test.SHA2.ToUpper());
                    var result2 = TestDigestInt(test.Data, "sha2");
                    result.AssertEqual(result2);
                    }
                if (test.SHA3 != null) {
                    var result = TestDigestInt(test.Data, "sha3");
                    result.AssertEqual(test.SHA3.ToUpper());
                    }
                }
            }

        string TestDigestInt(string content, string alg = null) {
            var testCLI = new TestCLI();
            var filename = content.ToFileUnique();
            var algClause = alg == null ? "" : $" /alg {alg}";
            var result = testCLI.Dispatch($"file digest {filename}{algClause}") as ResultDigest;
            result.AssertNotNull();
            return result.Digest;

            }


        class TestVectorDigest {
            public string Data;
            public string ContentType;
            public string SHA2;
            public string SHA3;
            public string Key;

            public TestVectorDigest(
                     string data,
                string sha2,
                string sha3,
                string contentType=null,
                string key=null) {
                Data = data;
                ContentType = contentType;
                SHA2 = sha2;
                SHA3 = sha3;
                Key = key;
                }
            }




        }

    }
