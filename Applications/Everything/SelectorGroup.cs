using Goedel.Cryptography.Dare;
namespace Goedel.Everything;

#region // Bindings to classes specified through the Guigen schema.

// Documented in Guigen output
public partial class GroupSection {

    IAccountSelector Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    /// <summary>
    /// Return an instance bound to the Contacts catalog of the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account whose contacts are to be used.</param>
    public GroupSection(IAccountSelector account=null) {
        Account = account;
        var catalog = ContextUser.GetStore(CatalogApplication.Label, create: false) as GuigenCatalogApplication;
        ChooseGroup = new GroupSelection(catalog);
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
    public GroupSelection(GuigenCatalogApplication catalog) : base(catalog) {
        }


    }


#endregion