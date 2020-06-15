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

        /// <summary>
        /// Maintain a client key collection.
        /// </summary>
        /// <param name="catalogHost">The machine parameters.</param>
        /// <param name="keyCollection">The base key collection.</param>
        public KeyCollectionClient(MeshHost catalogHost, KeyCollection keyCollection) {
            keyCollectionBase = keyCollection;
            this.catalogHost = catalogHost;
            }


        /// <summary>
        /// Persist a key to the underlying key collection.
        /// </summary>
        /// <param name="udf">The identifier under which the key is to be persisted.</param>
        /// <param name="privateKey">The key to persist.</param>
        /// <param name="exportable">If true, the key is bound to the current machine and cannot
        /// be exported.</param>
        public override void Persist(string udf, IPKIXPrivateKey privateKey, bool exportable) =>
            keyCollectionBase.Persist(udf, privateKey, exportable);

        /// <summary>
        /// Persist a key to the underlying key collection.
        /// </summary>
        /// <param name="udf">The identifier under which the key is to be persisted.</param>
        /// <param name="joseKey">The key to persist.</param>
        /// <param name="exportable">If true, the key is bound to the current machine and cannot
        /// be exported.</param>
        public override void Persist(string udf, IJson joseKey, bool exportable) =>
            keyCollectionBase.Persist(udf, joseKey, exportable);

        /// <summary>
        /// Attempt to obtain a recipient with identifier <paramref name="keyID"/>.
        /// </summary>
        /// <param name="keyID">The key identifier to match.</param>
        /// <returns>The key pair if found.</returns>
        public override CryptoKey TryMatchRecipient(string keyID) =>
            keyCollectionBase.TryMatchRecipient(keyID) ?? TryMatchRecipientKeyPair(keyID);

        /// <summary>
        /// Attempt to obtain a private key with identifier <paramref name="keyID"/>.
        /// </summary>
        /// <param name="keyID">The key identifier to match.</param>
        /// <returns>The key pair if found as a JSON key.</returns>
        public override IJson LocatePrivateKey(string keyID) => 
            keyCollectionBase.LocatePrivateKey(keyID);

        /// <summary>
        /// Attempt to obtain a private key with identifier <paramref name="keyID"/>.
        /// </summary>
        /// <param name="keyID">The key identifier to match.</param>
        /// <returns>The key pair if found.</returns>
        public override CryptoKey LocatePrivateKeyPair(string keyID) => 
            keyCollectionBase.LocatePrivateKeyPair(keyID);

        /// <summary>
        /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyID">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public override CryptoKey GetByAccountEncrypt(string keyID) {
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
        public override CryptoKey GetByAccountSign(string keyID) {
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
