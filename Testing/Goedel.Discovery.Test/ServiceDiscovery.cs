using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UT=Microsoft.VisualStudio.TestTools.UnitTesting;


using Goedel.Discovery;
using Goedel.Utilities;
using Goedel.Test;

namespace Goedel.DNS.Test {

    public partial class ServiceDiscovery {



        [TestMethod]
        public void TestDNS() {
            var Service1 = DNSClient.ResolveService("prismproof.org");

            var Service2 = DNSClient.ResolveService("prismproof.org", "mmm");

            var Service3 = DNSClient.ResolveService("prismproof.org", "www", 80);


            }
        }
    }
