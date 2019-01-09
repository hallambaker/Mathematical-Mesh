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
        public void TestProfileSSHPrivate() {
            var accountA = "alice@example.com";

            var device1 = GetTestCLI();
            var device2 = GetTestCLI();
            var device3 = GetTestCLI();

            device1.Dispatch($"profile master /new {accountA}");
            var result1 = device1.Dispatch($"profile pin");
            var pin = "";
            device2.Dispatch($"profile connect {accountA} /pin {pin}");

            device1.Dispatch($"profile ssh create");
            device1.Dispatch($"profile ssh private");
            device1.Dispatch($"profile ssh public");
            device1.Dispatch($"profile ssh show auth");

            device2.Dispatch($"profile ssh private");
            device2.Dispatch($"profile ssh public");
            device2.Dispatch($"profile ssh show auth");

            pin = "";
            device3.Dispatch($"profile connect {accountA} /pin {pin}");

            device3.Dispatch($"profile ssh private");
            device3.Dispatch($"profile ssh public");

            // should all match
            device1.Dispatch($"profile ssh show auth");
            device2.Dispatch($"profile ssh show auth");
            device3.Dispatch($"profile ssh show auth");
            }

        [Fact]
        public void TestProfileSSHPublic() {
            var accountA = "alice@example.com";
            var knownHosts = "known_hosts";

            var device1 = GetTestCLI();
            var device2 = GetTestCLI();
            var device3 = GetTestCLI();

            device1.Dispatch($"profile master /new {accountA}");
            var result1 = device1.Dispatch($"profile pin");
            var pin = "";
            device2.Dispatch($"profile connect {accountA} /pin {pin}");

            device1.Dispatch($"profile ssh add known {knownHosts}");

            device1.Dispatch($"profile ssh show known");
            device2.Dispatch($"profile ssh show known");

            pin = "";
            device3.Dispatch($"profile connect {accountA} /pin {pin}");

            device1.Dispatch($"profile ssh show known");
            device2.Dispatch($"profile ssh show known");
            device3.Dispatch($"profile ssh show known");
            }


        }
    }
