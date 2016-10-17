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
using System.Security.Cryptography.X509Certificates;
using Goedel.Cryptography;

using Goedel.Debug;


namespace Goedel.Cryptography.PKIX {

    /// <summary>
    /// Backing class for managing X.509v3 Certificates using the 
    /// native C# parser code.
    /// </summary>
    public partial class Certificate {
        private byte[] _Data;

        /// <summary>
        /// Returns the cached binary value of the certificate. Note that this 
        /// property is only filled when the certificate is signed.
        /// </summary>
        public byte[] Data {
                
            get {
                if (_Data == null) {
                    _Data = DER();
                    }
                return _Data; }
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
        public byte[] SHA1 {
            get {
                if (_SHA1 == null) {
                    _SHA1 = Goedel.Cryptography.UDF.SHA1(Data);
                    }
                return _SHA1;
                }
            }
        byte[] _SHA1;

        /// <summary>
        /// The SHA-2-256 fingerprint of the certificate.
        /// </summary>
        public byte[] SHA256 {
            get {
                if (_SHA256 == null) {
                    _SHA256 = Goedel.Cryptography.UDF.SHA256(Data);
                    }
                return _SHA256;
                }
            }
        byte[] _SHA256;

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


        /// <summary>
        /// Subject Key Identifier
        /// </summary>
        public byte[] SubjectKeyIdentifier {
            get { return KeyPair.GetUDFBytes(); }
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
                this(SubjectKey, Application) {
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
        /// <param name="Subject">Subject name.</param>
        /// <param name="SubjectAltName">The certificate subject altname</param>
        public Certificate(KeyPair SubjectKey, Application Application,
                    string Subject,
                    string SubjectAltName) {
            _KeyPair = SubjectKey;

            var SubjectName = new Name(Subject).ToList();
            TBSCertificate = new TBSCertificate(SubjectKey, SubjectName);
            TBSCertificate.SetProfile(Application);
            TBSCertificate.SetSubjectAltName(SubjectAltName);
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





        /// <summary>
        /// Create a certificate from binary data. 
        /// </summary>
        /// <param name="Data">Binary certificate data</param>
        public Certificate(byte[] Data) {
            //Goedel.Debug.Trace.WriteLine(Convert.ToBase64String(Data));
            _Data = Data;
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
                TBSCertificate.SetSubjectKeyIdentifier(SubjectKeyIdentifier);
                TBSCertificate.SetAuthorityKeyIdentifier(SigningCertificate.SubjectKeyIdentifier);
                Sign(SigningCertificate.CryptoProviderSignature);
                }
            else {
                Sign();
                }
            }

        /// <summary>
        /// Self-sign certificate. The issuer name and key identifier 
        /// are taken from the TBS certificate.
        /// </summary>
        public void Sign() {
            TBSCertificate.Issuer = TBSCertificate.Subject;
            TBSCertificate.SetSubjectKeyIdentifier(SubjectKeyIdentifier);
            TBSCertificate.SetAuthorityKeyIdentifier(SubjectKeyIdentifier);
            //TBSCertificate.SetKeyUsage();
            //TBSCertificate.SetSubjectAltName();
            //TBSCertificate.SetBasicConstraints(false, 0);
            //TBSCertificate.SetExtendedKeyUsage();
            //Key usage?
            //subject altname?
            // Basic constraints?


            Sign(CryptoProviderSignature);
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

        ///// <summary>
        ///// Create a self signed root certificate with the specified
        ///// parameters.
        ///// </summary>
        ///// <param name="SubjectKey">Cryptographic provider for the signer.</param>
        ///// <param name="SubjectName"></param>
        ///// <returns></returns>
        ///// 

        //public static Certificate CreateRoot(
        //                CryptoProviderSignature SubjectKey,
        //                string SubjectName) {
        //    var Certificate = new Certificate(SubjectKey,
        //        Application.Root);
        //    return null;
        //    }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="SubjectKey">Subject key to be signed.</param>
        ///// <param name="SubjectName">Subject Name</param>
        ///// <returns></returns>
        //public static Certificate CreateIntermediate(
        //                CryptoProviderSignature SubjectKey,
        //                string SubjectName) {
        //    var Certificate = new Certificate(SubjectKey,
        //        Application.CA);
        //    Certificate.TBSCertificate.Subject = Name.ToName(SubjectName);
        //    return null;
        //    }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="SubjectKey"></param>
        ///// <param name="Application">Application use(s)</param>
        ///// <param name="Account"></param>
        ///// <param name="SubjectName"></param>
        ///// <returns></returns>
        //public static Certificate CreateEndEntity(
        //                CryptoProviderAsymmetric SubjectKey,
        //                Application Application,
        //                string Account,
        //                string SubjectName) {
        //    var Certificate = new Certificate(SubjectKey, Application);
        //    Certificate.TBSCertificate.Subject = Name.ToName(SubjectName);
        //    Certificate.TBSCertificate.SetSubjectAltName(Account);
        //    return null;
        //    }


        }

    public partial class AlgorithmIdentifier {
        /// <summary>
        /// Convert a X509Certificate2 Oid structure to an algorithm identifier.
        /// </summary>
        /// <param name="Oid"></param>
        public AlgorithmIdentifier(Oid Oid) {
            }
        }

    public partial class CertificationRequest {

        /// <summary>
        /// Construct a certification request.
        /// </summary>
        public CertificationRequest() {
            CertificationRequestInfo = new CertificationRequestInfo();
            }

        /// <summary>
        /// Construct a certification request for the specified certificate.
        /// </summary>
        /// <param name="Certificate"></param>
        public CertificationRequest(Certificate Certificate) {
            CertificationRequestInfo = new CertificationRequestInfo();
            CertificationRequestInfo.Subject =
                Certificate.TBSCertificate.Subject;
            CertificationRequestInfo.SubjectPublicKeyInfo =
                Certificate.TBSCertificate.SubjectPublicKeyInfo;
            Sign(Certificate.CryptoProviderSignature);
            }



        /// <summary>
        /// Sign the request
        /// </summary>
        /// <param name="SigningKey"></param>
        public void Sign(CryptoProviderSignature SigningKey) {
            SignatureAlgorithm = new AlgorithmIdentifier(SigningKey.OID);
            var SignatureData = SigningKey.Sign(CertificationRequestInfo.DER());
            Signature = SignatureData.Integrity;
            }

        /// <summary>
        /// Set the subject name.
        /// </summary>
        /// <param name="name"></param>
        public void SetSubject(string name) {
            CertificationRequestInfo.Subject = Name.ToName(name);
            }

        ///// <summary>
        ///// Set the subject key
        ///// </summary>
        ///// <param name="RSAPublicKey"></param>
        //public void SetSubjectKey(RSAPublicKey RSAPublicKey) {
        //    SetSubjectKey(Algorithm.RSA, RSAPublicKey.DER());
        //    }


        //public void SetSubjectKey(Algorithm Algorithm, byte[] KeyData) {
        //    CertificationRequestInfo.SubjectPublicKeyInfo =
        //                new SubjectPublicKeyInfo(Algorithm, KeyData);
        //    }

        }


    public partial class CertificationRequestInfo : Goedel.ASN1.Root {
        /// <summary>
        /// Create an empty CertificationRequestInfo class with version 1.0
        /// </summary>
        public CertificationRequestInfo() {
            Version = 0;
            }
        }
    }
