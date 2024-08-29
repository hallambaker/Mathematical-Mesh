namespace Goedel.Everything;

#region // Bindings to classes specified through the Guigen schema.

// Documented in Guigen output
public partial class CalendarSection : IHeadedSelection {

    IAccountSelector Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public CalendarSelection CalendarSelection { get; }

    GuigenCatalogTasks Catalog { get; }

    ///<inheritdoc/>
    public override ISelectCollection ChooseAppointment { get => CalendarSelection; set { } }

    ///<inheritdoc/>
    public GuiBinding SelectionBinding => _BoundAppointment.BaseBinding;

    /// <summary>
    /// Return an instance bound to the Contacts catalog of the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account whose contacts are to be used.</param>
    public CalendarSection(IAccountSelector? account = null) {
        Account = account;
        Catalog = ContextUser.GetStore(CatalogTask.Label, create: false) as GuigenCatalogTasks;
        CalendarSelection = Catalog is null ? null : new CalendarSelection(ContextUser, Catalog);
        }

    public async Task AddAsync(CatalogedTask entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry);
        await transaction.TransactAsync();

        var bound = new BoundTask(entry);
        CalendarSelection.Add(bound);
        }


    public async Task UpdateAsync(BoundTask entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry.CatalogedTask);
        await transaction.TransactAsync();

        CalendarSelection.Update(entry);
        }


    public async Task DeleteAsync(BoundTask entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry.CatalogedTask);
        await transaction.TransactAsync();

        CalendarSelection.Remove(entry);
        }

    }

#endregion
#region // Selection Catalog backing type.

public partial class CalendarSelection : TaskSelection {

    /// <summary>
    /// Constructor returning an instance of the selection data backer bound to the 
    /// catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog"></param>
    public CalendarSelection(ContextAccount contextAccount,
                GuigenCatalogTasks catalog) : base(contextAccount, catalog) {
        }


    public override bool Include(CatalogedTask? item) =>
        item.EnvelopedTask.EnvelopedObject is WorkTask;
    }

#endregion