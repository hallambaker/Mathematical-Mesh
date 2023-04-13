

using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography;
using Microsoft.Extensions.Logging;
using Goedel.Mesh;
using System.Data.SqlTypes;
using Goedel.Cryptography.PKIX;

namespace Goedel.Callsign.Registry;

/// <summary>
/// Context for managing the callsign registry account.
/// </summary>
public class ContextRegistry : ContextAccount {

    #region Properties

    ///<summary>The enclosing user context.</summary>
    public ContextUser ContextUser;

    public override ProfileDevice ProfileDevice => ContextUser.ProfileDevice; 


    ///<inheritdoc/>
    public override Profile Profile => CatalogedRegistry.ProfileRegistry;

    ///<inheritdoc/>
    public override Connection Connection { get; }


    ///<summary>The catalogued Registry description.</summary>
    public CatalogedRegistry CatalogedRegistry;

    ///<summary>The registation catalog.</summary> 

    public CatalogRegistration CatalogRegistration;

    public CatalogNotary CatalogNotary;
    ///<summary>The callsign mapping</summary> 
    public CallsignMapping CallsignMapping { get; }

    public  string DefaultPage => "CharacterPageLatin";
    ///<inheritdoc/>
    public override string AccountAddress { get; }

    public override string ServiceDns { get; }

    ///<inheritdoc/>
    public override Dictionary<string, StoreFactoryDelegate> DictionaryCatalogDelegates => StaticCatalogDelegates;
    static readonly Dictionary<string, StoreFactoryDelegate> StaticCatalogDelegates = new() {
            { CatalogRegistration.Label, CatalogRegistration.Factory },
            { CatalogNotary.Label, CatalogNotary.Factory },
        // All contexts have a capability catalog:
            { CatalogAccess.Label, CatalogAccess.Factory },
            { CatalogPublication.Label, CatalogPublication.Factory }
        };

    ActivationApplicationRegistry ActivationApplicationRegistry;

    ///<inheritdoc/>
    public override KeyPair KeyCommonEncryption =>
            ActivationApplicationRegistry?.CommonEncryptionKey ??
            ActivationCommon?.CommonEncryptionKey;

    ///<inheritdoc/>
    public override KeyPair KeyAdministratorSign =>
        ActivationApplicationRegistry?.AdministratorSignatureKey ??
        ActivationCommon?.AdministratorSignatureKey;

    ///<inheritdoc/>
    public KeyPair AccountAuthentication =>
        ActivationApplicationRegistry?.AccountAuthentication ;


    ///<inheritdoc/>
    public override MeshCredentialPrivate GetMeshCredentialPrivate() {
        ProfileDevice.Activate(KeyCollection);
        return new(ProfileDevice, CatalogedRegistry.ConnectionService, 
                null, AccountAuthentication as KeyPairAdvanced);
        }

    #endregion
    #region Constructors and factories
    /// <summary>
    /// Default constuctor, creates a Registry context for <paramref name="catalogedCallsign"/>
    /// </summary>
    /// <param name="contextAccount">The enclosing account context.</param>
    /// <param name="catalogedCallsign">Description of the Registry to return the
    /// context for.</param>
    /// <param name="activationAccount">The account activation.</param>
    public ContextRegistry(
                ContextUser contextAccount,
                CatalogedRegistry catalogedCallsign,
                ActivationApplicationRegistry activationApplicationRegistry = null,
                ActivationCommon activationAccount = null
        ) :
                base(contextAccount.MeshHost, null) {

        // Set the service account address
        var profile = catalogedCallsign.ProfileRegistry;
        AccountAddress = profile.AccountAddress;
        ServiceDns = AccountAddress.GetService();

        ActivationCommon = activationAccount;
        ActivationApplicationRegistry = activationApplicationRegistry;

        CatalogedRegistry = catalogedCallsign;
        ContextUser = contextAccount;

        CallsignMapping = new CallsignMapping();

        var policy = new DarePolicy() {
            Public = true
            };

        CatalogRegistration = new CatalogRegistration(StoresDirectory, policy: policy);
        AddStore(CatalogRegistration);

        CatalogNotary = new CatalogNotary(StoresDirectory, policy: policy);
        AddStore(CatalogNotary);

        //CatalogRegistration = GetStore(CatalogRegistration.Label) as CatalogRegistration;
        //CatalogNotary = GetStore(CatalogNotary.Label) as CatalogNotary;
        CatalogRegistration.CallsignMapping = CallsignMapping;

        KeyCollection.Add(KeyCommonEncryption);

        CallsignMapping = CallsignMapping.Default;
        }

    void AddStore(Store store) {

        var syncStore = new SyncStatus(store);

        DictionaryStores.Add(store.StoreName, syncStore);
        }



    /// <summary>
    /// Create the callsign Registry.
    /// </summary>
    /// <param name="contextUser">The user context in which the Registry is to be created.</param>
    /// <param name="RegistryName">Name of the Registry to create.</param>
    /// <param name="accountSeed">Specifies the secret seed and algorithms used to generate private keys.</param>
    /// <param name="roles">List of rights to be granted.</param>
    /// <returns></returns>

    public static ContextRegistry CreateRegistry(
                    ContextUser contextUser,
                    string RegistryName,
                    PrivateKeyUDF accountSeed = null,
                    List<string> roles = null,
                    CallsignMapping callsignMapping = null
                    ) {

        // create the registry profile
        accountSeed ??= new PrivateKeyUDF(udfAlgorithmIdentifier: UdfAlgorithmIdentifier.MeshProfileAccount);
        var keyCollectionRegistry = new KeyCollectionEphemeral();
        var activationRegistry = new ActivationCommon(keyCollectionRegistry, accountSeed) {
            ActivationKey = accountSeed.PrivateValue
            };
        var profileRegistry = new ProfileRegistry(RegistryName, activationRegistry);
        profileRegistry.Validate();

        // Wrap the registry profile in an application entry.
        var catalogedRegistry = new CatalogedRegistry(profileRegistry,
            activationRegistry) {
            Grant = roles,
            MaximumRequestLength = 8191,
            MaximumCallsignLength = 31
            };


        var envelopedBindings = contextUser.MakeBindings(profileRegistry, RegistryName);

        // here we request creation of the Registry at the service.
        var createRequest = new BindRequest() {
            AccountAddress = RegistryName,
            EnvelopedProfileAccount = profileRegistry.GetEnvelopedProfileAccount(),
            EnvelopedCallsignBinding = envelopedBindings
            };


        // Since the service does not know this account (yet)
        var credentialPrivate = new MeshKeyCredentialPrivate(
                    activationRegistry.CommonAuthenticationKey as KeyPairAdvanced, profileRegistry.UdfString);
        var registryClient = contextUser.MeshMachine.GetMeshClient(credentialPrivate, RegistryName);
        var createResponse = registryClient.BindAccount(createRequest);
        createResponse.AssertSuccess();

        // create the Registry context
        var contextRegistry = CreateRegistry(contextUser, catalogedRegistry, activationRegistry, registryClient);
        contextRegistry.MeshClient = registryClient;
        var contact = contextRegistry.CreateContact();

        var applicationEntries = new List<ApplicationEntry>();


        // Commit all changes to the administrator context in a single transaction.
        using (var transaction = contextUser.TransactBegin()) {
            // Add the Registry to the application catalog
            applicationEntries = transaction.ApplicationCreate(catalogedRegistry);
            var catalogAccess = transaction.GetCatalogAccess();

            // Create a contact for the Registry and add to the contact catalog
            var contactCatalog = transaction.GetCatalogContact();
            var catalogedContact = new CatalogedContact(contact);
            transaction.CatalogUpdate(contactCatalog, catalogedContact);

            transaction.Transact();
            }


        using (var transaction = contextRegistry.TransactBegin()) {
            var catalogAccess = transaction.GetCatalogAccess();
            foreach (var applicationEntry in applicationEntries) {


                var access = applicationEntry.GetCatalogedAccess();
                if (access != null) {
                    transaction.CatalogUpdate(catalogAccess, access);
                    }
                }

            transaction.Transact();
            }

        //contextUser.CallsignRegistry = RegistryName;
        contextUser.ProfileRegistryCallsign = profileRegistry;
        contextRegistry.ProfileRegistryCallsign = profileRegistry;

        return contextRegistry;
        }


    /// <summary>
    /// Create a new Registry.
    /// </summary>
    /// <param name="contextAccount">The enclosing account context.</param>
    /// <param name="catalogedRegistry">Description of the Registry to create.</param>
    /// <param name="activationAccount">The account activation.</param>
    /// <param name="client">The client to connect to the service with.</param>
    /// <returns>The Registry context.</returns>
    public static ContextRegistry CreateRegistry(
                ContextUser contextAccount,
                CatalogedRegistry catalogedRegistry,
                ActivationCommon activationAccount,
                MeshServiceClient client) {

        var storesDirectory = GetStoresDirectory(contextAccount.MeshMachine, catalogedRegistry.ProfileRegistry);
        Directory.CreateDirectory(storesDirectory);

        var result = new ContextRegistry(contextAccount, catalogedRegistry, activationAccount: activationAccount) {
            MeshClient = client
            };

        // Prepopulate the catalogs
        result.LoadStores();
        result.SyncProgressUpload();

        return result;
        }

    #endregion
    #region Methods

    /// <summary>
    /// Process the list of pending messages in order of receipt. 
    /// </summary>
    public List<ProcessResult> Process() {

        // synchronize the store
        Sync();

        var results = new List<ProcessResult>();


        var x = new FilterSequenceIndex();

        var spoolInbound = GetSpoolInbound();
        foreach (var spoolEntry in spoolInbound.GetMessages(open: true)) {
            var meshMessage = spoolEntry.Message;

            //Logger.GotMessage(meshMessage.GetType().ToString(), meshMessage.MessageId, spoolEntry.MessageStatus);
            if (spoolEntry.IsOpen) {
                switch (meshMessage) {
                    case CallsignRegistrationRequest callsignRegistrationRequest: {
                        Process(spoolEntry, callsignRegistrationRequest);
                        break;
                        }

                    }
                }
            }

        // Perform the transaction


        return results;
        }


    /// <summary>
    /// Process the callsign registration request <paramref name="registrationRequest"/>.
    /// </summary>
    /// <param name="registrationRequest">The request to process.</param>
    /// <returns>Reports the processing result.</returns>
    public ProcessResult Process(
                SpoolIndexEntry spoolEntry,
                CallsignRegistrationRequest registrationRequest) {


        CallsignBinding binding = null;
        ProcessResult result;
        try {
            // Extract binding request
            binding = registrationRequest.EnvelopedCallsignBinding.Decode();
            var canonical = MessageValidate(spoolEntry, registrationRequest, binding, out var previous);
            PaymentValidate(registrationRequest, binding);




            var transactRequest = TransactBegin();


            var id = Udf.Nonce();

            var registration = new Registration() {
                Submitted = DateTime.Now,
                Id = id,
                Entry = registrationRequest.EnvelopedCallsignBinding,
                Reason = previous == null ?
                    CallsignConstants.RegistrationReasonInitialTag : 
                        CallsignConstants.RegistrationReasonUpdateTag,
                PriorId = previous?.Id
                };

            var enveloped = registration.Enveloped(KeyAdministratorSign);
            var catalogedRegistration = new CatalogedRegistration() {
                Canonical = canonical,
                Id = id,
                EnvelopedRegistration = enveloped
                };

            CallsignRegistrationResponse registrationResponse = new CallsignRegistrationResponse() {
                Registered = true,
                Reason = registration.Reason,
                CatalogedRegistration = catalogedRegistration,
                MessageId = registrationRequest.GetResponseId(),
                };


            transactRequest.CatalogUpdate(CatalogRegistration, catalogedRegistration);
            result = new ProcessResultCallsignRegistration() {
                Success = true,
                CallsignRegistrationResponse = registrationResponse
                };

            transactRequest.OutboundMessage(registrationRequest.Sender, registrationResponse);
            transactRequest.InboundComplete(StateSpoolMessage.Closed, registrationRequest, registrationResponse);

            var responseTransaction = Transact(transactRequest);

            return result;
            }
        catch (Exception ex) {
            return RefuseRequest(registrationRequest, binding, ex);
            }
        }

    /// <summary>
    /// Return a message refusing the request <paramref name="registrationRequest"/> for the
    /// reason corresponding to <paramref name="exception"/>. The request is returned
    /// to the original sender.
    /// </summary>
    /// <param name="registrationRequest">The request that caused the exception to be raised.</param>
    /// <param name="exception">The exception raised.</param>
    /// <returns>Processing result with <see cref="ProcessResult.Success"/> set false.</returns>
    public ProcessResult RefuseRequest (
                CallsignRegistrationRequest registrationRequest,
                CallsignBinding? binding,
                Exception exception) {
        var reason = exception switch {
            CanonicalFormInvalid => RegistrationRefusal.CanonicalFormInvalid,
            DisplayFormInvalid => RegistrationRefusal.DisplayFormInvalid,
            CallsignLengthInvalid => RegistrationRefusal.CallsignLengthInvalid,
            RequestSignatureInvalid => RegistrationRefusal.RequestSignatureInvalid,
            BindingSignatureInvalid => RegistrationRefusal.BindingSignatureInvalid,
            RequestNotAuthorized => RegistrationRefusal.RequestNotAuthorized,
            RequestRequiresPayment => RegistrationRefusal.RequestRequiresPayment,
            PaymentInsufficient => RegistrationRefusal.PaymentInsufficient,
            _ => RegistrationRefusal.RegistrationRefused
            };

        var transactRequest = TransactBegin();
        var registrationResponse = new CallsignRegistrationResponse() {
            Reason = reason.ToLabel(),
            Registered = false,
            MessageId = registrationRequest.GetResponseId(),
            Callsign = binding?.Canonical ?? binding?.Display
            };

        transactRequest.OutboundMessage(registrationRequest.Sender, registrationResponse);
        transactRequest.InboundComplete(StateSpoolMessage.Closed, registrationRequest, registrationResponse);
        var responseTransaction = Transact(transactRequest);


        return new ProcessResultCallsignRegistration() {
            Success = false,
            CallsignRegistrationResponse = registrationResponse
            };

        }

    /// <summary>
    /// /
    /// </summary>
    /// <param name="registrationRequest"></param>
    /// <param name="binding"></param>
    /// <exception cref="RegistrationRefused">The callsign registration was refused</exception>
    /// <exception cref="RequestTooLarge">The binding request was larger than the maximum permitted size.</exception>
    /// <exception cref="CanonicalFormInvalid">The canonical form is not valid.</exception>
    /// <exception cref="DisplayFormInvalid">The display form does not match the canonical form.</exception>
    /// <exception cref="CallsignLengthInvalid">The callsign length is invalid.</exception>
    /// <exception cref="BindingSignatureInvalid">The binding signature is invalid.</exception>
    /// <exception cref="RequestSignatureInvalid">The request signature is invalid.</exception>
    /// <exception cref="RequestNotAuthorized">The request is not authorized.</exception>
    public string MessageValidate(
                SpoolIndexEntry spoolEntry,
                CallsignRegistrationRequest registrationRequest,
                CallsignBinding binding,
                out CatalogedRegistration previous) {

        // check that the binding is of acceptable size.

        (spoolEntry.DataLength <= CatalogedRegistry.MaximumRequestLength).
            AssertTrue(RequestTooLarge.Throw);


        var canonical = StripAt(binding.Canonical);
        var display = StripAt(binding.Display);


        Console.WriteLine();
        Console.WriteLine($"got request for @{canonical} = @{display}");



        string page = binding.CharacterPage ?? DefaultPage;
        DefaultPage.Equals(page).AssertTrue(CanonicalFormInvalid.Throw);

        // Is the canonical form legitimate?
        (canonical.Length <= CatalogedRegistry.MaximumCallsignLength).AssertTrue(CallsignLengthInvalid.Throw);

        // check that it really is canonical.
        var canonical2 = CallsignMapping.Canonicalize(canonical);
        (canonical == canonical2).AssertTrue(CanonicalFormInvalid.Throw);

        CallsignMapping.CheckPage(canonical, page).AssertTrue(CanonicalFormInvalid.Throw);
        //page.Id.AssertEqual("CharacterPageLatin", CanonicalFormInvalid.Throw);

        if (display != null) {
            (display.Length <= CatalogedRegistry.MaximumCallsignLength).AssertTrue(CallsignLengthInvalid.Throw);

            var display2 = CallsignMapping.Canonicalize(canonical);
            (canonical == display2).AssertTrue(DisplayFormInvalid.Throw);

            CallsignMapping.CheckPage(display, page).AssertTrue(DisplayFormInvalid.Throw);
            }

        // check that the binding is signed under the specified ProfileUdf

        if (binding.ProfileUdf != null) {
            binding.Validate(registrationRequest.Profiles).AssertTrue(BindingSignatureInvalid.Throw);
            }
        else if (binding.TransferUdf != null) {
            
            }

        // Check the signature on the registrationRequest
        if (CatalogRegistration.TryGetValue(canonical, out var index)) {
            previous = index.JsonObject as CatalogedRegistration;
            previous.AssertNotNull(NYI.Throw);

            var previousRegistration = previous.EnvelopedRegistration.Decode();
            var previousBinding = previousRegistration.Entry.Decode();

            registrationRequest.DareEnvelope.PayloadDigestComputed ??=
                    spoolEntry.ComputeDigest();

            var previousUdf = previousBinding.TransferUdf ?? previousBinding.ProfileUdf;
            registrationRequest.Validate(previousUdf).AssertTrue(RequestSignatureInvalid.Throw); ;

            if (binding.TransferUdf != null) {
                binding.ValidateAny(registrationRequest.Profiles, previousBinding.ProfileUdf).AssertTrue(
                            BindingSignatureInvalid.Throw);
                }


            }
        else {
            binding.TransferUdf.AssertNull(BindingSignatureInvalid.Throw);
            previous = null;
            }

        return canonical;
        }



    string StripAt(string callsign) {
        if (callsign[0] != '@') {
            return callsign; 
            }
        return callsign.Substring(1);
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="registrationRequest"></param>
    /// <param name="binding"></param>
    /// <exception cref="RequestRequiresPayment"></exception>
    /// <exception cref="PaymentInsufficient"></exception>
    public void PaymentValidate(
                CallsignRegistrationRequest registrationRequest,
                CallsignBinding binding) {

        return;

        //throw new RequestRequiresPayment();
        //throw new PaymentInsufficient();
        }

    #endregion


    }
