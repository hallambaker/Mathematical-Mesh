#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using Goedel.Cryptography;
using Goedel.Cryptography.KeyFile;
using Goedel.IO;
using Goedel.Mesh.Test;
using Goedel.Test;

using Xunit;

namespace Goedel.XUnit;


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
