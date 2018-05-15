using System.Numerics;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Utilities;
using Goedel.Test;
using Goedel.Cryptography;
//using Goedel.Cryptography.Framework;

namespace Test.Goedel.Cryptography {
    public partial class TestGoedelCryptography {

        byte[] SHA_Plaintext =
                        ("6bc1bee22e409f96e93d7e117393172a"
                        + "ae2d8a571e03ac9c9eb76fac45af8e51"
                        + "30c81c46a35ce411e5fbc1191a0a52ef"
                        + "f69f2445df4f9b17ad2b417be66c3710.").FromBase16();

        List<CryptoAlgorithmID> Algorithms = new List<CryptoAlgorithmID>() {
            CryptoAlgorithmID.SHA_1_DEPRECATED,
            CryptoAlgorithmID.SHA_2_256,
            CryptoAlgorithmID.SHA_2_512,
            CryptoAlgorithmID.SHA_2_512T128,
            CryptoAlgorithmID.SHA_3_256,
            CryptoAlgorithmID.SHA_3_512,
            };

        // http://csrc.nist.gov/groups/ST/toolkit/documents/Examples/SHA_All.pdf
        // https://www.di-mgt.com.au/sha_testvectors.html
        List<TestVectorSHA> TestVectors_SHA_NIST = new List<TestVectorSHA>() {

            new TestVectorSHA() {
                ID = CryptoAlgorithmID.SHA_1_DEPRECATED,
                Message = "abc",
                Digest =  ("A9993E36 4706816A BA3E2571 7850C26C 9CD0D89D").FromBase16(),
                },

            new TestVectorSHA() {
                ID = CryptoAlgorithmID.SHA_1_DEPRECATED,
                Message = "abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq",
                Digest =  ("84983E44 1C3BD26E BAAE4AA1 F95129E5 E54670F1").FromBase16(),
                },



            new TestVectorSHA() {
                ID = CryptoAlgorithmID.SHA_2_256,
                Message = "abc",
                Digest =  ("BA7816BF 8F01CFEA 414140DE 5DAE2223" +
                            "B00361A3 96177A9C B410FF61 F20015AD").FromBase16(),
                },

            new TestVectorSHA() {
                ID = CryptoAlgorithmID.SHA_2_256,
                Message = "abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq",
                Digest =  ("248D6A61 D20638B8 E5C02693 0C3E6039" +
                            "A33CE459 64FF2167 F6ECEDD4 19DB06C1").FromBase16(),
                },


            new TestVectorSHA() {
                ID = CryptoAlgorithmID.SHA_2_512,
                Message = "abc",
                Digest =  ("DDAF35A1 93617ABA CC417349 AE204131"
                    +"12E6FA4E 89A97EA2 0A9EEEE6 4B55D39A 2192992A 274FC1A8"
                    +"36BA3C23 A3FEEBBD 454D4423 643CE80E 2A9AC94F A54CA49F").FromBase16(),
                },

            new TestVectorSHA() {
                ID = CryptoAlgorithmID.SHA_2_512,
                Message = "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmnhi" +
                            "jklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu",
                Digest =  ("8E959B75 DAE313DA 8CF4F728 14FC143F"
                    +"8F7779C6 EB9F7FA1 7299AEAD B6889018 501D289E 4900F7E4"
                    +"331B99DE C4B5433A C7D329EE B6DD2654 5E96E55B 874BE909").FromBase16(),
                },

            new TestVectorSHA() {
                ID = CryptoAlgorithmID.SHA_2_512T128,
                Message = "abc",
                Digest =  ("DDAF35A1 93617ABA CC417349 AE204131").FromBase16(),
                },

            new TestVectorSHA() {
                ID = CryptoAlgorithmID.SHA_2_512T128,
                Message = "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmnhi" +
                            "jklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu",
                Digest =  ("8E959B75 DAE313DA 8CF4F728 14FC143F").FromBase16(),
                }
            };

        [TestMethod]
        public void TestSHA_NIST() {
            foreach (var TestVector in TestVectors_SHA_NIST) {
                var Provider = CryptoCatalog.Default.GetDigest(TestVector.ID);
                TestVector.Verify(Provider);
                }
            }

        [TestMethod]
        public void TestSHA_NIST_Streamed() {
            foreach (var TestVector in TestVectors_SHA_NIST) {
                var Provider = CryptoCatalog.Default.GetDigest(TestVector.ID);
                TestVector.Verify_Streamed(Provider);
                }
            }

        }


    public class TestVectorSHA {
        public CryptoAlgorithmID ID { get; set; }

        public string Message { get; set; }

        public byte[] Digest { get; set; }

        public void Verify(CryptoProviderDigest Provider) {

            var Result = Provider.ProcessData(Message.ToBytes());

            UT.Assert.IsTrue(Result.IsEqualTo(Digest));
            }


        public void Verify_Streamed(CryptoProviderDigest Provider) {

            var Encoder = Provider.MakeEncoder();
            Encoder.Write(Message.ToBytes());
            Encoder.Complete();
            var Result = Encoder.Integrity;

            UT.Assert.IsTrue(Result.IsEqualTo(Digest));
            }

        }
    }
