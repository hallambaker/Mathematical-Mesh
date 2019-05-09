using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using Goedel.Protocol;
using Goedel.Cryptography.Jose;

namespace Goedel.Mesh.Client {

    /// <summary>
    /// Class that represents a device's view of the current state of a
    /// Mesh profile
    /// </summary>
    public partial class ContextDevice : Disposable {





        public Dictionary<string, Store> DictionaryStores = new Dictionary<string, Store>();
        protected override void Disposing() {

            foreach (var entry in DictionaryStores) {
                Console.Write($"Close store{entry.Key}");
                entry.Value.Dispose();
                }
            }


        ///<summary>The Machine context</summary>
        public virtual IMeshMachine MeshMachine { get; }

        ///<summary>The active profile. A client may have multiple profiles open at once on the
        ///same device but each one must be accessed through a different context.</summary>
        public AssertionAccount AssertionAccount {
            get => assertionAccount;
            protected set {
                assertionAccount = value;
                if (assertionAccount != null) {
                    ProfileMaster = assertionAccount.ProfileMaster;
                    }
                }
            }
        AssertionAccount assertionAccount;

        public bool IsAdministrator => AdministratorKey != null;


        KeyPair AdministratorKey = null;


        ///<summary>The master profile</summary>
        public virtual ProfileMaster ProfileMaster {
            get => profileMaster;
            protected set {
                profileMaster = value;
                AdministratorKey = null;
                if (profileMaster?.OnlineSignatureKeys != null ) {
                    foreach (var admin in profileMaster.OnlineSignatureKeys) {
                        AdministratorKey = KeyCollection.LocatePrivate(admin.KeyPair.UDF);
                        }
                    }

                }
            }
        ProfileMaster profileMaster;





        ///<summary>The active client connection to the service.</summary>
        protected MeshService MeshService;

        protected MeshClientSession MeshClientSession => meshClientSession ??
            new MeshClientSession(this).CacheValue(out meshClientSession);
        MeshClientSession meshClientSession;

        ///<summary>If true, the associated device profile is the default</summary>
        public bool DefaultDevice;

        ///<summary>If true, the associated personal profile is the default</summary>
        public bool DefaultPersonal;

        ///<summary>The account name</summary>
        public string AccountName => AssertionAccount.Account;

        ///<summary>The device profile</summary>
        public virtual ProfileDevice ProfileDevice { get; private set; }

        DareMessage ProfileDeviceSigned => ProfileDevice.DareMessage;

        ///<summary>The active KeyCollection (from Machine)</summary>
        public KeyCollection KeyCollection => MeshMachine.KeyCollection;

        public CatalogEntryDevice CatalogEntryDevice;


        #region // Convenience properties for accessing default stores and spools.
        //public CatalogCredential CatalogCredential =>
        //    (catalogCredential ?? GetStore(CatalogCredential.Factory, CatalogCredential.Label).CacheValue(out catalogCredential)) as CatalogCredential;
        //Store catalogCredential;

        public CatalogDevice GetCatalogDevice() =>
            (catalogDevice ?? GetStore(CatalogDevice.Label).CacheValue(out catalogDevice)) as CatalogDevice;
        Store catalogDevice = null;

        public CatalogContact GetCatalogContact() =>
            (catalogContact ?? GetStore(CatalogContact.Label).CacheValue(out catalogContact)) as CatalogContact;
        Store catalogContact;

        public CatalogApplication GetCatalogApplication() =>
            (catalogApplication ?? GetStore(CatalogApplication.Label).CacheValue(out catalogApplication)) as CatalogApplication;
        Store catalogApplication;



        public CatalogBookmark GetCatalogBookmark() =>
            GetStore(CatalogBookmark.Label) as CatalogBookmark;

        public CatalogCredential GetCatalogCredential() =>
            GetStore(CatalogCredential.Label) as CatalogCredential;


        public CatalogCalendar GetCatalogCalendar() =>
            GetStore(CatalogCalendar.Label) as CatalogCalendar;


        public CatalogNetwork GetCatalogNetwork() =>
            GetStore(CatalogNetwork.Label) as CatalogNetwork;



        public Spool SpoolInbound =>
            (spoolInbound ?? GetStore(Spool.SpoolInbound).CacheValue(out spoolInbound)) as Spool;
        Store spoolInbound;

        public Spool Outbound =>
            (spoolOutbound ?? GetStore(Spool.SpoolOutbound).CacheValue(out spoolOutbound)) as Spool;
        Store spoolOutbound;
        #endregion
        #region // Convenience properties for accessing private keys.
        KeyPair DeviceSign => deviceSign ?? KeyCollection.LocatePrivate(ProfileDevice.KeySignature.UDF).CacheValue(out deviceSign);
        KeyPair deviceSign;

        KeyPair DeviceEncrypt => deviceEncrypt ?? KeyCollection.LocatePrivate(ProfileDevice.KeyEncryption.UDF).CacheValue(out deviceEncrypt);
        KeyPair deviceEncrypt;

        KeyPair DeviceAuthenticate => deviceAuthenticate ?? KeyCollection.LocatePrivate(ProfileDevice.KeyAuthentication.UDF).CacheValue(out deviceAuthenticate);
        KeyPair deviceAuthenticate;


        KeyPair KeySign;
        KeyPair KeyEncrypt;
        KeyPair KeyAuthenticate;

        #endregion


        #region // Constructors
        public ContextDevice(IMeshMachine machine, ProfileDevice profileDevice,
                    KeyPair keySign = null, KeyPair keyEncrypt = null, KeyPair keyAuthenticate = null) {
            MeshMachine = machine;
            ProfileDevice = profileDevice;
            this.deviceSign = keySign;
            this.deviceEncrypt = keyEncrypt;
            this.deviceAuthenticate = keyAuthenticate;
            }

        /// <summary>
        /// Construct a context connecting to an existing profile.
        /// </summary>
        /// <param name="machine">The Machine context in which the account data is stored.</param>
        /// <param name="accountName">Select profile by account name.</param>
        /// <param name="deviceUDF">Select profile by device profile.</param>
        public ContextDevice(
                    IMeshMachine machine,
                    string accountName = null,
                    string deviceUDF = null) {
            MeshMachine = machine;
            AssertionAccount = MeshMachine.GetConnection(accountName, deviceUDF);
            }

        public ContextDevice(
                    IMeshMachine machine,
                    ProfileMaster profileMaster,
                    AssertionAccount profileMesh,
                    ProfileDevice profileDevice) : this(machine, profileDevice) {
            ProfileMaster = profileMaster;
            AssertionAccount = profileMesh;
            }
        #endregion

        #region // Device profile operations
        //public ContextDevice ContextDeviceHack => this;

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
                    CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default,
                    string description = null) {

            machine = machine ?? Mesh.MeshMachine.GetMachine();
            var keyCollection = machine.KeyCollection;

            var profile = ProfileDevice.Generate(keyCollection, algorithmSign, algorithmEncrypt, algorithmAuthenticate);

            // Register the profile locally
            machine.Register(profile.DareMessage);


            // Create the self contact record and add to the catalog

            return new ContextDevice(machine, profile);

            }




        /// <summary>
        /// Generate a new Master profile.
        /// </summary>
        /// <param name="algorithmSign"></param>
        /// <param name="algorithmEncrypt"></param>
        /// <returns></returns>
        public void GenerateMaster(
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default,
                string description = null) {



            if (ProfileDevice == null) {
                ProfileDevice = ProfileDevice.Generate(KeyCollection, algorithmSign, algorithmEncrypt, algorithmAuthenticate);
                }

            algorithmSign = algorithmSign.DefaultAlgorithmSign();
            algorithmEncrypt = algorithmEncrypt.DefaultAlgorithmEncrypt();

            var keySign = KeyPair.Factory(algorithmSign, KeySecurity.Master, KeyCollection, keyUses: KeyUses.Sign);
            var keyEncrypt = KeyPair.Factory(algorithmEncrypt, KeySecurity.Master, KeyCollection, keyUses: KeyUses.Encrypt);

            var profile = Mesh.ProfileMaster.Generate(ProfileDevice, keySign, keyEncrypt);

            CatalogEntryDevice = profile.Add(MeshMachine, ProfileDevice, true);

            // Register the profile locally
            MeshMachine.Register(ProfileDevice.DareMessage);
            MeshMachine.Register(profile.DareMessage);
            MeshMachine.Register(Encode(CatalogEntryDevice));

            ProfileMaster = profile;
            }
        #endregion



        public DareMessage Encode(CatalogEntryDevice catalogEntryDevice) =>
            catalogEntryDevice.Encode(KeySign);

        public static ContextDevice GetContextDevice(
                    IMeshMachine machine,
                    string deviceUDF,
                    string deviceID) {
            var machineClient = machine as IMeshMachineClient;
            return machineClient.CatalogHost.GetContextDevice(deviceID: deviceID, deviceUDF: deviceUDF);

            }


        public ProfileMaster Recover(DareMessage escrow, IEnumerable<string> shares) {
            var secret = new Secret(shares);
            return Recover(escrow, secret);
            }

        public ProfileMaster Recover(DareMessage escrow, KeyShare[] shares) {
            var secret = new Secret(shares);
            return Recover(escrow, secret);
            }

        public ProfileMaster Recover(DareMessage escrow, Secret secret) {
            var escrowedKeySet = RecoverKeySet(escrow, secret);

            var masterSignatureKey = escrowedKeySet.MasterSignatureKey.GetKeyPair(KeySecurity.Exportable);
            var profileMaster = ProfileMaster.Generate(ProfileDevice, masterSignatureKey,
                null);

            return profileMaster;
            }


        public EscrowedKeySet RecoverKeySet(DareMessage escrow, Secret secret) {


            var cryptoStack = new CryptoStack(secret, CryptoAlgorithmID.AES256CBC) {
                Salt = escrow.Header.Salt
                };
            var Decrypted = cryptoStack.DecodeBody(escrow.Body);

            return EscrowedKeySet.FromJSON(Decrypted.JSONReader(), true);

            }

        public void Add(MeshMessage selfMessage, string catalogID = null, CatalogEntry entry = null) {
            MeshService = MeshService ?? MeshMachine.GetMeshClient(AccountName);

            selfMessage.MessageID = selfMessage.MessageID ?? UDF.Nonce(200);

            var message = DareMessage.Encode(selfMessage.GetBytes());

            var uploadRequest = new UploadRequest() {
                Account = AccountName,
                Self = new List<DareMessage> { message }
                };

            DareMessage catalogEntry = null;
            Catalog catalog = null;

            if (catalogID != null) {
                catalog = GetStore(catalogID) as Catalog;
                catalogEntry = catalog.ContainerEntry(entry, ContainerPersistenceStore.EventNew);
                var update = new ContainerUpdate() {
                    Container = catalogID,
                    Message = new List<DareMessage> { catalogEntry }
                    };
                uploadRequest.Updates = new List<ContainerUpdate> { update };
                }

            var result = MeshService.Upload(uploadRequest, MeshClientSession);

            if (result.Success()) {
                if (catalog != null) {
                    catalog.AppendDirect(catalogEntry);
                    }
                }
            }


        #region // store and catalog management


        static int Devicecount = 0;
        int devicecount = Devicecount++;

        /// <summary>
        /// Return catalog or container by name, using the cached value if it exists or opening it otherwise.
        /// </summary>
        /// <param name="storeFactoryDelegate">The store creation delegate</param>
        /// <param name="name">The catalog or spool name.</param>
        /// <returns>The opened store.</returns>
        public Store GetStore(string name) {

            if (DictionaryStores.TryGetValue(name, out var store)) {
                return store;
                }
            Console.WriteLine($"Open store {name} on {MeshMachine.DirectoryMesh} {devicecount}");

            store = MakeStore(name);
            DictionaryStores.Add(name, store);

            return store;
            }

        Store MakeStore(string name) {

            switch (name) {
                case Spool.SpoolInbound: return new Spool(MeshMachine.DirectoryMesh, name, null, KeyCollection);
                case Spool.SpoolOutbound: return new Spool(MeshMachine.DirectoryMesh, name, null, KeyCollection);
                case Spool.SpoolArchive: return new Spool(MeshMachine.DirectoryMesh, name, null, KeyCollection);

                case CatalogCredential.Label: return new CatalogCredential(MeshMachine.DirectoryMesh, name, null, KeyCollection);
                case CatalogDevice.Label: return new CatalogDevice(MeshMachine.DirectoryMesh, name, null, KeyCollection);
                case CatalogContact.Label: return new CatalogContact(MeshMachine.DirectoryMesh, name, null, KeyCollection);
                case CatalogCalendar.Label: return new CatalogCalendar(MeshMachine.DirectoryMesh, name, null, KeyCollection);
                case CatalogBookmark.Label: return new CatalogBookmark(MeshMachine.DirectoryMesh, name, null, KeyCollection);
                case CatalogNetwork.Label: return new CatalogNetwork(MeshMachine.DirectoryMesh, name, null, KeyCollection);


                case CatalogApplication.Label: return new CatalogApplication(MeshMachine.DirectoryMesh, name, null, KeyCollection);

                }

            throw new NYI();
            }
        #endregion

        public DareMessage SignContact(string recipient, Contact contact) {
            var signedContact = DareMessage.Encode(contact.GetBytes(tag: true),
                    signingKey: DeviceSign, contentType: "application/mmm");

            var request = new MessageContactRequest() {
                Contact = signedContact,
                Recipient = recipient
                };

            return Sign(request);
            }

        protected DareMessage Sign(JSONObject data) =>
                    DareMessage.Encode(data.GetBytes(tag: true),
                        signingKey: DeviceSign, contentType: "application/mmm");



        #region // process requests
        public void ProcessContactRequest(
                    MessageContactRequest messageContactRequest,
                    bool Accept) {
            if (!Accept) {
                // here decide if we are going to send a rejection notice

                // if sending notification, do so.
                throw new NYI();
                }

            var contact = messageContactRequest.Contact;

            GetCatalogContact().Add(contact);
            }

        public void ProcessConfirmationRequest(
                    MessageConfirmationRequest messageConfirmationRequest,
                    bool accept) {
            var result = ConfirmationResponse(
                messageConfirmationRequest, accept);
            }
        #endregion


        #region // Master profile operations
        /// <summary>
        /// Sign a device or application profile for entry in a catalog
        /// </summary>
        /// <param name="Profile"></param>
        /// <returns></returns>
        public DareMessage MakeAdministrator(ProfileDevice Profile) => throw new NYI();




        public (DareMessage, KeyShare[]) Escrow(int shares, int quorum, int bits = 128) {

            var secret = new Secret(bits);
            var keyShares = secret.Split(shares, quorum);
            var cryptoStack = new CryptoStack(secret, CryptoAlgorithmID.AES256CBC);

            var MasterSignatureKeyPair = KeyCollection.LocatePrivate(ProfileMaster.KeySignature.UDF);
            var MasterSignatureKey = Key.FactoryPrivate(MasterSignatureKeyPair);
            var MasterEscrowKeys = new List<Key>();

            var EscrowedKeySet = new EscrowedKeySet() {
                MasterSignatureKey = MasterSignatureKey,
                MasterEscrowKeys = MasterEscrowKeys
                };

            var message = new DareMessage(cryptoStack, EscrowedKeySet.GetJson(true));

            return (message, keyShares);
            }
        #endregion

        #region // Administrator operations

        public MessageConnectionPIN GetPIN() {

            IsAdministrator.AssertTrue(NotAdministrator.Throw);

            var message = new MessageConnectionPIN() {
                Account = AccountName,
                Expires = DateTime.Now.AddHours(4),
                PIN = Cryptography.UDF.Nonce(125)
                };
            Add(message);
            return message;
            }



        public MeshResult CreateAccount(string accountName,
                    CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            IsAdministrator.AssertTrue(NotAdministrator.Throw);

            algorithmEncrypt = algorithmEncrypt.DefaultMeta(CryptoAlgorithmID.Ed448);
            var keyEncrypt = KeyPair.Factory(algorithmEncrypt, KeySecurity.Device, KeyCollection, keyUses: KeyUses.Encrypt);

            var profileMesh = new AssertionAccount() {
                Account = accountName,
                MasterProfile = ProfileMaster.DareMessage,
                AccountEncryptionKey = new PublicKey(keyEncrypt.KeyPairPublic())
                };

            this.AssertionAccount = profileMesh;
            var profileMeshSigned = Sign(profileMesh);

            var catalogEntryDevice = MakeCatalogEntryDevice(ProfileDevice);
            var catalogEntryDeviceSigned = GetCatalogDevice().ContainerEntry(catalogEntryDevice, ContainerPersistenceStore.EventNew);


            var contactEntry = SetContactSelf();

            var createRequest = new CreateRequest() {
                MeshProfile = profileMeshSigned,
                CatalogEntryDevices = new List<DareMessage> { catalogEntryDeviceSigned },
                CatalogEntryContacts = new List<CatalogEntryContact> { contactEntry }
                };

            // We create a new meshClientSession because this won't have the 
            var meshClientSession = new MeshClientSession(this);


            MeshService = MeshMachine.GetMeshClient(accountName);

            var result = MeshService.CreateAccount(createRequest, meshClientSession);

            // if successful write out to host file
            MeshMachine.Register(profileMeshSigned);
            MeshMachine.Register(catalogEntryDeviceSigned);

            GetCatalogDevice().Apply(catalogEntryDeviceSigned);

            return new MeshResult() { MeshResponse = result };
            }







        public MeshResult DeleteAccount() {
            IsAdministrator.AssertTrue(NotAdministrator.Throw);

            var deleteRequest = new DeleteRequest() { Account = AccountName };
            var result = MeshService.DeleteAccount(deleteRequest, MeshClientSession);
            return new MeshResult() { MeshResponse = result };
            }

        public CatalogEntryContact SetContactSelf() {
            var contact = new Contact() {
                Identifier = AssertionAccount.UDF,
                Account = AccountName,
                };
            return SetContactSelf(contact);
            }

        public CatalogEntryContact SetContactSelf(Contact contact, string label = null) {
            IsAdministrator.AssertTrue(NotAdministrator.Throw);

            var signedContact = Sign(contact);
            var catalogEntryContact = new CatalogEntryContact(signedContact) {
                Key = AccountName,
                Permissions = new List<Permission> {
                    new Permission () {Name ="self" }
                    }
                };
            Add(catalogEntryContact);
            return catalogEntryContact;
            }


        public MeshResult Add(CatalogEntryContact catalogEntryContact) =>
            Add(GetCatalogContact(), catalogEntryContact);


        /// <summary>
        /// Sign a device or application profile for entry in a catalog
        /// </summary>
        /// <param name="Profile"></param>
        /// <returns></returns>
        public DareMessage Add(Assertion profile) => throw new NYI();

        public void ProcessConnectionRequest(
            MessageConnectionRequest messageConnectionRequest,
            MessageConnectionPIN messageConnectionPIN) {
            
            IsAdministrator.AssertTrue(NotAdministrator.Throw);

            "Check witness value".TaskValidate(); // Hack: Should check the witness value here.
            "Compute nonce with PIN".TaskValidate(); // Hack: Use the nonce value to check the witness value

            ProcessConnectionRequest(messageConnectionRequest, true);
            }


        public void ProcessConnectionRequest(
                    MessageConnectionRequest messageConnectionRequest,
                    bool accept) {
            IsAdministrator.AssertTrue(NotAdministrator.Throw);
            if (accept) {

                var profile = ProfileDevice.Decode(messageConnectionRequest.DeviceProfile);
                var catalogEntryDevice = MakeCatalogEntryDevice(profile);

                // create the completion message
                var completion = new MeshMessageComplete(messageConnectionRequest.MessageID,
                    MeshMessageComplete.Accept);


                Add(completion, CatalogDevice.Label, catalogEntryDevice);
                }
            else {
                // mark the connection request as having been rejected
                var completion = new MeshMessageComplete(messageConnectionRequest.MessageID,
                    MeshMessageComplete.Reject);
                Add(completion);
                }
            }

        #endregion

        }

    }
