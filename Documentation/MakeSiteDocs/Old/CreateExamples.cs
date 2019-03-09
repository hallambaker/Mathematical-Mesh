using System;

using System.Collections.Generic;
using System.IO;
using System.Text;
using Goedel.Mesh.Shell;
using Goedel.Utilities;

using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Protocol;
using Goedel.IO;
using Goedel.Command;

namespace ExampleGenerator {

    /// <summary>
    /// 
    /// </summary>

    public partial class ExampleGenerator {

        public static Dictionary<string, string> ToDoList = new Dictionary<string, string>();

        public static string ToDo (string Code, string Text) {
            ToDoList.Add(Code, Text);
            return "\n<b>ToDo</b> " + Text;

            }

        }



    public class DocumentationEntry {
        public string Tag;
        public string UserName = "";
        public string DeviceName = "";
        public bool NYI;
        public List<string[]> Texts = new List<string[]>();


        public override string ToString () {
            var Builder = new StringBuilder();
            Builder.Append($"~~~~\n<div=\"{DeviceName}\">\n");

            foreach (var Text in Texts) {
                Builder.Append($"<cmd>{Text[0]}\n");
                for (var i = 1; i < Text.Length; i++) {
                    if (Text[i] != null) {
                        Builder.Append("<rsp>");
                        Builder.Append(Text[i]);

                        }
                    }
                }


            Builder.Append("</div>\n~~~~\n");
            return Builder.ToString();
            }


        public void Add (DocumentationEntry Entry) {
            foreach (var Text in Entry.Texts) {
                Texts.Add(Text);
                }
            }
        }


    public class MeshManShell : Shell {
        public string OutputClass;
        StringBuilder Buffer = new StringBuilder();


        //public override void ReportWrite (string Text) {
        //    if (ReportOutput) {
        //        Buffer.Append(Text);
        //        Console.Write(Text);
        //        }
        //    }

        //public override void ReportWriteLine (string Text, params object[] Data) {
        //    if (ReportOutput) {
        //        var Output = System.String.Format(Text, Data);
        //        Buffer.Append(Output);
        //        Buffer.Append("\n");
        //        Console.WriteLine(Output);
        //        }
        //    }

        public string Result {
            get {
                var Text = Buffer.ToString();
                Buffer.Clear();
                return Text;
                }
            }

        }

    public class MeshAppsShell : Shell {
        public string OutputClass;
        StringBuilder Buffer = new StringBuilder();

        public string Result {
            get {
                var Text = Buffer.ToString();
                Buffer.Clear();
                return Text;
                }
            }

        //public MeshAppsShell(MeshMachine RegistrationMachine = null)  {
        //    }
        }

    public partial class CreateExamples {
        public Dictionary<string, string> ToDoList = ExampleGenerator.ToDoList;

        public Dictionary<string, DocumentationEntry> Examples = new Dictionary<string, DocumentationEntry>();


        //public MeshManShell ShellAlice1 = new MeshManShell() {
        //    MeshMachine = new MeshMachineCached(),
        //    DefaultDescription = Device1Description,
        //    OutputClass = "terminal"
        //    };

        //public MeshManShell ShellAlice2 = new MeshManShell() {
        //    MeshMachine = new MeshMachineCached(),
        //    DefaultDescription = Device2Description,
        //    OutputClass = "terminal2"
        //    };

        //public MeshManShell ShellAlice3 = new MeshManShell() {
        //    MeshMachine = new MeshMachineCached(),
        //    DefaultDescription = Device2Description,
        //    OutputClass = "terminal2"
        //    };

        //public MeshAppsShell ShellAlice = new MeshAppsShell(new MeshMachineCached()) {
        //    OutputClass = "terminala"
        //    };

        //public MeshAppsShell ShellBob = new MeshAppsShell(new MeshMachineCached()) {
        //    OutputClass = "terminalb"
        //    };

        //public MeshAppsShell ShellMallet = new MeshAppsShell(new MeshMachineCached()) {
        //    OutputClass = "terminalm"
        //    };



        public DocumentationEntry DeviceMesh (MeshManShell Shell, string Terminal, string Command, string Tag = null, bool NYI = false) {
            if (NYI) {
                return MakeExample(Terminal, Tag, Command);
                }

            var CommandLine = ""; // Shell.Dispatch(Command);
            var Result = Shell.Result;

            return MakeExample(Terminal, Tag, CommandLine, Result);
            }




        DocumentationEntry DocumentationEntry1;
        public DocumentationEntry Device1 (string Command, string Tag = null, bool NYI = false) {
            //DocumentationEntry1 = DeviceMesh(ShellAlice1, "terminal", Command, Tag, NYI);
            return DocumentationEntry1;
            }

        //DocumentationEntry DocumentationEntry2;
        //public void Device2(string Command, string Tag = null, string Result = null, bool NYI = false) => DocumentationEntry2 = DeviceMesh(ShellAlice2, "terminal2", Command, Tag, NYI);

        //DocumentationEntry DocumentationEntry3;
        //public void Device3(string Command, string Tag = null, string Result = null, bool NYI = false) => DocumentationEntry3 = DeviceMesh(ShellAlice3, "terminal3", Command, Tag, NYI);



        public DocumentationEntry DeviceApp (MeshAppsShell Shell, string Terminal, string Command, string Tag = null, bool NYI = false) {
            if (NYI) {
                return MakeExample(Terminal, Tag, Command);
                }

            //var CommandLine = Shell.Dispatch(Command);
            var Result = Shell.Result;

            return MakeExample(Terminal, Tag, Command, Result);
            }


        //DocumentationEntry DocumentationEntryA;
        //public void DeviceAlice(string Command, string Tag = null, bool NYI = false) => DocumentationEntryA = DeviceApp(ShellAlice, "terminala", Command, Tag, NYI);

        //DocumentationEntry DocumentationEntryB;
        //public void DeviceBob(string Command, string Tag = null, string Result = null, bool NYI = false) => DocumentationEntryB = DeviceApp(ShellBob, "terminalb", Command, Tag, NYI);

        //DocumentationEntry DocumentationEntryC;
        //public void DeviceMallet(string Command, string Tag = null, string Result = null, bool NYI = false) => DocumentationEntryC = DeviceApp(ShellMallet, "terminalm", Command, Tag, NYI);

        public DocumentationEntry MakeExample (string Device, string Tag, 
                        string Command, string Result = null, bool NYI = false) {

            NYI = NYI | Result == null;

            if (NYI & Tag != null) {
                var Text = ($"\n<b>Make example for {Tag} => {Command}<b>\n\n");
                ToDoList.Add(Tag, Text);
                }

            var Entry = new DocumentationEntry() {
                DeviceName = Device,
                Tag = Tag,
                NYI = NYI | Result == null
                };
            Entry.Texts.Add (new string[] { Command, Result});

            Examples.Add(Tag, Entry);
            return Entry;
            }


        public DocumentationEntry MakeExampleSet (string Terminal, string Tag) {
            var Entry = new DocumentationEntry() {
                DeviceName = Terminal,
                Tag = Tag,
                NYI = false
                };

            Examples.Add(Tag, Entry);
            return Entry;
            }

        public string Example (string Tag) {
            if (Examples.TryGetValue(Tag, out var Result)) {
                return Result.ToString();
                }

            if (ToDoList.TryGetValue(Tag, out var Ignore)) {
                return Ignore;
                }

            var Text = ($"\n<b>Make example for {Tag}<b>\n\n");
            ToDoList.Add(Tag, Text);
            return Text;
            }

        public CreateExamples () {
            //StartServices();
            //Goedel.Mesh.MeshMan.CommandLineInterpreter.DefaultCommand = null;
            //Goedel.Combined.Shell.Client.CommandLineInterpreter.DefaultCommand = null;

            //CreateExamplesApps();
            //CreateExamplesMesh();

            }

        public void CreateExamplesMesh () {

            //var IndexExample = MakeExampleSet("terminal", "IndexSet");

            //Device1($"keygen", "NewKeygen");


            //// Create profile
            //Device1($"verify {PortalIdAlice}", "CreateVerify");
            //IndexExample.Add (Device1($"personal create  {PortalIdAlice}", "Create1"));
            //Device1($"personal sync", "CreateSync", NYI:true);
            //Device1($"personal register  {PortalIdAlice2}", "CreateRegister", NYI: true);
            //Device1($"personal deregister  {PortalIdAlice2}", "CreateDeregister", NYI: true);
            //Device1($"personal fingerprint", "CreateFingerprint");
            

            //// Connect Device
            //Device2($"connect start {PortalIdAlice}", "ConnectBasic1");
            //var ConnectRequestID = (ShellAlice2.LastResult as ResultConnectStart).Authenticator;
            //Device1($"connect pending", "ConnectBasic2");
            //Device1($"connect accept {ConnectRequestID}", "ConnectBasic3");
            //Device2($"connect complete", "ConnectBasic4");

            //// Mail 
            //IndexExample.Add(Device1($"mail create", "MailCreate", NYI: true));
            //Device1($"mail create alice@example.net /ca=ca.example.com", "MailCreateCA", NYI: true);
            //Device1($"keygen", "MailKeygen");
            //KeyGenPasswordMail = (ShellAlice1.LastResult as ResultKeyGenPassword).UDF;
            //Device1($"mail get alice@example.net /pass={KeyGenPasswordMail}", "MailGet", NYI: true);

            //// SSH
            //IndexExample.Add(Device1($"ssh create", "SSHCreate"));
            //Device2($"ssh sync", "SSHSync");

            //Device1($"ssh auth", "SSHAuth");
            //Device1($"ssh public rsa.pub", "SSHPublic");
            //Device1($"keygen", "SSHKeygen");
            //KeyGenPasswordSSH = (ShellAlice1.LastResult as ResultKeyGenPassword).UDF;
            //Device1($"ssh private rsa.private /pass={KeyGenPasswordSSH}", "SSHPrivate", NYI: true);

            //Device2($"ssh known", "SSHKnown", NYI: true);
            //Device1($"ssh add known_hosts", "SSHKnownAdd");

            //// Catalog

            //IndexExample.Add(Device1($"password add ftp.example.com alice badpassword", "PasswordAdd"));
            //Device1($"password get ftp.example.com", "PasswordGet");
            //Device1($"keygen", "PasswordKeygen");
            //KeyGenPasswordPassword = (ShellAlice1.LastResult as ResultKeyGenPassword).UDF;
            //Device1($"password add ftp.example.com alice {KeyGenPasswordPassword}", "PasswordUpdate", NYI: true);

            //// More connection 
            //ToDoList.Add("Connection", "Delete connection device 2");
            //Device1($"connect generate", "ConnectPIN1", NYI: true);
            //Device2($"connect start {PortalIdAlice} /pin=[Code]", "ConnectPIN2", NYI: true);
            //Device1($"connect accept /pre", "ConnectPIN3", NYI: true);
            //Device2($"connect complete", "ConnectPIN4", NYI: true);

            //Device1($"connect bootstrap", "ConnectBootstrap1", NYI: true);
            //Device2($"connect start {PortalIdAlice} /reboot", "ConnectBootstrap2", NYI: true);
            //Device1($"connect accept /pre", "ConnectBootstrap3", NYI: true);
            //Device2($"connect complete", "ConnectBootstrap4", NYI: true);

            //Device2($"device /barcode=example.net", "ConnectBarcode1", NYI: true);
            //Device1($"connect accept [barcode]", "ConnectBarcode2", NYI: true);

            //// Escrow
            //Device1($"personal escrow /shares=3 /quorum=2", "CreateEscrow");
            //EscrowShares = (ShellAlice1.LastResult as ResultEscrow).Shares;
            //Device1($"personal purge {EscrowShares[0]} {EscrowShares[1]}", "PurgeMaster", NYI: true);
            //Device2($"personal alice@example.com recover {EscrowShares[0]} {EscrowShares[1]}", "RecoverEscrow", NYI: true);
            //Device2($"personal purge /force", "PurgeForce", NYI: true);
            }

        public void CreateExamplesApps () {
            //DeviceAlice($"mesh create {PortalIdAlice}", "CreateAliceApp");
            //DeviceAlice($"account create {AccountIdAlice}", "AccountAlice");

            //DeviceBob($"mesh create {PortalIdBob}", "CreateBobApp");
            //DeviceBob($"account create {AccountIdBob}", "CreateBobAccount");

            //DeviceMallet($"mesh create {PortalIdMallet}", "CreateMalletApp");
            //DeviceMallet($"account create {AccountIdMallet}", "CreateMalletAccount");

            //DeviceBob($"confirm post {AccountIdAlice} \"Log in to Host1\"", "ConfirmPost");
            //var EnquireResponse = ShellBob.LastResult.Response as EnquireResponse;

            //DeviceBob($"confirm status {EnquireResponse.BrokerID}", "ConfirmStatus1");
            //DeviceAlice($"confirm pending /id={AccountIdAlice}", "ConfirmPending");
            //DeviceAlice($"confirm accept {EnquireResponse.BrokerID} /id={AccountIdAlice}", "ConfirmAccept", NYI: true);
            //DeviceBob($"confirm status {EnquireResponse.BrokerID}", "ConfirmStatus2");

            //RecryptTestFileInitial.WriteFileNew(RecryptTestFileText);

            //DeviceAlice($"recrypt create {RecryptTestFileGroup} {AccountIdAlice}", "recryptCreate");
            //DeviceAlice($"recrypt encrypt {RecryptTestFileGroup} /in={RecryptTestFileInitial}", "recryptEncrypt");
            //DeviceAlice($"recrypt add {RecryptTestFileGroup} {AccountIdMallet}", "recryptAdd");
            //DeviceMallet($"recrypt decrypt /in={RecryptTestFileEncrypted}  /out={RecryptTestFileDecrypted}", "recryptDecrypt");
            //DeviceAlice($"recrypt delete {RecryptTestFileGroup} {AccountIdMallet}", "recryptDelete");
            //DeviceMallet($"recrypt decrypt /in={RecryptTestFileEncrypted}  /out={RecryptTestFileDecryptFail}", "recryptDecryptFail");
            }


        public List<string> EscrowShares;

        public static string KeyGenPasswordMail = "NYI";
        public static string KeyGenPasswordSSH = "NYI";
        public static string KeyGenPasswordPassword = "NYI";

        public static string ConfirmTransactionID = "NYI";

        //MeshPortalDirect MeshPortal;
        //public AccountPortalDirect AccountPortal;
        //public ConfirmPortalDirect ConfirmPortal;
        //public RecryptPortalDirect RecryptPortal;

        public static string RecryptTestFileGroup = "recrypt@example.com";
        public static string RecryptTestFileInitial = "file1.txt";
        public static string RecryptTestFileEncrypted = "file1.txt.mmx";
        public static string RecryptTestFileDecrypted = "file1m.txt";
        public static string RecryptTestFileDecryptFail = "file1f.txt";
        public static string RecryptTestFileText = "This is a Test";

        public static string LogPortal = "Portal.jlog";
        public static string LogMesh = "Mesh.jlog";
        public static string PortalServiceDNS = "cryptomesh.org";
        public static string PortalServiceDNS2 = "example.com";
        public static string AccountServiceDNS = "cryptomesh.org";

        public static string PortalIdAlice = "alice@" + PortalServiceDNS;
        public static string PortalIdBob = "alice@" + PortalServiceDNS;
        public static string PortalIdMallet = "alice@" + PortalServiceDNS;
        public static string PortalIdAlice2 = "alice@" + PortalServiceDNS2;

        public static string AccountIdAlice = "alice@" + AccountServiceDNS;
        public static string AccountIdBob = "bob@" + AccountServiceDNS;
        public static string AccountIdCarol = "carol@" + AccountServiceDNS;
        public static string AccountIdMallet = "mallet@" + AccountServiceDNS;

        public static string Device1Name = "AliceDesktop";
        public static string Device1Description = "Alice's PC";

        public static string Device2Name = "AliceWatch";
        public static string Device2Description = "Alice's Watch";

        public static string Device3Name = "AliceTablet";
        public static string Device3Description = "Alice's tablet";


        /// <summary>
        /// Start the Mesh as a direct service
        /// </summary>
        void StartServices () {
            // Create test Mesh
            System.IO.File.Delete(LogMesh);
            System.IO.File.Delete(LogPortal);

            //MeshPortal = new MeshPortalDirect(PortalServiceDNS, LogMesh, LogPortal);
            //Goedel.Mesh.Portal.MeshPortal.Default = MeshPortal;
            //AccountPortal = new AccountPortalDirect(AccountServiceDNS);
            //Goedel.Account.AccountPortal.Default = AccountPortal;
            //ConfirmPortal = new ConfirmPortalDirect(AccountServiceDNS);
            //Goedel.Confirm.ConfirmPortal.Default = ConfirmPortal;
            //RecryptPortal = new RecryptPortalDirect(AccountServiceDNS);
            //Goedel.Recrypt.RecryptPortal.Default = RecryptPortal;
            }

        }

    }
