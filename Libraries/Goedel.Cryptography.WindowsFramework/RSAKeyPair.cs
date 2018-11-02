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
using Goedel.Utilities;
using Goedel.Cryptography.PKIX;
using Goedel.Cryptography.Standard;

namespace Goedel.Cryptography.Windows {


    /// <summary>
    /// RSA Key Pair
    /// </summary>
    public partial class KeyPairRSAWindows : KeyPairRSA {
        /// <summary>
        /// Return the underlying .NET cryptographic provider.
        /// </summary>
        public override AsymmetricAlgorithm AsymmetricAlgorithm => _Provider;


        private RSA _Provider;
        private RSAParameters PublicParameters;


        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public override IPKIXPrivateKey PKIXPrivateKey => PKIXPrivateKeyRSA;


        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public override IPKIXPublicKey PKIXPublicKey => PKIXPublicKeyRSA;



        /// <summary>
        /// Return private key parameters in PKIX structure
        /// </summary>
        public override PKIXPrivateKeyRSA PKIXPrivateKeyRSA {
            get {
                try {
                    var PrivateParameters = _Provider.ExportParameters(true);
                    return PrivateParameters.RSAPrivateKey();
                    }
                catch (System.Security.Cryptography.CryptographicException) {
                    throw new NotExportable();
                    }
                }
            }

        /// <summary>
        /// Return public key parameters in PKIX structure
        /// </summary>
        public override PKIXPublicKeyRSA PKIXPublicKeyRSA => PublicParameters.RSAPublicKey();

        /// <summary>
        /// The Windows RSA provider.
        /// </summary>
        public RSA Provider {
            get {
                if (_Provider == null) { GetProvider(); }
                return _Provider;
                }
            }

        void GetProvider() {
            _Provider = new RSACryptoServiceProvider();
            _Provider.ImportParameters(PublicParameters);
            }


        /// <summary>
        /// Find a KeyPair with the specified container fingerprint in the local key store.
        /// </summary>
        /// <param name="UDF">Fingerprint of key.</param>
        /// <returns>RSAKeyPair</returns>
        public static  KeyPairRSA FindLocal(string UDF) //=> throw new NYI();
            
            {
            var Provider = PlatformLocateRSAProvider(UDF);
            if (Provider == null) { return null; }
            return new KeyPairRSA(Provider);
        }

    /// <summary>
    /// Return the CryptoAlgorithmID that would be used with the specified base parameters.
    /// </summary>
    /// <param name="Base">The base algorithm</param>
    /// <returns>The computed CryptoAlgorithmID</returns>
    public override CryptoAlgorithmID SignatureAlgorithmID(CryptoAlgorithmID Base) => CryptoAlgorithmID.RSASign | Base.Bulk();



        /// <summary>
        /// Return a PKIX SubjectPublicKeyInfo structure for the public key.
        /// </summary>

        public override SubjectPublicKeyInfo KeyInfoData => new SubjectPublicKeyInfo(CryptoConfig.MapNameToOID("RSA"),
                        PKIXPublicKeyRSA.DER());

        /// <summary>
        /// Return a PKIX SubjectPublicKeyInfo structure for the private key.
        /// </summary>

        public override SubjectPublicKeyInfo PrivateKeyInfoData => new SubjectPublicKeyInfo(CryptoConfig.MapNameToOID("RSA"),
                        PKIXPrivateKeyRSA.DER());


        /// <summary>The supported key uses (e.g. signing, encryption)</summary>
        public override KeyUses KeyUses => KeyUses.Any;



        void PersistKey(CspProviderFlags CspProviderFlags, int KeySize) {
            var PreCSPParameters = new CspParameters() {
                Flags = CspProviderFlags.UseArchivableKey
                };
            var TempProvider = new RSACryptoServiceProvider(KeySize, PreCSPParameters);
            var PrivateParameters = TempProvider.ExportParameters(true);
            PublicParameters = TempProvider.ExportParameters(false);
            TempProvider.Dispose();

            var CspParameters = new CspParameters() { Flags = CspProviderFlags };

            CspParameters.KeyContainerName = ContainerFramework.Name(UDF);
            var NewProvider = new RSACryptoServiceProvider(CspParameters);
            NewProvider.ImportParameters(PrivateParameters);
            _Provider = NewProvider;

            KeySecurity = (KeySecurity & KeySecurity.Exportable) | KeySecurity.Persisted;
            }



        /// <summary>
        /// Generate a KeyPair from a .NET set of parameters.
        /// </summary>
        /// <param name="RSAParameters">The RSA parameters.</param>
        public KeyPairRSAWindows(RSAParameters RSAParameters) : base (RSAParameters) {
            PublicParameters = RSAParameters;

            _Provider = new RSACryptoServiceProvider();
            _Provider.ImportParameters(RSAParameters);
            }


        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns></returns>
        public override KeyPair KeyPairPublic() {
            var Result = new KeyPairRSA(_Provider.ExportParameters(false));
            Assert.True(Result.PublicOnly);
            return Result;
            }


        /// <summary>
        /// Delegate to create a key pair base
        /// </summary>
        /// <param name="PKIXParameters">The parameters to construct from</param>
        /// <returns>The created key pair</returns>
        public static new KeyPair KeyPairPublicFactory(PKIXPublicKeyRSA PKIXParameters) {

            var RSAParameters = PKIXParameters.RSAParameters();
            return new KeyPairRSA(RSAParameters);
            }


        /// <summary>
        /// If true, the provider only provides the public key values.
        /// </summary>
        public override bool PublicOnly => (!(Provider is RSACryptoServiceProvider RSACryptoServiceProvider)
                    || !RSACryptoServiceProvider.PublicOnly);


        /// <summary>
        /// Locate a key stored in the platform cryptographic key store.
        /// </summary>
        /// <param name="UDF"></param>
        /// <returns>cryptographic provider matching the specified fingerprint</returns>
        static RSACryptoServiceProvider PlatformLocateRSAProvider(string UDF) {
            try {
                var Parameters = new CspParameters() {
                    KeyContainerName = ContainerFramework.Name(UDF),
                    Flags = CspProviderFlags.UseExistingKey
                    };
                var Provider = new RSACryptoServiceProvider(Parameters);
                return Provider;
                }
            catch (System.Security.Cryptography.CryptographicException) { // Key not found
                return null;
                }
            }

        /// <summary>
        /// Retrieve the private key from local storage.
        /// </summary>
        public  void GetPrivate() {
            if (!PublicOnly) {
                return;
                }
            //Goedel.Debug.Trace.WriteLine("Get Private for {0}", UDF);

            var cp = new CspParameters() {
                KeyContainerName = ContainerFramework.Name(UDF)
                };

            _Provider = new RSACryptoServiceProvider(cp);

            }

        /// <summary>
        /// Erase the key from the local machine
        /// </summary>
        public  void EraseFromDevice() {
            var cp = new CspParameters() {
                KeyContainerName = ContainerFramework.Name(UDF)
                };

            _Provider = new RSACryptoServiceProvider(cp) {
                PersistKeyInCsp = false
                };
            _Provider.Clear();
            }

         }

    }
