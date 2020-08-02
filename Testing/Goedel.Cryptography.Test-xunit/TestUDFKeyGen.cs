using Goedel.Cryptography;
using Goedel.Cryptography.Algorithms;
using Goedel.Utilities;
using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;
using Goedel.Test;

#pragma warning disable IDE0059


namespace Goedel.XUnit {
    public partial class TestGoedelCryptography {


        [Theory]
        [ClassData(typeof(UDFKeyGen))]
        public void UDFKeyGen(TestVectorUDFKeyGen Test) => Test.Test();





        [Theory]
        [InlineData(100, MeshKeyType.DeviceProfile)]
        public void UDFMultipleKeyTest(int iterations, MeshKeyType baseType) {
            int fail = 0;
            for (var i = 0; i < iterations; i++) {
                //Test(UdfAlgorithmIdentifier.MeshProfileDevice, baseType, MeshKeyType.Sign);
                if (!Test(UdfAlgorithmIdentifier.MeshProfileDevice, baseType, MeshKeyType.Encrypt)) {
                    fail++;
                    }


                }
            Console.WriteLine($"Results {fail}/{iterations}");
            }

        // Make test with fixed value so as to be repeatable.

        public bool Test(UdfAlgorithmIdentifier udfAlgorithmIdentifier, MeshKeyType baseType, MeshKeyType keyType) {

            var bits = 256;
            var baseSeed = new PrivateKeyUDF(udfAlgorithmIdentifier, bits: bits);
            var activationSeed = UDF.DerivedKey(udfAlgorithmIdentifier + 1, data: Platform.GetRandomBits(bits));
            keyType |= baseType;

            var baseKey = baseSeed.BasePrivate(keyType);


            var basePublic = baseKey.ActivatePublic(activationSeed, keyType);


            var basePrivate = baseSeed.ActivatePrivate(activationSeed, keyType);


            //basePublic.UDF.AssertEqual(basePrivate.UDF);

            if (basePublic.KeyIdentifier != basePrivate.KeyIdentifier) {
                var baseKeyX = (baseKey as KeyPairX448).PublicKey.Public;
                var basePublicX = (basePublic as KeyPairX448).PublicKey.Public;
                var basePrivateX = (basePrivate as KeyPairX448).PublicKey.Public;


                Console.WriteLine("Fail");

                }


            return basePublic.KeyIdentifier == basePrivate.KeyIdentifier;

            }


        [Theory]
        [InlineData(100)]
        public void CombineCurveX448(int iterations) {
            for (var i = 0; i < iterations; i++) {
                CombineCurveX448Inner(10, 12 + i);
                }
            }

        [Theory]
        [InlineData(10,12)]
        public void CombineCurveX448Inner(int a, int b) {
            //var a = 10;
            //var b = 12;

            var c1 = CurveX448.Base.Multiply(a);
            var c2 = CurveX448.Base.Multiply(b);

            var c12a = CurveX448.Base.Multiply(a+b);
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








        public bool Test(KeyUses keyUses, KeyPair privateKey, KeyPair publicKey = null) {
            publicKey ??= privateKey.KeyPairPublic();

            (keyUses == publicKey.KeyUses).TestTrue();
            (keyUses == privateKey.KeyUses).TestTrue();

            return keyUses switch
                {
                    KeyUses.Sign => TestSign(privateKey, publicKey),
                    KeyUses.Encrypt => TestEncrypt(privateKey, publicKey),
                    _ => TestAny(privateKey, publicKey),
                    };
            }


        public bool TestSign(KeyPair privateKey, KeyPair publicKey) {

            var message = "This is a test".ToBytes();

            // sign a message with the private
            var signature = privateKey.Sign(message);

            // check the signature with the public

            var result = publicKey.Verify(message, signature);

            result.TestTrue();
            return result;
            }

        public bool TestEncrypt(KeyPair privateKey, KeyPair publicKey) {
            var plaintext = Platform.GetRandomBits(256);

            // sign a message with the private
            publicKey.Encrypt(plaintext, out var exchange, out var ephemeral);

            // check the signature with the public

            var decrypt = privateKey.Decrypt(exchange, ephemeral);
            decrypt.TestEqual(plaintext);

            return true;

            }

        public bool TestAny(KeyPair privateKey, KeyPair publicKey) =>
            TestSign(privateKey, publicKey) & TestEncrypt(privateKey, publicKey);
        }


    public class TestVectorUDFKeyGenUdfKey: TestVectorUDFKeyGen {

        public string SeedA;

        public string ResultSign;
        public string ResultEncrypt;
        public string ResultAuthenticate;

        public override void Test() {
            var udf = UDF.DerivedKey(UdfAlgorithmIdentifier, data: Seed.ToUTF8());
            var privatekeyUDF = new PrivateKeyUDF(UdfAlgorithmIdentifier, udf);

            var udfa = UDF.DerivedKey(UdfAlgorithmIdentifier, data: SeedA.ToUTF8());
            var privatekeyUDFa = new PrivateKeyUDF(UdfAlgorithmIdentifier, udf);



            var meshKeyType = UdfAlgorithmIdentifier.GetMeshKeyType();
            
            // The base keys
            var baseSign = privatekeyUDF.BasePrivate(meshKeyType | MeshKeyType.Sign);
            var baseEncrypt = privatekeyUDF.BasePrivate(meshKeyType | MeshKeyType.Encrypt);
            var baseAuthenticate = privatekeyUDF.BasePrivate(meshKeyType | MeshKeyType.Authenticate);

            var basePublicSign = baseSign.KeyPairPublic();
            var basePublicEncrypt = baseEncrypt.KeyPairPublic();
            var basePublicAuthenticate = baseAuthenticate.KeyPairPublic();

            // The activated keys
            var privateSign = privatekeyUDFa.ActivatePrivate(privatekeyUDF, meshKeyType | MeshKeyType.Sign);
            var privateEncrypt = privatekeyUDFa.ActivatePrivate(privatekeyUDF, meshKeyType | MeshKeyType.Encrypt);
            var privateAuthenticate = privatekeyUDFa.ActivatePrivate(privatekeyUDF, meshKeyType | MeshKeyType.Authenticate);

            var publicSign = basePublicSign.ActivatePublic(privatekeyUDFa.PrivateValue, meshKeyType | MeshKeyType.Sign);
            var publicEncrypt = basePublicEncrypt.ActivatePublic(privatekeyUDFa.PrivateValue, meshKeyType | MeshKeyType.Encrypt);
            var publicAuthenticate = basePublicAuthenticate.ActivatePublic(privatekeyUDFa.PrivateValue, meshKeyType | MeshKeyType.Authenticate);

            Test(KeyUses.Sign, privateSign, publicSign);
            Test(KeyUses.Encrypt, privateEncrypt, publicEncrypt);
            Test(KeyUses.Encrypt, privateAuthenticate, publicAuthenticate);

            Console.WriteLine($"{UdfAlgorithmIdentifier}:");
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
            yield return new object[] { TEST_KG_Group };
            yield return new object[] { TEST_KG_Service };
            }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        #region // Direct tests

        public static TestVectorUDFKeyGen TEST1 = new TestVectorUDFKeyGen() {
            Seed = "test1",
            UdfAlgorithmIdentifier = UdfAlgorithmIdentifier.Ed25519,
            KeyUses = KeyUses.Sign,
            ResultUDF = "MC4S-LNRM-GNHQ-242E-7756-2BZP-YAAH"
            };

        public static TestVectorUDFKeyGen TEST2 = new TestVectorUDFKeyGen() {
            Seed = "test2",
            UdfAlgorithmIdentifier = UdfAlgorithmIdentifier.Ed448,
            KeyUses = KeyUses.Sign,
            ResultUDF = "MBPN-IO4E-XBGU-VO6I-G5WR-TADX-LRIA"
            };

        public static TestVectorUDFKeyGen TEST3 = new TestVectorUDFKeyGen() {
            Seed = "test3",
            UdfAlgorithmIdentifier = UdfAlgorithmIdentifier.X25519,
            KeyUses = KeyUses.Encrypt,
            ResultUDF = "MCHO-66GD-NNJU-M4QH-RAVG-NYQ7-LQZZ"
            };

        public static TestVectorUDFKeyGen TEST4 = new TestVectorUDFKeyGen() {
            Seed = "test4",
            UdfAlgorithmIdentifier = UdfAlgorithmIdentifier.X448,
            KeyUses = KeyUses.Encrypt,
            ResultUDF = "MDXP-FV36-Z5DS-5YRG-5YVU-FOE5-46FJ"
            };

        #endregion


        #region // KeyGen tests


        public static TestVectorUDFKeyGenUdfKey TEST_KG_Device = new TestVectorUDFKeyGenUdfKey() {
            Seed = "test1",
            SeedA = "test1a",
            UdfAlgorithmIdentifier = UdfAlgorithmIdentifier.MeshProfileDevice,
            KeyUses = KeyUses.KeyAgreement,
            ResultSign = "MCXN-ECWE-YDNI-RZHA-D2D4-EAJ3-WD2N",
            ResultEncrypt = "MCIR-4KBH-4WMF-DCZA-K4CH-IQKG-EE7V",
            ResultAuthenticate = "MAVJ-733B-OLW5-O5VC-B7ST-ZZPG-VTVD"
            };

        // will fail as 
        public static TestVectorUDFKeyGenUdfKey TEST_KG_User = new TestVectorUDFKeyGenUdfKey() {
            Seed = "test1",
            SeedA = "test1a",
            UdfAlgorithmIdentifier = UdfAlgorithmIdentifier.MeshProfileUser,
            KeyUses = KeyUses.KeyAgreement,
            ResultSign = "fail",
            ResultEncrypt = "fail",
            ResultAuthenticate = "fail"
            };

        public static TestVectorUDFKeyGenUdfKey TEST_KG_Group= new TestVectorUDFKeyGenUdfKey() {
            Seed = "test1",
            SeedA = "test1a",
            UdfAlgorithmIdentifier = UdfAlgorithmIdentifier.MeshProfileGroup,
            KeyUses = KeyUses.KeyAgreement,
            ResultSign = "MDPH-JVTG-JIHO-42QY-TI76-L2NH-LWQ2",
            ResultEncrypt = "MAI5-PA4K-VLIB-6B6Q-J4UC-QCLO-6FAV",
            ResultAuthenticate = "MA4B-XZCN-NKZG-MD3P-YXCD-QCMN-ZTAB"
            };

        public static TestVectorUDFKeyGenUdfKey TEST_KG_Service = new TestVectorUDFKeyGenUdfKey() {
            Seed = "test1",
            SeedA = "test1a",
            UdfAlgorithmIdentifier = UdfAlgorithmIdentifier.MeshProfileService,
            KeyUses = KeyUses.KeyAgreement,
            ResultSign = "MATV-XM2M-QQPF-OCIR-XNHQ-HX6E-IWCX",
            ResultEncrypt = "MDOI-HEQF-4G3S-HQ7F-LA2L-UOE3-6HQM",
            ResultAuthenticate = "MBFE-EQFQ-O6UD-H3DQ-TMT2-ZD7J-6G2K"
            };

        #endregion


        }

    }