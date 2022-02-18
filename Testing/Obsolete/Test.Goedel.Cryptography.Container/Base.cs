using System;
using System.Collections.Generic;
using MT=Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography;
using Goedel.Utilities;
using System.IO;
using Goedel.Protocol;
using Goedel.Test;

namespace Test.Goedel.Cryptography.Container {
    [MT.TestClass]
    public partial class TestContainers {

        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect() {
            InitializeClass();

            var Instance = new TestContainers();
            Instance.ContainerTestTree();
            Instance.ContainerTestMerkleTree();
            }



        [MT.AssemblyInitialize]
        public static void InitializeClass(MT.TestContext Context) => InitializeClass();
        public static void InitializeClass() => CryptographyFramework.Initialize();


        }
    }
