using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;

using System.Collections.Generic;

namespace ExampleGenerator {

    public class ExampleSet {
        CreateExamples CreateExamples;

        public TestCLI testCLIAlice1 => CreateExamples.testCLIAlice1;
        public TestCLI testCLIAlice2 => CreateExamples.testCLIAlice2;
        public TestCLI testCLIAlice3 => CreateExamples.testCLIAlice3;
        public TestCLI testCLIAlice4 => CreateExamples.testCLIAlice4;
        public TestCLI testCLIBob1 => CreateExamples.testCLIBob1;
        public TestCLI testCLIMallet1 => CreateExamples.testCLIMallet1;
        public TestCLI testCLIConsole1 => CreateExamples.testCLIConsole1;
        public TestCLI testCLIMaker1 => CreateExamples.testCLIMaker1;

        public string AliceDevice1 => CreateExamples.AliceDevice1;
        public string AliceDevice2 => CreateExamples.AliceDevice2;
        public string AliceDevice3 => CreateExamples.AliceDevice3;
        public string AliceDevice4 => CreateExamples.AliceDevice4;
        public string AliceDevice5 => CreateExamples.AliceDevice5;

        public ExampleSet(CreateExamples createExamples) {
            CreateExamples = createExamples;

            }
        }


    public class ShellAccount {
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

        }

    public class ShellBookmark {
        public List<ExampleResult> BookmarkAdd;
        public List<ExampleResult> BookmarkGet;
        public List<ExampleResult> BookmarkList;
        public List<ExampleResult> BookmarkDelete;
        public List<ExampleResult> BookmarkAuth;

        public List<ExampleResult> BookmarkList2;

        public string BookmarkPath1 = "Folder1/1";
        public string BookmarkURI1 = "http://example.com/";
        public string BookmarkTitle1 = "Example Dot Com";

        public string BookmarkPath2 = "Folder1/2";
        public string BookmarkURI2 = "http://example.net/Bananas";
        public string BookmarkTitle2 = "Banana Site";

        public string BookmarkPath3 = "Folder1/1a";
        public string BookmarkURI3 = "http://example.com/Fred";
        public string BookmarkTitle3 = "The Fred Space";

        }
 
    public class ShellPassword {
        public List<ExampleResult> PasswordAdd;
        public List<ExampleResult> PasswordGet;
        public List<ExampleResult> PasswordUpdate;
        public List<ExampleResult> PasswordList;
        public List<ExampleResult> PasswordDelete;
        public List<ExampleResult> PasswordAuth;
        public List<ExampleResult> PasswordSequence => CreateExamples.Concat(PasswordAdd, PasswordList, PasswordUpdate, PasswordGet);


        public string PasswordAccount1 = "alice1";
        public string PasswordValue1 = "password";
        public string PasswordValue1a = "newpassword";
        public string PasswordSite = "ftp.example.com";
        public string PasswordAccount2 = "alice@example.com";
        public string PasswordValue2 = "newpassword";
        public string PasswordSite2 = "www.example.com";


        public List<ExampleResult> PasswordList2;
        }

    public class ShellContact {
        public List<ExampleResult> ContactRequest;
        public List<ExampleResult> ContactPending;
        public List<ExampleResult> ContactAccept;
        public List<ExampleResult> ContactCatalog;
        public List<ExampleResult> ContactGetResponse;
        public List<ExampleResult> ContactReject;
        public List<ExampleResult> ContactBlock;

        public List<ExampleResult> ContactList2;

        public List<ExampleResult> ContactAdd;
        public List<ExampleResult> ContactAddSelf;
        public List<ExampleResult> ContactGet;
        public List<ExampleResult> ContactList;

        public List<ExampleResult> ContactDelete;
        public List<ExampleResult> ContactAuth;
        }

    public class ShellConfirm {
        public string BobPurchase = "Purchase equipment for $6,000?";

        public List<ExampleResult> ConfirmRequest;
        public List<ExampleResult> ConfirmPending;
        public List<ExampleResult> ConfirmAccept;
        public List<ExampleResult> ConfirmGetAccept;
        public List<ExampleResult> ConfirmReject;
        public List<ExampleResult> ConfirmGetReject;
        public List<ExampleResult> ConfirmMallet;
        }

    public class ShellCalendar {
        public List<ExampleResult> CalendarList2;

        public List<ExampleResult> CalendarAdd;
        public List<ExampleResult> CalendarGet;
        public List<ExampleResult> CalendarList;
        public List<ExampleResult> CalendarDelete;
        public List<ExampleResult> CalendarAuth;


        public string CalendarFile1 = "CalendarEntry1.json";
        public string CalendarFile2 = "CalendarEntry2.json";
        public string CalendarID1 = "CalID1";
        public string CalendarID2 = "CalID2";
        }

    public class ShellNetwork {
        public List<ExampleResult> NetworkList2;
        }

    public class ShellMail {
        public List<ExampleResult> MailAuth;
        public List<ExampleResult> MailSMIMEPrivate2;
        }

    public class ShellSSH : ExampleSet {
        public List<ExampleResult> SSHCreate;
        public List<ExampleResult> SSHPrivate;
        public List<ExampleResult> SSHPublic;
        public List<ExampleResult> SSHMergeClients;
        public List<ExampleResult> SSHMergeHosts;
        public List<ExampleResult> SSHAddClient;
        public List<ExampleResult> SSHShowClient;
        public List<ExampleResult> SSHAddHost;
        public List<ExampleResult> SSHShowKnown;
        public List<ExampleResult> SSHAuthDev;
        public List<ExampleResult> SSHAuthProof;

        public string SSHFilePublic = "ssh-key.public";
        public string SSHFilePrivate = "ssh-key.public";
        public string SSHFileKnownHosts = "ssh-key.public";
        public string SSHFileAuthKeys = "ssh-key.public";


        public ShellSSH(CreateExamples createExamples) :
            base(createExamples) {
                SSHCreate = testCLIAlice1.Example($"ssh create");
                SSHPrivate = testCLIAlice1.Example($"ssh private {SSHFilePrivate}");
                SSHPublic = testCLIAlice1.Example($"ssh public {SSHFilePublic}");
                SSHMergeClients = testCLIAlice1.Example($"ssh merge client");
                SSHMergeHosts = testCLIAlice1.Example($"ssh merge host");
                SSHAddClient = testCLIAlice1.Example($"ssh add client");
                SSHShowClient = testCLIAlice1.Example($"ssh show client");
                SSHAddHost = testCLIAlice1.Example($"ssh add host");
                SSHShowKnown = testCLIAlice1.Example($"ssh show host");

                SSHAuthDev = testCLIAlice1.Example($"device auth {AliceDevice2} /ssh");
                SSHAuthProof = testCLIAlice1.Example($"ssh show host");
                }

            }

    public class ShellGroup {
        public List<ExampleResult> GroupCreate;
        public List<ExampleResult> GroupDecryptAlice;
        public List<ExampleResult> GroupAdd;
        public List<ExampleResult> GroupDecryptBob2;
        public List<ExampleResult> GroupList1;
        public List<ExampleResult> GroupDelete;
        public List<ExampleResult> GroupDecryptBob3;
        public List<ExampleResult> GroupList2;
        public List<ExampleResult> GroupEncrypt;
        }

    public partial class CreateExamples {

        
        public ShellConfirm ShellConfirm = new ShellConfirm();
        public ShellGroup ShellGroup = new ShellGroup();
        public ShellAccount ShellAccount = new ShellAccount();
        public ShellContact ShellContact = new ShellContact();
        public ShellCalendar ShellCalendar = new ShellCalendar();
        public ShellNetwork ShellNetwork = new ShellNetwork();
        public ShellMail ShellMail = new ShellMail();
        public ShellSSH ShellSSH ;
        public ShellPassword ShellPassword = new ShellPassword();
        public ShellBookmark ShellBookmark = new ShellBookmark();

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

            //ContactAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /contact");
            //BookmarkAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /bookmark");
            //PasswordAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /password");
            //CalendarAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /calendar ");
            //NetworkAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /network");


            // These are all failing because the container is being initialized before it is 
            // synchronized on the device.


            // Failing: Because the key collection is not being populated with the activated keys as it should be.

            ShellContact.ContactList2 = testCLIAlice2.Example($"contact list");
            ShellBookmark.BookmarkList2 = testCLIAlice2.Example($"bookmark list");
            ShellPassword.PasswordList2 = testCLIAlice2.Example($"password list");
            ShellCalendar.CalendarList2 = testCLIAlice2.Example($"calendar list");
            ShellNetwork.NetworkList2 = testCLIAlice2.Example($"network list");

            ShellMail.MailAuth = testCLIAlice1.Example($"device auth {AliceDevice2} /mail ");
            ShellMail.MailSMIMEPrivate2 = testCLIAlice2.Example($"mail smime private {AliceService1} {MailSMIMEPrivateKey}");
            }




        public void DoCommandsGroup() {
            ShellGroup.GroupCreate = testCLIAlice1.Example($"group create {GroupService}");
            ShellGroup.GroupEncrypt = testCLIBob1.Example(
                        $"dare encode{TestFile1} /out={TestFile1Group} /encrypt={GroupService}",
                        $"dare decode  {TestFile1Group}");
            ShellGroup.GroupDecryptAlice = testCLIAlice1.Example($"dare decode  {TestFile1Group}");
            ShellGroup.GroupAdd = testCLIAlice1.Example($"group add {GroupService} {BobService}");
            ShellGroup.GroupDecryptBob2 = testCLIAlice1.Example($"dare decode  {TestFile1Group}");
            ShellGroup.GroupList1 = testCLIAlice1.Example($"group list {GroupService}");
            ShellGroup.GroupDelete = testCLIAlice1.Example($"group delete {GroupService} {BobService}");
            ShellGroup.GroupDecryptBob3 = testCLIAlice1.Example($"dare decode  {TestFile1Group}");
            ShellGroup.GroupList2 = testCLIAlice1.Example($"group list {GroupService}");

            }

        #endregion

        }
    }
