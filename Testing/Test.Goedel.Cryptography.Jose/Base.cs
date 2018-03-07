using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Goedel.Cryptography;
using Goedel.Cryptography.Framework;
using Goedel.Cryptography.KeyFile;
using Goedel.IO;
using Goedel.Test;


namespace Test.Goedel.Cryptography.Jose {


    [TestClass]
    public partial class TestCryptography {

        static CryptoProviderExchange Encrypter;
        static CryptoProviderSignature Signer;

        static KeyPairBaseRSA EncrypterKeyPair;
        static KeyPairBaseRSA SignerKeyPair;

        static KeyPairDH AliceKeyPair;
        static KeyPairDH BobKeyPair;
        static KeyPairDH GroupKeyPair;

        [AssemblyInitialize]
        public static void Initialize(TestContext Context) {
            global::Goedel.IO.Debug.Initialize();
            CryptographyWindows.Initialize();

            SignerKeyPair = (KeyPairBaseRSA)KeyFileDecode.DecodePEM(Directories.TestKey_OpenSSH_Private);
            Signer = SignerKeyPair.SignatureProvider();

            EncrypterKeyPair = (KeyPairBaseRSA)KeyFileDecode.DecodePEM(Directories.TestKey_OpenSSH_Private);
            Encrypter = EncrypterKeyPair.ExchangeProvider();
            
            AliceKeyPair = new KeyPairDH();
            BobKeyPair = new KeyPairDH();
            GroupKeyPair = new KeyPairDH();

            }


        }
    }
