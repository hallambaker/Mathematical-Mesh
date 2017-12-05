using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Utilities;
using Goedel.Test;
using Goedel.Cryptography.Framework;

namespace Goedel.Cryptography.Test {

    public partial class TestCryptography {

        [TestMethod]
        public void TestDHAlg_SimpleAgreement() {

            var AliceKey = AlicePrivate.Agreement(BobPublic);
            var BobKey = BobPrivate.Agreement(AlicePublic);

            UT.Assert.IsTrue(AliceKey.Equals(BobKey));
            UT.Assert.IsTrue(BobKey.Equals(AliceKey));

            }
        
        [TestMethod]
        public void Test_DHAlg_Ephemeral_Agreement() {

            var AliceAgree = BobPublic.Agreement();

            var AliceKey = AliceAgree.Public as DHKeyPair;

            var BobAgreement = BobPrivate.Agreement(AliceKey.PublicKey);

            UT.Assert.IsTrue(BobAgreement.Equals(AliceAgree.Agreement));
            }

        [TestMethod]
        public void TestDH_Recryption_2 () {

            var BobSplit = GroupPrivate.MakeRecryption(2);
            var BobRecryption = BobSplit[0];
            var BobDecryption = BobSplit[1];


            var AliceAgreeW = AlicePrivate.Agreement(GroupKeyPublic);
            var ServerRecrypt = BobRecryption.Agreement(AlicePublic);
            var BobAgreeW = BobDecryption.Agreement(AlicePublic, ServerRecrypt);

            UT.Assert.IsTrue(AliceAgreeW == BobAgreeW );

            }
        [TestMethod]
        public void TestDH_Recryption_2_100() {
            for (var i = 0; i < 100; i++) {
                TestDH_Recryption_2();
                }
            }

        [TestMethod]
        public void TestDH_Recryption_8() {
            TestRecrypt(8);
            }

        [TestMethod]
        public void TestDH_Recryption_n_5() {
            for (var i = 0; i < 5; i++) {
                for (var n = 2; n < 16; n++) {
                    TestRecrypt(n);
                    }
                }
            }


        void TestRecrypt (int Shares) {
            // Alice's encryption
            var AliceAgreeW = AlicePrivate.Agreement(GroupKeyPublic);

            // Keyset for decryption
            var KeySet = GroupPrivate.MakeRecryption(Shares);

            // Calculate part results
            var Recrypts = new BigInteger[Shares];
            for (var i = 0; i < Shares; i++) {
                Recrypts[i] = KeySet[i].Agreement(AlicePublic);
                }

            // Combine them
            var BobAgreeW = GroupKeyPublic.Agreement(Recrypts);

            UT.Assert.IsTrue(AliceAgreeW == BobAgreeW);
            }



        [TestMethod]
        public void TestDH_Encrypt () {
            BobKeyPair.Test_EncryptDecrypt();
            }

        [TestMethod]
        public void TestDH_KeyGen() {
            var Encrypter = CryptoCatalog.Default.GetExchange(CryptoAlgorithmID.DH);
            Encrypter.Generate(KeySecurity.Ephemeral, KeySize: 2048);
            var EncrypterKeyPair = Encrypter.KeyPair as DHKeyPair;

            EncrypterKeyPair.Test_EncryptDecrypt();
            }


        [TestMethod]
        public void TestDH_ReadKey() {
            var PublicPKIX = AliceKeyPair.PKIXPublicKeyDH;

            var NewSigner = DHKeyPairBase.KeyPairPublicFactory(PublicPKIX);

            UT.Assert.IsNotNull(NewSigner);
            }


        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_LifecycleMaster_DH() {
            CryptoAlgorithmID.Test_LifecycleMaster();
            }

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_LifecycleAdmin_DH() {
            CryptoAlgorithmID.Test_LifecycleAdmin();
            }

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_LifecycleDevice_DH() {
            CryptoAlgorithmID.Test_LifecycleDevice();
            }

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_LifecycleEphemeral_DH() {
            CryptoAlgorithmID.Test_LifecycleEphemeral();
            }


        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_LifecycleExportable_DH() {
            CryptoAlgorithmID.Test_LifecycleExportable();
            }

        }
    }
