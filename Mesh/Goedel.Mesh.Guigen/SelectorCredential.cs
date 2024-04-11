﻿using Goedel.Cryptography.Dare;
namespace Goedel.Everything;

#region // Bindings to classes specified through the Guigen schema.

// Documented in Guigen output
public partial class CredentialSection : IHeadedSelection {

    IAccountSelector Account { get; }
    ContextUser ContextUser => Account.ContextUser;
    public CredentialSelection CredentialSelection { get; }

    GuigenCatalogCredential Catalog { get; }

    ///<inheritdoc/>
    public override ISelectCollection ChooseCredential { get => CredentialSelection; set { } }

    ///<inheritdoc/>
    public GuiBinding SelectionBinding => _BoundCredential.BaseBinding;

    /// <summary>
    /// Return an instance bound to the Contacts catalog of the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account whose contacts are to be used.</param>
    public CredentialSection(IAccountSelector? account =null) {
        Account = account;
        Catalog = ContextUser.GetStore(CatalogCredential.Label, create: false) as GuigenCatalogCredential;
        CredentialSelection = new CredentialSelection(Catalog);
        }

    public async Task AddAsync(CatalogedCredential entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry);
        await transaction.TransactAsync();

        var bound = BoundCredential.Factory(entry);
        CredentialSelection.Add(bound);
        }


    public async Task UpdateAsync(BoundCredential entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry.CatalogedCredential);
        await transaction.TransactAsync();

        CredentialSelection.Update(entry);
        }


    public async Task DeleteAsync(BoundCredential entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry.CatalogedCredential);
        await transaction.TransactAsync();

        CredentialSelection.Remove(entry);
        }

    }


public partial class BoundCredential : IBoundPresentation, IDialog {

    public CatalogedCredential CatalogedCredential => Bound as CatalogedCredential;
    public GuiDialog Dialog(Gui gui) => (gui as EverythingMaui).DialogBoundCredential;


    public static BoundCredential Factory(CatalogedCredential contact) {
        var result = new BoundCredential();
        result.Bound = contact;
        result.ReadBound();
        return result;
        }

    public virtual void ReadBound() {
        Protocol = CatalogedCredential.Protocol;
        Protocol = CatalogedCredential.Protocol;
        Service = CatalogedCredential.Service;
        Username = CatalogedCredential.Username;
        }

    public virtual void SetBound() {
        CatalogedCredential.Protocol = Protocol;
        CatalogedCredential.Service = Service;
        CatalogedCredential.Username = Username;
        }
    }

// Documented in Guigen output
public partial class BoundPassword : IBoundPresentation, IDialog {


    public override IFieldIcon Type => FieldIcons.CredentialPassword;

    public CatalogedCredential Convert() {
        var result = new CatalogedCredential() {
            Protocol = Protocol,
            Service = Service,
            Username = Username,
            Password = Password,
            Uid = Udf.Nonce()
            };

        return result;
        }

    public static BoundPassword Convert(CatalogedCredential entry) {
        var result = new BoundPassword() {
            Bound = entry
            };
        result.ReadBound();
        return result;
        }

    public override void ReadBound() {
        base.ReadBound();
        Password = CatalogedCredential.Password;
        }

    public override void SetBound() {
        base.SetBound();
        CatalogedCredential.Password = Password;
        }


    }

public partial class BoundPasskey: IBoundPresentation, IDialog {


    public override IFieldIcon Type => FieldIcons.CredentialPasskey;
    public CatalogedCredential Convert() {
        var result = new CatalogedCredential() {
            Protocol = Protocol,
            Service = Service,
            Username = Username,
            Uid = Udf.Nonce()
            };

        return result;
        }

    public static BoundPasskey Convert(CatalogedCredential entry) {
        var result = new BoundPasskey() {
            Protocol = entry.Protocol,
            Service = entry.Service,
            Username = entry.Username
            };

        return result;

        }
    }




#endregion
#region // Binding to classes specified in the Mesh schema

/// <summary>
/// Extends <see cref="CatalogApplication"/> to override the <see cref="Intern"/> method
/// so as to allow the bound selection boxes to be updated.
/// </summary>
public class GuigenCatalogCredential : CatalogCredential {

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
        new GuigenCatalogCredential(directory, storeId, policy, cryptoParameters, keyCollection,
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
    public GuigenCatalogCredential(
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

public partial class CredentialSelection : SelectionCatalog<GuigenCatalogCredential,
            CatalogedCredential, BoundPassword> {

    /// <summary>
    /// Constructor returning an instance of the selection data backer bound to the 
    /// catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog"></param>
    public CredentialSelection(GuigenCatalogCredential catalog) : base(catalog) {
        }

    #region // Conversion overrides
    //public override CatalogedCredential CreateFromBindable(IBindable contact) =>
    //    (contact as BoundPassword)?.Convert();

    public override BoundPassword ConvertToBindable(CatalogedCredential input) => BoundPassword.Convert(input);

    public override CatalogedCredential UpdateWithBindable(IBindable entry) {
        var binding = entry as BoundPassword;
        binding.ReadBound();
        return binding.Bound as CatalogedCredential;
        }

    #endregion


    }


#endregion