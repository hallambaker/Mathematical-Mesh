using System;
using System.IO;
using System.Collections.Generic;
using Goedel.Utilities;
using Goedel.Cryptography;


namespace Goedel.Cryptography.Jose {

    /// <summary>
    /// Track a collection of keys from various sources allowing recall when required for recryption use.
    /// </summary>
    public class KeyCollection {

        Object ExclusiveAccess = new Object();

        /// <summary>
        /// The default collection.
        /// </summary>
        public static KeyCollection Default = new KeyCollection();

        Dictionary<string, KeyPair> DictionaryKeyPairByUDF = new Dictionary<string, KeyPair>();
        Dictionary<string, KeyPair> DictionaryKeyPairBySIN = new Dictionary<string, KeyPair>();
        Dictionary<string, KeyPair> DictionaryKeyPairByAccount = new Dictionary<string, KeyPair>();

        /// <summary>
        /// Add a keypair to the collection.
        /// </summary>
        /// <param name="KeyPair">The key pair to add.</param>
        public void Add(KeyPair KeyPair) {
            lock (ExclusiveAccess) {
                DictionaryKeyPairByUDF.AddSafe(KeyPair.UDF, KeyPair);
                if (KeyPair.Locator != null) {
                    DictionaryKeyPairBySIN.AddSafe(KeyPair.StrongInternetName, KeyPair);
                    DictionaryKeyPairByAccount.AddSafe(KeyPair.Locator, KeyPair);
                    }
                }

            }

        /// <summary>
        /// Add a recryption group account to the group.
        /// </summary>
        /// <param name="RecryptionGroup"></param>
        public void Add(string RecryptionGroup) {
            }




        // ToDo: Make Recipients into an interface...

        /// <summary>
        /// Attempt to decrypt a decryption blob from a list of recipient entries.
        /// </summary>
        /// <param name="Recipients">The recipient entry.</param>
        /// <param name="AlgorithmID">The symmetric encryption cipher (used to decrypt the wrapped key).</param>
        /// <returns></returns>
        public byte[] Decrypt(List<Recipient> Recipients, CryptoAlgorithmID AlgorithmID) {
            foreach (var Recipient in Recipients) {

                var DecryptionKey = TryMatchRecipient(Recipient.Header.Kid);

                // Recipient has the following fields of interest
                // Recipient.EncryptedKey -- The RFC3394 wrapped symmetric key
                // Recipient.Header.Epk  -- The ephemeral public key
                // Recipient.Header.Epk.KeyPair  -- The ephemeral public key

                if (DecryptionKey != null) {
                    return DecryptionKey.Decrypt(Recipient.EncryptedKey, Recipient.Header.Epk.KeyPair, AlgorithmID: AlgorithmID);
                    }
                }


            throw new NoAvailableDecryptionKey();
            }



        /// <summary>
        /// Attempt to find a private key for the specified recipient entry.
        /// </summary>
        /// <param name="KID">The key identifier to match</param>
        /// <returns>True if a match is found, otherwise false.</returns>
        public KeyPair TryMatchRecipient(string KID) {


            // Search our this.SessionPersonal = SessionPersonal;
            if (DictionaryKeyPairByUDF.TryGetValue(KID, out var KeyPair)) {
                return KeyPair;
                }
            if (DictionaryKeyPairBySIN.TryGetValue(KID, out KeyPair)) {
                return KeyPair;
                }
            if (DictionaryKeyPairByAccount.TryGetValue(KID, out KeyPair)) {
                return KeyPair;
                }

            // finally search local persistence stores.
            return KeyPair.FindLocal(KID);
            }
        }
    }
