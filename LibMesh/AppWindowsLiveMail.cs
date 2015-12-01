using System;
using System.Security.Cryptography;
using System.Xml;
using System.IO;
using System.Text;
using Microsoft.Win32;
using Goedel.Protocol;
using Goedel.Debug;
using Goedel.CryptoLibNG.PKIX;

namespace Goedel.Mesh {

    public partial class MailClientCatalog {
        public MailAccountInfoWLM DefaultWLMAccount;

        public IntegrateLiveMail IntegrateLiveMail;

        public int ImportWindowsLiveMail() {
            int Result = 0;

            IntegrateLiveMail = new IntegrateLiveMail(this);

            return Result;
            }

        }





    public class IntegrateLiveMail : IntegratorMailClient {

        readonly string WindowsLiveMailRegistryKey =
                @"Software\Microsoft\Windows Live Mail";

        string StoreRoot;
        string DefaultMailAccount;

        public IntegrateLiveMail(MailClientCatalog Catalog) {
            this.Catalog = Catalog;
            GetRegistryValues();
            EnumerateAccounts();
            }

        public void GetRegistryValues() {
            // The directory location for the user's store is at
            // HKCU\Software\Microsoft\Windows Live Mail\Store Root
            //            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Software\xyz");
            //string pathName = (string)registryKey.GetValue("BinDir");

            using (var RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(WindowsLiveMailRegistryKey)) {
                if (RegistryKey != null) {
                    StoreRoot = (string)RegistryKey.GetValue("Store Root");
                    DefaultMailAccount = (string)RegistryKey.GetValue("Default Mail Account");
                    }
                }

            return;
            }


        public override void EnumerateAccounts() {
            if (StoreRoot == null) return;
            var Directories = Directory.EnumerateDirectories(StoreRoot);

            foreach (var DirectoryEntry in Directories) {
                var AccountFiles = Directory.EnumerateFiles(
                        DirectoryEntry, "*.oeaccount");

                foreach (var AccountFile in AccountFiles) {
                    Console.WriteLine("file:{0}", AccountFile);
                    var Account = new MailAccountInfoWLM(AccountFile);
                    Catalog.Accounts.Add(Account);

                    if (Path.GetFileName(AccountFile) == DefaultMailAccount) {
                        Catalog.DefaultWLMAccount = Account;
                        }
                    }
                }
            }

        public override void CreateAccount(MailAccountInfo MailAccountInfo) {

            }


        //public void SetCertificates(PKIX.Certificate Sign, PKIX.Certificate Encrypt) {
        //    if (CurrentAccount == null) throw new Exception("No valid account");
        //    CurrentAccount.SMTP_Certificate = Sign.X509Certificate2.Thumbprint;
        //    CurrentAccount.SMTP_Encryption_Certificate = Encrypt.X509Certificate2.Thumbprint;

        //    CurrentAccount.Update();
        //    }

        }

    public class MailAccountInfoWLM : MailAccountInfo {

        // Article to make use of
        // CryptUnprotectData
        // https://msdn.microsoft.com/en-us/library/windows/desktop/aa380882(v=vs.85).aspx
        // http://securityxploded.com/passwordsecrets.php#Windows_Live_Mail

        // also
        // http://email-export.motobit.com/help/emailexport/cm614.htm
        // http://www.overclock.net/t/1293731/windows-data-protection-api-c-and-c

        string FileName;

        //public string Account_Name = null;
        //public string SMTP_Display_Name = null;

        //public string SMTP_Email_Address = null;

        public string WLM_Certificate = null;
        public string WLM_Encryption_Certificate = null;


        public MailAccountInfoWLM(string FileName) {
            this.FileName = FileName;
            Inbound = new MailConnection();
            Outbound = new MailConnection();

            Read();
            }


        public override void SetCertificates() {
            }

        public override void SetInbound(MailConnection MailConnection) {
            }

        public override void SetOutbound(MailConnection MailConnection) {
            }


        public void Read() {
            using (var StreamReader = new StreamReader(FileName)) {
                var Input = XmlReader.Create(StreamReader);
                ReadXml(Input);
                }
            }


        public void Update() {

            using (var StringWriter = new StringWriter()) {

                //StringWriter.Write ("This is a test");

                using (var StreamReader = new StreamReader(FileName)) {
                    var Input = XmlReader.Create(StreamReader);
                    var XmlWriterSettings = new XmlWriterSettings();
                    XmlWriterSettings.Indent = true;
                    var Output = XmlWriter.Create(StringWriter, XmlWriterSettings);
                    UpdateXml(Input, Output);
                    Output.Flush();
                    }
                Console.WriteLine(StringWriter.ToString());
                using (var FileHandle = File.Open(FileName, FileMode.Create)) {
                    using (var StreamWriter = new StreamWriter(FileHandle, Encoding.Unicode)) {
                        StreamWriter.Write(StringWriter.ToString());
                        }
                    }
                }
            }

        public void ReadXml(XmlReader In) {
            // For future info, how to decrypt the password
            // http://securityxploded.com/outlookpasswordsecrets.php
            string Name = null;

            while (In.Read()) {
                switch (In.NodeType) {
                    case XmlNodeType.Element:
                        Name = In.Name;
                        break;
                    case XmlNodeType.Text:
                        if (Name == "Account_Name") AccountName  = In.Value;
                        if (Name == "SMTP_Display_Name") DisplayName = In.Value;
                        if (Name == "SMTP_Email_Address") EmailAddress = In.Value;

                        if (Name == "IMAP_Server") {
                            Inbound.Server = In.Value;
                            Inbound.Protocol = AppProtocol.IMAP4;
                            }

                        if (Name == "IMAP_Port") Inbound.Port = Convert.ToInt32 (In.Value, 16);
                        if (Name == "IMAP_User_Name") Inbound.Account = In.Value;
                        if (Name == "IMAP_Password2") Inbound.Password = ReadPassword (In.Value);

                        if (Name == "IMAP_Secure_Connection") {
                            Inbound.TLS = (Convert.ToInt32(In.Value, 16) == 1);
                            }

                        if (Name == "IMAP_Timeout") Inbound.TimeOut = Convert.ToInt32(In.Value, 16);
                        if (Name == "IMAP_Polling") Inbound.Polling = Convert.ToInt32(In.Value, 16);

                        if (Name == "SMTP_Certificate") WLM_Certificate = In.Value;
                        if (Name == "SMTP_Encryption_Certificate") WLM_Encryption_Certificate = In.Value;
                        break;
                    }
                }
            }

        public string ReadPassword(string hex) {
            // This code almost works. The problem seems to be that we don't know 
            // what the salt should be and so the call to unprotect crashes the machine.

            //byte Salt = null /* Find what that should be */
            //var Binary = BaseConvert.FromBase16String(hex);
            //var Unencrypted =  ProtectedData.Unprotect (Binary, Salt, DataProtectionScope.CurrentUser);
            //var Text = Encoding.Unicode.GetString(Unencrypted);

            return "NYI";
            }


        public void EnrollCertificate (Certificate Certificate, bool Sign, bool Encrypt) {
            Trace.TBS("Enroll certificate in windows cert store");

            if (Sign) {
                WLM_Certificate = Certificate.SHA1;
                }
            if (Encrypt) {
                WLM_Encryption_Certificate = Certificate.SHA1;
                }
            }

        public void UpdateXml(XmlReader In, XmlWriter Out) {
            bool Write_SMTP_Certificate = WLM_Certificate != null;
            bool Write_SMTP_Encryption_Certificate = WLM_Encryption_Certificate != null;

            string Name = null;

            while (In.Read()) {
                switch (In.NodeType) {
                    case XmlNodeType.Element:
                        Out.WriteStartElement(In.Name);
                        Name = In.Name;
                        if (In.HasAttributes) {
                            while (In.MoveToNextAttribute()) {
                                Out.WriteAttributeString(In.Name, In.Value);
                                }
                            }
                        break;
                    case XmlNodeType.Text:
                        if (Name == "SMTP_Certificate") {
                            Out.WriteString(WLM_Certificate);
                            Write_SMTP_Certificate = false;
                            }
                        else if (Name == "SMTP_Encryption_Certificate") {
                            Out.WriteString(WLM_Encryption_Certificate);
                            Write_SMTP_Encryption_Certificate = false;
                            }
                        else {
                            Out.WriteString(In.Value);
                            }
                        break;
                    case XmlNodeType.XmlDeclaration:
                    case XmlNodeType.ProcessingInstruction:
                        Out.WriteProcessingInstruction(In.Name, In.Value);
                        break;
                    case XmlNodeType.Comment:
                        Out.WriteComment(In.Value);
                        break;
                    case XmlNodeType.EndElement:

                        if (In.Name == "MessageAccount") {
                            if (Write_SMTP_Certificate) {
                                Out.WriteStartElement("SMTP_Certificate");
                                Out.WriteAttributeString("type", "BINARY");
                                Out.WriteString(WLM_Certificate);
                                Out.WriteFullEndElement();
                                }
                            if (Write_SMTP_Encryption_Certificate) {
                                Out.WriteStartElement("SMTP_Encryption_Certificate");
                                Out.WriteAttributeString("type", "BINARY");
                                Out.WriteString(WLM_Encryption_Certificate);
                                Out.WriteFullEndElement();
                                }
                            }


                        Out.WriteFullEndElement();
                        break;
                    }
                }
            }


        /// <summary>
        /// Create a new account with these settings.
        /// </summary>
        public void CreateAccount () {

            // create the registry key


            }


        }



    }
