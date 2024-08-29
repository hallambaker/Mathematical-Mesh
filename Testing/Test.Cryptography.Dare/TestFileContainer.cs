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

namespace Goedel.XUnit;

[Collection("Our Test Collection #1")]
/// <summary>
/// Test routines for file containers
/// </summary>
public partial class TestDareLog {




    public static TestDareLog Test() => new();
    /// <summary>
    /// Test a single plaintext singleton containers.
    /// </summary>
    [Fact]
    public void TestFileContainer1() {
        var seed = DeterministicSeed.AutoClean();

        ReadWriteEnvelope(100);
        }


    /// <summary>
    /// Test multiple plaintext singleton containers.
    /// </summary>
    [Fact]
    public void TestFileContainer16() {
        var seed = DeterministicSeed.AutoClean();
        ReadWriteEnvelope(0);

        int length = 1;
        for (var i = 1; i < 16; i++) {
            ReadWriteEnvelope(length, null);
            length *= 2;
            }
        }




    /// <summary>
    /// It is not possible to perform more than one test simultaneously when testing the 
    /// per-account O/S integration. Thus unit testing does not work
    /// </summary>
    [Fact]
    public void TestFileContainerEncrypted1() {
        var seed = DeterministicSeed.AutoClean();
        var policy = TestEnvironmentCommon.MakeCrypto(seed, encryptId: CryptoAlgorithmId.X448);

        ReadWriteEnvelope(100, policy);
        }


    /// <summary>
    /// Test multiple plaintext singleton containers.
    /// </summary>
    [Fact]
    public void TestFileContainerEncrypted16() {
        var seed = DeterministicSeed.AutoClean();
        var policy = TestEnvironmentCommon.MakeCrypto(seed, encryptId: CryptoAlgorithmId.X448);


        ReadWriteEnvelope(0, policy);

        int length = 1;
        for (var i = 1; i < 16; i++) {
            ReadWriteEnvelope(length, null);
            length *= 2;
            }
        }

    /// <summary>
    /// Test empty archive
    /// </summary>
    [Fact]
    public void TestLog0() => ReadWriteLog(0);

    /// <summary>
    /// Test single file archive
    /// </summary>
    [Fact]
    public void TestLog1() => ReadWriteLog(1);

    /// <summary>
    /// Test file archive with 10 plaintext entries 
    /// </summary>
    [Fact]
    public void TestLog10() => ReadWriteLog(10);

    /// <summary>
    /// Test file archive with 10 encrypted entries encrypted under one key exchange
    /// </summary>
    [Fact]
    public void TestLogEncrypted10Bulk() {
        var seed = DeterministicSeed.AutoClean();
        var policy = TestEnvironmentBase.MakePolicy(seed, encryptId: CryptoAlgorithmId.X448);
        ReadWriteLog(10, policy, false);
        }

    /// <summary>
    /// Test file archive with 10 encrypted entries encrypted under independent key exchanges
    /// </summary>
    [Fact]
    public void TestLogEncrypted10Individual() {
        var seed = DeterministicSeed.AutoClean();
        var policy = TestEnvironmentBase.MakePolicy(seed, encryptId: CryptoAlgorithmId.X448);
        ReadWriteLog(10, policy, true);
        }

    /// <summary>
    /// Test file archive with multiple different sizes, etc.
    /// </summary>
    [Fact]
    public void TestLogMulti() {
        var entries = new int[] { 5, 15, 30, 100 };

        foreach (var entry in entries) {
            var seed = DeterministicSeed.AutoClean(entry);
            var policy = TestEnvironmentBase.MakePolicy(seed, encryptId: CryptoAlgorithmId.X448);


            ReadWriteLog(entry, seed: seed);
            ReadWriteLog(entry, policy, false, seed: seed);
            ReadWriteLog(entry, policy, true, seed: seed);
            }
        }

    static readonly Random Random = new();

    static byte[] CreateBytes(int length) => CryptoCatalog.GetBytes(length);


    static string GetLabel(DarePolicy policy, bool independent = false) =>
        policy == null ? "null" : policy.Encrypt ? (independent ? "Ind" : "Bulk") : "Plaintext";

    static void ReadWriteEnvelope(
                    int length = 1000,
                    CryptoParameters policy = null,
                    DeterministicSeed seed = null) {


        seed ??= DeterministicSeed.Auto(length);
        var fileName = seed.GetFilename("Sequence.random");
        policy ??= new CryptoParameters();


        //    ReadWriteContainer (fileName, testData, policy);
        //    }

        //static void ReadWriteContainer(string fileName, byte[] testData, DarePolicy policy = null) {
        seed.MakeTestFile(fileName, length);
        seed.CheckTestFile(fileName, length);

        var tempEncode = seed.GetTempFilePath();
        DareEnvelope.Encode(policy, fileName, tempEncode);

        var tempDecode = seed.GetTempFilePath();
        DareEnvelope.Decode(tempEncode, tempDecode, policy.KeyLocate);

        seed.CheckTestFile(tempDecode, length);


        var v1 = DareEnvelope.Verify(tempEncode);

        if (policy.SignerKeys != null) {
            // Here corrupt the file data 

            var v2 = DareEnvelope.Verify(tempEncode);
            }
        }


    static void ReadWriteLog(
                    int entries,
                    DarePolicy policy = null,
                    bool independent = false,
                    DeterministicSeed seed = null) {


        seed ??= DeterministicSeed.Auto(entries, GetLabel(policy, independent));
        policy ??= TestEnvironmentBase.MakePolicy(seed);

        var policyNill = policy == null ? "-null" : "";
        var mode = policy.Encrypt ? (independent ? "-Ind" : "-Bulk") : "-plaintext";



        var filename = seed.GetFilename("Sequence");

        //    ReadWriteArchive(fileName, entries, policy, independent);
        //    }



        //static void ReadWriteArchive(
        //            string filename, 
        //            int entries,
        //            DarePolicy policy = null, 
        //            bool independent = false) {


        var testData = new byte[entries][];
        for (var i = 0; i < entries; i++) {
            var Length = Random.Next(32768);
            testData[i] = CreateBytes(Length);
            }


        //var filename = fileNameBase + $"{policyNill}{mode}_{entries}";


        using (var writer = new DareLogWriter(
                filename, fileStatus: FileStatus.Overwrite, policy: policy)) {
            for (var i = 0; i < entries; i++) {
                writer.AddData(testData[i]);
                }
            }

        // Test retrieval by index number. Note that since record 0 has the 
        // container header data, the data items run through [1..Entries]
        using (var reader = new DareLogReader(filename, keyLocate: policy.KeyLocation)) {
            for (var i = 0; i < entries; i++) {


                //throw new NYI();

                reader.Read(policy?.KeyLocation, out var ReadData, out var ContentMeta, index: i + 1);
                ReadData.IsEqualTo(testData[i]).TestTrue();
                }
            }

        Sequence.VerifyPolicy(filename, policy.KeyLocation);
        }



    }
