using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;

namespace Goedel.Cryptography {


    /// <summary>
    /// Return a new KeyCollection
    /// </summary>
    /// <returns></returns>
    public delegate KeyCollection KeyCollectionDelegate();

    /// <summary>
    /// Track a collection of keys from various sources allowing recall when required for recryption use.
    /// </summary>
    public abstract class KeyCollection {

        Object ExclusiveAccess = new Object();

        /// <summary>
        /// The default collection.
        /// </summary>
        public static KeyCollection Default;

        //static KeyCollection _Default = null;

        ///<summary>Delegate returning a new KeyCollection</summary>
        public static KeyCollectionDelegate NewKeyCollection;


        Dictionary<string, KeyPair> DictionaryKeyPairByUDF = new Dictionary<string, KeyPair>();
        Dictionary<string, KeyPair> DictionaryKeyPairBySINEncrypt = new Dictionary<string, KeyPair>();
        Dictionary<string, KeyPair> DictionaryKeyPairByAccountEncrypt = new Dictionary<string, KeyPair>();
        Dictionary<string, KeyPair> DictionaryKeyPairBySINSign = new Dictionary<string, KeyPair>();
        Dictionary<string, KeyPair> DictionaryKeyPairByAccountSign = new Dictionary<string, KeyPair>();


        //Dictionary<string, KeyPair> DictionaryKeyPairPrivateByUDF = new Dictionary<string, KeyPair>();



        /// <summary>
        /// Add a keypair to the collection.
        /// </summary>
        /// <param name="keyPair">The key pair to add.</param>
        public virtual void Add(KeyPair keyPair ) {
            lock (ExclusiveAccess) {
                DictionaryKeyPairByUDF.AddSafe(keyPair.UDF, keyPair);
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
        /// Add a recryption group account to the group.
        /// </summary>
        /// <param name="recryptionGroup"></param>
        public void Add(string recryptionGroup) {
            }

        /// <summary>
        /// Attempt to find a private key for the specified recipient entry.
        /// </summary>
        /// <param name="keyID">The key identifier to match</param>
        /// <returns>True if a match is found, otherwise false.</returns>
        public virtual KeyPair TryMatchRecipient(string keyID) {


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
        /// Locate a private key
        /// </summary>
        /// <param name="UDF">fingerprint of key to locate.</param>
        /// <returns>A KeyPair instance bound to the private key.</returns>
        public virtual KeyPair LocatePrivate(string UDF) {


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
        /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyID">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public virtual KeyPair GetByAccountEncrypt(string keyID) {
            var Found = DictionaryKeyPairByAccountEncrypt.TryGetValue(keyID, out var Result);
            return Result;
            }

        /// <summary>
        /// Resolve a private key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyID">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public virtual KeyPair GetByAccountSign(string keyID) {
            var Found = DictionaryKeyPairByAccountSign.TryGetValue(keyID, out var Result);
            return Result;
            }




        }
    }
