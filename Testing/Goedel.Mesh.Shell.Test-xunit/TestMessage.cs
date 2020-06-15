using Goedel.Mesh;
using Goedel.Mesh.Shell;
using Goedel.Utilities;
using System.Collections.Generic;
using Xunit;
using Goedel.Mesh.Test;

#pragma warning disable IDE0059
namespace Goedel.XUnit {
    public partial class ShellTests {


        [Fact]
        public void TestMessageContactBusinessCardFetch() {

            var deviceA = GetTestCLI("MachineAlice");
            var deviceB = GetTestCLI("DeviceBobName");


            var resulta = MakeAccount(deviceA, AccountA);
            var resultb = MakeAccount(deviceB, AccountB);

            // Create a contact with 
            var resultcuri = deviceA.Dispatch($"contact static") as ResultPublish;

            var uri = resultcuri.Uri;

            // fetch the contact, do not reciprocate
            var resultfetch = deviceB.Dispatch($"contact fetch {uri}") ;
            ValidContact(deviceB, AccountB, AccountA);
            ValidContact(deviceA, AccountA);
            }


        [Fact]
        public void TestMessageContactBusinessCardExchange() {
            var deviceA = GetTestCLI("MachineAlice");
            var deviceB = GetTestCLI("DeviceBobName");


            var resulta = MakeAccount(deviceA, AccountA);
            var resultb = MakeAccount(deviceB, AccountB);

            // Create a static QR code contact.
            var resultcuri = deviceA.Dispatch($"contact static") as ResultPublish;

            var uri = resultcuri.Uri;

            // fetch the contact, request reciprocation
            var resultfetch = deviceB.Dispatch($"contact exchange {uri}");
            ValidContact(deviceB, AccountB, AccountA);

            // accept the contact request.

            var result6 = deviceA.Dispatch($"account sync /auto");
            //var result6 = ProcessMessage(deviceA, true, 1, 0);
            ValidContact(deviceA, AccountA, AccountB);
            }


        [Fact]
        public void TestMessageContactBusinessCardReject() {
            var deviceA = GetTestCLI("MachineAlice");
            var deviceB = GetTestCLI("DeviceBobName");


            var resulta = MakeAccount(deviceA, AccountA);
            var resultb = MakeAccount(deviceB, AccountB);

            // Create a dynamic QR code contact.
            var resultcuri = deviceA.Dispatch($"contact static") as ResultPublish;

            var uri = resultcuri.Uri;

            // fetch the contact, request reciprocation
            var resultfetch = deviceB.Dispatch($"contact exchange {uri}");
            ValidContact(deviceB, AccountB, AccountA);

            // reject the contact request.
            var result6 = ProcessMessage(deviceA, false, 1, 0);
            ValidContact(deviceA, AccountA);
            }

        [Fact]
        public void TestMessageContactInPerson() {
            var deviceA = GetTestCLI("MachineAlice");
            var deviceB = GetTestCLI("DeviceBobName");

            var resulta = MakeAccount(deviceA, AccountA);
            var resultb = MakeAccount(deviceB, AccountB);

            // Create a dynamic QR code contact.
            var resultcuri = deviceA.Dispatch($"contact dynamic") as ResultPublish;

            var uri = resultcuri.Uri;

            // fetch the contact, request reciprocation
            var resultfetch = deviceB.Dispatch($"contact exchange {uri}");
            ValidContact(deviceB, AccountB, AccountA);

            // Automatically accept the contact request.
            var result6 = deviceB.Dispatch($"account sync /auto");
            ValidContact(deviceA, AccountA, AccountB);
            }


        [Fact]
        public void TestMessageContactRemote() {


            var deviceA = GetTestCLI("MachineAlice");
            var deviceB = GetTestCLI("DeviceBobName");

            var resulta = MakeAccount(deviceA, AccountA);
            var resultb = MakeAccount(deviceB, AccountB);


            var result2 = deviceB.Dispatch($"message contact {AccountA}");

            var result3 = deviceA.Dispatch("message pending") as ResultPending;
            
            // check there is exactly one pending message and accept it
            var result4 = ProcessMessage(deviceA, true, 1, 0);

            ValidContact(deviceA, AccountA,AccountB);

            // check the contact is listed
            var result6 = deviceB.Dispatch($"account sync /auto");
            ValidContact(deviceB, AccountB, AccountA);
            }

        Result MakeAccount(TestCLI device, string account) {
            var result = device.Dispatch($"mesh create /service={account}");

            // check there is the correct contact entry for this account.
            ValidContact(device, account);

            // check there are no pending messages.
            var resultmp1 = device.Dispatch("message pending") as ResultPending;
            (resultmp1.Messages.Count == 0).AssertTrue();

            return result;
            }


        Result ProcessMessage(TestCLI device, bool accept, int length, int index) {
            var resultPending = device.Dispatch("message pending") as ResultPending;
            // check there is exactly one pending message.
            (resultPending.Messages.Count == length).AssertTrue();

            // extract message id
            var messageId = resultPending.Messages[0].MessageID;

            var response = accept ? "accept": "reject";
            return device.Dispatch($"message {response} {messageId}");
            }

        bool ValidContact(Mesh.Test.TestCLI device, params string[] accountAddress) {
            var resultDump = device.Dispatch("contact list") as ResultDump;
            return ValidContact(resultDump.CatalogedEntries, accountAddress);
            }


        bool CreateAliceBob(out TestCLI deviceA, out Mesh.Test.TestCLI deviceB) {

            deviceA = GetTestCLI("MachineAlice");
            deviceB = GetTestCLI("DeviceBobName");

            var resulta = MakeAccount(deviceA, AccountA);
            var resultb = MakeAccount(deviceB, AccountB);

            // Create a dynamic QR code contact.
            var resultcuri = deviceA.Dispatch($"contact dynamic") as ResultPublish;

            var uri = resultcuri.Uri;

            // fetch the contact, request reciprocation
            var resultfetch = deviceB.Dispatch($"contact exchange {uri}");
            ValidContact(deviceB, AccountB, AccountA);

            // Automatically accept the contact request.
            var result6 = deviceB.Dispatch($"account sync /auto");
            ValidContact(deviceA, AccountA, AccountB);

            return true;
            }

        Result GetMessage(TestCLI deviceA, string id) {
            throw new NYI();
            }


        bool ValidContact(List<CatalogedEntry> catalogedEntries , params string[] accountAddress) {
            var dictionary = new Dictionary<string, NetworkAddress>();
            foreach (var catalogedEntry in catalogedEntries) {
                var contactEntry = catalogedEntry as CatalogedContact;
                var contact = contactEntry.Contact;

                foreach (var address in contact.NetworkAddresses) {
                    dictionary.Add(address.Address, address);
                    // don't need to add safe because we want an error if there is a double entry.
                    }
                }

            (dictionary.Count == accountAddress.Length).AssertTrue();
            foreach (var address in accountAddress) {
                dictionary.ContainsKey (address).AssertTrue();
                }

            return true;
            }



        [Fact]
        public void TestMessageConfirmationAccept() {
            CreateAliceBob(out var deviceA, out var deviceB);

            var resultRequest = deviceB.Dispatch("message confirm {accountA} start") as ResultConfirm;
            var resultHandle = ProcessMessage(deviceA, true, 2, 1);


            var resultResponse = GetMessage(deviceB, resultRequest.Id) as ResultConfirm;

            "check that the response is Accept".TaskTest();

            //deviceB.Dispatch("message status {accountA}");
            throw new NYI();
            }

        [Fact]
        public void TestMessageConfirmationReject() {
            CreateAliceBob(out var deviceA, out var deviceB);

            var resultRequest = deviceB.Dispatch("message confirm {accountA} start") as ResultConfirm;
            var resultHandle = ProcessMessage(deviceA, false, 2, 1);


            var resultResponse = GetMessage(deviceB, resultRequest.Id) as ResultConfirm;

            "check that the response is REJECT".TaskTest();

            //deviceB.Dispatch("message status {accountA}");
            throw new NYI();
            }


        }
    }
