﻿using Goedel.Cryptography.Dare;
using Goedel.Mesh;

using System.Xml.Linq;

namespace Goedel.Everything;

#region // Bindings to classes specified through the Guigen schema.

// Documented in Guigen output
public partial class BookmarkSection : IHeadedSelection {

    IAccountSelector Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    BookmarkSelection BookmarkSelection { get; }

    GuigenCatalogBookmark Catalog { get; }

    ///<inheritdoc/>
    public override ISelectCollection ChooseBookmark { get => BookmarkSelection; set { } }

    ///<inheritdoc/>
    public GuiBinding SelectionBinding => _BoundBookmark.BaseBinding;

    /// <summary>
    /// Return an instance bound to the Contacts catalog of the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account whose contacts are to be used.</param>
    public BookmarkSection(IAccountSelector? account =null) {
        Account = account;
        Catalog = ContextUser.GetStore(CatalogBookmark.Label, create: false) as GuigenCatalogBookmark;
        BookmarkSelection = Catalog is null ? null : new BookmarkSelection(ContextUser, Catalog);
        }

    public async Task AddAsync(CatalogedBookmark entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry);
        await transaction.TransactAsync();

        var bound =  BoundBookmark.Factory(entry);
        BookmarkSelection.Add(bound);
        }


    public async Task UpdateAsync(BoundBookmark entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry.CatalogedBookmark);
        await transaction.TransactAsync();

        BookmarkSelection.Update(entry);
        }


    public async Task DeleteAsync(BoundBookmark entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry.CatalogedBookmark);
        await transaction.TransactAsync();

        BookmarkSelection.Remove(entry);
        }


    }

// Documented in Guigen output
public partial class BoundBookmark : IBoundPresentation, IDialog {

    public CatalogedBookmark CatalogedBookmark => Bound as CatalogedBookmark;

    public virtual GuiDialog Dialog(Gui gui) => (gui as EverythingMaui).DialogBoundBookmark;

    public override IFieldIcon Type => FieldIcons.Bookmark(Uri);


    public virtual CatalogedBookmark Convert() {
        var result = new CatalogedBookmark() {
            Uid = Udf.Nonce()
            };

        ReadBound();
        return result;
        }

    public static BoundBookmark Factory(CatalogedBookmark entry) {
        var result = new BoundBookmark() {
            Bound = entry
            };
        result.ReadBound();
        return result;

        }

    public virtual void ReadBound() {


        Uri = CatalogedBookmark.Uri;
        Title = CatalogedBookmark.Title;
        Path = CatalogedBookmark.Path;
        Description = CatalogedBookmark.Description;
        }

    public virtual void SetBound() {

        CatalogedBookmark.Title = Title;
        CatalogedBookmark.Path = Path;
        }

    }



#endregion
#region // Binding to classes specified in the Mesh schema

/// <summary>
/// Extends <see cref="CatalogApplication"/> to override the <see cref="Intern"/> method
/// so as to allow the bound selection boxes to be updated.
/// </summary>
public class GuigenCatalogBookmark : CatalogBookmark {

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
        new GuigenCatalogBookmark(directory, storeId, policy, cryptoParameters, keyCollection,
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
    public GuigenCatalogBookmark(
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

public partial class BookmarkSelection : SelectionCatalog<GuigenCatalogBookmark,
            CatalogedBookmark, BoundBookmark> {

    /// <summary>
    /// Constructor returning an instance of the selection data backer bound to the 
    /// catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog"></param>
    public BookmarkSelection(ContextAccount contextAccount,
                GuigenCatalogBookmark catalog) : base(contextAccount, catalog) {
        }

    #region // Conversion overrides
    //public override CatalogedBookmark CreateFromBindable(IBindable input) =>
    //    (input as BoundBookmark)?.Convert();

    public override BoundBookmark ConvertToBindable(CatalogedBookmark input) {
        switch (input) {
            case CatalogedFeed feed: {
                return BoundFeed.Factory(feed);
                }
            default: {
                return BoundBookmark.Factory(input);
                }
            }
        }

    public override CatalogedBookmark UpdateWithBindable(IBindable entry) {
        var binding = entry as BoundBookmark;
        binding.ReadBound();
        return binding.Bound as CatalogedBookmark;
        }

    #endregion


    }


#endregion