using System;
using System.Diagnostics;
using System.Collections.Generic;
using Goedel.Cryptography.Dare;
using Goedel.Mesh;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.KeyFile;
using Goedel.Test;
using Goedel.Utilities;
using Goedel.Protocol.Test;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Test;
using Goedel.Cryptography.Jose.Test;
using Goedel.Cryptography.KeyFile.Test;
using Goedel.Cryptography.DH.Test;
using Goedel.Cryptography.Windows.Test;
using Goedel.DNS.Test;
using Goedel.Mesh.Test_Windows;
using Goedel.Cryptography.Test_xunit;
using Goedel.Test.Core;

namespace Scratchpad {



    partial class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World");

            //TestDare.TestDirect();
            //TestEnvironment.Initialize(true);

            //TestCryptographyJose.InitializeClass();
            //TestCryptographyJose.Test().Test_Write_DH_Private();
            //TestAsymmetric.Test().EncryptTest(CryptoAlgorithmID.DH);

            //var TestSplit = new TestSplit();
            //TestSplit.TestShares(3, 2);



            //TestLifecycle.Test.Test_LifecycleMaster(CryptoAlgorithmID.RSAExch);
            //TestLifecycle.Test.Test_LifecycleAdmin(CryptoAlgorithmID.RSAExch);
            //TestLifecycle.Test.Test_LifecycleDevice(CryptoAlgorithmID.RSAExch);
            //TestLifecycle.Test.Test_LifecycleEphemeral(CryptoAlgorithmID.RSAExch);
            //TestLifecycle.Test.Test_LifecycleExportable(CryptoAlgorithmID.RSAExch);

            //TestLifecycle.Test().Test_LifecycleDevice(CryptoAlgorithmID.RSASign);
            //TestLifecycle.Test().Test_LifecycleEphemeral(CryptoAlgorithmID.Ed25519);
            TestLifecycle.Test().Test_LifecycleExportable(CryptoAlgorithmID.RSASign);
            TestLifecycle.Test().Test_LifecycleMaster(CryptoAlgorithmID.RSASign);



            //TestProfilesWindows.TestDirect();


            //TestAsymmetric.Test.EncryptTest(CryptoAlgorithmID.DH);
            //foreach (var Test in new RFC8032()) {
            //    TestAsymmetric.Test().TestRFC8032((TestVectorAsymmetric)Test[0]);
            //    }

            //TestProfilesWindows.TestDirect();
            //CatalogTests.TestDirect();
            //TestCryptographyJose.TestDirect();
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
            var Recipients = new List<string> { "Alice@example.com" };
            var CryptoParameters = new Goedel.Test.CryptoParametersTest(
                        Recipients: Recipients);


            // Create container
            var CipherText = FileContainerWriter.Data(
                        TestData.ToBytes(), null, CryptoParameters: CryptoParameters);


            FileContainerReader.Data(CipherText, out var ReadData, out var ContentMetaOut);

            var Result = ReadData.ToUTF8();
            }







        }
    }
