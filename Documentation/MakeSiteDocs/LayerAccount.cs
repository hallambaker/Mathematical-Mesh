using Goedel.Mesh.Test;

using System.Collections.Generic;

namespace ExampleGenerator {


    public partial class CreateExamples {

        public void LayerAccount() {
            DoCommandsCreateAcount();
            DoCommandsContact();
            DoCommandsBookmark();
            DoCommandsCalendar();
            DoCommandsNetwork();
            DoCommandsPassword();
            DoCommandsMail();
            DoCommandsSSH();

            }

        #region // Tests

        public void DoCommandsCreateAcount() => ProfileCreateAlice = testCLIAlice1.Example($"account create {AliceService1}");

        public List<ExampleResult> ContactAdd;
        public List<ExampleResult> ContactAddSelf;
        public List<ExampleResult> ContactGet;
        public List<ExampleResult> ContactList;

        public List<ExampleResult> ContactDelete;
        public List<ExampleResult> ContactAuth;

        public void DoCommandsContact() {
            ContactAddSelf = testCLIAlice1.Example($"contact self email {AliceService1}");
            ContactAdd = testCLIAlice1.Example($"contact add email {CarolService}");
            ContactGet = testCLIAlice1.Example($"contact get {CarolService}");
            ContactList = testCLIAlice1.Example($"contact list");
            ContactDelete = testCLIAlice1.Example($"contact delete {CarolService}");

            }

        public List<ExampleResult> PasswordAdd;
        public List<ExampleResult> PasswordGet;
        public List<ExampleResult> PasswordUpdate;
        public List<ExampleResult> PasswordList;
        public List<ExampleResult> PasswordDelete;
        public List<ExampleResult> PasswordAuth;
        public List<ExampleResult> PasswordSequence => Concat(PasswordAdd, PasswordList, PasswordUpdate, PasswordGet);

        public string PasswordAccount1 = "alice1";
        public string PasswordValue1 = "password";
        public string PasswordValue1a = "newpassword";
        public string PasswordSite = "ftp.example.com";
        public string PasswordAccount2 = "alice@example.com";
        public string PasswordValue2 = "newpassword";
        public string PasswordSite2 = "www.example.com";

        public void DoCommandsPassword() {
            PasswordAdd = testCLIAlice1.Example($"password add {PasswordSite} {PasswordAccount1} {PasswordValue1}",
                $"password add {PasswordSite2} {PasswordAccount2} {PasswordValue2}");
            PasswordList = testCLIAlice1.Example($"password list");
            PasswordUpdate = testCLIAlice1.Example($"password add {PasswordSite} {PasswordAccount1} {PasswordValue1a}");
            PasswordGet = testCLIAlice1.Example($"password get {PasswordSite}");
            PasswordDelete = testCLIAlice1.Example($"password delete {PasswordSite2}");

            }

        public List<ExampleResult> BookmarkAdd;
        public List<ExampleResult> BookmarkGet;
        public List<ExampleResult> BookmarkList;
        public List<ExampleResult> BookmarkDelete;
        public List<ExampleResult> BookmarkAuth;


        public string BookmarkPath1 = "Folder1/1";
        public string BookmarkURI1 = "http://example.com/";
        public string BookmarkTitle1 = "Example Dot Com";

        public string BookmarkPath2 = "Folder1/2";
        public string BookmarkURI2 = "http://example.net/Bananas";
        public string BookmarkTitle2 = "Banana Site";

        public string BookmarkPath3 = "Folder1/1a";
        public string BookmarkURI3 = "http://example.com/Fred";
        public string BookmarkTitle3 = "The Fred Space";

        public void DoCommandsBookmark() {
            BookmarkAdd = testCLIAlice1.Example($"bookmark add {BookmarkPath1} {BookmarkURI1} \"{BookmarkTitle1}\"",
                $"bookmark add {BookmarkPath2} {BookmarkURI2} \"{BookmarkTitle2}\"",
                $"bookmark add {BookmarkPath3} {BookmarkURI3} \"{BookmarkTitle3}\"");
            BookmarkGet = testCLIAlice1.Example($"bookmark get {BookmarkPath2}");
            BookmarkList = testCLIAlice1.Example($"bookmark list");
            BookmarkDelete = testCLIAlice1.Example($"bookmark delete BookmarkPath2");

            }

        public List<ExampleResult> CalendarAdd;
        public List<ExampleResult> CalendarGet;
        public List<ExampleResult> CalendarList;
        public List<ExampleResult> CalendarDelete;
        public List<ExampleResult> CalendarAuth;


        public string CalendarFile1 = "CalendarEntry1.json";
        public string CalendarFile2 = "CalendarEntry2.json";
        public string CalendarID1 = "CalID1";
        public string CalendarID2 = "CalID2";

        public void DoCommandsCalendar() {
            CalendarAdd = testCLIAlice1.Example($"calendar add {CalendarFile1} {CalendarID1}",
                $"calendar add {CalendarFile2} {CalendarID2}");
            CalendarGet = testCLIAlice1.Example($"calendar get {CalendarID1}");
            CalendarList = testCLIAlice1.Example($"calendar list");

            CalendarDelete = testCLIAlice1.Example($"calendar delete {CalendarID1}",
                $"calendar list");

            }

        public List<ExampleResult> NetworkAdd;
        public List<ExampleResult> NetworkGet;
        public List<ExampleResult> NetworkList;

        public List<ExampleResult> NetworkDelete;
        public List<ExampleResult> NetworkAuth;

        public string NetworkFile1 = "NetworkEntry1.json";
        public string NetworkFile2 = "NetworkEntry2.json";
        public string NetworkID1 = "NetID1";
        public string NetworkID2 = "NetID2";

        public void DoCommandsNetwork() {
            NetworkAdd = testCLIAlice1.Example($"network add {NetworkFile1} {NetworkID1}",
                $"network add {NetworkFile2} {NetworkID2}");
            NetworkGet = testCLIAlice1.Example($"network get {NetworkID2}");
            NetworkList = testCLIAlice1.Example($"network list");

            NetworkDelete = testCLIAlice1.Example($"network delete {NetworkID2}",
                $"network list");

            }

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

        public void DoCommandsSSH() {
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

        public List<ExampleResult> MailAdd;
        public List<ExampleResult> MailAddExplicit;
        public List<ExampleResult> MailUpdate;

        public List<ExampleResult> MailUpdateOpenPGP;
        public List<ExampleResult> MailOpenPGPPrivate;
        public List<ExampleResult> MailOpenPGPPublic;

        public List<ExampleResult> MailUpdateSMIME;
        public List<ExampleResult> MailSMIMECA;
        public List<ExampleResult> MailSMIMEPrivate;
        public List<ExampleResult> MailSMIMEPublic;

        public string SMIMECA = "ca.example.net";
        public string MailPGPPublicKey = "pgp.public";
        public string MailPGPPrivateKey = "pgp.private";
        public string MailSMIMEPublicKey = "smime.public";
        public string MailSMIMEPrivateKey = "smime.private";

        public void DoCommandsMail() {
            MailAdd = testCLIAlice1.Example($"mail add {AliceService1}");
            MailAddExplicit = testCLIAlice1.Example($"mail add {AliceService2} /inbound={AliceAccount2Inbound} /outbound={AliceAccount2Outbound}");
            MailUpdate = testCLIAlice1.Example($"mail update {AliceService2}");

            MailUpdateOpenPGP = testCLIAlice1.Example($"mail update  {AliceService1} /openpgp");
            MailOpenPGPPrivate = testCLIAlice1.Example($"mail openpgp private {AliceService1} {MailPGPPrivateKey}");
            MailOpenPGPPublic = testCLIAlice1.Example($"mail openpgp public {AliceService1} {MailPGPPublicKey}");

            MailUpdateSMIME = testCLIAlice1.Example($"mail {AliceService1} /smime");
            MailSMIMECA = testCLIAlice1.Example($"mail {AliceService1} /ca={SMIMECA}");
            MailSMIMEPrivate = testCLIAlice1.Example($"mail smime private {AliceService1} {MailSMIMEPrivateKey}");
            MailSMIMEPublic = testCLIAlice1.Example($"mail smime public {AliceService1} {MailSMIMEPublicKey}");


            }

        #endregion
        }
    }
