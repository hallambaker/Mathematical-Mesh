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

using Goedel.Anything;
using Goedel.Cryptography.Algorithms;
using Goedel.Discovery;
using Goedel.Test;
using Goedel.Utilities;

using System.Collections.Generic;
using System.Threading.Tasks;

#pragma warning disable IDE0059

namespace Goedel.XUnit;

public partial class ServiceAnything {
    public static ServiceAnything Test() => new();




    /// <summary>
    /// Test transfering data to a DNS secondary
    /// </summary>
    [Fact]
    public void TestDnsTransfer() {
        // Load up the authentication key


        // push data to the secondary


        // Read data back


        }


    [Fact]
    public void TestOnboadDevice() {

        var identity = new CatalogedIdentity() {
            Identities = new List<Identity>() {
                    new DnsIdentity () {
                        Name = "alice.example.com"
                        },
                    new LocalIdentity () {
                        Name ="local"
                        },
                    new CallsignIdentity () {
                        Name = "alice"
                        },
                }
            };


        var tsig = SHAKE256.HashData("Anything TSIG Test Key".ToBytes());
        Console.WriteLine($"TSIG: [{tsig.ToStringBase64()}]");


        var publicDns = new DnsSecondary() {
            Primary = System.Net.IPAddress.Parse("127.0.0.1"),
            TSig = tsig
            };

        var localDns = new DnsSecondary() {
            Primary = System.Net.IPAddress.Parse("192.168.0.21"),
            TSig = tsig
            };

        var service = new AnythingServicePrototype(identity, [localDns], [publicDns]);

        var thing = new CatalogedThing() {
            LocalName = "coffee",
            InternalIp = ["10.0.0.1"],
            ExternalIp = ["192.168.1.1"]
            };

        // Create the private roots
        service.CreatePrivateRoots();

        // Begin registration
        var context = service.RegistrationBegin(thing);
        var complete = thing.Process(context);

        while (!context.Finished) {
            while (!service.RegistrationContinue(context)) {
                Task.Delay(context.TryAfter - DateTime.Now);
                }
            thing.Process(context);
            }

        }


    }
