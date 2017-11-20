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

using GCP=Goedel.Cryptography.PKIX;

namespace Goedel.Cryptography {

    /// <summary>
    /// Interface to the platform certificate store. Calls dispatch methods
    /// that have been registered by a subclass.
    /// </summary>
    public partial class CertificateStore {
        static bool _TestMode = false;

        /// <summary>
        /// If set, certificates are marked as test certificates, thus enabling
        /// simple and risk-free cleaning of the cert store(s). Note that
        /// setting KeyPair.TestMode will automatically set certificate store into test
        /// mode.
        /// </summary>
        public static bool TestMode  {
            get { return KeyPair.TestMode | _TestMode; }
            set { _TestMode = value; }
            }

        /// <summary>
        /// Register a certificate in the default Windows store and location
        /// for that type of certificate.
        /// </summary>
        protected delegate void DelegateRegister (GCP.Certificate Certificate) ;

        /// <summary>
        /// The delegate for Register(GCP.Certificate Certificate)
        /// </summary>
        protected static DelegateRegister PlatformRegister;

        /// <summary>
        /// Register a certificate in the default Windows store and location
        /// for that type of certificate.
        /// </summary>
        /// <param name="Certificate">Certificate to register.</param>
        public static void Register(GCP.Certificate Certificate) {
            PlatformRegister(Certificate);
            }



        /// <summary>
        /// Register a certificate in the default Windows store and location
        /// for that type of certificate.
        /// </summary>
        protected delegate void DelegateRegisterTrustedRoot(GCP.Certificate Certificate);

        /// <summary>
        /// The delegate for Register(GCP.Certificate Certificate)
        /// </summary>
        protected static DelegateRegisterTrustedRoot PlatformRegisterTrustedRoot;


        /// <summary>
        /// Register a certificate in the default Windows store and location
        /// for that type of certificate.
        /// </summary>
        /// <param name="Certificate">Certificate to register.</param>
        public static void RegisterTrustedRoot(GCP.Certificate Certificate) {
            PlatformRegisterTrustedRoot(Certificate);
            }


        /// <summary>
        /// Register a certificate in the default Windows store and location
        /// for that type of certificate.
        /// </summary>
        protected delegate void DelegateRegisterTrustedRootByte(byte[] Data);

        /// <summary>
        /// The delegate for Register(GCP.Certificate Certificate)
        /// </summary>
        protected static DelegateRegisterTrustedRootByte PlatformRegisterTrustedRootByte;

        /// <summary>
        /// Register a certificate in the default Windows store and location
        /// for that type of certificate.
        /// </summary>
        /// <param name="Data">Certificate to register.</param>
        public static void RegisterTrustedRoot(byte[] Data) {
            }

        /// <summary>
        /// Register a certificate in the default Windows store and location
        /// for that type of certificate.
        /// </summary>
        protected delegate GCP.Certificate DelegateGet(string Fingerprint);

        /// <summary>
        /// The delegate for Register(GCP.Certificate Certificate)
        /// </summary>
        protected static DelegateGet PlatformGet;


        /// <summary>
        /// Find the certificate with a specified fingerprint.
        /// </summary>
        /// <param name="Fingerprint">Fingerprint of public key</param>
        /// <returns>Parsed certificate</returns>
        public static GCP.Certificate Get(string Fingerprint) {
            return PlatformGet (Fingerprint);
            }


        /// <summary>
        /// Register a certificate in the default Windows store and location
        /// for that type of certificate.
        /// </summary>
        protected delegate void DelegateClean();

        /// <summary>
        /// The delegate for Register(GCP.Certificate Certificate)
        /// </summary>
        protected static DelegateClean PlatformClean;

        /// <summary>
        /// Clean all certificate stores to remove test certificates
        /// </summary>
        public static void Clean() {
            PlatformClean();
            }

        }
    }
