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



// Todo: SSH Add support for SSH ECC Algorithms
// Todo: SSH Support for per device client keys
// Todo: SSH Create SSH root of trust for user
// Todo: SSH Collect host credentials, sign and book to service
// Todo: SSH Passphrase for PEM Private keys

namespace Goedel.Mesh;


public partial class ApplicationCredential {
    }

public partial class CatalogedApplicationCredential {

    public KeyPair PrimaryPrivate { get; set; }


    public static CatalogedApplicationCredential Create(
                        string localName, 
                        List<string> roles,
                        CredentialProfile credentialProfile,
                        CatalogedApplicationCredential parent=null) {

        var clientKey = KeyPair.Factory(credentialProfile.AlgorithmId,
                    KeySecurity.Exportable, keySize: credentialProfile.keySize);

        var result = new CatalogedApplicationCredential() {
            Key = clientKey.KeyIdentifier,
            LocalName = localName,
            Grant = roles,
            Kind = "Credential",
            PrimaryPrivate = clientKey,
            Primary = new KeyData(clientKey)
            };

        return result;
        }



    ///<inheritdoc/>
    public override void Activate(List<ApplicationEntry> activationEntry, ProfileDevice profileDevice, IKeyCollection keyCollection) {
        }



    ///<inheritdoc/>
    public override KeyData[] GetEscrow() => Array.Empty<KeyData>();

    ///<inheritdoc/>
    public override ApplicationEntry? GetActivation(CatalogedDevice catalogedDevice) => null;

    ///<inheritdoc/>
    public override void ToBuilder(StringBuilder output) {

        }
    }




