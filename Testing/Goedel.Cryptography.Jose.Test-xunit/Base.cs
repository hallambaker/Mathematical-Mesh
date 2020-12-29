
using Goedel.Cryptography;
using Goedel.Cryptography.KeyFile;
using Goedel.IO;
using Goedel.Test.Core;


namespace Goedel.XUnit {


    public partial class TestCryptographyJose {

        static KeyPairBaseRSA EncrypterKeyPair;
        static KeyPairBaseRSA SignerKeyPair;

        //static KeyPairDH AliceKeyPair;
        //static KeyPairDH BobKeyPair;
        //static KeyPairDH GroupKeyPair;

        static KeyPairDH TestKeyPairDH;
        static KeyPairBaseRSA TestKeyPairRSA;




        static TestCryptographyJose() {


            SignerKeyPair = (KeyPairBaseRSA)KeyFileDecode.DecodePEM(
                    Directories.TestKey_OpenSSH_Private, KeySecurity.Exportable, null);


            EncrypterKeyPair = (KeyPairBaseRSA)KeyFileDecode.DecodePEM(
                Directories.TestKey_OpenSSH_Private, KeySecurity.Exportable, null);


            TestKeyPairDH = new KeyPairDH(keySecurity: KeySecurity.Exportable);
            TestKeyPairRSA = SignerKeyPair;
            }


        }
    }
