using Goedel.Mesh.Shell;

using Xunit;

#pragma warning disable IDE0059
namespace Goedel.XUnit {
    public partial class ShellTests {




        [Fact]
        public void TestMessageContact() {
            var accountA = "alice@example.com";
            var accountB = "bob@example.com";

            var deviceA = GetTestCLI("MachineAlice");
            var deviceB = GetTestCLI("MachineBob");

            deviceA.Dispatch($"mesh create /service={accountA}");
            deviceB.Dispatch($"mesh create /service={accountB}");

            var result1 = deviceA.Dispatch("message pending") as ResultPending;

            deviceB.Dispatch($"message contact {accountA}");

            //deviceB.Dispatch($"message status {accountA}");

            var result2 = deviceA.Dispatch("message pending") as ResultPending;

            deviceA.Dispatch("message accept {}");

            //deviceB.Dispatch("message status {accountA}");

            }


        [Fact]
        public void TestMessageConfirmation() {
            var accountA = "alice@example.com";
            var accountB = "bob@example.com";


            var deviceA = GetTestCLI("MachineAlice");
            var deviceB = GetTestCLI("MachineBob");

            deviceA.Dispatch($"mesh create /service={accountA}");
            deviceB.Dispatch($"mesh create /service={accountB}");

            var result1 = deviceA.Dispatch("message pending") as ResultPending;

            deviceB.Dispatch("message confirm {accountA} start");

            //deviceB.Dispatch("message status {accountA}");

            var result2 = deviceA.Dispatch("message pending") as ResultPending;

            deviceA.Dispatch("message accept {}");

            //deviceB.Dispatch("message status {accountA}");

            }




        }
    }
