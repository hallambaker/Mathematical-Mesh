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
    /// <param name="pkixParameters"></param>
    /// <returns></returns>
    public delegate KeyPair FactoryRSAPublicKeyDelegate(
        PKIXPublicKeyRSA pkixParameters);


    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="pkixParameters"></param>
    /// <returns></returns>
    public delegate KeyPair FactoryRSAPrivateKeyDelegate(
            PKIXPrivateKeyRSA pkixParameters);

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
        /// <param name="pkixKey">The public key parameters.</param>
        /// <returns>The created key pair.</returns>
        public static KeyPair Create(PKIXPublicKeyRSA pkixKey) =>
            KeyPairPublicFactory(pkixKey);

        /// <summary>
        /// Create a KeyPair for the specified parameters.
        /// </summary>
        /// <param name="pkixKey">The private key parameters.</param>
        /// <returns>The created key pair.</returns>
        public static KeyPair Create(PKIXPrivateKeyRSA pkixKey = null) =>
            KeyPairPrivateFactory(pkixKey);

        }

    /// <summary>
    /// Delegate to create a new keypair.
    /// </summary>
    /// <param name="algorithmID">The type of keypair to create.</param>
    /// <param name="keySecurity">The key security model</param>
    /// <param name="KeySize">The key size (ignored if the algorithm supports only one key size)</param>
    /// <param name="Sign">If true, the key may be used for singature operations</param>
    /// <param name="Exchange">If true, the key may be used for exchange operations</param>
    /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
    /// the value of <paramref name="keySecurity"/></param>
    /// <returns>The created key pair</returns>
    public delegate KeyPair FactoryKeyPairDelegate(
                    int keySize = 0,
                    KeyStorage keyType = KeyStorage.Bound,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmID algorithmID = CryptoAlgorithmID.NULL);


    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="pkixParameters">The PKIX parameter structure from which to create
    /// the key pair</param>
    /// <returns>The created key pair</returns>
    public delegate KeyPair FactoryDHPublicKeyDelegate(PKIXPublicKeyDH pkixParameters);


    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="keySecurity">The key security rextrictions.</param>
    /// <param name="keyCollection">The key collection to add the key to.</param>
    /// <param name="pkixParameters">The PKIX parameter structure from which to create
    /// the key pair</param>
    /// <returns>The created key pair</returns>
    public delegate KeyPair FactoryDHPrivateKeyDelegate(PKIXPrivateKeyDH pkixParameters,
        KeyStorage keyType = KeyStorage.Public);


    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="pkixParameters">The PKIX parameter structure from which to create
    /// the key pair</param>
    /// <returns>The created key pair</returns>
    public delegate KeyPair FactoryECDHPublicKeyDelegate(PKIXPublicKeyECDH pkixParameters);


    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="keySecurity">The key security rextrictions.</param>
    /// <param name="keyCollection">The key collection to add the key to.</param>
    /// <param name="pkixParameters">The PKIX parameter structure from which to create
    /// the key pair</param>
    /// <returns>The created key pair</returns>
    public delegate KeyPair FactoryECDHPrivateKeyDelegate(PKIXPrivateKeyECDH pkixParameters,
        KeyStorage keyType = KeyStorage.Public);


    }
