#region // Copyright
//  © 2021 by Phill Hallam-Baker
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
#endregion

using System;

using Goedel.Cryptography.PKIX;

namespace Goedel.Cryptography {

    /// <summary>
    /// Interface describing private key operations
    /// </summary>
    public interface IKeyDecrypt {
        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="encryptedKey">The encrypted session</param>
        /// <param name="ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="algorithmID">The algorithm to use (redundant?)</param>
        /// <param name="partial">Partial key agreement carry in (for recryption)</param>
        /// <param name="salt">Optional salt value for use in key derivation. If specified
        /// must match the salt used to encrypt.</param>        
        /// <returns>The decoded data instance</returns>
        byte[] Decrypt(
                    byte[] encryptedKey,
                    KeyPair ephemeral = null,
                    CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, // hack: redundant?
                    KeyAgreementResult partial = null,
                    byte[] salt = null);

        /// <summary>
        /// Perform a partial key agreement.
        /// </summary>
        /// <param name="keyPair">The key pair to perform the agreement against.</param>
        /// <returns>The key agreement result.</returns>
        KeyAgreementResult Agreement(KeyPair keyPair);



        }

    /// <summary>
    /// Interface describing private key operations
    /// </summary>
    public interface IKeySign {

        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="data">The data to sign.</param>
        /// <param name="algorithmID">The algorithm to use.</param>
        /// <param name="context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <returns>The signature data</returns>
        byte[] SignHash(byte[] data,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null);
        }

    /// <summary>
    /// Base class for all cryptographic keys.
    /// </summary>
    public abstract class CryptoKey : IKeyLocate, IKeyDecrypt, IKeySign {

        /// <summary>
        /// Cryptographic Algorithm Identifier
        /// </summary>
        public CryptoAlgorithmId CryptoAlgorithmId {
            get; set;
            }


        /// <summary>
        /// UDF fingerprint of the key
        /// </summary>
        public virtual string KeyIdentifier => null;


        /// <summary>
        /// UDF fingerprint of the key
        /// </summary>
        public abstract byte[] UDFBytes { get; }

        /// <summary>
        /// The key name.
        /// </summary>
        public virtual string Name { get; set; } = null;



        #region // Implement IKeyLocate


        /// <summary>
        /// Attempt to find a private key for the specified recipient entry.
        /// </summary>
        /// <param name="keyId">The key identifier to match</param>
        ///  <param name="cryptoKey">The key, (if found).</param>
        /// <returns>True if a match is found, otherwise false.</returns>
        public virtual bool TryFindPublicKey(string keyId, out CryptoKey cryptoKey) {
            if (keyId == KeyIdentifier) {
                cryptoKey = this;
                return true;
                }
            cryptoKey = null;
            return false;
            }



        /// <summary>
        /// Attempt to find a private key for the specified recipient entry.
        /// </summary>
        /// <param name="keyId">The key identifier to match</param>
        ///  <param name="cryptoKey">The key, (if found).</param>
        /// <returns>True if a match is found, otherwise false.</returns>
        public virtual bool TryFindKeyDecryption(string keyId, out IKeyDecrypt cryptoKey) {
            if (keyId == KeyIdentifier) {
                cryptoKey = this;
                return true;
                }
            cryptoKey = null;
            return false;
            }

        /// <summary>
        /// Resolve a public key by identifier. This always returns null because the collection
        /// cannot contain a <see cref="KeyPair"/>
        /// </summary>
        /// <param name="keyId">The identifier to resolve.</param>
        /// <param name="cryptoKey">The found key </param>
        /// <returns>The identifier.</returns>
        public bool TryFindKeyEncryption(string keyId, out CryptoKey cryptoKey) {
            if (keyId == KeyIdentifier) {
                cryptoKey = this;
                return true;
                }
            cryptoKey = null;
            return false;
            }

        /// <summary>
        /// Resolve a private key by identifier.  This always returns null because the collection
        /// cannot contain a <see cref="KeyPair"/>
        /// </summary>
        /// <param name="keyId">The identifier to resolve.</param>
        ///  <param name="cryptoKey">The key, (if found).</param>
        /// <returns>The identifier.</returns>
        public bool TryFindKeySignature(string keyId, out CryptoKey cryptoKey) {
            if (keyId == KeyIdentifier) {
                cryptoKey = this;
                return true;
                }
            cryptoKey = null;
            return false;

            }

        /// <summary>
        /// Locate the private key.
        /// </summary>
        /// <param name="keyId">fingerprint of key to locate.</param>
        ///  <param name="cryptoKey">The key, (if found).</param>
        /// <returns>A KeyPair instance bound to the private key.</returns>
        public bool LocatePrivateKeyPair(string keyId, out CryptoKey cryptoKey) {
            if (keyId == KeyIdentifier) {
                cryptoKey = this;
                return true;
                }
            cryptoKey = null;
            return false;
            }

        /// <summary>
        /// Add a keypair to the collection.
        /// </summary>
        /// <param name="keyPair">The key pair to add.</param>
        public void Add(KeyPair keyPair) => throw new NotImplementedException();

        /// <summary>
        /// Persist a private key if permitted by the KeySecurity model of the key.
        /// </summary>
        /// <param name="keyPair">The key to persist.</param>
        public void Persist(KeyPair keyPair) => throw new NotImplementedException();

        #endregion

        /// <summary>
        /// Check to see if <paramref name="keyId"/> is a valid name for this key using the
        /// extended value from the public key parameters if known;
        /// </summary>
        /// <param name="keyId">The key identifier to check.</param>
        /// <returns>True if keyId is sufficiently long and matches the leading characters of the
        /// key identifier.</returns>
        public bool MatchKeyIdentifier(string keyId) =>
            // Hack: should do a proper check on shorter key ids.

            keyId == KeyIdentifier;


        /// <summary>
        /// Encrypt a bulk key.
        /// </summary>
        /// <returns>The encoder</returns>
        /// <param name="key">The key to encrypt.</param>
        /// <param name="ephemeral">The ephemeral key to use for the exchange (if used)</param>
        /// <param name="exchange">The private key to use for the exchange.</param>
        /// <param name="salt">Optional salt value for use in key derivation.</param>
        public abstract void Encrypt(byte[] key,
            out byte[] exchange, out KeyPair ephemeral, byte[] salt = null);

        /// <summary>
        /// Perform a key exchange to encrypt a bulk or wrapped key under this one.
        /// </summary>
        /// <param name="encryptedKey">The encrypted session</param>
        /// <param name="ephemeral">Ephemeral key input (required for DH)</param>
        /// <param name="algorithmID">The algorithm to use (redundant?)</param>
        /// <param name="partial">Partial key agreement carry in (for recryption)</param>
        /// <param name="salt">Optional salt value for use in key derivation. If specified
        /// must match the salt used to encrypt.</param>        
        /// <returns>The decoded data instance</returns>
        public abstract byte[] Decrypt(
                    byte[] encryptedKey,
                    KeyPair ephemeral = null,
                    CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, // hack: redundant?
                    KeyAgreementResult partial = null,
                    byte[] salt = null);


        /// <summary>
        /// Sign a precomputed digest
        /// </summary>
        /// <param name="data">The data to sign.</param>
        /// <param name="algorithmID">The algorithm to use.</param>
        /// <param name="context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <returns>The signature data</returns>
        public abstract byte[] SignHash(byte[] data,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default,
                byte[] context = null);

        /// <summary>
        /// Verify a signature over the purported data digest.
        /// </summary>
        /// <param name="signature">The signature blob value.</param>
        /// <param name="algorithmID">The signature and hash algorithm to use.</param>
        /// <param name="context">Additional data added to the signature scope
        /// for protocol isolation.</param>
        /// <param name="digest">The digest value to be verified.</param>
        /// <returns>True if the signature is valid, otherwise false.</returns>
        public abstract bool VerifyHash(byte[] digest, byte[] signature,
                CryptoAlgorithmId algorithmID = CryptoAlgorithmId.Default, byte[] context = null);



        /// <summary>
        /// Return the CryptoAlgorithmID that would be used with the specified base parameters.
        /// </summary>
        /// <param name="baseID">The base identifier.</param>
        /// <returns>The computed CryptoAlgorithmID</returns>
        public virtual CryptoAlgorithmId SignatureAlgorithmID(CryptoAlgorithmId baseID) => baseID;

        /// <summary>
        /// Perform a partial key agreement.
        /// </summary>
        /// <param name="keyPair">The key pair to perform the agreement against.</param>
        /// <returns>The key agreement result.</returns>
        public virtual KeyAgreementResult Agreement(KeyPair keyPair) => throw new System.NotImplementedException();

        }




    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="pkixParameters"></param>
    /// <returns></returns>
    public delegate KeyPair FactoryRSAPublicKeyDelegate(
        PkixPublicKeyRsa pkixParameters);


    /// <summary>
    /// Delegate to create a key pair base
    /// </summary>
    /// <param name="keyType">The key security model</param>
    /// <param name="pkixParameters">The key parameters</param>
    /// <param name="keyCollection">The key collection that keys are to be persisted to (dependent on 
    /// the value of <paramref name="keyType"/></param>
    /// <returns>the created key pair</returns>
    public delegate KeyPair FactoryRSAPrivateKeyDelegate(
            PkixPrivateKeyRsa pkixParameters,
            KeySecurity keyType, KeyCollection keyCollection);

    /// <summary>
    /// RSA Key Pair
    /// </summary>
    public abstract class KeyPairBaseRSA : KeyPair {

        /// <summary>
        /// Return private key parameters in PKIX structure
        /// </summary>
        public abstract PkixPrivateKeyRsa PkixPrivateKeyRSA { get; }

        /// <summary>
        /// Return public key parameters in PKIX structure
        /// </summary>
        public abstract PkixPublicKeyRsa PkixPublicKeyRsa { get; }

        /// <summary>
        /// Construct a KeyPair entry from PKIX parameters. Defaults to the built in
        /// provider.
        /// </summary>
        public static FactoryRSAPublicKeyDelegate KeyPairPublicFactory { get; set; } = KeyPairRSA.KeyPairPublicFactory;

        /// <summary>
        /// Construct a KeyPair entry from PKIX parameters. Initialized by the cryptographic
        /// platform provider.
        /// </summary>
        public static FactoryRSAPrivateKeyDelegate KeyPairPrivateFactory { get; set; } = KeyPairRSA.KeyPairPrivateFactory;



        /// <summary>
        /// Create a KeyPair for the specified parameters.
        /// </summary>
        /// <param name="pkixKey">The public key parameters.</param>
        /// <returns>The created key pair.</returns>
        public static KeyPair Create(PkixPublicKeyRsa pkixKey) =>
            KeyPairPublicFactory(pkixKey);

        /// <summary>
        /// Create a KeyPair for the specified parameters.
        /// </summary>
        /// <param name="pkixKey">The private key parameters.</param>
        /// <returns>The created key pair.</returns>
        public static KeyPair Create(PkixPrivateKeyRsa pkixKey = null) =>
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
