using System;
using System.Text;
using System.Collections.Generic;
using Goedel.Cryptography.Dare;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Framework;
using Goedel.Cryptography.KeyFile;
using Goedel.IO;
using Goedel.Utilities;
using Goedel.Test;
using Goedel.Mesh.Portal.Server;
using Test.Goedel.Mesh;
using Test.Goedel.Cryptography.Container;
using Test.Cryptography.Algorithms;
using Goedel.Cryptography.Algorithms;
using Test.Goedel.Cryptography;

namespace Scratchpad {



    partial class Program {
        static void Main (string[] args) {
            //CryptographyWindows.Initialize();

            //TestEncryptDecrypt();


            //TestPersistenceContainers.TestDirect();

            TestRecrypt.TestDirect();




            //TestFileContainer.TestFileContainerDirect();
            //TestServices.TestServicesDirect();

            //TestConfirm.TestServicesDirect();


            // These test TRD
            //TestCatalog.TestServicesDirect();
            //TestSSH.TestServicesDirect();
            //TestMail.TestServicesDirect();

            //TestDigests.TestDirect();

            //TestGoedelCryptography.TestDirect();

            }

        static KeyPair CreateKeyPair () {
            var Result = new KeyPairDH();
            KeyCollection.Default.Add(Result);

            return Result;
            }


        static void TestEncryptDecrypt () {
            //string FileName = "TopSecret.jcx";
            string TestData = "<h1>Tippety Top Secret</h1>";
            KeyPair EncryptionKey = CreateKeyPair();

            var Recipients = EncryptionKey == null ? null : new List<KeyPair> { EncryptionKey };

            // Create container
            var CipherText = FileContainerWriter.Data(TestData.ToBytes(), null, Recipients: Recipients);


            FileContainerReader.Data(CipherText, out var ReadData, out var ContentMetaOut);

            var Result = ReadData.ToUTF8();
            }






        byte[] Empty = new byte[0];

        // The tree methods do not currently work when re-opening an existing file
        // it is necessary to re-traverse the chain to build pointers to the previous powers of 2.


        string Service => "example.com";
        string AccountAlice => $"alice@{Service}";
        string AccountBob => $"bob@{Service}";


        public void Go3() {

            // create singleton container of one file


            // read back


            // create with encryption

            // read back


            // bulk tests


            }


        public void Go4 () {

            // create archive container of X files


            // read back


            // create with encryption

            // read back


            // bulk tests


            }



        }
    }
