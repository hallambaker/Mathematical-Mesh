using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

using System.Threading;

namespace Goedel.Mesh.Test {

    public static class Crypto {

        static int IDCount = 0;
        public static string MakeUnique(this string Base) {
            var Count = Interlocked.Increment(ref IDCount);
            var Split = Base.Split('@');

            return Split[0] + "_" + Count.ToString() + "@" + Split[1];
            }


        static Crypto() {
            }


        public static void Test_EncryptDecrypt(this KeyPair KeyPair) {

            var Key = Platform.GetRandomBits(256);

            KeyPair.Encrypt(Key, out var Exchange, out var Ephemeral);
            var Result = KeyPair.Decrypt(Exchange, Ephemeral);

            Assert.True(Key.IsEqualTo(Result));

            }


        public static void Test_Lifecycle(this CryptoAlgorithmId CryptoAlgorithmID, KeyCollection keyCollection, int KeySize = 2048) {
            Test_LifecycleMaster(CryptoAlgorithmID, keyCollection, KeySize);
            Test_LifecycleAdmin(CryptoAlgorithmID, keyCollection, KeySize);
            Test_LifecycleDevice(CryptoAlgorithmID, keyCollection, KeySize);
            Test_LifecycleEphemeral(CryptoAlgorithmID, keyCollection, KeySize);
            Test_LifecycleExportable(CryptoAlgorithmID, keyCollection, KeySize);
            }



        public static void Test_LifecycleMaster(this CryptoAlgorithmId CryptoAlgorithmID, KeyCollection keyCollection, int KeySize = 2048) {
            bool Exportable = true;
            var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Master, keyCollection, keySize: KeySize);
            Encrypter.Test_EncryptDecrypt();
            TestExport(Encrypter, Exportable);
            CheckPersisted(Encrypter.KeyIdentifier, keyCollection, true, Exportable);
            }

        public static void Test_LifecycleAdmin(this CryptoAlgorithmId CryptoAlgorithmID, KeyCollection keyCollection, int KeySize = 2048) {
            bool Exportable = false;
            var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Admin, keyCollection, keySize: KeySize);
            Encrypter.Test_EncryptDecrypt();
            TestExport(Encrypter, Exportable);
            CheckPersisted(Encrypter.KeyIdentifier, keyCollection, true, Exportable);
            }



        public static void Test_LifecycleDevice(this CryptoAlgorithmId CryptoAlgorithmID, KeyCollection keyCollection, int KeySize = 2048) {
            bool Exportable = false;
            var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Device, keyCollection, keySize: KeySize);
            Encrypter.Test_EncryptDecrypt();
            TestExport(Encrypter, Exportable);
            CheckPersisted(Encrypter.KeyIdentifier, keyCollection, true, Exportable);
            }


        /// <summary>Test for lifecycle of ephemeral key. Key can be created and used but FindLocal
        /// fails as the key is never written to the local store</summary>
        /// <param name="CryptoAlgorithmID"></param>
        public static void Test_LifecycleEphemeral(this CryptoAlgorithmId CryptoAlgorithmID, KeyCollection keyCollection, int KeySize = 2048) {
            bool Exportable = false;
            var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.Ephemeral, keyCollection, keySize: KeySize);
            Encrypter.Test_EncryptDecrypt();
            TestExport(Encrypter, Exportable);
            CheckPersisted(Encrypter.KeyIdentifier, keyCollection, false, Exportable);
            }

        /// <summary>Test for lifecycle of ephemeral key. Key can be created and used but FindLocal
        /// fails as the key is never written to the local store</summary>
        /// <param name="CryptoAlgorithmID"></param>
        public static void Test_LifecycleExportable(this CryptoAlgorithmId CryptoAlgorithmID, KeyCollection keyCollection, int KeySize = 2048) {
            bool Exportable = true;
            var Encrypter = KeyPair.Factory(CryptoAlgorithmID, KeySecurity.ExportableStored, keyCollection, keySize: KeySize);
            Encrypter.Test_EncryptDecrypt();
            TestExport(Encrypter, Exportable);
            CheckPersisted(Encrypter.KeyIdentifier, keyCollection, true, Exportable);
            }


        static void TestExport(KeyPair keyPair, bool Succeed) {

            IPKIXPrivateKey Private = null;
            try {
                Private = keyPair.PKIXPrivateKey;
                Assert.True(Succeed);
                }
            catch (NotExportable) {
                Assert.False(Succeed);
                Assert.Null(Private);
                }

            }


        /// <summary>
        /// Check persistence of the key, that it can be found in the local store and
        /// then that it cannot be found after deletion.
        /// </summary>
        /// <param name="UDF"></param>
        static void CheckPersisted(string UDF, KeyCollection keyCollection, bool persisted, bool exportable) {

            var key = keyCollection.LocatePrivateKeyPair(UDF);
            if (!persisted) {
                Assert.Null(key);
                return;
                }
            TestExport(key, exportable);
            }



        }
    }
