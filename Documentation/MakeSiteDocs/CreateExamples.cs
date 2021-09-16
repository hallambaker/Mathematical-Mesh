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
using System.Net.Mail;

using Goedel.IO;
using Goedel.Mesh;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Test;
using Goedel.Utilities;


namespace ExampleGenerator {
    /// <summary>
    /// 
    /// </summary>
    public partial class CreateExamples {


        ///<summary></summary> 
        public string AliceService = "example.com";

        ///<summary></summary> 
        public string AliceFingerprint;

        ///<summary></summary> 
        public ProfileAccount AliceProfileAccount;

        ///<summary></summary> 
        public string TestFile1Text = "This is a test";

        ///<summary></summary> 
        public int CountMissing = 0;

        ///<summary></summary> 
        public int CountObsolete = 0;

        public void ReportMissingExample() {

            ReportMissing();
            _Output.Write("\n{0}", _Indent);
            _Output.Write("~~~~\n{0}", _Indent);
            _Output.Write("Missing example {1}{0}\n", _Indent, CountMissing);
            _Output.Write("~~~~\n{0}", _Indent);
            }
        public void ReportObsoleteExample() {
            CountObsolete++;
            ReportMissing();
            _Output.Write("\n{0}", _Indent);
            _Output.Write("~~~~\n{0}", _Indent);
            _Output.Write("Obsolete example {1}{0}\n", _Indent, CountObsolete);
            _Output.Write("~~~~\n{0}", _Indent);
            }


        public void ReportMissing() {
            CountMissing++;
            Screen.WriteInfo("Missing example!");
            }


        /// <summary>
        /// 
        /// </summary>
        public void PerformAll() {
            // ignore unit test errors.
            Goedel.Test.AssertTest.FlagFailure = false;


            ServiceConnect();
            CreateAliceAccount();
            EncodeDecodeFile();
            PasswordCatalog();
            BookmarkCatalog();
            ContactCatalog();


            NetworkCatalog();
            TaskCatalog();


            ConnectDeviceCompare(out deviceId);

            SSHApp();
            MailApp();
            CreateBobAccount();
            ContactExchange();
            Confirmation();
            GroupOperations();
            ConnectPINDynamicQR();
            ConnectStaticQR();






            }




        public void ServiceConnect() {
            Alice1 = GetTestCLI(AliceDevice1);
            Service.Hello = Alice1.Example(
                $"account hello {AliceAccount}"
                );
            var hello = Service.Hello.GetResultHello();
            }

        public void CreateAliceAccount() {
            // create the alice account.
            Account.CreateAlice = Alice1.Example(
                $"account create {AliceAccount}"
                );
            var aliceCreateAccount = Account.CreateAlice.GetResultCreateAccount();
            AliceProfileAccount = aliceCreateAccount.ProfileAccount;


            // Check the passwords work - enable checks later on.
            Account.PasswordAdd = Alice1.Example(
                $"password add {ShellPassword.PasswordSite} {ShellPassword.PasswordAccount1} {ShellPassword.PasswordValue1}",
                $"password add {ShellPassword.PasswordSite2} {ShellPassword.PasswordAccount2} {ShellPassword.PasswordValue2}"
                );
            Account.PasswordGet = Alice1.Example(
                $"password get {ShellPassword.PasswordSite}"
                );
            }


        public void EncodeDecodeFile() {
            // Encrypt the file
            Account.EncryptSourceFile.WriteFileNew(TestFile1Text);
            var dump = Alice1.DumpFile(Account.EncryptSourceFile);
            var encode = Alice1.Example(
                $"dare encode {Account.EncryptSourceFile} {Account.EncryptTargetFile} /encrypt {AliceAccount} ");
            var verify = Alice1.Example(
                $"dare verify {Account.EncryptTargetFile}"
                );

            var verifyFile = verify.GetResultFileDare();
            (verifyFile.TotalBytes > 0).TestTrue();
            //verifyFile.Envelope.Trailer.TestNotNull();
            verifyFile.Envelope.PayloadDigest.TestNotNull();

            Account.ConsoleEncryptFile = new List<ExampleResult>() {
                dump, encode[0], verify[0]
                };

            // Decrypt the file
            var decode = Alice1.Example(
                $"dare decode {Account.EncryptTargetFile} {Account.EncryptResultFile}"
                );
            var dump2 = Alice1.DumpFile(Account.EncryptResultFile);
            Account.ConsoleDecryptFile = new List<ExampleResult>() {
                decode[0], dump2
                };


            }


        public void PasswordCatalog() {




            // Password catalog
            var resultPassword = Account.PasswordGet.GetResultEntry();
            Apps.CredentialCatalogEntry = resultPassword.CatalogEntry;


            }


        public void BookmarkCatalog() {
            // Bookmark catalog
            string uri1 = "http://www.site1.com", title1 = "site1", path1 = "Sites.1";
            var bookmark = Alice1.Example(
                $"bookmark add {path1} {uri1} {title1}",
                $"bookmark get {path1}"
                );
            var resultBookmark = bookmark.GetResultEntry(1);
            Apps.BookmarkCatalogEntry = resultBookmark.CatalogEntry;
            }


        public void ContactCatalog() {

            // Contact catalog
            //string uri1 = "http://www.site1.com", title1 = "site1", path1 = "Sites.1";
            var contact = Alice1.Example(
                $"contact list "
                );
            var resultContact = contact.GetResultDump();
            Apps.ContactCatalogEntry = resultContact.CatalogedEntries[0];
            }




        public void NetworkCatalog() {
            // Network catalog
            //string uri1 = "http://www.site1.com", title1 = "site1", path1 = "Sites.1";
            var network = Alice1.Example(
                $"network add myWiFi securePassword",
                $"network list"
                );
            var resultNetwork = network.GetResultDump(1);
            Apps.NetworkCatalogEntry = resultNetwork.CatalogedEntries[0];
            }

        public void TaskCatalog() {

            // Task catalog
            //string uri1 = "http://www.site1.com", title1 = "site1", path1 = "Sites.1";
            var task = Alice1.Example(
                $"calendar add SomeItem",
                $"calendar list"
                );
            var resultTask = task.GetResultDump(1);
            Apps.TaskCatalogEntry = resultTask.CatalogedEntries[0];
            }

        public void ConnectDeviceCompare(out string deviceId) {

            Alice2 = GetTestCLI(AliceDevice2);
            // Connect the second device

            Connect.ConnectRequest = Alice2.Example(
                $"device request {AliceAccount}"
                );

            var connectRequest = Connect.ConnectRequest[0].Result as ResultConnect;

            Connect.ResponseIdentifierMessage = connectRequest.RequestConnection;
            Connect.ResponseIdentifierEnvelope = Connect.ResponseIdentifierMessage.DareEnvelope;


            var x = Connect.ResponseIdentifierEnvelope.EnvelopeId;

            Connect.ConnectPending = Alice1.Example(
                $"device pending"
                );

            var resultPending = Connect.ConnectPending.GetResultPending();
            var id1 = resultPending.Messages[0].MessageId;


            "Need to specify WHAT rights are being assigned!".TaskFunctionality();

            Connect.ConnectAccept = Alice1.Example(
                $"device accept {id1} /message /web"
                );
            var resultAccept = Connect.ConnectAccept[0].Result as ResultProcess;
            deviceId = (resultAccept.ProcessResult as ResultAcknowledgeConnection).
                    AcknowledgeConnection.MessageConnectionRequest.ProfileDevice.Udf;

            Connect.ConnectComplete = Alice2.Example(
                $"device complete"
                );

            Connect.ConnectRequest.GetResult().Success.TestTrue();
            Connect.ConnectPending.GetResult().Success.TestTrue();
            Connect.ConnectAccept.GetResult().Success.TestTrue();
            Connect.ConnectComplete.GetResult().Success.TestTrue();

            // This is not syncing correctly. Do not have the credentials in the store(!)
            Account.SyncAlice = Alice2.Example(
                $"account sync"
                );

            // Password catalog access broken on device 2
            // Don't have the account decryption key either.
            Connect.PasswordList2 = Alice2.Example(
                $"password get {ShellPassword.PasswordSite}",
                $"dare decode {Account.EncryptTargetFile} {Connect.EncryptResultFile}"
                );

            Connect.PasswordList2.Add(Alice2.DumpFile(Connect.EncryptResultFile));


            Connect.PasswordList2.GetResult(0).Success.TestTrue();
            Connect.PasswordList2.GetResult(1).Success.TestTrue();
            }

        public void TestConnectDisconnect(string deviceId) {
            Connect.Disconnect = Alice1.Example(
            $"device delete {deviceId}"
            );
            Connect.Disconnect.GetResult().Success.TestTrue();

            Connect.PasswordList2Disconnect = Alice2.Example(
                //$"password get {PasswordSite}",
                $"account sync",
                $"dare decode {Account.EncryptTargetFile} {Connect.EncryptResultFile}"
                );



            Connect.PasswordList2Disconnect.GetResult(1).Success.TestFalse();


            }




        public void SSHApp() {

            // Add an SSH application profile 'SSH'
            Apps.SSH = Alice1.Example(
                "ssh create /web");

            // Dump out the private key in SSH format
            Apps.SSHPrivate = Alice1.Example(
                $"ssh private /file={Apps.SshPrivateKey}");

            // Dump out the public key in SSH format
            Apps.SSHPublic = Alice1.Example(
                $"ssh public /file={Apps.SshPublicKey}");

            Apps.SSHConnect = Alice2.Example(
                    "account sync",
                    $"ssh private /file={Apps.SshPrivateKey2}");
            }

        public void MailApp() {
            // Add an SSH application profile 'SSH'
            Apps.Mail = Alice1.Example(
                $"mail add {Apps.Mailaddress} /inbound {Apps.Mailinbound1} /outbound {Apps.Mailoutbound} /web");

            // Dump out the private key in SSH format
            Apps.MailSmimeSign = Alice1.Example(
                $"ssh smime sign {Apps.Mailaddress}  /file={Apps.MailSmimeFile}");

            // Dump out the public key in SSH format
            Apps.MailOpenpgpSign = Alice1.Example(
                $"sshopenpgp sign {Apps.Mailaddress} /file={Apps.MailOpenpgpFile}");

            Apps.MailConnect = Alice2.Example(
                    "account sync",
                    "mail list");

            }

        public void CreateBobAccount() {
            // Interactions with Bob... create an account
            Bob1 = GetTestCLI("Bob");
            Account.CreateBob = Bob1.Example(
                $"account create {BobAccount}"
                );
            }

        public ResultPending ContactExchange() {
            ResultPending resultPending;
            // Contact requests (Remote)
            Contact.ContactBobRequest = Bob1.Example(
                $"message contact {AliceAccount}"
                 );

            Contact.ContactAliceResponse = Alice1.Example(
                $"account sync",
                $"message pending"
                 );
            resultPending = Contact.ContactAliceResponse.GetResultPending(1);
            var contactMessage = resultPending.Messages[0] as Goedel.Mesh.MessageContact;
            Contact.BobRequest = contactMessage;

            var contactAccept = Alice1.Example(
                $"message accept {contactMessage.MessageId}",
                $"contact list"
                );
            Contact.ContactAliceResponse.Add(contactAccept[0]);
            Contact.ContactAliceResponse.Add(contactAccept[1]);

            Contact.ContactBobFinal = Bob1.Example(
                    $"account sync /auto",
                    $"contact list"
                     );



            // Interactions with Bob... create an account

            Contact.ContactBobRequest.GetResult().Success.TestTrue();
            Contact.ContactAliceResponse.GetResult().Success.TestTrue();
            Contact.ContactAliceResponse.GetResult(1).Success.TestTrue();
            contactAccept.GetResult().Success.TestTrue();

            return resultPending;
            }

        public void Confirmation() {
            Console1 = GetTestCLI("Console");

            Account.CreateConsole = Console1.Example(
                $"account create {ConsoleAccount}"
                );
            // Confirmation
            Confirm.ConfirmRequest = Console1.Example(
                $"message confirm {AliceAccount} start"
                );
            var resultConfirmSent = Confirm.ConfirmRequest.GetResultSent();

            Confirm.ConfirmAliceSync = Alice1.Example(
                $"account sync",
                $"message pending"
                 );
            var messageId = resultConfirmSent.Message.MessageId;
            var confirmResponseID = resultConfirmSent.Message.GetResponseId();

            Confirm.ConfirmAliceResponse = Alice1.Example(
                $"message accept {messageId}"
                );

            var testc = Console1.Example(
                $"account sync",
                $"message pending"
                 );

            Confirm.ConfirmVerify = Console1.Example(
                $"message status {confirmResponseID}"
                 );
            "Verify the confirmation response".TaskFunctionality();

            var resultConfirmVerify = Confirm.ConfirmVerify.GetResultReceived();
            Confirm.RequestConfirmation = resultConfirmSent?.Message as RequestConfirmation;

            // This is not working correctly here.
            Confirm.ResponseConfirmation = resultConfirmVerify?.Message as ResponseConfirmation;


            Confirm.ConfirmRequest.GetResult().Success.TestTrue();
            Confirm.ConfirmAliceResponse.GetResult().Success.TestTrue();
            Confirm.ConfirmVerify.GetResult().Success.TestTrue();
            }

        public void GroupOperations() {

            // Group
            Group.GroupCreate = Alice1.Example(
                $"group create {GroupAccount}"
                 );

            Group.EncryptSourceFile.WriteFileNew(Group.TestText);
            var dump = Alice1.DumpFile(Account.EncryptSourceFile);
            var encode = Alice1.Example(
                $"dare encode {Group.EncryptSourceFile} {Group.EncryptTargetFile} /encrypt {GroupAccount}",
                $"dare decode {Group.EncryptTargetFile} {Group.GroupDecryptAliceFile}"
                );


            Group.GroupEncrypt = new List<ExampleResult>() {
                dump, encode[0], encode[1]
                };

            Group.GroupDecryptAlice = Alice1.Example(
                $"dare decode {Group.EncryptTargetFile}"
                 );

            Group.GroupAddAlice = Alice1.Example(
                $"group add {GroupAccount} {AliceAccount}",
                $"account sync /auto",
                $"dare decode {Group.EncryptTargetFile} {Group.GroupDecryptAliceFile}"
                 );

            Group.GroupAddAlice.Add(Alice1.DumpFile(Group.GroupDecryptAliceFile));
            // dump EncryptTargetFile 

            Group.GroupDecryptAlice = Alice1.Example(
                $"dare decode {Group.EncryptTargetFile}"
                 );
            Group.GroupDecryptBobFail = Bob1.Example(
                $"dare decode {Group.EncryptTargetFile}"
                 );


            Group.GroupAddBob = Alice1.Example(
                $"group add {GroupAccount} {BobAccount}"
                 );

            //#% var result = Group.GroupAddBob [0];
            var addBob = Group.GroupAddBob[0].Traces[1].RequestObject as TransactRequest;
            Group.GroupInvitation = addBob.Outbound[0].JsonObject as GroupInvitation;

            Group.GroupDecryptBobSuccess = Bob1.Example(
                $"account sync  /auto",
                $"dare decode {Group.EncryptTargetFile} {Group.GroupDecryptBobFile}"
                 );
            Group.GroupDecryptBobSuccess.Add(Bob1.DumpFile(Group.GroupDecryptBobFile));
            // dump EncryptTargetFile 

            Group.GroupDeleteBob = Alice1.Example(
                $"group delete {GroupAccount} {BobAccount}"
                 );

            Group.GroupDecryptBobRevoked = Bob1.Example(
                $"dare decode {Group.EncryptTargetFile} {Group.GroupDecryptBobFile2}"
                 );

            Group.GroupDecryptAlice.GetResult().Success.TestTrue();
            Group.GroupDecryptBobFail.GetResult().Success.TestFalse();
            Group.GroupAddBob.GetResult().Success.TestTrue();
            Group.GroupDecryptBobSuccess.GetResult(0).Success.TestTrue();
            Group.GroupDecryptBobSuccess.GetResult(1).Success.TestTrue();
            Group.GroupDeleteBob.GetResult().Success.TestTrue();
            Group.GroupDecryptBobRevoked.GetResult().Success.TestFalse();

            }

        public void ConnectPINDynamicQR() {
            Alice3 = GetTestCLI(AliceDevice3);

            // Connect device using a PIN (which can be presented as a QR code)
            Connect.ConnectPINCreate = Alice1.Example(
                    $"account pin /web"
                    );
            var pinResult = Connect.ConnectPINCreate.GetResultPIN();
            var pin = pinResult.MessagePIN.Pin;
            Connect.ConnectPINMessagePin = pinResult.MessagePIN;
            Connect.ConnectDynamicURI = pinResult.MessagePIN.GetURI();


            Connect.ConnectPINRequest = Alice3.Example(
                $"device request {AliceAccount} /pin {pin}"
                );

            var connectRequest = Connect.ConnectPINRequest.GetResultConnect();
            Connect.ConnectPINRequestConnection = Connect.ConnectPINRequest[0].Traces[0];
            Connect.ConnectPINResponseConnection = Connect.ConnectPINRequest[0].Traces[0];

            // decode the request message using the server encryption key??
            // decode the response message using the device key??

            Connect.ConnectRequestPIN = connectRequest.RequestConnection;

            var responseConnection = Connect.ConnectPINResponseConnection.ResponseObject as ConnectResponse;
            Connect.ConnectPINAcknowledgeConnection = responseConnection.EnvelopedAcknowledgeConnection.Decode();


            Connect.ConnectPINPending = Alice1.Example(
                $"message pending",
                $"account sync /auto"  // Failing because object already created
                );

            // this is probably failing because previous auto complete actions are not being marked closed.

            var connectPendingPIN = Connect.ConnectPINPending.GetResultPending();
            var syncUpdates = Connect.ConnectPINPending[1].Traces[1].RequestObject as TransactRequest;

            Connect.ConnectPINCompleteMessage = syncUpdates.Local[1].JsonObject as MessageComplete; // change here!!!

            Connect.ConnectPINComplete = Alice3.Example(
                $"device complete",
                $"account sync"
                );

            //this is not being assigned correctly

            var connectPINComplete = Connect.ConnectPINComplete.GetResultConnect();
            Connect.RespondConnectionPIN = connectPINComplete.RespondConnection;


            Connect.ConnectPINActivationDevice = null;
            Connect.ConnectPINCatalogedDevice = null;

            Connect.ConnectPINRequestComplete = Connect.ConnectPINComplete[0].Traces[0];
            Connect.ConnectPINRespondComplete = Connect.ConnectPINComplete[0].Traces[0];


            var watchMachine = connectPINComplete.CatalogedMachine;
            Connect.AliceProfileDeviceWatch = watchMachine.ProfileDevice;
            //Connect.AliceActivationDeviceWatch = watchMachine.A;
            }

        public void ConnectStaticQR() {
            Maker1 = GetTestCLI("Maker");
            Alice4 = GetTestCLI(AliceDevice4);

            // Connect the coffee pot using a static QR

            Connect.ConnectMakerCreate = Maker1.Example(
                $"account create {MakerAccount}"
                );
            Connect.ConnectStaticPrepare = Maker1.Example(
                $"device preconfig"
                );
            var resultPublishDevice = Connect.ConnectStaticPrepare.GetResultPublishDevice();

            Connect.ConnectStaticPreconfig = resultPublishDevice.DevicePreconfiguration;

            Connect.ConnectEARL = Connect.ConnectStaticPreconfig.ConnectUri;

            Connect.ConnectStaticInstall = Alice4.Example(
                $"device install {resultPublishDevice.FileName}"
                );
            //Connect.ConnectStaticPollFail = testCLIAlice4.Example(
            //    $"device complete"
            //    );
            Connect.ConnectStaticClaim = Alice1.Example(
                $"account connect {resultPublishDevice.Uri} /web"
                );


            Connect.RequestClaim = Connect.ConnectStaticClaim[0].Traces[0];
            Connect.ResponseClaim = Connect.ConnectStaticClaim[0].Traces[0];

            var requestClaim = Connect.RequestClaim.RequestObject as ClaimRequest;
            Connect.MessageClaim = requestClaim.EnvelopedMessageClaim.Decode();


            Connect.ConnectStaticPollSuccess = Alice4.Example(
                $"device complete"
                );

            Connect.RequestPollClaim = Connect.ConnectStaticPollSuccess[0].Traces[0];
            Connect.ResponsePollClaim = Connect.ConnectStaticPollSuccess[0].Traces[0];


            var connectStaticPollSuccess = Connect.ConnectStaticPollSuccess.GetResultConnect();
            var coffeePotMachine = connectStaticPollSuccess?.CatalogedMachine;
            var coffeePotDevice = coffeePotMachine?.CatalogedDevice;
            Connect.AliceProfileDeviceCoffee = coffeePotMachine.ProfileDevice;
            Connect.AliceActivationDeviceCoffee = connectStaticPollSuccess.ActivationDevice;
            //Connect.AliceActivationAccountCoffee = connectStaticPollSuccess.ActivationAccount;
            //Connect.AliceConnectionDeviceCoffee = coffeePotDevice.ConnectionUser;
            }

        public void EscrowAndRecover() {
            Alice2 = GetTestCLI(AliceDevice2);


            Account.ProfileEscrow = Alice1.Example(
                $"account escrow"
                );
            var resultEscrow = Account.ProfileEscrow.GetResultEscrow();
            var share1 = resultEscrow.Shares[0];
            var share2 = resultEscrow.Shares[2];

            Account.DeleteAlice = Alice1.Example(
                $"account delete {AliceProfileAccount.Udf}"
                );

            //Account.ProfileRecover = Alice2.Example(
            //    $"account recover {share1} {share2} /verify"
            //    );


            //Account.ProfileEscrow.GetResult().Success.TestTrue();
            //Account.DeleteAlice.GetResult().Success.TestTrue();
            //Account.ProfileRecover.GetResult().Success.TestTrue();


            }








        }
    }
