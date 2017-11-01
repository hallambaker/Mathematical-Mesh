using System;
using System.Collections.Generic;
using Goedel.Utilities;


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



    public partial class CreateExamples {

        public Dictionary<string, string> Examples = new Dictionary<string, string>();

        public void DeviceA (string Tag, string Command) {
            MakeExample(Tag, Command);
            }

        public void DeviceB (string Tag, string Command) {
            MakeExample(Tag, Command);
            }

        public void DeviceC (string Tag, string Command) {
            MakeExample(Tag, Command);
            }

        public void MakeExample (string Tag, string Command) {
            Command = "<div=\"terminal\">\n<cmd> " + Command + "\n\n..Result TBS\n</div>\n";


            Examples.Add(Tag, Command);

            }

        public string Example (string Tag) {
            Examples.TryGetValue(Tag, out var Result);
            return Result;

            }

        public CreateExamples () {

            DeviceA("CreateVerify", "meshman verify  alice@example.com");
            DeviceA("Create1", "meshman personal create  alice@example.com");
            DeviceA("CreateSync", "meshman personal sync");
            DeviceA("CreateRegister", "meshman personal register  alice@example.net");
            DeviceA("CreateDeregister", "meshman personal deregister  alice@example.net");
            DeviceA("CreateFingerprint", "meshman personal fingerprint");
            

            DeviceB("ConnectBasic1", "meshman connect start alice@example.com");
            DeviceA("ConnectBasic2", "meshman connect pending");
            DeviceA("ConnectBasic3", "meshman connect accept [Request]");
            DeviceB("ConnectBasic4", "meshman connect complete");

            


            DeviceA("MailCreate", "meshman mail create");
            DeviceA("MailCreateCA", "meshman mail create alice@example.net /ca=ca.example.com");
            DeviceA("MailKeygen", "meshman keygen");
            DeviceA("MailGet", "meshman mail get alice@example.net /pass=[keygen]");

            DeviceA("SSHCreate", "meshman ssh create");
            DeviceB("SSHSync", "meshman ssh sync");

            DeviceA("SSHAuth", "meshman ssh auth");
            DeviceA("SSHPublic", "meshman ssh public rsa.pub");
            DeviceA("SSHPrivate", "meshman ssh private rsa.private /pass=[keygen]");

            DeviceB("SSHKnown", "meshman ssh known");
            DeviceA("SSHKnownAdd", "meshman ssh add known_hosts");

            DeviceA("PasswordAdd", "meshapp password add ftp.example.com alice badpassword");
            DeviceA("PasswordGet", "meshapp password get ftp.example.com");
            DeviceA("PasswordKeygen", "meshapp keygen");
            DeviceA("PasswordUpdate", "meshapp password add ftp.example.com alice [keygen]");


            DeviceA("AccountAlice", "meshapp account create alice@account.example.com");
            DeviceA("Account2", "meshapp account create bob@account.example.com");
            DeviceA("Account3", "meshapp account create malletb@account.example.com");

            DeviceC("ConfirmPost", "meshapp confirm post alice@account.example.com \"Log in to Host1\"");
            DeviceC("ConfirmStatus1", "meshapp confirm status [ID]");
            DeviceA("ConfirmPending", "meshapp confirm pending ");
            DeviceA("ConfirmAccept", "meshapp confirm accept ");
            DeviceC("ConfirmStatus2", "meshapp confirm status [ID]");


            DeviceA("recryptCreate", "recrypt create recrypt@example.com alice@example.com");
            DeviceB("recryptEncrypt", "recrypt encrypt recrypt@example.com /in=file1.txt");
            DeviceA("recryptAdd", "recrypt add recrypt@example.com mallet@example.com");
            DeviceC("recryptDecrypt", "recrypt decrypt /in=file1.txt.mmx  /out=file1m.txt");
            DeviceA("recryptDelete", "recrypt delete recrypt@example.com mallet@example.com");
            DeviceC("recryptDecryptFail", "recrypt decrypt /in=file1.txt.mmx  /out=file1m.txt");


            DeviceA("ConnectPIN1", "meshman connect generate");
            DeviceB("ConnectPIN2", "meshman connect start alice@example.com /pin=[Code]");
            DeviceA("ConnectPIN3", "meshman connect accept /pre");
            DeviceB("ConnectPIN4", "meshman connect complete");

            DeviceA("ConnectBootstrap1", "meshman connect bootstrap");
            DeviceC("ConnectBootstrap2", "meshman connect start alice@example.com /reboot");
            DeviceA("ConnectBootstrap3", "meshman connect accept /pre");
            DeviceB("ConnectBootstrap4", "meshman connect complete");

            DeviceC("ConnectBarcode1", "meshman device /barcode=example.net");
            DeviceA("ConnectBarcode2", "meshman connect accept [barcode]");

            DeviceA("CreateEscrow", "meshman personal escrow /shares=3 /quorum=2");
            DeviceA("PurgeMaster", "meshman personal purge [share1] [share2]");
            DeviceB("RecoverEscrow", "meshman personal alice@example.com recover [share1] [share2]");
            DeviceB("PurgeForce", "meshman personal purge /force");
            }


        }

    }
