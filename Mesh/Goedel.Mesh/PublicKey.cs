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

    /// <summary>
    /// Mesh Key types
    /// </summary>
    public enum KeyType {
        /// <summary>
        /// Personal Master Key
        /// </summary>
        PMSK,

        /// <summary>
        /// Personal Master Escrow Key
        /// </summary>
        PMEK,

        /// <summary>
        /// Personal Master Online Signing Key
        /// </summary>
        POSK,

        /// <summary>
        /// Device Signing Key 
        /// </summary>
        DSK,

        /// <summary>
        /// Device authentication key 
        /// </summary>
        DAK,

        /// <summary>
        /// Device Encryption Key
        /// </summary>
        DEK,

        /// <summary>
        /// Application Signing Key
        /// </summary>
        ASK,

        /// <summary>
        /// Application Authentication Key
        /// </summary>
        AAK,

        /// <summary>
        /// Application Encryption Key
        /// </summary>
        AEK,

        /// <summary>
        /// Unspecified.
        /// </summary>
        Unknown
        }

    /// <summary>
    /// Extension methods
    /// </summary>
    public static partial class Extension {

        /// <summary>
        /// Return the algorithm class of a key type
        /// </summary>
        /// <param name="KeyType">The Mesh key type</param>
        /// <returns>The cryptographic algorithm type to use.</returns>
        public static CryptoAlgorithmClass AlgorithmClass(this KeyType KeyType) {

            switch (KeyType) {
                case KeyType.PMSK:
                case KeyType.POSK:
                case KeyType.DSK:
                case KeyType.ASK: {
                    return CryptoAlgorithmClass.Signature;
                    }
                case KeyType.PMEK:
                case KeyType.DEK:
                case KeyType.AEK: {
                    return CryptoAlgorithmClass.Exchange;
                    }
                case KeyType.DAK:
                case KeyType.AAK: {
                    return CryptoAlgorithmClass.Exchange;
                    }
                }
            return CryptoAlgorithmClass.NULL;
            }

        }


    public partial class PublicKey {
        ///// <summary>
        ///// Return the initial key security level for a key type
        ///// </summary>
        ///// <param name="KeyType">Type of key</param>
        ///// <returns>Initial security level</returns>
        //public static KeyStorage GetKeySecurity(KeyType KeyType) {
        //    switch (KeyType) {
        //        case KeyType.DSK:
        //        case KeyType.DEK:
        //        case KeyType.DAK: {
        //            return KeyStorage.Device;
        //            }
        //        case KeyType.ASK:
        //        case KeyType.AEK:
        //        case KeyType.AAK:
        //            {
        //            return KeyStorage.Exportable;
        //            }
        //        case KeyType.PMSK:
        //        case KeyType.POSK:
        //        case KeyType.PMEK: {
        //            return KeyStorage.Master;
        //            }
        //        }
        //    return KeyStorage.Ephemeral;
        //    }

        //public List<Certificate> Chain;

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



        /// <summary>
        /// The type of key
        /// </summary>
        public KeyType KeyType { get; set; } = KeyType.Unknown;

        private Certificate _Certificate;


        // TODO: Fix this mess PKIX cert key handling

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
 


        ///// <summary>
        ///// Generate a new key pair and return a PublicKey object for the public 
        ///// parameters.
        ///// </summary>
        ///// <param name="KeyType">The mest key type.</param>
        ///// <param name="CryptoAlgorithmID">The algorithm to generate keys for.</param>
        ///// <returns>The generated key pair</returns>
        //public static PublicKey Generate(KeyType KeyType, CryptoAlgorithmID CryptoAlgorithmID) {

        //    //var KeyClass = KeyType.AlgorithmClass();
        //    //CryptoProviderAsymmetric CryptoProvider;
        //    //if (KeyClass == CryptoAlgorithmClass.Signature) {
        //    //    CryptoProvider = CryptoCatalog.Default.GetSignature(CryptoAlgorithmID);
        //    //    }
        //    //else {
        //    //    CryptoProvider = CryptoCatalog.Default.GetExchange(CryptoAlgorithmID);
        //    //    }
        //    //var KeySecurity = GetKeySecurity(KeyType);
        //    //CryptoProvider.Generate(KeySecurity);
        //    //var KeyPair = CryptoProvider.KeyPair;



        //    var KeyPairNew = KeyPair.Factory(CryptoAlgorithmID, GetKeySecurity(KeyType));
        //    return new PublicKey (KeyPairNew);
        //    }

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
