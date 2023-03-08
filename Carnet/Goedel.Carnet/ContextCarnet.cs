

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

    ///<inheritdoc/>
    public override string ServiceDns => AccountAddress.GetService();
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

    /// <summary>
    /// Create a new client resolver context.
    /// </summary>
    /// <param name="meshHost">The mesh host.</param>
    /// <param name="resolverAddress">The address of the resolver account.</param>
    /// <param name="accountSeed">Optional account seed.</param>
    /// <param name="roles">The authorized roles.</param>
    /// <returns></returns>
    public static ContextCarnet Create(
                MeshHost meshHost,
                string resolverAddress,
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

    /// <summary>
    /// Issue a carnet to <paramref name="recipient"/> with value <paramref name="tokens"/>.
    /// </summary>
    /// <param name="recipient">The recipient name.</param>
    /// <param name="tokens">The number of tokens.</param>
    public void Issue(string recipient, int tokens) {
        this.Future();
        recipient.Future();
        tokens.Future();
        } 
    #endregion


    }
