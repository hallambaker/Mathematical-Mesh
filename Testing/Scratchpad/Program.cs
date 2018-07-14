using System;
using System.Diagnostics;
using System.Collections.Generic;
using Goedel.Cryptography.Dare;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.KeyFile;
using Goedel.IO;
using Goedel.Utilities;
using Goedel.Protocol.Test;
using Goedel.Catalog.Test;
using Goedel.Mesh.Portal.Server;
using Test.Goedel.Mesh;
using Goedel.Cryptography.Dare.Test;
using Test.Cryptography.Algorithms;
using Goedel.Cryptography.Algorithms;
using Test.Goedel.Cryptography;
using Goedel.Cryptography.Jose.Test;
using Goedel.Cryptography.KeyFile.Test;
using Goedel.Cryptography.DH.Test;
using Goedel.Cryptography.Windows.Test;

namespace Scratchpad {



    partial class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World");

            Goedel.IO.Debug.Initialize();

            //TestCryptography.TestDirect();
            TestDare.TestDirect();
            }




        static void WriteBody(DAREMessage Message, byte[] Plaintext, int Stride = 0) {
            if (Stride <= 0) {
                Message.Process(Plaintext, true);
                return;
                }

            for (long i = 0; i < Plaintext.LongLength; i += Stride) {
                var Length = Plaintext.LongLength - i;
                if (Length > Stride) {
                    Message.Process(Plaintext, false, i, Stride);
                    }
                else {
                    Message.Process(Plaintext, true, i, Length);
                    }
                }
            }







        static KeyPair CreateKeyPair(bool Register=true) {
            var Result = new KeyPairDH();
            if (Register) {
                KeyCollection.Default.Add(Result);
                }
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







        }
    }
