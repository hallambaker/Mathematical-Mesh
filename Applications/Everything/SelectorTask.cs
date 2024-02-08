﻿using Goedel.Cryptography.Dare;

using System.Threading;
using System.Xml.Linq;

namespace Goedel.Everything;

#region // Bindings to classes specified through the Guigen schema.

// Documented in Guigen output
public partial class TaskSection : IHeadedSelection {

    IAccountSelector Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    ///<inheritdoc/>
    public GuiBinding SelectionBinding => _BoundTask.BaseBinding;

    /// <summary>
    /// Return an instance bound to the Contacts catalog of the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account whose contacts are to be used.</param>
    public TaskSection(IAccountSelector account =null) {
        Account = account;
        var catalog = ContextUser.GetStore(CatalogTask.Label, create: false) as GuigenCatalogTasks;
        ChooseTask = catalog is null ? null : new TaskSelection(catalog);
        }

    }

// Documented in Guigen output
public partial class BoundTask : IBoundPresentation, IDialog {

    public virtual GuiDialog Dialog(Gui gui) => (gui as EverythingMaui).DialogBoundTask;

    public override IFieldIcon Type => FieldIcons.TaskComplete;
    public virtual CatalogedTask Convert() {
        var result = new CatalogedTask() {
            Title = Title,
            Uid = Udf.Nonce()
            };

        return result;
        }

    public static BoundTask Convert(CatalogedTask entry) {
        var result = new BoundTask() {
            Title = entry.Title
            };

        return result;

        }

    public virtual void Fill() {
        }


    }

#endregion
#region // Binding to classes specified in the Mesh schema

/// <summary>
/// Extends <see cref="CatalogApplication"/> to override the <see cref="Intern"/> method
/// so as to allow the bound selection boxes to be updated.
/// </summary>
public class GuigenCatalogTasks : CatalogTask {

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
                IMeshClient meshClient = null,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) =>
        new GuigenCatalogTasks(directory, storeId, policy, cryptoParameters, keyCollection,
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
    public GuigenCatalogTasks(
                string directory,
                string storeName = null,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) :
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

public partial class TaskSelection : SelectionCatalog<GuigenCatalogTasks,
            CatalogedTask, BoundTask> {

    /// <summary>
    /// Constructor returning an instance of the selection data backer bound to the 
    /// catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog"></param>
    public TaskSelection(GuigenCatalogTasks catalog) : base(catalog) {
        }

    #region // Conversion overrides
    public override CatalogedTask CreateFromBindable(IBindable input) =>
        (input as BoundTask)?.Convert();

    public override BoundTask ConvertToBindable(CatalogedTask input) =>
        BoundTask.Convert(input);

    public override CatalogedTask UpdateWithBindable(IBindable entry) {
        var binding = entry as BoundTask;
        binding.Fill();
        return binding.Bound as CatalogedTask;
        }

    #endregion


    }


#endregion