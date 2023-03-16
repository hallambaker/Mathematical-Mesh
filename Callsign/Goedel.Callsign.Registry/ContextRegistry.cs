

using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography;
using Microsoft.Extensions.Logging;
using Goedel.Mesh;
using System.Data.SqlTypes;

namespace Goedel.Callsign.Registry;

/// <summary>
/// Context for managing the callsign registry account.
/// </summary>
public class ContextRegistry : ContextAccount {

    #region Properties

    ///<summary>The enclosing user context.</summary>
    public ContextUser ContextUser;

    ///<inheritdoc/>
    public override Profile Profile => CatalogedRegistry.ProfileRegistry;

    ///<inheritdoc/>
    public override Connection Connection => throw new NotImplementedException();


    ///<summary>The catalogued Registry description.</summary>
    public CatalogedRegistry CatalogedRegistry;

    ///<summary>The registation catalog.</summary> 

    public CatalogRegistration CatalogRegistration;

    public CatalogNotary CatalogNotary;
    ///<summary>The callsign mapping</summary> 
    public CallsignMapping CallsignMapping { get; }


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
                ActivationCommon activationAccount) :
                base(contextAccount.MeshHost, null) {

        // Set the service account address
        var profile = catalogedCallsign.ProfileRegistry;
        AccountAddress = profile.AccountAddress;
        ServiceDns = AccountAddress.GetService();

        ActivationCommon = activationAccount;
        CatalogedRegistry = catalogedCallsign;
        ContextUser = contextAccount;

        CallsignMapping = new CallsignMapping();

        CatalogRegistration = GetStore(CatalogRegistration.Label) as CatalogRegistration;
        CatalogNotary = GetStore(CatalogNotary.Label) as CatalogNotary;
        CatalogRegistration.CallsignMapping = CallsignMapping;

        KeyCollection.Add(KeyCommonEncryption);

        CallsignMapping = CallsignMapping.Default;

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
            activationRegistry, contextUser.KeyCommonEncryption) {
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

        // Commit all changes to the administrator context in a single transaction.
        using (var transaction = contextUser.TransactBegin()) {
            // Add the Registry to the application catalog
            transaction.ApplicationCreate(catalogedRegistry);
            var catalogAccess = transaction.GetCatalogAccess();

            // Create a contact for the Registry and add to the contact catalog
            var contactCatalog = transaction.GetCatalogContact();
            var catalogedContact = new CatalogedContact(contact);
            transaction.CatalogUpdate(contactCatalog, catalogedContact);

            transaction.Transact();
            }

        callsignMapping ??= CallsignMapping.Default;


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

        var result = new ContextRegistry(contextAccount, catalogedRegistry, activationAccount) {
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


        CallsignBinding binding;


        ProcessResult result;
        try {
            // Extract binding request
            binding = registrationRequest.EnvelopedCallsignBinding.Decode();
            MessageValidate(spoolEntry, registrationRequest, binding);
            PaymentValidate(registrationRequest, binding);





            var transactRequest = TransactBegin();

            Console.WriteLine("got request");
            CallsignRegistrationResponse registrationResponse = null;
            if (CatalogRegistration.PrepareAdd(
                    registrationRequest.EnvelopedCallsignBinding,
                    KeyAdministratorSign,
                    out var catalogedRegistration,
                    out var reason)) {

                registrationResponse = new CallsignRegistrationResponse() {
                    Registered = true,
                    CatalogedRegistration = catalogedRegistration,
                    MessageId = registrationRequest.GetResponseId(),
                    };
                transactRequest.CatalogUpdate(CatalogRegistration, catalogedRegistration);

                result = new ProcessResultCallsignRegistration() {
                    Success = true,
                    CallsignRegistrationResponse = registrationResponse
                    };

                }
            else {
                registrationResponse = new CallsignRegistrationResponse() {
                    Registered = false,
                    CatalogedRegistration = catalogedRegistration,
                    Reason = reason
                    };
                result = new ProcessResultCallsignRegistration() {
                    Success = true,
                    CallsignRegistrationResponse = registrationResponse
                    };

                }

            transactRequest.OutboundMessage(registrationRequest.Sender, registrationResponse);
            transactRequest.LocalComplete(StateSpoolMessage.Closed, registrationRequest, registrationResponse);

            var responseTransaction = Transact(transactRequest);

            return result;
            }
        catch (Exception ex) {
            return RefuseRequest(registrationRequest, ex);
            }
        }


    public ProcessResult RefuseRequest (
                CallsignRegistrationRequest registrationRequest,
                Exception e) {
        var transactRequest = TransactBegin();
        var registrationResponse = new CallsignRegistrationResponse() {
            Registered = true,
            MessageId = registrationRequest.GetResponseId(),
            };

        transactRequest.OutboundMessage(registrationRequest.Sender, registrationResponse);
        transactRequest.LocalComplete(StateSpoolMessage.Closed, registrationRequest, registrationResponse);
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
    public void MessageValidate(
                SpoolIndexEntry spoolEntry,
                CallsignRegistrationRequest registrationRequest,
                CallsignBinding binding) {

        // check that the binding is of acceptable size.

        (spoolEntry.DataLength <= CatalogedRegistry.MaximumRequestLength).
            AssertTrue(RequestTooLarge.Throw);


        var canonical = StripAt(binding.Canonical);



        var display = StripAt(binding.Display);



        // Is the canonical form legitimate?
        (canonical.Length <= CatalogedRegistry.MaximumCallsignLength).AssertTrue(CallsignLengthInvalid.Throw);

        // check that it really is canonical.
        var canonical2 = CallsignMapping.Canonicalize(canonical);
        (canonical == canonical2).AssertTrue(CanonicalFormInvalid.Throw);



        if (display != null) {
            (display.Length <= CatalogedRegistry.MaximumCallsignLength).AssertTrue(CallsignLengthInvalid.Throw);

            var display2 = CallsignMapping.Canonicalize(canonical);
            (canonical == display2).AssertTrue(DisplayFormInvalid.Throw);
            }

        // check that the binding is signed under the specified ProfileUdf

        throw new BindingSignatureInvalid();


        // Check the signature on the registrationRequest

        throw new RequestSignatureInvalid();

        // is there an existing registration?

        throw new CanonicalFormInvalid();

        // If not, accept

        // Otherwise, check that the signer has valid authorization for the specific registration form.
        throw new RequestNotAuthorized();


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
        throw new RequestRequiresPayment();
        throw new PaymentInsufficient();
        }

    #endregion


    }
