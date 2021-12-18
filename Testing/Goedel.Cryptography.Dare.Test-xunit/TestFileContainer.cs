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
        var bytes = CreateBytes(100);
        var policy = TestEnvironmentCommon.MakePolicy();

        ReadWriteContainer("TestFilePlaintext_100", bytes, policy);
        }


    /// <summary>
    /// Test multiple plaintext singleton containers.
    /// </summary>
    [Fact]
    public void TestFileContainer16() {
        byte[] bytes = Array.Empty<Byte>();

        var policy = TestEnvironmentCommon.MakePolicy();
        ReadWriteContainer("TestFilePlaintext_0", bytes, policy);

        int length = 1;
        for (var i = 1; i < 16; i++) {
            var filename = $"TestFilePlaintext_{length}";
            bytes = CreateBytes(length);
            ReadWriteContainer(filename, bytes, null);
            length *= 2;
            }
        }




    /// <summary>
    /// It is not possible to perform more than one test simultaneously when testing the 
    /// per-account O/S integration. Thus unit testing does not work
    /// </summary>
    [Fact]
    public void TestFileContainerEncrypted1() {

        var policy = TestEnvironmentCommon.MakePolicy(encryptId: CryptoAlgorithmId.X448);

        var Bytes = CreateBytes(100);
        ReadWriteContainer("TestFileEncrypted_100", Bytes, policy);
        }


    /// <summary>
    /// Test multiple plaintext singleton containers.
    /// </summary>
    [Fact]
    public void TestFileContainerEncrypted16() {
        var policy = TestEnvironmentCommon.MakePolicy(encryptId: CryptoAlgorithmId.X448);

        byte[] bytes = Array.Empty<Byte>();
        ReadWriteContainer("TestFileEncrypted_0", bytes, policy);

        int length = 1;
        for (var i = 1; i < 16; i++) {
            var filename = $"TestFileEncrypted_{length}";
            bytes = CreateBytes(length);
            ReadWriteContainer(filename, bytes, null);
            length *= 2;
            }
        }

    /// <summary>
    /// Test empty archive
    /// </summary>
    [Fact]
    public void TestArchive0() => ReadWriteArchive("TestArchive_", 0);

    /// <summary>
    /// Test single file archive
    /// </summary>
    [Fact]
    public void TestArchive1() => ReadWriteArchive("TestArchive_", 1);

    /// <summary>
    /// Test file archive with 10 plaintext entries 
    /// </summary>
    [Fact]
    public void TestArchive10() => ReadWriteArchive("TestArchive_", 10);

    /// <summary>
    /// Test file archive with 10 encrypted entries encrypted under one key exchange
    /// </summary>
    [Fact]
    public void TestArchiveEncrypted10Bulk() {
        var policy = TestEnvironmentCommon.MakePolicy(encryptId: CryptoAlgorithmId.X448);
        ReadWriteArchive("TestArchive_", 10, policy, false);
        }

    /// <summary>
    /// Test file archive with 10 encrypted entries encrypted under independent key exchanges
    /// </summary>
    [Fact]
    public void TestArchiveEncrypted10Individual() {
        var policy = TestEnvironmentCommon.MakePolicy(encryptId: CryptoAlgorithmId.X448);
        ReadWriteArchive("TestArchive_", 10, policy, true);
        }

    /// <summary>
    /// Test file archive with multiple different sizes, etc.
    /// </summary>
    [Fact]
    public void TestArchiveMulti() {
        var policy = TestEnvironmentCommon.MakePolicy(encryptId: CryptoAlgorithmId.X448);
        var entries = new int[] { 5, 15, 30, 100 };

        foreach (var entry in entries) {
            ReadWriteArchive("TestArchive_", entry);
            ReadWriteArchive("TestArchive_", entry, policy, false);
            ReadWriteArchive("TestArchive_", entry, policy, true);
            }
        }

    static readonly Random Random = new();

    static byte[] CreateBytes(int length) => CryptoCatalog.GetBytes(length);

    static void ReadWriteContainer(string fileName, byte[] testData, DarePolicy policy = null) {
        policy ??= TestEnvironmentCommon.MakePolicy();

        // Create container
        DareLogWriter.ArchiveFile(fileName, policy, testData, null);

        // Read Container
        DareLogReader.File(fileName, policy.KeyLocation,
                    out var ReadData, out var ContentMetaOut);

        // Check for equality
        ReadData.IsEqualTo(testData).TestTrue();


        Sequence.VerifyPolicy(fileName, policy.KeyLocation);
        }


    void ReadWriteArchive(string fileNameBase, int entries,
                DarePolicy policy = null, bool independent = false) {

        var policyNill = policy == null ? "_null" : "";
        policy ??= TestEnvironmentCommon.MakePolicy();

        var testData = new byte[entries][];
        for (var i = 0; i < entries; i++) {
            var Length = Random.Next(32768);
            testData[i] = CreateBytes(Length);
            }

        var mode = policy.Encrypt ? (independent ? "_Ind" : "_Bulk") : "_plaintext";
        var filename = fileNameBase + $"{policyNill}{mode}_{entries}";


        using (var writer = new DareLogWriter(
                filename, policy, true, fileStatus: FileStatus.Overwrite)) {
            for (var i = 0; i < entries; i++) {
                writer.AddData(testData[i]);
                }
            }

        // Test retrieval by index number. Note that since record 0 has the 
        // container header data, the data items run through [1..Entries]
        using (var reader = new DareLogReader(filename, policy.KeyLocation)) {
            for (var i = 0; i < entries; i++) {

                reader.Read(policy?.KeyLocation, out var ReadData, out var ContentMeta, index: i + 1);
                ReadData.IsEqualTo(testData[i]).TestTrue();
                }
            }

        Sequence.VerifyPolicy(filename, policy.KeyLocation);
        }



    }
