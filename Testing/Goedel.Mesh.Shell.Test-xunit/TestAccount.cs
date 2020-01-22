using Xunit;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Protocol;

using System.Collections.Generic;

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


            Dispatch($"mesh create");

            Dispatch($"account create {AliceAccount1}");

            Dispatch($"password add  {site1} {username1} {password1}");

            // Bug: this password entry is not being added to the catalog at the service when the account is registered
            // Bug: the credential catalog turns up twice


            Dispatch($"account hello {AliceService1}");

            Dispatch($"account register {AliceService1}");

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

        [Fact]
        public void TestEscrow() {

            var testCLIAlice1 = GetTestCLI(AliceDevice1);

            var ProfileCreateAlice = testCLIAlice1.Example($"mesh create");
            var AliceProfiles = ProfileCreateAlice[0].Result as ResultCreatePersonal;

            var ProfileList = testCLIAlice1.Example($"mesh list");
            var ProfileDump = testCLIAlice1.Example($"mesh get");


            // Escrow round trip
            var ProfileEscrow = testCLIAlice1.Example($"mesh escrow");

            var share1 = (ProfileEscrow[0].Result as ResultEscrow).Shares[0];
            var share2 = (ProfileEscrow[0].Result as ResultEscrow).Shares[2];    


            var ProfileAliceDelete = testCLIAlice1.Example($"mesh delete");
            var ProfileRecover = testCLIAlice1.Example($"mesh recover {share1} {share2} /verify");

            }


        }
    }
