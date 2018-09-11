using System.Numerics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Cryptography;
using Goedel.Cryptography.KeyFile;
using Goedel.IO;
using Goedel.Test;


namespace Goedel.Cryptography.Jose.Test {


    [TestClass]
    public partial class TestCryptographyJose {


        /// <summary>
        /// 
        /// </summary>
        public static void TestDirect() {
            InitializeClass();

            var Instance = new TestCryptographyJose();

            Instance.Test_Write_RSA_Public();
            Instance.Test_Write_RSA_Private();
            Instance.Test_Write_DH_Public();
            Instance.Test_Write_DH_Private();
            }


        static CryptoProviderExchange Encrypter;
        static CryptoProviderSignature Signer;

        static KeyPairBaseRSA EncrypterKeyPair;
        static KeyPairBaseRSA SignerKeyPair;

        static KeyPairDH AliceKeyPair;
        static KeyPairDH BobKeyPair;
        static KeyPairDH GroupKeyPair;

        static KeyPairDH TestKeyPairDH;
        static KeyPairBaseRSA TestKeyPairRSA;

        [AssemblyInitialize]
        public static void Initialize(TestContext Context) {
            Directory.SetCurrentDirectory(Directories.RunDirectory);
            InitializeClass();
            }

        public static void InitializeClass() {

            global::Goedel.IO.Debug.Initialize();
            CryptographyWindows.Initialize();

            SignerKeyPair = (KeyPairBaseRSA)KeyFileDecode.DecodePEM(Directories.TestKey_OpenSSH_Private);
            Signer = SignerKeyPair.SignatureProvider();

            EncrypterKeyPair = (KeyPairBaseRSA)KeyFileDecode.DecodePEM(Directories.TestKey_OpenSSH_Private);
            Encrypter = EncrypterKeyPair.ExchangeProvider();
            
            AliceKeyPair = new KeyPairDH();
            BobKeyPair = new KeyPairDH();
            GroupKeyPair = new KeyPairDH();

            TestKeyPairDH = new KeyPairDH(KeySecurity.Exportable);
            TestKeyPairRSA = SignerKeyPair;
            }


        }
    }
