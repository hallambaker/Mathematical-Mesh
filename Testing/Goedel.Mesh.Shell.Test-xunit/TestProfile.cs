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
        public void TestHello() {

            var testCLI = GetTestCLI();

            var result = testCLI.Dispatch("profile hello");

            }

        [Fact]
        public void TestProfileLifecycle() {
            var account = "alice@example.com";

            Dispatch("profile list");
            // check we have no profiles.

            Dispatch("profile master");
            Dispatch($"profile register {account}");
            DefaultDevice.AssertAccount(1, account);

            Dispatch("profile escrow /quorum 2 /shares 3");
            Dispatch("profile delete");
            DefaultDevice.AssertAccount(0, account, false);

            var resultEscrow = DefaultDevice.Last as ResultEscrow;
            var share1 = resultEscrow.Shares[0];
            var share2 = resultEscrow.Shares[1];
            Dispatch($"profile recover {share1} {share2} /portal {account}");

            DefaultDevice.AssertAccount(1, account);
            }


        [Fact]
        public void TestProfileConnect() {
            var accountA = "alice@example.com";

            var device1 = GetTestCLI("Device1");
            var device2 = GetTestCLI("Device2");
            var device3 = GetTestCLI("Device3");

            device1.Dispatch($"profile master {accountA} /new ");

            device2.Dispatch($"profile connect {accountA} /new");
            device2.Dispatch($"profile sync", fail:true);

            var result2 = device1.Dispatch($"profile pending");
            device1.Dispatch($"profile accept");
            device2.Dispatch($"profile sync");

            device3.Dispatch($"profile connect {accountA}  /new");
            device3.Dispatch($"profile sync", fail: true);

            var result3 = device1.Dispatch($"profile pending");
            device1.Dispatch($"profile reject");
            device3.Dispatch($"profile sync", fail: true);
            }


        [Fact]
        public void TestProfileConnectPin() {
            var accountA = "alice@example.com";

            var device1 = GetTestCLI("Device1");
            var device2 = GetTestCLI("Device2");
            var device3 = GetTestCLI("Device3");

            device1.Dispatch($"profile master {accountA} /new ");
            var result1 = device1.Dispatch($"profile pin");
            var pin1 = "";
            device2.Dispatch($"profile connect {accountA} /pin {pin1}");

            var result2 = device1.Dispatch($"profile pin");
            var pin2 = "";
            device3.Dispatch($"profile connect {accountA} /pin {pin2}");
            }
        }
    }
