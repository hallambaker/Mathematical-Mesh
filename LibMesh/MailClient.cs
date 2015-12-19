using System.Collections.Generic;
using Goedel.LibCrypto;
using Goedel.LibCrypto.PKIX;
using Goedel.Debug;

namespace Goedel.Mesh {
    public partial class MailClientCatalog {


        /// <summary>
        /// List of all accounts discovered on the local machine.
        /// </summary>
        public List<MailAccountInfo> Accounts = new List<MailAccountInfo>() ;

        /// <summary>
        /// Search local application configuration files to discover account 
        /// details.
        /// </summary>
        /// <returns>List of the accounts found.</returns>
        public static List<MailAccountInfo> FindLocal () {
            var MailClientCatalog = new MailClientCatalog();
            MailClientCatalog.ImportWindowsLiveMail();
            return MailClientCatalog.Accounts;
            }

        /// <summary>
        /// Debug utility, dumps list of accounts to the console.
        /// </summary>
        public virtual void Dump () {
            foreach (var Account in Accounts) {
                Account.Dump();
                }
            }

        }

    /// <summary>
    /// Base class for mail profile information for applications on local machine.
    /// </summary>
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
        /// Does the account have S/MIME parameters already?
        /// </summary>
        public virtual bool GotSMIME {
            get {
                return false;
                }
            }

        /// <summary>
        /// List of keys for signing.
        /// </summary>
        public override List<PublicKey> Sign {
            get { return _Sign; }
            set { _Sign = value;
                if (_Sign != null && _Sign.Count > 0) {
                    CertificateSign = _Sign[0];
                    }
                }

            }

        /// <summary>
        /// List of keys for encryption.
        /// </summary>
        public override List<PublicKey> Encrypt {
            get { return _Encrypt; }
            set {
                _Encrypt = value;
                if (_Encrypt != null && _Encrypt.Count > 0) {
                    CertificateEncrypt = _Encrypt[0];
                    }
                }

            }


        List<PublicKey> _Sign = new List<PublicKey> ();
        List<PublicKey> _Encrypt = new List<PublicKey>();

        /// <summary>
        /// Signing Certificate
        /// </summary>
        public virtual PublicKey CertificateSign {
            get {
                return _CertificateSign;
                }

            set {
                _CertificateSign = value;
                _Sign.Add(_CertificateSign);
                }
            }
        private PublicKey _CertificateSign;

        /// <summary>
        /// Encryption Certificate if different from signing certificate.
        /// </summary>
        public virtual PublicKey CertificateEncrypt {
            get {
                return _CertificateEncrypt;
                }

            set {
                _CertificateEncrypt = value;
                _Encrypt.Add(_CertificateEncrypt);
                }
            }
        private PublicKey _CertificateEncrypt;

        /// <summary>
        /// Create a new profile using the specified configuration data.
        /// </summary>
        public virtual void Create() {
            }

        /// <summary>
        /// Update a found profile to match this profile.
        /// </summary>
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

            CertificateSign = SignKey;
            CertificateEncrypt = EncryptKey;

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
