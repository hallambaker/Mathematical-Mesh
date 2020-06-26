using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;

using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh.Client {




    /// <summary>
    /// Bound context for a Mesh Account. 
    /// </summary>
    public class ContextAccount : ContextAccountEntry, IKeyLocate {

        #region // Properties
        ///<summary>The enclosing mesh context.</summary>
        public override ContextMesh ContextMesh { get; }

        ///<summary>The account entry</summary>
        public AccountEntry AccountEntry { get; private set; }


        ///<summary>The account activation</summary>
        public ActivationAccount ActivationAccount =>
                AccountEntry.GetActivationAccount(KeyCollection);

        ///<summary>Convenience accessor for the account profile</summary>
        public ProfileAccount ProfileAccount => AccountEntry.ProfileAccount;

        ///<summary>Convenience accessor for the account connection</summary>
        ConnectionAccount ConnectionAccount => AccountEntry.ConnectionAccount;

        ///<summary>Convenience accessor for the connection.</summary>
        public override Connection Connection => ConnectionAccount;

        ///<summary>The directory containing the catalogs related to the account.</summary>
        public override string StoresDirectory => directoryAccount ??
            Path.Combine(MeshMachine.DirectoryMesh, ActivationAccount.AccountUDF).CacheValue(out directoryAccount);
        string directoryAccount;

        ///<summary>The Account Address</summary>
        public override string AccountAddress { get; protected set; }


        #endregion
        #region // Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="contextMesh">The Mesh context to which this account belongs.</param>
        /// <param name="accountEntry">The account entry within the device catalog entry.</param>
        /// <param name="accountAddress">The account service identifier.</param>
        public ContextAccount(
                    ContextMesh contextMesh,
                    AccountEntry accountEntry,
                    string accountAddress = null
                    )  {
            // Set up the basic context
            ContextMesh = contextMesh;
            AccountEntry = accountEntry;
            this.AccountAddress = accountAddress ?? AccountEntry.ProfileAccount?.ServiceDefault;

            var activationKey = ActivationAccount.ActivationKey;
            KeySignature = ContextMesh.ActivateKey(activationKey, MeshKeyType.DeviceSign);
            KeyEncryption = ContextMesh.ActivateKey(activationKey, MeshKeyType.DeviceEncrypt);
            KeyAuthentication = ContextMesh.ActivateKey(activationKey, MeshKeyType.DeviceAuthenticate);

            KeySignature.KeyIdentifier.AssertEqual(ConnectionAccount.KeySignature.UDF);
            KeyEncryption.KeyIdentifier.AssertEqual(ConnectionAccount.KeyEncryption.UDF);
            KeyAuthentication.KeyIdentifier.AssertEqual(ConnectionAccount.KeyAuthentication.UDF);

            KeyCollection.Add(KeyEncryption);

            //ContainerCryptoParameters = new CryptoParameters(keyCollection: KeyCollection, recipient: KeyEncryption);
            ContainerCryptoParameters = new CryptoParameters(keyCollection: KeyCollection);
            }

        #endregion
        #region // Methods managing devices, services and applications

        /// <summary>
        /// Add a device to the device catalog.
        /// </summary>
        /// <param name="catalogedDevice">The device to add.</param>
        public void AddDevice(CatalogedDevice catalogedDevice) {
            var catalog = GetCatalogDevice();
            var transaction = new TransactionServiced(catalog, MeshClient);
            transaction.Update(catalogedDevice);
            transaction.Commit();
            }

        /// <summary>
        /// Add service to the account. A request is issued to the service name corresponding to
        /// <paramref name="accountAddress"/>. If this is successful, the account context is updated to
        /// include the newly created account. If the <paramref name="sync"/> parameter is true,
        /// the client also attempts to synchronize to the service.
        /// </summary>
        /// <param name="accountAddress">The account service identifier.</param>
        /// <param name="sync">If true, the client attempts to synchronize the device to the service.</param>
        public void AddService(
                string accountAddress,
                bool sync = true) {
            // Add to assertion
            ProfileAccount.AccountAddresses = ProfileAccount.AccountAddresses ?? new List<string>();
            ProfileAccount.AccountAddresses.Add(accountAddress);
            ContextMeshAdmin.Sign(ProfileAccount);
            this.AccountAddress = accountAddress;

            var createRequest = new CreateRequest() {
                AccountAddress = accountAddress,
                SignedAssertionAccount = ProfileAccount.DareEnvelope,
                SignedProfileMesh = ContextMesh.ProfileMesh.DareEnvelope
                };

            // Attempt to register with service in question
            MeshClient.CreateAccount(createRequest, MeshClient.JpcSession);

            // Generate a contact and self-sign
            var contact = CreateDefaultContact();
            SetContactSelf(contact);


            // Update all the devices connected to this profile.
            UpdateDevices(ProfileAccount);

            if (sync) {
                GetCatalogApplication();
                GetCatalogContact();
                GetCatalogDevice();
                GetCatalogCredential();
                GetCatalogBookmark();
                GetCatalogCalendar();
                GetCatalogNetwork();
                SyncProgressUpload();
                }

            }

        /// <summary>
        /// Update all the devices connected to the account to incorporate values from
        /// <paramref name="account"/>.
        /// </summary>
        /// <param name="account">The modified account profile.</param>
        void UpdateDevices(ProfileAccount account) {
            var catalog = GetCatalogDevice();

            var updates = new List<CatalogedDevice>();
            foreach (var device in catalog.AsCatalogEntryDevice) {
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
            ContextMesh.UpdateDevice();
            }

        /// <summary>
        /// Add a device to the account and the underlying Mesh.
        /// </summary>
        /// <param name="profileDevice">Profile of the device to add.</param>
        /// <returns>The catalog entry.</returns>
        public CatalogedDevice AddDevice(ProfileDevice profileDevice) {
            var device = ContextMeshAdmin.CreateCataloguedDevice(profileDevice);

            // Connect the device to the Account
            ProfileAccount.ConnectDevice(KeyCollection, device, null);


            //Console.WriteLine(device.ToString());


            // Update the local and remote catalog.
            AddDevice(device);

            return device;
            }


        /// <summary>
        /// Get the default (i.e. minimum contact info). This has a single network 
        /// address entry for this mesh and mesh account. 
        /// </summary>
        /// <returns>The default contact.</returns>
        public override Contact CreateDefaultContact(bool meshUDF = false) {

            var address = new NetworkAddress(AccountAddress, ProfileAccount);

            var anchorAccount = new Anchor() {
                UDF = ProfileAccount.UDF,
                Validation = "Self"
                };
            // ContextMesh.ProfileMesh.UDF 

            var contact = new ContactPerson() {
                Anchors = new List<Anchor>() { anchorAccount },
                NetworkAddresses = new List<NetworkAddress>() { address }
                };

            if (meshUDF) {
                var anchorMesh = new Anchor() {
                    UDF = ContextMesh.ProfileMesh.UDF,
                    Validation = "Self"
                    };
                contact.Anchors.Add(anchorMesh);
                }


            return contact;
            }

        /// <summary>
        /// Create a contact entry for self using the parameters specified in <paramref name="contact"/>.
        /// </summary>
        /// <param name="contact">The contact parameters.</param>
        /// <param name="localname">Short name to apply to the signed contact info</param>
        public CatalogedContact SetContactSelf(Contact contact, string localname = null) {
            ContextMeshAdmin.Sign(contact);

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
        /// Get the primary account address bound to this profile. This is a bit of a hack right
        /// now as the code doesn't really support the 'multiple services per account' model yet.
        /// </summary>
        /// <returns>The account service address.</returns>
        public override string GetAccountAddress() {
            ProfileAccount.AccountAddresses.AssertNotNull();
            (ProfileAccount.AccountAddresses.Count > 0).AssertTrue();

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
            throw new NYI();

            }

        #endregion

        #region // Convenience accessors for catalogs and stores


        //public bool SyncProgress(int maxEnvelopes = -1) => SyncProgressUpload(maxEnvelopes);

        /// <summary>
        /// Synchronize the device to the store in increments of no more than <paramref name="maxEnvelopes"/>
        /// at a time. This should really be changed to something more Async callback friendly. Hours in
        /// a day... ??? Its midnight.
        /// </summary>
        /// <param name="maxEnvelopes">The maximum number of envelopes to return.</param>
        /// <returns>If true, the synchronization has completed.</returns>
        public bool SyncProgressUpload(int maxEnvelopes = -1) {
            bool complete = true;
            var updates = new List<ContainerUpdate>();

            //// Always do the devices first (if we are an admin device)
            //if (SyncStatusDevice != null) {
            //    maxEnvelopes -= AddUpload(updates, SyncStatusDevice, maxEnvelopes);
            //    }

            try {
                // upload all the containers here
                foreach (var store in DictionaryStores) {
                    maxEnvelopes -= AddUpload(updates, store.Value, maxEnvelopes);
                    }
                }
            catch {
                }


            if (updates.Count > 0) {
                var uploadRequest = new UploadRequest() {
                    Updates = updates
                    };
                MeshClient.Upload(uploadRequest);
                }

            return complete;
            }

        int AddUpload(List<ContainerUpdate> containerUpdates, SyncStatus syncStatus, int maxEnvelopes = -1) {

            //Console.WriteLine($"Initial sync of {syncStatus.Store.ContainerName}");

            int uploads = 0;
            if (maxEnvelopes == 0) {
                return 0; // no more room left in this request.
                }


            if (syncStatus.Index <= syncStatus.Store.FrameCount) {
                var container = syncStatus.Store.Container;
                var envelopes = new List<DareEnvelope>();
                var containerUpdate = new ContainerUpdate() {
                    Container = syncStatus.Store.ContainerName,
                    Envelopes = envelopes,
                    Digest = container.Digest
                    // put the digest value here
                    };

                var start = 1 + syncStatus.Index;
                long last = (maxEnvelopes < 0) ? syncStatus.Store.FrameCount :
                    Math.Min((start + maxEnvelopes), syncStatus.Store.FrameCount);

                if (start == 0) {
                    envelopes.Add(container.FrameZero);
                    start++;
                    }


                for (var i = start; i < last; i++) {
                    container.MoveToIndex(i);
                    envelopes.Add(container.ReadDirect());
                    }


                containerUpdates.Add(containerUpdate);
                }


            return uploads;

            }

        #region // Convenience accessors to fetch store contexts

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



        public override CryptoKey GetByAccountEncrypt(string keyId) {

            var key = base.GetByAccountEncrypt(keyId);
            if (key != null) {
                return key;
                }
            return GetCatalogContact().GetByAccountEncrypt(keyId);
            }

        /// <summary>
        /// Attempt to obtain a recipient with identifier <paramref name="keyId"/>.
        /// </summary>
        /// <param name="keyId">The key identifier to match.</param>
        /// <returns>The key pair if found.</returns>
        public override CryptoKey TryMatchRecipient(string keyId) {
            var key = KeyCollection.LocatePrivateKeyPair(keyId);
            if (key != null) {
                return key;
                }


            return GetCatalogContact().TryMatchRecipient(keyId);
            }

        #endregion


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
                    var meshMessage = Message.FromJSON(message.GetBodyReader());
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
            foreach (var message in GetSpoolInbound().Select(1, true)) {
                var contentMeta = message.Header.ContentMeta;


                var meshMessage = Message.FromJSON(message.GetBodyReader());
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


            (var profileGroup, var secretSeed) = ProfileGroup.Generate(
                        MeshMachine, algorithmSign, algorithmEncrypt);

            // here we request creation of the group at the service.

            var createRequest = new CreateGroupRequest() {
                AccountAddress = groupName,
                SignedProfileGroup = profileGroup.DareEnvelope
                };

            var createResponse = MeshClient.CreateGroup(createRequest, MeshClient.JpcSession);
            createResponse.Success().AssertTrue();
          
            var capability = new CapabilityAdministrator() {
                Id = profileGroup.UDF,
                KeyData = new KeyData() {
                    PrivateParameters = secretSeed
                    }
                };

            var envelopedCapability = DareEnvelope.Encode(capability.GetBytes(), encryptionKey: KeyEncryption);

            var catalogedGroup = new CatalogedGroup(profileGroup) {
                EnvelopedCapabilities = new List<DareEnvelope>() { envelopedCapability },
                Key = groupName
                };
            GetCatalogApplication().New(catalogedGroup);


            var contextGroup = ContextGroup.CreateGroup(this, catalogedGroup);

            var contact = contextGroup.CreateDefaultContact();
            // Bug: Should also encrypt the relevant admin key to the admin encryption key.


            var contactCatalog = GetCatalogContact();
            contactCatalog.Add(contact);


            return contextGroup;
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

            // construct the group context
            // We do not attempt to get admin privs here, we will do that if necessary.
            return new ContextGroup(this, entry);


            }



        #endregion

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
                CatalogCapability.Label => new CatalogCapability(StoresDirectory, name, ContainerCryptoParameters, KeyCollection),
                _ => base.MakeStore (name),
                };



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

        DareEnvelope ClaimPublication(string uri, out string responseId) {
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


        #region // Processing


        // Tuesday - work out mechanism to dump out the message spool and check it!

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
                        results.Add(ProcessAutomatic(replyContact));
                        break;
                        }
                    }
                }

            return results;
            }


        /// <summary>
        /// Perform automatic processing of the message <paramref name="replyContact"/>.
        /// </summary>
        /// <param name="replyContact">Reply to contact request to be processed.</param>
        /// <param name="accept">Accept the requested action.</param>
        /// <param name="authorize">If true, the action is explicitly authorized.</param>
        /// <returns>The result of requesting the connection.</returns>
        public IProcessResult ProcessAutomatic(ReplyContact replyContact, bool accept=true,
                        bool authorize = false) {

            // check response pin here 
            var messagePIN = GetMessagePIN(replyContact.PinUDF);
            var pinWitness = MessagePIN.GetPinWitness(messagePIN.SaltedPIN, AccountAddress,
                        replyContact.Self, replyContact.Nonce);

            if (!pinWitness.IsEqualTo(replyContact.Witness)) {
                "Should collect up errors for optional reporting".TaskValidate();
                return InvalidPIN();
                }
            if (!(messagePIN.Automatic| authorize)) {
                return null;
                }

            if (accept) {
                GetCatalogContact().Add(replyContact.Self);
                }

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
            var messagePIN = GetMessagePIN(messageConnectionRequest.PinUDF);

            var pinWitness = MessagePIN.GetPinWitness(messagePIN.SaltedPIN, AccountAddress,
                messageConnectionRequest.ProfileDevice.UDF, messageConnectionRequest.ClientNonce);

            if (!pinWitness.IsEqualTo(messageConnectionRequest.PinWitness)) {
                "Should collect up errors for optional reporting".TaskValidate();
                return InvalidPIN();
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


        IProcessResult InvalidPIN() => throw new NYI();


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
            found.AssertTrue(String: "No message of that ID");

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
                Self = contactSelf,
                Nonce = nonce,
                Witness = witness,
                PinUDF =pinUdf
                };

            // send it to the service
            SendMessage(message, recipient);

            return message;
            }

        #endregion


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
            publishResponse.Success().AssertTrue();

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
            var pin = UDF.SymmetricKey ();

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

            var envelope = ClaimPublication(uri, out var responseId);

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

        }

    }
