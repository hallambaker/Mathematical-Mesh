using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.IO;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.PKIX;

namespace Goedel.Mesh.Protocol.Client {
    public class KeyCollectionClient : KeyCollection {

        KeyCollection KeyCollectionBase;
        CatalogHost CatalogHost;

        public KeyCollectionClient(CatalogHost catalogHost, KeyCollection keyCollection) {
            KeyCollectionBase = keyCollection;
            CatalogHost = catalogHost;
            }


        /// <summary>
        /// Persist a key to the underlying key collection.
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="Exportable"></param>
        public override void Persist(IPKIXPrivateKey privateKey, bool Exportable) =>
            KeyCollectionBase.Persist(privateKey, Exportable);


        public override KeyPair TryMatchRecipient(string keyID) => 
                    KeyCollectionBase.TryMatchRecipient(keyID);



        /// <summary>
        /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyID">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public override KeyPair GetByAccountEncrypt(string keyID) {
            // Check to see if we have an account by that name
            var profile = CatalogHost.GetProfileByAccount(keyID) as ProfileMesh;
            if (profile != null) {
                return profile.AccountEncryptionKey.KeyPair;
                }

            // Check the Contacts file 


            // Check the Omnibroker service


            // last gasp - check on the platform
            return KeyCollectionBase.GetByAccountEncrypt(keyID);
            }

        /// <summary>
        /// Resolve a private key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyID">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public override KeyPair GetByAccountSign(string keyID) {
            // Check to see if we have an account by that name


            // Check the Contacts file 


            // Check the Omnibroker service


            // last gasp - check on the platform
            return KeyCollectionBase.GetByAccountSign(keyID);
            }

        }
    }
