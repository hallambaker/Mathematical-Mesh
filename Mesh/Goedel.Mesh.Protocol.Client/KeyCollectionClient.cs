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

namespace Goedel.Mesh.Client {
    public class KeyCollectionClient : KeyCollection {

        KeyCollection keyCollectionBase;
        HostMesh catalogHost;

        public KeyCollectionClient(HostMesh catalogHost, KeyCollection keyCollection) {
            keyCollectionBase = keyCollection;
            this.catalogHost = catalogHost;
            }


        /// <summary>
        /// Persist a key to the underlying key collection.
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="Exportable"></param>
        public override void Persist(string udf, IPKIXPrivateKey privateKey, bool Exportable) =>
            keyCollectionBase.Persist(udf, privateKey, Exportable);


        public override KeyPair TryMatchRecipient(string keyID) => 
                    keyCollectionBase.TryMatchRecipient(keyID);



        /// <summary>
        /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyID">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public override KeyPair GetByAccountEncrypt(string keyID) {
            //// Check to see if we have an account by that name
            //if (CatalogHost.GetProfileMeshByAccount(keyID) is AssertionAccount profile) {
            //    return profile.AccountEncryptionKey.KeyPair;
            //    }

            // Check the Contacts file 
            keyID.Keep();

            // Check the Omnibroker service


            // last gasp - check on the platform
            return keyCollectionBase.GetByAccountEncrypt(keyID);
            }

        /// <summary>
        /// Resolve a private key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyID">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public override KeyPair GetByAccountSign(string keyID) {
            // Check to see if we have an account by that name

            //var profile = CatalogHost.GetProfileDeviceByAccount(keyID);
            //if (profile != null) {
            //    return profile.SignatureKey.KeyPair;
            //    }

            //var profile = CatalogHost.GetProfileByAccount(keyID) as CatalogEntryDevice;
            //if (profile != null) {
            //    return profile.ProfileDevice.DeviceSignatureKey.KeyPair;
            //    }

            // Check the Contacts file 
            keyID.Keep();

            // Check the Omnibroker service


            // last gasp - check on the platform
            return keyCollectionBase.GetByAccountSign(keyID);
            }

        }
    }
