using Goedel.Discovery;

using Xunit;

#pragma warning disable IDE0059

namespace Goedel.XUnit {

    public partial class ServiceDiscovery {
        public static ServiceDiscovery Test() => new();

        [Fact]
        public void TestDNS() {
            var Service1 = DnsClient.ResolveService("prismproof.org");

            var Service2 = DnsClient.ResolveService("prismproof.org", "mmm");

            var Service3 = DnsClient.ResolveService("prismproof.org", "www", 80);


            }

        [Theory]
        [InlineData(20)]
        public void TestDNSMultiple(int count) {
            for (var i = 0; i < count; i++) {
                TestDNS();
                }
            }
        }
    }
