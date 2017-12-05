using System.Numerics;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT=Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Utilities;
using Goedel.Test;
using Goedel.Cryptography;
//using Goedel.Cryptography.Framework;

namespace Goedel.Cryptography.Test {
    public partial class TestCryptography {

        string TestString = "This is a test";
        string TestStringBad = "This is a Test"; // Flip one bit

        /// <summary>
        /// Delete all test keys
        /// </summary>

        [TestCleanupAttribute]
        public void Cleanup() {
            // Test: Delete all test keys
            }



        bool CheckWorkingRSAKey (RSAKeyPairBase Key) {

            return false;
            }


        /// <summary>
        /// Sign and verify.
        /// </summary>

        [TestMethod]
        public void TestRSA_Sign() {
            var Result = Signer.Sign(TestString);
            var Signature = Result.Signature;
            var Verify = Signer.Verify(TestString, Signature);

            UT.Assert.IsTrue(Verify);
            }


        [TestMethod]
        public void TestRSA_Sign_Fail() {
            var Result = Signer.Sign(TestString);
            var Signature = Result.Signature;
            var Verify = Signer.Verify(TestStringBad, Signature);

            UT.Assert.IsFalse(Verify);
            }


        /// <summary>
        /// Encrypt and decrypt
        /// </summary>

        [TestMethod]
        public void TestRSA_Encrypt() {
            EncrypterKeyPair.Test_EncryptDecrypt();
            }


        /// <summary>
        /// Key generation
        /// </summary>

        [TestMethod]
        public void TestRSA_KeyGen() {

            var Encrypter = CryptoCatalog.Default.GetExchange(CryptoAlgorithmID.RSAExch);
            Encrypter.Generate(KeySecurity.Ephemeral, KeySize: 2048);
            var ThisEncrypterKeyPair = Encrypter.KeyPair;
            ThisEncrypterKeyPair.Test_EncryptDecrypt();

            var Signer = CryptoCatalog.Default.GetSignature(CryptoAlgorithmID.RSASign);
            Signer.Generate(KeySecurity.Ephemeral, KeySize: 2048);
            var SignerKeyPair = Signer.KeyPair;

            }

        /// <summary>
        /// Read key from PKIX parameter blob
        /// </summary>
        [TestMethod]
        public void TestRSA_ReadKey() {
            var SignerPKIX = SignerKeyPair.PKIXPublicKeyRSA;
            var NewSigner = RSAKeyPairBase.KeyPairPublicFactory (SignerPKIX);
            UT.Assert.IsNotNull(NewSigner);
            }

        ///// <summary>Test key lifecycles</summary>
        //[TestMethod]
        //public void Test_LifecycleMaster_RSA() {
        //    CryptoAlgorithmID.Test_LifecycleMaster();
        //    }

        ///// <summary>Test key lifecycles</summary>
        //[TestMethod]
        //public void Test_LifecycleAdmin_RSA() {
        //    CryptoAlgorithmID.Test_LifecycleAdmin();
        //    }

        ///// <summary>Test key lifecycles</summary>
        //[TestMethod]
        //public void Test_LifecycleDevice_RSA() {
        //    CryptoAlgorithmID.Test_LifecycleDevice();
        //    }

        ///// <summary>Test key lifecycles</summary>
        //[TestMethod]
        //public void Test_LifecycleEphemeral_RSA() {
        //    CryptoAlgorithmID.Test_LifecycleEphemeral();
        //    }

        ///// <summary>Test key lifecycles</summary>
        //[TestMethod]
        //public void Test_LifecycleExportable_RSA() {
        //    CryptoAlgorithmID.Test_LifecycleExportable();
        //    }

        }
    }
