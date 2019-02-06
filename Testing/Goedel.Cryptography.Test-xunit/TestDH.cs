using System.Numerics;

using Goedel.Utilities;
using Goedel.Mesh.Test;
using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Test.Core;
using Xunit;

namespace Goedel.XUnit {

    public partial class TestCryptography {

        static KeyPairDH AliceKeyPair;
        static KeyPairDH BobKeyPair;
        static KeyPairDH GroupKeyPair;

        static DiffeHellmanPrivate AlicePrivate;
        static DiffeHellmanPrivate BobPrivate;
        static DiffeHellmanPrivate GroupPrivate;

        static DiffeHellmanPublic AlicePublic;
        static DiffeHellmanPublic BobPublic;
        static DiffeHellmanPublic GroupKeyPublic;

        public MeshMachineTest MeshMachine;
        KeyCollection KeyCollection;

        static TestCryptography() {
            Cryptography.Cryptography.Initialize();

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
            var machineEnvironment = new TestEnvironmentMachine( "TestCryptography");

            MeshMachine = new MeshMachineTest(machineEnvironment);
            KeyCollection = new KeyCollectionTest(MeshMachine);
            }

        [Fact]
        public void TestDHAlg_SimpleAgreement() {

            var AliceKey = AlicePrivate.Agreement(BobPublic);
            var BobKey = BobPrivate.Agreement(AlicePublic);

            Utilities.Assert.True(AliceKey.Equals(BobKey));
            Utilities.Assert.True(BobKey.Equals(AliceKey));

            }
        
        [Fact]
        public void Test_DHAlg_Ephemeral_Agreement() {

            var AliceAgree = BobPublic.Agreement();

            var AliceKey = AliceAgree.EphemeralPublicValue;

            var BobAgreement = BobPrivate.Agreement(AliceKey);

            Utilities.Assert.True(BobAgreement.Equals(AliceAgree.Agreement));
            }

        [Fact]
        public void TestDH_Recryption_2 () {

            var BobSplit = GroupPrivate.MakeRecryptionKeySet(2);
            var BobRecryption = BobSplit[0] as DiffeHellmanPrivate;
            var BobDecryption = BobSplit[1] as DiffeHellmanPrivate; 


            var AliceAgreeW = AlicePrivate.Agreement(GroupKeyPublic);
            var ServerRecrypt = BobRecryption.Agreement(AlicePublic);
            var BobAgreeW = BobDecryption.Agreement(AlicePublic, ServerRecrypt);

            Utilities.Assert.True(AliceAgreeW == BobAgreeW );

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

            Utilities.Assert.True(AliceAgreeW == BobAgreeW);
            }



        [Fact]
        public void TestDH_Encrypt() => BobKeyPair.Test_EncryptDecrypt();

        [Fact]
        public void TestDH_KeyGen() {
            var Encrypter = KeyPair.Factory(CryptoAlgorithmID.DH, KeySecurity.Ephemeral);

            var EncrypterKeyPair = Encrypter as KeyPairDH;

            EncrypterKeyPair.Test_EncryptDecrypt();
            }


        [Fact]
        public void TestDH_ReadKey() {
            var PublicPKIX = AliceKeyPair.PKIXPublicKeyDH;

            var NewSigner = KeyPairBaseDH.KeyPairPublicFactory(PublicPKIX);

            Utilities.Assert.NotNull(NewSigner);
            }


        }
    }
