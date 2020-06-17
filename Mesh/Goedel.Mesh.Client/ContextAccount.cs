using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;
using Goedel.Cryptography.Jose;
using Goedel.Mesh;

using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh.Client {

    ///<summary>Track the synchronization status of an upload or download operation.</summary>
    public class SyncStatus {

        ///<summary>The local store</summary>
        public Store Store;

        ///<summary>The last index at the remote store</summary>
        public long Index;

        ///<summary>The apex digest value at the remote store</summary>
        public string Digest;

        /// <summary>
        /// Report the synchronization status of a Mesh store.
        /// </summary>
        /// <param name="store">The store reported on.</param>
        public SyncStatus(Store store) {
            Store = store;
            Index = -1;
            Digest = null;
            }
        }


    /// <summary>
    /// Bound context for a Mesh Account. 
    /// </summary>
    public class ContextAccount : ContextAccountEntry {

        ///<summary>The enclosing mesh context.</summary>
        public ContextMesh ContextMesh;

        ///<summary>The enclosing mesh context as an administrative context (if rights granted.</summary>
        ContextMeshAdmin ContextMeshAdmin => ContextMesh as ContextMeshAdmin;

        ///<summary>The account entry</summary>
        public AccountEntry AccountEntry { get; private set; }


        ///<summary>The account activation</summary>
        public ActivationAccount ActivationAccount =>
                AccountEntry.GetActivationAccount(KeyCollection);

        ///<summary>Convenience accessor for the account profile</summary>
        public ProfileAccount ProfileAccount => AccountEntry.ProfileAccount;

        ///<summary>Convenience accessor for the account connection</summary>
        ConnectionAccount ConnectionAccount => AccountEntry.ConnectionAccount;


        ///<summary>The Machine context.</summary>
        IMeshMachineClient MeshMachine => ContextMesh.MeshMachine;
        KeyCollection KeyCollection => ContextMesh.KeyCollection;

        ///<summary>The cryptographic parameters for reading/writing to account containers</summary>
        CryptoParameters containerCryptoParameters;


        ///<summary>Convenience accessor for the encryption key fingerprint.</summary>
        public string KeyEncryptionUDF => keyEncryption.KeyIdentifier;
        ///<summary>Convenience accessor for the signature key fingerprint.</summary>
        public string KeySignatureUDF => keySignature.KeyIdentifier;
        ///<summary>Convenience accessor for the authentication key fingerprint.</summary>
        public string KeyAuthenticationUDF => KeyAuthentication.KeyIdentifier;


        KeyPair KeyAuthentication { get; set; }

        ///<summary>Returns the MeshClient and caches the result for future use.</summary>
        public MeshService MeshClient => meshClient ?? GetMeshClient(AccountAddress).CacheValue(out meshClient);
        MeshService meshClient;

        ///<summary>The Account Address</summary>
        public string AccountAddress { get; private set; }


        ///<summary>The directory containing the catalogs related to the account.</summary>
        public string DirectoryAccount => directoryAccount ??
            Path.Combine(MeshMachine.DirectoryMesh, ActivationAccount.AccountUDF).CacheValue(out directoryAccount);
        string directoryAccount;

        Dictionary<string, SyncStatus> dictionaryStores = new Dictionary<string, SyncStatus>();


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
                    ) {
            // Set up the basic context
            ContextMesh = contextMesh;
            AccountEntry = accountEntry;
            this.AccountAddress = accountAddress ?? AccountEntry.ProfileAccount?.ServiceDefault;

            var activationKey = ActivationAccount.ActivationKey;
            keySignature = ContextMesh.ActivateKey(activationKey, MeshKeyType.DeviceSign);
            keyEncryption = ContextMesh.ActivateKey(activationKey, MeshKeyType.DeviceEncrypt);
            KeyAuthentication = ContextMesh.ActivateKey(activationKey, MeshKeyType.DeviceAuthenticate);

            keySignature.KeyIdentifier.AssertEqual(ConnectionAccount.KeySignature.UDF);
            keyEncryption.KeyIdentifier.AssertEqual(ConnectionAccount.KeyEncryption.UDF);
            KeyAuthentication.KeyIdentifier.AssertEqual(ConnectionAccount.KeyAuthentication.UDF);

            KeyCollection.Add(keyEncryption);

            //ContainerCryptoParameters = new CryptoParameters(keyCollection: KeyCollection, recipient: KeyEncryption);
            containerCryptoParameters = new CryptoParameters(keyCollection: KeyCollection);
            }

        /// <summary>
        /// Returns a Mesh service client for <paramref name="accountAddress"/>.
        /// </summary>
        /// <param name="accountAddress">The account service identifier.</param>
        /// <returns>The Mesh service client</returns>
        protected MeshService GetMeshClient(string accountAddress) =>
                    MeshMachine.GetMeshClient(accountAddress, KeyAuthentication,
                ConnectionAccount, ContextMesh.ProfileMesh);

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
        /// Get the default (i.e. minimum contact info). This has a single network 
        /// address entry for this mesh and mesh account. 
        /// </summary>
        /// <returns>The default contact.</returns>
        public Contact CreateDefaultContact(bool meshUDF = false) {

            var address = new NetworkAddress() {
                Address = AccountAddress,
                EnvelopedConnectionAccount = AccountEntry.EnvelopedConnectionAccount
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
        public void SetContactSelf(Contact contact, string localname = null) {
            ContextMeshAdmin.Sign(contact);

            contact.Sources ??= new List<TaggedSource>() { };
            var tagged = new TaggedSource() {
                LocalName = localname,
                Validation = "Self",
                EnvelopedSource = contact.DareEnvelope
                };
            contact.Sources.Add(tagged);

            contact.Id = ProfileAccount.UDF;


            GetCatalogContact().Add(contact, true);
            }


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
                foreach (var store in dictionaryStores) {
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


        /// <summary>
        /// List of the known store types.
        /// </summary>
        public List<string> Stores = new List<string> {
            SpoolOutbound.Label,
            SpoolInbound.Label,
            SpoolLocal.Label,
            SpoolArchive.Label,
            CatalogApplication.Label,
            CatalogDevice.Label,
            CatalogContact.Label,
            CatalogCredential.Label,
            CatalogBookmark.Label,
            CatalogCalendar.Label,
            CatalogNetwork.Label
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

        ///<summary>Returns the outbound spool catalog for the account</summary>
        public SpoolOutbound GetSpoolOutbound() => GetStore(SpoolOutbound.Label) as SpoolOutbound;

        ///<summary>Returns the outbound spool catalog for the account</summary>
        public SpoolLocal GetSpoolLocal() => GetStore(SpoolLocal.Label) as SpoolLocal;

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



            groupName.Future();

            var profileGroup = ProfileGroup.Generate(MeshMachine, algorithmSign, algorithmEncrypt);

            var catalogedGroup = new CatalogedGroup(profileGroup);

            return new ContextGroup(catalogedGroup);
            }

        /// <summary>
        /// Get a managment context for the group <paramref name="groupAddress"/>.
        /// </summary>
        /// <param name="groupAddress">The group to return the management context for.</param>
        /// <returns>The created management context.</returns>
        public ContextGroup GetContextGroup(string groupAddress) {
            groupAddress.Future();
            throw new NYI();


            }



        #endregion



        /// <summary>
        /// Return a <see cref="ConstraintsSelect"/> instance that requests synchronization to the
        /// remote store whose status is described by <paramref name="statusRemote"/>.
        /// </summary>
        /// <param name="statusRemote">Status of the remote store.</param>
        /// <returns>The selection constraints.</returns>
        public ConstraintsSelect GetStoreStatus(ContainerStatus statusRemote) {
            if (dictionaryStores.TryGetValue(statusRemote.Container, out var syncStore)) {
                var storeLocal = syncStore.Store;

                return storeLocal.FrameCount >= statusRemote.Index ? null :
                    new ConstraintsSelect() {
                        Container = statusRemote.Container,
                        IndexMax = statusRemote.Index,
                        IndexMin = (int)storeLocal.FrameCount
                        };
                }

            else {
                using var storeLocal = new Store(DirectoryAccount, statusRemote.Container,
                            decrypt: false, create: false);
                //Console.WriteLine($"Container {statusRemote.Container}   Local {storeLocal.FrameCount} Remote {statusRemote.Index}");
                return storeLocal.FrameCount >= statusRemote.Index ? null :
                    new ConstraintsSelect() {
                        Container = statusRemote.Container,
                        IndexMax = statusRemote.Index,
                        IndexMin = (int)storeLocal.FrameCount
                        };
                }
            }

        /// <summary>
        /// Update the store according to the values <paramref name="containerUpdate"/>.
        /// </summary>
        /// <param name="containerUpdate">The update to apply.</param>
        /// <returns>The number of envelopes successfully added.</returns>
        public int UpdateStore(ContainerUpdate containerUpdate) {
            int count = 0;
            if (dictionaryStores.TryGetValue(containerUpdate.Container, out var syncStore)) {
                var store = syncStore.Store;
                foreach (var entry in containerUpdate.Envelopes) {
                    if (entry.Index == 0) {
                        throw new NYI();
                        }

                    count++;
                    store.AppendDirect(entry);
                    }
                return count;
                }

            else {
                // we have zero envelopes being returned in this update.

                Store.Append(DirectoryAccount, containerUpdate.Envelopes, containerUpdate.Container);
                return containerUpdate.Envelopes.Count;
                }

            }

        /// <summary>
        /// Return a <see cref="Store"/> instance for the store named <paramref name="name"/>. If the
        /// parameter <paramref name="blind"/> is true, only the sequence header values are read.
        /// </summary>
        /// <param name="name">The store to open.</param>
        /// <param name="blind">If true, only the sequence header values are read</param>
        /// <returns>The <see cref="Store"/> instance.</returns>
        public Store GetStore(string name, bool blind = false) {
            if (dictionaryStores.TryGetValue(name, out var syncStore)) {
                if (!blind & (syncStore.Store is CatalogBlind)) {
                    // if we have a blind store from a sync operation but need a populated one,
                    // remake it.
                    syncStore.Store.Dispose();
                    syncStore.Store = MakeStore(name);
                    }
                return syncStore.Store;
                }

            //Console.WriteLine($"Open store {name} on {MeshMachine.DirectoryMesh}");

            var store = blind ? new CatalogBlind(DirectoryAccount, name) : MakeStore(name);
            syncStore = new SyncStatus(store);

            dictionaryStores.Add(name, syncStore);
            return syncStore.Store;
            }

        Store MakeStore(string name) => name switch
            {
                SpoolInbound.Label => new SpoolInbound(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                SpoolOutbound.Label => new SpoolOutbound(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                SpoolLocal.Label => new SpoolLocal(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                SpoolArchive.Label => new SpoolArchive(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                CatalogCredential.Label => new CatalogCredential(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                CatalogContact.Label => new CatalogContact(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                CatalogCalendar.Label => new CatalogCalendar(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                CatalogBookmark.Label => new CatalogBookmark(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                CatalogNetwork.Label => new CatalogNetwork(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                CatalogApplication.Label => new CatalogApplication(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                CatalogDevice.Label => new CatalogDevice(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                _ => throw new NYI(),
                };

        /// <summary>
        /// Request a transactional update to <paramref name="catalog"/>. Either all the 
        /// updates specified in <paramref name="updates"/> are committed or none are.
        /// </summary>
        /// <param name="catalog">The catalog to update.</param>
        /// <param name="updates">The updates to apply.</param>
        /// <returns>True if the transaction committed, otherwise false.</returns>
        public bool Transact(Catalog catalog, List<CatalogUpdate> updates) {

            if (AccountAddress == null) {
                return catalog.Transact(catalog, updates);
                }
            var envelopes = catalog.Prepare(updates);

            var containerUpdate = new ContainerUpdate() {
                Container = catalog.ContainerName,
                Index = (int)catalog.Container.FrameCount,
                Envelopes = envelopes
                };



            var uploadRequest = new UploadRequest() {
                Updates = new List<ContainerUpdate> { containerUpdate }
                };

            var uploadResponse = MeshClient.Upload(uploadRequest);
            uploadResponse.Success().AssertTrue();

            catalog.Commit(envelopes);


            return true;
            }


        /// <summary>
        /// Create a PIN value of length <paramref name="length"/> bits valid for 
        /// <paramref name="validity"/> minutes.
        /// </summary>
        /// <param name="length">The size of the PIN value to create in bits.</param>
        /// <param name="validity">The validity interval in minutes from the current 
        /// date and time.</param>
        /// <returns>A <see cref="MessagePIN"/> instance describing the created parameters.</returns>
        public MessagePIN GetPIN(string action,int length = 80, long validity = Constants.DayInTicks) {
            var pin = UDF.SymmetricKey(length);
            var expires = DateTime.Now.AddTicks(validity);

            return RegisterPIN(pin, expires, AccountAddress, action);
            }



        MessagePIN RegisterPIN(string pin, DateTime? expires, string accountAddress, string action) {
            var messageConnectionPIN = new MessagePIN(pin, expires, AccountAddress, action);

            SendMessageAdmin(messageConnectionPIN);
            return messageConnectionPIN;
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


        DareEnvelope ClaimPublication(string uri, out string responseId) {
            (var targetAccountAddress, var pin) = MeshUri.ParseConnectUri(uri);

            var key = new CryptoKeySymmetricSigner(pin);
            var messageClaim = new MessageClaim(targetAccountAddress, AccountAddress, pin);

            var envelopedMessageClaim = messageClaim.Encode(keySignature);

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


        /// <summary>
        /// Synchronize this device to the catalogs at the service. Since the authoritative copy of
        /// the service is held at the service, this means only downloading updates at present.
        /// </summary>
        /// <returns>The number of items synchronized</returns>
        public int Sync() {
            int count = 0;

            var statusRequest = new StatusRequest() {
                };
            var status = MeshClient.Status(statusRequest);

            (status.ContainerStatus == null).AssertFalse();


            var constraintsSelects = new List<ConstraintsSelect>();

            foreach (var container in status.ContainerStatus) {
                var constraintsSelect = GetStoreStatus(container);
                if (constraintsSelect != null) {
                    constraintsSelects.Add(constraintsSelect);
                    }
                }

            if (constraintsSelects.Count == 0) {
                return 0;
                }

            var downloadRequest = new DownloadRequest() {

                Select = constraintsSelects
                };

            // what is it with the ranges here? make sure they are all correct.
            // Then check that the remote versions are correct.

            var download = MeshClient.Download(downloadRequest);

            foreach (var update in download.Updates) {
                count += UpdateStore(update);
                }

            // At this point we want to look at all the pending messages and see if there
            // are any PIN authenticated auto-executing messages.
            // TBS: If we have synchronized the catalogs, upload cached offline updates here.

            return count;
            }


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
        /// <returns>The result of requesting the connection.</returns>
        public IProcessResult ProcessAutomatic(ReplyContact replyContact, bool accept=true) {

            // check response pin here 
            var messagePIN = GetMessagePIN(replyContact.PinUDF);
            var pinWitness = MessagePIN.GetPinWitness(messagePIN.SaltedPIN, AccountAddress,
                        replyContact.Self, replyContact.Nonce);

            if (!pinWitness.IsEqualTo(replyContact.Witness)) {
                "Should collect up errors for optional reporting".TaskValidate();
                return InvalidPIN();
                }


            GetCatalogContact().Add(replyContact.Self);

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


        MessagePIN GetMessagePIN(string PinUDF) {
            var pinCreate = GetSpoolLocal().CheckPIN(PinUDF);

            // check PIN
            if (pinCreate == null || pinCreate.Closed) {
                "Should collect up errors for optional reporting".TaskValidate();
                "Should check on expiry".TaskValidate();
                throw new NYI();
                //return InvalidPIN();
                }

            return pinCreate.Message as MessagePIN;
            }



        IProcessResult InvalidPIN() => throw new NYI();


        /// <summary>
        /// Obtain the status of the remote store.
        /// </summary>
        /// <returns></returns>
        public StatusResponse Status() {
            var statusRequest = new StatusRequest() {
                };
            return MeshClient.Status(statusRequest);
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


        //-------------------------------

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
                    return ProcessAutomatic(replyContact, accept);
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
                case OfferGroup offerGroup: {
                    offerGroup.Future();
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



        IProcessResult SendReplyContact(string recipient, string pin, string localname) {
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

            return null;
            }


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
        public string ContactUriStatic(DateTime? expire, string localName = null) {
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
            var messageConnectionPIN = new MessagePIN(pin, expire, AccountAddress, "Contact");
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

            RegisterPIN(pin, null, AccountAddress, "Contact");

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
        /// <returns>The cataloged contact information.</returns>
        public CatalogedContact ContactExchange(string uri, bool reciprocate, string localname = null) {
            // Fetch, verify and decrypt the corresponding data.
            var envelope = ClaimPublication(uri, out var responseId);

            // Add to the catalog
            var catalog = GetCatalogContact();
            var result = catalog.Add(envelope);

            if (reciprocate) {
                (var targetAccountAddress, var pin) = MeshUri.ParseConnectUri(uri);
                SendReplyContact(targetAccountAddress, pin, localname);
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
                Request = requestConfirmation
                };

            SendMessage(message, recipient);

            // send it to the service
            return null;
            }


        void Connect() {
            if (MeshClient != null) {
                return;
                }

            ProfileAccount.AccountAddresses.AssertNotNull();
            (ProfileAccount.AccountAddresses.Count > 0).AssertTrue();

            AccountAddress = ProfileAccount.AccountAddresses[0];

            meshClient = GetMeshClient(AccountAddress);
            }

        /// <summary>
        /// Send <paramref name="meshMessage"/> to <paramref name="recipient"/>.
        /// </summary>
        /// <param name="meshMessage">The message to send.</param>
        /// <param name="recipient">The recipient service ID.</param>
        public void SendMessage(Message meshMessage, string recipient) =>
            SendMessage(meshMessage, new List<string> { recipient });


        /// <summary>
        /// Post the message <paramref name="meshMessage"/> to the service. If <paramref name="recipients"/>
        /// is not null, the message is to be posted to the outbound spool to be forwarded to the
        /// appropriate Mesh Service. Otherwise, the message is posted to the local spool for local
        /// collection.
        /// </summary>
        /// <param name="meshMessage">The message to post</param>
        /// <param name="recipients">The recipients the message is to be sent to. If null, the
        /// message is for local pickup.</param>
        public void SendMessage(
                    Message meshMessage, 
                    List<string> recipients=null) {
            Connect();

            meshMessage.Sender = AccountAddress;


            var envelope = meshMessage.Encode();

            var postRequest = new PostRequest() {
                Accounts = recipients,
                Message = new List<DareEnvelope>() { envelope }
                };


            MeshClient.Post(postRequest);
            }

        /// <summary>
        /// Send a message signed using the mesh administration key.
        /// </summary>
        /// <param name="meshMessage"></param>
        public void SendMessageAdmin(Message meshMessage) {
            Connect();

            var message = meshMessage.Encode(keySignature);

            var postRequest = new PostRequest() {
                Self = new List<DareEnvelope>() { message }
                };


            MeshClient.Post(postRequest);
            }




        }

    }
