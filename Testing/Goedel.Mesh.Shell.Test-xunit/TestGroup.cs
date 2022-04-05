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

using Goedel.Mesh.Shell;
using Goedel.Test;

using Xunit;


namespace Goedel.XUnit;

public partial class ShellTests {

    ///<summary>Basic test for group encryption. Creates two user accounts and a
    ///recryption group. A document is encrypted under the group by Alice and the ability
    ///of Bob to decrypt is tested before and after he is added to the group and again
    ///after he is removed.</summary>
    [Fact]
    public void TestMessageGroup() {
        var accountGroup = "groupw@example.com";
        var filename = "Hello world".ToFileUnique();

        CreateAliceBob(out var deviceA, out var deviceB);

        deviceA.Dispatch($"group create {accountGroup}  /web");
        var result1 = deviceA.Dispatch($"dare encode {filename} /encrypt {accountGroup}") as ResultFile;
        //deviceA.Dispatch($"dare decode {result1.Filename}", fail: true);
        //deviceB.Dispatch($"dare decode {result1.Filename}", fail: true);

        deviceA.Dispatch($"group add {accountGroup} {AliceAccount}");
        deviceA.Dispatch($"account sync /auto");
        deviceA.Dispatch($"group add {accountGroup} {AccountB}");
        deviceB.Dispatch($"account sync /auto");

        deviceA.Dispatch($"dare decode {result1.Filename}");
        deviceB.Dispatch($"dare decode {result1.Filename}");

        deviceA.Dispatch($"group delete {accountGroup} {AccountB}");
        deviceA.Dispatch($"dare decode {result1.Filename}");

        // Probably failing because Bob is not actually being deleted from the group
        deviceB.Dispatch($"dare decode {result1.Filename}", fail: true);

        deviceA.Dispatch($"group add {accountGroup} {AccountB}");
        deviceB.Dispatch($"account sync /auto");
        deviceB.Dispatch($"dare decode {result1.Filename}");
        }

    }
