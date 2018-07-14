using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Cryptography;


namespace Test.Goedel.ASN {
    [TestClass]
    public partial class TestCryptography {

        [AssemblyInitialize]
        public static void Initialize(TestContext Context) => CryptographyWindows.Initialize();


        }
    }
