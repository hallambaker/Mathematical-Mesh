#region // Copyright - MIT License
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
using System.Collections.Generic;

using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

namespace Goedel.Cryptography {

    /// <summary>
    /// Key discovery interface.
    /// </summary>
    public interface IKeyLocate {
        /// <summary>
        /// Attempt to find a private key for the specified recipient entry.
        /// </summary>
        /// <param name="keyID">The key identifier to match</param>
        /// <param name="cryptoKey">The key (if found)</param>
        /// <returns>True if a match is found, otherwise false.</returns>
        bool TryFindKeyDecryption(string keyID, out IKeyDecrypt cryptoKey);

        /// <summary>
        /// Locate a private key
        /// </summary>
        /// <param name="UDF">fingerprint of key to locate.</param>
        /// <param name="cryptoKey">The key (if found)</param>
        /// <returns>A KeyPair instance bound to the private key.</returns>
        bool LocatePrivateKeyPair(string UDF, out CryptoKey cryptoKey);

        /// <summary>
        /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyID">The identifier to resolve.</param>
        /// <param name="cryptoKey">The key (if found)</param>
        /// <returns>true if a key is found, otherwise, false.</returns>
        bool TryFindKeyEncryption(string keyID, out CryptoKey cryptoKey);

        /// <summary>
        /// Resolve a private key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="signingKey">The identifier to resolve.</param>
        /// <param name="cryptoKey">The key (if found)</param>
        /// <returns>The identifier.</returns>
        bool TryFindKeySignature(string signingKey, out CryptoKey cryptoKey);

        /// <summary>
        /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyId">The identifier to resolve.</param>
        /// <param name="cryptoKey">The key (if found)</param>
        /// <returns>The identifier.</returns>
        bool TryFindPublicKey(string keyId, out CryptoKey cryptoKey);


        /// <summary>
        /// Add a keypair to the collection.
        /// </summary>
        /// <param name="keyPair">The key pair to add.</param>
        void Add(KeyPair keyPair);

        /// <summary>
        /// Persist a private key if permitted by the KeySecurity model of the key.
        /// </summary>
        /// <param name="keyPair">The key to persist.</param>
        void Persist(KeyPair keyPair);


        }




    /// <summary>
    /// Return a new KeyCollection
    /// </summary>
    /// <returns></returns>
    public delegate KeyCollection KeyCollectionDelegate();

    /// <summary>
    /// Track a collection of keys from various sources allowing recall when required for recryption use.
    /// </summary>
    public abstract class KeyCollection : IKeyLocate {

        ///<summary>Lock used to ensure exclusive access during updates.</summary>
        Object exclusiveAccess = new();

        /// <summary>
        /// The default collection.
        /// </summary>
        public static KeyCollection Default { get; set; }

        //static KeyCollection _Default = null;

        ///<summary>Key pairs by UDF value.</summary>
        protected Dictionary<string, KeyPair> DictionaryKeyPairByUDF = new();

        ///<summary>Key pairs by SIN value.</summary>
        protected Dictionary<string, KeyPair> DictionaryKeyPairBySINEncrypt = new();

        ///<summary>Encryption keypairs by account identifier.</summary>
        protected Dictionary<string, KeyPair> DictionaryKeyPairByAccountEncrypt = new();

        ///<summary>Signature keypairs by SIN</summary>
        protected Dictionary<string, KeyPair> DictionaryKeyPairBySINSign = new();

        ///<summary>Signature keypairs by Account</summary>
        protected Dictionary<string, KeyPair> DictionaryKeyPairByAccountSign = new();


        //Dictionary<string, KeyPair> DictionaryKeyPairPrivateByUDF = new Dictionary<string, KeyPair>();



        /// <summary>
        /// Add a keypair to the collection.
        /// </summary>
        /// <param name="keyPair">The key pair to add.</param>
        public virtual void Add(KeyPair keyPair) {
            if (keyPair == null) {
                return;
                }

            lock (exclusiveAccess) {
                DictionaryKeyPairByUDF.AddSafe(keyPair.KeyIdentifier, keyPair);
                if (keyPair.Locator != null) {
                    if (keyPair.KeyUses.HasFlag(KeyUses.Encrypt)) {
                        DictionaryKeyPairBySINEncrypt.AddSafe(keyPair.StrongInternetName, keyPair);
                        DictionaryKeyPairByAccountEncrypt.AddSafe(keyPair.Locator, keyPair);
                        }
                    if (keyPair.KeyUses.HasFlag(KeyUses.Sign)) {
                        DictionaryKeyPairBySINSign.AddSafe(keyPair.StrongInternetName, keyPair);
                        DictionaryKeyPairByAccountSign.AddSafe(keyPair.Locator, keyPair);
                        }
                    }
                }
            }


        /// <summary>
        /// Attempt to find a private key for the specified recipient entry.
        /// </summary>
        /// <param name="keyId">The key identifier to match</param>
        /// <param name="keyDecrypt">The key, (if found).</param>
        /// <returns>True if a match is found, otherwise false.</returns>
        public virtual bool TryFindKeyDecryption(string keyId, out IKeyDecrypt keyDecrypt) {
            var result = TryMatchRecipientKeyPair(keyId, out var key);
            keyDecrypt = key as IKeyDecrypt;
            return result;
            }

        /// <summary>
        /// Attempt to find a private key for the specified recipient entry.
        /// </summary>
        /// <param name="keyId">The key identifier to match</param>
        /// <param name="cryptoKey">The key, (if found).</param>
        /// <returns>True if a match is found, otherwise false.</returns>
        protected bool TryMatchRecipientKeyPair(string keyId, out CryptoKey cryptoKey) {
            // Search our this.SessionPersonal = SessionPersonal;
            if (DictionaryKeyPairByUDF.TryGetValue(keyId, out var keyPair)) {
                cryptoKey = keyPair;
                return true;
                }
            if (DictionaryKeyPairBySINEncrypt.TryGetValue(keyId, out keyPair)) {
                cryptoKey = keyPair;
                return true;
                }
            if (DictionaryKeyPairByAccountEncrypt.TryGetValue(keyId, out keyPair)) {
                cryptoKey = keyPair;
                return true;
                }

            cryptoKey = null;
            return false;
            }


        /// <summary>
        /// Locate the private key with fingerprint <paramref name="udf"/> and return
        /// the corresponding JSON description.
        /// </summary>
        /// <param name="udf">Key to locate</param>
        /// <returns>The JSON description (if found).</returns>
        public abstract IJson LocatePrivateKey(string udf);

        /// <summary>
        /// Locate a private key
        /// </summary>
        /// <param name="udf">fingerprint of key to locate.</param>
        /// <param name="key">The key, (if found).</param>
        /// <returns>A KeyPair instance bound to the private key.</returns>
        public virtual bool LocatePrivateKeyPair(string udf, out CryptoKey key) {
            if (KeyPairRSA.Locate(udf, out var keyPair)) {
                key = keyPair;
                return true;
                }

            key = null;
            return false;
            }

        /// <summary>
        /// Persist a private key if permitted by the KeySecurity model of the key.
        /// </summary>
        /// <param name="keyPair">The key to persist.</param>
        public virtual void Persist(KeyPair keyPair) {
            //DictionaryKeyPairPrivateByUDF.AddSafe(keyPair.UDF, keyPair);

            if (keyPair.PersistPending) {
                keyPair.Persist(this);
                }

            }



        /// <summary>
        /// Persist the key pair specified by <paramref name="privateKey"/> and mark as exportable
        /// or non-exportable according to the value of <paramref name="Exportable"/>.
        /// </summary>
        /// <param name="udf">The UDF of the key</param>
        /// <param name="privateKey">The private key parameters.</param>
        /// <param name="Exportable">If true, the key is exportable.</param>
        public abstract void Persist(string udf, IPKIXPrivateKey privateKey, bool Exportable);


        /// <summary>
        /// Persist the key pair specified by <paramref name="joseKey"/> and mark as exportable
        /// or non-exportable according to the value of <paramref name="exportable"/>.
        /// </summary>
        /// <param name="udf">The UDF of the key</param>
        /// <param name="joseKey">The private key parameters.</param>
        /// <param name="exportable">If true, the key is exportable.</param>
        public abstract void Persist(string udf, IJson joseKey, bool exportable);


        /// <summary>
        /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyId">The identifier to resolve.</param>
        /// <param name="cryptoKey">The found key </param>
        /// <returns>The identifier.</returns>
        public virtual bool TryFindKeyEncryption(string keyId, out CryptoKey cryptoKey) {

            if (DictionaryKeyPairByUDF.TryGetValue(keyId, out var keyPair)) {
                cryptoKey = keyPair;
                return true;
                }
            if (DictionaryKeyPairByAccountEncrypt.TryGetValue(keyId, out keyPair)) {
                cryptoKey = keyPair;
                return true;
                }
            cryptoKey = null;
            return false;
            }

        /// <summary>
        /// Resolve a private key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyId">The identifier to resolve.</param>
        ///  <param name="cryptoKey">The key, (if found).</param>
        /// <returns>The identifier.</returns>
        public virtual bool TryFindKeySignature(string keyId, out CryptoKey cryptoKey) {

            var result = DictionaryKeyPairByAccountSign.TryGetValue(keyId, out var keyPair);
            cryptoKey = keyPair;
            return result;
            }


        /// <summary>
        /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyId">The identifier to resolve.</param>
        /// <param name="cryptoKey">The key (if found)</param>
        /// <returns>The identifier.</returns>
        public virtual bool TryFindPublicKey(string keyId, out CryptoKey cryptoKey) =>
                    TryMatchRecipientKeyPair(keyId, out cryptoKey);


        }
    }
