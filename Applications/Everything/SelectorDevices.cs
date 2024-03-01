using Goedel.Cryptography.Dare;
using Microsoft.UI.Xaml.Documents;

using System.Xml.Linq;

namespace Goedel.Everything;

#region // Bindings to classes specified through the Guigen schema.

// Documented in Guigen output
public partial class DeviceSection : IHeadedSelection {



    IAccountSelector Account { get; }
    ContextUser ContextUser => Account.ContextUser;

    public DeviceSelection DeviceSelection { get; }

    GuigenCatalogDevice Catalog { get; }

    ///<inheritdoc/>
    public override ISelectCollection ChooseDevice { get => DeviceSelection; set { } }

    ///<inheritdoc/>
    public GuiBinding SelectionBinding => _BoundDevice.BaseBinding;

    /// <summary>
    /// Return an instance bound to the Contacts catalog of the account <paramref name="account"/>.
    /// </summary>
    /// <param name="account">The account whose contacts are to be used.</param>
    public DeviceSection(IAccountSelector account=null) {
        Account = account;
        Catalog = ContextUser.GetStore(CatalogDevice.Label, create: false) as GuigenCatalogDevice;
        DeviceSelection = Catalog is null ? null : new DeviceSelection(Catalog);
        }

    public async Task AddAsync(CatalogedDevice entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry);
        await transaction.TransactAsync();

        var bound = BoundDevice.Factory(entry);
        DeviceSelection.Add(bound);
        }


    public async Task UpdateAsync(BoundDevice entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry.CatalogedDevice);
        await transaction.TransactAsync();

        DeviceSelection.Update(entry);
        }


    public async Task DeleteAsync(BoundDevice entry) {

        var transaction = ContextUser.TransactBegin();
        transaction.CatalogUpdate(Catalog, entry.CatalogedDevice);
        await transaction.TransactAsync();

        DeviceSelection.Remove(entry);
        }

    }

// Documented in Guigen output
public partial class BoundDevice : IBoundPresentation, IDialog {
    public virtual GuiDialog Dialog(Gui gui) => (gui as EverythingMaui).DialogBoundDevice;

    public CatalogedDevice CatalogedDevice => Bound as CatalogedDevice;

    public override IFieldIcon Type => FieldIcons.Device(DeviceType);


    public override string Udf => CatalogedDevice.DeviceUdf;

    public static BoundDevice Factory(CatalogedDevice contact) {
        var result = new BoundDevice();
        result.Bound = contact;
        result.ReadBound();
        return result;
        }

    public CatalogedDevice Convert() {
        var result = new CatalogedDevice() {
            };

        SetBound();
        return result;
        }

    public static BoundDevice Convert(CatalogedDevice entry) {
        var description = entry.DeviceDescription;

        var result = new BoundDevice() {
            Bound = entry,
            LocalName = entry.LocalName ?? description?.Name ?? "A Device",
            DeviceType = description ?.Platform,
            Rights = "Admin"
            };
        return result;

        }

    public static BoundTask Factory(CatalogedTask contact) {
        var result = new BoundTask();
        result.Bound = contact;
        result.ReadBound();
        return result;
        }

    public virtual void ReadBound() {
        LocalName = CatalogedDevice.LocalName;
        Description = CatalogedDevice.Description;
        }

    public virtual void SetBound() {

        CatalogedDevice.LocalName = LocalName;
        CatalogedDevice.Description = Description;
        }


    }

#endregion
#region // Binding to classes specified in the Mesh schema

/// <summary>
/// Extends <see cref="CatalogApplication"/> to override the <see cref="Intern"/> method
/// so as to allow the bound selection boxes to be updated.
/// </summary>
public class GuigenCatalogDevice : CatalogDevice {

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
        new GuigenCatalogDevice(directory, storeId, meshClient, policy, cryptoParameters, keyCollection,
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
    public GuigenCatalogDevice(
                string directory,
                string storeName = null,
                IMeshClient meshClient = null,
                DarePolicy policy = null,
                CryptoParameters cryptoParameters = null,
                IKeyCollection keyCollection = null,
                bool decrypt = true,
                bool create = true,
                byte[] bitmask = null) :
        base(directory, storeName ?? Label, meshClient,
                    policy, cryptoParameters, keyCollection,
                    decrypt: decrypt, create: create, bitmask: bitmask) {
        }

    public override void Intern(SequenceIndexEntry indexEntry) {
        base.Intern(indexEntry);
        }



    }


#endregion


#region // Selection Catalog backing type.

public partial class DeviceSelection : SelectionCatalog<GuigenCatalogDevice,
            CatalogedDevice, BoundDevice> {

    /// <summary>
    /// Constructor returning an instance of the selection data backer bound to the 
    /// catalog <paramref name="catalog"/>.
    /// </summary>
    /// <param name="catalog"></param>
    public DeviceSelection(GuigenCatalogDevice catalog) : base(catalog) {
        }

    #region // Conversion overrides
    //public override CatalogedDevice CreateFromBindable(IBindable contact) =>
    //    (contact as BoundDevice)?.Convert();

    public override BoundDevice ConvertToBindable(CatalogedDevice input) => BoundDevice.Convert(input);
    #endregion

    public override CatalogedDevice UpdateWithBindable(IBindable entry) {
        var binding = entry as BoundDevice;
        binding.SetBound();
        return binding.Bound as CatalogedDevice;
        }
    }


#endregion