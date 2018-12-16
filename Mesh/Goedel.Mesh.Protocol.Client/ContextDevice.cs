using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Protocol;

namespace Goedel.Mesh.Protocol.Client {

    /// <summary>
    /// Class that represents a device's view of the current state of a
    /// Mesh profile
    /// </summary>
    public partial class ContextDevice {

        ///<summary>The Machine context</summary>
        public virtual IMeshMachine Machine { get; }

        ///<summary>The active profile. A client may have multiple profiles open at once on the
        ///same device but each one must be accessed through a different context.</summary>
        public ProfileMesh ProfileMesh;

        ///<summary>The active client connection to the service.</summary>
        protected MeshService MeshService;

        protected MeshClientSession MeshClientSession => meshClientSession ??
            new MeshClientSession(this).CacheValue(out meshClientSession);
        MeshClientSession meshClientSession;

        ///<summary>The account name</summary>
        protected string AccountName;

        ///<summary>The device profile</summary>
        public virtual ProfileDevice ProfileDevice { get; }

        DareMessage ProfileDeviceSigned => ProfileDevice.ProfileDeviceSigned;

        ///<summary>The active KeyCollection (from Machine)</summary>
        public KeyCollection KeyCollection => Machine.KeyCollection;

        #region // Convenience properties for accessing default stores and spools.
        public CatalogCredential CatalogCredential =>
            (catalogCredential ?? GetStore(CatalogCredential.Factory, CatalogCredential.Label).CacheValue(out catalogCredential)) as CatalogCredential;
        Store catalogCredential;

        public CatalogDevice CatalogDevice =>
            (catalogDevice ?? GetStore(CatalogDevice.Factory, CatalogDevice.Label).CacheValue(out catalogDevice)) as CatalogDevice;
        Store catalogDevice;

        public CatalogContact CatalogContact =>
            (catalogContact ?? GetStore(CatalogContact.Factory, CatalogContact.Label).CacheValue(out catalogContact)) as CatalogContact;
        Store catalogContact;

        public CatalogApplication CatalogApplication =>
            (catalogApplication ?? GetStore(CatalogApplication.Factory, CatalogApplication.Label).CacheValue(out catalogApplication)) as CatalogApplication;
        Store catalogApplication;


        public SpoolInbound SpoolInbound =>
            (spoolInbound ?? GetStore(SpoolInbound.Factory, SpoolInbound.Label).CacheValue(out spoolInbound)) as SpoolInbound;
        Store spoolInbound;

        public SpoolOutbound Outbound =>
            (spoolOutbound ?? GetStore(SpoolOutbound.Factory, SpoolOutbound.Label).CacheValue(out spoolOutbound)) as SpoolOutbound;
        Store spoolOutbound;
        #endregion
        #region // Convenience properties for accessing private keys.
        KeyPair KeySign => keySign ?? KeyCollection.LocatePrivate(ProfileDevice.DeviceSignatureKey.UDF).CacheValue(out keySign);
        KeyPair keySign;

        KeyPair KeyEncrypt => keyEncrypt ?? KeyCollection.LocatePrivate(ProfileDevice.DeviceEncryptiontionKey.UDF).CacheValue(out keyEncrypt);
        KeyPair keyEncrypt;

        KeyPair KeyAuthenticate => keyAuthenticate ?? KeyCollection.LocatePrivate(ProfileDevice.DeviceAuthenticationKey.UDF).CacheValue(out keyAuthenticate);
        KeyPair keyAuthenticate;
        #endregion

        ContextDevice(IMeshMachine machine, ProfileDevice profileDevice,
                    KeyPair keySign, KeyPair keyEncrypt, KeyPair keyAuthenticate) {
            Machine = machine;
            ProfileDevice = profileDevice;
            this.keySign = keySign;
            this.keyEncrypt = keyEncrypt;
            this.keyAuthenticate = keyAuthenticate;
            }

        /// <summary>
        /// Construct a context connecting to an existing profile.
        /// </summary>
        /// <param name="machine">The Machine context in which the account data is stored.</param>
        /// <param name="accountName">Select profile by account name.</param>
        /// <param name="deviceUDF">Select profile by device profile.</param>
        public ContextDevice(
                    IMeshMachine machine, 
                    string accountName=null,
                    string deviceUDF=null) {
            Machine = machine;
            ProfileMesh = Machine.GetConnection(accountName, deviceUDF);
            }

        /// <summary>
        /// Generate a new device profile and register to the specified account.
        /// </summary>
        /// <param name="machine">The Machine context to which the account data is to be stored.</param>
        /// <param name="algorithmSign">The signature algorithm.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="algorithmAuthenticate">The authenticaton algorithm.</param>
        /// <returns>The newly created context.</returns>
        public static ContextDevice Generate(
                IMeshMachine machine = null,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {

            machine = machine ?? MeshMachine.GetMachine();
            var KeyCollection = machine.KeyCollection;

            algorithmSign = algorithmSign.DefaultMeta(CryptoAlgorithmID.Ed448);
            algorithmEncrypt = algorithmEncrypt.DefaultMeta(CryptoAlgorithmID.Ed448);
            algorithmAuthenticate = algorithmAuthenticate.DefaultMeta(CryptoAlgorithmID.Ed448);

            // Create the key set. 
            var keySign = KeyPair.Factory(algorithmSign, KeySecurity.Device, KeyCollection, keyUses: KeyUses.Sign);
            var keyEncrypt = KeyPair.Factory(algorithmEncrypt, KeySecurity.Device, KeyCollection, keyUses: KeyUses.Encrypt);
            var keyAuthenticate = KeyPair.Factory(algorithmAuthenticate, KeySecurity.Device, keyUses: KeyUses.Encrypt);

            // Generate the profile
            var Profile = Mesh.ProfileDevice.Generate(keySign, keyEncrypt, keyAuthenticate);

            // Register the profile locally
            machine.Register(Profile);

            return new ContextDevice(machine, Profile, keySign, keyEncrypt, keyAuthenticate);

            }

        /// <summary>
        /// Generate a new Master profile.
        /// </summary>
        /// <param name="algorithmSign"></param>
        /// <param name="algorithmEncrypt"></param>
        /// <returns></returns>
        public ContextMaster GenerateMaster(
            CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
            CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            algorithmSign = algorithmSign.DefaultMeta(CryptoAlgorithmID.Ed448);
            algorithmEncrypt = algorithmEncrypt.DefaultMeta(CryptoAlgorithmID.Ed448);

            var keySign = KeyPair.Factory(algorithmSign, KeySecurity.Master, KeyCollection, keyUses: KeyUses.Sign);
            var keyEncrypt = KeyPair.Factory(algorithmEncrypt, KeySecurity.Master, KeyCollection, keyUses: KeyUses.Encrypt);


            var Profile = Mesh.ProfileMaster.Generate(ProfileDevice, keySign, keyEncrypt);


            // Register the profile locally
            Machine.Register(Profile);
            return new ContextMaster(this, Profile);



            }

        public ProfileMaster Recover(DareMessage escrow, KeyShare[] shares) {

            var secret = new Secret(shares);
            var cryptoStack = new CryptoStack(secret, CryptoAlgorithmID.AES256CBC) {
                Salt = escrow.Header.Salt
                };
            var Decrypted = cryptoStack.DecodeBody(escrow.Body);

            var escrowedKeySet = EscrowedKeySet.FromJSON(Decrypted.JSONReader(), true);

            var masterSignatureKey = escrowedKeySet.MasterSignatureKey.GetKeyPair(KeySecurity.Exportable);
            var profileMaster = ProfileMaster.Generate(ProfileDevice, masterSignatureKey,
                null);

            return profileMaster;
            }





        public Dictionary<string, Store> DictionaryStores = new Dictionary<string, Store>();


        /// <summary>
        /// Return catalog or container by name, using the cached value if it exists or opening it otherwise.
        /// </summary>
        /// <param name="storeFactoryDelegate">The store creation delegate</param>
        /// <param name="name">The catalog or spool name.</param>
        /// <returns>The opened store.</returns>
        public Store GetStore(
                StoreFactoryDelegate storeFactoryDelegate, string name) {

            if (DictionaryStores.TryGetValue(name, out var store)) {
                return store;
                }
            store = storeFactoryDelegate(Machine.DirectoryMesh, name, null, KeyCollection);
            DictionaryStores.Add(name, store);

            return store;
            }


        public DareMessage SignContact(string recipient, Contact contact) {
            var signedContact = DareMessage.Encode(contact.GetBytes(tag: true),
                    SigningKey: KeySign, ContentType: "application/mmm");

            var request = new MessageContactRequest() {
                Contact = signedContact,
                Recipient = recipient
                };

            return Sign(request);
            }

        protected DareMessage Sign (JSONObject data) =>
                    DareMessage.Encode(data.GetBytes(tag: true),
                        SigningKey: keySign, ContentType: "application/mmm");


        }

    }
