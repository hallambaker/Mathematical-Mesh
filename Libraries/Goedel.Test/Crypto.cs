using System;
using System.Threading;
using System.Collections.Generic;
using UT = Microsoft.VisualStudio.TestTools.UnitTesting;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;
using Goedel.Cryptography.Algorithms;

namespace Goedel.Test {


    public class CryptoParametersTest : CryptoParameters {


        public CryptoParametersTest(
                    List<string> Recipients = null,
                    List<string> Signers = null,
                    CryptoAlgorithmID EncryptID = CryptoAlgorithmID.NULL,
                    CryptoAlgorithmID DigestID = CryptoAlgorithmID.NULL) :
            base(new KeyCollection(), Recipients, Signers, EncryptID, DigestID) {
            }

        protected override void AddEncrypt(string AccountId) => AddEncrypt(AccountId, true);

        public void AddEncrypt(string AccountId, bool Register = true) {
            EncryptionKeys = EncryptionKeys ?? new List<KeyPair>();

            var Keypair = new KeyPairDH();
            var Pub = Keypair.KeyPairPublic();
            var PublicKeyKeypair = Keypair.KeyPairPublic();
            EncryptionKeys.Add(PublicKeyKeypair);

            Console.WriteLine($"Keypair is {Keypair.UDF}");
            Console.WriteLine($"  Public {Keypair.PKIXPublicKeyDH}");
            Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

            if (Register) {
                KeyCollection.Add(Keypair);
                }

            }

        protected override void AddSign(string AccountId) => AddSign(AccountId, true);
        public void AddSign(string AccountId, bool Register) {
            SignerKeys = SignerKeys ?? new List<KeyPair>();

            var Keypair = KeyPairBaseRSA.Create() as KeyPairBaseRSA;
            var Public = Keypair.PKIXPublicKeyRSA;
            var PublicKeyKeypair = KeyPairBaseRSA.KeyPairPublicFactory(Public);
            SignerKeys.Add(Keypair);

            Console.WriteLine($"Keypair is {Keypair.UDF}");
            Console.WriteLine($"  Public {Keypair.PKIXPublicKeyRSA}");
            Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

            if (Register) {
                KeyCollection.Add(Keypair);
                }
            }

        }



    public class TestKeys {

        KeyCollection KeyCollection;

        public List<KeyPair> EncryptionKeys;
        public List<KeyPair> SignerKeys;

        public TestKeys(KeyCollection KeyCollection = null) => this.KeyCollection = KeyCollection ?? KeyCollection.Default;

        public void AddEncrypt(bool Register = true) {
            EncryptionKeys = EncryptionKeys ?? new List<KeyPair>();

            var Keypair = new KeyPairDH();
            var Public = Keypair.PKIXPublicKeyDH;
            var PublicKeyKeypair = KeyPairDH.KeyPairPublicFactory(Public);
            EncryptionKeys.Add(PublicKeyKeypair);

            Console.WriteLine($"Keypair is {Keypair.UDF}");
            Console.WriteLine($"  Public {Keypair.PKIXPublicKeyDH}");
            Console.WriteLine($"  Public {PublicKeyKeypair.UDF}");

            if (Register) {
                KeyCollection.Default.Add(Keypair);
                }
            }

        public void AddSign(bool Register = true) {
            SignerKeys = SignerKeys ?? new List<KeyPair>();

            throw new NYI();
            }
        }


    public static class Crypto {

        static int IDCount = 0;
        public static string MakeUnique(this string Base) {
            var Count = Interlocked.Increment(ref IDCount);
            var Split = Base.Split('@');

            return Split[0] + "_" + Count.ToString() + "@" + Split[1];
            }


        static Crypto() {
            }

        public const string TestString = "This is a test";

        public static void Test_EncryptDecrypt(this KeyPair KeyPair, string Test = TestString) {
            var Encrypter = KeyPair.ExchangeProvider();
            Encrypter.Test_EncryptDecrypt(Test);
            }





        public static void Test_EncryptDecrypt(this CryptoProviderExchange Encrypter, string Test = TestString) {
            var Result = Encrypter.Encrypt(Test);

            UT.Assert.IsTrue(Result.Exchanges.Count == 1);
            UT.Assert.IsTrue(Result.Signatures == null | Result.Signatures?.Count == 0);

            CheckDecrypt(Encrypter, Test, Result);
            }


        static void CheckDecrypt(CryptoProviderExchange Provider, string Expected, CryptoDataEncoder Result) {
            foreach (var Decrypt in Result.Exchanges) {
                CheckDecrypt(Provider, Expected, Result.BulkID, Result.ProcessedData, Result.IV,
                    Decrypt.Exchange, Decrypt.Ephemeral);
                }
            }

        static void CheckDecrypt(CryptoProviderExchange Provider, string Expected, CryptoAlgorithmID Bulk,
                    byte[] CipherText, byte[] IV, byte[] Exchange, KeyPair Ephemeral) {

            var Key = Provider.Decrypt(Exchange, Ephemeral);
            var BulkProvider = CryptoCatalog.Default.GetEncryption(Bulk);
            var Plaintext = BulkProvider.Decrypt(CipherText, Key, IV);

            UT.Assert.IsTrue(Expected == Plaintext.ToUTF8());
            }
        public static void Test_Lifecycle(this CryptoAlgorithmID CryptoAlgorithmID, int KeySize = 2048) {
            Test_LifecycleMaster(CryptoAlgorithmID, KeySize);
            Test_LifecycleAdmin(CryptoAlgorithmID, KeySize);
            Test_LifecycleDevice(CryptoAlgorithmID, KeySize);
            Test_LifecycleEphemeral(CryptoAlgorithmID, KeySize);
            Test_LifecycleExportable(CryptoAlgorithmID, KeySize);
            }



        public static void Test_LifecycleMaster(this CryptoAlgorithmID CryptoAlgorithmID, int KeySize = 2048) {
            var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Master, KeySize);
            Encrypter.Test_EncryptDecrypt();
            var UDF = Encrypter.UDF;

            ExportPrivate(UDF, true);
            CheckPersisted(UDF, true);


            }

        public static void Test_LifecycleAdmin(this CryptoAlgorithmID CryptoAlgorithmID, int KeySize = 2048) {
            var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Admin, KeySize);
            Encrypter.Test_EncryptDecrypt();
            var UDF = Encrypter.UDF;

            ExportPrivate(UDF, false);
            CheckPersisted(UDF, true);
            }



        public static void Test_LifecycleDevice(this CryptoAlgorithmID CryptoAlgorithmID, int KeySize = 2048) {
            var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Device, KeySize);
            Encrypter.Test_EncryptDecrypt();
            var UDF = Encrypter.UDF;

            ExportPrivate(UDF, false);
            CheckPersisted(UDF, true);
            }


        /// <summary>Test for lifecycle of ephemeral key. Key can be created and used but FindLocal
        /// fails as the key is never written to the local store</summary>
        /// <param name="CryptoAlgorithmID"></param>
        public static void Test_LifecycleEphemeral(this CryptoAlgorithmID CryptoAlgorithmID, int KeySize = 2048) {
            var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Ephemeral, KeySize);
            Encrypter.Test_EncryptDecrypt();
            var UDF = Encrypter.UDF;

            CheckPersisted(UDF, false);

            IPKIXPrivateKey Private = null;
            try {
                Private = Encrypter.PKIXPrivateKey;
                UT.Assert.Fail();
                }
            catch (NotExportable) {
                UT.Assert.IsNull(Private);
                }

            
            }

        /// <summary>Test for lifecycle of ephemeral key. Key can be created and used but FindLocal
        /// fails as the key is never written to the local store</summary>
        /// <param name="CryptoAlgorithmID"></param>
        public static void Test_LifecycleExportable(this CryptoAlgorithmID CryptoAlgorithmID, int KeySize=2048) {
            //var Encrypter = CryptoCatalog.Default.GetExchange(CryptoAlgorithmID);
            //Encrypter.Generate(KeySecurity.Exportable, KeySize: 2048);


            var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Exportable, KeySize);


            Encrypter.Test_EncryptDecrypt();
            var UDF = Encrypter.UDF;

            CheckPersisted(UDF, false);
            var Private = Encrypter.PKIXPrivateKey;
            UT.Assert.IsNotNull(Private);
            }



        /// <summary>
        /// Check persistence of the key, that it can be found in the local store and
        /// then that it cannot be found after deletion.
        /// </summary>
        /// <param name="UDF"></param>
        static void CheckPersisted(string UDF, bool Succeed) {
            var Encrypter2 = KeyPair.FindLocal(UDF);

            if (!Succeed) {
                UT.Assert.IsNull(Encrypter2);
                return; // No more testing possible
                }

            UT.Assert.IsNotNull(Encrypter2);
            Encrypter2.Test_EncryptDecrypt();

            Encrypter2.EraseFromDevice();

            var Encrypter3 = KeyPair.FindLocal(UDF);
            UT.Assert.IsNull(Encrypter3);
            }


        static void ExportPrivate(string UDF, bool Succeed) {
            try {
                var Encrypter2 = KeyPair.FindLocal(UDF);
                var Private = Encrypter2.PKIXPrivateKey;
                UT.Assert.IsTrue(Succeed);
                }

            catch (NotExportable) {
                UT.Assert.IsFalse(Succeed);
                }
            }


        }
    }
