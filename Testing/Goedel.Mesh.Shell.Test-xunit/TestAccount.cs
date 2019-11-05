using Xunit;


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


        }
    }
