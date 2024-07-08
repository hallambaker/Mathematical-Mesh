using Goedel.Callsign;
using Goedel.Cryptography.Dare;
using Goedel.Mesh;
namespace Goedel.Everything;

#region // Bindings to classes specified through the Guigen schema.

// Documented in Guigen output
public partial class ApplicationSection : IHeadedSelection {

    public IAccountSelector? Account { get; init; }
    ContextUser? ContextUser => Account?.ContextUser;

    ApplicationSelection? ApplicationSelection { get; }

    GuigenCatalogApplication? Catalog { get; }

    ///<inheritdoc/>
    public override ISelectCollection ChooseApplication { get => ApplicationSelection; set { } }

    ///<inheritdoc/>
    public GuiBinding SelectionBinding => _BoundApplication.BaseBinding;

    /// <summary>
    /// Return an instance bound to the Contacts catalog of the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account whose contacts are to be used.</param>
    public ApplicationSection(IAccountSelector? account=null) {
        Account = account;
        Catalog = ContextUser.GetStore(CatalogApplication.Label, create: false) as GuigenCatalogApplication;
        ApplicationSelection = Catalog is null ? null : new ApplicationSelection(ContextUser, Catalog);
        }

    public async Task AddAsync(CatalogedApplication entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry);
        await transaction.TransactAsync();

        var bound = new BoundApplication(entry);
        ApplicationSelection.Add(bound);
        }


    public async Task UpdateAsync(BoundApplication entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry.CatalogedApplication);
        await transaction.TransactAsync();

        ApplicationSelection.Update(entry);
        }


    public async Task DeleteAsync(BoundApplication entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry.CatalogedApplication);
        await transaction.TransactAsync();

        ApplicationSelection.Remove(entry);
        }


    }

// Documented in Guigen output
public partial class BoundApplication : IBoundPresentation, IDialog {
    public CatalogedApplication CatalogedApplication => Bound as CatalogedApplication;
    public virtual GuiDialog Dialog(Gui gui) => (gui as EverythingMaui).DialogBoundApplication;

    public string? LabelValue => LocalName;
    public string? SecondaryValue => "TBS";
    public virtual string? IconValue => "account.png";

    public virtual CatalogedApplication Convert() {
        throw new NotImplementedException();    
        //var result = new CatalogedApplication();

        //return result;
        }

    public BoundApplication() {
        }

    public BoundApplication(CatalogedApplication entry) {
        Bound = entry;
        ReadBound();
        }

    public static BoundTask Factory(CatalogedTask contact) {
        var result = new BoundTask();
        result.Bound = contact;
        result.ReadBound();
        return result;
        }

    protected void Fill(CatalogedApplication application) {
        Bound = application;
        Fill();
        }

    public virtual void Fill() {
        var bound = Bound as CatalogedApplication;
        Path = bound?.Path;
        LocalName = bound?.LocalName;
        Description = bound?.Description;
        }


    public virtual void ReadBound() {
        LocalName = CatalogedApplication.LocalName;
        Description = CatalogedApplication.Description;
        Path = CatalogedApplication.Path;
        }
    public virtual void SetBound() {
        CatalogedApplication.LocalName = LocalName;
        CatalogedApplication.Description = Description;
        CatalogedApplication.Path = Path;
        }

    }

public partial class BoundApplicationMail {

    public override string? IconValue => "mail.png";

    public override CatalogedApplication Convert() {
        var result = new CatalogedApplicationMail() {
            };

        Fill();
        return result;
        }

    public static BoundApplicationMail Convert(CatalogedApplicationMail application) {
        var result = new BoundApplicationMail();
        result.Fill(application);

        return result;

        }

    public override void Fill() {
        base.Fill();
        var bound = Bound as CatalogedApplicationMail;


        }

    }

public partial class BoundApplicationSsh {

    public override string? IconValue => "application_ssh.png";

    public override CatalogedApplication Convert() {
        throw new NotImplementedException();
        //var result = new CatalogedApplication();

        //return result;
        }

    public static BoundApplication Convert(CatalogedApplicationSsh application) {
        var result = new BoundApplicationSsh();
        result.Fill(application);

        return result;

        }
    }
public partial class BoundApplicationOpenPgp {

    public override string? IconValue => "application_openpgp.png";

    public override CatalogedApplication Convert() {
        throw new NotImplementedException();
        //var result = new CatalogedApplication();

        //return result;
        }

    public static BoundApplicationOpenPgp Convert(CatalogedApplicationOpenPgp application) {
        var result = new BoundApplicationOpenPgp();
        result.Fill(application);

        return result;

        }
    }
public partial class BoundApplicationDeveloper {

    public override string? IconValue => "application_developer.png";

    public override CatalogedApplication Convert() {
        throw new NotImplementedException();
        //var result = new CatalogedApplication();

        //return result;
        }

    public static BoundApplicationDeveloper Convert(CatalogedApplicationDeveloper application) {
        var result = new BoundApplicationDeveloper();
        result.Fill(application);

        return result;

        }
    }
public partial class BoundApplicationPkix {

    public override string? IconValue => "application_pkix.png";

    public override CatalogedApplication Convert() {
        throw new NotImplementedException();
        //var result = new CatalogedApplication();

        //return result;
        }

    public static BoundApplicationPkix Convert(CatalogedApplicationPkix application) {
        var result = new BoundApplicationPkix();
        result.Fill(application);

        return result;

        }
    }
//public partial class BoundApplicationGroup {

//    public override string? IconValue => "application_group.png";

//    public override CatalogedApplication Convert() {
//        throw new NotImplementedException();
//        //var result = new CatalogedApplication();

//        //return result;
//        }

//    public static BoundApplicationGroup Convert(CatalogedGroup application) {
//        var result = new BoundApplicationGroup();
//        result.Fill(application);

//        return result;

//        }
//    }
public partial class BoundApplicationCallSign {

    public override string? IconValue => "application_callsign.png";

    public override CatalogedApplication Convert() {
        throw new NotImplementedException();
        //var result = new CatalogedApplication();

        //return result;
        }

    public static BoundApplicationCallSign Convert(CatalogedApplicationCallsign application) {
        var result = new BoundApplicationCallSign();
        result.Fill(application);

        return result;

        }
    }


#endregion
#region // Binding to classes specified in the Mesh schema

/// <summary>
/// Extends <see cref="CatalogApplication"/> to override the <see cref="Intern"/> method
/// so as to allow the bound selection boxes to be updated.
/// </summary>
public class GuigenCatalogApplication : CatalogApplication {

    /// <summary>
    /// Factory delegate
    /// </summary>
    /// <param name="directory">Directory of store file on local machine.</param>
    /// <param name="storeId">Store identifier.</param>
    /// <param name="cryptoParameters">Cryptographic parameters for the store.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">Key collection to be used to resolve keys</param>
    /// <param name="decrypt">If true, attempt decryption of payload contents./</param>
    /// <param name="create">If true, create a new file if none exists.</param>
    /// <param name="meshClient">The mesh client.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    /// <returns>The instance created.</returns>
    public static new Store Factory(
            string directory,
                string storeId,
                IMeshClient? meshClient = null,
                DarePolicy? policy = null,
                CryptoParameters? cryptoParameters = null,
                IKeyCollection? keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[]? bitmask = null) =>
        new GuigenCatalogApplication(directory, storeId, policy, cryptoParameters, keyCollection,
            decrypt, create, bitmask: bitmask);


    /// <summary>
    /// Constructor for a catalog named <paramref name="storeName"/> in directory
    /// <paramref name="directory"/> using the cryptographic parameters <paramref name="cryptoParameters"/>
    /// and key collection <paramref name="keyCollection"/>.
    /// </summary>
    /// <param name="create">Create a new persistence store on disk if it does not already exist.</param>
    /// <param name="decrypt">Attempt to decrypt the contents of the catalog if encrypted.</param>
    /// <param name="directory">The directory in which the catalog persistence container is stored.</param>
    /// <param name="storeName">The catalog persistence container file name.</param>
    /// <param name="cryptoParameters">The default cryptographic enhancements to be applied to container entries.</param>
    /// <param name="policy">The cryptographic policy to be applied to the container.</param>
    /// <param name="keyCollection">The key collection to be used to resolve keys when reading entries.</param>
    /// <param name="bitmask">The bitmask to identify the store for filtering purposes.</param>
    public GuigenCatalogApplication(
                string directory,
                string? storeName = null,
                DarePolicy? policy = null,
                CryptoParameters? cryptoParameters = null,
                IKeyCollection? keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[]? bitmask = null) :
        base(directory, storeName ?? Label,
                    policy, cryptoParameters, keyCollection,
                    decrypt: decrypt, create: create, bitmask: bitmask) {
        }

    public override void Intern(SequenceIndexEntry indexEntry) {
        base.Intern(indexEntry);
        }



    }


#endregion


#region // Selection Catalog backing type.

public partial class ApplicationSelection : SelectionCatalog<GuigenCatalogApplication,
            CatalogedApplication, BoundApplication> {

    /// <summary>
    /// Constructor returning an instance of the selection data backer bound to the 
    /// catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog"></param>
    public ApplicationSelection(ContextAccount contextAccount,
                GuigenCatalogApplication catalog) : base(contextAccount, catalog) {
        }

    #region // Conversion overrides
    //public override CatalogedApplication CreateFromBindable(IBindable contact) =>
    //    (contact as BoundApplication)?.Convert();

    public override BoundApplication ConvertToBindable(CatalogedApplication input) {

        switch (input) {
            case CatalogedApplicationMail application: {
                return BoundApplicationMail.Convert(application);
                }
            case CatalogedApplicationSsh application: {
                return BoundApplicationSsh.Convert(application);
                }
            case CatalogedApplicationOpenPgp application: {
                return BoundApplicationOpenPgp.Convert(application);
                }
            case CatalogedApplicationDeveloper application: {
                return BoundApplicationDeveloper.Convert(application);
                }
            case CatalogedApplicationPkix application: {
                return BoundApplicationPkix.Convert(application);
                }
            case CatalogedGroup application: {
                return BoundApplicationGroup.Convert(application, ContextAccount);
                }
            case CatalogedApplicationCallsign application: {
                return BoundApplicationCallSign.Convert(application);
                }

            default: {
                return new BoundApplication(input);
                }
            }

        }

    public override CatalogedApplication UpdateWithBindable(IBindable entry) {
        var binding = entry as BoundApplication;
        binding.Fill();
        return binding.Bound as CatalogedApplication;
        }


    #endregion


    }


#endregion