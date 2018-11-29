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
            var response = MeshService.Hello(request);

            return new MeshResult() { MeshResponse = response };
            }

        /// <summary>
        /// Request connection to a Mesh service account from a device.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public MeshResultConnect RequestConnect(string account) {
            AccountName = account;

            // get the account profile
            MeshService = Machine.GetMeshClient(account);

            var messageConnectionRequest = new MessageConnectionRequest() {
                Recipient = account,
                DeviceProfile = ProfileDeviceSigned
                };

            var signedMessage = Sign(messageConnectionRequest);


            // generate the connection request 
            var connectRequest = new ConnectRequest() {
                SignedMessage = signedMessage
                };

            var connectResponse = MeshService.Connect(connectRequest);

            string deviceWitness = null;

            if (connectResponse.Success()) {
                var deviceUDF = ProfileDevice.UDFBytes;
                deviceWitness = UDF.MakeWitnessString(deviceUDF, connectResponse.ProfileConnect.ProfileWitness);
                Machine.Register(connectResponse.ProfileConnect);
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
        /// <param name="account"></param>
        /// <returns></returns>
        public MeshResult Status(string account = null) {


            account = account ?? AccountName;
            AccountName = account;

            var statusRequest = new StatusRequest() {
                Account = AccountName
                };

            var result = MeshService.Status(statusRequest);
            return new MeshResult() { MeshResponse = result };
            }


        public MeshResult ContactRequest(string recipient, DareMessage signedContact) {

            var messageContactRequest = new MessageContactRequest() {
                Recipient = recipient,
                Contact = signedContact
                };

            return Post(recipient, messageContactRequest);
            }

        public MeshResult ConfirmationRequest(string recipient, string text) {

            var messageConfirmationRequest = new MessageConfirmationRequest() {
                Recipient = recipient,
                Text = text
                };

            return Post(recipient, messageConfirmationRequest);
            }

        public MeshResult ConfirmationResponse(string recipient, bool accept) {

            var messageConfirmationResponse = new MessageConfirmationResponse() {
                Recipient = recipient,
                Accept = accept
                };

            return Post(recipient, messageConfirmationResponse);
            }



        MeshResult Post(string recipient, MeshMessage meshMessage) {

            var DareMessage = Sign(meshMessage); // need to add in the recipient here

            var postRequest = new PostRequest() {
                Message = new List<DareMessage> { DareMessage }
                };

            var response = MeshService.Post(postRequest);

            return new MeshResult() { MeshResponse = response };
            }

        public MeshResult Sync() => throw new NYI();

        public MeshResult Add(Catalog catalog, CatalogEntry catalogEntry) {


            var message = catalog.ContainerEntry(catalogEntry, ContainerPersistenceStore.EventNew);
            var messages = new List<DareMessage>() { message };

            var uploadRequest = new UploadRequest() {
                Account = AccountName,
                Message = messages,
                Container = catalog.ContainerDefault
                };
            // Get the account client

            var response = MeshService.Upload(uploadRequest);

            Assert.False(response.Error()); // check that we could do the upload.

            catalog.Apply(message);

            return new MeshResult() { MeshResponse = response };
            }

        public MeshResult Add(Catalog catalog, List<CatalogEntry> catalogEntry) {
            throw new NYI();
            }

        }
    }
