using System;
using System.Collections.Generic;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography;
using Goedel.Utilities;
using System.IO;
using Goedel.Protocol;
using Goedel.Test;

namespace Goedel.Cryptography.Dare.Test {
    [MT.TestClass]
    public partial class TestDare {

        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect() {
            InitializeClass();

            var TestDare = new TestDare();
            //TestDare.MessagePlaintext();


            var TestContainers = new TestContainers();

            var Test1 = Platform.GetRandomBytes(1000);
            var Recipients = new List<string> { "Alice@example.com" };
            var Signers = new List<string> { "Alice@example.com" };
            var CryptoParameters = new CryptoParametersTest(
                        //Recipients: Recipients,
                        //Signers: Signers
                        );

            //TestDare.ReadWriteArchive("TestArchive_", 1, CryptoParameters, false);

            TestContainers.TestContainer($"ContainerList", ContainerType.Digest, 1, 
                CryptoParameters: CryptoParameters);


            //TestDare.MessageSignAtomic();
            //TestContainers.TestContainer($"ContainerList", ContainerType.List, 1);
            }



        [MT.AssemblyInitialize]
        public static void InitializeClass(MT.TestContext Context) => InitializeClass();
        public static void InitializeClass() {
            global::Goedel.IO.Debug.Initialize();
            CryptographyWindows.Initialize();
            }

        }

    public partial class TestContainers {
        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect() {
            TestDare.InitializeClass();

            var TestContainers = new TestContainers();

            //TestDare.MessagePlaintext();
            TestContainers.ContainerTestList();
            //TestDare.MessageEncryptedAtomic();

            }


        }
    }
