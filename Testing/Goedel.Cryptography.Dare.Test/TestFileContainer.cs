using System;
using System.Text;
using System.Collections.Generic;
using MT = Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;
using Goedel.IO;
using Goedel.Test;

namespace Goedel.Cryptography.Dare.Test {

    /// <summary>
    /// Test routines for file containers
    /// </summary>
    public partial class TestDare {

        /// <summary>
        /// Test a single plaintext singleton containers.
        /// </summary>
        [MT.TestMethod]
        public void TestFileContainer1 () {
            var Bytes = CreateBytes(100);

            ReadWriteContainer("TestFilePlaintext_100", Bytes, null);
            }


        /// <summary>
        /// Test multiple plaintext singleton containers.
        /// </summary>
        [MT.TestMethod]
        public void TestFileContainer16 () {
            byte[] Bytes = new byte[0];
            ReadWriteContainer("TestFilePlaintext_0", Bytes, null);

            int Length = 1;
            for (var i = 1; i < 16; i++) {
                var Filename = $"TestFilePlaintext_{Length}";
                Bytes = CreateBytes(Length);
                ReadWriteContainer(Filename, Bytes, null);
                Length = Length * 2;
                }
            }




        /// <summary>
        /// It is not possible to perform more than one test simultaneously when testing the 
        /// per-account O/S integration. Thus unit testing does not work
        /// </summary>
        [MT.TestMethod]
        public void TestFileContainerEncrypted1 () {
            var TestKeys = new TestKeys();
            TestKeys.AddEncrypt();

            var Bytes = CreateBytes(100);
            ReadWriteContainer("TestFileEncrypted_100", Bytes, TestKeys.EncryptionKeys);
            }


        /// <summary>
        /// Test multiple plaintext singleton containers.
        /// </summary>
        [MT.TestMethod]
        public void TestFileContainerEncrypted16 () {
            var TestKeys = new TestKeys();
            TestKeys.AddEncrypt();

            byte[] Bytes = new byte[0];
            ReadWriteContainer("TestFileEncrypted_0", Bytes, TestKeys.EncryptionKeys);

            int Length = 1;
            for (var i = 1; i < 16; i++) {
                var Filename = $"TestFileEncrypted_{Length}";
                Bytes = CreateBytes(Length);
                ReadWriteContainer(Filename, Bytes, TestKeys.EncryptionKeys);
                Length = Length * 2;
                }
            }

        /// <summary>
        /// Test empty archive
        /// </summary>
        [MT.TestMethod]
        public void TestArchive0() => ReadWriteArchive("TestArchive_", 0);

        /// <summary>
        /// Test single file archive
        /// </summary>
        [MT.TestMethod]
        public void TestArchive1() => ReadWriteArchive("TestArchive_", 1);

        /// <summary>
        /// Test file archive with 10 plaintext entries 
        /// </summary>
        [MT.TestMethod]
        public void TestArchive10() => ReadWriteArchive("TestArchive_", 10);

        /// <summary>
        /// Test file archive with 10 encrypted entries encrypted under one key exchange
        /// </summary>
        [MT.TestMethod]
        public void TestArchiveEncrypted10Bulk () {
            var EncryptionKey = CreateKeyPair();
            ReadWriteArchive("TestArchive_", 10, EncryptionKey, false);
            }

        /// <summary>
        /// Test file archive with 10 encrypted entries encrypted under independent key exchanges
        /// </summary>
        [MT.TestMethod]
        public void TestArchiveEncrypted10Individual () {
            var EncryptionKey = CreateKeyPair();
            ReadWriteArchive("TestArchive_", 10, EncryptionKey, true);
            }

        /// <summary>
        /// Test file archive with multiple different sizes, etc.
        /// </summary>
        [MT.TestMethod]
        public void TestArchiveMulti () {
            var EncryptionKey = CreateKeyPair();
            var Entries = new int[] { 5, 15, 30, 100 };

            foreach (var Entry in Entries) {
                ReadWriteArchive("TestArchive_", Entry);
                ReadWriteArchive("TestArchive_", Entry, EncryptionKey, false);
                ReadWriteArchive("TestArchive_", Entry, EncryptionKey, true);
                }
            }

        KeyPair CreateKeyPair () {
            var Result = new KeyPairDH();
            KeyCollection.Default.Add(Result);

            return Result;
            }

        static Random Random = new Random();
        byte[] CreateBytes (int Length) => CryptoCatalog.GetBytes(Length);
       
        void ReadWriteContainer (string FileName, byte[] TestData, List<KeyPair> EncryptionKeys) {
            // Create container
            FileContainerWriter.File(FileName, TestData, null, Recipients: EncryptionKeys);

            // Read Container
            FileContainerReader.File(FileName, out var ReadData, out var ContentMetaOut);

            // Check for equality
            Assert.True(ReadData.IsEqualTo(TestData));
            }


        void ReadWriteArchive (string FileNameBase, int Entries, 
                    KeyPair EncryptionKey=null, bool Independent=false) {

            var TestData = new byte[Entries][];
            for (var i = 0; i < Entries; i++) {
                var Length = Random.Next(32768);
                TestData[i] = CreateBytes(Length);
                }

            var Mode = EncryptionKey == null ? "" : (Independent ? "_Ind" : "_Bulk");
            var Filename = FileNameBase + $"{Mode}_{Entries}";
            var Recipients = EncryptionKey == null ? null : new List<KeyPair> { EncryptionKey };

            using (var Writer = new FileContainerWriter(
                    Filename, true, FileStatus: FileStatus.Overwrite, Recipients: Recipients)) {
                for (var i = 0; i < Entries; i++) {
                    Writer.Add(TestData[i], null, Recipients);
                    }
                }

            // Test retrieval by index number. Note that since record 0 has the 
            // container header data, the data items run through [1..Entries]
            using (var Reader = new FileContainerReader(Filename)) {
                for (var i = 0; i < Entries; i++) {

                    Reader.Read(out var ReadData, out var ContentMeta, Index: i+1);
                    Assert.True(ReadData.IsEqualTo(TestData[i]));
                    }
                }
            }



        }

    }
