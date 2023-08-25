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
/// Base context for interacting with a preconfigured device
/// </summary>
public class ContextMeshPreconfigured : ContextAccount {

    ///<summary>Convenience accessor for the pending context.</summary>
    public CatalogedPreconfigured CatalogedPreconfigured
                => CatalogedMachine as CatalogedPreconfigured;

    ///<summary>The manufacturer profile used to direct configuration.</summary>
    public override Profile Profile => CatalogedPreconfigured.ProfileDevice;

    ///<summary>Preconfigured devices have a connection to the manufacturer profile.</summary>
    public override Connection Connection => CatalogedPreconfigured.ConnectionDevice;

    ///<summary>The account address. This binds to the manufacturer account.</summary>
    public override string ServiceAddress => CatalogedPreconfigured?.AccountAddress;

    ///<inheritdoc/>
    public override string ServiceDns => ServiceAddress.GetService();


    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="meshHost">The Mesh host</param>
    /// <param name="catalogedMachine">The pending connection description.</param>
    public ContextMeshPreconfigured(MeshHost meshHost, CatalogedMachine catalogedMachine) :
                base(meshHost, catalogedMachine) {

        var profileDevice = ProfileDevice;
        profileDevice.Activate(KeyCollection);

        var meshCredentialPrivate = new MeshKeyCredentialPrivate(
                profileDevice.KeyAuthentication as KeyPairAdvanced, ServiceAddress); 
        

        MeshClient = MeshHost.MeshMachine.GetMeshClient(
                meshCredentialPrivate, ServiceAddress);
        }


    /// <summary>
    /// Attempt to connect to a personal Mesh by polling various services. 
    /// </summary>
    /// <returns>If successfull returns an ContextAccount instance to allow access
    /// to the connected account. Otherwise, a null value is returned.</returns>
    public ContextMeshPending Poll() => PollAsync().Sync();

    /// <summary>
    /// Attempt to connect to a personal Mesh by polling various services. 
    /// </summary>
    /// <returns>If successfull returns an ContextAccount instance to allow access
    /// to the connected account. Otherwise, a null value is returned.</returns>
    public async Task<ContextMeshPending> PollAsync() {

        // Check that we can connect to the service.
        MeshClient.AssertNotNull(InvalidServiceResponse.Throw);

        var claimRequest = new PollClaimRequest() {
            TargetAccountAddress = CatalogedPreconfigured.AccountAddress,
            PublicationId = CatalogedPreconfigured.PublicationId
            };

        var claimResponse = await MeshClient.PollClaimAsync(claimRequest);

        if (claimResponse?.EnvelopedMessage == null) {
            return null;
            }

        var messageClaim = MeshItem.Decode(claimResponse.EnvelopedMessage, KeyCollection) as MessageClaim;
        messageClaim.AssertNotNull(InvalidServiceResponse.Throw); // should never be null

        messageClaim.Verify(
                CatalogedPreconfigured.ServiceAuthenticator,
                CatalogedPreconfigured.DeviceAuthenticator).AssertTrue(RefusedPINInvalid.Throw);

        //Screen.WriteLine($"Have been claimed by {messageClaim.Sender}");

        // Create a pending connection entry.
        var profileDevice = CatalogedPreconfigured.ProfileDevice;
        var catalogedPending = new CatalogedPending() {
            Id = profileDevice.UdfString,
            DeviceUDF = profileDevice.UdfString,
            AccountAddress = messageClaim.Sender,
            EnvelopedProfileDevice = profileDevice.GetEnvelopedProfileDevice(),
            EnvelopedAcknowledgeConnection =
                    new Enveloped<AcknowledgeConnection>(claimResponse.EnvelopedMessage)
            };

        var context = new ContextMeshPending(MeshHost, catalogedPending);

        // persist - might balk on reuse of ID
        MeshHost.Register(catalogedPending, context);

        return context;

        }


    /// <summary>
    /// Attempt to connect to a personal Mesh by polling various services. 
    /// </summary>
    /// <returns>If successfull returns an ContextAccountService instance to allow access
    /// to the connected account. Otherwise, a null value is returned.</returns>
    public async Task<ContextUser> CompleteAsync() {
        var Pending = await PollAsync();
        if (Pending != null) {
            return await Pending.CompleteAsync();
            }
        return null;
        }


    /// <summary>
    /// Write the device configuration <paramref name="devicePreconfiguration"/> to
    /// the Mesh host <paramref name="meshHost"/>.
    /// </summary>
    /// <param name="meshHost">The Mesh host to be written to.</param>
    /// <param name="devicePreconfiguration">The preconfiguration data.</param>
    /// <returns>Context for the preconfigured device.</returns>
    public static ContextMeshPreconfigured Install(
                MeshHost meshHost,
                DevicePreconfigurationPrivate devicePreconfiguration) {

        var privateKeyUDF = devicePreconfiguration.PrivateKey as PrivateKeyUDF;
        (var accountAddress, var key) = MeshUri.ParseConnectUri(devicePreconfiguration.ConnectUri);

        // Note that we process the devicePreconfiguration values so that the device itself
        // does not have a machine readable value for the secret key.
        var publicationID = Udf.SymetricKeyId(key);
        var serviceAuthenticator = CatalogedPublication.GetServiceAuthenticator(key);
        var deviceAuthenticator = CatalogedPublication.GetDeviceAuthenticator(key);

        var profileDevice = new ProfileDevice(privateKeyUDF);


        // check for sanity here
        var profileDeviceRecovered = devicePreconfiguration.EnvelopedProfileDevice.Decode();
        profileDeviceRecovered.Validate();
        (profileDeviceRecovered.UdfString == profileDevice.UdfString).AssertTrue(InvalidProfile.Throw);
        (profileDeviceRecovered.Authentication.Udf ==
                profileDevice.Authentication.Udf).AssertTrue(InvalidProfile.Throw);
        (profileDeviceRecovered.Encryption.Udf ==
                profileDevice.Encryption.Udf).AssertTrue(InvalidProfile.Throw);
        (profileDeviceRecovered.Signature.Udf ==
                profileDevice.Signature.Udf).AssertTrue(InvalidProfile.Throw);


        // Persist the seed to the platform protected key store.
        profileDevice.PersistSeed(meshHost.KeyCollection);

        // create a Mesh Host entry.
        var catalogedPreconfig = new CatalogedPreconfigured() {
            EnvelopedProfileDevice = devicePreconfiguration.EnvelopedProfileDevice,
            EnvelopedConnectionDevice = devicePreconfiguration.EnvelopedConnectionDevice,
            Id = profileDevice.UdfString,
            ServiceAuthenticator = serviceAuthenticator,
            DeviceAuthenticator = deviceAuthenticator,
            PublicationId = publicationID,
            AccountAddress = accountAddress
            };

        // add to the catalog.
        var context = new ContextMeshPreconfigured(meshHost, catalogedPreconfig);
        meshHost.Register(catalogedPreconfig, context);

        return context;

        }
    }
