using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Utilities;
using Goedel.Mesh.Test;
using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Core;
using Goedel.Test.Core;

namespace Goedel.Cryptography.DH.Test {

    public partial class TestCryptography {

        public MeshMachineTest MeshMachine;
        KeyCollection KeyCollection;

        public TestCryptography() {
            MeshMachine = new MeshMachineTest();
            KeyCollection = new KeyCollectionTest(MeshMachine);
            }

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

            var AliceKey = AliceAgree.EphemeralPublicValue;

            var BobAgreement = BobPrivate.Agreement(AliceKey);

            UT.Assert.IsTrue(BobAgreement.Equals(AliceAgree.Agreement));
            }

        [TestMethod]
        public void TestDH_Recryption_2 () {

            var BobSplit = GroupPrivate.MakeRecryptionKeySet(2);
            var BobRecryption = BobSplit[0] as DiffeHellmanPrivate;
            var BobDecryption = BobSplit[1] as DiffeHellmanPrivate; 


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
        public void TestDH_Recryption_8() => TestRecrypt(8);

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
            var KeySet = GroupPrivate.MakeRecryptionKeySet(Shares);

            // Calculate part results
            var Recrypts = new BigInteger[Shares];
            for (var i = 0; i < Shares; i++) {
                Recrypts[i] = (KeySet[i] as DiffeHellmanPrivate ).Agreement(AlicePublic);
                }

            // Combine them
            var BobAgreeW = GroupKeyPublic.Agreement(Recrypts);

            UT.Assert.IsTrue(AliceAgreeW == BobAgreeW);
            }



        [TestMethod]
        public void TestDH_Encrypt() => BobKeyPair.Test_EncryptDecrypt();

        [TestMethod]
        public void TestDH_KeyGen() {
            var Encrypter = KeyPair.Factory(CryptoAlgorithmID.DH, KeySecurity.Ephemeral);

            var EncrypterKeyPair = Encrypter as KeyPairDH;

            EncrypterKeyPair.Test_EncryptDecrypt();
            }


        [TestMethod]
        public void TestDH_ReadKey() {
            var PublicPKIX = AliceKeyPair.PKIXPublicKeyDH;

            var NewSigner = KeyPairBaseDH.KeyPairPublicFactory(PublicPKIX);

            UT.Assert.IsNotNull(NewSigner);
            }


        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_LifecycleMaster_DH() => CryptoAlgorithmID.Test_LifecycleMaster(KeyCollection);

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_LifecycleAdmin_DH() => CryptoAlgorithmID.Test_LifecycleAdmin(KeyCollection);

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_LifecycleDevice_DH() => CryptoAlgorithmID.Test_LifecycleDevice(KeyCollection);

        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_LifecycleEphemeral_DH() => CryptoAlgorithmID.Test_LifecycleEphemeral(KeyCollection);


        /// <summary>Test key lifecycles</summary>
        [TestMethod]
        public void Test_LifecycleExportable_DH() => CryptoAlgorithmID.Test_LifecycleExportable(KeyCollection);

        }
    }
