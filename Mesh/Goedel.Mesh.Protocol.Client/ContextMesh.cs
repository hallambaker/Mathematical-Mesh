using Goedel.Cryptography;
using Goedel.Utilities;

namespace Goedel.Mesh.Client {

    public partial class ContextMesh : Disposable {
        ///<summary>The Machine context.</summary>
        public IMeshMachineClient MeshMachine => MeshHost?.MeshMachine;


        public MeshHost MeshHost { get; }


        ///<summary>The master profile</summary>
        public ProfileMesh ProfileMesh { get; }

        ///<summary>The Device Entry in the CatalogHost</summary>
        public CatalogedMachine CatalogedMachine;


        ///<summary>Convenience property returning the device connections</summary>
        CatalogedStandard DeviceConnection => CatalogedMachine as CatalogedStandard;

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
            return new ContextAccount(this, account);
            }


        public void UpdateDevice(CatalogedDevice catalogedDevice) {

            CatalogedMachine.CatalogedDevice = catalogedDevice;
            MeshMachine.MeshHost.Register(CatalogedMachine);
            }

        }


    public class ContextMeshPending : ContextMesh {

        public CatalogedPending PendingConnection => CatalogedMachine as CatalogedPending;
        AcknowledgeConnection MessageConnectionResponse => PendingConnection?.MessageConnectionResponse;
        RequestConnection MessageConnectionRequest => MessageConnectionResponse?.MessageConnectionRequest;

        ProfileDevice ProfileDevice => MessageConnectionRequest?.ProfileDevice;


        KeyPair KeyAuthentication;

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
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {
            var profileDevice = ProfileDevice.Generate(meshHost.MeshMachine,
                algorithmSign: algorithmSign, algorithmEncrypt: algorithmEncrypt,
                algorithmAuthenticate: algorithmAuthenticate);

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

            KeyAuthentication = KeyAuthentication ?? MeshMachine.KeyCollection.LocatePrivateKeyPair(
                        ProfileDevice.KeyAuthentication.UDF);

            MeshClient = MeshClient ?? MeshMachine.GetMeshClient(ServiceID, KeyAuthentication, null);

            var completeRequest = new CompleteRequest() {
                DeviceUDF = ProfileDevice.UDF,
                ServiceID = ServiceID
                };

            var statusResponse = MeshClient.Complete(completeRequest);


            // OK so here we need to unpack the profile etc.
            var catalogedEntry = CatalogedDevice.Decode(statusResponse.EnvelopedCatalogEntryDevice, MeshMachine.KeyCollection);
            var profileMaster = ProfileMesh.Decode(statusResponse.EnvelopedProfileMaster);


            // now create the host profile here.

            var catalogedStandard = new CatalogedStandard() {
                ID = ProfileDevice.UDF,
                CatalogedDevice = catalogedEntry,
                EnvelopedProfileMaster = statusResponse.EnvelopedProfileMaster
                };

            MeshMachine.MeshHost.Register(catalogedStandard);


            var contextMesh = new ContextMesh(MeshHost, catalogedStandard);


            var contextAccount = contextMesh.GetContextAccount(accountName: ServiceID);

            contextAccount.InitializeStores(statusResponse);

            return contextAccount;
            }






        //protected MeshService GetMeshClient(string serviceID) => 
        //    MeshMachine.GetMeshClient(serviceID, KeyAuthentication,
        //        ActivationAccount.AssertionAccountConnection, ContextMesh.ProfileMesh);

        }
    }
