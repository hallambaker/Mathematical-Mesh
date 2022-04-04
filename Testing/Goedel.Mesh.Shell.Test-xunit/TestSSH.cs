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

using Xunit;

namespace Goedel.XUnit;

public partial class ShellTests {



    [Fact]
    public void TestProfileSSHPrivate() {
        CreateAlice(out var device1, out var device2);

        device1.Dispatch($"ssh create /web /threshold");
        device1.Dispatch($"ssh get /file=d1_ssh_pub.pem");
        device1.Dispatch($"ssh get /private /file=d1_ssh_prv.pem");
        //device1.Dispatch($"ssh show auth");

        device2.Dispatch($"account sync");
        device2.Dispatch($"ssh get /file=d2_ssh_pub.pem");
        device2.Dispatch($"ssh get /private /file=d1_ssh_prv.pem");
        //device2.Dispatch($"ssh show auth");

        var device3 = GetConnectedCLI(device1, "Device3", AliceAccount);

        device3.Dispatch($"ssh get /file=d3_ssh_pub.pem");
        device3.Dispatch($"ssh get /private /file=d1_ssh_prv.pem");



        // should all match
        //device1.Dispatch($"ssh show auth");
        //device2.Dispatch($"ssh show auth");
        //device3.Dispatch($"ssh show auth");

        EndTest();
        }

    //[Fact]
    //public void TestProfileSSHPublic() {
    //    var knownHosts = "known_hosts";

    //    CreateAlice(out var device1, out var device2);

    //    device1.Dispatch($"ssh add known {knownHosts}");

    //    device1.Dispatch($"ssh show known");
    //    device2.Dispatch($"ssh show known");

    //    var device3 = GetConnectedCLI(device1, "Device3", AliceAccount);

    //    device1.Dispatch($"ssh show known");
    //    device2.Dispatch($"ssh show known");
    //    device3.Dispatch($"ssh show known");
    //    }


    }
