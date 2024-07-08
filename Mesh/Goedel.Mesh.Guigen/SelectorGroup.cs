using Goedel.Cryptography.Dare;

using static System.Runtime.InteropServices.JavaScript.JSType;
using Goedel.Mesh;
namespace Goedel.Everything;

#region // Bindings to classes specified through the Guigen schema.

// Documented in Guigen output
public partial class GroupSection : IHeadedSelection {

    IAccountSelector Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public GroupSelection GroupSelection { get; }

    GuigenCatalogApplication Catalog { get; }

    ///<inheritdoc/>
    public GuiBinding SelectionBinding => _BoundApplicationGroup.BaseBinding;

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


    public void Add(BoundApplicationGroup entry) {
        GroupSelection.Add(entry);
        }


    public async Task UpdateAsync(BoundApplicationGroup entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry.CatalogedGroup);
        await transaction.TransactAsync();

        GroupSelection.Update(entry);
        }


    public async Task DeleteAsync(BoundApplicationGroup entry) {

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


public partial class BoundApplicationGroup : IBoundPresentation, IDialog {

    public GuiDialog Dialog(Gui gui) => (gui as EverythingMaui).DialogBoundApplicationGroup;

    public override string? IconValue => "application_group.png";

    public ContextGroup ContextGroup => contextGroup ??
        GetContext().CacheValue(out contextGroup);
    ContextGroup contextGroup;
    public override ISelectList? Members { 
            get => members ?? GetMembers().CacheValue (out members); 
            set => members = value; }
    ISelectList? members;

    public ContextUser ContextUser { get; init; }

    public CatalogedGroup CatalogedGroup => Bound as CatalogedGroup;

    CatalogMember CatalogMember { get; set; } = null;
    public BoundApplicationGroup() {
        }

    public BoundApplicationGroup(ContextGroup contextGroup, ContextUser contextUser) {
        ContextUser = contextUser;
        contextGroup = contextGroup;
        Bound = ContextGroup.CatalogedGroup;
        }

    public static BoundApplicationGroup Factory(CatalogedGroup catalogedGroup) {
        var result = new BoundApplicationGroup();
        result.Bound = catalogedGroup;
        result.ReadBound();
        return result;
        }

    public void ReadBound() {
        }

    public void SetBound() {
        }


    ISelectList GetMembers() {
        CatalogMember ??= ContextGroup.GetStore(CatalogMember.Label) as CatalogMember;

        var list = new SelectList();

        foreach (var entry in CatalogMember) {
            var item = new BoundGroupMember(entry);
            list.Add(item);
            // Got to add self to group

            }


        return list;
        }


    ContextGroup GetContext() => ContextUser.GetContextGroup(CatalogedGroup);


    public override CatalogedApplication Convert() => CatalogedGroup;

    public static BoundApplicationGroup Convert(
                CatalogedGroup application,
                ContextAccount contextAccount) {
        var result = new BoundApplicationGroup() {
            ContextUser = contextAccount as ContextUser
            };
        result.Fill(application);

        return result;

        }

    public override void Fill() {
        base.Fill();
        LocalName ??= CatalogedGroup?.ProfileGroup?.AccountAddress;

        }

    }

public partial class BoundGroupMember : IBoundPresentation {
    public BoundApplicationGroup BoundGroup { get; set; }
    public CatalogedMember CatalogedMember { get; set; }

    public BoundGroupMember() {
        }

    public BoundGroupMember(CatalogedMember member) {
        Bound = member;
        ContactName = member.LocalName;
        Address = member.ContactAddress;


        }


    }