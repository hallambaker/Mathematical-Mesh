using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;

namespace Goedel.Mesh.Client {

    /// <summary>
    /// Base context for interacting with a Mesh.
    /// </summary>
    public partial class ContextMesh : Disposable {
        ///<summary>The Machine context.</summary>
        public IMeshMachineClient MeshMachine => MeshHost?.MeshMachine;

        ///<summary>The Mesh host</summary>
        public MeshHost MeshHost { get; }


        ///<summary>The master profile</summary>
        public ProfileMesh ProfileMesh { get; }

        ///<summary>The Device Entry in the CatalogHost</summary>
        public CatalogedMachine CatalogedMachine;

        ///<summary>For a non administrative device, the CatalogEntryDevice is in the 
        ///connection entry;</summary>
        public virtual CatalogedDevice CatalogedDevice => CatalogedMachine?.CatalogedDevice;

        //public ConnectionDevice ConnectionDevice =>
        //    CatalogedDevice.ConnectionDevice;

        //public ContextMeshAdmin ContextMeshAdmin => this as ContextMeshAdmin;




        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="meshHost">The Mesh Host</param>
        /// <param name="deviceConnection">The device connection record.</param>
        public ContextMesh(MeshHost meshHost, CatalogedMachine deviceConnection) {
            Assert.AssertNotNull(deviceConnection, NYI.Throw);

            MeshHost = meshHost;
            CatalogedMachine = deviceConnection;

            ProfileMesh = ProfileMesh.Decode(CatalogedMachine.EnvelopedProfileMaster);

            }

        // The account activation was not added to activations.

        /// <summary>
        /// Return an account context within the context of the Mesh.
        /// </summary>
        /// <param name="localName">Local name of the account.</param>
        /// <param name="accountName">Service name of the account.</param>
        /// <returns></returns>
        public ContextAccount GetContextAccount(
                string localName = null,
                string accountName = null) {
            var account = CatalogedDevice.GetAccount(localName, accountName);
            return account == null ? null : new ContextAccount(this, account, CatalogedDevice.ProfileDevice);
            }

        /// <summary>
        /// Update <paramref name="catalogedDevice"/> in the Mesh context.
        /// </summary>
        /// <param name="catalogedDevice">The device to update.</param>
        public void UpdateDevice(CatalogedDevice catalogedDevice) {

            CatalogedMachine.CatalogedDevice = catalogedDevice;
            MeshMachine.MeshHost.Register(CatalogedMachine);
            }

        }

    /// <summary>
    /// Context for a pending Mesh connection request. Is deleted and replaced by a full context
    /// if accepted.
    /// </summary>
    public class ContextMeshPending : ContextMesh {

        ///<summary>Convenience accessor for the pending context.</summary>
        public CatalogedPending PendingConnection => CatalogedMachine as CatalogedPending;

        ///<summary>Convenience accessor for the connection request acknowledgement.</summary>
        public AcknowledgeConnection MessageAcknowledgeConnection => PendingConnection?.MessageConnectionResponse;
        
        ///<summary>Convenience accessor for the original connection request.</summary>
        public RequestConnection MessageRequestConnection => MessageAcknowledgeConnection?.MessageConnectionRequest;

        ///<summary>Convenience accessor for the Profile Device</summary>
        public ProfileDevice ProfileDevice => MessageRequestConnection?.ProfileDevice;


        KeyPair keyAuthentication;

        ///<summary>Convenience accessor for the Account Service ID</summary>
        public string ServiceID => MessageRequestConnection?.ServiceID;

        ///<summary>The Mesh Client.</summary>
        public MeshService MeshClient;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="meshHost">The Mesh host</param>
        /// <param name="catalogedMachine">The pending connection description.</param>
        public ContextMeshPending(MeshHost meshHost, CatalogedMachine catalogedMachine) :
                    base(meshHost, catalogedMachine) {
            }


        /// <summary>
        /// Initiate a connection request.
        /// </summary>
        /// <param name="meshHost">The Mesh Host</param>
        /// <param name="serviceID">The Service Identifier for the account to connect to.</param>
        /// <param name="localName">Local friendly name for the account.</param>
        /// <param name="pin">Pin code value (if supplied).</param>
        /// <param name="algorithmEncrypt">The encryption algorithm to use.</param>
        /// <param name="algorithmSign">The signature algorithm to use.</param>
        /// <param name="algorithmAuthenticate">The authentication algorithm to use.</param>
        /// <returns>The <see cref="ContextMeshPending"/> record describing the state of the 
        /// pending connection.</returns>
        public static ContextMeshPending ConnectService(
                MeshHost meshHost,
                string serviceID,
                string localName = null,
                string pin = null,
                CryptoAlgorithmID algorithmEncrypt = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmSign = CryptoAlgorithmID.Default,
                CryptoAlgorithmID algorithmAuthenticate = CryptoAlgorithmID.Default) {

            var secretSeed = new PrivateKeyUDF (
                    UdfAlgorithmIdentifier.MeshProfileDevice, algorithmEncrypt, algorithmSign,
                    algorithmAuthenticate);

            var profileDevice = new ProfileDevice (meshHost.KeyCollection, secretSeed, true);

            return ConnectService(meshHost, profileDevice, serviceID, localName, pin);
            }


        /// <summary>
        /// Initiate a connection request.
        /// </summary>
        /// <param name="meshHost">The Mesh Host</param>
        /// <param name="serviceID">The Service Identifier for the account to connect to.</param>
        /// <param name="localName">Local friendly name for the account.</param>
        /// <param name="pin">Pin code value (if supplied).</param>
        /// <param name="profileDevice">The device profile.</param>
        /// <returns>The <see cref="ContextMeshPending"/> record describing the state of the 
        /// pending connection.</returns>
        public static ContextMeshPending ConnectService(
                MeshHost meshHost,
                ProfileDevice profileDevice,
                string serviceID,
                string localName = null,
                string pin = null) {

            // generate MessageConnectionRequestClient
            var messageConnectionRequestClient = new RequestConnection() {
                ServiceID = serviceID,
                EnvelopedProfileDevice = profileDevice.DareEnvelope,
                ClientNonce = CryptoCatalog.GetBits(128),
                PinUDF = UDF.PIN2PinID(pin)
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
                ResponseID = MessageAcknowledgeConnection.GetResponseID(),
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
