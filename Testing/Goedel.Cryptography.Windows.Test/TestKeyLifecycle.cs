using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Cryptography;
using Goedel.Cryptography.Windows;
using Goedel.Test;
using Goedel.Utilities;

namespace Goedel.Cryptography.Windows.Test {

    public partial class TestCryptographyWindows {


        /// <summary>
        /// Delete all test keys
        /// </summary>

        [TestCleanupAttribute]
        public void Cleanup() {
            // Test: Delete all test keys
            }

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Windows_LifecycleMaster_RSA() => CryptoAlgorithmID.RSAExch.Test_LifecycleMaster();

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Windows_LifecycleAdmin_RSA() => CryptoAlgorithmID.RSAExch.Test_LifecycleAdmin();

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Windows_LifecycleDevice_RSA() => CryptoAlgorithmID.RSAExch.Test_LifecycleDevice();

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Windows_LifecycleEphemeral_RSA() => CryptoAlgorithmID.RSAExch.Test_LifecycleEphemeral();

        /// <summary>The reason this test fails is that the doofus RSACryptoServiceProvider
        /// does not allow ephemeral keys to be imported. It is stupid, stupid, stupid.
        /// Fixing this will require transitioning to the RSACng provider which
        /// will take some time and should probably be done at the same time
        /// that the ECDH keys are added.</summary>
        [TestMethod]
        public void Test_Windows_LifecycleExportable_RSA() => CryptoAlgorithmID.RSAExch.Test_LifecycleExportable();


        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Windows_LifecycleMaster_DH() => CryptoAlgorithmID.DH.Test_LifecycleMaster();

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Windows_LifecycleAdmin_DH() => CryptoAlgorithmID.DH.Test_LifecycleAdmin();

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Windows_LifecycleDevice_DH() => CryptoAlgorithmID.DH.Test_LifecycleDevice();

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Windows_LifecycleEphemeral_DH() => CryptoAlgorithmID.DH.Test_LifecycleEphemeral();


        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Windows_LifecycleExportable_DH() => CryptoAlgorithmID.DH.Test_LifecycleExportable();




        }
    }