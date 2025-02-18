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

using Goedel.Contacts;
using Goedel.Cryptography;
using Goedel.Discovery;
using Goedel.Protocol;
using Goedel.Test;
using Goedel.Utilities;

using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

#pragma warning disable IDE0059

namespace Goedel.XUnit;



public partial class Jmap {
    public static Jmap Test() => new();
    [Fact]
    public void TestContactAlice() {
        //JsonReader.Trace = true;

        var contact = new JsContact() {
            Version = "1.0",
            Type = "card",
            Created = DateTime.Now,
            Updated = DateTime.Now,

            Kind = "individual",
            Language = "en",
            SpeakToAs = new() {
                grammaticalGender = "feminine",
                Pronouns = new() {
                    { "p1", new() {
                        Values = "she/her"
                            }
                        }
                    },
                },
            Titles = new() {
                {
                    "t1", new() {
                        Kind = "title",
                        Name = "Research Scientist"
                        }
                    }
                },
            Emails = new() {
                {
                    "e1", new() {
                        Contexts = new () {
                            { "work", true }
                            },
                        Address = "jqpublic@xyz.example.com"
                        }
                    }
                }
            };

        Verify(contact);
        }



    bool Verify (JsContact contact) {

        var asBytes = contact.GetJson(false);
        var asString = asBytes.ToUTF8();
        Console.WriteLine(asString);

        var parsed = JsContact.FromJson(new JsonReader (asString), false);
        var parsedAsString = parsed.GetJson(false).ToUTF8();

        Console.WriteLine(parsedAsString);
        (asString == parsedAsString).TestTrue();


        var earl = Udf.AuthenticatedEncryptionKey(asBytes);
        Console.WriteLine($"Earl: udf://example.com/{earl}");

        var locator = Udf.Locator(earl);
        Console.WriteLine($"URL: https://example.com/.well-known/mmm-udf/{locator}");

        var key = Udf.GetEncryptionKey(earl);

        Console.WriteLine($"Key: {key.ToStringBase16FormatHex()}");
        //Console.WriteLine($"IV: {iv.ToStringBase16FormatHex()}");


        var encryptedContact = Udf.GetEncryptedData(asBytes, earl);

        var decryptedContact = Udf.GetDecryptedData(encryptedContact, earl);
        Console.WriteLine(decryptedContact.ToUTF8());

        asBytes.TestEqual(decryptedContact);

        // corrupt the contact data
        encryptedContact[0] ^= 0x01;
        Xunit.Assert.Throws<AuthenticationTagMismatchException>(() => Udf.GetDecryptedData(encryptedContact, earl));


        asBytes[0] ^= 0x01;
        encryptedContact = Udf.GetEncryptedData(asBytes, earl);

        Xunit.Assert.Throws<EarlContentInvalid>(() => Udf.GetDecryptedData(encryptedContact, earl));




        return true;
        }


    
    }

public partial class ServiceDiscovery {
    public static ServiceDiscovery Test() => new();

    [Fact]
    public void TestResoveServices() {


        TestResolveService("@alice.example.net", [
            new HandleServiceAtprotocol () { 
                Did = "did:plc:k647x4n6h3jm347u3t5cm6ki"
                },
            new HandleServiceOauth (){
                Did = "did:plc:k647x4n6h3jm347u3t5cm6ki",
                ServiceUri ="https://example.com"
                },
            new HandleServiceMesh (){
                Dsa = "maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah@@example.com"
                },
            new HandleServiceHttp (){
                Domain ="alice.example.net"
                }
            ]);

        TestResolveService("@bob.example.net",[
            new HandleServiceOauth (){
                Did = "did:mmm:mbqn-a3es-zbye-xp3o-w6et-pqug-go5v",
                ServiceUri ="https://example.com"
                },
            new HandleServiceMesh (){
                Dsa = "mbqn-a3es-zbye-xp3o-w6et-pqug-go5v@@example.com"
                },
            new HandleServiceHttp (){
                Domain ="bob.example.net"
                }
            ]);

        TestResolveService("@carol.example.net",[
            new HandleServiceMesh (){
                Dsa = "mbqn-a3es-zbye-xp3o-w6et-pqug-go5v@@example.com"
                },
            new HandleServiceHttp (){
                Domain ="carol.example.net"
                }
            ]);

        TestResolveService("@doug.example.net",[
            new HandleServiceAtprotocol () {
                Did = "did:plc:k647x4n6h3jm347u3t5cm6ki"
                },
            ]);

        TestResolveService("@edward.example.net", [
            new HandleServiceOauth (){
                Did = "did:plc:k647x4n6h3jm347u3t5cm6ki",
                ServiceUri ="https://example.com"
                }
            ]);
        }


    bool TestResolveService(
            string handle,
            HandleService[] servicesTest
            ) {


        var parsed = new ParsedHandle(handle);
        var services = parsed.GetServices().Sync();
        (services.Services.Count == servicesTest.Length).TestTrue();

        for (var i = 0; i< services.Services.Count; i++) {
            Check(services.Services[i], servicesTest[i]);
            }


        return true;
        }

    bool Check(HandleService t1, HandleService t2) => t1 switch {
        HandleServiceHttp t1n => Check (t1n, t2),
        HandleServiceOauth t1n => Check(t1n, t2),
        HandleServiceAtprotocol t1n => Check(t1n, t2),
        HandleServiceMesh t1n => Check(t1n, t2),
        _ => throw new NYI()    
        };

    bool Check(HandleServiceMesh t1, HandleService t2in) {
        var t2 = t2in as HandleServiceMesh;
        t2in.TestNotNull();
        (t1.Dsa == t2.Dsa).TestTrue();
        return true;
        }

    bool Check(HandleServiceOauth t1, HandleService t2in) {
        var t2 = t2in as HandleServiceOauth;
        t2in.TestNotNull();
        (t1.Did == t2.Did).TestTrue();
        (t1.ServiceUri == t2.ServiceUri).TestTrue();
        return true;
        }

    bool Check(HandleServiceAtprotocol t1, HandleService t2in) {
        var t2 = t2in as HandleServiceAtprotocol;
        t2in.TestNotNull();
        (t1.Did == t2.Did).TestTrue();
        (t1.ServiceUri == t2.ServiceUri).TestTrue();
        return true;
        }

    bool Check(HandleServiceHttp t1, HandleService t2in) {
        var t2 = t2in as HandleServiceHttp;
        t2in.TestNotNull();
        (t1.Domain == t2.Domain).TestTrue();

        return true;
        }

    [Fact]
    public void TestResoveHandles() {
        // Service
        TestResolve("alice@example.com", "alice@example.com");

        TestResolve("maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah@@example.com",
            "maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah@@example.com");
        TestResolve("maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah@alice@example.com",
            "maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah@@example.com");





        // DNS handle
        TestResolve("@alice.example.net",
            "maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah@@example.com");

        TestResolve("@maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah@alice.example.net",
            "maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah@@example.com");




        }

    bool TestResolve(
                string handle,
                string address) {

        var result = ParsedHandle.Resolve(handle);

        result.TestIsEqual(address);


        return true;
        }



    [Fact]
    public void TestHandles() {

        TestHandle("maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah", 
            HandleType.Fingerprint, 
            fingerprint: "maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah");
        TestHandle("alice@example.com", 
            HandleType.AccountServiceAddress, 
            name: "alice", 
            service: "example.com");
        TestHandle("maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah@@example.com", 
            HandleType.DirectServiceAddress, 
            fingerprint: "maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah",
            service: "example.com");
        TestHandle("maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah@alice@example.com", 
            HandleType.DirectAccountServiceAddress, 
            fingerprint: "maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah",
            name: "alice",
            service: "example.com");
        TestHandle("@alice.example.net", 
            HandleType.DnsHandle, 
            name: "alice.example.net");
        TestHandle("@maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah@alice.example.net",
            HandleType.DirectDnsHandle,
            fingerprint: "maua-f6qe-ejui-gbwr-c4bh-4x5o-tlah",
            name: "alice.example.net");
        TestHandle("@alice", 
            HandleType.LocalName, 
            name: "alice");
        }

    bool TestHandle(
                string handle,
                HandleType type,
                string fingerprint=null,
                string name=null,
                string service=null) {

        var parsed = new ParsedHandle(handle);

        parsed.HandleType.TestEqual(type);
        parsed.Fingerprint.TestIsEqual(fingerprint);
        parsed.Name.TestIsEqual(name);
        parsed.Service.TestIsEqual(service);

        return true;
        }





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
