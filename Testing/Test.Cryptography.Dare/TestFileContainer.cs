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

using System;

using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Mesh.Test;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;

namespace Goedel.XUnit;

/// <summary>
/// Test routines for file containers
/// </summary>
public partial class TestDareArchive {




    public static TestDareArchive Test() => new();
    /// <summary>
    /// Test a single plaintext singleton containers.
    /// </summary>
    [Fact]
    public void TestFileContainer1() {
        var seed = DeterministicSeed.AutoClean();


        var bytes = CreateBytes(100);
        var policy = TestEnvironmentCommon.MakePolicy(seed);

        ReadWriteContainer(bytes, policy);
        }


    /// <summary>
    /// Test multiple plaintext singleton containers.
    /// </summary>
    [Fact]
    public void TestFileContainer16() {
        var seed = DeterministicSeed.AutoClean();
        byte[] bytes = Array.Empty<Byte>();

        var policy = TestEnvironmentCommon.MakePolicy(seed);
        ReadWriteContainer(bytes, policy);

        int length = 1;
        for (var i = 1; i < 16; i++) {
            bytes = CreateBytes(length);
            ReadWriteContainer(bytes, null);
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
        var policy = TestEnvironmentCommon.MakePolicy(seed, encryptId: CryptoAlgorithmId.X448);

        var bytes = CreateBytes(100);
        ReadWriteContainer(bytes, policy);
        }


    /// <summary>
    /// Test multiple plaintext singleton containers.
    /// </summary>
    [Fact]
    public void TestFileContainerEncrypted16() {
        var seed = DeterministicSeed.AutoClean();
        var policy = TestEnvironmentCommon.MakePolicy(seed, encryptId: CryptoAlgorithmId.X448);

        byte[] bytes = Array.Empty<Byte>();
        ReadWriteContainer(bytes, policy);

        int length = 1;
        for (var i = 1; i < 16; i++) {
            bytes = CreateBytes(length);
            ReadWriteContainer( bytes, null);
            length *= 2;
            }
        }

    /// <summary>
    /// Test empty archive
    /// </summary>
    [Fact]
    public void TestArchive0() => ReadWriteArchive(0);

    /// <summary>
    /// Test single file archive
    /// </summary>
    [Fact]
    public void TestArchive1() => ReadWriteArchive(1);

    /// <summary>
    /// Test file archive with 10 plaintext entries 
    /// </summary>
    [Fact]
    public void TestArchive10() => ReadWriteArchive(10);

    /// <summary>
    /// Test file archive with 10 encrypted entries encrypted under one key exchange
    /// </summary>
    [Fact]
    public void TestArchiveEncrypted10Bulk() {
        var seed = DeterministicSeed.AutoClean();
        var policy = TestEnvironmentBase.MakePolicy(seed, encryptId: CryptoAlgorithmId.X448);
        ReadWriteArchive(10, policy, false);
        }

    /// <summary>
    /// Test file archive with 10 encrypted entries encrypted under independent key exchanges
    /// </summary>
    [Fact]
    public void TestArchiveEncrypted10Individual() {
        var seed = DeterministicSeed.AutoClean();
        var policy = TestEnvironmentBase.MakePolicy(seed, encryptId: CryptoAlgorithmId.X448);
        ReadWriteArchive(10, policy, true);
        }

    /// <summary>
    /// Test file archive with multiple different sizes, etc.
    /// </summary>
    [Fact]
    public void TestArchiveMulti() {
        var entries = new int[] { 5, 15, 30, 100 };

        foreach (var entry in entries) {
            var seed = DeterministicSeed.AutoClean(entry);
            var policy = TestEnvironmentBase.MakePolicy(seed, encryptId: CryptoAlgorithmId.X448);


            ReadWriteArchive(entry, seed: seed);
            ReadWriteArchive(entry, policy, false, seed: seed);
            ReadWriteArchive(entry, policy, true, seed: seed);
            }
        }

    static readonly Random Random = new();

    static byte[] CreateBytes(int length) => CryptoCatalog.GetBytes(length);


    static string GetLabel(DarePolicy policy, bool independent = false) =>
        policy == null ? "null" : policy.Encrypt ? (independent ? "Ind" : "Bulk") : "Plaintext";

    static void ReadWriteContainer(
                    byte[] testData,
                    DarePolicy policy = null,
                    DeterministicSeed seed = null) {

        var length = testData?.Length.ToString() ?? "";
        seed ??= DeterministicSeed.CreateDeep(1, GetLabel(policy), length);
        var fileName = seed.GetFilename("Sequence");

    //    ReadWriteContainer (fileName, testData, policy);
    //    }

    //static void ReadWriteContainer(string fileName, byte[] testData, DarePolicy policy = null) {
        policy ??= TestEnvironmentCommon.MakePolicy(seed);

        // Create container
        DareArchive.ArchiveFile(fileName, policy, testData, null);

        // Read Sequence
        DareLogReader.File(fileName, policy.KeyLocation,
                    out var ReadData, out var ContentMetaOut);

        // Check for equality
        ReadData.IsEqualTo(testData).TestTrue();


        Sequence.VerifyPolicy(fileName, policy.KeyLocation);
        }


    static void ReadWriteArchive(
                    int entries,
                    DarePolicy policy = null,
                    bool independent = false,
                    DeterministicSeed seed = null) {
        policy ??= TestEnvironmentBase.MakePolicy(seed);

        var policyNill = policy == null ? "-null" : "";
        var mode = policy.Encrypt ? (independent ? "-Ind" : "-Bulk") : "-plaintext";


        seed ??= DeterministicSeed.CreateParent(entries, GetLabel(policy, independent));
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


        using (var writer = new DareArchive(
                filename, fileStatus: FileStatus.Overwrite, policy:policy, read:true)) {
            for (var i = 0; i < entries; i++) {
                writer.AddData(testData[i]);
                }
            }

        // Test retrieval by index number. Note that since record 0 has the 
        // container header data, the data items run through [1..Entries]
        using (var reader = new DareArchive(filename, keyLocate:policy.KeyLocation)) {
            for (var i = 0; i < entries; i++) {

                reader.Read(policy?.KeyLocation, out var ReadData, out var ContentMeta, index: i + 1);
                ReadData.IsEqualTo(testData[i]).TestTrue();
                }
            }

        Sequence.VerifyPolicy(filename, policy.KeyLocation);
        }



    }
