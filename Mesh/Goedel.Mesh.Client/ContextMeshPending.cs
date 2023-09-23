#region // Copyright - MIT License
//  © 2021 by Phill Hallam-Baker
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


namespace Goedel.Mesh.Client;


/// <summary>
/// Context for a pending Mesh connection request. Is deleted and replaced by a full context
/// if accepted.
/// </summary>
public class ContextMeshPending : ContextAccount {

    ///<summary>The connection request message sent to the service. This is only populated
    ///in an instance returned as a result of issuing a device connection request.</summary> 
    public RequestConnection RequestConnection;
    ///<summary>The connection request acknowledgement message received from the service. 
    ///This is only populated
    ///in an instance returned as a result of issuing a device connection request.</summary> 
    public AcknowledgeConnection AcknowledgeConnection;


    ///<summary>Convenience accessor for the pending context.</summary>
    public CatalogedPending CatalogedPending => CatalogedMachine as CatalogedPending;

    readonly KeyPair keyAuthentication;
    readonly KeyPair keyEncryption;
    //KeyPair keySignature;

    ///<summary>The account address from the cataloged pending record. Note that this
    ///address MUST be for the same service that the original request was made to.</summary>
    public override string ServiceAddress => CatalogedPending?.AccountAddress;

    ///<inheritdoc/>
    public override string ServiceDns => ServiceAddress.GetService();

    ///<summary>The account profile. Always null.</summary>
    public override Profile Profile => null;

    ///<summary>The connection binding the calling context to the account. This is of course null
    ///since a device in the state Mesh Pending does not have a connection by definition.</summary>
    public override Connection Connection => null;


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

        //DeviceKeySeed should never be null
        DeviceKeySeed = KeyCollection.LocatePrivateKey(ProfileDevice.UdfString) as PrivateKeyUDF;
        DeviceKeySeed.AssertNotNull(DeviceSeedNotFound.Throw);

        keyEncryption = DeviceKeySeed?.GenerateContributionKeyPair(
                    MeshKeyType.Base, MeshActor.Device, MeshKeyOperation.Encrypt);
        keyAuthentication = DeviceKeySeed?.GenerateContributionKeyPair(
                    MeshKeyType.Base, MeshActor.Device, MeshKeyOperation.Authenticate);
        KeyCollection.Add(keyEncryption);
        KeyCollection.Add(keyAuthentication);
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
    /// <param name="rights">The list of rights being requested by the device.</param>
    /// <param name="bits">Work factor of the secret seed.</param>
    /// <returns>The <see cref="ContextMeshPending"/> record describing the state of the 
    /// pending connection.</returns>
    public static async Task<ContextMeshPending> ConnectServiceAsync(
            MeshHost meshHost,
            string accountAddress,
            string localName = null,
            string pin = null,
            CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
            CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
            CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default,
            int bits = 256,
            List<string> rights = null) {

        // If accountAddress is a Mesh Connect URI, replace account, pin with the parsed values.
        MeshUri.ParseUri(ref accountAddress, ref pin);

        var profileDevice = ProfileDevice.Generate(
                    algorithmEncrypt, algorithmSign, algorithmAuthenticate, bits);

        profileDevice.PersistSeed(meshHost.KeyCollection);

        return await ConnectServiceAsync(meshHost, profileDevice, accountAddress, localName, pin, rights: rights);
        }


    /// <summary>
    /// Initiate a connection request.
    /// </summary>
    /// <param name="meshHost">The Mesh Host</param>
    /// <param name="accountAddress">The account address to connect to.</param>
    /// <param name="localName">Local friendly name for the account.</param>
    /// <param name="pin">Pin code value (if supplied).</param>
    /// <param name="profileDevice">The device profile.</param>
    /// <param name="rights">The list of rights being requested by the device.</param>
    /// <returns>The <see cref="ContextMeshPending"/> record describing the state of the 
    /// pending connection.</returns>
    public static async Task<ContextMeshPending> ConnectServiceAsync(
            MeshHost meshHost,
            ProfileDevice profileDevice,
            string accountAddress,
            string localName = null,
            string pin = null,
            List<string> rights = null) {

        localName.Future();


        // generate MessageConnectionRequestClient
        var requestConnection = new RequestConnection(profileDevice,
            accountAddress, pin);

        meshHost.KeyCollection.LocatePrivateKeyPair(
                        profileDevice.Authentication.Udf, out var keyAuthentication);

        requestConnection.Envelope(keyAuthentication);

        profileDevice.Activate(meshHost.KeyCollection);
        //var meshCredentialPrivate = new MeshCredentialPrivate(profileDevice, null, null,
        //    profileDevice.KeyAuthentication as KeyPairAdvanced);

        var meshCredentialPrivate = new MeshKeyCredentialPrivate(
            profileDevice.KeyAuthentication as KeyPairAdvanced, accountAddress);


        // Acquire ephemeral client. This will only be used for the Connect and Complete methods.


        var meshClient = meshHost.MeshMachine.GetMeshClient(
                    meshCredentialPrivate, accountAddress);

        var connectRequest = new ConnectRequest() {
            EnvelopedRequestConnection = requestConnection.EnvelopedRequestConnection,
            Rights = rights
            };

        var connectResponse = await meshClient.ConnectAsync(connectRequest);

        // create the pending connection here

        var catalogedPending = new CatalogedPending() {
            Id = profileDevice.UdfString,
            DeviceUDF = profileDevice.UdfString,
            AccountAddress = accountAddress,
            EnvelopedAcknowledgeConnection = connectResponse.EnvelopedAcknowledgeConnection,
            EnvelopedProfileAccount = connectResponse.EnvelopedProfileAccount,
            EnvelopedProfileDevice = profileDevice.GetEnvelopedProfileDevice(),
            Local = localName
            };

        var acknowledgeConnection =
                connectResponse.EnvelopedAcknowledgeConnection.Decode(meshHost.KeyCollection);

        var context = new ContextMeshPending(meshHost, catalogedPending) {
            RequestConnection = requestConnection,
            AcknowledgeConnection = acknowledgeConnection
            };

        // persist 
        meshHost.Register(catalogedPending, context);

        return context;
        }

    /// <summary>
    /// Complete the pending connection request.
    /// </summary>
    /// <returns>If successfull returns an ContextAccountService instance to allow access
    /// to the connected account. Otherwise, a null value is returned.</returns>
    public async Task<ContextUser> CompleteAsync() {

        var completeRequest = new CompleteRequest() {
            ResponseID = CatalogedPending.GetResponseID(),
            AccountAddress = ServiceAddress
            };
        var profileDevice = ProfileDevice;
        profileDevice.Activate(KeyCollection);

        var meshCredentialPrivate = new MeshKeyCredentialPrivate(
                profileDevice.KeyAuthentication as KeyPairAdvanced, ServiceAddress);
        var meshClient = MeshHost.MeshMachine.GetMeshClient(
                meshCredentialPrivate, ServiceAddress);

        var completeResponse = meshClient.Complete(completeRequest);
        completeResponse.Success().AssertTrue(ConnectionAccountUnknown.Throw);

        //// OK so here we need to unpack the profile etc.
        var respondConnection = completeResponse.EnvelopedRespondConnection.Decode(KeyCollection);

        respondConnection.Validate(profileDevice, KeyCollection);

        switch (respondConnection.Result) {
            case MeshConstants.TransactionResultReject: throw new ConnectionRefused();
            case MeshConstants.TransactionResultPending: throw new ConnectionPending();
            case MeshConstants.TransactionResultExpired: throw new ConnectionExpired();
            }


        // Check the return result here!

        respondConnection.Result.AssertEqual(MeshConstants.TransactionResultAccept,
                ConnectionException.Throw);


        var catalogedEntry = respondConnection.CatalogedDevice;
        var profileUser = catalogedEntry.ProfileUser;

        // create the host catalog entry
        var catalogedStandard = new CatalogedStandard() {
            Id = profileDevice.UdfString,
            CatalogedDevice = catalogedEntry,
            EnvelopedProfileAccount = profileUser.GetEnvelopedProfileAccount()
            };

        // create the context mesh
        var contextUser = new ContextUser(MeshHost, catalogedStandard) {
            RespondConnection = respondConnection
            };

        MeshHost.Register(catalogedStandard, contextUser);

        // create the account context for the account we asked to connect to and initialize
        Directory.CreateDirectory(contextUser.StoresDirectory);
        await contextUser.SynchronizeAsync();
        return contextUser;
        }


    }
