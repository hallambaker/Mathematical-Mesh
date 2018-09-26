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
    public abstract class CryptoKey {

        /// <summary>
        /// Cryptographic Algorithm Identifier
        /// </summary>
        public CryptoAlgorithmID CryptoAlgorithmID {
            get; set;
            }


        /// <summary>
        /// UDF fingerprint of the key
        /// </summary>
        public virtual string UDF => null;

        /// <summary>
        /// The key name.
        /// </summary>
        public virtual string Name { get; set; } = null;
        }




    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="PKIXParameters"></param>
    /// <returns></returns>
    public delegate KeyPair FactoryRSAPublicKeyDelegate(PKIXPublicKeyRSA PKIXParameters);


    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="PKIXParameters"></param>
    /// <returns></returns>
    public delegate KeyPair FactoryRSAPrivateKeyDelegate(PKIXPrivateKeyRSA PKIXParameters);

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
        public static KeyPair Create(PKIXPrivateKeyRSA Private = null) =>
            KeyPairPrivateFactory(Private);

        }

    /// <summary>
    /// Delegate to create a new keypair.
    /// </summary>
    /// <param name="algorithmID">The type of keypair to create.</param>
    /// <param name="KeySecurity">The key security model</param>
    /// <param name="KeySize">The key size (ignored if the algorithm supports only one key size)</param>
    /// <param name="Sign">If true, the key may be used for singature operations</param>
    /// <param name="Exchange">If true, the key may be used for exchange operations</param>
    /// <param name="KeyCollection">The key collection that keys are to be persisted to (dependent on 
    /// the value of <paramref name="KeySecurity"/></param>
    /// <returns>The created key pair</returns>
    public delegate KeyPair FactoryKeyPairDelegate(
                KeySecurity KeySecurity = KeySecurity.Ephemeral,
                KeyCollection KeyCollection=null,
        int KeySize = 0,
        bool Sign = true,
        bool Exchange = true,
        CryptoAlgorithmID algorithmID = CryptoAlgorithmID.NULL);


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
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="PKIXParameters">The PKIX parameter structure from which to create
    /// the key pair</param>
    /// <returns>The created key pair</returns>
    public delegate KeyPair FactoryECDHPublicKeyDelegate(PKIXPublicKeyECDH PKIXParameters);


    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="Exportable">If true, private key parameters may be exported</param>
    /// <param name="PKIXParameters">The PKIX parameter structure from which to create
    /// the key pair</param>
    /// <returns>The created key pair</returns>
    public delegate KeyPair FactoryECDHPrivateKeyDelegate(PKIXPrivateKeyECDH PKIXParameters,
        bool Exportable = false);


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

        ///// <summary>
        ///// Locate the private key in the local key store.
        ///// </summary>
        ///// <param name="UDF">Fingerprint of key to locate.</param>
        ///// <returns>True if private key exists.</returns>
        //public abstract bool FindLocal(string UDF);


        /// <summary>
        /// The default digest algorithm. This may be overridden in subclasses.
        /// for example, to make a different digest algorithm the default for
        /// a particular provider.
        /// </summary>
        public abstract CryptoAlgorithmID BulkAlgorithmDefault { get; set; }



        }


    }
