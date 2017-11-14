using System;
using System.Collections.Generic;
using System.IO;
using Goedel.IO;
using System.Text;
using System.Threading.Tasks;
using Goedel.Combined.Shell.Client;
using Goedel.Mesh.Server;
using Goedel.Mesh.Platform.Linux;
using Goedel.Account;
using Goedel.Utilities;
using Goedel.Protocol.Debug;
using Goedel.Account.Server;
using Goedel.Confirm.Server;
using Goedel.Recrypt.Server;
using Goedel.Registry;

namespace RunMeshApps {
    // Todo: Create, document mesh profiles for recrypt, confirm

    public partial class MakeExamples {



        CommandLineInterpreter CommandLineInterpreter = new CommandLineInterpreter();
        CombinedShell ShellAlice = new CombinedShell(new MeshMachineLinux("Profiles\\Alice"));
        CombinedShell ShellBob = new CombinedShell(new MeshMachineLinux("Profiles\\Bob"));
        CombinedShell ShellMallet = new CombinedShell(new MeshMachineLinux("Profiles\\Mallet"));

        // Hack: This will do for now. But this will need to be a different directory to 
        // exercise the connection functionality.
        CombinedShell ShellAlice2 = new CombinedShell(new MeshMachineLinux("Profiles\\Alice"));


        static int Count = 0;
        string AliceDevice (string Command, out string Tag) {
            Tag = Label(Command);
            ShellAlice.Dispatch(Command);
            return Command;
            }

        string AliceDevice2 (string Command, out string Tag) {
            Tag = Label(Command);
            ShellAlice2.Dispatch(Command);
            return Command;
            }

        string BobDevice (string Command, out string Tag) {
            Tag = Label(Command);
            ShellBob.Dispatch(Command);
            return Command;
            }

        string MalletDevice (string Command, out string Tag) {
            Tag = Label(Command);
            ShellMallet.Dispatch(Command);
            return Command;
            }

        string Ignore;

        public TraceDictionary MeshTraces => MeshPortal.Traces; 

        public MeshPortalTraced MeshPortal;
        public AccountPortalTraced AccountPortal;
        public ConfirmPortalTraced ConfirmPortal;
        public RecryptPortalTraced RecryptPortal;

        public string CreateAliceMesh;
        public string CreateAliceAccount;
        public string ConfirmPostRequest;
        public string ConfirmStatusFail;
        public string ConfirmStatusSuccess;
        public string ConfirmRespond;
        public string ConfirmPending;

        public string RecryptCreateGroup;
        public string RecryptAddMember1;
        public string RecryptAddMember2;
        public string RecryptDeleteMember;
        public string RecryptDecryptionSuccess;
        public string RecryptDecryptionFail;

        public string RecryptEncryptFile2;
        public string RecryptEncryptFile1;

        public string AliceConfirmAccount = "alice@example.com";
        public string BobConfirmAccount = "bob@example.com";

        public string AlicePostConfirm;

        public string CiphertextFileData;
        public string PlaintextFileData;

        public string PlaintextFile = "file1.txt";
        public string CiphertextFile = "file1.txt.mmx";

        void Generate () {

            PlaintextFileData = PlaintextFile.OpenReadToEnd();
            CiphertextFileData = CiphertextFile.OpenReadToEnd();



            // Create the server instances and traced direct portals
            MeshPortal = new MeshPortalTraced(PortalService, LogMesh, LogPortal);
            Goedel.Mesh.Server.MeshPortal.Default = MeshPortal;
            AccountPortal = new AccountPortalTraced(AppService);
            Goedel.Account.AccountPortal.Default = AccountPortal;
            ConfirmPortal = new ConfirmPortalTraced(AppService);
            Goedel.Confirm.ConfirmPortal.Default = ConfirmPortal;
            RecryptPortal = new RecryptPortalTraced(AppService);
            Goedel.Recrypt.RecryptPortal.Default = RecryptPortal;


            // Note that we require separate profiles for Mesh and applications
            //
            // The Mesh portal account is used to manage the mesh that the user uses to 
            // bind all his devices together into a single logical entity.

            // The Account profile used for applications is separate. A user is likely to 
            // have multiple account profiles for different purposes, e.g. work and personal
            // but will usually only have a single mesh profile.

            // This design does make it easy to link all the accounts owned by a user that
            // are tied to a particular Mesh profile. But this is probably the right default.
            // The best way to support seggregated profiles so that a uiser can establish
            // independent identities is probably to establish a common profile that the user
            // uses to connect their devices together and then use that common profile to
            // move around the credentials necessary to support the multiple device profiles.

            // In this example, all the users use the same mesh portal and the same
            // application service. In a real life example, they would likely use different
            // mesh portals but their application service would be the same for a 
            // given recryption group.
            // Create mesh profiles and add in recrypt and confirm
            AliceDevice("mesh create alice@example.net", out CreateAliceMesh);
            AliceDevice("account create alice@example.com", out CreateAliceAccount);

            BobDevice("mesh create bob@example.net", out Ignore);
            BobDevice("account create bob@example.com", out Ignore);

            MalletDevice("mesh create mallet@example.net", out Ignore);
            MalletDevice("account create mallet@example.com", out Ignore);

            // Alice creates recryption group containing {Alice, Bob}
            AliceDevice("recrypt create recrypt@example.com alice@example.com", out RecryptCreateGroup);

            /*
             *   Checkpoint the state here to enable lots of unit testing.
             */

            // Alice adds Mallet to the group
            AliceDevice("recrypt add recrypt@example.com mallet@example.com", out RecryptAddMember2);


            // ================
            // Recrypt Examples

            // Bob encrypts two documents. The first document is also uploaded to
            // the portal
            BobDevice("recrypt encrypt recrypt@example.com /in=file1.txt", out RecryptEncryptFile1);

            //// Alice adds Bob to the group
            //AliceDevice("recrypt add bob@example.net", out RecryptAddMember1);



            // Mallet decrypts document 1
            MalletDevice("recrypt decrypt /in=file1.txt.mmx  /out=file1m.txt", out RecryptDecryptionSuccess);

            //// Alice removes Mallet from the group
            //AliceDevice("recrypt delete mallet@example.net", out RecryptDeleteMember);

            //// Mallet tries to decrypt document 2 (fails)
            //MalletDevice("recrypt decrypt file1.txt.jenc ", out RecryptDecryptionFail);


            //// Alice decrypts document
            //AliceDevice("recrypt decrypt /in=file1.txt.mmx /out=file1a.txt", out Ignore);

            // ==================
            // Confirm examples

            // Alice posts a confirmation request
            AlicePostConfirm = AliceDevice(@"confirm post bob@example.com ""Open pod bay doors""", out ConfirmPostRequest);

            // Alice attempts to get status (fails)
            AliceDevice("confirm status " + ShellAlice.LastID, out ConfirmStatusFail);

            // Bob gets pending requests
            BobDevice("confirm pending /id=bob@example.com", out ConfirmPending);

            // Bob responds to a pending request
            BobDevice("confirm accept /id=bob@example.com " + ShellAlice.LastID, out ConfirmRespond);

            // Alice attempts to get status (success)
            AliceDevice("confirm status " + ShellAlice.LastID, out ConfirmStatusSuccess);

            }

        string Label (string Command) {
            var Tag = Count++.ToString();
            MeshPortal.Label(Tag, Command);
            AccountPortal.Label(Tag, Command);
            ConfirmPortal.Label(Tag, Command);
            RecryptPortal.Label(Tag, Command);
            return Tag;
            }



        public static string ToHexString (string Input) {
            var Builder = new StringBuilder();
            var Separator = new Separator(", ");
            var InputBytes = Input.ToBytes();

            foreach (var c in InputBytes) {
                Builder.Append(Separator.ToString());
                Builder.Append(c.ToString("x2"));
                }

            return Builder.ToString();
            }
        }
    }
