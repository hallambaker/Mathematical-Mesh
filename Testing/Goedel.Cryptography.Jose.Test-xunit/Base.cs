using System.Numerics;
using System.IO;

using Goedel.Cryptography;
using Goedel.Cryptography.KeyFile;
using Goedel.IO;
using Goedel.Test.Core;


namespace Goedel.XUnit {


    public partial class TestCryptographyJose : Initialization{

        static KeyPairBaseRSA EncrypterKeyPair;
        static KeyPairBaseRSA SignerKeyPair;

        static KeyPairDH AliceKeyPair;
        static KeyPairDH BobKeyPair;
        static KeyPairDH GroupKeyPair;

        static KeyPairDH TestKeyPairDH;
        static KeyPairBaseRSA TestKeyPairRSA;

        static bool Initialized;

        public TestCryptographyJose() => Initialize(ref Initialized, Initializer);


        static void Initializer (bool test=true) {

            TestEnvironment.Initialize();

            SignerKeyPair = (KeyPairBaseRSA)KeyFileDecode.DecodePEM(
                    Directories.TestKey_OpenSSH_Private, KeySecurity.Exportable, null);
            //Signer = SignerKeyPair.SignatureProvider();

            EncrypterKeyPair = (KeyPairBaseRSA)KeyFileDecode.DecodePEM(
                Directories.TestKey_OpenSSH_Private, KeySecurity.Exportable, null);
            //Encrypter = EncrypterKeyPair.ExchangeProvider();
            
            AliceKeyPair = new KeyPairDH(keySecurity: KeySecurity.Exportable);
            BobKeyPair = new KeyPairDH(keySecurity: KeySecurity.Exportable);
            GroupKeyPair = new KeyPairDH(keySecurity: KeySecurity.Exportable);

            TestKeyPairDH = new KeyPairDH(keySecurity:KeySecurity.Exportable);
            TestKeyPairRSA = SignerKeyPair;
            }


        }
    }
