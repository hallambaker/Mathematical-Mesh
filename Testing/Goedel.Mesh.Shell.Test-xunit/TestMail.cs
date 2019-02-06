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
        public void TestProfileMail() {
            var accountA = "alice@example.com";
            var mailaddress = "alice@example.net";
            var mailinbound1 = "pop://alice@pop3.example.net";
            var mailinbound2 = "imap://alice@imap.example.net";
            var mailoutbound = "submit://alice@submit.example.net";

            var device1 = GetTestCLI();
            var device2= GetTestCLI();

            device1.Dispatch($"profile master {accountA} /new ");
            var result1 = device1.Dispatch($"profile pin");
            var pin = "";
            device2.Dispatch($"profile connect {accountA} /pin {pin}");

            device1.Dispatch($"profile mail add {mailaddress} /inbound {mailinbound1} /outbound {mailoutbound}");
            device1.Dispatch($"profile mail smime private");
            device1.Dispatch($"profile mail smime public");
            device1.Dispatch($"profile mail openpgp private");
            device1.Dispatch($"profile mail openpgp public");

            device2.Dispatch($"profile mail dump");
            device2.Dispatch($"profile mail smime private");
            device2.Dispatch($"profile mail smime public");
            device2.Dispatch($"profile mail openpgp private");
            device2.Dispatch($"profile mail openpgp public");

            device1.Dispatch($"profile mail update {mailaddress} /inbound {mailinbound2} /outbound {mailoutbound}");
            device2.Dispatch($"profile mail dump");
            }



        }
    }
