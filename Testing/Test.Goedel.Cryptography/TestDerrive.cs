using System.Numerics;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT=Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Utilities;
using Goedel.Test;
using Goedel.Cryptography;
using Goedel.Cryptography.Framework;

namespace Test.Goedel.Cryptography {
    public partial class TestGoedelCryptography {

        List<TestVectorDerive> TestVectors_Derive_5869_SHA256 = new List<TestVectorDerive>() {
            // Case 1
            new TestVectorDerive () {
                IKM = TestVector.FillConstant (22, 0x0b),
                Salt = TestVector.FillCount (13, 0x00),
                Info = TestVector.FillCount (10, 0xf0),
                L=42,
                Result_PRK =
                        ("077709362c2e32df0ddc3f0dc47bba63"
                        +"90b6c73bb50f9c3122ec844ad7c2b3e5").FromBase16(),
                Result_OKM =
                        ("3cb25f25faacd57a90434f64d0362f2a"
                        +"2d2d0a90cf1a5a4c5db02d56ecc4c5bf"
                        +"34007208d5b887185865").FromBase16(),
                },

            // Case 2
            new TestVectorDerive () {
                IKM =TestVector.FillCount (80, 0),
                Salt = TestVector.FillCount(80, 0x60),
                Info = TestVector.FillCount(80, 0xb0),
                L=82,
                Result_PRK =
                        ("06a6b88c5853361a06104c9ceb35b45c"
                        +"ef760014904671014a193f40c15fc244").FromBase16(),
                Result_OKM =
                        ("b11e398dc80327a1c8e7f78c596a4934"
                        +"4f012eda2d4efad8a050cc4c19afa97c"
                        +"59045a99cac7827271cb41c65e590e09"
                        +"da3275600c2f09b8367793a9aca3db71"
                        +"cc30c58179ec3e87c14c01d5c1f3434f"
                        +"1d87  ").FromBase16(),
                },

            // Case 3
            new TestVectorDerive () {
                IKM = TestVector.FillConstant (22, 0x0b),
                Salt = null,
                Info = null,
                L=42,
                Result_PRK =
                        ("19ef24a32c717b167f33a91d6f648bdf"
                        +"96596776afdb6377ac434c1c293ccb04").FromBase16(),
                Result_OKM =
                        ("8da4e775a563c18f715f802a063c5a31"
                        +"b8a11f5c5ee1879ec3454e5f3c738d2d"
                        +"9d201395faa4b61a96c8").FromBase16(),
                },

            };

        [TestMethod]
        public void TestDerive_5869_Separate() {
            foreach (var TestVector in TestVectors_Derive_5869_SHA256) {

                var SHA256 = CryptoCatalog.Default.GetAuthentication(CryptoAlgorithmID.HMAC_SHA_2_256);

                TestVector.Verify(SHA256);
                }
            }


        //Try to request too many bits (MUST fail).

        [TestMethod]
        [ExpectedException (typeof(ImplementationLimit))]
        public void TestDerive_5869_Allocate_Fail() {
            foreach (var TestVector in TestVectors_Derive_5869_SHA256) {

                var SHA256 = CryptoCatalog.Default.GetAuthentication(CryptoAlgorithmID.HMAC_SHA_2_256);
                var KDF = new KeyDeriveHKDF(
                            TestVectors_Derive_5869_SHA256[0].IKM,
                            TestVectors_Derive_5869_SHA256[0].Salt, SHA256);
                var OKM = KDF.Derive(TestVectors_Derive_5869_SHA256[0].Info, (32*255) + 1);


                }
            }



        }


    public class TestVectorDerive {

        public byte[] IKM { get; set; }

        public byte[] Salt { get; set; }

        public byte[] Info { get; set; }

        public int L { get; set; }

        public byte[] Result_PRK { get; set; }

        public byte[] Result_OKM { get; set; }


        public void Verify(global::Goedel.Cryptography.CryptoProviderAuthentication Provider) {
            var KDF = new KeyDeriveHKDF(IKM, Salt, Provider);
            var OKM = KDF.Derive(Info, L * 8);


            TraceX.WriteLine("PRK = {0}", KDF.PRK.ToStringBase16());

            UT.Assert.IsTrue(KDF.PRK.IsEqualTo(Result_PRK));
            UT.Assert.IsTrue(OKM.IsEqualTo(Result_OKM));
            }

        public void Verify(CryptoAlgorithmID ID) {
            global::Goedel.Cryptography.CryptoProviderAuthentication Provider = CryptoCatalog.Default.GetAuthentication(ID);

            var KDF = new KeyDeriveHKDF(IKM, Salt, Provider);
            var OKM = KDF.Derive(Info, L * 8);

            TraceX.WriteLine("PRK = {0}", KDF.PRK.ToStringBase16());

            UT.Assert.IsTrue(KDF.PRK.IsEqualTo(Result_PRK));
            UT.Assert.IsTrue(OKM.IsEqualTo(Result_OKM));
            }


        }
    }
