using System;
using System.Collections.Generic;
using System.Text;
using Goedel.Mesh;
using Goedel.Protocol;
using Goedel.Utilities;
using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
namespace Goedel.Mesh.Protocol.Client {

    /// <summary>
    /// 
    /// </summary>
    public enum ConnectionState {
        ///<summary>The device is not currently connected.</summary>
        None,
        ///<summary>A connection request is currently pending.</summary>
        Pending,
        ///<summary>The device is connected.</summary>
        Connected
        }

    /*
     * 
     * Currently, only the device initiated connection request is implemented. The account to 
     * which the device is to be connected is entered into the device which initiates a connection
     * to the service managing the account and requests 
     * 
     * We also need a mode in which the device has a resolvable URL/UDF that maps 
     * to a description of how to connect to the device. i.e. a JSON file specifying
     * the manufacturer keys for connecting to it, a device serial number and the hailing
     * mechanisms it supports. For example, a WiFi SSID that it will listen out for,
     * DHCP based discovery, etc.
     */

    // The client functions associated with the device.
    public partial class ContextDevice {


        /// <summary>
        /// Determine the protocol version and options supported by a Mesh service.
        /// </summary>
        /// <param name="account">The Mesh account to which the transaction is directed in the form
        /// &lt;username&gt;@&lt;dnsaddress&gt;. The value &lt;username&gt is required but need not
        /// exist when the request is made.</param>
        /// <returns>The result of the request.</returns>
        public MeshResult Hello(string account = null) {

            account = account ?? AccountName;
            MeshService = Machine.GetMeshClient(account);
            var request = new HelloRequest();
            var response = MeshService.Hello(request, MeshClientSession);

            return new MeshResult() { MeshResponse = response };
            }

        /// <summary>
        /// Request connection to a Mesh service account from a device. 
        /// </summary>
        /// <param name="account">The account the user is requesting a connection to.</param>
        /// <returns>Transaction status information</returns>
        public MeshResultConnect RequestConnect(string account) {
            AccountName = account;

            // get the account profile
            var meshClientSession = new MeshClientSession(this);
            MeshService = Machine.GetMeshClient(account);

            var meshConnectData = new ProfileMesh() {
                Account = account,
                DeviceProfile = ProfileDeviceSigned
                };

            var signedMessage = Sign(meshConnectData);


            // generate the connection request 
            var connectRequest = new ConnectRequest() {
                SignedMessage = signedMessage
                };
            //JSONReader.Trace = true;
            var connectResponse = MeshService.Connect(connectRequest, MeshClientSession);

            string deviceWitness = null;

            if (connectResponse.Success()) {
                var deviceUDF = ProfileDevice.UDFBytes;
                deviceWitness = UDF.MakeWitnessString(deviceUDF,
                    connectResponse.ProfileMesh.ProfileNonce);

                Machine.Register(connectResponse.ProfileMesh);
                }

            // if successful save the connection response for later use.


            // No, instread create a variable for the device state.
            // the witness value is used in the connect pending state.
            return new MeshResultConnect() {
                MeshResponse = connectResponse,
                Witness = deviceWitness
                };

            }

        /// <summary>
        /// Request the status of an account 
        /// </summary>
        /// <param name="account">The account for which status is requested.</param>
        /// <returns>The status of the request.</returns>
        public MeshResult Status(string account = null) {


            account = account ?? AccountName;
            AccountName = account;

            var statusRequest = new StatusRequest() {
                Account = AccountName
                };

            var result = MeshService.Status(statusRequest, MeshClientSession);
            return new MeshResult() { MeshResponse = result };
            }


        /// <summary>
        /// Post a contact request message
        /// </summary>
        /// <param name="recipient">The intended recipient.</param>
        /// <param name="signedContact">The sender's contact information.</param>
        /// <returns>Transaction status information</returns>
        public MeshResult ContactRequest(string recipient, DareMessage signedContact) {

            var messageContactRequest = new MessageContactRequest() {
                Recipient = recipient,
                Contact = signedContact
                };

            return Post(recipient, messageContactRequest);
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipient">The intended recipient.</param>
        /// <param name="text"></param>
        /// <returns>Transaction status information</returns>
        public MeshResult ConfirmationRequest(string recipient, string text) {

            var messageConfirmationRequest = new MessageConfirmationRequest() {
                Recipient = recipient,
                Sender = AccountName,
                Text = text
                };

            return Post(recipient, messageConfirmationRequest);
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recipient">The intended recipient.</param>
        /// <param name="accept"></param>
        /// <returns>Transaction status information</returns>
        public MeshResult ConfirmationResponse(
            MessageConfirmationRequest messageConfirmationRequest, 
            bool accept) {

            var recipient = messageConfirmationRequest.Sender;

            var messageConfirmationResponse = new MessageConfirmationResponse() {
                Recipient = recipient,
                ResponseID = messageConfirmationRequest.MessageID,
                Accept = accept
                };

            return Post(recipient, messageConfirmationResponse);
            }


        /// <summary>
        /// Post a message to a mesh service
        /// </summary>
        /// <param name="recipient">The intended recipient.</param>
        /// <param name="meshMessage"></param>
        /// <returns>Transaction status information</returns>
        public MeshResult Post(string recipient, MeshMessage meshMessage) {

            var DareMessage = Sign(meshMessage); // need to add in the recipient here

            var postRequest = new PostRequest() {
                Message = new List<DareMessage> { DareMessage },
                Accounts = new List<string> { recipient }
                };

            var response = MeshService.Post(postRequest, MeshClientSession);

            return new MeshResult() { MeshResponse = response };
            }

        /// <summary>
        /// Synchroniza a local catalog store with the one held remotely.
        /// </summary>
        /// <returns>Transaction status information</returns>
        public MeshResult Sync(string account = null) {
            account = account ?? AccountName;
            AccountName = account;

            var meshResult = Status(account);

            if (meshResult.Error) {
                return meshResult;
                }

            var statusResponse = meshResult.MeshResponse as StatusResponse;

            List<ConstraintsSelect> select = null;



            foreach (var containerStatus in statusResponse.ContainerStatus) {
                var store = GetStore(Store.Factory, containerStatus.Container);
                if (store.FrameCount < containerStatus.Index) {
                    select = select ?? new List<ConstraintsSelect>();
                    var constraintsSelect = new ConstraintsSelect() {
                        Container = containerStatus.Container,
                        IndexMin = (int) store.FrameCount
                        };
                    select.Add(constraintsSelect);
                    }
                }

            if (select == null) {
                return meshResult;
                }

            var downloadRequest = new DownloadRequest() {
                Select = select,
                Account = account
                };

            var downloadResponse = MeshService.Download(downloadRequest, MeshClientSession);


            foreach (var Update in downloadResponse.Updates) {
                var store = GetStore(Store.Factory, Update.Container);
                foreach (var message in Update.Message) {
                    // Hack: Should have checks here to make sure this is what we asked for and robust, etc.
                    store.AppendDirect(message);
                    }
                }


            return meshResult;

            }

        void Sync(ContainerStatus containerStatus) {
            var store = GetStore(Store.Factory, containerStatus.Container);
            if (store.FrameCount == containerStatus.Index) {
                return;
                }
            Assert.True(containerStatus.Index > store.FrameCount, NYI.Throw);


            throw new NYI();
            // try to pull the updates here.

            }


        /// <summary>
        /// Add an entry to a catalog at the service and remotely.
        /// </summary>
        /// <param name="catalog">The catalog that the entries are to be added to.</param>
        /// <param name="catalogEntry">The entry to be added.</param>
        /// <returns>Transaction status information</returns>
        /// <returns>Transaction status information</returns>
        public MeshResult Add(Catalog catalog, CatalogEntry catalogEntry) {


            var message = catalog.ContainerEntry(catalogEntry, ContainerPersistenceStore.EventNew);
            var messages = new List<DareMessage>() { message };

            var containerUpdate = new ContainerUpdate() {
                Message = messages,
                Container = catalog.ContainerDefault
                };

            var uploadRequest = new UploadRequest() {
                Account = AccountName,
                Updates = new List<ContainerUpdate> { containerUpdate }
                };
            // Get the account client

            var response = MeshService.Upload(uploadRequest, MeshClientSession);

            Assert.False(response.Error()); // check that we could do the upload.

            catalog.Apply(message);

            return new MeshResult() { MeshResponse = response };
            }

        /// <summary>
        /// Add a list of entries to a catalog at the service and remotely.
        /// </summary>
        /// <param name="catalog">The catalog that the entries are to be added to.</param>
        /// <param name="catalogEntries">The list of entries to be added.</param>
        /// <returns>Transaction status information</returns>
        public MeshResult Add(Catalog catalog, List<CatalogEntry> catalogEntries) => throw new NYI();

        }
    }
