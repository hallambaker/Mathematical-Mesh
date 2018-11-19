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
using Goedel.Cryptography.Algorithms;
using Goedel.XUnit;

using Goedel.Test.Core;


namespace Scratchpad {



    partial class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World");
            TestService.Test().ProtocolAccountLifecycle();
            //TestLifecycle.Test().Test_LifecycleMaster(CryptoAlgorithmID.Ed25519);
            //TestDare.Test().TestPersistenceStore();
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
            //TestLifecycle.Test().Test_LifecycleExportable(CryptoAlgorithmID.RSASign);
            //TestLifecycle.Test().Test_LifecycleMaster(CryptoAlgorithmID.RSASign);



            //TestProfilesWindows.TestDirect();


            //TestAsymmetric.Test.EncryptTest(CryptoAlgorithmID.DH);
            //foreach (var Test in new RFC8032()) {
            //    TestAsymmetric.Test().TestRFC8032((TestVectorAsymmetric)Test[0]);
            //    }

            //TestProfilesWindows.TestDirect();
            //CatalogTests.TestDirect();
            //TestCryptographyJose.TestDirect();
            }


        }
    }
