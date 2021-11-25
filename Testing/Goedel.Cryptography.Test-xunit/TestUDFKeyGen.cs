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

using System;
using System.Collections;
using System.Collections.Generic;

using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;

namespace Goedel.XUnit;

public partial class TestGoedelCryptography {


    [Theory]
    [ClassData(typeof(UDFKeyGen))]
    public void UDFKeyGen(TestVectorUDFKeyGen Test) => Test.Test();





    [Theory]
    [InlineData(100, UdfAlgorithmIdentifier.MeshProfileDevice)]
    public void UDFMultipleKeyTest(int iterations, UdfAlgorithmIdentifier udfAlgorithmIdentifier) {
        int fail = 0;
        for (var i = 0; i < iterations; i++) {
            //Test(UdfAlgorithmIdentifier.MeshProfileDevice, baseType, MeshKeyType.Sign);
            if (!Test(udfAlgorithmIdentifier, MeshKeyOperation.Encrypt)) {
                fail++;
                }


            }
        Console.WriteLine($"Results {fail}/{iterations}");
        }

    // Make test with fixed value so as to be repeatable.

    public static bool Test(UdfAlgorithmIdentifier udfAlgorithmIdentifier, MeshKeyOperation operation, int bits = 256) {

        (var actor, var keytype) = udfAlgorithmIdentifier.GetMeshKeyType();

        var primeUDF = UDF.DerivedKey(udfAlgorithmIdentifier, data: Platform.GetRandomBits(bits));
        var primeSeed = new PrivateKeyUDF(primeUDF);
        var primeKey = primeSeed.GenerateContributionKeyPair(keytype, actor, operation);

        var activationUDF = UDF.DerivedKey(udfAlgorithmIdentifier + 1, data: Platform.GetRandomBits(bits));
        var activationSeed = new PrivateKeyUDF(activationUDF);
        var activationKey = activationSeed.GenerateContributionKeyPair(MeshKeyType.Activation, actor, operation);

        switch (keytype) {
            case MeshKeyType.Complete: {
                    // test splitting the key and recombing it
                    return TestBase(primeKey as KeyPairAdvanced, activationKey as KeyPairAdvanced, activationUDF, actor, operation);
                    }
            case MeshKeyType.Base: {
                    // test activating the key and recombing it
                    return TestComplete(primeKey as KeyPairAdvanced, activationKey as KeyPairAdvanced, activationUDF, actor, operation);
                    }
            }

        throw new NYI();
        }

    static bool TestBase(KeyPairAdvanced baseKey, KeyPairAdvanced activationKey, string activationUDF,
                MeshActor actor, MeshKeyOperation operation) {
        // Check these are both the same kind
        (baseKey.CryptoAlgorithmId == activationKey.CryptoAlgorithmId).TestTrue();


        var activationSeed = new PrivateKeyUDF(activationUDF);
        var basePublic = baseKey.KeyPairPublic();

        var completeKey = baseKey.Combine(activationKey);

        // view from the admin device creating the activation
        var completePublic = activationSeed.ActivatePublic(basePublic, actor, operation);

        // view from the connected device using the activation
        var completePrivate = activationSeed.ActivatePrivate(baseKey, actor, operation);

        // Check that we end up with the same key each way
        (completePublic.CryptoAlgorithmId == completePrivate.CryptoAlgorithmId).TestTrue();
        (completeKey.CryptoAlgorithmId == completePrivate.CryptoAlgorithmId).TestTrue();

        (completePublic.KeyIdentifier == completePrivate.KeyIdentifier).TestTrue();
        (completeKey.KeyIdentifier == completePrivate.KeyIdentifier).TestTrue();

        return true;
        }

    static bool TestComplete(KeyPairAdvanced completeKey, KeyPairAdvanced activationKey, string activationUDF,
                MeshActor actor, MeshKeyOperation operation) {
        // Check these are both the same kind
        (completeKey.CryptoAlgorithmId == activationKey.CryptoAlgorithmId).TestTrue();

        var activationSeed = new PrivateKeyUDF(activationUDF);

        // Admin device part
        var thresholdKey = completeKey.GetThresholdKey(activationKey);

        // view from the connected device using the activation
        var completePrivate = activationSeed.ActivatePrivate(thresholdKey, actor, operation);

        // Check that we end up with the same key each way

        (completeKey.CryptoAlgorithmId == completePrivate.CryptoAlgorithmId).TestTrue();
        (completeKey.KeyIdentifier == completePrivate.KeyIdentifier).TestTrue();

        return true;
        }



    [Theory]
    [InlineData(100)]
    public void CombineCurveX448(int iterations) {
        for (var i = 0; i < iterations; i++) {
            CombineCurveX448Inner(10, 12 + i);
            }
        }

    [Theory]
    [InlineData(10, 12)]
    public void CombineCurveX448Inner(int a, int b) {
        //var a = 10;
        //var b = 12;

        var c1 = CurveX448.Base.Multiply(a);
        var c2 = CurveX448.Base.Multiply(b);

        var c12a = CurveX448.Base.Multiply(a + b);
        var c12b = c1.Add(c2);

        if (c12b.V != c12a.V) {
            Console.WriteLine($"Fail: {c12a.Odd}  /  {c12b.Odd}");
            }

        //c12b.U.AssertEqual(c12a.U);
        //c12b.V.AssertEqual(c12a.V);


        }

    [Theory]
    [InlineData(100)]
    public void CombineCurveX25519(int iterations) {
        for (var i = 0; i < iterations; i++) {
            CombineCurveX25519Inner(10, 12 + i);
            }
        }

    [Theory]
    [InlineData(10, 12)]
    public void CombineCurveX25519Inner(int a, int b) {
        //var a = 10;
        //var b = 12;

        var c1 = CurveX25519.Base.MultiplySigned(a);
        var c2 = CurveX25519.Base.MultiplySigned(b);

        var c12a = CurveX25519.Base.MultiplySigned(a + b);
        var c12b = c1.Add(c2);

        if (c12b.V != c12a.V) {
            Console.WriteLine($"Fail: {c1.Odd} + {c2.Odd} =  {c12a.Odd}  /  {c12b.Odd}");
            }

        //c12b.U.AssertEqual(c12a.U);
        //c12b.V.AssertEqual(c12a.V);


        }



    [Fact]
    public void CombineCurveX4482() {

        var c1 = new CurveX448Private(10, true);
        var c2 = new CurveX448Private(12, true);

        var c12pub = c1.Public.Combine(c2.Public);

        var c12priv = c1.Combine(c2);

        var t1 = c12pub.Public;
        var t2 = c12priv.Public.Public;


        t1.U.TestEqual(t2.U);
        t1.V.TestEqual(t2.V);
        }


    }
public class TestVectorUDFKeyGen {

    public string Seed;
    public KeyUses KeyUses;
    public UdfAlgorithmIdentifier UdfAlgorithmIdentifier;

    public string ResultUDF;



    public virtual void Test() {

        var udf = UDF.DerivedKey(UdfAlgorithmIdentifier, data: Seed.ToUTF8());


        var keypair = UDF.DeriveKey(udf, KeySecurity.Ephemeral, KeyUses);
        Console.WriteLine($"{UdfAlgorithmIdentifier}:  {udf} -> {keypair.KeyIdentifier}");


        (keypair.KeyIdentifier == ResultUDF).TestTrue();
        }








    public static bool Test(KeyUses keyUses, KeyPair privateKey, KeyPair publicKey = null) {
        publicKey ??= privateKey.KeyPairPublic();

        (keyUses == publicKey.KeyUses).TestTrue();
        (keyUses == privateKey.KeyUses).TestTrue();

        return keyUses switch {
            KeyUses.Sign => TestSign(privateKey, publicKey),
            KeyUses.Encrypt => TestEncrypt(privateKey, publicKey),
            _ => TestAny(privateKey, publicKey),
            };
        }


    public static bool TestSign(KeyPair privateKey, KeyPair publicKey) {

        var message = "This is a test".ToBytes();

        // sign a message with the private
        var signature = privateKey.Sign(message);

        // check the signature with the public

        var result = publicKey.Verify(message, signature);

        result.TestTrue();
        return result;
        }

    public static bool TestEncrypt(KeyPair privateKey, KeyPair publicKey) {
        var plaintext = Platform.GetRandomBits(256);

        // sign a message with the private
        publicKey.Encrypt(plaintext, out var exchange, out var ephemeral);

        // check the signature with the public

        var decrypt = privateKey.Decrypt(exchange, ephemeral);
        decrypt.TestEqual(plaintext);

        return true;

        }

    public static bool TestAny(KeyPair privateKey, KeyPair publicKey) =>
        TestSign(privateKey, publicKey) & TestEncrypt(privateKey, publicKey);
    }


public class TestVectorUDFKeyGenUdfKey : TestVectorUDFKeyGen {

    public string SeedA;

    public string ResultSign;
    public string ResultEncrypt;
    public string ResultAuthenticate;

    public override void Test() {
        var udf = UDF.DerivedKey(UdfAlgorithmIdentifier, data: Seed.ToUTF8());
        var privatekeyUDF = new PrivateKeyUDF(udf);

        var udfa = UDF.DerivedKey(UdfAlgorithmIdentifier, data: SeedA.ToUTF8());
        var privatekeyUDFa = new PrivateKeyUDF(udfa);


        (var actor, var _) = UdfAlgorithmIdentifier.GetMeshKeyType();


        // The base keys
        var baseSign = privatekeyUDF.GenerateContributionKeyPair(MeshKeyType.Base, actor, MeshKeyOperation.Sign);
        var baseEncrypt = privatekeyUDF.GenerateContributionKeyPair(MeshKeyType.Base, actor, MeshKeyOperation.Encrypt);
        var baseAuthenticate = privatekeyUDF.GenerateContributionKeyPair(MeshKeyType.Base, actor, MeshKeyOperation.Authenticate);


        var basePublicSign = baseSign.KeyPairPublic();
        var basePublicEncrypt = baseEncrypt.KeyPairPublic();
        var basePublicAuthenticate = baseAuthenticate.KeyPairPublic();

        // The activated keys
        var privateSign = privatekeyUDFa.ActivatePrivate(baseSign, actor, MeshKeyOperation.Sign);
        var privateEncrypt = privatekeyUDFa.ActivatePrivate(baseEncrypt, actor, MeshKeyOperation.Encrypt);
        var privateAuthenticate = privatekeyUDFa.ActivatePrivate(baseAuthenticate, actor, MeshKeyOperation.Authenticate);

        var publicSign = privatekeyUDFa.ActivatePublic(basePublicSign, actor, MeshKeyOperation.Sign);
        var publicEncrypt = privatekeyUDFa.ActivatePublic(basePublicEncrypt, actor, MeshKeyOperation.Encrypt);
        var publicAuthenticate = privatekeyUDFa.ActivatePublic(basePublicAuthenticate, actor, MeshKeyOperation.Authenticate);

        Test(KeyUses.Sign, privateSign, publicSign);
        Test(KeyUses.Encrypt, privateEncrypt, publicEncrypt);
        Test(KeyUses.Encrypt, privateAuthenticate, publicAuthenticate);

        Console.WriteLine($"{UdfAlgorithmIdentifier}:  {udf} {udfa}");
        //Console.WriteLine($" BaseSign= \"{basePublicSign.KeyIdentifier}\" ");


        Console.WriteLine($" ResultSign = \"{publicSign.KeyIdentifier}\",");
        Console.WriteLine($" ResultEncrypt = \"{publicEncrypt.KeyIdentifier}\",");
        Console.WriteLine($" ResultAuthenticate = \"{publicAuthenticate.KeyIdentifier}\"");

        (privateSign.KeyIdentifier == ResultSign).TestTrue();
        (publicEncrypt.KeyIdentifier == ResultEncrypt).TestTrue();
        (publicAuthenticate.KeyIdentifier == ResultAuthenticate).TestTrue();

        }

    }

public class UDFKeyGen : IEnumerable<object[]> {

    public IEnumerator<object[]> GetEnumerator() {
        yield return new object[] { TEST1 };
        yield return new object[] { TEST2 };
        yield return new object[] { TEST3 };
        yield return new object[] { TEST4 };
        yield return new object[] { TEST_KG_Device };
        yield return new object[] { TEST_KG_User };
        yield return new object[] { TEST_KG_Service };
        }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


    #region // Direct tests

    public static TestVectorUDFKeyGen TEST1 { get; } = new() {
        Seed = "test1",
        UdfAlgorithmIdentifier = UdfAlgorithmIdentifier.Ed25519,
        KeyUses = KeyUses.Sign,
        ResultUDF = "MB2W-MYKD-RT2Q-VZD4-76ER-ER5O-3WH2"
        };

    public static TestVectorUDFKeyGen TEST2 { get; } = new() {
        Seed = "test2",
        UdfAlgorithmIdentifier = UdfAlgorithmIdentifier.Ed448,
        KeyUses = KeyUses.Sign,
        ResultUDF = "MAHJ-HXR2-YQVB-J5BB-6JFA-A4NF-XX65"
        };

    public static TestVectorUDFKeyGen TEST3 { get; } = new() {
        Seed = "test3",
        UdfAlgorithmIdentifier = UdfAlgorithmIdentifier.X25519,
        KeyUses = KeyUses.Encrypt,
        ResultUDF = "MDID-WXVE-4ZC7-JJYZ-CEWP-DN3W-BIFG"
        };

    public static TestVectorUDFKeyGen TEST4 { get; } = new() {
        Seed = "test4",
        UdfAlgorithmIdentifier = UdfAlgorithmIdentifier.X448,
        KeyUses = KeyUses.Encrypt,
        ResultUDF = "MDIQ-NMGG-GYIS-T3VB-2JMI-ROED-ESTP"
        };

    #endregion


    #region // KeyGen tests


    public static TestVectorUDFKeyGenUdfKey TEST_KG_Device { get; } = new() {
        Seed = "test1",
        SeedA = "test1a",
        UdfAlgorithmIdentifier = UdfAlgorithmIdentifier.MeshProfileDevice,
        KeyUses = KeyUses.KeyAgreement,

        ResultSign = "MDBL-SQGO-72WK-SRJ6-TSRL-Y4N6-WMJZ",
        ResultEncrypt = "MDAU-46LN-F4C6-HQNC-PKDQ-WZZV-UDMG",
        ResultAuthenticate = "MAND-U3TZ-TOP3-BDIJ-GHRV-G7EM-4XLN"
        };

    // will fail as 
    public static TestVectorUDFKeyGenUdfKey TEST_KG_User { get; } = new() {
        Seed = "test1",
        SeedA = "test1a",
        UdfAlgorithmIdentifier = UdfAlgorithmIdentifier.MeshProfileAccount,
        KeyUses = KeyUses.KeyAgreement,
        ResultSign = "MCOA-BVPL-XFLW-TPNH-NY4Z-OM3U-TQ3N",
        ResultEncrypt = "MD4Z-OX5B-Y7R6-CVBB-CMZB-4GSG-VC72",
        ResultAuthenticate = "MBDI-ARCO-T3DZ-GV5W-PXSK-CPBQ-H6AV"
        };


    public static TestVectorUDFKeyGenUdfKey TEST_KG_Service { get; } = new() {
        Seed = "test1",
        SeedA = "test1a",
        UdfAlgorithmIdentifier = UdfAlgorithmIdentifier.MeshProfileService,
        KeyUses = KeyUses.KeyAgreement,
        ResultSign = "MCVI-EA6S-DURR-SM3Z-UF7H-LLJE-5EQS",
        ResultEncrypt = "MAOU-ARVS-SHGW-BFEZ-CHTN-3UNJ-OC4S",
        ResultAuthenticate = "MAIN-5RVA-LYL2-3QZF-BVLF-HAI6-EOOM"
        };

    #endregion


    }
