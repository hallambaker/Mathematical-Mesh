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

using System.Net;

namespace Goedel.Mesh;



public partial class CatalogedApplicationService {

    ///<inheritdoc/>
    public override string _PrimaryKey => Key;

    /// <summary>
    /// Create a catalogged service entry for Thing service.
    /// </summary>
    /// <param name="localName">The local name</param>
    /// <param name="roles">The roles to which the application is granted.</param>
    /// <param name="zone">The zone under control</param>
    /// <param name="admin">The service administration address</param>
    /// <param name="description">Description of the account.</param>
    /// <returns>The application</returns>
    public static CatalogedApplicationService CreateThing(
                string localName, 
                List<string> roles,
                string zone,
                string admin,
                string description = null) {


        return new CatalogedApplicationService() {
            Key = Udf.Nonce(),
            LocalName = localName,
            Grant = roles,
            Protocol = "thing",
            Address = zone,
            AdministrationAddress = admin,
            Description = description
            };
        }

    /// <summary>
    /// Create a catalogged service entry for Web service.
    /// </summary>
    /// <param name="localName">The local name</param>
    /// <param name="roles">The roles to which the application is granted.</param>
    /// <param name="address">The Web address</param>
    /// <param name="description">Description of the account.</param>
    /// <returns>The application</returns>
    public static CatalogedApplicationService CreateWeb(
                string localName, 
                List<string> roles,
                string address,
                string description = null) {


        return new CatalogedApplicationService() {
            Key = Udf.Nonce(),
            LocalName = localName,
            Grant = roles,
            Protocol = "http",
            Address = address,
            Description = description
            };
        }

    /// <summary>
    /// Create a catalogged service entry for Messaging service.
    /// </summary>
    /// <param name="localName">The local name</param>
    /// <param name="roles">The roles to which the application is granted.</param>
    /// <param name="address">The Web address</param>
    /// <param name="protocol">The messaging protocol.</param>
    /// <param name="description">Description of the account.</param>
    /// <returns>The application</returns>
    public static CatalogedApplicationService CreateMessaging(
                string localName,
                List<string> roles,
                string address,
                string protocol,
                string description = null) {


        return new CatalogedApplicationService() {
            Key = Udf.Nonce(),
            LocalName = localName,
            Grant = roles,
            Protocol = protocol,
            Address = address,
            Description = description
            };
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