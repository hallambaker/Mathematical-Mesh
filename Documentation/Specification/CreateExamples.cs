using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Mesh;
using Goedel.Utilities;
using Goedel.Protocol.Debug;
using Goedel.Mesh.Server;
using Goedel.Mesh.MeshMan;
using Goedel.Mesh.Platform;

namespace ExampleGenerator {
    public partial class CreateExamples {


        void Go(string Output1, string Output2) {
            StartService();

            CreateProfile();
            ConnectDevice();
            AddApplicationWeb();  
            AddApplicationSSH();  // Todo: check, implement
            //AddApplicationMail(); // Todo: implement
            KeyRecovery(); // Todo: implement

            Traces = Portal.Traces;

            using (var Writer = new StreamWriter (Output1)) {
                var ExampleGenerator = new ExampleGenerator(Writer);
                ExampleGenerator.MeshExamples(this);
                }

            using (var Writer = new StreamWriter(Output2)) {
                var ExampleGenerator = new ExampleGenerator(Writer);
                ExampleGenerator.MeshExamplesWeb(this);
                }

            }

        public static string NameAccount = "alice";
        public static string NameService = "example.com";
        public readonly string AccountID = Account.ID(NameAccount, NameService);

        //public Mesh Mesh;

        MeshClient MeshClient;
        MeshPortalTraced Portal;
        /// <summary>
        /// Start the Mesh as a direct service
        /// </summary>
        void StartService() {
            // Create test Mesh
            File.Delete(LogMesh);
            File.Delete(LogPortal);

            Portal = new MeshPortalTraced(NameService, LogMesh, LogPortal);
            MeshPortal.Default = Portal;

            MeshClient = new MeshClient(PortalAccount: AccountID);
            }

        public static string Device1Name = "AliceDesktop";
        public static string Device1Description = "A desktop computer built by Acme Computer Co.";

        public static string Device2Name = "AliceRing";
        public static string Device2Description = "A wearable ring computer";

        public static string Device3Name = "AliceLaptop";
        public static string Device3Description = "A laptop computer";


        //public SignedDeviceProfile SignedDeviceProfile1
        //public SignedDeviceProfile2;
        //public PersonalProfile PersonalProfile;
        //public SignedPersonalProfile SignedPersonalProfile;

        CommandLineInterpreter CommandLineInterpreter = new CommandLineInterpreter();

        public Shell Shell1 = new Shell() {
            MeshCatalog = new MeshCatalog(new RegistrationMachineCached()),
            DefaultDescription = Device1Description
            };
        public string Device1 (string Command) {
            return Device1(Command, out var Forget);
            }
        public string Device1 (string Command, out string Tag) {
            Tag = Label(Command);
            return Shell1.Dispatch(Command);
            }

        public Shell Shell2 = new Shell() {
            MeshCatalog = new MeshCatalog(new RegistrationMachineCached()),
            DefaultDescription = Device2Description
            };
        public string Device2 (string Command, out string Tag) {
            Tag = Label(Command);
            return Shell2.Dispatch(Command);
            }

        public Shell Shell3 = new Shell() {
            MeshCatalog = new MeshCatalog(new RegistrationMachineCached()),
            DefaultDescription = Device3Description
            };
        public string Device3 (string Command, out string Tag) {
            Tag = Label(Command);
            return Shell3.Dispatch(Command);
            }

        static int Count = 0;
        string Label (string Command) {
            var Tag = Count++.ToString();
            Portal.Label(Tag);
            Portal.Traces.Current.Command = Command;
            return Tag;
            }

        public string LabelValidate;
        public string LabelCreatePersonal;
        public string CommandValidate;

        /// <summary>
        /// Create a new profile for alice@example.com
        /// </summary>
        void CreateProfile() {
            // check that the name is available
            Device1("verify test@prismproof.org", out LabelValidate);

            // create the profile
            Device1("personal create test@prismproof.org \\id=" + Device1Name, out LabelCreatePersonal);
            }


        public string LabelConnectRequest;
        public string LabelConnectPending;
        public string LabelConnectAccept;
        public string LabelConnectComplete;
        /// <summary>
        /// Add a second device
        /// </summary>
        void ConnectDevice() {

            // Connect the second device
            Device2("connect start test@prismproof.org", out LabelConnectRequest);
            Device1("connect pending", out LabelConnectPending);

            Device1("connect accept " + Shell2.Authenticator, out LabelConnectAccept);
            Device2("connect Complete", out LabelConnectComplete);
            }

        
        public string LabelApplicationWeb1;
        public string LabelApplicationWeb2;
        public string LabelApplicationWeb3;
        public string LabelApplicationWeb4;
        public string LabelApplicationWeb5;


        public string LabelApplicationProfile;


        public PasswordProfile PasswordProfile1 ;
        public PasswordProfile PasswordProfile2 ;
        public PasswordProfile PasswordProfile3 ;

        /// <summary>
        /// Create a Web credential profile.
        /// </summary>
        void AddApplicationWeb() {

            Device1("password create", out LabelApplicationWeb1);
            Device1("password add example.com alice password1", out LabelApplicationWeb1);
            PasswordProfile1 = Shell1.PasswordProfile;
            Device1("password add example.com alice password2", out LabelApplicationWeb2);
            Device1("password add example.net alice password3", out LabelApplicationWeb3);
            PasswordProfile2 = Shell1.PasswordProfile;
            Device1("password add example.com alice password2", out LabelApplicationWeb4);
            Device1("password delete example.net", out LabelApplicationWeb5);
            PasswordProfile3 = Shell1.PasswordProfile;
            }

        //SSHProfile SSHProfile;

        /// <summary>
        /// Create a SSH credential profile.
        /// </summary>
        void AddApplicationSSH() {

            Device1("ssh create");
            Device1("ssh known");
            Device1("ssh public ");
            Device1("ssh private");
            }

        /// <summary>
        /// Create a SSH credential profile.
        /// </summary>
        void AddApplicationMail () {
            throw new NYI();
            }


        /// <summary>
        /// The offline escrow entry data.
        /// </summary>
        public OfflineEscrowEntry OfflineEscrowEntry { get => Shell1.OfflineEscrowEntry;  }


        public string LabelEscrow = "Publish escrow";
        public string LabelRecover = "Recover";

        /// <summary>
        /// Create and recover profile.
        /// </summary>
        void KeyRecovery() {

            Device1("personal escrow /quorum 2 /shares 3 /file=escrow.json", out LabelEscrow);

            var Params = OfflineEscrowEntry.KeyShares[0].Text + " " +
                OfflineEscrowEntry.KeyShares[1].Text;
            Device1("personal recover " + Params, out LabelRecover);

            //throw new NYI();



            //// Create escrow keyshares for 2 our of 3
            //OfflineEscrowEntry = new OfflineEscrowEntry(PersonalProfile, 3, 2);

            //Portal.Label(LabelEscrow);
            //// Publish key escrow to the Mesh
            //MeshClient.Publish(OfflineEscrowEntry);

            //// Recover encryption key from two shares
            //var share1 = OfflineEscrowEntry.KeyShares[0].Text;
            //var share2 = OfflineEscrowEntry.KeyShares[1].Text;

            //// Get recovery data
            //string[] TestShares = { share1, share2 };
            //var RecoveryKey = new Secret (TestShares);

            //// Determine identifier
            //var Identifier = UDF.ToString(UDF.FromEscrowed(
            //    RecoveryKey.Key, 150));

            //// Here need a call to pull the data
            //Portal.Label(LabelRecover);

            //MeshClient.Recover(Identifier);
            }

        }
    }
