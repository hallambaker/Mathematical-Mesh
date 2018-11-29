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

        public virtual IMeshMachine Machine { get; }
        public ProfileAccount ProfileAccount;


        public ConnectionState ConnectionState;
        public string Witness;


        protected MeshService MeshService;
        protected string AccountName;

        public virtual ProfileDevice ProfileDevice { get; }
        public DareMessage ProfileDeviceSigned => ProfileDevice.ProfileDeviceSigned;


        public KeyCollection KeyCollection => Machine.KeyCollection;

        ContextDevice(IMeshMachine machine, ProfileDevice profileDevice,
                    KeyPair keySign, KeyPair keyEncrypt, KeyPair keyAuthenticate) {
            Machine = machine;
            ProfileDevice = profileDevice;
            this.keySign = keySign;
            this.keyEncrypt = keyEncrypt;
            this.keyAuthenticate = keyAuthenticate;
            }


        public ContextDevice(
                    IMeshMachine machine, 
                    string accountName=null,
                    string deviceUDF=null) {
            Machine = machine;
            ProfileAccount = Machine.GetConnection(accountName, deviceUDF);


            throw new NYI();
            }



        KeyPair KeySign => keySign ?? KeyCollection.LocatePrivate(ProfileDevice.DeviceSignatureKey.UDF).CacheValue(out keySign);
        KeyPair keySign;

        KeyPair KeyEncrypt => keyEncrypt ?? KeyCollection.LocatePrivate(ProfileDevice.DeviceEncryptiontionKey.UDF).CacheValue(out keyEncrypt);
        KeyPair keyEncrypt;

        KeyPair KeyAuthenticate => keyAuthenticate ?? KeyCollection.LocatePrivate(ProfileDevice.DeviceAuthenticationKey.UDF).CacheValue(out keyAuthenticate);
        KeyPair keyAuthenticate;

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



        public bool Complete(string account) => throw new NYI();

        public CatalogCredential CatalogCredential =>
            catalogCredential ?? GetCatalogCredential().CacheValue(out catalogCredential);
        CatalogCredential catalogCredential;

        public CatalogDevice CatalogDevice =>
            catalogDevice ?? GetCatalogDevice().CacheValue(out catalogDevice);
        CatalogDevice catalogDevice;

        public CatalogContact CatalogContact =>
            catalogContact ?? GetCatalogContact().CacheValue(out catalogContact);
        CatalogContact catalogContact;

        public CatalogApplication CatalogApplication =>
            catalogApplication ?? GetCatalogApplication().CacheValue(out catalogApplication);
        CatalogApplication catalogApplication;



        public CatalogCredential GetCatalogCredential(string name = null) =>
            new CatalogCredential(Machine.DirectoryMesh, name);

        public CatalogDevice GetCatalogDevice(string name = null) =>
            new CatalogDevice(Machine.DirectoryMesh, name);

        public CatalogContact GetCatalogContact(string name = null) =>
            new CatalogContact(Machine.DirectoryMesh, name);

        public CatalogApplication GetCatalogApplication(string name = null) =>
            new CatalogApplication(Machine.DirectoryMesh, name);


        public SpoolInbound SpoolInbound =>
            spoolInbound ?? GetSpoolInbound().CacheValue(out spoolInbound);
        SpoolInbound spoolInbound;

        public SpoolOutbound SpoolOutbound =>
            spoolOutbound ?? GetSpoolOutbound().CacheValue(out spoolOutbound);
        SpoolOutbound spoolOutbound;



        public SpoolInbound GetSpoolInbound(string name = null) =>
            new SpoolInbound(Machine.DirectoryMesh, name);

        public SpoolOutbound GetSpoolOutbound(string name = null) =>
            new SpoolOutbound(Machine.DirectoryMesh, name);

        public SpoolOutbound GetSpoolPending(string name = null) =>
            new SpoolOutbound(Machine.DirectoryMesh, name);


        //public DareMessage ConnectionRequest(string Profile) {
        //    var request = ProfileDevice.ConnectionRequest(Profile);

        //    // get device signing key here

        //    return DareMessage.Encode(request.GetBytes(tag: true),
        //            SigningKey: keySign, ContentType: "application/mmm");
        //    }

        public DareMessage SignContact(string recipient, Contact contact) {
            var signedContact = DareMessage.Encode(contact.GetBytes(tag: true),
                    SigningKey: KeySign, ContentType: "application/mmm");

            var request = new MessageContactRequest() {
                Contact = signedContact,
                Recipient = recipient
                };

            // get device signing key here

            return Sign(request);
            }

        protected DareMessage Sign (JSONObject data) =>
                    DareMessage.Encode(data.GetBytes(tag: true),
                        SigningKey: keySign, ContentType: "application/mmm");






        }

    }
