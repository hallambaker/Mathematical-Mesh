using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Cryptography;
using Goedel.Cryptography.Framework;

namespace Test.Goedel.ASN {
    [TestClass]
    public partial class TestCryptography {

        [AssemblyInitialize]
        public static void Initialize (TestContext Context) {
            CryptographyFramework.Initialize();
            }


        }
    }
