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
using Goedel.Test;
using Goedel.Utilities;

#pragma warning disable IDE0059

namespace Goedel.XUnit;

public partial class ServiceDiscovery {
    public static ServiceDiscovery Test() => new();


    [Fact]
    public void TestServiceAddressParse() {

        TestServiceAddress("10.1.2.3", ParsedAddressType.IPv4, "10.1.2.3");
        TestServiceAddress("10.0.0.0:80", ParsedAddressType.IPv4, "10.0.0.0", port: 80);


        TestServiceAddress("0:1:2:3:4:5:6:7", ParsedAddressType.IPv6, "0:1:2:3:4:5:6:7");
        TestServiceAddress("[0:1:2:3:4:5:6:7]:80", ParsedAddressType.IPv6, "0:1:2:3:4:5:6:7", port: 80);
        TestServiceAddress("[0:1:2:3:4:5:6:7]", ParsedAddressType.IPv6, "0:1:2:3:4:5:6:7");
        TestServiceAddress("[::0]:80", ParsedAddressType.IPv6, "::0", port: 80);


        TestServiceAddress("1:2:3:4:5:6:7", valid: false);
        TestServiceAddress("1:2:3:4:5:6:7:8:9", valid: false);
        TestServiceAddress("1:2:3:4:5:6:7:80000", valid: false);

        // invalid addresses
        TestServiceAddress("", valid: false);
        TestServiceAddress("mm--", valid: false);
        TestServiceAddress(".", valid: false);
        TestServiceAddress(".whatever", valid: false);
        TestServiceAddress("@", valid: false);
        TestServiceAddress("@.", valid: false);
        TestServiceAddress("@0", valid: false);
        TestServiceAddress("@alice.0.0", valid: false);


        // If it has more than two @ signs, it is invalid
        TestServiceAddress("blender@alice@example", valid: false);

        //Singleton callsigns callsigns: If it starts with an @ it is ALWAYS a callsign.

        TestServiceAddress("@alice.0", ParsedAddressType.Callsign, account: "alice", version: 0);
        TestServiceAddress("@alice.mm--", ParsedAddressType.Callsign, account: "alice");
        TestServiceAddress("@alice.0.mm--", ParsedAddressType.Callsign, account: "alice", version: 0);
        TestServiceAddress("alice.0", ParsedAddressType.Callsign, account: "alice", version: 0);
        TestServiceAddress("alice.mm--", ParsedAddressType.Callsign, account: "alice");
        TestServiceAddress("alice.0.mm--", ParsedAddressType.Callsign, account: "alice", version: 0);

        //Doubleton, same
        TestServiceAddress("@toaster.alice", ParsedAddressType.Callsign, account: "toaster.alice");

        // Callsign at specified callsign service
        TestServiceAddress("@alice@example", ParsedAddressType.CallsignCallsign, "example", "alice");

        //// If it has no ., it is ALWAYS a callsign.
        TestServiceAddress("alice", ParsedAddressType.Callsign, account: "alice");
        TestServiceAddress("alice@example", ParsedAddressType.CallsignCallsign, "example", "alice");



        //// If it end in mm--, it is ALWAYS a callsign.
        TestServiceAddress("alice@example.mm--", ParsedAddressType.CallsignCallsign, "example", "alice");
        TestServiceAddress("alice@example.0.mm--", ParsedAddressType.CallsignCallsign, "example", "alice", version: 0);
        //TestServiceAddress("alice@MB3T-WIPZ-JRCW-QZFM-SCQL-OVVO-AHO2.mm--",
        //            ParsedAddressType.CallsignCallsign, "mb3t-wipz-jrcw-qzfm-scql-ovvo-aho2", "alice");




        // valid dns
        TestServiceAddress("fred@example.com", ParsedAddressType.AccountDns, "example.com", "fred");
        TestServiceAddress("example.com", ParsedAddressType.Dns, "example.com");
        //    TestServiceAddress("alice@mb3t-wipz-jrcw-qzfm-scql-ovvo-aho2.mm--",
        //ParsedAddressType.CallsignCallsign, "mb3t-wipz-jrcw-qzfm-scql-ovvo-aho2", "alice");

        TestServiceAddress("blender.fred@example.com", ParsedAddressType.AccountDns, "example.com", "blender.fred");



        TestServiceAddress("@alice.example", ParsedAddressType.Callsign, account: "alice.example");


        }


    bool TestServiceAddress(
        string address,
        ParsedAddressType addressType = ParsedAddressType.Invalid,

        string service = null,
        string account = null,
        int? port = null,
        int? version = null,
        bool valid = true) {

        var result = ServiceAddress.TryParse(address, out var addressValue);
        (valid == result).TestTrue();

        if (!result) {
            return result;
            }


        (addressValue.AddressType == addressType).TestTrue();
        (addressValue.Account?.Address == account).TestTrue();
        (addressValue.Service?.Address == service).TestTrue();

        //(addressValue.ServiceVersion == version).TestTrue();
        //(addressValue.Port == port).TestTrue();
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
