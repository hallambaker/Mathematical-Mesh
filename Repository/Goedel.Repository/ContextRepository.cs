

using Goedel.Cryptography.Jose;

namespace Goedel.Repository;

/// <summary>
/// Context for managing the callsign Repository account.
/// </summary>
public class ContextRepository : ContextAccount {

    #region Properties

    ///<summary>The enclosing user context.</summary>
    public ContextUser ContextUser;

    ///<inheritdoc/>
    public override Profile Profile => throw new NotImplementedException();

    ///<inheritdoc/>
    public override Connection Connection => throw new NotImplementedException();


    ///<summary>The catalogued group description.</summary>
    public CatalogedRepository CatalogedCallsign;


    ///<inheritdoc/>
    public override string AccountAddress => "@Repository";


    ///<inheritdoc/>
    public override Dictionary<string, StoreFactoryDelegate> DictionaryCatalogDelegates => StaticCatalogDelegates;
    static readonly Dictionary<string, StoreFactoryDelegate> StaticCatalogDelegates = new() {
        // All contexts have a capability catalog:
            { CatalogAccess.Label, CatalogAccess.Factory },
            { CatalogPublication.Label, CatalogPublication.Factory }
        };



    #endregion
    #region Constructors and factories
    /// <summary>
    /// Default constuctor, creates a group context for <paramref name="catalogedCallsign"/>
    /// </summary>
    /// <param name="contextAccount">The enclosing account context.</param>
    /// <param name="catalogedCallsign">Description of the group to return the
    /// context for.</param>
    /// <param name="activationAccount">The account activation.</param>
    public ContextRepository(ContextUser contextAccount,
                CatalogedRepository catalogedCallsign,
                ActivationCommon activationAccount) :
                base(contextAccount.MeshHost, null) {
        ActivationCommon = activationAccount;
        CatalogedCallsign = catalogedCallsign;
        ContextUser = contextAccount;
        }


    /// <summary>
    /// Create a threshold encryption group.
    /// </summary>
    /// <param name="contextUser">The user context in which the group is to be created.</param>
    /// <param name="groupName">Name of the group to create.</param>
    /// <param name="accountSeed">Specifies the secret seed and algorithms used to generate private keys.</param>
    /// <param name="roles">List of rights to be granted.</param>
    /// <returns></returns>

    public ContextRepository CreateGroup(
                    ContextUser contextUser,
                    string groupName,
                    PrivateKeyUDF accountSeed = null,
                    List<string> roles = null
                    ) {

        // create the Repository profile
        accountSeed ??= new PrivateKeyUDF(udfAlgorithmIdentifier: UdfAlgorithmIdentifier.MeshProfileAccount);
        var keyCollectionRepository = new KeyCollectionEphemeral();
        var activationGroup = new ActivationCommon(keyCollectionRepository, accountSeed) {
            ActivationKey = accountSeed.PrivateValue
            };
        var profileRepository = new ProfileRepository(groupName, activationGroup);
        profileRepository.Validate();

        // Wrap the Repository profile in an application entry.
        var catalogedRepository = new CatalogedRepository(profileRepository,
            activationGroup, KeyCommonEncryption) {
            Grant = roles
            };


        var envelopedBindings = MakeBindings(profileRepository, groupName);

        // here we request creation of the group at the service.
        var createRequest = new BindRequest() {
            AccountAddress = groupName,
            EnvelopedProfileAccount = profileRepository.GetEnvelopedProfileAccount(),
            EnvelopedCallsignBinding = envelopedBindings
            };


        // Since the service does not know this account (yet)
        var credentialPrivate = new MeshKeyCredentialPrivate(
                    activationGroup.CommonAuthenticationKey as KeyPairAdvanced, profileRepository.Udf);

        var groupClient = MeshMachine.GetMeshClient(credentialPrivate, profileRepository.Udf);


        var createResponse = groupClient.BindAccount(createRequest);
        createResponse.AssertSuccess();

        // create the group context
        var contextGroup = CreateGroup(contextUser, catalogedRepository, activationGroup, groupClient);
        contextGroup.MeshClient = groupClient;


        var contact = contextGroup.CreateContact();

        // Commit all changes to the administrator context in a single transaction.
        using (var transaction = contextUser.TransactBegin()) {
            // Add the group to the application catalog
            transaction.ApplicationCreate(catalogedRepository);
            var catalogAccess = transaction.GetCatalogAccess();

            // Create a contact for the group and add to the contact catalog
            var contactCatalog = transaction.GetCatalogContact();
            var catalogedContact = new CatalogedContact(contact);
            transaction.CatalogUpdate(contactCatalog, catalogedContact);

            transaction.Transact();
            }

        return contextGroup;
        }


    /// <summary>
    /// Create a new group.
    /// </summary>
    /// <param name="contextAccount">The enclosing account context.</param>
    /// <param name="catalogedRepository">Description of the group to create.</param>
    /// <param name="activationAccount">The account activation.</param>
    /// <param name="client">The client to connect to the service with.</param>
    /// <returns>The group context.</returns>
    public static ContextRepository CreateGroup(
                ContextUser contextAccount,
                CatalogedRepository catalogedRepository,
                ActivationCommon activationAccount,
                MeshServiceClient client) {
        var result = new ContextRepository(contextAccount, catalogedRepository, activationAccount) {
            MeshClient = client
            };

        // Prepopulate the catalogs
        Directory.CreateDirectory(result.StoresDirectory);

        result.LoadStores();
        result.SyncProgressUpload();

        return result;
        }

    #endregion

    #region Methods

    public void Issue(string recipient, int tokens) {

        } 
    #endregion


    }
