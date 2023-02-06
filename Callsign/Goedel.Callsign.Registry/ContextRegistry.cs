

using Goedel.Cryptography.Dare;
using Goedel.Cryptography.Jose;
using Goedel.Cryptography;
using Microsoft.Extensions.Logging;
using Goedel.Mesh;

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

    ///<summary>The callsign mapping</summary> 
    public CallsignMapping CallsignMapping { get; }


    ///<inheritdoc/>
    public override string AccountAddress => "@registry";


    ///<inheritdoc/>
    public override Dictionary<string, StoreFactoryDelegate> DictionaryCatalogDelegates => StaticCatalogDelegates;
    static readonly Dictionary<string, StoreFactoryDelegate> StaticCatalogDelegates = new() {
            { CatalogRegistration.Label, CatalogRegistration.Factory },

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
    public ContextRegistry(ContextUser contextAccount,
                CatalogedRegistry catalogedCallsign,
                ActivationCommon activationAccount) :
                base(contextAccount.MeshHost, null) {
        ActivationCommon = activationAccount;
        CatalogedRegistry = catalogedCallsign;
        ContextUser = contextAccount;

        CallsignMapping = new CallsignMapping();
        
        CatalogRegistration = GetStore(CatalogRegistration.Label) as CatalogRegistration;
        CatalogRegistration.CallsignMapping = CallsignMapping;
        }


    /// <summary>
    /// Create a threshold encryption Registry.
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
                    List<string> roles = null
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
            Grant = roles
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
                    activationRegistry.CommonAuthenticationKey as KeyPairAdvanced, profileRegistry.Udf);
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


        var x = new Evaluate();

        var spoolInbound = GetSpoolInbound();
        foreach (var spoolEntry in spoolInbound.GetMessages(evaluateIndex: Evaluate.GetOpen)) {
            var meshMessage = spoolEntry.Message;

            //Logger.GotMessage(meshMessage.GetType().ToString(), meshMessage.MessageId, spoolEntry.MessageStatus);
            if (spoolEntry.IsOpen) {
                switch (meshMessage) {
                    case CallsignRegistrationRequest callsignRegistrationRequest: {
                        Process(callsignRegistrationRequest);
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
    public ProcessResult Process (
                CallsignRegistrationRequest registrationRequest) {

        var transactRequest = TransactBegin();

        Console.WriteLine("got request");

        ProcessResult result;

        CallsignRegistrationResponse registrationResponse = null;
        if (CatalogRegistration.PrepareAdd(
                registrationRequest.EnvelopedCallsignBinding,
                KeyAdministratorSign,
                out var catalogedRegistration, 
                out var reason)) {

            registrationResponse = new CallsignRegistrationResponse() {
                Registered = true,
                CatalogedRegistration = catalogedRegistration
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
                Success = false,
                CallsignRegistrationResponse = registrationResponse
                };

            }

        transactRequest.OutboundMessage(registrationRequest.Sender, registrationResponse);
        transactRequest.LocalComplete(MessageStatus.Closed, registrationRequest, registrationResponse);

        var responseTransaction = Transact(transactRequest);

        return result;

        }




    #endregion


    }
