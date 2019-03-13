using System;
using System.Collections.Generic;
using Xunit;
using Goedel.Mesh.Shell;
using Goedel.Cryptography;
using Goedel.Mesh;
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
        public void TestProfileEscrow() {
            var account = "alice@example.com";

            Dispatch("profile list");
            // check we have no profiles.

            Dispatch($"profile master {account} /new ");
            //DefaultDevice.AssertAccount(1, account);

            var result = Dispatch("profile escrow test1.escrow /quorum 2 /shares 3") ;
            //Dispatch("profile delete");
            //DefaultDevice.AssertAccount(0, account, false);
            var resultEscrow = result as ResultEscrow;
            var share1 = resultEscrow.Shares[0];
            var share2 = resultEscrow.Shares[1];
            Dispatch($"profile recover  {share1} {share2} /file test1.escrow /verify");

            //DefaultDevice.AssertAccount(1, account);

            // Goal: implement comprehensive key escrow.
            "Check ability to delete account".TaskTest();
            "Check ability to recover deleted account from the service".TaskTest();
            "Implement ability to store escrow records to service".TaskFunctionality();
            "Implement encryption key escrow".TaskFunctionality();
            "Implement encryption key recovery".TaskFunctionality();
            }


        [Fact]
        public void TestProfileConnect() {
            var accountA = "alice@example.com";

            var device1 = GetTestCLI("Device1");
            var device2 = GetTestCLI("Device2");
            var device3 = GetTestCLI("Device3");

            device1.Dispatch($"profile master {accountA} /new ");

            device2.Dispatch($"connect request {accountA} /new");
            device2.Dispatch($"profile sync", fail:true);

            var result2 = device1.Dispatch($"connect pending");
            var message = (result2 as ResultPending).Messages[0] as MessageConnectionRequest;
            var witness = message.Witness;

            device1.Dispatch($"connect accept {witness}");
            device2.Dispatch($"profile sync");

            device3.Dispatch($"connect request {accountA}  /new");
            device3.Dispatch($"profile sync", fail: true);

            var result3 = device1.Dispatch($"connect pending");

            message = (result3 as ResultPending).Messages[0] as MessageConnectionRequest;
            witness = message.Witness;
            device1.Dispatch($"connect reject {witness}");
            device3.Dispatch($"profile sync", fail: true);
            }


        [Fact]
        public void TestProfileConnectPin() {
            var accountA = "alice@example.com";

            var device1 = GetTestCLI("Device1");
            var device2 = GetTestCLI("Device2");
            var device3 = GetTestCLI("Device3");

            device1.Dispatch($"profile master {accountA} /new ");

            device1.Connect(device2, accountA);
            device1.Connect(device3, accountA);
            }
        }
    }
