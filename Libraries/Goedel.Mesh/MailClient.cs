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

using System.Collections.Generic;
using Goedel.IO;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;

namespace Goedel.Mesh {

    /// <summary>
    /// Base class for the MailClientCatalog class defined in Goedel.Mesh.Platform
    /// </summary>
    public abstract class MailClientCatalog {


        /// <summary>
        /// List of all accounts discovered on the local machine.
        /// </summary>
        public List<MailAccountInfo> Accounts = new List<MailAccountInfo>() ;

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
        public virtual bool GotSMIME => false;

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
        /// <returns>The generated key pair data.</returns>
        public virtual bool GenerateSMIME () {

            // Much of this should probably be turned into convenience methods on the PublicKey class.

            var RootKey = PublicKey.Generate(KeyType.ASK,
                                CryptoCatalog.Default.AlgorithmSignature);

            //var NewCert = new Certificate(RootKey.KeyPair, 
            //    Application.PersonalMaster | Application.CA |
            //    Application.CodeSigning | Application.TimeStamping |
            //    Application.ServerAuth | Application.ClientAuth,
            //    EmailAddress, EmailAddress);
            //NewCert.TBSCertificate.SetValidity(20);

            //NewCert.Sign(Signer.Certificate);



            RootKey.SignCertificate(Application.PersonalMaster | Application.CA, 
                    EmailAddress, RootKey);
            var RootKeyCertificate = RootKey.Certificate.Data;

            var SignKey = PublicKey.Generate(KeyType.ASK,
                                CryptoCatalog.Default.AlgorithmSignature);
            SignKey.SignCertificate(Application.EmailSignature |
                        Application.DataSignature, EmailAddress, RootKey);
            SignKey.X509Chain = new List<byte[]>() { RootKeyCertificate };


            var EncryptKey = PublicKey.Generate(KeyType.AEK, 
                                CryptoCatalog.Default.AlgorithmExchange);
            EncryptKey.SignCertificate(Application.EmailEncryption |
                        Application.DataEncryption, EmailAddress, RootKey);
            EncryptKey.X509Chain = new List<byte[]>() { RootKeyCertificate };


            //var SigningCSR = new CertificationRequest(SignKey.Certificate);
            //SignKey.X509CSR = SigningCSR.DER();

            //var EncryptionCSR = new CertificationRequest(EncryptKey.Certificate);
            //EncryptKey.X509CSR = EncryptionCSR.DER();

            CertificateStore.RegisterTrustedRoot(RootKey.Certificate);
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
            Debug.WriteLine("Account {0}  <{1}> ({2})", AccountName, EmailAddress, DisplayName);
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
