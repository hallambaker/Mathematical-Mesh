using Goedel.Cryptography.Dare;

using static System.Runtime.InteropServices.JavaScript.JSType;
using Goedel.Mesh;
namespace Goedel.Everything;

#region // Bindings to classes specified through the Guigen schema.

// Documented in Guigen output
public partial class GroupSection {

    IAccountSelector Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public GroupSelection GroupSelection { get; }

    GuigenCatalogApplication Catalog { get; }

    ///<inheritdoc/>
    public override ISelectCollection ChooseGroup { get => GroupSelection; set { } }

    /// <summary>
    /// Return an instance bound to the Contacts catalog of the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account whose contacts are to be used.</param>
    public GroupSection(IAccountSelector? account =null) {
        Account = account;
        Catalog = ContextUser.GetStore(CatalogApplication.Label, create: false) as GuigenCatalogApplication;
        GroupSelection = new GroupSelection(ContextUser, Catalog);
        }


    public void Add(BoundGroup entry) {
        GroupSelection.Add(entry);
        }


    public async Task UpdateAsync(BoundGroup entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry.CatalogedGroup);
        await transaction.TransactAsync();

        GroupSelection.Update(entry);
        }


    public async Task DeleteAsync(BoundGroup entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry.CatalogedGroup);
        await transaction.TransactAsync();

        GroupSelection.Remove(entry);
        }

    }



#endregion


#region // Selection Catalog backing type.

public partial class GroupSelection : ApplicationSelection {

    /// <summary>
    /// Constructor returning an instance of the selection data backer bound to the 
    /// catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog"></param>
    public GroupSelection(
                ContextAccount contextAccount, 
                GuigenCatalogApplication catalog) : base(contextAccount, catalog) {
        }

    public override bool Include(CatalogedApplication? item) => item is CatalogedGroup;
    }


#endregion


public partial class BoundGroup : IBoundPresentation {

    public ContextGroup ContextGroup { get; set; }


    public ContextUser ContextUser { get; set; }

    public CatalogedGroup CatalogedGroup => Bound as CatalogedGroup;



    public static BoundGroup Factory(ContextGroup contextGroup) {
        var result = new BoundGroup();
        result.Bound = contextGroup;
        result.ReadBound();
        return result;
        }

    public void ReadBound() {
        }

    public void SetBound() {
        }


    public ContextGroup GetContext() => throw new NYI();

    }