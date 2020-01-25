using Goedel.Cryptography;
using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Protocol;
using Goedel.Utilities;

using System;
using System.Collections.Generic;
using System.Text;

namespace Goedel.Mesh.Client {

    public partial class ContextMesh : Disposable {
        ///<summary>The Machine context.</summary>
        public IMeshMachineClient MeshMachine => MeshHost?.MeshMachine;


        public MeshHost MeshHost { get; }


        ///<summary>The master profile</summary>
        public ProfileMesh ProfileMesh { get; }

        ///<summary>The Device Entry in the CatalogHost</summary>
        public CatalogedMachine CatalogedMachine;

        ///<summary>For a non administrative device, the CatalogEntryDevice is in the 
        ///connection entry;</summary>
        public virtual CatalogedDevice CatalogedDevice => CatalogedMachine?.CatalogedDevice;

        public ConnectionDevice ConnectionDevice =>
            CatalogedDevice.ConnectionDevice;

        public ContextMeshAdmin ContextMeshAdmin => this as ContextMeshAdmin;





        public ContextMesh(MeshHost meshHost, CatalogedMachine deviceConnection) {
            Assert.AssertNotNull(deviceConnection, NYI.Throw);

            MeshHost = meshHost;
            CatalogedMachine = deviceConnection;

            ProfileMesh = ProfileMesh.Decode(CatalogedMachine.EnvelopedProfileMaster);

            }

        // The account activation was not added to activations.

        public ContextAccount GetContextAccount(
                string localName = null,
                string accountName = null) {
            var account = CatalogedDevice.GetAccount(localName, accountName);
            return account == null ? null : new ContextAccount(this, account);
            }


        public void UpdateDevice(CatalogedDevice catalogedDevice) {

            CatalogedMachine.CatalogedDevice = catalogedDevice;
            MeshMachine.MeshHost.Register(CatalogedMachine);
            }

        }


    public class ContextMeshPending : ContextMesh {

        public CatalogedPending PendingConnection => CatalogedMachine as CatalogedPending;
        public AcknowledgeConnection MessageConnectionResponse => PendingConnection?.MessageConnectionResponse;
        public RequestConnection MessageConnectionRequest => MessageConnectionResponse?.MessageConnectionRequest;

        public ProfileDevice ProfileDevice => MessageConnectionRequest?.ProfileDevice;


        KeyPair keyAuthentication;

        public string ServiceID => MessageConnectionRequest?.ServiceID;
        public MeshService MeshClient;

        public ContextMeshPending(MeshHost meshHost, CatalogedMachine deviceConnection) :
                    base(meshHost, deviceConnection) {
            }



        public static ContextMeshPending ConnectService(
                MeshHost meshHost,
            string serviceID,
            string localName = null,
            string PIN = null,
            CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
            CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
            CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {

            var secretSeed = new PrivateKeyUDF (
                    UdfAlgorithmIdentifier.MeshProfileDevice, algorithmEncrypt, algorithmSign,
                    algorithmAuthenticate);

            var profileDevice = new ProfileDevice (meshHost.KeyCollection, secretSeed, true);

            return ConnectService(meshHost, profileDevice, serviceID, localName, PIN);
            }



        public static ContextMeshPending ConnectService(
                MeshHost meshHost,
                ProfileDevice profileDevice,
                string serviceID,
                string localName = null,
                string PIN = null) {

            // generate MessageConnectionRequestClient
            var messageConnectionRequestClient = new RequestConnection() {
                ServiceID = serviceID,
                EnvelopedProfileDevice = profileDevice.DareEnvelope,
                ClientNonce = CryptoCatalog.GetBits(128),
                PinUDF = UDF.PIN2PinID(PIN)
                };



            var keyAuthentication = meshHost.KeyCollection.LocatePrivateKeyPair(
                        profileDevice.KeyAuthentication.UDF);

            var messageConnectionRequestClientEncoded = messageConnectionRequestClient.Encode(keyAuthentication);

            // Acquire ephemeral client. This will only be used for the Connect and Complete methods.
            var meshClient = meshHost.MeshMachine.GetMeshClient(serviceID, keyAuthentication, null);

            var connectRequest = new ConnectRequest() {
                MessageConnectionRequestClient = messageConnectionRequestClientEncoded
                };

            var response = meshClient.Connect(connectRequest);

            // create the pending connection here

            var connection = new CatalogedPending() {
                ID = profileDevice.UDF,
                DeviceUDF = profileDevice.UDF,
                EnvelopedMessageConnectionResponse = response.EnvelopedConnectionResponse,
                EnvelopedProfileMaster = response.EnvelopedProfileMaster,
                EnvelopedProfileDevice = profileDevice.DareEnvelope,
                EnvelopedAccountAssertion = response.EnvelopedAccountAssertion
                };

            meshHost.Register(connection);

            return new ContextMeshPending(meshHost, connection);

            }

        /// <summary>
        /// Complete the pending connection request.
        /// </summary>
        /// <returns>If successfull returns an ContextAccountService instance to allow access
        /// to the connected account. Otherwise, a null value is returned.</returns>
        public ContextAccount Complete() {

            "The catalog contents are not currently encrypted as they should be".TaskFunctionality();

            keyAuthentication ??= MeshMachine.KeyCollection.LocatePrivateKeyPair(
                        ProfileDevice.KeyAuthentication.UDF);

            MeshClient ??= MeshMachine.GetMeshClient(ServiceID, keyAuthentication, null);

            var completeRequest = new CompleteRequest() {
                ResponseID = MessageConnectionResponse.GetResponseID(),
                ServiceID = ServiceID
                };

            var completeResponse = MeshClient.Complete(completeRequest);


            //// OK so here we need to unpack the profile etc.
            var respondConnection = RespondConnection.Decode(
                    completeResponse.SignedResponse, MeshMachine.KeyCollection);

            respondConnection.Validate(ProfileDevice, MeshMachine.KeyCollection);

            var catalogedEntry = respondConnection.CatalogedDevice;
            var activationDevice = catalogedEntry.GetActivationDevice(MeshMachine.KeyCollection);
            var connectionDevice = catalogedEntry.ConnectionDevice;
            var profileMaster = catalogedEntry.ProfileMesh;


            // now create the host catalog entry
            var catalogedStandard = new CatalogedStandard() {
                ID = ProfileDevice.UDF,
                CatalogedDevice = catalogedEntry,
                EnvelopedProfileMaster = profileMaster.DareEnvelope
                };
            MeshMachine.MeshHost.Register(catalogedStandard);

            // create the context mesh
            var contextMesh = new ContextMesh(MeshHost, catalogedStandard);

            // now create the account context for the account we asked to connect to and initialize
            var contextAccount = contextMesh.GetContextAccount(accountName: ServiceID);
            contextAccount.Sync();
                      
            return contextAccount;
            }


        }
    }
