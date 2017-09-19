using System;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Protocol.Framework;
using Goedel.Confirm;
using Goedel.Confirm.Client;
using Goedel.Confirm.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT=Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Confirm {
    [TestClass]
    public class TestServices {
        public static ConfirmClient ConfirmClient;
        public static ConfirmPortalDirect Portal;
        [AssemblyInitialize]

        public static void InitializeClass (TestContext context) {

            string ServiceAddress = "recrypt.example.com";

            Portal = new ConfirmPortalDirect();
            ConfirmPortal.Default = Portal;
            ConfirmClient = new ConfirmClient(ServiceAddress);
            }





        [TestMethod]
        public void TestMethod1 () {
            var Response = ConfirmClient.Hello();
            UT.Assert.IsNotNull(Response.Version);
            UT.Assert.IsTrue(Response.Version.Minor == 1);
            UT.Assert.IsTrue(Response.Version.Major == 0);
            }
        }
    }
