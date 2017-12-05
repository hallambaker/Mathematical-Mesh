using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GU=Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Framework;
using Goedel.Cryptography.KeyFile;
using Goedel.IO;
using Goedel.Test;

namespace Goedel.Cryptography.Test {
    [TestClass]
    public partial class TestCryptography {

        

        static CryptoProviderExchange Encrypter;
        static CryptoProviderSignature Signer;

        static RSAKeyPairBase EncrypterKeyPair;
        static RSAKeyPairBase SignerKeyPair;

        const CryptoAlgorithmID CryptoAlgorithmID = Goedel.Cryptography.CryptoAlgorithmID.RSAExch;

        [AssemblyInitialize]
        public static void Initialize (TestContext Context) {
            Goedel.IO.Debug.Initialize();
            CryptographyFramework.Initialize();

            SignerKeyPair = (RSAKeyPairBase) KeyFileDecode.DecodePEM(Directories.TestKey_OpenSSH_Private);
            Signer = SignerKeyPair.SignatureProvider();


            EncrypterKeyPair = (RSAKeyPairBase) KeyFileDecode.DecodePEM(Directories.TestKey_OpenSSH_Private);
            Encrypter = EncrypterKeyPair.ExchangeProvider();
            }


        }
    }
