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
using Goedel.Cryptography.PKIX;

namespace Goedel.Cryptography {


    /// <summary>
    /// Base class for all cryptographic keys.
    /// </summary>
    public abstract class CryptoKey {

        /// <summary>
        /// Cryptographic Algorithm Identifier
        /// </summary>
        public CryptoAlgorithmId CryptoAlgorithmId {
            get; set;
            }


        /// <summary>
        /// UDF fingerprint of the key
        /// </summary>
        public virtual string UDF => null;


        /// <summary>
        /// UDF fingerprint of the key
        /// </summary>
        public abstract byte[] UDFBytes { get; }

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
    /// <param name="keyType">The key security model</param>
    /// <param name="pkixParameters">The key parameters</param>
    /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
    /// the value of <paramref name="keyType"/></param>
    /// <returns>the created key pair</returns>
    public delegate KeyPair FactoryRSAPrivateKeyDelegate(
            PKIXPrivateKeyRSA pkixParameters,
            KeySecurity keyType, KeyCollection keyCollection);

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
        public static FactoryRSAPublicKeyDelegate KeyPairPublicFactory = KeyPairRSA.KeyPairPublicFactory;

        /// <summary>
        /// Construct a KeyPair entry from PKIX parameters. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryRSAPrivateKeyDelegate KeyPairPrivateFactory = KeyPairRSA.KeyPairPrivateFactory;



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
            KeyPairPrivateFactory(pkixKey, KeySecurity.Exportable, null);

        }

    /// <summary>
    /// Delegate to create a new keypair.
    /// </summary>
    /// <param name="algorithmID">The type of keypair to create.</param>
    /// <param name="keyType">The key security model</param>
    /// <param name="keySize">The key size (ignored if the algorithm supports only one key size)</param>
    /// <param name="keyUses">The permitted uses (signing, exchange) for the key.</param>
    /// <returns>The created key pair</returns>
    public delegate KeyPair FactoryKeyPairDelegate(
                    int keySize = 0,
                    KeySecurity keyType = KeySecurity.Bound,
                    KeyUses keyUses = KeyUses.Any,
                    CryptoAlgorithmId algorithmID = CryptoAlgorithmId.NULL);


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
    /// <param name="keyType">The key security model</param>
    /// <param name="pkixParameters">The PKIX parameter structure from which to create
    /// the key pair</param>
    /// <returns>The created key pair</returns>
    public delegate KeyPair FactoryDHPrivateKeyDelegate(PKIXPrivateKeyDH pkixParameters,
        KeySecurity keyType = KeySecurity.Public);


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
    /// <param name="keyType">The key security model</param>
    /// <param name="pkixParameters">The PKIX parameter structure from which to create
    /// the key pair</param>
    /// <returns>The created key pair</returns>
    public delegate KeyPair FactoryECDHPrivateKeyDelegate(PKIXPrivateKeyECDH pkixParameters,
        KeySecurity keyType = KeySecurity.Public);


    }
