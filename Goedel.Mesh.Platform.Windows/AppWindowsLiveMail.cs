//   Copyright © 2015 by Comodo Group Inc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml;
using System.IO;
using System.Text;
using Microsoft.Win32;
using Goedel.Mesh.Integration.LiveMail;

namespace Goedel.Mesh.Platform {

    /// <summary>
    /// The collection of mail client entries from multiple applications.
    /// </summary>
    public partial class MailClientCatalogPlatform {

        /// <summary>
        /// The default mail account for Windows Live Mail.
        /// </summary>
        public MailAccountInfoWLM DefaultWLMAccount;

        /// <summary>
        /// The Windows Live Mail integration object.
        /// </summary>
        public IntegrateLiveMail IntegrateLiveMail;

        /// <summary>
        /// Import all accounts from Windows Live Mail.
        /// </summary>
        public void ImportWindowsLiveMail() {
            IntegrateLiveMail = new IntegrateLiveMail(this);
            return ;
            }

        }


    /// <summary>
    /// Windows Live Mail integration class.
    /// </summary>
    public class IntegrateLiveMail : IntegratorMailClient {

        static readonly string WindowsLiveMailRegistryKey =
                @"Software\Microsoft\Windows Live Mail";

        static RegistryKey _RegistryKey;
        static string _StoreRoot;
        static string _DefaultMailAccount;

        /// <summary>
        /// Get the directory for the default mail account.
        /// </summary>
        public static string DefaultMailAccount {
            get {
                if (_DefaultMailAccount == null) {
                    _DefaultMailAccount = (string)RegistryKey.GetValue("Default Mail Account");
                    }
                return _DefaultMailAccount;
                }
            }

        /// <summary>
        /// Get the root directory for the Windows Live Mail store.
        /// </summary>
        public static string StoreRoot {
            get {
                if (_StoreRoot == null) {
                    _StoreRoot = (string)RegistryKey.GetValue("Store Root");
                    }
                return _StoreRoot;
                }
            }

        /// <summary>
        /// Get a RegistryKey object for Windows Live Mail.
        /// </summary>
        public static RegistryKey RegistryKey {
            get {
                if (_RegistryKey == null) {
                    _RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                                WindowsLiveMailRegistryKey);
                    }
                return _RegistryKey;
                }
            }

        /// <summary>
        /// Construct an integrator for the specified catalog and enumerate the accounts.
        /// </summary>
        /// <param name="Catalog">Mail account catalog to add to.</param>
        public IntegrateLiveMail(MailClientCatalogPlatform Catalog) {
            this.Catalog = Catalog;
            EnumerateAccounts();
            }

        /// <summary>
        /// Enumerate accounts in the store, creating and populating a MailAccountInfoWLM 
        /// instance for each account.
        /// </summary>
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
        }

    /// <summary>
    /// MailAccountInfo class for Windows Live Mail account. Provides convenience 
    /// accessors to the corresponding .oeaccount file.
    /// </summary>
    public class MailAccountInfoWLM : MailAccountInfo {

        // Article to make use of
        // CryptUnprotectData
        // https://msdn.microsoft.com/en-us/library/windows/desktop/aa380882(v=vs.85).aspx
        // http://securityxploded.com/passwordsecrets.php#Windows_Live_Mail

        // also
        // http://email-export.motobit.com/help/emailexport/cm614.htm
        // http://www.overclock.net/t/1293731/windows-data-protection-api-c-and-c

        string FileName;
        MessageAccount MessageAccount;


        /// <summary>
        /// The RFC822 Email address. [e.g. "alice@example.com"]
        /// </summary>
        public override string EmailAddress {
            get {
                return MessageAccount.SMTP_Email_Address;
                }
            set {
                MessageAccount.SMTP_Email_Address = value;
                }
            }

        /// <summary>
        /// The RFC822 Email address. [e.g. "alice@example.com"]
        /// </summary>
        public override string ReplyToAddress {
            get {
                return MessageAccount.SMTP_Reply_To_Email_Address;
                }
            set {
                MessageAccount.SMTP_Reply_To_Email_Address = value;
                }
            }

        /// <summary>
        /// The Display Name. [e.g. "Alice Example"]
        /// </summary>
        public override string DisplayName {
            get {
                return MessageAccount.SMTP_Display_Name;
                }
            set {
                MessageAccount.SMTP_Display_Name = value;
                }
            }

        /// <summary>
        /// The Account Name for display to the app user [e.g. "Example.com"]
        /// </summary>
        public override string AccountName {
            get {
                return MessageAccount.Account_Name;
                }
            set {
                MessageAccount.Account_Name = value;
                }
            }

        /// <summary>
        /// Inbound Mail Connection
        /// </summary>
        public override List<Connection> Inbound {
            get {
                return GetInbound ();
                }

            set {
                SetInbound (value);
                }
            }
        //private Connection _Inbound;

        /// <summary>
        /// Outbound Mail Connection
        /// </summary>
        public override List<Connection> Outbound {
            get {
                return GetOutbound();
                }

            set {
                SetOutbound(value);
                }
            }
        //private Connection _Outbound;

        /// <summary>
        /// Does the account have S/MIME parameters already?
        /// </summary>
        public override bool GotSMIME {
            get {
                return true;
                //return MessageAccount.SMTP_Certificate != null;
                }
            }

        /// <summary>
        /// Signing Certificate.
        /// </summary>
        public override PublicKey CertificateSign {
            get {
                // Here, need to use the SHA1 of the cert to locate the
                // certificate in the store.
                return _CertificateSign;
                }

            set {
                _CertificateSign = value;
                MessageAccount.SMTP_Certificate = 
                    _CertificateSign.Certificate.SHA1;

                }
            }
        private PublicKey _CertificateSign;

        /// <summary>
        /// Encryption Certificate.
        /// </summary>
        public override PublicKey CertificateEncrypt {
            get {
                // Here, need to use the SHA1 of the cert to locate the
                // certificate in the store.
                return _CertificateEncrypt;
                }

            set {
                _CertificateEncrypt = value;
                MessageAccount.SMTP_Encryption_Certificate = 
                        _CertificateEncrypt.Certificate.SHA1;
                }
            }
        private PublicKey _CertificateEncrypt;


        /// <summary>
        /// Construct an account information object from the specified
        /// Windows Live Mail file.
        /// </summary>
        /// <param name="FileName">The configuration file for the account.</param>
        public MailAccountInfoWLM(string FileName) {
            this.FileName = FileName;
            //_Inbound = new Connection();
            //_Outbound = new Connection();
            Read();
            }

        /// <summary>
        /// Construct an empty account information object.
        /// </summary>
        public MailAccountInfoWLM() {
            // General settings
            MessageAccount = new MessageAccount ();
            MessageAccount.Connection_Type = 3;
            MessageAccount.Make_Available_Offline = 1;

            // 

            }

        //static readonly List<string> UseTLS = { "

        //https://msdn.microsoft.com/en-us/library/ms715237(v=vs.85).aspx
        List<Connection> GetInbound() {

            var _Inbound = new Connection();
            var ConnectionList = new List<Connection> { _Inbound };

            var IMAP_Server = MessageAccount.IMAP_Server;
            if (IMAP_Server != null) {
                _Inbound.AppProtocol = AppProtocol.IMAP4;
                _Inbound.ServiceName = IMAP_Server;
                _Inbound.Port = (int)MessageAccount.IMAP_Port;
                
                _Inbound.UserName = MessageAccount.IMAP_User_Name;
                _Inbound.Password = null;
                _Inbound.TLSMode = MessageAccount.IMAP_Secure_Connection == 0 ?
                    TLSMode.None : TLSMode.Direct;
                _Inbound.SecureAuth = MessageAccount.IMAP_Use_Sicily != 0;
                _Inbound.TimeOut = (int) MessageAccount.IMAP_Timeout;
                _Inbound.Polling =  MessageAccount.IMAP_Polling > 0;

                }
            return ConnectionList;
            }

        void SetInbound(List<Connection> Connection) {
            var _Inbound = Connection[0];

            if (_Inbound.AppProtocol == AppProtocol.IMAP4) {
                MessageAccount.IMAP_Server = _Inbound.ServiceName;
                MessageAccount.IMAP_Port = (uint)_Inbound.Port;
                MessageAccount.IMAP_User_Name = _Inbound.UserName;
                MessageAccount.IMAP_Secure_Connection = (uint) (
                    (_Inbound.TLSMode == TLSMode.Direct |
                        _Inbound.TLSMode == TLSMode.Upgrade) ? 1 : 0);
                MessageAccount.IMAP_Use_Sicily = (uint)(
                    _Inbound.SecureAuth ? 1 : 0);
                MessageAccount.IMAP_Timeout = (uint)_Inbound.TimeOut;
                MessageAccount.IMAP_Polling = (uint) (_Inbound.Polling ? 1 : 0);
                }
            }

        List<Connection> GetOutbound() {
            var _Outbound = new Connection();
            var ConnectionList = new List<Connection> { _Outbound };
            var SMTP_Server = MessageAccount.SMTP_Server;
            if (SMTP_Server != null) {
                _Outbound.ServiceName = SMTP_Server;
                _Outbound.Port = (int)MessageAccount.SMTP_Port;
                _Outbound.AppProtocol = AppProtocol.SMTP;
                _Outbound.UserName = MessageAccount.SMTP_User_Name;
                _Outbound.Password = null;
                _Outbound.TLSMode = MessageAccount.SMTP_Secure_Connection == 0 ?
                    TLSMode.None : TLSMode.Direct;
                _Outbound.SecureAuth = MessageAccount.SMTP_Use_Sicily != 0;
                _Outbound.TimeOut = (int) MessageAccount.SMTP_Timeout;
                }
            return ConnectionList;
            }

        void SetOutbound(List<Connection> Connection) {
            var _Outbound = Connection[0];

            MessageAccount.SMTP_Server = _Outbound.ServiceName;
            MessageAccount.SMTP_Port = (uint)_Outbound.Port;
            MessageAccount.SMTP_User_Name = _Outbound.UserName;
            //MessageAccount.SMTP_Password2 = null;
            MessageAccount.SMTP_Secure_Connection = (uint) (
                (_Outbound.TLSMode == TLSMode.Upgrade |
                _Outbound.TLSMode == TLSMode.Direct) ? 1 : 0);
            MessageAccount.SMTP_Use_Sicily = (uint)(
                _Outbound.SecureAuth ? 1 : 0);
            MessageAccount.SMTP_Timeout = (uint)_Outbound.TimeOut;

            }

        /// <summary>
        /// Write out all settings to the console for debug purposes.
        /// </summary>
        public override void Dump() {
            var XmlWriterSettings = new XmlWriterSettings();
            XmlWriterSettings.Indent = true;
            var Writer = XmlWriter.Create(Console.Out, XmlWriterSettings);
            MessageAccount.Write(Writer);
            }

        /// <summary>
        /// Read the corrsponding .oeaccount file.
        /// </summary>
        public void Read() {
            MessageAccount = new MessageAccount();
            MessageAccount.Read(FileName);
            Dump();
            }

        /// <summary>
        /// Update an existing .oeaccount file.
        /// </summary>
        public override void Update() {
            MessageAccount.Write(FileName);
            }

        /// <summary>
        /// Create a new account by writing the account settings to a .oeaccount 
        /// file in the store root see:
        /// https://msdn.microsoft.com/en-us/library/ms715237(v=vs.85).aspx.
        /// </summary>
        public override void Create() {
            FileName = IntegrateLiveMail.StoreRoot + @"\account{" + AccountName + "}.oeaccount";
            MessageAccount.Write(FileName);
            }

        /// <summary>
        /// Generate keys and certificates for S/MIME
        /// </summary>
        /// <returns>true if new parameters were installed.</returns>
        public override bool GenerateSMIME(
                    ) {
            var Set = base.GenerateSMIME();
            return Set;
            }


        }
    }
