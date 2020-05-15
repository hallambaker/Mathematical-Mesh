using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;
using Goedel.Mesh;
using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh.Client {





    /// <summary>
    /// Base context for interacting with a Mesh.
    /// </summary>
    public partial class ContextMesh : Disposable {
        ///<summary>The Machine context.</summary>
        public IMeshMachineClient MeshMachine => MeshHost?.MeshMachine;

        ///<summary>The Mesh host</summary>
        public MeshHost MeshHost { get; }

        ///<summary>The key collection</summary>
        public KeyCollection KeyCollection => MeshHost.KeyCollection;


        ///<summary>The cataloged device</summary>
        public virtual CatalogedDevice CatalogedDevice => CatalogedMachine?.CatalogedDevice;

        ///<summary>The connection device</summary>
        public ConnectionDevice ConnectionDevice => CatalogedDevice?.ConnectionDevice;

        ///<summary>The master profile</summary>
        public ProfileMesh ProfileMesh => CatalogedDevice?.ProfileMesh;

        ///<summary>The device profile</summary>
        public ProfileDevice ProfileDevice => CatalogedMachine?.ProfileDevice;

        ///<summary>The device activation</summary>
        public ActivationDevice ActivationDevice => CatalogedDevice?.GetActivationDevice(KeyCollection);

        ///<summary>The Device Entry in the CatalogHost</summary>
        public CatalogedMachine CatalogedMachine;


        //public ContextMeshAdmin ContextMeshAdmin => this as ContextMeshAdmin;

        ///<summary>The device key generation seed</summary>
        protected PrivateKeyUDF DeviceKeySeed;

        KeyPair deviceDecrypt;

        KeyPair keySignature;
        KeyPair keyEncryption;
        KeyPair keyAuthentication;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="meshHost">The Mesh Host</param>
        /// <param name="catalogedMachine">The cataloged Mesh record.</param>
        public ContextMesh(MeshHost meshHost, CatalogedMachine catalogedMachine) {
            Assert.AssertNotNull(catalogedMachine, NYI.Throw);

            MeshHost = meshHost;
            CatalogedMachine = catalogedMachine;

            // set profile device up here
            // 



            DeviceKeySeed = ProfileDevice?.GetPrivateKeyUDF(MeshHost.MeshMachine);
            deviceDecrypt = DeviceKeySeed?.BasePrivate(MeshKeyType.DeviceEncrypt);

            Console.WriteLine($"Device Encrypt {deviceDecrypt}");
            KeyCollection.Add(deviceDecrypt);

            // register the private decryption key here.

            if (CatalogedDevice != null) {
                var activationKey = ActivationDevice.ActivationKey;
                activationKey.AssertNotNull(Internal.Throw);

                keySignature = DeviceKeySeed.ActivatePrivate(
                    activationKey, MeshKeyType.DeviceSign, KeyCollection);
                keyEncryption = DeviceKeySeed.ActivatePrivate(
                    activationKey, MeshKeyType.DeviceEncrypt, KeyCollection);
                keyAuthentication = DeviceKeySeed.ActivatePrivate(
                    activationKey, MeshKeyType.DeviceAuthenticate, KeyCollection);

                
                
                (keySignature.UDF).AssertEqual(ConnectionDevice.KeySignature.UDF);
                
                
                // These are failing because the underlying combination schemes are failing.
                (keyEncryption.UDF).AssertEqual(ConnectionDevice.KeyEncryption.UDF);
                (keyAuthentication.UDF).AssertEqual(ConnectionDevice.KeyAuthentication.UDF);

                }
            }

        /// <summary>
        /// Derive a <see cref="KeyPair"/> instance of type <paramref name="meshKeyType"/>
        /// using the activation secret <paramref name="activationKey"/>.
        /// </summary>
        /// <param name="activationKey">The activation secret seed used to derrive the 
        /// activation key.</param>
        /// <param name="meshKeyType">The type of key to derive</param>
        /// <returns>The derrived key.</returns>
        public KeyPair ActivateKey(string activationKey, MeshKeyType meshKeyType) {

            DeviceKeySeed ??= ProfileDevice?.GetPrivateKeyUDF(MeshHost.MeshMachine);
            return DeviceKeySeed.ActivatePrivate(
                    activationKey, meshKeyType, KeyCollection);
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
            return account == null ? null : new ContextAccount(this, account);
            }

        /// <summary>
        /// Update the persisted <see cref="CatalogedMachine"/>.
        /// </summary>
        public void UpdateDevice() => MeshHost.Register(CatalogedMachine, this);

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

        KeyPair keyAuthentication;
        KeyPair keyEncryption;
        //KeyPair keySignature;

        ///<summary>Convenience accessor for the Account Service ID</summary>
        public string ServiceID => MessageRequestConnection?.AccountAddress;

        ///<summary>The Mesh Client.</summary>
        public MeshService MeshClient;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="meshHost">The Mesh host</param>
        /// <param name="catalogedMachine">The pending connection description.</param>
        public ContextMeshPending(MeshHost meshHost, CatalogedMachine catalogedMachine) :
                    base(meshHost, catalogedMachine) {

            
            keyAuthentication = DeviceKeySeed?.BasePrivate(MeshKeyType.DeviceAuthenticate);
            keyEncryption= DeviceKeySeed?.BasePrivate(MeshKeyType.DeviceEncrypt);
            //keySignature = DeviceKeySeed?.BasePrivate(MeshKeyType.DeviceSign);

            KeyCollection.Add(keyEncryption);
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
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default) {

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
        /// <param name="accountAddress">The account address to connect to.</param>
        /// <param name="localName">Local friendly name for the account.</param>
        /// <param name="pin">Pin code value (if supplied).</param>
        /// <param name="profileDevice">The device profile.</param>
        /// <returns>The <see cref="ContextMeshPending"/> record describing the state of the 
        /// pending connection.</returns>
        public static ContextMeshPending ConnectService(
                MeshHost meshHost,
                ProfileDevice profileDevice,
                string accountAddress,
                string localName = null,
                string pin = null) {

            localName.Future();

            // generate MessageConnectionRequestClient
            var messageConnectionRequestClient = new RequestConnection(accountAddress,
                        profileDevice, pin);


            var keyAuthentication = meshHost.KeyCollection.LocatePrivateKeyPair(
                        profileDevice.KeyAuthentication.UDF);

            var messageConnectionRequestClientEncoded = 
                messageConnectionRequestClient.Encode(keyAuthentication);

            // Acquire ephemeral client. This will only be used for the Connect and Complete methods.
            var meshClient = meshHost.MeshMachine.GetMeshClient(accountAddress, keyAuthentication, null);

            var connectRequest = new ConnectRequest() {
                MessageConnectionRequestClient = messageConnectionRequestClientEncoded
                };

            var response = meshClient.Connect(connectRequest);

            // create the pending connection here

            var catalogedPending = new CatalogedPending() {
                ID = profileDevice.UDF,
                DeviceUDF = profileDevice.UDF,
                EnvelopedMessageConnectionResponse = response.EnvelopedConnectionResponse,
                EnvelopedProfileMaster = response.EnvelopedProfileMaster,
                EnvelopedProfileDevice = profileDevice.DareEnvelope,
                EnvelopedAccountAssertion = response.EnvelopedAccountAssertion
                };

            var context= new ContextMeshPending(meshHost, catalogedPending);

            // persist 
            meshHost.Register(catalogedPending, context);

            return context;
            }

        /// <summary>
        /// Complete the pending connection request.
        /// </summary>
        /// <returns>If successfull returns an ContextAccountService instance to allow access
        /// to the connected account. Otherwise, a null value is returned.</returns>
        public ContextAccount Complete() {

            "The catalog contents are not currently encrypted as they should be".TaskFunctionality();


            MeshClient ??= MeshMachine.GetMeshClient(ServiceID, keyAuthentication, null);

            var completeRequest = new CompleteRequest() {
                ResponseID = MessageAcknowledgeConnection.GetResponseID(),
                ServiceID = ServiceID
                };

            var completeResponse = MeshClient.Complete(completeRequest);
            completeResponse.Success().AssertTrue(ConnectionAccountUnknown.Throw);

            //// OK so here we need to unpack the profile etc.
            var respondConnection = RespondConnection.Decode(
                    completeResponse.SignedResponse, KeyCollection);

            respondConnection.Validate(ProfileDevice, KeyCollection);

            switch (respondConnection.Result) {
                case Constants.TransactionResultReject: throw new ConnectionRefused();
                case Constants.TransactionResultPending: throw new ConnectionPending();
                case Constants.TransactionResultExpired: throw new ConnectionExpired();
                }



            // Check the return result here!

            respondConnection.Result.AssertEqual(Constants.TransactionResultAccept);


            var catalogedEntry = respondConnection.CatalogedDevice;
            //var activationDevice = catalogedEntry.GetActivationDevice(KeyCollection);
            //var connectionDevice = catalogedEntry.ConnectionDevice;
            var profileMaster = catalogedEntry.ProfileMesh;


            // now create the host catalog entry
            var catalogedStandard = new CatalogedStandard() {
                ID = ProfileDevice.UDF,
                CatalogedDevice = catalogedEntry,
                EnvelopedProfileMaster = profileMaster.DareEnvelope
                };

            // create the context mesh
            var contextMesh = new ContextMesh(MeshHost, catalogedStandard);

            MeshHost.Register(catalogedStandard, contextMesh);

            // now create the account context for the account we asked to connect to and initialize
            var contextAccount = contextMesh.GetContextAccount(accountName: ServiceID); 
            Directory.CreateDirectory(contextAccount.DirectoryAccount);
            contextAccount.Sync();
            return contextAccount;
            }


        }
    }
