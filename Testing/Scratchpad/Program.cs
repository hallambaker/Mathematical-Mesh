using System;
using System.Diagnostics;
using System.Collections.Generic;
using Goedel.Cryptography.Dare;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Framework;
using Goedel.Cryptography.KeyFile;
using Goedel.IO;
using Goedel.Utilities;
using Goedel.Protocol.Test;
using Goedel.Mesh.Portal.Server;
using Test.Goedel.Mesh;
using Test.Goedel.Cryptography.Container;
using Test.Cryptography.Algorithms;
using Goedel.Cryptography.Algorithms;
using Test.Goedel.Cryptography;

namespace Scratchpad {



    partial class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World");

            Goedel.IO.Debug.Initialize();
            GoedelProtocol.TestDirect();
            }
        
        //CryptographyWindows.Initialize();
        //var Test1 = Platform.GetRandomBytes(1000);
        //var Test2 = Platform.GetRandomBytes(100);
        //var Test3 = Platform.GetRandomBytes(50);
        //var DataSequences = new List<byte[]> { Test2, Test3 };
        //var AlicePrivate = new DiffeHellmanPrivate();
        //var AliceKeypair = new KeyPairDH(AlicePrivate);
        //var AlicePublic = AlicePrivate.DiffeHellmanPublic;
        //var AlicePublicKeypair = new KeyPairDH(AlicePublic);
        //var EncryptionKeys = new List<KeyPair> { AlicePublicKeypair };
        //Console.WriteLine("Blank");
        //JSONReader.Trace = true;
        
        //// Plaintext atomic
        //var Message = new DAREMessage(Test1);
        //var MessageJSON = Message.GetJson(false);
        //Console.WriteLine("Plaintext Atomic");
        //Console.WriteLine(MessageJSON.ToUTF8());
        //TestDare.CheckDecodeDirect(MessageJSON, Test1);
        
        //// Plaintext atomic EDS
        //var MessageAtomicDS = new DAREMessage(Test1, DataSequences: DataSequences);
        //Console.WriteLine("Plaintext Atomic");
        //Console.WriteLine(MessageAtomicDS.GetJson(false).ToUTF8());
        
            //// Plaintext atomic
        //var MessageEnc = new DAREMessage(Test1, EncryptionKeys: EncryptionKeys);
        //Console.WriteLine("Plaintext Atomic");
        //Console.WriteLine(MessageEnc.GetJson(false).ToUTF8());
        //// Plaintext atomic EDS
        //var MessageAtomicDSEnc = new DAREMessage(Test1, EncryptionKeys: EncryptionKeys, DataSequences: DataSequences);
        //Console.WriteLine("Plaintext Atomic");
        //Console.WriteLine(MessageAtomicDSEnc.GetJson(false).ToUTF8());
        //// Plaintext fixed
        //var OutputStreamFixed = new MemoryStream();
        //var MessageFixed = new DAREMessage(OutputStreamFixed);
        //WriteBody(MessageFixed, Test1);
        //Console.WriteLine("Plaintext Fixed");
        //Console.WriteLine(OutputStreamFixed.ToArray().ToUTF8());
        //// Plaintext variable
        //var OutputStreamVariable = new MemoryStream();
        //var MessageVariable = new DAREMessage(OutputStreamVariable);
        //WriteBody(MessageVariable, Test1, 23);//Console.WriteLine("Plaintext Variable");
        //Console.WriteLine(OutputStreamVariable.ToArray().ToUTF8());//Console.WriteLine();
        //Console.WriteLine("WithDS");
        //// Plaintext fixed
        //var OutputStreamFixedDS = new MemoryStream();
        //var MessageFixedDS = new DAREMessage(OutputStreamFixedDS);
        //WriteBody(MessageFixedDS, Test1);
        //Console.WriteLine("Plaintext Fixed");
        //Console.WriteLine(OutputStreamFixedDS.ToArray().ToUTF8());
        //// Plaintext variable
        //var OutputStreamVariableDS = new MemoryStream();
        //var MessageVariableDS = new DAREMessage(OutputStreamVariableDS);
        //WriteBody(MessageVariableDS, Test1, 23);
        //Console.WriteLine(OutputStreamVariableDS.ToArray().ToUTF8());
        //Console.WriteLine();
        //Console.WriteLine("Encrypted");
        //// Plaintext fixed
        //var OutputStreamFixedEnc = new MemoryStream();
        //var MessageFixedEnc = new DAREMessage(OutputStreamFixedEnc, EncryptionKeys: EncryptionKeys);
        //WriteBody(MessageFixedEnc, Test1);
        //Console.WriteLine("Plaintext Fixed");
        //Console.WriteLine(OutputStreamFixedEnc.ToArray().ToUTF8());
        //// Plaintext variable
        //var OutputStreamVariableEnc = new MemoryStream();
        //var MessageVariableEnc = new DAREMessage(OutputStreamVariableEnc, EncryptionKeys: EncryptionKeys);
        //WriteBody(MessageVariableEnc, Test1, 23);
        //Console.WriteLine("Plaintext Variable");
        //Console.WriteLine(OutputStreamVariableEnc.ToArray().ToUTF8());
        //Console.WriteLine();
        //Console.WriteLine("WithDS");
        //// Plaintext fixed
        //var OutputStreamFixedDSEnc = new MemoryStream();
        //var MessageFixedDSEnc = new DAREMessage(OutputStreamFixedDSEnc, EncryptionKeys: EncryptionKeys);//WriteBody(MessageFixedDSEnc, Test1);
        //Console.WriteLine("Plaintext Fixed");
        //Console.WriteLine(OutputStreamFixedDSEnc.ToArray().ToUTF8());
        //// Plaintext variable
        //var OutputStreamVariableDSEnc = new MemoryStream();
        //var MessageVariableDSEnc = new DAREMessage(OutputStreamVariableDSEnc, EncryptionKeys: EncryptionKeys);
        //WriteBody(MessageVariableDSEnc, Test1, 23);
        //Console.WriteLine(OutputStreamVariableDSEnc.ToArray().ToUTF8());
        //var Message2 = DAREMessage.FromJSON(MessageBytes.JSONReader());
        //TestDare.TestDirect();
        //TestEncryptDecrypt();
        //TestRecrypt.TestDirect();
        //TestFileContainer.TestFileContainerDirect();
        //TestServices.TestServicesDirect();
        //TestConfirm.TestServicesDirect();
        // These test TRD
        //TestCatalog.TestServicesDirect();
        //TestSSH.TestServicesDirect();
        //TestMail.TestServicesDirect();
        //TestDigests.TestDirect();
        //TestGoedelCryptography.TestDirect();



        static void WriteBody (DAREMessage Message, byte[] Plaintext, int Stride=0) {
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
