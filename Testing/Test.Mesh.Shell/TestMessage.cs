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

using Goedel.Mesh;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test;

using Xunit;

#pragma warning disable IDE0059
//#pragma warning disable CA1822

namespace Goedel.XUnit;

public partial class ShellTests {


    [Fact]
    public void TestMessageContactBusinessCardFetch() {

        var deviceA = GetTestCLI("MachineAlice");
        var deviceB = GetTestCLI("DeviceBobName");


        var resulta = MakeAccount(deviceA, AliceAccount);
        var resultb = MakeAccount(deviceB, AccountB);

        // Create a contact with 
        var resultcuri = deviceA.Dispatch($"contact static") as ResultPublish;

        var uri = resultcuri.Uri;

        // fetch the contact, do not reciprocate
        var resultfetch = deviceB.Dispatch($"contact fetch {uri}");
        ValidContact(deviceB, AccountB, AliceAccount);
        ValidContact(deviceA, AliceAccount);

        EndTest();
        }


    [Fact]
    public void TestMessageContactBusinessCardExchange() {
        var deviceA = GetTestCLI("MachineAlice");
        var deviceB = GetTestCLI("DeviceBobName");


        var resulta = MakeAccount(deviceA, AliceAccount);
        var resultb = MakeAccount(deviceB, AccountB);

        // Create a static QR code contact.
        var resultcuri = deviceA.Dispatch($"contact static") as ResultPublish;

        var uri = resultcuri.Uri;

        // fetch the contact, request reciprocation
        var resultfetch = deviceB.Dispatch($"contact exchange {uri}") as ResultEntrySent;
        ValidContact(deviceB, AccountB, AliceAccount);

        // process the contact request. It is not processed automatically because
        // this pin is markes as not automatic

        var result6 = deviceA.Dispatch($"account sync /auto");
        ValidContact(deviceA, AliceAccount);

        var messageId = resultfetch.Message.MessageId;

        // reject the contact request.
        var result7 = ProcessMessage(deviceA, true, messageId);
        ValidContact(deviceA, AliceAccount, AccountB);

        EndTest();
        }


    [Fact]
    public void TestMessageContactBusinessCardReject() {
        var deviceA = GetTestCLI("MachineAlice");
        var deviceB = GetTestCLI("DeviceBobName");


        var resulta = MakeAccount(deviceA, AliceAccount);
        var resultb = MakeAccount(deviceB, AccountB);

        // Create a dynamic QR code contact.
        var resultcuri = deviceA.Dispatch($"contact static") as ResultPublish;

        var uri = resultcuri.Uri;

        // fetch the contact, request reciprocation
        var resultfetch = deviceB.Dispatch($"contact exchange {uri}") as ResultEntrySent;
        ValidContact(deviceB, AccountB, AliceAccount);


        var messageId = resultfetch.Message.MessageId;

        // reject the contact request.
        var result6 = ProcessMessage(deviceA, false, messageId);
        ValidContact(deviceA, AliceAccount);

        // Explicit reject has no effect
        var result7 = deviceA.Dispatch($"account sync /auto");
        ValidContact(deviceA, AliceAccount);

        EndTest();
        }

    [Fact]
    public void TestMessageContactInPerson() {
        var deviceA = GetTestCLI("MachineAlice");
        var deviceB = GetTestCLI("DeviceBobName");

        var resulta = MakeAccount(deviceA, AliceAccount);
        var resultb = MakeAccount(deviceB, AccountB);

        // Create a dynamic QR code contact.
        var resultcuri = deviceA.Dispatch($"contact dynamic") as ResultPublish;

        var uri = resultcuri.Uri;

        // fetch the contact, request reciprocation
        var resultfetch = deviceB.Dispatch($"contact exchange {uri}");
        ValidContact(deviceB, AccountB, AliceAccount);

        // Automatically accept the contact request.
        var result6 = deviceA.Dispatch($"account sync /auto");
        ValidContact(deviceA, AliceAccount, AccountB);

        EndTest();
        }


    [Fact]
    public void TestMessageContactRemote() {


        var deviceA = GetTestCLI("MachineAlice");
        var deviceB = GetTestCLI("DeviceBobName");

        var resulta = MakeAccount(deviceA, AliceAccount);
        var resultb = MakeAccount(deviceB, AccountB);


        var result2 = deviceB.Dispatch($"contact request {AliceAccount}");

        var result3 = deviceA.Dispatch("message pending") as ResultPending;

        // check there is exactly one pending message and accept it
        var result4 = ProcessMessage(deviceA, true, 1);

        ValidContact(deviceA, AliceAccount, AccountB);


        // check the contact is listed
        var result6 = deviceB.Dispatch($"account sync /auto");
        ValidContact(deviceB, AccountB, AliceAccount);



        EndTest();
        }

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

    /// <summary>
    /// Check that <paramref name="device"/> has received the message <paramref name="messageId"/>
    /// and accept or reject it according to the value of <paramref name="accept"/>.
    /// </summary>
    /// <param name="device"></param>
    /// <param name="accept"></param>
    /// <param name="messageId"></param>
    /// <returns>Result of processing</returns>
    Result ProcessMessage(TestCLI device, bool accept, string messageId) {
        var message = GetMessage(device, messageId);
        message.TestNotNull();

        var response = accept ? "accept" : "reject";
        return device.Dispatch($"message {response} {messageId}");
        }


    bool ValidContact(TestCLI device, params string[] accountAddress) {
        var resultDump = device.Dispatch("contact list") as ResultDump;
        return ValidContact(resultDump.CatalogedEntries, accountAddress);
        }


    bool CreateAlice(out TestCLI device1, out TestCLI device2) {
        GetTestCLI("Device1");


        device1 = CreateMasterDevice("Device1A", AliceAccount);
        device2 = GetConnectedCLI(device1, "Device2A", AliceAccount);

        return true;
        }

    TestCLI CreateMasterDevice(string name, string account) {
        var device1 = GetTestCLI(name);
        device1.Dispatch($"account create {account}");

        return device1;
        }


    public TestCLI GetConnectedCLI(TestCLI deviceAdmin, string name, string account) {
        var device = GetTestCLI(name);
        deviceAdmin.Connect(device, account);
        return device;
        }


    bool CreateAliceBob(out TestCLI deviceA, out TestCLI deviceB) {

        deviceA = GetTestCLI("MachineAlice");
        deviceB = GetTestCLI("DeviceBobName");

        var resulta = MakeAccount(deviceA, AliceAccount);
        var resultb = MakeAccount(deviceB, AccountB);

        // Create a dynamic QR code contact.
        var resultcuri = deviceA.Dispatch($"contact dynamic") as ResultPublish;

        var uri = resultcuri.Uri;

        // fetch the contact, request reciprocation
        var resultfetch = deviceB.Dispatch($"contact exchange {uri}");
        ValidContact(deviceB, AccountB, AliceAccount);

        // Automatically accept the contact request.
        var result6 = deviceA.Dispatch($"account sync /auto");
        ValidContact(deviceA, AliceAccount, AccountB);

        return true;
        }


    bool CreateAliceBobMallet(out TestCLI alice, out TestCLI bob, out TestCLI mallet) {
        CreateAliceBob(out alice, out bob);
        mallet = GetTestCLI(MalletAccount);
        return true;
        }

    Message GetResponse(TestCLI deviceA, Message message) => GetMessage(deviceA, message.GetResponseId());

    static Message GetMessage(TestCLI deviceA, string id) {
        var resultPending = deviceA.Dispatch($"message pending") as ResultPending;

        if (resultPending.Messages == null) {
            return null;
            }
        foreach (var message in resultPending.Messages) {
            if (message.MessageId == id) {
                return message;
                }
            }
        return null;
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








    [Fact]
    public void TestMessageConfirmationAccept() {
        CreateAliceBob(out var deviceA, out var deviceB);

        var resultRequest = deviceB.Dispatch($"message confirm {AliceAccount} start") as ResultSent;
        var messageId = resultRequest.Message.MessageId;

        var resultHandle = ProcessMessage(deviceA, true, messageId);

        var resultResponse = GetResponse(deviceB, resultRequest.Message) as ResponseConfirmation;

        resultResponse.Accept.TestTrue();
        }

    [Fact]
    public void TestMessageConfirmationReject() {
        CreateAliceBob(out var deviceA, out var deviceB);

        var resultRequest = deviceB.Dispatch($"message confirm {AliceAccount} start") as ResultSent;
        var messageId = resultRequest.Message.MessageId;

        var resultHandle = ProcessMessage(deviceA, false, messageId);
        var responseId = resultRequest.Message.GetResponseId();
        var resultResponse = GetResponse(deviceB, resultRequest.Message) as ResponseConfirmation;

        resultResponse.Accept.TestFalse();

        }


    }
