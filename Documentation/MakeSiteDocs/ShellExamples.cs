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

            ShellSSH = new ShellSSH(this);

            }

        #region // Tests

        public void DoCommandsCreateAcount() => 
            ProfileCreateAlice = testCLIAlice1.Example($"account create {AliceService1}");

        public void DoCommandsContact() {
            ShellContact.ContactAddSelf = testCLIAlice1.Example($"contact self email {AliceService1}");
            ShellContact.ContactAdd = testCLIAlice1.Example($"contact add email {CarolService}");
            ShellContact.ContactGet = testCLIAlice1.Example($"contact get {CarolService}");
            ShellContact.ContactList = testCLIAlice1.Example($"contact list");
            ShellContact.ContactDelete = testCLIAlice1.Example($"contact delete {CarolService}");
            }

        public void DoCommandsPassword() {
            ShellPassword.PasswordAdd = testCLIAlice1.Example(
                $"password add {ShellPassword.PasswordSite} {ShellPassword.PasswordAccount1} {ShellPassword.PasswordValue1}",
                $"password add {ShellPassword.PasswordSite2} {ShellPassword.PasswordAccount2} {ShellPassword.PasswordValue2}");
            ShellPassword.PasswordList = testCLIAlice1.Example($"password list");
            ShellPassword.PasswordUpdate = testCLIAlice1.Example($"password add {ShellPassword.PasswordSite} {ShellPassword.PasswordAccount1} {ShellPassword.PasswordValue1a}");
            ShellPassword.PasswordGet = testCLIAlice1.Example($"password get {ShellPassword.PasswordSite}");
            ShellPassword.PasswordDelete = testCLIAlice1.Example($"password delete {ShellPassword.PasswordSite2}");
            }

        public void DoCommandsBookmark() {
            ShellBookmark.BookmarkAdd = testCLIAlice1.Example($"bookmark add {ShellBookmark.BookmarkPath1} {ShellBookmark.BookmarkURI1} \"{ShellBookmark.BookmarkTitle1}\"",
                $"bookmark add {ShellBookmark.BookmarkPath2} {ShellBookmark.BookmarkURI2} \"{ShellBookmark.BookmarkTitle2}\"",
                $"bookmark add {ShellBookmark.BookmarkPath3} {ShellBookmark.BookmarkURI3} \"{ShellBookmark.BookmarkTitle3}\"");
            ShellBookmark.BookmarkGet = testCLIAlice1.Example($"bookmark get {ShellBookmark.BookmarkPath2}");
            ShellBookmark.BookmarkList = testCLIAlice1.Example($"bookmark list");
            ShellBookmark.BookmarkDelete = testCLIAlice1.Example($"bookmark delete BookmarkPath2");

            }



        public void DoCommandsCalendar() {
            ShellCalendar.CalendarAdd = testCLIAlice1.Example($"calendar add {ShellCalendar.CalendarFile1} {ShellCalendar.CalendarID1}",
                $"calendar add {ShellCalendar.CalendarFile2} {ShellCalendar.CalendarID2}");
            ShellCalendar.CalendarGet = testCLIAlice1.Example($"calendar get {ShellCalendar.CalendarID1}");
            ShellCalendar.CalendarList = testCLIAlice1.Example($"calendar list");

            ShellCalendar.CalendarDelete = testCLIAlice1.Example($"calendar delete {ShellCalendar.CalendarID1}",
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
