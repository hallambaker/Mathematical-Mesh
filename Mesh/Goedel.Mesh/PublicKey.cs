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
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh {




    public partial class PublicKey {


        /// <summary>
        /// The cryptolib representation of the Key Pair. This is the point of access
        /// for all cryptolib operations. 
        /// </summary>
        protected KeyPair _KeyPair;

        /// <summary>
        /// The cryptolib representation of the Key Pair. This is the point of access
        /// for all cryptolib operations. 
        /// </summary>
        public virtual KeyPair KeyPair {
            get {
                if (_KeyPair == null) {
                    _KeyPair = GetKeyPair();
                    }

                return _KeyPair;
                }
            set {
                _KeyPair = value;
                UDF = KeyPair.UDF;
                }
            }

        private Certificate _Certificate;


        // Hack: Fix this mess PKIX cert key handling

        /// <summary>
        /// The PKIX Certificate for the key (if it exists). This is the 
        /// deserialized version of X509Certificate.
        /// </summary>
        public Certificate Certificate {
            get {
                if (_Certificate == null) {
                    _Certificate = null; // NYI Parse X509Certificate to get Certificate 
                    }
                return _Certificate;
                }
            set {
                _Certificate = value;
                X509Certificate = _Certificate.Data;
                }
            }

        /// <summary>
        /// Unpack that the public key parameters match the UDF fingerprint.
        /// </summary>
        /// <returns>true if the verification succeeds, false otherwise.</returns>

        public bool Verify() => Verify(UDF);

        /// <summary>
        /// Verify the keypair parameters match the fingerprint.
        /// </summary>
        /// <param name="TestUDF">The fingerprint value.</param>
        /// <returns>true if the verification succeeds, false otherwise.</returns>
        public bool Verify (string TestUDF) { 
            var KeyPair = GetKeyPair();
            if (KeyPair.UDF == TestUDF) {
                _KeyPair = KeyPair;
                return true;
                }

            return false;
            }


        private KeyPair GetKeyPair () {
            if (PrivateParameters != null) {
                return PrivateParameters.GetKeyPair(KeySecurity.Bound);
                }
            if (PublicParameters != null) {
                return PublicParameters.GetKeyPair(KeySecurity.Bound);
                }
            Assert.Fail(NYI.Throw,"Need to construct from the private parameters.");

            return null;
            }
 


        /// <summary>
        /// Default Constructor
        /// </summary>
        public PublicKey () {
            }

        /// <summary>
        /// Return a PublicKey object for the specified KeyPair
        /// </summary>
        /// <param name="KeyPair">The key pair to bind.</param>
        /// <returns>The generated key pair</returns>
        public PublicKey (KeyPair KeyPair) {
            this.KeyPair = KeyPair;
            PublicParameters = Key.GetPublic(KeyPair);
            }


        /// <summary>
        /// Create a Private Parameters property that contains the 
        /// private parameters of the key.
        /// </summary>
        public void ExportPrivateParameters() {
            if (KeyPair.GetType() == typeof(KeyPairBaseRSA)) {
                PrivateParameters = new PrivateKeyRSA(KeyPair as KeyPairBaseRSA);
                }
            }



        /// <summary>
        /// Create a provider object that includes the private key parameters and add this
        /// to the certificate.
        /// </summary>
        public void ImportPrivateParameters() {
            if (KeyPair.GetType() == typeof(KeyPairBaseRSA)) {
                if (PrivateParameters.GetType() != typeof(PrivateKeyRSA)) {
                    throw new Exception("Invalid key description");
                    }

                //var RSAKeyPair = KeyPair as RSAKeyPair;
                var PrivateKeyRSA = PrivateParameters as PrivateKeyRSA;
                //var RSAKeyPair = KeyPair as RSAKeyPair;

                throw new NYI("RSA Key Pair Management");


                //var RSAParameters = PrivateKeyRSA.Parameters;
                //KeyPair = new RSAKeyPair(RSAParameters);
                //Certificate.KeyPair = KeyPair;

                //if (X509Chain != null) {
                //    foreach (var cert in X509Chain) {
                //        CertificateStore.RegisterTrustedRoot(cert);
                //        }
                //    }

                //CertificateStore.Register(Certificate);
                }
            }



        /// <summary>
        /// Create a self signed root certificate
        /// </summary>
        /// <param name="PKIXUse">Bit mask specifying certificate uses.</param>
        public void SelfSignCertificate(Application PKIXUse) => Certificate = new Certificate(_KeyPair, PKIXUse, null);

        /// <summary>
        /// Create an application or intermediary certificate
        /// </summary>
        /// <param name="PKIXUse">Bit mask specifying certificate uses.</param>
        /// <param name="Signer">The signing key (which must have an attached certificate).</param>
        public void SignCertificate(Application PKIXUse, PublicKey Signer) => Certificate = new Certificate(_KeyPair, PKIXUse, Signer.Certificate);

        /// <summary>
        /// Create an application certificate with the specified SubjectAltName.
        /// </summary>
        /// <param name="PKIXUse">Bit mask specifying certificate uses.</param>
        /// <param name="SubjectAltName">The subjectAltName. Must be a DNS domain name
        /// or a RFC822 email address.</param>
        /// <param name="Signer">The signing key (which must have an attached certificate).</param>
        public void SignCertificate(Application PKIXUse, string SubjectAltName, PublicKey Signer) {
            //NB it is essential that the assignment to the Certificate property
            //takes place AFTER the cert is signed. Otherwise the value of X509Certificate
            // is not set correctly.
            var NewCert = new Certificate(_KeyPair, PKIXUse, SubjectAltName, SubjectAltName);
            NewCert.Sign(Signer.Certificate);

            Certificate = NewCert;
            }


        }

    }
