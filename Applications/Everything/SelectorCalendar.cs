using Goedel.Cryptography.Dare;
namespace Goedel.Everything;

#region // Bindings to classes specified through the Guigen schema.

// Documented in Guigen output
public partial class CalendarSection : IHeadedSelection {

    IAccountSelector Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    ///<inheritdoc/>
    public GuiBinding SelectionBinding => _BoundAppointment.BaseBinding;

    /// <summary>
    /// Return an instance bound to the Contacts catalog of the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account whose contacts are to be used.</param>
    public CalendarSection(IAccountSelector account) {
        Account = account;
        var catalog = ContextUser.GetStore(CatalogTask.Label, create: false) as GuigenCatalogTasks;
        ChooseAppointment = catalog is null ? null : new CalendarSelection(catalog);
        }

    }

#endregion
#region // Selection Catalog backing type.

public partial class CalendarSelection : TaskSelection  {

    /// <summary>
    /// Constructor returning an instance of the selection data backer bound to the 
    /// catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog"></param>
    public CalendarSelection(GuigenCatalogTasks catalog) : base(catalog) {
        }

    }

#endregion