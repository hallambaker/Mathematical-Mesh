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
        public string GroupAccount => Group.GroupAccount;

        public ProfileUser AliceProfileAccount;
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


        public void PerformAll() {

            Service.Hello = testCLIAlice1.Example(
                $"account hello {AliceAccount}"
                );


            // create the alice account.
            Account.CreateAlice = testCLIAlice1.Example(
                $"account create {AliceAccount}"
                );

            Account.EncryptSourceFile.WriteFileNew(TestFile1Text);
            Account.ConsoleEncryptFile = testCLIAlice1.Example(
                $"dare encode {Account.EncryptSourceFile} /encrypt {AliceAccount} /out {Account.EncryptTargetFile}");

            Account.ConsoleDecryptFile = testCLIAlice1.Example(
                $"dare decode {Account.EncryptTargetFile}"
                );

            // Check the passwords work

            Account.PasswordAdd = testCLIAlice1.Example(
                $"password add {PasswordSite} {PasswordAccount1} {PasswordValue1}",
                $"password add {PasswordSite2} {PasswordAccount2} {PasswordValue2}"
                );
            Account.PasswordGet = testCLIAlice1.Example(
                $"password get {PasswordSite}"
                );

            // Connect the second device

            Connect.ConnectRequest = testCLIAlice2.Example(
                $"device request {AliceAccount}"
                );
            Connect.ConnectPending = testCLIAlice1.Example(
                $"device pending"
                );

            var resultPending = (Connect.ConnectPending[0].Result as ResultPending);
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


            //Connect.PasswordList2 = testCLIAlice2.Example(
            //    $"password get {PasswordSite}"
            //    );

            Connect.Disconnect = testCLIAlice1.Example(
                $"device delete {deviceId}"
                );
            //Connect.PasswordList2Disconnect = testCLIAlice2.Example(
            //    $"password get {PasswordSite}"
            //    );

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
            resultPending = Contact.ContactAliceResponse[1].Result as ResultPending;
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
            var resultConfirmSent = Confirm.ConfirmRequest[0].Result as ResultSent;
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
            Group.GroupAddBob = testCLIAlice1.Example(
                $"group add {GroupAccount} {BobAccount}"
                 );
            Group.GroupDecryptBobSuccess = testCLIAlice1.Example(
                $"dare decode {Group.EncryptTargetFile}"
                 );
            Group.GroupDeleteBob = testCLIAlice1.Example(
                $"group delete {GroupAccount} {BobAccount}"
                 );
            Group.GroupDecryptBobRevoked = testCLIAlice1.Example(
                $"dare decode {Group.EncryptTargetFile}"
                 );




            Account.ProfileEscrow = testCLIAlice1.Example(
                $"account escrow"
                );
            var resultEscrow = Account.ProfileEscrow[0].Result as ResultEscrow;
            var share1 = resultEscrow.Shares[0];
            var share2 = resultEscrow.Shares[2];

            Account.DeleteAlice = testCLIAlice1.Example(
                $"account delete"
                );

            Account.ProfileRecover = testCLIAlice2.Example(
                $"account recover {share1} {share2} /verify"
                );


            Console.WriteLine($"*****");
            Console.WriteLine($"Missing {CountMissing} of which {CountObsolete} obsolete");
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
