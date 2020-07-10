﻿using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

using System;
using System.Collections.Generic;

namespace Goedel.Cryptography {

    /// <summary>
    /// Key discovery interface.
    /// </summary>
    public interface IKeyLocate {
        /// <summary>
        /// Attempt to find a private key for the specified recipient entry.
        /// </summary>
        /// <param name="keyID">The key identifier to match</param>
        /// <returns>True if a match is found, otherwise false.</returns>
        IKeyDecrypt TryFindKeyDecryption(string keyID);

        /// <summary>
        /// Locate a private key
        /// </summary>
        /// <param name="UDF">fingerprint of key to locate.</param>
        /// <returns>A KeyPair instance bound to the private key.</returns>
        CryptoKey LocatePrivateKeyPair(string UDF);

        /// <summary>
        /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyID">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        CryptoKey TryFindKeyEncryption(string keyID);

        /// <summary>
        /// Resolve a private key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="signingKey">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        CryptoKey TryFindKeySignature(string signingKey);



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
    public delegate keyCollection KeyCollectionDelegate();

    /// <summary>
    /// Track a collection of keys from various sources allowing recall when required for recryption use.
    /// </summary>
    public abstract class keyCollection : IKeyLocate {

        ///<summary>Lock used to ensure exclusive access during updates.</summary>
        Object exclusiveAccess = new Object();

        /// <summary>
        /// The default collection.
        /// </summary>
        public static keyCollection Default;

        //static KeyCollection _Default = null;

        ///<summary>Key pairs by UDF value.</summary>
        protected Dictionary<string, KeyPair> DictionaryKeyPairByUDF = new Dictionary<string, KeyPair>();

        ///<summary>Key pairs by SIN value.</summary>
        protected Dictionary<string, KeyPair> DictionaryKeyPairBySINEncrypt = new Dictionary<string, KeyPair>();
        
        ///<summary>Encryption keypairs by account identifier.</summary>
        protected Dictionary<string, KeyPair> DictionaryKeyPairByAccountEncrypt = new Dictionary<string, KeyPair>();
        
        ///<summary>Signature keypairs by SIN</summary>
        protected Dictionary<string, KeyPair> DictionaryKeyPairBySINSign = new Dictionary<string, KeyPair>();

        ///<summary>Signature keypairs by Account</summary>
        protected Dictionary<string, KeyPair> DictionaryKeyPairByAccountSign = new Dictionary<string, KeyPair>();


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
        /// <param name="keyID">The key identifier to match</param>
        /// <returns>True if a match is found, otherwise false.</returns>
        public virtual IKeyDecrypt TryFindKeyDecryption(string keyID) => 
                        TryMatchRecipientKeyPair(keyID);


        /// <summary>
        /// Attempt to find a private key for the specified recipient entry.
        /// </summary>
        /// <param name="keyID">The key identifier to match</param>
        /// <returns>True if a match is found, otherwise false.</returns>
        protected KeyPair TryMatchRecipientKeyPair(string keyID) {
            // Search our this.SessionPersonal = SessionPersonal;
            if (DictionaryKeyPairByUDF.TryGetValue(keyID, out var KeyPair)) {
                return KeyPair;
                }
            if (DictionaryKeyPairBySINEncrypt.TryGetValue(keyID, out KeyPair)) {
                return KeyPair;
                }
            if (DictionaryKeyPairByAccountEncrypt.TryGetValue(keyID, out KeyPair)) {
                return KeyPair;
                }

            return null;
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
        /// <param name="UDF">fingerprint of key to locate.</param>
        /// <returns>A KeyPair instance bound to the private key.</returns>
        public virtual CryptoKey LocatePrivateKeyPair(string UDF) {


            var keyPair = KeyPairRSA.Locate(UDF);
            if (keyPair != null) {
                return keyPair;
                }

            return null;
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
        /// <param name="keyID">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public virtual CryptoKey TryFindKeyEncryption(string keyID) {
            DictionaryKeyPairByAccountEncrypt.TryGetValue(keyID, out var Result);
            return Result;
            }

        /// <summary>
        /// Resolve a private key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyID">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public virtual CryptoKey TryFindKeySignature(string keyID) {
            DictionaryKeyPairByAccountSign.TryGetValue(keyID, out var Result);
            return Result;
            }




        }
    }
