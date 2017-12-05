using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Utilities;
using Goedel.Test;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Framework;




namespace Test.Goedel.Cryptography.Jose {

    public partial class TestCryptography {


        string TestString = "This is a test";
        string TestStringBad = "This is a Test"; // Flip one bit

        [TestMethod]
        public void Test_Jose_Encrypt() {

            var JWE = new JoseWebEncryption(TestString, EncrypterKeyPair);
            var JWEText = JWE.ToString();
            var JWEProt = JWE.Protected.ToUTF8();

            var JWE2 = JoseWebEncryption.FromJSON(JWEText.JSONReader());
            var Data = JWE2.Decrypt(EncrypterKeyPair);
            var Text = Data.ToUTF8();

            UT.Assert.AreEqual(TestString, Text);
            }



        [TestMethod]
        public void Test_Jose_Encrypt_Symmetric() {

            var Key = Platform.GetRandomBits(256);
            var JWE = new JoseWebEncryption(TestString, Key);
            var JWEText = JWE.ToString();

            var JWE2 = JoseWebEncryption.FromJSON(JWEText.JSONReader());

            var Data = JWE2.Decrypt(Key);
            var Text = Data.ToUTF8();

            UT.Assert.AreEqual(TestString, Text);
            }


        [TestMethod]
        public void Test_Jose_Sign() {
            var JWS = new JoseWebSignature(TestString, SignerKeyPair);
            var JWSText = JWS.ToString();

            foreach (var Signer in JWS.Signatures) {
                var JWSProt = Signer.Protected.ToUTF8();
                }

            var JWS2 = JoseWebSignature.FromJSON(JWSText.JSONReader());

            var Verify1 = JWS2.Verify(SignerKeyPair);
            UT.Assert.IsTrue(Verify1);

            JWS2.Payload = TestStringBad.ToBytes();
            var Verify2 = JWS2.Verify(SignerKeyPair);
            UT.Assert.IsFalse(Verify2);
            }


        [TestMethod]
        public void Test_Jose_Sign_Encrypt() {

            var JWES = new JoseWebEncryption(TestString, EncrypterKeyPair, SignerKeyPair);
            var JWESText = JWES.ToString();
            var JWESProt = JWES.Protected.ToUTF8();

            foreach (var Signer in JWES.Signatures) {
                var JWSProt = Signer.Protected.ToUTF8();
                }

            var JWES2 = JoseWebEncryption.FromJSON(JWESText.JSONReader());

            var Data2 = JWES2.Decrypt(EncrypterKeyPair);
            var Text = Data2.ToUTF8();

            var Verify1 = JWES2.Verify(SignerKeyPair);

            UT.Assert.AreEqual(TestString, Text);
            UT.Assert.IsTrue(Verify1);

            // Test: Check for a bad signature.
            }


        [TestMethod]
        public void Test_Write_RSA_Public() {
            var Key = new PublicKeyRSA(SignerKeyPair.PKIXPublicKeyRSA);

            var Text = Key.ToJson();
            (Directories.Results + "Test_Write_RSA_Public.jpub").WriteFileNew(Text);
            }

        [TestMethod]
        public void Test_Write_RSA_Private() {
            var Key = new PrivateKeyRSA(SignerKeyPair.PKIXPrivateKeyRSA);

            var Text = Key.ToJson(true);
            (Directories.Results + "Test_Write_RSA_Private.jprv").WriteFileNew(Text);
            }

        [TestMethod]
        public void Test_Write_DH_Public() {


            }

        [TestMethod]
        public void Test_Write_DH_Private() {


            }

        }
    }
