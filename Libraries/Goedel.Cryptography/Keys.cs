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
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

namespace Goedel.Cryptography {

    /// <summary>
    /// Describes a reference to a key
    /// </summary>
    public class KeyHandle {

        /// <summary>
        /// UDF fingerprint of the key
        /// </summary>
        public string UDF { get; set; }

        /// <summary>
        /// Construct by key fingerprint
        /// </summary>
        /// <param name="UDF">Fingerprint of the key.</param>
        public KeyHandle(string UDF) {
            }

        /// <summary>
        /// Construct by key fingerprint and use
        /// </summary>
        /// <param name="UDF">Fingerprint of the key.</param>
        /// <param name="Application">The use.</param>
        public KeyHandle(string UDF, string Application) {
            }

        /// <summary>
        /// Construct by key fingerprint, use and name of key.
        /// </summary>
        /// <param name="UDF">Fingerprint of the key.</param>
        /// <param name="Application">The use.</param>
        /// <param name="Name">The key friendly name</param>
        public KeyHandle(string UDF, string Application, string Name) {
            }

        /// <summary>
        /// Form a KeyHandle from an end entity certificate 
        /// </summary>
        /// <param name="Certificate">The end entity certificate to construct
        /// the handle from.</param>
        public KeyHandle(Certificate Certificate) {

            }

        /// <summary>
        /// Form a KeyHandle from a certificate chain.
        /// </summary>
        /// <param name="Certificates">Certificate Chain</param>
        public KeyHandle(List<Certificate> Certificates) {

            }

        /// <summary>
        /// X.509 v3 Certificate for this key and set of uses.
        /// </summary>
        public Certificate Certificate { get; set; }

        /// <summary>
        /// X.509 v3 Certificate chain validating this certificate.
        /// </summary>
        public List<Certificate> CertificateChain { get; set; }

        }

    /// <summary>
    /// Base class for all cryptographic keys.
    /// </summary>
    public abstract class CryptoKey  {

        /// <summary>
        /// Cryptographic Algorithm Identifier
        /// </summary>
        public CryptoAlgorithmID CryptoAlgorithmID {
            get; set;
            }


        /// <summary>
        /// UDF fingerprint of the key
        /// </summary>
        public virtual string UDF  => null;

        /// <summary>
        /// The key name.
        /// </summary>
        public virtual string Name { get; set; }  = null;
        }


    /// <summary>
    /// Base class for all cryptographic key pairs.
    /// </summary>
    public abstract partial class KeyPair : CryptoKey {

        /// <summary>
        /// The key locator, an Internet name in username@domain format. This is used as the basis 
        /// for constructing the Strong Internet Name.
        /// </summary>
        public string Locator { get; set; }

        /// <summary>
        /// The strong internet name for the key.
        /// </summary>
        public string StrongInternetName => Locator + ".mm--" + UDF;

        /// <summary>
        /// If true, keys will be created in containers prefixed with the name
        /// "test:" to allow them to be easily identified and cleaned up.
        /// </summary>
        public static bool TestMode { get; set; } = false;

        /// <summary>
        /// Returns a signature provider for the key (if the private portion is available).
        /// </summary>
        /// <param name="BulkAlgorithm">The digest algorithm to use</param>
        /// <returns>The signature provider.</returns>
        public abstract CryptoProviderSignature SignatureProvider(
                    CryptoAlgorithmID BulkAlgorithm = CryptoAlgorithmID.Default);

        /// <summary>
        /// Returns an encryption provider for the key (if the public portion is available)
        /// </summary>
        /// <param name="BulkAlgorithm">The encryption algorithm to use</param>
        /// <returns>The encryption provider.</returns>
        public abstract CryptoProviderExchange ExchangeProvider(
                    CryptoAlgorithmID BulkAlgorithm = CryptoAlgorithmID.Default);

        CryptoProviderExchange CachedExchangeProvider = null;
        CryptoProviderSignature CachedSignatureProvider = null;


        /// <summary>
        /// Return the CryptoAlgorithmID that would be used with the specified base parameters.
        /// </summary>
        /// <param name="Base">The base identifier.</param>
        /// <returns>The computed CryptoAlgorithmID</returns>
        public virtual CryptoAlgorithmID SignatureAlgorithmID(CryptoAlgorithmID Base) => Base;



        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="Bulk">The provider to wrap.</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <returns>The encryption provider</returns>
        public virtual CryptoDataExchange EncryptKey(CryptoData Bulk,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default) {

            CachedExchangeProvider = CachedExchangeProvider ?? ExchangeProvider(AlgorithmID);
            var Exchange = CachedExchangeProvider.Encrypt(Bulk, Wrap: true);
            Bulk.Exchanges = Bulk.Exchanges ?? new List<CryptoDataExchange>();
            Bulk.Exchanges.Add(Exchange);

            return Exchange;
            }



        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="Bulk">The provider to wrap.</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <returns>The cryptographic result.</returns>
        public virtual CryptoData Sign(CryptoData Bulk,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default) {

            CachedSignatureProvider = CachedSignatureProvider ??
                        SignatureProvider(AlgorithmID);

            throw new NYI("Fix here");
            }


        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="Data">The data to sign.</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <returns>The signature data</returns>
        public virtual CryptoDataSignature Sign(byte [] Data,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default) {

            CachedSignatureProvider = CachedSignatureProvider ??
                        SignatureProvider(AlgorithmID);

            return CachedSignatureProvider.Sign(Data);
            }

        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="Data">The data to sign.</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <returns>The signature data</returns>
        public virtual byte[] SignHash(byte[] Data,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default) {

            CachedSignatureProvider = CachedSignatureProvider ??
                        SignatureProvider(AlgorithmID);

            return CachedSignatureProvider.SignHash(Data, AlgorithmID);
            }


        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="EncryptedKey">The encrypted session</param>
        /// <param name="Ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="AlgorithmID">The algorithm to use.</param>
        /// <param name="Partial">Partial key agreement carry in (for recryption)</param>
        /// <returns>The decoded data instance</returns>
        public virtual byte[] Decrypt(
                    byte[]EncryptedKey,
                    KeyPair Ephemeral = null,
                    CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default,
                    KeyAgreementResult Partial= null) {

            CachedExchangeProvider = CachedExchangeProvider ??
                ExchangeProvider(AlgorithmID);

            return CachedExchangeProvider.Decrypt(EncryptedKey, Ephemeral, 
                CryptoAlgorithmID, Partial: Partial);
            }

        /// <summary>
        /// Verify a precomputed digest
        /// </summary>
        /// <param name="Bulk">The provider to wrap.</param>
        /// <param name="Signature">The signature blob value.</param>
        /// <param name="AlgorithmID">The algorithm used.</param>
        /// <returns>True if the digest is cvalid, otherwise false.</returns>
        public virtual bool Verify(CryptoData Bulk, Byte [] Signature,
                CryptoAlgorithmID AlgorithmID = CryptoAlgorithmID.Default) {
            CachedSignatureProvider = CachedSignatureProvider ??
                        SignatureProvider(AlgorithmID);

            return CachedSignatureProvider.Verify(Bulk, Signature);
            }

        /// <summary>
        /// Search for the local key with the specified UDF fingerprint.
        /// </summary>
        public abstract void GetPrivate();


        /// <summary>
        /// Search all the local machine stores to find a key pair with the specified
        /// fingerprint
        /// </summary>
        /// <param name="UDF">Fingerprint of key</param>
        /// <returns>The key pair found</returns>
        public static KeyPair FindLocal(string UDF) {
            foreach (var Delegate in Platform.FindLocalDelegates) {
                var KeyPair = Delegate(UDF);
                if (KeyPair != null) {
                    return KeyPair;
                    }
                }
            return null;
            }


        /// <summary>
        /// Erase the key from the local machine.
        /// </summary>
        public abstract void EraseFromDevice();

        /// <summary>
        /// The public key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public abstract SubjectPublicKeyInfo KeyInfoData { get; }


        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public abstract SubjectPublicKeyInfo PrivateKeyInfoData { get; }


        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public abstract IPKIXPrivateKey PKIXPrivateKey { get; }


        /// <summary>
        /// The private key data formatted as a PKIX KeyInfo data blob.
        /// </summary>
        public abstract IPKIXPublicKey PKIXPublicKey { get; }


        string _UDF = null;
        /// <summary>
        /// Returns the UDF fingerprint of the current key as a string.
        /// </summary>
        public override string UDF {
            get {
                if (_UDF == null) {
                    _UDF = PKIXPublicKey.UDF();
                    }
                return _UDF;
                }
            }

        /// <summary>
        /// Perform a key agreement on the specified public key.
        /// </summary>
        /// <param name="KeyPair">Public key pair to perform agreement to.</param>
        /// <returns>The result of the key agreement.</returns>
        public virtual KeyAgreementResult Agreement(KeyPair KeyPair) => throw new CryptographicOperationNotSupported();


        /// <summary>
        /// Returns a new KeyPair instance which only has the public values.
        /// </summary>
        /// <returns></returns>
        public abstract KeyPair KeyPairPublic();

        /// <summary>
        /// If true, the provider only provides the public key values.
        /// </summary>
        public abstract bool PublicOnly { get; }

        }



    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="PKIXParameters"></param>
    /// <returns></returns>
    public delegate KeyPair FactoryRSAPublicKeyDelegate (PKIXPublicKeyRSA PKIXParameters);


    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="PKIXParameters"></param>
    /// <returns></returns>
    public delegate KeyPair FactoryRSAPrivateKeyDelegate (PKIXPrivateKeyRSA PKIXParameters);

    /// <summary>
    /// RSA Key Pair
    /// </summary>
    public abstract class KeyPairBaseRSA : KeyPair {

        /// <summary>
        /// Return private key parameters in PKIX structure
        /// </summary>
        public abstract PKIXPrivateKeyRSA PKIXPrivateKeyRSA { get; }

        /// <summary>
        /// Return public key parameters in PKIX structure
        /// </summary>
        public abstract PKIXPublicKeyRSA PKIXPublicKeyRSA { get; }

        /// <summary>
        /// Construct a KeyPair entry from PKIX parameters. Defaults to the built in
        /// provider.
        /// </summary>
        public static FactoryRSAPublicKeyDelegate KeyPairPublicFactory;

        /// <summary>
        /// Construct a KeyPair entry from PKIX parameters. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryRSAPrivateKeyDelegate KeyPairPrivateFactory;

        /// <summary>
        /// Create a KeyPair for the specified parameters.
        /// </summary>
        /// <param name="Public">The public key parameters.</param>
        /// <returns>The created key pair.</returns>
        public static KeyPair Create(PKIXPublicKeyRSA Public) =>
            KeyPairPublicFactory(Public);

        /// <summary>
        /// Create a KeyPair for the specified parameters.
        /// </summary>
        /// <param name="Private">The private key parameters.</param>
        /// <returns>The created key pair.</returns>
        public static KeyPair Create(PKIXPrivateKeyRSA Private=null) =>
            KeyPairPrivateFactory(Private);

        }

    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="PKIXParameters">The PKIX parameter structure from which to create
    /// the key pair</param>
    /// <returns>The created key pair</returns>
    public delegate KeyPair FactoryDHPublicKeyDelegate(PKIXPublicKeyDH PKIXParameters);


    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="Exportable">If true, private key parameters may be exported</param>
    /// <param name="PKIXParameters">The PKIX parameter structure from which to create
    /// the key pair</param>
    /// <returns>The created key pair</returns>
    public delegate KeyPair FactoryDHPrivateKeyDelegate(PKIXPrivateKeyDH PKIXParameters,
        bool Exportable = false);

    /// <summary>
    /// RSA Key Pair
    /// </summary>
    public abstract class KeyPairBaseDH : KeyPair {

        /// <summary>
        /// ASN.1 Object Identifier for the domain parameters.
        /// </summary>
        /// <remarks>
        /// Since this is not standard DH, the OID is in 
        /// PHB's OID space.
        /// </remarks>
        public const string KeyOIDDomain = Constants.OIDS__id_dh_domain;
            
            
            //"1.3.6.1.4.1.35405.1.22.0";

        /// <summary>
        /// ASN.1 Object Identifier for the public key parameters.
        /// </summary>
        /// <remarks>
        /// Since this is not standard DH, the OID is in 
        /// PHB's OID space.
        /// </remarks>
        public const string KeyOIDPublic = Constants.OIDS__id_dh_public;// "1.3.6.1.4.1.35405.1.22.1";

        /// <summary>
        /// ASN.1 Object Identifier for the private key parameters.
        /// </summary>
        /// <remarks>
        /// Since this is not standard DH, the OID is in 
        /// PHB's OID space.
        /// </remarks>
        public const string KeyOIDPrivate = Constants.OIDS__id_dh_private;
                    // "1.3.6.1.4.1.35405.1.22.2";



        /// <summary>
        /// Return private key parameters in PKIX structure
        /// </summary>
        public abstract DHDomain DHDomain { get; }

        /// <summary>
        /// Return private key parameters in PKIX structure
        /// </summary>
        public abstract PKIXPrivateKeyDH PKIXPrivateKeyDH { get; }

        /// <summary>
        /// Return public key parameters in PKIX structure
        /// </summary>
        public abstract PKIXPublicKeyDH PKIXPublicKeyDH { get; }

        /// <summary>
        /// Construct a KeyPair entry from PKIX parameters. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryDHPublicKeyDelegate KeyPairPublicFactory = KeyPairDH.KeyPairPublicFactory;

        /// <summary>
        /// Construct a KeyPair entry from PKIX parameters. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryDHPrivateKeyDelegate KeyPairPrivateFactory = KeyPairDH.KeyPairPrivateFactory;




        }



    /// <summary>
    /// Base class for all public key cryptographic providers.
    /// </summary>
    public abstract class CryptoProviderAsymmetric : CryptoProvider {
        /// <summary>
        /// Generates a new signing key pair with the default key size.
        /// </summary>
        /// <param name="KeySecurity">Specifies the protection level for the key.</param>
        /// <param name="KeySize">The key size</param>
        public abstract void Generate(KeySecurity KeySecurity, int KeySize=0);

        /// <summary>
        /// Locate the private key in the local key store.
        /// </summary>
        /// <param name="UDF">Fingerprint of key to locate.</param>
        /// <returns>True if private key exists.</returns>
        public abstract bool FindLocal(string UDF);


        /// <summary>
        /// The default digest algorithm. This may be overridden in subclasses.
        /// for example, to make a different digest algorithm the default for
        /// a particular provider.
        /// </summary>
        public abstract CryptoAlgorithmID BulkAlgorithmDefault { get; set; }



        }


    }
