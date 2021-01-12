﻿using Goedel.Mesh;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Utilities;
using Goedel.IO;
using System;
using System.Collections.Generic;
using Goedel.Test;

namespace ExampleGenerator {

    public partial class CreateExamples {
        public string AliceService = "example.com";
        public string AliceFingerprint;



        public ProfileAccount AliceProfileAccount;


        public string TestFile1Text = "This is a test";


        public int CountMissing = 0;
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
            Screen.WriteLine("Missing example!");
            }

        /*
         * Stuff needing to be fixed...
         * 
            ## Alice> account sync /auto

            ERROR - Cannot access a closed file.
            Alice> device accept RQUH-LNHP-XVR6-UHQ5-WSCZ-WCZC-Q5PK
            ERROR - Cannot access a closed file

            ## device complete

            Gives no report on outcome [pending / accepted / refused]

            ## Alice2> password get ftp.example.com

            ERROR - No decryption key is available
            Alice2> dare decode ciphertext.dare plaintext2.txt
            ERROR - No decryption key is available

            ## Alice> device delete TBS

            ERROR - The feature has not been implemented


            ## Alice2> dare decode ciphertext.dare plaintext2.txt

            ERROR - No decryption key is available


            ## Create SSH profile....


            ## Alice> message accept NBKU-OVBZ-YZRN-FEB4-ARMW-VUVI-2JSG

            ERROR - Cannot access a closed file.


            ## Alice> message accept NBAC-LLBY-E4EU-7ZRF-I47O-ZYHZ-PBCW

            ERROR - The specified message could not be found.


            ## Alice> $message status {confirmResponseID}

            ERROR - The command System.Object[] is not known.

            ## Alice> group create groupw@example.com
            ERROR - Cannot access a closed file.


            ## Alice2> account recover /verify
            ERROR - Expected {
         * 
         */

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


            ConnectDeviceCompare( out var deviceId);
            TestConnectDisconnect(deviceId);
            SSHApp();
            MailApp();
            CreateBobAccount();
            ContactExchange();
            Confirmation();
            GroupOperations();
            ConnectPINDynamicQR();
            ConnectStaticQR();
            EscrowAndRecover();
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
                ) ;

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


            if (Check.DisableDeletedDevices) {
                Connect.PasswordList2Disconnect.GetResult(1).Success.TestFalse();
                }

            }




        public static void SSHApp() {
            // Application tests
            //Apps.SSH = testCLIAlice1.Example(
            //     );
            "SSH App config".TaskFunctionality();

            // Add an SSH application profile 'SSH'

            // Dump out the private key in SSH format

            // Dump out the public key in SSH format

            if (Check.DisableSSH) {
                throw new NYI();
                }
            }

        public static void MailApp() {
            //Apps.Mail = testCLIAlice1.Example(
            //     );
            "Mail App config".TaskFunctionality();

            // Add an Email profile


            // Add keys for S/MIME


            // Add keys for OpenPGP

            if (Check.DisableMail) {
                throw new NYI();
                }
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

            Group.GroupEncrypt = Alice1.Example(
                $"dare encode {Group.EncryptSourceFile} {Group.EncryptTargetFile} /encrypt {GroupAccount}",
                $"dare decode {Group.EncryptTargetFile} {Group.GroupDecryptBobFile}"
                );




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
                    $"account pin"
                    );
            var pinResult = Connect.ConnectPINCreate.GetResultPIN();
            var pin = pinResult.MessagePIN.Pin;
            Connect.ConnectPINMessagePin = pinResult.MessagePIN;
            Connect.ConnectDynamicURI = pinResult.MessagePIN.GetURI();

            Connect.ConnectPINRequest = Alice3.Example(
                $"device request {AliceAccount} /pin {pin}"
                );

            var connectRequest = Connect.ConnectPINRequest.GetResultConnect();
            var connectRequestT = Connect.ConnectPINRequest[0].Traces[0].RequestObject;
            var connectResponseT = Connect.ConnectPINRequest[0].Traces[0].ResponseObject;

            // decode the request message using the server encryption key??
            // decode the response message using the device key??

            Connect.ConnectRequestPIN = connectRequest.RequestConnection;
            Connect.AcknowledgeConnectionPIN = connectRequest.AcknowledgeConnection;


            Connect.ConnectPINPending = Alice1.Example(
                $"message pending",
                $"account sync /auto"
                );

            var connectPendingPIN = Connect.ConnectPINPending.GetResultPending();
            var syncUpdates = Connect.ConnectPINPending[1].Traces[1].RequestObject as TransactRequest;

            Connect.ConnectPINCompleteMessage = syncUpdates.Local[1].JsonObject as MessageComplete; // change here!!!

            Connect.ConnectPINComplete = Alice3.Example(
                $"device complete",
                $"account sync"
                );

            // this is not being assigned correctly

            var connectPINComplete = Connect.ConnectPINComplete.GetResultConnect();
            Connect.RespondConnectionPIN = connectPINComplete.RespondConnection;

            var watchMachine = connectPINComplete.CatalogedMachine;
            Connect.AliceProfileDeviceWatch = watchMachine.ProfileDevice;
            //Connect.AliceActivationDeviceWatch = watchMachine.ProfileDevice;
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

            Connect.ConnectEARL = null;

            Connect.ConnectStaticInstall = Alice4.Example(
                $"device install {resultPublishDevice.FileName}"
                );
            //Connect.ConnectStaticPollFail = testCLIAlice4.Example(
            //    $"device complete"
            //    );
            Connect.ConnectStaticClaim = Maker1.Example(
                $"account connect {resultPublishDevice.Uri}"
                );
            Connect.ConnectStaticPollSuccess = Alice4.Example(
                $"device complete"
                );
            var connectStaticPollSuccess = Connect.ConnectStaticPollSuccess.GetResultConnect();
            var coffeePotMachine = connectStaticPollSuccess?.CatalogedMachine;
            var coffeePotDevice = coffeePotMachine?.CatalogedDevice;
            Connect.AliceProfileDeviceCoffee = coffeePotMachine.ProfileDevice;
            Connect.AliceActivationDeviceCoffee = connectStaticPollSuccess.ActivationDevice;
            //Connect.AliceActivationAccountCoffee = connectStaticPollSuccess.ActivationAccount;
            Connect.AliceConnectionDeviceCoffee = coffeePotDevice.ConnectionUser;
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

            Account.ProfileRecover = Alice2.Example(
                $"account recover {share1} {share2} /verify"
                );


            Account.ProfileEscrow.GetResult().Success.TestTrue();
            Account.DeleteAlice.GetResult().Success.TestTrue();
            Account.ProfileRecover.GetResult().Success.TestTrue();


            }








        }
    }
