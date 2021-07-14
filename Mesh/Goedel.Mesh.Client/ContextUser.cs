using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Mesh;
using System;
using System.Collections.Generic;
using System.IO;
using Goedel.Protocol;
using Goedel.Protocol.Presentation;
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
        public override Connection Connection => ConnectionDevice;

        ///<summary>Convenience accessor to the account address.</summary>
        public override string AccountAddress => ProfileUser.AccountAddress;


        ///<summary>The cataloged device</summary>
        public virtual CatalogedDevice CatalogedDevice => CatalogedMachine?.CatalogedDevice;

        ///<summary>The profile</summary>
        public ProfileUser ProfileUser { get; set; }

        ///<summary>The connection device</summary>
        public ConnectionDevice ConnectionDevice => CatalogedDevice?.ConnectionUser;


        ///<summary>The connection device</summary>
        public ConnectionAddress ConnectionAddress => CatalogedDevice?.ConnectionAccount;

        ///<summary>The device activation</summary>
        public ActivationDevice ActivationDevice { get; private set; }


        ///<summary>The device key generation seed</summary>
        protected PrivateKeyUDF MeshSecretSeed;

        ///<summary>The RequestConnection message sent during device connection.
        ///This is only populated when the context is returned as the result of completing 
        ///device connection</summary> 
        public RequestConnection RequestConnection;

        ///<summary>The RespondConnection message returned during device connection.
        ///This is only populated when the context is returned as the result of completing 
        ///device connection</summary> 
        public RespondConnection RespondConnection;

        ///<summary>Device decryption key in account context.</summary> 
        public KeyPairAdvanced BaseDecrypt { get; }

        ///<summary>Device decryption key in account context.</summary> 
        public KeyPairAdvanced BaseAuthenticate { get; }


        ///<summary>Device signature key in account context.</summary>
        public KeyPairAdvanced DeviceSignature => ActivationDevice?.DeviceSignature;

        ///<summary>Device decryption key in account context.</summary>
        public KeyPairAdvanced DeviceEncryption => ActivationDevice?.DeviceEncryption;

        ///<summary>Device authentication key in account context.</summary>
        public KeyPairAdvanced DeviceAuthentication => ActivationDevice?.DeviceAuthentication;

        /// <summary>
        /// Create a new ICredential.
        /// </summary>
        /// <returns>The credential</returns>
        public override MeshCredentialPrivate GetMeshCredentialPrivate() => new(
                ProfileDevice, ConnectionDevice, ConnectionAddress,
                DeviceAuthentication ?? BaseAuthenticate);

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
            var deviceKeySeed = KeyCollection.LocatePrivateKey(ProfileDevice.Udf) as PrivateKeyUDF;
            BaseDecrypt = deviceKeySeed.GenerateContributionKeyPair(MeshKeyType.Base,
                MeshActor.Device, MeshKeyOperation.Encrypt);
            BaseAuthenticate = deviceKeySeed.GenerateContributionKeyPair(MeshKeyType.Base,
                MeshActor.Device, MeshKeyOperation.Authenticate);
            KeyCollection.Add(BaseDecrypt);

            // Activate the device within the account.
            ActivationDevice = CatalogedDevice?.GetActivationDevice(KeyCollection);
            ActivationDevice.Activate(deviceKeySeed);

            // Activate the device to communicate as the account (via threshold)
            ActivationAccount = CatalogedDevice?.GetActivationAccount(KeyCollection);
            ActivationAccount.Activate(KeyCollection);

            if (KeyAccountEncryption != null) {
                KeyCollection.Add(KeyAccountEncryption);
                }

            // Some validation checks
            (DeviceSignature.KeyIdentifier).AssertEqual(ConnectionDevice.Signature.Udf,
                    KeyActivationFailed.Throw);
            (DeviceEncryption.KeyIdentifier).AssertEqual(ConnectionDevice.Encryption.Udf,
                    KeyActivationFailed.Throw);
            (DeviceAuthentication.KeyIdentifier).AssertEqual(ConnectionDevice.Authentication.Udf,
                    KeyActivationFailed.Throw);
            }

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
                MeshSecretSeed = KeyCollection.LocatePrivateKey(ProfileUser.ProfileSignature.Udf) as PrivateKeyUDF;
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
        public void EraseMeshSecret() => KeyCollection.ErasePrivateKey(ProfileUser.ProfileSignature.Udf);

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
            KeyProfile.AssertNotNull(NotSuperAdministrator.Throw);

            // Query the service capabilities
            var helloRequest = new HelloRequest();
            var helloResponse = MeshClient.Hello(helloRequest);
            ProfileService = helloResponse.EnvelopedProfileService.Decode();

            // Update the profile
            ProfileUser.ServiceUdf = ProfileService.Udf;
            ProfileUser.AccountAddress = accountAddress;
            ProfileUser.Envelope(KeyProfile);

            // Request binding
            var createRequest = new BindRequest() {
                AccountAddress = accountAddress,
                EnvelopedProfileAccount = ProfileUser.EnvelopedProfileAccount,
                };

            // Attempt to register with service in question
            var response = MeshClient.BindAccount(createRequest);
            response.AssertSuccess(ServerOperationFailed.Throw);

            ActivationAccount.BindService(ProfileService);

            ////RudStream.Rebind(MeshClient, AccountAddress);

            //"Fix this rebind to put the connection in".TaskFunctionality(true);
            //MeshClient.Rebind(GetMeshCredentialPrivate());

            // Generate a contact and self-sign
            var contact = CreateContact();
            SetContactSelf(contact);
            LoadStores(); // Load all stores so that these are created on the service.

            SyncProgressUpload();

            // should probably save the updated profile at some point.
            }

        /// <summary>
        /// Returns the stores directory on <paramref name="meshHost"/> for the profile 
        /// <paramref name="profileUser"/>.
        /// </summary>
        /// <param name="meshHost">The host.</param>
        /// <param name="profileUser">The profile.</param>
        /// <returns>Path to the directory containing the profile stores.</returns>
        public static string GetStoresDirectory(
                MeshHost meshHost, ProfileUser profileUser) =>
                    Path.Combine(meshHost.MeshMachine.DirectoryMesh, profileUser.Udf);

        /// <summary>
        /// Create the stores directory and initialize catalogs.
        /// </summary>
        /// <param name="meshHost">The host context</param>
        /// <param name="profileUser">The user profile</param>
        /// <param name="activationAccount">The account activation</param>
        /// <param name="keyLocate">the key locator.</param>
        public static void CreateDirectory(
                    MeshHost meshHost, 
                    ProfileUser profileUser,
                    ActivationAccount activationAccount,
                    IKeyCollection keyLocate) {
            var StoresDirectory = ContextUser.GetStoresDirectory(meshHost, profileUser);
            Directory.CreateDirectory(StoresDirectory);


            // Create each of the stores and add the activation to the record.
            foreach (var entry in StaticCatalogDelegates) {
                
                var storeName = entry.Key;
                if (!ServiceCatalogs.Contains(storeName)) {

                    var factory = entry.Value;
                    var policy = activationAccount.InitializeStore(storeName);

                    using var store = factory(StoresDirectory, storeName, null, policy, keyCollection: keyLocate);
                    }
                }
            foreach (var entry in StaticSpoolDelegates) {
                var storeName = entry.Key;
                var factory = entry.Value;
                var policy = activationAccount.InitializeStore(storeName);

                using var store = factory(StoresDirectory, storeName, null, policy);
                }

            }


        #endregion
        #region // Contact management


        /// <summary>
        /// Create a contact entry for self using the parameters specified in <paramref name="contact"/>.
        /// </summary>
        /// <param name="contact">The contact parameters.</param>
        /// <param name="localname">Short name to apply to the signed contact info</param>
        public CatalogedContact SetContactSelf(Contact contact, string localname = null) {
            KeyAccountSignature.AssertNotNull(NotAdministrator.Throw);
            contact.Envelope(KeyAccountSignature);

            contact.Sources ??= new List<TaggedSource>() { };
            var tagged = new TaggedSource() {
                LocalName = localname,
                Validation = "Self",
                EnvelopedSource = contact.EnvelopedContact
                };
            contact.Sources.Add(tagged);

            contact.Id = ProfileUser.Udf;

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
                Udf = ProfileUser.Udf,
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

        #region // Operations on capabilities 


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
        public static CryptographicCapability GetCapability(DareEnvelope envelopedCapability) {
            envelopedCapability.Future();

            throw new NYI();

            }
        #endregion

        #region // Store management and convenience accessors

        ///<summary>Dictionarry used to create stores</summary>
        public override Dictionary<string, StoreFactoryDelegate> DictionaryCatalogDelegates => StaticCatalogDelegates;
        static Dictionary<string, StoreFactoryDelegate> StaticCatalogDelegates = new() {
            {CatalogCredential.Label, CatalogCredential.Factory},
            {CatalogContact.Label, CatalogContact.Factory},
            {CatalogTask.Label, CatalogTask.Factory},
            {CatalogBookmark.Label, CatalogBookmark.Factory},
            {CatalogNetwork.Label, CatalogNetwork.Factory},
            {CatalogApplication.Label, CatalogApplication.Factory},
            {CatalogDevice.Label, CatalogDevice.Factory},

            // All contexts have a capability catalog:
            {CatalogAccess.Label, CatalogAccess.Factory},
            {CatalogPublication.Label, CatalogPublication.Factory}
            };

        static SortedSet<string> ServiceCatalogs = new() {
            CatalogAccess.Label,
            CatalogPublication.Label
            };

        ///<summary>Returns the inbound spool for the account</summary>
        public SpoolInbound GetSpoolInbound() => GetStore(SpoolInbound.Label) as SpoolInbound;

        /// <summary>
        /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyId">The identifier to resolve.</param>
        /// <param name="cryptoKey">The found key </param>
        /// <returns>The identifier.</returns>
        public override bool TryFindKeyEncryption(string keyId, out CryptoKey cryptoKey) {
            if (base.TryFindKeyEncryption(keyId, out cryptoKey)) {
                return true;
                }
            cryptoKey = GetByAccountEncrypt(keyId);
            return cryptoKey != null;
            }


        /// <summary>
        /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
        /// an account identifier or strong account identifier.
        /// </summary>
        /// <param name="keyId">The identifier to resolve.</param>
        /// <param name="cryptoKey">The found key </param>
        /// <returns>The identifier.</returns>
        public override bool TryFindKeySignature(string keyId, out CryptoKey cryptoKey) {
            if (keyId == AccountAddress) {
                cryptoKey = KeyAccountSignature;
                return true;
                }
            if (TryFindKeySignature(keyId, out cryptoKey)) {
                return true;
                }
            return false;
            }


        /// <summary>
        /// Attempt to obtain a recipient with identifier <paramref name="keyId"/>.
        /// </summary>
        /// <param name="keyId">The key identifier to match.</param>
        /// <param name="cryptoKey">The found key </param>
        /// <returns>The key pair if found.</returns>
        public override bool TryFindKeyDecryption(string keyId, out IKeyDecrypt cryptoKey) {


            if (KeyCollection.TryFindKeyDecryption(keyId, out cryptoKey)) {
                return true;
                }
            if (ActivationAccount?.AccountEncryptionKey?.TryFindKeyDecryption(keyId, out cryptoKey) == true) {
                return true;
                }

            var catalogCapability = GetStore(CatalogAccess.Label) as CatalogAccess;
            return catalogCapability.TryFindKeyDecryption(keyId, out cryptoKey);
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
            GetPendingMessage(MessageContact.__Tag);


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

                if (!completed.ContainsKey(contentMeta.UniqueId)) {
                    var meshMessage = Message.Decode(message, KeyCollection);
                    //Console.WriteLine($"Message {contentMeta?.MessageType} ID {meshMessage.MessageID}");
                    if (contentMeta.MessageType == tag) {
                        return meshMessage;
                        }
                    switch (meshMessage) {
                        case MessageComplete meshMessageComplete: {
                            foreach (var reference in meshMessageComplete.References) {
                                completed.Add(reference.MessageId, meshMessageComplete);
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
                var meshMessage = Message.Decode(envelope, KeyCollection);

                // Message.FromJson(envelope.GetBodyReader());
                //meshMessage.DareEnvelope = envelope;
                //Console.WriteLine($"Message {contentMeta?.MessageType} ID {meshMessage.MessageID}");

                if (meshMessage.MessageId == messageID) {
                    read = true;
                    return meshMessage;
                    }
                switch (meshMessage) {
                    case MessageComplete meshMessageComplete: {
                        foreach (var reference in meshMessageComplete.References) {
                            if (reference.MessageId == messageID) {
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
        /// <param name="accountSeed">Specifies the secret seed and algorithms used to generate private keys.</param>
        /// <param name="rights">List of rights to be granted.</param>
        /// <returns></returns>

        public ContextGroup CreateGroup(string groupName,
                        PrivateKeyUDF accountSeed = null,
                        List<string> rights = null
                        ) {

            // create the cataloged group
            accountSeed ??= new PrivateKeyUDF(udfAlgorithmIdentifier: UdfAlgorithmIdentifier.MeshProfileAccount);

            var keyCollectionGroup = new KeyCollectionEphemeral();
            var activationGroup = new ActivationAccount(keyCollectionGroup, accountSeed);
            var profileGroup = new ProfileGroup(groupName, activationGroup);

            // Check that the profile is valid before using it.
            profileGroup.Validate();


            // create an administrative connection for this user
            var connectionGroup = new ConnectionAddress() {
                Account = groupName,
                Subject = ProfileUser.Udf,
                Authority = profileGroup.Udf
                };
            var envelopedConnectionGroup = connectionGroup.Envelope(activationGroup.AdministratorSignatureKey);



            // When we move to using thresholded keys, this needs to be modified
            // so that the activation for the cataloged group is saved under the 
            // account escrow key.

            rights.Future();
            var catalogedGroup = activationGroup.MakeCatalogedGroup(profileGroup,
                activationGroup, KeyAccountEncryption, connectionGroup);

            // here we request creation of the group at the service.
            var createRequest = new BindRequest() {
                AccountAddress = groupName,
                EnvelopedProfileAccount = profileGroup.EnvelopedProfileAccount
                };

            var createResponse = MeshClient.BindAccount(createRequest);
            createResponse.AssertSuccess();





            // create the group context
            var contextGroup = ContextGroup.CreateGroup(this, catalogedGroup);
            var contact = contextGroup.CreateContact();


            // create key generation capabilities
            var capabilityGroupEncrypt = CapabilityKeyGenerate.CreateThreshold(activationGroup.AccountEncryptionKey);
            var capabilityGroupSign = CapabilityKeyGenerate.CreateThreshold(activationGroup.AccountSignatureKey);

            // Commit all changes to the administrator context in a single transaction.
            using (var transaction = TransactBegin()) {
                // Add the group to the application catalog
                var catalogApplication = transaction.GetCatalogApplication();
                transaction.CatalogUpdate(catalogApplication, catalogedGroup);

                var catalogAccess = transaction.GetCatalogAccess();
                catalogAccess.Add(capabilityGroupEncrypt);
                catalogAccess.Add(capabilityGroupSign);

                // Create a contact for the group and add to the contact catalog
                var contactCatalog = transaction.GetCatalogContact();
                var catalogedContact = new CatalogedContact(contact);
                transaction.CatalogUpdate(contactCatalog, catalogedContact);

                transaction.Transact();
                }

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
        public DevicePreconfiguration Preconfigure(
                    out string filename,
                    out ProfileDevice profileDevice,
                    out string connectUri, 
                    string path = "") {

            CreateDeviceEarl(
                    out var secretSeed,
                    out profileDevice,
                    out var connectionDevice,
                    out var connectKey,
                    out connectUri);

            filename = Path.Combine(path, connectKey + ".medk");

            var devicePreconfiguration = new DevicePreconfiguration() {
                PrivateKey = secretSeed,
                ConnectUri = connectUri,
                EnvelopedProfileDevice = profileDevice.EnvelopedProfileDevice,
                EnvelopedConnectionDevice = connectionDevice.EnvelopedConnectionDevice
                };
            devicePreconfiguration.ToFile(filename, tagged: true);

            return devicePreconfiguration;
            }


        /// <summary>
        /// Create an EARL for a device, publish the result to the Mesh service and return 
        /// the device profile <paramref name="profileDevice"/>, secret seed value 
        /// <paramref name="secretSeed"/>, connection URI 
        /// <paramref name="connectURI"/> and PIN <paramref name="pin"/>.
        /// </summary>
        /// <param name="secretSeed">The computed secret seed value.</param>
        /// <param name="profileDevice">The computed device profile.</param>
        /// <param name="connectionDevice">The computed device connection.</param>
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
                    out ConnectionDevice connectionDevice,
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
                udfAlgorithmIdentifier: UdfAlgorithmIdentifier.MeshProfileDevice, secret: secret, algorithmEncrypt: algorithmEncrypt,
                algorithmSign: algorithmSign, algorithmAuthenticate: algorithmAuthenticate, bits: bits);


            pin = MeshUri.GetConnectPin(secretSeed, AccountAddress);

            var key = new CryptoKeySymmetric(pin);

            connectURI = MeshUri.ConnectUri(AccountAddress, pin);

            // Create a device profile 
            profileDevice = new ProfileDevice(secretSeed);

            // Create and sign the connection
            connectionDevice = new ConnectionDevice() {
                Signature = profileDevice.Signature,
                Encryption = profileDevice.Encryption,
                Authentication = profileDevice.Encryption
                };
            connectionDevice.Envelope(KeyAdministratorSign);


            // Convert the enveloped profile device to a binary field and take the envelope
            // of that.
            var plaintext = profileDevice.DareEnvelope.GetBytes();
            var encryptedProfileDevice = DareEnvelope.Encode((byte[])plaintext, encryptionKey: key);
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
        /// <param name="rights">The list of rights being requested by the device.</param>
        /// <returns>The </returns>
        public CatalogedDevice Connect(string uri, List<string> rights=null) {

            var envelopedProfileDevice = ClaimPublication(uri, out var responseId);

            // Decode the Profile Device
            var profileDevice = ProfileDevice.Decode(envelopedProfileDevice);
            var deviceEncrypt = profileDevice.Encryption.GetKeyPair();

            // Approve the request
            // Have to add in the Mesh profile here and Account Assertion

            var cataloguedDevice = ActivationAccount.MakeCatalogedDevice(profileDevice, ProfileUser, roles: rights);

            //Console.WriteLine($"Accept connection ID is {responseId}");
            var respondConnection = new RespondConnection() {
                MessageId = responseId,
                CatalogedDevice = cataloguedDevice,
                Result = MeshConstants.TransactionResultAccept
                };

            // Transactional update.
            var transact = TransactBegin();
            transact.LocalMessage(respondConnection, deviceEncrypt);

            var catalogDevice = transact.GetCatalogDevice();
            transact.CatalogUpdate(catalogDevice, cataloguedDevice);
            Transact(transact);

            //SendMessage(respondConnection);


            // ContextMeshPending
            return cataloguedDevice;
            }

        /// <summary>
        /// Delete the device <paramref name="id"/> from the device catalog.
        /// </summary>
        /// <param name="id">Identifier of the device to remove.</param>
        public void DeleteDevice(string id) {
            var transact = TransactBegin();
            var catalogDevice = transact.GetCatalogDevice();

            var deviceEntry = catalogDevice.Locate(id);

            transact.CatalogDelete(catalogDevice, deviceEntry);
            Transact(transact);
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

            messageClaim.Envelope(KeyAccountSignature);

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

            //Screen.WriteLine($"ProcessAutomatics");


            // This is failing the second time round.
            // The frame count is 3, the index of the returned record is 1
            // SpoolEntryLast???


            var spoolInbound = GetSpoolInbound();
            foreach (var spoolEntry in spoolInbound.GetMessages(MessageStatus.Open)) {
                var meshMessage = spoolEntry.Message;

                // Must enforce this from now on. 
                //spoolEntry.Open.AssertTrue(Internal.Throw);

                //Screen.WriteLine($"$$ Got message {meshMessage.GetType()} { meshMessage.MessageId}: Status {spoolEntry.MessageStatus}");

                if (!spoolEntry.Closed) {
                    switch (meshMessage) {
                        case AcknowledgeConnection acknowledgeConnection: {
                            if (acknowledgeConnection.MessageConnectionRequest.PinId != null) {
                                //Screen.WriteLine($"    {acknowledgeConnection.MessageConnectionRequest.PinId}");
                                results.Add(ProcessAutomatic(acknowledgeConnection));
                                }
                            break;
                            }
                        case MessageContact replyContact: {
                            results.Add(ProcessAutomatic(replyContact));
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
                var catalogCapability = transactRequest.GetCatalogAccess(); // Hack: make transactional
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
        /// <param name="request">Connection request to be processed.</param>
        /// <returns>The result of requesting the connection.</returns>
        public ProcessResult ProcessAutomatic(AcknowledgeConnection request) {
            var messageConnectionRequest = request.MessageConnectionRequest;

            // get the pin value here
            var messagePin = GetMessagePIN(messageConnectionRequest.PinId);

            var pinStatus = MessagePin.ValidatePin(messagePin,
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
        /// <param name="rights">The list of rights to be granted to the device.</param>
        /// <param name="messagePin">The PIN value to be used to authenticate the regquest.</param>
        /// <returns>The result of processing.</returns>
        ProcessResult Process(AcknowledgeConnection request, bool accept = true, MessagePin messagePin = null,
               List<string> rights=null) {
            var transactRequest = TransactBegin();

            var respondConnection = new RespondConnection() {
                MessageId = request.GetResponseId()
                };
            if (accept) {
                // Connect the device to the Mesh
                var device = ActivationAccount.MakeCatalogedDevice(
                        request.MessageConnectionRequest.ProfileDevice, ProfileUser, roles: rights);

                respondConnection.CatalogedDevice = device;
                respondConnection.Result = MeshConstants.TransactionResultAccept;
                var catalogDevice = transactRequest.GetCatalogDevice();
                transactRequest.CatalogUpdate(catalogDevice, device);

                }
            else {
                respondConnection.Result = MeshConstants.TransactionResultReject;
                }

            var deviceEncrypt = request.MessageConnectionRequest.ProfileDevice.Encryption.GetKeyPair();

            transactRequest.InboundComplete(MessageStatus.Closed, request, respondConnection);
            transactRequest.LocalMessage(respondConnection, deviceEncrypt);

            // Mark the pin code as having been used.
            if (messagePin != null) {
                transactRequest.LocalComplete(MessageStatus.Closed, 
                    messagePin, respondConnection);
                }

            // Perform the transaction
            var responseTransaction = Transact(transactRequest);

            return new ResultAcknowledgeConnection(request, messagePin, responseTransaction);
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
        /// <param name="rights">The list of rights to be granted to the device.</param>
        /// <returns>The result of processing.</returns>
        public ProcessResult Process(Message meshMessage, bool accept = true, bool reciprocate = true,
                    List<string> rights = null) {
            "Merge this processing loop with the other processing loop".TaskFunctionality();
            reciprocate.Future();

            switch (meshMessage) {
                case AcknowledgeConnection connection: {
                    return Process(connection, accept, rights: rights);
                    }
                case MessageContact requestContact: {
                    return ContactReply(requestContact, accept);
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
        /// <param name="accept">If true, enter the contact data from <paramref name="requestContact.Self"/>
        /// in the contact catalog.</param>
        /// <param name="localname">Local name to be used to identify the contact recorded in
        /// the catalog.</param>
        public ProcessResult ContactReply(
                MessageContact requestContact,
                bool accept,
                string localname = null) {

            // Do nothing if the request is rejected.
            if (!accept) {
                return new ResultMessageContact(requestContact, null);
                }

            // Add the requestContact.Self contact to the catalog
            if (requestContact.AuthenticatedData != null) {
                var contact = MeshItem.Decode(requestContact.AuthenticatedData) as Contact;
                var cataloged = contact.CatalogedContact();

                var transact = TransactBegin();
                var catalog = transact.GetCatalogContact();

                transact.CatalogUpdate(catalog, cataloged);
                transact.Transact();
                }

            // Get the reply (if required)
            var reply = requestContact.Reply ?
                ContactRequest(requestContact.Sender, requestContact.PIN, localname, false) : null;

            return new ResultMessageContact(requestContact, reply);
            }

        /// <summary>
        /// Perform automatic processing of the message <paramref name="request"/>.
        /// </summary>
        /// <param name="request">Reply to contact request to be processed.</param>
        /// <param name="authorize">If true, the action is explicitly authorized.</param>
        /// <returns>The result of requesting the connection.</returns>
        public ProcessResult ProcessAutomatic(
                    MessageContact request,
                    bool authorize = false) {

            // No pin specified? Request is not automatic.
            if (request.PinId == null) {
                return new InsufficientAuthorization(request);
                }

            // check response pin here 
            var messagePin = GetMessagePIN(request.PinId);

            // check the pin value
            var pinStatus = request.ValidatePin(messagePin, AccountAddress);
            if (pinStatus != ProcessingResult.Success) {
                return new ProcessResultError(request, pinStatus, messagePin);
                }

            // check that the pin is automatic or request is explicitly authorized.
            if (!(messagePin.Automatic | authorize)) {
                return new InsufficientAuthorization(request);
                }

            return ContactReply(request, true);
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
            var self = GetContact(ProfileUser.Udf);

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
            var messageConnectionPIN = new MessagePin(
                pin, automatic, expire, AccountAddress, MeshConstants.MessagePINActionContact);

            using (var transactRequest = TransactBegin()) {
                transactRequest.LocalMessage(messageConnectionPIN, KeyAccountEncryption);
                var catalogPublication = transactRequest.GetCatalogPublication();
                transactRequest.CatalogUpdate(catalogPublication, catalogedPublication);
                Transact(transactRequest);
                }

            // return the contact address
            return MeshUri.ConnectUri(AccountAddress, pin);
            }


        /// <summary>
        /// Construct a contact request.
        /// </summary>
        /// <param name="recipient">The contact to request.</param>
        /// <param name="pin">Optional pin value used to authenticate a response.</param>
        /// <param name="localname">Local name for the contact</param>
        /// <param name="reply">if true, request return of the recpients contact info in reply.</param>
        public MessageContact ContactRequest(string recipient,
                        string pin = null,
                        string localname = null,
                        bool reply = true) {
            // prepare the reply
            var contactSelf = GetSelf(localname);

            //"agh... not creating the pin code for the response here.".TaskFunctionality(true);

            var message = new MessageContact() {
                Recipient = recipient,
                Subject = recipient,
                AuthenticatedData = contactSelf,
                Reply = reply
                
                };

            using (var transact = TransactBegin()) {

                // If we are requesting a reply, add a PIN code.
                if (reply) {
                    var messagePin = GetPIN(MeshConstants.MessagePINActionContact, true,
                        128, register: false);
                    message.PIN = messagePin.Pin;
                    transact.LocalMessage(messagePin, KeyAccountEncryption);
                    }

                // If a PIN value was specified in the request, use it to authenticate the response.
                message.Authenticate(pin);

                // send it to the service
                transact.OutboundMessage(recipient, message);                
                Transact(transact);
                }

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
        public CatalogedContact ContactExchange(
                    string uri, 
                    bool reciprocate, 
                    out Message message, 
                    string localname = null) {
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
                message = ContactRequest(targetAccountAddress, pin, localname) as Message;
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
                MessageId = requestConfirmation.GetResponseId(),
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
            (GetStore(CatalogTask.Label) as CatalogTask).Get(key);

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
