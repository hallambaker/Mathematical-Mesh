using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using System;
using System.Collections.Generic;
using System.IO;
using Goedel.Protocol;
using System.Diagnostics;
using System.Runtime.Serialization;
using Goedel.IO;

namespace Goedel.Mesh.Client {

    /// <summary>
    /// Context for interacting with a Mesh Account
    /// </summary>
    public partial class ContextUser : ContextAccount {


        #region // Public and private properties

        ///<summary>The directory containing the catalogs related to the account.</summary>
        public override string StoresDirectory => directoryAccount ??
            GetStoresDirectory(MeshHost, ProfileUser).CacheValue(out directoryAccount);
        string directoryAccount;





        ///<summary>The account profile</summary>
        public override Profile Profile => ProfileUser;

        ///<summary>Convenience accessor for the connection.</summary>
        public override Connection Connection => ConnectionUser;

        ///<summary>Cached accessor to the account address.</summary>
        public override string AccountAddress => accountAddress ?? GetAccountAddress().CacheValue(out accountAddress);

        string accountAddress;

        ///<summary>The cataloged device</summary>
        public virtual CatalogedDevice CatalogedDevice => CatalogedMachine?.CatalogedDevice;

        ///<summary>The profile</summary>
        public ProfileUser ProfileUser { get; private set; }

        ///<summary>The connection device</summary>
        public ConnectionUser ConnectionUser => CatalogedDevice?.ConnectionUser;

        ///<summary>The device activation</summary>
        public ActivationDevice ActivationUser { get; private set; }

        ///<summary>The device activation</summary>
        public ActivationAccount ActivationAccount { get; private set; }

        ///<summary>The device key generation seed</summary>
        protected PrivateKeyUDF MeshSecretSeed;


        ///<summary>The member's device signature key</summary>
        protected override KeyPair KeySignature => PrivateDeviceSignature;

        // device key accessors
        KeyPair PrivateDeviceDecrypt { get; }
        KeyPair PrivateDeviceSignature => ActivationUser.PrivateDeviceSignature;
        KeyPair PrivateDeviceEncryption => ActivationUser.PrivateDeviceEncryption;
        KeyPair PrivateDeviceAuthentication => ActivationUser.PrivateDeviceAuthentication;

        // account key accessors
        KeyPair PrivateAccountOfflineSignature => ActivationAccount.PrivateAccountOfflineSignature;
        KeyPair PrivateAccountOnlineSignature => ActivationAccount.PrivateAccountOnlineSignature;
        KeyPair PrivateAccountEncryption => ActivationAccount.PrivateAccountEncryption;
        KeyPair PrivateAccountAuthentication => ActivationAccount.PrivateAccountAuthentication;

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
                CatalogedMachine catalogedMachine) : base(meshHost, catalogedMachine) {

            if (CatalogedDevice == null) {
                return;
                }

            ProfileUser = CatalogedDevice.ProfileUser;

            // Get the device key so that we can decrypt the activation record.
            var deviceKeySeed = ProfileDevice?.GetPrivateKeyUDF(MeshHost.MeshMachine);
            PrivateDeviceDecrypt = deviceKeySeed?.BasePrivate(MeshKeyType.DeviceEncrypt);
            KeyCollection.Add(PrivateDeviceDecrypt);

            ActivationUser = CatalogedDevice?.GetActivationDevice(KeyCollection);
            ActivationUser.Activate(KeyCollection, deviceKeySeed);

            ActivationAccount = CatalogedDevice?.GetActivationAccount(KeyCollection);
            ActivationAccount.Activate();


            // Some validation checks
            (PrivateDeviceSignature.KeyIdentifier).AssertEqual(ConnectionUser.DeviceSignature.UDF,
                    KeyActivationFailed.Throw);
            (PrivateDeviceEncryption.KeyIdentifier).AssertEqual(ConnectionUser.DeviceEncryption.UDF,
                    KeyActivationFailed.Throw);
            (PrivateDeviceAuthentication.KeyIdentifier).AssertEqual(ConnectionUser.DeviceAuthentication.UDF,
                    KeyActivationFailed.Throw);
            }

        #endregion
        #region // Account creation 



        ///// <summary>
        ///// Create a new personal mesh and return an administration context for it.
        ///// </summary>
        ///// <param name="meshHost">The mesh host context that the mesh is going to be created on.</param>
        ///// <param name="localName">Optional local name to be associated with the account.</param>
        ///// <param name="onlineSignature">The key to be used for initial administration operations.</param>
        ///// <param name="algorithmSign">The signature algorithm.</param>
        ///// <param name="algorithmEncrypt">The encryption algorithm.</param>
        ///// <param name="algorithmAuthenticate">The authentication algorithm.</param>
        ///// <param name="secretSeed">A UDF secret seed</param>
        ///// <returns>An administration context instance for the created profile.</returns>
        //public static ContextUser CreateAccountUser(
        //        MeshHost meshHost,
        //        ActivationAccount activationAccount,
        //        string localName = null){
        //    //string secretSeed = null) {

        //    // Create the master profile.

        //    var profileUser = new ProfileUser(activationAccount);

        //    var catalogedMachine = new CatalogedStandard() {
        //        EnvelopedProfileUser = profileUser.DareEnvelope,
        //        Local = localName,
        //        Id = profileUser.UDF
        //        };

        //    var contextUser = new ContextUser(meshHost, catalogedMachine) {
        //        //MeshSecretSeed = privateKeyUDF, // temporary access
        //        ProfileUser = profileUser,
        //        ActivationAccount = activationAccount
        //        //PrivateAccountOnlineSignature = onlineSignature,
        //        //PrivateAccountOfflineSignature = profileUser.PrivateAccountOfflineSignature,
        //        //PrivateAccountEncryption = profileUser.PrivateAccountEncryption,
        //        //PrivateAccountAuthentication = profileUser.PrivateAccountAuthentication
        //        };

        //    Directory.CreateDirectory(contextUser.StoresDirectory);

        //    return contextUser;
        //    }


        #endregion
        #region // Operations requiring the Mesh Secret - Escrow, Erase.

        /// <summary>
        /// Get the MeshSecret.
        /// </summary>
        /// <exception cref="NoMeshSecret">Is thrown if the private key cannot be found.</exception>
        /// <returns>The Mesh secret bytes.</returns>
        byte[] GetMeshSecret() {
            try {
                // pull the master key
                MeshSecretSeed = KeyCollection.LocatePrivateKey(ProfileUser.OfflineSignature.UDF) as PrivateKeyUDF;
                MeshSecretSeed.AssertNotNull(NoMeshSecret.Throw);
                // convert to byte array;
                return MeshSecretSeed.PrivateValue.FromBase32();
                }
            catch {
                throw new NoMeshSecret();
                }
            }

        /// <summary>
        /// Erase the Mesh Secret from the persistence store of this machine.
        /// </summary>
        public void EraseMeshSecret() => KeyCollection.ErasePrivateKey(ProfileUser.OfflineSignature.UDF);

        /// <summary>
        /// Create an escrow set for the master key.
        /// </summary>
        /// <param name="shares">Number of shares to create</param>
        /// <param name="threshold">Number of shares required to recreate the quorum</param>
        /// <exception cref="NoMeshSecret">Is thrown if the private key cannot be found.</exception>
        /// <returns>The encrypted escrow entry and the key shares.</returns>
        public KeyShareSymmetric[] Escrow(int shares, int threshold) {
            var mastersecretBytes = GetMeshSecret();
            var secret = new SharedSecret(mastersecretBytes);
            return secret.Split(shares, threshold);
            }



        #endregion
        #region // Operations requiring OfflineSignatureKey - GrantAdmin, SetService



        /// <summary>
        /// Set the initial Mesh Service. This MUST be called before devices are added to the 
        /// personal mesh. This method does not support transfer of the Mesh Service.
        /// </summary>
        /// <param name="accountAddress">The account address</param>
        public void SetService(
                string accountAddress) {
            PrivateAccountOfflineSignature.AssertNotNull(NotSuperAdministrator.Throw);

            // cache the account address value
            this.accountAddress = accountAddress;

            var helloRequest = new HelloRequest();
            var helloResponse = MeshClient.Hello(helloRequest);

            // Add to assertion
            ProfileUser.AccountAddresses = ProfileUser.AccountAddresses ?? new List<string>();
            ProfileUser.AccountAddresses.Add(accountAddress);
            ProfileUser.EnvelopedProfileService = helloResponse.EnvelopedProfileService;

            ProfileUser.Sign(PrivateAccountOfflineSignature);

            var createRequest = new CreateRequest() {
                AccountAddress = accountAddress,
                EnvelopedProfileUser = ProfileUser.EnvelopedProfileUser,
                };

            // Attempt to register with service in question
            var response = MeshClient.CreateAccount(createRequest, MeshClient.JpcSession);
            response.AssertSuccess(ServerOperationFailed.Throw);

            // Generate a contact and self-sign
            var contact = CreateContact();
            SetContactSelf(contact);

            MakeStores();

            SyncProgressUpload();
            }

        public static string GetStoresDirectory(
        MeshHost MeshHost, ProfileUser profileUser) =>
            Path.Combine(MeshHost.MeshMachine.DirectoryMesh, profileUser.UDF);



        #endregion
        #region // Operations requiring AdminSignatureKey - AddDevice, GrantPermission, GrantCapability






        ///// <summary>
        ///// Create a CatalogedDevice entry for the device with profile <paramref name="profileDevice"/>
        ///// and activation <paramref name="activationDevice"/>.
        ///// </summary>
        ///// <param name="profileAccount">The mesh profile.</param>
        ///// <param name="profileDevice">Profile of the device to be added.</param>
        ///// <param name="activationDevice">The device key overlay.</param>
        ///// <param name="activationAccount">The account key overlay.</param>
        ///// <returns>The CatalogedDevice entry.</returns>
        //CatalogedDevice CreateCataloguedDevice(
        //            ProfileUser profileAccount,
        //            ProfileDevice profileDevice,
        //            ActivationDevice activationDevice,
        //            ActivationAccount activationAccount) {

        //    PrivateAccountOnlineSignature.AssertNotNull(NotSuperAdministrator.Throw);


        //    profileAccount.AssertNotNull(Internal.Throw);
        //    profileAccount.DareEnvelope.AssertNotNull(Internal.Throw);
        //    profileDevice.AssertNotNull(Internal.Throw);
        //    profileDevice.DareEnvelope.AssertNotNull(Internal.Throw);

        //    activationDevice.AssertNotNull(Internal.Throw);
        //    activationDevice.Package(PrivateAccountOfflineSignature);
        //    activationDevice.DareEnvelope.AssertNotNull(Internal.Throw);

        //    activationAccount.AssertNotNull(Internal.Throw);
        //    activationAccount.Package(PrivateAccountOfflineSignature);
        //    activationAccount.DareEnvelope.AssertNotNull(Internal.Throw);


        //    var connectionDevice = activationDevice.ConnectionUser;
        //    connectionDevice.AssertNotNull(Internal.Throw);
        //    connectionDevice.Sign(PrivateAccountOnlineSignature);
        //    connectionDevice.DareEnvelope.AssertNotNull(Internal.Throw);

        //    // Wrap the connectionDevice and activationDevice in envelopes

        //    var catalogEntryDevice = new CatalogedDevice() {
        //        UDF = activationDevice.UDF,
        //        EnvelopedProfileUser = profileAccount.DareEnvelope,
        //        EnvelopedProfileDevice = profileDevice.DareEnvelope,
        //        EnvelopedConnectionUser = connectionDevice.DareEnvelope,
        //        EnvelopedActivationDevice = activationDevice.DareEnvelope,
        //        EnvelopedActivationAccount = activationAccount.DareEnvelope,
        //        DeviceUDF = profileDevice.UDF
        //        };

        //    return catalogEntryDevice;
        //    }

        ///// <summary>
        ///// Add the device specified by <paramref name="profileDevice"/> to the account granting administration
        ///// privileges if <paramref name="keyPairOnlineSignature"/> is not null and super administration 
        ///// privilege if <paramref name="superAdmin"/> is true. Note that it is possible for a device to 
        ///// be a super administrator without also being an administrator.
        ///// </summary>
        ///// <param name="profileDevice">Profile of the device to add.</param>
        ///// <param name="keyPairOnlineSignature">If not null, specifies an online signature key that is to be used
        ///// to sign administrator functions.</param>
        ///// <param name="rights">The initial rights to be assigned to the device.</param>
        ///// <returns>The catalog entry.</returns>
        //public CatalogedDevice MakeCatalogedDevice(
        //                ProfileDevice profileDevice, 
        //                KeyPair keyPairOnlineSignature = null,
        //                List<string> rights = null) {

        //    // Grant the device access to data encrypted under the account key.
        //    // Note that this cannot be granted through the capabilities catalog because that
        //    // is also encrypted under the account key.
        //    var activationUser = new ActivationDevice(profileDevice);

        //    var activationAccount = MakeActivationAccount(profileDevice, keyPairOnlineSignature, rights);

        //    var catalogedDevice = CreateCataloguedDevice(
        //            ProfileUser, profileDevice, activationUser, activationAccount);

        //    catalogedDevice.SignatureUDF = keyPairOnlineSignature?.KeyIdentifier;

        //    return catalogedDevice;
        //    }





        /// <summary>
        /// Create a contact entry for self using the parameters specified in <paramref name="contact"/>.
        /// </summary>
        /// <param name="contact">The contact parameters.</param>
        /// <param name="localname">Short name to apply to the signed contact info</param>
        public CatalogedContact SetContactSelf(Contact contact, string localname = null) {
            PrivateAccountOnlineSignature.AssertNotNull(NotAdministrator.Throw);
            contact.Sign(PrivateAccountOnlineSignature);

            contact.Sources ??= new List<TaggedSource>() { };
            var tagged = new TaggedSource() {
                LocalName = localname,
                Validation = "Self",
                EnvelopedSource = contact.EnvelopedContact
                };
            contact.Sources.Add(tagged);

            contact.Id = ProfileUser.UDF;

            var transact = TransactBegin();
            var catalog = transact.GetCatalogContact();

            var (cataloged, success) = catalog.TryAdd(contact, true);

            if (!success) {
                cataloged.Contact = contact;
                transact.CatalogUpdate(catalog, cataloged);
                }

            transact.Transact();

            return cataloged;
            }

        /// <summary>
        /// Get the default (i.e. minimum contact info). This has a single network 
        /// address entry for this mesh and mesh account. 
        /// </summary>
        /// <returns>The default contact.</returns>
        public override Contact CreateContact(
                    List<CryptographicCapability> capabilities = null) {

            var address = new NetworkAddress(AccountAddress, ProfileUser) {
                Capabilities = capabilities
                };

            var anchorAccount = new Anchor() {
                UDF = ProfileUser.UDF,
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
        public string GetAccountAddress() {
            ProfileUser.AccountAddresses.AssertNotNull(AccountNotBound.Throw);
            foreach (var address in ProfileUser.AccountAddresses) {
                if (address.IsAccountID()) {
                    return address;
                    }

                }
            throw new AddressNotSupported();
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

        ///<summary>Dictionarry used to create stores</summary>
        public override Dictionary<string, StoreFactoryDelegate> DictionaryCatalogDelegates => catalogDelegates;
        Dictionary<string, StoreFactoryDelegate> catalogDelegates = new Dictionary<string, StoreFactoryDelegate>() {
            {CatalogCredential.Label, CatalogCredential.Factory},
            {CatalogContact.Label, CatalogContact.Factory},
            {CatalogCalendar.Label, CatalogCalendar.Factory},
            {CatalogBookmark.Label, CatalogBookmark.Factory},
            {CatalogNetwork.Label, CatalogNetwork.Factory},
            {CatalogApplication.Label, CatalogApplication.Factory},
            {CatalogDevice.Label, CatalogDevice.Factory},

            // All contexts have a capability catalog:
            {CatalogCapability.Label, CatalogCapability.Factory},
            {CatalogPublication.Label, CatalogPublication.Factory}
            };



        ///<summary>Returns the inbound spool for the account</summary>
        public SpoolInbound GetSpoolInbound() => GetStore(SpoolInbound.Label) as SpoolInbound;

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
            return GetByAccountEncrypt(keyId);
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

            var catalogCapability = GetStore(CatalogCapability.Label) as CatalogCapability;

            return catalogCapability.TryFindKeyDecryption(keyId);
            }
        #endregion
        #region // Message Handling - Get/Process pending.

        /// <summary>
        /// Return the latest unprocessed MessageConnectionRequest that was received.
        /// </summary>
        /// <returns>The latest unprocessed MessageConnectionRequest</returns>
        public Message GetPendingMessageConnectionRequest() =>
            GetPendingMessage(AcknowledgeConnection.__Tag);

        /// <summary>
        /// Return the latest unprocessed MessageContactRequest that was received.
        /// </summary>
        /// <returns>The latest unprocessed MessageContactRequest</returns>
        public Message GetPendingMessageContactRequest() =>
            GetPendingMessage(RequestContact.__Tag);

        /// <summary>
        /// Return the latest unprocessed MessageContactRequest that was received.
        /// </summary>
        /// <returns>The latest unprocessed MessageContactRequest</returns>
        public Message GetPendingMessageContactReply() =>
            GetPendingMessage(ReplyContact.__Tag);

        /// <summary>
        /// Return the latest unprocessed MessageConfirmationRequest that was received.
        /// </summary>
        /// <returns>The latest unprocessed MessageConfirmationRequest</returns>
        public Message GetPendingMessageConfirmationRequest() =>
            GetPendingMessage(RequestConfirmation.__Tag);

        /// <summary>
        /// Return the latest unprocessed MessageConfirmationResponse that was received.
        /// </summary>
        /// <returns>The latest unprocessed MessageConfirmationResponse</returns>
        public Message GetPendingMessageConfirmationResponse() =>
            GetPendingMessage(ResponseConfirmation.__Tag);


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
                EnvelopedProfileGroup = profileGroup.EnvelopedProfileGroup
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


            var transaction = TransactBegin();

            var catalogCapability = transaction.GetCatalogCapability();
            catalogCapability.Add(capabilityAdmin);
            catalogCapability.Add(capabilityDecrypt);

            var catalogedGroup = new CatalogedGroup(profileGroup) {
                Key = groupName
                };
            var catalogApplication = transaction.GetCatalogApplication();
            transaction.CatalogUpdate(catalogApplication, catalogedGroup);


            var contextGroup = ContextGroup.CreateGroup(this, catalogedGroup);

            var contact = contextGroup.CreateContact();


            var contactCatalog = transaction.GetCatalogContact();
            var catalogedContact = new CatalogedContact(contact);
            transaction.CatalogUpdate(contactCatalog, catalogedContact);

            transaction.Transact();

            return contextGroup;


            }

        /// <summary>
        /// Get a managment context for the group <paramref name="groupAddress"/>.
        /// </summary>
        /// <param name="groupAddress">The group to return the management context for.</param>
        /// <returns>The created management context.</returns>
        public ContextGroup GetContextGroup(string groupAddress) {

            // read through the entries in CatalogApplication
            var catalog = GetStore(CatalogApplication.Label) as CatalogApplication;
            var entry = catalog.LocateGroup(groupAddress);

            // construct the group context
            // We do not attempt to get admin privs here, we will do that if necessary.
            return new ContextGroup(this, entry);
            }



        #endregion
        #region // Device connection

        /// <summary>
        /// Convenience wrapper for <see cref="CreateDeviceEarl"/>. Generates a device profile
        /// and writes the <see cref="DevicePreconfiguration"/> data to a file in the directory
        /// specified by <paramref name="path"/>.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="profileDevice"></param>
        /// <param name="connectUri"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool Preconfigure(
                    out string filename,
                    out ProfileDevice profileDevice,
                    out string connectUri, 
                    string path = "") {

            var response = CreateDeviceEarl(
                    out var secretSeed,
                    out profileDevice,
                    out var connectKey,
                    out connectUri);

            filename = Path.Combine(path, connectKey + ".medk");

            var devicePreconfiguration = new DevicePreconfiguration(secretSeed, connectUri);
            devicePreconfiguration.ToFile(filename, tagged: true);

            return response;
            }


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
        /// <param name="bits">The size of secret to generate in bits/</param>
        /// <returns>Response from the server.</returns>
        public bool CreateDeviceEarl(
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
                UdfAlgorithmIdentifier.MeshProfileDevice, null, secret, 
                algorithmEncrypt, algorithmSign, algorithmAuthenticate,
                bits: bits);


            pin = MeshUri.GetConnectPin(secretSeed, AccountAddress);

            var key = new CryptoKeySymmetric(pin);

            connectURI = MeshUri.ConnectUri(AccountAddress, pin);

            // Create a device profile 
            profileDevice = new ProfileDevice(secretSeed: secretSeed);

            // Convert the enveloped profile device to a binary field and take the envelope
            // of that.
            var plaintext = profileDevice.DareEnvelope.GetBytes();
            var encryptedProfileDevice = DareEnvelope.Encode(plaintext, encryptionKey: key);
            var catalogedPublication = new CatalogedPublication(pin) {
                EnvelopedData = encryptedProfileDevice,
                };


            // commit the transaction
            var transactPublication = TransactBegin();
            var catalogPublication = transactPublication.GetCatalogPublication();
            transactPublication.CatalogUpdate(catalogPublication, catalogedPublication);
            Transact(transactPublication);

            return true;
            }


        /// <summary>
        /// Attempt device connection by means of the static URI <paramref name="uri"/>.
        /// </summary>
        /// <param name="uri">The connection URI</param>
        /// <returns>The </returns>
        public CatalogedDevice Connect(string uri, List<string> rights=null) {

            var envelopedProfileDevice = ClaimPublication(uri, out var responseId);

            // Decode the Profile Device
            var profileDevice = ProfileDevice.Decode(envelopedProfileDevice);

            // Approve the request
            // Have to add in the Mesh profile here and Account Assertion

            var cataloguedDevice = ActivationAccount.MakeCatalogedDevice(profileDevice, ProfileUser, rights: rights);

            //Console.WriteLine($"Accept connection ID is {responseId}");
            var respondConnection = new RespondConnection() {
                MessageID = responseId,
                CatalogedDevice = cataloguedDevice,
                Result = Constants.TransactionResultAccept
                };

            // Transactional update.
            var transact = TransactBegin();
            transact.LocalMessage(respondConnection);

            var catalogDevice = transact.GetCatalogDevice();
            transact.CatalogUpdate(catalogDevice, cataloguedDevice);
            Transact(transact);

            //SendMessage(respondConnection);


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

            messageClaim.Envelope(KeySignature);

            // make claim request to service managing the device
            var claimRequest = new ClaimRequest {
                EnvelopedMessageClaim = messageClaim.EnvelopedMessageClaim
                };

            var claimResponse = MeshClient.Claim(claimRequest);

            // The Dare envelope contains a DareEnvelope<ProfileDevice>
            var encryptedEnvelope = claimResponse.CatalogedPublication.EnvelopedData;

            // Verify: if the key is a encrypt/sign, need to verify here.
            "If the key is a encrypt/sign, need to verify here.".TaskValidate();

            var result = encryptedEnvelope.DecodeJsonObject(key) as DareEnvelope;

            responseId = messageClaim.GetResponseId();

            return result;
            }
        #endregion
        #region // Processing

        /// <summary>
        /// Process automatic actions.
        /// </summary>
        /// <returns>The results of the automatic processing attempted.</returns>
        public List<ProcessResult> ProcessAutomatics() {
            var results = new List<ProcessResult>();

            Screen.WriteLine($"ProcessAutomatics");


            // This is failing the second time round.
            // The frame count is 3, the index of the returned record is 1
            // SpoolEntryLast???


            var spoolInbound = GetSpoolInbound();
            foreach (var spoolEntry in spoolInbound.GetMessages(MessageStatus.Open)) {
                var meshMessage = spoolEntry.Message;

                // Must enforce this from now on. 
                //spoolEntry.Open.AssertTrue(Internal.Throw);

                Screen.WriteLine($"$$ Got message {meshMessage.GetType()} { meshMessage.MessageID}: Status {spoolEntry.MessageStatus}");

                if (!spoolEntry.Closed) {
                    switch (meshMessage) {
                        case AcknowledgeConnection acknowledgeConnection: {
                            if (acknowledgeConnection.MessageConnectionRequest.PinUDF != null) {
                                Screen.WriteLine($"    {acknowledgeConnection.MessageConnectionRequest.PinUDF}");
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
                }

            return results;
            }



        /// <summary>
        /// Perform automatic processing of the message <paramref name="request"/>.
        /// </summary>
        /// <param name="request">Reply to contact request to be processed.</param>
        /// <param name="accept">Accept the requested action.</param>
        /// <param name="authorize">If true, the action is explicitly authorized.</param>
        /// <returns>The result of requesting the connection.</returns>
        public ProcessResult ProcessAutomatic(
                        GroupInvitation request, 
                        bool accept = true,
                        bool authorize = false) {
            authorize.Future();

            if (!accept) {
                return new ResultRefused(request);
                }

            if (request.Contact == null) {
                return new ProcessResultError(request, ProcessingResult.ContactInvalid);
                }

            var transactRequest = TransactBegin();
            var catalogContact = transactRequest.GetCatalogContact();

            catalogContact.Add(request.Contact);  // Hack: make transactional
            if (request.Contact?.NetworkAddresses != null) {
                var catalogCapability = transactRequest.GetCatalogCapability(); // Hack: make transactional
                foreach (var address in request.Contact.NetworkAddresses) {
                    if (address.Capabilities != null) {
                        foreach (var capability in address.Capabilities) {
                            catalogCapability.Add(capability);
                            }
                        }
                    }
                }

            transactRequest.Transact();

            return new ResultGroupInvitation (request);
            }

        /// <summary>
        /// Perform automatic processing of the message <paramref name="request"/>.
        /// </summary>
        /// <param name="request">Reply to contact request to be processed.</param>
        /// <param name="accept">Accept the requested action.</param>
        /// <param name="authorize">If true, the action is explicitly authorized.</param>
        /// <returns>The result of requesting the connection.</returns>
        public ProcessResult ProcessAutomatic(
                    ReplyContact request, 
                    bool accept = true,
                    bool authorize = false) {
            
            authorize.Future();

            // check response pin here 
            var messagePin = GetMessagePIN(request.PinUDF);

            var pinStatus = MessagePIN.ValidatePin(messagePin,
                    AccountAddress,
                    request.AuthenticatedData,
                    request.ClientNonce,
                    request.PinWitness);

            if (pinStatus != ProcessingResult.Success) {
                return new ProcessResultError(request, pinStatus, messagePin);
                }
            if (!(messagePin.Automatic | accept)) {
                return new InsufficientAuthorization(request);
                }

            var contact = Contact.Decode(request.AuthenticatedData);

            var transactRequest = TransactBegin();
            var catalog = transactRequest.GetCatalogContact();
            var catalogedContact = catalog.GetUpdated(contact);

            transactRequest.CatalogUpdate(catalog, catalogedContact);
            transactRequest.InboundComplete(MessageStatus.Closed, request, null);
            transactRequest.Transact();

            return new ResultReplyContact(request, messagePin);
            }

        /// <summary>
        /// Perform automatic processing of the message <paramref name="request"/>.
        /// </summary>
        /// <param name="request">Connection request to be processed.</param>
        /// <returns>The result of requesting the connection.</returns>
        public ProcessResult ProcessAutomatic(AcknowledgeConnection request) {
            var messageConnectionRequest = request.MessageConnectionRequest;

            // get the pin value here
            var messagePin = GetMessagePIN(messageConnectionRequest.PinUDF);

            var pinStatus = MessagePIN.ValidatePin(messagePin,
                    AccountAddress,
                    messageConnectionRequest.AuthenticatedData,
                    messageConnectionRequest.ClientNonce,
                    messageConnectionRequest.PinWitness);

            if (pinStatus != ProcessingResult.Success) {
                return new ProcessResultError(request, pinStatus, messagePin);
                }

            return Process(request, true, messagePin);
            }

        /// <summary>
        /// Accept or reject a connection request.
        /// </summary>
        /// <param name="request">The request to accept or reject.</param>
        /// <param name="accept">If true, accept the request. Otherwise, it is rejected.</param>
        ProcessResult Process(AcknowledgeConnection request, bool accept = true, MessagePIN messagePIN = null,
               List<string> rights=null) {
            var transactRequest = TransactBegin();
            rights.Future();

            var respondConnection = new RespondConnection() {
                MessageID = request.GetResponseId()
                };
            if (accept) {
                // Connect the device to the Mesh
                var device = ActivationAccount.MakeCatalogedDevice(
                        request.MessageConnectionRequest.ProfileDevice, ProfileUser, rights: rights);

                respondConnection.CatalogedDevice = device;
                respondConnection.Result = Constants.TransactionResultAccept;
                var catalogDevice = transactRequest.GetCatalogDevice();
                transactRequest.CatalogUpdate(catalogDevice, device);

                }
            else {
                respondConnection.Result = Constants.TransactionResultReject;
                }

            transactRequest.InboundComplete(MessageStatus.Closed, request, respondConnection);
            transactRequest.LocalMessage(respondConnection);

            // Mark the pin code as having been used.
            if (messagePIN != null) {
                transactRequest.LocalComplete(MessageStatus.Closed, 
                    messagePIN, respondConnection);
                }

            // Perform the transaction
            var responseTransaction = Transact(transactRequest);

            return new ResultAcknowledgeConnection(request, messagePIN, responseTransaction);
            }





        /// <summary>
        /// Generalized processing loop for messages
        /// </summary>
        /// <param name="messageId">Identifier of the message to process.</param>
        /// <param name="accept">If true, accept the request, otherwise reject it.</param>
        /// <param name="reciprocate">If true, reciprocate the response: e.g. return user's own
        /// contact information in response to an initial contact request.</param>
        /// <returns></returns>
        public ProcessResult Process(string messageId, bool accept = true, bool reciprocate = true) {


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
        public ProcessResult Process(Message meshMessage, bool accept = true, bool reciprocate = true,
                    List<string> rights = null) {
            "Merge this processing loop with the other processing loop".TaskFunctionality();
            reciprocate.Future();

            switch (meshMessage) {
                case AcknowledgeConnection connection: {
                    return Process(connection, accept, rights: rights);
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
        public ProcessResult ContactReply(RequestContact requestContact, string localname = null) {

            // Add the requestContact.Self contact to the catalog

            if (requestContact.Self != null) {
                var contact = MeshItem.Decode(requestContact.Self) as Contact;
                var cataloged = contact.CatalogedContact();

                var transact = TransactBegin();
                var catalog = transact.GetCatalogContact();

                transact.CatalogUpdate(catalog, cataloged);
                transact.Transact();
                }

            var reply = SendReplyContact(requestContact.Sender, requestContact.PIN, localname);


            return new ResultRequestContact(requestContact, reply);
            }

        ReplyContact SendReplyContact(string recipient, string pin, string localname) {
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
            var transact = TransactBegin();
            transact.OutboundMessage(recipient,  message);
            Transact(transact);

            //SendMessage(message, recipient);

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
        public Enveloped<Contact> GetSelf(string localName) {
            var self = GetContact(ProfileUser.UDF);

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

            // Register the pin
            var messageConnectionPIN = new MessagePIN(pin, automatic, expire, AccountAddress, "Contact");

            var transactRequest = TransactBegin();
            transactRequest.LocalMessage(messageConnectionPIN);
            var catalogPublication = transactRequest.GetCatalogPublication();
            transactRequest.CatalogUpdate(catalogPublication, catalogedPublication);
            Transact(transactRequest);

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

            var transact = TransactBegin();
            transact.OutboundMessage(recipientAddress, message);
            Transact(transact);

            //SendMessage(message, recipientAddress);

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

            var contact = MeshItem.Decode(envelope) as Contact;
            var cataloged = contact.CatalogedContact();

            var transact = TransactBegin();
            var catalog = transact.GetCatalogContact();
            transact.CatalogUpdate(catalog, cataloged);
            transact.Transact();


            if (reciprocate) {
                (var targetAccountAddress, var pin) = MeshUri.ParseConnectUri(uri);
                message = SendReplyContact(targetAccountAddress, pin, localname) as Message;
                }
            else {
                message = null;
                }

            return cataloged;
            }
        #endregion
        #region // Confirmation Processing

        /// <summary>
        /// Construct a confirmation request.
        /// </summary>
        /// <param name="recipientAddress">The contact to request.</param>
        /// <param name="messageText">The message text to send.</param>
        public RequestConfirmation ConfirmationRequest(string recipientAddress, string messageText) {
            // prepare the contact request

            var message = new RequestConfirmation() {
                Recipient = recipientAddress,
                Text = messageText
                };

            var transact = TransactBegin();
            transact.OutboundMessage(recipientAddress, message);
            Transact(transact);

            // send it to the service
            return message;
            }


        /// <summary>
        /// Make a contact reply.
        /// </summary>
        /// <param name="requestConfirmation">The request received.</param>
        /// <param name="response">If true, accept the confirmation request, otherwise reject.</param>
        public ProcessResult ConfirmationResponse(RequestConfirmation requestConfirmation, bool response) {
            // prepare the contact request

            var recipientAddress = requestConfirmation.Sender;

            var message = new ResponseConfirmation() {
                MessageID = requestConfirmation.GetResponseId(),
                Recipient = recipientAddress,
                Accept = response,
                Request = requestConfirmation.EnvelopedRequestConfirmation
                };

            var transact = TransactBegin();
            transact.OutboundMessage(recipientAddress, message);
            Transact(transact);

            // send it to the service
            return null;
            }



        #region // Convenience methods for Contacts catalog

        /// <summary>
        /// Return the application with identifier <paramref name="key"/>.
        /// </summary>
        /// <param name="key">specifies the identifier to return.</param>
        /// <returns>The contact, if found. Otherwise null.</returns>
        public CatalogedApplication GetApplication(string key) =>
            (GetStore(CatalogApplication.Label) as CatalogApplication).Get(key);

        /// <summary>
        /// Return the device with identifier <paramref name="key"/>.
        /// </summary>
        /// <param name="key">specifies the identifier to return.</param>
        /// <returns>The device, if found. Otherwise null.</returns>
        public CatalogedDevice GetDevice(string key) =>
            (GetStore(CatalogDevice.Label) as CatalogDevice).Get(key);

        /// <summary>
        /// Return the contact with identifier <paramref name="key"/>.
        /// </summary>
        /// <param name="key">specifies the identifier to return.</param>
        /// <returns>The contact, if found. Otherwise null.</returns>
        public CatalogedContact GetContact(string key) =>
            (GetStore(CatalogContact.Label) as CatalogContact).Get(key);

        /// <summary>
        /// Return the credential with identifier <paramref name="key"/>.
        /// </summary>
        /// <param name="key">specifies the identifier to return.</param>
        /// <returns>The credential, if found. Otherwise null.</returns>
        public CatalogedCredential GetCredential(string key) =>
            (GetStore(CatalogCredential.Label) as CatalogCredential).Get(key);

        /// <summary>
        /// Return the credential with identifier <paramref name="key"/>.
        /// </summary>
        /// <param name="key">specifies the identifier to return.</param>
        /// <returns>The credential, if found. Otherwise null.</returns>
        public CatalogedCredential GetCredentialByService(string key) =>
            (GetStore(CatalogCredential.Label) as CatalogCredential).GetCredentialByService(key);


        /// <summary>
        /// Return the bookmark with identifier <paramref name="key"/>.
        /// </summary>
        /// <param name="key">specifies the identifier to return.</param>
        /// <returns>The bookmark, if found. Otherwise null.</returns>
        public CatalogedBookmark GetBookmark(string key) =>
            (GetStore(CatalogBookmark.Label) as CatalogBookmark).Get(key);

        /// <summary>
        /// Return the task with identifier <paramref name="key"/>.
        /// </summary>
        /// <param name="key">specifies the identifier to return.</param>
        /// <returns>The task, if found. Otherwise null.</returns>
        public CatalogedTask GetCalendar(string key) =>
            (GetStore(CatalogCalendar.Label) as CatalogCalendar).Get(key);

        /// <summary>
        /// Return the network entry with identifier <paramref name="key"/>.
        /// </summary>
        /// <param name="key">specifies the identifier to return.</param>
        /// <returns>The network entry, if found. Otherwise null.</returns>
        public CatalogedNetwork GetNetwork(string key) =>
            (GetStore(CatalogNetwork.Label) as CatalogNetwork).Get(key);



        /// <summary>
        /// Add the contact data specified in the file <paramref name="fileName"/>. If 
        /// <paramref name="self"/> is true, register this as the self contact. If
        /// <paramref name="merge"/> is true, merge this contact information.
        /// </summary>
        /// <param name="fileName">The file to fetch the contact data from.</param>
        /// <param name="self">If true, contact data corresponds to this user.</param>
        /// <param name="localName">Short name for the contact to distinguish it from
        /// others.</param>
        /// <param name="merge">Add this data to the existing contact.</param>
        /// <param name="format">The format the input is written in.</param>
        /// <returns></returns>
        public CatalogedContact AddFromFile(
                    string fileName,
                    bool self,
                    CatalogedEntryFormat format = CatalogedEntryFormat.Unknown,
                    bool merge = true,
                    string localName = null) {
            merge.Future();
            localName.Future();

            using var transaction = TransactBegin();
            var catalog = transaction.GetCatalogContact();
            using var stream = fileName.OpenFileReadShared();
            var contact = catalog.ReadFromStream(stream, format);

            contact.Self = self;
            transaction.CatalogUpdate(catalog, contact);
            transaction.Transact();

            return contact;

            }

        /// <summary>
        /// Return the network entry for the address <paramref name="networkAddress"/>
        /// </summary>
        /// <param name="networkAddress">The address to return the entry for.</param>
        /// <returns>The network entry if found, otherwise, null.</returns>
        public NetworkProtocolEntry GetNetworkEntry(string networkAddress) =>
            (GetStore(CatalogContact.Label) as CatalogContact).GetNetworkEntry(networkAddress);

        /// <summary>
        /// Retuen the mesh account encryption key for the address <paramref name="networkAddress"/>
        /// </summary>
        /// <param name="networkAddress">The address to return the entry for.</param>
        /// <returns>The mesh account encryption key if found, otherwise, null.</returns>
        public CryptoKey GetByAccountEncrypt(string networkAddress) =>
            (GetStore(CatalogContact.Label) as CatalogContact).GetByAccountEncrypt(networkAddress);

        #endregion

        #endregion
        }


    }
