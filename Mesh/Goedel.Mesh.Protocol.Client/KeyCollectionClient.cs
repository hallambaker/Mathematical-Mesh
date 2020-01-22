using Goedel.Cryptography;
using Goedel.Cryptography.PKIX;
using Goedel.Utilities;

namespace Goedel.Mesh.Client {


    /// <summary>
    /// A wrapper around a KeyCollection that allows other key resolution sources to be added.
    /// This may well be unnecessary due to the move from multiple frameworks to .Core alone.
    /// </summary>
    public class KeyCollectionClient : KeyCollection {

        KeyCollection keyCollectionBase;
        MeshHost catalogHost;

        public KeyCollectionClient(MeshHost catalogHost, KeyCollection keyCollection) {
            keyCollectionBase = keyCollection;
            this.catalogHost = catalogHost;
            }


        /// <summary>
        /// Persist a key to the underlying key collection.
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="exportable"></param>
        public override void Persist(string udf, IPKIXPrivateKey privateKey, bool exportable) =>
            keyCollectionBase.Persist(udf, privateKey, exportable);


        public override void Persist(string udf, IJson joseKey, bool exportable) =>
            keyCollectionBase.Persist(udf, joseKey, exportable);

        public override KeyPair TryMatchRecipient(string keyID) =>
                    keyCollectionBase.TryMatchRecipient(keyID);

        public override IJson LocatePrivateKey(string udf) => 
            keyCollectionBase.LocatePrivateKey(udf);


        public override KeyPair LocatePrivateKeyPair(string udf) => 
            keyCollectionBase.LocatePrivateKeyPair(udf);

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
