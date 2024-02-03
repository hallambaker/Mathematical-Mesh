using Goedel.Cryptography.Dare;
namespace Goedel.Everything;

#region // Bindings to classes specified through the Guigen schema.

// Documented in Guigen output
public partial class FeedSection {

    IAccountSelector Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    /// <summary>
    /// Return an instance bound to the Contacts catalog of the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account whose contacts are to be used.</param>
    public FeedSection(IAccountSelector account) {
        Account = account;

        var catalog = ContextUser.GetStore(CatalogBookmark.Label, create: false) as GuigenCatalogBookmark;
        ChooseFeed = new FeedSelection(catalog);
        }

    }


#endregion



#region // Selection Catalog backing type.

public partial class FeedSelection : BookmarkSelection {

    /// <summary>
    /// Constructor returning an instance of the selection data backer bound to the 
    /// catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog"></param>
    public FeedSelection(GuigenCatalogBookmark catalog) : base(catalog) {
        }

    #region // Conversion overrides
    //public override CatalogedApplication ConvertFromBindable(IBindable contact) {
    //    throw new NYI();
    //    }

    //public override BoundApplication ConvertToBindable(CatalogedApplication input) {
    //    throw new NYI();
    //    }
    #endregion


    }


#endregion