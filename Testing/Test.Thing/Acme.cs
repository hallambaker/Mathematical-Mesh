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

using Goedel.Acme;

using System.Net;
using System.Threading.Tasks;
using Certes.Acme;
using Certes;
using System;
using System.Linq;
using Goedel.Thing;
using Org.BouncyCastle.Bcpg;
namespace Goedel.XUnit;

public class Acme {
    public static Acme Test() => new();

    public string AcmeAccountAddress = "admin@hallambaker.com";
    public string DeviceDns = "camera1.cryptomesh.org";

    public string AliceDns = "alice.cryptomesh.org";
    public string AliceHomeDns = "alicehome.cryptomesh.org";
    public string DeviceIp = "192.168.1.21";

    static string Zone => "cryptomesh.org";
    static string MintUri(string zone) => $"udf://{zone}/{Udf.Nonce()}";


    [Fact(Skip = "Need DNS update to automate")]
    public async Task TestJsDevice() {
        //var bytes = "e9fb9e3b8254041333e89333a78beca9a557d1a6cf2b045420087dc9ec15dd1d2abfa588c46972e95e131f65cbde659aa9b2984914d75a5a00".FromBase16();
        //var base64 = bytes.ToStringBase64url();
        //var base32 = bytes.ToStringBase32(format:ConversionFormat.Dash4);


        var device = MakeJsDevice(Zone);
        var address = IPAddress.Parse(DeviceIp);

        // so pretend we retrieved that from a jsdevice uri

        var thingService = new ServiceThingClient();

        var deviceDomain = thingService.GetName(AliceHomeDns, device.NameHint);
        var configTask = await thingService.NewDeviceAsync(
                    DeviceDns, [address], [
                        new(WellKnownService.HTTPS),
                        new(WellKnownService.SSH)]);




        }





    static JsDevice MakeJsDevice(string zone) {

        var imageFront = new DeviceImage() {
            MediaType = "image/png",
            Uri = MintUri(zone),
            View = "front"

            };
        var imageRear = new DeviceImage() {
            MediaType = "image/png",
            Uri = MintUri(zone),
            View = "rear"
            };

        var offered = new List<Service>() {
            new () {
                Name = "https",
                Requires = ["anything"],
                Transports = ["TLS", "QUIC"]
                },
            new () {
                Name = "ssh",
                },
            new () {
                Name = "thing",
                Credentials = [
                    new () {
                        MediaType= "application/jwks",
                        Uri = MintUri(zone)
                        }
                    ]
                }
            };

        var used = new List<Service>() {
            new () {
                Name = "anything",
                Transports = ["TLS", "QUIC"]
                },
            };

        var wifi = new Physical() {
            Name = "IEEE 802.11",
            Profiles = ["b", "a", "g", "n", "ac", "ax"]
            };

        var ethernet = new Physical() {
            Name = "IEEE 802.3",
            Profiles = ["10BASE-T", "100BASE-T", "1000BASE-T",]
            };

        var storage = new List<Storage>() {
            new() {
                Purpose = "Surveillance",
                TypicalUse = 50_000_000
                },
            new () {
                Purpose = "Archive",
                TypicalAnnual = 200_000_000
                }
            };

        var device = new JsDevice() {
            ModelName = "FredCam",
            NameHint = "camera",
            ModelSerial = "Fred001",
            DeviceSerial = "0100021",
            DeviceIdentifier = Udf.Nonce(),
            Manufacturer = "Freddly Manufacturing Co. Ltd.",
            CountryOfOrigin = "UK",
            Manufactured = DateTime.UtcNow,
            OfferedServices = offered,
            UsedServices = used,
            Images = [imageFront, imageRear],
            Physical = [wifi, ethernet]
            };
        var asText = device.GetJson(false).ToUTF8();

        return device;
        }





    [Fact(Skip = "Need DNS update to automate")]
    public async Task TestEnroll5() {

        var thingService = new ServiceThingClient();
        var configTask = await thingService.NewDeviceAsync(
                    DeviceDns,[], [
                        new(WellKnownService.HTTPS), 
                        new(WellKnownService.SSH)]);

        }




    [Fact(Skip = "Need DNS update to automate")]
    public async Task TestEnroll4() {

        var thingService = new ServiceThingClient();
        var configTask = await thingService.NewDeviceHttpsAsync(DeviceDns, DeviceIp);

        }



    [Fact(Skip = "Need DNS update to automate")]
    public async Task TestEnroll3() {

        // Service config here 
        var dnsAccount = new DnsUpdateAccount("cryptomesh.org", IPAddress.Parse("178.62.79.124"), "1234") ;
        dnsAccount.Initialize();
        var account = await AcmeAccount.Create(AcmeAccountAddress, true);

        // Step 1: Get the credentials set up
        var order = await account.PlaceOrder([DeviceDns]);

        foreach (var challengePair in order.DictionaryZoneToChallenge) {
            var challenge = challengePair.Value;

            Console.WriteLine($"{challenge.PrefixedDomain} TXT \"{challenge.Text}\"");
            // here respond to the challenge thang

            dnsAccount.PublishTxt(challenge.PrefixedDomain, challenge.Text);
            }
        var result = await order.TryCompleteOrder("my-cert", "abcd1234");

        // Step 2: Publish the service addresses
        dnsAccount.PublishA(DeviceDns, [IPAddress.Parse("178.62.79.124")]);

        }




    [Fact(Skip = "Need DNS update to automate")]
    public async Task TestEnroll2() {

        var account = await AcmeAccount.Create(AcmeAccountAddress, true);

        var order = await account.PlaceOrder(["*.cryptomesh.org"]);

        foreach (var challengePair in order.DictionaryZoneToChallenge) {
            var challenge = challengePair.Value;

            Console.WriteLine($"{challenge.PrefixedDomain} TXT \"{challenge.Text}\"");
            // here respond to the challenge thang
            }


        var result = await order.TryCompleteOrder("my-cert", "abcd1234");


        // the certificates should be ready at this point.

        }



    [Fact(Skip = "Need DNS update to automate")]
    public async Task TestEnroll() {

        // Creating new ACME account:
        var acme = new AcmeContext(WellKnownServers.LetsEncryptStagingV2);
        var account = await acme.NewAccount("admin@hallambaker.com", true);

        // Save the account key for later use
        var pemKey = acme.AccountKey.ToPem();

        ////Use an existing ACME account:

        //// Load the saved account key
        //var accountKey = KeyFactory.FromPem(pemKey);
        //var acme = new AcmeContext(WellKnownServers.LetsEncryptStagingV2, accountKey);
        //var account = await acme.Account();

        //Place a wildcard certificate order (DNS validation is required for wildcard certificates)
        var order = await acme.NewOrder(new[] { "*.cryptomesh.org" });

        var authzs = await order.Authorizations();
        var authz = authzs.First();
        var dnsChallenge = await authz.Dns();
        var dnsTxt = acme.AccountKey.DnsTxt(dnsChallenge.Token);


        //Add a DNS TXT record to _acme-challenge.your.domain.name with dnsTxt value.

        // Ask the ACME server to validate our domain ownership


        var validation = await dnsChallenge.Validate();


        while (validation.Status == Certes.Acme.Resource.ChallengeStatus.Pending |
                validation.Status == Certes.Acme.Resource.ChallengeStatus.Processing) {

            Console.WriteLine("Tick");
            await Task.Delay(1000);

            validation = await dnsChallenge.Resource();
            }


        //Download the certificate once validation is done
        var privateKey = KeyFactory.NewKey(KeyAlgorithm.ES256);
        var cert = await order.Generate(new CsrInfo {
            CountryName = "CA",
            State = "Ontario",
            Locality = "Toronto",
            Organization = "Certes",
            OrganizationUnit = "Dev",
            CommonName = "*.cryptomesh.org",
            }, privateKey);

        ////Export full chain certification
        //var certPem = cert.ToPem();

        //Export PFX
        var pfxBuilder = cert.ToPfx(privateKey);
        var pfx = pfxBuilder.Build("my-cert", "abcd1234");


        }



    }
