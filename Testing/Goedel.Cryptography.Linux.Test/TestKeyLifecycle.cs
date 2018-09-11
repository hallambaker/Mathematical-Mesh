using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Cryptography;
using Goedel.Cryptography.Linux;
using Goedel.Test;
using Goedel.Utilities;

namespace Goedel.Cryptography.Linux.Test {

    public partial class TestCryptography {


        /// <summary>
        /// Delete all test keys
        /// </summary>

        [TestCleanupAttribute]
        public void Cleanup() {
            // Test: Delete all test keys
            }

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Linux_LifecycleMaster_RSA() => CryptoAlgorithmID.RSAExch.Test_LifecycleMaster();

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Linux_LifecycleAdmin_RSA() => CryptoAlgorithmID.RSAExch.Test_LifecycleAdmin();

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Linux_LifecycleDevice_RSA() => CryptoAlgorithmID.RSAExch.Test_LifecycleDevice();

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Linux_LifecycleEphemeral_RSA() => CryptoAlgorithmID.RSAExch.Test_LifecycleEphemeral();

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Linux_LifecycleExportable_RSA() => CryptoAlgorithmID.RSAExch.Test_LifecycleExportable();


        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Linux_LifecycleMaster_DH() => CryptoAlgorithmID.DH.Test_LifecycleMaster();

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Linux_LifecycleAdmin_DH() => CryptoAlgorithmID.DH.Test_LifecycleAdmin();

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Linux_LifecycleDevice_DH() => CryptoAlgorithmID.DH.Test_LifecycleDevice();

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Linux_LifecycleEphemeral_DH() => CryptoAlgorithmID.DH.Test_LifecycleEphemeral();


        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_Linux_LifecycleExportable_DH() => CryptoAlgorithmID.DH.Test_LifecycleExportable();




        }
    }