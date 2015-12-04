using System.Collections.Generic;
using Goedel.CryptoLibNG.PKIX;
using Goedel.Debug;

namespace Goedel.Mesh {
    public partial class MailClientCatalog {
        public List<MailAccountInfo> Accounts = new List<MailAccountInfo>() ;


        public static List<MailAccountInfo> FindLocal () {
            var MailClientCatalog = new MailClientCatalog();
            MailClientCatalog.ImportWindowsLiveMail();
            return MailClientCatalog.Accounts;
            }

        public void Write () {
            foreach (var Account in Accounts) {
                Account.Write();
                }
            }

        }

    /*
    MailAccountInfo: public class
        EmailAddress: public virtual string
    
    */


    public class MailAccountInfo {
        /// <summary>
        /// The RFC822 Email address. [e.g. "alice@example.com"]
        /// </summary>
        public virtual string EmailAddress {
            get {
                return _EmailAddress;
                }

            set {
                _EmailAddress = value;
                }
            }
        private string _EmailAddress;

        /// <summary>
        /// The RFC822 Reply toEmail address. [e.g. "alice@example.com"]
        /// </summary>
        public virtual string ReplyToAddress {
            get {
                return _ReplyToAddress;
                }

            set {
                _ReplyToAddress = value;
                }
            }
        private string _ReplyToAddress;

        /// <summary>
        /// The Display Name. [e.g. "Alice Example"]
        /// </summary>
        public virtual string DisplayName {
            get {
                return _DisplayName;
                }

            set {
                _DisplayName = value;
                }
            }
        private string _DisplayName;

        /// <summary>
        /// The Account Name for display to the app user [e.g. "Example.com"]
        /// </summary>
        public virtual string AccountName {
            get {
                return _AccountName;
                }

            set {
                _AccountName = value;
                }
            }
        private string _AccountName;

        /// <summary>
        /// Inbound Mail Connection
        /// </summary>
        public virtual MailConnection Inbound {
            get {
                return _Inbound;
                }

            set {
                _Inbound = value;
                }
            }
        private MailConnection _Inbound;

        /// <summary>
        /// Outbound Mail Connection
        /// </summary>
        public virtual MailConnection Outbound {
            get {
                return _Outbound;
                }

            set {
                _Outbound = value;
                }
            }
        private MailConnection _Outbound;

        /// <summary>
        /// Signing Certificate
        /// </summary>
        public virtual Certificate CertificateSign {
            get {
                return _CertificateSign;
                }

            set {
                _CertificateSign = value;
                }
            }
        private Certificate _CertificateSign;

        /// <summary>
        /// Encryption Certificate if different from signing certificate.
        /// </summary>
        public virtual Certificate CertificateEncrypt {
            get {
                return _CertificateEncrypt;
                }

            set {
                _CertificateEncrypt = value;
                }
            }
        private Certificate _CertificateEncrypt;

        public virtual void CreateAccount() {
            }


        /// <summary>
        /// For debugging
        /// </summary>
        public void Write() {
            Trace.WriteLine("Account {0}  <{1}> ({2})", AccountName, EmailAddress, DisplayName);
            Inbound.Write ();
            Outbound.Write ();
            }
        }

    public class MailConnection {
        public string Server;
        public int Port;
        public AppProtocol AppProtocol;
        public string Account;
        public string Password;

        public TLSMode TLSMode;
        public bool SecureAuth;
        public int TimeOut;
        public int Polling;

        public virtual void Write () {
            Trace.WriteLine("    Server {0} : Port {1} : Protocol", Server, Port, AppProtocol);
            Trace.WriteLine("        Username {0}/{1}", Account, Password);
            Trace.WriteLine("        Timeout {0} : Poll {1}", TimeOut, Polling);           
            }

        public MailConnection() { }

        public MailConnection(string Server, int Port, AppProtocol AppProtocol,
            string Account, string Password, TLSMode TLSMode, bool SecureAuth) {

            this.Server = Server;
            this.Port = Port;
            this.AppProtocol = AppProtocol;
            this.Account = Account;
            this.Password = Password;
            this.TLSMode = TLSMode;
            this.SecureAuth = SecureAuth;

            }
        }


    public enum AppProtocol {
        SMTP = 1,
        SUBMIT = 2,
        POP3 = 4,
        IMAP4 = 5,

        NULL = 0
        };

    /// <summary>
    /// The TLS enhancement mode to use
    /// </summary>
    public enum TLSMode {
        /// <summary>
        /// Use TLS directly, i.e. no TLS upgrade negotiation.
        /// </summary>
        PORT = 1,

        /// <summary>
        /// Negotiate TLS upgrade after cleartext start. E.g. using STARTTLS in SMTP.
        /// </summary>
        STARTTLS = 2,

        /// <summary>
        /// No TLS enhancement
        /// </summary>
        None = 0
        }

    }
