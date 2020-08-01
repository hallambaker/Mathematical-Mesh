using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using System;
using System.Collections.Generic;
using System.IO;
using Goedel.Protocol;

namespace Goedel.Mesh.Client {

    /// <summary>
    /// Context for interacting with a Mesh Account
    /// </summary>
    public partial class ContextUser : ContextAccount {

        #region // Public properties

        ///<summary>The account profile</summary>
        public override Profile Profile => ProfileAccount;


        /////<summary>The enclosing mesh context.</summary>
        //public override ContextMesh ContextMesh => throw new NYI();

        ///<summary>The account entry</summary>
        public AccountEntry AccountEntry { get; private set; }

        ///<summary>Convenience accessor for the account connection</summary>
        ConnectionAccount ConnectionAccount => AccountEntry.ConnectionAccount;

        ///<summary>Convenience accessor for the connection.</summary>
        public override Connection Connection => ConnectionAccount;



        ///<summary>The cataloged device</summary>
        public virtual CatalogedDevice CatalogedDevice => CatalogedMachine?.CatalogedDevice;

        ///<summary>The profile</summary>
        public ProfileUser ProfileAccount => CatalogedDevice?.ProfileAccount;

        ///<summary>The connection device</summary>
        public ConnectionDevice ConnectionDevice => CatalogedDevice?.ConnectionDevice;

        ///<summary>The device activation</summary>
        public ActivationDevice ActivationDevice => CatalogedDevice?.GetActivationDevice(KeyCollection);

        ///<summary>The device key generation seed</summary>
        protected PrivateKeyUDF DeviceKeySeed;

        ///<summary>The device key generation seed</summary>
        protected PrivateKeyUDF MeshSecretSeed;




        ///<summary>This context has the make device an adminitrator capability.</summary>
        public bool HasPrivilegeMakeAdministrator = false;

        ///<summary>This context has the add device capability.</summary>
        public bool HasPrivilegeAddDevice = false;

        ///<summary>This context has the messaging capability.</summary>
        public bool HasPrivilegeMessaging = false;


        KeyPair deviceDecrypt;
        KeyPair keySignature;
        KeyPair keyEncryption;
        KeyPair keyAuthentication;

        #endregion
        #region // Constructors

        /// <summary>
        /// Constructor, creates a <see cref="ContextUser"/> instance for the catalog entry 
        /// <paramref name="catalogedMachine"/> on machine <paramref name="meshHost"/>.
        /// </summary>
        /// <param name="catalogedMachine">Description of the device profile.</param>
        /// <param name="meshHost">The Mesh host to add the admin context to.</param>
        public ContextUser(
                MeshHost meshHost,
                CatalogedMachine catalogedMachine) : base (meshHost, catalogedMachine) {


            // unpack the device key seed and add it to the key collection
            // ToDo: Create a wrapper that allows the DeviceKeySeed to be a wrapper to an embedded device key
            DeviceKeySeed ??= ProfileDevice?.GetPrivateKeyUDF(MeshHost.MeshMachine);
            deviceDecrypt = DeviceKeySeed?.BasePrivate(MeshKeyType.DeviceEncrypt);
            KeyCollection.Add(deviceDecrypt);

            if (CatalogedDevice != null) {
                var activationKey = ActivationDevice.ActivationKey;
                activationKey.AssertNotNull(Internal.Throw);

                keySignature = DeviceKeySeed.ActivatePrivate(
                    activationKey, MeshKeyType.DeviceSign, KeyCollection);
                keyEncryption = DeviceKeySeed.ActivatePrivate(
                    activationKey, MeshKeyType.DeviceEncrypt, KeyCollection);
                keyAuthentication = DeviceKeySeed.ActivatePrivate(
                    activationKey, MeshKeyType.DeviceAuthenticate, KeyCollection);

                (keySignature.KeyIdentifier).AssertEqual(ConnectionDevice.KeySignature.UDF,
                        KeyActivationFailed.Throw);
                (keyEncryption.KeyIdentifier).AssertEqual(ConnectionDevice.KeyEncryption.UDF,
                        KeyActivationFailed.Throw);
                (keyAuthentication.KeyIdentifier).AssertEqual(ConnectionDevice.KeyAuthentication.UDF,
                        KeyActivationFailed.Throw);
                }

            }

        #endregion
        #region // Account creation 

        /// <summary>
        /// Create a new personal mesh and return an administration context for it.
        /// </summary>
        /// <param name="meshHost">The mesh host context that the mesh is going to be created on.</param>
        /// <param name="profileDevice">The device profile.</param>
        /// <param name="algorithmSign">The signature algorithm.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="algorithmAuthenticate">The authentication algorithm.</param>
        /// <param name="masterSecret">Specifies a seed from which to generate the ProfileMesh</param>
        /// <param name="deviceSecret">Specifies a seed from which to generate the ProfileDevice</param>
        /// <param name="persist">If <see langword="true"/> persist the secret seed value to
        /// <paramref name="meshHost"/>.</param>
        /// <returns>An administration context instance for the created profile.</returns>
        public static ContextUser CreateMesh(
                MeshHost meshHost,
                string serviceAddress = null,
                ProfileDevice profileDevice = null,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default,
                byte[] masterSecret = null,
                byte[] deviceSecret = null,
                bool? persist = null) {

            // Create the master profile.
            var secretSeedMaster = new PrivateKeyUDF(
                UdfAlgorithmIdentifier.MeshProfileMaster, algorithmEncrypt, algorithmSign,
                algorithmAuthenticate, masterSecret);
            persist ??= masterSecret == null;

            var profileAccount = new ProfileUser(meshHost.KeyCollection, secretSeedMaster, serviceAddress, persist == true);

            profileDevice ??= new ProfileDevice(meshHost.KeyCollection,
                algorithmEncrypt, algorithmSign, algorithmAuthenticate,
                deviceSecret, true);

            return CreateMesh(meshHost, profileAccount, profileDevice, algorithmSign);
            }


        /// <summary>
        /// Create a new personal mesh.
        /// </summary>
        /// <param name="meshHost">The machine context that the mesh is going to be created on.</param>
        /// <param name="profileDevice">The device profile.</param>
        /// <param name="profileMaster">The mesh profile.</param>
        /// <param name="algorithmSign">The algorithm to use for the adminitrator signature key</param>
        /// <returns>An administration context instance for the created profile.</returns>
        public static ContextUser CreateMesh(
            MeshHost meshHost,
            ProfileUser profileMaster,
            ProfileDevice profileDevice,
            CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default) {

            //Console.WriteLine($"Created new mesh  {profileMaster.UDF} device {profileDevice.UDF}");

            // Add this device to the profile as an administrator device by adding the necessary activation.
            var activationDevice = new ActivationDevice(profileDevice);
            throw new NYI();


            //var catalogedAdmin = AddAdministrator(meshHost, profileMaster, profileDevice, activationDevice, algorithmSign);

            //// Create an administration context
            //var contextMeshAdmin = new ContextMeshAdmin(meshHost, catalogedAdmin);


            //// Use the administration context to create a connection for this device and add to the record
            //var catalogedDevice = contextMeshAdmin.CreateCataloguedDevice(profileMaster, profileDevice, activationDevice);
            //catalogedAdmin.CatalogedDevice = catalogedDevice;


            //// Now save the results to host.dcat (the only catalog we have at this point) and return the admin context.
            //meshHost.Register(catalogedAdmin, contextMeshAdmin);
            //return contextMeshAdmin;
            }



        #endregion
        #region // Operations requiring the Mesh Secret - Escrow, Erase.

        /// <summary>
        /// Get the MeshSecret.
        /// </summary>
        /// <returns>The Mesh secret bytes.</returns>
        byte[] GetMeshSecret() {
            // pull the master key
            var mastersecret = KeyCollection.LocatePrivateKey(ProfileAccount.KeyOfflineSignature.UDF);
            mastersecret.AssertNotNull(NoMeshSecret.Throw);
            // convert to byte array;
            return (mastersecret as PrivateKeyUDF).PrivateValue.FromBase32();
            }

        /// <summary>
        /// Erase the Mesh Secret from the persistence store of this machine.
        /// </summary>
        /// <returns>True if the key was found, otherwise false.</returns>
        public void EraseMeshSecret() => KeyCollection.ErasePrivateKey(ProfileAccount.KeyOfflineSignature.UDF);

        /// <summary>
        /// Create an escrow set for the master key.
        /// </summary>
        /// <param name="shares">Number of shares to create</param>
        /// <param name="threshold">Number of shares required to recreate the quorum</param>
        /// <returns>The encrypted escrow entry and the key shares.</returns>
        public KeyShareSymmetric[] Escrow(int shares, int threshold) {
            var mastersecretBytes = GetMeshSecret();
            var secret = new SharedSecret(mastersecretBytes);
            return secret.Split(shares, threshold);
            }



        #endregion
        #region // Operations requiring OfflineSignatureKey - GrantAdmin, SetService

        KeyPair GetOfflineSignatureKey() {
            throw new NYI();
            }

        public void GrantAdministrator(
                CatalogedDevice targetDevice) {
            throw new NYI();
            }

        public void SetService(
                string accountAddress) {
            var keySign = GetOfflineSignatureKey();
            keySign.AssertNotNull(NotAdministrator.Throw);

            AccountAddress = accountAddress;

            var helloRequest = new HelloRequest();
            var helloResponse = MeshClient.Hello(helloRequest);

            // Add to assertion
            ProfileAccount.AccountAddresses = ProfileAccount.AccountAddresses ?? new List<string>();
            ProfileAccount.AccountAddresses.Add(accountAddress);
            ProfileAccount.EnvelopedProfileService = helloResponse.EnvelopedProfileService;

            ProfileAccount.Sign(keySign);



            var createRequest = new CreateRequest() {
                AccountAddress = accountAddress,
                SignedProfileAccount = ProfileAccount.DareEnvelope,
                };

            // Attempt to register with service in question
            MeshClient.CreateAccount(createRequest, MeshClient.JpcSession);

            // Generate a contact and self-sign
            var contact = CreateContact();
            SetContactSelf(contact);


            // Update all the devices connected to this profile.
            UpdateDevices(ProfileAccount);

            GetCatalogCapability();
            GetCatalogApplication();
            GetCatalogContact();
            GetCatalogDevice();
            GetCatalogCredential();
            GetCatalogBookmark();
            GetCatalogCalendar();
            GetCatalogNetwork();
            SyncProgressUpload();

            }

        /// <summary>
        /// Update all the devices connected to the account to incorporate values from
        /// <paramref name="account"/>.
        /// </summary>
        /// <param name="account">The modified account profile.</param>
        void UpdateDevices(ProfileUser account) {
            var catalog = GetCatalogDevice();

            var updates = new List<CatalogedDevice>();
            foreach (var device in catalog.AsCatalogedType) {
                bool updated = false;
                device.Accounts ??= new List<AccountEntry>();

                foreach (var accountEntry in device.Accounts) {
                    if (accountEntry.AccountUDF == account.UDF) {
                        accountEntry.EnvelopedProfileAccount = account.DareEnvelope;
                        updated = true;
                        }
                    }
                if (!updated) {
                    }
                updates.Add(device);

                }
            foreach (var device in updates) {
                catalog.Update(device);
                }
            //ContextMesh.UpdateDevice();
            throw new NYI();

            }


        #endregion
        #region // Operations requiring AdminSignatureKey - AddDevice, GrantPermission, GrantCapability

        KeyPair GetAdminSignatureKey() {
            throw new NYI();
            }

        /// <summary>
        /// Create a CatalogedDevice entry for the device with profile <paramref name="profileDevice"/>.
        /// </summary>
        /// <param name="profileDevice">Profile of the device to be added.</param>
        /// <returns>The CatalogedDevice entry.</returns>
        public CatalogedDevice CreateCataloguedDevice(ProfileDevice profileDevice) {
            var activationDevice = new ActivationDevice(profileDevice);
            var result = CreateCataloguedDevice(ProfileAccount, profileDevice, activationDevice);

            return result;
            }

        /// <summary>
        /// Create a CatalogedDevice entry for the device with profile <paramref name="profileDevice"/>
        /// and activation <paramref name="activationDevice"/>.
        /// </summary>
        /// <param name="profileAccount">The mesh profile.</param>
        /// <param name="profileDevice">Profile of the device to be added.</param>
        /// <param name="activationDevice">The device key overlay.</param>
        /// <returns>The CatalogedDevice entry.</returns>
        CatalogedDevice CreateCataloguedDevice(
                    ProfileUser profileAccount,
                    ProfileDevice profileDevice,
                    ActivationDevice activationDevice) {

            var keyAdministratorSignature = GetAdminSignatureKey();

            profileAccount.AssertNotNull(Internal.Throw);
            profileAccount.DareEnvelope.AssertNotNull(Internal.Throw);
            profileDevice.AssertNotNull(Internal.Throw);
            profileDevice.DareEnvelope.AssertNotNull(Internal.Throw);

            activationDevice.AssertNotNull(Internal.Throw);
            activationDevice.Package(keyAdministratorSignature);
            activationDevice.DareEnvelope.AssertNotNull(Internal.Throw);

            var connectionDevice = activationDevice.ConnectionDevice;
            connectionDevice.AssertNotNull(Internal.Throw);
            connectionDevice.DareEnvelope.AssertNotNull(Internal.Throw);

            // Wrap the connectionDevice and activationDevice in envelopes


            var catalogEntryDevice = new Mesh.CatalogedDevice() {
                UDF = activationDevice.UDF,
                EnvelopedProfileMesh = profileAccount.DareEnvelope,
                EnvelopedProfileDevice = profileDevice.DareEnvelope,
                EnvelopedConnectionDevice = connectionDevice.DareEnvelope,
                EnvelopedActivationDevice = activationDevice.DareEnvelope,
                DeviceUDF = profileDevice.UDF
                };

            return catalogEntryDevice;
            }

        /// <summary>
        /// Add a device to the account and the underlying Mesh.
        /// </summary>
        /// <param name="profileDevice">Profile of the device to add.</param>
        /// <returns>The catalog entry.</returns>
        public CatalogedDevice AddDevice(ProfileDevice profileDevice) {
            //var device = ContextMeshAdmin.CreateCataloguedDevice(profileDevice);

            //var accountEncryptionKey = GetAccountEncryptionKey();
            //// Connect the device to the Account
            //ProfileAccount.ConnectDevice(KeyCollection, device, accountEncryptionKey, null);


            ////Console.WriteLine(device.ToString());


            //// Update the local and remote catalog.
            //AddDevice(device);

            //return device;

            throw new NYI();
            }





        /// <summary>
        /// Create a contact entry for self using the parameters specified in <paramref name="contact"/>.
        /// </summary>
        /// <param name="contact">The contact parameters.</param>
        /// <param name="localname">Short name to apply to the signed contact info</param>
        public CatalogedContact SetContactSelf(Contact contact, string localname = null) {
            var keyAdministratorSignature = GetAdminSignatureKey();
            contact.Sign(keyAdministratorSignature);

            contact.Sources ??= new List<TaggedSource>() { };
            var tagged = new TaggedSource() {
                LocalName = localname,
                Validation = "Self",
                EnvelopedSource = contact.DareEnvelope
                };
            contact.Sources.Add(tagged);

            contact.Id = ProfileAccount.UDF;


            var catalog = GetCatalogContact();

            var (cataloged, success) = catalog.TryAdd(contact, true);

            if (!success) {
                cataloged.Contact = contact;
                catalog.Update(cataloged);
                }
            return cataloged;
            }

        /// <summary>
        /// Get the default (i.e. minimum contact info). This has a single network 
        /// address entry for this mesh and mesh account. 
        /// </summary>
        /// <returns>The default contact.</returns>
        public override Contact CreateContact(
                    List<CryptographicCapability> capabilities = null) {

            var address = new NetworkAddress(AccountAddress, ProfileAccount) {
                Capabilities = capabilities
                };

            var anchorAccount = new Anchor() {
                UDF = ProfileAccount.UDF,
                Validation = "Self"
                };
            // ContextMesh.ProfileMesh.UDF 

            var contact = new ContactPerson() {
                Anchors = new List<Anchor>() { anchorAccount },
                NetworkAddresses = new List<NetworkAddress>() { address }
                };

            return contact;
            }

        #endregion

        #region // General Operations 

        /// <summary>
        /// Get the primary account address bound to this profile. This is a bit of a hack right
        /// now as the code doesn't really support the 'multiple services per account' model yet.
        /// </summary>
        /// <returns>The account service address.</returns>
        public override string GetAccountAddress() {
            ProfileAccount.AccountAddresses.AssertNotNull(AccountNotBound.Throw);
            (ProfileAccount.AccountAddresses.Count > 0).AssertTrue(AccountNotBound.Throw);

            return ProfileAccount.AccountAddresses[0];
            }

        /// <summary>
        /// Return the first cryptographic capability granted to this particular device
        /// for the application <paramref name="catalogedApplication"/>.
        /// </summary>
        /// <param name="catalogedApplication">The application to return the capability from.</param>
        /// <returns>The first cryptographic capability this device has been granted if found,
        /// otherwise null.</returns>
        public CryptographicCapability GetCapability(CatalogedApplication catalogedApplication) {

            foreach (var envelope in catalogedApplication.EnvelopedCapabilities) {
                var capability = GetCapability(envelope);
                if (capability != null) {
                    return capability;
                    }
                }
            return null;
            }

        /// <summary>
        /// Attempt to decrypt <paramref name="envelopedCapability"/>. If successful, the content 
        /// data is decoded and the enclosed capability returned. Otherwise, null is returned.
        /// </summary>
        /// <param name="envelopedCapability">The envelope to attempt to decrypt.</param>
        /// <returns>The first cryptographic capability this device has been granted if found,
        /// otherwise null.</returns>
        public CryptographicCapability GetCapability(DareEnvelope envelopedCapability) {
            envelopedCapability.Future();

            throw new NYI();

            }
        #endregion

        #region // Store management and convenience accessors

        /// <summary>
        /// Create a new instance bound to the specified core within this account context.
        /// </summary>
        /// <param name="name">The name of the store to bind.</param>
        /// <returns>The store instance.</returns>
        protected override Store MakeStore(string name) => name switch
            {
                SpoolInbound.Label => new SpoolInbound(StoresDirectory, name, ContainerCryptoParameters, KeyCollection),
                SpoolOutbound.Label => new SpoolOutbound(StoresDirectory, name, ContainerCryptoParameters, KeyCollection),
                SpoolLocal.Label => new SpoolLocal(StoresDirectory, name, ContainerCryptoParameters, KeyCollection),
                SpoolArchive.Label => new SpoolArchive(StoresDirectory, name, ContainerCryptoParameters, KeyCollection),
                CatalogCredential.Label => new CatalogCredential(StoresDirectory, name, ContainerCryptoParameters, KeyCollection),
                CatalogContact.Label => new CatalogContact(StoresDirectory, name, ContainerCryptoParameters, KeyCollection),
                CatalogCalendar.Label => new CatalogCalendar(StoresDirectory, name, ContainerCryptoParameters, KeyCollection),
                CatalogBookmark.Label => new CatalogBookmark(StoresDirectory, name, ContainerCryptoParameters, KeyCollection),
                CatalogNetwork.Label => new CatalogNetwork(StoresDirectory, name, ContainerCryptoParameters, KeyCollection),
                CatalogApplication.Label => new CatalogApplication(StoresDirectory, name, ContainerCryptoParameters, KeyCollection),
                CatalogDevice.Label => new CatalogDevice(StoresDirectory, name, ContainerCryptoParameters, KeyCollection),
                _ => base.MakeStore(name),
                };


        ///<summary>Returns the application catalog for the account</summary>
        public CatalogApplication GetCatalogApplication() => GetStore(CatalogApplication.Label) as CatalogApplication;

        ///<summary>Returns the contacts catalog for the account</summary>
        public CatalogDevice GetCatalogDevice() => GetStore(CatalogDevice.Label) as CatalogDevice;

        ///<summary>Returns the contacts catalog for the account</summary>
        public CatalogContact GetCatalogContact() => GetStore(CatalogContact.Label) as CatalogContact;

        ///<summary>Returns the credential catalog for the account</summary>
        public CatalogCredential GetCatalogCredential() => GetStore(CatalogCredential.Label) as CatalogCredential;

        ///<summary>Returns the bookmark catalog for the account</summary>
        public CatalogBookmark GetCatalogBookmark() => GetStore(CatalogBookmark.Label) as CatalogBookmark;

        ///<summary>Returns the calendar catalog for the account</summary>
        public CatalogCalendar GetCatalogCalendar() => GetStore(CatalogCalendar.Label) as CatalogCalendar;

        ///<summary>Returns the network catalog for the account</summary>
        public CatalogNetwork GetCatalogNetwork() => GetStore(CatalogNetwork.Label) as CatalogNetwork;

        ///<summary>Returns the inbound spool for the account</summary>
        public SpoolInbound GetSpoolInbound() => GetStore(SpoolInbound.Label) as SpoolInbound;

        ///<summary>Returns the outbound spool for the account</summary>
        public SpoolOutbound GetSpoolOutbound() => GetStore(SpoolOutbound.Label) as SpoolOutbound;


        /// <summary>
        /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyId">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public override CryptoKey TryFindKeyEncryption(string keyId) {

            var key = base.TryFindKeyEncryption(keyId);
            if (key != null) {
                return key;
                }
            return GetCatalogContact().GetByAccountEncrypt(keyId);
            }


        /// <summary>
        /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyId">The identifier to resolve.</param>
        /// <returns>The identifier.</returns>
        public override CryptoKey TryFindKeySignature(string keyId) {
            if (keyId == AccountAddress) {
                return KeySignature;
                }
            if (base.TryFindKeySignature(keyId).NotNull(out var key)) {
                return key;
                }
            return null;
            }


        /// <summary>
        /// Attempt to obtain a recipient with identifier <paramref name="keyId"/>.
        /// </summary>
        /// <param name="keyId">The key identifier to match.</param>
        /// <returns>The key pair if found.</returns>
        public override IKeyDecrypt TryFindKeyDecryption(string keyId) {
            var key = base.TryFindKeyDecryption(keyId);
            if (key != null) {
                return key;
                }

            var catalogCapability = GetCatalogCapability();
            return catalogCapability.TryFindKeyDecryption(keyId);
            }
        #endregion
        #region // Message Handling - Get/Process pending.
        /// <summary>
        /// Search the inbound spool and return the last message of type <paramref name="tag"/>.
        /// This is obviously a placeholder for something more comprehensive.
        /// </summary>
        /// <param name="tag">Message selector.</param>
        /// <returns>The message found.</returns>
        public Message GetPendingMessage(string tag) {
            var completed = new Dictionary<string, Message>();

            foreach (var message in GetSpoolInbound().Select(1, true)) {
                var contentMeta = message.Header.ContentMeta;

                if (!completed.ContainsKey(contentMeta.UniqueID)) {
                    var meshMessage = Message.FromJson(message.GetBodyReader());
                    //Console.WriteLine($"Message {contentMeta?.MessageType} ID {meshMessage.MessageID}");
                    if (contentMeta.MessageType == tag) {
                        return meshMessage;
                        }
                    switch (meshMessage) {
                        case MessageComplete meshMessageComplete: {
                            foreach (var reference in meshMessageComplete.References) {
                                completed.Add(reference.MessageID, meshMessageComplete);
                                // Hack: This should make actual use of the relationship
                                //   (Accept, Reject, Read)
                                }
                            break;
                            }

                        default:
                        break;
                        }
                    }
                }
            return null;
            }

        /// <summary>
        /// Return the last message with messageID <paramref name="messageID"/>. If the message
        /// has been read, the value <paramref name="read"/> is true.
        /// </summary>
        /// <param name="messageID">The message to locate.</param>
        /// <param name="read">If true, the message has already been read.</param>
        /// <returns>The message value (if unread).</returns>
        public Message GetPendingMessageByID(string messageID, out bool read) {
            foreach (var envelope in GetSpoolInbound().Select(1, true)) {
                var contentMeta = envelope.Header.ContentMeta;
                var meshMessage = Message.Decode(envelope);

                // Message.FromJson(envelope.GetBodyReader());
                //meshMessage.DareEnvelope = envelope;
                //Console.WriteLine($"Message {contentMeta?.MessageType} ID {meshMessage.MessageID}");

                if (meshMessage.MessageID == messageID) {
                    read = true;
                    return meshMessage;
                    }
                switch (meshMessage) {
                    case MessageComplete meshMessageComplete: {
                        foreach (var reference in meshMessageComplete.References) {
                            if (reference.MessageID == messageID) {
                                read = true;
                                return null;
                                }
                            }
                        break;
                        }

                    default:
                    break;
                    }

                }

            read = false;
            return null;
            }

        #endregion
        #region // Group operations

        /// <summary>
        /// Create a threshold encryption group.
        /// </summary>
        /// <param name="groupName">Name of the group to create.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm</param>
        /// <param name="algorithmSign">The signature algorithm.</param>
        /// <returns></returns>

        public ContextGroup CreateGroup(string groupName,
                    CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                    CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default) {

            var meshKeyType = MeshKeyType.GroupProfile;
            (var profileGroup, var secretSeed) = ProfileGroup.Generate(
                        MeshMachine, algorithmSign, algorithmEncrypt);
            var keySign = secretSeed.BasePrivate(meshKeyType | MeshKeyType.Sign,
                        keySecurity: KeySecurity.Exportable);
            var keyEncrypt = secretSeed.BasePrivate(meshKeyType | MeshKeyType.Encrypt,
                        keySecurity: KeySecurity.Exportable);

            // here we request creation of the group at the service.

            var createRequest = new CreateGroupRequest() {
                AccountAddress = groupName,
                SignedProfileGroup = profileGroup.DareEnvelope
                };

            var createResponse = MeshClient.CreateGroup(createRequest, MeshClient.JpcSession);
            createResponse.AssertSuccess();

            var capabilityAdmin = new CapabilitySign() {
                Id = UDF.Nonce(),
                SubjectAddress = groupName,
                SubjectId = keySign.KeyIdentifier,
                KeyData = new KeyData(keySign, true),
                };

            var capabilityDecrypt = new CapabilityKeyGenerate() {
                Id = UDF.Nonce(),
                SubjectAddress = groupName,
                SubjectId = keyEncrypt.KeyIdentifier,
                KeyData = new KeyData(keyEncrypt, true)
                };

            GetCatalogCapability().Add(capabilityAdmin);
            GetCatalogCapability().Add(capabilityDecrypt);



            //var envelopedCapabilityAdmin = DareEnvelope.Encode(capabilityAdmin.GetBytes(), encryptionKey: KeyDeviceEncryption);
            //var envelopedCapabilityDecrypt = DareEnvelope.Encode(capabilityDecrypt.GetBytes(), encryptionKey: KeyDeviceEncryption);



            var catalogedGroup = new CatalogedGroup(profileGroup) {
                Key = groupName
                };
            GetCatalogApplication().New(catalogedGroup);


            //var contextGroup = ContextGroup.CreateGroup(this, catalogedGroup);

            //var contact = contextGroup.CreateContact();
            //// Bug: Should also encrypt the relevant admin key to the admin encryption key.


            //var contactCatalog = GetCatalogContact();
            //contactCatalog.Add(contact);


            //return contextGroup;

            throw new NYI();
            }

        /// <summary>
        /// Get a managment context for the group <paramref name="groupAddress"/>.
        /// </summary>
        /// <param name="groupAddress">The group to return the management context for.</param>
        /// <returns>The created management context.</returns>
        public ContextGroup GetContextGroup(string groupAddress) {

            // read through the entries in CatalogApplication
            var catalog = GetCatalogApplication();
            var entry = catalog.LocateGroup(groupAddress);

            //// construct the group context
            //// We do not attempt to get admin privs here, we will do that if necessary.
            //return new ContextGroup(this, entry);

            throw new NYI();
            }



        #endregion
        #region // Device connection

        /// <summary>
        /// Create an EARL for a device, publish the result to the Mesh service and return 
        /// the device profile <paramref name="profileDevice"/>, secret seed value 
        /// <paramref name="secretSeed"/>, connection URI 
        /// <paramref name="connectURI"/> and PIN <paramref name="pin"/>.
        /// </summary>
        /// <param name="secretSeed">The computed secret seed value.</param>
        /// <param name="profileDevice">The computed device profile</param>
        /// <param name="pin">The computed PIN code.</param>
        /// <param name="connectURI">The connection URI to be used for pickup.</param>
        /// <param name="algorithmEncrypt">The encryption algorithm.</param>
        /// <param name="algorithmSign">The signature algorithm</param>
        /// <param name="algorithmAuthenticate">The signature algorithm</param>
        /// <param name="secret">The master secret.</param>
        /// <param name="bits">The size of key to generate in bits/</param>
        /// <returns>Response from the server.</returns>
        public PublishResponse CreateDeviceEarl(
                    out PrivateKeyUDF secretSeed,
                    out ProfileDevice profileDevice,
                    out string pin,
                    out string connectURI,

                    CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                    CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                    CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default,
                    byte[] secret = null,
                    int bits = 256
                    ) {

            // an invitation consists of a uri of the form:
            // mmm://q@example.org/NQED-5C35-WSBQ-OBHW-ENBI-XOZF


            secretSeed = new PrivateKeyUDF(
                UdfAlgorithmIdentifier.MeshProfileDevice,
                algorithmEncrypt,
                algorithmSign,
                algorithmAuthenticate,
                secret,
                bits);


            pin = MeshUri.GetConnectPin(secretSeed, AccountAddress);

            var key = new CryptoKeySymmetric(pin);

            connectURI = MeshUri.ConnectUri(AccountAddress, pin);

            // Create a device profile and encrypt under pin
            profileDevice = new ProfileDevice(secretSeed);
            var plaintext = profileDevice.DareEnvelope.GetBytes();

            var encryptedProfileDevice = DareEnvelope.Encode(plaintext, encryptionKey: key);

            var catalogedPublication = new CatalogedPublication(pin) {
                EnvelopedData = encryptedProfileDevice,
                };

            var publishRequest = new PublishRequest() {
                Publications = new List<CatalogedPublication>() { catalogedPublication }
                };

            var publishResponse = MeshClient.Publish(publishRequest);


            return publishResponse;
            }


        /// <summary>
        /// Attempt device connection by means of the static URI <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The connection URI</param>
        /// <returns>The </returns>
        public CatalogedDevice Connect(string uri) {

            var envelopedProfileDevice = ClaimPublication(uri, out var responseId);

            // Decode the Profile Device
            var profileDevice = ProfileDevice.Decode(envelopedProfileDevice) as ProfileDevice;

            // Approve the request
            // Have to add in the Mesh profile here and Account Assertion

            var cataloguedDevice = AddDevice(profileDevice);

            //Console.WriteLine($"Accept connection ID is {responseId}");
            var respondConnection = new RespondConnection() {
                MessageID = responseId,
                CatalogedDevice = cataloguedDevice,
                Result = Constants.TransactionResultAccept
                };

            SendMessage(respondConnection);


            // ContextMeshPending
            return cataloguedDevice;
            }
        #endregion
        #region // Claim publication
        /// <summary>
        /// Claim the document published at the EARL <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The EARL to resolve</param>
        /// <param name="responseId">The response from the service.</param>
        /// <returns>The recovered envelope.</returns>
        public DareEnvelope ClaimPublication(string uri, out string responseId) {
            (var targetAccountAddress, var pin) = MeshUri.ParseConnectUri(uri);

            var key = new CryptoKeySymmetricSigner(pin);
            var messageClaim = new MessageClaim(targetAccountAddress, AccountAddress, pin);

            var envelopedMessageClaim = messageClaim.Encode(KeySignature);

            // make claim request to service managing the device
            var claimRequest = new ClaimRequest {
                EnvelopedMessageClaim = envelopedMessageClaim
                };

            var claimResponse = MeshClient.Claim(claimRequest);

            // The Dare envelope contains a DareEnvelope<ProfileDevice>
            var encryptedEnvelope = claimResponse.CatalogedPublication.EnvelopedData;

            // Verify: if the key is a encrypt/sign, need to verify here.
            "If the key is a encrypt/sign, need to verify here.".TaskValidate();

            var result = encryptedEnvelope.DecodeJsonObject(key) as DareEnvelope;

            responseId = messageClaim.GetResponseID();

            return result;
            }
        #endregion
        #region // Processing

        /// <summary>
        /// Process automatic actions.
        /// </summary>
        /// <returns>The results of the automatic processing attempted.</returns>
        public List<IProcessResult> ProcessAutomatics() {

            var results = new List<IProcessResult>();

            var spoolInbound = GetSpoolInbound();
            foreach (var envelope in spoolInbound.GetMessages(MessageStatus.Open)) {
                var meshMessage = envelope.Message;
                switch (meshMessage) {
                    case AcknowledgeConnection acknowledgeConnection: {
                        if (acknowledgeConnection.MessageConnectionRequest.PinUDF != null) {
                            results.Add(ProcessAutomatic(acknowledgeConnection));
                            }

                        break;
                        }
                    case ReplyContact replyContact: {
                        results.Add(ProcessAutomatic(replyContact, false));
                        break;
                        }
                    case GroupInvitation groupInvitation: {
                        results.Add(ProcessAutomatic(groupInvitation));
                        break;
                        }
                    }
                }

            return results;
            }



        /// <summary>
        /// Perform automatic processing of the message <paramref name="groupInvitation"/>.
        /// </summary>
        /// <param name="groupInvitation">Reply to contact request to be processed.</param>
        /// <param name="accept">Accept the requested action.</param>
        /// <param name="authorize">If true, the action is explicitly authorized.</param>
        /// <returns>The result of requesting the connection.</returns>
        public IProcessResult ProcessAutomatic(GroupInvitation groupInvitation, bool accept = true,
                        bool authorize = false) {
            accept.Future();
            authorize.Future();

            if (groupInvitation.Contact == null) {
                return null; // invitation did not contain a credential
                }

            GetCatalogContact().Add(groupInvitation.Contact);
            if (groupInvitation.Contact?.NetworkAddresses == null) {
                return null; // invitation did not contain a credential
                }

            var catalogCapability = GetCatalogCapability();
            foreach (var address in groupInvitation.Contact.NetworkAddresses) {
                if (address.Capabilities != null) {
                    foreach (var capability in address.Capabilities) {
                        catalogCapability.Add(capability);
                        }
                    }
                }



            return null;
            }

        /// <summary>
        /// Perform automatic processing of the message <paramref name="replyContact"/>.
        /// </summary>
        /// <param name="replyContact">Reply to contact request to be processed.</param>
        /// <param name="accept">Accept the requested action.</param>
        /// <param name="authorize">If true, the action is explicitly authorized.</param>
        /// <returns>The result of requesting the connection.</returns>
        public IProcessResult ProcessAutomatic(ReplyContact replyContact, bool accept = true,
                        bool authorize = false) {
            authorize.Future();

            // check response pin here 
            var messagePin = GetMessagePIN(replyContact.PinUDF);

            var result = MessagePIN.ValidatePin(messagePin,
                    AccountAddress,
                    replyContact.AuthenticatedData,
                    replyContact.ClientNonce,
                    replyContact.PinWitness);

            if (!(messagePin.Automatic | accept)) {
                return new PINNotAutomatic();
                }

            if (!(result is MessagePIN)) {
                return result;
                }

            GetCatalogContact().Add(replyContact.AuthenticatedData);

            return null;
            }
        /// <summary>
        /// Perform automatic processing of the message <paramref name="acknowledgeConnection"/>.
        /// </summary>
        /// <param name="acknowledgeConnection">Connection request to be processed.</param>
        /// <returns>The result of requesting the connection.</returns>
        public IProcessResult ProcessAutomatic(AcknowledgeConnection acknowledgeConnection) {
            var messageConnectionRequest = acknowledgeConnection.MessageConnectionRequest;

            // get the pin value here
            var messagePin = GetMessagePIN(messageConnectionRequest.PinUDF);

            var result = MessagePIN.ValidatePin(messagePin,
                    AccountAddress,
                    messageConnectionRequest.AuthenticatedData,
                    messageConnectionRequest.ClientNonce,
                    messageConnectionRequest.PinWitness);

            if (!(result is MessagePIN)) {
                return result;
                }

            return Process(acknowledgeConnection, true);
            }





        /// <summary>
        /// Accept or reject a connection request.
        /// </summary>
        /// <param name="request">The request to accept or reject.</param>
        /// <param name="accept">If true, accept the request. Otherwise, it is rejected.</param>
        IProcessResult Process(AcknowledgeConnection request, bool accept = true) {
            var messageID = request.GetResponseID();
            var respondConnection = new RespondConnection() {
                MessageID = messageID
                };

            if (accept) {
                // Connect the device to the Mesh
                var device = AddDevice(request.MessageConnectionRequest.ProfileDevice);
                respondConnection.CatalogedDevice = device;
                respondConnection.Result = Constants.TransactionResultAccept;
                }
            else {
                respondConnection.Result = Constants.TransactionResultReject;
                }

            //Console.WriteLine($"Accept connection ID is {messageID}");

            SendMessage(respondConnection);

            return respondConnection;
            }





        /// <summary>
        /// Generalized processing loop for messages
        /// </summary>
        /// <param name="messageId">Identifier of the message to process.</param>
        /// <param name="accept">If true, accept the request, otherwise reject it.</param>
        /// <param name="reciprocate">If true, reciprocate the response: e.g. return user's own
        /// contact information in response to an initial contact request.</param>
        /// <returns></returns>
        public IProcessResult Process(string messageId, bool accept = true, bool reciprocate = true) {


            // Hack: should be able to accept, reject specific requests, not just
            // the last one.
            var message = GetPendingMessageByID(messageId, out var found);
            found.AssertTrue(MessageIdNotFound.Throw);

            return Process(message, accept, reciprocate);

            }

        /// <summary>
        /// Generalized processing loop for messages
        /// </summary>
        /// <param name="meshMessage">The message to process.</param>
        /// <param name="accept">If true, accept the request, otherwise reject it.</param>
        /// <param name="reciprocate">If true, reciprocate the response: e.g. return user's own
        /// contact information in response to an initial contact request.</param>
        /// <returns></returns>
        public IProcessResult Process(Message meshMessage, bool accept = true, bool reciprocate = true) {

            reciprocate.Future();

            switch (meshMessage) {
                case AcknowledgeConnection connection: {
                    return Process(connection, accept);
                    }
                case ReplyContact replyContact: {
                    return ProcessAutomatic(replyContact, accept, true);
                    }
                case RequestContact requestContact: {
                    return ContactReply(requestContact);

                    }

                case RequestConfirmation requestConfirmation: {
                    return ConfirmationResponse(requestConfirmation, accept);

                    }
                case ResponseConfirmation responseConfirmation: {
                    responseConfirmation.Future();
                    break;
                    }
                case RequestTask requestTask: {
                    requestTask.Future();
                    break;
                    }
                case GroupInvitation groupInvitation: {
                    groupInvitation.Future();
                    break;
                    }

                default: throw new NYI();
                }


            return null;
            }

        /// <summary>
        /// Make a contact reply.
        /// </summary>
        /// <param name="requestContact">The contact request.</param>
        /// <param name="localname">Local name to be used to identify the contact recorded in
        /// the catalog.</param>
        public IProcessResult ContactReply(RequestContact requestContact, string localname = null) {

            // Add the requestContact.Self contact to the catalog

            if (requestContact.Self != null) {
                var catalog = GetCatalogContact();
                catalog.Add(requestContact.Self);
                }

            return SendReplyContact(requestContact.Sender, requestContact.PIN, localname);

            }

        Message SendReplyContact(string recipient, string pin, string localname) {
            // prepare the reply
            var contactSelf = GetSelf(localname);

            // calculate the witness value over contactSelf and PIN

            var saltedPin = MessagePIN.SaltPIN(pin, Constants.MessagePINActionContact);

            var nonce = CryptoCatalog.GetBits(128);

            var witness = MessagePIN.GetPinWitness(saltedPin, recipient, contactSelf, nonce);
            var pinUdf = MessagePIN.GetPinUDF(saltedPin, recipient);


            var message = new ReplyContact() {
                Recipient = recipient,
                Subject = recipient,
                AuthenticatedData = contactSelf,
                ClientNonce = nonce,
                PinWitness = witness,
                PinUDF = pinUdf
                };

            // send it to the service
            SendMessage(message, recipient);

            return message;
            }

        #endregion
        #region // ContactManagement

        /// <summary>
        /// Get the user's own contact. There is only ever one contact entry but there MAY
        /// be multiple envelopes 
        /// </summary>
        /// <param name="localName">Local name for the contact</param>
        /// <returns></returns>
        public DareEnvelope GetSelf(string localName) {
            var catalog = GetCatalogContact();
            var entry = catalog.PersistenceStore.Get(ProfileAccount.UDF);

            var self = entry.JsonObject as CatalogedContact;

            foreach (var tagged in self.Contact.Sources) {
                if (tagged.EnvelopedSource == null) {
                    // skip entries that don't have an enveloped source.
                    }
                else if (localName == null || tagged.LocalName == localName) {
                    return tagged.EnvelopedSource;
                    }
                }

            throw new NYI();
            }



        /// <summary>
        /// Construct a contact fetch URI.
        /// </summary>
        /// <param name="localName">Local name for the contact</param>
        /// <param name="expire">Expiry time for the corresponding PIN</param>
        /// <param name="automatic">If true, presentation of the pin code is sufficient
        /// to authenticate and authorize the action.</param>
        public string ContactUri(bool automatic, DateTime? expire, string localName = null) {
            var envelope = GetSelf(localName);

            var combinedKey = new CryptoKeySymmetricSigner();

            var pin = combinedKey.SecretKey;

            // Add a signature under the signature key.
            var encryptedContact = DareEnvelope.Encode(envelope.GetBytes(),
                    signingKey: combinedKey, encryptionKey: combinedKey);

            // publish the enveloped contact to the service.
            var catalogedPublication = new CatalogedPublication(pin) {
                EnvelopedData = encryptedContact,
                NotOnOrAfter = expire
                };

            var publishRequest = new PublishRequest() {
                Publications = new List<CatalogedPublication>() { catalogedPublication },
                };

            var publishResponse = MeshClient.Publish(publishRequest);
            publishResponse.AssertSuccess();

            // Register the pin
            var messageConnectionPIN = new MessagePIN(pin, automatic, expire, AccountAddress, "Contact");
            SendMessageAdmin(messageConnectionPIN);
            // Spec - maybe should enforce type check here.


            // return the contact address
            return MeshUri.ConnectUri(AccountAddress, pin);
            }



        /// <summary>
        /// Construct a contact request.
        /// </summary>
        /// <param name="recipientAddress">The contact to request.</param>
        /// <param name="localName">Local name for the contact</param>
        public RequestContact ContactRequest(string recipientAddress, string localName = null) {
            // prepare the contact request

            var contactSelf = GetSelf(localName);
            var pin = UDF.SymmetricKey();

            var message = new RequestContact() {
                Recipient = recipientAddress,
                Subject = recipientAddress,
                Self = contactSelf,
                PIN = pin
                };

            RegisterPIN(pin, true, null, AccountAddress, "Contact");

            SendMessage(message, recipientAddress);

            // send it to the service

            return message;
            }


        /// <summary>
        /// Fetch contact data referenced by the URI <paramref name="uri"/>. If <paramref name="reciprocate"/>
        /// is true, send own contact data.
        /// </summary>
        /// <param name="uri">The URI to resolve.</param>
        /// <param name="reciprocate">If true send own contact data.</param>
        /// <param name="localname">Local name for the contact to send in exchange</param>
        /// <param name="message">The reciprocation message (if sent), otherwise null.</param>
        /// <returns>The cataloged contact information.</returns>
        public CatalogedContact ContactExchange(string uri, bool reciprocate, out Message message, string localname = null) {
            // Fetch, verify and decrypt the corresponding data.

            var envelope = ClaimPublication(uri, out var _);

            // Add to the catalog
            var catalog = GetCatalogContact();
            var result = catalog.Add(envelope);

            if (reciprocate) {
                (var targetAccountAddress, var pin) = MeshUri.ParseConnectUri(uri);
                message = SendReplyContact(targetAccountAddress, pin, localname) as Message;
                }
            else {
                message = null;
                }

            return result;
            }
        #endregion
        #region // Confirmation Processing

        /// <summary>
        /// Construct a confirmation request.
        /// </summary>
        /// <param name="accountAddress">The contact to request.</param>
        /// <param name="messageText">The message text to send.</param>
        public RequestConfirmation ConfirmationRequest(string accountAddress, string messageText) {
            // prepare the contact request

            var message = new RequestConfirmation() {
                Recipient = accountAddress,
                Text = messageText
                };

            SendMessage(message, accountAddress);

            // send it to the service
            return message;
            }


        /// <summary>
        /// Make a contact reply.
        /// </summary>
        /// <param name="requestConfirmation">The request received.</param>
        /// <param name="response">If true, accept the confirmation request, otherwise reject.</param>
        public IProcessResult ConfirmationResponse(RequestConfirmation requestConfirmation, bool response) {
            // prepare the contact request

            var recipient = requestConfirmation.Sender;

            var message = new ResponseConfirmation() {
                MessageID = requestConfirmation.GetResponseID(),
                Recipient = recipient,
                Accept = response,
                Request = requestConfirmation.DareEnvelope
                };

            SendMessage(message, recipient);

            // send it to the service
            return null;
            }


        #endregion
        }


    }
