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
            var accountGroup = "groupw@example.com";
            var filename = "Hello world".ToFileUnique();

            CreateAliceBob(out var deviceA, out var deviceB);

            deviceA.Dispatch($"group create {accountGroup}");
            var result1 = deviceA.Dispatch($"dare encode {filename} /encrypt {accountGroup}") as ResultFile;
            //deviceA.Dispatch($"dare decode {result1.Filename}", fail: true);
            //deviceB.Dispatch($"dare decode {result1.Filename}", fail: true);

            deviceA.Dispatch($"group add {accountGroup} {AccountA}");
            deviceA.Dispatch($"account sync /auto");
            deviceA.Dispatch($"group add {accountGroup} {AccountB}");
            deviceB.Dispatch($"account sync /auto");

            deviceA.Dispatch($"dare decode {result1.Filename}");
            deviceB.Dispatch($"dare decode {result1.Filename}");

            deviceA.Dispatch($"group delete {accountGroup} {AccountB}");
            deviceA.Dispatch($"dare decode {result1.Filename}");

            // Probably failing because Bob is not actually being deleted from the group
            deviceB.Dispatch($"dare decode {result1.Filename}", fail: true);
            }

        }
    }
