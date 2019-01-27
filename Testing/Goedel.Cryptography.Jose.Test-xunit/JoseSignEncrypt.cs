using System;


using Goedel.Utilities;
using Goedel.Test;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Test.Core;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography;
using Xunit;


namespace Goedel.XUnit {

    public partial class TestCryptographyJose {

        public static TestCryptographyJose Test() => new TestCryptographyJose();

        static string TestString = "This is a test";
        static string TestStringBad = "This is a Test"; // Flip one bit


        [Theory]
        [InlineData(CryptoAlgorithmID.Ed448)]
        [InlineData(CryptoAlgorithmID.Ed25519)]
        [InlineData(CryptoAlgorithmID.X448)]
        [InlineData(CryptoAlgorithmID.X25519)]
        [InlineData(CryptoAlgorithmID.DH)]
        [InlineData(CryptoAlgorithmID.RSAExch)]
        [InlineData(CryptoAlgorithmID.RSASign)]
        public void RoundTripKey(CryptoAlgorithmID cryptoAlgorithmID) {
            var key = KeyPair.Factory(CryptoAlgorithmID.Ed448, keySecurity: KeySecurity.Ephemeral);
            var jsonPublic = Key.GetPublic(key);
            var key2 = jsonPublic.KeyPair;
            key.UDF.AssertEqual(key2.UDF);

            var jsonPrivate = Key.GetPrivate(key);
            var key3 = jsonPrivate.KeyPair;
            key.UDF.AssertEqual(key3.UDF);
            }


        [Fact]
        public void Test_Jose_Encrypt() {

            // Limit - make use of KeyCollection.

            var JWE = new JoseWebEncryption(TestString, EncrypterKeyPair);
            var JWEText = JWE.ToString();
            var JWEProt = JWE.Protected.ToUTF8();

            var JWE2 = JoseWebEncryption.FromJSON(JWEText.JSONReader(),false);
            var Data = JWE2.Decrypt(EncrypterKeyPair);
            var Text = Data.ToUTF8();

            Utilities.Assert.True(TestString==Text);
            }



        [Fact]
        public void Test_Jose_Encrypt_Symmetric() {

            var Key = Platform.GetRandomBits(256);
            var JWE = new JoseWebEncryption(TestString, Key);
            var JWEText = JWE.ToString();

            var JWE2 = JoseWebEncryption.FromJSON(JWEText.JSONReader(), false);

            var Data = JWE2.Decrypt(Key);
            var Text = Data.ToUTF8();

            Utilities.Assert.True(TestString== Text);
            }


        [Fact]
        public void Test_Jose_Sign() {
            var JWS = new JoseWebSignature(TestString, SignerKeyPair);
            var JWSText = JWS.ToString();

            foreach (var Signer in JWS.Signatures) {
                var JWSProt = Signer.Protected.ToUTF8();
                }

            var JWS2 = JoseWebSignature.FromJSON(JWSText.JSONReader(), false);

            var Verify1 = JWS2.Verify(SignerKeyPair);
            Utilities.Assert.True(Verify1);

            JWS2.Payload = TestStringBad.ToBytes();
            var Verify2 = JWS2.Verify(SignerKeyPair);
            Utilities.Assert.False(Verify2);
            }


        [Fact]
        public void Test_Jose_Sign_Encrypt() {

            var JWES = new JoseWebEncryption(TestString, EncrypterKeyPair, SignerKeyPair);
            var JWESText = JWES.ToString();
            var JWESProt = JWES.Protected.ToUTF8();

            foreach (var Signer in JWES.Signatures) {
                var JWSProt = Signer.Protected.ToUTF8();
                }

            var JWES2 = JoseWebEncryption.FromJSON(JWESText.JSONReader(), false);

            var Data2 = JWES2.Decrypt(EncrypterKeyPair);
            var Text = Data2.ToUTF8();

            var Verify1 = JWES2.Verify(SignerKeyPair);

            Utilities.Assert.True(TestString== Text);
            Utilities.Assert.True(Verify1);

            // Test: Check for a bad signature.
            }


        [Fact]
        public void Test_Write_RSA_Public() {
            var Key = new PublicKeyRSA(TestKeyPairRSA.PKIXPublicKeyRSA);

            var Text = Key.ToJson();
            ("Test_Write_RSA_Public.jpub").WriteFileNew(Text);

            // TEST: check that the key can be read back and used???
            }

        [Fact]
        public void Test_Write_RSA_Private() {
            var Key = new PrivateKeyRSA(TestKeyPairRSA.PKIXPrivateKeyRSA);

            var Text = Key.ToJson(true);
            ("Test_Write_RSA_Private.jprv").WriteFileNew(Text);

            // TEST: check that the key can be read back and used???
            }

        [Fact]
        public void Test_Write_DH_Public() {

            var Key = new PublicKeyDH(TestKeyPairDH.PKIXPublicKeyDH);

            var Text = Key.ToJson();
            ("Test_Write_DH_Public.jpub").WriteFileNew(Text);

            // TEST: check that the key can be read back and used???
            }

        [Fact]
        public void Test_Write_DH_Private() {
            var Key = new PrivateKeyDH(TestKeyPairDH.PKIXPrivateKeyDH);

            var Text = Key.ToJson(true);
            ("Test_Write_DH_Private.jprv").WriteFileNew(Text);

            // TEST: check that the key can be read back and used???
            }

        }
    }
