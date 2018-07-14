using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GU=Goedel.Utilities;
using Goedel.Cryptography;

namespace Test.Goedel.Cryptography {

    public partial class TestGoedelCryptography {

        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect () {
            InitializeClass();

            var Instance = new TestGoedelCryptography();
            Instance.Ed448RecoverX();
            Instance.TestDHEd448Decode();
            }



        [AssemblyInitialize]
        public static void InitializeClass(TestContext Context) => InitializeClass();
        public static void InitializeClass() => CryptographyWindows.Initialize();

        [TestMethod]
        public void TestInitialize() => CryptographyWindows.Initialize();


        [TestMethod]
        public void TestRandom() {
            var Random1 = Platform.GetRandomBytes(10);
            var Random2 = Platform.GetRandomBigInteger(2048);
            }

        }
    }
