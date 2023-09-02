#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion

using Goedel.Discovery;
using Goedel.Utilities;
using Goedel.Test;

using Xunit;

#pragma warning disable IDE0059

namespace Goedel.XUnit;

public partial class ServiceDiscovery {
    public static ServiceDiscovery Test() => new();


    [Fact]
    public void TestServiceAddressParse() {
        TestServiceAddress("10.1.2.3", ServiceAddressType.DNS, "10.1.2.3");
        TestServiceAddress("10.0.0.0:80", ServiceAddressType.IPv4, "10.0.0.0", port:80);


        TestServiceAddress("0:1:2:3:4:5:6:7", ServiceAddressType.IPv6, "0:1:2:3:4:5:6:7");
        TestServiceAddress("[0:1:2:3:4:5:6:7]:80", ServiceAddressType.IPv6, "0:1:2:3:4:5:6:7", port: 80);
        TestServiceAddress("[0:1:2:3:4:5:6:7]", ServiceAddressType.IPv6, "0:1:2:3:4:5:6:7");
        TestServiceAddress("[::0]:80", ServiceAddressType.IPv6, "::0", port: 80);


        TestServiceAddress("1:2:3:4:5:6:7", valid: false);
        TestServiceAddress("1:2:3:4:5:6:7:8:9", valid: false);
        TestServiceAddress("1:2:3:4:5:6:7:80000", valid: false);

        // invalid addresses
        TestServiceAddress("", valid:false);
        TestServiceAddress("mm--", valid: false);
        TestServiceAddress(".", valid: false);
        TestServiceAddress(".whatever", valid: false);
        TestServiceAddress("@", valid: false);
        TestServiceAddress("@.", valid: false);
        TestServiceAddress("@0", valid: false);
        TestServiceAddress("@alice.0.0", valid: false);

        // valid callsigns: If it starts with an @ it is ALWAYS a callsign.
        TestServiceAddress("@example", ServiceAddressType.Callsign, "example");
        TestServiceAddress("@example.0", ServiceAddressType.Callsign, "example", version: 0);
        TestServiceAddress("@example.mm--", ServiceAddressType.Callsign, "example");
        TestServiceAddress("@example.0.mm--", ServiceAddressType.Callsign, "example", version: 0);

        TestServiceAddress("@alice@example", ServiceAddressType.Callsign, "example", "alice");

        TestServiceAddress("@alice.example", ServiceAddressType.Callsign, "example", "alice");
        TestServiceAddress("@blender@alice@example", ServiceAddressType.Callsign, "example", "blender.alice");
        TestServiceAddress("@blender@alice.example", ServiceAddressType.Callsign, "example", "blender.alice");
        TestServiceAddress("@blender.alice.example", ServiceAddressType.Callsign, "example", "blender.alice");

        // If it has multiple @ symbols, it is ALWAYS a callsign.
        TestServiceAddress("blender@alice@example", ServiceAddressType.Callsign, "example", "blender.alice");

        // If it has no ., it is ALWAYS a callsign.
        TestServiceAddress("example", ServiceAddressType.Callsign, "example");
        TestServiceAddress("alice@example", ServiceAddressType.Callsign, "example", "alice");

        // If it end in mm--, it is ALWAYS a callsign.
        TestServiceAddress("alice@example.mm--", ServiceAddressType.Callsign, "example", "alice");
        TestServiceAddress("alice@example.0.mm--", ServiceAddressType.Callsign, "example", "alice", version: 0);
        TestServiceAddress("alice@MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2.mm--", 
                    ServiceAddressType.Callsign, "mb3t-wipz-jrcw-qzfm-scql-ovvo-aho2", "alice");
        TestServiceAddress("alice@mb3t-wipz-jrcw-qzfm-scql-ovvo-aho2.mm--",
                    ServiceAddressType.Callsign, "mb3t-wipz-jrcw-qzfm-scql-ovvo-aho2", "alice");


        // valid dns
        TestServiceAddress("example.com", ServiceAddressType.DNS, "example.com");
        TestServiceAddress("fred@example.com", ServiceAddressType.DNS, "example.com", "fred");
        TestServiceAddress("blender.fred@example.com", ServiceAddressType.DNS, "example.com", "blender.fred");


        // valid IPv4



        //// valid IPv6
        //TestServiceAddress("10.0.0.0", ServiceAddressType.IPv4);
        //TestServiceAddress("0:1:2:3:4:5:6:7", ServiceAddressType.IPv6);

        //TestServiceAddress("10.0.0.0:80", ServiceAddressType.IPv4, port:80);
        //TestServiceAddress("[0:1:2:3:4:5:6:7]:80", ServiceAddressType.IPv6, port: 80);
        }


    bool TestServiceAddress(
        string address,
        ServiceAddressType serviceAddressType = ServiceAddressType.Invalid,
        string service = null,
        string account = null,
        int? port = null,
        int? version = null,
        bool valid = true) {
        
        var result = ServiceAddress.TryParse (address, out var addressValue);
        (valid == result).TestTrue();

        if (!result) {
            return result;
            }

        (addressValue.Service == service).TestTrue();
        (addressValue.Account == account).TestTrue();
        (addressValue.Version == version).TestTrue();
        (addressValue.Port == port).TestTrue();
        return result;
        
        
        }




    [Fact]
    public void TestDNS() {

        var service = "example.com"; //"prismproof.org")

        var Service1 = DnsClient.ResolveServiceAsync(service).Sync();

        var Service2 = DnsClient.ResolveServiceAsync(service, "mmm").Sync();

        var Service3 = DnsClient.ResolveServiceAsync(service, "www", 80).Sync();


        }

    [Theory]
    [InlineData(20)]
    public void TestDNSMultiple(int count) {
        for (var i = 0; i < count; i++) {
            TestDNS();
            }
        }
    }
