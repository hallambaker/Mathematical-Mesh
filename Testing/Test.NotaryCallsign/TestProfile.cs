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

using System.Collections.Generic;
using System.Threading;

using Goedel.Mesh;
using Goedel.Mesh.Server;
using Goedel.Mesh.ServiceAdmin;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Protocol.Service;
using Goedel.Test;
using Goedel.Test.Core;

using Xunit;

#pragma warning disable IDE0059
#pragma warning disable IDE0060

namespace Goedel.XUnit;



public partial class RegistrationTests {
    string AliceAccount => $"alice@{ServiceDns}";
    string CarolAccount => $"carol@{ServiceDns}";
    string MalletAccount => $"mallet@{ServiceDns}";

    string AliceCallsign => $"@alice";
    string BobCallsign => $"@bob";


    string Currency => $"BitKitten";


    string AccountB => $"bob@{ServiceDns}";

    string AccountC => $"carol@{ServiceDns}";

    string AccountQ => $"quartermaster@{ServiceDns}";

    static string DeviceQName => "DeviceQ";

    static string DeviceAdminName => "DeviceAdmin";

    static string DeviceConnect1Name => "DeviceConnect1";

    Result MakeAccount(TestCLI device, string account) {
        var result = device.Dispatch($"account create {account}");

        // check there is the correct contact entry for this account.
        ValidContact(device, account);

        // check there are no pending messages.
        var resultmp1 = device.Dispatch("message pending") as ResultPending;
        (resultmp1.Messages.Count == 0).TestTrue();

        return result;
        }

    static Result ProcessMessage(TestCLI device, bool accept, int length) {

        var resultPending = device.Dispatch("message pending") as ResultPending;
        // check there is exactly one pending message.
        (resultPending.Messages.Count == length).TestTrue();

        // extract message id
        var messageId = resultPending.Messages[0].MessageId;

        var response = accept ? "accept" : "reject";
        return device.Dispatch($"message {response} {messageId}");
        }

    bool ValidContact(TestCLI device, params string[] accountAddress) {
        var resultDump = device.Dispatch("contact list") as ResultDump;
        return ValidContact(resultDump.CatalogedEntries, accountAddress);
        }
    static bool ValidContact(List<CatalogedEntry> catalogedEntries, params string[] accountAddress) {
        var dictionary = new Dictionary<string, NetworkAddress>();
        foreach (var catalogedEntry in catalogedEntries) {
            var contactEntry = catalogedEntry as CatalogedContact;
            var contact = contactEntry.Contact;

            foreach (var address in contact.NetworkAddresses) {
                dictionary.Add(address.Address.ToLower(), address);
                // don't need to add safe because we want an error if there is a double entry.
                }
            }

        (dictionary.Count == accountAddress.Length).TestTrue();
        foreach (var address in accountAddress) {
            dictionary.ContainsKey(address.ToLower()).TestTrue();
            //Screen.WriteLine($"Found contact: {address}");
            }

        return true;
        }


    private TestCLI CheckCallsign(TestCLI deviceA) {
        var deviceB = GetTestCLI("DeviceBobName");
        var resultb = MakeAccount(deviceB, AccountB);


        var result2 = deviceB.Dispatch($"contact request {AliceCallsign}");
        var result3 = deviceA.Dispatch("message pending") as ResultPending;

        ValidContact(deviceA, AliceAccount, AliceCallsign, AccountB);
        var result6 = deviceB.Dispatch($"account sync /auto");
        ValidContact(deviceB, AccountB, AliceCallsign);


        return deviceB;
        }

    LogService Logger { get; set; }

    IMeshMachineClient MeshMachineHost => TestEnvironment.HostMachineMesh;
    Configuration ConfigurationCallSign { get; set; }
    PublicMeshService CallSignServiceProvider { get; set; }


    const string CallSignDns = "registry.example.net";
    const string CallSignIP = "127.0.0.1:666";



    public ContextUser GetCallSignService(
                    int charge = 0) {

        TestEnvironment.StartServiceCallSign();

        throw new NYI();
        }

    public TestCLI GetCarnetService() {


        throw new NYI();
        }

    public TestCLI GetPresenceService() {


        throw new NYI();
        }



    public string GetInCurrency(int amount) => $"{amount}${Currency}";


    }
