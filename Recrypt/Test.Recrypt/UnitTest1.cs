using System;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;

using Goedel.Recrypt;
using Goedel.Recrypt.Client;
using Goedel.Recrypt.Server;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT=Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Recrypt {
    [TestClass]
    public class TestServices {
        public static RecryptClient RecryptClient;
        public static RecryptPortalDirect Portal;
        [AssemblyInitialize]

        public static void InitializeClass (TestContext context) {

            string ServiceAddress = "recrypt.example.com";

            Portal = new RecryptPortalDirect();
            RecryptPortal.Default = Portal;
            RecryptClient = new RecryptClient(ServiceAddress);
            }





        [TestMethod]
        public void TestMethod1 () {
            var Response = RecryptClient.Hello();
            UT.Assert.IsNotNull(Response.Version);
            UT.Assert.IsTrue(Response.Version.Minor == 1);
            UT.Assert.IsTrue(Response.Version.Major == 0);
            }
        }
    }
