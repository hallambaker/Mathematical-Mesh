using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Test;

using System.Numerics;

using Xunit;

namespace Goedel.XUnit {

    public partial class TestCryptography {


        public static KeyPairDH AliceKeyPair;
        public static KeyPairDH BobKeyPair;
        public static KeyPairDH GroupKeyPair;

        public static DiffeHellmanPrivate AlicePrivate;
        public static DiffeHellmanPrivate BobPrivate;
        public static DiffeHellmanPrivate GroupPrivate;

        public static DiffeHellmanPublic AlicePublic;
        public static DiffeHellmanPublic BobPublic;
        public static DiffeHellmanPublic GroupKeyPublic;

        public MeshMachineTest MeshMachine;
        public KeyCollection KeyCollection;

        static TestCryptography() {
            AlicePrivate = new DiffeHellmanPrivate();
            BobPrivate = new DiffeHellmanPrivate();
            GroupPrivate = new DiffeHellmanPrivate();

            AliceKeyPair = new KeyPairDH(AlicePrivate);
            BobKeyPair = new KeyPairDH(BobPrivate);
            GroupKeyPair = new KeyPairDH(GroupPrivate);

            AlicePublic = AlicePrivate.DiffeHellmanPublic;
            BobPublic = BobPrivate.DiffeHellmanPublic;
            GroupKeyPublic = GroupPrivate.DiffeHellmanPublic;
            }


        public TestCryptography() {
            //var machineEnvironment = new TestEnviron_USELESS_DELETE( "TestCryptography");
            var testEnvironmentCommon = new TestEnvironmentCommon();

            MeshMachine = new MeshMachineTest(testEnvironmentCommon);
            KeyCollection = new KeyCollectionTest(MeshMachine);
            }

        [Fact]
        public void TestDHAlg_SimpleAgreement() {

            var AliceKey = AlicePrivate.Agreement(BobPublic);
            var BobKey = BobPrivate.Agreement(AlicePublic);

            (AliceKey.Equals(BobKey)).TestTrue();
            (BobKey.Equals(AliceKey)).TestTrue();

            }

        [Fact]
        public void Test_DHAlg_Ephemeral_Agreement() {

            var AliceAgree = BobPublic.Agreement();

            var AliceKey = AliceAgree.EphemeralPublicValue;

            var BobAgreement = BobPrivate.Agreement(AliceKey);

            BobAgreement.Equals(AliceAgree.Agreement).TestTrue(); 
            }

        [Fact]
        public void TestDH_Recryption_2() {

            var BobSplit = GroupPrivate.MakeThresholdKeySet(2);
            var BobRecryption = BobSplit[0] as DiffeHellmanPrivate;
            var BobDecryption = BobSplit[1] as DiffeHellmanPrivate;


            var AliceAgreeW = AlicePrivate.Agreement(GroupKeyPublic);
            var ServerRecrypt = BobRecryption.Agreement(AlicePublic);
            var BobAgreeW = BobDecryption.Agreement(AlicePublic, ServerRecrypt);

            (AliceAgreeW == BobAgreeW).TestTrue();

            }

        [Fact]
        public void TestDH_Recryption_2_100() {
            for (var i = 0; i < 100; i++) {
                TestDH_Recryption_2();
                }
            }

        [Fact]
        public void TestDH_Recryption_8() => TestRecrypt(8);

        [Fact]
        public void TestDH_Recryption_n_5() {
            for (var i = 0; i < 5; i++) {
                for (var n = 2; n < 16; n++) {
                    TestRecrypt(n);
                    }
                }
            }

        static void TestRecrypt(int Shares) {
            // Alice's encryption
            var AliceAgreeW = AlicePrivate.Agreement(GroupKeyPublic);

            // Keyset for decryption
            var KeySet = GroupPrivate.MakeThresholdKeySet(Shares);

            // Calculate part results
            var Recrypts = new BigInteger[Shares];
            for (var i = 0; i < Shares; i++) {
                Recrypts[i] = (KeySet[i] as DiffeHellmanPrivate).Agreement(AlicePublic);
                }

            // Combine them
            var BobAgreeW = GroupKeyPublic.Agreement(Recrypts);

            (AliceAgreeW == BobAgreeW).TestTrue(); 
            }



        [Fact]
        public void TestDH_Encrypt() => BobKeyPair.Test_EncryptDecrypt();

        [Fact]
        public void TestDH_KeyGen() {
            var Encrypter = KeyPair.Factory(CryptoAlgorithmId.DH, KeySecurity.Ephemeral);

            var EncrypterKeyPair = Encrypter as KeyPairDH;

            EncrypterKeyPair.Test_EncryptDecrypt();
            }


        [Fact]
        public void TestDH_ReadKey() {
            var PublicPKIX = AliceKeyPair.PKIXPublicKeyDH;

            var NewSigner = KeyPairBaseDH.KeyPairPublicFactory(PublicPKIX);

            NewSigner.TestNotNull();
            }


        }
    }
