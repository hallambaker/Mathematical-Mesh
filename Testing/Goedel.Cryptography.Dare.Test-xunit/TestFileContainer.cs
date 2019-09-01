using System;
using System.Text;
using System.Collections.Generic;
using Xunit;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Test.Core;

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
        public void TestFileContainer1 () {
            var Bytes = CreateBytes(100);

            ReadWriteContainer("TestFilePlaintext_100", Bytes, null);
            }


        /// <summary>
        /// Test multiple plaintext singleton containers.
        /// </summary>
        [Fact]
        public void TestFileContainer16 () {
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
        public void TestFileContainerEncrypted1 () {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);

            var Bytes = CreateBytes(100);
            ReadWriteContainer("TestFileEncrypted_100", Bytes, CryptoParameters);
            }


        /// <summary>
        /// Test multiple plaintext singleton containers.
        /// </summary>
        [Fact]
        public void TestFileContainerEncrypted16 () {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);

            byte[] Bytes = new byte[0];
            ReadWriteContainer("TestFileEncrypted_0", Bytes, CryptoParameters);

            int Length = 1;
            for (var i = 1; i < 16; i++) {
                var Filename = $"TestFileEncrypted_{Length}";
                Bytes = CreateBytes(Length);
                ReadWriteContainer(Filename, Bytes, CryptoParameters);
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
        public void TestArchiveEncrypted10Bulk () {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);
            ReadWriteArchive("TestArchive_", 10, CryptoParameters, false);
            }

        /// <summary>
        /// Test file archive with 10 encrypted entries encrypted under independent key exchanges
        /// </summary>
        [Fact]
        public void TestArchiveEncrypted10Individual () {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);
            ReadWriteArchive("TestArchive_", 10, CryptoParameters, true);
            }

        /// <summary>
        /// Test file archive with multiple different sizes, etc.
        /// </summary>
        [Fact]
        public void TestArchiveMulti () {
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        recipients: Recipients);
            var Entries = new int[] { 5, 15, 30, 100 };

            foreach (var Entry in Entries) {
                ReadWriteArchive("TestArchive_", Entry);
                ReadWriteArchive("TestArchive_", Entry, CryptoParameters, false);
                ReadWriteArchive("TestArchive_", Entry, CryptoParameters, true);
                }
            }

        KeyPair CreateKeyPair () {
            var Result = new KeyPairDH();
            KeyCollection.Default.Add(Result);

            return Result;
            }

        static Random Random = new Random();
        byte[] CreateBytes (int Length) => CryptoCatalog.GetBytes(Length);
       
        void ReadWriteContainer (string FileName, byte[] TestData, CryptoParameters CryptoParameters=null) {
            CryptoParameters = CryptoParameters ?? new CryptoParameters();

            // Create container
            FileContainerWriter.File(FileName, CryptoParameters, TestData, null);

            // Read Container
            FileContainerReader.File(FileName, CryptoParameters.KeyCollection,
                        out var ReadData, out var ContentMetaOut);

            // Check for equality
            Utilities.Assert.True(ReadData.IsEqualTo(TestData));
            }


        void ReadWriteArchive (string FileNameBase, int Entries, 
                    CryptoParameters CryptoParameters=null, bool Independent=false) {

            CryptoParameters = CryptoParameters ?? new CryptoParameters();

            var TestData = new byte[Entries][];
            for (var i = 0; i < Entries; i++) {
                var Length = Random.Next(32768);
                TestData[i] = CreateBytes(Length);
                }

            var Mode = CryptoParameters.Encrypt ? "" : (Independent ? "_Ind" : "_Bulk");
            var Filename = FileNameBase + $"{Mode}_{Entries}";


            using (var Writer = new FileContainerWriter(
                    Filename, CryptoParameters, true, FileStatus: FileStatus.Overwrite)) {
                for (var i = 0; i < Entries; i++) {
                    Writer.Add(TestData[i], CryptoParameters);
                    }
                }

            // Test retrieval by index number. Note that since record 0 has the 
            // container header data, the data items run through [1..Entries]
            using (var Reader = new FileContainerReader(Filename, CryptoParameters.KeyCollection)) {
                for (var i = 0; i < Entries; i++) {

                    Reader.Read(out var ReadData, out var ContentMeta, Index: i+1);
                    Utilities.Assert.True(ReadData.IsEqualTo(TestData[i]));
                    }
                }
            }



        }

    }
