

using Goedel.Cryptography.Jose;

namespace Goedel.Carnet;

/// <summary>
/// Context for managing the callsign Carnet account.
/// </summary>
public class ContextCarnet : ContextAccount {

    #region Properties

    ///<summary>The enclosing user context.</summary>
    public ContextUser ContextUser;

    ///<inheritdoc/>
    public override Profile Profile => ProfileCarnet;
    ProfileCarnet ProfileCarnet { get;  }
    ///<inheritdoc/>
    public override Connection Connection => throw new NotImplementedException();


    ///<summary>The catalogued group description.</summary>
    public CatalogedCarnet CatalogedCarnet;

    ///<inheritdoc/>
    public override Dictionary<string, StoreFactoryDelegate> DictionaryCatalogDelegates => StaticCatalogDelegates;
    static readonly Dictionary<string, StoreFactoryDelegate> StaticCatalogDelegates = new() {
            { CatalogCarnet.Label, CatalogCarnet.Factory },

        // All contexts have a capability catalog:
            { CatalogAccess.Label, CatalogAccess.Factory },
            { CatalogPublication.Label, CatalogPublication.Factory }
        };

    ///<inheritdoc/>
    public override string AccountAddress { get; }

    KeyPair KeyAuthentication { get; }
    ///<summary>Returns the inbound spool for the account</summary>
    public CatalogCarnet CatalogCarnet { get; }

    #endregion
    #region Constructors and factories

    /// <summary>
    /// Constructor returning an instance of a resolver account context running on host
    /// <paramref name="meshHost"/> using the description given in <paramref name="catalogedService"/>.
    /// </summary>
    /// <param name="meshHost">The mesh host.</param>
    /// <param name="catalogedService">The resolver configuration description.</param>
    public ContextCarnet(
            MeshHost meshHost,
            CatalogedService catalogedService) : base(meshHost, catalogedService) {

        ProfileCarnet = catalogedService.EnvelopedProfileService.Decode() as ProfileCarnet;


        var SecretSeed = meshHost.KeyCollection.LocatePrivateKey(ProfileCarnet.Udf) as PrivateKeyUDF;
        (KeyAuthentication, _) = SecretSeed.GenerateContributionKey(
        ProfileCarnet.MeshKeyType, ProfileCarnet.MeshActor, MeshKeyOperation.Authenticate);

        var storesDirectory = GetStoresDirectory(meshHost, ProfileCarnet);

        CatalogCarnet = CatalogCarnet.Factory(storesDirectory, CatalogCarnet.Label, this,
                create: false) as CatalogCarnet;

        var syncStore = new SyncStatus(CatalogCarnet);

        DictionaryStores.Add(CatalogCarnet.Label, syncStore);

        }

    ///// <summary>
    ///// Create a threshold encryption group.
    ///// </summary>
    ///// <param name="contextUser">The user context in which the group is to be created.</param>
    ///// <param name="groupName">Name of the group to create.</param>
    ///// <param name="accountSeed">Specifies the secret seed and algorithms used to generate private keys.</param>
    ///// <param name="roles">List of rights to be granted.</param>
    ///// <returns></returns>

    //public static ContextCarnet Create(
    //                ContextUser contextUser,
    //                string groupName,
    //                PrivateKeyUDF accountSeed = null,
    //                List<string> roles = null
    //                ) {

    //    // create the Carnet profile
    //    accountSeed ??= new PrivateKeyUDF(udfAlgorithmIdentifier: UdfAlgorithmIdentifier.MeshProfileAccount);
    //    var keyCollectionCarnet = new KeyCollectionEphemeral();
    //    var activationGroup = new ActivationCommon(keyCollectionCarnet, accountSeed) {
    //        ActivationKey = accountSeed.PrivateValue
    //        };
    //    var profileCarnet = new ProfileCarnet(groupName, activationGroup);
    //    profileCarnet.Validate();

    //    // Wrap the Carnet profile in an application entry.
    //    var catalogedCarnet = new CatalogedCarnet(profileCarnet,
    //        activationGroup, KeyCommonEncryption) {
    //        Grant = roles
    //        };


    //    var envelopedBindings = MakeBindings(profileCarnet, groupName);

    //    // here we request creation of the group at the service.
    //    var createRequest = new BindRequest() {
    //        AccountAddress = groupName,
    //        EnvelopedProfileAccount = profileCarnet.GetEnvelopedProfileAccount(),
    //        EnvelopedCallsignBinding = envelopedBindings
    //        };


    //    // Since the service does not know this account (yet)
    //    var credentialPrivate = new MeshKeyCredentialPrivate(
    //                activationGroup.CommonAuthenticationKey as KeyPairAdvanced, profileCarnet.Udf);

    //    var groupClient = MeshMachine.GetMeshClient(credentialPrivate, profileCarnet.Udf);


    //    var createResponse = groupClient.BindAccount(createRequest);
    //    createResponse.AssertSuccess();

    //    // create the group context
    //    var contextGroup = CreateGroup(contextUser, catalogedCarnet, activationGroup, groupClient);
    //    contextGroup.MeshClient = groupClient;


    //    var contact = contextGroup.CreateContact();

    //    // Commit all changes to the administrator context in a single transaction.
    //    using (var transaction = contextUser.TransactBegin()) {
    //        // Add the group to the application catalog
    //        transaction.ApplicationCreate(catalogedCarnet);
    //        var catalogAccess = transaction.GetCatalogAccess();

    //        // Create a contact for the group and add to the contact catalog
    //        var contactCatalog = transaction.GetCatalogContact();
    //        var catalogedContact = new CatalogedContact(contact);
    //        transaction.CatalogUpdate(contactCatalog, catalogedContact);

    //        transaction.Transact();
    //        }

    //    return contextGroup;
    //    }


    /// <summary>
    /// Create a new client resolver context.
    /// </summary>
    /// <param name="meshHost">The mesh host.</param>
    /// <param name="resolverAddress">The address of the resolver account.</param>
    /// <param name="registryAddress">The address of the registry account.</param>
    /// <param name="accountSeed">Optional account seed.</param>
    /// <param name="roles">The authorized roles.</param>
    /// <returns></returns>
    public static ContextCarnet Create(
                MeshHost meshHost,
                string resolverAddress,
                //Enveloped<ProfileAccount> envelopedProfileCarnet,
                    PrivateKeyUDF accountSeed = null,
                    List<string> roles = null
                ) {
        var meshMachine = meshHost.MeshMachine;
        // Create the service profile

        var profileResolver = ProfileCarnet.Generate(resolverAddress, meshMachine.KeyCollection);
        profileResolver.PersistSeed(meshMachine.KeyCollection);


        // create the cataloged machine entry for the service
        var catalogedService = new CatalogedService() {
            EnvelopedProfileService = profileResolver.GetEnvelopedProfileAccount(),
            };

        // create the directory
        var storesDirectory = ContextAccount.GetStoresDirectory(meshHost, profileResolver);
        Directory.CreateDirectory(storesDirectory);

        var contextResolver = new ContextCarnet(meshHost, catalogedService);


        return contextResolver;
        }

    #endregion

    #region Methods

    public void Issue(string recipient, int tokens) {

        } 
    #endregion


    }
