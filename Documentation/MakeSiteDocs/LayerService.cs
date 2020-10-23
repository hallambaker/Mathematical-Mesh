using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;

using System.Collections.Generic;

namespace ExampleGenerator {


    public partial class CreateExamples {
        public void LayerService() {
            DoCommandsService();
            //DoCommandsServicedAccount();
            }


        #region // Tests

        public List<ExampleResult> ConnectRequest;
        public List<ExampleResult> ConnectRequestMallet;
        public List<ExampleResult> ConnectPending;
        public List<ExampleResult> ConnectAccept;
        public List<ExampleResult> ConnectSync;
        public List<ExampleResult> ConnectPending2;
        public List<ExampleResult> ConnectReject;
        public List<ExampleResult> ConnectGetPin;
        public List<ExampleResult> ConnectPin;
        public List<ExampleResult> ConnectSyncPIN;
        public List<ExampleResult> ConnectPending3;

        public List<ExampleResult> ConnectEarlPrep;

        public List<ExampleResult> ConnectList;
        public List<ExampleResult> ConnectDelete;

        public List<ExampleResult> DeviceEarl1;
        public List<ExampleResult> DeviceEarl2;
        public List<ExampleResult> DeviceEarl3;
        public List<ExampleResult> DeviceEarl4;

        public List<ExampleResult> DeviceCreate;
        public string DeviceCreateUDF;
        public string DeviceCreateHTTP;

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

            ConnectRequest = testCLIAlice2.Example($"device request {AliceService1}");
            ConnectRequestMallet = testCLIMallet1.Example($"device request {AliceService1}");

            ConnectPending = testCLIAlice1.ExampleNoCatch($"device pending");


            var resultPending = (ConnectPending[0].Result as ResultPending);
            var id1 = resultPending.Messages[1].MessageId;


            ConnectAccept = testCLIAlice1.Example($"device accept {id1}");



            var id2 = resultPending.Messages[0].MessageId;

            ConnectSync = testCLIAlice2.Example($"device complete");
            testCLIAlice2.Example($"account sync");

            ConnectReject = testCLIAlice1.Example($"device reject {id2}");

            ConnectList = testCLIAlice1.Example($"device list");
            ConnectDelete = testCLIAlice1.Example($"device delete {id1}",
                $"device list");

            // Connect Device 3 using a PIN
            ConnectGetPin = testCLIAlice1.Example($"account pin");
            var resultPin = (ConnectGetPin[0].Result as ResultPIN);
            var pin = resultPin.MessagePIN.SaltedPin;
            ConnectPin = testCLIAlice3.Example($"device request {AliceService1} /pin={pin}");

            // Bug: fails because of spool not having envelope written to it and this causes closed message to crash
            //ConnectPending3 = testCLIAlice1.Example($"device pending");
            //ConnectSyncPIN = testCLIAlice3.Example($"account sync");


            ConnectEarlPrep = testCLIAlice4.Example("key earl");
            var resultEarl = (ConnectEarlPrep[0].Result as ResultKey);

            DeviceCreateUDF = $"udf://{EARLService}/{resultEarl.Key}";

            DeviceEarl1 = testCLIAlice4.Example($"device pre {PollService} /key={DeviceCreateUDF}");
            DeviceEarl2 = testCLIAlice4.Example($"account sync");
            DeviceEarl3 = testCLIAlice1.Example($"device earl {DeviceCreateUDF}");
            DeviceEarl4 = testCLIAlice4.Example($"account sync");




            }


        public List<ExampleResult> BookmarkList2;
        public List<ExampleResult> ContactList2;
        public List<ExampleResult> PasswordList2;
        public List<ExampleResult> CalendarList2;
        public List<ExampleResult> NetworkList2;
        public List<ExampleResult> MailAuth;
        public List<ExampleResult> MailSMIMEPrivate2;


        public void DoCommandsServicedAccount() {

            ContactAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /contact");
            BookmarkAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /bookmark");
            PasswordAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /password");
            CalendarAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /calendar ");
            NetworkAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /network");


            // These are all failing because the container is being initialized before it is 
            // synchronized on the device.


            // Failing: Because the key collection is not being populated with the activated keys as it should be.

            ContactList2 = testCLIAlice2.Example($"contact list");
            BookmarkList2 = testCLIAlice2.Example($"bookmark list");
            PasswordList2 = testCLIAlice2.Example($"password list");
            CalendarList2 = testCLIAlice2.Example($"calendar list");
            NetworkList2 = testCLIAlice2.Example($"network list");

            MailAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /mail ");
            MailSMIMEPrivate2 = testCLIAlice2.Example($"mail smime private {AliceService1} {MailSMIMEPrivateKey}");
            }


        public List<ExampleResult> GroupCreate;
        public List<ExampleResult> GroupDecryptAlice;
        public List<ExampleResult> GroupAdd;
        public List<ExampleResult> GroupDecryptBob2;
        public List<ExampleResult> GroupList1;
        public List<ExampleResult> GroupDelete;
        public List<ExampleResult> GroupDecryptBob3;
        public List<ExampleResult> GroupList2;

        public void DoCommandsGroup() {
            GroupCreate = testCLIAlice1.Example($"group create {GroupService}");
            GroupEncrypt = testCLIBob1.Example(
                        $"dare encode{TestFile1} /out={TestFile1Group} /encrypt={GroupService}",
                        $"dare decode  {TestFile1Group}");
            GroupDecryptAlice = testCLIAlice1.Example($"dare decode  {TestFile1Group}");
            GroupAdd = testCLIAlice1.Example($"group add {GroupService} {BobService}");
            GroupDecryptBob2 = testCLIAlice1.Example($"dare decode  {TestFile1Group}");
            GroupList1 = testCLIAlice1.Example($"group list {GroupService}");
            GroupDelete = testCLIAlice1.Example($"group delete {GroupService} {BobService}");
            GroupDecryptBob3 = testCLIAlice1.Example($"dare decode  {TestFile1Group}");
            GroupList2 = testCLIAlice1.Example($"group list {GroupService}");

            }

        #endregion

        }
    }
