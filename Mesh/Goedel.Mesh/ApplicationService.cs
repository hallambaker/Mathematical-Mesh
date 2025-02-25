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


public partial class ApplicationService {
    }

public partial class CatalogedApplicationService {

    public override string _PrimaryKey => Key;


    public static CatalogedApplicationService CreateThing(
                string localName, 
                List<string> roles,
                string zone,
                string service) {


        return new CatalogedApplicationService() {
            Key = Udf.Nonce(),
            LocalName = localName,
            Grant = roles,
            Protocol = "thing",
            Address = zone,
            AdministrationAddress = service
            };
        }

    public static CatalogedApplicationService CreateWeb(
                string localName, 
                List<string> roles,
                string address) {


        return new CatalogedApplicationService() {
            Key = Udf.Nonce(),
            LocalName = localName,
            Grant = roles,
            Protocol = "http",
            Address = address
            };
        }


    public static CatalogedApplicationService CreateMessaging(
                string localName,
                List<string> roles,
                string address,
                string protocol) {


        return new CatalogedApplicationService() {
            Key = Udf.Nonce(),
            LocalName = localName,
            Grant = roles,
            Protocol = protocol,
            Address = address
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