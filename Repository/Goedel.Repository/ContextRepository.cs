

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
    public override string ServiceAddress => "@Repository";

    ///<inheritdoc/>
    public override string ServiceDns => ServiceAddress.GetService();

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

    /// <summary>
    /// Publish the content <paramref name="data"/>.
    /// </summary>
    /// <param name="data">The content to publish.</param>
    /// <returns>The publication message.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public Message Publish(byte[] data) {
        throw new NotImplementedException();
        }
    #endregion


    }
