using System;
using System.Collections.Generic;
using Xunit;
using Goedel.Mesh.Shell;
using Goedel.Cryptography;
using Goedel.Mesh.Test;
using Goedel.Test.Core;
using Goedel.Test;
using Goedel.Utilities;


namespace Goedel.XUnit {
    public partial class ShellTests {


        [Fact]
        public void TestMessageContact() {
            var accountA = "alice@example.com";
            var accountB = "bob@example.com";

            var deviceA = GetTestCLI("MachineAlice");
            var deviceB = GetTestCLI("MachineBob");

            deviceA.Dispatch($"profile master {accountA} /new ");
            deviceB.Dispatch($"profile master {accountB} /new ");

            var result1 = deviceA.Dispatch("message pending") as ResultPending;

            deviceB.Dispatch("message contact {accountA}");

            deviceB.Dispatch("message status {accountA}");

            var result2 = deviceA.Dispatch("message pending") as ResultPending;

            deviceA.Dispatch("message accept {}");

            deviceB.Dispatch("message status {accountA}");

            }


        [Fact]
        public void TestMessageConfirmation() {
            var accountA = "alice@example.com";
            var accountB = "bob@example.com";


            var deviceA = GetTestCLI("MachineAlice");
            var deviceB = GetTestCLI("MachineBob");

            deviceA.Dispatch($"profile master {accountA} /new ");
            deviceB.Dispatch($"profile master {accountB} /new ");

            var result1 = deviceA.Dispatch("message pending") as ResultPending;

            deviceB.Dispatch("message confirm {accountA} start");

            deviceB.Dispatch("message status {accountA}");

            var result2 = deviceA.Dispatch("message pending") as ResultPending;

            deviceA.Dispatch("message accept {}");

            deviceB.Dispatch("message status {accountA}");

            }




        }
    }
