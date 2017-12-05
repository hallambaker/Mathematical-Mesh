using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GU=Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Framework;

namespace Test.Goedel.Cryptography {

    public partial class TestGoedelCryptography {

        [AssemblyInitialize]
        public static void Initialize (TestContext Context) {
            CryptographyFramework.Initialize();
            }


        [TestMethod]
        public void TestInitialize() {
            CryptographyFramework.Initialize();
            }


        [TestMethod]
        public void TestRandom() {
            var Random1 = Platform.GetRandomBytes(10);
            var Random2 = Platform.GetRandomBigInteger(2048);
            }

        }
    }
