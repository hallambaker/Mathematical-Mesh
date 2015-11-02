using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Goedel.CryptoLibNG;
using Goedel.Protocol;
using Goedel.Debug;


namespace Goedel.CryptoLibNG.PKIX {

    public partial class Certificate {
        private byte[] _Data;

        /// <summary>
        /// Returns the cached binary value of the certificate. Note that this 
        /// property is only filled when the certificate is signed.
        /// </summary>
        public byte[] Data {
            get { return _Data; }
            }
        
        /// <summary>
        /// High level description of key use.
        /// </summary>
        public Application Application {
            get { return _Application; }
            set { _Application = value; }
            }
        Application _Application;

        /// <summary>
        /// The UDF fingerprint of the keyInfo element.
        /// </summary>
        public string UDF {
            get { return _UDF; }
            }
        string _UDF;

        /// <summary>
        /// The SHA1 fingerprint of the certificate.
        /// </summary>
        public string SHA1 {
            get { return null; }
            }

        /// <summary>
        /// The SHA-2-256 fingerprint of the certificate.
        /// </summary>
        public string SHA256 {
            get { return null; }
            }


        KeyPair _KeyPair;
        /// <summary>
        /// The Certificate Public Key
        /// </summary>
        public KeyPair KeyPair {
            get { return _KeyPair; }
            set { _KeyPair = value; }
            }

        CryptoProviderSignature _CryptoProviderSignature = null;

        /// <summary>
        /// Returns the signature provider associated with the current certificate.
        /// </summary>
        public CryptoProviderSignature CryptoProviderSignature {
            get {
            if (_CryptoProviderSignature == null) {
                _CryptoProviderSignature = KeyPair.SignatureProvider;
                }
                return _CryptoProviderSignature;
                }
            }

        CryptoProviderExchange _CryptoProviderExchange = null;

        /// <summary>
        /// Returns the exchange provider associated with the current certificate.
        /// </summary>
        public CryptoProviderExchange CryptoProviderExchange {
            get {
                if (_CryptoProviderExchange == null) {
                    _CryptoProviderExchange = KeyPair.ExchangeProviderEncrypt;
                    }
                return _CryptoProviderExchange;
                }
            }

        //CryptoProvider _CryptoProvider;

        ///// <summary>
        ///// Cryptographic provider for the certificate.
        ///// </summary>
        //public CryptoProvider CryptoProvider {
        //    get { return _CryptoProvider; }
        //    set { _CryptoProvider = value; }
        //    }




        /// <summary>
        /// Subject Key Identifier
        /// </summary>
        public byte [] SubjectKeyIdentifier {
            get { return KeyPair.GetUDFBytes (); }
            }


        /// <summary>
        /// Create an anonymous certificate with the specified key uses, subject Key and
        /// sign with the specified key.
        /// <para>
        /// Default lifespan is 20 years.
        /// </para>
        /// </summary>
        /// <param name="SubjectKey">Cryptographic provider for the subject key.</param>
        /// <param name="Application">Certificate application(s).</param>
        /// <param name="SigningCertificate">Certificate of signer.</param>
        public Certificate(KeyPair SubjectKey, Application Application,
                    Certificate SigningCertificate) :
                this (SubjectKey, Application) {
            _UDF = SubjectKey.UDF;
            TBSCertificate.SetValidity(20);

            Sign(SigningCertificate);
            this.Application = Application;
            }



        /// <summary>
        /// Create a certificate with the specified subject Key. Note that the template is 
        /// must be completed with calls to set validity etc. before use.
        /// </summary>
        /// <param name="SubjectKey">Cryptographic provider for the subject key.</param>
        /// <param name="Application">Certificate application(s).</param>
        public Certificate(KeyPair SubjectKey, Application Application) {
            _KeyPair = SubjectKey;

            var SubjectName = new Name(SubjectKey).ToList();
            TBSCertificate = new TBSCertificate(SubjectKey, SubjectName);
            }

        /// <summary>
        /// Create a certificate with the specified subject Key. Note that the template is 
        /// must be completed with calls to set validity etc. before use.
        /// </summary>
        /// <param name="SubjectKey">Cryptographic provider for the subject key.</param>
        /// <param name="Application">Certificate application(s).</param>
        public Certificate(CryptoProvider SubjectKey, Application Application) {
            _KeyPair = SubjectKey.KeyPair;
            if (SubjectKey as CryptoProviderSignature != null) {
                _CryptoProviderSignature = SubjectKey as CryptoProviderSignature;
                }
            if (SubjectKey as CryptoProviderExchange != null) {
                _CryptoProviderExchange = SubjectKey as CryptoProviderExchange;
                }

            var SubjectName = new Name(SubjectKey).ToList();
            TBSCertificate = new TBSCertificate(SubjectKey.KeyPair, SubjectName);
            }


        //public Certificate(PublicKey PublicKey, Application Application) {
        //    _KeyPair = PublicKey.KeyPair;

        //    var SubjectName = new Name(SubjectKey).ToList();
        //    TBSCertificate = new TBSCertificate(SubjectKey, SubjectName);
        //    }

        /// <summary>
        /// Certae a certificate from binary data. 
        /// </summary>
        /// <param name="Data">Binary certificate data</param>
        public Certificate(byte[] Data) {
            Goedel.Debug.Trace.WriteLine(Convert.ToBase64String(Data));
            var X509Cert = new X509Certificate2(Data);
            _KeyPair = KeyPair.GetKeyPair(X509Cert.PublicKey.Key);
            TBSCertificate = new TBSCertificate(X509Cert);
            }


        /// <summary>
        /// Sign certificate. The issuer name and key identifier are taken from the
        /// signing certificate.
        /// </summary>
        /// <param name="SigningCertificate">Certificate of signer.</param>
        public void Sign(Certificate SigningCertificate) {
            if (SigningCertificate != null) {
                TBSCertificate.Issuer = SigningCertificate.TBSCertificate.Subject;
                TBSCertificate.SetAuthorityKeyIdentifier(SigningCertificate.SubjectKeyIdentifier);
                Sign(SigningCertificate.CryptoProviderSignature);
                }
            else {
                TBSCertificate.Issuer = TBSCertificate.Subject;
                TBSCertificate.SetAuthorityKeyIdentifier(SubjectKeyIdentifier);
                Sign(CryptoProviderSignature);
                }
            }



        /// <summary>
        /// Sign certificate.
        /// </summary>
        /// <param name="Signer">Cryptographic provider for the signer.</param>
        public void Sign(CryptoProviderSignature Signer) {

            TBSCertificate.Signature = new AlgorithmIdentifier(Signer.OID);
            SignatureAlgorithm = TBSCertificate.Signature;


            var Data = TBSCertificate.DER();
            var SignatureData = Signer.Sign(Data);
            Signature = SignatureData.Integrity;

            _Data = this.DER();
            }


        }

    public partial class AlgorithmIdentifier {
        /// <summary>
        /// Convert a X509Certificate2 Oid structure to an algorithm identifier.
        /// </summary>
        /// <param name="Oid"></param>
        public AlgorithmIdentifier(Oid Oid) {
            }
        }

    }
