
using Goedel.Cryptography;
using Goedel.Cryptography.KeyFile;
using Goedel.Mesh.Test;
using Goedel.Test;

namespace Goedel.XUnit {


    public partial class TestCryptographyJose {

        static KeyPairBaseRSA EncrypterKeyPair;
        static KeyPairBaseRSA SignerKeyPair;

        static KeyPairDH TestKeyPairDH;
        static KeyPairBaseRSA TestKeyPairRSA;

        static TestCryptographyJose() {
            Goedel.Cryptography.Core.Initialization.Initialized.TestTrue();

            SignerKeyPair = (KeyPairBaseRSA)KeyFileDecode.DecodePEM(
                    Directories.TestKey_OpenSSH_Private, KeySecurity.Exportable, null);


            EncrypterKeyPair = (KeyPairBaseRSA)KeyFileDecode.DecodePEM(
                Directories.TestKey_OpenSSH_Private, KeySecurity.Exportable, null);


            TestKeyPairDH = new KeyPairDH(keySecurity: KeySecurity.Exportable);
            TestKeyPairRSA = SignerKeyPair;
            }


        }
    }
