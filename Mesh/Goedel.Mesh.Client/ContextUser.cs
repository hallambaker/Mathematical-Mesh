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
/// Process a mesh message received.
/// </summary>
/// <param name="contextUser">The user context to process the message.</param>
/// <param name="meshMessage">The message to process.</param>
/// <param name="accept">If relevant, accept offer made by message.</param>
/// <param name="reciprocate">If relevant respond to message by reciprocating.</param>
/// <param name="roles">Roles to be assigned to devices/applications create
/// in response to the message.</param>
/// <returns>The result of processing the message.</returns>
public delegate Task<ProcessResult> ProcessMessageDelegate(
                ContextUser contextUser,
                Message meshMessage, bool accept = true, bool reciprocate = true,
                List<string> roles = null);

/// <summary>
/// Context for interacting with a Mesh Account
/// </summary>
public partial class ContextUser : ContextAccount {


    #region // Public and private properties




    ///<summary>The account profile</summary>
    public override Profile Profile => ProfileUser;

    ///<summary>Convenience accessor for the connection.</summary>
    public override Connection Connection => ConnectionAccount;

    ///<summary>Convenience accessor to the account address.</summary>
    public override string ServiceAddress => ProfileUser?.AccountAddress;


    static ILogger Logger => Component.Logger;

    ///<summary>The profile</summary>
    public ProfileUser ProfileUser { get; }

    ///<summary>The service DNS value.</summary> 
    public override string ServiceDns { get; }

    ///<summary>The connection device</summary>
    public ConnectionService ConnectionService => CatalogedDevice?.ConnectionService;

    ///<summary>The connection device</summary>
    public ConnectionDevice ConnectionAccount => CatalogedDevice?.ConnectionDevice;

    ///<summary>The human readable device description.</summary> 
    public DeviceDescription DeviceDescription => CatalogedDevice?.DeviceDescription;

    /////<summary>The connection of the profile to the account address</summary>
    //public ConnectionStripped ConnectionAddress => CatalogedDevice?.ConnectionAccount;

    ///<summary>The connection device</summary>
    public List<ApplicationEntry> ApplicationEntries => CatalogedDevice?.ApplicationEntries;


    ///<summary>The device activation</summary>
    public ActivationAccount ActivationAccount { get; set; }


    ///<summary>The device key generation seed</summary>
    protected PrivateKeyUDF MeshSecretSeed;

    ///<summary>The RequestConnection message sent during device connection.
    ///This is only populated when the context is returned as the result of completing 
    ///device connection</summary> 
    public RequestConnection RequestConnection;

    ///<summary>The RespondConnection message returned during device connection.
    ///This is only populated when the context is returned as the result of completing 
    ///device connection</summary> 
    public RespondConnection RespondConnection;

    ///<summary>Device decryption key in account context.</summary> 
    public KeyPairAdvanced BaseDecrypt { get; }

    ///<summary>Device decryption key in account context.</summary> 
    public KeyPairAdvanced BaseAuthenticate { get; }



    ///<summary>Device signature key in account context.</summary>
    public KeyPairAdvanced AccountSignature => ActivationAccount?.AccountSignature;

    ///<summary>Device decryption key in account context.</summary>
    public KeyPairAdvanced AccountEncryption => ActivationAccount?.AccountEncryption;

    ///<summary>Device authentication key in account context.</summary>
    public KeyPairAdvanced AccountAuthentication => ActivationAccount?.AccountAuthentication;

    ///<summary>The contact catalog, used for key location of group keys.</summary>  
    protected CatalogContact CatalogContact { get; set; }

    string? deviceSeedId;

    /// <summary>
    /// Create a new ICredential.
    /// </summary>
    /// <returns>The credential</returns>
    public override MeshCredentialPrivate GetMeshCredentialPrivate() =>
        new(ProfileDevice, ConnectionService, null,
            AccountAuthentication ?? BaseAuthenticate);

    ///<summary>Dictionary mapping message type to processing delegate.</summary> 
    public static Dictionary<Type, ProcessMessageDelegate> ProcessDictionary { get; } = new();


    #endregion
    #region // Constructors

    /// <summary>
    /// Constructor, creates a <see cref="ContextUser"/> instance for the catalog entry 
    /// <paramref name="catalogedMachine"/> on machine <paramref name="meshHost"/>.
    /// </summary>
    /// <param name="catalogedMachine">Description of the device profile.</param>
    /// <param name="meshHost">The Mesh host to add the admin context to.</param>
    public ContextUser(
            MeshHost meshHost,
            CatalogedMachine catalogedMachine) : base(meshHost, catalogedMachine) {

        if (CatalogedDevice == null) {
            return;
            }

        ProfileUser = CatalogedDevice.ProfileUser;
        ServiceDns = ProfileUser.AccountAddress.GetService();

        // Get the device key so that we can decrypt the activation record.
        var deviceKeySeed = KeyCollection.LocatePrivateKey(ProfileDevice.UdfString) as PrivateKeyUDF;



        deviceSeedId = deviceKeySeed.KeyId;

        BaseDecrypt = deviceKeySeed.GenerateContributionKeyPair(MeshKeyType.Base,
            MeshActor.Device, MeshKeyOperation.Encrypt);
        BaseAuthenticate = deviceKeySeed.GenerateContributionKeyPair(MeshKeyType.Base,
            MeshActor.Device, MeshKeyOperation.Authenticate);
        KeyCollection.Add(BaseDecrypt);

        // Activate the device within the account.
        ActivationAccount = CatalogedDevice?.GetActivationAccount(KeyCollection);
        ActivationAccount.Activate(deviceKeySeed);

        KeyCollection.Add(ActivationAccount.AccountEncryption);

        // Activate the device to communicate as the account (via threshold)
        ActivationCommon = CatalogedDevice?.GetActivationCommon(KeyCollection);
        ActivationCommon.Activate(this);

        if (ActivationCommon.Entries != null) {
            foreach (var entry in ActivationCommon.Entries) {
                Privileges.Add(entry.Resource);
                }
            }

        if (KeyCommonEncryption != null) {
            KeyCollection.Add(KeyCommonEncryption);
            }

        if (catalogedMachine?.CatalogedDevice?.EnvelopedConnectionService != null) {
            // Some validation checks
            (AccountAuthentication.KeyIdentifier).AssertEqual(
                    ConnectionService.Authentication.CryptoKey.KeyIdentifier,
                    KeyActivationFailed.Throw);

            var connectionService = catalogedMachine?.CatalogedDevice?.EnvelopedConnectionService.Decode();
            }
        if (catalogedMachine?.EnvelopedAccountHostAssignment != null) {
            var hostAssignment = catalogedMachine?.EnvelopedAccountHostAssignment.Decode();
            ProfileService = hostAssignment.EnvelopedProfileService?.Decode();
            }

        if (catalogedMachine?.CatalogedDevice?.EnvelopedConnectionDevice != null) {
            //Logger.ActivateConnection("Signature", ConnectionDevice.Signature.CryptoKey.KeyIdentifier);
            //Logger.ActivateConnection("Encryption", ConnectionDevice.Encryption.CryptoKey.KeyIdentifier);
            Logger.ActivateConnection("Authentication", ConnectionAccount.Authentication.CryptoKey.KeyIdentifier);

            // Some validation checks
            (AccountSignature.KeyIdentifier).AssertEqual(ConnectionAccount.Signature.CryptoKey.KeyIdentifier,
                    KeyActivationFailed.Throw);
            (AccountEncryption.KeyIdentifier).AssertEqual(ConnectionAccount.Encryption.CryptoKey.KeyIdentifier,
                    KeyActivationFailed.Throw);
            (AccountAuthentication.KeyIdentifier).AssertEqual(ConnectionAccount.Authentication.CryptoKey.KeyIdentifier,
                    KeyActivationFailed.Throw);
            }

        }


    /// <summary>
    /// Write a description of the context to <paramref name="output"/>.
    /// </summary>
    /// <param name="output">Textwriter to write the output to.</param>
    public void DescribeContext(TextWriter output) {


        output.WriteLine($"Profile {Profile.UdfString}");
        output.WriteLine($"    Account Common {ProfileUser.AccountAddress}");
        output.WriteLine($"        Signature {ProfileUser.CommonSignature.Udf}");
        output.WriteLine($"        Authentication {ProfileUser.CommonAuthentication.Udf}");
        output.WriteLine($"        Encryption {ProfileUser.CommonEncryption.Udf}");
        output.WriteLine($"    Account Device");
        output.WriteLine($"        Signature {ConnectionAccount?.Signature?.Udf} " +
            $"Loaded = {ActivationAccount.AccountSignature != null}");
        output.WriteLine($"        Authentication {ConnectionAccount?.Authentication?.Udf}" +
            $"Loaded = {ActivationAccount.AccountAuthentication != null}");
        output.WriteLine($"        Encryption {ConnectionAccount?.Encryption?.Udf}" +
            $"Loaded = {ActivationAccount.AccountEncryption != null}");
        output.WriteLine($"    Device {ProfileDevice.UdfString} {deviceSeedId}");
        output.WriteLine($"        Signature {ProfileDevice.Signature.CryptoKey.KeyIdentifier} " +
            $"Loaded {ActivationAccount.AccountSignature != null}");
        output.WriteLine($"        Authentication {ProfileDevice.Authentication.CryptoKey.KeyIdentifier} " +
            $"Loaded {ActivationAccount.AccountAuthentication != null}");
        output.WriteLine($"        Encryption {ProfileDevice.Encryption.CryptoKey.KeyIdentifier} " +
            $"Loaded {ActivationAccount.AccountEncryption != null}");

        output.WriteLine($"Connection Device to Account {ConnectionAccount?.AuthenticationPublic.KeyIdentifier}");


        }



    #endregion
    #region // Operations requiring the Mesh Secret - Escrow, Erase.

    /// <summary>
    /// Get the MeshSecret.
    /// </summary>
    /// <exception cref="NoMeshSecret">Is thrown if the private key cannot be found.</exception>
    /// <returns>The Mesh secret bytes.</returns>
    byte[] GetMeshSecret() {
        try {
            // pull the master key
            MeshSecretSeed = KeyCollection.LocatePrivateKey(ProfileUser.UdfString) as PrivateKeyUDF;
            MeshSecretSeed.AssertNotNull(NoMeshSecret.Throw);
            // convert to byte array;
            return MeshSecretSeed.PrivateValue.FromBase32();
            }
        catch {
            throw new NoMeshSecret();
            }
        }

    /// <summary>
    /// Erase the Mesh Secret from the persistence store of this machine.
    /// </summary>
    public void EraseMeshSecret() => KeyCollection.ErasePrivateKey(ProfileUser.UdfString);

    /// <summary>
    /// Create an escrow set for the master key.
    /// </summary>
    /// <param name="shares">Number of shares to create</param>
    /// <param name="threshold">Number of shares required to recreate the quorum</param>
    /// <exception cref="NoMeshSecret">Is thrown if the private key cannot be found.</exception>
    /// <returns>The encrypted escrow entry and the key shares.</returns>
    public KeyShareSymmetric[] Escrow(int shares, int threshold) {
        var mastersecretBytes = GetMeshSecret();
        var secret = new SharedSecret(mastersecretBytes);
        return secret.Split(shares, threshold);
        }



    #endregion
    #region // Operations requiring OfflineSignatureKey - GrantAdmin, SetService


    /// <summary>
    /// Set the initial Mesh Service. This MUST be called before devices are added to the 
    /// personal mesh. This method does not support transfer of the Mesh Service.
    /// </summary>
    /// <param name="accountAddress">The account address</param>
    /// <param name="contact"></param>
    public async Task SetServiceAsync(
                string accountAddress,
                ContactPerson? contact = null) {

        KeyProfileSigners.AssertNotNull(NotSuperAdministrator.Throw);

        // Since the service does not know this account (yet)
        var credentialPrivate = new MeshKeyCredentialPrivate(
                    KeyCommonAuthentication as KeyPairAdvanced, ProfileUser.UdfString);

        MeshClient = MeshMachine.GetMeshClient(credentialPrivate, accountAddress);

        // Query the service capabilities
        var helloRequest = new HelloRequest();
        var helloResponse = await MeshClient.HelloAsync(helloRequest);
        ProfileService = helloResponse.EnvelopedProfileService.Decode();

        // Update the profile
        ProfileUser.ServiceUdf = ProfileService.UdfString;
        ProfileUser.AccountAddress = accountAddress;
        ProfileUser.Envelope(KeyProfileSigners, includeSignatureKey: true);

        ActivationCommon.BindService(ProfileService);

        // Generate a contact and self-sign
        var contact2 = CreateContact(contact: contact);
        await SetContactSelfAsync(contact2);
        }


    /// <summary>
    /// Bind to a service under the account address <paramref name="accountAddress"/>.
    /// </summary>
    /// <param name="accountAddress">The account address to bind.</param>
    public async Task BindServiceAsync(string accountAddress) {

        var envelopedBindings = MakeBindings(ProfileUser, accountAddress);

        // Request binding
        var createRequest = new BindRequest() {
            AccountAddress = accountAddress,
            EnvelopedProfileAccount = ProfileUser.GetEnvelopedProfileAccount(),
            EnvelopedCallsignBinding = envelopedBindings
            //Updates = transactUser.TransactRequest.Updates
            };

        // Attempt to register with service in question
        var response = await MeshClient.BindAccountAsync(createRequest);
        response.AssertSuccess(ServerOperationFailed.Throw);

        // Create the Access catalog here with policy allowing the service access

        //var accessEncrypt = response.AccessEncrypt;

        CatalogedMachine.EnvelopedAccountHostAssignment = response.EnvelopedAccountHostAssignment;
        var accessEncrypt = AccountHostAssignment.AccessEncrypt;

        ActivationCommon.DictionaryStoreEncryptionKey.TryGetValue(CatalogAccess.Label, out var accessSelf);

        var recipients = new List<Key> {
                    accessEncrypt.PublicParameters,
                    Key.FactoryPublic(accessSelf) };

        var policy = new DarePolicy() {
            EncryptKeys = recipients
            };
        using var store = MakeStore(CatalogAccess.Label, policy);

        LoadStores(); // Load all stores so that these are created on the service.
        await SyncProgressUploadAsync();
        }



    /// <summary>
    /// Create an administrator device entry.
    /// </summary>
    /// <param name="rights">The rights to be granted to the administrator device.</param>
    public async Task MakeAdministratorAsync(List<string> rights) {
        var transact = TransactBegin();

        CatalogedMachine.CatalogedDevice = ActivationCommon.MakeCatalogedDevice(
                ProfileDevice, ProfileUser, rights, transact, ActivationAccount,
                deviceDescription: DeviceDescription);

        // When creating a device for the first time, the update is always encrypted
        // under the device key.
        transact.CatalogUpdate(CatalogedMachine.CatalogedDevice,
                    ProfileDevice.KeyEncrypt);

        foreach (var update in transact.TransactRequest.Updates) {
            DictionaryStores.TryGetValue(update.Store, out var status).AssertTrue(NYI.Throw);
            status.Index = update.Envelopes.Count;
            }

        await transact.TransactAsync();
        }



    /// <summary>
    /// Create the stores directory and initialize catalogs.
    /// </summary>
    /// <param name="meshHost">The host context</param>
    /// <param name="profileUser">The user profile</param>
    /// <param name="activationAccount">The account activation</param>
    /// <param name="keyLocate">the key locator.</param>
    public static string CreateDirectory(
                MeshHost meshHost,
                ProfileUser profileUser,
                ActivationCommon activationAccount,
                IKeyCollection keyLocate) {
        var storesDirectory = ContextAccount.GetStoresDirectory(meshHost, profileUser);
        Directory.CreateDirectory(storesDirectory);


        // Create each of the stores and add the activation to the record.
        foreach (var entry in StaticCatalogDelegates) {

            var storeName = entry.Key;
            var factory = entry.Value;
            var policy = activationAccount.InitializeStore(storeName, keyLocate);
            if (!ServiceCatalogs.Contains(storeName)) {
                // We do not create the access store yet because we need the host key
                using var store = factory(storesDirectory, storeName, null, policy, keyCollection: keyLocate);
                }
            else {
                //keyLocate.Add (policy.)
                }
            }
        foreach (var entry in StaticSpoolDelegates) {
            var storeName = entry.Key;
            var factory = entry.Value;
            var policy = activationAccount.InitializeStore(storeName);

            using var store = factory(storesDirectory, storeName, null, policy);
            }

        return storesDirectory;
        }

    #endregion
    #region // Contact management



    /// <summary>
    /// Create a contact entry for self using the parameters specified in <paramref name="contact"/>.
    /// </summary>
    /// <param name="contact">The contact parameters.</param>
    /// <param name="localname">Short name to apply to the signed contact info</param>
    public async Task<CatalogedContact> SetContactSelfAsync(Contact contact, string localname = null) {
        KeyCommonSignature.AssertNotNull(NotAdministrator.Throw);
        contact.Envelope(KeyCommonSignature);

        contact.Sources ??= new List<TaggedSource>() { };
        var tagged = new TaggedSource() {
            LocalName = localname,
            Validation = "Self",
            EnvelopedSource = contact.EnvelopedContact
            };
        contact.Sources.Add(tagged);

        contact.Id = ProfileUser.UdfString;

        var transact = TransactBegin();
        var catalog = transact.GetCatalogContact();

        var (cataloged, success) = catalog.TryAdd(contact, true);

        if (!success) {
            cataloged.Contact = contact;
            transact.CatalogUpdate(catalog, cataloged);
            await transact.TransactAsync();
            }

        return cataloged;
        }


    #endregion


    #region // Store management and convenience accessors

    ///<inheritdoc/>
    public override Dictionary<string, StoreFactoryDelegate> DictionaryCatalogDelegates => StaticCatalogDelegates;
    static readonly Dictionary<string, StoreFactoryDelegate> StaticCatalogDelegates = new() {
            { CatalogCredential.Label, CatalogCredential.Factory },
            { CatalogContact.Label, CatalogContact.Factory },
            { CatalogTask.Label, CatalogTask.Factory },
            { CatalogBookmark.Label, CatalogBookmark.Factory },
            { CatalogNetwork.Label, CatalogNetwork.Factory },
            { CatalogApplication.Label, CatalogApplication.Factory },
            { CatalogDevice.Label, CatalogDevice.Factory },

        // All contexts have a capability catalog:
            { CatalogAccess.Label, CatalogAccess.Factory },
            { CatalogDocument.Label, CatalogDocument.Factory },
            { CatalogPublication.Label, CatalogPublication.Factory }
        };

    static readonly SortedSet<string> ServiceCatalogs = new() {
        CatalogAccess.Label,
        //CatalogPublication.Label
        };



    /// <summary>
    /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
    /// an account identifier or strong account identifier.
    /// </summary>
    /// <param name="keyId">The identifier to resolve.</param>
    /// <param name="cryptoKey">The found key </param>
    /// <returns>The identifier.</returns>
    public override bool TryFindKeyEncryption(string keyId, out CryptoKey cryptoKey) {
        if (base.TryFindKeyEncryption(keyId, out cryptoKey)) {
            return true;
            }
        cryptoKey = GetByAccountEncrypt(keyId);
        return cryptoKey != null;
        }


    /// <summary>
    /// Resolve a public key by identifier. This may be a UDF fingerprint of the key,
    /// an account identifier or strong account identifier.
    /// </summary>
    /// <param name="keyId">The identifier to resolve.</param>
    /// <param name="cryptoKey">The found key </param>
    /// <returns>The identifier.</returns>
    public override bool TryFindKeySignature(string keyId, out CryptoKey cryptoKey) {
        if (keyId == ServiceAddress) {
            cryptoKey = KeyCommonSignature;
            return true;
            }
        if (base.TryFindKeySignature(keyId, out cryptoKey)) {
            return true;
            }
        return false;
        }


    /// <summary>
    /// Attempt to obtain a recipient with identifier <paramref name="keyId"/>.
    /// </summary>
    /// <param name="keyId">The key identifier to match.</param>
    /// <param name="cryptoKey">The found key </param>
    /// <returns>The key pair if found.</returns>
    public override bool TryFindKeyDecryption(string keyId, out IKeyDecrypt cryptoKey) {


        if (KeyCollection.TryFindKeyDecryption(keyId, out cryptoKey)) {
            return true;
            }
        if (ActivationCommon?.CommonEncryptionKey?.TryFindKeyDecryption(keyId, out cryptoKey) == true) {
            return true;
            }
        CatalogContact ??= GetStore(CatalogContact.Label, create: false) as CatalogContact;
        if (CatalogContact != null) {
            return CatalogContact.TryFindKeyDecryption(keyId, out cryptoKey);
            }

        return false;
        }



    #endregion
    #region // Message Handling - Get/Process pending.

    /// <summary>
    /// Send the message <paramref name="message"/> to <paramref name="recipientAddress"/>.
    /// </summary>
    /// <param name="recipientAddress">The address to send the message to.</param>
    /// <param name="message">The message to send.</param>
    public async Task SendMessageAsync(string recipientAddress, Message message) {
        var transact = TransactBegin();
        transact.OutboundMessage(recipientAddress, message);
        await TransactAsync(transact);

        }


    ///<inheritdoc/>
    public override async Task<long> SynchronizeAsync() {
        return (await SyncPartialAsync(catalogedDeviceDigest: CatalogedMachine?.CatalogedDeviceDigest ?? "")).Processed;
        }


    /// <summary>
    /// Return the latest unprocessed MessageConnectionRequest that was received.
    /// </summary>
    /// <returns>The latest unprocessed MessageConnectionRequest</returns>
    public Message GetPendingMessageConnectionRequest() =>
        GetOpenMessageLast(AcknowledgeConnection.__Tag);

    /// <summary>
    /// Return the latest unprocessed MessageContactRequest that was received.
    /// </summary>
    /// <returns>The latest unprocessed MessageContactRequest</returns>
    public Message GetPendingMessageContactRequest() =>
        GetOpenMessageLast(MessageContact.__Tag);


    /// <summary>
    /// Return the latest unprocessed MessageConfirmationRequest that was received.
    /// </summary>
    /// <returns>The latest unprocessed MessageConfirmationRequest</returns>
    public Message GetPendingMessageConfirmationRequest() =>
        GetOpenMessageLast(RequestConfirmation.__Tag);

    /// <summary>
    /// Return the latest unprocessed MessageConfirmationResponse that was received.
    /// </summary>
    /// <returns>The latest unprocessed MessageConfirmationResponse</returns>
    public Message GetPendingMessageConfirmationResponse() =>
        GetOpenMessageLast(ResponseConfirmation.__Tag);


    /// <summary>
    /// Return the list of open messages.
    /// </summary>
    ///<param name="tag">If not null, return only messages of this type.</param>
    /// <returns>The list of messages.</returns>
    public List<Message> GetOpenMessages(
                    string tag = null) {
        // get the inbound spool
        var inbound = GetSpoolInbound();
        var messages = new List<Message>();
        foreach (var index in inbound.GetMessages()) {
            if (index.HasPayload & (
                    tag == null || index.MessageType == tag)) {
                var meshMessage = index.Message;
                if (meshMessage != null) {
                    messages.Add(meshMessage);
                    }
                }
            }
        return messages;
        }

    /// <summary>
    /// Return the last open message received.
    /// </summary>
    /// <param name="tag">If not null, return the last message received of this type.</param>
    /// <returns>The message (if found).</returns>
    public Message GetOpenMessageLast(
                string tag = null) {
        // get the inbound spool
        var inbound = GetSpoolInbound();
        var messages = new List<Message>();
        foreach (var index in inbound.GetMessages()) {
            if (tag == null || index.MessageType == tag) {
                return index.Message;

                }
            }
        return null;
        }

    /// <summary>
    /// Attempt to return a message received in response to the request message 
    /// <paramref name="request"/>. If successful, returns true and the response message
    /// in <paramref name="response"/>. Otherwise the value false is returned.
    /// </summary>
    /// <param name="request">The request message.</param>
    /// <param name="response">The response (if found).</param>
    /// <returns>True if found, otherwise false.</returns>
    public bool TryGetMessageResponse(
                Message request,
                out SpoolIndexEntry response) {

        var responseId = request.GetResponseId();
        DateTime? notBefore = request?.DareEnvelope?.Header?.ContentMeta?.Created;

        return TryGetMessageByMessageId(responseId, out response, notBefore);

        }

    /// <summary>
    /// Attempt to return a message received with message ID  
    /// <paramref name="messageID"/>. If successful, returns true and the response message
    /// in <paramref name="index"/>. Otherwise the value false is returned.
    /// </summary>
    /// <param name="messageID">The request message.</param>
    /// <param name="index">The message (if found).</param>
    /// <param name="notBefore">If found, only return a message if received after 
    /// this date. This may be used to bound searching for a response message by only
    /// looking at messages after the request was sent.</param>
    /// <returns>True if found, otherwise false.</returns>
    public bool TryGetMessageByMessageId(
                string messageID, out SpoolIndexEntry index,
                DateTime? notBefore = null) {
        notBefore.Future();
        var inbound = GetSpoolInbound();
        index = inbound.GetByMessageId(messageID);
        return index != null;
        }







    #endregion
    #region // Group operations

    /// <summary>
    /// Create a threshold encryption group.
    /// </summary>
    /// <param name="groupAddress">Name of the group to create.</param>
    /// <param name="accountSeed">Specifies the secret seed and algorithms used to generate private keys.</param>
    /// <param name="roles">List of rights to be granted.</param>
    /// <param name="cover">Specifies HTML content containing a default cover page.</param>
    /// <param name="groupName">Friendly name for the group.</param>
    /// <returns></returns>

    public async Task<ContextGroup> CreateGroupAsync(
                    string groupAddress,
                    string groupName,
                    PrivateKeyUDF accountSeed = null,
                    List<string> roles = null,
                    byte[] cover = null
                    ) {

        // create the cataloged group
        accountSeed ??= new PrivateKeyUDF(udfAlgorithmIdentifier: UdfAlgorithmIdentifier.MeshProfileAccount);

        var keyCollectionGroup = new KeyCollectionEphemeral();

        // Phase3: Work out a better way to manage the activation seed for groups
        var activationGroup = new ActivationCommon(keyCollectionGroup, accountSeed) {
            ActivationKey = accountSeed.PrivateValue
            };

        var profileGroup = ProfileGroup.Generate(groupAddress, activationGroup);    
        profileGroup.Cover = cover;
           

        // Check that the profile is valid before using it.
        profileGroup.Validate();


        // When we move to using thresholded keys, this needs to be modified
        // so that the activation for the cataloged group is saved under the 
        // account escrow key.

        var catalogedGroup = new CatalogedGroup(profileGroup,
            activationGroup, KeyCommonEncryption) {
            Grant = roles
            };


        var envelopedBindings = MakeBindings(profileGroup, groupAddress);

        // here we request creation of the group at the service.
        var createRequest = new BindRequest() {
            AccountAddress = groupAddress,
            EnvelopedProfileAccount = profileGroup.GetEnvelopedProfileAccount(),
            EnvelopedCallsignBinding = envelopedBindings
            };


        // Since the service does not know this account (yet)
        var credentialPrivate = new MeshKeyCredentialPrivate(
                    activationGroup.CommonAuthenticationKey as KeyPairAdvanced, profileGroup.UdfString);

        var groupClient = MeshMachine.GetMeshClient(credentialPrivate, groupAddress);


        var createResponse = await groupClient.BindAccountAsync(createRequest);
        createResponse.AssertSuccess();

        // create the group context
        var contextGroup = await ContextGroup.CreateGroup(this, catalogedGroup, activationGroup, groupClient);
        contextGroup.MeshClient = groupClient;


        var contact = contextGroup.CreateContact();

        // Commit all changes to the administrator context in a single transaction.
        using (var transaction = TransactBegin()) {
            // Add the group to the application catalog
            transaction.ApplicationCreate(catalogedGroup);
            var catalogAccess = transaction.GetCatalogAccess();

            // Create a contact for the group and add to the contact catalog
            var contactCatalog = transaction.GetCatalogContact();
            var catalogedContact = new CatalogedContact(contact);
            transaction.CatalogUpdate(contactCatalog, catalogedContact);

            await transaction.TransactAsync();
            }

        return contextGroup;
        }

    /// <summary>
    /// Escrow the seed from which an account is derrived. This is attached to the 
    /// user context to allow future implementations to support alternative or
    /// additional escrow policies. Keys might be escrowed under the account escrow
    /// and also escrow administrator keys to allow closer control.
    /// </summary>
    /// <param name="keyDatas">The keys to be escrowed.</param>
    public List<Enveloped<KeyData>> EscrowSeed(
                    params KeyData[] keyDatas) {
        var result = new List<Enveloped<KeyData>>();

        foreach (var keyData in keyDatas) {
            var enveloped = new Enveloped<KeyData>(
                    keyData, encryptionKey: ProfileUser.EscrowEncryptionKey);
            result.Add(enveloped);
            }
        return result;
        }


    /// <summary>
    /// Get a managment context for the group <paramref name="groupAddress"/>.
    /// </summary>
    /// <param name="groupAddress">The group to return the management context for.</param>
    /// <returns>The created management context.</returns>
    public ContextGroup GetContextGroup(string groupAddress) {

        // read through the entries in CatalogApplication
        var catalog = GetStore(CatalogApplication.Label) as CatalogApplication;
        var entry = catalog.LocateGroup(groupAddress);

        return GetContextGroup(entry);
        }

    /// <summary>
    /// Get a managment context for the group <paramref name="entry"/>.
    /// </summary>
    /// <param name="entry">The group to return the management context for.</param>
    /// <returns>The created management context.</returns>
    public ContextGroup GetContextGroup(CatalogedGroup entry) {
        // BUG!!! Should be the UDF of the group.
        var groupAddress = entry.ProfileGroup.AccountAddress;

        // get the Application entry here.
        var applicationEntry = GetApplicationEntryGroup(groupAddress);
        applicationEntry.AssertNotNull(GroupNotFound.Throw, groupAddress);

        // Get the activation from the entry
        var activationAccount = applicationEntry.GetActivationAccount();

        // construct the group context
        // We do not attempt to get admin privs here, we will do that if necessary.
        return new ContextGroup(this, entry, activationAccount);
        }

    #endregion
    #region // Device connection


    /// <summary>
    /// Convenience wrapper for <see cref="CreateDeviceEarlAsync"/>. Generates a device profile
    /// and writes the <see cref="DevicePreconfigurationPrivate"/> data to a file in the directory
    /// specified by <paramref name="path"/>.
    /// </summary>
    /// <param name="path">Path to write the configuration file to.</param>
    /// <param name="bits">Work factor of the connection secret in bits.</param>
    /// <returns>The public and private configuration instances.</returns>
    public DevicePreconfiguration Preconfigure(
                string path = "",
                int bits = 120) {

        var preconfiguration = CreateDeviceEarlAsync(bitsPin: bits).Sync();

        var filename = Path.Combine(path, preconfiguration.ConnectKey + ".medk");

        var devicePreconfigurationPrivate = new DevicePreconfigurationPrivate() {
            PrivateKey = preconfiguration.SecretSeed,
            ConnectUri = preconfiguration.ConnectUri,
            EnvelopedProfileDevice = preconfiguration.ProfileDevice.GetEnvelopedProfileDevice(),
            EnvelopedConnectionDevice = preconfiguration.ConnectionDevice.GetEnvelopedConnectionDevice(),
            EnvelopedConnectionService = preconfiguration.ConnectionService.GetEnvelopedConnectionService()
            };
        devicePreconfigurationPrivate.ToFile(filename, tagged: true);

        var devicePreconfigurationPublic = new DevicePreconfigurationPublic() {
            EnvelopedProfileDevice = preconfiguration.ProfileDevice.GetEnvelopedProfileDevice()
            };


        preconfiguration.DevicePreconfigurationPublic = devicePreconfigurationPublic;
        preconfiguration.DevicePreconfigurationPrivate = devicePreconfigurationPrivate;
        preconfiguration.Filename = filename;

        return preconfiguration;
        }


    /// <summary>
    /// Create an EARL for a device, publish the result to the Mesh service and return 
    /// the device preconfiguration parameters. 
    /// </summary>
    /// <param name="algorithmEncrypt">The encryption algorithm.</param>
    /// <param name="algorithmSign">The signature algorithm</param>
    /// <param name="algorithmAuthenticate">The signature algorithm</param>
    /// <param name="secret">The master secret.</param>
    /// <param name="bitsSecret">Work factor of the master secret in bits.</param>
    /// <param name="bitsPin">The size of secret to generate in bits/</param>
    /// <returns>Response from the server.</returns>
    public async Task<DevicePreconfiguration> CreateDeviceEarlAsync(
                CryptoAlgorithmId algorithmEncrypt = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmSign = CryptoAlgorithmId.Default,
                CryptoAlgorithmId algorithmAuthenticate = CryptoAlgorithmId.Default,
                byte[] secret = null,
                int bitsPin = 256,
                int bitsSecret = 256
                ) {

        // an invitation consists of a uri of the form:
        // mmm://q@example.org/NQED-5C35-WSBQ-OBHW-ENBI-XOZF


        var secretSeed = new PrivateKeyUDF(
            udfAlgorithmIdentifier: UdfAlgorithmIdentifier.MeshProfileDevice, secret: secret, algorithmEncrypt: algorithmEncrypt,
            algorithmSign: algorithmSign, algorithmAuthenticate: algorithmAuthenticate, bits: bitsSecret);


        var pin = MeshUri.GetConnectPin(secretSeed, ServiceAddress, length: bitsPin);

        var key = new CryptoKeySymmetric(pin);

        var connectURI = MeshUri.ConnectUriDevice(ServiceAddress, pin);

        // Create a device profile 
        var profileDevice = ProfileDevice.Generate(secretSeed);

        // Create and sign the connection
        var connectionService = new ConnectionService() {
            Authentication = profileDevice.Encryption
            };
        connectionService.Envelope(KeyAdministratorSign);

        var connectionDevice = new ConnectionDevice() {
            Signature = profileDevice.Signature,
            Encryption = profileDevice.Encryption,
            Authentication = profileDevice.Encryption
            };
        connectionDevice.Envelope(KeyAdministratorSign);

        // Convert the enveloped profile device to a binary field and take the envelope
        // of that.
        var plaintext = profileDevice.DareEnvelope.GetBytes();
        var encryptedProfileDevice = DareEnvelope.Encode((byte[])plaintext, encryptionKey: key);
        var catalogedPublication = new CatalogedPublication(pin) {
            EnvelopedData = encryptedProfileDevice,
            };


        // commit the transaction
        var transactPublication = TransactBegin();
        var catalogPublication = transactPublication.GetCatalogPublication();
        transactPublication.CatalogUpdate(catalogPublication, catalogedPublication);
        await transactPublication.TransactAsync();

        return new DevicePreconfiguration(
            secretSeed, profileDevice, connectionService, connectionDevice, pin, connectURI);
        }


    /// <summary>
    /// Attempt device connection by means of the static URI <paramref name="uri"/>.
    /// </summary>
    /// <param name="uri">The connection URI</param>
    /// <param name="rights">The list of rights being requested by the device.</param>
    /// <returns>The </returns>
    /// <param name="localName"></param>
    public async Task<CatalogedDevice> ConnectStaticUriAsync(string uri, List<string> rights = null, string localName = null) {

        var envelopedProfileDevice = ClaimPublication(uri, out var responseId);

        // Decode the Profile Device
        var profileDevice = ProfileDevice.Decode(envelopedProfileDevice);
        var deviceEncrypt = profileDevice.Encryption.GetKeyPair();

        // Approve the request
        // Have to add in the Mesh profile here and Account Assertion
        var transact = TransactBegin();
        var cataloguedDevice = ActivationCommon.MakeCatalogedDevice(profileDevice,
                ProfileUser, transactContextAccount: transact, roles: rights);



        //Console.WriteLine($"Accept connection ID is {responseId}");
        var respondConnection = new RespondConnection() {
            MessageId = responseId,
            CatalogedDevice = cataloguedDevice,
            Result = MeshConstants.TransactionResultAccept
            };

        // Transactional update.

        transact.LocalMessage(respondConnection, deviceEncrypt);

        // When creating a device for the first time, the update is always encrypted
        // under the device key.
        // Phase2: Consider introducing an additional blinding key
        transact.CatalogUpdate(cataloguedDevice, profileDevice.KeyEncrypt);


        //var catalogDevice = transact.GetCatalogDevice();
        //transact.CatalogUpdate(catalogDevice, cataloguedDevice);
        await transact.TransactAsync();

        //SendMessage(respondConnection);


        // ContextMeshPending
        return cataloguedDevice;
        }

    /// <summary>
    /// Delete the device <paramref name="id"/> from the device catalog.
    /// </summary>
    /// <param name="id">Identifier of the device to remove.</param>
    public async Task DeleteDeviceAsync(string id) {
        var transact = TransactBegin();
        var catalogDevice = transact.GetCatalogDevice();

        var deviceEntry = catalogDevice.Locate(id);

        var catalogAccess = transact.GetCatalogAccess();
        //var authenticationI = 

        var accessCapability = new CatalogedAccess() {
            Capability = new AccessCapability() {
                Id = deviceEntry.ConnectionDevice.AuthenticationPublic.KeyIdentifier,
                Active = false
                }
            };
        transact.CatalogUpdate(catalogAccess, accessCapability);



        foreach (var entry in catalogAccess.GetEntries) {
            if (entry.Capability is CryptographicCapability cryptographicCapability) {
                if (cryptographicCapability.GranteeUdf ==
                        deviceEntry.ConnectionDevice.AuthenticationPublic.KeyIdentifier) {

                    var cryptoCapability = new CatalogedAccess() {
                        Capability = new NullCapability() {
                            Id = cryptographicCapability.Id,
                            Active = false
                            }
                        };
                    transact.CatalogUpdate(catalogAccess, cryptoCapability);
                    }
                }


            }

        transact.CatalogDelete(catalogDevice, deviceEntry);
        await transact.TransactAsync();
        }


    #endregion
    #region // Claim publication
    /// <summary>
    /// Claim the document published at the EARL <paramref name="uri"/>.
    /// </summary>
    /// <param name="uri">The EARL to resolve</param>
    /// <param name="responseId">The response from the service.</param>
    /// <returns>The recovered envelope.</returns>
    public DareEnvelope ClaimPublication(string uri, out string responseId) {
        (var targetAccountAddress, var pin) = MeshUri.ParseConnectUri(uri);

        var key = new CryptoKeySymmetricSigner(pin);
        var messageClaim = new MessageClaim(targetAccountAddress, ServiceAddress, pin);

        messageClaim.Envelope(KeyCommonSignature);


        var claimClient = MeshMachine.GetMeshClient(
                        GetMeshCredentialPrivate(), targetAccountAddress);

        // make claim request to service managing the device
        var claimRequest = new ClaimRequest {
            EnvelopedMessageClaim = messageClaim.GetEnvelopedMessageClaim()
            };

        var claimResponse = claimClient.Claim(claimRequest);

        // The Dare envelope contains a DareEnvelope<ProfileDevice>
        var encryptedEnvelope = claimResponse.CatalogedPublication.EnvelopedData;

        // Verify: if the key is a encrypt/sign, need to verify here.
        "If the key is a encrypt/sign, need to verify here.".TaskValidate();

        var result = encryptedEnvelope.DecodeJsonObject(key) as DareEnvelope;

        responseId = messageClaim.GetResponseId();

        return result;
        }
    #endregion
    #region // Processing

    /// <summary>
    /// Process automatic actions.
    /// </summary>
    /// <returns>The results of the automatic processing attempted.</returns>
    public async Task<List<ProcessResult>> ProcessAutomaticsAsync() {
        var results = new List<ProcessResult>();

        var spoolInbound = GetSpoolInbound();
        foreach (var spoolEntry in spoolInbound.GetMessages(open: true)) {
            var meshMessage = spoolEntry.Message;
            Logger.GotMessage(meshMessage?.GetType().ToString(), meshMessage?.MessageId, spoolEntry.MessageStatus);

            if (spoolEntry.IsOpen) {
                switch (meshMessage) {
                    case AcknowledgeConnection acknowledgeConnection: {
                        if (acknowledgeConnection.MessageConnectionRequest.PinId != null) {
                            results.Add(await ProcessAutomaticAsync(acknowledgeConnection));
                            }
                        break;
                        }
                    case MessageContact replyContact: {
                        results.Add(await ProcessAutomaticAsync(replyContact));
                        break;
                        }
                    case GroupInvitation groupInvitation: {
                        results.Add(await ProcessAutomaticAsync(groupInvitation));
                        break;
                        }
                    default: {

                        // need to add in a mechanism to hook this so that we can process the message type.

                        break;
                        }
                    }
                }
            }

        return results;
        }



    /// <summary>
    /// Perform automatic processing of the message <paramref name="request"/>.
    /// </summary>
    /// <param name="request">Reply to contact request to be processed.</param>
    /// <param name="accept">Accept the requested action.</param>
    /// <param name="authorize">If true, the action is explicitly authorized.</param>
    /// <returns>The result of requesting the connection.</returns>
    public async Task<ProcessResult> ProcessAutomaticAsync(
                    GroupInvitation request,
                    bool accept = true,
                    bool authorize = false) {
        if (!Privileges.Contains(CatalogContact.Label)) {
            return new InsufficientAuthorization(request);
            }

        authorize.Future();

        if (!accept) {
            return new ResultRefused(request);
            }

        if (request.Contact == null) {
            return new ProcessResultError(request, ProcessingResult.ContactInvalid);
            }

        var transaction = TransactBegin();
        var catalogContact = transaction.GetCatalogContact();

        transaction.CatalogUpdate(catalogContact, request.Contact);
        transaction.InboundComplete(StateSpoolMessage.Closed, request);
        await transaction.TransactAsync();

        return new ResultGroupInvitation(request);
        }



    /// <summary>
    /// Perform automatic processing of the message <paramref name="request"/>.
    /// </summary>
    /// <param name="request">Connection request to be processed.</param>
    /// <returns>The result of requesting the connection.</returns>
    public async Task<ProcessResult> ProcessAutomaticAsync(AcknowledgeConnection request) {
        if (!IsAdministrator || !Privileges.Contains(CatalogDevice.Label)) {
            return new InsufficientAuthorization(request);
            }

        var messageConnectionRequest = request.MessageConnectionRequest;

        // get the pin value here
        var messagePin = GetMessagePIN(messageConnectionRequest.PinId);

        var pinStatus = MessagePin.ValidatePin(messagePin,
                ServiceAddress,
                messageConnectionRequest.AuthenticatedData,
                messageConnectionRequest.ClientNonce,
                messageConnectionRequest.PinWitness);

        if (pinStatus != ProcessingResult.Success) {
            return new ProcessResultError(request, pinStatus, messagePin);
            }

        return await ProcessAsync(request, true, messagePin);
        }

    /// <summary>
    /// Accept or reject a connection request.
    /// </summary>
    /// <param name="request">The request to accept or reject.</param>
    /// <param name="accept">If true, accept the request. Otherwise, it is rejected.</param>
    /// <param name="rights">The list of rights to be granted to the device.</param>
    /// <param name="messagePin">The PIN value to be used to authenticate the regquest.</param>
    /// <returns>The result of processing.</returns>
    async Task<ProcessResult> ProcessAsync(AcknowledgeConnection request, bool accept = true, MessagePin messagePin = null,
           List<string> rights = null) {


        //Console.WriteLine($"Process connection request {request.MessageId}");

        rights ??= messagePin?.Roles;
        var transaction = TransactBegin();

        var respondConnection = new RespondConnection() {
            MessageId = request.GetResponseId()
            };
        if (accept) {
            // Connect the device to the Mesh
            AddDevice(request, rights, transaction, respondConnection);

            }
        else {
            respondConnection.Result = MeshConstants.TransactionResultReject;
            }

        var deviceEncrypt = request.MessageConnectionRequest.ProfileDevice.Encryption.GetKeyPair();

        //Console.WriteLine($"Make response message {respondConnection.MessageId}");

        transaction.InboundComplete(StateSpoolMessage.Closed, request, respondConnection);
        transaction.LocalMessage(respondConnection, deviceEncrypt);

        // Mark the pin code as having been used.
        if (messagePin != null) {
            transaction.LocalComplete(StateSpoolMessage.Closed,
                messagePin, respondConnection);
            }

        // Perform the transaction
        var responseTransaction = await transaction.TransactAsync();

        return new ResultAcknowledgeConnection(request, messagePin, responseTransaction);
        }

    private void AddDevice(AcknowledgeConnection request, List<string> rights, TransactUser transact, RespondConnection respondConnection) {

        var device = ActivationCommon.MakeCatalogedDevice(
                request.MessageConnectionRequest.ProfileDevice, ProfileUser, roles: rights, transactContextAccount: transact);

        device.ApplicationEntries = MakeApplicationEntries(rights, transact, device);
        respondConnection.CatalogedDevice = device;
        respondConnection.Result = MeshConstants.TransactionResultAccept;


        // When creating a device for the first time, the update is always encrypted
        // under the device key.
        transact.CatalogUpdate(device, ProfileDevice.KeyEncrypt);
        }

    /// <summary>
    /// Create a list of application entries.
    /// </summary>
    /// <param name="roles">The roles under which the application entries are to be
    /// granted.</param>
    /// <param name="transactRequest">The transaction under which catalog updates are to be added.</param>
    /// <param name="catalogedDevice">The device entry.</param>
    /// <returns>The list of application entries.</returns>
    public List<ApplicationEntry> MakeApplicationEntries(
        List<string> roles,
        TransactUser transactRequest,
        CatalogedDevice catalogedDevice
        ) {

        var catalogApplication = transactRequest.GetCatalogApplication();
        if (catalogApplication == null) {
            return null;
            }
        List<ApplicationEntry> result = null;

        foreach (var application in catalogApplication.GetEntries) {


            if (!application.Deny.Intersects(roles) &&
                application.Grant.Intersects(roles)) {

                application.Activate(ApplicationEntries, ProfileDevice, this);

                result ??= new();
                result.Add(application.GetActivation(catalogedDevice));
                }
            }

        return result;
        }


    /// <summary>
    /// Generalized processing loop for messages
    /// </summary>
    /// <param name="messageId">Identifier of the message to process.</param>
    /// <param name="accept">If true, accept the request, otherwise reject it.</param>
    /// <param name="reciprocate">If true, reciprocate the response: e.g. return user's own
    /// contact information in response to an initial contact request.</param>
    /// <returns></returns>
    public async Task<ProcessResult> ProcessAsync(string messageId, bool accept = true, bool reciprocate = true) {
        TryGetMessageByMessageId(messageId, out var index).AssertTrue(MessageIdNotFound.Throw);
        index.IsOpen.AssertTrue(NYI.Throw); // make a better response for already done.

        return await ProcessAsync(index.Message, accept, reciprocate);

        }

    /// <summary>
    /// Generalized processing loop for messages
    /// </summary>
    /// <param name="meshMessage">The message to process.</param>
    /// <param name="accept">If true, accept the request, otherwise reject it.</param>
    /// <param name="reciprocate">If true, reciprocate the response: e.g. return user's own
    /// contact information in response to an initial contact request.</param>
    /// <param name="roles">The list of rights to be granted to the device.</param>
    /// <returns>The result of processing.</returns>
    public async Task<ProcessResult> ProcessAsync(Message meshMessage, bool accept = true, bool reciprocate = true,
                List<string> roles = null) {
        "Merge this processing loop with the other processing loop".TaskFunctionality();
        reciprocate.Future();

        switch (meshMessage) {
            case AcknowledgeConnection connection: {
                return await ProcessAsync(connection, accept, rights: roles);
                }
            case MessageContact requestContact: {
                return await ContactReplyAsync(requestContact, accept);
                }

            case RequestConfirmation requestConfirmation: {
                return await ConfirmationResponseAsync(requestConfirmation, accept);
                }
            case ResponseConfirmation responseConfirmation: {
                responseConfirmation.Future();
                break;
                }
            case RequestTask requestTask: {
                requestTask.Future();
                break;
                }
            case GroupInvitation groupInvitation: {
                groupInvitation.Future();
                break;
                }

            default: {
                if (ProcessDictionary.TryGetValue(meshMessage.GetType(), out var messageDelegate)) {
                    return await messageDelegate(this, meshMessage, accept, reciprocate, roles);
                    }
                return new ProcessResultNotSupported() {
                    MessageId = meshMessage.MessageId,
                    Sender = meshMessage.Sender,
                    Recipient = meshMessage.Recipient,
                    ErrorReport = $"Message type {meshMessage._Tag} not supported",
                    Success = false
                    };

                }
            }


        return null;
        }

    /// <summary>
    /// Make a contact reply.
    /// </summary>
    /// <param name="requestContact">The contact request.</param>
    /// <param name="accept">If true, enter the contact data from <paramref name="requestContact.Self"/>
    /// in the contact catalog.</param>
    /// <param name="localname">Local name to be used to identify the contact recorded in
    /// the catalog.</param>
    public async Task<ProcessResult> ContactReplyAsync(
            MessageContact requestContact,
            bool accept,
            string localname = null) {

        // Do nothing if the request is rejected.
        if (!accept) {
            using var transaction = TransactBegin();
            transaction.InboundComplete(StateSpoolMessage.Closed, requestContact);
            await transaction.TransactAsync();

            return new ResultMessageContact(requestContact, null);
            }

        // Add the requestContact.Self contact to the catalog
        if (requestContact.AuthenticatedData != null) {
            var contact = MeshItem.Decode(requestContact.AuthenticatedData) as Contact;
            var cataloged = contact.CatalogedContact();

            using var transaction = TransactBegin();
            var catalog = transaction.GetCatalogContact();

            transaction.CatalogUpdate(catalog, cataloged);
            transaction.InboundComplete(StateSpoolMessage.Closed, requestContact);
            await transaction.TransactAsync();
            }

        // Get the reply (if required)
        var reply = requestContact.Reply == true ?
            await ContactRequestAsync(requestContact.Sender, requestContact.PIN, localname, false) : null;

        return new ResultMessageContact(requestContact, reply);
        }

    /// <summary>
    /// Perform automatic processing of the message <paramref name="request"/>.
    /// </summary>
    /// <param name="request">Reply to contact request to be processed.</param>
    /// <param name="authorize">If true, the action is explicitly authorized.</param>
    /// <returns>The result of requesting the connection.</returns>
    public async Task<ProcessResult> ProcessAutomaticAsync(
                MessageContact request,
                bool authorize = false) {

        if (!Privileges.Contains(CatalogContact.Label)) {
            return new InsufficientAuthorization(request);
            }


        // No pin specified? Request is not automatic.
        if (request.PinId == null) {
            return new InsufficientAuthorization(request);
            }

        // check response pin here 
        var messagePin = GetMessagePIN(request.PinId);

        // check the pin value
        var pinStatus = request.ValidatePin(messagePin, ServiceAddress);
        if (pinStatus != ProcessingResult.Success) {
            return new ProcessResultError(request, pinStatus, messagePin);
            }

        // check that the pin is automatic or request is explicitly authorized.
        if (!(messagePin.Automatic == true | authorize)) {
            return new InsufficientAuthorization(request);
            }

        return await ContactReplyAsync(request, true);
        }




    #endregion
    #region // ContactManagement

    /// <summary>
    /// Get the user's own contact. There is only ever one contact entry but there MAY
    /// be multiple envelopes 
    /// </summary>
    /// <param name="localName">Local name for the contact</param>
    /// <returns></returns>
    public Enveloped<Contact> GetSelf(string localName) {
        var self = GetContact(ProfileUser.UdfString);

        foreach (var tagged in self.Contact.Sources) {
            if (tagged.EnvelopedSource == null) {
                // skip entries that don't have an enveloped source.
                }
            else if (localName == null || tagged.LocalName == localName) {
                return tagged.EnvelopedSource;
                }
            }

        throw new NYI();
        }



    /// <summary>
    /// Construct a contact fetch URI.
    /// </summary>
    /// <param name="localName">Local name for the contact</param>
    /// <param name="expire">Expiry time for the corresponding PIN</param>
    /// <param name="automatic">If true, presentation of the pin code is sufficient
    /// to authenticate and authorize the action.</param>
    public async Task<string> ContactUri(bool automatic, System.DateTime? expire, string localName = null) {
        var envelope = GetSelf(localName);
        var combinedKey = new CryptoKeySymmetricSigner();

        var pin = combinedKey.SecretKey;

        // Add a signature under the signature key.
        var encryptedContact = DareEnvelope.Encode(envelope.GetBytes(),
                signingKey: combinedKey, encryptionKey: combinedKey);

        // publish the enveloped contact to the service.
        var catalogedPublication = new CatalogedPublication(pin) {
            EnvelopedData = encryptedContact,
            NotOnOrAfter = expire
            };

        // Register the pin
        var messageConnectionPIN = new MessagePin(
            pin, automatic, expire, ServiceAddress, MeshConstants.MessagePINActionContact);

        using (var transaction = TransactBegin()) {
            transaction.LocalMessage(messageConnectionPIN, KeyCommonEncryption);
            var catalogPublication = transaction.GetCatalogPublication();
            transaction.CatalogUpdate(catalogPublication, catalogedPublication);
            await transaction.TransactAsync();
            }

        // return the contact address
        return MeshUri.ConnectUriDevice(ServiceAddress, pin);
        }


    /// <summary>
    /// Construct a contact request.
    /// </summary>
    /// <param name="recipient">The contact to request.</param>
    /// <param name="pin">Optional pin value used to authenticate a response.</param>
    /// <param name="localname">Local name for the contact</param>
    /// <param name="reply">if true, request return of the recpients contact info in reply.</param>
    /// <param name="message">Optional message to explain the request.</param>
    public async Task<MessageContact> ContactRequestAsync(string recipient,
                    string pin = null,
                    string localname = null,
                    bool reply = true,
                    string message = null) {

        // process the recipient to get the service, unless known.

        CryptoKey recipientEncryptionKey = null;

        var addressType = recipient.SplitAccountAddress(out var service, out var account);
        switch (addressType) {
            case AddressType.Callsign: {
                var binding = await TryResolveCallsignAsync(account);
                binding.AssertNotNull(NYI.Throw);
                recipient = binding.GetMeshAccount();
                recipientEncryptionKey = binding.GetEncryptionKey();
                break;
                }
            case AddressType.AccountAtDns: {
                TryFindKeyEncryption(recipient, out recipientEncryptionKey);
                break;
                }
            }

        var contactSelf = GetSelf(localname);

        //"agh... not creating the pin code for the response here.".TaskFunctionality(true);

        var contactMessage = new MessageContact() {
            Recipient = recipient,
            Subject = recipient,
            AuthenticatedData = contactSelf,
            Reply = reply

            };

        using (var transaction = TransactBegin()) {

            // If we are requesting a reply, add a PIN code.
            if (reply) {
                var messagePin = await GetPinAsync(MeshConstants.MessagePINActionContact, true,
                    128, register: false);
                contactMessage.PIN = messagePin.Pin;
                transaction.LocalMessage(messagePin, KeyCommonEncryption);
                }

            // If a PIN value was specified in the request, use it to authenticate the response.
            contactMessage.Authenticate(pin);

            // send it to the service
            transaction.OutboundMessage(recipient, recipientEncryptionKey, contactMessage);
            await transaction.TransactAsync();
            }

        return contactMessage;
        }






    /// <summary>
    /// Fetch contact data referenced by the URI <paramref name="uri"/>. If <paramref name="reciprocate"/>
    /// is true, send own contact data.
    /// </summary>
    /// <param name="uri">The URI to resolve.</param>
    /// <param name="reciprocate">If true send own contact data.</param>
    /// <param name="localname">Local name for the contact to send in exchange</param>
    /// <returns>The cataloged contact information including the response message (if sent).</returns>
    public async Task<CatalogedContact> ContactExchange(
                string uri,
                bool reciprocate,
                string localname = null) {
        // Fetch, verify and decrypt the corresponding data.

        var envelope = ClaimPublication(uri, out var _);

        // Add to the catalog

        var contact = MeshItem.Decode(envelope) as Contact;
        var cataloged = contact.CatalogedContact();

        var transaction = TransactBegin();
        var catalog = transaction.GetCatalogContact();
        transaction.CatalogUpdate(catalog, cataloged);
        await transaction.TransactAsync();

        if (reciprocate) {
            (var targetAccountAddress, var pin) = MeshUri.ParseConnectUri(uri);
            cataloged.Message = await ContactRequestAsync(targetAccountAddress, pin, localname) as Message;
            }


        return cataloged;
        }
    #endregion
    #region // Confirmation Processing

    /// <summary>
    /// Construct a confirmation request.
    /// </summary>
    /// <param name="recipientAddress">The contact to request.</param>
    /// <param name="messageText">The message text to send.</param>
    public async Task<RequestConfirmation> ConfirmationRequestAsync(string recipientAddress, string messageText) {
        // prepare the contact request

        var message = new RequestConfirmation() {
            Recipient = recipientAddress,
            Text = messageText
            };

        await SendMessageAsync(recipientAddress, message);


        // send it to the service
        return message;
        }


    /// <summary>
    /// Make a confirmation reply.
    /// </summary>
    /// <param name="requestConfirmation">The request received.</param>
    /// <param name="response">If true, accept the confirmation request, otherwise reject.</param>
    public async Task<ProcessResult> ConfirmationResponseAsync(RequestConfirmation requestConfirmation, bool response) {
        // prepare the contact request

        var recipientAddress = requestConfirmation.Sender;
        //Console.WriteLine(
        //$"Message is {requestConfirmation.MessageId}, response will be {requestConfirmation.GetResponseId()}");


        var message = new ResponseConfirmation() {
            MessageId = requestConfirmation.GetResponseId(),
            Recipient = recipientAddress,
            Accept = response,
            Request = requestConfirmation.GetEnvelopedRequestConfirmation()

            };

        var transact = TransactBegin();
        transact.OutboundMessage(recipientAddress, message);
        await transact.TransactAsync();

        // send it to the service
        return null;
        }



    #region // Convenience methods for Contacts catalog

    /// <summary>
    /// Return the application with identifier <paramref name="key"/>.
    /// </summary>
    /// <param name="key">specifies the identifier to return.</param>
    /// <returns>The contact, if found. Otherwise null.</returns>
    public CatalogedApplication GetApplication(string key) =>
        (GetStore(CatalogApplication.Label) as CatalogApplication).Get(key);



    /// <summary>
    /// Return the application with identifier <paramref name="key"/>.
    /// </summary>
    /// <param name="key">specifies the identifier to return.</param>
    /// <returns>The contact, if found. Otherwise null.</returns>
    public T GetApplication<T>(string? key)
                where T : CatalogedApplication {
        if (key == null) {
            var result = (GetStore(CatalogApplication.Label) as CatalogApplication).GetDefault<T>();
            return result;


            }
        return (GetStore(CatalogApplication.Label) as CatalogApplication).Get(key) as T;
        }

    /// <summary>
    /// Return the device with identifier <paramref name="key"/>.
    /// </summary>
    /// <param name="key">specifies the identifier to return.</param>
    /// <returns>The device, if found. Otherwise null.</returns>
    public CatalogedDevice GetDevice(string key) =>
        (GetStore(CatalogDevice.Label) as CatalogDevice).Get(key);

    /// <summary>
    /// Return the contact with identifier <paramref name="key"/>.
    /// </summary>
    /// <param name="key">specifies the identifier to return.</param>
    /// <returns>The contact, if found. Otherwise null.</returns>
    public CatalogedContact GetContact(string key) =>
        (GetStore(CatalogContact.Label) as CatalogContact).Get(key);

    /// <summary>
    /// Return the credential with identifier <paramref name="key"/>.
    /// </summary>
    /// <param name="key">specifies the identifier to return.</param>
    /// <returns>The credential, if found. Otherwise null.</returns>
    public CatalogedCredential GetCredential(string key) =>
        (GetStore(CatalogCredential.Label) as CatalogCredential).Get(key);

    /// <summary>
    /// Return the credential with identifier <paramref name="key"/>.
    /// </summary>
    /// <param name="key">specifies the identifier to return.</param>
    /// <returns>The credential, if found. Otherwise null.</returns>
    public CatalogedCredential GetCredentialByService(string key) =>
        (GetStore(CatalogCredential.Label) as CatalogCredential).GetCredentialByService(key);


    /// <summary>
    /// Return the bookmark with identifier <paramref name="key"/>.
    /// </summary>
    /// <param name="key">specifies the identifier to return.</param>
    /// <returns>The bookmark, if found. Otherwise null.</returns>
    public CatalogedBookmark GetBookmark(string key) =>
        (GetStore(CatalogBookmark.Label) as CatalogBookmark).Get(key);

    /// <summary>
    /// Return the task with identifier <paramref name="key"/>.
    /// </summary>
    /// <param name="key">specifies the identifier to return.</param>
    /// <returns>The task, if found. Otherwise null.</returns>
    public CatalogedTask GetCalendar(string key) =>
        (GetStore(CatalogTask.Label) as CatalogTask).Get(key);

    /// <summary>
    /// Return the network entry with identifier <paramref name="key"/>.
    /// </summary>
    /// <param name="key">specifies the identifier to return.</param>
    /// <returns>The network entry, if found. Otherwise null.</returns>
    public CatalogedNetwork GetNetwork(string key) =>
        (GetStore(CatalogNetwork.Label) as CatalogNetwork).Get(key);








    /// <summary>
    /// Return the network entry for the address <paramref name="networkAddress"/>
    /// </summary>
    /// <param name="networkAddress">The address to return the entry for.</param>
    /// <returns>The network entry if found, otherwise, null.</returns>
    public NetworkProtocolEntry GetNetworkEntry(string networkAddress) =>
        (GetStore(CatalogContact.Label) as CatalogContact).GetNetworkEntry(networkAddress);

    /// <summary>
    /// Retuen the mesh account encryption key for the address <paramref name="networkAddress"/>
    /// </summary>
    /// <param name="networkAddress">The address to return the entry for.</param>
    /// <returns>The mesh account encryption key if found, otherwise, null.</returns>
    public CryptoKey GetByAccountEncrypt(string networkAddress) =>
        (GetStore(CatalogContact.Label) as CatalogContact).GetByAccountEncrypt(networkAddress);

    #endregion

    #endregion

    #region // Application entries

    /// <summary>
    /// Get the SSH application <paramref name="applicationId"/>.
    /// </summary>
    /// <param name="applicationId">The name of the specific SSH application.</param>
    /// <returns>The application iff found, otherwise null.</returns>
    public CatalogedApplicationSsh GetApplicationSsh(
            string applicationId) =>
        GetApplication<CatalogedApplicationSsh>(applicationId) as CatalogedApplicationSsh;

    /// <summary>
    /// Get the Mail application <paramref name="address"/>.
    /// </summary>
    /// <param name="address">The email address.</param>
    /// <returns>The application iff found, otherwise null.</returns>
    public CatalogedApplicationMail GetApplicationMail(
            string address) => GetApplication(
                CatalogedApplicationMail.GetKey(address)) as CatalogedApplicationMail;

    /// <summary>
    /// Get the application entry  for the context device.<paramref name="applicationId"/>.
    /// </summary>
    /// <param name="applicationId">The name of the specific application entry.</param>
    /// <returns>The application iff found, otherwise null.</returns>
    public ApplicationEntry GetApplicationEntry(
            string applicationId) {

        if (ApplicationEntries != null) {

            foreach (var entry in ApplicationEntries) {
                if (entry.Identifier == applicationId) {
                    entry.Decode(KeyCollection);
                    return entry;
                    }
                }
            }
        return null;
        }


    /// <summary>
    /// Get the SSH application entry for the context device.<paramref name="applicationId"/>.
    /// </summary>
    /// <param name="applicationId">The name of the specific SSH application.</param>
    /// <returns>The application iff found, otherwise null.</returns>
    public ApplicationEntrySsh GetApplicationEntrySsh(
            string applicationId) => GetApplicationEntry(applicationId) as ApplicationEntrySsh;

    /// <summary>
    /// Get the Mail application entry  for the context device.<paramref name="applicationId"/>.
    /// </summary>
    /// <param name="applicationId">The name of the specific Mail application entry.</param>
    /// <returns>The application iff found, otherwise null.</returns>
    public ApplicationEntryMail GetApplicationEntryMail(
            string applicationId) => GetApplicationEntry(
                CatalogedApplicationMail.GetKey(applicationId)) as ApplicationEntryMail;

    /// <summary>
    /// Get the Mail application entry  for the context device.<paramref name="applicationId"/>.
    /// </summary>
    /// <param name="applicationId">The name of the specific Mail application entry.</param>
    /// <returns>The application iff found, otherwise null.</returns>
    public ApplicationEntryGroup GetApplicationEntryGroup(
           string applicationId) => GetApplicationEntry(applicationId) as ApplicationEntryGroup;



    #endregion
    }
