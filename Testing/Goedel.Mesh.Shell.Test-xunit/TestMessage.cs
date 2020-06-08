using Goedel.Mesh;
using Goedel.Mesh.Shell;
using Goedel.Utilities;
using System.Collections.Generic;
using Xunit;

#pragma warning disable IDE0059
namespace Goedel.XUnit {
    public partial class ShellTests {


        [Fact]
        public void TestMessageContactBusinessCard() {

            var deviceA = GetTestCLI("MachineAlice");
            var deviceB = GetTestCLI("DeviceBobName");

            deviceA.Dispatch($"mesh create /service={AccountA}");
            deviceB.Dispatch($"mesh create /service={AccountB}");

            throw new NYI();
            }

        [Fact]
        public void TestMessageContactInPerson() {


            var deviceA = GetTestCLI("MachineAlice");
            var deviceB = GetTestCLI("DeviceBobName");

            deviceA.Dispatch($"mesh create /service={AccountA}");
            deviceB.Dispatch($"mesh create /service={AccountB}");

            throw new NYI();
            }


        [Fact]
        public void TestMessageContactRemote() {


            var deviceA = GetTestCLI("MachineAlice");
            var deviceB = GetTestCLI("DeviceBobName");

            deviceA.Dispatch($"mesh create /service={AccountA}");
            var resulta = deviceA.Dispatch("contact list") as ResultDump;
            ValidContact(resulta.CatalogedEntries[0], AccountA);

            deviceB.Dispatch($"mesh create /service={AccountB}");
            var resultb = deviceB.Dispatch("contact list") as ResultDump;
            ValidContact(resultb.CatalogedEntries[0], AccountB);

            var result1 = deviceA.Dispatch("message pending") as ResultPending;
            // check there are no pending messages.
            (result1.Messages.Count == 0).AssertTrue();


            var result2 = deviceB.Dispatch($"message contact {AccountA}");

            var result3 = deviceA.Dispatch("message pending") as ResultPending;
            // check there is exactly one pending message.
            (result1.Messages.Count == 0).AssertTrue();

            // extract message id
            var messageId = result3.Messages[0].MessageID;

            var result4 = deviceA.Dispatch($"message accept {messageId}");
            var result5 = deviceA.Dispatch("contact list") as ResultDump;
            (result5.CatalogedEntries.Count == 2).AssertTrue();
            ValidContact(result5.CatalogedEntries[0], AccountA,AccountB);


            // check the contact is listed

            var result6 = deviceB.Dispatch($"account sync /auto");
            var result7 = deviceB.Dispatch("contact list") as ResultDump;
            (result7.CatalogedEntries.Count == 2).AssertTrue();
            ValidContact(result5.CatalogedEntries[0], AccountB, AccountA);


            throw new NYI();
            }


        bool ValidContact(CatalogedEntry catalogedEntry , params string[] accountAddress) {
            var contactEntry = catalogedEntry as CatalogedContact;
            var contact = contactEntry.Contact;


            var dictionary = new Dictionary<string, NetworkAddress>();
            foreach (var address in contact.NetworkAddresses) {
                dictionary.Add(address.Address, address);
                // don't need to add safe because we want an error if there is a double entry.
                }

            (dictionary.Count == accountAddress.Length).AssertTrue();
            foreach (var address in accountAddress) {
                dictionary.ContainsKey (address).AssertTrue();
                }

            return true;
            }





        [Fact]
        public void TestMessageContact() {
            var accountA = "alice@example.com";
            var accountB = "bob@example.com";

            var deviceA = GetTestCLI("MachineAlice");
            var deviceB = GetTestCLI("MachineBob");

            deviceA.Dispatch($"mesh create /service={accountA}");
            deviceB.Dispatch($"mesh create /service={accountB}");

            var result1 = deviceA.Dispatch("message pending") as ResultPending;

            deviceB.Dispatch($"message contact {accountA}");

            //deviceB.Dispatch($"message status {accountA}");

            var result2 = deviceA.Dispatch("message pending") as ResultPending;

            deviceA.Dispatch("message accept {}");

            //deviceB.Dispatch("message status {accountA}");


            throw new NYI();
            }


        [Fact]
        public void TestMessageConfirmation() {
            var accountA = "alice@example.com";
            var accountB = "bob@example.com";


            var deviceA = GetTestCLI("MachineAlice");
            var deviceB = GetTestCLI("MachineBob");

            deviceA.Dispatch($"mesh create /service={accountA}");
            deviceB.Dispatch($"mesh create /service={accountB}");

            var result1 = deviceA.Dispatch("message pending") as ResultPending;

            deviceB.Dispatch("message confirm {accountA} start");

            //deviceB.Dispatch("message status {accountA}");

            var result2 = deviceA.Dispatch("message pending") as ResultPending;

            deviceA.Dispatch("message accept {}");

            //deviceB.Dispatch("message status {accountA}");
            throw new NYI();
            }




        }
    }
