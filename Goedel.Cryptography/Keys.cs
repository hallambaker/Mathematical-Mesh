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
using Goedel.Cryptography.PKIX;

namespace Goedel.Cryptography {

    /// <summary>
    /// Describes a reference to a key
    /// </summary>
    public class KeyHandle {

        string _UDF;

        /// <summary>
        /// UDF fingerprint of the key
        /// </summary>
        public string UDF {
            get { return _UDF; }
            set { _UDF = value; }
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UDF"></param>
        public KeyHandle(string UDF) {
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UDF"></param>
        /// <param name="Application"></param>
        public KeyHandle(string UDF, string Application) {
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UDF"></param>
        /// <param name="Application"></param>
        /// <param name="Name"></param>
        public KeyHandle(string UDF, string Application, string Name) {
            }

        /// <summary>
        /// Form a KeyHandle from an end entity certificate 
        /// </summary>
        /// <param name="Certificate"></param>
        public KeyHandle(Certificate Certificate) {

            }

        /// <summary>
        /// Form a KeyHandle from a certificate chain.
        /// </summary>
        /// <param name="Certificates">Certificate Chain</param>
        public KeyHandle(List<Certificate> Certificates) {

            }

        Certificate _Certificate;

        /// <summary>
        /// X.509 v3 Certificate for this key and set of uses.
        /// </summary>
        public Certificate Certificate {
            get { return _Certificate; }
            set { _Certificate = value; }
            }


        List<Certificate> _CertificateChain;

        /// <summary>
        /// X.509 v3 Certificate chain validating this certificate.
        /// </summary>
        public List<Certificate> CertificateChain {
            get { return _CertificateChain; }
            set { _CertificateChain = value; }
            }

        }

    /// <summary>
    /// Base class for all cryptographic keys.
    /// </summary>
    public abstract class CryptoKey  {

        CryptoAlgorithmID _CryptoAlgorithmID;

        /// <summary>
        /// Cryptographic Algorithm Identifier
        /// </summary>
        public CryptoAlgorithmID CryptoAlgorithmID {
            get { return _CryptoAlgorithmID; }
            set { _CryptoAlgorithmID = value; }
            }


        /// <summary>
        /// UDF fingerprint of the key
        /// </summary>
        public virtual string UDF {
            get { return null; }
            }

        }




    /// <summary>
    /// Base class for all cryptographic key pairs.
    /// </summary>
    public abstract partial class KeyPair : CryptoKey {
        static bool _TestMode = false;

        /// <summary>
        /// Return the underlying .NET crypto provider.
        /// </summary>
        public abstract AsymmetricAlgorithm AsymmetricAlgorithm {
            get;
            }

        /// <summary>
        /// If true, keys will be created in containers prefixed with the name
        /// "test:" to allow them to be easily identified and cleaned up.
        /// </summary>
        public static bool TestMode {
            get { return _TestMode; }
            set { _TestMode = value; }
            }



        /// <summary>
        /// Returns a signature provider for the key (if the private portion is available).
        /// </summary>
        public abstract CryptoProviderSignature SignatureProvider {
            get;
            }

        /// <summary>
        /// Returns a signature provider for the key (if the public portion is available).
        /// </summary>
        public abstract CryptoProviderSignature VerificationProvider {
            get;
            }

        /// <summary>
        /// Returns an encryption provider for the key (if the public portion is available)
        /// </summary>
        public abstract CryptoProviderExchange ExchangeProviderEncrypt {
            get;
            }

        /// <summary>
        /// Returns an encryption provider for the key (if the public portion is available)
        /// </summary>
        public abstract CryptoProviderExchange ExchangeProviderDecrypt {
            get;
            }

        /// <summary>
        /// Search for the local key with the specified UDF fingerprint.
        /// </summary>
        public abstract void GetPrivate();


        /// <summary>
        /// Search all the local machine stores to find a key pair with the specified
        /// fingerprint
        /// </summary>
        /// <param name="UDF"></param>
        /// <returns></returns>
        public static KeyPair FindLocal(string UDF) {
            var FindRSA = RSAKeyPair.FindLocal(UDF);
            if (FindRSA != null) {
                return FindRSA;
                }

            return null;
            }


        /// <summary>
        /// The public key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public abstract SubjectPublicKeyInfo KeyInfoData { get; } 

        string _UDF = null;
        /// <summary>
        /// Returns the UDF fingerprint of the current key as a string.
        /// </summary>
        public override string UDF {
            get {
                if (_UDF == null) _UDF = Goedel.Cryptography.UDF.ToString(GetUDFBytes());
                return _UDF;
                }
            }



        /// <summary>
        /// Returns the UDF fingerprint of the current key as a byte array.
        /// </summary>
        public byte[] GetUDFBytes() {
            return Goedel.Cryptography.UDF.FromKeyInfo(KeyInfoData.DER());
            }

        /// <summary>
        /// Get the key associated with a system asymmetric provider.
        /// </summary>
        /// <param name="AsymmetricAlgorithm">Asymmetric provider.</param>
        /// <returns></returns>
        public static KeyPair GetKeyPair(AsymmetricAlgorithm AsymmetricAlgorithm) {

            var AsRSA = AsymmetricAlgorithm as RSACryptoServiceProvider;
            if (AsRSA != null) {
                return new RSAKeyPair(AsRSA);
                }

            return null;
            }


        }


    /// <summary>
    /// Utility class, not visible outside the assembly. Contains public key 
    /// utility functions that are shared by the signature and exchange 
    /// providers.
    /// </summary>
    public partial class RSAKeyPair : KeyPair {
        /// <summary>
        /// Return the underlying .NET cryptographic provider.
        /// </summary>
        public override AsymmetricAlgorithm AsymmetricAlgorithm {
            get { return _Provider; }
            }


        private RSACryptoServiceProvider _Provider;
        private RSAParameters _Parameters;


        /// <summary>
        /// Returns a signature provider for the key (if the private portion is available).
        /// </summary>
        public override CryptoProviderSignature SignatureProvider {
            get {
                GetPrivate();
                return new CryptoProviderSignatureRSA(this);
                }
            }

        /// <summary>
        /// Returns a signature provider for the key (if the private portion is available).
        /// </summary>
        public override CryptoProviderSignature VerificationProvider {
            get { return new CryptoProviderSignatureRSA(this); }
            }


        /// <summary>
        /// Returns an encryption provider for the key (if the public portion is available)
        /// </summary>
        public override CryptoProviderExchange ExchangeProviderEncrypt {
            get { return new CryptoProviderExchangeRSA(this); }
            }

        /// <summary>
        /// Returns an encryption provider for the key (if the public portion is available)
        /// </summary>
        public override CryptoProviderExchange ExchangeProviderDecrypt {
            get {
                GetPrivate();
                return new CryptoProviderExchangeRSA(this); }
            }

        /// <summary>
        /// The Windows RSA provider.
        /// </summary>
        public RSACryptoServiceProvider Provider {
            get {

                if (_Provider == null) { GetProvider ();}

                return _Provider; }
            }

        void GetProvider () {
            _Provider = new RSACryptoServiceProvider();
            _Provider.ImportParameters(_Parameters);
            }


        /// <summary>
        /// Find a KeyPair with the specified container fingerprint in the local key store.
        /// </summary>
        /// <param name="UDF">Fingerprint of key.</param>
        /// <returns>RSAKeyPair</returns>
        public static new RSAKeyPair FindLocal(string UDF) {
            var Provider = PlatformLocateRSAProvider(UDF);
            if (Provider == null) return null;
            return new RSAKeyPair(Provider);
            }





        /// <summary>
        /// Return a PKIX SubjectPublicKeyInfo structure for the key.
        /// </summary>

        public override SubjectPublicKeyInfo KeyInfoData {
            get { return GetKeyInfo(); }
            }

        SubjectPublicKeyInfo GetKeyInfo() {
            var RSAParameters = Provider.ExportParameters(false);
            var RSAPublicKey = new RSAPublicKey(RSAParameters);
            var Result = new SubjectPublicKeyInfo(CryptoConfig.MapNameToOID("RSA"), 
                        RSAPublicKey.DER());

            return Result;
            }

        /// <summary>
        /// Generate an ephemeral RSA key with the specified key size.
        /// </summary>
        /// <param name="KeySize">Size of key in multiples of 64 bits.</param>
        public RSAKeyPair(int KeySize)
            : this(KeySize, true) {
            }

        /// <summary>
        /// Generate an ephemeral RSA key with the specified key size.
        /// </summary>
        /// <param name="KeySize">Size of key in multiples of 64 bits.</param>
        /// <param name="Exportable">If true, key may be exported, otherwise machine bound.</param>
        public RSAKeyPair(int KeySize, bool Exportable) {
            var Parameters = new CspParameters();
            if (Exportable) {
                Parameters.Flags = CspProviderFlags.UseArchivableKey | CspProviderFlags.CreateEphemeralKey;
                }
            else {
                Parameters.Flags = CspProviderFlags.UseNonExportableKey | CspProviderFlags.CreateEphemeralKey;
                }
            _Provider = new RSACryptoServiceProvider(KeySize, Parameters);
            }


        /// <summary>
        /// Create a new KeyPair with the specified container fingerprint.
        /// </summary>
        /// <param name="UDF">Fingerprint of key.</param>
        public RSAKeyPair(string UDF) {
            _Provider = PlatformLocateRSAProvider(UDF);
            }









        /// <summary>
        /// Generate a KeyPair from a .NET Provider.
        /// </summary>
        /// <param name="RSACryptoServiceProvider"></param>
        public RSAKeyPair(RSACryptoServiceProvider RSACryptoServiceProvider) {
            _Provider = RSACryptoServiceProvider;
            }


        /// <summary>
        /// Generate a KeyPair from a .NET set of parameters.
        /// </summary>
        /// <param name="RSAParameters">The RSA parameters.</param>
        public RSAKeyPair(RSAParameters RSAParameters) {
            _Parameters = RSAParameters;

            _Provider = new RSACryptoServiceProvider();
            _Provider.ImportParameters(RSAParameters);
            }


        /// <summary>
        /// Makes a key persistent on the local machine with the specified level of
        /// protection.
        /// </summary>
        /// <param name="KeySecurity">Key protection level to be applied.</param>
        public void Persist (KeySecurity KeySecurity) {

            if (Provider == null) throw new System.Exception ("No provider set");

            var Parameters = new CspParameters();
            switch (KeySecurity) {
                case KeySecurity.Master:
                Parameters.Flags = CspProviderFlags.UseArchivableKey | CspProviderFlags.UseUserProtectedKey;
                Parameters.Flags = CspProviderFlags.NoFlags;
                break;
                case KeySecurity.Admin:
                Parameters.Flags = CspProviderFlags.UseArchivableKey | CspProviderFlags.UseUserProtectedKey;
                Parameters.Flags = CspProviderFlags.NoFlags;
                break;
                case KeySecurity.Device:
                Parameters.Flags = CspProviderFlags.UseNonExportableKey;
                break;
                case KeySecurity.Ephemeral:
                Parameters.Flags = CspProviderFlags.UseNonExportableKey;
                break;
                }

            Parameters.KeyContainerName = ContainerName(UDF);

            var NewProvider = new RSACryptoServiceProvider(Parameters);
            var KeyParams = Provider.ExportParameters(true);

            NewProvider.ImportParameters(KeyParams);
            Provider.Dispose();
            _Provider = NewProvider;

            if (KeySecurity == KeySecurity.Master) {
                KeyParams = Provider.ExportParameters(true);
                }
            }


        }
    }
