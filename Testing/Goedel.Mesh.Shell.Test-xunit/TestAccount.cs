using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test;
using Goedel.Utilities;

using Xunit;

#pragma warning disable IDE0059

namespace Goedel.XUnit {
    public partial class ShellTests {
        public string AliceAccount1 = "personal";
        public string AliceAccount2 = "business";
        public string AliceService1 = "alice@example.com";
        public string AliceService2 = "alice@example.net";

        [Fact]
        public void TestAccount() {
            var site1 = "example.com"; var username1 = "alice1"; var password1 = "password1";
            var username3 = "alice3"; var password3 = "password3";

            Dispatch($"account create {AliceAccount1}");

            Dispatch($"password add  {site1} {username1} {password1}");


            Dispatch($"account hello {AliceService1}");

            var result1 = Dispatch($"account status");


            Dispatch($"password add {site1} {username3}  {password3}");

            var result = Dispatch($"account sync");


            var result2 = Dispatch($"account status");
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

            var testCLIAlice2 = GetTestCLI(AliceDevice2);
            var ProfileRecover = testCLIAlice2.Example($"account recover {share1} {share2} /verify");

            var recoverSync = testCLIAlice2.Example($"account sync");

            "Should add much more test functionality here".TaskTest();
            }

        [Fact]
        public void TestEscrowDeleteDevice() {
            var testCLIAlice1 = GetTestCLI(AliceDevice1);
            var createAccount = testCLIAlice1.Example($"account create {AliceAccount}");
            var profileUdf = createAccount.GetResultCreateAccount().Account;

            var ProfileEscrow = testCLIAlice1.Example($"account escrow");
            var share1 = (ProfileEscrow[0].Result as ResultEscrow).Shares[0];
            var share2 = (ProfileEscrow[0].Result as ResultEscrow).Shares[2];

            var ProfileAliceDelete = testCLIAlice1.Example($"account delete {profileUdf}");

            var testCLIAlice2 = GetTestCLI(AliceDevice2);
            var ProfileRecover = testCLIAlice2.Example($"account recover {share1} {share2} /verify");

            var recoverSync = testCLIAlice2.Example($"account sync");

            "Should add much more test functionality here".TaskTest();
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
            var profileUdf = account.ProfileAccount.Udf;
            var ProfileAliceDelete = testCLIAlice1.Example($"account delete {profileUdf}");

            // Failing because the device catalog is keypt open.
            testCLIAlice1.Dispatch($"account sync", fail: true);
            }



        [Fact]
        public void TestConnectRequest() {
            var testCLIAlice1 = GetTestCLI(AliceDevice1);
            var testCLIAlice2 = GetTestCLI(AliceDevice2);
            var testCLIMallet1 = GetTestCLI(MalletDevice1);

            var ProfileHello = testCLIAlice1.Example($"account hello {AliceService1}");
            var ResultHello = ProfileHello[0].Result as ResultHello;

            var ProfileCreateAliceAccount = testCLIAlice1.ExampleNoCatch($"account create {AliceService1}");


            // ToDo: need to add a flow for an administration QR code push and implement the QR code document.

            var ConnectRequest = testCLIAlice2.Example($"device request {AliceService1}");
            var ConnectRequestMallet = testCLIMallet1.Example($"device request {AliceService1}");

            var ConnectPending = testCLIAlice1.ExampleNoCatch($"device pending");


            var resultPending = (ConnectPending[0].Result as ResultPending);
            var id1 = resultPending.Messages[1].MessageId;


            var ConnectAccept = testCLIAlice1.Example($"device accept {id1}");


            var id2 = resultPending.Messages[0].MessageId;


            var ConnectReject = testCLIAlice1.Example($"device reject {id2}");


            // Test ability to synchronize

            var AliceDevice2Sync = testCLIAlice2.ExampleNoCatch($"device complete");
            var AliceDevice2Sync2 = testCLIAlice2.ExampleNoCatch($"account sync");
            var MalletDevice2Sync = testCLIMallet1.Example($"device complete");
            MalletDevice2Sync[0].Result.Success.TestFalse();


            }
        }
    }
