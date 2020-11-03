using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;

namespace ExampleGenerator {




    public class ExampleSet : CreateExamples {
        public CreateExamples CreateExamples;

        public override TestCLI testCLIAlice1 => CreateExamples.testCLIAlice1;
        public override TestCLI testCLIAlice2 => CreateExamples.testCLIAlice2;
        public override TestCLI testCLIAlice3 => CreateExamples.testCLIAlice3;
        public override TestCLI testCLIAlice4 => CreateExamples.testCLIAlice4;
        public override TestCLI testCLIBob1 => CreateExamples.testCLIBob1;
        public override TestCLI testCLIMallet1 => CreateExamples.testCLIMallet1;
        public override TestCLI testCLIConsole1 => CreateExamples.testCLIConsole1;
        public override TestCLI testCLIMaker1 => CreateExamples.testCLIMaker1;


        public string Secret1 {
            get => CreateExamples.Secret1;
            set => CreateExamples.Secret1 = value;
            }

        public ExampleSet(CreateExamples createExamples) {
            CreateExamples = createExamples;

            }
        }

    public partial class CreateExamples {


        public ShellMessage ShellMessage;
        public ShellContact ShellContact;

        public ShellGroup ShellGroup;
        public ShellAccount ShellAccount;

        public ShellCalendar ShellCalendar;
        public ShellNetwork ShellNetwork;
        public ShellMail ShellMail;
        public ShellSSH ShellSSH ;
        public ShellPassword ShellPassword;
        public ShellBookmark ShellBookmark;

        public ShellKey ShellKey;
        public ShellHash ShellHash;
        public ShellDare ShellDare;
        public ShellSequence ShellSequence;


        public void LayerService() {
            DoCommandsService();

            

            //DoCommandsServicedAccount();
            }


        #region // Tests



        public void DoCommandsService() {

            // check connection to service
            ProfileHello = testCLIAlice1.Example($"account hello {AliceService1}");
            ResultHello = ProfileHello[0].Result as ResultHello;

            // Shortcut to existing profile
            AliceProfiles = ProfileCreateAlice[0].Result as ResultCreatePersonal;


            // Create a Bob Account
            ProfileCreateBob = testCLIBob1.Example($"account create {BobService} ");

            // Basic get information tests.
            ProfileList = testCLIAlice1.Example($"mesh list");
            ProfileDump = testCLIAlice1.Example($"mesh get");


            // Import and export test
            ProfileExport = testCLIAlice1.Example($"mesh export {TestExport}");
            ProfileImport = testCLIAlice4.Example($"mesh import {TestExport}"); // do on another device (to be created




            // ToDo: need to add a flow for an administration QR code push and implement the QR code document.

            ShellAccount.ConnectRequest = testCLIAlice2.Example($"device request {AliceService1}");
            ShellAccount.ConnectRequestMallet = testCLIMallet1.Example($"device request {AliceService1}");

            ShellAccount.ConnectPending = testCLIAlice1.ExampleNoCatch($"device pending");


            var resultPending = (ShellAccount.ConnectPending[0].Result as ResultPending);
            var id1 = resultPending.Messages[1].MessageId;


            ShellAccount.ConnectAccept = testCLIAlice1.Example($"device accept {id1}");



            var id2 = resultPending.Messages[0].MessageId;

            ShellAccount.ConnectSync = testCLIAlice2.Example($"device complete");
            testCLIAlice2.Example($"account sync");

            ShellAccount.ConnectReject = testCLIAlice1.Example($"device reject {id2}");

            ShellAccount.ConnectList = testCLIAlice1.Example($"device list");
            ShellAccount.ConnectDelete = testCLIAlice1.Example($"device delete {id1}",
                $"device list");

            // Connect Device 3 using a PIN
            ShellAccount.ConnectGetPin = testCLIAlice1.Example($"account pin");
            var resultPin = (ShellAccount.ConnectGetPin[0].Result as ResultPIN);
            var pin = resultPin.MessagePIN.SaltedPin;
            ShellAccount.ConnectPin = testCLIAlice3.Example($"device request {AliceService1} /pin={pin}");

            // Bug: fails because of spool not having envelope written to it and this causes closed message to crash
            //ConnectPending3 = testCLIAlice1.Example($"device pending");
            //ConnectSyncPIN = testCLIAlice3.Example($"account sync");


            ShellAccount.ConnectEarlPrep = testCLIAlice4.Example("key earl");
            var resultEarl = (ShellAccount.ConnectEarlPrep[0].Result as ResultKey);

            ShellAccount.DeviceCreateUDF = $"udf://{EARLService}/{resultEarl.Key}";

            ShellAccount.DeviceEarl1 = testCLIAlice4.Example($"device pre {PollService} /key={ShellAccount.DeviceCreateUDF}");
            ShellAccount.DeviceEarl2 = testCLIAlice4.Example($"account sync");
            ShellAccount.DeviceEarl3 = testCLIAlice1.Example($"device earl {ShellAccount.DeviceCreateUDF}");
            ShellAccount.DeviceEarl4 = testCLIAlice4.Example($"account sync");

            }





        public void DoCommandsServicedAccount() {

            ShellContact.ContactAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /contact");
            ShellBookmark.BookmarkAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /bookmark");
            ShellPassword.PasswordAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /password");
            ShellCalendar.CalendarAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /calendar ");
            ShellNetwork.NetworkAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /network");


            // These are all failing because the container is being initialized before it is 
            // synchronized on the device.


            // Failing: Because the key collection is not being populated with the activated keys as it should be.

            ShellContact.ContactList2 = testCLIAlice2.Example($"contact list");
            ShellBookmark.BookmarkList2 = testCLIAlice2.Example($"bookmark list");
            ShellPassword.PasswordList2 = testCLIAlice2.Example($"password list");
            ShellCalendar.CalendarList2 = testCLIAlice2.Example($"calendar list");
            ShellNetwork.NetworkList2 = testCLIAlice2.Example($"network list");

            ShellMail.MailAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /mail ");
            ShellMail.MailSMIMEPrivate2 = testCLIAlice2.Example($"mail smime private {AliceService1} {ShellMail.MailSMIMEPrivateKey}");
            }






        #endregion

        }
    }
