using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GU=Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Test;

namespace Goedel.Cryptography.Windows.Test {
    [TestClass]
    public partial class TestCryptographyWindows {

        public static void TestDirect() {
            InitializeClass();

            var TestCryptographyWindows = new TestCryptographyWindows();
            TestCryptographyWindows.Test_Windows_Lifecycle_DH();
            }
        const CryptoAlgorithmID CryptoAlgorithmID = Goedel.Cryptography.CryptoAlgorithmID.RSAExch;

        [AssemblyInitialize]
        public static void Initialize(TestContext Context) => InitializeClass();


        public static void InitializeClass() {
            Goedel.IO.Debug.Initialize();
            CryptographyWindows.Initialize();
            }


        }
    }
