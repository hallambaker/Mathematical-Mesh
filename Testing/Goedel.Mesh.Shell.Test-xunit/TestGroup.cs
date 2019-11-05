using Goedel.Mesh.Shell;
using Goedel.Test;

using Xunit;


namespace Goedel.XUnit {
    public partial class ShellTests {

        ///<summary>Basic test for group encryption. Creates two user accounts and a
        ///recryption group. A document is encrypted under the group by Alice and the ability
        ///of Bob to decrypt is tested before and after he is added to the group and again
        ///after he is removed.</summary>
        [Fact]
        public void TestMessageGroup() {
            var accountA = "alice@example.com";
            var accountB = "bob@example.com";
            var accountGroup = "groupw@example.com";

            var deviceA = GetTestCLI();
            var deviceB = GetTestCLI();

            var filename = "Hello world".ToFileUnique();


            deviceA.CreateAccount(accountA);
            deviceB.CreateAccount(accountB);

            deviceA.Dispatch($"group create {accountGroup}");
            var result1 = Dispatch($"dare encode {filename} /encrypt {accountGroup}") as ResultFile;
            deviceA.Dispatch($"dare decode {result1.Filename}");
            deviceB.Dispatch($"dare decode {result1.Filename}", fail: true);

            deviceA.Dispatch($"group add {accountGroup} {accountB}");
            deviceA.Dispatch($"dare decode {result1.Filename}");
            deviceB.Dispatch($"dare decode {result1.Filename}");

            deviceA.Dispatch($"group delete {accountGroup} {accountB}");
            deviceA.Dispatch($"dare decode {result1.Filename}");
            deviceB.Dispatch($"dare decode {result1.Filename}", fail: true);
            }

        }
    }
