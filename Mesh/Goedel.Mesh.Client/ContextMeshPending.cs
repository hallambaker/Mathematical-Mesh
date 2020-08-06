using Goedel.Cryptography;
using Goedel.Cryptography.Jose;
using Goedel.Utilities;
using Goedel.Mesh;
using System;
using System.Collections.Generic;
using System.IO;

namespace Goedel.Mesh.Client {


    /// <summary>
    /// Context for a pending Mesh connection request. Is deleted and replaced by a full context
    /// if accepted.
    /// </summary>
    public class ContextMeshPending : ContextAccount {

        ///<summary>Convenience accessor for the pending context.</summary>
        public CatalogedPending CatalogedPending => CatalogedMachine as CatalogedPending;

        KeyPair keyAuthentication;
        KeyPair keyEncryption;
        //KeyPair keySignature;

        ///<summary>The account address from the cataloged pending record. Note that this
        ///address MUST be for the same service that the original request was made to.</summary>
        public override string AccountAddress => CatalogedPending.AccountAddress;

        
        ///<summary>The account profile. Always null.</summary>
        public override Profile Profile => null;

        ///<summary>The connection binding the calling context to the account. This is of course null
        ///since a device in the state Mesh Pending does not have a connection by definition.</summary>
        public override Connection Connection =>null;


        /////<summary>Convenience accessor for the Account Service ID</summary>
        //public string AccountAddress => CatalogedPending?.AccountAddress;


        ///<summary>The device key generation seed</summary>
        protected PrivateKeyUDF DeviceKeySeed;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="meshHost">The Mesh host</param>
        /// <param name="catalogedMachine">The pending connection description.</param>
        public ContextMeshPending(MeshHost meshHost, CatalogedMachine catalogedMachine) :
                    base(meshHost, catalogedMachine) {


            keyAuthentication = DeviceKeySeed?.BasePrivate(MeshKeyType.DeviceAuthenticate);
            keyEncryption = DeviceKeySeed?.BasePrivate(MeshKeyType.DeviceEncrypt);
            //keySignature = DeviceKeySeed?.BasePrivate(MeshKeyType.DeviceSign);

            KeyCollection.Add(keyEncryption);
            }


        /// <summary>
        /// Initiate a connection request.
        /// </summary>
        /// <param name="meshHost">The Mesh Host</param>
        /// <param name="accountAddress">The Service Identifier for the account to connect to.</param>
        /// <param name="localName">Local friendly name for the account.</param>
        /// <param name="pin">Pin code value (if supplied).</param>
        /// <param name="algorithmEncrypt">The encryption algorithm to use.</param>
        /// <param name="algorithmSign">The signature algorithm to use.</param>
        /// <param name="algorithmAuthenticate">The authentication algorithm to use.</param>
        /// <returns>The <see cref="ContextMeshPending"/> record describing the state of the 
        /// pending connection.</returns>
        public static ContextMeshPending ConnectService(
                MeshHost meshHost,
                string accountAddress,
                string localName = null,
                string pin = null,
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default,
                int bits = 256) {

            var secretSeed = new PrivateKeyUDF(
                UdfAlgorithmIdentifier.MeshProfileDevice, null, null,
                algorithmEncrypt, algorithmSign, algorithmAuthenticate,
                bits: bits);


            var profileDevice = new ProfileDevice();
            profileDevice.PersistSeed(meshHost.KeyCollection);

            return ConnectService(meshHost, profileDevice, accountAddress, localName, pin);
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
            var messageConnectionRequestClient = new RequestConnection(profileDevice,
                accountAddress, pin);


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
                Id = profileDevice.UDF,
                DeviceUDF = profileDevice.UDF,
                AccountAddress = accountAddress,
                EnvelopedMessageConnectionResponse = response.EnvelopedConnectionResponse,
                EnvelopedProfileUser = response.EnvelopedProfileMaster,
                EnvelopedProfileDevice = profileDevice.DareEnvelope,
                EnvelopedAccountAssertion = response.EnvelopedAccountAssertion
                };

            var context = new ContextMeshPending(meshHost, catalogedPending);

            // persist 
            meshHost.Register(catalogedPending, context);

            return context;
            }

        /// <summary>
        /// Complete the pending connection request.
        /// </summary>
        /// <returns>If successfull returns an ContextAccountService instance to allow access
        /// to the connected account. Otherwise, a null value is returned.</returns>
        public ContextUser Complete() {

            "The catalog contents are not currently encrypted as they should be".TaskFunctionality();

            var completeRequest = new CompleteRequest() {
                ResponseID = CatalogedPending.GetResponseID(),
                AccountAddress = AccountAddress
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

            respondConnection.Result.AssertEqual(Constants.TransactionResultAccept,
                    ConnectionException.Throw);


            var catalogedEntry = respondConnection.CatalogedDevice;
            var profileUser = catalogedEntry.ProfileUser;

            // now create the host catalog entry
            var catalogedStandard = new CatalogedStandard() {
                Id = ProfileDevice.UDF,
                CatalogedDevice = catalogedEntry,
                EnvelopedProfileUser = profileUser.DareEnvelope
                };

            // create the context mesh
            var contextUser = new ContextUser(MeshHost, catalogedStandard);

            MeshHost.Register(catalogedStandard, contextUser);

            // now create the account context for the account we asked to connect to and initialize
            Directory.CreateDirectory(contextUser.StoresDirectory);
            contextUser.Sync();
            return contextUser;
            }


        }

    }
