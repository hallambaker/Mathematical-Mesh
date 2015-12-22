//Sample license text.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Goedel.LibCrypto;
using Goedel.Debug;
using Goedel.Protocol;
using Goedel.Cryptography.Jose;

namespace CryptoTest {
    class Program {
        static void Main(string[] args) {
            KeyPair.TestMode = true;
            var T = CryptoSuites.Default;

            var Test = new Test();
            Test.Do();
            }
        }

    class Test {
        CryptoCatalog CryptoCatalog;
        string HelloWorld = "Hello World!";

        string HelloWorld_SHA_2_256 = "7f83b1657ff1fc53b92dc18148a1d65dfc2d4b1fa3d677284addd200126d9069";
        string HelloWorld_SHA_2_512 = "861844d6704e8573fec34d967e20bcfef3d424cf48be04e6dc08f2bd58c729743371015ead891cc3cf1c9d34b49264b510751b1ff9e537937bc46b5d6ff4ecc8";

        //string HelloWorld_HMAC_SHA_2_256 = "d5c76cef29e08eed61cd130f6e9883ab8f17dc439b2752655eda8c3a13d5676c";
        string HelloWorld_HMAC_SHA_2_512 = "f9701f6bcc90b321860d88abb2b48f89b4ebd07b211d2463ddf20b44ccfd52a57125e0e9d6f9ca7adc86e9c5eb5268246f75f0e8bdd2139311cfc29f99418e53";


        byte[] Test1Key = Trace.HexToByte("0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b");
        byte[] Test1Data = Trace.HexToByte("4869205468657265");
        byte[] Test1SHA256 = Trace.HexToByte("b0344c61d8db38535ca8afceaf0bf12b881dc200c9833da726e9376c2e32cff7");
        byte[] Test1SHA512 = Trace.HexToByte("87aa7cdea5ef619d4ff0b4241a1d6cb02379f4e2ce4ec2787ad0b30545e17cdedaa833b7d6b8a702038b274eaea3f4e4be9d914eeb61f1702e696c203a126854");

        public void Do() {
            CryptoCatalog = new CryptoCatalog();

            Trace.WriteLine("Start Test");
            TestDigest(CryptoAlgorithmID.SHA_2_256, HelloWorld, HelloWorld_SHA_2_256);
            TestDigest(CryptoAlgorithmID.SHA_2_512, HelloWorld, HelloWorld_SHA_2_512);

            TestAuthentication(CryptoAlgorithmID.HMAC_SHA_2_256, Test1Key, Test1Data, Test1SHA256);
            TestAuthentication(CryptoAlgorithmID.HMAC_SHA_2_512, Test1Key, Test1Data, Test1SHA512);

            // Test Bulk Encryption
            TestEncryption(CryptoAlgorithmID.AES128CBC, HelloWorld);
            TestEncryption(CryptoAlgorithmID.AES256CBC, HelloWorld);


            TestEncryption(CryptoAlgorithmID.AES128CBC, "01234567890ABCDEF0");


            TestEncryption(CryptoAlgorithmID.AES128CBC, HelloWorld_HMAC_SHA_2_512);
            TestEncryption(CryptoAlgorithmID.AES256CBC, HelloWorld_HMAC_SHA_2_512);

            //TestEncryption(CryptoAlgorithmID.AES128CTS, HelloWorld);
            //TestEncryption(CryptoAlgorithmID.AES256CTS, HelloWorld);

            // Test Sign & Verify
            TestSignVerify(CryptoAlgorithmID.RSASign2048, CryptoAlgorithmID.SHA_2_256, HelloWorld);
            TestSignVerify(CryptoAlgorithmID.RSASign4096, CryptoAlgorithmID.SHA_2_256, HelloWorld);
            TestSignVerify(CryptoAlgorithmID.RSASign2048, CryptoAlgorithmID.SHA_2_512, HelloWorld);
            TestSignVerify(CryptoAlgorithmID.RSASign4096, CryptoAlgorithmID.SHA_2_512, HelloWorld);
            // Test Encrypt and Decrypt

            TestPublicEncrypt(CryptoAlgorithmID.RSAExch2048, CryptoAlgorithmID.AES128CBC, HelloWorld);
            TestPublicEncrypt(CryptoAlgorithmID.RSAExch2048, CryptoAlgorithmID.AES256CBC, HelloWorld);

            TestPublicEncrypt(CryptoAlgorithmID.RSAExch4096, CryptoAlgorithmID.AES128CBC, HelloWorld);
            TestPublicEncrypt(CryptoAlgorithmID.RSAExch4096, CryptoAlgorithmID.AES256CBC, HelloWorld);
            }


        public void TestDigest(CryptoAlgorithmID DigestID, string Input, string TestHex) {
            var TestVector = Trace.HexToByte(TestHex);

            var Provider = CryptoCatalog.GetDigest(DigestID);
            Trace.WriteLine("Test provider {0}", Provider.Name);
            var Result = Provider.Process(HelloWorld);
            Trace.WriteHex("Result", Result.Integrity);
            Trace.AssertEqual("Check Testvector", Result.Integrity, TestVector);

            // Reinitialize and retest
            Provider.Initialize();
            var Result2 = Provider.Process(HelloWorld);
            Trace.WriteHex("Result#2", Result2.Integrity);
            Trace.AssertEqual("Check reinitialization", Result.Integrity, Result2.Integrity);

            // Check that the validation is correct
            Result.Integrity[0] = (byte)(Result.Integrity[0] ^ 0xff);
            Trace.AssertNotEqual("Check verification code", Result.Integrity, Result2.Integrity);
            }


        public void TestAuthentication(CryptoAlgorithmID MACID, byte[] Key, byte[] Input, byte[] TestVector) {

            var Provider = CryptoCatalog.GetAuthentication(MACID);
            Provider.Key = Key;

            Trace.WriteLine("Test provider {0}", Provider.Name);
            var Result = Provider.Process(Input);
            Trace.WriteHex("Result", Result.Integrity);
            Trace.AssertEqual("Check Testvector", Result.Integrity, TestVector);

            // Reinitialize and retest
            Provider.Initialize();
            var Result2 = Provider.Process(Input);
            Trace.WriteHex("Result#2", Result2.Integrity);
            Trace.AssertEqual("Check reinitialization", Result.Integrity, Result2.Integrity);

            // Check that the validation is correct
            Result.Integrity[0] = (byte)(Result.Integrity[0] ^ 0xff);
            Trace.AssertNotEqual("Check verification code", Result.Integrity, Result2.Integrity);
            }

        public void TestEncryption(CryptoAlgorithmID EncID, string Text) {

            var BinaryText = Encoding.UTF8.GetBytes(Text);

            var Encryptor = CryptoCatalog.GetEncryption(EncID);
            Trace.WriteLine("Test provider {0}", Encryptor.Name);

            // Encrypt using provider generated Key and IV
            Encryptor.StartEncrypt();
            var Result = Encryptor.Process(BinaryText);

            // Decrypt from cryto blob.
            var Decryptor = CryptoCatalog.GetEncryption(EncID);
            var Result2 = Decryptor.Decrypt(Result, Result.Data);

            Trace.AssertEqual("Encryption Round Trip", BinaryText, Result2.Data);
            }

        public void TestSignVerify(CryptoAlgorithmID SignID, CryptoAlgorithmID DigestID, string Text) {

            var SignProvider = CryptoCatalog.GetSignature(SignID);
            var DigestProvider = CryptoCatalog.GetDigest(DigestID);
            Trace.WriteLine("Test provider {0} with {1}", SignProvider.Name, DigestProvider.Name);

            var Result = DigestProvider.Process(Text);
            Trace.WriteHex("Digest", Result.Integrity);


            SignProvider.Generate(KeySecurity.Ephemeral);
            Trace.WriteLine("fingerprint {0}", SignProvider.UDF);

            var Signature = SignProvider.Sign(Result);
            Trace.WriteHex("Signature", Signature.Integrity);

            // Find the signature provider in the local store by fingerprint.
            var VerifyProvider = CryptoCatalog.GetSignature(SignProvider.UDF);

            var ValidSignResult = VerifyProvider.Verify(Result, Signature);
            Trace.WriteLine("Checked valid signature valid={0}", ValidSignResult);

            Trace.Assert("Check valid signature", ValidSignResult);

            // Clobber the integrity data
            Result.Integrity[0] = (byte)(Result.Integrity[0] ^ 0xff);

            var InvalidSignResult = VerifyProvider.Verify(Result, Signature);
            Trace.WriteLine("Checked valid signature valid={0}", InvalidSignResult);

            Trace.Assert("Check invalid signature", !InvalidSignResult);
            }

        public void TestPublicEncrypt(CryptoAlgorithmID PublicID, CryptoAlgorithmID BulkID, string Text) {
            var PublicProvider = CryptoCatalog.GetExchange(PublicID);
            var Encryptor = CryptoCatalog.GetEncryption(BulkID);
            Trace.WriteLine("Test provider {0} with {1}", PublicProvider.Name, Encryptor.Name);

            var BinaryText = Encoding.UTF8.GetBytes(Text);

            Encryptor.StartEncrypt();
            var Key = Encryptor.Key;
            var IV = Encryptor.IV;
            var Result = Encryptor.Process(BinaryText);

            PublicProvider.Generate(KeySecurity.Ephemeral);
            var EncryptedKey = PublicProvider.Encrypt(Result);
            Trace.WriteHex("Public key blob:", EncryptedKey.Data);

            // find the key by UDF
            var PublicDecryptor = CryptoCatalog.GetExchange(PublicProvider.UDF);
            var DecryptedKey = PublicDecryptor.Decrypt(EncryptedKey);

            Trace.AssertEqual("Encryption Round Trip", Key, DecryptedKey.Key);

            var Decryptor = CryptoCatalog.GetEncryption(BulkID);
            Decryptor.StartDecrypt(DecryptedKey.Key, IV);

            Result.Key = DecryptedKey.Key;
            var Result2 = Decryptor.Decrypt(Result, Result.Data);

            Trace.AssertEqual("Encryption Round Trip", BinaryText, Result2.Data);


            }




        }
    }
