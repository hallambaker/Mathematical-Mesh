using Goedel.Cryptography;
using Goedel.Cryptography.KeyFile;
using Goedel.IO;
using Goedel.Mesh.Test;
using Goedel.Test;

using Xunit;

namespace Goedel.XUnit {


    public partial class KeyFileTest {
        public static KeyFileTest Test() => new();

        

        [Fact]
        public void TestKeyRead() {

            var SSH_Public = KeyFileDecode.DecodePEM(Directories.TestKey_SSH2, KeySecurity.Exportable, null);
            var SSH_AuthHosts = KeyFileDecode.DecodeAuthHost(Directories.TestKey_OpenSSH);
            var SSH_Private = KeyFileDecode.DecodePEM(Directories.TestKey_OpenSSH_Private, KeySecurity.Exportable, null);

            (SSH_Public.KeyIdentifier == SSH_Private.KeyIdentifier).TestTrue();
            (SSH_AuthHosts[0].SSHData.KeyPair.KeyIdentifier == SSH_Private.KeyIdentifier).TestTrue();

            }
        [Fact]
        public void TestWritePEMRSA() {
            var SignerKeyPair = KeyFileDecode.DecodePEM(Directories.TestKey_OpenSSH_Private, KeySecurity.Exportable, null);
            var OutFile = "TestWritePEMRSA.prv";
            var DataString = SignerKeyPair.ToPEMPrivate();
            OutFile.WriteFileNew(DataString);

            }
        // TEST: Write File SSH Public RSA
        // TEST: Write File PEM Putty RSA
        // TEST: Write File PEM SSH RSA
        }
    }
