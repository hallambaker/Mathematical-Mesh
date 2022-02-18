using System;
using System.Collections.Generic;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography;
using Goedel.Utilities;
using Goedel.IO;
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
            //Test.MessageEncrypted();


            //var Test1 = Platform.GetRandomBytes(100);
            //var Recipients = new List<string> { "Alice@example.com" };
            //var Signers = new List<string> { "Alice@example.com" };

            //var TestDare = new TestDare();
            //var TestContainers = new TestContainers();
            //////TestDare.TestArchive1();

            //var CryptoParameters = new CryptoParametersTest(
            //            //Recipients: Recipients,
            //            //Signers: Signers
            //            );
            //TestContainers.TestContainer($"ContainerScratch", ContainerType.Chain, Records:100,
            //    CryptoParametersEntry: CryptoParameters, MoveStep: 13, ReOpen: 27);

            ////var EncryptingContainer = Container.NewContainer("Test1Enc", FileStatus.New, CryptoParameters, ContainerType.List);
            ////EncryptingContainer.Append(Test1);
            ////EncryptingContainer.Append(Test1);



            ////TestDare.TestMessageAtomic(Test1, CryptoParameters);

            ////TestDare.ReadWriteArchive("TestArchive_", 1, CryptoParameters, false);


            //TestContainers.ContainerTest500();


            //




            //TestContainers.TestContainer($"ContainerTest", ContainerType.List, 1,
            //        CryptoParameters: CryptoParameters);


            //TestContainers.ContainerTest500();
            //TestContainers.TestContainer($"ContainerList", ContainerType.List, 1);
            }



        [MT.AssemblyInitialize]
        public static void InitializeClass(MT.TestContext Context) => InitializeClass();

        public static void InitializeClass() {
            global::Goedel.IO.Debug.Initialize();
            Cryptography.Initialize();
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
            //TestContainers.ContainerTestList();
            //TestDare.MessageEncryptedAtomic();

            }


        }
    }
