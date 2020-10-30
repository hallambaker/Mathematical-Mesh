using Goedel.Mesh;
using Goedel.Mesh.Shell;
using Goedel.Mesh.Test;
using Goedel.Utilities;
using Goedel.IO;
using System;
using System.Collections.Generic;

namespace ExampleGenerator {

    public partial class CreateExamples {
        public string AliceService = "example.com";
        public string AliceFingerprint;
        public string AliceAccount = "alice@example.com";
        public string BobAccount = "bob@example.com";
        public string MeshServiceProvider = "example.com";
        public string ConsoleAccount = "console@example.com";
        public string MakerAccount = "maker@example.com";
        public string GroupAccount => Group.GroupAccount;

        public ProfileAccount AliceProfileAccount;
        public ProfileDevice AliceProfileDeviceCoffee;

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
        Alice2> dare decode ciphertext.dare plaintext2.txt
        ERROR - No decryption key is available

        Alice> device delete TBS
        ERROR - The feature has not been implemented

        Alice2> dare decode ciphertext.dare plaintext2.txt
        ERROR - No decryption key is available

        Alice creates an SSH profile within her Mesh on the administrative device. 
        Missing example 1

        Alice> message accept NCYI-I2BW-RJ5F-UYEB-X47Y-UTJW-FUX3
        ERROR - The specified message could not be found.

        The secure console verifies the response and grants access: 
        Missing example 2

        Alice> dare encode grouptext.txt /encrypt groupw@example.com /out ^
        groupsecret.dare
        ERROR - The option System.Object[] is not known.

        Alice> dare decode groupsecret.dare
        ERROR - No decryption key is available

        Bob> account sync
        Bob> dare decode groupsecret.dare
        ERROR - No decryption key is available

        Alice2> account recover /verify
        ERROR - Expected {
         * 
         */


        public void PerformAll() {

            Service.Hello = testCLIAlice1.Example(
                $"account hello {AliceAccount}"
                );
            var hello = Service.Hello.GetResultHello();

            // create the alice account.
            Account.CreateAlice = testCLIAlice1.Example(
                $"account create {AliceAccount}"
                );
            var aliceCreateAccount = Account.CreateAlice.GetResultCreateAccount();
            AliceProfileAccount = aliceCreateAccount.ProfileAccount;

            // Encrypt the file
            Account.EncryptSourceFile.WriteFileNew(TestFile1Text);
            var dump = testCLIAlice1.DumpFile(Account.EncryptSourceFile);
            var encode = testCLIAlice1.Example(
                $"dare encode {Account.EncryptSourceFile} {Account.EncryptTargetFile} /encrypt {AliceAccount} ");
            var verify = testCLIAlice1.Example(
                $"dare verify {Account.EncryptTargetFile}"
                );
            Account.ConsoleEncryptFile = new List<ExampleResult>() {
                dump, encode[0], verify[0]
                };

            // Decrypt the file
            var decode = testCLIAlice1.Example(
                $"dare decode {Account.EncryptTargetFile} {Account.EncryptResultFile}"
                );
            var dump2 = testCLIAlice1.DumpFile(Account.EncryptResultFile);
            Account.ConsoleDecryptFile = new List<ExampleResult>() {
                decode[0], dump2
                };

            // Check the passwords work

            Account.PasswordAdd = testCLIAlice1.Example(
                $"password add {PasswordSite} {PasswordAccount1} {PasswordValue1}",
                $"password add {PasswordSite2} {PasswordAccount2} {PasswordValue2}"
                );
            Account.PasswordGet = testCLIAlice1.Example(
                $"password get {PasswordSite}"
                );

            // Bookmark catalog
            string uri1 = "http://www.site1.com", title1 = "site1", path1 = "Sites.1";
            var bookmark = testCLIAlice1.Example(
                $"bookmark add {path1} {uri1} {title1}",
                $"bookmark get {path1}"
                );
            var resultBookmark = bookmark.GetResultEntry(1);
            Apps.BookmarkCatalogEntry = resultBookmark.CatalogEntry;

            // Contact catalog
            //string uri1 = "http://www.site1.com", title1 = "site1", path1 = "Sites.1";
            var contact = testCLIAlice1.Example(
                $"contact list "
                );
            var resultContact = contact.GetResultDump();
            Apps.ContactCatalogEntry = resultContact.CatalogedEntries[0];

            // Password catalog
            var resultPassword = Account.PasswordGet.GetResultEntry();
            Apps.CredentialCatalogEntry = resultPassword.CatalogEntry;

            // Network catalog
            //string uri1 = "http://www.site1.com", title1 = "site1", path1 = "Sites.1";
            var network = testCLIAlice1.Example(
                $"network add myWiFi securePassword",
                $"network list"
                );
            var resultNetwork = network.GetResultDump(1);
            Apps.NetworkCatalogEntry = resultNetwork.CatalogedEntries[0];

            // Task catalog
            //string uri1 = "http://www.site1.com", title1 = "site1", path1 = "Sites.1";
            var task = testCLIAlice1.Example(
                $"calendar add SomeItem",
                $"calendar list"
                );
            var resultTask = task.GetResultDump(1);
            Apps.TaskCatalogEntry = resultTask.CatalogedEntries[0];


            // Connect the second device

            Connect.ConnectRequest = testCLIAlice2.Example(
                $"device request {AliceAccount}"
                );
            Connect.ConnectPending = testCLIAlice1.Example(
                $"device pending"
                );

            var resultPending = Connect.ConnectPending.GetResultPending();
            var id1 = resultPending.Messages[0].MessageId;

            Connect.ConnectAccept = testCLIAlice1.Example(
                $"device accept {id1}"
                );
            var resultAccept = Connect.ConnectAccept[0].Result;
            var deviceId = "TBS";

            Connect.ConnectComplete = testCLIAlice2.Example(
                $"device complete"
                );
            Account.SyncAlice = testCLIAlice2.Example(
                $"account sync"
                );

            // Password catalog access broken on device 2
            // Don't have the account decryption key either.
            Connect.PasswordList2 = testCLIAlice2.Example(
                $"password get {PasswordSite}",
                $"dare decode {Account.EncryptTargetFile} {Connect.EncryptResultFile}"
                );

            Connect.Disconnect = testCLIAlice1.Example(
                $"device delete {deviceId}"
                );
            Connect.PasswordList2Disconnect = testCLIAlice2.Example(
                //$"password get {PasswordSite}",
                $"dare decode {Account.EncryptTargetFile} {Connect.EncryptResultFile}"
                );

            // Static connection tests
            "Static connect".TaskFunctionality();

            //Connect.ConnectStaticPrepare = testCLIAlice1.Example(
            //    );

            //Connect.ConnectStaticPollFail = testCLIAlice1.Example(
            //     );

            //Connect.ConnectStaticClaim = testCLIAlice1.Example(
            //     );

            //Connect.ConnectStaticPollSuccess = testCLIAlice1.Example(
            //     );

            // Application tests
            //Apps.SSH = testCLIAlice1.Example(
            //     );
            "SSH App config".TaskFunctionality();

            //Apps.Mail = testCLIAlice1.Example(
            //     );
            "Mail App config".TaskFunctionality();

            // Interactions with Bob... create an account
            Account.CreateBob = testCLIBob1.Example(
                $"account create {BobAccount}"
                );


            // Contact requests (Remote)
            Contact.ContactBobRequest = testCLIBob1.Example(
                $"message contact {AliceAccount}"
                 );

            Contact.ContactAliceResponse = testCLIAlice1.Example(
                $"account sync",
                $"message pending"
                 );
            resultPending = Contact.ContactAliceResponse.GetResultPending(1);
            var contactMessage = resultPending.Messages[0];

            var contactAccept = testCLIAlice1.Example(
                $"message accept {contactMessage.MessageId}"
                );
            Contact.ContactAliceResponse.Add(contactAccept[0]);

            // Interactions with Bob... create an account
            Account.CreateConsole = testCLIConsole1.Example(
                $"account create {ConsoleAccount}"
                );
            // Confirmation
            Confirm.ConfirmRequest = testCLIConsole1.Example(
                $"message confirm {AliceAccount} start"
                );
            var resultConfirmSent = Confirm.ConfirmRequest.GetResultSent();
            var messageId = resultConfirmSent.Message.MessageId;

            Confirm.ConfirmAliceResponse = testCLIAlice1.Example(
                $"message accept {messageId}"
                );

            //Confirm.ConfirmVerify = testCLIAlice1.Example(
            //     );
            "Verify the confirmation response".TaskFunctionality();


            // Group
            Group.GroupCreate = testCLIAlice1.Example(
                $"group create {GroupAccount}"
                 );

            Group.EncryptSourceFile.WriteFileNew(Group.TestText);
            Group.GroupEncrypt = testCLIAlice1.Example(
                $"dare encode {Group.EncryptSourceFile} /encrypt {GroupAccount} /out {Group.EncryptTargetFile}"
                 );
            Group.GroupDecryptAlice = testCLIAlice1.Example(
                $"dare decode {Group.EncryptTargetFile}"
                 );
            Group.GroupDecryptBobFail = testCLIAlice1.Example(
                $"dare decode {Group.EncryptTargetFile}"
                 );
            //Group.GroupAddBob = testCLIAlice1.Example(
            //    $"group add {GroupAccount} {BobAccount}"
            //     );
            //Group.GroupDecryptBobSuccess = testCLIBob1.Example(
            //    $"account sync",
            //    $"dare decode {Group.EncryptTargetFile}"
            //     );
            //Group.GroupDeleteBob = testCLIAlice1.Example(
            //    $"group delete {GroupAccount} {BobAccount}"
            //     );
            //Group.GroupDecryptBobRevoked = testCLIBob1.Example(
            //    $"dare decode {Group.EncryptTargetFile}"
            //     );



            // Connect device using a PIN (which can be presented as a QR code)
            Connect.ConnectPINCreate = testCLIAlice1.Example(
                    $"account pin"
                    );
            var pinResult = Connect.ConnectPINCreate.GetResultPIN();
            var pin = pinResult.MessagePIN.Pin;
            Connect.ConnectPINMessagePin = pinResult.MessagePIN;
            Connect.ConnectEARL = pinResult.MessagePIN.GetURI();

            Connect.ConnectPINRequest = testCLIAlice3.Example(
                $"device request {AliceAccount} /pin {pin}"
                );

            Connect.ConnectPending = testCLIAlice1.Example(
                $"account sync /auto"
                );

            Connect.ConnectPINComplete = testCLIAlice3.Example(
                $"device complete",
                $"account sync"
                );
            var connectPINComplete = Connect.ConnectPINComplete.GetResultConnect();
            var watchMachine = connectPINComplete.CatalogedMachine;
            Connect.AliceProfileDeviceWatch = watchMachine.ProfileDevice;
            //Connect.AliceActivationDeviceWatch = watchMachine.ProfileDevice;

            // Connect the coffee pot using a static QR

            Connect.ConnectMakerCreate = testCLIMaker1.Example(
                $"account create {MakerAccount}"
                );
            Connect.ConnectStaticPrepare = testCLIMaker1.Example(
                $"device preconfig"
                );
            var resultPublishDevice = Connect.ConnectStaticPrepare.GetResultPublishDevice();

            Connect.ConnectStaticInstall = testCLIAlice4.Example(
                $"device install {resultPublishDevice.FileName}"
                );
            //Connect.ConnectStaticPollFail = testCLIAlice4.Example(
            //    $"device complete"
            //    );
            Connect.ConnectStaticClaim = testCLIMaker1.Example(
                $"account connect {resultPublishDevice.Uri}"
                );
            Connect.ConnectStaticPollSuccess = testCLIAlice4.Example(
                $"device complete"
                );
            var connectStaticPollSuccess = Connect.ConnectStaticPollSuccess.GetResultConnect();
            var coffeePotMachine = connectStaticPollSuccess?.CatalogedMachine;
            var coffeePotDevice = coffeePotMachine?.CatalogedDevice;
            Connect.AliceProfileDeviceCoffee = coffeePotMachine.ProfileDevice;
            Connect.AliceActivationDeviceCoffee = connectStaticPollSuccess.ActivationDevice;
            //Connect.AliceActivationAccountCoffee = connectStaticPollSuccess.ActivationAccount;
            Connect.AliceConnectionDeviceCoffee = coffeePotDevice.ConnectionUser;


            Account.ProfileEscrow = testCLIAlice1.Example(
                $"account escrow"
                );
            var resultEscrow = Account.ProfileEscrow.GetResultEscrow();
            var share1 = resultEscrow.Shares[0];
            var share2 = resultEscrow.Shares[2];

            Account.DeleteAlice = testCLIAlice1.Example(
                $"account delete"
                );

            Account.ProfileRecover = testCLIAlice2.Example(
                $"account recover {share1} {share2} /verify"
                );



            
             }


        //public byte[] Enhance(
        //            byte[] MasterSecret,
        //            byte[] Plaintext,
        //            byte[] Salt = null) {

        //    Salt ??= Goedel.Cryptography.Platform.GetRandomBits(128);
        //    var CryptoStack = new CryptoStack(encryptID: CryptoAlgorithmId.AES256CBC) {
        //        Salt = Salt ?? Goedel.Cryptography.Platform.GetRandomBits(128),
        //        MasterSecret = MasterSecret
        //        };
        //    return CryptoStack.EncodeEDS(Plaintext, null);
        //    }



        }
    }
