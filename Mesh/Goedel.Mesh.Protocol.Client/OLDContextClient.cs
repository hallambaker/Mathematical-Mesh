﻿//using System;
//using System.Collections.Generic;
//using System.Text;
//using Goedel.Mesh;
//using Goedel.Protocol;
//using Goedel.Utilities;
//using Goedel.Cryptography;
//using Goedel.Cryptography.Dare;
//namespace Goedel.Mesh.Client {

//    /// <summary>
//    /// 
//    /// </summary>
//    public enum ConnectionState {
//        ///<summary>The device is not currently connected.</summary>
//        None,
//        ///<summary>A connection request is currently pending.</summary>
//        Pending,
//        ///<summary>The device is connected.</summary>
//        Connected
//        }

//    /*
//     * 
//     * Currently, only the device initiated connection request is implemented. The account to 
//     * which the device is to be connected is entered into the device which initiates a connection
//     * to the service managing the account and requests 
//     * 
//     * We also need a mode in which the device has a resolvable URL/UDF that maps 
//     * to a description of how to connect to the device. i.e. a JSON file specifying
//     * the manufacturer keys for connecting to it, a device serial number and the hailing
//     * mechanisms it supports. For example, a WiFi SSID that it will listen out for,
//     * DHCP based discovery, etc.
//     */

//    // The client functions associated with the device.
//    public partial class ContextDevice {


//        /// <summary>
//        /// Determine the protocol version and options supported by a Mesh service.
//        /// </summary>
//        /// <param name="account">The Mesh account to which the transaction is directed in the form
//        /// &lt;username&gt;@&lt;dnsaddress&gt;. The value &lt;username&gt is required but need not
//        /// exist when the request is made.</param>
//        /// <returns>The result of the request.</returns>
//        public MeshResult Hello(string account = null) {

//            account = account ?? AccountName;
//            MeshService = MeshMachine.GetMeshClient(account);
//            var request = new HelloRequest();
//            var response = MeshService.Hello(request, MeshClientSession);

//            return new MeshResult() { MeshResponse = response };
//            }

//        /// <summary>
//        /// Request connection to a Mesh service account from a device. 
//        /// </summary>
//        /// <param name="account">The account the user is requesting a connection to.</param>
//        /// <returns>Transaction status information</returns>
//        public MeshResultConnect RequestConnect(string account, string PIN=null) {
//            // get the account profile
//            var meshClientSession = new MeshClientSession(this);
//            MeshService = MeshMachine.GetMeshClient(account);

//            var clientNonce = CryptoCatalog.GetBits(128);
//            var PinID = UDF.PIN2PinID(PIN);

//            // generate the connection request 
//            var connectRequest = new ConnectRequest() {
//                Account = account,
//                ClientNonce = clientNonce,
//                DeviceProfile = ProfileDevice.DareEnvelope,
//                PinID = PinID
//                };



//            var connectResponse = MeshService.Connect(connectRequest, MeshClientSession);

//            string deviceWitness = null;
//            connectResponse.Success().AssertTrue();

//            var deviceUDF = ProfileDevice.UDFBytes;
//            deviceWitness = connectResponse.Witness;

//            AssertionAccount = AssertionAccount.Decode(connectResponse.ProfileMesh);

//            var witness = UDF.MakeWitness(
//                    AssertionAccount.UDFBytes, connectResponse.ServerNonce,
//                    ProfileDevice.UDFBytes, clientNonce);

//            UDF.Matches(deviceWitness, witness).AssertTrue();


//            // if successful save the connection response for later use.
//            MeshMachine.Register(connectResponse.ProfileMesh);


//            // No, instread create a variable for the device state.
//            // the witness value is used in the connect pending state.
//            return new MeshResultConnect() {
//                MeshResponse = connectResponse,
//                Witness = deviceWitness
//                };

//            }


//        public CatalogEntryDevice MakeCatalogEntryDevice(ProfileDevice profileDevice) {

//            var profileMeshDevicePublic = new AssertionDeviceConnection() {
//                //DeviceProfile = profileDevice.DareEnvelope
//                };

//            var ProfileMeshDevicePrivate = new AssertionDevicePrivate() {
//                };

//            var catalogEntryDevice = new CatalogEntryDevice() {
//                Accounts = new List<string> { AccountName },
//                UDF = profileDevice.UDF,
//                AuthUDF = profileDevice.KeyAuthentication.UDF,
//                SignedDeviceConnection = Sign(profileMeshDevicePublic),
//                EncryptedDevicePrivate = Sign(ProfileMeshDevicePrivate)
//                };


//            return catalogEntryDevice;
//            }


//        /// <summary>
//        /// Request the status of an account 
//        /// </summary>
//        /// <param name="account">The account for which status is requested.</param>
//        /// <returns>The status of the request.</returns>
//        public MeshResult Status() {
//            MeshService = MeshService ?? MeshMachine.GetMeshClient(AccountName);
//            var statusRequest = new StatusRequest() {
//                Account = AccountName
//                };

//            var result = MeshService.Status(statusRequest, MeshClientSession);

//            if (result.CatalogEntryDevice != null) {
//                // Register the CatalogEntryDevice if updated.
//                MeshMachine.Register(result.CatalogEntryDevice);
//                }

//            return new MeshResult() { MeshResponse = result };
//            }


//        /// <summary>
//        /// Post a contact request message
//        /// </summary>
//        /// <param name="recipient">The intended recipient.</param>
//        /// <param name="signedContact">The sender's contact information.</param>
//        /// <returns>Transaction status information</returns>
//        public MeshResult ContactRequest(string recipient, DareEnvelope signedContact) {
//            MeshService = MeshService ?? MeshMachine.GetMeshClient(AccountName);
//            var messageContactRequest = new MessageContactRequest() {

//                Recipient = recipient,
//                Contact = signedContact
//                };



//            return Post(recipient, messageContactRequest);
//            }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="recipient">The intended recipient.</param>
//        /// <param name="text"></param>
//        /// <returns>Transaction status information</returns>
//        public MeshResult ConfirmationRequest(string recipient, string text) {

//            var messageConfirmationRequest = new MessageConfirmationRequest() {
//                Recipient = recipient,
//                Sender = AccountName,
//                Text = text
//                };

//            return Post(recipient, messageConfirmationRequest);
//            }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="recipient">The intended recipient.</param>
//        /// <param name="accept"></param>
//        /// <returns>Transaction status information</returns>
//        public MeshResult ConfirmationResponse(
//            MessageConfirmationRequest messageConfirmationRequest, 
//            bool accept) {

//            var recipient = messageConfirmationRequest.Sender;

//            var messageID = UDF.Nonce(200);

//            var messageConfirmationResponse = new MessageConfirmationResponse() {
//                MessageID = messageID,
//                Recipient = recipient,
//                ResponseID = messageConfirmationRequest.MessageID,
//                Accept = accept
//                };

//            var completion = new MeshMessageComplete(messageID, MeshMessageComplete.Accept);

//            return Post(recipient, messageConfirmationResponse);
//            }


//        /// <summary>
//        /// Post a message to a mesh service
//        /// </summary>
//        /// <param name="recipient">The intended recipient.</param>
//        /// <param name="meshMessage"></param>
//        /// <returns>Transaction status information</returns>
//        public MeshResult Post(string recipient, MeshMessage meshMessage,
//                    MeshMessageComplete meshMessageSelf=null) {
//            meshMessage.MessageID = meshMessage.MessageID ?? UDF.Nonce(200);

//            var DareEnvelope = Sign(meshMessage); // need to add in the recipient here
            
//            var postRequest = new PostRequest() {
//                Message = new List<DareEnvelope> { DareEnvelope },
//                Accounts = new List<string> { recipient }
//                };

//            if (meshMessageSelf != null) {
//                postRequest.Self = Sign(meshMessageSelf);
//                }

//            var response = MeshService.Post(postRequest, MeshClientSession);

//            return new MeshResult() { MeshResponse = response };
//            }

//        /// <summary>
//        /// Synchroniza a local catalog store with the one held remotely.
//        /// </summary>
//        /// <returns>Transaction status information</returns>
//        public MeshResult Sync() {

//            var meshResult = Status();

//            if (meshResult.Error) {
//                return meshResult;
//                }

//            var statusResponse = meshResult.MeshResponse as StatusResponse;

//            List<ConstraintsSelect> select = null;



//            foreach (var containerStatus in statusResponse.ContainerStatus) {
//                var store = GetStore(containerStatus.Container) ;
//                if (store.FrameCount < containerStatus.Index) {
//                    select = select ?? new List<ConstraintsSelect>();
//                    var constraintsSelect = new ConstraintsSelect() {
//                        Container = containerStatus.Container,
//                        IndexMin = (int)store.FrameCount
//                        };
//                    select.Add(constraintsSelect);
//                    }

//                }

//            if (select == null) {
//                return meshResult;
//                }

//            var downloadRequest = new DownloadRequest() {
//                Select = select,
//                Account = AccountName
//                };

//            var downloadResponse = MeshService.Download(downloadRequest, MeshClientSession);


//            foreach (var Update in downloadResponse.Updates) {
//                var store = GetStore(Update.Container);
//                foreach (var message in Update.Message) {
//                    // Hack: Should have checks here to make sure this is what we asked for and robust, etc.
//                    store.AppendDirect(message);
//                    }
//                }
//            if (IsAdministrator) {
//                ProcessConnectionRequests();
//                }

//            return meshResult;

//            }


//        void ProcessConnectionRequests() {

//            var completed = new Dictionary<string, MeshMessage>();
//            var pending = new Dictionary<string, MessageConnectionRequest>();

//            foreach (var message in SpoolInbound.Select(1, true)) {
//                var meshMessage = MeshMessage.FromJSON(message.GetBodyReader());
//                if (!completed.ContainsKey(meshMessage.MessageID)) {
//                    switch (meshMessage) {
//                        case MeshMessageComplete meshMessageComplete: {
//                            foreach (var reference in meshMessageComplete.References) {
//                                completed.Add(reference.MessageID, meshMessageComplete);
//                                }
//                            break;
//                            }
//                        case MessageConnectionRequest messageConnectionRequest: {
//                            if (messageConnectionRequest.PinID != null) {
//                                pending.AddSafe(messageConnectionRequest.PinID, messageConnectionRequest);
//                                }

//                            break;
//                            }
//                        case MessageConnectionPIN messageConnectionPIN: {
//                            var PinID = UDF.PIN2PinID(messageConnectionPIN.PIN);
//                            if (pending.TryGetValue(PinID, out var messageConnectionRequest)) {
//                                ProcessConnectionRequest(messageConnectionRequest, messageConnectionPIN);
//                                }

//                            break;
//                            }
//                        }
//                    }
//                }
//            }





//        /// <summary>
//        /// Add an entry to a catalog at the service and remotely.
//        /// </summary>
//        /// <param name="catalog">The catalog that the entries are to be added to.</param>
//        /// <param name="catalogEntry">The entry to be added.</param>
//        /// <returns>Transaction status information</returns>
//        /// <returns>Transaction status information</returns>
//        public MeshResult Add(Catalog catalog, CatalogEntry catalogEntry) {


//            var message = catalog.ContainerEntry(catalogEntry, ContainerPersistenceStore.EventNew);
//            var messages = new List<DareEnvelope>() { message };

//            var containerUpdate = new ContainerUpdate() {
//                Message = messages,
//                Container = catalog.ContainerDefault
//                };

//            var uploadRequest = new UploadRequest() {
//                Account = AccountName,
//                Updates = new List<ContainerUpdate> { containerUpdate }
//                };
//            // Get the account client

//            UploadResponse response=null;
//            if (MeshService != null) {
//                response = MeshService.Upload(uploadRequest, MeshClientSession);
//                Assert.False(response.Error()); // check that we could do the upload.
//                }

//            catalog.Apply(message);

//            return new MeshResult() { MeshResponse = response };
//            }

//        /// <summary>
//        /// Add a list of entries to a catalog at the service and remotely.
//        /// </summary>
//        /// <param name="catalog">The catalog that the entries are to be added to.</param>
//        /// <param name="catalogEntries">The list of entries to be added.</param>
//        /// <returns>Transaction status information</returns>
//        public MeshResult Add(Catalog catalog, List<CatalogEntry> catalogEntries) => throw new NYI();

//        }
//    }
