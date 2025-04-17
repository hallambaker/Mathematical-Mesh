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



public partial class CatalogedApplicationDeveloper {

    /// <summary>
    /// The primary key used to catalog the entry.
    /// </summary>
    public override string _PrimaryKey => Key;

    /// <summary>
    /// Create a new Developer application instance.
    /// </summary>
    /// <param name="localName">The local name</param>
    /// <param name="roles">The roles to which the application is granted.</param>
    /// <param name="description">Description of the account.</param>
    /// <returns>The application</returns>
    public static List<CatalogedApplication> Create(string localName, List<string> roles, string description = null) {

        // create a root code signing cert
        var rootCertCode = CatalogedApplicationCredential.Create(
                    localName + "_rootcode", roles, CredentialProfile.Code);
        var signingCertCode1 = CatalogedApplicationCredential.Create(
                    localName + "_windows", roles, CredentialProfile.Windows, parent: rootCertCode);
        var signingCertCode2 = CatalogedApplicationCredential.Create(
                    localName + "_apple", roles, CredentialProfile.Apple, parent: rootCertCode);
        var signingCertCode3 = CatalogedApplicationCredential.Create(
                    localName + "_android", roles, CredentialProfile.Android, parent: rootCertCode);
        var signingCertCode4 = CatalogedApplicationCredential.Create(
                    localName + "_linux", roles, CredentialProfile.Linux, parent: rootCertCode);


        var signingCertCommit = CatalogedApplicationCredential.Create(
                    localName + "_commit", roles, CredentialProfile.Commit, parent: rootCertCode);

        // create an SSH client key
        var sslKey = CatalogedApplicationSsh.Create(localName + "_ssh", roles);

        var developer = new CatalogedApplicationDeveloper() {
            Key = Udf.Nonce(),
            LocalName = localName,
            Kind="Developer",
            Grant = roles,
            Ssh = [sslKey._PrimaryKey],
            Commit = [signingCertCommit._PrimaryKey],
            Code = [rootCertCode._PrimaryKey, signingCertCode1._PrimaryKey,
                signingCertCode2._PrimaryKey, signingCertCode3._PrimaryKey,
                signingCertCode4._PrimaryKey],
            Description = description
            };

        List<CatalogedApplication> result = [
            developer, rootCertCode, signingCertCode1, signingCertCode2, signingCertCode3, signingCertCode4,
            signingCertCommit, sslKey
            ];

        return result;
        }



    ///<inheritdoc/>
    public override void Activate(
                    List<ApplicationEntry> activationEntry, 
                    ProfileDevice profileDevice, 
                    IKeyCollection keyCollection) {
        }



    ///<inheritdoc/>
    public override KeyData[] GetEscrow() => Array.Empty<KeyData>();

    ///<inheritdoc/>
    public override ApplicationEntry? GetActivation(CatalogedDevice catalogedDevice) {

        return null;
        //return new ApplicationEntryDeveloper() {
        //    };
        }

    ///<inheritdoc/>
    public override void ToBuilder(StringBuilder output) {

        }
    }
