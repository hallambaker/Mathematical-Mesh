using Goedel.Cryptography;
using Goedel.Cryptography.KeyFile;
using Goedel.IO;
using Goedel.Test.Core;

using Xunit;

namespace Goedel.XUnit {

    public partial class KeyFileTest {
        public KeyFileTest() => TestEnvironmentCommon.Initialize(true);
        public static KeyFileTest Test() => new KeyFileTest();



        [Fact]
        public void TestKeyRead() {

            var SSH_Public = KeyFileDecode.DecodePEM(Directories.TestKey_SSH2, KeySecurity.Exportable, null);
            var SSH_AuthHosts = KeyFileDecode.DecodeAuthHost(Directories.TestKey_OpenSSH);
            var SSH_Private = KeyFileDecode.DecodePEM(Directories.TestKey_OpenSSH_Private, KeySecurity.Exportable, null);

            Utilities.Assert.True(SSH_Public.UDF == SSH_Private.UDF);
            Utilities.Assert.True(SSH_AuthHosts[0].SSHData.KeyPair.UDF == SSH_Private.UDF);

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
