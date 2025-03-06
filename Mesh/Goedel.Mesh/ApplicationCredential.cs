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



public partial class CatalogedApplicationCredential {

    ///<summary>The primary keypair.</summary> 
    public KeyPair PrimaryPrivate { get; set; }

    /// <summary>
    /// Create a credential
    /// </summary>
    /// <param name="localName">Local Name</param>
    /// <param name="roles">Assigned roles</param>
    /// <param name="credentialProfile">Profile</param>
    /// <param name="parent">Parent credential, used in CA operations.</param>
    /// <returns>The credential</returns>
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
            Kind = credentialProfile.Platform,
            PrimaryPrivate = clientKey,
            Primary = new KeyData(clientKey),
            Description = $"Code Sign for {credentialProfile.Platform}"
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




