﻿//   Copyright © 2015 by Comodo Group Inc.
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

using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

using System;

namespace Goedel.Mesh {




    public partial class KeyData {


        /// <summary>
        /// The cryptolib representation of the Key Pair. This is the point of access
        /// for all cryptolib operations. 
        /// </summary>
        CryptoKey keyPair;

        /// <summary>
        /// The cryptolib representation of the Key Pair. This is the point of access
        /// for all cryptolib operations. 
        /// </summary>
        public virtual CryptoKey CryptoKey {
            get {
                if (keyPair == null) {
                    keyPair = GetKeyPair();
                    }

                return keyPair;
                }
            set {
                keyPair = value;
                UDF = CryptoKey.KeyIdentifier;
                }
            }

        private Certificate certificate;


        // Hack: Fix this mess PKIX cert key handling

        /// <summary>
        /// The PKIX Certificate for the key (if it exists). This is the 
        /// deserialized version of X509Certificate.
        /// </summary>
        public Certificate Certificate {
            get {
                if (certificate == null) {
                    certificate = null; // NYI Parse X509Certificate to get Certificate 
                    }
                return certificate;
                }
            set {
                certificate = value;
                X509Certificate = certificate.Data;
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
        public bool Verify(string TestUDF) {
            var KeyPair = GetKeyPair();
            if (KeyPair.KeyIdentifier == TestUDF) {
                keyPair = KeyPair;
                return true;
                }

            return false;
            }


        /// <summary>
        /// Return a <see cref="KeyPair"/> instance for the key parameters.
        /// </summary>
        /// <returns>The created key pair.</returns>
        public KeyPair GetKeyPair(KeySecurity keySecurity = KeySecurity.Bound) {
            if (PrivateParameters != null) {
                return PrivateParameters.GetKeyPair(keySecurity);
                }
            if (PublicParameters != null) {
                return PublicParameters.GetKeyPair(keySecurity);
                }
            Assert.Fail(NYI.Throw, "No key parameters specified");

            return null;
            }

        /// <summary>
        /// Return a <see cref="KeyPairAdvanced"/> instance for the key parameters.
        /// </summary>
        /// <returns>The created key pair.</returns>
        public KeyPairAdvanced GetKeyPairAdvanced(
                KeySecurity keySecurity = KeySecurity.Bound
                ) => GetKeyPair(keySecurity) as KeyPairAdvanced;




        /// <summary>
        /// Default Constructor
        /// </summary>
        public KeyData() {
            }

        /// <summary>
        /// Return a PublicKey object for the specified KeyPair
        /// </summary>
        /// <param name="cryptoKey">The key pair to bind.</param>
        /// <returns>The generated key pair</returns>
        public KeyData(CryptoKey cryptoKey, bool export = false) {
            CryptoKey = cryptoKey;
            if (cryptoKey is KeyPair keyPair) {
                PublicParameters = Key.GetPublic(keyPair);
                }
            if (export) {
                ExportPrivateParameters();
                }
            }

        public KeyData(IKeyAdvancedPrivate keyAdvancedPrivate) =>
            PrivateParameters = keyAdvancedPrivate switch {
                IKeyPrivateECDH keyPrivateECDH => new PrivateKeyECDH(keyPrivateECDH),
                _ => throw new NYI()
                };

 



        /// <summary>
        /// Create a Private Parameters property that contains the 
        /// private parameters of the key.
        /// </summary>
        public void ExportPrivateParameters() =>
            PrivateParameters = CryptoKey switch {
                KeyPairBaseRSA keyPairBaseRSA => new PrivateKeyRSA(keyPairBaseRSA),
                KeyPairECDH keyPairECDH => new PrivateKeyECDH (keyPairECDH),
                KeyPairDH keyPairDH => new PrivateKeyDH(keyPairDH),
                _ => throw new NYI()
                };




        /// <summary>
        /// Create a provider object that includes the private key parameters and add this
        /// to the certificate.
        /// </summary>
        public void ImportPrivateParameters() {
            if (CryptoKey.GetType() == typeof(KeyPairBaseRSA)) {
                if (PrivateParameters.GetType() != typeof(PrivateKeyRSA)) {
                    throw new Exception("Invalid key description");
                    }

                //var RSAKeyPair = KeyPair as RSAKeyPair;
                var PrivateKeyRSA = PrivateParameters as PrivateKeyRSA;
                //var RSAKeyPair = KeyPair as RSAKeyPair;

                throw new NYI("RSA Key Pair Management");
                }
            }



        /// <summary>
        /// Create a self signed root certificate
        /// </summary>
        /// <param name="PKIXUse">Bit mask specifying certificate uses.</param>
        public void SelfSignCertificate(Application PKIXUse) => Certificate = new Certificate(keyPair as KeyPair, PKIXUse, null);

        /// <summary>
        /// Create an application or intermediary certificate
        /// </summary>
        /// <param name="PKIXUse">Bit mask specifying certificate uses.</param>
        /// <param name="Signer">The signing key (which must have an attached certificate).</param>
        public void SignCertificate(Application PKIXUse, KeyData Signer) => Certificate = new Certificate(keyPair as KeyPair, PKIXUse, Signer.Certificate);

        /// <summary>
        /// Create an application certificate with the specified SubjectAltName.
        /// </summary>
        /// <param name="PKIXUse">Bit mask specifying certificate uses.</param>
        /// <param name="SubjectAltName">The subjectAltName. Must be a DNS domain name
        /// or a RFC822 email address.</param>
        /// <param name="Signer">The signing key (which must have an attached certificate).</param>
        public void SignCertificate(Application PKIXUse, string SubjectAltName, KeyData Signer) {
            //NB it is essential that the assignment to the Certificate property
            //takes place AFTER the cert is signed. Otherwise the value of X509Certificate
            // is not set correctly.
            var NewCert = new Certificate(keyPair as KeyPair, PKIXUse, SubjectAltName, SubjectAltName);
            NewCert.Sign(Signer.Certificate);

            Certificate = NewCert;
            }


        }

    }
