namespace Goedel.Everything;

#region // Bindings to classes specified through the Guigen schema.

// Documented in Guigen output
public partial class FeedSection : IHeadedSelection {

    IAccountSelector Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public FeedSelection FeedSelection { get; }

    GuigenCatalogBookmark Catalog { get; }

    ///<inheritdoc/>
    public GuiBinding SelectionBinding => _BoundFeed.BaseBinding;

    ///<inheritdoc/>
    public override ISelectCollection ChooseFeed { get => FeedSelection; set { } }


    /// <summary>
    /// Return an instance bound to the Contacts catalog of the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account whose contacts are to be used.</param>
    public FeedSection(IAccountSelector? account = null) {
        Account = account;
        Catalog = ContextUser.GetStore(CatalogBookmark.Label, create: false) as GuigenCatalogBookmark;
        FeedSelection = new FeedSelection(ContextUser, Catalog);
        }

    public async Task AddAsync(CatalogedFeed entry) {
        FeedSelection.AssertNotNull(NYI.Throw);
        var bound = BoundFeed.Factory(entry);
        await FeedSelection.AddAsync(bound);



        //var transaction = ContextUser.TransactBegin();
        //transaction.CatalogUpdate(Catalog, entry);
        //await transaction.TransactAsync();

        //var bound = BoundFeed.Factory(entry);
        //FeedSelection.Add(bound);
        }


    public async Task UpdateAsync(BoundFeed entry) {
        FeedSelection.AssertNotNull(NYI.Throw);
        await FeedSelection.UpdateAsync(entry);


        //var transaction = ContextUser.TransactBegin();
        //transaction.CatalogUpdate(Catalog, entry.CatalogedFeed);
        //await transaction.TransactAsync();

        //FeedSelection.Update(entry);
        }


    public async Task DeleteAsync(BoundFeed entry) {
        FeedSelection.AssertNotNull(NYI.Throw);
        await FeedSelection.RemoveAsync(entry);

        //var transaction = ContextUser.TransactBegin();
        //transaction.CatalogUpdate(Catalog, entry.CatalogedFeed);
        //await transaction.TransactAsync();

        //FeedSelection.Remove(entry);
        }


    }


#endregion



#region // Selection Catalog backing type.

public partial class FeedSelection : BookmarkSelection {


    public override GuiBinding SelectionBinding => _BoundFeed.BaseBinding;

    /// <summary>
    /// Constructor returning an instance of the selection data backer bound to the 
    /// catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog"></param>
    public FeedSelection(ContextAccount contextAccount,
                GuigenCatalogBookmark catalog) : base(contextAccount, catalog) {
        }

    public override bool Include(CatalogedBookmark? item) => item is CatalogedFeed;


    #region // Conversion overrides
    //public override CatalogedApplication ConvertFromBindable(IBindable contact) {
    //    throw new NYI();
    //    }

    //public override BoundApplication ConvertToBindable(CatalogedApplication input) {
    //    throw new NYI();
    //    }
    #endregion


    }

public partial class BoundFeed {


    public CatalogedFeed CatalogedFeed => Bound as CatalogedFeed;

    public override CatalogedFeed Convert() {
        var result = new CatalogedFeed() {
            Uid = Udf.Nonce()
            };
        ReadBound();
        return result;
        }

    public static BoundFeed Factory(CatalogedFeed contact) {
        var result = new BoundFeed();
        result.Bound = contact;
        result.ReadBound();
        return result;
        }


    public static BoundFeed Convert(CatalogedFeed entry) {
        var result = new BoundFeed() {
            Bound = entry
            };
        result.ReadBound();
        return result;

        }

    public static BoundFeed Factory(CatalogedTask entry) {
        var result = new BoundFeed() {
            Bound = entry
            };
        result.ReadBound();
        return result;
        }

    public override void ReadBound() {
        base.ReadBound();
        Protocol = CatalogedFeed.Protocol;
        }

    public override void SetBound() {
        base.SetBound();
        CatalogedFeed.Protocol = Protocol;
        }

    }



#endregion