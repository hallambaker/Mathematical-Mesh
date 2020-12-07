using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.IO;
using Goedel.Test;
using Goedel.Utilities;

using System;
using System.Collections.Generic;

using Xunit;

namespace Goedel.XUnit {

    /// <summary>
    /// Test routines for file containers
    /// </summary>
    public partial class TestDareArchive {
        public static TestDareArchive Test() => new TestDareArchive();
        /// <summary>
        /// Test a single plaintext singleton containers.
        /// </summary>
        [Fact]
        public void TestFileContainer1() {
            var bytes = CreateBytes(100);

            ReadWriteContainer("TestFilePlaintext_100", bytes, null);
            }


        /// <summary>
        /// Test multiple plaintext singleton containers.
        /// </summary>
        [Fact]
        public void TestFileContainer16() {
            byte[] bytes = new byte[0];
            ReadWriteContainer("TestFilePlaintext_0", bytes, null);

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
            var recipients = new List<string> { "Alice@example.com" };
            var cryptoParameters = new CryptoParametersTest(
                        recipients: recipients);

            var Bytes = CreateBytes(100);
            ReadWriteContainer("TestFileEncrypted_100", Bytes, null);
            }


        /// <summary>
        /// Test multiple plaintext singleton containers.
        /// </summary>
        [Fact]
        public void TestFileContainerEncrypted16() {
            var recipients = new List<string> { "Alice@example.com" };
            var cryptoParameters = new CryptoParametersTest(
                        recipients: recipients);

            byte[] bytes = new byte[0];
            ReadWriteContainer("TestFileEncrypted_0", bytes, null);

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
            var recipients = new List<string> { "Alice@example.com" };
            var cryptoParameters = new CryptoParametersTest(
                        recipients: recipients);
            ReadWriteArchive("TestArchive_", 10, null, false);
            }

        /// <summary>
        /// Test file archive with 10 encrypted entries encrypted under independent key exchanges
        /// </summary>
        [Fact]
        public void TestArchiveEncrypted10Individual() {
            var recipients = new List<string> { "Alice@example.com" };
            var cryptoParameters = new CryptoParametersTest(
                        recipients: recipients);
            ReadWriteArchive("TestArchive_", 10, null, true);
            }

        /// <summary>
        /// Test file archive with multiple different sizes, etc.
        /// </summary>
        [Fact]
        public void TestArchiveMulti() {
            var recipients = new List<string> { "Alice@example.com" };
            var cryptoParameters = new CryptoParametersTest(
                        recipients: recipients);
            var entries = new int[] { 5, 15, 30, 100 };

            foreach (var entry in entries) {
                ReadWriteArchive("TestArchive_", entry);
                ReadWriteArchive("TestArchive_", entry, null, false);
                ReadWriteArchive("TestArchive_", entry, null, true);
                }
            }

        static Random Random = new Random();

        static byte[] CreateBytes(int length) => CryptoCatalog.GetBytes(length);

        static void ReadWriteContainer(string fileName, byte[] testData, DarePolicy cryptoParameters = null) {
            //CryptoParameters ??= new CryptoParameters();

            // Create container
            FileContainerWriter.File(fileName, cryptoParameters, testData, null);

            // Read Container
            FileContainerReader.File(fileName, cryptoParameters.KeyLocate,
                        out var ReadData, out var ContentMetaOut);

            // Check for equality
            ReadData.IsEqualTo(testData).TestTrue();


            Container.VerifyPolicy(fileName);
            }


        void ReadWriteArchive(string fileNameBase, int entries,
                    DarePolicy policy = null, bool independent = false) {

            var cryptoParameters = new CryptoParameters();

            var testData = new byte[entries][];
            for (var i = 0; i < entries; i++) {
                var Length = Random.Next(32768);
                testData[i] = CreateBytes(Length);
                }

            var mode = policy.Encrypt ? "" : (independent ? "_Ind" : "_Bulk");
            var filename = fileNameBase + $"{mode}_{entries}";


            using (var writer = new FileContainerWriter(
                    filename, policy, true, fileStatus: FileStatus.Overwrite)) {
                for (var i = 0; i < entries; i++) {
                    writer.Add(testData[i]);
                    }
                }

            // Test retrieval by index number. Note that since record 0 has the 
            // container header data, the data items run through [1..Entries]
            using (var reader = new FileContainerReader(filename, policy.KeyLocate)) {
                for (var i = 0; i < entries; i++) {

                    reader.Read(policy?.KeyLocate, out var ReadData, out var ContentMeta, index: i + 1);
                    ReadData.IsEqualTo(testData[i]).TestTrue();
                    }
                }

            Container.VerifyPolicy(filename);
            }



        }

    }
