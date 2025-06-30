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

#pragma warning disable IDE0059

namespace Goedel.XUnit;

public partial class ShellTests {









    [Fact (Skip="Push callsignb to backburner")]
    public void TestHandleCallsign() {
        var admin = GetTestCLI(AliceDevice1);
        var webserver = GetTestCLI(AliceDevice2);
        var nas = GetTestCLI(AliceDevice2);


        var c1 = admin.Example($"account create {AliceAccount} /local=alice /handle=@alice.example.net");
        Dispatch($"self anywhere");
        Dispatch($"self anyone");
        Dispatch($"self anything");
        Dispatch($"self publish");

        // Create a new public DNS zone for domain.example
        Dispatch($"dns zone domain.example /group=iot");

        // Create a new Mesh callsign, it is only distinguished by being in a non ICANN domain:
        Dispatch($"dns zone domain.mesh /group=iot /private");

        // create a handle @alice.domain.example and publish the default contact information there
        Dispatch($"dns handle alice.domain.example");

        // Connect the device webserver with local name and give it the DNS name www.domain.example 
        ConnectDevice(admin, webserver, "webserver");
        admin.Example($"device service webserver http /dns=iot");

        // Set the default service for the domain to www
        Dispatch($"dns wildcard iot webserver");

        // The Web server can now pull its TLS credentials
        webserver.Example($"device credential  /public=fullchain.pem /private=privkey.pem");

        ConnectDevice(admin, nas, "nas");
        admin.Example($"device service nas http /dns=iot");
        nas.Example($"device credential  /public=fullchain.pem /private=privkey.pem");
        }


    [Fact]
    public void TestHandleThing() {
        var admin = GetTestCLI(AliceDevice1);
        var webserver = GetTestCLI(AliceDevice2);
        var nas = GetTestCLI(AliceDevice2);

        var c1 = admin.Example($"account create {AliceAccount} /local=alice /handle=@alice.example.net") ;
        Dispatch($"self anywhere");
        Dispatch($"self anyone");
        Dispatch($"self anything");
        Dispatch($"self publish");

        // Create a new DNS zone for domain.example
        Dispatch($"dns zone domain.example /group=iot");

        // create a handle @alice.domain.example and publish the default contact information there
        Dispatch($"dns handle alice.domain.example");

        // Connect the device webserver with local name and give it the DNS name www.domain.example 
        ConnectDevice(admin, webserver, "webserver");
        webserver.Example($"device service webserver http /dns=www.domain.example");

        // Set the default service for the domain to www
        Dispatch($"dns wildcard iot webserver");

        // The Web server can now pull its TLS credentials
        webserver.Example($"device credential webserver /public=fullchain.pem /private=privkey.pem");

        ConnectDevice(admin, nas, "nas");
        nas.Example($"device service nas http /dns=nas.www.domain.example");
        nas.Example($"device credential nas /public=fullchain.pem /private=privkey.pem");

        }

    bool ConnectDevice(TestCLI admin, TestCLI device, string local) {

        var ConnectRequest = device.Example($"device request {AliceAccount}");
        var ConnectPending = admin.ExampleNoCatch($"device pending");

        var resultPending = (ConnectPending[0].Result as ResultPending);
        var id1 = resultPending.Messages[0].MessageId; // Alice device 2

        var ConnectAccept = admin.Example($"device accept {id1} /thing=public local=webserver");
        var AliceDevice2Sync = device.ExampleNoCatch($"device complete");

        // sync everything up
        var AliceDevice2Sync1 = admin.ExampleNoCatch($"account sync");
        var AliceDevice2Sync2 = device.ExampleNoCatch($"account sync");

        return true;
        }

    [Fact]
    public void TestHandleContactAliceBob() {
        var alicehandle = "@alice.example.com";
        var bobhandle = "@bob.example.com";
        var alice = GetTestCLI("MachineAlice");
        var bob = GetTestCLI("DeviceBobName");

        var resulta = MakeAccount(alice, AliceAccount, alicehandle);
        var resultb = MakeAccount(bob, AccountB, bobhandle);

        var i3 = alice.ExampleNoCatch($"contact get {bobhandle}");
        bob.ExampleNoCatch($"contact request {bobhandle}");

        var result4 = ProcessMessage(alice, true, 1);
        var result6 = bob.Example($"account sync /auto");
        }



    [Fact]
    public void TestHandleContactAlice() {

        var c1 = Dispatch($"account create alice@example.com /local=alice /handle=@alice.example.net") as ResultCreateAccount;
        //var c2 = Dispatch($"account create bob@example.com /local=bob /handle=@bob.example.net") as ResultCreateAccount;


        var h1 = Dispatch($"account hello @alice") as ResultHello;
        (h1.ServiceAddress == "example.com").TestTrue();

        var h2 = Dispatch($"account hello alice@example.com") as ResultHello;
        (h2.ServiceAddress == "example.com").TestTrue();

        var i1 = Dispatch($"contact query alice@example.com") as ResultInfo;
        // will fail because there is no public contact record published

        var i2 = Dispatch($"self publish") as ResultInfo;

        var i3 = Dispatch($"contact query alice@example.com") as ResultInfo;
        var i4 = Dispatch($"contact query @alice.example.net") as ResultInfo;
        // check the i1.Contact matches c1


        var ssh1 = Dispatch($"ssh create developer");
        var i5 = Dispatch($"account query @alice.example.net") as ResultInfo;
        var i6 = Dispatch($"account query @alice.example.net /ssh") as ResultInfo;

        var m1 = Dispatch($"mail add alice@example.com");
        var i7 = Dispatch($"account query @alice.example.net") as ResultInfo;

        var d1 = Dispatch($"dev create");
        var i8 = Dispatch($"account info @alice.example.net") as ResultInfo;
        var i9 = Dispatch($"account query @alice.example.net /dev");

        }


    [Fact]
    public void TestAccountHandle() {
        var h1 = Dispatch($"account hello example.com") as ResultHello;
        (h1.ServiceAddress == "example.com").TestTrue();

        var c1 = Dispatch($"account create alice@example.com /local=alice /handle=@alice.example.net") as ResultCreateAccount;
        var h7 = Dispatch($"account hello @alice.example.net") as ResultHello;
        (h7.ServiceAddress == "example.com").TestTrue();

        var h2 = Dispatch($"account hello @alice.example.com") as ResultHello;
        (h2.ServiceAddress == "example.com").TestTrue();

        var h3 = Dispatch($"account hello alice@example.com") as ResultHello;
        (h3.ServiceAddress == "example.com").TestTrue();

        var h4 = Dispatch($"account hello @alice.example.net") as ResultHello;
        (h4.ServiceAddress == "example.com").TestTrue();

        var udf = c1.Account.ToLower();
        var h5 = Dispatch($"account hello {udf}@@example.com") as ResultHello; ;
        (h5.ServiceAddress == "example.com").TestTrue();

        var h6 = Dispatch($"account hello {udf}@alice@example.com") as ResultHello; ;
        (h6.ServiceAddress == "example.com").TestTrue();


        }

    [Fact]
    public void TestAccount() {
        var site1 = "example.com"; var username1 = "alice1"; var password1 = "password1";
        var username3 = "alice3"; var password3 = "password3";


        // This should create the following services:

        // Mesh:  http://+:15099/.well-known/mmm/1-1/
        // Mesh:  http://+:15099/.well-known/wsmp/MeshService/1-1/

        Dispatch($"account create {AliceAccount}");

        Dispatch($"password add  {site1} {username1} {password1}");

        Dispatch($"account hello {ServiceDns}");


        var result1 = Dispatch($"account status");


        Dispatch($"password add {site1} {username3}  {password3}");

        var result = Dispatch($"account sync");


        var result2 = Dispatch($"account status");


        TestEnvironment.Dispose();
        EndTest();
        }

    public string AliceDevice1 = "Alice";
    public string AliceDevice2 = "Alice2";
    public string AliceDevice3 = "Alice3";
    public string AliceDevice4 = "Alice4";
    public string AliceDevice5 = "Alice5";

    public string MalletDevice1 = "Mallet1";

    [Fact]
    public void TestEscrowChangeDevice() {

        var testCLIAlice1 = GetTestCLI(AliceDevice1);

        var ProfileCreateAlice = testCLIAlice1.Example($"account create  {AliceAccount}");


        var AliceProfiles = ProfileCreateAlice[0].Result as ResultCreatePersonal;

        var ProfileList = testCLIAlice1.Example($"account list");
        var ProfileDump = testCLIAlice1.Example($"account get");


        // Escrow round trip
        var ProfileEscrow = testCLIAlice1.Example($"account escrow");

        var share1 = (ProfileEscrow[0].Result as ResultEscrow).Shares[0];
        var share2 = (ProfileEscrow[0].Result as ResultEscrow).Shares[2];


        var ProfileRecover1 = testCLIAlice1.Example($"account recover {share1} {share2} /account={AliceAccount}  /verify");



        var testCLIAlice2 = GetTestCLI(AliceDevice2);
        var ProfileRecover = testCLIAlice2.Example($"~account recover {share1} {share2} /account={AliceAccount}  ");

        var recoverSync = testCLIAlice2.Example($"~account sync");

        "Should add much more test functionality here".TaskTest();

        EndTest();
        }

    [Fact]
    public void TestEscrowDeleteDevice() {
        var testCLIAlice1 = GetTestCLI(AliceDevice1);
        var createAccount = testCLIAlice1.Example($"account create {AliceAccount}");
        var profileUdf = createAccount.GetResultCreateAccount().Account;

        var ProfileEscrow = testCLIAlice1.Example($"account escrow");
        var share1 = (ProfileEscrow[0].Result as ResultEscrow).Shares[0];
        var share2 = (ProfileEscrow[0].Result as ResultEscrow).Shares[2];


        var ProfileRecover1 = testCLIAlice1.Example($"account recover {share1} {share2} /account={AliceAccount}  /verify");

        var ProfileAliceDelete = testCLIAlice1.Example($"account delete {profileUdf}");

        var testCLIAlice2 = GetTestCLI(AliceDevice2);
        var ProfileRecover = testCLIAlice2.Example($"~account recover {share1} {share2} /account={AliceAccount} ");

        var recoverSync = testCLIAlice2.Example($"~account sync");

        "Should add much more test functionality here".TaskTest();

        EndTest();
        }


    //[Fact]
    //public void TestEscrowChangeService() {
    //    var testCLIAlice1 = GetTestCLI(AliceDevice1);
    //    testCLIAlice1.Dispatch($"account create {AccountA}");

    //    var ProfileEscrow = testCLIAlice1.Example($"account escrow");
    //    var share1 = (ProfileEscrow[0].Result as ResultEscrow).Shares[0];
    //    var share2 = (ProfileEscrow[0].Result as ResultEscrow).Shares[2];

    //    var ProfileAliceDelete = testCLIAlice1.Example($"account delete");

    //    var testCLIAlice2 = GetTestCLI(AliceDevice2);
    //    var ProfileRecover = testCLIAlice2.Example($"account recover  {AccountA2} {share1} {share2} /verify");

    //    testCLIAlice2.Dispatch($"account sync");

    //    "Should add much more test functionality here".TaskTest();
    //    }



    [Fact]
    public void TestAccountDelete() {
        var testCLIAlice1 = GetTestCLI(AliceDevice1);
        var account = testCLIAlice1.Dispatch($"account create {AliceAccount}") as ResultCreateAccount;
        var profileUdf = account.ProfileAccount.UdfString;
        var ProfileAliceDelete = testCLIAlice1.ExampleNoCatch($"account delete {profileUdf}");

        // Failing because the device catalog is keypt open.
        testCLIAlice1.Dispatch($"account sync", fail: true);


        EndTest();
        }

    [Fact]
    public void TestPendingMessages() {
        var testCLIAlice1 = GetTestCLI(AliceDevice1);
        var testCLIAlice2 = GetTestCLI(AliceDevice2);


        var ProfileCreateAliceAccount = testCLIAlice1.ExampleNoCatch($"account create {AliceAccount}");
        var ConnectRequest = testCLIAlice2.Example($"device request {AliceAccount}");
        var ConnectPending = testCLIAlice1.ExampleNoCatch($"device pending");

        var resultPending = (ConnectPending[0].Result as ResultPending);
        var id1 = resultPending.Messages[0].MessageId;

        var ConnectAccept = testCLIAlice1.Example($"device accept {id1} /web");

        var ConnectPending2 = testCLIAlice1.ExampleNoCatch($"device pending");
        ((ConnectPending2[0].Result as ResultPending).Messages.Count == 0).TestTrue();

        EndTest();
        }



    [Fact]
    public void TestConnectRequest() {
        var testCLIAlice1 = GetTestCLI(AliceDevice1);
        var testCLIAlice2 = GetTestCLI(AliceDevice2);
        var testCLIMallet1 = GetTestCLI(MalletDevice1);

        var ProfileHello = testCLIAlice1.Example($"account hello {ServiceDns}");
        var ResultHello = ProfileHello[0].Result as ResultHello;

        var ProfileCreateAliceAccount = testCLIAlice1.ExampleNoCatch($"account create {AliceAccount}");

        var ConnectRequest = testCLIAlice2.Example($"device request {AliceAccount}");
        var ConnectRequestMallet = testCLIMallet1.Example($"device request {AliceAccount}");
        var ConnectPending = testCLIAlice1.ExampleNoCatch($"device pending");

        var resultPending = (ConnectPending[0].Result as ResultPending);
        var id1 = resultPending.Messages[1].MessageId; // Alice device 2
        var id2 = resultPending.Messages[0].MessageId; // Mallet (latest)

        var ConnectAccept = testCLIAlice1.Example($"device accept {id1} /web");
        var ConnectReject = testCLIAlice1.Example($"device reject {id2}");

        // Test ability to synchronize
        var AliceDevice2Sync = testCLIAlice2.ExampleNoCatch($"device complete");
        var AliceDevice2Sync2 = testCLIAlice2.ExampleNoCatch($"account sync");
        var MalletDevice2Sync = testCLIMallet1.Example($"!device complete");

        EndTest();
        }
    }
