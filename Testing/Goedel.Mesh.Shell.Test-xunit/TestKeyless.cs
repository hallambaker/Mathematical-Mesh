using Goedel.Cryptography;
using Goedel.Mesh.Shell;
using Goedel.Test;
using Goedel.Test.Core;
using Goedel.Utilities;

using System;
using System.Collections.Generic;

using Xunit;

namespace Goedel.XUnit {




    public partial class ShellTests {

        static ShellTests() {
            TestEnvironmentCommon.Initialize();
            Mesh.Mesh.Initialize();
            }

        public static ShellTests Test() => new ShellTests();
        #region // Commitment
        List<TestVectorDigest> CommitmentTests = new List<TestVectorDigest>() {
                new TestVectorDigest ("Konrad is the traitor", "ADFI-EPKG-VKPP-NHHM-5DCA-QBRW-AVRJ",
                    null, key:"NC56-CJPL-HRLU-MGTU-PUEW-S5WU-PYGP"),
                new TestVectorDigest ("", "AASY-DPYV-3WLT-OIQZ-ZBZF-OMSB-PEMH",
                    null, key:"NDZ4-GVE3-KQHX-NJCL-GGDM-KKZB-PELP") };

        [Fact]
        public void TestCommitment() {

            //foreach (var test in CommitmentTests) {
            //    var testCLI = GetTestCLI();
            //    var filename = test.Data.ToFileUnique();
            //    var keyClause = $" /key {test.Key}";

            //    if (test.SHA2 != null) {
            //        var result = testCLI.Dispatch($"hash commit {filename}{keyClause} /alg sha2") as ResultCommitment;
            //        Console.WriteLine($"SHA2 {result}");
            //        }
            //    if (test.SHA3 != null) {
            //        var result = testCLI.Dispatch($"hash commit {filename}{keyClause} /alg sha3") as ResultCommitment;
            //        Console.WriteLine($"SHA3 {result}");
            //        }
            //    }

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
            var algs = new List<string>() { null, "sha2" };

            foreach (var test in CommitmentTests) {
                foreach (var alg in algs) {
                    var result1 = TestCommitmentInt(test.Data, alg: alg);
                    var result2 = TestCommitmentInt(test.Data, result1.Key, alg: alg);
                    result1.Digest.AssertEqual(result2.Digest);
                    }
                }
            }

        ResultDigest TestCommitmentInt(string content, string key = null, string alg = null) {
            var testCLI = GetTestCLI();
            var filename = content.ToFileUnique();
            var keyClause = key == null ? "" : $" /key {key}";
            var algClause = alg == null ? "" : $" /alg {alg}";
            var result = testCLI.Dispatch($"hash mac {filename}{keyClause}{algClause}") as ResultDigest;
            result.AssertNotNull();
            return result;

            }

        #endregion
        #region // Random
        [Theory]
        [InlineData(0)]
        [InlineData(128)]
        [InlineData(192)]
        [InlineData(256)]
        [InlineData(512)]
        public void TestRandom(int bits) {

            var bitsClause = bits == 0 ? "" : $" /bits {bits}";
            bits = bits == 0 ? 128 : bits;
            var length = (bits + 12) / 5;
            length += ((length - 1) / 4);

            var repeat = 10;
            var results = new HashSet<string>();
            var testCLI = GetTestCLI();

            for (var i = 0; i < repeat; i++) {
                var result = testCLI.Dispatch($"key nonce{bitsClause}") as ResultKey; ;
                var random = result.Key;
                var randomData = UDF.Nonce(random);
                randomData.Length.AssertEqual(bits / 8);

                random.Length.AssertEqual(length);
                results.Contains(random).AssertFalse();
                results.Add(random);
                }
            }

        [Theory]
        [InlineData(0)]
        [InlineData(128)]
        [InlineData(192)]
        [InlineData(256)]
        [InlineData(512)]
        public void TestKey(int bits) {
            var bitsClause = bits == 0 ? "" : $" /bits {bits}";
            bits = bits == 0 ? 128 : bits;
            var length = (bits + 12) / 5;
            length += ((length - 1) / 4);

            var repeat = 10;
            var results = new HashSet<string>();
            var testCLI = GetTestCLI();

            for (var i = 0; i < repeat; i++) {
                var result = testCLI.Dispatch($"key secret{bitsClause}") as ResultKey; ;
                var random = result.Key;
                var randomData = UDF.SymmetricKey(random);
                randomData.Length.AssertEqual(bits / 8);
                random.Length.AssertEqual(length);
                results.Contains(random).AssertFalse();
                results.Add(random);
                }
            }

        #endregion
        #region // UDF

        List<TestVectorDigest> UDFTests = new List<TestVectorDigest>() {
            new TestVectorDigest ("UDF Data Value", "MDDK-7N6A-727A-JZNO-STRX-XKS7-DJAF",
                "KCFI-NCQG-DRKG-47R7-OVPT-TCHZ-7UXY", null),
            new TestVectorDigest ("290668103", "MAAA-AAB3-VVFO-FE2C-LRWO-SCAA-HVFI",
                "KB7J-76FG-ZKT3-PK5F-UTRU-MMUR-USIC", null),
            new TestVectorDigest ("44870804", "MA5W-3F6R-GMBG-EWUT-O3GY-XYNK-R7RK",
                "KAAA-AABG-OZEP-IALD-6X7K-PCQJ-MZB2", null),
            new TestVectorDigest ("", "MBID-UQYL-4UGZ-ZDAY-KFFM-QLAN-6RLN",
                "KDBD-MJ6C-IVDS-PDTG-HEFE-6F3P-UIBX", null)

            };

        [Fact]
        public void TestUDF() {
            //foreach (var test in UDFTests) {
            //    if (test.SHA2 != null) {
            //        var result = TestUDFInt(test.Data, test.ContentType);
            //        var result2 = TestUDFInt(test.Data, test.ContentType, "sha2");
            //        Console.WriteLine($"SHA2 {result}");
            //        }
            //    if (test.SHA3 != null) {
            //        var result = TestUDFInt(test.Data, test.ContentType, "sha3");
            //        Console.WriteLine($"SHA3 {result}");
            //        }
            //    }

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


        public int FindCompression() {

            for (var i = 0; true; i++) {
                if (i % 1000 == 0) {
                    Console.WriteLine(i);
                    }
                var content = i.ToString().ToUTF8();
                var buffer = UDF.DataToUDFBinary(
                    content, "text/plain", cryptoAlgorithmID: CryptoAlgorithmId.SHA_3_512);
                if (buffer[0] > 144) {
                    Console.WriteLine(UDF.PresentationBase32(buffer));

                    return i;
                    }
                }

            }

        string TestUDFInt(string content, string contentType, string alg = null) {
            var testCLI = GetTestCLI();
            var filename = content.ToFileUnique();
            var contentClause = contentType == null ? "" : $" /cty {contentType}";
            var algClause = alg == null ? "" : $" /alg {alg}";
            var result = testCLI.Dispatch($"hash udf {filename}{contentClause}{algClause}") as ResultDigest;
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
            var testCLI = GetTestCLI();
            var filename = content.ToFileUnique();
            var algClause = alg == null ? "" : $" /alg {alg}";
            var result = testCLI.Dispatch($"hash digest {filename}{algClause}") as ResultDigest;
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
                string contentType = null,
                string key = null) {
                Data = data;
                ContentType = contentType;
                SHA2 = sha2;
                SHA3 = sha3;
                Key = key;
                }
            }

        }

    }
