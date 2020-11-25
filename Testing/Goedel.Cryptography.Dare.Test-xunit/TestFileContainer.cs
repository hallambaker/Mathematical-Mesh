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
            var Bytes = CreateBytes(100);

            ReadWriteContainer("TestFilePlaintext_100", Bytes, null);
            }


        /// <summary>
        /// Test multiple plaintext singleton containers.
        /// </summary>
        [Fact]
        public void TestFileContainer16() {
            byte[] Bytes = new byte[0];
            ReadWriteContainer("TestFilePlaintext_0", Bytes, null);

            int Length = 1;
            for (var i = 1; i < 16; i++) {
                var Filename = $"TestFilePlaintext_{Length}";
                Bytes = CreateBytes(Length);
                ReadWriteContainer(Filename, Bytes, null);
                Length *= 2;
                }
            }




        /// <summary>
        /// It is not possible to perform more than one test simultaneously when testing the 
        /// per-account O/S integration. Thus unit testing does not work
        /// </summary>
        [Fact]
        public void TestFileContainerEncrypted1() {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);

            var Bytes = CreateBytes(100);
            ReadWriteContainer("TestFileEncrypted_100", Bytes, null);
            }


        /// <summary>
        /// Test multiple plaintext singleton containers.
        /// </summary>
        [Fact]
        public void TestFileContainerEncrypted16() {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);

            byte[] Bytes = new byte[0];
            ReadWriteContainer("TestFileEncrypted_0", Bytes, null);

            int Length = 1;
            for (var i = 1; i < 16; i++) {
                var Filename = $"TestFileEncrypted_{Length}";
                Bytes = CreateBytes(Length);
                ReadWriteContainer(Filename, Bytes, null);
                Length *= 2;
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
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);
            ReadWriteArchive("TestArchive_", 10, null, false);
            }

        /// <summary>
        /// Test file archive with 10 encrypted entries encrypted under independent key exchanges
        /// </summary>
        [Fact]
        public void TestArchiveEncrypted10Individual() {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);
            ReadWriteArchive("TestArchive_", 10, null, true);
            }

        /// <summary>
        /// Test file archive with multiple different sizes, etc.
        /// </summary>
        [Fact]
        public void TestArchiveMulti() {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);
            var Entries = new int[] { 5, 15, 30, 100 };

            foreach (var Entry in Entries) {
                ReadWriteArchive("TestArchive_", Entry);
                ReadWriteArchive("TestArchive_", Entry, null, false);
                ReadWriteArchive("TestArchive_", Entry, null, true);
                }
            }

        static Random Random = new Random();
        byte[] CreateBytes(int Length) => CryptoCatalog.GetBytes(Length);

        void ReadWriteContainer(string FileName, byte[] TestData, DarePolicy CryptoParameters = null) {
            //CryptoParameters ??= new CryptoParameters();

            // Create container
            FileContainerWriter.File(FileName, CryptoParameters, TestData, null);

            // Read Container
            FileContainerReader.File(FileName, CryptoParameters.KeyLocate,
                        out var ReadData, out var ContentMetaOut);

            // Check for equality
            ReadData.IsEqualTo(TestData).TestTrue();
            }


        void ReadWriteArchive(string FileNameBase, int Entries,
                    DarePolicy policy = null, bool Independent = false) {

            var CryptoParameters = new CryptoParameters();

            var TestData = new byte[Entries][];
            for (var i = 0; i < Entries; i++) {
                var Length = Random.Next(32768);
                TestData[i] = CreateBytes(Length);
                }

            var Mode = policy.Encrypt ? "" : (Independent ? "_Ind" : "_Bulk");
            var Filename = FileNameBase + $"{Mode}_{Entries}";


            using (var Writer = new FileContainerWriter(
                    Filename, policy, true, fileStatus: FileStatus.Overwrite)) {
                for (var i = 0; i < Entries; i++) {
                    Writer.Add(TestData[i]);
                    }
                }

            // Test retrieval by index number. Note that since record 0 has the 
            // container header data, the data items run through [1..Entries]
            using var Reader = new FileContainerReader(Filename, policy.KeyLocate);
            for (var i = 0; i < Entries; i++) {

                Reader.Read(policy?.KeyLocate, out var ReadData, out var ContentMeta, index: i + 1);
                ReadData.IsEqualTo(TestData[i]).TestTrue(); 
                }
            }



        }

    }
