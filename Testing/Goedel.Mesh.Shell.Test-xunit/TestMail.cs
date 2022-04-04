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
    public void TestProfileMail() {

        var mailaddress = "alice@example.net";
        var mailinbound1 = "pop://alice@pop3.example.net";
        //var mailinbound2 = "imap://alice@imap.example.net";
        var mailoutbound = "submit://alice@submit.example.net";

        CreateAlice(out var device1, out var device2);

        device1.Dispatch($"mail add {mailaddress} /inbound {mailinbound1} /outbound {mailoutbound} /web /threshold");
        device1.Dispatch($"mail list");
        device1.Dispatch($"mail smime sign {mailaddress} /file=d1_smime_prv.p12 /private");
        device1.Dispatch($"mail smime encrypt {mailaddress} /file=d1_smime_prv.pem /private");
        device1.Dispatch($"mail openpgp sign {mailaddress} /file=d1_pgp_pub.pem");
        device1.Dispatch($"mail openpgp encrypt {mailaddress} /file=d1_pgp_pub.pem");

        device2.Dispatch($"account sync");
        device2.Dispatch($"mail list");
        device2.Dispatch($"mail smime sign {mailaddress} /file=d2_smime_prv.p12 /private");
        device2.Dispatch($"mail smime encrypt {mailaddress} /file=d2_smime_pub.pem");
        device2.Dispatch($"mail openpgp sign {mailaddress} /file=d2_pgp_prv.pem /private");
        device2.Dispatch($"mail openpgp encrypt {mailaddress} /file=d2_pgp_pub.pem");


        EndTest();
        //device1.Dispatch($"mail update {mailaddress} /inbound {mailinbound2} /outbound {mailoutbound}");

        //device2.Dispatch($"account sync");
        //device2.Dispatch($"mail list");
        }



    }
