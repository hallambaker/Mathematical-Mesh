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

namespace Goedel.XUnit;




public partial class ShellTests {


    #region // Commitment
    readonly List<TestVectorDigest> commitmentTests = new() {
        new TestVectorDigest("Konrad is the traitor", "ADFI-EPKG-VKPP-NHHM-5DCA-QBRW-AVRJ",
                null, key: "NC56-CJPL-HRLU-MGTU-PUEW-S5WU-PYGP"),
        new TestVectorDigest("", "AASY-DPYV-3WLT-OIQZ-ZBZF-OMSB-PEMH",
                null, key: "NDZ4-GVE3-KQHX-NJCL-GGDM-KKZB-PELP")
        };

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

        foreach (var test in commitmentTests) {
            if (test.SHA2 != null) {
                var result = TestCommitmentInt(test.Data, test.Key);
                //Console.WriteLine(result);
                result.Digest.TestEqual(test.SHA2);
                var result2 = TestCommitmentInt(test.Data, test.Key, "sha2");
                result.Digest.TestEqual(result2.Digest);
                }
            if (test.SHA3 != null) {
                var result = TestCommitmentInt(test.Data, test.Key, "sha3");
                //Console.WriteLine(result);
                result.Digest.TestEqual(test.SHA3);
                }
            }

        EndTest();
        }

    [Fact]
    public void TestCommitmentRandom() {
        var algs = new List<string>() { null, "sha2" };

        foreach (var test in commitmentTests) {
            foreach (var alg in algs) {
                var result1 = TestCommitmentInt(test.Data, alg: alg);
                var result2 = TestCommitmentInt(test.Data, result1.Key, alg: alg);
                result1.Digest.TestEqual(result2.Digest);
                }
            }

        EndTest();
        }

    ResultDigest TestCommitmentInt(string content, string key = null, string alg = null) {
        var testCLI = GetTestCLI();
        var filename = content.ToFileUnique();
        var keyClause = key == null ? "" : $" /key {key}";
        var algClause = alg == null ? "" : $" /alg {alg}";
        var result = testCLI.Dispatch($"hash mac {filename}{keyClause}{algClause}") as ResultDigest;
        result.TestNotNull();
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
        StartTest(Mode, bits);

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
            var randomData = Udf.Nonce(random);
            randomData.Length.TestEqual(bits / 8);

            random.Length.TestEqual(length);
            results.Contains(random).TestFalse();
            results.Add(random);
            }

        EndTest();
        }

    [Theory]
    [InlineData(0)]
    [InlineData(128)]
    [InlineData(192)]
    [InlineData(256)]
    [InlineData(512)]
    public void TestKey(int bits) {
        StartTest(Mode, bits);

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
            var randomData = Udf.SymmetricKey(random);
            randomData.Length.TestEqual(bits / 8);
            random.Length.TestEqual(length);
            results.Contains(random).TestFalse();
            results.Add(random);
            }

        EndTest();
        }

    #endregion
    #region // UDF

    readonly List<TestVectorDigest> uDFTests = new() {
        new TestVectorDigest("UDF Data Value", "MDDK-7N6A-727A-JZNO-STRX-XKS7-DJAF",
            "KCFI-NCQG-DRKG-47R7-OVPT-TCHZ-7UXY", null),
        new TestVectorDigest("290668103", "MAAA-AAB3-VVFO-FE2C-LRWO-SCAA-HVFI",
            "KB7J-76FG-ZKT3-PK5F-UTRU-MMUR-USIC", null),
        new TestVectorDigest("44870804", "MA5W-3F6R-GMBG-EWUT-O3GY-XYNK-R7RK",
            "KAAA-AABG-OZEP-IALD-6X7K-PCQJ-MZB2", null),
        new TestVectorDigest("", "MBID-UQYL-4UGZ-ZDAY-KFFM-QLAN-6RLN",
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

        foreach (var test in uDFTests) {
            if (test.SHA2 != null) {
                var result = TestUDFInt(test.Data, test.ContentType);
                Console.WriteLine(result);
                result.TestEqual(test.SHA2);
                var result2 = TestUDFInt(test.Data, test.ContentType, "sha2");
                result.TestEqual(result2);

                }
            if (test.SHA3 != null) {
                var result = TestUDFInt(test.Data, test.ContentType, "sha3");
                //result.TestEqual(test.SHA3);
                Console.WriteLine(result);
                }
            }
        EndTest();
        }


    public static int FindCompression() {

        for (var i = 0; true; i++) {
            if (i % 1000 == 0) {
                Console.WriteLine(i);
                }
            var content = i.ToString().ToUTF8();
            var buffer = Udf.DataToUDFBinary(
                content, "text/plain", cryptoAlgorithmId: CryptoAlgorithmId.SHA_3_512);
            if (buffer[0] > 144) {
                //Console.WriteLine(UDF.PresentationBase32(buffer));

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
        result.TestNotNull();
        return result.Digest;

        }
    #endregion



    readonly List<TestVectorDigest> digestTests = new() {
        new TestVectorDigest("abc",
            "ddaf35a193617abacc417349ae20413112e6fa4e89a97ea20a9eeee64b55d39a2192992a274fc1a836ba3c23a3feebbd454d4423643ce80e2a9ac94fa54ca49f",
            "b751850b1a57168a5693cd924b6b096e08f621827444f70d884f5d0240d2712e10e116e9192af3c91a7ec57647e3934057340b4cf408d5a56592f8274eec53f0"),
        new TestVectorDigest("",
            "cf83e1357eefb8bdf1542850d66d8007d620e4050b5715dc83f4a921d36ce9ce47d0d13c5d85f2b0ff8318d2877eec2f63b931bd47417a81a538327af927da3e",
            "a69f73cca23a9ac5c8b567dc185a756e97c982164fe25859e0d1dcc1475c80a615b2123af1f5f94c11e3e9402c3ac558f500199d95b6d3e301758586281dcd26")
        };

    [Fact]
    public void TestDigest() {
        foreach (var test in digestTests) {
            if (test.SHA2 != null) {
                var result = TestDigestInt(test.Data);
                result.TestEqual(test.SHA2.ToUpper());
                var result2 = TestDigestInt(test.Data, "sha2");
                result.TestEqual(result2);
                }
            if (test.SHA3 != null) {
                var result = TestDigestInt(test.Data, "sha3");
                result.TestEqual(test.SHA3.ToUpper());
                }
            }
        }

    string TestDigestInt(string content, string alg = null) {
        var testCLI = GetTestCLI();
        var filename = content.ToFileUnique();
        var algClause = alg == null ? "" : $" /alg {alg}";
        var result = testCLI.Dispatch($"hash digest {filename}{algClause}") as ResultDigest;
        result.TestNotNull();
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
