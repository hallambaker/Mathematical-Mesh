using System.Numerics;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT=Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Utilities;
using Goedel.Test;
using Goedel.Cryptography;

namespace Test.Goedel.Cryptography {
    public partial class TestGoedelCryptography {

        List<TestVectorHMAC> TestVectors_HMAC_4231 = new List<TestVectorHMAC>() {
            // Case 1
            new TestVectorHMAC {
                Key = "0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b".FromBase16(),
                Data = "Hi There".ToUTF8(),
                Result_HMAC_224 =
                        ("896fb1128abbdf196832107cd49df33f"
                        +"47b4b1169912ba4f53684b22").FromBase16(),
                Result_HMAC_256 =
                        ("b0344c61d8db38535ca8afceaf0bf12b"
                        +"881dc200c9833da726e9376c2e32cff7").FromBase16(),
                Result_HMAC_384 =
                        ("afd03944d84895626b0825f4ab46907f"
                        +"15f9dadbe4101ec682aa034c7cebc59c"
                        +"faea9ea9076ede7f4af152e8b2fa9cb6").FromBase16(),
                Result_HMAC_512 =
                        ("87aa7cdea5ef619d4ff0b4241a1d6cb0"
                        +"2379f4e2ce4ec2787ad0b30545e17cde"
                        +"daa833b7d6b8a702038b274eaea3f4e4"
                        +"be9d914eeb61f1702e696c203a126854").FromBase16()},
            //Case 2
            new TestVectorHMAC {
                Key = "Jefe".ToUTF8(),
                Data =  ("7768617420646f2079612077616e7420"
                        +"666f72206e6f7468696e673f").FromBase16(),
                Result_HMAC_224 =
                        ("a30e01098bc6dbbf45690f3a7e9e6d0f"
                        +"8bbea2a39e6148008fd05e44").FromBase16(),
                Result_HMAC_256 =
                        ("5bdcc146bf60754e6a042426089575c7"
                        +"5a003f089d2739839dec58b964ec3843").FromBase16(),
                Result_HMAC_384 =
                        ("af45d2e376484031617f78d2b58a6b1b"
                        +"9c7ef464f5a01b47e42ec3736322445e"
                        +"8e2240ca5e69e2c78b3239ecfab21649").FromBase16(),
                Result_HMAC_512 =
                        ("164b7a7bfcf819e2e395fbe73b56e0a3"
                        +"87bd64222e831fd610270cd7ea250554"
                        +"9758bf75c05a994a6d034f65f8f0e6fd"
                        +"caeab1a34d4a6b4b636e070a38bce737").FromBase16()},
            // Case 3
            new TestVectorHMAC {
                Key = TestVector.FillConstant (20, 0xaa),
                Data = TestVector.FillConstant (50, 0xdd),
                Result_HMAC_224 =
                        ("7fb3cb3588c6c1f6ffa9694d7d6ad264"
                        +"9365b0c1f65d69d1ec8333ea").FromBase16(),
                Result_HMAC_256 =
                        ("773ea91e36800e46854db8ebd09181a7"
                        +"2959098b3ef8c122d9635514ced565fe").FromBase16(),
                Result_HMAC_384 =
                        ("88062608d3e6ad8a0aa2ace014c8a86f"
                        +"0aa635d947ac9febe83ef4e55966144b"
                        +"2a5ab39dc13814b94e3ab6e101a34f27").FromBase16(),
                Result_HMAC_512 =
                        ("fa73b0089d56a284efb0f0756c890be9"
                        +"b1b5dbdd8ee81a3655f83e33b2279d39"
                        +"bf3e848279a722c806b485a47e67c807"
                        +"b946a337bee8942674278859e13292fb").FromBase16()},
            // Case 4
            new TestVectorHMAC {
                Key = TestVector.FillCount (25, 1),
                Data = TestVector.FillConstant (50, 0xcd),
                Result_HMAC_224 =
                        ("6c11506874013cac6a2abc1bb382627c"
                        +"ec6a90d86efc012de7afec5a").FromBase16(),
                Result_HMAC_256 =
                        ("82558a389a443c0ea4cc819899f2083a"
                        +"85f0faa3e578f8077a2e3ff46729665b").FromBase16(),
                Result_HMAC_384 =
                        ("3e8a69b7783c25851933ab6290af6ca7"
                        +"7a9981480850009cc5577c6e1f573b4e"
                        +"6801dd23c4a7d679ccf8a386c674cffb").FromBase16(),
                Result_HMAC_512 =
                        ("b0ba465637458c6990e5a8c5f61d4af7"
                        +"e576d97ff94b872de76f8050361ee3db"
                        +"a91ca5c11aa25eb4d679275cc5788063"
                        +"a5f19741120c4f2de2adebeb10a298dd").FromBase16()},
            // Case 5
            new TestVectorHMAC {
                Key = TestVector.FillConstant (20, 0x0c),
                Data = "Test With Truncation".ToUTF8(),
                Result_HMAC_224 = "0e2aea68a90c8d37c988bcdb9fca6fa8".FromBase16(),
                Result_HMAC_256 = "a3b6167473100ee06e0c796c2955552b".FromBase16(),
                Result_HMAC_384 = "3abf34c3503b2a23a46efc619baef897".FromBase16(),
                Result_HMAC_512 = "415fad6271580a531d4179bc891d87a6".FromBase16()},
            // Case 6
            new TestVectorHMAC {
                Key = TestVector.FillConstant (131, 0xaa),
                Data = "Test Using Larger Than Block-Size Key - Hash Key First".ToUTF8(),
                Result_HMAC_224 =
                        ("95e9a0db962095adaebe9b2d6f0dbce2"
                        +"d499f112f2d2b7273fa6870e").FromBase16(),
                Result_HMAC_256 =
                        ("60e431591ee0b67f0d8a26aacbf5b77f"
                        +"8e0bc6213728c5140546040f0ee37f54").FromBase16(),
                Result_HMAC_384 =
                        ("4ece084485813e9088d2c63a041bc5b4"
                        +"4f9ef1012a2b588f3cd11f05033ac4c6"
                        +"0c2ef6ab4030fe8296248df163f44952").FromBase16(),
                Result_HMAC_512 =
                        ("80b24263c7c1a3ebb71493c1dd7be8b4"
                        +"9b46d1f41b4aeec1121b013783f8f352"
                        +"6b56d037e05f2598bd0fd2215d6a1e52"
                        +"95e64f73f63f0aec8b915a985d786598").FromBase16()},
            // Case 7
            new TestVectorHMAC {
                Key = TestVector.FillConstant (131, 0xaa),
                Data = ("This is a test using a larger than block-size key and a larger than block-size d"+
                        "ata. The key needs to be hashed before being used by the HMAC algorithm.") .ToUTF8(),
                Result_HMAC_224 =
                        ("3a854166ac5d9f023f54d517d0b39dbd"
                        +"946770db9c2b95c9f6f565d1").FromBase16(),
                Result_HMAC_256 =
                        ("9b09ffa71b942fcb27635fbcd5b0e944"
                        +"bfdc63644f0713938a7f51535c3a35e2").FromBase16(),
                Result_HMAC_384 =
                        ("6617178e941f020d351e2f254e8fd32c"
                        +"602420feb0b8fb9adccebb82461e99c5"
                        +"a678cc31e799176d3860e6110c46523e").FromBase16(),
                Result_HMAC_512 =
                        ("e37b6a775dc87dbaa4dfa9f96e5e3ffd"
                        +"debd71f8867289865df5a32d20cdc944"
                        +"b6022cac3c4982b10d5eeb55c3e4de15"
                        +"134676fb6de0446065c97440fa8c6a58").FromBase16()}


                };


        [TestMethod]
        public void TestHMAC_4231_Separate() {
            foreach (var TestVector in TestVectors_HMAC_4231) {

                var SHA256 = CryptoCatalog.Default.GetAuthentication(CryptoAlgorithmID.HMAC_SHA_2_256);
                var SHA512 = CryptoCatalog.Default.GetAuthentication(CryptoAlgorithmID.HMAC_SHA_2_512);

                TestVector.Verify(SHA256, TestVector.Result_HMAC_256);
                TestVector.Verify(SHA512, TestVector.Result_HMAC_512);
                }
            }

        [TestMethod]
        public void TestHMAC_4231_Repeat() {
            var SHA256 = CryptoCatalog.Default.GetAuthentication(CryptoAlgorithmID.HMAC_SHA_2_256);
            var SHA512 = CryptoCatalog.Default.GetAuthentication(CryptoAlgorithmID.HMAC_SHA_2_512);

            foreach (var TestVector in TestVectors_HMAC_4231) {
                TestVector.Verify(SHA256, TestVector.Result_HMAC_256);
                TestVector.Verify(SHA512, TestVector.Result_HMAC_512);
                }
            }

        }


    public class TestVectorHMAC {

        public byte[] Key { get; set; }

        public byte[] Data { get; set; }


        public byte[] Result_HMAC_224 { get; set; }

        public byte[] Result_HMAC_256 { get; set; }

        public byte[] Result_HMAC_384 { get; set; }

        public byte[] Result_HMAC_512 { get; set; }


        public void Verify (
            global::Goedel.Cryptography.CryptoProviderAuthentication Provider, byte[] Expected) {

            var Result = Provider.ProcessData(Data, Key);

            if (Expected.Length < Provider.Size/8) {
                System.Array.Resize(ref Result, Expected.Length);
                }

            Debug.WriteLine("Key = {0}", Key.ToStringBase16());
            Debug.WriteLine("Data = {0}", Data.ToStringBase16());
            Debug.WriteLine("Result = {0}", Result.ToStringBase16());

            UT.Assert.IsTrue(Result.IsEqualTo(Expected));
            }
        }
    }
