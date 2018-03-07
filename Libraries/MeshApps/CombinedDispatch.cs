using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Goedel.IO;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Command;
using Goedel.Recrypt;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;
using Goedel.Mesh.Platform;
using Goedel.Confirm;
using Goedel.Account.Client;
using Goedel.Recrypt.Client;
using Goedel.Confirm.Client;
using Goedel.Mesh.Portal;
using Goedel.Mesh.Portal.Client;
using Goedel.Mesh.Portal.Server;


namespace Goedel.Combined.Shell.Client {
    public partial class CombinedShell {

        CommandLineInterpreter CommandLineInterpreter = new CommandLineInterpreter();
        MeshSession MeshSession = null;
        public MeshMachine MeshMachine = null;


        string DefaultMeshPortalAccount  => PersonalSession.Portals.Default; 
        //static string DefaultApplicationAccount = null;

        public string CommandLine { get; set; }
        public string LastID { get; private set; }

        public SessionPersonal PersonalSession => MeshMachine.Personal; 
        public PersonalProfile PersonalProfile => PersonalSession.PersonalProfile; 
        public DeviceProfile DeviceProfile => PersonalProfile.DeviceProfile; 

        public string Dispatch (string Command) {
            CommandLine = "meshapp" + Command;
            CommandLineInterpreter.MainMethod(this, CommandSplitLex.Split(Command));
            return CommandLine;
            }

        public ResultBase LastResult;

        public CombinedShell (MeshMachine RegistrationMachine = null) {
            this.MeshMachine = RegistrationMachine ?? new MeshMachineCached();
            MeshSession = new MeshSession(this.MeshMachine);
            }


        public override void PersonalCreate (PersonalCreate Options) {

            var Address = Options.Portal.Value;
            Assert.True((Address != null & Address != ""), NoPortalAccount.Throw);
            SetReporting(Options.Report, Options.Verbose);

            var DeviceRegistration = GetDevice(Options);

            var PersonalProfile = new PersonalProfile(DeviceRegistration.DeviceProfile);

            var Registration = MeshSession.CreateAccount(Address, PersonalProfile);


            Report("Created new personal profile {0}", Registration.UDF);
            Report("Profile registered to {0}", Address);

            LastResult = new ResultPersonalCreate() {
                PersonalProfile = PersonalProfile,
                PortalAccount = Address
                };
            LastResult.Display(Options);

            }

        // Account dispatch

        public override void AccountCreate (AccountCreate Options) {
            var AccountID = Options.AccountID.Value;
            var PersonalSession = GetPersonal(Options);
            var PersonalProfile = PersonalSession.PersonalProfile;

            // Create the empty profiles
            var RecryptProfile = new RecryptProfile(PersonalSession.PersonalProfile, AccountID);
            var ConfirmProfile = new ConfirmProfile(PersonalSession.PersonalProfile, AccountID);

            // Because we are lazy, make every device an administrator device for both apps.
            foreach (var Device in PersonalProfile.Devices) {
                RecryptProfile.AddDevice(Device.DeviceProfile, true);
                ConfirmProfile.AddDevice(Device.DeviceProfile, true);
                }

            var RecryptSession = PersonalSession.Add(RecryptProfile);
            var ConfirmSession = PersonalSession.Add(ConfirmProfile);
            PersonalSession.Write();
            RecryptSession.Write();
            ConfirmSession.Write();

            var AccountClient = new AccountClient(AccountID);

            var Response = AccountClient.Create(
                AccountID, 
                PersonalProfile.UDF,
                DefaultMeshPortalAccount,
                Options.PIN.Value);

            LastResult = new ResultAccountCreate() {
                Response = Response,
                AccountID = AccountID
                };
            LastResult.Display(Options);
            }

        public override void AccountDelete (AccountDelete Options) {
            var AccountID = Options.AccountID.Value;
            var AccountClient = new AccountClient(AccountID);

            var Response = AccountClient.Delete(DefaultMeshPortalAccount);
            LastResult = new ResultAccountCreate() {
                Response = Response,
                AccountID = AccountID
                };
            LastResult.Display(Options);
            }

        public override void AccountUpdate (AccountUpdate Options) {
            var AccountID = Options.AccountID.Value;
            var AccountClient = new AccountClient(AccountID);

            // not sure what to update right now.
            var Response = AccountClient.Update(DefaultMeshPortalAccount);
            LastResult = new ResultAccountCreate() {
                Response = Response
                };
            LastResult.Display(Options);
            }

        public override void AccountGet (AccountGet Options) {
            var AccountID = Options.AccountID.Value;
            var AccountClient = new AccountClient(AccountID);


            var Response = AccountClient.Get(DefaultMeshPortalAccount);
            LastResult = new ResultAccountCreate() {
                Response = Response
                };
            LastResult.Display(Options);
            }


        // Confirm dispatch
        #region // Confirm dispatch
        public override void ConfirmPost (ConfirmPost Options) {
            var AccountID = Options.AccountID.Value;
            var ConfirmClient = new ConfirmClient(AccountID);


            var UnsignedRequest = new TBSRequest() {
                FromID = DefaultMeshPortalAccount,
                ToID = Options.AccountID.Value,
                Text = ConfirmClient.ToRequestText (Options.Text.Value)
                };

            var SignedRequest = new JoseWebSignature(UnsignedRequest, 
                        SigningKey: DeviceProfile.DeviceSignatureKey.KeyPair);

            var RequestEntry = new RequestEntry() {
                ResponderAccount = Options.AccountID.Value,
                Request = SignedRequest,
                Expire = DateTime.UtcNow.AddHours(4)
                };

            var Response = ConfirmClient.Enquire(RequestEntry);

            LastID = Response.BrokerID;
            LastResult = new ResultAccountCreate() {
                Response = Response
                };
            LastResult.Display(Options);
            }

        public override void ConfirmStatus (ConfirmStatus Options) {
            var ConfirmClient = new ConfirmClient(Options.ID.Value);

            var Response = ConfirmClient.Status(Options.ID.Text, Options.Cancel.Value);

            Report("Status {0}: {1}", Options.ID.Text, Response.Response.RequestStatus);
            LastResult = new ResultAccountCreate() {
                Response = Response
                };
            LastResult.Display(Options);
            }

        public override void ConfirmPending (ConfirmPending Options) {
            var AccountID = Options.AccountID.Value;
            var ConfirmClient = new ConfirmClient(AccountID);

            var Response = ConfirmClient.Pending(Options.AccountID.Value);

            LastResult = new ResultConfirmPending() {
                Response = Response
                };
            LastResult.Display(Options);
            }



        public override void ConfirmAccept (ConfirmAccept Options) {
            var Response = Respond(Options, Options.AccountID.Value, Options.ID.Value, true, DeviceProfile.DeviceSignatureKey.KeyPair);
            }

        public override void ConfirmReject (ConfirmReject Options) {
            var Response = Respond(Options, Options.AccountID.Value, Options.ID.Value, false, DeviceProfile.DeviceSignatureKey.KeyPair);

            }



        public RespondResponse Respond (IReporting Options, string AccountID, string BrokerID, bool Accept, KeyPair SignatureKey) {
            var ConfirmClient = new ConfirmClient(AccountID);

            var Response = ConfirmClient.Pending(AccountID);
            var SignedRequest = Response.Entries.Find(Entry => Entry.BrokerID == BrokerID);

            var UnsignedResponse = new TBSResponse() {
                SignedRequest = SignedRequest.Request,
                Value = Accept
                };

            var SignedResponse = new JoseWebSignature(UnsignedResponse,
                        SigningKey: DeviceProfile.DeviceSignatureKey.KeyPair);

            var ResponseEntry = new ResponseEntry() {
                RequestStatus = "Reply",
                BrokerID = BrokerID,
                EnquirerID = SignedRequest.EnquirerID,
                Response =SignedResponse
                };

            var TransactionResponse = ConfirmClient.Respond(ResponseEntry);

            LastResult = new ResultConfirmRespond() {
                Pending = Response,
                Response = TransactionResponse
                };
            LastResult.Display(Options);

            return (TransactionResponse);
            }
        #endregion

        #region // Recrypt dispatch
        // Recrypt dispatch
        public override void CreateGroup (CreateGroup Options) {
            var AccountID = Options.AccountID.Value;
            var RecryptClient = new RecryptClient(AccountID);

            Assert.NotNull(Options.GroupID.Value, NoGroupSpecified.Throw);

            var RecryptProfile = PersonalSession.GetRecryptProfile(Options.AccountID.Value);

            var RecryptionGroup = new RecryptionGroup() {
                GroupName = Options.GroupID.Value
                };

            RecryptionGroup.Generate(DeviceProfile);
            RecryptionGroup.AddMember(PersonalSession.PersonalProfile, RecryptProfile);

            var Response = RecryptClient.CreateGroup(RecryptionGroup);
            LastResult = new ResultCreateGroup() {
                Response = Response
                };
            LastResult.Display(Options);
            }

        public override void RecryptAdd (RecryptAdd Options) {
            var GroupID = Options.GroupID.Value;
            var AccountID = Options.AccountID.Value;

            var AccountClient = new AccountClient(AccountID);
            var RecryptClient = new RecryptClient(GroupID);

            // Get the user's recryption profile

            // Get the account
            var AccountInfo = AccountClient.Get(AccountID);
            var AccountData = AccountInfo?.Data;

            Assert.NotNull(AccountData, ProfileNotFound.Throw);


            SessionPersonal.GetUserProfile(AccountData.MeshUDF, AccountData.Portal, "RecryptProfile",
                out var AddPersonal, out var AddApplication);

            // NYI: mechanism to tell the user that they have been added to the recryption group
            var Response = RecryptClient.GetGroup(GroupID); 
            var RecryptionGroup = Response.RecryptionGroup;
            RecryptionGroup.AddMember(AddPersonal, AddApplication as RecryptProfile);

            var UpdateResponse = RecryptClient.UpdateGroup(RecryptionGroup);
            LastResult = new ResultRecryptAdd() {
                Response = Response
                };
            LastResult.Display(Options);
            }


        public override void Encrypt (Encrypt Options) {
            //var Response = RecryptClient.EncryptData(
            //        Options.GroupID.Value,
            //        Options.In.Value,
            //        Options.Out.Value);

            var GroupID = Options.GroupID.Value;
            var In = Options.In.Value;
            var Out = Options.Out.Value ?? In + ".mmx";

            // Get the recryption key
            var RecryptClient = new RecryptClient(GroupID);
            var Response = RecryptClient.RecryptKey(GroupID);


            var EncryptionKey = RecryptionKey.GetEncryptionKey(Response.SignedKey);
            var KID = UDF.MakeStrongName (GroupID, EncryptionKey.PublicParameters.Kid);

            // Encrypt the file
            In.OpenReadToEnd(out var Plaintext);
            var KeyPair = EncryptionKey.KeyPair;
            var Encrypted = new JoseWebEncryption(Plaintext, EncryptionKey: KeyPair, KID: KID);
            Out.WriteFileNew(Encrypted.ToJson());
            LastResult = new ResultEncrypt() {
                Response = Response
                };
            LastResult.Display(Options);
            }

        public override void Decrypt (Decrypt Options) {
            var In = Options.In.Value;
            var Out = Options.Out.Value ?? Path.GetFileNameWithoutExtension(In);

            // Read the file encryption entry
            In.OpenReadToEnd(out var Ciphertext);
            var Encrypted = JoseWebEncryption.FromJSON(Ciphertext.JSONReader(), false);

            var PersonalSession = GetPersonal(Options);
            var PersonalProfile = PersonalSession.PersonalProfile;

            // ok so here we want to turn the set of recryption keys into a
            // set of account memberships...

            var Recipient = Encrypted.GetRecrypted(out var Address, out var UDF);
            var RecryptClient = new RecryptClient(Address);

            var SessionRecryption = new SessionRecryption(PersonalSession);
            var EncryptionKey = SessionRecryption.GetEncryptionKey(Encrypted.Recipients);


            // Get the recryption data
            var Response = RecryptClient.RecryptData(PersonalProfile.UDF, EncryptionKey.UDF, Recipient);

            // Complete the decryption
            var EncryptedDecryptionKey = Response.DecryptionKey;
            var Partial = Response.Partial;

            // Decrypt the file
            var PartialAgreement = KeyAgreement.FromJSON(Partial.JSONReader());
            var CompletionKeyData = EncryptedDecryptionKey.Decrypt(EncryptionKey);

            // recover the completion key
            var CompletionKey = Key.FromJSON(CompletionKeyData.JSONReader());

            // decrypt the data
            var Plaintext = Encrypted.Decrypt(Recipient, CompletionKey.KeyPair, 
                PartialAgreement.KeyAgreementResult);

            LastResult = new ResultDecrypt() {
                Response = Response
                };
            LastResult.Display(Options);
            }

        #endregion


        //AccountClient GetAccountClient (IReporting Options) {
        //    return null;
        //    }


        //ConfirmClient GetConfirmClient (IReporting Options) {
        //    return null;
        //    }


        //RecryptClient GetRecryptClient (IReporting Options) {
        //    return null;
        //    }

        //public override void RecryptDelete (RecryptDelete Options) {
        //    var Response = RecryptClient.UpdateGroup();
        //    } 


        } // class CombinedShell
    }
