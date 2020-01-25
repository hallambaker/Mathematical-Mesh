using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Utilities;

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

        public SyncStatus(Store store) {
            Store = store;
            Index = -1;
            Digest = null;
            }
        }


    public interface IDare {




        }




    public class ContextAccount : ContextAccountEntry {

        ///<summary>The enclosing machine context.</summary>
        public ContextMesh ContextMesh;


        public MeshHost MeshHost => MeshMachine.MeshHost;

        ContextMeshAdmin ContextMeshAdmin => ContextMesh as ContextMeshAdmin;

        public AccountEntry AccountEntry { get; private set; }


        ///<summary>The account activation</summary>
        public ActivationAccount ActivationAccount => 
                AccountEntry.GetActivationAccount(KeyCollection);


        public ProfileAccount ProfileAccount => AccountEntry.ProfileAccount;

        ConnectionAccount ConnectionAccount => AccountEntry.ConnectionAccount;


        ///<summary>The Machine context.</summary>
        IMeshMachineClient MeshMachine => ContextMesh.MeshMachine;
        KeyCollection KeyCollection => MeshMachine.KeyCollection;

        ///<summary>The cryptographic parameters for reading/writing to account containers</summary>
        CryptoParameters containerCryptoParameters;


        public string KeySignatureUDF => keySignature.UDF;
        public string KeyEncryptionUDF => keyEncryption.UDF;
        public string KeyAuthenticationUDF => KeyAuthentication.UDF;



        KeyPair KeyAuthentication { get; set; }

        public MeshService MeshClient => meshClient ?? GetMeshClient(ServiceID).CacheValue(out meshClient);
        MeshService meshClient;


        public string ServiceID { get; private set; }


        ///<summary>The directory containing the catalogs related to the account.</summary>
        public string DirectoryAccount => directoryAccount ??
            Path.Combine(MeshMachine.DirectoryMesh, ActivationAccount.AccountUDF).CacheValue(out directoryAccount);
        string directoryAccount;

        Dictionary<string, SyncStatus> dictionaryStores = new Dictionary<string, SyncStatus>();


        protected override void Disposing() => spoolInbound?.Dispose();





        public ContextAccount(
                    ContextMesh contextMesh,
                    AccountEntry accountEntry,
                    string serviceID = null
                    ) {
            // Set up the basic context
            ContextMesh = contextMesh;
            AccountEntry = accountEntry;
            ServiceID = serviceID ?? AccountEntry.ProfileAccount?.ServiceDefault;

            // Set up the crypto keys so that we can open the application catalog

            keySignature = ActivationAccount.KeySignature.GetPrivate(MeshMachine);

            keyEncryption = ActivationAccount.KeyEncryption.GetPrivate(MeshMachine);
            KeyAuthentication = ActivationAccount.KeyAuthentication.GetPrivate(MeshMachine);
            KeyCollection.Add(keyEncryption);

            //ContainerCryptoParameters = new CryptoParameters(keyCollection: KeyCollection, recipient: KeyEncryption);
            containerCryptoParameters = new CryptoParameters(keyCollection: KeyCollection);
            }


        protected MeshService GetMeshClient(string serviceID) =>
                    MeshMachine.GetMeshClient(serviceID, KeyAuthentication,
                ConnectionAccount, ContextMesh.ProfileMesh);

        /// <summary>
        /// Add a device to the device catalog.
        /// </summary>
        /// <param name="catalogedDevice"></param>
        public void AddDevice(CatalogedDevice catalogedDevice) {
            var catalog = GetCatalogDevice();
            var transaction = new TransactionServiced(catalog, MeshClient);
            transaction.Update(catalogedDevice);
            transaction.Commit();



            //GetCatalogDevice().Update(catalogedDevice);
            }

        /// <summary>
        /// Add service to the 
        /// </summary>
        /// <param name="serviceID"></param>
        /// <param name="sync"></param>
        public void AddService(
                string serviceID,
                bool sync = true) {
            // Add to assertion
            ProfileAccount.ServiceIDs = ProfileAccount.ServiceIDs ?? new List<string>();
            ProfileAccount.ServiceIDs.Add(serviceID);
            ContextMeshAdmin.Sign(ProfileAccount);
            ServiceID = serviceID;

            var createRequest = new CreateRequest() {
                ServiceID = serviceID,
                SignedAssertionAccount = ProfileAccount.DareEnvelope,
                SignedProfileMesh = ContextMesh.ProfileMesh.DareEnvelope
                };

            // Attempt to register with service in question
            MeshClient.CreateAccount(createRequest, MeshClient.JpcSession);

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
                if (device.UDF == ContextMesh.CatalogedDevice.UDF) {
                    ContextMesh.UpdateDevice(device);
                    }
                }

            }


        public void SetContactSelf(Contact contact) {
            ContextMeshAdmin.Sign(contact);
            GetCatalogContact().Add(contact, true);
            }


        #region // Convenience accessors for catalogs and stores

        ///<summary>Dictionary used to cache stores to avoid need to re-open them repeatedly.</summary>

        public bool SyncProgress(int maxEnvelopes = -1) => SyncProgressUpload(maxEnvelopes);


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



        public List<string> Stores = new List<string> {
            Spool.SpoolOutbound,
            Spool.SpoolInbound,
            Spool.SpoolLocal,
            Spool.SpoolArchive,
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
        public Spool GetSpoolInbound() => spoolInbound ?? (GetStore(Spool.SpoolInbound) as Spool).CacheValue(out spoolInbound);
        Spool spoolInbound;


        ///<summary>Returns the outbound spool catalog for the account</summary>
        public Spool GetSpoolOutbound() => GetStore(Spool.SpoolOutbound) as Spool;

        ///<summary>Returns the outbound spool catalog for the account</summary>
        public Spool GetSpoolLocal() => spoolLocal ?? (GetStore(Spool.SpoolLocal) as Spool).CacheValue(out spoolLocal);
        Spool spoolLocal;

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
        /// Search the inbound spool and 
        /// </summary>
        /// <param name="spoolInbound"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public Message GetPendingMessage(string tag) {
            var completed = new Dictionary<string, Message>();

            foreach (var message in GetSpoolInbound().Select(1, true)) {
                var contentMeta = message.Header.ContentMeta;

                if (!completed.ContainsKey(contentMeta.UniqueID)) {
                    var meshMessage = Message.FromJSON(message.GetBodyReader());
                    Console.WriteLine($"Message {contentMeta?.MessageType} ID {meshMessage.MessageID}");
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
                        }
                    }
                }
            return null;
            }


        public Message GetPendingMessageByID (string messageID, out bool found) {
            foreach (var message in GetSpoolInbound().Select(1, true)) {
                var contentMeta = message.Header.ContentMeta;


                var meshMessage = Message.FromJSON(message.GetBodyReader());
                Console.WriteLine($"Message {contentMeta?.MessageType} ID {meshMessage.MessageID}");
                
                if (meshMessage.MessageID == messageID) {
                    found = true;
                    return meshMessage;
                    }
                switch (meshMessage) {
                    case MessageComplete meshMessageComplete: {
                        foreach (var reference in meshMessageComplete.References) {
                            if (reference.MessageID == messageID) {
                                found = true;
                                return null;
                                }
                            }
                        break;
                        }
                    }

                }

            found = false;
            return null;
            }


        #endregion

        public void InitializeStores(StatusResponse statusResponse) {
            Directory.CreateDirectory(DirectoryAccount);
            Sync();
            }

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
                Console.WriteLine($"Container {statusRemote.Container}   Local {storeLocal.FrameCount} Remote {statusRemote.Index}");
                return storeLocal.FrameCount >= statusRemote.Index ? null :
                    new ConstraintsSelect() {
                        Container = statusRemote.Container,
                        IndexMax = statusRemote.Index,
                        IndexMin = (int)storeLocal.FrameCount

                        };
                }
            }

        public int UpdateStore(ContainerUpdate containerUpdate) {
            int count = 0;
            if (dictionaryStores.TryGetValue(containerUpdate.Container, out var syncStore)) {
                var store = syncStore.Store;
                foreach (var entry in containerUpdate.Envelopes) {
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
                Spool.SpoolInbound => new Spool(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                Spool.SpoolOutbound => new Spool(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                Spool.SpoolLocal => new Spool(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                Spool.SpoolArchive => new Spool(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                CatalogCredential.Label => new CatalogCredential(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                CatalogContact.Label => new CatalogContact(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                CatalogCalendar.Label => new CatalogCalendar(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                CatalogBookmark.Label => new CatalogBookmark(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                CatalogNetwork.Label => new CatalogNetwork(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                CatalogApplication.Label => new CatalogApplication(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                CatalogDevice.Label => new CatalogDevice(DirectoryAccount, name, containerCryptoParameters, KeyCollection),
                _ => throw new NYI(),
                };

        public bool Transact(Catalog catalog, List<CatalogUpdate> updates) {

            if (ServiceID == null) {
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


            catalog.Commit(envelopes);


            return true;
            }



        public MessagePIN GetPIN(int length = 80, int validity = 24 * 60) {
            var pin = UDF.Nonce(length);
            var expires = DateTime.Now.AddMinutes(validity);
            var messageConnectionPIN = new MessagePIN() {
                Account = ActivationAccount.AccountUDF,
                Expires = expires,
                PIN = pin,
                MessageID = UDF.Nonce()
                };

            SendMessageAdmin(messageConnectionPIN);

            return messageConnectionPIN;
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


            // TBS: If we have synchronized the catalogs, upload cached offline updates here.

            return count;
            }

        public StatusResponse Status() {
            var statusRequest = new StatusRequest() {
                };
            return MeshClient.Status(statusRequest);
            }



        /// <summary>
        /// Accept a connection request.
        /// </summary>
        /// <param name="request">The request to accept.</param>
        IProcessResult Process(AcknowledgeConnection request, bool accept = true) {
            var messageID = request.GetResponseID();
            var respondConnection = new RespondConnection() {
                MessageID = messageID
                };

            if (accept) {
                // Connect the device to the Mesh
                var device = ContextMeshAdmin.CreateCataloguedDevice(
                                request.MessageConnectionRequest.ProfileDevice);

                // Connect the device to the Account
                ProfileAccount.ConnectDevice(MeshMachine, device, null);
                
                
                Console.WriteLine(device.ToString());


                // Update the local and remote catalog.
                AddDevice(device);


                respondConnection.CatalogedDevice = device;
                respondConnection.Result = Constants.TransactionResultAccept;
                }
            else {
                respondConnection.Result = Constants.TransactionResultReject;
                }

            Console.WriteLine($"Accept connection ID is {messageID}");

            SendMessage(respondConnection, uniqueID: messageID);

            return respondConnection;
            }

        //-------------------------------

        public void Download(long maxItems = -1) {
            }


        public IProcessResult Process(Message meshMessage, bool accept = true, bool respond = true) {

            switch (meshMessage) {
                case AcknowledgeConnection connection: {
                    return Process(connection, accept) ;
                    }
                case ReplyContact replyContact: {
                    break;
                    }
                case RequestContact requestContact: {
                    ContactReply(requestContact.Sender);
                    break;
                    }

                case RequestConfirmation requestConfirmation: {
                    ConfirmationResponse(requestConfirmation, true);


                    break;
                    }
                case ResponseConfirmation responseConfirmation: {
                    break;
                    }
                case RequestTask requestTask: {
                    break;
                    }
                case OfferGroup offerGroup: {
                    break;
                    }

                default: throw new NYI();
                }


            return null;
            }

        public void ContactReply(string serviceID) {
            // prepare the contact request

            var message = new ReplyContact() {
                Recipient = serviceID,
                Subject = serviceID
                };

            SendMessage(message, serviceID);

            // send it to the service




            }

        public void ContactRequest(string serviceID) {
            // prepare the contact request

            var message = new RequestContact() {
                Recipient = serviceID,
                Subject = serviceID
                };

            SendMessage(message, serviceID);

            // send it to the service




            }



        public void ConfirmationRequest(string serviceID, string messageText) {
            // prepare the contact request

            var message = new RequestConfirmation() {
                Recipient = serviceID,
                Text = messageText
                };

            SendMessage(message, serviceID);

            // send it to the service

            }
        public void ConfirmationResponse(RequestConfirmation requestConfirmation, bool response) {
            // prepare the contact request

            var recipient = requestConfirmation.Sender;

            var message = new ResponseConfirmation() {
                Recipient = recipient,
                Accept = response,
                Request = requestConfirmation
                };

            SendMessage(message, recipient);

            // send it to the service

            }


        void Connect() {
            if (MeshClient != null) {
                return;
                }

            ProfileAccount.ServiceIDs.AssertNotNull();
            (ProfileAccount.ServiceIDs.Count > 0).AssertTrue();

            ServiceID = ProfileAccount.ServiceIDs[0];

            meshClient = GetMeshClient(ServiceID);
            }

        public void SendMessage(Message MeshMessage, string recipient) =>
            SendMessage(MeshMessage, new List<string> { recipient });


        /// <summary>
        /// Post the message <paramref name="MeshMessage"/> to the service. If <paramref name="recipients"/>
        /// is not null, the message is to be posted to the outbound spool to be forwarded to the
        /// appropriate Mesh Service. Otherwise, the message is posted to the local spool for local
        /// collection.
        /// </summary>
        /// <param name="MeshMessage">The message to post</param>
        /// <param name="recipients">The recipients the message is to be sent to. If null, the
        /// message is for local pickup.</param>
        /// <param name="uniqueID">The unique message ID.</param>
        public void SendMessage(
                    Message MeshMessage, 
                    List<string> recipients=null,
                    string uniqueID=null) {
            Connect();

            MeshMessage.Sender = ServiceID;
            uniqueID ??= UDF.Nonce();

            var message = DareEnvelope.Encode(MeshMessage.GetBytes());
            message.Header.ContentMeta = new ContentMeta() {
                UniqueID = uniqueID,
                MessageType = MeshMessage._Tag

                };
            var postRequest = new PostRequest() {
                Accounts = recipients,
                Message = new List<DareEnvelope>() { message }
                };


            MeshClient.Post(postRequest);
            }

        /// <summary>
        /// Send a message signed using the mesh administration key.
        /// </summary>
        /// <param name="MeshMessage"></param>
        public void SendMessageAdmin(Message MeshMessage) {
            Connect();

            var message = DareEnvelope.Encode(MeshMessage.GetBytes());
            message.Header.ContentMeta = new ContentMeta() {
                UniqueID = UDF.Nonce(),
                MessageType = MeshMessage._Tag

                };



            var postRequest = new PostRequest() {
                Self = new List<DareEnvelope>() { message }
                };


            MeshClient.Post(postRequest);
            }



        public ContextGroup CreateGroup(string groupName,
                    CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                    CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default) {

            // create the group keys

            // 

            var profileGroup = ProfileGroup.Generate(MeshMachine, algorithmSign, algorithmEncrypt);

            var catalogedGroup = new CatalogedGroup(profileGroup);


            return new ContextGroup(catalogedGroup);

            }

        public ContextGroup GetContextGroup(string groupName) => throw new NYI();
        }

    }
