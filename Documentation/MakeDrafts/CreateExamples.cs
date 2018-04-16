using System;

using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Mesh;
using Goedel.Utilities;
using Goedel.Protocol.Debug;
using Goedel.Mesh.MeshMan;
using Goedel.Mesh.Portal;
using Goedel.Mesh.Portal.Server;
using Goedel.Mesh.Portal.Client;
using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Container;
using Goedel.Protocol;
using Goedel.Protocol.Exchange;
using Goedel.Protocol.Exchange.Server;
using Goedel.IO;
using Goedel.Command;

namespace ExampleGenerator {


    public partial class CreateExamples {

        public string ContainerFramingSimple = "";
        StringWriter ConsoleWriter ;

        public List<ContainerHeader> ContainerHeadersSimple = new List<ContainerHeader>();
        public List<ContainerHeader> ContainerHeadersChain = new List<ContainerHeader>();
        public List<ContainerHeader> ContainerHeadersTree = new List<ContainerHeader>();
        public List<ContainerHeader> ContainerHeadersMerkleTree = new List<ContainerHeader>();

        void GoContainer () {
            //// Simple
            //var TContainer = MakeContainer("Test1List", ContainerType.List);
            //var Data = TestData(300);
            //TContainer.Append(Data);
            //ReadContainer(TContainer, ContainerHeadersSimple);
            //ContainerFramingSimple = ConsoleWriter.ToString();


            //// Digest
            //TContainer = MakeContainer("Test1Chain", ContainerType.Chain);
            //TContainer.Append(Data);
            //TContainer.Append(Data);
            //TContainer.Append(Data);
            //ReadContainer(TContainer, ContainerHeadersChain);


            //// Tree
            //TContainer = MakeContainer("Test1Tree", ContainerType.Tree);
            //TContainer.Append(Data);
            //TContainer.Append(Data);
            //TContainer.Append(Data);
            //TContainer.Append(Data);
            //TContainer.Append(Data);
            //TContainer.Append(Data);
            //ReadContainer(TContainer, ContainerHeadersTree);


            //// Merkle Tree
            //TContainer = MakeContainer("Test1Merkle", ContainerType.MerkleTree);
            //TContainer.Append(Data);
            //TContainer.Append(Data);
            //TContainer.Append(Data);
            //TContainer.Append(Data);
            //TContainer.Append(Data);
            //TContainer.Append(Data);
            //ReadContainer(TContainer, ContainerHeadersMerkleTree);


            //ExampleGenerator.MeshExamplesContainer(this);

            ExampleGenerator.MeshExamplesUDF(this);
            ExampleGenerator.MeshExamplesUDFCompressed(this);
            ExampleGenerator.MakeExamplesKeyExchange(this);
            }

        KeyExchangeClient KeyExchangeClient;
        KeyExchangePortalTraced KeyExchangePortalTraced;

        public TraceDictionary KeyExchangeTraces;
        public Key ClientDHIdentity;
        public string TraceDH = "DiffieHellman";

        void GoKeyExchange () {

            Message.Append(Message._TagDictionary, ExchangeMessage._TagDictionary);
            KeyExchangePortalTraced = new KeyExchangePortalTraced(NameService);
            KeyExchangePortal.Default = KeyExchangePortalTraced;

            KeyExchangeClient = new KeyExchangeClient(AccountID);

            KeyExchangeTraces = KeyExchangePortalTraced.Traces;
            KeyExchangeTraces.Label(TraceDH);

            var DHProvider = CryptoCatalog.Default.GetRecryption(CryptoAlgorithmID.DH);
            DHProvider.Generate(KeySecurity.Exportable, 2048);

            var ClientIdentity = DHProvider.KeyPair;


            var Ticket = KeyExchangeClient.GetTicket(DHProvider);
            }


        public Container MakeContainer (string FileName, ContainerType ContainerType = ContainerType.Chain) {
            ConsoleWriter = new StringWriter();

            //var FileStream = FileName.FileStream(FileStatus.Overwrite);
            var JBCDStream = new JBCDStreamDebug(FileName, FileStatus.Overwrite, Output:ConsoleWriter);
            return Container.NewContainer(JBCDStream, ContainerType);

            }


        public byte[] TestData (int MaxSize) {
            var Data = new byte[MaxSize];
            for (var i = 0; i < MaxSize; i++) {
                Data[i] = (byte)(i & 0xff);
                }
            return Data;
            }


        public void ReadContainer (Container Container, List<ContainerHeader> ContainerHeaders) {

            Goedel.Protocol.JSONReader.Trace = true; // HACK: 

            Container.First();
            while (!Container.EOF) {
                ContainerHeaders.Add(Container.ContainerHeader);
                Container.Next();
                }
            }

        void GoMesh () {
            ExampleGenerator.MakeExamplesCatalog(this);
            ExampleGenerator.MakeExamplesBookmark(this);
            ExampleGenerator.MakeExamplesCredential(this);
            ExampleGenerator.MakeExamplesContact(this);
            ExampleGenerator.MakeExamplesCalendar(this);
            ExampleGenerator.MakeExamplesMail(this);
            ExampleGenerator.MakeExamplesSSH(this);

            //StartService();

            //CreateProfile();
            //ConnectDevice();
            ////AddApplicationWeb();  
            //AddApplicationSSH();  // Todo: check, implement
            ////AddApplicationMail(); // Todo: implement
            //KeyRecovery(); // Todo: implement

            //Traces = Portal.Traces;

            //ExampleGenerator.MeshExamples(this);
            //ExampleGenerator.MeshExamplesWeb(this);
            }

        public static string NameAccount = "alice";
        public static string NameService = "example.com";
        public readonly string AccountID = Account.ID(NameAccount, NameService);

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
            MeshMachine = new MeshMachineCached(),
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
            MeshMachine = new MeshMachineCached(),
            DefaultDescription = Device2Description
            };
        public string Device2 (string Command, out string Tag) {
            Tag = Label(Command);
            return Shell2.Dispatch(Command);
            }

        public Shell Shell3 = new Shell() {
            MeshMachine = new MeshMachineCached(),
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
            Device1("keygen");


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
            var Authenticator = (Shell2.LastResult as ResultConnectStart).Authenticator;

            Device1("connect pending", out LabelConnectPending);
            Device1("connect accept " + Authenticator, out LabelConnectAccept);
            Device2("connect Complete", out LabelConnectComplete);
            }

        
        public string LabelApplicationWeb1;
        public string LabelApplicationWeb2;
        public string LabelApplicationWeb3;
        public string LabelApplicationWeb4;
        public string LabelApplicationWeb5;


        public string LabelApplicationProfile;


        //public PasswordProfile PasswordProfile1 ;
        //public PasswordProfile PasswordProfile2 ;
        //public PasswordProfile PasswordProfile3 ;

        ///// <summary>
        ///// Create a Web credential profile.
        ///// </summary>
        //void AddApplicationWeb() {

        //    Device1("password create", out LabelApplicationWeb1);
        //    Device1("password add example.com alice password1", out LabelApplicationWeb1);
        //    PasswordProfile1 = Shell1.PasswordProfile;
        //    Device1("password add example.com alice password2", out LabelApplicationWeb2);
        //    Device1("password add example.net alice password3", out LabelApplicationWeb3);
        //    PasswordProfile2 = Shell1.PasswordProfile;
        //    Device1("password add example.com alice password2", out LabelApplicationWeb4);
        //    Device1("password delete example.net", out LabelApplicationWeb5);
        //    PasswordProfile3 = Shell1.PasswordProfile;
        //    }

        //SSHProfile SSHProfile;

        /// <summary>
        /// Create a SSH credential profile.
        /// </summary>
        void AddApplicationSSH() {
            Device1("keygen"); // Generate a password for the later pieces 

            Device1("ssh create");

            Device1("ssh public ");
            Device1("ssh private");

            Device1("ssh known");
            Device1("ssh add ssh1.example.com rsa AAAA1234");
            Device1("ssh known");

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
        public OfflineEscrowEntry OfflineEscrowEntry => Shell1.OfflineEscrowEntry;  


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
