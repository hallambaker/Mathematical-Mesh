using Goedel.Discovery;

using Xunit;

#pragma warning disable IDE0059

namespace Goedel.XUnit {

    public partial class ServiceDiscovery {
        public static ServiceDiscovery Test() => new ServiceDiscovery();

        [Fact]
        public void TestDNS() {
            var Service1 = DNSClient.ResolveService("prismproof.org");

            var Service2 = DNSClient.ResolveService("prismproof.org", "mmm");

            var Service3 = DNSClient.ResolveService("prismproof.org", "www", 80);


            }
        }
    }
