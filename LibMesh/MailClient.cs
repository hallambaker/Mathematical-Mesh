using System.Collections.Generic;
using Goedel.LibCrypto;
using Goedel.LibCrypto.PKIX;
using Goedel.Debug;

namespace Goedel.Mesh {
    public partial class MailClientCatalog {
        public List<MailAccountInfo> Accounts = new List<MailAccountInfo>() ;


        public static List<MailAccountInfo> FindLocal () {
            var MailClientCatalog = new MailClientCatalog();
            MailClientCatalog.ImportWindowsLiveMail();
            return MailClientCatalog.Accounts;
            }

        public virtual void Dump () {
            foreach (var Account in Accounts) {
                Account.Dump();
                }
            }

        }



    public partial class MailAccountInfo : MailProfilePrivate {

        /// <summary>
        /// Convenience accessor for the first outbound connection
        /// </summary>
        public Connection Out {
            get {
                return Outbound[0];
                }

            set {
                Outbound = new List<Connection> { value };
                }
            }

        /// <summary>
        /// Convenience accessor for the first inbound connection
        /// </summary>
        public Connection In {
            get {
                return Inbound[0];
                }

            set {
                Inbound = new List<Connection> { value };
                }
            }


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

        public virtual void Create() {
            }

        public virtual void Update () {
            }

        /// <summary>
        /// Generate S/MIME key pairs and register in the correct Windows stores.
        /// </summary>
        /// <returns></returns>
        public virtual bool GenerateSMIME () {
            var SignKey = PublicKey.Generate(KeyType.ASK,
                                CryptoCatalog.Default.AlgorithmSignature);
            SignKey.SignCertificate(Application.EmailSignature |
                        Application.DataSignature, EmailAddress, SignKey);

            var EncryptKey = PublicKey.Generate(KeyType.AEK, 
                                CryptoCatalog.Default.AlgorithmExchange);
            EncryptKey.SignCertificate(Application.EmailEncryption |
                        Application.DataEncryption, EmailAddress, EncryptKey);
            
            var SigningCSR = new CertificationRequest(SignKey.Certificate);
            var EncryptionCSR = new CertificationRequest(EncryptKey.Certificate);

            CertificateStore.Register(SignKey.Certificate);
            CertificateStore.Register(EncryptKey.Certificate);

            CertificateSign = SignKey.Certificate;
            CertificateEncrypt = EncryptKey.Certificate;

            if (Encrypt == null) {
                Encrypt = new List<PublicKey>();
                }
            if (Sign == null) {
                Sign = new List<PublicKey>();
                }

            Encrypt.Add(EncryptKey);
            Sign.Add(SignKey);


            return false;
            }

        
        /// <summary>
        /// For debugging
        /// </summary>
        public virtual void Dump() {
            Trace.WriteLine("Account {0}  <{1}> ({2})", AccountName, EmailAddress, DisplayName);
            foreach (var Connection in Inbound) {
                Connection.Dump();
                }
            foreach (var Connection in Outbound) {
                Connection.Dump();
                }
            }
        }

    /// <summary>
    /// Application protocol enumeration
    /// </summary>
    public enum AppProtocol {
        /// <summary>
        /// SMTP
        /// </summary>
        SMTP = 1,

        /// <summary>
        /// SMTP on the SUBMIT port
        /// </summary>
        SUBMIT = 2,

        /// <summary>
        /// POP
        /// </summary>
        POP3 = 4,

        /// <summary>
        /// IMAP
        /// </summary>
        IMAP4 = 5,

        /// <summary>
        /// Unspecified.
        /// </summary>
        NULL = 0
        };

    /// <summary>
    /// The TLS enhancement mode to use
    /// </summary>
    public enum TLSMode {
        /// <summary>
        /// Use TLS directly, i.e. no TLS upgrade negotiation.
        /// </summary>
        Direct = 1,

        /// <summary>
        /// Negotiate TLS upgrade after cleartext start. E.g. using STARTTLS in SMTP.
        /// </summary>
        Upgrade = 2,

        /// <summary>
        /// No TLS enhancement
        /// </summary>
        None = 0
        }

    }
