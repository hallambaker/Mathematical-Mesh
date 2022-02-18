using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Cryptography;
using Goedel.Cryptography.Windows;
using Goedel.Mesh.Test;
using Goedel.Utilities;

namespace Goedel.Cryptography.Windows.Test {

    public partial class TestCryptographyWindows {
        KeyCollection KeyCollection;

        [AssemblyInitialize]
        public void Initialize() => KeyCollection = new KeyCollectionWindows();


        /// <summary>
        /// Delete all test keys
        /// </summary>

        [TestCleanup]
        public void Cleanup() {
            // Test: Delete all test keys
            }

        [TestMethod]
        public void Test_Windows_Lifecycle_RSAExch() => CryptoAlgorithmID.RSAExch.Test_Lifecycle(KeyCollection);

        [TestMethod]
        public void Test_Windows_Lifecycle_RSASign() => CryptoAlgorithmID.RSASign.Test_Lifecycle(KeyCollection);

        [TestMethod]
        public void Test_Windows_Lifecycle_DH() => CryptoAlgorithmID.DH.Test_Lifecycle(KeyCollection);

        [TestMethod]
        public void Test_Windows_Lifecycle_Ed25519() => CryptoAlgorithmID.Ed25519.Test_Lifecycle(KeyCollection);

        [TestMethod]
        public void Test_Windows_Lifecycle_Ed448() => CryptoAlgorithmID.Ed448.Test_Lifecycle(KeyCollection);

        [TestMethod]
        public void Test_Windows_Lifecycle_X25519() => CryptoAlgorithmID.X25519.Test_Lifecycle(KeyCollection);

        [TestMethod]
        public void Test_Windows_Lifecycle_X448() => CryptoAlgorithmID.X448.Test_Lifecycle(KeyCollection);

        }
    }