using System.Collections.Generic;
using Goedel.Debug;

namespace Goedel.Mesh {
    public partial class MailClientCatalog {
        public List<MailAccountInfo> Accounts = new List<MailAccountInfo>() ;


        public static List<MailAccountInfo> FindLocal () {
            var MailClientCatalog = new MailClientCatalog();
            MailClientCatalog.ImportWindowsLiveMail();
            return MailClientCatalog.Accounts;
            }

        }



    public abstract class MailAccountInfo {
        /// <summary>
        /// The RFC822 Email address. [e.g. "alice@example.com"]
        /// </summary>
        public string EmailAddress;

        /// <summary>
        /// The Display Name. [e.g. "Alice Example"]
        /// </summary>
        public string DisplayName;

        /// <summary>
        /// The Account Name for display to the app user [e.g. "Example.com"]
        /// </summary>
        public string AccountName;

        public MailConnection Inbound;
        public MailConnection Outbound;

        public abstract void SetCertificates();

        public abstract void SetInbound(MailConnection MailConnection);

        public abstract void SetOutbound(MailConnection MailConnection);


        public void Write() {
            Trace.WriteLine("Account {0}  <{1}> ({2})", AccountName, EmailAddress, DisplayName);
            Inbound.Write ();
            Outbound.Write ();
            }
        }

    public class MailConnection {
        public string Server;
        public int Port;
        public AppProtocol Protocol;
        public string Account;
        public string Password;

        public bool TLS;
        public bool SecureAuth;
        public int TimeOut;
        public int Polling;

        public virtual void Write () {
            Trace.WriteLine("    Server {0} : Port {1} : Protocol", Server, Port, Protocol);
            Trace.WriteLine("        Username {0}/{1}", Account, Password);
            Trace.WriteLine("        Timeout {0} : Poll {1}", TimeOut, Polling);           
            }

        
        }


    public enum AppProtocol {
        NULL = 0,
        SMTP = 1,
        SUBMIT = 2,
        POP3 = 4,
        IMAP4 = 5
        };



    }
