#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using Goedel.Cryptography.Algorithms;

using System.Numerics;

namespace Goedel.XUnit;

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
        //var testEnvironmentCommon = new TestEnvironmentCommon();

        //MeshMachine = new MeshMachineTest(testEnvironmentCommon);
        //KeyCollection = new KeyCollectionTest(MeshMachine);
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
